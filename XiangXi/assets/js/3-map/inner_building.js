'use strict';

require(['vue', 'jquery', 'cmodules', 'amap'
//, '../assets/js/0-common/initfakedmap'
], function (Vue, $) {
    var request = GetRequest() || { address: '' };
    if (request) {
        var params = $.extend(request, { BAddress: request.address });
        //$.call('getcameralist',params, function (cam) {
        var vm = new Vue({
            data: $.extend(request, {
                buildings: []
            }),
            methods: {
                reviewbud: function reviewbud(row) {
                    //location.href = "/XiangXi/gen/Building.html?data=" + encodeURIComponent(row);
                    location.href = "/XiangXi/gen/Building.html?hidden_title=1&table=Building&data=" + encodeURIComponent(JSON.stringify(row));
                }
            }
        }).$mount("#app");
        $.call('getbuildinglist', params, function (bud) {
            vm.$data.buildings = bud.rows;
        });
    }
});

//# sourceMappingURL=inner_building.js.map
