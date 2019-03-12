require(['jquery', 'jquery.cookie', 'bootstrap', 'leaflet', 'leaflet.contextmenu', 'leaflet.MiniMap', 'leaflet.Zoomslider', 'leaflet.fullscreen', 'leaflet.defaultextent', 'leaflet.MarkerCluster',
    'leaflet.draw', 'leaflet.measurecontrol', 'baguetteBox'], function ($) {
        accountCheck('map002');
        loadCommonModule('map');
        $('.collapse').collapse()
        $('#search_list').hide();
        /******************************
        switchType: 0——清空
                    1——人口地图
                    2——农业地图
                    3——特殊人口类型
                    4——鸟瞰模式
                    5——作物分布模式
        districtSwitch: 0——关闭
                        1——开启
        ******************************/
        /*-----------地图初始化-----------*/
        mapCRS();
        var map = L.map('map', {
            center: [31.0848565751, 120.4066879619],
            zoom:17,
            crs: L.CRS.EPSG320500,
            zoomControl: true,
            zoomsliderControl: false,
            fullscreenControl: true,
            fullscreenControlOptions: {
                position: 'topleft'
            },
            defaultExtentControl: true,
            continuousWorld: true,
            contextmenu: true,
            contextmenuWidth: 80,
            contextmenuItems: [
                { text: '东山全图', callback: function () { map.fitBounds([[31.18922, 120.58178], [31.20601, 120.56527]]); } }, '-',
                { text: '放大', callback: function () { map.zoomIn(); } },
                { text: '缩小', callback: function () { map.zoomOut(); } },
              '-',
                {
                    text: '清空', callback: function () {
                        measureLength.setDisable();
                        measureArea.setDisable();
                        L.clearLayers();
                    }
                }
            ]

        });
        var measureLength = new L.Control.measureControl().addTo(map);
        var measureArea = new L.Control.measureAreaControl().addTo(map);
        mapInit(map, 7);
        //定义
        var areaGroup = new L.layerGroup();
        var populationGroup = new L.layerGroup();
        //var populationGroup_List = new L.markerClusterGroup();
        var agricultureGroup = new L.layerGroup();
        var markerGroup = new L.layerGroup();
        var switchType = 1;
        var districtSwitch = 1;
        $.ajax({
            url: SVC_MAP + "/getDistrictCenter",
            type: "GET",
            data: {
                districtID: $.cookie('JTZH_districtID')
            },
            success: function (data) {
                //console.log(data);
                var latlng = new L.LatLng(data.x, data.y);
                map.setView(latlng, 7);
                $.ajax({
                    url: SVC_MAP + "/getMapPopulationBlock",
                    data: {
                        districtID: $.cookie('JTZH_districtID'),
                        centerX: data.x,
                        centerY: data.y,
                        zoomLevel: 7,
                        explorX: 1280,
                        explorY: 800
                    },
                    type: "GET",
                    success: function (data) {
                        console.log(data);
                        if (data.success == true) {
                            var temp = [];
                            var number = "", districtName = "";
                            for (var i in data.data) {
                                switch (data.data[i].districtID) {
                                    case "D10050316": number = 54001;
                                        break;
                                    case "D1005031601": number = 3365;
                                        break;
                                    case "D1005031602": number = 3352;
                                        break;
                                    case "D1005031603": number = 3377;
                                        break;
                                    case "D1005031604": number = 5195;
                                        break;
                                    case "D1005031605": number = 4873;
                                        break;
                                    case "D1005031606": number = 3800;
                                        break;
                                    case "D1005031607": number = 2675;
                                        break;
                                    case "D1005031608": number = 4614;
                                        break;
                                    case "D1005031609": number = 5100;
                                        break;
                                    case "D1005031610": number = 3673;
                                        break;
                                    case "D1005031611": number = 5085;
                                        break;
                                    case "D1005031612": number = 812;
                                        break;
                                    case "D1005031613": number = 7246;
                                        break;
                                    default: number = 0;
                                        break;
                                }
                                var mapBlock = L.marker([data.data[i].x, data.data[i].y], {
                                    icon: L.divIcon({
                                        html: '<div class="block_circle"><div class="spinner"></div><div class="block_circle_number"><h4>' + number + '</h4></div><div class="block_circle_title">' + data.data[i].districtName + '</div></div>'
                                        //html: '<div class="block_circle"><div class="spinner"></div><div class="block_circle_number"><h4>' + data.data[i].number + '</h4></div><div class="block_circle_title">' + data.data[i].districtName + '</div></div>'
                                    })
                                }).addTo(populationGroup);

                                mapBlock.on('click', function (e) {
                                    map.zoomIn()
                                });
                            }
                            map.addLayer(populationGroup);

                            addDistrict();
                        } else {
                            console.warn(data.message);
                        }
                    },
                    error: function () {
                        
                    }
                })
            }, error: function () {
                var latlng = new L.LatLng(31.0848565751, 120.4066879619);
                map.setView(latlng, 7);
            }
        })
        zoomendEvent();
        dragendEvent();
        /*------------人口按钮-------------*/
        $('#map_btn-population').click(function () {
            $('.map_right_nav').animate({ right: '-160px' });
            //$('.map_left_nav').animate({ left: '-160px' });
            $('.map_right_nav').html(
                    '<div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">' +
                         '<div class="panel panel-default">' +
                            '<div class="panel-heading" role="tab" id="heading">' +
                                '<h4 class="panel-title">' +
                                    '<a role="button" type="population" href="#all" aria-expanded="true">' +
                                        '<i class="glyphicon glyphicon-th-large"></i>全部' +
                                    '</a>' +
                                '</h4>' +
                            '</div>' +
                        '</div>' +
                        '<div class="panel panel-default">' +
                            '<div class="panel-heading" role="tab" id="headingOne">' +
                                '<h4 class="panel-title">' +
                                    '<a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">' +
                                        '<i class="glyphicon glyphicon-chevron-right"></i>党员' +
                                    '</a>' +
                                '</h4>' +
                            '</div>' +
                            '<div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">' +
                                '<div class="panel-body">' +
                                    '<ul>' +
                                        '<li><a href="#" type="party" name=1>全部</a></li>' +
                                        '<li><a href="#" type="party" name=2>50年以上党龄</a></li>' +
                                        '<li><a href="#" type="party" name=3>40~50年党龄</a></li>' +
                                        '<li><a href="#" type="party" name=4>30~40年党龄</a></li>' +
                                        '<li><a href="#" type="party" name=5>20~30年党龄</a></li>' +
                                        '<li><a href="#" type="party" name=6>10~20年党龄</a></li>' +
                                        '<li><a href="#" type="party" name=7>0~10年党龄</a></li>' +
                                    '</ul>' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                        '<div class="panel panel-default">' +
                            '<div class="panel-heading" role="tab" id="headingTwo">' +
                                '<h4 class="panel-title">' +
                                    '<a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">' +
                                        '<i class="glyphicon glyphicon-chevron-right"></i>老年人' +
                                    '</a>' +
                                '</h4>' +
                            '</div>' +
                            '<div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">' +
                                '<div class="panel-body">' +
                                    '<ul>' +
                                    '<li><a href="#" type="elderly" name=1>全部（60岁以上）</a></li>' +
                                    '<li><a href="#" type="elderly" name=2>80岁以上</a></li>' +
                                    '<li><a href="#" type="elderly" name=3>70~80岁</a></li>' +
                                    '<li><a href="#" type="elderly" name=4>60~70岁</a></li>' +
                                    '</ul>' +
                               ' </div>' +
                            '</div>' +
                       ' </div>' +
                       ' <div class="panel panel-default">' +
                            '<div class="panel-heading" role="tab" id="headingThree">' +
                               ' <h4 class="panel-title">' +
                                    '<a class="collapsed" type="disabled" role="button" href="#">' +
                                        '<i class="glyphicon glyphicon-chevron-right"></i>残疾人' +
                                    '</a>' +
                               ' </h4>' +
                            '</div>' +
                        '</div>' +
                        ' <div class="panel panel-default">' +
                            '<div class="panel-heading" role="tab" id="headingFour">' +
                               ' <h4 class="panel-title">' +
                                    '<a class="collapsed" type="goodFamily" role="button"  href="#collapseFour">' +
                                        '<i class="glyphicon glyphicon-chevron-right"></i>五好家庭' +
                                    '</a>' +
                               ' </h4>' +
                            '</div>' +
                        '</div>' +
                    '</div>');
            $('.map_right_nav').show();
            $('.map_right_nav').animate({ right: '0px' });
            $('.map_right_nav').find('.panel-group').find('a').click(function () {
                populationTypeSelect(this.type, this.name);
            })
            switchType = 1;
            map.eachLayer(function (layer) {
                //console.log(layer)
                if (!layer._url && layer.options && layer.options.color != "#2194fe") map.removeLayer(layer);
            }, map);
            switchTypeShow();
        })
        /*------------农业按钮-------------*/
        $('#map_btn-agriculture').on('click', function () {
            //$('.map_right_nav').animate({ right: '-200px' });
            //$('.map_right_nav').html(
            //        '<div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">' +
            //             '<div class="panel panel-default">' +
            //                '<div class="panel-heading" role="tab" id="heading_farmLand">' +
            //                    '<h4 class="panel-title">' +
            //                        '<a role="button" href="#all" aria-expanded="true">' +
            //                            '<i class="glyphicon glyphicon-th-large"></i>农田分布' +
            //                        '</a>' +
            //                    '</h4>' +
            //                '</div>' +
            //             '</div>' +
            //            '<div class="panel panel-default">' +
            //                '<div class="panel-heading" role="tab" id="headingOne">' +
            //                    '<h4 class="panel-title">' +
            //                        '<a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">' +
            //                            '<i class="glyphicon glyphicon-chevron-right"></i>作物分布' +
            //                        '</a>' +
            //                    '</h4>' +
            //                '</div>' +
            //                '<div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">' +
            //                    '<div class="panel-body">' +
            //                        '<a href="#" style="padding:3px;" name=1><img src="../assets/i/marker/pangxie.png"></a>' +
            //                        '<a href="#" style="padding:3px;" name=2><img src="../assets/i/marker/chaye.png"></a>' +
            //                        '<a href="#" style="padding:3px;" name=3><img src="../assets/i/marker/yangmei.png"></a>' +
            //                        '<a href="#" style="padding:3px;" name=4><img src="../assets/i/marker/pipa.png"></a>' +
            //                    '</div>' +
            //                '</div>' +
            //            '</div>' +
            //           // '<div class="panel panel-default">' +
            //           //     '<div class="panel-heading" role="tab" id="headingTwo">' +
            //           //         '<h4 class="panel-title">' +
            //           //             '<a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">' +
            //           //                 '<i class="glyphicon glyphicon-chevron-right"></i>老年人' +
            //           //             '</a>' +
            //           //         '</h4>' +
            //           //     '</div>' +
            //           //     '<div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">' +
            //           //         '<div class="panel-body">' +
            //           //             '<ul>' +
            //           //             '<li><a href="#">全部（60岁以上）</a></li>' +
            //           //             '<li><a href="#">80岁以上</a></li>' +
            //           //             '<li><a href="#">70~80岁</a></li>' +
            //           //             '<li><a href="#">60~70岁</a></li>' +
            //           //             '</ul>' +
            //           //        ' </div>' +
            //           //     '</div>' +
            //           //' </div>' +
            //           //' <div class="panel panel-default">' +
            //           //     '<div class="panel-heading" role="tab" id="headingThree">' +
            //           //        ' <h4 class="panel-title">' +
            //           //             '<a class="collapsed" role="button" href="#">' +
            //           //                 '<i class="glyphicon glyphicon-chevron-right"></i>残疾人' +
            //           //             '</a>' +
            //           //        ' </h4>' +
            //           //     '</div>' +
            //           // '</div>' +
            //           // ' <div class="panel panel-default">' +
            //           //     '<div class="panel-heading" role="tab" id="headingFour">' +
            //           //        ' <h4 class="panel-title">' +
            //           //             '<a class="collapsed" role="button"  href="#collapseFour">' +
            //           //                 '<i class="glyphicon glyphicon-chevron-right"></i>五好家庭' +
            //           //             '</a>' +
            //           //        ' </h4>' +
            //           //     '</div>' +
            //           // '</div>' +
            //        '</div>');
            $('.map_right_nav').hide();
            $('.map_right_nav').animate({ right: '-200px' });

            populationGroup.clearLayers();
            switchType = 2;
            markerGroup.clearLayers();
            districtSwitch = 0;
            cleanLayer(map);
            showFarmLand();
            //$('.map_right_nav .btn-group-vertical button').click(function () {
            //    //populationTypeSelect($(this).attr("value"));
            //})
            //$('.map_right_nav').find('a').click(function () {
            //    districtSwitch = 0;
            //    cleanLayer(map);
            //    plantTypeSelect(this.name);
            //})
            //$('.map_right_nav').find('#heading_farmLand').find('a').click(function () {
            //    districtSwitch = 0;
            //    cleanLayer(map);
            //    showFarmLand();
            //})
            //populationGroup.clearLayers();
            //switchType = 2;
            //markerGroup.clearLayers();

        })
        /*------------人口详情-------------*/        /*------------搜索框---------------*/
        $('#map_search_btn').click(function () {
            $('.list-group').html('');
            if ($('#map_search').val() != '') {
                if ($('#map_search_type').val() != 1) {
                    //农业查询
                } else {
                    //人口查询
                    $.ajax({
                        url: SVC_MAP + "/mapSearchPopulation",
                        type: "GET",
                        data: {
                            districtID: $.cookie('JTZH_districtID'),
                            offset: 0,
                            search: $('#map_search').val()
                        },
                        success: function (data) {
                            console.log(data);
                            for (var i in data.rows) {
                                var address = '';
                                if (data.rows[i].address != null) address = data.rows[i].address + "号";
                                $('.list-group').append(
                                    '<a href="#" class="list-group-item" name="' + data.rows[i].id + '">' +
                                        '<h5 class="list-group-item-heading">' + data.rows[i].name + '（' + data.rows[i].IDCard + '）</h4>' +
                                        '<p class="list-group-item-text"><span class="glyphicon glyphicon-map-marker" style="color:#2f94c1"></span>' + address + '</p>' +
                                    '</a>')
                            }
                            //if(data.total)
                            /*------------搜索内容-------------*/
                            $('.list-group-item').click(function () {
                                $.ajax({
                                    url: SVC_MAP + "/mapSearchPopulationDetail",
                                    type: "get",
                                    data: {
                                        id: this.name
                                    },
                                    success: function (data) {
                                        if (data.success == true) {
                                            switchType = 0;
                                            cleanLayer(map);
                                            L.marker([data.data.x, data.data.y], {
                                                riseOnHover: true
                                            }).addTo(map)
                                       .bindPopup(
                                       '<table class="table table-bordered">' +
                                            '<tr><td>姓名</td><td><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data.id + '\')" class="population_detail-open">' + data.data.name + '</a></td><td>身份证</td><td>' + data.data.IDCard + '</td></tr>' +
                                            '<tr><td>政治面貌</td><td>' + data.data.politicsStatus + '</td><td>地址</td><td>' + data.data.address + '</td></tr>' +
                                       '</table>'
                                       , {
                                           minWidth: 400
                                       });
                                            map.setView([data.data.x, data.data.y], 10);
                                        } else {
                                            alert(data.message);
                                        }
                                    },
                                    error: function () {
                                        
                                    }
                                })
                            })
                        }
                    })
                }
                $('#search_list').show();
            } else {
                $('#search_list').hide();
            }

        })
        $('#map_search').keyup(function () {
            if ($('#map_search').val() == '') $('#search_list').hide();
        })
        /*------------缩放事件-------------*/
        function zoomendEvent() {
            map.on('zoomend', function (e) {
                if (districtSwitch == 1) {//控制区域缩放
                    var zoom = map.getZoom();
                    if (zoom < 5) zoom = 6;
                    else if (zoom >= 5 && zoom <= 7) zoom = 7;
                    if (zoom < 10) {
                        map.eachLayer(function (layer) {
                            //console.log(layer)
                            if (!layer._url && layer.options && layer.options.color == "#2194fe" && layer._latlngs.length != 0) map.removeLayer(layer);
                        }, map);
                        $.ajax({
                            url: SVC_MAP + "/getDistrict",
                            type: "GET",
                            data: {
                                districtID: $.cookie("JTZH_districtID"),
                                zoom: zoom
                            },
                            success: function (data) {
                                //console.log(data)
                                if (data.success == true) {
                                    for (var i in data.data) {
                                        var latlngs = new Array();
                                        for (var j in data.data[i].Area) {
                                            latlngs.push(L.latLng(data.data[i].Area[j].x, (data.data[i].Area[j].y)));
                                        }
                                        if (map.getZoom() > 7) {
                                            L.polygon(latlngs, {
                                                color: '#2194fe',
                                                fill: true,
                                                fillColor: getRandomColor(),
                                                fillOpacity: 0.4
                                            }).bindPopup(data.data[i].districtName)
                                                .addTo(map);
                                        } else {
                                            L.polygon(latlngs, {
                                                color: '#2194fe',
                                                fill: true,
                                                fillColor: getRandomColor(),
                                                fillOpacity: 0.4
                                            }).bindPopup(data.data[i].description, {
                                                minWidth: 600
                                            }).on('click', function () {
                                                baguetteBox.run('.gallery', {
                                                    // Custom options
                                                });
                                            }).addTo(map);
                                        }
                                    }
                                } else {
                                    console.warn(data.message);
                                }
                                switchTypeShow();
                            },
                            Error: function () {
                                
                            }
                        })
                    } else {
                        switchTypeShow();
                    }

                } else {
                    switchTypeShow();
                }
            })

        }
        /*------------拖拽事件-------------*/
        function dragendEvent() {
            map.on('dragstart', function (e) {
                if (map.getZoom() >= 11 && switchType == 1) {
                    //显示人口
                    //获取中心点和人数,传递缩放等级和中心点坐标
                    $.ajax({
                        url: SVC_MAP + "/getMapFamily",
                        data: {
                            districtID: $.cookie('JTZH_districtID'),
                            centerX: map.getCenter().lat,
                            centerY: map.getCenter().lng,
                            zoomLevel: map.getZoom(),
                            explorX: map.getSize().x,
                            explorY: map.getSize().y
                        },
                        type: "GET",
                        success: function (data) {
                            populationGroup.clearLayers();//先清空图层
                            //console.log(data);
                            if (data.success == true) {
                                for (var i in data.data) {
                                    this.houseDetail = '<h4>房屋详情</h4>';
                                    this.houseDetail += '<table class="table table-bordered"><tr><td>区域：' + data.data[i].district + '</td><td>门牌号/房号：' + data.data[i].houseNum + '</td></tr></table>';


                                    this.familyList = '<h4>选择家庭</h4>';
                                    this.familyMember = '<div class="tab-content">';
                                    this.familyList += ' <ul class="nav nav-tabs" role="tablist">';

                                    for (var k = 0; k < data.data[i].houseMembers.length; k++) {
                                        //创造标签页，注意第一个家庭需要active标签页
                                        if (k == 0) {
                                            this.familyList += ' <li role="presentation" class="active"><a href="#' + data.data[i].houseMembers[0].bookletNum + '" aria-controls="' + data.data[i].houseMembers[0].bookletNum + '" role="tab" data-toggle="tab">' + data.data[i].houseMembers[0].bookletNum + '</a></li>'
                                            this.familyMember += '<div role="tabpanel" class="tab-pane active" id="' + data.data[i].houseMembers[k].bookletNum + '">';
                                        } else {
                                            this.familyList += '<li role="presentation"><a href="#' + data.data[i].houseMembers[k].bookletNum + '" aria-controls="' + data.data[i].houseMembers[k].bookletNum + '" role="tab" data-toggle="tab">' + data.data[i].houseMembers[k].bookletNum + '</a></li>'
                                            this.familyMember += '<div role="tabpanel" class="tab-pane" id="' + data.data[i].houseMembers[k].bookletNum + '">';
                                        }
                                        this.familyMember += '<h4>家庭成员</h4>';
                                        this.familyMember += '<table class="table table-bordered table-condensed"><tr><th>姓名</th><th>性别</th><th>年龄</th><th>身份证</th><th>与户主关系</th></tr>';
                                        for (var j in data.data[i].houseMembers[k].familyMembers) {
                                            this.familyMember += '<tr><td><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data[i].houseMembers[k].familyMembers[j].id + '\')" class="population_detail-open" id="' + data.data[i].houseMembers[k].familyMembers[j].id + '">' +
                                                data.data[i].houseMembers[k].familyMembers[j].name + '</a></td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].sex + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].age + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].IDCard + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].relationship + '</td></tr>';
                                        }
                                        this.familyMember += '</table>';
                                        this.familyMember += '家庭农田：'
                                        for (var j in data.data[i].houseMembers[k].farmLand) {
                                            this.familyMember += '<button class="map_family_farmLand" name="' + data.data[i].houseMembers[k].farmLand[j].id + '">' + data.data[i].houseMembers[k].farmLand[j].address + '</button>';
                                        }

                                        this.familyMember += '</div>';
                                        $('#' + data.data[i].houseMembers[0].bookletNum + ' a').click(function (e) {
                                            e.preventDefault();
                                            $(this).tab('show')
                                        })
                                    }

                                    this.familyList += '</ul>';
                                    this.familyMember += '</div>';
                                    L.marker([data.data[i].x, data.data[i].y])
                                        .addTo(populationGroup)
                                        .bindPopup(this.houseDetail + this.familyList + this.familyMember, {
                                            minWidth: 500
                                        })
                                    .on('click', function (e) {
                                        console.log(e);
                                        $('.map_family_farmLand').click(function () {
                                            findFarmLand(e.latlng, this.name, map);
                                        })
                                    })
                                    $('#myTabs a').click(function (e) {
                                        e.preventDefault()
                                        $(this).tab('show')
                                    })

                                }
                                map.addLayer(populationGroup);

                            } else {
                                
                            }

                        },
                        error: function () {
                           
                        }
                    })
                }
            })

        }
        /*------------人口查询-------------*/
        function populationSearch() {
            markerGroup.clearLayers();
            populationGroup.clearLayers();
            $.ajax({
                url: SVC_MAP + "/getDistrictCenter",
                type: "GET",
                data: {
                    districtID: $.cookie('JTZH_districtID')
                },
                success: function (data) {
                    console.log(data);
                    var latlng = new L.LatLng(data.x, data.y);
                    map.setView(latlng, 7);
                    $.ajax({
                        url: SVC_MAP + "/getMapPopulationBlock",
                        data: {
                            districtID: $.cookie('JTZH_districtID'),
                            centerX: data.x,
                            centerY: data.y,
                            zoomLevel: 7,
                            explorX: 1280,
                            explorY: 800
                        },
                        type: "GET",
                        success: function (data) {
                            if (data.success == true) {
                                var temp = [];
                                for (var i in data.data) {
                                    var mapBlock = L.marker([data.data[i].x, data.data[i].y], {
                                        icon: L.divIcon({
                                            html: '<div class="block_circle"><div class="spinner"></div><div class="block_circle_number"><h4>' + data.data[i].number + '</h4></div><div class="block_circle_title">' + data.data[i].districtName + '</div></div>'
                                        })
                                    }).addTo(populationGroup);
                                    mapBlock.on('click', function (e) {
                                        map.zoomIn()
                                    });
                                }
                                map.addLayer(populationGroup);
                            } else {
                                console.warn(data.message);
                            }
                        },
                        error: function () {
                           
                        }
                    })
                }, error: function () {
                    var latlng = new L.LatLng(31.0848565751, 120.4066879619);
                    map.setView(latlng, 7);
                }
            })
            switchType = 1;
        }
        /*------------人口类型选择----------*/
        function populationTypeSelect(type, name) {
            populationGroup.clearLayers();
            switchType = 3;
            switch (type) {
                case "population"://基础人口
                    populationSearch();
                    break;
                case "party"://党员
                    $.ajax({
                        url: SVC_MAP + "/getPartyMember",
                        type: "GET",
                        data: {
                            districtID: $.cookie("JTZH_districtID"),
                            type: parseInt(name)
                        },
                        success: function (data) {
                            console.log(data);
                            if (data.success == true) {
                                for (var i in data.data) {
                                    L.marker([data.data[i].x, data.data[i].y], {
                                        icon: L.icon({
                                            iconUrl: '../assets/i/marker/Marker_PartyMember.png',
                                            popupAnchor: [15, 15]
                                        })
                                    }).addTo(populationGroup)
                                        .bindPopup('<div class="row map_party_card">' +
                                        '<div class="col-md-2"><img width=150 src="../upload/portrait/' + data.data[i].name + '.jpg" alt="..." class="img-thumbnail img-circle"></div>' +
                                        '<div class="col-md-10"><dl class="dl-horizontal">' +
                                        '<dt>姓名</dt><dd><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data[i].id + '\')" class="population_detail-open" id="' + data.data[i].id + '">' + data.data[i].name + '</a></dd>' +
                                        '<dt>身份证</dt><dd>' + data.data[i].IDCard + '</dd>' +
                                        '<dt>入党时间</dt><dd>' + data.data[i].joinTime + '</dd>' +
                                        '<dt>党龄</dt><dd>' + data.data[i].partyAge + '年</dd>' +
                                        '<dt>所属支部</dt><dd>' + data.data[i].department + '</dd></dl>' +
                                        '</div>' +
                                        '</div>', {
                                            minWidth: 493,
                                            className: "map_party_card-popup"
                                        })
                                }
                                map.addLayer(populationGroup);
                            } else {
                                console.warn(data.message)
                            }
                        },
                        error: function () {
                           
                        }
                    })
                    break;
                case "elderly"://老人
                    $.ajax({
                        url: SVC_MAP + "/getElderly",
                        type: "GET",
                        data: {
                            districtID: $.cookie("JTZH_districtID"),
                            type: parseInt(name)
                        },
                        success: function (data) {
                            console.log(data);
                            if (data.success == true) {
                                for (var i in data.data) {
                                    L.marker([data.data[i].x, data.data[i].y], {
                                        icon: L.icon({
                                            iconUrl: '../assets/i/marker/Marker_Elderly.png',
                                            popupAnchor: [15, 10]
                                        })
                                    }).addTo(populationGroup)
                                        .bindPopup('<div class="row map_leader_card">' +
                                         '<table class="table  table-bordered  table-hover">' +
                                        '<tr><td class="warning">姓名</td><td><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data[i].id + '\')" class="population_detail-open" id="' + data.data[i].id + '">' + data.data[i].name + '</a></td><td class="warning">身份证</td><td>' + data.data[i].IDCard + '</td></tr>' +
                                        '<tr><td class="warning">年龄</td><td>' + data.data[i].age + '</td><td class="warning">区域</td><td>' + data.data[i].district + '</td></tr>' +
                                        '</table>' +
                                        '</div>')
                                }
                                map.addLayer(populationGroup);
                            } else {
                                console.warn(data.message)
                            }
                        },
                        error: function () {
                             
                        }
                    })
                    break;
                case "disabled"://残疾
                    $.ajax({
                        url: SVC_MAP + "/getMapDisabled",
                        type: "GET",
                        data: {
                            districtID: $.cookie("JTZH_districtID")
                        },
                        success: function (data) {
                            console.log(data);
                            if (data.success == true) {
                                for (var i in data.data) {
                                    L.marker([data.data[i].x, data.data[i].y], {
                                        icon: L.icon({
                                            iconUrl: '../assets/i/marker/Marker_Disabled.png',
                                            popupAnchor: [15, 10]
                                        })
                                    }).addTo(populationGroup)
                                        .bindPopup('<div class="row map_leader_card">' +
                                        '<table class="table  table-bordered  table-hover">' +
                                        '<tr><td class="warning">姓名</td><td><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data[i].id + '\')" class="population_detail-open" id="' + data.data[i].id + '">' + data.data[i].name + '</a></td><td class="warning">身份证</td><td>' + data.data[i].IDCard + '</td></tr>' +
                                        '<tr><td class="warning">残疾证号</td><td>' + data.data[i].disableNum + '</td><td class="warning">性别</td><td>' + data.data[i].sex + '</td></tr>' +
                                        '<tr><td class="warning">残疾等级</td><td>' + data.data[i].disablelevel + '</td><td class="warning">残疾补助</td><td>' + data.data[i].relieffunds + '</td></tr>' +
                                        '<tr><td class="warning">监护人</td><td>' + data.data[i].guardian + '</td></tr>' +
                                        '</table>' +
                                        '</div>', {
                                            minWidth: 500
                                        })
                                }
                                map.addLayer(populationGroup);
                            } else {
                                console.warn(data.message)
                            }
                        },
                        error: function () {
                           
                        }
                    })
                    break;
                case "goodFamily"://和谐家庭
                    $.ajax({
                        url: SVC_MAP + "/getMapHarmoniousFamily",
                        type: "GET",
                        data: {
                            districtID: $.cookie("JTZH_districtID")
                        },
                        success: function (data) {
                            //console.log(data);
                            if (data.success == true) {
                                for (var i in data.data) {
                                    this.houseDetail = '<h4>房屋详情</h4>';
                                    this.houseDetail += '<table class="table table-bordered"><tr><td>区域：' + data.data[i].district + '</td><td>门牌号/房号：' + data.data[i].houseNum + '</td></tr></table>';


                                    this.familyList = '<h4>选择家庭</h4>';
                                    this.familyMember = '<div class="tab-content">';
                                    this.familyList += ' <ul class="nav nav-tabs" role="tablist">';

                                    for (var k = 0; k < data.data[i].houseMembers.length; k++) {
                                        //创造标签页，注意第一个家庭需要active标签页
                                        if (k == 0) {
                                            this.familyList += ' <li role="presentation" class="active"><a href="#' + data.data[i].houseMembers[0].bookletNum + '" aria-controls="' + data.data[i].houseMembers[0].bookletNum + '" role="tab" data-toggle="tab">' + data.data[i].houseMembers[0].bookletNum + '</a></li>'
                                            this.familyMember += '<div role="tabpanel" class="tab-pane active" id="' + data.data[i].houseMembers[k].bookletNum + '">';
                                        } else {
                                            this.familyList += '<li role="presentation"><a href="#' + data.data[i].houseMembers[k].bookletNum + '" aria-controls="' + data.data[i].houseMembers[k].bookletNum + '" role="tab" data-toggle="tab">' + data.data[i].houseMembers[k].bookletNum + '</a></li>'
                                            this.familyMember += '<div role="tabpanel" class="tab-pane" id="' + data.data[i].houseMembers[k].bookletNum + '">';
                                        }
                                        this.familyMember += '<h4>家庭成员</h4>';
                                        this.familyMember += '<table class="table table-bordered table-condensed"><tr><th>姓名</th><th>性别</th><th>年龄</th><th>身份证</th><th>与户主关系</th></tr>';
                                        for (var j in data.data[i].houseMembers[k].familyMembers) {
                                            this.familyMember += '<tr><td><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data[i].houseMembers[k].familyMembers[j].id + '\')" class="population_detail-open" id="' + data.data[i].houseMembers[k].familyMembers[j].id + '">' +
                                                data.data[i].houseMembers[k].familyMembers[j].name + '</a></td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].sex + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].age + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].IDCard + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].relationship + '</td></tr>';
                                        }
                                        this.familyMember += '</table></div>';
                                        $('#' + data.data[i].houseMembers[0].bookletNum + ' a').click(function (e) {
                                            e.preventDefault();
                                            $(this).tab('show')
                                        })
                                    }

                                    this.familyList += '</ul>';
                                    this.familyMember += '</div>';
                                    L.marker([data.data[i].x, data.data[i].y], {
                                        riseOnHover: true
                                    }).addTo(populationGroup)
                                        .bindPopup(this.houseDetail + this.familyList + this.familyMember, {
                                            minWidth: 500
                                        })
                                    $('#myTabs a').click(function (e) {
                                        e.preventDefault()
                                        $(this).tab('show')
                                    })
                                }
                                map.addLayer(populationGroup);
                            } else {
                                console.warn(data.message);
                            }

                        },
                        error: function () {
                            
                        }
                    })
                    break;
            }
        }
        /*------------作物类型选择-----------*/
        function plantTypeSelect(type) {
            if (type != '') {
                switchType = 5;
                map.setView([31.0848565751, 120.4066879619], 6);
                var color = '';
                switch (type) {
                    case '1': color = '#990066';
                        break;
                    case '2': color = '#00FF33';
                        break;
                    case '3': color = '#660066';
                        break;
                    case '4': color = '#CC9933';
                        break;
                }
                $.ajax({
                    url: SVC_MAP + "/getProductArea",
                    type: "GET",
                    data: {
                        type: type
                    },
                    success: function (data) {
                        console.log(data);
                        if (data.success == true) {
                            for (var i in data.data) {
                                var latlngs = new Array();
                                for (var j in data.data[i].area) {
                                    latlngs.push(L.latLng(data.data[i].area[j].x, (data.data[i].area[j].y)));
                                }
                                L.polygon(latlngs, {
                                    color: '#2194ff',
                                    fill: true,
                                    fillColor: color,
                                    fillOpacity: 0.4
                                }).bindPopup(
                                '<div class="row map_product_popup">' +
                                    '<div class="col-md-5">' +
                                        '<div class="thumbnail">' +
                                            '<img src="../assets/i/material/' + data.data[i].imageURL + '" />' +
                                        '</div>' +
                                    '</div>' +
                                    '<div class="col-md-7"><div class="map_product_popup-description">' +
                                        data.data[i].description +
                                    '</div></div>' +
                                '</div>', {
                                    minWidth: 500,
                                }).addTo(map);
                            }
                        } else {
                            console.warn(data.message);
                        }
                    },
                    error: function () {
                        
                    }
                })
            }

        }
        /*------------显示农田-------------*/
        function showFarmLand() {
            $.ajax({
                url: SVC_MAP + "/mapGetFarmLand",
                type: "GET",
                data: {
                    districtID: $.cookie('JTZH_districtID')
                },
                success: function (data) {
                    console.log(data)
                    if (data.success == true) {
                        for (var i in data.data) {
                            var latlngs = new Array();
                            for (var j in data.data[i].area) {
                                latlngs.push(L.latLng(data.data[i].area[j].x, (data.data[i].area[j].y)));
                            }
                            L.polygon(latlngs, {
                                color: '#009933',
                                opacity: 0.5,
                                fill: true,
                                fillColor: "#FFFF00",
                                fillOpacity: 0.7
                            }).bindPopup('<div class="map_farmLand">' +
                            '<table class="table table-bordered">' +
                            '<tr><td class="success">塘口号</td><td>' + data.data[i].farmLandID + '</td><td class="success">塘口位置</td><td>' + data.data[i].address + '</td></tr>' +
                            '<tr><td class="success">作物</td><td>' + data.data[i].product + '</td><td class="success">面积</td><td>' + data.data[i].farmArea + '</td></tr>' +
                            '<tr><td class="success">承包人</td><td>' + data.data[i].name + '</td><td class="success">身份证</td><td>' + data.data[i].IDCard + '</td></tr>' +
                            '<tr><td class="success">电话</td><td>' + data.data[i].phone + '</td></tr>' +
                            '</table>' +
                            '</div>', {
                                minWidth: 500
                            }).addTo(map);
                        }
                    } else {
                        console.warn(data.message);
                    }
                },
                error: function () {
                    
                }
            })
        }


        /*------------叠加区域--------------*/
        function addDistrict() {
            var zoom = map.getZoom();
            if (zoom < 7) zoom = 6;
            $.ajax({
                url: SVC_MAP + "/getDistrict",
                type: "GET",
                data: {
                    districtID: $.cookie("JTZH_districtID"),
                    zoom: zoom
                },
                success: function (data) {
                    if (data.success == true) {
                        console.log(map.getZoom());
                        for (var i in data.data) {
                            var latlngs = new Array();
                            for (var j in data.data[i].Area) {
                                latlngs.push(L.latLng(data.data[i].Area[j].x, (data.data[i].Area[j].y)));
                            }
                            if (map.getZoom() > 7) {
                                L.polygon(latlngs, {
                                    color: '#2194fe',
                                    fill: true,
                                    fillColor: getRandomColor(),
                                    fillOpacity: 0.4
                                }).bindPopup(data.data[i].districtName)
                                .addTo(map);
                            } else {
                                L.polygon(latlngs, {
                                    color: '#2194fe',
                                    fill: true,
                                    fillColor: getRandomColor(),
                                    fillOpacity: 0.4
                                }).bindPopup(data.data[i].description, {
                                    minWidth: 600
                                }).on('click', function () {
                                    baguetteBox.run('.gallery', {
                                        // Custom options
                                    });
                                }).addTo(map);
                            }

                        }
                    } else {
                         
                    }
                },
                Error: function () {
                    
                }
            })
        }
        /*------------根据switchType显示不同类型---------*/
        function switchTypeShow() {
            if (switchType == 1) {
                var zoom = map.getZoom()
                if (zoom == 10) zoom = 9;
                if (zoom < 10) {
                    //6级及以下显示街道区域
                    populationGroup.clearLayers();//先清空图层
                    //populationGroup_List.clearLayers();
                    //获取中心点和人数,传递缩放等级和中心点坐标
                    $.ajax({
                        url: SVC_MAP + "/getMapPopulationBlock",
                        data: {
                            districtID: $.cookie('JTZH_districtID'),
                            centerX: map.getCenter().lat,
                            centerY: map.getCenter().lng,
                            zoomLevel: zoom,
                            explorX: map.getSize().x,
                            explorY: map.getSize().y
                        },
                        type: "GET",
                        success: function (data) {
                            console.log(data);
                            if (data.success == true) {
                                var temp = [];
                                for (var i in data.data) {
                                    if (map.getZoom() <= 7) {
                                        switch (data.data[i].districtID) {
                                            case "D10050316": number = 54001;
                                                break;
                                            case "D1005031601": number = 3365;
                                                break;
                                            case "D1005031602": number = 3352;
                                                break;
                                            case "D1005031603": number = 3377;
                                                break;
                                            case "D1005031604": number = 5195;
                                                break;
                                            case "D1005031605": number = 4873;
                                                break;
                                            case "D1005031606": number = 3800;
                                                break;
                                            case "D1005031607": number = 2675;
                                                break;
                                            case "D1005031608": number = 4614;
                                                break;
                                            case "D1005031609": number = 5100;
                                                break;
                                            case "D1005031610": number = 3673;
                                                break;
                                            case "D1005031611": number = 5085;
                                                break;
                                            case "D1005031612": number = 812;
                                                break;
                                            case "D1005031613": number = 7246;
                                                break;
                                            default: number = 0;
                                                break;
                                        }
                                        var mapBlock = L.marker([data.data[i].x, data.data[i].y], {
                                            icon: L.divIcon({
                                                html: '<div class="block_circle"><div class="spinner"></div><div class="block_circle_number"><h4>' + number + '</h4></div><div class="block_circle_title">' + data.data[i].districtName + '</div></div>'
                                                //html: '<div class="block_circle"><div class="spinner"></div><div class="block_circle_number"><h4>' + data.data[i].number + '</h4></div><div class="block_circle_title">' + data.data[i].districtName + '</div></div>'
                                            })
                                        }).addTo(populationGroup);
                                    } else {
                                        var mapBlock = L.marker([data.data[i].x, data.data[i].y], {
                                            icon: L.divIcon({
                                                //html: '<div class="block_circle"><div class="spinner"></div><div class="block_circle_number"><h4>' + number + '</h4></div><div class="block_circle_title">' + data.data[i].districtName + '</div></div>'
                                                html: '<div class="block_circle"><div class="spinner"></div><div class="block_circle_number"><h4>' + data.data[i].number + '</h4></div><div class="block_circle_title">' + data.data[i].districtName + '</div></div>'
                                            })
                                        }).addTo(populationGroup);
                                    }

                                    mapBlock.on('click', function (e) {
                                        map.zoomIn()
                                    });
                                }
                                map.addLayer(populationGroup);

                            } else {
                                
                            }
                        },
                        error: function () {
                            
                        }
                    })
                } else if (map.getZoom() >= 10) {
                    //显示人口
                    populationGroup.clearLayers();//先清空图层
                    //populationGroup_List.clearLayers();
                    //获取中心点和人数,传递缩放等级和中心点坐标
                    $.ajax({
                        url: SVC_MAP + "/getMapFamily",
                        data: {
                            districtID: $.cookie('JTZH_districtID'),
                            centerX: map.getCenter().lat,
                            centerY: map.getCenter().lng,
                            zoomLevel: map.getZoom(),
                            explorX: map.getSize().x,
                            explorY: map.getSize().y
                        },
                        type: "GET",
                        success: function (data) {
                            //console.log(data);
                            if (data.success == true) {
                                for (var i in data.data) {
                                    this.houseDetail = '<h4>房屋详情</h4>';
                                    this.houseDetail += '<table class="table table-bordered"><tr><td>区域：' + data.data[i].district + '</td><td>门牌号/房号：' + data.data[i].houseNum + '</td></tr></table>';


                                    this.familyList = '<h4>选择家庭</h4>';
                                    this.familyMember = '<div class="tab-content">';
                                    this.familyList += ' <ul class="nav nav-tabs" role="tablist">';

                                    for (var k = 0; k < data.data[i].houseMembers.length; k++) {
                                        //创造标签页，注意第一个家庭需要active标签页
                                        if (k == 0) {
                                            this.familyList += ' <li role="presentation" class="active"><a href="#' + data.data[i].houseMembers[0].bookletNum + '" aria-controls="' + data.data[i].houseMembers[0].bookletNum + '" role="tab" data-toggle="tab">' + data.data[i].houseMembers[0].bookletNum + '</a></li>'
                                            this.familyMember += '<div role="tabpanel" class="tab-pane active" id="' + data.data[i].houseMembers[k].bookletNum + '">';
                                        } else {
                                            this.familyList += '<li role="presentation"><a href="#' + data.data[i].houseMembers[k].bookletNum + '" aria-controls="' + data.data[i].houseMembers[k].bookletNum + '" role="tab" data-toggle="tab">' + data.data[i].houseMembers[k].bookletNum + '</a></li>'
                                            this.familyMember += '<div role="tabpanel" class="tab-pane" id="' + data.data[i].houseMembers[k].bookletNum + '">';
                                        }
                                        this.familyMember += '<h4>家庭成员</h4>';
                                        this.familyMember += '<table class="table table-bordered table-condensed"><tr><th>姓名</th><th>性别</th><th>年龄</th><th>身份证</th><th>与户主关系</th></tr>';
                                        for (var j in data.data[i].houseMembers[k].familyMembers) {
                                            this.familyMember += '<tr><td><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data[i].houseMembers[k].familyMembers[j].id + '\')" class="population_detail-open" id="' + data.data[i].houseMembers[k].familyMembers[j].id + '">' +
                                                data.data[i].houseMembers[k].familyMembers[j].name + '</a></td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].sex + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].age + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].IDCard + '</td><td>' +
                                                data.data[i].houseMembers[k].familyMembers[j].relationship + '</td></tr>';
                                        }
                                        this.familyMember += '</table>';
                                        this.familyMember += '家庭农田：'
                                        for (var j in data.data[i].houseMembers[k].farmLand) {
                                            this.familyMember += '<button class="map_family_farmLand" name="' + data.data[i].houseMembers[k].farmLand[j].id + '">' + data.data[i].houseMembers[k].farmLand[j].address + '</button>';
                                        }

                                        this.familyMember += '</div>';
                                        $('#' + data.data[i].houseMembers[0].bookletNum + ' a').click(function (e) {
                                            e.preventDefault();
                                            $(this).tab('show')
                                        })
                                    }

                                    this.familyList += '</ul>';
                                    this.familyMember += '</div>';
                                    L.marker([data.data[i].x, data.data[i].y])
                                        .addTo(populationGroup)
                                        .bindPopup(this.houseDetail + this.familyList + this.familyMember, {
                                            minWidth: 500
                                        })
                                    .on('click', function (e) {
                                        console.log(e);
                                        $('.map_family_farmLand').click(function () {
                                            findFarmLand(e.latlng, this.name, map);
                                        })
                                    })
                                    $('#myTabs a').click(function (e) {
                                        e.preventDefault()
                                        $(this).tab('show')
                                    })

                                }
                                map.addLayer(populationGroup);

                            } else {
                                console.warn(data.message);
                            }

                        },
                        error: function () {
                          
                        }
                    })

                } else {
                    //容错
                }
            } else {//农业地图缩放

            }
        }
        /*------------清空按钮--------------*/
        $('#Clear_Marker').click(function () {
            switchType = 0;
            districtSwitch = 0;
            cleanLayer(map);
        })
        /*------------天景按钮-------------*/
        $('#Plane_Marker').click(function () {
            switchType = 4;//鸟瞰视角
            districtSwitch = 0;
            cleanLayer(map);
            $.ajax({
                url: SVC_MAP + "/getplane",
                type: "GET",
                data: {
                    type: "1"
                },
                success: function (data) {
                    if (data.success == true) {
                        for (var i in data.data) {
                            console.log(data.data[i])
                            var marker = L.marker([data.data[i].x, data.data[i].y], {
                                icon: L.icon({
                                    iconUrl: "../assets/i/marker/" + data.data[i].pin,
                                })
                            }).addTo(markerGroup)
                                .on("click", function () {
                                    window.location.href = "../8-travel/travel_Z.html"
                                })
                            map.addLayer(markerGroup);
                        }
                    } else {
                        console.warn(data.message);
                    }
                    map.setView([31.0848565751, 120.4066879619], 6);
                },
                Error: function () {
                    
                }
            })
        })
        /*------------叠加区域按钮-------------*/
        $('#District_Marker').click(function () {
            if (districtSwitch == 1) {
                map.eachLayer(function (layer) {
                    if (!layer._url && layer._latlngs && layer._latlngs.length != 0) map.removeLayer(layer);
                }, map);
                districtSwitch = 0;
            } else if (districtSwitch == 0) {
                var zoom = map.getZoom();
                if (zoom > 9) {
                    zoom = 9;
                }
                addDistrict();
                districtSwitch = 1;
            }


        })
    })
