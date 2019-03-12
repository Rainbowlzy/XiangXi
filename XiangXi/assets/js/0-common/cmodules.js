'use strict';

/**
 * Created by Lu Zheng Yao on 2018/5/23.
 */

define([
    'vue'
    , 'jquery'
    , 'jquery.cookie'
    , 'echarts'
    , 'bootstrap'
    , "bootstrap-table"
    , 'bootstrap-typeahead'
    //, "bootstrap-datetimepicker.zh-CN"
    , "fileinput"
    , "fileinput_locale_zh"
    , "../assets/UEditor-utf8-net/ueditor.all.min.js"
    ,"../assets/UEditor-utf8-net/ueditor.config.js"
], function (Vue) {

    var imglist = '../assets/i/emptyimage/1.png,../assets/i/emptyimage/11.png,../assets/i/emptyimage/111.png,../assets/i/emptyimage/123.png,../assets/i/emptyimage/12312315.png,../assets/i/emptyimage/2.png,../assets/i/emptyimage/22 (2).png,../assets/i/emptyimage/22.png,../assets/i/emptyimage/222 (2).png,../assets/i/emptyimage/222.png,../assets/i/emptyimage/2231.png,../assets/i/emptyimage/256.png,../assets/i/emptyimage/3.png,../assets/i/emptyimage/33 (2).png,../assets/i/emptyimage/33.png,../assets/i/emptyimage/44.png,../assets/i/emptyimage/45463.png,../assets/i/emptyimage/45465.png,../assets/i/emptyimage/5456.png,../assets/i/emptyimage/55.png,../assets/i/emptyimage/78.png,../assets/i/emptyimage/78423.png,../assets/i/emptyimage/888.png,../assets/i/emptyimage/895.png,../assets/i/emptyimage/denglurizhi.png,../assets/i/emptyimage/list.txt,../assets/i/emptyimage/tu (2).png,../assets/i/emptyimage/tu.png,../assets/i/emptyimage/tutututu.png,../assets/i/emptyimage/tututuu.png,../assets/i/emptyimage/组1拷贝19.png'.split(",");

    Vue.component('page-top',
        {
            mounted: function () {
                var vm = this;
                $.call("GetMenuConfigurationByAuth", { "offset": 0, "limit": 800, sort: 'MCOrder' }, function (datum) {
                    // 这里请求顶部菜单数据
                    if (!datum.success) {
                        alert(datum.message);
                        return;
                    }
                    vm.$data.secondmenu = datum.rows;
                });
            },
            data: function () {
                return {
                    current_menu: "首页",
                    secondmenu: [],
                    thirdmenu: [],
                    imglist: imglist,
                    svcHeader: svcHeader,
                    colorlist: "CCDB4C#A8B81F#739DFB#5381E7#BB8BC6#A077A9#FB9A73#E87C51#E2767D#D83D47#5F9FC9#4B83A7#82DC66#54B935#5F9FC9#4B83A7#D04AD5#BB28C0#CCDB4C#A8B81F#739DFB#5381E7#BB8BC6#A077A9#FB9A73#E87C51#E2767D#D83D47#5F9FC9#4B83A7#82DC66#54B935#5F9FC9#4B83A7#D04AD5#BB28C0".split('#').reverse()
                };
            },
            methods: {
                exit: function () {
                    $.cookie("auth_user", null, { path: "/" });
                    location.href = '../4_login/login.html';
                },
                random: function random() {
                    return Math.random() * this.imglist.length;
                },
                isdirect: function isdirect(row) {
                    return row && (row.MCLink || row.link) && (row.MCLink || row.link).indexOf('business.html') === -1;
                }
            },
            template: `
    <div style="overflow: hidden; background-image: url(../assets/i/metaicon/e.jpg); background-repeat: no-repeat; background-size: cover;">
<div class="row">
        <div style="">
            <!--优化图片-->
            <div style="background:url(../assets/i/metaicon/宝华首页_03.png);
            margin: 0px 20px;
            line-height: 50px;width: 471.1px;height: 65.8px;background-size: 100%"></div>
        </div>
    </div>
    <!--顶部菜单-->
    <div class="row" style="display:none; position:relative; top:0px; width: 65535px; font-size:32px;" v-show="secondmenu">
        <div id="nav">
            <ul class="nav navbar-nav navbar-nav-cust nav-pills">
                <li class="nav-item">
                    <a class="active" href="/XiangXi/1_index/index.html" :style="current_menu==='首页'?'color:#ffa54d':''">
                        首页
                    </a>
                </li>
                <li v-for="row in secondmenu" class="nav-item">
                    <a v-bind:href="row.MCLink || '../1_index/business.html?data='+JSON.stringify(row)"
                       :style="current_menu===row.MCTitle?'color:#ffa54d':'#ffffff'">
                        {{row.MCDisplayName}}
                    </a>
                </li>
                <li>
                    <a href="#" @click="exit">
                        <div style="margin-top:-13px;">
                            <img src="../assets/i/metaicon/退出(1).png" style="height: 45px; width:45px;">
                        </div>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</div>`
        })

    Vue.component('c-uedit', {
        template: '<div></div>',
        props: ['url','field','value'],
        mounted: function mounted() {
            var uid = "c" + Math.random(100) * Math.pow(10, 18);
            var vm = this;
            $(vm.$el).attr("id", uid).attr("type", "text/plain");
            if (!UE || !UE.getEditor) window.location.reload()
            var ue = vm.vue = UE.getEditor(uid, {
                autoHeight: true,
                autoFloatEnabled: false
            });
            var cur = vm;
            ue.addListener("selectionchange", function (type, arg1, arg2) {
                cur.$emit('input', encodeURIComponent(ue.getContent()));
            });
            var val = vm.value;
            ue.addListener("ready", function () {
                if (val) ue.setContent(val);
            });
        }
    });

    function genfields(data) {
        var html = [];
        for (var p in data) {
            if (data[p]) html.push('\
            <div class="form-group">\
                <label for="xx" class="col-xs-3 control-label">xx</label>\
                <div class="col-xs-8"><input type="text" name="xx" value="yy" class="form-control"/></div>\
             </div>'.replace(/xx/g, p).replace(/yy/g, data[p]));else html.push('\
            <div class="form-group">\
                <label for="xx" class="col-xs-3 control-label">xx</label>\
                <div class="col-xs-8"><input type="text" v-model="xx" class="form-control"/></div>\
             </div>'.replace(/xx/g, p));
        }
        return html.join("<br />");
    }

    Vue.component('c-button', {
        template: '<button class="btn btn-primary">{{title}}</button>',
        props: ['title']
    });
    Vue.component('c-form', {
        template: '<div><button title="保存"></button></div>',
        component: {
            button: "c-button"
        },
        props: ['url'],
        beforeMount: function beforeMount() {
            this.init();
        },

        methods: {
            save: function save() {
                this.$emit('save');
            },
            init: function init() {
                var thiz = this;
                $.getJSON(svcHeader + thiz.url, {}, function (data) {
                    //if (thiz.url && thiz.url.indexOf('?')) {
                    //    thiz.url.split('?')[1].split('&').map(e=>e.split('=')).map(e=>data[e[0]] = e[1])
                    //}
                    $(thiz.$el)
                    //.append($('<button class="btn btn-primary" @click="save">保存</button>'))
                    .append(genfields(data));
                    //.on("submit", function (event) {
                    //    //event.preventDefault();
                    //    console.log(event,this)
                    //    $.getJSON(svcHeader+thiz.url+"&debug=debug",$(thiz.$el).serialize(), function (resp) {
                    //        alert(JSON.stringify(resp))
                    //    })
                    //    return false;
                    //});
                });
            }
        }
    });

    //$.fn.table = function (options) {
    //    var defaultoption = {
    //        method: 'get',
    //        toolbar: '#toolbar',
    //        striped: true,
    //        cache: false,
    //        pagination: true,
    //        sortable: true,
    //        queryParamsType: "limit",
    //        detailView: false,
    //        sidePagination: "server",
    //        pageSize: 10,
    //        pageList: [10, 25, 50, 100],
    //        search: true,
    //        showColumns: true,
    //        showRefresh: true,
    //        minimumCountColumns: 2,
    //        clickToSelect: true
    //    };
    //    $(this).bootstrapTable($.extend(defaultoption, options))
    //};

    //c-table
    Vue.component('c-table', {
        template: '<table></table>', props: ['method', 'columns'],
        mounted: function mounted() {
            this.init();
        },

        methods: {
            getcolumns: function getcolumns() {
                var defaultcolumns = [];
                var resp = $.callsync(this.method);
                if (!resp) return;
                var rows = resp.rows;
                if (rows) $.each(rows[0], function (t) {
                    defaultcolumns.push({
                        field: t,
                        title: t,
                        sortable: true,
                        align: "center"
                    });
                });
                defaultcolumns = [defaultcolumns];
                return defaultcolumns;
            },
            init: function init() {
                $(this.$el).table({
                    url: '/XiangXi/DefaultHandler.ashx?method=' + this.method,
                    queryParams: function queryParams(param) {
                        $.print(param);
                        return { data: JSON.stringify(param) };
                    },

                    columns: this.columns || this.getcolumns()
                });
            }
        }
    });
    //c-typeahead
    Vue.component("c-typeahead", {
        inherantVisible: false,
        template: '<input type="text"  data-provide="typeahead"  :value="value"  @input="$emit(\'input\', $event.target.value)"  class="form-control">',
        props: {
            url: String,
            field: String,
            value: String
        },
        mounted: function mounted() {
            this.init();
        },

        methods: {
            init: function init() {
                var cur = this;
                var url = cur.url;
                var field = cur.field;
                $(cur.$el).typeahead({
                    updater: function updater(val) {
                        cur.$emit('input', val);
                        return val;
                    },
                    source: function source(query, process) {
                        if (!query || query.trim().length === 0) return;
                        var search = query.trim();
                        var parameter = { search: search };
                        $.get(url, parameter, function (data) {
                            var dic = {};
                            var rows = data.rows.map(function (i) {
                                return i[field];
                            }).filter(function (i) {
                                return i && i.length > 0 && !dic[i] && (dic[i] = i);
                            });
                            console.log(rows)
                            if (rows && rows.length > 0) process(rows);
                        });
                    }
                });
            }
        }
    });
    //typeahead
    //c-pie
    Vue.component("c-pie", {
        inherantVisible: false,
        template: '<div></div>',
        props: {
            url: String,
            title: String,
            subtitle: String
        },
        mounted: function mounted() {
            this.load(this.paint);
        },

        methods: {
            load: function load(callback) {
                $.getJSON(svcHeader + this.url, {}, callback);
            },
            paint: function paint(data) {
                // temp_data is the default structure.
                var temp_data = {
                    "series": [{
                        "name": "80到90岁",
                        "value": 2
                    }, {
                        "name": "50到60岁",
                        "value": 13
                    }]
                };

                var thiz = this;
                var series = data;
                if (!series) return;
                var title = thiz.title;
                var subtitle = thiz.subtitle;
                console.log(thiz.$el);
                thiz.$myChart = echarts.init(thiz.$el).setOption({
                    title: {
                        text: title + '比例',
                        //subtext: subtitle,
                        subtext: '日期:' + new Date().toLocaleDateString(),
                        x: 'center'
                    },
                    tooltip: {
                        trigger: 'item',
                        formatter: "{a} <br/>{b} : {c} ({d}%)"
                    },
                    calculable: true,
                    series: [{
                        name: '比例',
                        type: 'pie',
                        radius: '55%',
                        center: ['50%', '60%'],
                        data: data.series
                    }]
                });
            }
        }
    });
    Vue.component("c-histogram-date", {
        template: '<div style="height:100%;"></div>',
        props: {
            url: String,
            title: String
        },
        mounted: function mounted() {
            this.init();
        },

        methods: {
            load: function load(callback) {
                $.getJSON(svcHeader + this.url, {}, callback);
            },
            init: function init() {
                var thiz = this;
                thiz.load(function (data) {
                    var px = function px(n) {
                        if (typeof n === 'string' && n.indexOf('px') !== -1) return n;
                        return n + 'px';
                    };
                    var width = px(thiz.width || $(window).width());
                    var height = px(thiz.height || $(window).height());
                    var id = 'c' + Math.random(10) * Math.pow(10, 18);
                    $(thiz.$el).attr('id', id);
                    echarts.init(thiz.$el, 'macarons').setOption({
                        title: {
                            text: thiz.title + '统计',
                            x: 'center'
                        },
                        tooltip: {
                            trigger: 'axis'
                        },
                        calculable: true,
                        xAxis: [{
                            type: 'category',
                            splitLine: { show: false },
                            data: data.xaxis
                        }],
                        yAxis: [{
                            type: 'value',
                            position: 'left'
                        }],
                        series: [{
                            name: '数量',
                            type: 'bar',
                            tooltip: { trigger: 'item' },
                            data: data.series
                        }]
                    });
                });
            }
        }
    });
    //折线统计
    Vue.component("c-histoline-date", {
        template: '<div></div>',
        props: {
            url: String,
            title: String,
            width: String,
            height: String
        },
        mounted: function mounted() {
            this.init();
        },

        methods: {
            load: function load(callback) {
                $.getJSON(svcHeader + this.url, {}, callback);
            },
            init: function init() {
                var thiz = this;
                thiz.load(function (data) {
                    var height = thiz.height || $(window).height();
                    var width = thiz.width || $(window).width();
                    $(thiz.$el).css({ "width": width, "height": height });
                    echarts.init(thiz.$el, 'macarons').setOption({
                        title: {
                            text: thiz.title + '折线统计',
                            subtext: '日期:' + new Date().toLocaleDateString(),
                            x: 'center'
                        },
                        tooltip: {
                            trigger: 'axis'
                        },
                        calculable: true,
                        xAxis: [{
                            type: 'category',
                            splitLine: { show: false },
                            data: data.xaxis
                        }],
                        yAxis: [{
                            type: 'value',
                            position: 'left'
                        }],
                        series: [{
                            name: '数量',
                            type: 'line',
                            tooltip: { trigger: 'item' },
                            data: data.series
                        }]
                    });
                });
            }
        }
    });
    Vue.component('c-select', {
        template: '<select class="selectpicker form-control"></select>',
        props: ['value', 'options'],
        methods: {
            init: function init() {
                var thiz = this;
                var options = thiz.options || [];
                console.log(options, thiz.value, thiz.options);
                var el = $(thiz.$el);
                el.append(options.map(function (ent) {
                    var doc = document.createElement('option');
                    doc.innerText = ent.text || ent;
                    doc.value = ent.val || ent;
                    return doc;
                }));
                el.selectpicker({
                    style: 'btn-info',
                    size: 4
                });
                el.on('changed.bs.select', function (e) {
                    thiz.$emit("input", this.value);
                });
                el.selectpicker('val', thiz.value);
                el.selectpicker('refresh');
            }
        },
        mounted: function mounted() {
            this.init();
        }
    });
    Vue.component('c-date', {
        template: '<input size="16" type="text" class="form_datetime form-control">',
        props: ['value', 'format', 'minView', 'maxView'],
        mounted: function mounted() {
            this.init();
        },

        methods: {
            init: function init() {
                var _this2 = this;

                var thiz = this;
                var el = $(thiz.$el);
                el.val(thiz.value);
                el.datetimepicker({
                    format: this.format || "yyyy-mm-dd",
                    language: "zh-CN",
                    weekStart: 1,
                    minView: this.minView || 2,
                    maxView: this.maxView || 4,
                    startView: 4,
                    autoclose: true
                });
                el.on('changeDate', function (ev) {
                    thiz.$emit('input', _this2.value);
                });
            }
        }
    });
    Vue.component('c-icon', {
        template: '<img />',
        props: ['label', 'color1', 'color2', 'width', 'height', 'nolabel'],
        mounted: function mounted() {
            var param = $.extend({
                label: this.label || '党员',
                color1: this.color1 || '144E76',
                color2: this.color2 || '8FE0FE',
                width: this.width || '400',
                height: this.height || '400',
                icon: (this.label || '党员') + '.png',
                shape: 'pie'
            }, $.select(this, ['label', 'color1', 'color2', 'width', 'height', 'nolabel']));
            var url = 'http://localhost/XiangXi/ImageHandler.ashx?' + Object.keys(param).map(function (key) {
                return encodeURIComponent(key) + '=' + encodeURIComponent(param[key]);
            }).join('&');
            $(this.$el).attr('src', url).attr('alt', param.label);
        }
    });
    Vue.component('c-fileinput', {
        template: '<input class="input-file form-control" type="file">',
        props: ['value', 'language', 'uploadUrl', 'allowedFileExtensions', 'showUpload', 'dropZoneEnabled', 'showCaption', 'browseClass', 'previewFileIcon', 'msgFilesTooMany'],
        mounted: function mounted() {
            var thiz = this;
            var options = {
                language: thiz.language || "zh", //设置语言
                uploadUrl: thiz.uploadUrl || svcHeader + "/XiangXi/ImageUpload.ashx?",
                allowedFileExtensions: thiz.allowedFileExtensions || ["jpg", "png", "gif", "JPEG", "doc","docx","xlsx","xls"],
                showUpload: thiz.showUpload || true, //是否显示上传按钮
                dropZoneEnabled: thiz.dropZoneEnabled || false,
                showCaption: thiz.showCaption || true, //是否显示标题
                browseClass: thiz.browseClass || "btn btn-primary", //按钮样式
                previewFileIcon: thiz.previewFileIcon || "<i class='glyphicon glyphicon-king'></i>",
                msgFilesTooMany: thiz.msgFilesTooMany || "选择上传的文件数量?({n}) 超过允许的最大数值{m}?"
                //initialPreview: []
            };
            if (thiz.value && thiz.value.length > 0) {
                options.initialPreview = thiz.value.split(',').filter(function (s) {
                    return s;
                }).map(function (s) {
                    return "<img src='" + s + "' class='file-preview-image' alt='Desert' title='Desert'>";
                });
            }
            $(thiz.$el).fileinput(options);
            $(thiz.$el).on("fileuploaded", function (event, data, previewId, index) {
                thiz.$emit('input', [thiz.value, data.response.imageURL].filter(function (t) {
                    return t && t.length;
                }).join(","));
            });
            $(thiz.$el).on('fileclear', function (event) {
                thiz.$emit('input', '');
            });
        }
    });
    return {};
});

//# sourceMappingURL=cmodules.js.map

//# sourceMappingURL=cmodules.js.map
