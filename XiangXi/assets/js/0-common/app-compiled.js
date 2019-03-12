"use strict";

var _shim;

function _defineProperty(obj, key, value) {
    if (key in obj) {
        Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true });
    } else {
        obj[key] = value;
    }return obj;
}

/*-------------所有可能加载的脚本--------------*/
require.config({
    paths: {
        "leaflet": ["../assets/js/0-common/leaflet"],
        "leaflet.contextmenu": ["../assets/Leaflet/plugins/Leaflet.contextmenu/leaflet.contextmenu"],
        "leaflet.MiniMap": ["../assets/Leaflet/plugins/Leaflet-MiniMap-master/Control.MiniMap"],
        "leaflet.Zoomslider": ["../assets/Leaflet/plugins/Leaflet.zoomslider-0.6.1/L.Control.Zoomslider"],
        "leaflet.fullscreen": ["../assets/Leaflet/plugins/Leaflet.fullscreen-gh-pages/Leaflet.fullscreen"],
        "leaflet.draw": ["../assets/Leaflet/plugins/Leaflet.draw-master/leaflet.draw-src"],
        "leaflet.measurecontrol": ["../assets/Leaflet/plugins/Leaflet.MeasureControl-gh-pages/leaflet.measurecontrol"],
        "leaflet.MarkerCluster": ["../assets/Leaflet/plugins/Leaflet.markercluster/leaflet.markercluster"],
        "leaflet.usermarker": ["../assets/Leaflet/plugins/Leaflet-usermarker-master/leaflet.usermarker"],
        "leaflet.defaultextent": ["../assets/Leaflet/plugins/Leaflet.defaultextent-master/leaflet.defaultextent"],
        "leaflet.echarts": ["../assets/Leaflet/plugins/Leaflet-echarts-master/leaflet-echarts"],
        "leaflet.echarts-source": ["../assets/Leaflet/plugins/Leaflet-echarts-master/echarts.source"],
        "cmodules": ["../assets/js/0-common/cmodules"],
        "jquery": ["https://cdn.bootcss.com/jquery/3.3.1/jquery.min"],
        "bootstrap": ["https://cdn.bootcss.com/bootstrap/3.0.0/js/bootstrap.min"],
        "bootstrap-table-locale-all": ["https://cdn.bootcss.com/bootstrap-table/1.10.0/bootstrap-table-locale-all"],
        "bootstrap-table-zh-CN": ["https://cdn.bootcss.com/bootstrap-table/1.10.0/locale/bootstrap-table-zh-CN.min"],
        "bootstrap-table": ["https://cdn.bootcss.com/bootstrap-table/1.10.0/bootstrap-table"],
        "bootstrap-table-export": ["../assets/js/0-common/bootstrap-table-export"],
        "tableExport": ["../assets/js/0-common/tableExport"],
        "bootstrap-editable": ["https://cdn.bootcss.com/x-editable/1.5.1/bootstrap-editable/js/bootstrap-editable"],
        "bootstrap-table-editable": ["https://cdn.bootcss.com/x-editable/1.5.1/bootstrap-editable/js/bootstrap-editable"],
        "jquery.cookie": ["https://cdn.bootcss.com/jquery-cookie/1.4.1/jquery.cookie.min"],
        "TileHeadPic": ["../assets/js/0-common/TileHeadPic"],
        "modernizr": ["../assets/js/0-common/modernizr"],
        "fileinput": ["../assets/js/0-common/fileinput.min"],
        "fileinput_locale_zh": ["../assets/js/0-common/fileinput_locale_zh"],
        "bootstrap-select": ["https://cdn.bootcss.com/bootstrap-select/2.0.0-beta1/js/bootstrap-select.min"],
        "mq-map": [" https://www.mapquestapi.com/sdk/leaflet/v2.2/mq-map.js?key=lYrP4vF3Uk5zgTiGGuEzQGwGIVDGuy24"],
        "mq-routing": ["https://www.mapquestapi.com/sdk/leaflet/v2.2/mq-routing.js?key=lYrP4vF3Uk5zgTiGGuEzQGwGIVDGuy24"],
        "leaflet-routing-machine": ["leaflet-routing-machine-master/dist/leaflet-routing-machine.min"],
        "control.geocoder": ["leaflet-routing-machine-master/examples/control.geocoder"],
        "bootstrap-datetimepicker": ["https://cdn.bootcss.com/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min"],
        "bootstrap-datetimepicker.zh-CN": ["https://cdn.bootcss.com/bootstrap-datetimepicker/2.1.30/js/locales/bootstrap-datetimepicker.zh-CN"],
        "notifyme": ["../assets/js/0-common/notifyme"],
        "echarts": [
        //'https://cdn.bootcss.com/echarts/4.1.0.rc2/echarts.min'
        'https://cdn.bootcss.com/echarts/2.2.7/echarts-all'],
        "popper.js": ["https://cdn.bootcss.com/popper.js/0.2.0/popper"],
        "pie": ['../assets/js/0-common/pie'],
        "baguetteBox": ["../assets/js/0-common/baguetteBox"],
        "ztree": ["../assets/js/0-common/jquery.ztree.all.min"],
        "validationengine-en": ["../assets/js/fullcanlendar/formvalidator/js/jquery.validationengine-en"],
        "validationengine": ["../assets/js/fullcanlendar/formvalidator/js/jquery.validationengine"],
        "moment-with-locales": "https://cdn.bootcss.com/moment.js/2.22.1/moment-with-locales",
        "moment-zh-cn": "https://cdn.bootcss.com/moment.js/2.22.1/locale/zh-cn",
        "moment": "https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.22.2/moment.min",
        "bootstrap-popover": ["https://cdn.bootcss.com/bootstrap/2.3.1/js/bootstrap-popover.min"],
        "fullcalendar": ["../node_modules/fullcalendar/dist/fullcalendar.min"],
        "fullcalendar-zh-cn": ["../assets/js/0-common/fullcalendar-zh-cn"],
        "fullcalendar-custom": ["../assets/js/fullcanlendar/jquery-ui-1.8.6.custom.min"],
        "fullcalendar-timepicker-addon": ["../assets/js/fullcanlendar/jquery-ui-timepicker-addon"],
        "vue": ["https://cdn.bootcss.com/vue/2.5.17-beta.0/vue"],
        "bootstrap-typeahead": ["https://cdn.bootcss.com/bootstrap/2.3.1/js/bootstrap-typeahead.min"],
        "amap": [
        //"http://webapi.amap.com/maps?v=1.4.6&key=f053dcd72f0ad04daeaa371b0b410bac",
        "http://webapi.amap.com/maps?v=1.4.6&key=d19bd922e0ef902491adfea1eb684502&"],
        'ueditor.config': ['../assets/UEditor-utf8-net/ueditor.config'],
        'ueditor': ['../assets/UEditor-utf8-net/ueditor.all']
    },
    shim: (_shim = {
        ueditor: {
            exports: 'ueditor',
            deps: ['../assets/UEditor-utf8-net/third-party/zeroclipboard/ZeroClipboard', '../assets/UEditor-utf8-net/ueditor.config'
            //, '../assets/UEditor-utf8-net/lang/zh-cn/zh-cn.js'
            ]
        },
        echarts: {
            exports: 'echarts'
            //deps: ["http://cache.amap.com/lbs/static/addToolbar"]
        },
        amap: {
            //deps: ["http://cache.amap.com/lbs/static/addToolbar"]
        },
        fullcalendar: {
            deps: ['moment-zh-cn']
        },
        jquery: {
            exports: 'jquery'
        },
        bootstrap: {
            deps: ['jquery']
        },
        "jquery.cookie": {
            deps: ['jquery']
        },
        TileHeadPic: {
            deps: ['jquery']
        },
        popmenu: {
            deps: ['jquery']
        },
        jquerygeo: {
            deps: ['jquery']
        },
        "bootstrap-table-zh-CN": {
            deps: ['bootstrap-table']
        },
        "bootstrap-table": {
            deps: ['bootstrap']
        },
        'bootstrap-table-locale-all': { deps: ['bootstrap-table'] },
        fileinput: {
            deps: ['bootstrap']
        },
        fileinput_locale_zh: {
            deps: ['fileinput']
        },
        "bootstrap-select": {
            deps: ['bootstrap']
        },
        "bootstrap-typeahead": {
            deps: ['bootstrap']
        },
        'bootstrap-datetimepicker': {
            deps: ['bootstrap']
        },
        "bootstrap-datetimepicker.zh-CN": {
            deps: ['bootstrap-datetimepicker']
        },
        leaflet: {
            exports: 'leaflet'
        },
        "leaflet.contextmenu": {
            deps: ['leaflet']
        },
        "leaflet.MiniMap": {
            deps: ['leaflet']
        },
        "leaflet.Zoomslider": {
            deps: ['leaflet']
        },
        "leaflet.fullscreen": {
            deps: ['leaflet']
        },
        "leaflet.draw": {
            deps: ['leaflet']
        },
        "leaflet.measurecontrol": {
            deps: ['leaflet.draw']
        },
        "leaflet.MarkerCluster": {
            deps: ['leaflet']
        },
        "leaflet.MarkerClusterGroup": {
            deps: ['leaflet']
        },
        "leaflet.usermarker": {
            exports: 'leaflet.usermarker',
            deps: ['leaflet']
        },
        "leaflet.defaultextent": {
            exports: 'leaflet.defaultextent',
            deps: ['leaflet']
        },
        "mq-map": {
            deps: ['leaflet']
        },
        "mq-routing": {
            deps: ['leaflet']
        },
        "leaflet-routing-machine": {
            deps: ['leaflet']
        },
        "control.geocoder": {
            deps: ['leaflet']
        },
        "leaflet.config": {
            deps: ['leaflet']
        },
        moment: {
            deps: ['jquery', "moment-with-locales"]
        },
        "moment-zh-cn": {
            deps: ['jquery', "moment"]
        }
    }, _defineProperty(_shim, "fullcalendar", {
        deps: ['moment']
    }), _defineProperty(_shim, "fullcalendar-zh-cn", {
        deps: ['fullcalendar']
    }), _defineProperty(_shim, "notifyme", {
        deps: ['jquery']
    }), _defineProperty(_shim, "leaflet.echarts", {
        deps: ['leaflet']
    }), _defineProperty(_shim, "leaflet.echarts-source", {
        deps: ['leaflet.echarts']
    }), _defineProperty(_shim, "ztree", {
        deps: ['jquery']
    }), _defineProperty(_shim, "validationengine-en", {
        deps: ['jquery']
    }), _defineProperty(_shim, "validationengine", {
        deps: ['fullcalendar2']
    }), _defineProperty(_shim, "fullcalendar2", {
        deps: ['jquery']
    }), _defineProperty(_shim, "fullcalendar-custom", {
        deps: ['jquery']
    }), _defineProperty(_shim, "fullcalendar-timepicker-addon", {
        deps: ['jquery']
    }), _shim)
});

