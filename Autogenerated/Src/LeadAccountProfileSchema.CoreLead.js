/**
 * Lead account profile class.
 * @class BPMSoft.LeadAccountProfileSchema
 */
define("LeadAccountProfileSchema", ["LeadAccountProfileSchemaResources", "LeadSimilarEntitiesProfileSchemaUtilities"],
	function(resources) {
		return {
			entitySchemaName: "Account",
			mixins: {
				LeadSimilarEntitiesUtilities: "BPMSoft.LeadSimilarEntitiesProfileSchemaUtilities"
			},
			attributes: {
				/**
				 * Virtual collection of Account entity primary column values.
				 */
				"SimilarCollection": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					"value": []
				},
				/**
				 * Enabled state of the Similar button.
				 */
				"SimilarButtonEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * The caption of the Similar button.
				 */
				"SimilarButtonCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: resources.localizableStrings.SimilarButtonCaption
				},
				/**
				 * The hint of the Similar button.
				 */
				"SimilarButtonHintText": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: resources.localizableStrings.SimilarButtonNotFoundHintText
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseProfileSchema#onCardEntityInitialized
				 * @overridden
				 */
				onCardEntityInitialized: function() {
					this.callParent(arguments);
					this.initSimilarEntityRecordsCollection();
				},

				/**
				 * @inheritdoc BPMSoft.BaseProfileSchema#initEntity
				 * @overridden
				 */
				initEntity: function() {
					this.callParent(arguments);
					this.initSimilarEntityRecordsCollection();
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"name": "SimilarButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"classes": {
							"textClass": "blank-slate-button"
						},
						"caption": {"bindTo": "SimilarButtonCaption"},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"enabled": true,
						"visible": {"bindTo": "SimilarButtonEnabled"},
						"click": {"bindTo": "onSimilarButtonClick"},
						"tips": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SimilarButton",
					"propertyName": "tips",
					"name": "SimilarButtonTip",
					"values": {
						"content": {"bindTo": "SimilarButtonHintText"},
						"style": BPMSoft.TipStyle.WHITE,
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.HOVER
						},
						"tools": []
					}
				},
			]
		};
	});
