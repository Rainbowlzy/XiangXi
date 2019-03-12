"use strict";

require(["vue", "jquery", "jquery.cookie", "bootstrap", "bootstrap-table", "bootstrap-select", "bootstrap-datetimepicker", "bootstrap-datetimepicker.zh-CN", 'cmodules'], function (Vue, $) {

    $(document).ready(function () {
        $.call('GetUserRolesList', { PageSize: 4000, PageIndex: 0 }, function (umdata) {
            $.call('GetUserInformationList', { PageSize: 4000, PageIndex: 0 }, function (userdata) {
                $.call('getroleconfigurationlist', { PageSize: 4000, PageIndex: 0 }, function (rolesdata) {
                    window.vm = new Vue({
                        el: '#app',
                        data: {
                            users: userdata.rows,
                            roles: rolesdata.rows,
                            umdata: umdata.rows
                        },
                        methods: {
                            any: function any(URRoleName, URLoginName) {
                                var dt = this.$data.umdata;
                                if (dt) {
                                    for (var i = 0; i < dt.length; i++) {
                                        var row = dt[i];
                                        if (row.URRoleName == URRoleName && row.URLoginName == URLoginName) {
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
                                $.call("saveUserRolesdic", objs, function (data) {

                                    if (data && data.success) location.href = "../0_common/UserRoles.html";
                                });
                            }
                        }
                    });
                });
            });
        });
    });
});

//# sourceMappingURL=UserRoles-compiled.js.map

//# sourceMappingURL=UserRoles-compiled.js.map
