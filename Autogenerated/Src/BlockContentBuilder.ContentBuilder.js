/**
 * Parent: ContentBuilder
 */
define("BlockContentBuilder", ["css!ProcessSchemaElementPropertiesEditCSS"], function() {
	return {
		messages: {
			"SetContentBuilderConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetContentBuilderConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"EditContentBlockDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"InitializedContentBuilder": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"SelectedContentItemChange": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * @override
			 */
			UseBlockLibrary: {
				value: false
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_onSetContentBuilderConfig: function(config) {
				this.set("ContentBuilderConfig", config);
				this.initializeSheet();
				this._selectFirstItem();
			},

			/**
			 * @private
			 */
			_onGetContentBuilderConfig: function() {
				const contentBuilderHelper = this.createContentBuilderHelper();
				const config = contentBuilderHelper.toJSON(this);
				return config;
			},

			/**
			 * @private
			 */
			_selectFirstItem: function() {
				const item = this.get("Items").first();
				if (item) {
					item.set("Selected", true);
					item.set("Movable", false);
					item.set("Removable", false);
					item.set("Clonable", false);
				}
			},

			/**
			 * @private
			 */
			_onEditContentBlockDesigner: function() {
				this.set("IsContentBlockDesignerVisible", true);
			},

			/**
			 * @private
			 */
			_subscribeOnSandboxEvents: function() {
				this.sandbox.subscribe("SetContentBuilderConfig", this._onSetContentBuilderConfig, this);
				this.sandbox.subscribe("GetContentBuilderConfig", this._onGetContentBuilderConfig, this);
				this.sandbox.subscribe("EditContentBlockDesigner", this._onEditContentBlockDesigner, this);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#init
			 * @override
			 */
			init: function(callback, scope) {
				this._subscribeOnSandboxEvents();
				this.callParent([function() {
					this.sandbox.publish("InitializedContentBuilder");
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#getContentSheetConfig
			 * @override
			 */
			getContentSheetConfig: function(callback, scope) {
				const blockConfig = this.get("ContentBuilderConfig");
				const config = {
					ItemType: "sheet",
					Items: [blockConfig]
				};
				Ext.callback(callback, scope, [config]);
			},

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this._selectFirstItem();
			},

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#setItemTools
			 * @override
			 */
			setItemTools: function(item) {
				item.set("Removable", false);
				item.set("Clonable", false);
				item.set("Movable", false);
			},

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#onSelectedContentItemChange
			 * @override
			 */
			onSelectedContentItemChange: function() {
				this.callParent(arguments);
				this.sandbox.publish("SelectedContentItemChange");
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "HeaderContainer"
			}
		]/**SCHEMA_DIFF*/
	};
});