//查看人口详情
function populationDetailOpen(id) {
    console.log(id);
    $.ajax({
        url: SVC_POP + "/getSinglePopulationByID",
        data: {
            id: id,
            districtID: $.cookie('JTZH_districtID')
        },
        type: "GET",
        success: function (data) {
            console.log(data);
            if (data.success == true) {
                $('#population_detail-id').html(data.data[0].id);
                $('#population_detail-name').html(data.data[0].name);
                $('#population_detail-IDCard').html(data.data[0].IDCard);
                $('#population_detail-phone').html(data.data[0].phone);
                $('#population_detail-sex').html(data.data[0].sex);
                $('#population_detail-nation').html(data.data[0].nation);
                $('#population_detail-marriageStatus').html(data.data[0].marriageStatus);
                $('#population_detail-politicsStatus').html(data.data[0].politicsStatus);
                $('#population_detail-censusRegister').html(data.data[0].censusRegister);
                $('#population_detail-bookletNum').html(data.data[0].bookletNum);
                $('#population_detail-populationType').html(data.data[0].populationType);
                $('#population_detail-workPlace').html(data.data[0].workPlace);
                $('#population_detail-educationDegree').html(data.data[0].educationDegree);
                $('#population_detail-district').html(data.data[0].district);
                $('#population_detail-address').html(data.data[0].address);

            } else {
                console.warn(data.message);
            }
        },
        error: function () {
            console.warn('网络错误！');
        }
    })
    $('#population_detail').fadeIn()
    $('#population_detail').animate({
        //right: '250px',
        height: '450px',
        width: '550px',
    }, "fast");
}