/*---------------接口地址----------------*/
//脚本里用到的所有的转发连接都放在这里
var svcHeader = (window.location.protocol ? window.location.protocol + "//" : "") + window.location.host;
if (window.location.href.indexOf("localhost") !== -1) {
    svcHeader = "http://localhost";
}
var SVC_SYS = svcHeader + "/XiangXiService/System.svc";
var SVC_DYNC = svcHeader + "/XiangXiService/Dynamic.svc";
var SVC_POP = svcHeader + "/XiangXiService/Population.svc";
var SVC_PARTY = svcHeader + "/XiangXiService/PartyService.svc";
var SVC_MAP = svcHeader + "/XiangXiService/Map.svc";
var SVC_AGR = svcHeader + "/XiangXiService/Agriculture.svc";
var SVC_BUS = svcHeader + "/XiangXiService/Business.svc";
var SVC_NEW = svcHeader + "/XiangXi/DefaultHandler.ashx";
var SVC_DOWNLOAD = svcHeader + "/XiangXiNewService/Service.svc/DownloadFile";

var siteHeader = svcHeader;
var site_gen = siteHeader + "/XiangXi/gen/";
var site_cover = siteHeader + "/XiangXi/upload/cover/";
var site_population = siteHeader + "/XiangXi/2-population/";
var site_business = siteHeader + "/XiangXi/3-business/";

