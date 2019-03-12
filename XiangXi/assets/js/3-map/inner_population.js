'use strict';

require(['vue', 'jquery', 'cmodules', 'amap'
//, '../assets/js/0-common/initfakedmap'
], function (Vue, $) {
    var request = GetRequest();
    var params = $.extend(request, {PAddress: request.address});
    //$.call('getcameralist',params, function (cam) {
    var vm = new Vue({
        computed: {
            request: function () {
                return GetRequest();
            }
        },
        data: function () {
            return {
                populations: []
            };
        },
        methods: {
            reviewpop: function reviewpop(row) {
                location.href = "/XiangXi/gen/Population.html?hidden_title=1&table=Population&data=" + encodeURIComponent(JSON.stringify(row));
            }
        }
    }).$mount("#app");
    $.call('getpopulationlist', params, function (pop) {
        vm.$data.populations = pop.rows;
    });
});

//# sourceMappingURL=inner_population.js.map
