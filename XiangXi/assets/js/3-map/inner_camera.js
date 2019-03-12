'use strict';

require(['vue', 'jquery', 'cmodules', 'amap'], function (Vue, $) {
    var request = GetRequest() || { address: '' };
    if (request) {
        var params = $.extend(request, { PAddress: request.address });
        //$.call('getcameralist',params, function (cam) {
        var vm = new Vue({
            data: $.extend(request, {
                cam: []
            }),
            methods: {
                jiankong: function jiankong(row) {
                    //location.href = "/XiangXi/2_map/watchjiankong.html?src=" + encodeURIComponent(row);
                    location.href = "/XiangXi/2_map/RTSP.aspx?src=" + encodeURIComponent(row);
                }
            }
        }).$mount("#app");
        $.call('CameraList', params, function (cam) {
            location.href = "/XiangXi/2_map/RTSP.aspx?src=" + encodeURIComponent(cam[0].url);
        });
    }
});

//# sourceMappingURL=inner_camera.js.map
