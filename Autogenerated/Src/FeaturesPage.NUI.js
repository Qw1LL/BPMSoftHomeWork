define("FeaturesPage", ["css!FeaturesPageCSS"], function() {
	return {
		entitySchemaName: "Feature",
		attributes: {
			/**
			 * List of features.
			 * @type {BPMSoft.DataValueType.COLLECTION}
			 */
			"FeaturesList": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": Ext.create("BPMSoft.BaseViewModelCollection")
			},
			/**
			 * Feature code.
			 * @type {BPMSoft.dataValueType.TEXT}
			 */
			"FeatureCode": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.FeatureCodeCaption"},
				"isRequired": true
			},
			/**
			 * Feature name.
			 * @type {BPMSoft.dataValueType.TEXT}
			 */
			"FeatureName": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.FeatureNameCaption"}
			},
			/**
			 * Feature description.
			 * @type {BPMSoft.dataValueType.TEXT}
			 */
			"FeatureDescription": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.FeatureDescriptionCaption"}
			},
			/**
			 * Feature visible.
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"SaveButtonVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": false
			},
			/**
			 * Schema Generator Config
			 * @type {BPMSoft.DataValueType.CUSTOM_OBJECT}
			 */
			"SchemaGeneratorConfig": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": {
					schemaName: "FeatureItemSchema",
					profileKey: "FeatureItemSchema"
				}
			},
			/**
			 * Schema builder class name
			 * @type {BPMSoft.DataValueType.TEXT}
			 */
			"SchemaBuilderClassName": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": "BPMSoft.SchemaBuilder"
			}
		},
		messages: {
			/**
			 * @message InitDataViews
			 * Changes current page header.
			 */
			"InitDataViews": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message ChangeHeaderCaption
			 * Changes current page header.
			 */
			"ChangeHeaderCaption": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message NeedHeaderCaption
			 */
			"NeedHeaderCaption": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "FeaturesContentContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FeatureActionContainer",
				"parentName": "FeaturesContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"classes": {
						"wrapClassName": ["action-feature-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "CreateFeatureContainer",
				"parentName": "FeaturesContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"classes": {
						"wrapClassName": ["add-feature-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "CreateFeatureLabel",
				"parentName": "FeatureActionContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"classes": {
						"wrapClassName": ["feature-label-container"],
						"labelClass": ["feature-label"]
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.CreateFeatureCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "FeatureCode",
				"parentName": "CreateFeatureContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					},
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"value": {
						"bindTo": "FeatureCode"
					},
					"classes": {
						"labelClass": ["feature-item-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "FeatureName",
				"parentName": "CreateFeatureContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					},
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"value": {
						"bindTo": "FeatureName"
					},
					"classes": {
						"labelClass": ["feature-item-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "FeatureDescription",
				"parentName": "CreateFeatureContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					},
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"value": {
						"bindTo": "FeatureDescription"
					},
					"classes": {
						"labelClass": ["feature-item-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "CreateFeatureButton",
				"parentName": "FeatureActionContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.CreateFeatureCaption"},
					"classes": {"textClass": ["feature-item-button-add"]},
					"click": {"bindTo": "createFeature"}
				}
			},
			{
				"operation": "insert",
				"name": "ApplyChagesButton",
				"parentName": "FeatureActionContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": {"bindTo": "Resources.Strings.FeatureSaveChangeButtonCaption"},
					"classes": {"textClass": ["feature-item-button-save"]},
					"enabled": {"bindTo": "SaveButtonVisible"},
					"click": {"bindTo": "saveFeatureChanges"},
					"tips": []
				}
			},
			{
				"operation": "insert",
				"name": "FeatureItemsContainer",
				"parentName": "FeaturesContentContainer",
				"propertyName": "items",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"classes": {"wrapClassName": ["features-container-list"]},
					"idProperty": "Id",
					"collection": "FeaturesList",
					"dataItemIdPrefix": "feature-item",
					"onGetItemConfig": "getItemViewConfig",
					"isAsync": false
				}
			}
		],
		methods: {
			/**
			 * Initializes Header.
			 * @private
			 */
			initHeader: function() {
				this.initPageCaption();
				this.sandbox.subscribe("NeedHeaderCaption", function() {
					this.sandbox.publish("InitDataViews", {caption: this.get("Resources.Strings.PageHeaderCaption")});
				}, this);
			},

			/**
			 * Initializes page caption.
			 * @protected
			 */
			initPageCaption: function() {
				this.sandbox.publish("ChangeHeaderCaption", {
					"caption": this.get("Resources.Strings.PageHeaderCaption"),
					"dataViews": Ext.create("BPMSoft.Collection")
				});
			},

			/**
			 * Initializes collection events.
			 * @private
			 */
			initCollectionEvents: function() {
				var featuresCollection = this.get("FeaturesList");
				featuresCollection.on("dataLoaded", function(items) {
					items.each(this.subscribeModelEvents, this);
				}, this);
			},

			/**
			 * Subscribes for model events.
			 * @private
			 * @param {BPMSoft.FeatureItemViewModel} model Feature item view model.
			 */
			subscribeModelEvents: function(model) {
				model.on("changeFeatureState", this.onChangeFeatureState, this);
			},

			/**
			 * Handles feature state changes.
			 * @private
			 */
			onChangeFeatureState: function() {
				var features = this.getChangedFeatureState();
				this.set("SaveButtonVisible", !Ext.isEmpty(features));
			},

			/**
			 * Gets features from FeaturesList if IsChanged = true.
			 * @private
			 * @return {Array}
			 */
			getChangedFeatureState: function() {
				var result = [];
				var featuresCollection = this.get("FeaturesList");
				featuresCollection.each(function(item) {
					if (item.get("IsChangedFeature")) {
						var state = item.get("ActualState");
						var code = item.get("Code");
						result.push({
							state: state,
							code: code
						});
					}
				}, this);
				return result;
			},

			/**
			 * Builds Schema.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			buildSchema: function(callback, scope) {
				var schemaBuilder = this.Ext.create(this.get("SchemaBuilderClassName"));
				var generatorConfig = this.BPMSoft.deepClone(this.get("SchemaGeneratorConfig"));
				schemaBuilder.build(generatorConfig, function(viewModelClass, viewConfig) {
					this.set("FeatureItemViewModelClass", viewModelClass);
					this.set("FeatureItemViewConfig", viewConfig);
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Initializes features list.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			initFeaturesList: function(callback, scope) {
				this.callService({
					serviceName: "FeatureService",
					methodName: "GetFeaturesInfo"
				}, function(response) {
					var features = (response && response.GetFeaturesInfoResult) || [];
					this.prepareFeatureModels(features);
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Set's up feature view models.
			 * @private
			 * @param {Array} features List of the features
			 * @param {Array} states List of the states
			 */
			prepareFeatureModels: function(features) {
				var featuresCollection = this.get("FeaturesList");
				featuresCollection.clear();
				var processedFeaturesCollection = Ext.create("BPMSoft.Collection");
				BPMSoft.each(features, function(feature) {
					var viewModel = this.getFeatureItemViewModel(feature);
					processedFeaturesCollection.add(feature.Id, viewModel);
				}, this);
				featuresCollection.loadAll(processedFeaturesCollection);
			},

			/**
			 * Returns feature item view model.
			 * @private
			 * @param {Array} entity Select item.
			 * @return {BPMSoft.FeatureItemViewModel} Feature item view model.
			 */
			getFeatureItemViewModel: function(entity) {
				var viewModelClass = this.get("FeatureItemViewModelClass");
				var viewModel = Ext.create(viewModelClass, {
					BPMSoft: this.BPMSoft,
					Ext: this.Ext,
					sandbox: this.sandbox,
					values: entity
				});
				viewModel.init();
				return viewModel;
			},

			/**
			 * Creates feature button handler.
			 * @private
			 */
			createFeature: function() {
				var featureCode = this.get("FeatureCode");
				var featureName = this.get("FeatureName") || featureCode;
				var featureDescription = this.get("FeatureDescription") || "";
				if (Ext.isEmpty(featureCode)) {
					var validateMsgTemplate = this.get("Resources.Strings.ValidateMsgTemplate");
					var codeCaption = this.get("Resources.Strings.FeatureCodeCaption");
					this.showInformationDialog(Ext.String.format(validateMsgTemplate, codeCaption));
					return;
				}
				this.callService({
					serviceName: "FeatureService",
					methodName: "CreateFeature",
					data: {
						code: featureCode,
						name: featureName,
						description: featureDescription
					}
				}, function(response) {
					if (!response.result.success) {
						BPMSoft.showErrorMessage(response.result.errorInfo.message);
						return;
					}
					this.showInformationDialog(this.get("Resources.Strings.CreateFeatureMessage"), function() {
						this.reloadPage();
					}, {buttons: [BPMSoft.MessageBoxButtons.OK.returnCode]}, this);
				}, this);
			},

			/**
			 * Saves all change state
			 * @private
			 */
			saveFeatureChanges: function() {
				var data = {
					"features": this.getChangedFeatureState()
				};
				this.callService({
					serviceName: "FeatureService",
					methodName: "SetFeaturesState",
					data: data
				}, function(response) {
					if (!response.result.success) {
						BPMSoft.showErrorMessage(response.result.errorInfo.message);
						return;
					}
					this.showInformationDialog(this.get("Resources.Strings.FeatureChangedMessage"), function() {
						this.reloadPage();
					}, {buttons: [BPMSoft.MessageBoxButtons.OK.returnCode]}, this);
				}, this);
			},

			/**
			 * Reloads page.
			 * @private
			 */
			reloadPage: function() {
				this.set("SaveButtonVisible", false);
				this.initFeaturesList();
			},

			/**
			 * Generates view config for feature item.
			 * @private
			 * @param {Object} itemConfig View config of item.
			 */
			getItemViewConfig: function(itemConfig) {
				var viewConfig = this.get("FeatureItemViewConfig");
				itemConfig.config = viewConfig[0];
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						this.initHeader();
						this.initCollectionEvents();
						BPMSoft.chain(
								this.buildSchema,
								this.initFeaturesList,
								function() {
									Ext.callback(callback, scope || this);
								}, this);
					}, this
				]);
			}
		}
	};
});
