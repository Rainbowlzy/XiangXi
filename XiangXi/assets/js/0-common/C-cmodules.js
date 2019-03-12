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
    , "bootstrap-datetimepicker.zh-CN"
    , "fileinput"
    , "fileinput_locale_zh"
    , "ueditor"
], function (Vue) {
    Vue.component('c-uedit', {
        template: '<div></div>',
        props: {
            url: String,
            field: String,
            value: String
        },
        mounted() {
            var uid = "c" + Math.random(100) * Math.pow(10, 18);
            $(this.$el).html(this.value).attr("id", uid);
            var ue = this.vue = UE.getEditor(uid, {
                autoHeight: true,
                autoFloatEnabled: false
            });
            ue.setContent(this.value);
            ue.addListener("selectionchange", function (type, arg1, arg2) {
                cur.$emit('input', arg1);
                console.log(arg1 + " " + arg2);
            });
        }
    });

    function genfields(data) {
        var html = [];
        for (var p in data) {
            if (data[p])
                html.push('\
            <div class="form-group">\
                <label for="xx" class="col-xs-3 control-label">xx</label>\
                <div class="col-xs-8"><input type="text" name="xx" value="yy" class="form-control"/></div>\
             </div>'.replace(/xx/g, p).replace(/yy/g, data[p]));
            else
                html.push('\
            <div class="form-group">\
                <label for="xx" class="col-xs-3 control-label">xx</label>\
                <div class="col-xs-8"><input type="text" v-model="xx" class="form-control"/></div>\
             </div>'.replace(/xx/g, p))
        }
        return html.join("<br />")
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
        beforeMount() {
            this.init();
        },
        methods: {
            save() {
                this.$emit('save');
            },
            init() {
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
                })
            }
        }
    });

    window.Call = function Call(method, data, callback) {
        var domain = '/';
        if ($.cookie) {
            $.cookie('auth_user', $.cookie('auth_user') || $(document.body).data('auth_user'), {
                expires: 99999,
                path: domain
            });
            var cookie = $.cookie('auth_user');
        }
        cookie = cookie || $(document.body).data('auth_user');
        $.post(SVC_NEW + "?method=" + method + '&auth_user=' + cookie, {data: JSON.stringify(data)}, function (resp) {
            if (!callback) {
                callback = function (one) {
                    console.log(one);
                }
            }
            if (callback) callback(resp);
            else console.error(resp);
        });
    };

    $.fn.table = function (options) {
        var defaultoption = {
            method: 'get',
            toolbar: '#toolbar',
            striped: true,
            cache: false,
            pagination: true,
            sortable: true,
            queryParamsType: "limit",
            detailView: false,
            sidePagination: "server",
            pageSize: 10,
            pageList: [10, 25, 50, 100],
            search: true,
            showColumns: true,
            showRefresh: true,
            minimumCountColumns: 2,
            clickToSelect: true
        };
        $(this).bootstrapTable($.extend(defaultoption, options))
    };
    Array.prototype.set = function () {
        var obj = {};
        return this.filter(function (a) {
            return !obj[a] && (obj[a] = 1
                )
        });
    };
    Array.prototype.groupby = function (key, fn) {
        var obj = {};
        $.each(this, function () {
            obj[this[key]] = obj[this[key]] || [];
            if (fn) {
                obj[this[key]].push(fn(this));
            } else {
                obj[this[key]].push(this);
            }
        });
        return obj;
    };

    $.extend({
        failed(data) {
            if (!data) {
                alert('未取到任何数�?');
                return true;
            }
            if (!data.success) {
                alert(data.message);
                return true;
            }
            return false;
        },
        log() {
            console.log(arguments);
            return arguments;
        },
        print(o) {
            var val = o || this;
            console.log(val, '\n', JSON.stringify(val));
            return val;
        },
        test() {
            var f = function () {
                console.log(1)
            };
            $.setTimeoutQueue([f, f, f, f, f], 1000)
        },
        repeat(n, o) {
            return this.range(n).map(function () {
                return o;
            })
        },
        range(a, b) {
            if (!a)return [];
            var arr = [];
            if (!b) {
                b = a, a = 0;
            }
            for (var i = a; i < b; ++i) {
                arr.push(i);
            }
            return arr;
        },
        setTimeoutQueue(arr, n) {
            if (!arr || arr.length === 0)return;
            var f = this;
            setTimeout(function () {
                arr[0]();
                f.setTimeoutQueue(arr.slice(1), n)
            }, n)
        },
        calcCenter(points) {
            if (!points || points.length === 0)return [0, 0];
            var minx, miny, maxx, maxy;
            minx = miny = 4000;
            maxx = maxy = -4000;
            for (var j = 0; j < points.length; ++j) {
                var cur = points[j];
                var x = cur[0];
                var y = cur[1];
                if (x < minx) {
                    minx = x;
                }
                if (x > maxx) {
                    maxx = x;
                }
                if (y < miny) {
                    miny = y;
                }
                if (y > maxy) {
                    maxy = y;
                }
            }
            var center = [
                ((maxx - minx) / 2 + minx),
                ((maxy - miny) / 2 + miny)
            ];
            return center;
        },
        login(user, pwd) {
            $.call('login', {
                UILoginName: user || 'xiangxi',
                UIPassword: pwd || 'xiangxi'
            }, function (data) {
                if (!(data && data.success)) {
                    alert(data.message || data)
                } else {
                    var domain = '/';
//if(location.href.indexOf(':')!==-1)domain = location.href.substr(0,location.href.indexOf('/',8)+1);
                    if (data.data) {
                        $.cookie('auth_user', data.data, {expires: 99999, path: domain});
                        $(document.body).data('auth_user', data.data)
                    }
                    if (location.href.indexOf('C-login.html') !== -1) location.href = '../1_index/C-business.html'
                }
            });
        },
        back2login() {
            location.href = '/XiangXi/4_login/C-login.html';
        },
        select(obj, props) {
            var o = {};
            for (var p in obj) {
                if (props.find(function (k) {
                        return k === p
                    })) {
                    o[p] = obj[p];
                }
            }
            return o;
        },
        call(method, data, callback) {
            var thiz = this;
            return Call(method, data, resp=>{
                if (resp && !resp.success && resp.message && resp.message.indexOf('请登录') !== -1) this.back2login();
                if (callback) callback(resp)
            });
        },
        callsync(method, data) {
            var thiz = this;
            var text = $.ajax({
                url: SVC_NEW + "?method=" + method + '&auth_user=' + $.cookie("auth_user"),
                data: {data: JSON.stringify(data)},
                async: false
            }).responseText;
            if (text && text[0] !== '{') {
                alert(text);
                return;
            }
            var resp = JSON.parse(text);
            if (resp && !resp.success && resp.message && resp.message.indexOf('请登录') !== -1) thiz.back2login();
            return resp;
        },
        mapSearch(key, fn) {
            AMap.plugin('AMap.Autocomplete', function () {
                var autoOptions = {
                    city: '苏州'
                };
                var autoComplete = new AMap.Autocomplete(autoOptions);
                autoComplete.search(key, function (status, result) {
                    fn(result);
                })
            })
        }
    });

    //c-table
    Vue.component('c-table', {
        template: '<table></table>', props: ['method', 'columns'],
        mounted() {
            this.init();
        },
        methods: {
            getcolumns() {
                var defaultcolumns = [];
                var resp = $.callsync(this.method);
                if (!resp)return;
                var rows = resp.rows;
                if (rows)
                    $.each(rows[0], function (t) {
                        defaultcolumns.push(
                            {
                                field: t,
                                title: t,
                                sortable: true,
                                align: "center"
                            })
                    });
                defaultcolumns = [defaultcolumns];
                return defaultcolumns;
            },
            init() {
                $(this.$el).table({
                    url: '/XiangXi/DefaultHandler.ashx?method=' + this.method,
                    queryParams(param) {
                        $.print(param);
                        return {data: JSON.stringify(param)}
                    },
                    columns: this.columns || this.getcolumns()
                });
            }
        }
    });

    //c-typeahead
    Vue.component("c-typeahead", {
        inherantVisible: false,
        template: '<input type="text" ' +
        'data-provide="typeahead" ' +
        ':value="value" ' +
        '@input="$emit(\'input\', $event.target.value)" ' +
        'class="form-control">',
        props: {
            url: String,
            field: String,
            value: String
        },
        mounted() {
            this.init();
        },
        methods: {
            init() {
                var cur = this;
                var url = cur.url;
                var field = cur.field;
                $(cur.$el).typeahead({
                    updater(val) {
                        cur.$emit('input', val);
                        return val;
                    },
                    source(query, process) {
                        if (!query || query.trim().length === 0)return;
                        var search = query.trim();
                        var parameter = {search: search};
                        $.get(url, parameter, function (data) {
                            var dic = {};
                            var rows = data.rows.map(function (i) {
                                return i[field]
                            }).filter(function (i) {
                                return i && i.length > 0 && !dic[i] && (dic[i] = i)
                            });
                            if (rows && rows.length > 0)process(rows);
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
        mounted() {
            this.load(this.paint)
        },
        methods: {
            load(callback) {
                $.getJSON(svcHeader + this.url, {}, callback)
            },
            paint(data) {
                // temp_data is the default structure.
                var temp_data={
                    "series": [
                        {
                            "name": "80到90岁",
                            "value": 2
                        },
                        {
                            "name": "50到60岁",
                            "value": 13
                        }
                    ]
                };


                var thiz = this;
                var series = data;
                if (!series) return;
                var title = thiz.title;
                var subtitle = thiz.subtitle;
                console.log(thiz.$el)
                thiz.$myChart = echarts.init(thiz.$el)
                    .setOption({
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
                        series: [
                            {
                                name: '比例',
                                type: 'pie',
                                radius: '55%',
                                center: ['50%', '60%'],
                                data: data.series
                            }
                        ]
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
        mounted() {
            this.init()
        },
        methods: {
            load(callback) {
                $.getJSON(svcHeader + this.url, {}, callback)
            },
            init() {
                var thiz = this;
                thiz.load(function (data) {
                    var px = function (n) {
                        if (typeof(n) === 'string' && n.indexOf('px') !== -1) return n;
                        return `${n}px`;
                    };
                    var width = px(thiz.width || $(window).width());
                    var height = px(thiz.height || $(window).height());
                    var id = `c${Math.random(10) * Math.pow(10, 18)}`;
                    $(thiz.$el)
                        .attr('id', id)
                    echarts.init(thiz.$el, 'macarons')
                        .setOption({
                            title: {
                                text: thiz.title + '统计',
                                x: 'center'
                            },
                            tooltip: {
                                trigger: 'axis'
                            },
                            calculable: true,
                            xAxis: [
                                {
                                    type: 'category',
                                    splitLine: {show: false},
                                    data: data.xaxis
                                }
                            ],
                            yAxis: [
                                {
                                    type: 'value',
                                    position: 'left'
                                }
                            ],
                            series: [
                                {
                                    name: '数量',
                                    type: 'bar',
                                    tooltip: {trigger: 'item'},
                                    data: data.series
                                }
                            ]
                        })
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
        mounted() {
            this.init()
        },
        methods: {
            load(callback) {
                $.getJSON(svcHeader + this.url, {}, callback)
            },
            init() {
                var thiz = this;
                thiz.load(function (data) {
                    var height = thiz.height || $(window).height();
                    var width = thiz.width || $(window).width();
                    $(thiz.$el).css({"width": width, "height": height});
                    echarts.init(thiz.$el, 'macarons')
                        .setOption({
                            title: {
                                text: thiz.title + '折线统计',
                                subtext: '日期:' + new Date().toLocaleDateString(),
                                x: 'center'
                            },
                            tooltip: {
                                trigger: 'axis'
                            },
                            calculable: true,
                            xAxis: [
                                {
                                    type: 'category',
                                    splitLine: {show: false},
                                    data: data.xaxis
                                }
                            ],
                            yAxis: [
                                {
                                    type: 'value',
                                    position: 'left'
                                }
                            ],
                            series: [
                                {
                                    name: '数量',
                                    type: 'line',
                                    tooltip: {trigger: 'item'},
                                    data: data.series
                                }
                            ]
                        });
                })
            }
        }
    });

    Vue.component('c-select', {
        template: '<select class="selectpicker form-control"></select>',
        props: ['value', 'options'],
        methods: {
            init() {
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
                    thiz.$emit("input", this.value)
                });
                el.selectpicker('val', thiz.value);
                el.selectpicker('refresh')
            }
        },
        mounted() {
            this.init();
        }
    });
    Vue.component('c-date', {
        template: '<input size="16" type="text" class="form_datetime form-control">',
        props: ['value', 'format', 'minView', 'maxView'],
        mounted() {
            this.init();
        },
        methods: {
            init() {
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
                el.on('changeDate', (ev)=>{
                    thiz.$emit('input', this.value)
                });
            }
        }
    });
    Vue.component('c-icon', {
        template: '<img />',
        props: ['label', 'color1', 'color2', 'width', 'height', 'nolabel'],
        mounted() {
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
        props: ['value', 'language', 'uploadUrl',
            'allowedFileExtensions', 'showUpload', 'dropZoneEnabled',
            'showCaption', 'browseClass', 'previewFileIcon', 'msgFilesTooMany'],
        mounted() {
            var thiz = this;
            var options = {
                language: thiz.language || "zh", //设置语言
                uploadUrl: thiz.uploadUrl || svcHeader + "/XiangXi/ImageUpload.ashx?",
                allowedFileExtensions: thiz.allowedFileExtensions || ["jpg", "png", "gif", "JPEG"],
                showUpload: thiz.showUpload || true, //是否显示上传按钮
                dropZoneEnabled: thiz.dropZoneEnabled || false,
                showCaption: thiz.showCaption || true, //是否显示标题
                browseClass: thiz.browseClass || "btn btn-primary", //按钮样式
                previewFileIcon: thiz.previewFileIcon || "<i class='glyphicon glyphicon-king'></i>",
                msgFilesTooMany: thiz.msgFilesTooMany || "选择上传的文件数�?({n}) 超过允许的最大数值{m}�?"
                //initialPreview: []
            };
            if (thiz.value && thiz.value.length > 0) {
                options.initialPreview = thiz.value.split(',').filter(function (s) {
                    return s;
                }).map(function (s) {
                    return "<img src='" + s + "' class='file-preview-image' alt='Desert' title='Desert'>"
                });
            }
            $(thiz.$el).fileinput(options);
            $(thiz.$el).on("fileuploaded", function (event, data, previewId, index) {
                thiz.$emit('input', thiz.value + ',' + data.response.imageURL)
            });
            $(thiz.$el).on('fileclear', function (event) {
                thiz.$emit('input', '')
            });
        }
    });

    return {};
});