/*----------------集成方法---------------*/
function Download(file, callback) {
    $.get(SVC_DOWNLOAD, { downfile: file }, callback);
}

//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg); //匹配目标参数
    if (r != null) return unescape(r[2]);
    return null; //返回参数值
}
//注销
var logout = function logout() {
    $.cookie("JTZH_userID", null, { path: "/" });
    $.cookie("JTZH_districtID", null, { path: '/' });
    window.location.href = "../login.html";
};
function bootstrap_alert(msg) {
    $(".alert").remove();
    $('<div class="alert alert-danger">' + msg + '</div>').insertBefore('form:first-child');
}
function parseParam(param, key) {
    var paramStr = "";
    if (param instanceof String || param instanceof Number || param instanceof Boolean) {
        var val = encodeURIComponent(param);
        var keyval = key + "=" + val;
        paramStr += "&" + keyval;
    } else {
        $.each(param, function (i) {
            //if (this instanceof Window) return;
            var k = key == null ? i : key + (param instanceof Array ? "[" + i + "]" : "." + i);
            var keypaire = parseParam(this, k);
        });
    }
    return paramStr.substr(1);
};
function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串   
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        var arr = str.split("&");
        for (var i = 0; i < arr.length; i++) {
            var split = arr[i].split("=");
            var val = decodeURI(split[1]);
            val = val.indexOf('%') ? unescape(val) : val;
            theRequest[split[0]] = val;
        }
    } else {
        return null;
    }
    return theRequest;
}
function slashDate2yyyyMMdd(str) {
    "/Data(12345) => 2010-1-1";

    if (!str || str.indexOf('T') == 0) return str;
    var date = str.substr(0, 10);
    return date;

    //if (!str || str.indexOf('/Date(') !== 0)return str;
    //var d = eval('new ' + str.substr(1, str.length - 2));

    //var ar_date = [d.getFullYear(), d.getMonth() + 1, d.getDate()];

    //function dFormat(i) {
    //    return i < 10 ? "0" + i.toString() : i;
    //}

    //for (var i = 0; i < ar_date.length; i++) ar_date[i] = dFormat(ar_date[i]);
    //return ar_date.join('-')
}

