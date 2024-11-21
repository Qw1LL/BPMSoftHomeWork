/**
 * Parent: BaseSchemaViewModel
 */
define("BaseSectionPageSettings", [
	"BaseSectionPageSettingsResources",
	"HtmlControlGeneratorV2",
	"AcademyUtilities",
	"GridUtilitiesV2",
	"ConfigurationGridUtilities",
	"ConfigurationGrid",
	"ConfigurationGridGenerator",
	"SysModuleEditManager",
	"SectionPageSettingsItemModel",
	"DesignTimeEnums",
	"SectionSettingsMixin",
	"ProcessModuleUtilities",
	"SectionPageWizard",
	"ModalBoxSchemaModule",
	"StructureExplorerUtilitiesV2",
	"TimelineManager"
], function(resources) {
	return {
		mixins: {
			SectionSettingsMixin: BPMSoft.SectionSettingsMixin,
			ConfigurationGridUtilities: BPMSoft.ConfigurationGridUtilities,
			GridUtilities: BPMSoft.GridUtilities
		},
		messages: {
			"SaveSectionPageSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"PageSettingsChanged": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"ValidateSectionPageSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"ValidateMultiPageSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"PushHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"GetModuleInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"SavePageTypeSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"EntitySchemaDataCollectionInitialized": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"GetEntitySchema": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			"IsInitialized": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			"BlankSlateDescription": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"IsEditable": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			"TypeColumn": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			"GridData": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			"TypeList": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			"PackageUId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},
			"SysModuleEntityManagerItem": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_initAttributes: function() {
				this._initType();
				this._initGridData();
				this._initBlankSlateDescription();
			},

			/**
			 * @private
			 */
			_initType: function() {
				const typeColumn = {
					name: "Type",
					columnPath: "Type",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					caption: this.get("Resources.Strings.GridTypeColumnCaption"),
					uId: BPMSoft.generateGUID(),
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isSimpleLookup: true,
					defaultValue: {}
				};
				this.set("Type", typeColumn);
				const columns = {Type: typeColumn};
				this.entitySchema = new BPMSoft.BaseEntitySchema({columns: columns});
				Ext.apply(this.columns, columns);
			},

			/**
			 * @private
			 */
			_initGridData: function() {
				this.set("GridData", new BPMSoft.BaseViewModelCollection());
			},

			/**
			 * @private
			 */
			_initBlankSlateDescription: function() {
				const config = {
					contextHelpCode: "SectionPageSettings",
					callback: this._onGetAcademyUrlCallback,
					scope: this
				};
				BPMSoft.AcademyUtilities.getUrl(config);
			},

			/**
			 * @private
			 */
			_onGetAcademyUrlCallback: function(url) {
				const template = this.get("Resources.Strings.BlankSlateDescription");
				// todo link in message disabled
				// let startTagPart = "";
				// let endTagPart = "";
				// if (!Ext.isEmpty(url)) {
				// 	startTagPart = "<a target=\"_blank\" href=\"" + url + "\">";
				// 	endTagPart = "</a>";
				// }
				const description = Ext.String.format(template);
				this.set("BlankSlateDescription", description);
			},

			/**
			 * @private
			 */
			_loadPageList: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this._fillTypeList(next, this);
					},
					function(next) {
						this._fillGridData(next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_fillTypeList: function(callback, scope) {
				this.set("TypeList", new BPMSoft.Collection());
				const typeColumn = this.get("TypeColumn");
				if (!typeColumn || !typeColumn.column) {
					return Ext.callback(callback, scope);
				}
				BPMSoft.chain(
					function(next) {
						if (this.getIsNewTypeEntitySchema(typeColumn)) {
							this.loadTypeValueListFromDataManager(typeColumn, next, this);
						} else {
							this._loadTypeValueListFromDB(next, this);
						}
					},
					function(next, collection) {
						this.set("TypeList", collection);
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @inheritdoc BPMSoft.EntityBaseViewModelMixin#getLookupQuery
			 * @override
			 */
			getLookupQuery: function(filterValue, columnName) {
				const esq = this.callParent(arguments);
				esq.rowCount = -1;
				esq.isPageable = false;
				return esq;
			},

			/**
			 * @private
			 */
			_loadTypeValueListFromDB: function(callback, scope) {
				const esq = this.getLookupQuery(null, "Type");
				esq.getEntityCollection(function(response) {
					const collection = new BPMSoft.Collection();
					response.collection.each(function(item) {
						const id = item.get("value");
						const caption = item.get("displayValue");
						collection.add(id, {
							value: id,
							displayValue: caption
						});
					}, this);
					Ext.callback(callback, scope, [collection]);
				}, this);
			},

			/**
			 * @private
			 */
			_getReferenceEntitySchemaName: function(typeColumn) {
				const referenceSchema = this._getReferenceEntitySchemaManagerItem(typeColumn);
				const schemaName = referenceSchema ? referenceSchema.name : null;
				return schemaName;
			},

			/**
			 * @private
			 */
			_getReferenceEntitySchemaManagerItem: function(typeColumn) {
				let referenceSchema = null;
				if (typeColumn && typeColumn.column) {
					const referenceSchemaUId = typeColumn.column.referenceSchemaUId;
					referenceSchema = BPMSoft.EntitySchemaManager.getItem(referenceSchemaUId);
				}
				return referenceSchema;
			},

			/**
			 * @private
			 */
			_fillGridData: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.getActiveSysModuleEditManagerItemsChain(next, this);
					},
					function(next, moduleEdits) {
						const collection = new BPMSoft.BaseViewModelCollection();
						Promise.all(moduleEdits.getItems().map(function(moduleEdit) {
							return new Promise(function(resolve) {
								this._generatePageItemViewModel(moduleEdit, function(itemViewModel) {
									collection.add(itemViewModel.get("Id"), itemViewModel);
									resolve();
								}, scope);
							}.bind(this));
						}.bind(this))).then(function() {
							this.getGridData().reloadAll(collection);
							Ext.callback(callback, scope);
						}.bind(this));
					}, this
				);
			},

			/**
			 * @private
			 */
			_generatePageItemViewModel: function(moduleEdit, callback, scope) {
				const typeList = this.get("TypeList");
				const typeColumnValue = moduleEdit.getTypeColumnValue();
				const typeListItem = typeList.findByPath("value", typeColumnValue);
				const displayValue = typeListItem && typeListItem.displayValue;
				let type = null;
				if (displayValue) {
					type = {
						value: typeColumnValue,
						displayValue: displayValue
					};
				}
				const uId = moduleEdit.getCardSchemaUId();
				const schema = BPMSoft.ClientUnitSchemaManager.findExtendedItem(uId, this.$PackageUId) ||
					BPMSoft.ClientUnitSchemaManager.get(uId);
				BPMSoft.BaseSchemaDesignerUtilities.getIsPackageForeign(schema.packageUId, function(response) {
					const viewModel = new BPMSoft.SectionPageSettingsItemModel({
						entitySchema: this.entitySchema,
						rowConfig: this.entitySchema.columns,
						values: {
							Id: moduleEdit.id,
							ModuleEdit: moduleEdit,
							SchemaUId: schema.getUId(),
							SchemaName: schema.getName(),
							Caption: schema.getCaption(),
							SettingsModel: this,
							Type: type,
							CanRenameSchema: !response.isPackageForeign
						},
						Ext: Ext,
						BPMSoft: BPMSoft,
						sandbox: this.sandbox
					});
					callback.call(scope, viewModel);
				}, this);
			},

			/**
			 * @private
			 */
			_getPageBlankSlateImage: function() {
				const image = this.get("Resources.Images.BlankSlateImage");
				const url = BPMSoft.ImageUrlBuilder.getUrl(image);
				return url;
			},

			/**
			 * @private
			 */
			_createPage: function(config, callback, scope) {
				config = config || {};
				BPMSoft.eachAsyncAll(
					[
						function(next) {
							this._createPageSchema(config, next, this);
						},
						function(next) {
							BPMSoft.SysModuleEditManager.createItem(next, this);
						}
					],
					function(results) {
						const page = results[0];
						const moduleEdit = results[1];
						moduleEdit.setSysModuleEntityId(this.get("SysModuleEntityUId"));
						moduleEdit.setCardSchemaUId(page.uId);
						const caption = (page.caption || "").toString();
						this._setModuleEditType(moduleEdit, config.type, caption);
						moduleEdit.setActionKindName(page.name);
						BPMSoft.SysModuleEditManager.addItem(moduleEdit);
						BPMSoft.chain(
							function(next) {
								this.getActiveSysModuleEditManagerItemsChain(next, this);
							},
							function(next, pages) {
								if (pages.getCount() === 1) {
									this.sandbox.publish("PageSettingsChanged", null, [this.sandbox.id]);
								}
								Ext.callback(callback, scope, [page]);
							}, this
						);
					}, this
				);
			},

			/**
			 * @private
			 */
			_setModuleEditType: function(moduleEdit, type, caption) {
				if (caption) {
					moduleEdit.setPageCaption(caption);
				}
				const actionKindCaption = this._generateSysModuleEditManagerItemCaption(type);
				moduleEdit.setActionKindCaption(actionKindCaption);
				moduleEdit.setTypeColumnValue(type && type.value);
			},

			/**
			 * @private
			 */
			_addPage: function(config, callback, scope) {
				let page;
				BPMSoft.chain(
					function(next) {
						this._createPage(config, next, this);
					},
					function(next, newPage) {
						page = newPage;
						this._loadPageList(next, this);
					},
					function() {
						Ext.callback(callback, scope, [page]);
					}, this
				);
			},

			/**
			 * @private
			 */
			_generateSysModuleEditManagerItemCaption: function(type) {
				const typeDisplayValue = type && type.displayValue;
				return typeDisplayValue || "";
			},

			/**
			 * @private
			 */
			_createPageSchema: function(config, callback, scope) {
				let page;
				const packageUId = this.get("PackageUId");
				BPMSoft.chain(
					function(next) {
						const entitySchema = this.getModuleEntitySchema();
						BPMSoft.EntitySchemaManager.getPackageSchemaInstanceBySchemaName(entitySchema.name, packageUId, next, this);
					},
					function(next, entitySchema) {
						const schemaType = BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA;
						const bodyTemplate = BPMSoft.ClientUnitSchemaBodyTemplate[schemaType];
						const entitySchemaName = entitySchema.getPropertyValue("name");
						const pageNameTemplate = BPMSoft.ApplicationStructureWizardUtils
							.getEntityFullName(entitySchemaName + "{0}Page");
						const schemaName = BPMSoft.ClientUnitSchemaManager.getUniqueNameByTemplate(pageNameTemplate);
						const schemaCaption = config.caption || this.generateEntitySchemaCaption(config.type);
						const baseUIds = BPMSoft.DesignTimeEnums.BaseSchemaUId;
						const parentSchemaUId = this.getIsSspSection()
							? baseUIds.BASE_SECTION_PAGE
							: baseUIds.BASE_MODULE_PAGE;
						const schemaConfig = {
							uId: BPMSoft.generateGUID(),
							name: schemaName,
							packageUId: packageUId,
							caption: new BPMSoft.LocalizableString(schemaCaption),
							body: Ext.String.format(bodyTemplate, schemaName, entitySchemaName),
							schemaType: BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,
							parentSchemaUId: parentSchemaUId
						};
						page = BPMSoft.ClientUnitSchemaManager.createSchema(schemaConfig);
						const diff = this._getProfileContainerDiff(entitySchema);
						page.setSchemaDiff(diff);
						this._createFilesDetail(page, entitySchemaName, next, this);
					},
					function(next) {
						BPMSoft.ClientUnitSchemaManager.addSchema(page);
						page.define(next, this);
					},
					function() {
						Ext.callback(callback, scope, [page]);
					}, this
				);
			},

			/**
			 * @private
			 */
			_getProfileContainerDiff: function(entitySchema) {
				const primaryDisplayColumnName = entitySchema.primaryDisplayColumn.name;
				return [
					{
						"operation": "insert",
						"name": primaryDisplayColumnName + BPMSoft.generateGUID(),
						"values": {
							"layout": {
								"colSpan": 24,
								"rowSpan": 1,
								"column": 0,
								"row": 0,
								"layoutName": "ProfileContainer"
							},
							"bindTo": primaryDisplayColumnName
						},
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"index": 0
					}
				];
			},

			/**
			 * @private
			 */
			_getFileDetailDefine: function(fileSchemaName, entitySchemaName) {
				return {
					"schemaName": "FileDetailV2",
					"entitySchemaName": fileSchemaName,
					"filter": {
						"masterColumn": "Id",
						"detailColumn": entitySchemaName
					}
				};
			},

			/**
			 * @private
			 */
			_getNotesAndFilesDiff: function() {
				const entitySchema = this.getModuleEntitySchema();
				const existingNotesColumn = entitySchema.columns.findByPath("name", "Notes");
				const userNotesColumnName = BPMSoft.ApplicationStructureWizardUtils.getEntityFullName("Notes");
				const notesColumnName = existingNotesColumn ? existingNotesColumn.name : userNotesColumnName;
				return [
					{
						"operation": "insert",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 0,
						"name": "NotesAndFilesTab",
						"values": {
							"caption": {"bindTo": "Resources.Strings.NotesAndFilesTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesAndFilesTab",
						"propertyName": "items",
						"name": "Files",
						"values": {
							"itemType": "#BPMSoft.ViewItemType.DETAIL#"
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesAndFilesTab",
						"propertyName": "items",
						"name": "NotesControlGroup",
						"values": {
							"itemType": "#BPMSoft.ViewItemType.CONTROL_GROUP#",
							"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesControlGroup",
						"propertyName": "items",
						"name": "Notes",
						"values": {
							"bindTo": notesColumnName,
							"dataValueType": "#BPMSoft.DataValueType.TEXT#",
							"contentType": "#BPMSoft.ContentType.RICH_TEXT#",
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"labelConfig": {"visible": false},
							"controlConfig": {
								"imageLoaded": {"bindTo": "insertImagesToNotes"},
								"images": {"bindTo": "NotesImagesCollection"}
							}
						}
					}
				];
			},

			/**
			 * @private
			 */
			_registerFileDetail: function(fileSchemaName, callback, scope) {
				const detailSchemaUId = BPMSoft.DesignTimeEnums.BaseSchemaUId.FILE_DETAIL;
				const detailSchema = BPMSoft.ClientUnitSchemaManager.findItem(detailSchemaUId);
				const entitySchemaItems = BPMSoft.EntitySchemaManager.getItems();
				const fileSchema = entitySchemaItems.findByPath("name", fileSchemaName);
				const fileSchemaUId = fileSchema.getUId();
				const fileSchemaCaption = fileSchema.getCaption();
				const detailSchemaName = detailSchema.getName();
				const detailConfig = {
					propertyValues: {
						detailSchemaUId: detailSchemaUId,
						entitySchemaUId: fileSchemaUId,
						caption: fileSchemaCaption,
						detailSchemaName: detailSchemaName,
						entitySchemaName: fileSchemaName
					}
				};
				const detail = BPMSoft.DetailManager.getItems().findByPath("entitySchemaUId", fileSchemaUId);
				if (detail) {
					callback.call(scope);
				} else {
					BPMSoft.DetailManager.createItem(detailConfig, function(item) {
						BPMSoft.DetailManager.addItem(item);
						callback.call(scope);
					}, this);
				}
			},

			/**
			 * @private
			 */
			_addPageFileDetail: function(page, fileSchemaName, entitySchemaName) {
				const detailsStr = page.getSchemaDetails();
				const details = JSON.parse(detailsStr);
				details.Files = this._getFileDetailDefine(fileSchemaName, entitySchemaName);
				page.setSchemaDetails(details);
				const diffStr = page.getSchemaDiff();
				let diff = JSON.parse(diffStr);
				const notesAndFilesDiff = this._getNotesAndFilesDiff();
				diff = diff.concat(notesAndFilesDiff);
				page.setSchemaDiff(diff);
			},

			/**
			 * @private
			 */
			_createFilesDetail: function(page, entitySchemaName, callback, scope) {
				const manager = BPMSoft.EntitySchemaManager;
				const prefix = !manager.startWithPrefix(entitySchemaName)
					? manager.getSchemaNamePrefix()
					: "";
				let fileSchemaName = prefix + entitySchemaName + "File";
				const entitySchemaItems = BPMSoft.EntitySchemaManager.getItems();
				if (!entitySchemaItems.findByPath("name", fileSchemaName)) {
					fileSchemaName = "File" + entitySchemaName;
					if (!entitySchemaItems.findByPath("name", fileSchemaName)) {
						return Ext.callback(callback, scope);
					}
				}
				this._addPageFileDetail(page, fileSchemaName, prefix + entitySchemaName);
				this._registerFileDetail(fileSchemaName, callback, scope);
			},

			/**
			 * @private
			 */
			_openSectionPageWizard: function(pageUId, callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.onBeforeSectionPageWiazardOpen(next, this);
					},
					function() {
						const section = this.get("SectionManagerItem");
						const url = [
							BPMSoft.workspaceBaseUrl,
							BPMSoft.DesignTimeEnums.WizardUrl.SECTION_PAGE_WIZARD_URL,
							[
								BPMSoft.SectionWizardEnums.PageName.PAGE_DESIGNER,
								section.id,
								pageUId
							].join("/")
						].join("");
						this.sandbox.publish("PushHistoryState", {hash: url});
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_editPage: function(item) {
				this._showModuleMask();
				const schemaUId = item.get("SchemaUId");
				this._openSectionPageWizard(schemaUId);
			},

			/**
			 * @private
			 */
			_initTypeColumn: function() {
				const managerItem = this.get("SysModuleEntityManagerItem");
				const typeColumnUId = managerItem.getTypeColumnUId();
				this._setTypeColumnByUId(typeColumnUId);
			},

			/**
			 * @private
			 */
			_saveTypeColumn: function(columnUId, callback, scope) {
				const moduleEntity = this.get("SysModuleEntityManagerItem");
				moduleEntity.setTypeColumnUId(columnUId);
				const section = this.get("SectionManagerItem");
				if (columnUId) {
					const entitySchema = this.getModuleEntitySchema();
					const column = entitySchema.columns.get(columnUId);
					section.setAttribute(column.name);
				} else {
					section.setAttribute(null);
				}
				this._setTypeColumnByUId(columnUId, callback, scope);
			},

			/**
			 * @private
			 */
			_setTypeColumnByUId: function(typeColumnUId, callback, scope) {
				let columnItem = null;
				if (typeColumnUId) {
					const entitySchema = this.getModuleEntitySchema();
					const column = entitySchema && entitySchema.columns.get(typeColumnUId);
					if (column) {
						const referenceEntity = BPMSoft.EntitySchemaManager.findItem(column.referenceSchemaUId);
						columnItem = {
							value: column.uId,
							displayValue: (column.caption || "").toString(),
							dataValueType: column.dataValueType,
							column: column,
							key: column.name,
							referenceItem: referenceEntity
						};
						const type = this.get("Type");
						if (referenceEntity) {
							type.uId = column.uId;
							type.caption = (column.caption || "").toString();
							type.referenceSchemaUId = column.referenceSchemaUId;
							type.referenceSchemaName = referenceEntity.getName();
						}
					}
				}
				this._setTypeColumnValue(columnItem);
				const typeColumn = this.get("TypeColumn");
				this.requireReferenceEntitySchema(typeColumn, function(referenceEntitySchema) {
					this.set("ReferenceEntitySchema", referenceEntitySchema);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_setTypeColumnValue: function(column, callback, scope) {
				const oldColumn = this.get("TypeColumn");
				this.set("TypeColumn", column);
				const newValue = column && column.value;
				const oldValue = oldColumn && oldColumn.value;
				const isInitialized = this.get("IsInitialized");
				if (newValue !== oldValue && (oldValue || isInitialized)) {
					this._resetPagesTypeColumn(callback, scope);
				}
			},

			/**
			 * @private
			 */
			_resetPagesTypeColumn: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.getActiveSysModuleEditManagerItemsChain(next, this);
					},
					function(next, moduleEdits) {
						moduleEdits.each(function(moduleEdit) {
							moduleEdit.setTypeColumnValue(null);
						}, this);
						this._loadPageList(next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_onSaveSectionPageSettings: function(callback) {
				BPMSoft.chain(
					function(next) {
						this.getActiveSysModuleEditManagerItemsChain(next, this);
					},
					function(next, pages) {
						if (pages.isEmpty()) {
							this._addPage(null, next, this);
						} else {
							next();
						}
					},
					function() {
						Ext.callback(callback);
					}, this
				);
			},

			/**
			 * @private
			 */
			_onValidateMultiPageSettings: function() {
				return true;
			},

			/**
			 * @private
			 */
			_showModuleMask: function() {
				const maskId = BPMSoft.Mask.show({
					selector: "#" + this.renderTo,
					timeout: 0
				});
				return maskId;
			},

			/**
			 * @private
			 */
			_selectTypeColumn: function(callback, scope) {
				const entitySchema = this.getModuleEntitySchema();
				entitySchema.undef();
				entitySchema.define();
				this.sandbox.subscribe("GetEntitySchema", function(entitySchemaName) {
					if (entitySchemaName === entitySchema.name) {
						return BPMSoft[entitySchema.name];
					}
				}, this);
				const typeColumn = this.get("TypeColumn");
				BPMSoft.StructureExplorerUtilities.open({
					moduleName: "StructureExploreModuleV2",
					moduleConfig: {
						useOldStructureExplorer: true,
						schemaName: entitySchema.name,
						columnPath: typeColumn && typeColumn.key,
						lookupsColumnsOnly: true,
						firstColumnsOnly: true,
						allowEmptyResult: true
					},
					handlerMethod: function(result) {
						const columnUId = result.metaPath[0];
						Ext.callback(callback, scope, [columnUId]);
					},
					scope: this
				});
			},

			/**
			 * @private
			 */
			_getNeedAddLookupColumn: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.getEntitySchemaLookupColumns(next, this);
					},
					function(next, columns) {
						const hasLookupColumn = columns.any(function(item) {
							return this._isBaseLookupSchema(item.column.referenceSchemaUId);
						}, this);
						const needAddLookupColumn = !hasLookupColumn;
						Ext.callback(callback, scope, [needAddLookupColumn]);
					}, this
				);
			},

			/**
			 * @private
			 */
			_isBaseLookupSchema: function(entitySchemaUId) {
				const entityItem = BPMSoft.EntitySchemaManager.findItem(entitySchemaUId);
				let response = false;
				if (entityItem) {
					const hierarchy = entityItem.getHierarchyInfo() || [];
					response = hierarchy.some(function(item) {
						return item && item.uId === BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_LOOKUP;
					}, this);
				}
				return response;
			},

			/**
			 * @private
			 */
			_addLookupColumn: function(callback, scope) {
				const entitySchema = this.getModuleEntitySchema();
				const nameMask = BPMSoft.ApplicationStructureWizardUtils.getEntityFullName(entitySchema.name, "Type");
				const lookupName = BPMSoft.EntitySchemaManager.generateItemUniqueName(nameMask);
				const captionMask = this.get("Resources.Strings.TypeReferenceEntitySchemaCaptionMask");
				const lookupCaption = Ext.String.format(captionMask, (entitySchema.caption || "").toString());
				const lookupSchema = BPMSoft.EntitySchemaManager.createSchema({
					uId: BPMSoft.generateGUID(),
					name: lookupName,
					caption: new BPMSoft.LocalizableString(lookupCaption),
					packageUId: this.get("PackageUId")
				});
				BPMSoft.chain(
					function(next) {
						lookupSchema.setParent(BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_LOOKUP, next, this);
					},
					function(next) {
						lookupSchema.define();
						const lookupEntitySchema = BPMSoft.EntitySchemaManager.addSchema(lookupSchema);
						BPMSoft.DataManager.initEntitySchemaDataCollection(lookupSchema.name);
						BPMSoft.ApplicationStructureWizardUtils.createLookupManagerItem(lookupEntitySchema, next, this);
					},
					function(next) {
						const column = this._createLookupColumn(lookupSchema);
						entitySchema.addColumn(column);
						this._setTypeColumnByUId(column.uId, next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_createLookupColumn: function(lookupSchema) {
				const caption = this.get("Resources.Strings.DefaultTypeColumnCaption");
				const column = new BPMSoft.EntitySchemaColumn({
					name: BPMSoft.EntitySchemaManager.getSchemaNamePrefix() + "Type",
					caption: new BPMSoft.LocalizableString(caption)
				});
				column.dataValueType = BPMSoft.DataValueType.LOOKUP;
				column.isRequired = true;
				column.isSimpleLookup = true;
				column.referenceSchemaUId = lookupSchema.uId;
				column.setNew();
				return column;
			},

			/**
			 * @private
			 */
			_tryConvertSectionToSinglePageSection: function(callback, scope) {
				this.getActiveSysModuleEditManagerItemsChain(function(collection) {
					if (collection.getCount() <= 1) {
						if (collection.getCount() === 1) {
							const moduleEditManagerItem = collection.first();
							moduleEditManagerItem.setActionKindCaption("");
						}
						this._saveTypeColumn(null, callback, scope);
					} else {
						Ext.callback(callback, scope);
					}
				}, this);
			},

			// endregion

			// region Methods: Protected

			/**
			 * Returns section types enumeration.
			 * @protected
			 * @return {Object} Section types enumeration.
			 */
			getSectionTypes: function() {
				const settings = this.$Settings;
				const sectionTypes = settings && settings.sectionTypes;
				return sectionTypes || {};
			},

			/**
			 * Checks is current section type SSP.
			 * @protected
			 * @return {Boolean} True if current section type SSP, false otherwise.
			 */
			getIsSspSection: function() {
				const sectionManagerItem = this.get("SectionManagerItem");
				const types = this.getSectionTypes();
				return sectionManagerItem.type === types.SSP;
			},

			/**
			 * Before section page wizard open action.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			onBeforeSectionPageWiazardOpen: function(callback, scope) {
				Ext.callback(callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.set("IsInitialized", false);
				this.subscribeSandboxEvents();
				this._initAttributes();
				const parentMethod = this.getParentMethod();
				BPMSoft.chain(
					function(next) {
						parentMethod.call(this, next, this);
					},
					function(next) {
						this.mixins.SectionSettingsMixin.init.call(this);
						BPMSoft.ClientUnitSchemaManager.initialize(next, this);
					},
					function(next) {
						this._loadPageList(next, this);
					},
					function() {
						this.sandbox.subscribe("ValidateSectionPageSettings", this.onValidate, this, [this.sandbox.id]);
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				const tags = [this.sandbox.id];
				this.sandbox.subscribe("SaveSectionPageSettings", this._onSaveSectionPageSettings, this, tags);
				this.sandbox.subscribe("ValidateMultiPageSettings", this._onValidateMultiPageSettings, this, tags);
				this.mixins.SectionSettingsMixin.subscribeSandboxEvents.call(this);
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#getInitializedMessageName
			 * @override
			 */
			getInitializedMessageName: function() {
				return "SectionPageSettingsInitialized";
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#initModuleSettings
			 * @override
			 */
			initModuleSettings: function(callback, scope) {
				if (this.canEdit()) {
					this._initTypeColumn();
				}
				Ext.callback(callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.SectionSettingsMixin#clearModel
			 * @override
			 */
			clearModel: function() {
				this.mixins.SectionSettingsMixin.clearModel.call(this);
				this._setTypeColumnValue(null);
				this.getGridData().clear();
			},

			/**
			 * Returns grid data.
			 * @protected
			 * @return {Object} Grid data.
			 */
			getGridData: function() {
				return this.get("GridData");
			},

			/**
			 * @protected
			 */
			onValidate: function() {
				return true;
			},

			/**
			 * @protected
			 */
			setupPage: function(config, callback, scope) {
				this._showModuleMask();
				BPMSoft.chain(
					function(next) {
						this._addPage(config, next, this);
					},
					function(next, page) {
						this._openSectionPageWizard(page.uId, function() {
							next(page);
						}, this);
					},
					function(next, page) {
						Ext.callback(callback, scope, [page]);
					}, this
				);
			},

			/**
			 * @protected
			 */
			onSetupPageButtonClick: function() {
				this.setupPage();
			},

			/**
			 * @protected
			 */
			isSinglePageContainerVisible: function(collection) {
				return Boolean(collection) && collection.getCount() === 1;
			},

			/**
			 * @protected
			 */
			isMultiPageContainerVisible: function(collection) {
				return Boolean(collection) && collection.getCount() > 1;
			},

			/**
			 * @protected
			 */
			onSinglePageButtonClick: function() {
				this.onEditSinglePage();
			},

			/**
			 * @protected
			 */
			onAddPageButtonClick: function() {
				this.openPageTypeSettingsPage();
			},

			/**
			 * @protected
			 */
			openPageTypeSettingsPage: function(config, callback, scope) {
				const maskId = this._showModuleMask();
				BPMSoft.chain(
					function(next) {
						this._getNeedAddLookupColumn(next, this);
					},
					function(next, needAddLookupColumn) {
						if (needAddLookupColumn) {
							this._addLookupColumn(next, this);
						} else {
							next();
						}
					},
					function(next) {
						config = config || {};
						const getModuleInfo = config.onGetInfo || this.onGetPageTypeSettingsData;
						const savePageTypeSettings = config.onSave || this.onSavePageTypeSettings;
						const moduleId = this.sandbox.id + "PageTypeSettingsModule";
						this.sandbox.subscribe("GetModuleInfo", getModuleInfo, this, [moduleId]);
						this.sandbox.subscribe("SavePageTypeSettings", savePageTypeSettings, this, [moduleId]);
						this.sandbox.loadModule("ModalBoxSchemaModule", {
							id: moduleId,
							callback: next,
							scope: this
						});
					},
					function() {
						BPMSoft.Mask.hide(maskId);
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @protected
			 */
			onGetPageTypeSettingsData: function() {
				let typeColumn = this.get("TypeColumn");
				const entitySchema = this.getModuleEntitySchema();
				if (!typeColumn) {
					const typeColumnNames = [BPMSoft.EntitySchemaManager.getSchemaNamePrefix() + "Type", "Type"];
					const defaultTypeColumn = entitySchema.columns.findByFn(function(column) {
						return _.contains(typeColumnNames, column.name);
					}, this);
					if (defaultTypeColumn) {
						typeColumn = {value: defaultTypeColumn.uId};
					}
				}
				return {
					schemaName: "PageTypeSettingsPage",
					entitySchema: entitySchema,
					typeColumn: typeColumn,
					settingsModel: this
				};
			},

			/**
			 * Handler for SavePageTypeSettings message. Process response of save SavePageTypeSettingsPage.
			 * @protected
			 * @param {Object} response Result of SavePageTypeSettingsPage.
			 * @param {Object} [response.typeColumn] Selected lookup column.
			 * @param {Object} [response.typeValue] Selected lookup column value.
			 * @param {String} [response.schemaCaption] Custom schema caption.
			 */
			onSavePageTypeSettings: function(response, callback, scope) {
				BPMSoft.chain(
					function(next) {
						this._saveTypeColumn(response.typeColumn && response.typeColumn.value, next, this);
					},
					function(next) {
						const config = {
							type: response.typeValue,
							caption: response.schemaCaption
						};
						this.setupPage(config, next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @protected
			 */
			getPageTypeHeaderCaption: function() {
				let caption = "";
				const typeColumn = this.get("TypeColumn");
				const typeDisplayValue = typeColumn && typeColumn.displayValue;
				if (typeDisplayValue) {
					caption = this.get("Resources.Strings.TypeColumnCaption");
				} else {
					caption = this.get("Resources.Strings.EmptyTypeColumnCaption");
				}
				return caption;
			},

			/**
			 * @protected
			 */
			onPageTypeSettingsButtonClick: function() {
				this.changeTypeColumn();
			},

			/**
			 * @protected
			 */
			changeTypeColumn: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this._selectTypeColumn(next, this);
					},
					function(next, columnUId) {
						this._saveTypeColumn(columnUId);
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @protected
			 */
			getUsedTypes: function() {
				const usedTypes = [];
				const gridData = this.getGridData();
				gridData.each(function(item) {
					const type = item.get("Type");
					if (type && !type.isNewValue) {
						const result = BPMSoft.findWhere(usedTypes, {value: type.value});
						if (!result) {
							usedTypes.push(type);
						}
					}
				}, this);
				return usedTypes;
			},

			/**
			 * @protected
			 */
			checkCanAddNewType: function(displayValue) {
				const usedTypes = this.getUsedTypes();
				const result = BPMSoft.findWhere(usedTypes, {displayValue: displayValue});
				if (result) {
					const message = this.get("Resources.Strings.CantAddNewTypeMessage");
					BPMSoft.showMessage(message);
				}
				return !result;
			},

			/**
			 * @protected
			 */
			openPageTypeSettingsPageForCopyItem: function(schemaCaption, callback, scope) {
				this.openPageTypeSettingsPage({
					onGetInfo: function() {
						const result = this.onGetPageTypeSettingsData();
						result.schemaCaption = schemaCaption;
						return result;
					},
					onSave: function(response) {
						BPMSoft.chain(
							function(next) {
								this._saveTypeColumn(response.typeColumn && response.typeColumn.value, next, this);
							},
							function() {
								Ext.callback(callback, scope, [response]);
							}, this
						);
					}
				});
			},

			/**
			 * @protected
			 */
			onEditSinglePage: function() {
				const item = this.getGridData().first();
				this.editModelItem(item);
			},

			/**
			 * @protected
			 */
			onRenameSinglePage: function() {
				const item = this.getGridData().first();
				this.renameModelItem(item);
			},

			/**
			 * @protected
			 */
			onCopySinglePage: function() {
				const item = this.getGridData().first();
				this.copyModelItem(item);
			},

			/**
			 * @protected
			 */
			onRemoveSinglePage: function() {
				const item = this.getGridData().first();
				this.removeModelItem(item);
			},

			/**
			 * @protected
			 */
			canRenameSinglePage: function() {
				const firstItem = this.$GridData.first();
				return firstItem && firstItem.$CanRenameSchema;
			},

			// endregion

			// region Methods: Public

			/**
			 * Returns reference entity schema for type column.
			 * @param {Object} typeColumn Type column info.
			 * @param {Function} callback The callback function.
			 * @param {BPMSoft.manager.EntitySchema} callback.referenceEntitySchema Result entity schema.
			 * @param {Object} scope The scope of callback function.
			 */
			requireReferenceEntitySchema: function(typeColumn, callback, scope) {
				const entitySchema = this._getReferenceEntitySchemaManagerItem(typeColumn);
				if (!entitySchema) {
					return Ext.callback(callback, scope, null);
				}
				const entitySchemaName = entitySchema.name;
				BPMSoft.chain(
					function(next) {
						if (this.getIsNewTypeEntitySchema(typeColumn)) {
							next();
						} else {
							this.sandbox.requireModuleDescriptors(["force!" + entitySchemaName], next);
						}
					},
					function(next) {
						BPMSoft.require([entitySchemaName], next, this);
					},
					function(next, referenceEntitySchema) {
						Ext.callback(callback, scope, [referenceEntitySchema]);
					}, this
				);
			},

			/**
			 * Returns lookup columns of current module entity schema.
			 * @param {Function} callback The callback function.
			 * @param {BPMSoft.core.collections.Collection} callback.collection Result collection.
			 * @param {Object} scope The scope of callback function.
			 */
			getEntitySchemaLookupColumns: function(callback, scope) {
				const entitySchema = this.getModuleEntitySchema();
				const columns = entitySchema.columns.filterByFn(function(column) {
					return BPMSoft.isLookupDataValueType(column.dataValueType) &&
						column.usageType !== BPMSoft.EntitySchemaColumnUsageType.None &&
						column.getStatus() !== BPMSoft.ModificationStatus.REMOVED;
				}, this);
				const collection = new BPMSoft.Collection();
				BPMSoft.eachAsync(columns.getItems(),
					function(column, next) {
						const item = BPMSoft.EntitySchemaManager.getItem(column.referenceSchemaUId);
						item.getInstance(function(referenceSchema) {
							const isLookupSchema = referenceSchema.primaryDisplayColumn != null;
							if (isLookupSchema) {
								collection.add(column.uId, {
									value: column.uId,
									displayValue: (column.caption || "").toString() || column.name,
									column: column
								});
							}
							next();
						}, this);
					},
					function() {
						Ext.callback(callback, scope, [collection]);
					}, this
				);
			},

			/**
			 * Adds new type record to data manager store.
			 * @param {Object} config
			 * @param {String} config.displayValue New type record display value.
			 * @param {Object} [config.typeColumn] Type column info.
			 * @param {Function} callback The callback function.
			 * @param {Object} callback.response Added item info response.
			 * @param {Object} scope The scope of callback function.
			 */
			addTypeRecordToDataManager: function(config, callback, scope) {
				const displayValue = config.displayValue;
				const dataItemId = BPMSoft.generateGUID();
				BPMSoft.chain(
					function(next) {
						if (config.typeColumn) {
							this.requireReferenceEntitySchema(config.typeColumn, next, this);
						} else {
							next(this.get("ReferenceEntitySchema"));
						}
					},
					function(next, entitySchema) {
						const createConfig = {
							entitySchemaName: entitySchema.name,
							columnValues: {
								Id: dataItemId,
								Name: displayValue,
								value: dataItemId,
								displayValue: displayValue
							}
						};
						BPMSoft.DataManager.createItem(createConfig, next, this);
					},
					function(next, dataManagerItem) {
						dataManagerItem.dataItemId = dataItemId;
						BPMSoft.DataManager.addItem(dataManagerItem);
						const response = {
							value: dataItemId,
							displayValue: displayValue
						};
						Ext.callback(callback, scope, [response]);
					}, this
				);
			},

			/**
			 * Loads type value list from data manager store.
			 * @param {Object} typeColumn Type column info.
			 * @param {Function} callback The callback function.
			 * @param {BPMSoft.core.collections.Collection} callback.collection Result collection.
			 * @param {Object} scope The scope of callback function.
			 */
			loadTypeValueListFromDataManager: function(typeColumn, callback, scope) {
				this.getTypeRecordsFromDataManager({typeColumn: typeColumn}, function(response) {
					const collection = new BPMSoft.Collection();
					response.collection.each(function(item) {
						const id = item.get("Id");
						const caption = item.get("Name");
						collection.add(id, {
							value: id,
							displayValue: caption
						});
					}, this);
					Ext.callback(callback, scope, [collection]);
				}, this);
			},

			/**
			 * Returns status of type column reference entity schema.
			 * @param {Object} config.typeColumn Type column info.
			 * @return {Boolean} Returns true if reference entity schema is new.
			 */
			getIsNewTypeEntitySchema: function(typeColumn) {
				typeColumn = Ext.isDefined(typeColumn) ? typeColumn : this.get("TypeColumn");
				const referenceSchemaUId = BPMSoft.get(typeColumn, "column.referenceSchemaUId");
				const schema = referenceSchemaUId && BPMSoft.EntitySchemaManager.findItem(referenceSchemaUId);
				const isNew = schema ? schema.getStatus() === BPMSoft.ModificationStatus.NEW : false;
				return isNew;
			},

			/**
			 * Returns type lookup records from data manager
			 * @param {Object} config
			 * @param {Object} config.typeColumn Type column info.
			 * @param {String} [config.filterValue] Filtered value.
			 * @param {Boolean} [config.uniqueTypeValues] Flag to filter already used type values.
			 * @param {Boolean} [config.currentType] Type for not filter from already used type values.
			 * @param {Function} callback The callback function.
			 * @param {BPMSoft.core.collections.Collection} callback.collection Result collection.
			 * @param {Object} scope The scope of callback function.
			 */
			getTypeRecordsFromDataManager: function(config, callback, scope) {
				const typeColumn = Ext.isDefined(config.typeColumn) ? config.typeColumn : this.get("TypeColumn");
				const filterValue = config.filterValue;
				const uniqueTypeValues = config.uniqueTypeValues;
				const currentType = config.currentType;
				const entitySchemaName = this._getReferenceEntitySchemaName(typeColumn);
				const selectConfig = {
					entitySchemaName: entitySchemaName,
					columnsInfo: [
						{columnName: "Id"},
						{columnName: "Name"}
					]
				};
				const gridData = this.getGridData();
				BPMSoft.DataManager.select(selectConfig, function(dataCollection) {
					const collection = new BPMSoft.BaseViewModelCollection();
					dataCollection.each(function(dataItem) {
						const rowViewModel = dataItem.viewModel;
						const recordId = rowViewModel.get("Id");
						if (uniqueTypeValues) {
							const gridItem = gridData.findByFn(function(item) {
								const typeValue = item.get("Type") && item.get("Type").value;
								return typeValue === recordId;
							}, this);
							if (!gridItem || (currentType && gridItem.get("Type") &&
								currentType.value === gridItem.get("Type").value)) {
								const displayValue = rowViewModel.get("Name") || "";
								if (!filterValue || (filterValue && displayValue.indexOf(filterValue) > -1)) {
									collection.add(recordId, rowViewModel);
								}
							}
						} else {
							collection.add(recordId, rowViewModel);
						}
					}, this);
					Ext.callback(callback, scope, [collection]);
				}, this);
			},

			/**
			 * Adds to query filter for not equal used types, except exceptType.
			 * @param {BPMSoft.data.queries.EntitySchemaQuery} esq Query.
			 * @param {{value: String, displayValue: String}} [exceptType] Type for not include in filter.
			 */
			addUsedTypesFilter: function(esq, exceptType) {
				const usedTypes = this.getUsedTypes();
				if (exceptType) {
					const result = BPMSoft.findItem(usedTypes, {value: exceptType.value});
					if (result) {
						usedTypes.splice(result.index, 1);
					}
				}
				const usedTypesIds = usedTypes.map(function(type) {
					return type.value;
				}, this);
				const filter = BPMSoft.createColumnInFilterWithParameters("Id", usedTypesIds);
				filter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				esq.filters.add("notUsedValueFilter", filter);
			},

			/**
			 * Edit grid data item by id.
			 * @param {BPMSoft.configuration.SectionPageSettingsItemModel} item Grid data item.
			 */
			editModelItem: function(item) {
				this._showModuleMask();
				this._editPage(item);
			},

			/**
			 * Changes type for grid data item.
			 * @param {BPMSoft.configuration.SectionPageSettingsItemModel} item Grid data item.
			 * @param {{value: String, displayValue: String}} [type] New type.
			 */
			changeModelItemType: function(item, type) {
				const moduleEdit = item.get("ModuleEdit");
				this._setModuleEditType(moduleEdit, type);
			},

			/**
			 * Rename grid data item by id.
			 * @param {BPMSoft.configuration.SectionPageSettingsItemModel} item Grid data item.
			 * @param {Function} [callback] The callback function.
			 * @param {Object} [scope] The scope of callback function.
			 */
			renameModelItem: function(item, callback, scope) {
				var config = {
          style: {
            borderStyle: "rename-modalbox-schema-wrap-item",
          }
        };

				BPMSoft.showInputBox(resources.localizableStrings.SchemaCaption, function(buttonCode, values) {
					if (buttonCode === "ok") {
						let caption = values.caption.value;
						if (caption) {
							caption = caption.slice(0, 250);
						} else {
							caption = this.generateEntitySchemaCaption(item.get("Type"));
						}
						item.set("Caption", caption);
						const schemaUId = item.get("SchemaUId");
						BPMSoft.ClientUnitSchemaManager.getInstanceByUId(schemaUId, function(schema) {
							schema.setLocalizableStringPropertyValue("caption", caption);
							Ext.callback(callback, scope);
						}, this);
					} else {
						Ext.callback(callback, scope);
					}
				}, ["ok", "cancel"], this, {
					caption: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						value: item.get("Caption"),
						customConfig: {
							hasClearIcon: true,
							focused: true,
							markerValue: "SchemaCaptionInput"
						}
					}
				}, config);
			},

			removeAngularModuleItems: function (code) {
				var start = code.indexOf("/**SCHEMA_DIFF*/[");
				var end = code.indexOf("]/**SCHEMA_DIFF*/") + "]/**SCHEMA_DIFF*/".length;
				var diffString = code.substring(start, end);
	
				var diffArray = eval(diffString.replace("/**SCHEMA_DIFF*/", ""));
			
				// Фильтруем массив, удаляя элементы с markerValue: "AngularModule"
				var filteredDiff = diffArray.filter(function(item) {
					return !(item.values && item.values.markerValue === "AngularModule");
				});
			
				// Воссоздаём строку diff с отфильтрованным содержимым
				var newDiffString = "/**SCHEMA_DIFF*/" + JSON.stringify(filteredDiff, null, 4) + "/**SCHEMA_DIFF*/";
			
				// Заменяем старую часть кода на новую
				return code.substring(0, start) + newDiffString + code.substring(end);
			},
			
			/**
			 * Copy grid data item by id.
			 * @param {BPMSoft.configuration.SectionPageSettingsItemModel} item Grid data item.
			 * @param {Function} [callback] The callback function.
			 * @param {Object} [scope] The scope of callback function.
			 */
			copyModelItem: function(item, callback, scope) {
				let sourcePage, type, caption, copyPage;
				const manager = BPMSoft.ClientUnitSchemaManager;
				const sourceSchemaUId = item.get("SchemaUId");
				const sourceItem = manager.getItem(sourceSchemaUId);
				const packageUId = this.get("PackageUId");
				const sysModuleEntityUId = this.get("SysModuleEntityUId");
				BPMSoft.chain(
					function(next) {
						sourceItem.getInstance(next, this);
					},
					function(next, sourceSchemaInstance) {
						sourcePage = sourceSchemaInstance;
						const prefix = sourcePage.caption + " - " + resources.localizableStrings.PageCopySuffix;
						caption = manager.generateItemUniqueCaption(prefix);
						this.openPageTypeSettingsPageForCopyItem(caption, next, this);
					},
					function(next, response) {
						const copyItem = manager.copySchema(sourcePage);
						copyPage = copyItem.instance;
						type = response.typeValue;
						caption = response.schemaCaption || caption;
						copyPage.setLocalizableStringPropertyValue("caption", caption);
						copyPage.setPropertyValue("packageUId", packageUId);
						copyPage.define(next, this);
					},
					function(next) {
						BPMSoft.SysModuleEditManager.createItem(next, this);
					},
					function(next, moduleEdit) {
						moduleEdit.setSysModuleEntityId(sysModuleEntityUId);
						moduleEdit.setCardSchemaUId(copyPage.uId);
						moduleEdit.setActionKindName(copyPage.name);
						this._setModuleEditType(moduleEdit, type, caption);
						BPMSoft.SysModuleEditManager.addItem(moduleEdit);
						this._loadPageList(next, this);
					},
					function(next) {
						BPMSoft.TimelineManager.copyTimelinePageConfig({
							sourceKey: sourcePage.name,
							targetKey: copyPage.name,
							packageUId
						}, next, this);
					},
					function(next) {
						this._openSectionPageWizard(copyPage.uId, next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * Remove grid data item by id.
			 * @param {BPMSoft.configuration.SectionPageSettingsItemModel} item Grid data item.
			 * @param {Function} [callback] The callback function.
			 * @param {Object} [scope] The scope of callback function.
			 */
			removeModelItem: function(item, callback, scope) {
				BPMSoft.chain(
					function(next) {
						const message = resources.localizableStrings.DeleteConfirmationMessage;
						BPMSoft.showConfirmation(message, function(returnCode) {
							if (returnCode === "yes") {
								next();
							}
						}, ["yes", "no"], this);
					},
					function(next) {
						const moduleEditId = item.get("Id");
						const schemaUId = item.get("SchemaUId");
						BPMSoft.ClientUnitSchemaManager.remove(schemaUId);
						BPMSoft.SysModuleEditManager.remove(moduleEditId);
						this._tryConvertSectionToSinglePageSection(next, this);
					},
					function(next) {
						this._fillGridData(next, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * Generates entity schema caption by type.
			 * @param {Object} type Type lookup value.
			 * @return {String}
			 */
			generateEntitySchemaCaption: function(type) {
				let caption;
				const entitySchema = this.getModuleEntitySchema();
				const entitySchemaCaption = (entitySchema.caption || "").toString();
				if (type) {
					const template = this.get("Resources.Strings.MultiEditPageCaptionTemplate");
					caption = Ext.String.format(template, entitySchemaCaption, type.displayValue);
				} else {
					const template = this.get("Resources.Strings.SingleEditPageCaptionTemplate");
					caption = Ext.String.format(template, entitySchemaCaption);
				}
				return caption;
			}

			// endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "MainPageSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["section-page-settings-container"]},
					"items": [
						{
							"name": "PageSettingsLabelContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["section-settings-label-container"]},
							"items": [
								{
									"name": "PageSettingsLabel",
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": {"bindTo": "Resources.Strings.SectionPageSettingsGroupCaption"},
									"labelClass": ["section-settings-label"]
								}
							]
						},
						{
							"name": "BlankSlateContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["blank-slate-container"]},
							"visible": {
								"bindTo": "GridData",
								"bindConfig": {"converter": "isEmptyValue"}
							},
							"items": [
								{
									"name": "BlankSlateImageContainer",
									"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
									"onPhotoChange": BPMSoft.emptyFn,
									"getSrcMethod": "_getPageBlankSlateImage"
								},
								{
									"name": "BlankSlateRightContainer",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"classes": {"wrapClassName": ["blank-slate-right-container"]},
									"items": [
										{
											"name": "BlankSlateDescriptionControl",
											"generator": "HtmlControlGeneratorV2.generateHtmlControl",
											"htmlContent": {"bindTo": "BlankSlateDescription"},
											"classes": {"wrapClass": ["description-label"]}
										},
										{
											"name": "SetupPagesButton",
											"itemType": BPMSoft.ViewItemType.BUTTON,
											"caption": {"bindTo": "Resources.Strings.SetupPageButtonCaption"},
											"click": {"bindTo": "onSetupPageButtonClick"},
											"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
											"enabled": {"bindTo": "canEdit"}
										}
									]
								}
							]
						},
						{
							"name": "PageSettingsContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["page-settings-container"]},
							"visible": {
								"bindTo": "GridData",
								"bindConfig": {"converter": "isNotEmptyValue"}
							},
							"items": [
								{
									"name": "SinglePageContainer",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"classes": {"wrapClassName": ["single-page-container"]},
									"visible": {
										"bindTo": "GridData",
										"bindConfig": {"converter": "isSinglePageContainerVisible"}
									},
									"items": [
										{
											"name": "SinglePageButton",
											"itemType": BPMSoft.ViewItemType.BUTTON,
											"caption": {"bindTo": "Resources.Strings.SinglePageButtonCaption"},
											"click": {"bindTo": "onSinglePageButtonClick"},
											"classes": {"wrapperClass": ["page-caption-button"]},
											"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
											"menu": {
												"items": [
													{
														"markerValue": "EditPageActionItem",
														"caption": resources.localizableStrings.EditPageActionItemCaption,
														"click": {"bindTo": "onEditSinglePage"}
													},
													{
														"markerValue": "RenamePageActionItem",
														"caption": resources.localizableStrings.RenamePageActionItemCaption,
														"click": {"bindTo": "onRenameSinglePage"},
														"enabled": {"bindTo": "canRenameSinglePage"}
													},
													{
														"markerValue": "CopyPageActionItem",
														"caption": resources.localizableStrings.CopyPageActionItemCaption,
														"click": {"bindTo": "onCopySinglePage"}
													},
													{
														"markerValue": "RemovePageActionItem",
														"caption": resources.localizableStrings.RemovePageActionItemCaption,
														"click": {"bindTo": "onRemoveSinglePage"}
													}
												]
											}
										}
									]
								},
								{
									"name": "MultiPageContainer",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"classes": {"wrapClassName": ["multi-page-container"]},
									"visible": {
										"bindTo": "GridData",
										"bindConfig": {"converter": "isMultiPageContainerVisible"}
									},
									"items": [
										{
											"name": "DataGridHeader",
											"itemType": BPMSoft.ViewItemType.CONTAINER,
											"classes": {"wrapClassName": ["data-grid-header"]},
											"items": [
												{
													"name": "PageCaption",
													"itemType": BPMSoft.ViewItemType.LABEL,
													"caption": {"bindTo": "Resources.Strings.PageColumnCaption"}
												},
												{
													"name": "PageType",
													"itemType": BPMSoft.ViewItemType.LABEL,
													"classes": {"labelClass": ["page-type-column"]},
													"caption": {
														"bindTo": "TypeColumn",
														"bindConfig": {"converter": "getPageTypeHeaderCaption"}
													}
												},
												{
													"name": "PageTypeSettings",
													"itemType": BPMSoft.ViewItemType.BUTTON,
													"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
													"classes": {"wrapperClass": ["page-type-settings-button"]},
													"imageConfig": {"bindTo": "Resources.Images.PageTypeSettings"},
													"click": {"bindTo": "onPageTypeSettingsButtonClick"},
													"hint": {"bindTo": "Resources.Strings.PageTypeSettingsHint"}
												}
											]
										},
										{
											"name": "PagesContainerList",
											"generator": "ConfigurationItemGenerator.generateContainerList",
											"idProperty": "Id",
											"itemPrefix": "Id",
											"collection": "GridData",
											"rowCssSelector": ".pageItemContainer",
											"classes": {"wrapClassName": ["pages-container-list"]},
											"defaultItemConfig": {
												"itemType": BPMSoft.ViewItemType.CONTAINER,
												"id": "item",
												"wrapClass": ["page-item-container"],
												"items": [
													{
														"name": "PageCaptionButton",
														"itemType": BPMSoft.ViewItemType.BUTTON,
														"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
														"caption": {"bindTo": "Caption"},
														"click": {"bindTo": "onMultiPageItemClick"},
														"markerValue": {"bindTo": "getPageCaptionButtonMarker"},
														"classes": {"wrapperClass": ["page-caption-button"]},
														"menu": {
															"items": [
																{
																	"markerValue": "EditPageActionItem",
																	"caption": resources.localizableStrings.EditPageActionItemCaption,
																	"click": {"bindTo": "onEditPageActionItem"}
																},
																{
																	"markerValue": "RenamePageActionItem",
																	"caption": resources.localizableStrings.RenamePageActionItemCaption,
																	"click": {"bindTo": "onRenamePageActionItem"},
																	"enabled": {"bindTo": "CanRenameSchema"}
																},
																{
																	"markerValue": "CopyPageActionItem",
																	"caption": resources.localizableStrings.CopyPageActionItemCaption,
																	"click": {"bindTo": "onCopyPageActionItem"}
																},
																{
																	"markerValue": "RemovePageActionItem",
																	"caption": resources.localizableStrings.RemovePageActionItemCaption,
																	"click": {"bindTo": "onRemovePageActionItem"}
																}
															],
															"alignType": "tr-br?"
														}
													},
													{
														"name": "PageTypeLookup",
														"itemType": BPMSoft.ViewItemType.COMPONENT,
														"className": "BPMSoft.ComboBoxEdit",
														"list": {"bindTo": "TypeList"},
														"value": {"bindTo": "Type"},
														"enableLocalFilter": false,
														"tag": "Type",
														"change": {"bindTo": "onLookupChange"},
														"enabled": {"bindTo": "isTypeEnabled"},
														"markerValue": {"bindTo": "getPageTypeLookupMarker"},
														"classes": {"wrapClass": ["page-type-lookup"]},
														"controlConfig": {"placeholder": resources.localizableStrings.PageTypeLookupPlaceholder}
													}
												]
											}
										}
									]
								},
								{
									"name": "AddPageButton",
									"itemType": BPMSoft.ViewItemType.BUTTON,
									"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
									"classes": {"wrapperClass": ["add-page-button"]},
									// "imageConfig": {"bindTo": "Resources.Images.AddPageButtonImage"},
									"caption": {"bindTo": "Resources.Strings.AddPageButtonCaption"},
									"click": {"bindTo": "onAddPageButtonClick"}
								}
							]
						}
					]
				}
			}
		]
	};
});
