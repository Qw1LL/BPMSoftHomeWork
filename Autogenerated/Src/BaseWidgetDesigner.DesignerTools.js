define("BaseWidgetDesigner", ["BaseWidgetDesignerResources"], function(resources) {
	return {
		messages: {

			/**
			 * Designer is closed.
			 */
			"WidgetDesignerCancel": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}

		},
		mixins: {
		},
		attributes: {

			/**
			 * Is required to use current state .
			 */
			UseCurrentState: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			BodyAttributeName: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "edit-widget-settings"
			},
			ScrollPosition: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0
			}
		},
		methods: {

			/**
			 * Generates caption for required object related field.
			 * @protected
			 * @virtual
			 * @return {String} Returns caption for required object related field.
			 */
			getSectionBindingColumnCaption: function() {
				var widgetConfig = this.getWidgetInitConfig();
				var result = "";
				if (widgetConfig && widgetConfig.relatedObjectCaptionConfig) {
					var formatConfig = widgetConfig.relatedObjectCaptionConfig;
					var entitySchemaNameInfo = this.get("entitySchemaName");
					var lookupValue = (entitySchemaNameInfo && entitySchemaNameInfo.displayValue) || "";
					var captionFormat = this._getRelatedCaptionFormat(formatConfig);
					var localizedType = this._getRelatedObjectLocalizedType(formatConfig.itemType);
					result = this.Ext.String.format(captionFormat, lookupValue, formatConfig.itemCaption, localizedType);
				} else {
					result = this.callParent();
				}
				return result;
			},

			/**
			 * Generates localized type for required object related field.
			 * @private
			 * @param {String} objectType Object type.
			 * @return {String} Returns localized type for required object related field.
			 */
			_getRelatedObjectLocalizedType: function(objectType) {
				switch (objectType) {
					case "detail" :
						return resources.localizableStrings.RelatedObjectDetail;
					case "section":
						return resources.localizableStrings.RelatedObjectSection;
					default:
						return "";
				}
			},

			/**
			 * Generates caption format for required object related field.
			 * @private
			 * @param {Object} formatConfig Format configuration.
			 * @return {String} Returns caption format for required object related field.
			 */
			_getRelatedCaptionFormat: function(formatConfig) {
				var result = resources.localizableStrings.DefaultRelatedObjectCaptionFormat;
				if (formatConfig.itemType && formatConfig.itemCaption) {
					result = resources.localizableStrings.RelatedObjectCaptionFormat;
				}
				return result;
			},

			/**
			 * Cancels widget option changes.
			 * @protected
			 * @virtual
			 */
			cancel: function() {
				this.sandbox.publish("WidgetDesignerCancel", null, [this.sandbox.id]);
				this.callParent(arguments);
			},

			/**
			 * Informs that state must be rolled back.
			 * @protected
			 * @virtual
			 */
			backHistoryState: function() {
				if (this.get("UseCurrentState")) {
					this.sandbox.publish("BackHistoryState");
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				var scrollPosition = BPMSoft.utils.dom.getTopScroll();
				this.set("ScrollPosition", scrollPosition);
				var bodyAttributeName = this.get("BodyAttributeName");
				BPMSoft.utils.dom.setAttributeToBody(bodyAttributeName, true);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				var bodyAttributeName = this.get("BodyAttributeName");
				var scrollPosition = this.get("ScrollPosition");
				BPMSoft.utils.dom.setAttributeToBody(bodyAttributeName, false);
				BPMSoft.utils.dom.setTopScroll(scrollPosition);
				this.callParent(arguments);
			}
		},
		diff: [
		]
	};
});