var clearPopup = function clearPopup() {
    $(".add-popup").html('');
};

/*-----------------------------------部分插件功能-------------------------------------*/
//获取table高度
function getHeight() {
    return $(window).height() - $('h1').innerHeight(true) - $('#container').innerHeight(true);
}

//人民币大小写转换
var c = "零壹贰叁肆伍陆柒捌玖".split("");
// ["零","壹","贰","叁","肆","伍","陆","柒","捌","玖"]
var _c = {}; // 反向对应关系
for (var i = 0; i < c.length; i++) {
    _c[c[i]] = i;
}
;

var d = "元***万***亿***万";
var e = ",拾,佰,仟".split(",");
function unit4(arr) {
    var str = "",
        i = 0;
    while (arr.length) {
        var t = arr.pop();
        str = c[t] + (t == 0 ? "" : e[i]) + str;
        i++;
    }

    str = str.replace(/[零]{2,}/g, "零");

    str = str.replace(/^[零]/, "");
    str = str.replace(/[零]$/, "");
    if (str.indexOf("零") == 0) {
        str = str.substring(1);
    }
    if (str.lastIndexOf("零") == str.length - 1) {
        str = str.substring(0, str.length - 1);
    }

    return str;
}
function _formatD(a) {
    // 转化整数部分
    var arr = a.split(""),
        i = 0,
        result = "";
    while (arr.length) {
        var arr1 = arr.splice(-4, 4);

        var dw = d.charAt(i),
            unit = unit4(arr1);

        if (dw == '万' && !unit) {
            dw = "";
        }
        result = unit + dw + result;
        i += 4;
    }
    return result == "元" ? "" : result;
}
function _formatF(b) {
    // 转化小数部分
    b = b || "";
    switch (b.length) {
        case 0:
            return "整";
        case 1:
            return c[b] + "角";
        default:
            return c[b.charAt(0)] + "角" + c[b.charAt(1)] + "分";
    }
}
function _format(n) {
    var a = ("" + n).split("."),
        a0 = a[0],
        a1 = a[1];
    return _formatD(a0) + _formatF(a1);
}

function parse4(u4) {
    var res = 0;
    while (t = /([零壹贰叁肆伍陆柒捌玖])([拾佰仟]?)/g.exec(u4)) {
        var n = _c[t[1]],
            d = {
            "": 1,
            "拾": 10,
            "佰": 100,
            "仟": 1000
        }[t[2]];
        res += n * d;
        u4 = u4.replace(t[0], "");
    }
    var result = "0000" + res;
    return result.substring(result.length - 4);
}
function _parseD(d) {
    var arr = d.replace(/[零]/g, "").split(/[万亿]/),
        rs = "";
    for (var i = 0; i < arr.length; i++) {
        rs += parse4(arr[i]);
    }
    ;
    return rs.replace(/^[0]+/, "");
};
function _parseF(f) {
    var res = "",
        t = f.replace(/[^零壹贰叁肆伍陆柒捌玖]+/g, "").split(""); // 去掉单位
    if (t.length) {
        res = ".";
    } else {
        return "";
    }
    ;
    for (var i = 0; i < t.length && i < 2; i++) {
        res += _c[t[i]];
    }
    ;
    return res;
};
function _parse(rmb) {
    var a = rmb.split("元"),
        a1 = a[1],
        a0 = a[0];
    if (a.length == 1) {
        a1 = a0;
        a0 = "";
    }
    return _parseD(a0) + _parseF(a1);
};
//小写转大写
function formatRMB(num) {
    var n = Number(num);
    if (!isNaN(num)) {
        if (num == 0) {
            return "零元整";
        } else {
            return _format(n);
        }
    } else {
        return false;
    }
}
//大写转小写
function parseRMB(rmb) {
    if (/^[零壹贰叁肆伍陆柒捌玖元万亿拾佰仟角分整]{2,}$/.test(rmb)) {
        var result = _parse(rmb);
        return rmb == this.formatRMB(result) ? result : result + "(?)";
    } else {
        return false;
    }
};
//生成随机颜色
function getRandomColor() {
    var c = '#';
    var cArray = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'];
    for (var i = 0; i < 6; i++) {
        var cIndex = Math.round(Math.random() * 15);
        c += cArray[cIndex];
    }
    return c;
}

