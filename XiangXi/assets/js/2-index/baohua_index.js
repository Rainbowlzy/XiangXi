﻿require([
    "vue",
    "jquery",
 "jquery.cookie",
 "bootstrap"
], function (Vue, $) {
    if ($.cookie && !$.cookie("auth_user")) location.href = "/XiangXi/login.html"
    $('#myTab li:eq(1) a').tab('show');
    $(document).ready(function() {
        var trigger = $(".hamburger"),
            overlay = $(".overlay"),
            isClosed = false;

        trigger.click(function() {
            hamburger_cross();
        });

        function hamburger_cross() {

            if (isClosed == true) {
                overlay.hide();
                trigger.removeClass("is-open");
                trigger.addClass("is-closed");
                isClosed = false;
            } else {
                //overlay.show();       
                trigger.removeClass("is-closed");
                trigger.addClass("is-open");
                isClosed = true;
            }
        }

        $('[data-toggle="offcanvas"]').click(function() {
            $("#wrapper").toggleClass("toggled");
        });
        var request = {};
        //request.search = '智慧党建系统';
        request.offset = 0;
        request.limit = 500;
        window.Call("GetMenuConfigurationByAuth", request, function (data) {

            if (!data || !data.success) {
                if (data.message.indexOf('请登录') !== -1) location.href = '../login.html';
                return;
            }
            var rows = data.rows;
            for (var i = 0; i < rows.length; i++) {
                var line = rows[i];
                if (line.MCParentTitle && line.MCParentTitle !== "") {
                    var found = rows.find(function (li) {
                        return li && li.MCCaption.trim() === line.MCParentTitle.trim();
                    });
                    if (typeof (found) !== "undefined") {
                        if (!found.arr) found.arr = [];
                        found.arr[found.arr.length] = line;
                        delete rows[i];
                    }
                }
            }
            data.rows = rows.filter(function (line) {
                return line.arr;
            })
            window.menu = new Vue({
                el: "#app",
                data: data,
                methods: {
                    redirect(li) {
                        var link = li.MCLink + "?data=" + JSON.stringify(li);
                        if (location.href[0] == "f") {
                            link = "http://localhost" + link;
                        }
                        $("#down").hide();
                        $("#body").hide();
                        if($("iframe").size()===0)$("#main").append('<iframe width="1200" height="800" frameborder="0" src="" marginheight="0" marginwidth="0" scrolling="yes"></iframe>')
                        $("iframe").attr("src", link);
                        $(".list-group-item").css({ "background": "", "color": "black" });
                        $("." + li.MCCaption).css({"background":"darkblue", "color":"white"});
                    }
                },
                mounted() {
                    $(".dropdown-toggle").dropdown();
                }
            });
        });
    });
});