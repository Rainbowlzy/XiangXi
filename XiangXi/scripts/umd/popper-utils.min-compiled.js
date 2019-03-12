'use strict';

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

/*
 Copyright (C) Federico Zivolo 2018
 Distributed under the MIT License (license terms are at http://opensource.org/licenses/MIT).
 */(function (a, b) {
  'object' == (typeof exports === 'undefined' ? 'undefined' : _typeof(exports)) && 'undefined' != typeof module ? b(exports) : 'function' == typeof define && define.amd ? define(['exports'], b) : b(a.PopperUtils = {});
})(undefined, function (a) {
  'use strict';
  function b(a, b) {
    if (1 !== a.nodeType) return [];var c = getComputedStyle(a, null);return b ? c[b] : c;
  }function c(a) {
    return 'HTML' === a.nodeName ? a : a.parentNode || a.host;
  }function d(a) {
    if (!a) return document.body;switch (a.nodeName) {case 'HTML':case 'BODY':
        return a.ownerDocument.body;case '#document':
        return a.body;}var e = b(a),
        f = e.overflow,
        g = e.overflowX,
        h = e.overflowY;return (/(auto|scroll|overlay)/.test(f + h + g) ? a : d(c(a))
    );
  }function e(a) {
    return 11 === a ? T : 10 === a ? U : T || U;
  }function f(a) {
    if (!a) return document.documentElement;for (var c = e(10) ? document.body : null, d = a.offsetParent; d === c && a.nextElementSibling;) {
      d = (a = a.nextElementSibling).offsetParent;
    }var g = d && d.nodeName;return g && 'BODY' !== g && 'HTML' !== g ? -1 !== ['TD', 'TABLE'].indexOf(d.nodeName) && 'static' === b(d, 'position') ? f(d) : d : a ? a.ownerDocument.documentElement : document.documentElement;
  }function g(a) {
    var b = a.nodeName;return 'BODY' !== b && ('HTML' === b || f(a.firstElementChild) === a);
  }function h(a) {
    return null === a.parentNode ? a : h(a.parentNode);
  }function j(a, b) {
    if (!a || !a.nodeType || !b || !b.nodeType) return document.documentElement;var c = a.compareDocumentPosition(b) & Node.DOCUMENT_POSITION_FOLLOWING,
        d = c ? a : b,
        e = c ? b : a,
        i = document.createRange();i.setStart(d, 0), i.setEnd(e, 0);var k = i.commonAncestorContainer;if (a !== k && b !== k || d.contains(e)) return g(k) ? k : f(k);var l = h(a);return l.host ? j(l.host, b) : j(a, h(b).host);
  }function k(a) {
    var b = 1 < arguments.length && arguments[1] !== void 0 ? arguments[1] : 'top',
        c = 'top' === b ? 'scrollTop' : 'scrollLeft',
        d = a.nodeName;if ('BODY' === d || 'HTML' === d) {
      var e = a.ownerDocument.documentElement,
          f = a.ownerDocument.scrollingElement || e;return f[c];
    }return a[c];
  }function l(a, b) {
    var c = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
        d = k(b, 'top'),
        e = k(b, 'left'),
        f = c ? -1 : 1;return a.top += d * f, a.bottom += d * f, a.left += e * f, a.right += e * f, a;
  }function m(a, b) {
    var c = 'x' === b ? 'Left' : 'Top',
        d = 'Left' == c ? 'Right' : 'Bottom';return parseFloat(a['border' + c + 'Width'], 10) + parseFloat(a['border' + d + 'Width'], 10);
  }function n(a, b, c, d) {
    return R(b['offset' + a], b['scroll' + a], c['client' + a], c['offset' + a], c['scroll' + a], e(10) ? c['offset' + a] + d['margin' + ('Height' === a ? 'Top' : 'Left')] + d['margin' + ('Height' === a ? 'Bottom' : 'Right')] : 0);
  }function o() {
    var a = document.body,
        b = document.documentElement,
        c = e(10) && getComputedStyle(b);return { height: n('Height', a, b, c), width: n('Width', a, b, c) };
  }function p(a) {
    return V({}, a, { right: a.left + a.width, bottom: a.top + a.height });
  }function q(a) {
    var c = {};try {
      if (e(10)) {
        c = a.getBoundingClientRect();var d = k(a, 'top'),
            f = k(a, 'left');c.top += d, c.left += f, c.bottom += d, c.right += f;
      } else c = a.getBoundingClientRect();
    } catch (a) {}var g = { left: c.left, top: c.top, width: c.right - c.left, height: c.bottom - c.top },
        h = 'HTML' === a.nodeName ? o() : {},
        i = h.width || a.clientWidth || g.right - g.left,
        j = h.height || a.clientHeight || g.bottom - g.top,
        l = a.offsetWidth - i,
        n = a.offsetHeight - j;if (l || n) {
      var q = b(a);l -= m(q, 'x'), n -= m(q, 'y'), g.width -= l, g.height -= n;
    }return p(g);
  }function r(a, c) {
    var f = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
        g = e(10),
        h = 'HTML' === c.nodeName,
        i = q(a),
        j = q(c),
        k = d(a),
        m = b(c),
        n = parseFloat(m.borderTopWidth, 10),
        o = parseFloat(m.borderLeftWidth, 10);f && 'HTML' === c.nodeName && (j.top = R(j.top, 0), j.left = R(j.left, 0));var r = p({ top: i.top - j.top - n, left: i.left - j.left - o, width: i.width, height: i.height });if (r.marginTop = 0, r.marginLeft = 0, !g && h) {
      var s = parseFloat(m.marginTop, 10),
          t = parseFloat(m.marginLeft, 10);r.top -= n - s, r.bottom -= n - s, r.left -= o - t, r.right -= o - t, r.marginTop = s, r.marginLeft = t;
    }return (g && !f ? c.contains(k) : c === k && 'BODY' !== k.nodeName) && (r = l(r, c)), r;
  }function s(a) {
    var b = 1 < arguments.length && arguments[1] !== void 0 && arguments[1],
        c = a.ownerDocument.documentElement,
        d = r(a, c),
        e = R(c.clientWidth, window.innerWidth || 0),
        f = R(c.clientHeight, window.innerHeight || 0),
        g = b ? 0 : k(c),
        h = b ? 0 : k(c, 'left'),
        i = { top: g - d.top + d.marginTop, left: h - d.left + d.marginLeft, width: e, height: f };return p(i);
  }function t(a) {
    var d = a.nodeName;return 'BODY' === d || 'HTML' === d ? !1 : !('fixed' !== b(a, 'position')) || t(c(a));
  }function u(a) {
    if (!a || !a.parentElement || e()) return document.documentElement;for (var c = a.parentElement; c && 'none' === b(c, 'transform');) {
      c = c.parentElement;
    }return c || document.documentElement;
  }function v(a, b, e, f) {
    var g = 4 < arguments.length && void 0 !== arguments[4] && arguments[4],
        h = { top: 0, left: 0 },
        i = g ? u(a) : j(a, b);if ('viewport' === f) h = s(i, g);else {
      var k;'scrollParent' === f ? (k = d(c(b)), 'BODY' === k.nodeName && (k = a.ownerDocument.documentElement)) : 'window' === f ? k = a.ownerDocument.documentElement : k = f;var l = r(k, i, g);if ('HTML' === k.nodeName && !t(i)) {
        var m = o(),
            n = m.height,
            p = m.width;h.top += l.top - l.marginTop, h.bottom = n + l.top, h.left += l.left - l.marginLeft, h.right = p + l.left;
      } else h = l;
    }return h.left += e, h.top += e, h.right -= e, h.bottom -= e, h;
  }function w(a) {
    var b = a.width,
        c = a.height;return b * c;
  }function x(a, b, c, d, e) {
    var f = 5 < arguments.length && arguments[5] !== void 0 ? arguments[5] : 0;if (-1 === a.indexOf('auto')) return a;var g = v(c, d, f, e),
        h = { top: { width: g.width, height: b.top - g.top }, right: { width: g.right - b.right, height: g.height }, bottom: { width: g.width, height: g.bottom - b.bottom }, left: { width: b.left - g.left, height: g.height } },
        i = Object.keys(h).map(function (a) {
      return V({ key: a }, h[a], { area: w(h[a]) });
    }).sort(function (c, a) {
      return a.area - c.area;
    }),
        j = i.filter(function (a) {
      var b = a.width,
          d = a.height;return b >= c.clientWidth && d >= c.clientHeight;
    }),
        k = 0 < j.length ? j[0].key : i[0].key,
        l = a.split('-')[1];return k + (l ? '-' + l : '');
  }function y(a, b) {
    return Array.prototype.find ? a.find(b) : a.filter(b)[0];
  }function z(a, b, c) {
    if (Array.prototype.findIndex) return a.findIndex(function (a) {
      return a[b] === c;
    });var d = y(a, function (a) {
      return a[b] === c;
    });return a.indexOf(d);
  }function A(a) {
    var b;if ('HTML' === a.nodeName) {
      var c = o(),
          d = c.width,
          e = c.height;b = { width: d, height: e, left: 0, top: 0 };
    } else b = { width: a.offsetWidth, height: a.offsetHeight, left: a.offsetLeft, top: a.offsetTop };return p(b);
  }function B(a) {
    var b = getComputedStyle(a),
        c = parseFloat(b.marginTop) + parseFloat(b.marginBottom),
        d = parseFloat(b.marginLeft) + parseFloat(b.marginRight),
        e = { width: a.offsetWidth + d, height: a.offsetHeight + c };return e;
  }function C(a) {
    var b = { left: 'right', right: 'left', bottom: 'top', top: 'bottom' };return a.replace(/left|right|bottom|top/g, function (a) {
      return b[a];
    });
  }function D(a, b, c) {
    c = c.split('-')[0];var d = B(a),
        e = { width: d.width, height: d.height },
        f = -1 !== ['right', 'left'].indexOf(c),
        g = f ? 'top' : 'left',
        h = f ? 'left' : 'top',
        i = f ? 'height' : 'width',
        j = f ? 'width' : 'height';return e[g] = b[g] + b[i] / 2 - d[i] / 2, e[h] = c === h ? b[h] - d[j] : b[C(h)], e;
  }function E(a, b, c) {
    var d = 3 < arguments.length && arguments[3] !== void 0 ? arguments[3] : null,
        e = d ? u(b) : j(b, c);return r(c, e, d);
  }function F(a) {
    for (var b = [!1, 'ms', 'Webkit', 'Moz', 'O'], c = a.charAt(0).toUpperCase() + a.slice(1), d = 0; d < b.length; d++) {
      var e = b[d],
          f = e ? '' + e + c : a;if ('undefined' != typeof document.body.style[f]) return f;
    }return null;
  }function G(a) {
    return a && '[object Function]' === {}.toString.call(a);
  }function H(a, b) {
    return a.some(function (a) {
      var c = a.name,
          d = a.enabled;return d && c === b;
    });
  }function I(a, b, c) {
    var d = y(a, function (a) {
      var c = a.name;return c === b;
    }),
        e = !!d && a.some(function (a) {
      return a.name === c && a.enabled && a.order < d.order;
    });if (!e) {
      var f = '`' + b + '`';console.warn('`' + c + '`' + ' modifier is required by ' + f + ' modifier in order to work, be sure to include it before ' + f + '!');
    }return e;
  }function J(a) {
    return '' !== a && !isNaN(parseFloat(a)) && isFinite(a);
  }function K(a) {
    var b = a.ownerDocument;return b ? b.defaultView : window;
  }function L(a, b) {
    return K(a).removeEventListener('resize', b.updateBound), b.scrollParents.forEach(function (a) {
      a.removeEventListener('scroll', b.updateBound);
    }), b.updateBound = null, b.scrollParents = [], b.scrollElement = null, b.eventsEnabled = !1, b;
  }function M(a, b, c) {
    var d = void 0 === c ? a : a.slice(0, z(a, 'name', c));return d.forEach(function (a) {
      a['function'] && console.warn('`modifier.function` is deprecated, use `modifier.fn`!');var c = a['function'] || a.fn;a.enabled && G(c) && (b.offsets.popper = p(b.offsets.popper), b.offsets.reference = p(b.offsets.reference), b = c(b, a));
    }), b;
  }function N(a, b) {
    Object.keys(b).forEach(function (c) {
      var d = b[c];!1 === d ? a.removeAttribute(c) : a.setAttribute(c, b[c]);
    });
  }function O(a, b) {
    Object.keys(b).forEach(function (c) {
      var d = '';-1 !== ['width', 'height', 'top', 'right', 'bottom', 'left'].indexOf(c) && J(b[c]) && (d = 'px'), a.style[c] = b[c] + d;
    });
  }function P(a, b, c, e) {
    var f = 'BODY' === a.nodeName,
        g = f ? a.ownerDocument.defaultView : a;g.addEventListener(b, c, { passive: !0 }), f || P(d(g.parentNode), b, c, e), e.push(g);
  }function Q(a, b, c, e) {
    c.updateBound = e, K(a).addEventListener('resize', c.updateBound, { passive: !0 });var f = d(a);return P(f, 'scroll', c.updateBound, c.scrollParents), c.scrollElement = f, c.eventsEnabled = !0, c;
  }for (var R = Math.max, S = 'undefined' != typeof window && 'undefined' != typeof document, T = S && !!(window.MSInputMethodContext && document.documentMode), U = S && /MSIE 10/.test(navigator.userAgent), V = Object.assign || function (a) {
    for (var b, c = 1; c < arguments.length; c++) {
      for (var d in b = arguments[c], b) {
        Object.prototype.hasOwnProperty.call(b, d) && (a[d] = b[d]);
      }
    }return a;
  }, W = ['Edge', 'Trident', 'Firefox'], X = 0, Y = 0; Y < W.length; Y += 1) {
    if (S && 0 <= navigator.userAgent.indexOf(W[Y])) {
      X = 1;break;
    }
  }var i = S && window.Promise,
      Z = i ? function (a) {
    var b = !1;return function () {
      b || (b = !0, window.Promise.resolve().then(function () {
        b = !1, a();
      }));
    };
  } : function (a) {
    var b = !1;return function () {
      b || (b = !0, setTimeout(function () {
        b = !1, a();
      }, X));
    };
  };a.computeAutoPlacement = x, a.debounce = Z, a.findIndex = z, a.getBordersSize = m, a.getBoundaries = v, a.getBoundingClientRect = q, a.getClientRect = p, a.getOffsetParent = f, a.getOffsetRect = A, a.getOffsetRectRelativeToArbitraryNode = r, a.getOuterSizes = B, a.getParentNode = c, a.getPopperOffsets = D, a.getReferenceOffsets = E, a.getScroll = k, a.getScrollParent = d, a.getStyleComputedProperty = b, a.getSupportedPropertyName = F, a.getWindowSizes = o, a.isFixed = t, a.isFunction = G, a.isModifierEnabled = H, a.isModifierRequired = I, a.isNumeric = J, a.removeEventListeners = L, a.runModifiers = M, a.setAttributes = N, a.setStyles = O, a.setupEventListeners = Q, a['default'] = { computeAutoPlacement: x, debounce: Z, findIndex: z, getBordersSize: m, getBoundaries: v, getBoundingClientRect: q, getClientRect: p, getOffsetParent: f, getOffsetRect: A, getOffsetRectRelativeToArbitraryNode: r, getOuterSizes: B, getParentNode: c, getPopperOffsets: D, getReferenceOffsets: E, getScroll: k, getScrollParent: d, getStyleComputedProperty: b, getSupportedPropertyName: F, getWindowSizes: o, isFixed: t, isFunction: G, isModifierEnabled: H, isModifierRequired: I, isNumeric: J, removeEventListeners: L, runModifiers: M, setAttributes: N, setStyles: O, setupEventListeners: Q }, Object.defineProperty(a, '__esModule', { value: !0 });
});
//# sourceMappingURL=popper-utils.min.js.map

//# sourceMappingURL=popper-utils.min-compiled.js.map