/*----------------------------------地图配置信息--------------------------------------*/

//初始化
var CONST_MAPINIT = {
    center: [31.1967, 120.56652],
    zoom: 7,
    fullExtent: [[31.18922, 120.58178], [31.20601, 120.56527]]
};
//矢量
var CONST_SZMAP = {
    //2012年地图
    //url: 'http://mt{s}.szgis.cn/v2/gettile/?level={z}&row={y}&col={x}&maptype=map&imgtype=png',
    //2015年地图
    url: 'http://arcgis1.szgis.cn/arcgis/rest/services/SZ_MAP_20150902/MapServer/tile/{z}/{y}/{x}',
    options: {
        attribution: "苏州地图  审图号：苏S（2015）003号",
        errorTileUrl: "",
        maxZoom: 11,
        minZoom: 2,
        opacity: 1,
        subdomains: [1, 2, 3, 4],
        tileSize: 256,
        unloadInvisibleTiles: false,
        updateWhenIdle: false,
        zoomOffset: 0
    }
};
//影像
var CONST_SZSATELLITE = {
    //2012年地图
    //url: "http://mt{s}.szgis.cn/v2/gettile/?level={z}&row={y}&col={x}&maptype=satellite&imgtype=jpg",
    //2015年地图
    url: 'http://arcgis1.szgis.cn/arcgis/rest/services/SZ_SATELLITE_20150902/MapServer/tile/{z}/{y}/{x}',
    options: {
        attribution: "苏州影像  审图号：苏S（2015）003号",
        errorTileUrl: "",
        maxZoom: 11,
        minZoom: 2,
        opacity: 1,
        subdomains: [1, 2, 3, 4],
        tileSize: 256,
        unloadInvisibleTiles: false,
        updateWhenIdle: false,
        zoomOffset: 0
    }
};
//道路
var CONST_SZROAD = {
    //2012年地图
    //url: "http://mt{s}.szgis.cn/v2/gettile/?level={z}&row={y}&col={x}&maptype=road&imgtype=png",
    //2015年地图
    url: 'http://arcgis1.szgis.cn/arcgis/rest/services/SZ_ROAD_20151209/MapServer/tile/{z}/{y}/{x}',
    options: {
        attribution: "",
        errorTileUrl: "",
        maxZoom: 11,
        minZoom: 2,
        opacity: 1,
        subdomains: [1, 2, 3, 4],
        tileSize: 256,
        unloadInvisibleTiles: false,
        updateWhenIdle: false,
        zoomOffset: 0
    }
};
//兴趣点
var CONST_SZPoi = {
    //2012年地图
    //url: "http://mt{s}.szgis.cn/v2/gettile/?level={z}&row={y}&col={x}&maptype=poi&imgtype=png",
    //2015年地图
    url: 'http://arcgis1.szgis.cn/arcgis/rest/services/SZ_Poi_20151209/MapServer/tile/{z}/{y}/{x}',
    options: {
        attribution: "",
        errorTileUrl: "",
        maxZoom: 11,
        minZoom: 2,
        opacity: 1,
        subdomains: [1, 2, 3, 4],
        tileSize: 256,
        unloadInvisibleTiles: false,
        updateWhenIdle: false,
        zoomOffset: 0
    }
};
//交通
var CONST_SZCOMMUNITY = {
    url: "http://mt{s}.szgis.cn/v2/gettile/?level={z}&row={y}&col={x}&maptype=community&imgtype=png",
    options: {
        attribution: "",
        errorTileUrl: "",
        maxZoom: 11,
        minZoom: 2,
        opacity: 1,
        subdomains: [1, 2, 3, 4],
        tileSize: 256,
        unloadInvisibleTiles: false,
        updateWhenIdle: false,
        zoomOffset: 0
    }
};

