/*!
    jQThumb V1.9.5
    Copyright (c) 2013-2014
    Dual licensed under the MIT and GPL licenses.
    Author       : Pak Cheong
    Version      : 1.9.5
    Last Updated : Thursday, July 10th, 2014, 5:18:48 PM
    Requirements : jQuery >=v1.3.0 or Zepto (with zepto-data plugin) >=v1.0.0
*/
! function(a, b, c) {
	function d(b, c) {
		this.element = b, this.settings = a.extend({}, g, c), this.settings.width = this.settings.width.toString().replace(/px/g, ""), this.settings.height = this.settings.height.toString().replace(/px/g, ""), this.settings.position.top = this.settings.position.top.toString().replace(/px/g, ""), this.settings.position.left = this.settings.position.left.toString().replace(/px/g, ""), this._defaults = g, this._name = e, "string" == typeof c ? "kill" == c.toLowerCase() && this.kill(this.element) : this.init()
	}
	var e = "jqthumb",
		f = {
			outputElems: [],
			inputElems: []
		},
		g = {
			classname: "jqthumb",
			width: 100,
			height: 100,
			position: {
				top: "50%",
				left: "50%"
			},
			source: "src",
			showoncomplete: !0,
			before: function() {},
			after: function() {},
			done: function() {}
		};
	d.prototype = {
		init: function() {
			this.support_css3_attr("backgroundSize") === !1 ? this.nonCss3Supported_method(this.element, this.settings) : this.css3Supported_method(this.element, this.settings)
		},
		kill: function(b) {
			if (a(b).data(e)) {
				if (a(b).prev().data(e) !== e) return console.error("We could not find the element created by jqthumb. It is probably due to one or more element has been added right before the image element after the plugin initialization, or it was removed."), !1;
				var c = [];
				a.each(f.outputElems, function(d, e) {
					a(e)[0] == a(b).prev()[0] || c.push(f.outputElems[d])
				}), f.outputElems = c, c = [], a.each(f.inputElems, function(d, e) {
					a(e)[0] == a(b)[0] || c.push(f.inputElems[d])
				}), f.inputElems = c, a(b).prev().remove(), a(b).removeAttr("style"), "undefined" != typeof a(b).data(e + "-original-styles") && a(b).attr("style", a(b).data(e + "-original-styles")), "undefined" != typeof a(b).data(e + "-original-styles") && a(b).removeData(e + "-original-styles"), "undefined" != typeof a(b).data(e) && a(b).removeData(e)
			}
		},
		nonCss3Supported_method: function(b, c) {
			c.before.call(b, b);
			var d = this,
				f = a(b);
			f.data(e + "-original-styles", f.attr("style")), f.hide();
			var g = a("<img/>");
			g.bind("load", function() {
				var h = {
						obj: g,
						size: {
							width: this.width,
							height: this.height
						}
					},
					i = d.percentOrPixel(c.width),
					j = d.percentOrPixel(c.height),
					k = a("<div />"),
					l = 0;
				a(k).insertBefore(f).append(a(h.obj)).css({
					position: "relative",
					overflow: "hidden",
					width: "%" == i ? c.width : c.width + "px",
					height: "%" == j ? c.height : c.height + "px"
				}).data(e, e), h.size.width > h.size.height ? (a(h.obj).css({
					width: "auto",
					"max-height": 99999999,
					"min-height": 0,
					"max-width": 99999999,
					"min-width": 0,
					height: a(h.obj).parent().height() + "px"
				}), l = a(h.obj).height() / a(h.obj).width(), a(h.obj).width() < a(h.obj).parent().width() && a(h.obj).css({
					width: a(h.obj).parent().width(),
					height: parseFloat(a(h.obj).parent().width() * l)
				})) : (a(h.obj).css({
					width: a(h.obj).parent().width() + "px",
					"max-height": 99999999,
					"min-height": 0,
					"max-width": 99999999,
					"min-width": 0,
					height: "auto"
				}), l = a(h.obj).width() / a(h.obj).height(), a(h.obj).height() < a(h.obj).parent().height() && a(h.obj).css({
					width: parseFloat(a(h.obj).parent().height() * l),
					height: a(h.obj).parent().height()
				})), posTop = "%" == d.percentOrPixel(c.position.top) ? c.position.top : c.position.top + "px", posLeft = "%" == d.percentOrPixel(c.position.left) ? c.position.left : c.position.left + "px", a(h.obj).css({
					position: "absolute",
					top: posTop,
					"margin-top": function() {
						return "%" == d.percentOrPixel(c.position.top) ? "-" + parseFloat(a(h.obj).height() / 100 * c.position.top.slice(0, -1)) + "px" : void 0
					}(),
					left: posLeft,
					"margin-left": function() {
						return "%" == d.percentOrPixel(c.position.left) ? "-" + parseFloat(a(h.obj).width() / 100 * c.position.left.slice(0, -1)) + "px" : void 0
					}()
				}), a(k).hide().addClass(c.classname), c.showoncomplete === !0 && a(k).show(), c.after.call(b, a(k)), d.updateGlobal(b, a(k), c)
			}).attr("src", f.attr(c.source))
		},
		css3Supported_method: function(b, c) {
			c.before.call(b, b);
			var d = this,
				f = a(b),
				g = a("<img />").attr("src", f.attr(c.source));
			f.data(e + "-original-styles", f.attr("style")), f.hide(), a.each(g, function(g, h) {
				var i = a(h);
				i.one("load", function() {
					var g = d.percentOrPixel(c.width),
						h = d.percentOrPixel(c.height),
						i = null,
						j = null;
					i = a("<div/>").css({
						width: "%" == g ? c.width : c.width + "px",
						height: "%" == h ? c.height : c.height + "px",
						display: "none"
					}).addClass(c.classname).data(e, e), j = a("<div/>").css({
						width: "100%",
						height: "100%",
						//"border-radius":"100%",
						"margin":"3px auto",
  						"cursor":"pointer",
  						'transition':' All 0.4s ease-in-out',
						'-webkit-transition':' All 0.4s ease-in-out',
						'-moz-transition':' All 0.4s ease-in-out',
						'-o-transition':' All 0.4s ease-in-out',
						"background-image": 'url("' + f.attr(c.source) + '")',
						"background-repeat": "no-repeat",
						"background-position": function() {
							var a = "%" == d.percentOrPixel(c.position.top) ? c.position.top : c.position.top + "px",
								b = "%" == d.percentOrPixel(c.position.left) ? c.position.left : c.position.left + "px";
							return a + " " + b
						}(),
						"background-size": "cover"
					}).hover(function(){
						$(this).css({
						"transform":  'scale(1.2)',
						"-webkit-transform":'scale(1.2)',
						"-moz-transform":'scale(1.2)',
						"-o-transform":'scale(1.2)',
						"-ms-transform":'scale(1.2)'
						})
					},function(){
						 
						$(this).css({
						"transform":  'scale(1)',
						"-webkit-transform":'scale(1)',
						"-moz-transform":'scale(1)',
						"-o-transform":'scale(1)',
						"-ms-transform":'scale(1)'
						})
					 
					}).appendTo(a(i)), a(i).insertBefore(a(b)), c.showoncomplete === !0 && a(i).show(), d.checkSrcAttrName(b, c), c.after.call(b, a(i)), d.updateGlobal(b, a(i), c)
				})
			})
		},
		updateGlobal: function(b, c, d) {
			b.global.outputElems.push(a(c)[0]), b.global.elemCounter++, f.outputElems.push(a(c)[0]), b.global.elemCounter == b.global.inputElems.length && d.done.call(b, b.global.outputElems)
		},
		checkSrcAttrName: function(b, c) {
			"src" == c.source || "undefined" != typeof a(b).attr("src") && "" !== a(b).attr("src") || a(b).attr("src", a(b).attr(c.source))
		},
		percentOrPixel: function(a) {
			return a = a.toString(), a.match("px$") || a.match("PX$") || a.match("pX$") || a.match("Px$") ? "px" : a.match("%$") ? "%" : void 0
		},
		support_css3_attr: function() {
			{
				var a = c.createElement("div"),
					b = "Khtml Ms O Moz Webkit".split(" ");
				b.length
			}
			return function(c) {
				if (c in a.style) return !0;
				for (c = c.replace(/^[a-z]/, function(a) {
					return a.toUpperCase()
				}), i = 0; i < b.length; i++)
					if (b[i] + c in a.style) return !0;
				return !1
			}
		}()
	}, a.fn[e] = function(b) {
		var c = {
			elemCounter: 0,
			outputElems: [],
			inputElems: function(b) {
				for (var c = a(b), d = c.length, e = [], f = 0; d > f; f++) e.push(c.get(f));
				return e
			}(a(this))
		};
		return obj = {}, obj[e] = function(b) {
			return "undefined" == typeof b ? void console.error('Please specify an action like $.jqthumb("killall")') : (b = b.toLowerCase(), void("killall" == b && a.each(f.inputElems, function() {
				new d(this, "kill")
			})))
		}, a.extend(a, obj), this.each(function() {
			var g = a(this);
			this.global = c, f.inputElems.push(g), "string" == typeof b ? new d(this, b) : g.data(e) ? (new d(this, "kill"), g.data(e, new d(this, b))) : g.data(e, new d(this, b))
		})
	}
}(window.jQuery || window.Zepto, window, document);