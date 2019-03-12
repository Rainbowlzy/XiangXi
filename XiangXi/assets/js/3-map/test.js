require(['jquery', 'jquery.cookie', 'bootstrap', 'leaflet', 'leaflet.contextmenu', 'leaflet.MiniMap', 'leaflet.Zoomslider', 'leaflet.fullscreen', 'leaflet.defaultextent', 'leaflet.MarkerCluster',
    'leaflet.draw', 'leaflet.measurecontrol'], function ($) {
        loadCommonModule('map');
       
        $('#search_list').hide();
        /*-----------地图初始化-----------*/
        mapCRS();
        var map = L.map('map', {
            center: [31.0848565751, 120.4066879619],
            zoom: 7,
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
        mapInit(map);


       



        //定义
        var areaGroup = new L.layerGroup();
        var populationGroup = new L.layerGroup();
        //var populationGroup_List = new L.markerClusterGroup();
        var agricultureGroup = new L.layerGroup();
        var switchType = 1;
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
                            alert(data.message);
                        }
                    },
                    error: function () {
                        alert('网络错误！');
                    }
                })
            }, error: function () {
                var latlng = new L.LatLng(31.0848565751, 120.4066879619);
                map.setView(latlng, 7);
            }
        })
        zoomendEvent();
        /*-----------人口按钮-------------*/
        $('#map_btn-population').click(function () {
            $('.map_right_nav').html(
                '<div class="btn-group-vertical" role="group" aria-label="...">' +
                    '<button type="button" class="btn btn-default btn-lg" value=1><i class="glyphicon glyphicon-flash"></i>全部</button>' +
                    '<button type="button" class="btn btn-default btn-lg" value=2><i class="glyphicon glyphicon-chevron-right"></i>党员</button>' +
                    '<button type="button" class="btn btn-default btn-lg" value=3><i class="glyphicon glyphicon-chevron-right"></i>特殊人群</button>' +
                    '<button type="button" class="btn btn-default btn-lg" value=4><i class="glyphicon glyphicon-chevron-right"></i>民兵</button>' +
                    '<button type="button" class="btn btn-default btn-lg" value=5><i class="glyphicon glyphicon-chevron-right"></i>工作人员</button>' +

                    '<div class="btn-group" role="group">' +
                        '<button type="button" class="btn btn-default  btn-lg dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
                            '<i class="glyphicon glyphicon-chevron-right"></i>选择区域' +
                            '<span class="caret"></span>' +
                        '</button>' +
                        '<ul class="dropdown-menu">' +
                            '<li><a href="#">潦里</a></li>' +
                            '<li><a href="#">高田</a></li>' +
                        '</ul>' +
                    '</div>' +
                '</div>');
            $('.map_right_nav').show();
            $('.map_right_nav').animate({ right: '0px' });
            $('.map_right_nav .btn-group-vertical button').click(function () {
                populationTypeSelect($(this).attr("value"));
            })
            populationSearch();
        })
        /*-----------农业按钮-------------*/
        $('#map_btn-agriculture').on('click', function () {
            populationGroup.clearLayers();
            switchType = 2;

        })
        /*-----------人口详情-------------*/
        $('#population_detail .population_detail-close').click(function () {
            $('#population_detail').animate({
                //right: '20px',
                height: '50px',
                width: '50px',
            });

            $('#population_detail').fadeOut()
        });
        /*-----------搜索框---------------*/
        $('#map_search').keyup(function () {
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
                            for (var i in data.data) {
                                $('.list-group').append(
                                    '<a href="#" class="list-group-item">' +
                                        '<h4 class="list-group-item-heading">' + data.data[i].name + '（' + data.data[i].IDCard + '）</h4>' +
                                        '<p class="list-group-item-text"><span class="glyphicon glyphicon-map-marker" style="color:#2f94c1"></span>潦里103号</p>' +
                                    '</a>')
                            }
                        }
                    })
                }
                $('#search_list').show();
            } else {
                $('#search_list').hide();
            }

        })
        /*-----------缩放事件------------*/
        function zoomendEvent() {
            map.on('zoomend', function (e) {
                if (switchType == 1) {
                    if (e.target._animateToZoom < 10) {
                        //6级及以下显示街道区域
                        populationGroup.clearLayers();//先清空图层
                        //populationGroup_List.clearLayers();
                        //获取中心点和人数,传递缩放等级和中心点坐标
                        $.ajax({
                            url: SVC_MAP + "/getMapPopulationBlock",
                            data: {
                                districtID: $.cookie('JTZH_districtID'),
                                centerX: e.target._animateToCenter.lat,
                                centerY: e.target._animateToCenter.lng,
                                zoomLevel: e.target._animateToZoom,
                                explorX: e.target._size.x,
                                explorY: e.target._size.y
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
                                    alert(data.message);
                                }
                            },
                            error: function () {
                                alert('网络错误！');
                            }
                        })
                    } else if (e.target._animateToZoom >= 10) {
                        //显示人口
                        populationGroup.clearLayers();//先清空图层
                        //populationGroup_List.clearLayers();
                        //获取中心点和人数,传递缩放等级和中心点坐标
                        $.ajax({
                            url: SVC_MAP + "/getMapFamily",
                            data: {
                                districtID: $.cookie('JTZH_districtID'),
                                centerX: e.target._animateToCenter.lat,
                                centerY: e.target._animateToCenter.lng,
                                zoomLevel: e.target._animateToZoom,
                                explorX: e.target._size.x,
                                explorY: e.target._size.y
                            },
                            type: "GET",
                            success: function (data) {
                                //console.log(data);
                                if (data.success == true) {
                                    for (var i in data.data) {
                                        this.houseDetail = '<h4>房屋详情</h4>';
                                        this.houseDetail += '<table class="table table-bordered"><tr><td>区域：' + data.data[i].district + '</td><td>地址：' + data.data[i].address + '</td><td>门牌号/房号：' + data.data[i].houseNum + '</td><td>人数：' + data.data[i].populationNum + '</td></tr></table>';


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
                                        L.marker([data.data[i].x, data.data[i].y])
                                            .addTo(populationGroup)
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
                                    alert(data.message);
                                }

                            },
                            error: function () {
                                alert('网络错误！');
                            }
                        })

                    } else {
                        //容错
                    }
                } else {//农业地图缩放

                }

            })

        }
        /*-----------人口查询-------------*/
        function populationSearch() {
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
                                alert(data.message);
                            }
                        },
                        error: function () {
                            alert('网络错误！');
                        }
                    })
                }, error: function () {
                    var latlng = new L.LatLng(31.0848565751, 120.4066879619);
                    map.setView(latlng, 7);
                }
            })
            switchType = 1;
        }
        /*-----------人口类型选择---------*/
        function populationTypeSelect(type) {
            populationGroup.clearLayers();
            switchType = 3;
            switch (type) {
                case "1": populationSearch();
                    break;
                case "2":
                    $.ajax({
                        url: SVC_MAP + "/mapSearchPartyPopulation",
                        type: "GET",
                        data: {
                            districtID: $.cookie("JTZH_districtID"),
                            type: type
                        },
                        success: function (data) {
                            console.log(data);
                            if (data.success == true) {
                                for (var i in data.data) {
                                    L.marker([data.data[i].x, data.data[i].y])
                                        .addTo(populationGroup)
                                        .bindPopup('<div class="row map_party_card">' +
                                        '<div class="col-md-3"><img width=200 src="../assets/i/client.png" alt="..." class="img-thumbnail"></div>' +
                                        '<div class="col-md-9"><dl class="dl-horizontal">' +
                                        '<dt>姓名</dt><dd><a href="javascript:void(0)" onclick="populationDetailOpen(\'' + data.data[i].id + '\')" class="population_detail-open" id="' + data.data[i].id + '">' + data.data[i].name + '</a></dd>' +
                                        '<dt>身份证</dt><dd>' + data.data[i].IDCard + '</dd>' +
                                        '<dt>入党时间</dt><dd>' + data.data[i].joinTime + '</dd>' +
                                        '<dt>党龄</dt><dd>' + data.data[i].partyAge + '年</dd>' +
                                        '<dt>所属支部</dt><dd>' + data.data[i].department + '</dd></dl>' +
                                        '</div>' +
                                        '</div>', {
                                            minWidth: 500,
                                            className: "map_party_card-popup"
                                        })
                                }
                                map.addLayer(populationGroup);
                            } else {
                                alert(data.message)
                            }
                        },
                        error: function () {
                            alert("网络错误！");
                        }
                    })
                    break;
                case "3": alert("正在开发中！即将上线");
                    break;
            }
        }
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
                alert(data.message);
            }
        },
        error: function () {
            alert('网络错误！');
        }
    })
    $('#population_detail').fadeIn()
    $('#population_detail').animate({
        //right: '250px',
        height: '450px',
        width: '550px',
    }, "fast");
}
