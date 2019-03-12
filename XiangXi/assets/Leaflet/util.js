/**
* @class Array
*/
//Array.prototype.indexOf = function (o, from) {
//    var len = this.length;
//    from = from || 0;
//    from += (from < 0) ? len : 0;
//    for (; from < len; ++from) {
//        if (this[from] === o) {
//            return from;
//        }
//    }
//    return -1;
//};
//Array.prototype.remove = function (o) {
//    var index = this.indexOf(o);
//    if (index != -1) {
//        this.splice(index, 1);
//    }
//    return this;
//}

//Array.prototype.contains = function (e) {
//    ///<summary>Array扩展，检查数组中是否有某项</summary>
//    for (i = 0; i < this.length && this[i] != e; i++);
//    return !(i == this.length);
//}

//String.prototype.trim = function () {
//    ///<summary>String扩展，去除空格</summary>
//    return this.replace(/^\s+|\s+$/g, "");
//}

/*!
* Ext JS Library 3.2.0
* Copyright(c) 2006-2010 Ext JS, Inc.
* licensing@extjs.com
* http://www.extjs.com/license
*/
/**
* @class Ext.util.JSON
* Modified version of Douglas Crockford"s json.js that doesn"t
* mess with the Object prototype
* http://www.json.org/js.html
* @singleton
*/
/**
* @Util.JSON 此处全部使用Ext.util.JSON,只是将相关对象添加到这里使用
*/
var Util = {};
Util.JSON = new (function () {
    var useHasOwn = !!{}.hasOwnProperty,
        isNative = function () {
            var useNative = null;

            return function () {
                if (useNative === null) {
                    useNative = USE_NATIVE_JSON && window.JSON && JSON.toString() == '[object JSON]';
                }

                return useNative;
            };
        } (),
        USE_NATIVE_JSON = false,
        pad = function (n) {
            return n < 10 ? "0" + n : n;
        },
        doDecode = function (json) {
            return eval("(" + json + ')');
        },
        doEncode = function (o) {
            if (!isDefined(o) || o === null) {
                return "null";
            } else if (isArray(o)) {
                return encodeArray(o);
            } else if (isDate(o)) {
                return encodeDate(o);
            } else if (isString(o)) {
                return encodeString(o);
            } else if (typeof o == "number") {
                //don't use isNumber here, since finite checks happen inside isNumber  
                //isFinite函数用于检查其参数是否是无穷大
                return isFinite(o) ? String(o) : "null";
            } else if (isBoolean(o)) {
                return String(o);
            } else {
                var a = ["{"], b, i, v;
                for (i in o) {
                    // don't encode DOM objects
                    if (!o.getElementsByTagName) {
                        if (!useHasOwn || o.hasOwnProperty(i)) {
                            v = o[i];
                            switch (typeof v) {
                                case "undefined":
                                case "function":
                                case "unknown":
                                    break;
                                default:
                                    if (b) {
                                        a.push(',');
                                    }
                                    a.push(doEncode(i), ":",
                                        v === null ? "null" : doEncode(v));
                                    b = true;
                            }
                        }
                    }
                }
                a.push("}");
                return a.join("");
            }
        },
        m = {
            "\b": '\\b',
            "\t": '\\t',
            "\n": '\\n',
            "\f": '\\f',
            "\r": '\\r',
            '"': '\\"',
            "\\": '\\\\'
        },
        encodeString = function (s) {
            if (/["\\\x00-\x1f]/.test(s)) {
                return '"' + s.replace(/([\x00-\x1f\\"])/g, function (a, b) {
                    var c = m[b];
                    if (c) {
                        return c;
                    }
                    c = b.charCodeAt();
                    return "\\u00" +
                        Math.floor(c / 16).toString(16) +
                        (c % 16).toString(16);
                }) + '"';
            }
            return '"' + s + '"';
        },
        encodeArray = function (o) {
            var a = ["["], b, i, l = o.length, v;
            for (i = 0; i < l; i += 1) {
                v = o[i];
                switch (typeof v) {
                    case "undefined":
                    case "function":
                    case "unknown":
                        break;
                    default:
                        if (b) {
                            a.push(',');
                        }
                        a.push(v === null ? "null" : Util.JSON.encode(v));
                        b = true;
                }
            }
            a.push("]");
            return a.join("");
        },
        encodeDate = function (o) {
            return '"' + o.getFullYear() + "-" +
                pad(o.getMonth() + 1) + "-" +
                pad(o.getDate()) + "T" +
                pad(o.getHours()) + ":" +
                pad(o.getMinutes()) + ":" +
                pad(o.getSeconds()) + '"';
        },
        isDate = function (v) {
            return Object.prototype.toString.apply(v) === '[object Date]';
        },
        isArray = function (v) {
            return Object.prototype.toString.apply(v) === '[object Array]';
        },
        isString = function (v) {
            return typeof v === 'string';
        },
        isBoolean = function (v) {
            return typeof v === 'boolean';
        },
        isDefined = function (v) {
            return typeof v !== 'undefined';
        };


    /**
    * 

    Encodes a Date. This returns the actual string which is inserted into the JSON string as the literal expression.
    * The returned value includes enclosing double quotation marks.

    * 

    The default return format is "yyyy-mm-ddThh:mm:ss".

    * 

    To override this:


    Ext.util.JSON.encodeDate = function(d) {
    return d.format('"Y-m-d"');
    }; 

    /**
    * Encodes an Object, Array or other value
    * @param {Mixed} o The variable to encode
    * @return {String} The JSON string
    */
    this.encode = function () {
        var ec;
        return function (o) {
            if (!ec) {
                // setup encoding function on first access
                ec = isNative() ? JSON.stringify : doEncode;
            }
            return ec(o);
        };
    } ();



    /**
    * Decodes (parses) a JSON string to an object. If the JSON is invalid, this function throws a SyntaxError unless the safe option is set.
    * @param {String} json The JSON string
    * @return {Object} The resulting object
    */
    this.decode = function () {
        var dc;
        return function (json) {
            if (!dc) {
                // setup decoding function on first access
                dc = isNative() ? JSON.parse : doDecode;
            }
            return dc(json);
        };
    } ();

})();
/**
* Shorthand for {@link Ext.util.JSON#encode}
* @param {Mixed} o The variable to encode
* @return {String} The JSON string
* @member Ext
* @method encode
*/
Util.encode = Util.JSON.encode;
/**
* Shorthand for {@link Ext.util.JSON#decode}
* @param {String} json The JSON string
* @param {Boolean} safe (optional) Whether to return null or throw an exception if the JSON is invalid.
* @return {Object} The resulting object
* @member Ext
* @method decode
*/
Util.decode = Util.JSON.decode;

//Util.apply = function (o, c, defaults) {
//    if (defaults) {
//        Util.apply(o, defaults);
//    }
//    if (o && c && typeof c == 'object') {
//        for (var p in c) {
//            o[p] = c[p];
//        }
//    }
//    return o;
//};

//Util.NUM = function (value) {
//    //转换之前的科学计数法表示 
//    if (value && (typeof value == "string") && value.toLowerCase().indexOf('e') != -1) {
//        value = value.toLowerCase();
//        var result = value.split("e");
//        var resultValue = 0;
//        var power = 0;
//        if (result != null) {
//            resultValue = result[0];
//            power = result[1];
//            resultValue = resultValue * Math.pow(10, power);
//        }
//        return resultValue;
//    }
//    else {
//        return value;
//    }
//}

///* 颜色格式转换 */
//Util.HexToRGB = function (ColorHex) {
//    var colorArr = [];
//    var Red = parseInt("0x" + ColorHex.substr(0, 2));
//    var Green = parseInt("0x" + ColorHex.substr(2, 2));
//    var Blue = parseInt("0x" + ColorHex.substr(4, 2));
//    colorArr.push(Red);
//    colorArr.push(Green);
//    colorArr.push(Blue);
//    return colorArr;
//}
//geometry转wkt
/*WKT类型
ST_Point 

ST_LineString 

ST_Polygon 

ST_MultiPoint 

ST_MultiLineString 

ST_MultiPolygon 
*/
GeometryToWKT = function () {

}

GeometryToWKT.write = function (geometry) {
    var wkt = "";
    var wkt = new Array();
    switch (geometry.type) {
        case "point":
            wkt.push("POINT(");
            wkt = this.AppendCoordinate(geometry, wkt);
            wkt.push(")");
            break;
        case "polyline":
            wkt.push("LINESTRING(");
            wkt = this.AppendLineStringText(geometry, wkt);
            wkt.push(")");
            break;
        case "polygon":
            if (geometry.rings.length > 1) {
                wkt.push("MULTIPOLYGON (");
                wkt = this.AppendMultiPolygonText(geometry, wkt);
                wkt.push(")");
            }
            else {
                wkt.push("POLYGON((");
                wkt = this.AppendPolygonText(geometry, wkt);
                wkt.push("))");
            }
            break;
        case "extent":
            wkt.push("POLYGON((");
            wkt = this.AppendExtentText(geometry, wkt);
            wkt.push("))");
            break;
        default:
            wkt = "";
    }
    wkt = wkt.join("");
    return wkt;
};

GeometryToWKT.AppendCoordinate = function (geometry, wkt) {
    wkt.push(Util.NUM(geometry.x));
    wkt.push(" ");
    wkt.push(Util.NUM(geometry.y));
    return wkt;
};

GeometryToWKT.AppendExtentText = function (geometry, wkt) {
    wkt.push(Util.NUM(geometry.xmin));
    wkt.push(" ");
    wkt.push(Util.NUM(geometry.ymin));
    wkt.push(",");
    wkt.push(Util.NUM(geometry.xmax));
    wkt.push(" ");
    wkt.push(Util.NUM(geometry.ymin));
    wkt.push(",");
    wkt.push(Util.NUM(geometry.xmax));
    wkt.push(" ");
    wkt.push(Util.NUM(geometry.ymax));
    wkt.push(",");
    wkt.push(Util.NUM(geometry.xmin));
    wkt.push(" ");
    wkt.push(Util.NUM(geometry.ymax));
    wkt.push(",");
    wkt.push(Util.NUM(geometry.xmin));
    wkt.push(" ");
    wkt.push(Util.NUM(geometry.ymin));
    return wkt;
};

GeometryToWKT.AppendLineStringText = function (geometry, wkt) {
    if (geometry.paths.length == 1) {
        var path = geometry.paths[0];
        for (var i = 0; i < path.length; i++) {
            wkt.push(Util.NUM(path[i][0]));
            wkt.push(" ");
            wkt.push(Util.NUM(path[i][1]));
            if (i + 1 < path.length)
                wkt.push(",");
        }
    }
    return wkt;
}

GeometryToWKT.AppendPolygonText = function (geometry, wkt) {
    if (geometry.rings.length == 1) {
        var ring = geometry.rings[0];
        for (var i = 0; i < ring.length; i++) {
            wkt.push(Util.NUM(ring[i][0]));
            wkt.push(" ");
            wkt.push(Util.NUM(ring[i][1]));
            if (i + 1 < ring.length)
                wkt.push(",");
        }
    }
    return wkt;
};
GeometryToWKT.AppendMultiPolygonText = function (geometry, wkt) {
    if (geometry.rings.length > 1) {
        for (var i = 0; i < geometry.rings.length; i++) {
            wkt.push("((");
            for (var j = 0; j < geometry.rings[i].length; j++) {
                wkt.push(Util.NUM(geometry.rings[i][j][0]));
                wkt.push(" ");
                wkt.push(Util.NUM(geometry.rings[i][j][1]));
                if (j + 1 < geometry.rings[i].length)
                    wkt.push(",");
            }
            wkt.push("))");
            if (i + 1 < geometry.rings.length)
                wkt.push(",");
        }
    }
    return wkt;
};


//geometry转wkt
/*WKT类型
ST_Point 

ST_LineString 

ST_Polygon 

ST_MultiPoint 

ST_MultiLineString 

ST_MultiPolygon 
*/
function WKTToGeometry() {

}

WKTToGeometry.write2 = function (wkt, options) {
    var reg = /^\s*(\w+)\s*(\(+[^\(\)]+\)+)/
    var regValue = reg.exec(wkt);
    if (!regValue) { return null; }
    var wktType = regValue[1].toLowerCase();
    var wktJson = regValue[2];
    var srsId = "0";
    var geometry = null;
    switch (wktType) {
        case "point":
            var pointJson = wktJson.replace(/\(/g, "[").replace(/\)/g, "]");
            var re = /([-?\d\.]+[eE]?\d?)\s([-?\d\.]+[eE]?\d?)/g;
            pointJson = pointJson.replace(re, "[$1,$2]");
            var xy = Util.decode(pointJson); ;
            geometry = L.latLng(xy[0][0], xy[0][1]);
            break;
    }
    return geometry;
}

WKTToGeometry.write = function (wkt, options) {
    var reg = /^\s*(\w+)\s*(\(+[^\(\)]+\)+)/
    var regValue = reg.exec(wkt);
    if (!regValue) { return null; }
    var wktType = regValue[1].toLowerCase();
    var wktJson = regValue[2];
    var srsId = "0";
    var geometry = null;
    switch (wktType) {
        case "point":
            var pointJson = wktJson.replace(/\(/g, "[").replace(/\)/g, "]");
            var re = /([-?\d\.]+[eE]?\d?)\s([-?\d\.]+[eE]?\d?)/g;
            pointJson = pointJson.replace(re, "[$1,$2]");
            geometry = L.marker(Util.decode(pointJson.replace('[[', '[').replace(']]', ']')));
            break;
        case "linestring":
            //            var lineJson = wktJson.replace(/\(/g, "[").replace(/\)/g, "]");
            //            var re = /([-?\d\.]+[eE]?\d?)\s([-?\d\.]+[eE]?\d?)/g;
            //            lineJson = lineJson.replace(re, "[$1,$2]");
            //            lineJson = "{\"paths\":[" + lineJson;
            //            lineJson += "],\"spatialReference\":{\"wkid\":" + srsId + "}}";
            //            lineJson = Util.decode(lineJson);
            //geometry = new esri.geometry.Polyline(lineJson);
            break;
        case "polygon":
            var gonJson = wktJson.replace(/\(/g, "[").replace(/\)/g, "]");
            var re = /([-?\d\.]+[eE]?\d?)\s([-?\d\.]+[eE]?\d?)/g;
            gonJson = gonJson.replace(re, "[$1,$2]");
            var a = Util.decode(gonJson);
            if (a[0][0][0] > a[0][0][1]) {
                var tmp = 0;
                for (var i = 0; i < a.length; i++) {
                    for (var j = 0; j < a[i].length; j++) {
                        tmp = a[i][j][0];
                        a[i][j][0] = a[i][j][1];
                        a[i][j][1] = tmp;
                    }
                }
            }
            geometry = L.polygon(a, options)
            break;
        default:
            geometry = null;
    }
    return geometry;
};