L.Polygon.Measure = L.Draw.Polygon.extend({
    options: {
        showArea: true,
        allowIntersection: false,
        metric: true
    },
    addHooks: function () {
        L.Draw.Polygon.prototype.addHooks.call(this);
        if (this._map) {
            this._markerGroup = new L.LayerGroup();
            this._map.addLayer(this._markerGroup);

            this._markers = [];
            this._map.on('click', this._onClick, this);
            this._startShape();
        }
    },

    removeHooks: function () {
        L.Draw.Polygon.prototype.removeHooks.call(this);

        this._clearHideErrorTimeout();

        //!\ Still useful when control is disabled before any drawing (refactor needed?)
        this._map.off('mousemove', this._onMouseMove);
        this._clearGuides();
        this._container.style.cursor = '';

        this._removeShape();

        this._map.off('click', this._onClick, this);
    },

    _startShape: function () {
        this._drawing = true;
        this._poly = new L.Polygon([], this.options.shapeOptions);

        this._container.style.cursor = 'crosshair';

        this._updateTooltip();
        this._map.on('mousemove', this._onMouseMove, this);
    },

    _finishShape: function () {
        this._drawing = false;

        this._cleanUpShape();
        this._clearGuides();
        this._updateTooltip();

        this._map.off('mousemove', this._onMouseMove, this);
        this._container.style.cursor = '';
    },

    _removeShape: function () {
        if (!this._poly)
            return;
        this._map.removeLayer(this._poly);
        delete this._poly;
        this._markers.splice(0);
        this._markerGroup.clearLayers();
    },

    _onClick: function (e) {
        if (!this._drawing) {
            this._removeShape();
            this._startShape();
            return;
        }
    },

    _getTooltipText: function () {
        var labelText = L.Draw.Polygon.prototype._getTooltipText.call(this);
        if (!this._drawing) {
            labelText.text = '';
        }
        return labelText;
    }
    ,
    getArea: function (e) {
        var obj = e.target;
        var area = L.GeometryUtil.geodesicArea(obj.getLatLngs());
        if (this.isGeodesic)
            return area.toFixed(2) + ' m<sup>2</sup>';
        else
            return L.GeometryUtil.readableArea(area);
    }
});

L.Control.MeasureAreaControl = L.Control.extend({
    statics: {
        TITLE: '测面'
    },
    options: {
        position: 'topleft',
        showArea: true,
        handler: {}
    },
    setDisable: function () {
        this.handler.disable.call(this.handler);
    },
    toggle: function () {
        if (this.handler.enabled()) {
            this.handler.disable.call(this.handler);
        } else {
            //L.Control.MeasureControl.prototype.setDisable();
            this.handler.enable.call(this.handler);
        }
    },

    onAdd: function (map) {
        var className = 'leaflet-control-draw';

        this._container = L.DomUtil.create('div', 'leaflet-bar');

        this.handler = new L.Polygon.Measure(map, this.options.handler);
        this.handler.on('enabled', function () {
            L.DomUtil.addClass(this._container, 'enabled');
        }, this);

        this.handler.on('disabled', function () {
            L.DomUtil.removeClass(this._container, 'enabled');
        }, this);

        var link = L.DomUtil.create('a', className + '-measure-area', this._container);
        link.href = '#';
        link.title = L.Control.MeasureAreaControl.TITLE;

        L.DomEvent
            .addListener(link, 'click', L.DomEvent.stopPropagation)
            .addListener(link, 'click', L.DomEvent.preventDefault)
            .addListener(link, 'click', this.toggle, this);

        return this._container;
    }
});

L.Polyline.Measure = L.Draw.Polyline.extend({
    addHooks: function () {
        L.Draw.Polyline.prototype.addHooks.call(this);
        if (this._map) {
            this._markerGroup = new L.LayerGroup();
            this._map.addLayer(this._markerGroup);

            this._markers = [];
            this._map.on('click', this._onClick, this);
            this._startShape();
        }
    },

    removeHooks: function () {
        L.Draw.Polyline.prototype.removeHooks.call(this);

        this._clearHideErrorTimeout();

        //!\ Still useful when control is disabled before any drawing (refactor needed?)
        this._map.off('mousemove', this._onMouseMove);
        this._clearGuides();
        this._container.style.cursor = '';

        this._removeShape();
        //this._tooltip.dispose
        this._map.off('click', this._onClick, this);
    },

    _startShape: function () {
        this._drawing = true;
        this._poly = new L.Polyline([], this.options.shapeOptions);

        this._container.style.cursor = 'crosshair';

        this._updateTooltip();
        this._map.on('mousemove', this._onMouseMove, this);
    },

    _finishShape: function () {
        this._drawing = false;

        this._cleanUpShape();
        this._clearGuides();

        this._updateTooltip();

        this._map.off('mousemove', this._onMouseMove, this);
        this._container.style.cursor = '';
    },

    _removeShape: function () {
        if (!this._poly)
            return;
        this._map.removeLayer(this._poly);
        delete this._poly;
        this._markers.splice(0);
        this._markerGroup.clearLayers();
    },

    _onClick: function (e) {
        if (!this._drawing) {
            this._removeShape();
            this._startShape();
            return;
        }
    },

    _getTooltipText: function () {
        var labelText = L.Draw.Polyline.prototype._getTooltipText.call(this);
        if (!this._drawing) {
            labelText.text = '';
        }
        return labelText;
    }
});

L.Control.MeasureControl = L.Control.extend({

    statics: {
        TITLE: '测距'
    },
    options: {
        position: 'topleft',
        handler: {}
    },
    setDisable: function () {
        this.handler.disable.call(this.handler);
    },
    toggle: function () {
        if (this.handler.enabled()) {
            this.handler.disable.call(this.handler);
        } else {
            this.handler.enable.call(this.handler);
        }
    },

    onAdd: function (map) {
        var className = 'leaflet-control-draw';

        this._container = L.DomUtil.create('div', 'leaflet-bar');

        this.handler = new L.Polyline.Measure(map, this.options.handler);
        this.handler.on('enabled', function () {
            L.DomUtil.addClass(this._container, 'enabled');
        }, this);

        this.handler.on('disabled', function () {
            L.DomUtil.removeClass(this._container, 'enabled');
        }, this);

        var link = L.DomUtil.create('a', className + '-measure', this._container);
        link.href = '#';
        link.title = L.Control.MeasureControl.TITLE;

        L.DomEvent
            .addListener(link, 'click', L.DomEvent.stopPropagation)
            .addListener(link, 'click', L.DomEvent.preventDefault)
            .addListener(link, 'click', this.toggle, this);

        return this._container;
    }
});


L.Map.mergeOptions({
    measureControl: false
});

L.Map.mergeOptions({
    measureAreaControl: false
});

L.Map.addInitHook(function () {
    if (this.options.measureControl) {
        this.measureControl = L.Control.measureControl().addTo(this);
    }
});
L.Map.addInitHook(function () {
    if (this.options.measureAreaControl) {
        this.measureAreaControl = L.Control.measureAreaControl().addTo(this);
    }
});

L.Control.measureControl = function (options) {
    return new L.Control.MeasureControl(options);
};
L.Control.measureAreaControl = function (options) {
    return new L.Control.MeasureAreaControl(options);
};

