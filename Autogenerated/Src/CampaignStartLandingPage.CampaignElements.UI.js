/**
 * Schema of campaign start Landing element page.
 * Parent: CampaignLandingPage => EntityCampaignSchemaElementPage
 */
define("CampaignStartLandingPage", [],
	function() {
	return {
		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement"
		},
		attributes: {
			/**
			 * Entity schema UId of landing's object.
			 * @type {String}
			 */
			"LandingEntitySchemaUId": {
				"dataValueType": this.BPMSoft.DataValueType.MAPPING,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Entity schema Name of landing's object.
			 * @type {String}
			 */
			"LandingEntitySchemaName": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Contact column name of landing's object.
			 * @type {String}
			 */
			"LandingEntityContactColumn": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Web form id column name of landing's object.
			 * @type {String}
			 */
			"LandingEntityWebFormColumn": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Flag to indicate state of participants' recurring entrance by signal.
			 * @type {Boolean}
			 */
			"IsRecurring": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false,
				"onChange": "onIsRecurringChanged"
			},

			/**
			 * Group of filters that is used for filtering entities by webFormId.
			 * @type {Object}
			 */
			"LandingEntityFilters": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			}
		},
		methods: {

			/**
			 * Returns a caption of entity schema.
			 * @private
			 * @param {Guid} schemaUId Unique identifier of entity schema.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The callback execution context.
			 * @return {String} The caption of entity schema.
			 */
			_getSchemaCaptionByUId: function(schemaUId, callback, scope) {
				BPMSoft.EntitySchemaManager.findItemByUId(schemaUId, function(item) {
					callback.call(scope, item.getCaption());
				}, this);
			},

			/**
			 * @private
			 */
			_isRecurringAllowed: function() {
				return BPMSoft.Features.getIsEnabled("CampaignSignalRecurringEntrance");
			},

			/**
			 * @private
			 */
			_initLandingEntityAsync: function(landingId, callback) {
				if (!landingId) {
					return;
				}
				BPMSoft.chain(
					function(next) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "GeneratedWebForm",
							rowCount: 1
						});
						esq.addColumn("Type.SchemaUid");
						esq.getEntity(landingId, function(response) {
							if (response.success && response.entity) {
								var schemaUid = response.entity.get("Type.SchemaUid").value;
								var schemaName = response.entity.get("Type.SchemaUid").displayValue;
								this.set("LandingEntitySchemaUId", schemaUid);
								this.set("LandingEntitySchemaName", schemaName);
								next();
							}
						}, this);
					},
					function (next) {
						var uid = this.get("LandingEntitySchemaUId");
						BPMSoft.EntitySchemaManager.getInstanceByUId(uid, next, this);
					},
					function (next, entitySchema) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "CampaignLandingEntity",
							rowCount: 1
						});
						esq.addColumn("ContactColumn");
						esq.addColumn("WebFormColumn");
						esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "EntityObject.Name", entitySchema.name));
						esq.getEntityCollection(function(response) {
							if (response.success && response.collection.getCount() > 0) {
								var item = response.collection.first();
								var contactColumn = item.get("ContactColumn");
								var webFormColumn = item.get("WebFormColumn");
								this.set("LandingEntityContactColumn", contactColumn);
								this.set("LandingEntityWebFormColumn", webFormColumn);
							}
							next();
						}, this);
					},
					function () {
						var landingFilter = BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, this.get("LandingEntityWebFormColumn"), landingId);
						var filterGroup = Ext.create("BPMSoft.FilterGroup");
						filterGroup.rootSchemaName = this.get("LandingEntitySchemaName");
						filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
						filterGroup.addItem(landingFilter);
						var serializedFilter = filterGroup.serialize({
							serializeFilterManagerInfo: true
						});
						var deserializedFilters = BPMSoft.deserialize(serializedFilter);
						var serializedFilterData = {
							className: "BPMSoft.FilterGroup",
							serializedFilterEditData: serializedFilter,
							dataSourceFilters: deserializedFilters.serialize()
						};
						serializedFilterData = BPMSoft.encode(serializedFilterData);
						this.set("LandingEntityFilters", serializedFilterData);
						if (callback) {
							callback.call(this);
						}
					},
					this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this.set("LandingEntitySchemaName", "");
			},

			/**
			 * Handles change of recurring sign
			 * @public
			 */
			onIsRecurringChanged: function(model, value) {
				var element = this.get("ProcessElement");
				element.isRecurring = value;
				element.updateMarkers();
			},

			/**
			 * @inheritdoc CampaignBaseAudiencePropertiesPage#getContextHelpCode
			 * @override
			 */
			getContextHelpCode: function() {
				return "CampaignStartLandingElement";
			},

			/**
			 * @inheritdoc BPMSoft.ProcessFlowElementPropertiesPage#saveParameters
			 * @override
			 */
			saveParameters: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.ProcessFlowElementPropertiesPage#initParameters
			 * @override
			 */
			initParameters: function(element) {
				this.callParent(arguments);
				this.$IsRecurring = element.isRecurring;
			},

			/**
			 * @inheritdoc BaseCampaignSchemaElementPage#initPageAsync
			 * @override
			 */
			initPageAsync: function(element, callback, scope) {
				const parentMethod = this.getParentMethod();
				if (!Ext.isEmpty(element.landingId)) {
					BPMSoft.chain(
						function(next) {
							parentMethod.call(scope, element, next);
						},
						function() {
							this._initLandingEntityAsync.call(scope, element.landingId, callback);
						},
						scope
					);
				} else {
					BPMSoft.chain(
						function(next) {
							parentMethod.call(scope, element, next);
						},
						function() {
							callback.call(scope);
						},
						scope
					);
				}
			},

			/**
			 * @inheritdoc BPMSoft.ProcessFlowElementPropertiesPage#saveValues
			 * @override
			 */
			saveValues: function() {
				this.callParent(arguments);
				var element = this.$ProcessElement;
				element.isRecurring = this.$IsRecurring;
				element.entitySchemaUId = this.get("LandingEntitySchemaUId");
				element.entityFilters = this.get("LandingEntityFilters");
			},

			/**
			 * @inheritdoc CampaignLandingPage#setPageParameters
			 * @override
			 */
			setPageParameters: function(landingEntity) {
				this.callParent(arguments);
				if (landingEntity && landingEntity.$Id) {
					this._initLandingEntityAsync(landingEntity.$Id);
				}
			},

			/**
			 * @inheritdoc EntityCampaignSchemaElementPage#clearPageParameters
			 * @override
			 */
			clearPageParameters: function() {
				this.callParent(arguments);
				this.set("IsRecurring", false);
				this.set("LandingEntitySchemaUId", null);
				this.set("LandingEntitySchemaName", "");
				this.set("LandingEntityContactColumn", "");
				this.set("LandingEntityWebFormColumn", "");
				this.set("LandingEntityFilters", null);
			},

			/**
			 * @inheritdoc BPMSoft.FilterModuleMixin#getFilterModuleConfig
			 * @override
			 */
			getFilterModuleConfig: function(entitySchemaName) {
				var baseConfig = this.callParent(arguments);
				var config = {
					rightExpressionMenuAligned: true
				};
				return Ext.apply(baseConfig, config);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "LandingEntitySchemaNameLabel",
				"parentName": "ContentContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 6,
						"colSpan": 24
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.LandingEntitySchemaNameCaption"
					},
					"classes": {
						"labelClass": ["label-small"]
					},
					"visible": {
						"bindTo": "isEntitySelected"
					}
				}
			},
			{
				"operation": "insert",
				"name": "LandingEntitySchemaName",
				"parentName": "ContentContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"visible": false
					},
					"layout": {
						"column": 0,
						"row": 7,
						"colSpan": 24
					},
					"classes": {
						"labelClass": ["feature-item-label"]
					},
					"enabled": false,
					"visible": {
						"bindTo": "isEntitySelected"
					},
					"controlConfig": {"tag": "LandingEntitySchemaName"}
				}
			},
			{
				"operation": "insert",
				"name": "RecurringAddContainer",
				"parentName": "ContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"visible": "$_isRecurringAllowed",
					"layout": {
						"column": 0,
						"row": 8,
						"colSpan": 24
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "RecurringAddLayout",
				"propertyName": "items",
				"parentName": "RecurringAddContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "IsRecurringLabel",
				"parentName": "RecurringAddLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.IsRecurringLabel",
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsRecurring",
				"parentName": "RecurringAddLayout",
				"propertyName": "items",
				"values": {
					"wrapClass": ["t-checkbox-control"],
					"caption": "$Resources.Strings.IsRecurringCaption",
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 23
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "RecurringAddLayout",
				"propertyName": "items",
				"name": "RecurringAddHint",
				"values": {
					"layout": {"column": 23, "row": 1, "colSpan": 1},
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$Resources.Strings.IsRecurringHint",
					"controlConfig": {
						"classes": {
							"wrapperClass": "t-checkbox-information-button"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.InfoButtonImage"
						}
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
