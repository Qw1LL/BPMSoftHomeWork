define("FileDetailV2", [
	"ViewUtilities", "ConfigurationConstants", "ConfigurationEnums", "DefaultProfileHelper", "ServiceHelper", "FileUploadErrorHandlers",
	"VanillaboxMin", "ImageListViewModel", "FileDownloader", "ConfigurationFileApi",
	"css!FileDetailCssModule", "css!VanillaboxCSS"],
	function(ViewUtilities, ConfigurationConstants, ConfigurationEnums, DefaultProfileHelper, ServiceHelper) {
	return {
		mixins: {
			FileUploadErrorHandlers : "BPMSoft.FileUploadErrorHandlers"
		},
		properties: {

			/**
			 * Files group identifier, that is needed for vanillabox plugin.
			 * @protected
			 * @type {String}
			 */
			groupId: null,

			/**
			 * Property, that stores vanillabox object.
			 * @protected
			 * @type {Object}
			 */
			vanillaboxContainer: null,

			/**
			 * Property, that stores ShowPreview system setting.
			 * @protected
			 * @type {Boolean}
			 */
			isShowPreview: null,

			/**
			 * Vanillabox options config.
			 * @protected
			 * It can contains such values
			 * {
					 *   animation: 'none',
					 *   closeButton: true,
					 *   keyboard: true,
					 *   loop: true,
					 *   preferredWidth: 800,
					 *   preferredHeight: 600,
					 *   repositionOnScroll: true,
					 *   type: 'image',
					 *   adjustToWindow: 'both',
					 *   grouping: true
					 * }
			 * for more information visit https://cocopon.me/app/vanillabox/
			 */
			vanillaboxDefaultConfig: {
				closeButton: true,
				loop: true,
				repositionOnScroll: true
			},

			/**
			 * List default grid columns.
			 * @protected
			 * @type {String[]}
			 */
			defaultGridColumnNames: ["Name", "Notes", "Type", "CreatedOn", "CreatedBy"],

			/**
			 * @private
			 */
			_isDenyEditAttachedFileDescriptionEnabled: false
		},
		attributes: {
			/**
			 * Save the name of the editing card
			 */
			"SchemaCardName": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * ######### ########## ######.
			 * @protected
			 */
			Extensions: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * @type {Boolean}
			 */
			isImageManagerDetailView: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value:true
			},
			/**
			 * @type {Boolean}
			 */
			isAddFileButtonInListedModeVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * @type {Boolean}
			 */
			isAddFileButtonInTiledModeVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * @type {Boolean}
			 */
			isAnyItemSelected: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * ############ ############# ######## ###########.
			 * @type {Object}
			 */
			ItemViewConfig: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Parent entity.
			 */
			parentEntity: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * ### ###### ## ######.
			 */
			cacheEntityLink: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * ############ #### ########.
			 */
			entityTypeConfig: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * #######, ####### ######### ## ##, ### ######## - ######.
			 * @readonly
			 */
			isLink: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * #######, ####### ######### ## ##, ### ######## - ####.
			 * @readonly
			 */
			isFile: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * #######, ####### ######### ## ##, ### ######## - ###### ## ######.
			 * @readonly
			 */
			isEntityLink: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		messages: {
			"ItemSelected": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},

		methods: {

			// region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#init
			 * @overridden
			 */
			init: function() {
				this.set("SchemaCardName", "LinkPageV2");
				this.initParentEntity();
				this.initFileUploadErrorHadlers();
				this.callParent(arguments);
				const cardModuleId = this.sandbox.id + "LinkPageV2";
				this.sandbox.subscribe("getCardInfo", this.getCardInfoConfig.bind(this), [cardModuleId]);
				this.set("isAnyItemSelected", false);
				this.set("Extensions", this.Ext.create("BPMSoft.Collection"));
				this.on("change:SelectedRows", function(model, value) {
					this.set("isAnyItemSelected", !this.Ext.isEmpty(value));
				}, this);
				this.on("change:ActiveRow", function(model, value) {
					this.set("isAnyItemSelected", !this.Ext.isEmpty(value));
				}, this);
				this.on("change:MasterRecordId", this.onMasterRecordIdChanged, this);
				this._isDenyEditAttachedFileDescriptionEnabled =
					this.BPMSoft.Features.getIsEnabled("DenyEditAttachedFileDescription");
				this.getShowPreviewSettingsValue();
			},

			/**
			 * Get ShowPreview system settings value.
			 */
			getShowPreviewSettingsValue: function() {
				this.BPMSoft.SysSettings.querySysSettingsItem("ShowPreview", function(settingsValue) {
					this.isShowPreview = settingsValue;
				}, this);
			},

			/**
			 * ####### ######## ## #######.
			 */
			destroy: function() {
				this.un("change:MasterRecordId", this.onMasterRecordIdChanged, this);
				this.callParent(arguments);
			},

			/**
			 * ############ ####### ######### ########### ############## ######.
			 * @param {Object} model Backbone ######.
			 * @param {Guid} value ########## ############# ######.
			 */
			onMasterRecordIdChanged: function(model, value) {
				const parentEntity = this.parentEntity;
				if (parentEntity && parentEntity.RecordId) {
					parentEntity.RecordId = value;
				}
			},

			/**
			 * ######## ###### #### ###### ## ########.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ##########.
			 */
			updateEntityLinkCache: function(callback, scope) {
				const esq = this.getEntityLink();
				esq.getEntityCollection(function(response) {
					if (response && response.success && response.collection) {

						var entityLinkCollection = this.prepareEntityLinkCollection(response.collection);
						this.prepareCacheEntityLink(entityLinkCollection);

						this.Ext.callback(callback, scope || this);

					} else {

						this._onQueryErrorResponse(response);

					}
				}, this);
			},

			prepareEntityLinkCollection: function(collection) {
				const collectionItems = collection.getItems();
				const collectionToCache = collectionItems.map(function(item) {
					const model = item.model;
					if (model) {
						return model.toJSON();
					} else {
						return {};
					}
				});

				return collectionToCache;

			},
			/**
			 * ############## ###### ##### #########.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ##########.
			 */
			initEntityType: function(callback, scope) {
				const esq = this.getEntityType();
				esq.getEntityCollection(function(response) {
					if (response && response.success && response.collection) {
						const collection = response.collection.getItems();
						this.prepareEntityTypeConfig(collection);
						const toolsButtonMenu = this.get("ToolsButtonMenu");
						this.addEntityOperationsMenuItems(toolsButtonMenu);
						if (callback) {
							callback.call(scope || this);
						}
					} else {
						this._onQueryErrorResponse(response);
					}
				}, this);
			},

			/**
			 * ############# ############ ##### #########.
			 * @param {Array} collection ###### #######.
			 */
			prepareEntityTypeConfig: function(collection) {
				this.entityTypeConfig = this.Ext.create("BPMSoft.Collection");
				this.BPMSoft.each(collection, this.addEntityType, this);
			},

			/**
			 * ############## ###### ####.
			 * @param {Array} collection ###### #######.
			 */
			prepareCacheEntityLink: function(collection) {

				this.cacheEntityLink = this.Ext.create("BPMSoft.Collection");
				this.BPMSoft.each(collection, function(item) {

					const data = Ext.JSON.decode(item.Data);
					if (data) {

						this.cacheEntityLink.add(item.Id, {
							"name": item.Name,
							"entityName": data.entitySchemaName,
							"recordId": data.recordId
						}, this);

					}

				}, this);

			},

			/**
			 * ######### ##### ####### ##-#########.
			 */
			setDefaultEntityType: function() {
				this.isFile = false;
				this.isLink = false;
				this.isEntityLink = false;
			},

			/**
			 * ########## ### ########.
			 * @param {Object} item
			 */
			defineEntityType: function(item) {
				this.setDefaultEntityType();
				const entityType = item.get("Type");
				const entityTypeId = entityType.value;
				if (entityTypeId === ConfigurationConstants.FileType.File) {
					this.isFile = true;
				}
				if (entityTypeId === ConfigurationConstants.FileType.Link) {
					this.isLink = true;
				}
				if (entityTypeId === ConfigurationConstants.FileType.EntityLink) {
					this.isEntityLink = true;
				}
			},

			/**
			 * ########## ############ ### ######## # ######## ##########.
			 * @overridden
			 */
			getCardInfoConfig: function() {
				const detailInfo = {
					valuePairs: this.get("DefaultValues") || []
				};
				detailInfo.typeColumnName = this.parentEntity.EntityName;
				detailInfo.typeUId = this.parentEntity.RecordId;
				return detailInfo;
			},

			/**
			 * Initializes parent entity.
			 */
			initParentEntity: function() {
				this.parentEntity = {};
				const entitySchemaName = this.entitySchema && this.entitySchema.name || "";
				const parentSchemaName = entitySchemaName.replace("File", "");
				const masterRecordId = this.get("MasterRecordId");
				this.parentEntity.EntityName = parentSchemaName;
				this.parentEntity.RecordId = masterRecordId;
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#getEditPagesSandboxIds
			 * @overridden
			 */
			getEditPagesSandboxIds: function() {
				return [this.sandbox.id + this.get("SchemaCardName")];
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#getEditRecordButtonEnabled
			 * @overridden
			 */
			getEditRecordButtonEnabled: function() {
				let isSingleSelect = this.isSingleSelected();
				if (!this._isDenyEditAttachedFileDescriptionEnabled) {
					return isSingleSelect;
				}
				if (!isSingleSelect) {
					return false;
				}
				const activeRow = this.getActiveRow();
				return (activeRow.get("Type").value === ConfigurationConstants.FileType.Link);
			},

			/**
			 * ########## ######.
			 */
			addLinkRecord: function() {
				const editPageUId = BPMSoft.GUID_EMPTY;
				const isNewRecord = this.getIsNewRecord();
				if (isNewRecord) {
					this.sandbox.subscribe("CardSaved", function() {
						this.openCard(ConfigurationEnums.CardStateV2.ADD, editPageUId, null);
					}, this, [this.sandbox.id]);
					const config = {
						isSilent: true,
						messageTags: [this.sandbox.id]
					};
					this.sandbox.publish("SaveRecord", config, [this.sandbox.id]);
				} else {
					this.openCard(ConfigurationEnums.CardStateV2.ADD, editPageUId, null);
				}
			},

			/**
			 * ########## ###### ## ########.
			 * @param {String} entityName ######## ########.
			 */
			addEntityLinkRecord: function(entityName) {
				const filters = this.getEntityFilter(entityName);
				const configLookup = {
					entitySchemaName: entityName,
					multiSelect: true,
					filters: filters
				};
				const isNewRecord = this.getIsNewRecord();
				if (isNewRecord) {
					this.sandbox.subscribe("CardSaved", function() {
						this.openLookup(configLookup, this.saveSelectedRecords.bind(this, entityName), this);
					}, this, [this.sandbox.id]);
					const config = {
						isSilent: true,
						messageTags: [this.sandbox.id]
					};
					this.sandbox.publish("SaveRecord", config, [this.sandbox.id]);
				} else {
					this.openLookup(configLookup, this.saveSelectedRecords.bind(this, entityName), this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#onDeleted
			 * @overridden
			 */
			onDeleted: function(record) {
				this.set("SelectedRows", []);
				this.reloadCollectionData();
				if (record && record.Success) {
					const deletedItems = record.DeletedItems;
					this.BPMSoft.each(deletedItems, function(item) {
						this.cacheEntityLink.removeByKey(item);
					}, this);
				}
				this.callParent(arguments);
			},

			/**
			 * ######### #######, ### ########### #########.
			 * @param {String} entityName ######## ########.
			 * @return {BPMSoft.data.filters.FilterGroup} ########## ###### ########.
			 */
			getEntityFilter: function(entityName) {
				const filterGroup = this.BPMSoft.createFilterGroup();
				if (!this.Ext.isEmpty(this.cacheEntityLink)) {
					this.cacheEntityLink.each(function(item) {
						if (item.entityName === entityName) {
							const idFilter = this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", item.recordId);
							filterGroup.addItem(idFilter);
						}
					}, this);
				}
				return filterGroup;
			},

			/**
			 * ########## ######## ########### ###### ############## ######.
			 * @return {Array} ######## ########### ###### ############## ######.
			 */
			generateButtonMenuItems: function() {
				const itemsConfig = [];
				if (!this.Ext.isEmpty(this.entityTypeConfig)) {
					this.entityTypeConfig.eachKey(function(entityName, item) {
						const addMethodName = "add" + entityName + "Record";
						this[addMethodName] = this.addEntityLinkRecord.bind(this, entityName);
						itemsConfig.push({
							"viewModelItem": this.getButtonMenuItem({
								Caption: item.menuItemCaption,
								Click: {"bindTo": addMethodName},
								Visible: {"bindTo": "getAddRecordButtonVisible"}
							}),
							"position": item.position,
							"key": entityName + "Item"
						});
					}, this);
				}
				return itemsConfig;
			},

			/**
			 * ######### # ####### ###### ## ########.
			 * @param {String} entityName ######## ########.
			 * @param {Object} config ###### #### {columnName: string, selectedRows: []}.
			 **/
			saveSelectedRecords: function(entityName, config) {

				const selectedRows = config.selectedRows.getItems();
				if (!selectedRows || !selectedRows.length) {
					return;
				}

				var insertedIds = [];
				const batchQuery = this.Ext.create("BPMSoft.BatchQuery");

				this.BPMSoft.each(selectedRows, function(item) {

					var newId = this.BPMSoft.generateGUID();
					var insertLinkQuery = this.getInsertEntityLink(item, entityName);
					insertLinkQuery.setParameterValue(this.entitySchema.primaryColumnName, newId, BPMSoft.DataValueType.GUID);
					insertedIds.push(newId);

					batchQuery.add(insertLinkQuery);
				}, this);

				batchQuery.add(this.getEntityLink(), function(response) {
					if (response && response.success && response.collection) {

						var entityLinkCollection = this.prepareEntityLinkCollection(response.collection);
						this.prepareCacheEntityLink(entityLinkCollection);

					}
				}, this);
				batchQuery.add(this.getInsertedEntities(insertedIds), this.addInsertedRecordToGrid, this);

				batchQuery.execute();

			},

			/**
			 * ######### ###### ## ########.
			 * @param {Object} item ###### ########.
			 * @param {Object} entityName ######## ########.
			 * @return {BPMSoft.InsertQuery}
			 */
			getInsertEntityLink: function(item, entityName) {

				const data = {
					entitySchemaName: entityName,
					recordId: item.value
				};
				const insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: this.entitySchemaName
				});

				insert.setParameterValue("Name", item.Name, BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("Data", Ext.JSON.encode(data), BPMSoft.DataValueType.BLOB);
				insert.setParameterValue(this.parentEntity.EntityName, this.parentEntity.RecordId,
						BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Type", ConfigurationConstants.FileType.EntityLink,
						BPMSoft.DataValueType.GUID);

				return insert;

				},

			getInsertedEntities: function(selectedIds) {

				const esq = this.getGridDataESQ();
				this.initQueryColumns(esq);
				this.initQuerySorting(esq);
				this.initQueryFilters(esq);
				this.initQueryEvents(esq);
				esq.filters.addItem(
					this.BPMSoft.createColumnInFilterWithParameters(this.entitySchema.primaryColumnName, selectedIds)
				);

				return esq;
			},

			addInsertedRecordToGrid: function(response) {

				this.updateLoadedGridData(response, this.onGridDataLoaded, this);

			},

			/**
			 * ########## ## ##### ######### ####### ## id.
			 * @param {String} id ############# ########.
			 * @return {Object} ###### ########.
			 */
			getEntityLinkCacheById: function(id) {
				if (!this.Ext.isEmpty(this.cacheEntityLink)) {
					return this.cacheEntityLink.get(id);
				}
				return null;
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getOpenCardConfig: function() {
				const config = this.callParent(arguments);
				return this.Ext.apply(config, {
					moduleId: this.sandbox.id + this.get("SchemaCardName"),
					entitySchemaName: this.entitySchemaName
				});
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initEditPages: function() {
				const collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				const typeUId = this.BPMSoft.GUID_EMPTY;
				collection.add(typeUId, this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Tag: typeUId,
						SchemaName: this.get("SchemaCardName")
					}
				}));
				this.set("EditPages", collection);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#linkClicked
			 * @overridden
			 */
			linkClicked: function(rowId) {
				const collection = this.getGridData();
				const record = collection.get(rowId);
				if (record.isEntityLink) {
					const recordId = record.get("Id");
					this.openCardEntity(recordId);
					return false;
				}
			},

			/**
			 * ######### ######## #######.
			 * @param {String} id ############# ######.
			 */
			openCardEntity: function(id) {
				const entityLink = this.getEntityLinkCacheById(id);
				if (!this.Ext.isEmpty(entityLink)) {
					const entityId = entityLink.recordId;
					const entityStructure = this.getEntityStructure(entityLink.entityName);
					const pages = entityStructure.pages;
					if (!this.Ext.isEmpty(pages)) {
						const cardModuleId = this.sandbox.id + "_" + pages[0].cardSchema;
						const operation = ConfigurationEnums.CardStateV2.EDIT;
						const openCardConfig = {
							moduleId: cardModuleId,
							schemaName: pages[0].cardSchema,
							operation: operation,
							id: entityId
						};
						this.sandbox.publish("OpenCard", openCardConfig, [this.sandbox.id]);
					}
				}
			},

			/**
			 * ########## ############ ### ############ ###### ## ########.
			 * @param {String} id ############# #######.
			 * @return {Object} URL ######.
			 */
			getEntityLinkConfigById: function(id) {
				const entityLink = this.getEntityLinkCacheById(id);
				if (!this.Ext.isEmpty(entityLink)) {
					const entityLinkId = entityLink.recordId;
					const entitySchemaName = entityLink.entityName;
					return this.createLink(entitySchemaName, "Id", "Name", entityLinkId);
				}
			},

			/**
			 * ########## ######## ######### ######### # ####### ######## ########### ########.
			 * @param {String} entityName ######## ########.
			 * @return {String} ######## ######### #########.
			 */
			getSysSettingImageByEntityName: function(entityName) {
				if (!this.Ext.isEmpty(this.entityTypeConfig) && this.entityTypeConfig.contains(entityName)) {
					const entityConfig = this.entityTypeConfig.get(entityName);
					return entityConfig.sysSettingImage;
				} else {
					return "KnowledgeBaseImage";
				}
			},

			/**
			 * @inheritdoc GridUtilitiesV2#createViewModel
			 * @overridden
			 */
			createViewModel: function(config) {
				this.callParent(arguments);
				this.bindItemViewModelMethods(config.viewModel);
			},

			/**
			 * Bind image list view model item to methods in detail.
			 * @protected
			 * @param {BPMSoft.ImageListViewModel} viewModel
			 */
			bindItemViewModelMethods: function(viewModel) {
				viewModel.getEntityLinkConfigById = this.getEntityLinkConfigById.bind(this);
				viewModel.openCardEntity = this.openCardEntity.bind(this);
				viewModel.setDefaultEntityType = this.setDefaultEntityType;
				viewModel.defineEntityType = this.defineEntityType;
				viewModel.getEntityLinkCacheById = this.getEntityLinkCacheById.bind(this);
				viewModel.getSysSettingImageByEntityName = this.getSysSettingImageByEntityName.bind(this);
			},

			/**
			 * ######### #####, ############ ############ ###### # ###### #######
			 * @overridden
			 */
			addColumnLink: function(item, column) {
				const columnPath = column.columnPath;
				if (columnPath === item.primaryDisplayColumnName) {
					const linkConfig = this.getColumnLinkConfig(item);
					item["on" + columnPath + "LinkClick"] = function() {
						const value = this.get(columnPath);
						return {
							caption: value,
							target: linkConfig.target,
							title: value,
							url: linkConfig.link
						};
					};
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * @override
			 * @param activeRow
			 * @param entity
			 * @param columnName
			 */
			setGridRowValueFromEntity: function(activeRow, entity, columnName) {
				this.callParent(arguments);
				this.addColumnLink(activeRow, activeRow.columns[columnName]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#onCardSaved
			 * overridden
			 */
			onCardSaved: function() {
				const config = this.get("FileUploadConfig");
				if (!this.Ext.isEmpty(config)) {
					this.upload(config, function() {
						this.set("FileUploadConfig", null);
					});
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#onRender
			 * overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				this.initDropzoneEvents();
				const mode = this.get("Mode");
				if (!mode) {
					this.setDefaultMode();
				}
				if(mode==="listed"){
					this.switchToListed();
				}
				if(mode==="tiled"){
					this.switchToTiled();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
			 * @overridden
			 */
			addRecordOperationsMenuItems: function(toolsButtonMenu) {
				const linkMenuItem = this.getAddLinkMenuItem();
				if (!this.Ext.isEmpty(linkMenuItem)) {
					toolsButtonMenu.addItem(linkMenuItem);
					toolsButtonMenu.addItem(this.getButtonMenuSeparator());
				}
				this.callParent(arguments);
			},

			/**
			 * ######### ######## # ######### ########### ###### ############## ######.
			 * @param {BPMSoft.core.collections.Collection} toolsButtonMenu ######### ########### ######.
			 */
			addEntityOperationsMenuItems: function(toolsButtonMenu) {
				const entityLink = this.generateButtonMenuItems();
				if (!this.Ext.isEmpty(entityLink)) {
					this.BPMSoft.each(entityLink, function(item) {
						toolsButtonMenu.insert(item.position, item.key, item.viewModelItem);
					}, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: function() {
				const menuItem = this.callParent(arguments);
				menuItem.set("Caption", {"bindTo": "Resources.Strings.ActionChangeSettingsCation"});
				menuItem.set("MarkerValue", {"bindTo": "Resources.Strings.ActionChangeSettingsCation"});
				return menuItem;
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#beforeLoadGridData
			 * @overridden
			 */
			beforeLoadGridData: function() {
				this.set("IsGridDataLoaded", false);
				if (!this.get("isImageManagerDetailView")) {
					this.set("IsGridLoading", true);
				}
				this.set("IsGridEmpty", false);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#loadGridData
			 * @overridden
			 */
			loadGridData: function() {

				this.BPMSoft.chain(
						function(next) {
							this.updateEntityLinkCache(next, this);
						},
						function(next) {
							this.beforeLoadGridData();
							next();
						},
						function(next) {
							const extensions = this.get("Extensions");
							if (extensions.getCount() > 0) {
								next();
							} else {
								this.loadExtensions(next);
							}
						},
						function() {
							this.loadContainerListData();
						},
						this);

			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetail#hideQuickFilterButton
			 * @overridden
			 */
			getHideQuickFilterButton: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetail#getQuickFilterButton
			 * @overridden
			 */
			getShowQuickFilterButton: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getIsCurrentGridRendered
			 * @overridden
			 */
			getIsCurrentGridRendered: function() {
				const currentGrid = this.getCurrentGrid();
				if (!this.get("isImageManagerDetailView")) {
					return this.callParent(arguments);
				} else {
					if (currentGrid) {
						currentGrid.rendered = false;
					}
					return false;
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#initQueryColumns
			 * @overridden
			 */
			initQueryColumns: function(esq) {
				this.callParent(arguments);
				this.initLoadFilesQueryColumns(esq);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#initQueryFilters
			 * @overridden
			 */
			initQueryFilters: function(esq) {
				const detailColumnName = this.get("DetailColumnName");
				var masterRecordId = this.get("MasterRecordId");
				if (masterRecordId == null) {
					masterRecordId = this.BPMSoft.GUID_EMPTY;
				}
				const filterGroup = this.getFilters();
				filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, detailColumnName, masterRecordId));
				esq.filters.add("entityFilterGroup", filterGroup);
			},

			/**
			 * ########## ######### ####### ######.
			 * @param {Boolean} value ######### ############# Image Manager.
			 * @return {Boolean} ######### ####### ######.
			 */
			getDataGridVisible: function(value) {
				return !value;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#switchGridMode
			 * @overridden
			 */
			switchGridMode: function() {
				this.deselectRows();
				const multiSelect = this.get("MultiSelect");
				this.set("MultiSelect", !multiSelect);
				this.reloadCollectionData();
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelClassName
			 * @overridden
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.ImageListViewModel";
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelConfig
			 * @overridden
			 */
			getGridRowViewModelConfig: function() {
				const config = this.callParent(arguments);
				this.Ext.apply(config, this.getAdditionalViewModelConfig());
				return config;
			},

			/**
			 * Config contains methods, needed for vanilla logic.
			 * @protected
			 * @returns {Object} config
			 */
			getAdditionalViewModelConfig: function() {
				return {
					Ext: this.Ext,
					BPMSoft: this.BPMSoft,
					sandbox: this.sandbox,
					methods: {
						imageContainerRender: this.setVanillaboxAttribute.bind(this),
						imageContainerReRender: this.setVanillaboxAttribute.bind(this)
					}
				};
			},

			/**
			 * Handles "itemsRendered" event, that has fired in ContainerList component.
			 */
			itemsRendered: function() {
				this._applyVanillaboxLogic();
			},

			/**
			 * ########### ######### ###### ##### ######### # ######.
			 * @overriden
			 * @param {BPMSoft.core.collections.Collection} collection ######### ######### #######.
			 */
			prepareResponseCollection: function(collection) {
				this.callParent(arguments);
				collection.each(function(item) {
					this.decorateItem(item);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @override
			 * @inheritdoc BPMSoft.GridUtilities#getProfile
			 */
			getProfile: function() {
				const profile = this.callParent(arguments);
				return BPMSoft.isEmpty(profile) || Ext.Object.isEmpty(profile) ? {isCollapsed: false} : profile;
			},

			/**
			 * @inheritDoc BPMSoft.BaseDetailV2#getToolsVisible
			 */
			getAddRecordButtonVisible: function() {
				return this.getToolsVisible() && this.get("CanEditMasterRecord");
			},

			/**
			 * @inheritDoc BPMSoft.BaseDetailV2#getToolsVisible
			 */
			getAddFileButtonInListedModeVisible: function() {
				return this.getToolsVisible() && this.get("isAddFileButtonInListedModeVisible") && this.get("CanEditMasterRecord");
			},

			/**
			 * @inheritDoc BPMSoft.BaseDetailV2#getToolsVisible
			 */
			getAddFileButtonInTiledModeVisible: function() {
				return this.getToolsVisible() && this.get("isAddFileButtonInTiledModeVisible") && this.get("CanEditMasterRecord");
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#initProfile
			 * @override
			 */
			initProfile: function () {
				this.callParent(arguments);
				this.initSortActionItems();
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#generateEntityProfile
			 * @override
			 */
			generateEntityProfile: function () {
				var entityShema = this.getGridEntitySchema();
				if (entityShema) {
					var defColumns = this._getDefaultGridViewColumns();
					return DefaultProfileHelper.getEntityProfile(this.getProfileKey(),
						entityShema.name, this.BPMSoft.GridType.LISTED, defColumns);
				} else {
					return {};
				}
			},

			/**
			 * ############## ######### ###### ############# ########.
			 * @protected
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ##########.
			 */
			initData: function(callback, scope) {
				this.callParent([this.initEntityType.bind(this, callback, scope), this]);
			},

			/**
			 * ########## ###### ## ####### ###### ##### #########.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.EntitySchemaQuery}
			 */
			getEntityType: function() {
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "EntityTypeLookup"
				});
				esq.addColumn("EntityName");
				esq.addColumn("MenuItemCaption");
				esq.addColumn("SysSettingImage");
				esq.addColumn("Position");
				return esq;
			},

			/**
			 * ########## ###### ## ####### ###### ###### ## ########.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.EntitySchemaQuery}
			 */
			getEntityLink: function() {
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.entitySchemaName
				});
				esq.addColumn("Id");
				esq.addColumn("Name");
				esq.addColumn("Data");
				esq.filters.addItem(esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, this.parentEntity.EntityName, this.parentEntity.RecordId));
				esq.filters.addItem(esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.FileType.EntityLink));

				return esq;
			},

			/**
			 * ########## #######, ####### ###### ########## ########.
			 * @protected
			 * @overridden
			 * @return {Object} ########## ###### ########-############ #######
			 */
			getGridDataColumns: function() {
				const baseGridDataColumns = this.callParent(arguments);
				const gridDataColumns = {
					"Type": {
						path: "Type"
					},
					"Version": {
						path: "Version"
					},
					"CreatedBy": {
						path: "CreatedBy"
					},
					"Notes": {
						path: "Notes"
					}
				};
				return this.Ext.apply(baseGridDataColumns, gridDataColumns);
			},

			/**
			 * ########## ######### ######## #####.
			 * @protected
			 * @return {Object} ######### ######## #####.
			 */
			getUploadConfig: function(files) {
				return {
					scope: this,
					onUpload: this.onUpload,
					onComplete: this.onComplete,
					onFileComplete: this.onFileComplete,
					entitySchemaName: this.entitySchema.name,
					columnName: "Data",
					parentColumnName: this.get("DetailColumnName"),
					parentColumnValue: this.get("MasterRecordId"),
					files: files,
					isChunkedUpload: true,
					oversizeErrorHandler: this.onFilesOversized
				};
			},

			/**
			 * ########## ####### ########## ######## ######. ######## ##### ########. #### ### ######## ########
			 * ######, ########## #########.
			 */
			onComplete: function() {
				this.hideBodyMask();
				this.onCompleteError();
			},

			/**
			 * ########## ####### ########## ######## #####. ########## ###### # #######. #### ### ######## ########
			 * ######, ######### ## # ###.
			 * @protected
			 */
			onFileComplete: function(error, xhr, file, options) {
				if (!error) {
					this.loadGridDataRecord(options.data.fileId);
				} else {
					this.onFileCompleteError(error, file);
				}
			},

			/**
			 * ########## ####### ########### ###### ############## ######, ########## ## ########## ######.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.BaseViewModel} ####### ########### ###### ############## ######, ########## ## ##########
			 * ######.
			 */
			getAddLinkMenuItem: function() {
				return this.getButtonMenuItem({
					Caption: {"bindTo": "Resources.Strings.AddLinkCaption"},
					Click: {"bindTo": "addLinkRecord"},
					Visible: {"bindTo": "getAddRecordButtonVisible"}
				});
			},

			/**
			 * Sets specified attributes, whis are needed for vanillabox plugin.
			 * @return {Object} Vanillabox configuration object.
			 * @protected
			 */
			setVanillaboxAttribute: function() {
				var groupId = this._getMessageFilesGroupId();
				var vanillaboxSelector = this.Ext.String.format("[vngrop]");
				if (this._isJqueryLoaded()) {
					var vanillaboxImages = $(".entity-image-view-class.vanillabox-selector").not(vanillaboxSelector);
					vanillaboxImages.attr("vngrop", groupId);
					vanillaboxImages.css("cursor", "pointer");
					vanillaboxImages.each(function(index, image) {
						image.setAttribute("href", image.src);
					});
				}
			},

			// endregion

			// region Methods: Private

			/**
			 * @private
			 */
			_getDefaultGridViewColumns: function () {
				var defColumns = BPMSoft.map(this.defaultGridColumnNames, function(columnName) {
					return BPMSoft.deepClone(this.columns[columnName]);
				}, this);
				return _.compact(defColumns);
			},

			/**
			 * ######### ############ #### ########.
			 * @private
			 * @param {Object} item ########## # ####.
			 * @param {String} item.EntityName ######## ########.
			 * @param {String} item.MenuItemCaption ####### # #### ############## ######.
			 * @param {String} item.SysSettingImage ######### ######### # ############ ########.
			 * @param {String} item.Position ####### ########### # #### ############## ######.
			 */
			addEntityType: function(item) {
				this.entityTypeConfig.add(item.get("EntityName"), {
					menuItemCaption: item.get("MenuItemCaption"),
					sysSettingImage: item.get("SysSettingImage"),
					position: item.get("Position")
				}, this);
			},

			/**
			 * @private
			 */
			_onQueryErrorResponse: function(response) {
				var exceptionInfo = {};
				if (response.errorInfo && response.errorInfo.message) {
					Ext.apply(exceptionInfo, {
						message: response.errorInfo.message
					});
				}
				throw new BPMSoft.UnknownException(exceptionInfo);
			},

			/**
			 * Returns the configuration of the link in the registry cell.
			 * @private
			 * @param {BPMSoft.BaseViewModel} item Record, click on which is processed.
			 */
			getColumnLinkConfig: function(item) {
				this.defineEntityType(item);
				const id = item.get("Id");
				const name = item.get("Name");
				let target = "_self";
				const click = null;
				let link;
				if (this.isFile) {
					link = BPMSoft.FileDownloader.getFileLink(this.entitySchema.uId, id);
				}
				if (this.isLink) {
					link = BPMSoft.addProtocolPrefix(name);
					target = "_blank";
				}
				if (this.isEntityLink) {
					const config = this.getEntityLinkConfigById(id);
					link = config.url;
				}
				return {
					target: target,
					link: link,
					click: click
				};
			},

			/**
			 * ########## ####### ###### #####.
			 * @private
			 * @param {Object} files #####, ############ FileAPI
			 */
			onFileSelect: function(files) {
				if (files.length <= 0) {
					return;
				}
				const config = this.getUploadConfig(files);
				const isNewRecord = this.getIsNewRecord();
				this.set("FileUploadConfig", config);
				if (isNewRecord) {
					const args = {
						isSilent: true,
						messageTags: [this.sandbox.id]
					};
					this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
				} else {
					this.upload(config, function() {
						this.set("FileUploadConfig", null);
					});
				}
			},

			/**
			 * Gets the state of the current record.
			 * @private
			 * @return {Boolean} True - is new record.
			 */
			getIsNewRecord: function() {
				const cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
				return (cardState.state === ConfigurationEnums.CardStateV2.ADD ||
						cardState.state === ConfigurationEnums.CardStateV2.COPY);
			},

			/**
			 * Uploads files using FileAPI.
			 * @private
			 * @param {Object} config File upload configuration.
			 * @param {Function} callback Callback.
			 */
			upload: function(config, callback) {
				this.BPMSoft.ConfigurationFileApi.upload(config, callback);
				this.set("IsGridEmpty", false);
				var mode=this.get("Mode");
				if(mode==="listed"){
					this.switchToListed();
				}
				if(mode==="tiled"){
					this.switchToTiled();
				}
			},

			/**
			 * ########## ####### ###### ######## ######. ########## ##### ########.
			 * @private
			 */
			onUpload: function() {
				this.showBodyMask();
			},

			/**
			 * ########## Url ########### ########## #####.
			 * @private
			 * @param {String} id ############# #####.
			 * @return {String} ###### ## ###########.
			 */
			getExtensionImageUrl: function(id) {
				return this.BPMSoft.ImageUrlBuilder.getUrl({
					source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
					params: {
						schemaName: "FileExtension",
						columnName: "Data",
						primaryColumnValue: id
					}
				});
			},

			/**
			 * ######### ######### ###### ##########.
			 * @private
			 * @param {BPMSoft.core.collections.Collection} collection ######### ####### ## ####### ##########.
			 * @param {Function} callback ####### ######### ######.
			 */
			fillExtensionsIcons: function(collection, callback) {
				const extensions = this.get("Extensions");
				this.BPMSoft.SysSettings.querySysSettingsItem("FileDetailDefaultIcon", function(response) {
					const defaultIconUrl = response
							? this.getExtensionImageUrl(response.value)
							: this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultIcon"));
					const defIconId = this.BPMSoft.generateGUID();
					extensions.add(defIconId, {
						"Extension": "default",
						"Url": defaultIconUrl
					});
					collection.each(function(item) {
						const extensionId = item.get("Id");
						const extensionName = item.get("Name").toLowerCase();
						const extensionUrl = this.getExtensionImageUrl(extensionId);
						if (extensionName !== "default") {
							extensions.add(extensionId, {
								"Extension": extensionName,
								"Url": extensionUrl
							});
						}
					}, this);
					if (callback) {
						callback.call(this);
					}
				}, this);
			},

			/**
			 * ######### Url ###### ########## ######.
			 * @private
			 * @param {Function} callback
			 */
			loadExtensions: function(callback) {
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "FileExtension"
				});
				esq.addColumn("Id");
				esq.addColumn("Name");
				esq.getEntityCollection(function(result) {
					if (result.success && result.collection) {
						this.fillExtensionsIcons(result.collection, callback);
					} else {
						Ext.callback(callback, this);
					}
				}, this);
			},

			/**
			 * ########## ########## #####.
			 * @private
			 * @param {String} imageName ######## ###########.
			 * @return {String} ##########.
			 */
			getExtensionFromName: function(imageName) {
				return imageName ? imageName.substring(imageName.lastIndexOf(".") + 1, imageName.length) : "";
			},

			/**
			 * ######### ########## ##### ## ### ###########.
			 * @private
			 * @param {String} extension ##########.
			 * @return {Boolean} ######### (true - ## ###########, false - ###########).
			 */
			isFileNotImage: function(extension) {
				return (extension.match(/(jpg|png|gif|bmp|jpeg)$/i) === null);
			},

			/**
			 * Determines, that file is an image, checking its extension.
			 * @private
			 * @param {String} extension File xtension.
			 * @return {Boolean} True, if file is image.
			 */
			_isFileImage: function(extension) {
				return !this.isFileNotImage(extension);
			},

			/**
			 * Return defaul image url.
			 * @private
			 */
			_getDefaultImageUrl: function() {
				const defaultImage = this.get("Resources.Images.DefaultImageIcon");
				return this.BPMSoft.ImageUrlBuilder.getUrl(defaultImage);
			},

			/**
			 * Return image url.
			 * @private
			 */
			_getFileContentUrl: function(item) {
				const fileId = item.$Id;
				const entitySchemaUid = item.entitySchema.uId;
				const url = ServiceHelper.buildConfigurationUrl('FileService', 'GetFile');
				return this.BPMSoft.combinePath(url, entitySchemaUid, fileId);
			},

			/**
			 * Initialize query columns.
			 * @private
			 * @param {BPMSoft.data.queries.EntitySchemaQuery} esq Entity schema query.
			 */
			initLoadFilesQueryColumns: function(esq) {
				if (!esq.columns.contains(this.primaryDisplayColumnName)) {
					esq.addColumn(this.primaryDisplayColumnName);
				}
				if (!esq.columns.contains("Type")) {
					esq.addColumn("Type");
				}
				if (!esq.columns.contains("CreatedBy")) {
					esq.addColumn("CreatedBy");
				}
				if (!esq.columns.contains("Notes")) {
					esq.addColumn("Notes");
				}
			},

			/**
			 * ########## ######## #######.
			 * @private
			 * @param {String} mode #####.
			 * @return {String} ######## #######.
			 */
			getDetailMarkerValue: function(mode) {
				const caption = this.get("Resources.Strings.Caption");
				return this.Ext.String.format("{0} {1}", caption, mode);
			},

			/**
			 * Changes detail mode.
			 * @private
			 * @param {String} value New mode.
			 */
			changeDetailMode: function(value) {
				const mode = this.get("Mode");
				if (value === mode) {
					return;
				}
				this.set("Mode", value);
				this.deselectRows();
				if(mode !== undefined){
					this.set("isImageManagerDetailView", mode === "listed");
				}
				else{
					this.set("isImageManagerDetailView", true);
				}
				
				this.reloadCollectionData();
			},

			/**
			 * Sets tiled mode.
			 * @private
			 */
			setTiledMode: function() {
				this.changeDetailMode("tiled");
				this.switchToTiled();
			},

			/**
			 * Sets listed mode.
			 * @private
			 */
			setListedMode: function() {
				this.changeDetailMode("listed");
				this.switchToListed();
			},

			getDropzone: function() {
				return document.getElementById("DragAndDropContainer");
			},

			reduceDropzone: function() {
				const dropzone=this.getDropzone();
				if(dropzone !== null) {
					dropzone.style.cssText=`
					height: 14em;
				`;
				}
			},

			resetDropzone: function() {
				const dropzone=this.getDropzone();
				dropzone.removeAttribute("style");
			},
			
			switchToListed: function() {
				if(!this.get("IsGridEmpty")) {
					this.reduceDropzone();
					const detail=document.querySelector(`[id$="FileDetailV2DetailControlGroup"]`);
					const newElement = document.getElementById("AddFilesTiledContainer");
					if(detail!==null&& newElement!==null){
						detail.appendChild(newElement);
					}
					this.set("isAddFileButtonInListedModeVisible",true);
				}
				else {
					this.resetDropzone();
					this.set("isAddFileButtonInListedModeVisible",false);
				}
				this.set("isAddFileButtonInTiledModeVisible",false);
			},
			
			switchToTiled: function() {
				if(!this.get("IsGridEmpty")) {
					this.reduceDropzone();
					const imageManagerContainer=document.getElementById("ImageManagerContainerContainerList");
					const newElement = document.getElementById("AddFilesTiledContainer");
					if(imageManagerContainer!==null && newElement!==null){
						imageManagerContainer.appendChild(newElement);
					}
					this.set("isAddFileButtonInTiledModeVisible",true);
				}
				else {
					this.resetDropzone();
					this.set("isAddFileButtonInTiledModeVisible",false);
				}
				
				this.set("isAddFileButtonInListedModeVisible",false);
			},

			/**
			 * Sets the default mode.
			 * @private
			 */
			setDefaultMode: function() {
				this.setTiledMode();
			},

			/**
			 * ######### ######### ######.
			 * @private
			 * @param {BPMSoft.BaseViewModelCollection} [currentCollection]
			 */
			reloadCollectionData: function(currentCollection) {
				const collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				const gridDataCollection = this.getGridData();
				collection.loadAll(gridDataCollection);
				if (currentCollection) {
					collection.loadAll(currentCollection);
				}
				gridDataCollection.clear();
				collection.each(this.decorateItem, this);
				gridDataCollection.loadAll(collection);
			},

			/**
			 * ########## ####### ##########.
			 * @private
			 * @param {BPMSoft.model.BaseViewModel} item ####### ######### #####.
			 */
			decorateItem: function(item) {
				const itemName = item.get("Name");
				const itemType = item.get("Type");
				if (!this.get("SelectedRows")) {
					this.set("SelectedRows", []);
				}
				Ext.applyIf(item.columns, this.columns);
				item.detail = this;
				item.isMultiSelect = this.get("MultiSelect");
				item.mode = this.get("Mode");
				if (itemType.value === ConfigurationConstants.FileType.EntityLink) {
					item.set("imageUrl", null);
					return;
				}
				const itemExtension = (itemType.value !== ConfigurationConstants.FileType.Link)
					? this.getExtensionFromName(itemName)
					: "url";
				if (this.isFileNotImage(itemExtension)) {
					const extensionsCollection = this.get("Extensions");
					const extensions = extensionsCollection.getItems();
					const existedExtensions = extensions.filter(function (extension) {
						return extension.Extension === itemExtension;
					});
					if (existedExtensions.length > 0) {
						item.set("imageUrl", existedExtensions[0].Url);
					} else {
						const defaultExtensions = extensions.filter(function (extension) {
							return extension.Extension === "default";
						});
						const defaultIconUrl = defaultExtensions[0] ? defaultExtensions[0].Url : null;
						item.set("imageUrl", defaultIconUrl);
					}
				} else if (this.isShowPreview) {
					const fileUrl = this._getFileContentUrl(item);
					item.set('imageUrl', fileUrl);
				} else {
					const defaultImageUrl = this._getDefaultImageUrl();
					item.set('imageUrl', defaultImageUrl);
				}
			},

			/**
			 * ######### ######### ###### ### ########## #############.
			 * @protected
			 */
			loadContainerListData: function() {
				const esq = this.getGridDataESQ();
				this.initQueryColumns(esq);
				this.initQuerySorting(esq);
				this.initQueryFilters(esq);
				this.initQueryOptions(esq);
				this.initQueryEvents(esq);
				const gridData = this.getGridData();
				const recordsCount = gridData.getCount();
				if (recordsCount > this.getRowCount()) {
					esq.rowCount = recordsCount;
				}
				esq.getEntityCollection(function(response) {
					this.destroyQueryEvents(esq);
					this.onGridDataLoaded(response);
				}, this);
			},


			/**
			 * @overridden
			 * @param {Object} response
			 */
			onGridDataLoaded:function(response){
				this.callParent(arguments);
				var mode=this.get("Mode");
				if(mode==="listed"){
					this.switchToListed();
				}
				if(mode==="tiled"){
					this.switchToTiled();
				}
			},

			/**
			 * ######### ############ ############# ######## ###########.
			 * @private
			 * @param {Object} itemConfig ###### ## ############ ######## # ContainerList.
			 */

			getItemViewConfig: function(itemConfig, item) {
				var imageWrapClasses = ["entity-image-view-class"];
				if (this._isFileImage(this.getExtensionFromName(item.values.Name)) && this.isShowPreview) {
					imageWrapClasses.push("vanillabox-selector");
				}
				const imagesListItemContainer = this.getImagesListItemContainerConfig(imageWrapClasses);
				itemConfig.config = imagesListItemContainer;
			},

			/**
			 * Returns configuration object for elements container.
			 * @private
			 * @param {Array} imageWrapClasses Wrap classes for ImageView component.
			 * @return {Object} Elements container configuration.
			 */
			getImagesListItemContainerConfig: function(imageWrapClasses) {
				const imagesListItemContainer =
						ViewUtilities.getContainerConfig("images-list-item-container", ["image-view-class"]);
				const entityImageWrapContainer =
						ViewUtilities.getContainerConfig("entity-image", ["entity-image-class"]);
				const selectEntityContainer =
						ViewUtilities.getContainerConfig("select-entity-container", ["select-entity-container-class"]);
				const checkBoxConfig = {
					className: "BPMSoft.CheckBoxEdit",
					classes: {wrapClass: ["entity-checked-class"]},
					visible: {"bindTo": "getIsMultiSelect"},
					checkedchanged: {"bindTo": "onSelectItem"},
					checked: {"bindTo": "getCheckItems"}
				};
				selectEntityContainer.items.push(checkBoxConfig);
				const imageContainer = ViewUtilities.getContainerConfig("entity-image-container",
						["entity-image-container-class"]);
				const imageViewConfig = {
					className: "BPMSoft.ImageView",
					imageSrc: {"bindTo": "getEntityImage"},
					classes: {wrapClass: imageWrapClasses},
					click: {"bindTo": "onEntityImageClick"}
				};
				imageContainer.items.push(imageViewConfig);
				imageContainer.afterrender = {"bindTo": "imageContainerRender"};
				imageContainer.afterrerender = {"bindTo": "imageContainerReRender"};
				const linkContainer = ViewUtilities.getContainerConfig("entity-link-container",
						["entity-link-container-class"]);
				linkContainer.afterrender = {"bindTo": "insertEntityLink"};
				linkContainer.afterrerender = {"bindTo": "insertEntityLink"};
				linkContainer.markerValue = {"bindTo": "getEntityText"};
				entityImageWrapContainer.items.push(selectEntityContainer, imageContainer, linkContainer);
				imagesListItemContainer.items.push(entityImageWrapContainer);
				imagesListItemContainer.markerValue = {bindTo: "getEntityText"};
				return imagesListItemContainer;
			},

			/**
			 * Button click event handler "Add File".
			 * @private
			 */
			onAddFileClick: BPMSoft.emptyFn,

			/**
			 * ############## ####### "drag" # "drop" ##########.
			 * @private
			 */
			initDropzoneEvents: function() {
				const dropZone = document.getElementById("DragAndDropContainer");
				if (!dropZone) {
					return;
				}
				if (!this.get("CanEditMasterRecord")) {
					return;
				}
				this.BPMSoft.ConfigurationFileApi.initDropzoneEvents(dropZone, function(over) {
					if (over) {
						dropZone.classList.add("dropzone-hover");
					} else {
						dropZone.classList.remove("dropzone-hover");
					}
				}, function(files) {
					this.onFileSelect(files);
				}.bind(this));
			},

			/**
			 * Gets vanillabox config.
			 * @private
			 * @return {Object} Vanillabox configuration object.
			 */
			_getVanillaboxConfig: function() {
				return Ext.apply({}, this.vanillaboxDefaultConfig);
			},

			/**
			 * Returns group identifier for grouping files from the message.
			 * @private
			 * @return {Guid} Files group identifier.
			 */
			_getMessageFilesGroupId: function() {
				if (this.groupId === null) {
					this.groupId = this.BPMSoft.generateGUID("N");
				}
				return this.groupId;
			},

			/**
			 * Checks jQuery load status.
			 * @return {boolean} False if jQuery isn't loaded.
			 * @private
			 */
			_isJqueryLoaded: function() {
				var $ = window.jQuery || window.$ || undefined;
				if (!$) {
					return false;
				}
				return true;
			},

			/**
			 * Applies vanillabox config.
			 * @private
			 */
			_applyVanillaboxLogic: function() {
				if (this.vanillaboxContainer !== null) {
					this.vanillaboxContainer.dispose();
				}
				var selector = this.Ext.String.format("[vngrop='{0}']", this._getMessageFilesGroupId());
				if (this._isJqueryLoaded()) {
					var $links = $(selector);
					if ($links.length) {
						this.vanillaboxContainer = $links.vanillabox(this._getVanillaboxConfig());
					}
				}
			},

			// endregion
		},

		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Detail",
				"values": {
					"markerValue": {
						bindTo: "Mode",
						bindConfig: {
							converter: "getDetailMarkerValue"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"visible": {
						"bindTo": "isImageManagerDetailView",
						"bindConfig": {"converter": "getDataGridVisible"}
					},
					"linkClick": {"bindTo": "linkClicked"}
				}
			},
			{
				"operation": "merge",
				"name": "AddRecordButton",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"tag": "addFileButton",
					"fileUpload": true,
					"filesSelected": {"bindTo": "onFileSelect"},
					"click": {"bindTo": "onAddFileClick"},
					"visible": false,
					"imageConfig": {"bindTo": "Resources.Images.AddFilesButtonForListedModeText"}
				}
			},
			{
				"operation": "insert",
				"parentName": "Detail",
				"name": "AddFiles Container",
				"propertyName": "items",
				"values":{
					"id": "AddFilesContainer",
					"selectors": {"wrapEl": "#AddFilesContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {"bindTo": "getAddFileButtonInListedModeVisible"},
					"items":[
						{
							"name": "AddFilesButtonForListedModeCrossButton",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"tag": "addFileButton",
							"fileUpload": true,
							"filesSelected": {"bindTo": "onFileSelect"},
							"click": {"bindTo": "onAddFileClick"},
							"hint": {"bindTo": "Resources.Strings.AddFilesButtonForListedModeText"},
							"classes": {
								"textClass": ["DragAndDropLabelLinkedText"]
							},
							"controlConfig": {
								"imageConfig": {"bindTo": "Resources.Images.ListedModeCrossButton"}
							}
						},
						{
							"name": "AddFilesButtonForListedMode",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"tag": "addFileButton",
							"fileUpload": true,
							"filesSelected": {"bindTo": "onFileSelect"},
							"click": {"bindTo": "onAddFileClick"},
							"hint": {"bindTo": "Resources.Strings.AddFilesButtonForListedModeText"},
							"classes": {
								"textClass": ["AddFileButtonLabel"]
							},
							"caption": {
								"bindTo": "Resources.Strings.AddFilesButtonForListedModeText"
							}
						}
					]
				}
			},
			{
				"operation": "insert",
				"parentName": "Detail",
				"name": "ImageManagerContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"generator": "ImageListConfigurationGenerator.generateContainerList",
					"idProperty": "Id",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"collection": "Collection",
					"observableRowNumber": 100,
					"wrapClassName": ["images-list-class"],
					"onGetItemConfig": "getItemViewConfig",
					"visible": "isImageManagerDetailView",
					"itemsRendered": "itemsRendered",
					"items":[]
				}
			},
			{
				"operation": "insert",
				"parentName": "Detail",
				"name": "AddFilesTiled Container",
				"propertyName": "items",
				"values":{
					"id": "AddFilesTiledContainer",
					"selectors": {"wrapEl": "#AddFilesTiledContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {"bindTo": "getAddFileButtonInTiledModeVisible"},
					"items":[
						{
							"name": "AddFilesButtonForTiledModeCrossButton",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"tag": "addFileButton",
							"fileUpload": true,
							"filesSelected": {"bindTo": "onFileSelect"},
							"click": {"bindTo": "onAddFileClick"},
							"visible": {"bindTo": "getAddFileButtonInTiledModeVisible"},
							"hint": {"bindTo": "Resources.Strings.AddFilesButtonForTiledModeText"},
							"classes": {
								"textClass": ["DragAndDropLabelLinkedText"],
								"imageClass": ["AddFilesButtonForTiledModeCrossButton"]
							},
							"controlConfig": {
								"imageConfig": {"bindTo": "Resources.Images.TiledModeCrossButton"}
							}
						},
						{
							"name": "AddFilesButtonForTiledModeLabel",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"tag": "addFileButton",
							"fileUpload": true,
							"filesSelected": {"bindTo": "onFileSelect"},
							"click": {"bindTo": "onAddFileClick"},
							"hint": {"bindTo": "Resources.Strings.AddFilesButtonForTiledModeText"},
							"classes": {
								"textClass": ["AddFileButtonTileModeLabel"]
							},
							"caption": {
								"bindTo": "Resources.Strings.AddFilesButtonForTiledModeText"
							}
						}
					]
				}
			},
			{
				"operation": "insert",
				"name": "DragAndDrop Container",
				"parentName": "Detail",
				"propertyName": "items",
				"values": {
					"id": "DragAndDropContainer",
					"selectors": {"wrapEl": "#DragAndDropContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["dropzone"],
					"items": [
						{
							"name": "DragAndDropFileLabel",
							"labelClass": ["DragAndDropLabel"],
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.DragAndDropCaption"}
						},
						{
							"name": "DragAndDropFileOrLabel",
							"labelClass": ["DragAndDropLabelOr"],
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.DragAndDropCaptionOrText"},
							"visible": {"bindTo": "getAddRecordButtonVisible"}
						},
						{
							"name": "DragAndDropFileLinkLabel",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"caption": {
								"bindTo": "Resources.Strings.DragAndDropCaptionLinkedText"
							},
							"tag": "addFileButton",
							"fileUpload": true,
							"filesSelected": {"bindTo": "onFileSelect"},
							"click": {"bindTo": "onAddFileClick"},
							"visible": {"bindTo": "getAddRecordButtonVisible"},
							"hint": {"bindTo": "Resources.Strings.DragAndDropCaptionLinkedText"},
							"classes": {
								"textClass": ["DragAndDropLabelLinkedText"]
							}
						}
					]
				}
			},
			{
				"operation": "insert",
				"name": "SetTiledModeButton",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "setTiledMode"},
					"visible": {"bindTo": "getToolsVisible"},
					"hint": {"bindTo": "Resources.Strings.TileViewButtonHint"},
					"controlConfig": {
						"imageConfig": {"bindTo": "Resources.Images.TiledViewIcon"}
					},
					"classes": {
						"wrapperClass": ["tiled-mode-button", "disable-left-margin"],
						"pressedClass": ["button-pressed"]
					},
					"markerValue": "tiled"
				}
			},
			{
				"operation": "insert",
				"name": "SetListedModeButton",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "setListedMode"},
					"visible": {"bindTo": "getToolsVisible"},
					"hint": {"bindTo": "Resources.Strings.ListViewButtonHint"},
					"controlConfig": {
						"imageConfig": {"bindTo": "Resources.Images.ListedViewIcon"}
					},
					"classes": {
						"wrapperClass": ["listed-mode-button"],
						"pressedClass": ["button-pressed"]
					},
					"markerValue": "listed"
				}
			},
			{
				"operation": "remove",
				"name": "FiltersContainer"
			}
		]
		/**SCHEMA_DIFF*/
	};
});
