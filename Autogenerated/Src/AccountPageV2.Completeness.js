define("AccountPageV2", ["ConfigurationConstants", "CompletenessMixin",
		"ConfigurationRectProgressBarGenerator", "CompletenessIndicator", "css!CompletenessCSSV2", "TooltipUtilities"
	],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Account",
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
			details: {
				Communications: {
					schemaName: "AccountCommunicationDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Account"
					},
					completeness: {
						isTyped: true,
						typeColumn: "CommunicationType",
						typeSchemaName: "CommunicationType"
					}
				},
				AccountAddress: {
					schemaName: "AccountAddressDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Account"
					},
					completeness: {
						isTyped: true,
						typeColumn: "AddressType",
						typeSchemaName: "AddressType"
					}
				},
				EmailDetailV2: {
					schemaName: "EmailDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Account"
					},
					completeness: {
						isTyped: false,
						typeColumn: "Type",
						typeValue: ConfigurationConstants.Activity.Type.Email
					}
				},
				Activities: {
					schemaName: "ActivityDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Account"
					},
					completeness: {
						isTyped: false,
						typeColumn: "Type",
						typeValue: ConfigurationConstants.Activity.Type.Task
					}
				}
			},
			diff: /**SCHEMA_DIFF*/ [
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "AccountCompletenessContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["completeness-container"]},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}
				},
				"alias": {
					"name": "CompletenessContainer",
					"excludeProperties": ["layout"],
					"excludeOperations": ["remove", "move"]
				}
			},
			{
				"operation": "insert",
				"parentName": "AccountCompletenessContainer",
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
			},
			{
				"operation": "insert",
				"parentName": "CompletenessValue",
				"propertyName": "tips",
				"name": "CompletenessTip",
				"values": {
					"content": {"bindTo": "Resources.Strings.CompletenessHint"}
				}
			}] /**SCHEMA_DIFF*/,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 */
				init: function() {
					this.set("MissingParametersCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onDetailChanged
				 */
				onDetailChanged: function() {
					this.callParent(arguments);
					this.calculateCompleteness();
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
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
				 */
				onSaved: function() {
					this.callParent(arguments);
					if (!this.isNewMode() && !this.get("IsProcessMode")) {
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