/*----------地图API--初步整理------------*/
function mapCRS() {
    function transformMap(initOptions) {
        var This = this;

        this.map = null;
        this.load = function (container, options) {
            This.map = L.map(container, options);
        };
        this.initLayer = function (baseLayers, overlays) {
            if (!This.map) {
                new Error("未初始化地图对象");
            }
            for (var p in baseLayers) {
                baseLayers[p] = This.getTileLayer(baseLayers[p].url, baseLayers[p].options);
            }
            for (var p in overlays) {
                overlays[p] = This.getTileLayer(overlays[p].url, overlays[p].options);
            }
            L.control.layers(baseLayers, overlays).addTo(This.map);
        };
        this.getTileLayer = function (url, options) {
            return L.tileLayer(url, options);
        };

        this.panTo = function (latlng, options) {
            This.map.panTo(latlng, options);
        };
        this.setZoom = function (zoom, options) {
            This.map.setZoom(delta, options);
        };
        this.zoomIn = function (delta, options) {
            This.map.zoomIn(delta, options);
        };
        this.zoomOut = function (delta, options) {
            This.map.zoomOut(delta, options);
        };
        this.fullExent = function (bounds) {
            This.map.fitBounds(bounds);
        };
        this.fitBounds = function (xmin, ymin, xmax, ymax) {
            This.map.fitBounds([[xmin, ymin], [xmax, ymax]]);
        };
        this.remove = function () {
            This.map.remove();
            This.map = null;
        };
        this.clearOverlay = function () {
            //清空地图
            This.map.eachLayer(function (layer) {
                if (!layer._url) This.map.removeLayer(layer);
            }, This.map);
        };
    }

    L.Projection.Suzhou = {
        project: function project(t) {
            var x = 6378245;
            var v = 0.00335232986925914;
            var D = 120.583333;
            var i = -3421129;
            var s = 50805;
            var o = -75.812;
            var n = -10.233;
            var B = Math.PI / 180;
            var E = t.lat * B;
            var y = t.lng * B;
            var z = D * B;
            var p = 2 * v - v * v;
            var m = p / (1 - p);
            var k = Math.tan(E) * Math.tan(E);
            var w = Math.pow(m, 2) * Math.pow(Math.cos(E), 2);
            var G = (y - z) * Math.cos(E);
            var h = (1 - p / 4 - 3 * Math.pow(p, 2) / 64 - 5 * Math.pow(p, 3) / 256) * E;
            var g = (3 * p / 8 + 3 * Math.pow(p, 2) / 32 + 45 * Math.pow(p, 3) / 1024) * Math.sin(2 * E);
            var f = (15 * Math.pow(p, 2) / 256 + 45 * Math.pow(p, 3) / 1024) * Math.sin(4 * E);
            var d = 35 * Math.pow(p, 3) / 3072 * Math.sin(6 * E);
            var r = x * (h - g + f - d);
            var q = x / Math.sqrt(1 - p * Math.pow(Math.sin(E), 2));
            var e = r + q * Math.tan(E) * (Math.pow(G, 2) / 2 + (5 - k + 9 * w + 4 * Math.pow(w, 2)) * Math.pow(G, 4) / 24) + (61 - 58 * k + Math.pow(k, 2) + 270 * w - 330 * k * w) * Math.pow(G, 6) / 720;
            var c = q * (G + (1 - k + w) * Math.pow(G, 3) / 6 + (5 - 18 * k + Math.pow(k, 2) + 14 * w - 58 * k * w) * Math.pow(G, 5) / 120);
            var u = e + i + n;
            var j = c + s + o;
            return new L.Point(j, u);
        },
        unproject: function unproject(C) {
            var B = 6378245;
            var w = 0.00335232986925914;
            var I = 120.583333;
            var c = -3421129;
            var s = 50805;
            var m = -75.812;
            var h = -10.233;
            var v = C.x;
            var u = C.y;
            var q;
            var t;
            var K, J, e, p, E;
            var o, l, g, f;
            var r, H, G, D;
            q = 180 / Math.PI * 3600;
            v -= s;
            u -= c;
            v -= m;
            u -= h;
            K = u * q / 6367558.4969;
            J = K * Math.PI / 180 / 3600;
            H = Math.cos(J) * Math.cos(J);
            e = K + (50221746 + (293622 + (2350 + 22 * H) * H) * H) * Math.sin(J) * Math.cos(J) * q * 1e-10;
            p = e * Math.PI / 180 / 3600;
            G = Math.cos(p) * Math.cos(p);
            r = 6399698.902 - (21562.267 - (108.973 - 0.612 * G) * G) * G;
            o = (0.5 + 0.003369 * G) * Math.sin(p) * Math.cos(p);
            l = 0.333333 - (0.166667 - 0.001123 * G) * G;
            g = 0.25 + (0.16161 + 0.00562 * G) * G;
            f = 0.2 - (0.1667 - 0.0088 * G) * G;
            t = v / r / Math.cos(p);
            D = t * t;
            var n = e - (1 - (g - 0.12 * D) * D) * D * o * q;
            n = n / 3600;
            E = (1 - (l - f * D) * D) * t * q;
            var d = E / 3600 + I;
            return new L.LatLng(n, d);
        }
    };

    L.CRS.EPSG320500 = L.extend({}, L.CRS, {
        code: "EPSG320500",
        projection: L.Projection.Suzhou,
        originX: -20000,
        originY: 130000,
        minX: -20000,
        minY: -20000,
        maxX: 130000,
        maxY: 130000,
        tileSize: 256,
        latLngToPoint: function latLngToPoint(f, d) {
            var c = this.projection.project(f);
            c = this.checkProjectedPoint(c);
            var b = this.getSize(d);
            var a = b.x * ((c.x - this.originX) / (this.maxX - this.minX));
            var e = b.y * ((this.originY - c.y) / (this.maxY - this.minY));
            return new L.Point(a, e);
        },
        pointToLatLng: function pointToLatLng(a, e) {
            var f = parseFloat(this.scale(e));
            var d = a.x * (this.maxX - this.minX) / f + this.originX;
            var b = this.originY - a.y * (this.maxY - this.minY) / f;
            var c = new L.Point(d, b);
            c = this.checkProjectedPoint(c);
            return this.projection.unproject(c);
        },
        scale: function scale(a) {
            return this.tileSize * Math.pow(2, a);
        },
        getSize: function getSize(b) {
            var a = this.scale(b);
            return L.point(a, a);
        },
        checkProjectedPoint: function checkProjectedPoint(b) {
            var a = b.x;
            var c = b.y;
            while (a < this.minX) {
                a += this.maxX - this.minX;
            }
            while (a > this.maxX) {
                a -= this.maxX - this.minX;
            }
            while (c < this.minY) {
                c += this.maxY - this.minY;
            }
            while (c > this.maxY) {
                c -= this.maxY - this.minY;
            }
            return L.point(a, c);
        }
    });

    L.CRS.EPSG320501 = L.extend({}, L.CRS, {
        code: "EPSG320501",
        projection: L.Projection.Suzhou3D,
        originX: -500000,
        originY: 500000,
        minX: -500000,
        minY: -500000,
        maxX: 500000,
        maxY: 500000,
        tileSize: 256,
        latLngToPoint: function latLngToPoint(f, d) {
            var c = this.projection.project(f);
            c = this.checkProjectedPoint(c);
            var b = this.getSize(d);
            var a = b.x * ((c.x - this.originX) / (this.maxX - this.minX));
            var e = b.y * ((this.originY - c.y) / (this.maxY - this.minY));
            return new L.Point(a, e);
        },
        pointToLatLng: function pointToLatLng(a, e) {
            var f = this.scale(e);
            var d = this.originX + a.x / f * (this.maxX - this.minX);
            var b = this.originY - a.y / f * (this.maxY - this.minY);
            var c = new L.Point(d, b);
            c = this.checkProjectedPoint(c);
            return this.projection.unproject(c);
        },
        scale: function scale(a) {
            return this.tileSize * Math.pow(2, a);
        },
        getSize: function getSize(b) {
            var a = this.scale(b);
            return L.point(a, a);
        },
        checkProjectedPoint: function checkProjectedPoint(b) {
            var a = b.x;
            var c = b.y;
            while (a < this.minX) {
                a += this.maxX - this.minX;
            }
            while (a > this.maxX) {
                a -= this.maxX - this.minX;
            }
            while (c < this.minY) {
                c += this.maxY - this.minY;
            }
            while (c > this.maxY) {
                c -= this.maxY - this.minY;
            }
            return L.point(a, c);
        }
    });
}
function mapInit(map, zoomLevel) {
    //获取切片数据的URL，x,y是切片的坐标，z是缩放级别
    var osmUrl = CONST_SZSATELLITE.url,
        osm = L.tileLayer(osmUrl, {
        attribution: "苏州地图  审图号：苏S（2015）003号",
        errorTileUrl: "",
        maxZoom: 12,
        minZoom: 2,
        opacity: 1,
        subdomains: [1, 2, 3, 4],
        tileSize: 256,
        unloadInvisibleTiles: false,
        updateWhenIdle: false,
        zoomOffset: 0
    });

    $.ajax({
        url: SVC_MAP + "/getDistrictCenter",
        type: "GET",
        data: {
            districtID: $.cookie('JTZH_districtID')
        },
        success: function success(data) {
            //(data);
            var latlng = new L.LatLng(data.x, data.y);
            map.setView(latlng, zoomLevel);
        }, error: function error() {
            var latlng = new L.LatLng(31.0848565751, 120.4066879619);
            map.setView(latlng, zoomLevel);
        }
    });
    map.addLayer(osm);
    L.control.scale({
        imperial: false
    }).addTo(map);
    var miniMap = new L.Control.MiniMap(L.tileLayer(CONST_SZMAP.url, CONST_SZMAP.options), {
        width: 200,
        height: 200,
        toggleDisplay: true
    }).addTo(map);
    miniMap._toggleDisplayButtonClicked();
    var baseLayers = {
        "矢量地图": CONST_SZMAP,
        "影像地图": CONST_SZSATELLITE
    };
    var overlays = {
        "路网": CONST_SZROAD,
        "标注": CONST_SZPoi,
        "社区图": CONST_SZCOMMUNITY
    };
    for (var p in baseLayers) {
        baseLayers[p] = L.tileLayer(baseLayers[p].url, baseLayers[p].options);
    }
    for (var p in overlays) {
        overlays[p] = L.tileLayer(overlays[p].url, overlays[p].options);
    }
    L.control.layers(baseLayers, overlays, {
        position: 'bottomleft'
    }).addTo(map);
}
function locateExtent(pointList) {
    if (pointList && pointList.length > 0) {
        var xmin = 0,
            ymin = 0,
            xmax = 0,
            ymax = 0;
        for (var i = 0; i < pointList.length; i++) {
            if (i == 0) {
                xmin = pointList[i].lng;
                ymin = pointList[i].lat;
                xmax = pointList[i].lng;
                ymax = pointList[i].lat;
            } else {
                if (xmin > pointList[i].lng) {
                    xmin = pointList[i].lng;
                }
                if (ymin > pointList[i].lat) {
                    ymin = pointList[i].lat;
                }
                if (xmax < pointList[i].lng) {
                    xmax = pointList[i].lng;
                }
                if (ymax < pointList[i].lat) {
                    ymax = pointList[i].lat;
                }
            }
        }

        map.fitBounds([[ymin, xmin], [ymax, xmax]]);
    }
}
//清空
function cleanLayer(map) {
    map.eachLayer(function (layer) {
        if (!layer._url) map.removeLayer(layer);
    }, map);
}

