require(['jquery', 'jquery.cookie', 'bootstrap', 'TileHeadPic', ], function ($) {
    accountCheck(1);
    //loadCommonModule();
    //轮播图片自适应


    $.ajax({
        url: SVC_SYS + "/getIndex_Z",
        type: "GET",
        data: {
            districtID: $.cookie('JTZH_districtID')
        },
        success: function (data) {
            console.log(data)
            if (data.success == true) {
                for (var i in data.data1) {
                    $('#InternalInformation').find('ul').append(
                        ' <li><span>·</span><a href="#" name="' + data.data1[i].id + '">' + data.data1[i].title + '</a></li>'
                        )
                }
                for (var i in data.data2) {
                    $('#Meeting').find('ul').append(
                        ' <li><span>·</span><a href="#" name="' + data.data2[i].id + '">' + data.data2[i].title + '</a></li>'
                        )
                }

                $('#InternalInformation').find('ul').find('a').click(function () {
                    $.ajax({
                        url: SVC_SYS + "/getInternalInformationDetail",
                        type: "GET",
                        data: {
                            id: this.name
                        },
                        success: function (data) {
                            if (data.success == true) {
                                $('#html-peek .modal-body').html(data.data);
                                $('#html-peek').modal();
                            } else {
                                
                            }
                        },
                        error: function () {
                             
                        }
                    })
                })

                $('#Meeting').find('ul').find('a').click(function () {
                    $.ajax({
                        url: SVC_SYS + "/getMeetingDetail",
                        type: "GET",
                        data: {
                            id: this.name
                        },
                        success: function (data) {
                            if (data.success == true) {
                                $('#html-peek .modal-body').html(data.data);
                                $('#html-peek').modal();
                            } else {
                                
                            }
                        },
                        error: function () {
                            
                        }
                    })
                })
                $('.carousel-inner').append('<div class="item active" title="' + data.data1[0].id + '"><img src="../upload/cover/' + data.data1[0].cover + '" alt="Third slide"><div class="carousel-caption">' + data.data1[0].title + '</div></div>')
                $('.carousel-inner').append('<div class="item" title="' + data.data1[1].id + '"><img src="../upload/cover/' + data.data1[1].cover + '" alt="Third slide"><div class="carousel-caption" >' + data.data1[1].title + '</div></div>')
                $('.carousel-inner').append('<div class="item" title="' + data.data1[2].id + '"><img src="../upload/cover/' + data.data1[2].cover + '" alt="Third slide"><div class="carousel-caption">' + data.data1[2].title + '</div></div>')
                $('.carousel-inner .item img').jqthumb({
                    width: '100%',
                    height: 300,
                    zoom: 2,
                    after: function (imgObj) {
                        imgObj.css('opacity', 0).animate({ opacity: 1 }, 1000);
                    }
                });
                $('.carousel-inner').find('.item').click(function () {
                    $.ajax({
                        url: SVC_SYS + "/getInternalInformationDetail",
                        type: "GET",
                        data: {
                            id: this.title
                        },
                        success: function (data) {
                            if (data.success == true) {
                                $('#html-peek .modal-body').html(data.data);
                                $('#html-peek').modal();
                            } else {
                                alert(data.message)
                            }
                        },
                        error: function () {
                            
                        }
                    })
                })
            } else {
                alert(data.message);
            }
        },
        error: function () {
            
        }
    })

    //标签卡切换
    $('#myTabs').find('.nav-tabs').find('a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    })
    $('#account-info').click(function () {
        $('#account-info-modal').modal()
    })

})