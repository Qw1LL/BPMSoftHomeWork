define("IconizedProgressBar", ["ext-base", "IconizedProgressBarResources", "css!IconizedProgressBar",
		"BaseProgressBarIndicator"], function(Ext, Resources) {
		/**
		 * @class BPMSoft.controls.IconizedProgressBar
		 * Rectangle progress bar component class.
		 */
		Ext.define("BPMSoft.controls.IconizedProgressBar", {
			alternateClassName: "BPMSoft.IconizedProgressBar",
			extend: "BPMSoft.BaseProgressBarIndicator",

			/**
			 * Array of progress points config.
			 * @type {Array}
			 */
			_icons: [],

			/**
			 * Point icon url.
			 * @type {String}
			 */
			pointIconUrl: BPMSoft.ImageUrlBuilder.getUrl(Resources.localizableImages.DefaultPointIcon),

			/**
			 * Empty point icon url.
			 * @type {String}
			 */
			emptyPointIconUrl: BPMSoft.ImageUrlBuilder.getUrl(Resources.localizableImages.EmptyPointIcon),

			/**
			 * @inheritdoc BPMSoft.Component#tpl
			 * @override
			 */
			tpl: [
				/* jshint ignore:start */
				/* jscs:disable */
				'<div id="{id}-wrap" class="{wrapClass} ts-iconized-progress-bar-wrap">',
				'<div id="{id}-iconized-progress-bar" class="iconized-progress-bar">',
				'<ul>',
				'<tpl for="icons">',
				'<li><img class="progress-point-icon" src={url} /></li>',
				'</tpl>',
				'</ul>',
				'</div>',
				'<div id="{id}-overlay" class="overlay" style="{overlayElStyle}" data-item-marker="{id}">',
				'<span class="caption">{caption}',
				'<tpl if="captionSuffix">',
				'<span class="caption-suffix">{captionSuffix}</span>',
				'</tpl>',
				'</span>',
				'</div>',
				'<tpl if="menu">',
				'<span id="{id}-menuWrapEl" class="{menuWrapClass}"></span>',
				'</tpl>',
				'</div>'
				/* jscs:enable */
				/* jshint ignore:end */
			],

			/**
			 * Setups progress icon url array.
			 * @protected
			 */
			fillProgressPoints: function() {
				this._icons = [];
				var sectorsBounds = this.sectorsBounds;
				var pointsRange = sectorsBounds.length;
				if (this.validateSectorsBounds(sectorsBounds)) {
					for (var i = 0; i < pointsRange - 1; i++) {
						var targetIcon = (this.value > 0 && this.value >= sectorsBounds[i])
							? this.pointIconUrl
							: this.emptyPointIconUrl;
						if (Ext.isEmpty(targetIcon)) {
							continue;
						}
						var icon = {
							url: targetIcon
						};
						this._icons.push(icon);
					}
				}
			},

			/**
			 * @inheritdoc BPMSoft.Component#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this.selectors = {
					wrapEl: "#" + this.id + "-wrap",
					overlayEl: "#" + this.id + "-overlay"
				};
				this.addEvents(
					/**
					 * Progress bar click event
					 * @param {BPMSoft.IconizedProgressBar} this
					 */
					"click"
				);
			},

			/**
			 * Implements mixin interface {@link BPMSoft.Bindable}.
			 * @override
			 */
			getBindConfig: function() {
				var bindConfig = this.callParent(arguments);
				var iconizedIndicatorBindConfig = {
					pointIconUrl: {
						changeMethod: "setPointIconUrl"
					},
					emptyPointIconUrl: {
						changeMethod: "setEmptyPointIconUrl"
					}
				};
				Ext.apply(iconizedIndicatorBindConfig, bindConfig);
				return iconizedIndicatorBindConfig;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProgressBarIndicator#getTplData
			 * @override
			 */
			getTplData: function() {
				var tplData = this.callParent(arguments);
				this.fillProgressPoints();
				tplData.icons = this._icons;
				this.setSectorsProgressColor();
				return tplData;
			},

			/**
			 * @inheritdoc BPMSoft.Component#onAfterRender
			 * @override
			 */
			onAfterRender: function() {
				this.callParent(arguments);
				this.setWrapClasses();
			},

			/**
			 * @inheritdoc BPMSoft.Component#onAfterReRender
			 * @override
			 */
			onAfterReRender: function() {
				this.callParent(arguments);
				this.setWrapClasses();
			},

			/**
			 * Set indicator's style.
			 * @protected
			 */
			setWrapClasses: function() {
				if (this.overlayEl) {
					var captionStyle = {
						"color": this.progressColor
					};
					this.overlayEl.setStyle(captionStyle);
				}
			},

			/**
			 * Set point icon url.
			 * @param {String} iconUrl to custom icon for progress point.
			 */
			setPointIconUrl: function(iconUrl) {
				if (Ext.isEmpty(iconUrl) || this.pointIconUrl === iconUrl) {
					return;
				}
				this.pointIconUrl = iconUrl;
				this.safeRerender();
			},

			/**
			 * Set empty point icon url.
			 * @param {String} iconUrl to custom icon for "empty" progress point.
			 */
			setEmptyPointIconUrl: function(iconUrl) {
				if (Ext.isEmpty(iconUrl) || this.emptyPointIconUrl === iconUrl) {
					return;
				}
				this.emptyPointIconUrl = iconUrl;
				this.safeRerender();
			}
		});
		return BPMSoft.IconizedProgressBar;
	}
);
