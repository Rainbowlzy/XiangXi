'use strict';

var _typeof2 = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

var _typeof = typeof Symbol === "function" && _typeof2(Symbol.iterator) === "symbol" ? function (obj) {
  return typeof obj === "undefined" ? "undefined" : _typeof2(obj);
} : function (obj) {
  return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj === "undefined" ? "undefined" : _typeof2(obj);
};

(function (root, factory) {
  if (typeof define === 'function' && define.amd) {
    define(["leaflet.defaultextent"], factory);
  } else if ((typeof exports === 'undefined' ? 'undefined' : _typeof(exports)) === 'object') {
    module.exports = factory(require('leaflet'));
  } else {
    root.L.Control.DefaultExtent = factory(root.L);
  }
})(undefined, function (L) {

  return function () {
    /* global L */
    'use strict';

    L.Control.DefaultExtent = L.Control.extend({
      options: {
        position: 'topleft',
        text: 'Default Extent',
        title: 'Zoom to default extent',
        className: 'leaflet-control-defaultextent'
      },
      onAdd: function onAdd(map) {
        this._map = map;
        return this._initLayout();
      },
      setCenter: function setCenter(center) {
        this._center = center;
        return this;
      },
      setZoom: function setZoom(zoom) {
        this._zoom = zoom;
        return this;
      },
      _initLayout: function _initLayout() {
        var container = L.DomUtil.create('div', 'leaflet-bar ' + this.options.className);
        this._container = container;
        this._fullExtentButton = this._createExtentButton(container);

        L.DomEvent.disableClickPropagation(container);

        this._map.whenReady(this._whenReady, this);

        return this._container;
      },
      _createExtentButton: function _createExtentButton() {
        var link = L.DomUtil.create('a', this.options.className + '-toggle', this._container);
        link.href = '#';
        link.innerHTML = this.options.text;
        link.title = this.options.title;

        L.DomEvent.on(link, 'mousedown dblclick', L.DomEvent.stopPropagation).on(link, 'click', L.DomEvent.stop).on(link, 'click', this._zoomToDefault, this);
        return link;
      },
      _whenReady: function _whenReady() {
        if (!this._center) {
          this._center = this._map.getCenter();
        }
        if (!this._zoom) {
          this._zoom = this._map.getZoom();
        }
        return this;
      },
      _zoomToDefault: function _zoomToDefault() {
        this._map.setView(this._center, this._zoom);
      }
    });

    L.Map.addInitHook(function () {
      if (this.options.defaultExtentControl) {
        this.addControl(new L.Control.DefaultExtent());
      }
    });

    L.control.defaultExtent = function (options) {
      return new L.Control.DefaultExtent(options);
    };

    return L.Control.DefaultExtent;
  }();
  ;
});

//# sourceMappingURL=leaflet.defaultextent-compiled.js.map

//# sourceMappingURL=leaflet.defaultextent-compiled.js.map