//显示农田
function findFarmLand(latlng, farmLandID, map) {
    $.ajax({
        url: SVC_MAP + "/mapFindFarmLand",
        type: "GET",
        data: {
            farmLandID: farmLandID
        },
        success: function success(data) {
            map.eachLayer(function (layer) {
                if (!layer._url && layer.options && layer.options.color == "#009933" && layer._latlngs.length != 0) map.removeLayer(layer);
            }, map);
            var latlngs = new Array();
            for (var j in data.data.area) {
                latlngs.push(L.latLng(data.data.area[j].x, data.data.area[j].y));
            }
            L.polygon(latlngs, {
                color: '#009933',
                opacity: 0.5,
                fill: true,
                fillColor: "#FFFF00",
                fillOpacity: 0.7
            }).bindPopup('<div class="map_farmLand">' + '<table class="table table-bordered">' + '<tr><td class="success">塘口号</td><td>' + data.data.farmLandID + '</td><td class="success">塘口位置</td><td>' + data.data.address + '</td></tr>' + '<tr><td class="success">品种</td><td>' + data.data.product + '</td><td class="success">面积</td><td>' + data.data.farmArea + '</td></tr>' + '<tr><td class="success">承包人</td><td>' + data.data.name + '</td><td class="success">身份证</td><td>' + data.data.IDCard + '</td></tr>' + '</td><td>操作</td><td><button class="map_farmLand-back">返回</button></td></tr>' + '</table>' + '</div>', {
                minWidth: 500
            }).on('click', function () {
                $('.map_farmLand-back').click(function () {
                    map.setView(latlng, 11).closePopup();
                });
            }).addTo(map);
            map.fitBounds(latlngs);
        },
        error: function error() {}
    });
}

function strlimit(s, len) {
    if (s && s.length < len) return s;
    var slen = len / 2 - 2;
    return s.substr(0, slen) + '...' + s.substr(s.length - slen, slen);
}

//？
function detailFormatter(index, row) {
    var html = [];
    $.each(row, function (key, value) {
        html.push("<p><b>" + key + ":</b> " + value + "</p>");
    });
    return html.join("");
}

function imgFormatter(col) {
    return function (value, row, index) {
        if (row[col] && row[col].indexOf(',') != -1) return [row[col] ? row[col].split(',').map(function (i) {
            return '<img src="' + i + '" width="40" height="40" />';
        }).join('') : ''];
        return [row[col] ? '<img src="' + row[col] + '" width="40" height="40" />' : ''];
    };
}
function linkFormatter(col) {
    return function (value, row, index) {
        ;
        return [row[col] ? $('<a></a>').attr('href', row[col]).text(strlimit(row[col], 30)).get(0).outerHTML : ''];
    };
}
function limitFormatter(col) {
    return function (value, row, index) {
        ;
        return [row[col] ? strlimit(row[col], 20) : ''];
    };
}

//# sourceMappingURL=app.js.map

//# sourceMappingURL=app-compiled.js.map