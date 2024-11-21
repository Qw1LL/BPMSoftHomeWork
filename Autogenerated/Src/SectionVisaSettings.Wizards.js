define("SectionVisaSettings", [
	"ext-base", "BPMSoft", "PackageSchemaBuilder", "ViewModelSchemaDesignerUtils",
	"SectionVisaSettingsResources", "ApplicationStructureWizardUtils", "ViewModelSchemaDesignerViewModelGenerator",
	"SectionSettingsMixin"
], function(Ext, BPMSoft, SchemaBuilder) {
	return {
		mixins: {
			"SectionSettingsMixin": "BPMSoft.SectionSettingsMixin"
		},
		messages: {
			"SaveSectionVisaSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {

			/**
			 * Indicates state of approval.
			 */
			"VisaChecked": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Module entity schema.
			 */
			"ModuleEntitySchema": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Package UId.
			 */
			"PackageUId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Module manager item.
			 */
			"SectionManagerItem": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Visa schema UId.
			 */
			"VisaSchemaUId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Visa section entity column UId.
			 */
			"MasterColumnUId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Visa section entity column name.
			 */
			"MasterColumnName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			/**
			 * SysModuleVisa Id.
			 */
			"SysModuleVisaId": {
				dataValueType: BPMSoft.DataValueType.GUID
			}

		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BaseSchemaViewModel#initLookupQuickAddMixin
			 * @override
			 */
			initLookupQuickAddMixin: function(next, scope) {
				Ext.callback(next, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.set("IsInitialized", false);
				this.subscribeSandboxEvents();
				this.callParent([function() {
					BPMSoft.SysModuleVisaManager.initialize(function() {
						this.mixins.SectionSettingsMixin.init.call(this);
						Ext.callback(callback, scope);
					}, this);
				}, this]);
			},

			/**
			 * Subscribe sandbox events
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				this.sandbox.subscribe("SaveSectionVisaSettings", this.onSaveSectionVisaSettings, this);
				this.mixins.SectionSettingsMixin.subscribeSandboxEvents.call(this);
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#getInitializedMessageName
			 * @override
			 */
			getInitializedMessageName: function() {
				return "VisaModuleSettingsInitialized";
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#initModuleSettings
			 * @override
			 */
			initModuleSettings: function(callback, scope) {
				const visaSchemaUId = this._findVisaSchemaUId();
				this.set("VisaSchemaUId", visaSchemaUId);
				this.set("VisaChecked", Boolean(visaSchemaUId));
				Ext.callback(callback, scope);
			},

			/**
			 * Handler for onSaveSectionVisaSettings message.
			 * @protected
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Callback function context.
			 */
			onSaveSectionVisaSettings: function(callback) {
				if (!this.get("VisaChecked")) {
					return Ext.callback(callback);
				}
				this.showBodyMask();
				BPMSoft.chain(
					function(next) {
						if (this.get("VisaSchemaUId")) {
							next();
						} else {
							this._addVisa(next, this);
						}
					},
					function(next) {
						if (this._isExistsVisaPage()) {
							next();
						} else {
							this._addVisaPage(next, this);
						}
					},
					function(next) {
						this.getActiveSysModuleEditManagerItemsChain(next, this);
					},
					function(next, collection) {
						const schemaUIds = collection.getItems().map(function(item) {
							return item.getCardSchemaUId();
						});
						this._updateClientSchemas(schemaUIds, next, this);
					},
					function() {
						this.hideBodyMask();
						Ext.callback(callback);
					}, this
				);
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#canEdit
			 * @override
			 */
			canEdit: function() {
				const isCanEdit = this.mixins.SectionSettingsMixin.canEdit.call(this);
				const visaSchemaUId = this.get("VisaSchemaUId");
				return isCanEdit && !visaSchemaUId;
			},

			//endregion

			//region Methods: Private

			/**
			 * Adds approvals to section.
			 * @private
			 */
			_addVisa: function(callback, scope) {
				BPMSoft.chain(
					this._createVisaEntitySchema,
					this._createSysModuleVisaManagerItem,
					function(next, visaManagerItem) {
						const sysModuleVisaId = visaManagerItem.getId();
						this._updateSectionManagerItem(sysModuleVisaId);
						this._createVisaDetail(next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * Updates current model instance properties, related to visa item.
			 * @private
			 * @param {BPMSoft.EntitySchemaManagerItem} item Visa entity schema item.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			_updateModelProperties: function(item, callback, scope) {
				this.$VisaSchemaUId = item.uId;
				item.getInstance(function(instance) {
					const columns = instance.columns;
					const entitySchema = this.getModuleEntitySchema();
					const entityUId = entitySchema.extendParent ? entitySchema.parentUId : entitySchema.uId;
					const column = columns.findByFn(function(columnItem) {
						return columnItem.referenceSchemaUId === entityUId;
					});
					this.$MasterColumnUId = column.uId;
					this.$MasterColumnName = column.name;
					Ext.callback(callback, scope || this, [item]);
				}, this);
			},

			/**
			 * Creates visa entity schema.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			_createVisaEntitySchema: function(callback, scope) {
				const visaEntityName = this._getVisaEntitySchemaName();
				const item = BPMSoft.EntitySchemaManager.findByFn(function(item) {
					return item.name === visaEntityName;
				});
				if (item) {
					return this._updateModelProperties(item, callback, scope);
				}
				const config = this._getVisaEntitySchemaConfig();
				const utils = BPMSoft.ApplicationStructureWizardUtils;
				const newSchema = utils.createNewSchema(config);
				const lookupColumnConfig = this._getLookupColumnConfig();
				const column = utils.createNewLookupColumn(lookupColumnConfig, newSchema);
				this.set("VisaSchemaUId", newSchema.uId);
				this.set("MasterColumnUId", column.uId);
				this.set("MasterColumnName", column.name);
				newSchema.setParent(BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_VISA, function() {
					const item = BPMSoft.EntitySchemaManager.addSchema(newSchema);
					callback.call(scope, item);
				}, this);
			},

			/**
			 * Creates SysModuleVisa item.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			_createSysModuleVisaManagerItem: function(callback, scope) {
				const visaSchemaUId = this.get("VisaSchemaUId");
				const item = BPMSoft.SysModuleVisaManager.findByFn(function(item) {
					return item.getVisaSchemaUId() === visaSchemaUId;
				}, this);
				if (item) {
					return Ext.callback(callback, scope || this, [item]);
				}
				BPMSoft.SysModuleVisaManager.createItem(null, function(item) {
					item.setVisaSchemaUId(this.get("VisaSchemaUId"));
					item.setMasterColumnUId(this.get("MasterColumnUId"));
					BPMSoft.SysModuleVisaManager.addItem(item);
					callback.call(scope, item);
				}, this);
			},

			/**
			 * Creates visa detail.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			_createVisaDetail: function(callback, scope) {
				const config = this._getVisaDetailItemConfig();
				BPMSoft.DetailManager.createItem(config, function(item) {
					const managerItem = BPMSoft.DetailManager.addItem(item);
					callback.call(scope, managerItem);
				}, this);
			},

			/**
			 * @private
			 */
			_updateClientSchemas: function(schemaUIds, callback, scope) {
				BPMSoft.eachAsync(schemaUIds, function(schemaUId, nextAsync) {
					this._updateClientSchema(schemaUId, nextAsync, this);
				}, function() {
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_updateClientSchema: function(schemaUId, callback, scope) {
				const packageUId = this.get("PackageUId");
				BPMSoft.chain(
					function(next) {
						BPMSoft.ClientUnitSchemaManager.findPackageItem(schemaUId, packageUId, next, this);
					},
					function(next, managerItem) {
						this._isVisaDetailExists(managerItem.name, next, this);
					},
					function(next, isVisaDetailExists) {
						if (isVisaDetailExists) {
							Ext.callback(callback, scope);
						} else {
							next();
						}
					},
					function(next) {
						const schemaConfig = {
							schemaUId: schemaUId,
							packageUId: packageUId
						};
						BPMSoft.ClientUnitSchemaManager.forceGetPackageSchema(schemaConfig, next, this);
					},
					function(next, schema) {
						this._preparePageDesignerClientUnitSchema(schema);
						this._addVisaDetailToPage(schema, next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_addVisaDetailToPage: function(page, callback, scope) {
				const packageUId = this.get("PackageUId");
				BPMSoft.chain(
					function(next) {
						SchemaBuilder.build({
							schemaName: page.name,
							useCache: false,
							packageUId
						}, next, this);
					},
					function(next, viewModelClass, viewConfig, pageSchema) {
						const utils = BPMSoft.ViewModelSchemaDesignerUtils;
						const detailName = utils.getUniqueItemName("VisaDetailV2");
						this._addVisaDetailDefine(detailName, page, pageSchema.details || {});
						this._addVisaDiff(detailName, page, pageSchema.diff || []);
						page.define(next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_isVisaDetailExists: function(schemaName, callback, scope) {
				const config = {
					schemaName: schemaName,
					useCache: false,
					packageUId: this.get("PackageUId")
				};
				SchemaBuilder.build(config, function(viewModelClass) {
					const result = _.some(viewModelClass.prototype.details, function(detail) {
						return detail.schemaName === "VisaDetailV2";
					}, this);
					Ext.callback(callback, scope, [result]);
				}, this);
			},

			/**
			 * Adds visa diff to page.
			 * @private
			 * @param {String} detailName Detail Name.
			 * @param {BPMSoft.manager.ClientUnitSchema} page Page.
			 * @param {Object[]} diffArray Schema diff array.
			 */
			_addVisaDiff: function(detailName, page, diffArray) {
				const utils = BPMSoft.ViewModelSchemaDesignerUtils;
				const tabName = utils.getUniqueItemName("Tab") + "TabLabel";
				const tabVisaDiff = this._getTabVisaDiff(tabName);
				diffArray.push(tabVisaDiff);
				const detailDiff = this._getDetailVisaDiff(detailName, tabName);
				diffArray.push(detailDiff);
				page.setSchemaDiff(diffArray);
			},

			/**
			 * Adds visa detail define.
			 * @private
			 * @param {String} detailName Detail Name.
			 * @param {BPMSoft.manager.ClientUnitSchema} page Page.
			 * @param {Object} details Schema details.
			 */
			_addVisaDetailDefine: function(detailName, page, details) {
				details[detailName] = this._getDefineDetailDiff();
				page.setSchemaDetails(details);
			},

			/**
			 * @private
			 */
			_preparePageDesignerClientUnitSchema: function(schema) {
				if (!BPMSoft.ClientUnitSchemaManager.contains(schema.uId)) {
					const entitySchemaName = this.get("EntitySchemaManagerItem").getName();
					schema.setDefaultSchemaBody(BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA, {
						entitySchemaName: entitySchemaName
					});
					BPMSoft.ClientUnitSchemaManager.addSchema(schema);
				}
			},

			/**
			 * Returns current section visa entity schema name.
			 * @private
			 * @return {String} Current section visa entity schema name.
			 */
			_getVisaEntitySchemaName: function() {
				const visaEntityUId = this._findVisaEntityUIdInRelatedSections();
				if (!Ext.isEmpty(visaEntityUId)) {
					const visaEntity = BPMSoft.EntitySchemaManager.findByFn(function(item) {
						return item.uId === visaEntityUId;
					}, this);
					return visaEntity.name;
				}
				const entitySchema = this.getModuleEntitySchema();
				const entityName = entitySchema.getName();
				return BPMSoft.ApplicationStructureWizardUtils.getEntityFullName(entityName, "Visa");
			},

			/**
			 * Returns visa entity schema config.
			 * @private
			 * @return {Object}
			 */
			_getVisaEntitySchemaConfig: function() {
				const entitySchema = this.getModuleEntitySchema();
				const entityName = this._getVisaEntitySchemaName();
				const entitySchemaCaption = entitySchema.getCaption();
				const captionTemplate = this.get("Resources.Strings.SchemaVisaCaption");
				const schemaCaption = this.Ext.String.format(captionTemplate, entitySchemaCaption);
				const packageUId = this.get("PackageUId");
				return {
					"entityName": entityName,
					"schemaCaption": schemaCaption,
					"packageUId": packageUId,
					"administratedByRecords": true
				};
			},

			/**
			 * Returns visa detail item config.
			 * @private
			 * @return {Object}
			 */
			_getVisaDetailItemConfig: function() {
				const entitySchema = this.getModuleEntitySchema();
				const entitySchemaCaption = entitySchema.getCaption();
				const captionTemplate = this.get("Resources.Strings.SchemaVisaCaption");
				const detailCaption = this.Ext.String.format(captionTemplate, entitySchemaCaption);
				const visaSchemaUId = this.get("VisaSchemaUId");
				const visaSchema = BPMSoft.EntitySchemaManager.getItem(visaSchemaUId);
				const detailSchemaUId = BPMSoft.DesignTimeEnums.BaseSchemaUId.VISA_DETAIL;
				const detailSchema = BPMSoft.ClientUnitSchemaManager.findItem(detailSchemaUId);
				return {
					propertyValues: {
						detailSchemaUId: detailSchemaUId,
						entitySchemaUId: visaSchemaUId,
						caption: detailCaption,
						detailSchemaName: detailSchema.getName(),
						entitySchemaName: visaSchema.getName()
					}
				};
			},

			/**
			 * Returns visa entity schema unique identifier from related sections.
			 * @private
			 * @return {String|null} Visa entity schema unique identifier.
			 */
			_findVisaEntityUIdInRelatedSections: function() {
				const sectionManagerItem = this.get("SectionManagerItem");
				const code = sectionManagerItem && sectionManagerItem.getCode();
				if (Ext.isEmpty(code)) {
					return null;
				}
				const sections = BPMSoft.SectionManager.filterByFn(function(item) {
					return item.getCode() === code;
				}, this);
				const section = sections.findByFn(function(item) {
					return !Ext.isEmpty(item.getSysModuleVisaId());
				});
				const sysModuleVisaId = section && section.getSysModuleVisaId();
				const visaSchemaItem = sysModuleVisaId && BPMSoft.SysModuleVisaManager.findItem(sysModuleVisaId);
				return visaSchemaItem && visaSchemaItem.getVisaSchemaUId();
			},

			/**
			 * Finds visa schema uId.
			 * @private
			 * @return {String|null}
			 */
			_findVisaSchemaUId: function() {
				const sectionManagerItem = this.get("SectionManagerItem");
				const sysModuleVisaId = sectionManagerItem && sectionManagerItem.getSysModuleVisaId();
				const visaSchemaItem = sysModuleVisaId && BPMSoft.SysModuleVisaManager.findItem(sysModuleVisaId);
				return visaSchemaItem && visaSchemaItem.getVisaSchemaUId();
			},

			/**
			 * Updates section manager item
			 * @private
			 * @param {String} sysModuleVisaId SysModuleVisa identifier.
			 */
			_updateSectionManagerItem: function(sysModuleVisaId) {
				const sectionManagerItem = this.get("SectionManagerItem");
				sectionManagerItem.setSysModuleVisaId(sysModuleVisaId);
				sectionManagerItem.setForceUpdateColumns(["SysModuleVisa"]);
			},

			/**
			 * Returns section entity uId.
			 * @private
			 * @return {String}
			 */
			_getSectionEntityUId: function() {
				const entitySchema = this.getModuleEntitySchema();
				return entitySchema.extendParent ? entitySchema.parentUId : entitySchema.uId;
			},

			/**
			 * Returns lookup column config.
			 * @private
			 * @return {Object}
			 */
			_getLookupColumnConfig: function() {
				const entitySchema = this.getModuleEntitySchema();
				return {
					sectionEntityUId: this._getSectionEntityUId(),
					caption: entitySchema.getCaption(),
					name: entitySchema.getName()
				};
			},

			/**
			 * Returns tab visa diff.
			 * @private
			 * @param {String} tabName Tab name.
			 * @return {Object}
			 */
			_getTabVisaDiff: function(tabName) {
				const utils = BPMSoft.ViewModelSchemaDesignerUtils;
				return {
					"operation": "insert",
					"propertyName": "tabs",
					"parentName": "Tabs",
					"name": tabName,
					"values": {
						"caption": {
							"bindTo": utils.getModelStringResourceName("TabVisaCaption")
						},
						"items": []
					}
				};
			},

			/**
			 * Returns tab visa diff.
			 * @private
			 * @param {String} detailName Detail name.
			 * @param {String} tabName Tab name.
			 * @return {Object}
			 */
			_getDetailVisaDiff: function(detailName, tabName) {
				return {
					"operation": "insert",
					"propertyName": "items",
					"parentName": tabName,
					"name": detailName,
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"markerValue": "added-detail"
					}
				};
			},

			/**
			 * Returns define detail diff.
			 * @private
			 * @return {Object}
			 */
			_getDefineDetailDiff: function() {
				const visaSchemaUId = this.get("VisaSchemaUId");
				const item = BPMSoft.EntitySchemaManager.getItem(visaSchemaUId);
				const entitySchemaName = item.getName();
				const detailColumn = this.$MasterColumnName;
				const detailSchemaUId = BPMSoft.DesignTimeEnums.BaseSchemaUId.VISA_DETAIL;
				const detailSchema = BPMSoft.ClientUnitSchemaManager.findItem(detailSchemaUId);
				return {
					"schemaName": detailSchema.getName(),
					"entitySchemaName": entitySchemaName,
					"filter": {
						"masterColumn": "Id",
						"detailColumn": detailColumn
					}
				};
			},

			/**
			 * @private
			 */
			_formatVisaPageSchemaName: function() {
				const entitySchemaManagerItem = this.get("EntitySchemaManagerItem");
				const entityName = entitySchemaManagerItem.getName();
				const pageName = BPMSoft.ApplicationStructureWizardUtils.getEntityFullName(entityName, "VisaPageV2");
				return pageName;
			},

			/**
			 * @private
			 */
			_isExistsVisaPage: function() {
				const pageName = this._formatVisaPageSchemaName();
				const page = BPMSoft.ClientUnitSchemaManager.getItems().findByPath("name", pageName);
				return page;
			},

			/**
			 * @private
			 */
			_createSysModuleEntityItem: function(config, callback, scope) {
				const entitySchemaUId = config.entitySchemaUId;
				const sysModuleEntityId = BPMSoft.generateGUID();
				BPMSoft.SysModuleEntityManager.createItem({propertyValues: {id: sysModuleEntityId}}, function(item) {
					item.setEntitySchemaUId(entitySchemaUId);
					BPMSoft.SysModuleEntityManager.addItem(item);
					Ext.callback(callback, scope, [item]);
				}, this);
			},

			/**
			 * @private
			 */
			_createVisaPageSchema: function() {
				const pageNameTemplate = this._formatVisaPageSchemaName();
				const pageName = BPMSoft.ClientUnitSchemaManager.getUniqueNameByTemplate(pageNameTemplate);
				const type = BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA;
				const visaEntitySchemaUId = this.get("VisaSchemaUId");
				const visaEntitySchema = BPMSoft.EntitySchemaManager.getItem(visaEntitySchemaUId);
				const visaEntityName = visaEntitySchema.getName();
				const body = Ext.String.format(BPMSoft.ClientUnitSchemaBodyTemplate[type], pageName, visaEntityName);
				const pageUId = BPMSoft.generateGUID();
				const config = {
					uId: pageUId,
					name: pageName,
					packageUId: this.get("PackageUId"),
					caption: new BPMSoft.LocalizableString(pageName),
					body: body,
					schemaType: type,
					parentSchemaUId: BPMSoft.DesignTimeEnums.BaseSchemaUId.VISA_PAGE,
					extendParent: false
				};
				const page = BPMSoft.ClientUnitSchemaManager.createSchema(config);
				BPMSoft.ClientUnitSchemaManager.addSchema(page);
				return page;
			},

			/**
			 * @private
			 */
			_createSysModuleEditItem: function(config, callback, scope) {
				const sysModuleEntityItem = config.sysModuleEntityItem;
				const clientUnitSchema = config.clientUnitSchema;
				BPMSoft.SysModuleEditManager.createItem(function(item) {
					item.setSysModuleEntityId(sysModuleEntityItem.getId());
					item.setCardSchemaUId(clientUnitSchema.getUId());
					item.setPageCaption(clientUnitSchema.getName());
					BPMSoft.SysModuleEditManager.addItem(item);
					Ext.callback(callback, scope, [item]);
				}, this);
			},

			/**
			 * @private
			 */
			_addVisaPage: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						const entitySchemaUId = this.get("VisaSchemaUId");
						this._createSysModuleEntityItem({entitySchemaUId: entitySchemaUId}, next, this);
					},
					function(next, item) {
						const page = this._createVisaPageSchema();
						this._createSysModuleEditItem({
							clientUnitSchema: page,
							sysModuleEntityItem: item
						}, next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "VisaSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [
						{
							"name": "VisaLabelContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["section-settings-label-container"]},
							"items": [
								{
									"name": "VisaLabel",
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": {"bindTo": "Resources.Strings.VisaSettingsCaption"},
									"labelClass": ["section-settings-label"]
								}
							]
						},
						{
							"name": "VisaChecked",
							"caption": {"bindTo": "Resources.Strings.AvailableVisaCaption"},
							"enabled": {"bindTo": "canEdit"},
							"wrapClass": ["t-checkbox-control visa-settings-checkbox"]
						}
					]
				}
			}
		]
	};
});
