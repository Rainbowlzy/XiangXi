window.SZMAP_KEY = {};window.SZMAP_KEY = "88f8a64ea9e0e9f48cf0d24aa0d2a8d7";
var mapUtil = {
    mapType: 0,
    MAP_TYPE_MAP: 0,
    MAP_TYPE_DOM: 1,
    MAP_TYPE_MAP3D: 2,
    baseLayers2D: null,
    overlayLaeyrs2D: null,
    baseLayers3D: null,
    layersControl: null,
    markersLayer: {},
    markersContainer: {},
    buslineLayer: null,
    popup: null,
    map: null,
    panoExitsTag: -1,
    /* 路径规划 */
    segmentPolyline: null,
    polyline: null,
    segmentPolyline: null,
    initialize: function () {
    },
    initMap: function (maptype) {
        try {
            this.baseLayers2D = {
                "电子地图": SZMAPS.tileLayer.SZMAP
            };
            this.baseLayersSatellite = {
                "航拍影像": SZMAPS.tileLayer.SZSATELLITE
            };
            // Overlay layers are grouped
            this.overlayLaeyrs2D = {
                "区划图": SZMAPS.tileLayer.SZCOMMUNITY
            };
            this.overlayLaeyrsSatellite = {
                "区划图": SZMAPS.tileLayer.SZCOMMUNITY,
                "路网": SZMAPS.tileLayer.SZROAD,
                "标注": SZMAPS.tileLayer.SZPOI
            };
            this.baseLayers3D = {
                "三维地图": SZMAPS.tileLayer.SZMAP3D
            };
            if (maptype == 'dom') {
                this.map = SZMAPS.szmap("div_map", {
                    center: [31.29954032620578, 120.62441035426534],
                    zoom: 5,
                    minZoom: 2,
                    zoomControl: false,
                    zoomsliderControl: false,
                    distanceMeasureControl: false,
                    areaMeasureControl: false,
                    continuousWorld: false,
                    layers: [SZMAPS.tileLayer.SZSATELLITE]
                });
                this.layersControl = SZMAPS.control.layers(null, this.overlayLaeyrsSatellite, {
                    collapsed: false
                }).addTo(this.map);
                this.mapType = this.MAP_TYPE_DOM;
            } else if (maptype == 'map3d') {
                this.map = SZMAPS.szmap("div_map", {
                    center: [31.29951, 120.62441],
                    zoom: 9,
                    minZoom: 2,
                    zoomControl: false,
                    zoomsliderControl: false,
                    distanceMeasureControl: false,
                    areaMeasureControl: false,
                    continuousWorld: false,
                    crs: SZMAPS.CRS.EPSG320501,
                    layers: [SZMAPS.tileLayer.SZMAP3D]
                });
                this.layersControl = SZMAPS.control.layers(this.baseLayers3D, null, {
                    collapsed: false
                }).addTo(this.map);
                this.mapType = this.MAP_TYPE_MAP3D;
            } else {
                this.map = SZMAPS.szmap("div_map", {
                    center: [31.31954032620578, 120.62441035426534],
                    zoom: 4,
                    minZoom: 2,
                    zoomControl: false,
                    zoomsliderControl: true,
                    distanceMeasureControl: true,
                    areaMeasureControl: true,
                    continuousWorld: false,
                    layers: [SZMAPS.tileLayer.SZMAP]
                });
                this.layersControl = SZMAPS.control.layers(null, this.overlayLaeyrs2D, {
                    collapsed: false
                }).addTo(this.map);
                this.mapType = this.MAP_TYPE_MAP;
            }

            // {{全屏
            SZMAPS.control.fullscreen({
                position: 'bottomright',
                title: '全屏显示',
                forceSeparateButton: true,
                forcePseudoFullscreen: true
            }).addTo(this.map);
            // }}

//            var miniMap = new SZMAPS.Control.MiniMap(SZMAPS.tileLayer.MINIMAP, {
//                toggleDisplay: true
//            }).addTo(this.map);
//            miniMap._minimize();

            SZMAPS.control.scale({
                imperial: false
            }).addTo(this.map);

            var magnifyingGlass = SZMAPS.magnifyingGlass({
                zoomOffset: 3
            });

            SZMAPS.control.magnifyingglass(magnifyingGlass, {
                forceSeparateButton: true
            }).addTo(this.map);

            return true;
        } catch (e) {
            alert("初始化地图失败，请刷新一下试试！" + e.message);
        }
        return false;
    },
    setMapType: function (mapType) {
        if (this.mapType == mapType) {
            return;
        }
        this.mapType = mapType;
        if (mapType == this.MAP_TYPE_MAP3D) {
            for (var i in this.baseLayers2D) {
                this.map.removeLayer(this.baseLayers2D[i]);
            }
            for (var i in this.overlayLaeyrs2D) {
                this.map.removeLayer(this.overlayLaeyrs2D[i]);
            }
            for (var i in this.baseLayersSatellite) {
                this.map.removeLayer(this.baseLayersSatellite[i]);
            }
            for (var i in this.overlayLaeyrsSatellite) {
                this.map.removeLayer(this.overlayLaeyrsSatellite[i]);
            }
            this.layersControl.removeFrom(this.map);
            var center = this.map.getCenter();
            this.map.options.crs = SZMAPS.CRS.EPSG320501;
            this.map.setView(center);
            this.map._resetView(this.map.getCenter(), this.map.getZoom(), true);
            this.layersControl = SZMAPS.control.layers(this.baseLayers3D).addTo(this.map);
            this.map.addLayer(this.baseLayers3D['三维地图'], false);
        } else if (mapType == this.MAP_TYPE_DOM) {
            for (var i in this.baseLayers2D) {
                this.map.removeLayer(this.baseLayers2D[i]);
            }
            for (var i in this.overlayLaeyrs2D) {
                this.map.removeLayer(this.overlayLaeyrs2D[i]);
            }
            for (var i in this.baseLayers3D) {
                this.map.removeLayer(this.baseLayers3D[i]);
            }
            this.layersControl.removeFrom(this.map);
            var center = this.map.getCenter();
            this.map.options.crs = SZMAPS.CRS.EPSG320500;
            this.map.setView(center);
            this.map._resetView(this.map.getCenter(), this.map.getZoom(), true);
            this.layersControl = SZMAPS.control.layers(null, this.overlayLaeyrsSatellite, {
                collapsed: false
            }).addTo(this.map);
            this.map.addLayer(this.baseLayersSatellite['航拍影像'], false);
        } else {
            // 电子地图
            for (var i in this.baseLayersSatellite) {
                this.map.removeLayer(this.baseLayersSatellite[i]);
            }
            for (var i in this.overlayLaeyrsSatellite) {
                this.map.removeLayer(this.overlayLaeyrsSatellite[i]);
            }
            for (var i in this.baseLayers3D) {
                this.map.removeLayer(this.baseLayers3D[i]);
            }
            this.layersControl.removeFrom(this.map);
            var center = this.map.getCenter();
            this.map.options.crs = SZMAPS.CRS.EPSG320500;
            this.map.setView(center);
            this.map._resetView(this.map.getCenter(), this.map.getZoom(), true);
            this.layersControl = SZMAPS.control.layers(null, this.overlayLaeyrs2D, {
                collapsed: false
            }).addTo(this.map);
            this.map.addLayer(this.baseLayers2D['电子地图'], false);
        }
    },
    showLayer: function (properties) {
        var settings = {
            layerName: "",
            graphicList: null,
            callback: function (markers) {
                return markers;
            },
            onClickEvent: function () {
            }
        };
        $.extend(settings, properties);
        var markers = this.markersContainer[settings.layerName];
        if (!markers) {
            this.addGraphicToLayer(settings);
            this.markersContainer[settings.layerName].on('click', function (e) {
                settings.onClickEvent(e.layer);
            });

        } else {
            for (var i = 0, len = markers.length; i < len; i++) {
                markers[i].show();
            }
        }
        if ($.isFunction(settings.callback)) {
            settings.callback(this.markersContainer[settings.layerName].getLayers());
        }
    },
    hideLayer: function (properties) {
        var settings = {
            layerName: ""
        };
        $.extend(settings, properties);
        if (!settings.layerName) {
            for (var key in this.markersContainer) {
                var markersLayer = this.markersContainer[key];
                if (this.markersContainer[key]) {
                    this.map.removeLayer(markersLayer);
                    this.markersContainer[key] = null;
                    delete this.markersContainer[key];
                }
                //                if (markers) {
                //                    markers = markers.markers;
                //                }
                //                if (markers && markers.length > 0) {
                //                    for (var i = 0, len = markers.length; i < len; i++) {
                //                        markers[i].hide();
                //                    }
                //                }
            }
        } else {
            var markers = this.markersContainer[settings.layerName];
            if (markers && markers.length > 0) {
                for (var i = 0, len = markers.length; i < len; i++) {
                    markers[i].hide();
                }
            }
        }
    },
    addGraphicToLayer: function (properties) {
        var settings = {
            itemFields: { xField: "x", yField: "y", attributes: "attributes" }
                , graphicList: []//坐标数组列表
                , symbolWidth: 22//图片宽度
                , symbolHeight: 27//图片高度
                , isClusterer: false
                , isBounce: false
                , callback: function () {
                    //回调函数
                }
        };
        $.extend(settings, properties);


        var Markers = [], marker;
        if (settings.isClusterer) {
            cluster = new L.MarkerClusterGroup({
                polygonOptions: {
                    fillColor: '#3887be',
                    color: '#3887be',
                    weight: 2,
                    opacity: 0,
                    fillOpacity: 0
                }
            });
        }
        if (settings.graphicList) {
            for (var i = 0; i < settings.graphicList.length; i++) {
                var item = settings.graphicList[i];
                var xy = { x: item[settings.itemFields.xField], y: item[settings.itemFields.yField] };
                xy = mapUtil.convertCoor(xy.x, xy.y);
                if (item.image) {
                    var myIcon = L.icon({
                        iconUrl: item.image,
                        iconSize: [settings.symbolWidth, settings.symbolHeight],
                        iconAnchor: [14, 4]
                    });
                    marker = L.marker([xy.y, xy.x], { icon: myIcon });

                }
                else if (item.html) {
                    var myIcon = L.divIcon({ className: 'my-div-icon', html: item.html });
                    marker = L.marker([xy.y, xy.x], { icon: myIcon });
                }
                else if (settings.icon) {
                    marker = L.marker([xy.y, xy.x], { icon: settings.icon });
                }
                if (settings.isBounce) {
                    $.extend(marker.options, {
                        bounceOnAdd: true,
                        bounceOnAddOptions: { duration: 1000, height: 100 },
                        bounceOnAddCallback: function () { console.log("done"); }
                    });
                }

                if (item[settings.itemFields.attributes]) {
                    marker.attributes = item[settings.itemFields.attributes];
                }
                else {
                    marker.attributes = item;
                }
                marker.geometry = xy;
                marker.latlng = { lng: xy.x, lat: xy.y };
                Markers.push(marker);
                if (settings.isClusterer) {
                    cluster.addLayer(marker)
                };
            };
            if (!settings.isClusterer) {
                this.markersContainer[settings.layerName] = L.featureGroup(Markers).addTo(this.map);
                this.markersContainer[settings.layerName].markers = Markers;
            }
            else {
                this.markersContainer[settings.layerName] = cluster.addTo(this.map);
            }
        }
    },
    zoomToPoint: function (properties) {
        var settings = {
            x: 0,
            y: 0,
            zoomLevel: this.map.defaultZoomLevel, 
            layerName: null,
            filed: null,
            value: null,
            onClickEvent: null
        };
        $.extend(settings, properties);

        if (settings.x != 0 && settings.y != 0) {
            if (settings.zoomLevel && settings.zoomLevel != 0) {
                this.map.setView(L.latLng(settings.y, settings.x), settings.zoomLevel);
            } else {
                this.map.panTo(L.latLng(settings.y, settings.x));
            }
        }
        if (settings.layerName) {
            var layer;
            if (this.markersContainer[settings.layerName]) {
                layer = this.markersContainer[settings.layerName];
            } else {
                layer = this.markersContainer["all"];
            }
            layer.eachLayer(function (layer) {
                if (layer.attributes[settings.filed] == settings.value) {
                    settings.onClickEvent(layer);
                }
            });
        }
    },
    convertCoor: function (x, y) {
        var bd09togcj02 = coordtransform.bd09togcj02(x, y);
        var gcj02towgs84 = coordtransform.gcj02towgs84(bd09togcj02[0], bd09togcj02[1]);
        return { x: gcj02towgs84[0], y: gcj02towgs84[1] };
    },
    convertArcgisToLeaflet: function (json) {
        var temp = [], entity;
        for (var i = 0; i < json.features.length; i++) {
            entity = {
                "type": "Polygon"
            }
            entity.coordinates = json.features[i].geometry.rings;
            temp.push({ "type": "Feature", properties: json.features[i].attributes, geometry: entity });
        }
        return temp;
    },
    revertCoor: function (x, y) {
        var wgs84togcj02 = coordtransform.wgs84togcj02(x, y);
        var gcj02tobd09 = coordtransform.gcj02tobd09(wgs84togcj02[0], wgs84togcj02[1]);
        return { x: gcj02tobd09[0], y: gcj02tobd09[1] };
    },
    addPoiMarker: function (type, item, onClickEvent) {
        if (this.markersLayer[type] == null) {
            this.markersLayer[type] = new SZMAPS.FeatureGroup();
            this.map.addLayer(this.markersLayer[type]);
        }
        var maker_icon = SZMAPS.icon({
            iconUrl: "images/symbols/icon" + type + ".png",
            iconSize: [39, 50],
            iconAnchor: [10, 28], // 如果以图片的底部中心点为定位点
            popupAnchor: [0, -26]
        });

        var marker = SZMAPS.marker([item.lat, item.lon], {
            icon: maker_icon
        });
        //marker.bindPopup($page.map.infoEventHtml(type, item), {maxWidth:650});
        this.markersLayer[type].addLayer(marker);
        this.markersLayer[type].on('click', function (e) {
            onClickEvent(e.layer);
        });
        marker.type = type;
        return marker;
    },
    addPoiSmallMarker: function (item) {
        // alert(index+":"+index+","+poi.uuid);
        if (this.markersLayer == null) {
            this.markersLayer = new SZMAPS.FeatureGroup();
            this.map.addLayer(this.markersLayer);
        }
        var maker_icon = SZMAPS.icon({
            iconUrl: 'images/marker/mark.png',
            iconSize: [14, 16],
            iconAnchor: [7, 16], // 如果以图片的底部中心点为定位点
            popupAnchor: [0, -16]
        });

        var marker = SZMAPS.marker([item.wgslat, item.wgslng], {
            icon: maker_icon
        });
        marker.bindPopup(this.getPopupContent(item, true));
        this.markersLayer.addLayer(marker);
    },
    addFromMarker: function (name, x, y) {
        if (this.markersLayer == null) {
            this.markersLayer = new SZMAPS.FeatureGroup();
            this.map.addLayer(this.markersLayer);
        }
        var maker_icon = SZMAPS.icon({
            iconUrl: 'images/from.png',
            iconSize: [20, 24],
            iconAnchor: [10, 24], // 如果以图片的底部中心点为定位点
            popupAnchor: [0, -24]
        });

        var marker = SZMAPS.marker([y, x], {
            icon: maker_icon
        });
        marker.bindPopup('<div style="max-width:120px">' + name + '<div>');
        this.markersLayer.addLayer(marker);
    },
    addToMarker: function (name, x, y) {
        if (this.markersLayer == null) {
            this.markersLayer = new SZMAPS.FeatureGroup();
            this.map.addLayer(this.markersLayer);
        }
        var maker_icon = SZMAPS.icon({
            iconUrl: 'images/to.png',
            iconSize: [20, 24],
            iconAnchor: [10, 24], // 如果以图片的底部中心点为定位点
            popupAnchor: [0, -24]
        });

        var marker = SZMAPS.marker([y, x], {
            icon: maker_icon
        });
        marker.bindPopup('<div style="max-width:120px">' + name + '<div>');
        this.markersLayer.addLayer(marker);
    },
    CheckPanoExits: function (item) {// Jquery.js
        var szlon = bus.project(item.wgslng, item.wgslat).x;
        var szlat = bus.project(item.wgslng, item.wgslat).y;
        jQuery.ajax({
            type: 'get', // 可选get,post
            url: 'panoExitsService/soapclient.php', // 这里是接收数据的页面
            data: 'lon=' + szlon + "&lat=" + szlat, // 传给服务器端的数据，多个参数用&连接
            dataType: 'html', // 服务器返回的数据类型 可选XML ,Json jsonp script
            // html text等
            beforeSend: function (request) {

            },
            success: function (result) {
                mapUtil.panoExitsTag = result;
                if (mapUtil.panoExitsTag == 1) {
                    var popupContent = '<a>' + item.title + '</a><a onclick="mapUtil.turnToPano(\'' + szlon + "\'," + '\'' + szlat + '\')"><img src="images/streetview.gif"></a>';
                    jQuery('#pop_title').html(popupContent);

                }

            },
            error: function () {
            }
        });
    },
    turnToPano: function (szlon, szlat) {
        window.open("http://pano1.map512.cn/ShareApp.html?x=" + szlon + "&y=" + szlat);
    },
    getPopupContent: function (poi, showTabBar) {
        var popupContent = '';
        if (!poi) {
            return popupContent;
        }

        popupContent = '<div id="div_popup" class="popup_window"><div class="popup_title" id="pop_title"><a>' + poi.title + '</a></div>';
        popupContent += '<div class="popup_content"><span class="title2">地址:</span>' + poi.snippet + '</div>';
        if (poi.phone != null && poi.phone != "") {
            popupContent += '<div class="popup_content"><span class="title2">电话:</span>' + poi.phone + '</div>';
        }
        if (showTabBar) {
            popupContent += '<div class="tabContainer" id="tabContainer">';
            popupContent += '<ul style="text-align: center;">';
            popupContent += '<li id="popupTab1" style="width: 90px;"><a href="javascript:void(0)" class="on" onclick="TabPage.switchTab(\'popupTab1\');this.blur();return false;">从这出发</a></li>';
            popupContent += '<li id="popupTab2" style="width: 90px;"><a href="javascript:void(0)" onclick="TabPage.switchTab(\'popupTab2\');this.blur();return false;">到达这里</a></li>';
            popupContent += '<li id="popupTab3" style="width: 90px;"><a href="javascript:void(0)" onclick="TabPage.switchTab(\'popupTab3\');this.blur();return false;">周边查询</a></li>';
            popupContent += '</ul>';

            popupContent += '<div style="height: 20px;"></div>';

            // 从这出发

            popupContent += '<div id="con1" class="content">';
            popupContent += '<input type="hidden" name="fromx" value="' + poi.wgslng + '" />';
            popupContent += '<input type="hidden" name="fromy" value="' + poi.wgslat + '" />';
            popupContent += '<input type="hidden" name="fromName" value="' + poi.title + '" />';
            popupContent += '<input type="hidden" name="fromKeyword" value="' + poi.title + '" />';
            popupContent += '终点：<input style="height: 24px;line-height: 24px;width: 140px; margin-right: 4px;" type="text" value="请输入终点" name="toKeyword" id="toKeyword" onFocus="this.value=\'\';return false;" onkeydown="if(event.keyCode == 13 && this.value != \'\' && this.value != \'请输入终点\') btnFrom.click();" />';

            var busRouteFromURL = "busRoute.php?fromName=" + encodeURI(poi.title) + "&fromKeyword=" + encodeURI(poi.title) + "&fromx=" + bus.project(poi.wgslng, poi.wgslat).x + "&fromy=" + bus.project(poi.wgslng, poi.wgslat).y;
            popupContent += '<input onclick="mapUtil.busRouteFrom(\'' + busRouteFromURL + '\')" class="popupButton" type="button" id="btnBusFrom" value="公交" />';

            var routingFromURL = "routing.php?fromName=" + encodeURI(poi.title) + "&fromKeyword=" + encodeURI(poi.title) + "&fromx=" + poi.wgslng + "&fromy=" + poi.wgslat;
            popupContent += '<input onclick="mapUtil.routingFrom(\'' + routingFromURL + '\')" class="popupButton" type="button" id="btnRouteFrom" value="驾车" />';
            popupContent += '</div>';

            // 到这里去
            popupContent += '<div id="con2" class="content" style="display: none">';
            popupContent += '<input type="hidden" name="tox" value="' + poi.wgslng + '" />';
            popupContent += '<input type="hidden" name="toy" value="' + poi.wgslat + '" />';
            popupContent += '<input type="hidden" name="toName" value="' + poi.title + '" />';
            popupContent += '<input type="hidden" name="toKeyword" value="' + poi.title + '" />';
            popupContent += '起点：<input style="height: 24px;line-height: 24px;width: 140px; margin-right: 4px; vertical-align: middle;" type="text" value="请输入起点" name="fromKeyword" id="fromKeyword" onFocus="this.value=\'\';return false;" onkeydown="if(event.keyCode == 13 && this.value != \'\' && this.value != \'请输入起点\') btnFrom.click();" />';
            var busRouteToURL = "busRoute.php?toName=" + encodeURI(poi.title) + "&toKeyword=" + encodeURI(poi.title) + "&tox=" + bus.project(poi.wgslng, poi.wgslat).x + "&toy=" + bus.project(poi.wgslng, poi.wgslat).y;
            popupContent += '<input onclick="mapUtil.busRouteTo(\'' + busRouteToURL + '\')" class="popupButton" type="button" id="btnBusFrom" value="公交" />';

            var routingToURL = "routing.php?toName=" + encodeURI(poi.title) + "&toKeyword=" + encodeURI(poi.title) + "&tox=" + poi.wgslng + "&toy=" + poi.wgslat;
            popupContent += '<input onclick="mapUtil.routingTo(\'' + routingToURL + '\')" class="popupButton" type="button" id="btnRouteFrom" value="驾车" />';
            popupContent += '</div>';

            // 周边查询
            var aroundURL = "searchAround.php?centerx=" + poi.wgslng + "&centery=" + poi.wgslat + "&centerKeyword=" + poi.title;
            popupContent += '<div id="con3" class="content" style="display: none">';
            popupContent += '<table style="vertical-align: middle;"><tr>';
            popupContent += '<td><select style="height: 24px;line-height: 24px; width: 80px; margin:0px 2px;" name="radius" id="radius"><option value="1000">1000米</option><option value="2000" selected="selected">2000米</option><option value="3000">3000米</option><option value="5000">5000米</option></select></td>';
            popupContent += '<td><input style="width: 140px; height: 24px;line-height: 24px; margin:0px 2px; vertical-align: middle;" type="text" name="aroundKeyword" id="aroundKeyword" value="请输入关键字" onFocus="this.value=\'\';return false;" onkeydown="if(event.keyCode == 13) btnAround.click();" /></td>';
            popupContent += '<td><input style="height: 24px; width: 40px; margin:0px 2px;" type="button" id="btnAround" value="查询" onclick="mapUtil.searchAround(\'' + aroundURL + '\')" /></td>';
            popupContent += '</tr></table>';

            popupContent += '<div class="link">';
            popupContent += '<table style="vertical-align: middle;margin-left: 4px;">';
            popupContent += '<tr><td>';
            popupContent += '<div style="margin:8px 4px;"><a href="javaScript:void(0)" onclick="mapUtil.searchAround2(\'' + aroundURL + '\',\'酒店\')">酒店</a>';
            popupContent += ' | <a href="javaScript:void(0)" onclick="mapUtil.searchAround2(\'' + aroundURL + '\',\'银行\')">银行</a>';
            popupContent += ' | <a href="javaScript:void(0)" onclick="mapUtil.searchAround2(\'' + aroundURL + '\',\'KTV\')">KTV</a>';
            popupContent += ' | <a href="javaScript:void(0)" onclick="mapUtil.searchAround2(\'' + aroundURL + '\',\'饭店\')">餐饮</a>';
            popupContent += ' | <a href="javaScript:void(0)" onclick="mapUtil.searchAround2(\'' + aroundURL + '\',\'医院\')">医院</a>';
            popupContent += ' | <a href="javaScript:void(0)" onclick="mapUtil.searchAround2(\'' + aroundURL + '\',\'超市\')">超市</a>';
            popupContent += ' | <a href="javaScript:void(0)" onclick="mapUtil.searchAround2(\'' + aroundURL + '\',\'商场\')">商场</a>';
            popupContent += '</div></td></tr>';
            popupContent += '</table>';
            popupContent += '</div>';

            popupContent += '</div>';

            popupContent += '</div>';
        }
        popupContent += '</div>';
        return popupContent;
    },
    routingFrom: function (url) {
        window.location.href = url + "&toKeyword=" + encodeURI(document.getElementById('toKeyword').value);
    },
    routingTo: function (url) {
        window.location.href = url + "&fromKeyword=" + encodeURI(document.getElementById('fromKeyword').value);
    },
    drawPath: function (path) {
        this.pathSearchResult = path;
        var coordArray = new Array();
        for (var i = 0; i < path.geometry.coordinates.length; i++) {
            var coord = path.geometry.coordinates[i];
            coordArray.push(new Array(coord[1], coord[0]));
        }
        if (this.polyline) {
            this.polyline.setLatLngs(coordArray);
        } else {
            this.polyline = SZMAPS.polyline(coordArray, {
                color: 'blue'
            }).addTo(this.map);
        }
        // zoom the map to the polyline
        this.map.fitBounds(this.polyline.getBounds());
    },
    drawSegment: function (index) {
        try {
            var seg = this.pathSearchResult.instructions[index];
            var interval0 = seg.interval[0];
            var interval1 = seg.interval[1];
            if (interval0 == interval1) {
                // 单个点
            } else {
                var coordArray = new Array();
                for (var i = interval0; i < interval1; i++) {
                    var coord = this.pathSearchResult.geometry.coordinates[i];
                    coordArray.push(new Array(coord[1], coord[0]));
                }
				
				
				alert(JSON.stringify(coordArray));
				
				
                if (this.segmentPolyline) {
                    this.segmentPolyline.setLatLngs(coordArray);
                } else {
                    this.segmentPolyline = SZMAPS.polyline(coordArray, {
                        color: 'red'
                    }).addTo(this.map);
                }
                this.map.fitBounds(this.segmentPolyline.getBounds());
            }
        } catch (e) {
            alert('绘制路径出错');
        }
    },
    busRouteFrom: function (url) {
        window.location.href = url + "&toKeyword=" + encodeURI(document.getElementById('toKeyword').value);
    },
    busRouteTo: function (url) {
        window.location.href = url + "&fromKeyword=" + encodeURI(document.getElementById('fromKeyword').value);
    },
    searchAround: function (url) {
        window.location.href = url + "&aroundKeyword=" + encodeURI(document.getElementById('aroundKeyword').value) + "&radius=" + document.getElementById('radius').value;
    },
    searchAround2: function (url, aroundKeyword) {
        window.location.href = url + "&radius=3000&aroundKeyword=" + aroundKeyword;
    },
    clearOverlay: function () {
        // alert('clear overlay');
        if (this.popup) {
            this.map.closePopup(this.popup);
            this.popup = null;
        }
        if (this.markersLayer) {
            this.map.removeLayer(this.markersLayer);
            this.markersLayer = null;
        }
        if (this.buslineLayer) {
            this.map.removeLayer(this.buslineLayer);
            this.buslineLayer = null;
        }
    },
    fitBounds: function (eminx, eminy, emaxx, emaxy) {
        // alert(eminx+","+eminy+","+emaxx+","+emaxy);
        this.map.fitBounds([[eminy, eminx], [emaxy, emaxx]]);
    },
    removePopup: function () {
        if (this.popup) {
            this.map.closePopup(this.popup);
            this.popup = null;
        }
    }
};
