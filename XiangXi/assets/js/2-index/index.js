require([
    "vue",
    "jquery", "jquery.cookie",
    "bootstrap",
    "bootstrap-table",
    "bootstrap-select",
    "bootstrap-datetimepicker",
    "bootstrap-datetimepicker.zh-CN"
], function(Vue, $) {
    if (!$.cookie("auth_user")) location.href = "/XiangXi/login.html";
    $(document).ready(function() {
        var trigger = $(".hamburger"),
            overlay = $(".overlay"),
            isClosed = false;

        setInterval(function() {
            if (!$.cookie("auth_user")) location.href = "/XiangXi/login.html";
        }, 10000);


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

        //$('[data-toggle="offcanvas"]').click(function() {
        //    $("#wrapper").toggleClass("toggled");
        //});

        var request = {};
        //request.search = '智慧党建系统';
        request.offset = 0;
        request.limit = 500;
        window.Call("GetMenuConfigurationByAuth", request, function(data) {
            if (!data || !data.success) {
                if (data.message.indexOf("请登录") !== -1) location.href = "../login.html";
                return;
            }
            var rows = data.rows;
            for (var i = 0; i < rows.length; i++) {
                var line = rows[i];
                if (line.MCParentTitle && line.MCParentTitle !== "") {
                    var found = rows.find(function(li) {
                        return li && li.MCCaption.trim() === line.MCParentTitle.trim();
                    });
                    if (typeof (found) !== "undefined") {
                        if (!found.arr) found.arr = [];
                        found.arr[found.arr.length] = line;
                        delete rows[i];
                    }
                }
            }
            for (var i = 0; i < rows.length; i++) {
                var line = rows[i];
                if (line && !line.arr) {
                    delete rows[i];
                }
            }
            window.menu = new Vue({
                el: "#app",
                data: data,
                methods: {
                    redirect(item) {
                        var li = item;
                        li.arr = null
                        $('a.open').removeClass('open')
                        $(':contains('+li.MCCaption+')').filter((a,i)=> i.innerHTML[0]===li.MCCaption[0]).addClass('open')
                        li.MCLink = li.MCLink||'/XiangXi/1_index/business.html'
                        if (li.MCLink.indexOf('?') != -1) var link = li.MCLink + "&data=" + JSON.stringify(li);
                        else var link = li.MCLink + "?data=" + JSON.stringify(li);
                        if (location.href[0] == "f") {
                            link = "http://localhost" + link;
                        }
                        $("iframe").attr("src", link);
                    }
                },
                mounted() {
                    $(".dropdown-toggle").dropdown();
                }
            });
        });
    });
});