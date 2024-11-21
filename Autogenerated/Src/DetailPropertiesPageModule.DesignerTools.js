define("DetailPropertiesPageModule", [
		"DetailPropertiesPageModuleResources",
		"BaseEntity",
		"BaseWizardStepSchemaMixin",
		"BasePropertiesPageModule",
		"DetailDesignerUtils"
	],
	function(resources, baseEntity) {
		Ext.define("BPMSoft.DetailPropertiesPageModule", {
			extend: "BPMSoft.BasePropertiesPageModule",

			messages: {
				/**
				 * @message GetDetailConfig
				 */
				"GetDetailConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SaveDetailConfig
				 */
				"SaveDetailConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetNewLookupPackageUId
				 */
				"GetNewLookupPackageUId": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message OpenDetailDesigner
				 */
				"OpenDetailDesigner": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message ReInitializeDetail
				 */
				"ReInitializeDetail": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},

			/**
			 * @private
			 */
			_masterEntitySchema: null,

			/**
			 * @private
			 */
			_packageUId: null,

			/**
			 * @private
			 */
			_caption: null,


			/**
			 * @private
			 */
			_getValidationConfig: function(config) {
				return {
					schemaNamePrefix: BPMSoft.ClientUnitSchemaManager.schemaNamePrefix,
					maxColumnNameLength: BPMSoft.EntitySchemaManager.getMaxEntitySchemaNameWithPrefix(),
					maxColumnCaptionLength: BPMSoft.DesignTimeEnums.EntitySchemaColumnSizes.MAX_CAPTION_SIZE,
					schemaColumnsNames: config.detailNames
				};
			},


			/**
			 * @private
			 */
			_getBaseColumnConfig: function({validationConfig, rootEntitySchemaItem, config}) {
				const lookupSettings = rootEntitySchemaItem instanceof BPMSoft.EntitySchemaManagerItem
					? {
						connectByLookup: {
							value: rootEntitySchemaItem.uId,
							name: rootEntitySchemaItem.name,
						},
						lookupColumnTitle: this.toLocalizableStringModel(config.masterEntitySchema.caption),
						lookupColumnCode: BPMSoft.EntitySchemaManager.generateNameWithPrefix(
							config.masterEntitySchema.name)
					}: {};
				return {
					itemType: this.getPageItemType(),
					validationConfig,
					baseEntity,
					packageUId: config.packageUId,
					canEdit: BPMSoft.Features.getIsDisabled("DisableDetailPropertiesPageLookupCreation"),
					showEditableDetailOption: BPMSoft.Features.getIsDisabled("DisableEditableDetailOption"),
					...lookupSettings
				};
			},

			/**
			 * @private
			 */
			_getColumnConfig: function() {
				const config = this.sandbox.publish("GetDetailConfig", null, [this.sandbox.id]);
				const masterEntitySchema = config.masterEntitySchema;
				const rootEntitySchemaItem = BPMSoft.EntitySchemaManager.findRootSchemaItemByName(masterEntitySchema.name);
				this._masterEntitySchema = masterEntitySchema;
				this._packageUId = config.packageUId;
				const customEvent = this.mixins.customEvent;
				const validationConfig = this._getValidationConfig(config);
				const baseColumnsConfig = this._getBaseColumnConfig({
					validationConfig,
					rootEntitySchemaItem: rootEntitySchemaItem || masterEntitySchema,
					config
				});
				if (!Ext.isEmpty(config.detailConfig)) {
					this._getDetailAttributes(config, (detailAttributes) => {
						this._caption = detailAttributes.caption;
						customEvent.publish("GetColumnConfig", {
							...baseColumnsConfig,
							detailConfig: detailAttributes.detail,
							caption: this.toLocalizableStringModel(detailAttributes.caption),
							name: detailAttributes.name,
							disableNameEditing: !config.canEdit,
							masterColumnConfig: detailAttributes.masterColumnConfig,
							detailColumnConfig: detailAttributes.detailColumnConfig
						}, this);
					});
				} else {
					customEvent.publish("GetColumnConfig", baseColumnsConfig, this);
				}
			},

			/**
			 * @private
			 */
			_getDetailAttributes: function(config, callback, scope) {
				const detailConfig = config.detailConfig;
				const detail = this._getDetail(detailConfig.detailSchemaName, detailConfig.detailEntitySchemaName);
				let entitySchema;
				const result = {
					detail: Object.assign(detail, {canEdit: config.canEdit}),
					name: detailConfig.detailKey
				};
				BPMSoft.chain(
					function(next) {
						this._getDetailEntitySchema({
							schemaUId: detail.value.entitySchemaUId,
							packageUId: config.packageUId
						}, next, this);
					},
					function(next, schema) {
						entitySchema = schema;
						this._getDetailCaption({
							localizableDetailCaption: detailConfig.localizableDetailCaption,
							packageUId: config.packageUId,
							detailSchemaUId: detail.value.detailSchemaUId
						}, next, this);
					},
					function(next, caption) {
						const detailColumnConfig = this._getDetailEntitySchemaColumn(entitySchema, detailConfig.detailEntitySchemaColumn) || {};
						detailColumnConfig.canEdit = config.canEdit;
						const masterColumnConfig = this._getMasterEntitySchemaColumn(config.masterEntitySchema,
							detailConfig.masterEntitySchemaColumn) || {};
						masterColumnConfig.canEdit = config.canEdit;
						Object.assign(result, {
							caption,
							masterColumnConfig,
							detailColumnConfig
						});
						callback.call(scope, result);
					},
					this
				);
			},

			/**
			 * @private
			 */
			_getMasterEntitySchemaColumn: function(masterEntitySchema, masterEntitySchemaColumnName) {
				const masterEntitySchemaColumn = masterEntitySchema.columns.firstOrDefault(function(column) {
					return column.name === masterEntitySchemaColumnName;
				}, this);
				let config;
				if (masterEntitySchemaColumn) {
					config= this._convertEntitySchemaColumnToLookupEntity(masterEntitySchemaColumn);
				}
				return config;
			},

			/**
			 * @private
			 */
			_getDetailCaption: function(config, callback, scope) {
				if (config.localizableDetailCaption) {
					callback.call(scope, config.localizableDetailCaption.clone());
				} else {
					const findConfig = {schemaUId: config.detailSchemaUId, packageUId: config.packageUId};
					BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(findConfig, function(instance) {
						const localizableDetailCaption = instance.localizableStrings.get("Caption");
						callback.call(scope, localizableDetailCaption.clone());
					}, this);
				}
			},

			/**
			 * @private
			 */
			_getCaption: function(uId) {
				this._getDetailCaption({detailSchemaUId: uId, packageUId: this._packageUId}, (caption) => {
					const customEvent = this.mixins.customEvent;
					customEvent.publish("GetCaption", this.toLocalizableStringModel(caption));
				}, this);
			},

			/**
			 * @private
			 */
			_getDetail: function(detailSchemaName, detailEntitySchemaName) {
				const items = BPMSoft.DetailManager.getItems();
				const detailManagerItem = items.firstOrDefault(function(item) {
					return item.getDetailSchemaName() === detailSchemaName &&
						(!detailEntitySchemaName || item.getEntitySchemaName() === detailEntitySchemaName);
				}, this);
				return this._convertDetailManagerItemToLookupEntity(detailManagerItem);
			},

			/**
			 * @private
			 */
			_getDetailEntitySchema: function(config, callback, scope) {
				BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, (entitySchema) => {
					callback.call(scope, entitySchema);
				});
			},

			/**
			 * @private
			 */
			_getDetailEntitySchemaColumn: function(entitySchema, columnName) {
				const detailEntitySchemaColumn = entitySchema.columns.firstOrDefault(function(column) {
					return column.name === columnName;
				}, this);
				let config;
				if (detailEntitySchemaColumn) {
					config = this._convertEntitySchemaColumnToLookupEntity(detailEntitySchemaColumn);
				}
				return config;
			},

			/**
			 * @private
			 */
			_convertEntitySchemaColumnToLookupEntity: function(entitySchemaColumn) {
				return {
					name: entitySchemaColumn.caption.toString(),
					value: {
						name: entitySchemaColumn.name,
						dataValueType: entitySchemaColumn.dataValueType,
						referenceSchemaUId: entitySchemaColumn.referenceSchemaUId
					}
				};
			},

			/**
			 * @private
			 */
			_convertDetailManagerItemToLookupEntity: function(detailManagerItem) {
				return {
					name: detailManagerItem.getCaption().toString(),
					value: {
						id: detailManagerItem.getId(),
						detailSchemaName: detailManagerItem.getDetailSchemaName(),
						detailSchemaUId: detailManagerItem.getDetailSchemaUId(),
						entitySchemaName: detailManagerItem.getEntitySchemaName(),
						entitySchemaUId: detailManagerItem.getEntitySchemaUId()
					}
				};
			},

			/**
			 * @private
			 */
			_getDetailList: function() {
				const detailCollection = BPMSoft.DetailManager.getItems();
				const columns = detailCollection
					.filterByFn(function(detailManagerItem) {
						return detailManagerItem.getDetailSchemaName() && detailManagerItem.getEntitySchemaName();
					}, this)
					.select(function(detailManagerItem) {
						return this._convertDetailManagerItemToLookupEntity(detailManagerItem);
					}, this);
				columns.sortByFn(this._lookupSortFn);
				const customEvent = this.mixins.customEvent;
				customEvent.publish("GetDetailList", columns.getItems());
			},

			/**
			 * @private
			 */
			_getEntitySchemaList: function() {
				const schemaItems = BPMSoft.EntitySchemaManager.getItems();
				const customEvent = this.mixins.customEvent;
				const resultConfig = schemaItems.mapArray((schemaItem) => {
					if (schemaItem.getExtendParent()) {
						return;
					}
					return {
						value: schemaItem.getUId(),
						name: schemaItem.getCaption()
					};
				}, this);
				customEvent.publish("GetEntitySchemaList", resultConfig.filter(Boolean));
			},

			/**
			 * @private
			 */
			_filterDataSourceColumn: function ({ dataValueType }) {
				return dataValueType === BPMSoft.DataValueType.GUID || dataValueType === BPMSoft.DataValueType.LOOKUP;
			},

			/**
			 * @private
			 */
			_filterMaterColumn: function (column, detailValue) {
				if (!detailValue || detailValue.dataValueType === BPMSoft.DataValueType.GUID || column.dataValueType === BPMSoft.DataValueType.GUID) {
					return true;
				} else {
					return detailValue.referenceSchemaUId && detailValue.referenceSchemaUId === column.referenceSchemaUId;
				}
			},

			/**
			 * @private
			 */
			_getMasterColumnList: function(detailColumnOption) {
				const columns = this._masterEntitySchema.columns
					.filterByFn((column) => this._filterDataSourceColumn(column) && this._filterMaterColumn(column, detailColumnOption?.value))
					.select(function(column) {
					return this._convertEntitySchemaColumnToLookupEntity(column);
				}, this);
				columns.sortByFn(this._lookupSortFn);
				const customEvent = this.mixins.customEvent;
				customEvent.publish("GetMasterColumnList", columns.getItems());
			},

			/**
			 * @private
			 */
			_getDetailColumnList: function(uId) {
				this._getDetailEntitySchema({
					schemaUId: uId,
					packageUId: this._packageUId
				}, (entitySchema) => {
					const columns = entitySchema.columns
						.filterByFn((column) => this._filterDataSourceColumn(column))
						.select(function(column) {
						return this._convertEntitySchemaColumnToLookupEntity(column);
					}, this);
					columns.sortByFn(this._lookupSortFn);
					const customEvent = this.mixins.customEvent;
					customEvent.publish("GetDetailColumnList", columns.getItems());
				}, this);
			},

			/**
			 * @private
			 */
			_lookupSortFn: function(item1, item2) {
				return item1.name.localeCompare(item2.name);
			},

			/**
			 * @private
			 */
			_getDetailConfig: function(data) {
				const caption = new BPMSoft.LocalizableString({
					cultureValues: this.getCultureValues(data.caption)
				});
				const {detail, detailColumn, masterColumn} = data;
				return {
					detailSchemaName: detail.detailSchemaName,
					detailEntitySchemaName: detail.entitySchemaName,
					detailEntitySchemaColumn: detailColumn.value.name,
					masterEntitySchemaColumn: masterColumn.value.name,
					localizableDetailCaption: caption,
					isDetailCaptionChanged: !this._isEqualLocalizableStrings(this._caption, caption),
					detailKey: data.name
				};
			},

			/**
			 * @private
			 */
			_isEqualLocalizableStrings: function(string1, string2) {
				if (!string1 || !string2) {
					return false;
				}
				const object1 = {};
				const object2 = {};
				string1.getSerializableObject(object1);
				string2.getSerializableObject(object2);
				return BPMSoft.isEqual(object1, object2);
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#getPageItemType
			 * @override
			 */
			getPageItemType: function() {
				return "detail";
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#save
			 * @override
			 */
			save: function(data, isSilent = false) {
				this.callParent(arguments);
				data.detail = data.detail.value;
				this.sandbox.publish("SaveDetailConfig", this._getDetailConfig(data), [this.sandbox.id]);
				if (!isSilent) {
					this.close();
				}
			},

			/**
			 * @private
			 */
			_addNewSysDetail: function({detailTitle, detailSchema, entitySchema}, callback, scope) {
				const captionLcz = new BPMSoft.LocalizableString({
					cultureValues: this.getCultureValues(detailTitle)
				});
				BPMSoft.DetailManager.createItem({
					propertyValues: {
						id: BPMSoft.generateGUID(),
						detailSchemaUId: detailSchema.uId,
						entitySchemaUId: entitySchema.uId,
						caption:  captionLcz.toString(),
						detailSchemaName: detailSchema.getName(),
						entitySchemaName: entitySchema.getName()
					},
					propertyLczValues: {
						caption: captionLcz
					}
				}, (item) => {
					const managerItem = BPMSoft.DetailManager.addItem(item);
					Ext.callback(callback, scope, [managerItem]);
				}, this);
			},

			/**
			 * @private
			 */
			_createNewLookupColumn: function({connectByLookup, lookupColumnTitle, lookupColumnCode}, entitySchema) {
				BPMSoft.ApplicationStructureWizardUtils.createNewLookupColumn({
					sectionEntityUId: connectByLookup.value,
					caption: new BPMSoft.LocalizableString({
						cultureValues: this.getCultureValues(lookupColumnTitle)
					}),
					name: lookupColumnCode,
				}, entitySchema);
			},

			/**
			 * @private
			 */
			_registerSysModuleEntity: function({entitySchemaUId}, callback, scope) {
				BPMSoft.SysModuleEntityManager.createItem(null, function(item) {
					item.setEntitySchemaUId(entitySchemaUId);
					BPMSoft.SysModuleEntityManager.addItem(item);
					callback.call(scope, item);
				}, this);
			},

			/**
			 * @private
			 */
			_registerSysModuleEdit: function({sysModuleEntityId, pageSchema}, callback, scope) {
				const pageCaptionLcz = pageSchema.caption;
				BPMSoft.SysModuleEditManager.createItem({
					propertyLczValues: {
						pageCaption: pageCaptionLcz
					}
				}, (item) => {
					item.setSysModuleEntityId(sysModuleEntityId);
					item.setCardSchemaUId(pageSchema.getPropertyValue("uId"));
					item.setPageCaption(pageCaptionLcz.toString());
					BPMSoft.SysModuleEditManager.addItem(item);
					callback.call(scope, item);
				}, this);
			},

			/**
			 * @private
			 */
			_createClientUnitSchema(config, callback, scope) {
				const {schemaType, parentSchemaUId, nameTemplate, packageUId, entitySchema, bodyTemplate} = config;
				const name = BPMSoft.ClientUnitSchemaManager.generateUniqueSchemaName(nameTemplate);
				BPMSoft.ApplicationStructureWizardUtils.createClientUnitSchema({
					name,
					caption: entitySchema.caption,
					schemaType,
					parentSchemaUId,
					packageUId,
					entitySchema,
					bodyTemplate
				}, callback, scope);
			},

			/**
			 * @private
			 */
			_createDetailWithExistingObject: function(data, callback, scope) {
				const packageUId = data.packageUId;
				let entitySchema, sysModuleEntityId, detailSchema, detailManagerItem;
				const schemaType = BPMSoft.DetailDesignerUtils.getDetailSchemaType(data.isEditable);
				BPMSoft.chain(
					(next) => {
						BPMSoft.EntitySchemaManager.findBundleSchemaInstance({
							schemaUId: data.entitySchema.value,
							packageUId: data.packageUId
						}, next, this);
					},
					(next, entitySchemaArg) => {
						entitySchema = entitySchemaArg;
						this._createClientUnitSchema({
							schemaType: BPMSoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,
							parentSchemaUId: BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_GRID_DETAIL,
							nameTemplate: "Schema{0}Detail",
							packageUId,
							entitySchema,
							bodyTemplate: BPMSoft.ClientUnitSchemaBodyTemplate[schemaType]
						}, next, this);
					},
					(next, detailSchemaArg) => {
						detailSchema = detailSchemaArg;
						this._addNewSysDetail({...data, detailSchema, entitySchema}, next, this);
					},
					(next, detailManagerItemArg) => {
						detailManagerItem = detailManagerItemArg;
						detailManagerItem.getSysModuleEntityManagerItem(next, this);
					},
					(next, sysModuleEntityManagerItem) => {
						if (sysModuleEntityManagerItem) {
							next(sysModuleEntityManagerItem);
						} else {
							const entitySchemaUId = entitySchema.uId;
							this._registerSysModuleEntity({entitySchemaUId}, next, this);
						}
					},
					(next, sysModuleEntityManagerItem) => {
						sysModuleEntityId = sysModuleEntityManagerItem.getId();
						sysModuleEntityManagerItem.getSysModuleEditManagerItems(next, this);
					},
					(next, sysModuleEditManagerItems) => {
						if (sysModuleEditManagerItems.getCount() > 0) {
							next.apply(this);
						} else {
							this._createClientUnitSchema({
								schemaType: BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,
								parentSchemaUId: BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE,
								nameTemplate: "Schema{0}Page",
								packageUId,
								entitySchema
							}, next, this);
						}
					},
					(next, pageSchema) => {
						if (pageSchema) {
							this._registerSysModuleEdit({sysModuleEntityId, pageSchema}, next, this);
						} else {
							next.apply(this);
						}
					},
					() => {
						const detailValue = this._convertDetailManagerItemToLookupEntity(detailManagerItem);
						this.mixins.customEvent.publish("SetNewDetailObject", detailValue, this);
						Ext.callback(callback, scope, [detailManagerItem]);
					}, this
				);
			},

			/**
			 * @private
			 */
			_createDetailWithNewObject: function(data, callback, scope) {
				const packageUId = data.packageUId;
				let entitySchema, sysModuleEntityId, detailSchema, pageSchema;
				const schemaType = BPMSoft.DetailDesignerUtils.getDetailSchemaType(data.isEditable);
				BPMSoft.chain(
					(next) => {
						const schemaCaption = new BPMSoft.LocalizableString({ cultureValues: this.getCultureValues(data.objectTitle) });
						const schemaName = data.objectCode;
						BPMSoft.ApplicationStructureWizardUtils.createNewSchemaWithPrimaryDisplayColumn({
							schemaName,
							schemaCaption,
							packageUId
						}, next, this);
					},
					(next, entitySchemaArg) => {
						entitySchema = entitySchemaArg;
						const entitySchemaUId = entitySchema.uId;
						this._createNewLookupColumn(data, entitySchema);
						this._registerSysModuleEntity({entitySchemaUId}, next, this);
					},
					(next, sysModuleEntityArg) => {
						sysModuleEntityId = sysModuleEntityArg.id;
						this._createClientUnitSchema({
							schemaType: BPMSoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,
							parentSchemaUId: BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_GRID_DETAIL,
							nameTemplate: "Schema{0}Detail",
							packageUId,
							entitySchema,
							bodyTemplate: BPMSoft.ClientUnitSchemaBodyTemplate[schemaType]
						}, next, this);
					},
					(next, detailSchemaArg) => {
						detailSchema = detailSchemaArg;
						this._createClientUnitSchema({
							schemaType: BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,
							parentSchemaUId: BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE,
							nameTemplate: "Schema{0}Page",
							packageUId,
							entitySchema
						}, next, this);
					},
					(next, pageSchemaArg) => {
						pageSchema = pageSchemaArg;
						this._registerSysModuleEdit({sysModuleEntityId, pageSchema}, next, this);
					},
					(next) => {
						this._addNewSysDetail({...data, detailSchema, entitySchema}, next, this);
					},
					(next, detailManagerItem) => {
						const detailValue = this._convertDetailManagerItemToLookupEntity(detailManagerItem);
						this.mixins.customEvent.publish("SetNewDetailObject", detailValue, this);
						Ext.callback(callback, scope, [detailManagerItem]);
					}, this
				);
			},

			/**
			 * @private
			 */
			_setNewDetailObject: function(data, callback, scope) {
				if (data.entitySchema) {
					this._createDetailWithExistingObject(data, callback, scope);
				} else {
					this._createDetailWithNewObject(data, callback, scope);
				}
			},

			/**
			 * @private
			 */
			_editDetail: function(data) {
				const detailId = data.detail.value.id;
				this.save(data, true);
				this.sandbox.publish("OpenDetailDesigner", detailId, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#initCustomEvents
			 * @override
			 */
			initCustomEvents: function() {
				this.callParent(arguments);
				const customEvent = this.mixins.customEvent;
				const packageUId = this.packageUId;
				customEvent.subscribe("GetColumnConfig").subscribe(this._getColumnConfig.bind(this));
				customEvent.subscribe("GetDetailList").subscribe(this._getDetailList.bind(this));
				customEvent.subscribe("GetMasterColumnList").subscribe(this._getMasterColumnList.bind(this));
				customEvent.subscribe("GetDetailColumnList").subscribe(this._getDetailColumnList.bind(this));
				customEvent.subscribe("GetCaption").subscribe(this._getCaption.bind(this));
				customEvent.subscribe("GetLookupList").subscribe(this.getLookupList.bind(this, {packageUId}));
				customEvent.subscribe("GetLookupNameList").subscribe(this.getLookupNameList.bind(this, {packageUId}));
				customEvent.subscribe("SetNewDetailObject").subscribe(this._setNewDetailObject.bind(this));
				customEvent.subscribe("EditDetail").subscribe(this._editDetail.bind(this));
				customEvent.subscribe("GetEntitySchemaList").subscribe(this._getEntitySchemaList.bind(this));
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#getPropertiesPageTranslation
			 * @override
			 */
			getPropertiesPageTranslation: function() {
				return {
					...this.callParent(arguments),
					caption: this.resources.localizableStrings.DetailModalBoxHeader,
					detailCaption: this.resources.localizableStrings.DetailNameCaption,
					selectValueCaption: this.resources.localizableStrings.SelectValueCaption,
					masterColumnCaption: this.resources.localizableStrings.MasterSchemaTitle,
					detailColumnCaption: this.resources.localizableStrings.DetailSchemaColumnCaption,
					dataSource: this.resources.localizableStrings.DataSourceCaption,
					duplicateDetailName: this.resources.localizableStrings.DuplicateDetailNameMessage,
					duplicateColumnName: this.resources.localizableStrings.DuplicateColumnNameMessage,
					wrongPrefixName: this.resources.localizableStrings.WrongPrefixMessage,
					detailFormPropertiesPageCaption: this.resources.localizableStrings.DetailFormPropertiesPageCaption,
					detailObjectSettingsGroupLabel: this.resources.localizableStrings.DetailObjectSettingsGroupLabel,
					howToConnectDetailToCurrentPageGroupLabel: this.resources.localizableStrings.HowToConnectDetailToCurrentPageGroupLabel,
					objectTitleLabel: this.resources.localizableStrings.ObjectTitleLabel,
					detailTitleLabel: this.resources.localizableStrings.DetailTitleLabel,
					objectCodeLabel: this.resources.localizableStrings.ObjectCodeLabel,
					connectByLookupLabel: this.resources.localizableStrings.ConnectByLookupLabel,
					lookupColumnTitleLabel: this.resources.localizableStrings.LookupColumnTitleLabel,
					lookupColumnCodeLabel: this.resources.localizableStrings.LookupColumnCodeLabel,
					entitySchemaLabel: this.resources.localizableStrings.EntitySchemaLabel,
					createDetailUsingExistingObject: this.resources.localizableStrings.CreateDetailUsingExistingObject,
					createDetailUsingNewObject: this.resources.localizableStrings.CreateDetailUsingNewObject,
					editDetailTooltipCaption: this.resources.localizableStrings.EditDetailTooltipCaption,
					createDetailTooltipCaption: this.resources.localizableStrings.CreateDetailTooltipCaption,
					isEditableLabel: BPMSoft.DetailDesignerUtils.getEnableGridCaption()
				};
			},

			/**
			 * @override
			 */
			init: function() {
				this.initResources(resources);
				this.callParent(arguments);
				this.sandbox.subscribe("ReInitializeDetail", () => {
					this.mixins.customEvent.publish("ReInitializeDetail", null, this);
				}, this, [this.sandbox.id]);
			},

			/**
			 * @override
			 */
			getCurrentPackageUId: function() {
				return this.packageUId;
			}

		});
		return BPMSoft.DetailPropertiesPageModule;
	});
