"use strict";

require(["vue", "jquery", "jquery.cookie", "bootstrap", "bootstrap-table", "bootstrap-select", "bootstrap-datetimepicker", "bootstrap-datetimepicker.zh-CN", "cmodules"], function (Vue, $) {

    $(document).ready(function () {
        $.call('getrolemenulist', { PageSize: 4000, PageIndex: 0 }, function (rolemenudata) {
            $.call('getroleconfigurationlist', { PageSize: 4000, PageIndex: 0 }, function (roledata) {
                $.call('getMenuConfigurationlist', { PageSize: 4000, PageIndex: 0 }, function (menudata) {

                    window.vm = new Vue({
                        el: '#app',
                        data: {
                            roles: roledata.rows,
                            menus: menudata.rows,
                            umdata: rolemenudata.rows
                        },
                        methods: {
                            any: function any(RMMenuTitle, RMRoleName) {
                                var dt = this.$data.umdata;
                                if (dt) {
                                    for (var i = 0; i < dt.length; i++) {
                                        var row = dt[i];
                                        if (row.RMMenuTitle == RMMenuTitle && row.RMRoleName == RMRoleName) {
                                            return true;
                                        }
                                    }
                                }
                                return false;
                            },
                            save: function save() {
                                var objs = $.map($(":checked"), function (input) {
                                    var val = $(input).attr("class");
                                    var arr = val.split(':');
                                    var obj = {};
                                    obj[arr[1]] = arr[0];
                                    return obj;
                                });
                                $.call("savemenuroledic", objs, function (data) {
                                    if (data && data.success) location.href += "?" + Math.random();
                                });
                            }
                        }
                    });
                });
            });
        });
    });
});

//# sourceMappingURL=menurole-compiled.js.map

//# sourceMappingURL=menurole-compiled.js.map