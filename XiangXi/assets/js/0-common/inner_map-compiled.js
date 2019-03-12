'use strict';

require(['vue', 'jquery', 'cmodules'], function (Vue, $) {

    var vm = new Vue({
        mounted: function mounted() {
            this.init();
        },

        methods: {
            pin: function pin(sr) {
                sr.marker.setMap(this.map);
                this.map.panTo(sr.position);
            },
            search: function search() {
                $.mapSearch(this.search_key_word, function (res) {
                    console.log(res);
                });
            },
            init: function init() {
                var map = this.map = new AMap.Map('container', {
                    resizeEnable: true,
                    zoom: 11,
                    center: [116.397428, 39.90923]
                });
            },
            clean: function clean() {
                this.search_result_list = [];
            },
            left_search: function left_search(label) {
                var thiz = this;
                var searchResultList = [{
                    id: 1,
                    label: "苏州相城白金汉爵大酒店",
                    stars: 5,
                    tel: "0512-66158888",
                    addr: "江苏省苏州市相城区相城大道1111号",
                    position: [116.397428, 39.90923]
                }, {
                    id: 1,
                    label: "苏州相城白金汉爵大酒店",
                    stars: 4,
                    tel: "0512-66158888",
                    addr: "江苏省苏州市相城区相城大道1111号",
                    position: [116.397428, 39.90923]
                }, {
                    id: 1,
                    label: "苏州相城白金汉爵大酒店",
                    stars: 3,
                    tel: "0512-66158888",
                    addr: "江苏省苏州市相城区相城大道1111号",
                    position: [116.397428, 39.90923]
                }];
                var dict = {
                    监控: 'jiank', 楼栋: 'cangf', 关爱: 'canji', 党员: 'dangyuan', 老人: 'laonian'
                };
                thiz.map.clearMap();
                $.each(searchResultList, function (i, row) {
                    var marker = new AMap.Marker({
                        position: row.position,
                        map: thiz.map,
                        title: row.label,
                        icon: '../assets/i/mapicon/' + (dict[label] || 'cangf') + '.png'
                    });
                    marker.setMap(thiz.map);
                    row.marker = marker;
                });
                thiz.map.panTo(searchResultList[0].position);
                return this.search_result_list = searchResultList;
            }
        },
        data: {
            svcHeader: svcHeader,
            search_key_word: "",
            search_result_list: []
        }
    }).$mount("#app");
});

//# sourceMappingURL=inner_map-compiled.js.map

//# sourceMappingURL=inner_map-compiled.js.map