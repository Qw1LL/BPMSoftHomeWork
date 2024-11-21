/**
 * Lead contact profile class.
 * @class BPMSoft.LeadContactProfileSchema
 */
define("LeadContactProfileSchema",["LeadContactProfileSchemaResources", "LeadSimilarEntitiesProfileSchemaUtilities",
		"CommunicationOptionsMixin"],
	function(resources) {
		return {
			entitySchemaName: "Contact",
			mixins: {
				LeadSimilarEntitiesUtilities: "BPMSoft.LeadSimilarEntitiesProfileSchemaUtilities",

				/**
				 * @class CommunicationOptionsMixin Mixin, implements communication options usage methods.
				 */
				CommunicationOptionsMixin: "BPMSoft.CommunicationOptionsMixin"
			},
			messages: {
				/**
				 * @message CallCustomer
				 * Starts phone call in CTI panel.
				 */
				"CallCustomer": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetEntityInfo
				 * Returns information about master entity for minipage.
				 */
				"GetMiniPageMasterEntityInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Virtual collection of Contact entity primary column values.
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
				},

				/**
				 * Related page column name.
				 * @type {String}
				 */
				"RelatedPageRecordColumn": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: "Lead"
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
				},

				/**
				 * Starts call in CTI panel.
				 * @param {String} number Phone number to call.
				 * @return {Boolean} False, to stop click event propagation.
				 */
				onCallClick: function(number) {
					return this.callLeadWithRelations(number, this.$Id, this.getProfileRelationFields());
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
				{
					"operation": "merge",
					"name": "Job",
					"parentName": "ProfileContentContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "JobTitle",
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 20
						}
					}
				},
				{
					"operation": "merge",
					"name": "MobilePhone",
					"parentName": "ProfileContentContainer",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.PhoneEdit",
						"bindTo": "MobilePhone",
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 20
						}
					}
				},
				{
					"operation": "remove",
					"name": "Phone"
				},
				{
					"operation": "remove",
					"name": "Email"
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
