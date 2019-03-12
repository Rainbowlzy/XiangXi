/**
 * Created by rainb on 2018/5/24.
 */
define(['vue', 'echarts', 'bootstrap', 'amap', 'cmodules'], function () {

    function loadmap() {

        var poi = {
            "PAddress": '厂房1',
            "Latitude": null,
            "Longitude": null,
            "IsDeleted": null
        };


        var point = [119.042806, 32.146854]
        var request = GetRequest();
        if (request.lnglat)
            var lnglat = JSON.parse(request.lnglat);
        if (request.zoom)
            var zoom = JSON.parse(request.zoom);
        if (request.markers)
            var markers = JSON.parse(request.markers);
        var satellite = new AMap.TileLayer.Satellite();
        var roadNet = new Amap.TileLayer.RoadNet();
        var map = new AMap.Map('amap', {
            //resizeEnable: true,
            zoom: zoom || 15,
            layers:[
                satellite,
                roadNet
            ],
            center: lnglat || point
        });
        map.plugin(["AMap.ToolBar"], function () {
            map.addControl(new AMap.ToolBar());
        });
        map.plugin(["AMap.Scale"], function () {
            map.addControl(new AMap.Scale());
        });
        map.plugin(["AMap.Geolocation"], function () {
            map.addControl(new AMap.Geolocation());
        });

        $('#Clear_Marker').click(function () {
            map.clearMap();
        })
        function drawpoint(map, position, title, link) {
            var marker = new AMap.Marker({
                map: map,
                position: position,
                title: title
            });
            marker.setMap(map)
            marker.on('click', function (e) {
                new AMap.InfoWindow({
                    content: '<iframe src="' + (link || '../2_map/CGcard.html') + '" width="400" height="250" frameborder="no" border="0"   marginheight="0" scrolling="no" allowtransparency="yes"/>'
                }).open(map, e.lnglat)
                current = e.lnglat;
                current.lat += 0.004
                map.panTo(current)
            })
        }

        function showpoints(key, subkey) {
            map.clearMap();
            return;
            if (key && subkey) {
                $.each(pointdata[key][subkey], function () {
                    drawpoint(map, this, subkey)
                })
                return;
            }
            $.each(pointdata[key], function () {
                $.each(this, function () {
                    drawpoint(map, this, key)
                })
            })
        }

        $('#collapseOne > div > ul > li > a').click(function () {
            var subkey = $(this).text();
            showpoints('城管问题', subkey);
        })
        $('#problem2 > div > ul > li > a').click(function () {
            var subkey = $(this).text();
            showpoints('环卫问题', subkey);
        })
        $("#accordion > div > div.panel-heading > h4").click(function () {
            var key = $(this).find("a").text();
            showpoints(key)
        })
        var arr = [];
        var clickListener = AMap.event.addListener(map, "click", function (e) {
            arr.push(e.lnglat);
            $.print(arr);
            new AMap.Marker({
                position: e.lnglat,
                map: map
            })
        }); //绑定事件，返回监听对象
        //AMap.event.removeListener(clickListener); //移除事件，以绑定时返回的对象作为参数


        function refresh() {
            var boxes = document.getElementsByTagName('input');
            var features = [];
            for (var i = 0; i < boxes.length; i += 1) {
                if (boxes[i].checked === true) {
                    features.push(boxes[i].name);
                }
            }
            map.setFeatures(features);
        }

        showpoints('全部')
    }

    $(function () {
        setTimeout(function () {
            loadmap()
        }, 500)
    })
    return {};
    //setTimeout(loadmap,500)
})
