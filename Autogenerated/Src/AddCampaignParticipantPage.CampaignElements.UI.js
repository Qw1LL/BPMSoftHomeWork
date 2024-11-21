define("AddCampaignParticipantPage", ["BusinessRuleModule", "FilterModuleMixin"], function(BusinessRuleModule) {
	BPMSoft.AddCampaignAudience = {
		DefaultRecurringFrequencyInDays: 30
	};
	return {
		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement"
		},
		properties: {
			defaultAudienceSchemaId: "5b229e55-8ebf-414a-8dee-26e2b059025b",
			folderSuffix: "Folder"
		},
		attributes: {
			/**
			 * Number of days before participant will be added next time.
			 * @type {Number}
			 */
			"DaysNumber": {
				"dataValueType": this.BPMSoft.DataValueType.INTEGER,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": BPMSoft.AddCampaignAudience.DefaultRecurringFrequencyInDays
			},

			/**
			 * Flag to indicate that element can do recurring participants add.
			 * @type {Boolean}
			 */
			"IsRecurring": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"onChange": "onIsRecurringChanged"
			},

			/**
			 * Values collection of lookup for AudienceSource.
			 * @type {BPMSoft.Collection}
			 */
			"AudienceSchemaCollection": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: Ext.create("BPMSoft.Collection")
			},

			/**
			 * Current audience schema to import participants to campaign.
			 * @type {Object}
			 */
			"AudienceSchema": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true
			}
		},
		rules: {
			"DaysNumber": {
				"BindExactTimeRequiredToDateMacro": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.REQUIRED,
					"conditions": [{
						"leftExpression": {
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "IsRecurring"
						},
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"rightExpression": {
							"type": BusinessRuleModule.enums.ValueType.CONSTANT,
							"value": true
						}
					}]
				}
			}
		},
		methods: {

			/**
			 * @private
			 */
			_getRecurringFrequencyInDays: function() {
				var validationInfo = this.validationInfo.get("DaysNumber") || { isValid: true };
				if (this.$IsRecurring && validationInfo.isValid) {
					return this.$DaysNumber;
				}
				return BPMSoft.AddCampaignAudience.DefaultRecurringFrequencyInDays;
			},

			/**
			 * Validates Folder column.
			 * If folder is not selected returns result with invalid validation message.
			 * @private
			 * @param {Object} folder Folder lookup object.
			 * @return {Object} Validation info.
			 */
			_folderValidator: function(folder) {
				var result = {
					invalidMessage: ""
				};
				if (Ext.isEmpty(folder) && this._checkAudienceSource(this.$AudienceSourceEnum.Folder)) {
					var message = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
					result.invalidMessage = message;
				}
				return result;
			},

			/**
			 * @private
			 */
			_validateDaysNumber: function(value) {
				var result = {
					isValid: true,
					invalidMessage: ""
				};
				if (this.$IsRecurring && value < 1) {
					result.isValid = false;
					result.invalidMessage = this.get("Resources.Strings.NegativeNumberErrorText");
				}
				return result;
			},

			/**
			 * @private
			 */
			_createAudienceSchemaESQ: function() {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "CampaignSignalEntity"
				});
				esq.addColumn("Id");
				esq.addColumn("EntityObject");
				esq.addColumn("Caption");
				return esq;
			},

			/**
			 * @private
			 */
			_getDefaultAudienceSchema: function() {
				var item = this.$AudienceSchemaCollection.findByFn(function(el) {
					return el.value === this.defaultAudienceSchemaId;
				}, this);
				if (item) {
					item.schemaName = this.defaultAudienceSchemaName;
					item.canSelectFolder = true;
				}
				return item;
			},

			/**
			 * @private
			 */
			_onAudienceSchemaInited: function(audienceSchema, callback, scope) {
				this.set("AudienceSchema", audienceSchema);
				this.on("change:AudienceSchema", this.onAudienceSchemaChanged, this);
				this._actualizeCanSelectFolders();
				callback.call(scope);
			},

			/**
			 * @private
			 */
			_initAudienceSchema: function(audienceSchemaId, callback, scope) {
				var selectedItem = this.$AudienceSchemaCollection.findByFn(function(el) {
					return el.value === audienceSchemaId;
				});
				if (!selectedItem) {
					selectedItem = this._getDefaultAudienceSchema();
				}
				if (!selectedItem) {
					return;
				}
				if (selectedItem.schemaName) {
					this._onAudienceSchemaInited(selectedItem, callback, scope);
					return;
				}
				BPMSoft.EntitySchemaManager.findItemByUId(selectedItem.entitySchemaUId, function(schema) {
					selectedItem.schemaName = schema.name;
					this._onAudienceSchemaInited(selectedItem, callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_initAudienceSchemaCollection: function(audienceSchemaId, callback, scope) {
				var esq = this._createAudienceSchemaESQ();
				esq.getEntityCollection(function(response) {
					this.loadAudienceSchemaCollection(response.collection);
					this._initAudienceSchema(audienceSchemaId, callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_updateAudienceSchemaData: function(props) {
				var schemaId = this.$AudienceSchema.value;
				var currentSchema = this.$AudienceSchemaCollection.findByFn(function(el) {
					return el.value === schemaId;
				}, this);
				BPMSoft.each(props, function(value, prop) {
					currentSchema[prop] = value;
				}, this);
			},

			/**
			 * @private
			 */
			_actualizeCanSelectFolders: function(hideMask) {
				var folderSchemaName = this._getFolderSchemaName();
				if (BPMSoft.isEmpty(this.$AudienceSchema.canSelectFolder)) {
					this.sandbox.requireModuleDescriptors(["find!" + folderSchemaName], function(result) {
						BPMSoft.require([folderSchemaName], function(schema) {
							var canSelectFolder = Boolean(schema);
							this.$CanSelectFolder = canSelectFolder;
							this._updateAudienceSchemaData({canSelectFolder: canSelectFolder});
							this._onCanSelectFoldersActualized(hideMask);
						}, this);
					}, this);
					return;
				}
				this.$CanSelectFolder = this.$AudienceSchema.canSelectFolder;
				this._onCanSelectFoldersActualized(hideMask);
				this.updateMarkers();
			},

			/**
			 * @private
			 */
			_onCanSelectFoldersActualized: function(hideMask) {
				if (!this.$CanSelectFolder && this._checkAudienceSource(this.$AudienceSourceEnum.Folder)) {
					var source = this.$AudienceSourceCollection.get(this.$AudienceSourceEnum.Filter.value);
					this.$AudienceSource = source;
				}
				if (this._checkAudienceSource(this.$AudienceSourceEnum.Filter)) {
					var filterModuleConfig = this.getFilterModuleConfig();
					var filterModuleId = this._getFilterEditModuleId();
					this.sandbox.publish("SetFilterModuleConfig", filterModuleConfig, [filterModuleId]);
				}
				if (hideMask) {
					this.hideBodyMask();
				}
			},

			/**
			 * @private
			 */
			_getFolderSchemaName: function() {
				return this.getFilterRootSchemaName() + this.folderSuffix;
			},

			/**
			 * @private
			 */
			_isCampaignAudienceImportEnabled: function() {
				return this.getIsFeatureEnabled("CampaignAudienceImport");
			},

			/**
			 * @inheritdoc CampaignBaseAudiencePropertiesPage#getContextHelpCode
			 * @override
			 */
			getContextHelpCode: function() {
				return "CampaignAddCampaignParticipantElement";
			},

			/**
			 * @inheritdoc BaseCampaignSchemaElementPage#initPageAsync
			 * @override
			 */
			initPageAsync: function(element, callback, scope) {
				var parentMethod = this.getParentMethod();
				this._initAudienceSchemaCollection(element.audienceSchemaId, function() {
					parentMethod.call(this, element, callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BaseCampaignSchemaElementPage#initElementProperties.
			 * @override
			 */
			 initElementProperties: function(element, callback, scope) {
				var parentMethod = this.getParentMethod();
				this._initAudienceSchema(element.audienceSchemaId, function() {
					this.set("IsRecurring", element.isRecurring);
					if (element.isRecurring && element.recurringFrequencyInDays) {
						this.$DaysNumber = element.recurringFrequencyInDays;
					}
					parentMethod.call(this, element, callback, scope);
				}, this);
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
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
			 * @overridden
			 */
			saveValues: function() {
				this.callParent(arguments);
				var element = this.get("ProcessElement");
				element.isRecurring = this.$IsRecurring;
				element.recurringFrequencyInDays = this._getRecurringFrequencyInDays();
				element.initLargeImage();
				element.audienceSchemaId = this.$AudienceSchema && this.$AudienceSchema.value;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Folder", this._folderValidator);
				this.addColumnValidator("DaysNumber", this._validateDaysNumber);
			},

			/**
			 * Handler on load audience schema list on combobox click.
			 * @protected
			 * @param {String} filter Text to contain.
			 * @param {BPMSoft.Collection} list Items collection.
			 */
			prepareAudienceSchemaList: function(filter, list) {
				list.reloadAll(this.$AudienceSchemaCollection);
			},

			/**
			 * Handler on "AudienceSchema" attribute change event.
			 * Clears folder/filter data and actualizes page state.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} model View model.
			 * @param {Object} value New value.
			 */
			onAudienceSchemaChanged: function(model, value) {
				this.set("FilterData", null);
				this.set("Folder", null);
				if (!value) {
					return;
				}
				this.loadPropertiesPageMask();
				if (!value.schemaName) {
					BPMSoft.EntitySchemaManager.findItemByUId(value.entitySchemaUId, function(schema) {
						this.$AudienceSchema.schemaName = schema.name;
						this._updateAudienceSchemaData({schemaName: schema.name});
						this._actualizeCanSelectFolders(true);
					}, this);
					return;
				}
				this._actualizeCanSelectFolders(true);
			},

			/**
			 * Loads available audience schemas to AudienceSchemaCollection.
			 * @protected
			 * @param {BPMSoft.Collection} collection Loaded audience schemas.
			 */
			loadAudienceSchemaCollection: function(collection) {
				var list = new BPMSoft.Collection();
				BPMSoft.each(collection, function(el) {
					var schemaObject = {
						value: el.$Id,
						displayValue: el.$Caption,
						caption: el.$Caption,
						entitySchemaUId: el.$EntityObject.value
					};
					list.add(el.$Id, schemaObject);
				}, this);
				list.sort("caption", this.BPMSoft.OrderDirection.ASC);
				this.$AudienceSchemaCollection.reloadAll(list);
			},

			/**
			 * @inheritdoc BPMSoft.CampaignBaseAudiencePropertiesPage#getFolderInfoData
			 * @override
			 */
			getFolderInfoData: function(element) {
				return {
					folderId: element.folderId,
					folderSchemaName: this._getFolderSchemaName()
				};
			},

			/**
			 * @inheritdoc BPMSoft.CampaignBaseAudiencePropertiesPage#getFilterRootSchemaName
			 * @override
			 */
			getFilterRootSchemaName: function() {
				if (!this.$AudienceSchema) {
					return this.defaultAudienceSchemaName;
				}
				return this.$AudienceSchema.schemaName;
			},

			/**
			 * @inheritdoc BPMSoft.CampaignBaseAudiencePropertiesPage#getFolderLookupConfig
			 * @override
			 */
			getFolderLookupConfig: function() {
				var config = this.callParent(arguments);
				config.entitySchemaName = this._getFolderSchemaName();
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.CampaignBaseAudiencePropertiesPage#getCustomLookupFilters
			 * @override
			 */
			getCustomLookupFilters: function() {
				if (this.$AudienceSchema.value === this.defaultAudienceSchemaId) {
					return this.callParent(arguments);
				}
				return BPMSoft.createFilterGroup();
			},

			/**
			 * @inheritdoc BPMSoft.CampaignBaseAudiencePropertiesPage#prepareFolderList
			 * @override
			 */
			prepareFolderList: function(filterParameter, list, columnName) {
				if (this.$AudienceSchema.schemaName === this.defaultAudienceSchemaName) {
					this.callParent(arguments);
				}
				var filters = this.getCustomLookupFilters();
				this.prepareLookupList(filters, filterParameter, this._getFolderSchemaName(),
					"FolderCollection", this);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AudienceEntitySchemaLayout",
				"parentName": "ContentContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"row": 0,
						"column": 0,
						"rowSpan": 1,
						"colSpan": 24
					},
					"visible": "$_isCampaignAudienceImportEnabled",
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "AudienceSchemaLabel",
				"parentName": "AudienceEntitySchemaLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.AudienceSchemaLabelCaption",
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "AudienceSchema",
				"parentName": "AudienceEntitySchemaLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"rowSpan": 1,
						"colSpan": 24
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": "$prepareAudienceSchemaList",
						"filterComparisonType": this.BPMSoft.StringFilterType.CONTAIN
					},
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "RecurringAddContainer",
				"parentName": "ContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"layout": {
						"column": 0,
						"row": 3,
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
						"colSpan": 22
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "RecurringAddLayout",
				"propertyName": "items",
				"name": "RecurringAddHint",
				"values": {
					"layout": {"column": 22, "row": 1, "colSpan": 1},
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$Resources.Strings.RecurringAddHint",
					"controlConfig": {
						"classes": {
							"wrapperClass": "t-checkbox-information-button"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.InfoButtonImage"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "DaysNumberLabel",
				"parentName": "RecurringAddLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.DaysNumberCaption",
					"visible": "$IsRecurring",
					"classes": {
						"labelClass": ["label-small"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "DaysNumber",
				"parentName": "RecurringAddLayout",
				"propertyName": "items",
				"values": {
					"dataValueType": this.BPMSoft.DataValueType.INTEGER,
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": false
					},
					"visible": "$IsRecurring"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
