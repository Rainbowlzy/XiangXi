require([
    "vue",
    "jquery", "jquery.cookie", "bootstrap",
    "bootstrap-table", "bootstrap-select", "bootstrap-datetimepicker", "bootstrap-datetimepicker.zh-CN"
], function (Vue, $) {
    var auth = null;
    if ($.cookie && !(auth = $.cookie("auth_user"))) location.href = "/XiangXi/login.html";

    Call("GetUserRoleListByAuth", {
        search: auth
    }, function (data) {
        if (data && !data.success) {
            if (data && data.message.indexOf("请登录") !== -1) location.href = "/XiangXi/login.html";
        }
        if (data.data[0].URRoleName.indexOf('宝华') !== -1 ||
            data.data[0].URRoleName.indexOf('XiangXi') !== -1) {
            location.href = '../1_index/XiangXi_index.html';
        } else {
            location.href = '../1_index/index.html';
        }
    })
});

