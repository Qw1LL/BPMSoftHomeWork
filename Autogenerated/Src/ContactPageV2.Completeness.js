define("ContactPageV2", ["ConfigurationConstants", "ConfigurationRectProgressBarGenerator",
		"CompletenessIndicator", "CompletenessMixin", "css!CompletenessCSSV2", "TooltipUtilities"
	],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Contact",
			attributes: {
				CompletenessValue: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					value: 0
				},
				MissingParametersCollection: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				}
			},
			mixins: {
				CompletenessMixin: "BPMSoft.CompletenessMixin",
				TooltipUtilitiesMixin: "BPMSoft.TooltipUtilities"
			},
			details: /**SCHEMA_DETAILS*/ {
				ContactCommunication: {
					schemaName: "ContactCommunicationDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					},
					completeness: {
						isTyped: true,
						typeColumn: "CommunicationType",
						typeSchemaName: "CommunicationType"
					}
				},
				EmailDetailV2: {
					schemaName: "EmailDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					},
					completeness: {
						isTyped: false,
						typeColumn: "Type",
						typeValue: ConfigurationConstants.Activity.Type.Email
					}
				},
				ContactAddress: {
					schemaName: "ContactAddressDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					},
					completeness: {
						isTyped: true,
						typeColumn: "AddressType",
						typeSchemaName: "AddressType"
					}
				},
				Activities: {
					schemaName: "ActivityDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					},
					completeness: {
						isTyped: false,
						typeColumn: "Type",
						typeValue: ConfigurationConstants.Activity.Type.Task
					}
				},
				ContactAnniversary: {
					schemaName: "ContactAnniversaryDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					},
					completeness: {
						isTyped: true,
						typeColumn: "AnniversaryType",
						typeSchemaName: "AnniversaryType"
					}
				}
			} /**SCHEMA_DETAILS*/ ,
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "Confirmed",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"wrapClass": ["contact-header-container-label"],
						"layout": {
							"column": 4,
							"row": 3,
							"colSpan": 8
						}
					}
				}, {
					"operation": "insert",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "CompletenessContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				}, {
					"operation": "insert",
					"parentName": "CompletenessContainer",
					"propertyName": "items",
					"name": "CompletenessValue",
					"values": {
						"generator": "ConfigurationRectProgressBarGenerator.generateProgressBar",
						"controlConfig": {
							"value": {
								"bindTo": "CompletenessValue"
							},
							"menu": {
								"items": {
									"bindTo": "MissingParametersCollection"
								}
							},
							"sectorsBounds": {
								"bindTo": "CompletenessSectorsBounds"
							}
						},
						"tips": []
					}
				}, {
					"operation": "insert",
					"parentName": "CompletenessValue",
					"propertyName": "tips",
					"name": "CompletenessTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.CompletenessHint"}
					}
				}
			] /**SCHEMA_DIFF*/ ,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.set("MissingParametersCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onDetailChanged
				 * @overridden
				 */
				onDetailChanged: function() {
					this.callParent(arguments);
					this.calculateCompleteness();
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					if (this.isEditMode()) {
						var collection = this.get("MissingParametersCollection");
						collection.clear();
						this.set("CompletenessValue", 0);
						this.calculateCompleteness();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					var callParentOnSaved = this.get("CallParentOnSaved");
					this.callParent(arguments);
					if (!callParentOnSaved && !this.isNewMode() && !this.get("IsProcessMode")) {
						this.calculateCompleteness();
					}
				},

				/**
				 * Starts calculation of the completeness of the data content.
				 * @protected
				 */
				calculateCompleteness: function() {
					var config = {
						recordId: this.get("Id"),
						schemaName: this.entitySchemaName
					};
					this.mixins.CompletenessMixin.getCompleteness.call(this, config, this.calculateCompletenessResponce, this);
				},

				/**
				 * Handles the response from mixin calculation completeness.
				 * @protected
				 * @param {Object} completenessResponce Response from mixin calculation completeness.
				 */
				calculateCompletenessResponce: function(completenessResponce) {
					if (this.Ext.isEmpty(completenessResponce)) {
						return;
					}
					var missingParametersCollection = completenessResponce.missingParametersCollection;
					var completeness = completenessResponce.completenessValue;
					var scale = completenessResponce.scale;
					if (!this.Ext.isEmpty(missingParametersCollection)) {
						var collection = this.get("MissingParametersCollection");
						collection.clear();
						collection.loadAll(missingParametersCollection);
					}
					if (this.Ext.isObject(scale) && this.Ext.isArray(scale.sectorsBounds)) {
						this.set("CompletenessSectorsBounds", scale.sectorsBounds);
					}
					if (this.Ext.isNumber(completeness)) {
						this.set("CompletenessValue", completeness);
					}
				}
			}
		};
	}
);
