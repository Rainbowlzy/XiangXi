'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});
/*
 Copyright (C) Federico Zivolo 2018
 Distributed under the MIT License (license terms are at http://opensource.org/licenses/MIT).
 */function a(a, b) {
  if (1 !== a.nodeType) return [];var c = getComputedStyle(a, null);return b ? c[b] : c;
}function b(a) {
  return 'HTML' === a.nodeName ? a : a.parentNode || a.host;
}function c(d) {
  if (!d) return document.body;switch (d.nodeName) {case 'HTML':case 'BODY':
      return d.ownerDocument.body;case '#document':
      return d.body;}var e = a(d),
      f = e.overflow,
      g = e.overflowX,
      h = e.overflowY;return (/(auto|scroll|overlay)/.test(f + h + g) ? d : c(b(d))
  );
}var d = 'undefined' != typeof window && 'undefined' != typeof document,
    e = d && !!(window.MSInputMethodContext && document.documentMode),
    f = d && /MSIE 10/.test(navigator.userAgent);function g(a) {
  return 11 === a ? e : 10 === a ? f : e || f;
}function h(b) {
  if (!b) return document.documentElement;for (var c = g(10) ? document.body : null, d = b.offsetParent; d === c && b.nextElementSibling;) {
    d = (b = b.nextElementSibling).offsetParent;
  }var e = d && d.nodeName;return e && 'BODY' !== e && 'HTML' !== e ? -1 !== ['TD', 'TABLE'].indexOf(d.nodeName) && 'static' === a(d, 'position') ? h(d) : d : b ? b.ownerDocument.documentElement : document.documentElement;
}function j(a) {
  var b = a.nodeName;return 'BODY' !== b && ('HTML' === b || h(a.firstElementChild) === a);
}function k(a) {
  return null === a.parentNode ? a : k(a.parentNode);
}function l(a, b) {
  if (!a || !a.nodeType || !b || !b.nodeType) return document.documentElement;var c = a.compareDocumentPosition(b) & Node.DOCUMENT_POSITION_FOLLOWING,
      d = c ? a : b,
      e = c ? b : a,
      f = document.createRange();f.setStart(d, 0), f.setEnd(e, 0);var g = f.commonAncestorContainer;if (a !== g && b !== g || d.contains(e)) return j(g) ? g : h(g);var i = k(a);return i.host ? l(i.host, b) : l(a, k(b).host);
}function m(a) {
  var b = 1 < arguments.length && arguments[1] !== void 0 ? arguments[1] : 'top',
      c = 'top' === b ? 'scrollTop' : 'scrollLeft',
      d = a.nodeName;if ('BODY' === d || 'HTML' === d) {
    var e = a.ownerDocument.documentElement,
        f = a.ownerDocument.scrollingElement || e;return f[c];
  }return a[c];
}function n(a, b) {
  var c = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
      d = m(b, 'top'),
      e = m(b, 'left'),
      f = c ? -1 : 1;return a.top += d * f, a.bottom += d * f, a.left += e * f, a.right += e * f, a;
}function o(a, b) {
  var c = 'x' === b ? 'Left' : 'Top',
      d = 'Left' == c ? 'Right' : 'Bottom';return parseFloat(a['border' + c + 'Width'], 10) + parseFloat(a['border' + d + 'Width'], 10);
}function p(a, b, c, d) {
  return Math.max(b['offset' + a], b['scroll' + a], c['client' + a], c['offset' + a], c['scroll' + a], g(10) ? c['offset' + a] + d['margin' + ('Height' === a ? 'Top' : 'Left')] + d['margin' + ('Height' === a ? 'Bottom' : 'Right')] : 0);
}function q() {
  var a = document.body,
      b = document.documentElement,
      c = g(10) && getComputedStyle(b);return { height: p('Height', a, b, c), width: p('Width', a, b, c) };
}var r = Object.assign || function (a) {
  for (var b, c = 1; c < arguments.length; c++) {
    for (var d in b = arguments[c], b) {
      Object.prototype.hasOwnProperty.call(b, d) && (a[d] = b[d]);
    }
  }return a;
};function s(a) {
  return r({}, a, { right: a.left + a.width, bottom: a.top + a.height });
}function t(b) {
  var c = {};try {
    if (g(10)) {
      c = b.getBoundingClientRect();var d = m(b, 'top'),
          e = m(b, 'left');c.top += d, c.left += e, c.bottom += d, c.right += e;
    } else c = b.getBoundingClientRect();
  } catch (a) {}var f = { left: c.left, top: c.top, width: c.right - c.left, height: c.bottom - c.top },
      h = 'HTML' === b.nodeName ? q() : {},
      i = h.width || b.clientWidth || f.right - f.left,
      j = h.height || b.clientHeight || f.bottom - f.top,
      k = b.offsetWidth - i,
      l = b.offsetHeight - j;if (k || l) {
    var n = a(b);k -= o(n, 'x'), l -= o(n, 'y'), f.width -= k, f.height -= l;
  }return s(f);
}function u(b, d) {
  var e = Math.max,
      f = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
      h = g(10),
      i = 'HTML' === d.nodeName,
      j = t(b),
      k = t(d),
      l = c(b),
      m = a(d),
      o = parseFloat(m.borderTopWidth, 10),
      p = parseFloat(m.borderLeftWidth, 10);f && 'HTML' === d.nodeName && (k.top = e(k.top, 0), k.left = e(k.left, 0));var q = s({ top: j.top - k.top - o, left: j.left - k.left - p, width: j.width, height: j.height });if (q.marginTop = 0, q.marginLeft = 0, !h && i) {
    var r = parseFloat(m.marginTop, 10),
        u = parseFloat(m.marginLeft, 10);q.top -= o - r, q.bottom -= o - r, q.left -= p - u, q.right -= p - u, q.marginTop = r, q.marginLeft = u;
  }return (h && !f ? d.contains(l) : d === l && 'BODY' !== l.nodeName) && (q = n(q, d)), q;
}function v(a) {
  var b = Math.max,
      c = 1 < arguments.length && void 0 !== arguments[1] && arguments[1],
      d = a.ownerDocument.documentElement,
      e = u(a, d),
      f = b(d.clientWidth, window.innerWidth || 0),
      g = b(d.clientHeight, window.innerHeight || 0),
      h = c ? 0 : m(d),
      i = c ? 0 : m(d, 'left'),
      j = { top: h - e.top + e.marginTop, left: i - e.left + e.marginLeft, width: f, height: g };return s(j);
}function w(c) {
  var d = c.nodeName;return 'BODY' === d || 'HTML' === d ? !1 : !('fixed' !== a(c, 'position')) || w(b(c));
}function x(b) {
  if (!b || !b.parentElement || g()) return document.documentElement;for (var c = b.parentElement; c && 'none' === a(c, 'transform');) {
    c = c.parentElement;
  }return c || document.documentElement;
}function y(a, d, e, f) {
  var g = 4 < arguments.length && void 0 !== arguments[4] && arguments[4],
      h = { top: 0, left: 0 },
      i = g ? x(a) : l(a, d);if ('viewport' === f) h = v(i, g);else {
    var j;'scrollParent' === f ? (j = c(b(d)), 'BODY' === j.nodeName && (j = a.ownerDocument.documentElement)) : 'window' === f ? j = a.ownerDocument.documentElement : j = f;var k = u(j, i, g);if ('HTML' === j.nodeName && !w(i)) {
      var m = q(),
          n = m.height,
          o = m.width;h.top += k.top - k.marginTop, h.bottom = n + k.top, h.left += k.left - k.marginLeft, h.right = o + k.left;
    } else h = k;
  }return h.left += e, h.top += e, h.right -= e, h.bottom -= e, h;
}function z(a) {
  var b = a.width,
      c = a.height;return b * c;
}function A(a, b, c, d, e) {
  var f = 5 < arguments.length && arguments[5] !== void 0 ? arguments[5] : 0;if (-1 === a.indexOf('auto')) return a;var g = y(c, d, f, e),
      h = { top: { width: g.width, height: b.top - g.top }, right: { width: g.right - b.right, height: g.height }, bottom: { width: g.width, height: g.bottom - b.bottom }, left: { width: b.left - g.left, height: g.height } },
      i = Object.keys(h).map(function (a) {
    return r({ key: a }, h[a], { area: z(h[a]) });
  }).sort(function (c, a) {
    return a.area - c.area;
  }),
      j = i.filter(function (a) {
    var b = a.width,
        d = a.height;return b >= c.clientWidth && d >= c.clientHeight;
  }),
      k = 0 < j.length ? j[0].key : i[0].key,
      l = a.split('-')[1];return k + (l ? '-' + l : '');
}for (var B = ['Edge', 'Trident', 'Firefox'], C = 0, D = 0; D < B.length; D += 1) {
  if (d && 0 <= navigator.userAgent.indexOf(B[D])) {
    C = 1;break;
  }
}function i(a) {
  var b = !1;return function () {
    b || (b = !0, window.Promise.resolve().then(function () {
      b = !1, a();
    }));
  };
}function E(a) {
  var b = !1;return function () {
    b || (b = !0, setTimeout(function () {
      b = !1, a();
    }, C));
  };
}var F = d && window.Promise,
    G = F ? i : E;function H(a, b) {
  return Array.prototype.find ? a.find(b) : a.filter(b)[0];
}function I(a, b, c) {
  if (Array.prototype.findIndex) return a.findIndex(function (a) {
    return a[b] === c;
  });var d = H(a, function (a) {
    return a[b] === c;
  });return a.indexOf(d);
}function J(a) {
  var b;if ('HTML' === a.nodeName) {
    var c = q(),
        d = c.width,
        e = c.height;b = { width: d, height: e, left: 0, top: 0 };
  } else b = { width: a.offsetWidth, height: a.offsetHeight, left: a.offsetLeft, top: a.offsetTop };return s(b);
}function K(a) {
  var b = getComputedStyle(a),
      c = parseFloat(b.marginTop) + parseFloat(b.marginBottom),
      d = parseFloat(b.marginLeft) + parseFloat(b.marginRight),
      e = { width: a.offsetWidth + d, height: a.offsetHeight + c };return e;
}function L(a) {
  var b = { left: 'right', right: 'left', bottom: 'top', top: 'bottom' };return a.replace(/left|right|bottom|top/g, function (a) {
    return b[a];
  });
}function M(a, b, c) {
  c = c.split('-')[0];var d = K(a),
      e = { width: d.width, height: d.height },
      f = -1 !== ['right', 'left'].indexOf(c),
      g = f ? 'top' : 'left',
      h = f ? 'left' : 'top',
      i = f ? 'height' : 'width',
      j = f ? 'width' : 'height';return e[g] = b[g] + b[i] / 2 - d[i] / 2, e[h] = c === h ? b[h] - d[j] : b[L(h)], e;
}function N(a, b, c) {
  var d = 3 < arguments.length && arguments[3] !== void 0 ? arguments[3] : null,
      e = d ? x(b) : l(b, c);return u(c, e, d);
}function O(a) {
  for (var b = [!1, 'ms', 'Webkit', 'Moz', 'O'], c = a.charAt(0).toUpperCase() + a.slice(1), d = 0; d < b.length; d++) {
    var e = b[d],
        f = e ? '' + e + c : a;if ('undefined' != typeof document.body.style[f]) return f;
  }return null;
}function P(a) {
  return a && '[object Function]' === {}.toString.call(a);
}function Q(a, b) {
  return a.some(function (a) {
    var c = a.name,
        d = a.enabled;return d && c === b;
  });
}function R(a, b, c) {
  var d = H(a, function (a) {
    var c = a.name;return c === b;
  }),
      e = !!d && a.some(function (a) {
    return a.name === c && a.enabled && a.order < d.order;
  });if (!e) {
    var f = '`' + b + '`';console.warn('`' + c + '`' + ' modifier is required by ' + f + ' modifier in order to work, be sure to include it before ' + f + '!');
  }return e;
}function S(a) {
  return '' !== a && !isNaN(parseFloat(a)) && isFinite(a);
}function T(a) {
  var b = a.ownerDocument;return b ? b.defaultView : window;
}function U(a, b) {
  return T(a).removeEventListener('resize', b.updateBound), b.scrollParents.forEach(function (a) {
    a.removeEventListener('scroll', b.updateBound);
  }), b.updateBound = null, b.scrollParents = [], b.scrollElement = null, b.eventsEnabled = !1, b;
}function V(a, b, c) {
  var d = void 0 === c ? a : a.slice(0, I(a, 'name', c));return d.forEach(function (a) {
    a['function'] && console.warn('`modifier.function` is deprecated, use `modifier.fn`!');var c = a['function'] || a.fn;a.enabled && P(c) && (b.offsets.popper = s(b.offsets.popper), b.offsets.reference = s(b.offsets.reference), b = c(b, a));
  }), b;
}function W(a, b) {
  Object.keys(b).forEach(function (c) {
    var d = b[c];!1 === d ? a.removeAttribute(c) : a.setAttribute(c, b[c]);
  });
}function X(a, b) {
  Object.keys(b).forEach(function (c) {
    var d = '';-1 !== ['width', 'height', 'top', 'right', 'bottom', 'left'].indexOf(c) && S(b[c]) && (d = 'px'), a.style[c] = b[c] + d;
  });
}function Y(a, b, d, e) {
  var f = 'BODY' === a.nodeName,
      g = f ? a.ownerDocument.defaultView : a;g.addEventListener(b, d, { passive: !0 }), f || Y(c(g.parentNode), b, d, e), e.push(g);
}function Z(a, b, d, e) {
  d.updateBound = e, T(a).addEventListener('resize', d.updateBound, { passive: !0 });var f = c(a);return Y(f, 'scroll', d.updateBound, d.scrollParents), d.scrollElement = f, d.eventsEnabled = !0, d;
}var $ = { computeAutoPlacement: A, debounce: G, findIndex: I, getBordersSize: o, getBoundaries: y, getBoundingClientRect: t, getClientRect: s, getOffsetParent: h, getOffsetRect: J, getOffsetRectRelativeToArbitraryNode: u, getOuterSizes: K, getParentNode: b, getPopperOffsets: M, getReferenceOffsets: N, getScroll: m, getScrollParent: c, getStyleComputedProperty: a, getSupportedPropertyName: O, getWindowSizes: q, isFixed: w, isFunction: P, isModifierEnabled: Q, isModifierRequired: R, isNumeric: S, removeEventListeners: U, runModifiers: V, setAttributes: W, setStyles: X, setupEventListeners: Z };exports.computeAutoPlacement = A;
exports.debounce = G;
exports.findIndex = I;
exports.getBordersSize = o;
exports.getBoundaries = y;
exports.getBoundingClientRect = t;
exports.getClientRect = s;
exports.getOffsetParent = h;
exports.getOffsetRect = J;
exports.getOffsetRectRelativeToArbitraryNode = u;
exports.getOuterSizes = K;
exports.getParentNode = b;
exports.getPopperOffsets = M;
exports.getReferenceOffsets = N;
exports.getScroll = m;
exports.getScrollParent = c;
exports.getStyleComputedProperty = a;
exports.getSupportedPropertyName = O;
exports.getWindowSizes = q;
exports.isFixed = w;
exports.isFunction = P;
exports.isModifierEnabled = Q;
exports.isModifierRequired = R;
exports.isNumeric = S;
exports.removeEventListeners = U;
exports.runModifiers = V;
exports.setAttributes = W;
exports.setStyles = X;
exports.setupEventListeners = Z;
exports.default = $;
//# sourceMappingURL=popper-utils.min.js.map

//# sourceMappingURL=popper-utils.min-compiled.js.map