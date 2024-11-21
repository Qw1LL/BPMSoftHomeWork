define("PreconfiguredEntityPageV2", ["CustomProcessPageV2Utilities"],
	/**
	 * @class BPMSoft.configuration.PreconfiguredEntityPageV2
	 * ###### ############### ######## c EntitySchema ## ########
	 */
	function() {
		return {
			mixins: {
				BaseProcessViewModel: "BPMSoft.CustomProcessPageV2Utilities"
			},
			attributes: {
				"SomeCalcField": {
					name: "CalcField",
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"TextParameter1": { dataValueType: BPMSoft.DataValueType.TEXT },
				"LookupParameter1": { dataValueType: BPMSoft.DataValueType.LOOKUP }
			},
			rules: {},
			details: /**SCHEMA_DETAILS*/{
				Activities: {
					schemaName: "ActivityDetailV2",
					filter: {
						masterColumn: "LookupParameter1",
						detailColumn: "Contact"
					},
					subscriber: function() {
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent();
				},

				/**
				 * @overridden
				 */
				initHeaderCaption: Ext.emptyFn,

				/**
				 * @protected
				 * @overridden
				 */
				initPrintButtonMenu: Ext.emptyFn,

				/**
				 * @overridden
				 * @param {Object} args #########
				 * @param {Object} tag ###
				 */
				loadVocabulary: function(args, tag) {
					args.schemaName = this.model.attributes[tag].referenceSchemaName;
					this.callParent(arguments);
				},

				/**
				 * @overridden
				 */
				onCloseCardButtonClick: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * @protected
				 */
				onNextButtonClick: function() {
					this.acceptProcessElement("NextButton");
				}
			},
			diff: /**SCHEMA_DIFF*/[
/*				{
					"operation": "remove",
					"name": "Tabs"
				},*/
				{
					"operation": "merge",
					"name": "ActionButtonsContainer",
					"values": {
						visible: true
					}
				},
				{
					"operation": "merge",
					"name": "actions",
					"values": {
						visible: false
					}
				},
				{
					"operation": "insert",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"name": "NextButton",
					"values": {
						caption: "NextButton",
						itemType: BPMSoft.ViewItemType.BUTTON,
						classes: {textClass: "actions-button-margin-right"},
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						click: {bindTo: "onNextButtonClick"}
					}
				},
				/*{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {
						itemType: BPMSoft.ViewItemType.CONTAINER,
						items: []
					}
				},*/
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"name": "GeneralInfoControlGroup",
					"propertyName": "items",
					"values": {
						itemType: BPMSoft.ViewItemType.CONTROL_GROUP,
						items: [],
						controlConfig: {
							collapsed: false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoControlGroup",
					"propertyName": "items",
					"name": "GeneralInfoBlock",
					"values": {
						itemType: BPMSoft.ViewItemType.GRID_LAYOUT,
						items: []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "TextParameter1",
					"values": {
						caption: "TextParameter1",
						contentType: BPMSoft.ContentType.TEXT,
						bindTo: "TextParameter1",
						layout: {column: 0, row: 0, colSpan: 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "LookupParameter1",
					"values": {
						caption: "LookupParameter1",
						contentType: BPMSoft.ContentType.LOOKUP,
						bindTo: "LookupParameter1",
						layout: {column: 0, row: 1, colSpan: 11}
					}
				}
			]/**SCHEMA_DIFF*/,
			userCode: {}
		};
	});
