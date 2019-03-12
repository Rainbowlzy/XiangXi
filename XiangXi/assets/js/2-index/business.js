'use strict';

console.log(1);

require(['vue', 'jquery', 'jquery.cookie', 'bootstrap', 'cmodules'], function (Vue, $) {
    
    if((location.href.split("?")[1]||'').indexOf('show_menu=no')!==-1){

    }

    $(function () {
        var w = window.screen.width;
        var zoom = w / 1920;
        $("#container").css({
            "zoom": zoom,
            "-moz-transform": "scale(" + zoom + ")",
            "-moz-transform-origin": "top left"
        });
    });
    //判断是否为IE
    if (!!window.ActiveXObject || "ActiveXObject" in window) {
        $("body").css('zoom', '0.7');
        $("#nav ul li").css('margin', '15px 10px');
        $("#exit").css({ 'left': '1840px' });
        $("#third-menu").css('left', '19%');
        $("#third-menu a img").css({ 'transform': 'scale(0.8)' }, { '-ms-transform': 'scale(0.8)' }, { '-webkit-transform': 'scale(0.8)' }, { '-o-transform': 'scale(0.8)' }, { '-moz-transform': 'scale(0.8)' }, { 'margin': '-15px -15px' });
    } else if (window.navigator.userAgent.indexOf("MSIE") >= 1) {
        $("body").css('zoom', '0.7');
        $("#nav ul li").css('margin', '18px 10px');
        $("#exit").css({ 'left': '1840px' });
        $("#third-menu").css('left', '19%');
        $("#third-menu a img").css({ 'transform': 'scale(0.8)' }, { '-ms-transform': 'scale(0.8)' }, { '-webkit-transform': 'scale(0.8)' }, { '-o-transform': 'scale(0.8)' }, { '-moz-transform': 'scale(0.8)' }, { 'margin': '-15px -15px' });
    } else {
        $("#third-menu a img").css({ 'margin': '10px 10px' });
    }
    //判断浏览器
    //function getBrowserInfo() {
    //    var Sys = {};
    //    var ua = navigator.userAgent.toLowerCase();
    //    var re = /(msie|firefox|chrome|opera|version).*?([\d.]+)/;
    //    var m = ua.match(re);
    //    Sys.browser = m[1].replace(/version/, "'safari");
    //    Sys.ver = m[2];
    //    return Sys;
    //}
    //var sys = getBrowserInfo();
    //console.log(sys.browser);
    var request = GetRequest() || {
        data: JSON.stringify({
            MCCaption: '首页'
        })
    };
    var imglist = '../assets/i/emptyimage/1.png,../assets/i/emptyimage/11.png,../assets/i/emptyimage/111.png,../assets/i/emptyimage/123.png,../assets/i/emptyimage/12312315.png,../assets/i/emptyimage/2.png,../assets/i/emptyimage/22 (2).png,../assets/i/emptyimage/22.png,../assets/i/emptyimage/222 (2).png,../assets/i/emptyimage/222.png,../assets/i/emptyimage/2231.png,../assets/i/emptyimage/256.png,../assets/i/emptyimage/3.png,../assets/i/emptyimage/33 (2).png,../assets/i/emptyimage/33.png,../assets/i/emptyimage/44.png,../assets/i/emptyimage/45463.png,../assets/i/emptyimage/45465.png,../assets/i/emptyimage/5456.png,../assets/i/emptyimage/55.png,../assets/i/emptyimage/78.png,../assets/i/emptyimage/78423.png,../assets/i/emptyimage/888.png,../assets/i/emptyimage/895.png,../assets/i/emptyimage/denglurizhi.png,../assets/i/emptyimage/list.txt,../assets/i/emptyimage/tu (2).png,../assets/i/emptyimage/tu.png,../assets/i/emptyimage/tutututu.png,../assets/i/emptyimage/tututuu.png,../assets/i/emptyimage/组1拷贝19.png'.split(",");

    var vm = new Vue({
        el: '#container',
        data: {
            current_menu:"首页",
            secondmenu: [],
            thirdmenu: [],
            svcHeader: svcHeader,
            imglist: imglist,
            colorlist: "CCDB4C#A8B81F#739DFB#5381E7#BB8BC6#A077A9#FB9A73#E87C51#E2767D#D83D47#5F9FC9#4B83A7#82DC66#54B935#5F9FC9#4B83A7#D04AD5#BB28C0#CCDB4C#A8B81F#739DFB#5381E7#BB8BC6#A077A9#FB9A73#E87C51#E2767D#D83D47#5F9FC9#4B83A7#82DC66#54B935#5F9FC9#4B83A7#D04AD5#BB28C0".split('#').reverse()
        },
        mounted: function mounted() {
            if (location.href.indexOf('?') != -1) return;
            var mapmenu = {
                "id": "d0fde592-2d11-4d82-bcd8-a8087a9ac915",
                "MCCaption": "村务地图",
                "MCLink": "/XiangXi/2_map/map.html?lnglat=[120.511929,31.252366]&zoom=16",
                "MCPicture": "/XiangXi/Upload/Image/966385cf-13d8-4381-8d08-cd74daa5cea5.png",
                "MCMenuType": "首页菜单",
                "TransactionID": "ca1227e1-0792-499b-b6a5-dfb4a4ef72fc",
                "CreateBy": "xiangxi",
                "CreateOn": "2018-05-16T00:00:00",
                "UpdateBy": "xiangxi",
                "UpdateOn": "2018-05-16T22:51:43.79"
            };
            this.redirect(mapmenu);
        },

        methods: {
            exit: function () {
                $.cookie("auth_user", null, { path: "/" });
                location.href = '../4_login/login.html';
            },
            random: function random() {
                return Math.random() * this.imglist.length;
            },
            isdirect: function isdirect(row) {
                return row && (row.MCLink || row.link) && (row.MCLink || row.link).indexOf('business.html') === -1;
            },
            redirect: function (p) {
                var link = p.link || p.MCLink || '';
                if (!link || link === '' || link === 'null' || link === svcHeader || link === svcHeader + 'null') {
                    location.href = '/XiangXi/1_index/business.html?data=' + encodeURIComponent(JSON.stringify({ MCCaption: p.title || p.MCCaption }));
                    return;
                }
                location.href = link;
            },
            redirect_iframe: function redirect(p) {
                if (p && p.isimage) return;
                //$("iframe").remove();
                $('#third-menu').hide();
                var link = p.link || p.MCLink || '';
                if (!link || link === '' || link === 'null' || link === svcHeader || link === svcHeader+'null') {
                    location.href = '/XiangXi/1_index/business.html?data=' + encodeURIComponent(JSON.stringify({ MCCaption: p.title || p.MCCaption }));
                    return;
                }

                if (link.indexOf(svcHeader) !== -1) link = link.substr(svcHeader.length);
                if (link.indexOf('http://') === -1) link = svcHeader + link;

                if (link.indexOf('business.html') !== -1) parent.location.href = link;
                if(link.indexOf('?')===-1)link+='?';
                link+="&nav="+encodeURIComponent(JSON.stringify({id:p.id}));

                $('iframe').remove();

                if ($("iframe").length == 0) var iframe = $("<iframe></iframe>")
                    .attr("src", link)
                    .attr("width", $(window).width())
                    .attr("height", $(window).height())
                    //                                        .attr("scrolling", "no")
                    .attr("frameborder", "0").css({
                        "top": "18%",
                        "position": "fixed",
                        "left":"0px",
                        "background": "transparent"
                    });else var iframe = $("iframe").attr("src", link);

                $(document.body)
                    .append(iframe);
                $(window).resize(function () {
                    $(iframe).attr("width", $(window).width()).attr("height", $(window).height());
                });
                var caption = p.title || p.MCCaption;
                this.$data.current_menu=caption;
            }
        }
    });

    if(request.data){
        var m = JSON.parse(request.data);
        if(m){
            vm.$data.current_menu = m.MCCaption;
        }
    }
    $.call("GetMenuConfigurationByAuth", { "offset": 0, "limit": 800, sort: 'MCSequence' }, function (datum) {
        // 这里请求顶部菜单数据
        if (!datum.success) {
            alert(datum.message);
            return;
        }
        vm.$data.secondmenu = datum.rows;

        // category = 首页背景图片
        $(document.body).css({
            //"background-image": "url("+(datum.background||'../assets/i/metaicon/e.jpg')+")",
            //                "height": '1080px',
            //'width': '1920px',
            'background-repeat': 'no-repeat',
            'background-size': 'cover'
            //                'overflow': 'hidden',
        });
        if(!request.data)return;



        var parent = JSON.parse(request.data);
        var menu = {
            "offset": 0, "limit": 800, "sort": "MCSequence","order":"asc", "MCParentTitle": parent.MCCaption
        };
        $.call('GetMenuConfigurationByAuth&key=' + parent.MCCaption, null, function (resp) {
            vm.$data.thirdmenu = resp.topmenu.map(function (i) {
                return { id:i.id, img: i.MCPicture, link: svcHeader + i.MCLink, title: i.MCCaption };
            }).filter(function (e) {
                return e;
            });
            // var MAX = 12
            // var len = vm.$data.thirdmenu.length;
            // var imglen = imglist.length;
            // if (len<MAX) {
            //     // load images async
            //     for (var i = 0; i < imglen; i++) {
            //         var img = new Image();
            //         img.src = imglist[i];
            //     }
            //     var imgindex = 0;
            //     for (var i = 0; i < MAX-len; ++i) {
            //         vm.$data.thirdmenu.push({ img: imglist[imglen%(++imgindex)], title: '', link: '', isimage: true })
            //     }
            // }
            //
            // if (len / 4 <= 1) {
            //     $("#third-menu").css({ "bottom": "42%", "top": "42%" });
            // }
            //
            // if (len / 4 <= 2 && len / 4 > 1) {
            //     $("#third-menu").css({ "bottom": "33%", "top": "33%" });
            // }

        });
    });
});

//# sourceMappingURL=business.js.map