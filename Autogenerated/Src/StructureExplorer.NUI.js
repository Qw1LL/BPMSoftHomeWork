define("StructureExplorer", ["StructureExplorerResources", "StructureExplorerComponent"], function(resources) {
	Ext.define("BPMSoft.control.StructureExplorer", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.StructureExplorer",

		mixins: {
			customEvent: "BPMSoft.mixins.CustomEventDomMixin",
		},

		setStructureExplorerLocalization: "getStructureExplorerTranslation",

		/**
		 * Structure explorer configuration.
		 * @type {Object}
		 * @param {Guid} config.entitySchemaUId;
		 * @param {Guid} [config.displayId];
		 * @param {BPMSoft.DataValueType} [config.dataValueType];
		 * @param {Boolean} [config.onlyLookups];
		 * @param {Boolean} [config.firstColumnsOnly];
		 * @param {Boolean} [config.enableBlobDataValueType];
		 * @param {string[]} [config.allowedReferenceSchemas];
		 * @param {BPMSoft.DataValueType[]} [config.excludedDataValueTypes];
		 * @param {Number} [config.usageType];
		 * @param {string[]} [config.allowedItems];
		 * @param {string[]} [config.excludedItems];
		 * @param {string[]} [config.selectedMetaPaths];
		 */
		config: null,

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\">',
			'<ts-structure-explorer-proxy id=\"{id}\"',
			' config = \"{config}\">',
			'</ts-structure-explorer-proxy>',
			'</div>'
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		_subscribeCustomEvents: function() {
			this.mixins.customEvent.init();
			this._publishStructureExplorerLocalization();
		},

		_publishStructureExplorerLocalization: function () {
			this.mixins.customEvent.publish(this.setStructureExplorerLocalization, {
				'StructureExplorerDialog.NoData': resources.localizableStrings.StructureExplorerNoDataCaption,
				'StructureExplorerDialog.Title': resources.localizableStrings.StructureExplorerTitle,
				'StructureExplorerDialog.CancelButtonCaption': resources.localizableStrings.StructureExplorerCancelButtonCaption,
				'StructureExplorerDialog.SelectButtonCaption': resources.localizableStrings.StructureExplorerSelectButtonCaption,
				'StructureExplorerDialog.FieldsTabCaption': resources.localizableStrings.StructureExplorerFieldsTabCaption,
				'StructureExplorerDialog.RelatedObjectsTabCaption': resources.localizableStrings.StructureExplorerRelatedObjectsTabCaption,
				'StructureExplorerDialog.SearchPlaceHolder': resources.localizableStrings.StructureExplorerSearchPlaceHolder,
			});
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"selected"
			);
			this._subscribeCustomEvents();
		},

		/**
		 * @inheritDoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			Ext.apply(tplData, {
				config: this.config
			});
			return tplData;
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const el = this.structureExplorerEl;
			if (el) {
				el.on("selected", this.handleSelected, this);
			}
		},

		/**
		 * @inheritDoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const el = this.structureExplorerEl;
			if (el) {
				el.un("selected", this.handleSelected, this);
			}
		},

		/**
		 * Handles selected.
		 * @param {Object} event selected.
		 */
		handleSelected: function(event) {
			const selected = event.browserEvent.detail;
			this.fireEvent("selected", selected);
		},

		/**
		 * @inheritDoc BPMSoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const config = {
				config: {
					changeMethod: "setConfig"
				}
			};
			Ext.apply(config, bindConfig);
			return config;
		},

		/**
		 * Sets configuration.
		 * @param {string} config Configuration.
		 */
		setConfig: function(config) {
			if (this.config === config || Ext.isEmpty(config)) {
				return;
			}
			this.config = BPMSoft.encodeHtml(BPMSoft.encode(config));
			this._setAttribute("config", this.config);
		},

		/**
		 * @inheritDoc BPMSoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				structureExplorerEl: "#" + this.id
			};
		},

		/**
		 * @private
		 */
		_setAttribute: function(name, value) {
			if (this.rendered) {
				this.structureExplorerEl.dom.setAttribute(name, value);
			}
		}
	});

	return BPMSoft.StructureExplorer;

});
