/**
 * Created by rainb on 2018/4/30.
 */
require(['vue', 'jquery',
    "jquery.cookie",
    "bootstrap",], function (Vue, $) {

    var vm = new Vue({
        el:"#app",
        data: {
            request:GetRequest(),

        }
    })

})
