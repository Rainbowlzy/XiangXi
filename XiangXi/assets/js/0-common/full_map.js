'use strict';

require(['vue', 'jquery', 'cmodules', 'amap'], function (Vue, $) {
    Vue.filter('json', function (val) {
        return JSON.stringify(val);
    });
    $(document).ready(function urlborder() {
        $('#m6').on("click", function () {
            alert("该模块还在开发中！");
        });
        var request = GetRequest() || { data: JSON.stringify({ address: '摄像头' }) };
        if (!request || !request.data) {
            alert('error');
            return;
        }
        var data = JSON.parse(decodeURIComponent(request.data));

        console.log(data)
        var address = data.address;
        AMap.Marker.prototype.openWindow = function (content) {
            var map = this.getMap();
            var position = this.getPosition();
            position = [position.lng, position.lat];
            var w = new AMap.InfoWindow({
                //                                        content: '<iframe src="' + (link || '../2_map/CGcard.html') + '" width="400" height="250" frameborder="no" border="0"   marginheight="0" scrolling="no" allowtransparency="yes"/>'
                content: content || '<iframe frameborder="0" src="../2_map/inner_population.html?address=' + this.getTitle() + '" width="400" height="500"></iframe>',
                showShadow: true
            });
            w.open(map, position);
            map.panTo(position);
        };
        var row2point = function row2point(e) {
            return [parseFloat(e.Longitude), parseFloat(e.Latitude)];
        };
        $.call('getpoilist', { search: data.address, limit: 4000, order: 'ord' }, function (resp) {
            data.markers = [];
            data.polygons = [];
            data.resp = resp;
            var vm = new Vue({
                mounted: function mounted() {
                    this.bind();
                    var center = data.lnglat || [120.511928, 31.252379];
                    $.print('load current position ' + JSON.stringify(center));
                    var zoom = data.zoom || 20;
                    $.print('load current zoom ' + JSON.stringify(zoom));
                    this.map = new AMap.Map('amap', {
                        zoom: zoom,
                        layers: [new AMap.TileLayer.Satellite()],
                        center: center
                    });
                    var thiz = this;
                    var ord = 0;
                    this.state = 'review';
                    var clickListener = AMap.event.addListener(thiz.map, "click", function (e) {
                        $.print('click point ' + JSON.stringify(e.lnglat) + ' ' + thiz.state);
                        if (thiz.markers && thiz.state === 'editmarker') {
                            if (ord === 0) ord = thiz.markers.length;
                            thiz.markers.push({
                                "PAddress": thiz.address,
                                "Latitude": e.lnglat.lat,
                                "Longitude": e.lnglat.lng,
                                "ord": ++ord
                            });
                        }
                        if (thiz.polygons && thiz.state === 'editpolygon') {
                            var polygons = thiz.polygons.filter(function (e) {
                                return e.name === thiz.address;
                            });
                            var polygon = polygons[0];
                            if (polygons.length === 0) {
                                thiz.polygons.push(polygon = {
                                    name: thiz.address,
                                    points: []
                                });
                            }
                            if (ord === 0) ord = polygon.points.length;
                            polygon.points.push({
                                "PAddress": thiz.address,
                                "Latitude": e.lnglat.lat,
                                "Longitude": e.lnglat.lng,
                                "ord": ++ord
                            });
                            polygon.center = $.calcCenter(polygon.points.map(function (e) {
                                return [parseFloat(e.Longitude), parseFloat(e.Latitude)];
                            }));
                            var marker = new AMap.Marker({
                                map: thiz.map,
                                position: [e.lnglat.lng, e.lnglat.lat],
                                title: name + ord
                            });
                        }
                    });
                    this.paintMarkers();
                },
                data: data,
                watch: {
                    markers: {
                        handler: function handler(val, oldval) {
                            return this.paintMarkers();
                        },
                        deep: true
                    },
                    polygons: {
                        handler: function handler(val, oldval) {
                            return this.paintMarkers();
                        },
                        deep: true
                    }
                },
                methods: {
                    search: function search() {
                        var c = this;
                        var address = this.address;
                        $.call('getpoilist', { search: address }, function (resp) {
                            c.resp = resp;

                            console.log(resp);
                            $.mapSearch(address, function (result) {
                                // 搜索成功时，result即是对应的匹配数据
                                if (result.tips) {
                                    var ord = 0;
                                    c.$data.markers = result.tips.filter(function (ent) {
                                        return ent.location;
                                    }).map(function (ent) {
                                        return {
                                            "PAddress": ent.name,
                                            "Latitude": ent.location.lat,
                                            "Longitude": ent.location.lng,
                                            "ord": ++ord
                                        };
                                    });
                                }
                            });
                            c.bind();
                        });
                    },
                    bind: function bind() {
                        var data = this.$data;
                        data.polygons = [];
                        data.markers = [];
                        $.each(this.resp.rows.groupby('PAddress'), function (k, v) {
                            var points = this;
                            if (points.length > 1) {
                                // 多边形
                                data.polygons.push({
                                    name: k,
                                    points: points
                                });
                            } else {
                                // 单点
                                data.markers.push(points[0]);
                            }
                        });
                    },
                    polygon2save: function polygon2save() {
                        var results = [];
                        $.each(this.polygons, function () {
                            var name = this.name;
                            $.each(this.points, function () {
                                this.PAddress = name;
                                this.id = null;
                                results.push(this);
                            });
                        });
                        return results;
                    },
                    delete: function _delete(markers, i) {},
                    editpoint: function editpoint() {
                        debugger;
                        $("#address").attr("readonly", false);
                        if (this.address.indexOf('#') === -1) this.address += '#';
                        this.state = this.state === 'editmarker' ? 'review' : 'editmarker';
                    },
                    editpolygon: function editpolygon() {
                        $("#address").attr("readonly", false);
                        if (this.address.indexOf('#') === -1) this.address += '#';
                        this.state = this.state === 'editpolygon' ? 'review' : 'editpolygon';
                    },
                    save: function save() {
                        debugger;
                        var thiz = this;
                        $.call('savepoilist', this.markers.concat(this.polygon2save()).concat([{
                            PAddress: this.address
                        }]).map(function (data) {
                            return $.select(data, ['id', 'Latitude', 'Longitude', 'PAddress', 'ord']);
                        }, function (result) {
                            alert(result.message);
                            location.reload();
                        }));
                    },
                    refresh: function refresh() {
                        var vm = this;
                        location.reload();
                    },
                    paintMarkers: function paintMarkers() {
                        var thiz = this;
                        this.map.clearMap();
                        $.each(this.markers, function () {
                            var ent = {
                                "PAddress": ent.name,
                                "Latitude": ent.position.lat,
                                "Longitude": ent.position.lng,
                                "ord": ++ord
                            };
                            var c = this;
                            var lnglat = [this.Longitude, this.Latitude];
                            var marker = new AMap.Marker({
                                map: thiz.map,
                                position: lnglat,
                                title: this.PAddress,
                                draggable: true,
                                content: '<div class="marker-route marker-marker-bus-from"></div>' //自定义点标记覆盖物内容
                            });
                            marker.setMap(thiz.map);
                            marker.on('click', function (e) {
                                this.openWindow('<iframe frameborder="0" src="../2_map/inner_population.html?address=' + this.getTitle() + '" width="500" height="500"></iframe>');
                            });
                            thiz.map.panTo(lnglat);
                            this.marker = marker;
                        });

                        var name = this.address;
                        var polygons = this.polygons;
                        $.each(polygons, function () {
                            var cur = this;
                            var points2 = cur.points.map(function (e) {
                                return [parseFloat(e.Longitude), parseFloat(e.Latitude)];
                            });
                            if (points2.length === 0) return;
                            var center = $.calcCenter(points2);
                            var marker = new AMap.Marker({
                                map: thiz.map,
                                position: center,
                                title: this.name
                            });
                            var polygon = new AMap.Polygon({
                                map: thiz.map,
                                fillColor: 'blue',
                                fillOpacity: 0.3,
                                path: points2
                            });
                            var k = 0;
                            marker.on('click', function (e) {
                                this.openWindow('<iframe frameborder="0" src="../2_map/inner_population.html?address=' + this.getTitle() + '" width="500" height="500"></iframe>');
                            });
                            thiz.map.setFitView();
                            thiz.map.panTo(center);
                        });
                    },
                    panTo: function panTo(marker, index) {
                        this.address = marker.PAddress;
                        if (marker.marker) marker.marker.openWindow('<iframe frameborder="0" src="../2_map/inner_population.html?address=' + marker.marker.getTitle() + '" width="500" height="500"></iframe>');
                        if (marker.center) this.map.panTo(marker.center);
                    },
                    editorswitch: function editorswitch() {
                        this.state.switch = !this.state.switch;
                    }
                }
            }).$mount('#app');
        });
    });
});

//# sourceMappingURL=full_map-compiled.js.map