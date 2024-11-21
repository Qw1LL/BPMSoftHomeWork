/**
 * Parent: BaseModalBoxPage
 */
define("DataSourcePropertiesPage", [
	"ProcessSchemaUserTaskUtilities",
	"NewColumnGridLayoutEditItemModel",
	"css!DataSourcePropertiesPageCss",
	"css!BaseModalBoxPageCss"
], function() {
	return {
		messages: {
			SaveDataModel: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			PageSchema: {
				type: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			DataSourceCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				isRequired: true
			},
			DataSourceSchema: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				isRequired: true
			},
			PageSchemaParameter: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				isRequired: true
			},
			DataSourceSchemaList: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			DataModelCollection: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			PrimaryColumnBindTo: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			PackageUId: {
				dataValueType: BPMSoft.DataValueType.LOOKUP
			},
			IsAddMode: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			NewParameter: {
				dataValueType: BPMSoft.DataValueType.LOOKUP
			}
		},
		properties: {
			modelBoxClass: "data-source-properties-page-modal-box"
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getNamePrefix: function(name) {
				const schemaNamePrefix = BPMSoft.ClientUnitSchemaManager.schemaNamePrefix;
				const normalizedName = Ext.String.capitalize(name.toLowerCase());
				return schemaNamePrefix ? (schemaNamePrefix + normalizedName) : normalizedName;
			},

			/**
			 * @private
			 */
			_generateParameterName: function() {
				const name = this.$DataSourceSchema.name;
				const list = this.$PageSchema.columns.mapArray(function(parameter) {
					return parameter.name.toLowerCase();
				}, this);
				var prefix = this._getNamePrefix(name);
				return BPMSoft.getUniqueValue(list, prefix);
			},

			/**
			 * @private
			 */
			_generateParameterCaption: function() {
				let caption = this.$DataSourceSchema.displayValue;
				const captions = this.$PageSchema.columns.mapArray(function(parameter) {
					return parameter.caption.toString().toLowerCase();
				}, this);
				if (BPMSoft.contains(captions, caption.toLowerCase())) {
					caption = BPMSoft.getUniqueValue(captions, caption + " ");
				}
				caption += this.get("Resources.Strings.NewParameterSuffix");
				return caption;
			},

			/**
			 * @private
			 */
			_subscribeOnChange: function() {
				this.on("change:DataSourceSchema", this._onDataSourceSchemaChanged, this);
			},

			/**
			 * @private
			 */
			_onDataSourceSchemaChanged: function(model, value) {
				const dataModels = this.$Designer.$DataModels;
				let caption = value && value.displayValue;
				var captions = dataModels.mapArray(function(model) {
					return model.$Caption.toLowerCase();
				});
				if (caption && BPMSoft.contains(captions, caption.toLowerCase())) {
					caption = BPMSoft.getUniqueValue(captions, caption + " ");
				}
				this.$DataSourceCaption = caption;
				let parameter = null;
				if (value) {
					parameter = {
						value: BPMSoft.generateGUID(),
						name: this._generateParameterName(),
						displayValue: this._generateParameterCaption()
					};
				}
				this.$PageSchemaParameter = parameter;
				this.$NewPageSchemaParameter = parameter;
			},

			/**
			 * @private
			 */
			_createPageParameter: function() {
				let displayValue = this.$PageSchemaParameter.displayValue;
				displayValue = displayValue.replace(this.get("Resources.Strings.NewParameterSuffix"), "");
				const parameter = new BPMSoft.ClientUnitSchemaParameter({
					uId: this.$PageSchemaParameter.value,
					caption: new BPMSoft.LocalizableString(displayValue),
					name: this.$PageSchemaParameter.name,
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					status: BPMSoft.ModificationStatus.NEW,
					referenceSchemaUId: this.$DataSourceSchema.value
				});
				this.$PageSchema.parameters.add(parameter.uId, parameter);
				return parameter;
			},

			/**
			 * @private
			 */
			_addPageParameterToExistingDraggableItems: function(parameter) {
				var collection = Ext.create("BPMSoft.Collection");
				collection.add(parameter.uId, parameter);
				var parametersDataModel = this.$DataModels.get("Parameters");
				var existingModelDraggableItems = parametersDataModel.get("ExistingModelDraggableItems");
				this.$Designer.loadColumnsCollection(existingModelDraggableItems, collection,
					"BPMSoft.ExistingColumnGridLayoutEditItemModel", parametersDataModel);
			},

			/**
			 * @private
			 */
			_saveBindToPageParameter: function() {
				if (!this.$PageSchema.parameters.contains(this.$PageSchemaParameter.value)) {
					const parameter = this._createPageParameter();
					this._addPageParameterToExistingDraggableItems(parameter);
				}
			},

			/**
			 * @private
			 */
			_getReferenceSchemaList: function() {
				var list = new BPMSoft.Collection();
				BPMSoft.EntitySchemaManager
					.filterByFn(function(item) {
						return !item.getExtendParent();
					})
					.each(function(item) {
						var uid = item.getUId();
						var listItem = {
							value: uid,
							name: item.getName(),
							displayValue: item.getCaption()
						};
						list.add(uid, listItem);
					});
				return list.sort("displayValue");
			},

			/**
			 * @private
			 */
			_getPageSchemaParameterList: function() {
				const list = new BPMSoft.Collection();
				const parameter = this.$NewPageSchemaParameter;
				this.$PageSchema.parameters.each(function(parameter) {
					if (BPMSoft.ProcessModuleUtilities.isSystemParameter(parameter.name)) {
						return;
					}
					if (parameter.dataValueType !== BPMSoft.DataValueType.LOOKUP) {
						return;
					}
					if (this.$DataSourceSchema && this.$DataSourceSchema.value !== parameter.referenceSchemaUId) {
						return;
					}
					list.add(parameter.uId, {
						value: parameter.uId,
						name: parameter.name,
						displayValue: parameter.caption.toString()
					});
				}, this);
				if (parameter) {
					list.addIfNotExists(parameter.value, parameter);
				}
				list.sort("displayValue");
				return list;
			},

			/**
			 * @private
			 */
			_initExistingDataSource: function() {
				const dataSource = this.$DataModels.get(this.$DataModelName);
				const dataModelsConfig = this.$Designer.$Schema.dataModels || {};
				const dataModelConfig = dataModelsConfig[this.$DataModelName];
				const bindTo = dataModelConfig.primaryColumnValue.bindTo;
				const parameter = this.$PageSchema.parameters.findByPath("name", bindTo);
				const dataSourceSchema = dataSource.get("Schema");
				this.set("DataSourceSchema", {
					name: dataSourceSchema.name,
					value: dataSource.get("EntitySchemaUId"),
					displayValue: dataSourceSchema.caption.toString()
				});
				this.set("DataSourceCaption", dataSource.get("Caption"));
				this.set("PageSchemaParameter", {
					name: parameter.name,
					value: parameter.uId,
					displayValue: (parameter.caption || parameter.name).toString()
				});
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.hideBodyMask();
					this.$DataModelName = this.$moduleInfo.DataModelName;
					this.$IsAddMode = Ext.isEmpty(this.$DataModelName);
					this.$Designer = this.$moduleInfo.Designer;
					this.$PageSchema = this.$Designer.$PageSchema;
					this.$PackageUId = this.$Designer.getPackageUId();
					this.$DataModels = this.$Designer.$DataModels;
					if (!this.$IsAddMode) {
						this._initExistingDataSource();
					}
					this._subscribeOnChange();
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseModalBoxPage#getModalBoxInitialConfig
			 * @override
			 */
			getModalBoxInitialConfig: function() {
				return {
					modalBoxConfig: {
						boxClasses: [this.modelBoxClass]
					}
				};
			},

			/**
			 * Returns modal box header.
			 * @return {String}
			 */
			getHeader: function() {
				return this.get("Resources.Strings.PageTitle");
			},

			/**
			 * @private
			 */
			_save: function(callback, scope) {
				var maskId = BPMSoft.Mask.show({selector: "." + this.modelBoxClass});
				BPMSoft.require([this.$DataSourceSchema.name], function(schema) {
					BPMSoft.EntitySchemaManager.forceGetPackageSchema({
						schemaUId: this.$DataSourceSchema.value,
						packageUId: this.$Designer.getPackageUId()
					}, function(designSchema) {
						this._saveBindToPageParameter();
						const dataModelsNames = this.$DataModels.mapArrayByAttr("Name");
						const uniqueName = BPMSoft.getUniqueValue(dataModelsNames, designSchema.name);
						this.sandbox.publish("SaveDataModel", {
							name: this.$IsAddMode ? uniqueName : this.$DataModelName,
							entitySchemaName: designSchema.name,
							designSchema: designSchema,
							schema: schema,
							bindTo: this.$PageSchemaParameter.name,
							caption: this.$DataSourceCaption
						}, [this.sandbox.id]);
						BPMSoft.Mask.hide(maskId);
						Ext.callback(callback, scope);
					}, this);
				}, this);
			},

			/**
			 * Closes properties page.
			 * @protected
			 */
			close: function() {
				this.destroyModule();
			},

			/**
			 * Handler for SaveButton click.
			 */
			onSaveButtonClick: function() {
				if (this.validate()) {
					this._save(function() {
						this.close();
					}, this);
				}
			},

			/**
			 * @protected
			 */
			prepareDataSourceSchemaList: function(filter, list) {
				if (list) {
					list.clear();
					list.loadAll(this._getReferenceSchemaList());
				}
			},

			/**
			 * @protected
			 */
			preparePageSchemaParameterList: function(filter, list) {
				if (list) {
					list.clear();
					list.loadAll(this._getPageSchemaParameterList());
				}
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"wrapClass": ["datasource-properties-page"]
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"name": "CardContentLayout",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [
						{
							"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
							"name": "DataSourceSchema",
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"labelConfig": {"caption": {"bindTo": "Resources.Strings.DataSourceSchema"}},
							"controlConfig": {
								"prepareList": {"bindTo": "prepareDataSourceSchemaList"},
								"focused": true,
								"placeholder": {"bindTo": "Resources.Strings.PlaceholderChooseObject"},
								"classes": ["placeholderOpacity"],
							},
							"enabled": {"bindTo": "IsAddMode"},
						},
						{
							"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
							"name": "DataSourceCaption",
							"layout": {"column": 0, "row": 1, "colSpan": 24},
							"labelConfig": {"caption": {"bindTo": "Resources.Strings.DataSourceCaption"}},
							"controlConfig": {
								"placeholder": {"bindTo": "Resources.Strings.PlaceholderChooseName"},
								"classes": ["placeholderOpacity"],
							},
						},
						{
							"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
							"name": "PageSchemaParameter",
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {"column": 0, "row": 2, "colSpan": 24},
							"labelConfig": {"caption": {"bindTo": "Resources.Strings.PrimaryColumnBindTo"}},
							"controlConfig": {
								"prepareList": {"bindTo": "preparePageSchemaParameterList"},
								"placeholder": {"bindTo": "Resources.Strings.PlaceholderChooseName"},
								"classes": ["placeholderOpacity"],
							}
						}
					]
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"name": "BottomButtonsWrapper",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["bottom-buttons-wrapper"],
					"items": [
						{
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"name": "SaveDataSource",
							"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
							"click": {"bindTo": "onSaveButtonClick"},
							"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
							"classes": {"textClass": "right-button"}
						},
						{
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"name": "CancelDataSource",
							"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
							"click": {"bindTo": "close"},
							"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
							"classes": {"textClass": "right-button"}
						}
					]
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
