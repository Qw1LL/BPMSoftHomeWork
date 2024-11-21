define("BusinessRuleActionDesignerViewModel", ["BusinessRuleActionDesignerViewModelResources",
	"BusinessRuleElementDesignerViewModel"], function(resources) {

		/**
		 * @class BPMSoft.Designers.BusinessRuleActionDesignerViewModel
		 */
		Ext.define("BPMSoft.Designers.BusinessRuleActionDesignerViewModel", {
			extend: "BPMSoft.BusinessRuleElementDesignerViewModel",
			alternateClassName: "BPMSoft.BusinessRuleActionDesignerViewModel",

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseModel#getModelColumns
			 * @protected
			 * @overridden
			 */
			getModelColumns: function() {
				var baseColumns = this.callParent(arguments);
				return this.Ext.apply(baseColumns, {
					"ControlClassName": {
						"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
						"dataValueType": BPMSoft.core.enums.DataValueType.TEXT
					},
					"RemoveActionIcon": {
						"dataValueType": BPMSoft.DataValueType.IMAGE,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"value": resources.localizableImages.RemoveActionIcon
					},
					"DefaultExpressionCaption": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"value": resources.localizableStrings.DefaultExpressionCaption
					}
				});
			},

			/**
			 * Return action title.
			 * @abstract
			 * @protected
			 * @return {String} Action title.
			 */
			getActionTitle: BPMSoft.abstractFn,

			/**
			 * Return title items.
			 * @protected
			 * @return {Array} Title items.
			 */
			getTitleItems: function() {
				return [{
					"className": "BPMSoft.Label",
					"caption": {"bindTo": "getActionTitle"}
				}, {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {"bindTo": "onRemoveButtonClick"},
					"imageConfig": {"bindTo": "RemoveActionIcon"},
					"markerValue": "RemoveAction"
				}];
			},

			/**
			 * Handler of remove button click.
			 * @protected
			 */
			onRemoveButtonClick: function() {
				this.fireEvent("removeAction", this);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseObject#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.addEvents(
					"removeAction"
				);
			},

			/**
			 * Enrich view config.
			 * @public
			 * @param  {Object} config View config.
			 */
			enrichViewConfig: function(config) {
				this.Ext.apply(config, {
					"className": this.get("ControlClassName"),
					"titleItems": this.getTitleItems()
				});
			}

			//endregion

		});
		return BPMSoft.BusinessRuleActionDesignerViewModel;
	});
