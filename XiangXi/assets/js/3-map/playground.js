'use strict';

function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

require(['vue', 'jquery', 'cmodules', 'amap'], function (Vue, $) {
    Vue.filter('json', function (val) {
        return JSON.stringify(val);
    });
    $(document).ready(function () {
        var request = GetRequest() || { data: JSON.stringify({ address: '摄像头' }) };
        if (!request || !request.data) {
            alert('error');
            return;
        }
        var data = JSON.parse(decodeURIComponent(request.data));
        var address = data.address;
        AMap.Marker.prototype.openWindow = function (content) {
            var map = this.getMap();
            var position = this.getPosition();
            position = [position.lng, position.lat];
            var w = new AMap.InfoWindow({
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
            var vm = new Vue(_defineProperty({
                mounted: function mounted() {
                    this.bind();
                    this.init();
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
                    pin: function pin(sr) {
                        sr.marker.setMap(this.map);
                        this.map.panTo(sr.position);
                    },

                    search: function search() {
                        //$.mapSearch(this.search_key_word, res=> {
                        //    console.log(res);
                        //})
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
                                            "POIAddress": ent.name,
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
                    init: function init() {
                        var center = data.lnglat || [120.511928, 31.252379];
                        $.print('load current position ' + JSON.stringify(center));
                        var zoom = data.zoom || 20;
                        $.print('load current zoom ' + JSON.stringify(zoom));
                        var map = this.map = new AMap.Map('container', {
                            resizeEnable: true,
                            zoom: zoom,
                            layers: [new AMap.TileLayer.Satellite()],
                            center: center
                        });
                        if(resp.total===1){
                            if(!this.markers)this.markers = [];
                            this.markers.push(resp.rows[0])
                        }
                        var thiz = this;
                        var ord = 0;
                        this.state = 'review';
                        var clickListener = AMap.event.addListener(thiz.map, "click", function (e) {
                            $.print('click point ' + JSON.stringify(e.lnglat) + ' ' + thiz.state);
                            if (thiz.markers && thiz.state === 'editmarker') {
                                if (ord === 0) ord = thiz.markers.length;
                                thiz.markers.push({
                                    "POIAddress": thiz.address,
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
                                    "POIAddress": thiz.address,
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

                        //var map = this.map = new AMap.Map('container', {
                        //    resizeEnable: true,
                        //    zoom: 11,
                        //    center: [116.397428, 39.90923]
                        //})
                    },
                    clean: function clean() {
                        this.search_result_list = [];
                    },
                    left_search: function left_search(label) {
                        var thiz = this;
                        var searchResultList = [{
                            id: 1,
                            label: "苏州相城白金汉爵大酒店",
                            stars: 5,
                            tel: "0512-66158888",
                            addr: "江苏省苏州市相城区相城大道1111号",
                            position: [116.397428, 39.90923]
                        }, {
                            id: 1,
                            label: "苏州相城白金汉爵大酒店",
                            stars: 4,
                            tel: "0512-66158888",
                            addr: "江苏省苏州市相城区相城大道1111号",
                            position: [116.397428, 39.90923]
                        }, {
                            id: 1,
                            label: "苏州相城白金汉爵大酒店",
                            stars: 3,
                            tel: "0512-66158888",
                            addr: "江苏省苏州市相城区相城大道1111号",
                            position: [116.397428, 39.90923]
                        }];
                        var dict = {
                            监控: 'jiank', 楼栋: 'cangf', 关爱: 'canji', 党员: 'dangyuan', 老人: 'laonian'
                        };
                        thiz.map.clearMap();
                        $.each(searchResultList, function (i, row) {
                            var marker = new AMap.Marker({
                                position: row.position,
                                map: thiz.map,
                                title: row.label,
                                icon: '../assets/i/mapicon/' + (dict[label] || 'cangf') + '.png'
                            });
                            marker.setMap(thiz.map);
                            row.marker = marker;
                        });
                        thiz.map.panTo(searchResultList[0].position);
                        return this.search_result_list = searchResultList;
                    },

                    bind: function bind() {
                        var data = this.$data;
                        data.polygons = [];
                        data.markers = [];
                        $.each(resp.rows.groupby('POIAddress'), function (k, v) {
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
                                this.POIAddress = name;
                                this.id = null;
                                results.push(this);
                            });
                        });
                        return results;
                    },
                    delete: function _delete(markers, i) {},
                    editpoint: function editpoint() {
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
                        var thiz = this;
                        $.call('savepoilist', this.markers.concat(this.polygon2save()).concat([{
                            POIAddress: address
                        }]).map(function (data) {
                            return $.select(data, ['id', 'Latitude', 'Longitude', 'POIAddress', 'ord']);
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
                        let map = thiz.map;
                        map.clearMap();
                        $.each(this.markers, function (k,v) {
                            var lnglat = [v.Longitude, v.Latitude];
                            let title = v.POIAddress;
                            var marker = new AMap.Marker({
                                map: thiz.map,
                                position: lnglat,
                                title: title,
                                // draggable: true,
                                // content: '<div class="marker-route marker-marker-bus-from"></div>' //自定义点标记覆盖物内容
                            });
                            marker.setMap(thiz.map);
                            marker.on('click', function (e) {
                                //在左边加载点位详情
                                this.openWindow('<p>'+ this.getTitle()+'</p>');
                            });
                            marker.openWindow('<p>'+ title+'</p>')
                            thiz.map.panTo(lnglat);
                            v.marker = marker;
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
                                //this.openWindow('<iframe frameborder="0" src="../2_map/inner_population.html?address=' + this.getTitle() + '" width="500" height="500"></iframe>');
                            });
                            thiz.map.setFitView();
                            thiz.map.panTo(center);
                        });
                    },
                    panTo: function panTo(marker, index) {
                        this.address = marker.POIAddress;
                        //if (marker.marker) marker.marker.openWindow('<iframe frameborder="0" src="../2_map/inner_population.html?address=' + marker.marker.getTitle() + '" width="500" height="500"></iframe>');
                        if (marker.center) this.map.panTo(marker.center);
                    },
                    editorswitch: function editorswitch() {
                        this.state.switch = !this.state.switch;
                    }
                }
            }, 'data', {
                svcHeader: svcHeader,
                search_key_word: "",
                search_result_list: []
            })).$mount('#app');
        });
    });
});

//# sourceMappingURL=playground.js.map
