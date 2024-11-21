 define("MLColumnSelectionSchema", ["ColumnSettingsUtilities", "MLModelColumnViewModel", "EntityColumnLookupMixin",
		"EntityStructureHelperMixin", "css!MLColumnSelectionModule"], function(ColumnSettingsUtilities) {
 	return {
 		mixins: {
			EntityColumnLookupMixin: "BPMSoft.EntityColumnLookupMixin",
			EntityStructureHelperMixin: "BPMSoft.EntityStructureHelperMixin"
		},
 		messages: {
			/**
			 * @message SetColumnsLookupInfo
			 * Gets selected columns from lookup page.
			 */
			"SetColumnsLookupInfo": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message GetColumnsLookupInfo
			 * Puts parameters info to columns lookup page.
			 */
			"GetColumnsLookupInfo": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ColumnSettingsInfo
			 * Subscription for the column settings info.
			 */
			"ColumnSettingsInfo": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message SelectedModelColumnsChanged
			 * Triggered, when collection of selected columns has been changed.
			 */
			"SelectedModelColumnsChanged": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message MLModelSaved
			 * Triggered, when parent ML model has been saved.
			 */
			"MLModelSaved": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetSelectionSchemaInfo
			 * Query for information about column selection schema.
			 */
			"GetSelectionSchemaInfo": {
				"direction": BPMSoft.MessageDirectionType.PUBLISH,
				"mode": BPMSoft.MessageMode.PTP
			},

			/**
			 * @message ColumnSetuped
			 * Subscription for the column setup.
			 */
			"ColumnSetuped": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * Schema to select columns from.
			 */
			"SelectionRootSchema": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP
			},

			/**
			 * Type of created columns.
			 */
			"MLColumnType": {
				"dataValueType": BPMSoft.DataValueType.GUID
			},

			/**
			 * Collection of selected columns.
			 */
			"ColumnCollection": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Identifier of parent ML model.
			 */
			"MLModelId": {
				"dataValueType": BPMSoft.DataValueType.GUID
			},

			/**
			 * Title of module.
			 */
			"ModuleTitle": {
				"dataValueType": BPMSoft.DataValueType.TEXT
			},

			/**
			 * Help button text.
			 */
			"HelpText": {
				"dataValueType": BPMSoft.DataValueType.TEXT
			},

			/**
			 * Indicates that ColumnCollection is empty.
			 */
			"IsColumnCollectionEmpty": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Card copy mode.
			 */
			"IsCardCopyMode": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			}
		},
		methods: {

			/**
			 * @private
			 * @param {String} modelId Identifier of the model, columns of which should be loaded.
			 */
			_queryModelColumns: function(modelId) {
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "MLModelColumn"
				});
				esq.addColumn("Id");
				esq.addColumn("ColumnUId");
				esq.addColumn("ColumnPath");
				esq.addColumn("AggregationType");
				esq.addColumn("SubFilters");
				esq.addColumn("Caption");
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "MLModel", modelId));
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "ColumnType", this.$MLColumnType));
				esq.getEntityCollection(function(response) {
					this._getExtendedColumnsInfoByPath(response.collection, this._loadColumnCollection, this);
				}, this);
			},

			/**
			 * @param {BPMSoft.BaseViewModelCollection} entities The collection of MLModel columns.
			 * @param {Function} callback The handler for columnsConfig created by entities.
			 * @param {Object} scope The callback scope.
			 * @private
			 */
			_getExtendedColumnsInfoByPath: function(entities, callback, scope) {
				const serviceParameters = [];
				if (Ext.isEmpty(this.$SelectionRootSchema)) {
					callback.call(scope, []);
					return;
				}
				const schemaName = this.$SelectionRootSchema.name;
				let columnsConfig;
				entities.each(function(entity) {
					const isSchemaColumn = !Ext.isEmpty(this._tryGetSelectionRootSchemaColumn(this.$ColumnCollection, {
						UId: entity.$UId,
						ColumnPath: entity.$ColumnPath
					}));
					if (!entity.$ColumnPath || isSchemaColumn) {
						return true;
					}
					serviceParameters.push({
						schemaName: schemaName,
						columnPath: entity.$ColumnPath,
						key: entity.$ColumnPath
					});
				}, this);
				if (serviceParameters.length === 0) {
					columnsConfig = this._getColumnsConfig(entities, []);
					callback.call(scope, columnsConfig);
					return;
				}
				this.getColumnPathCaption(this.Ext.JSON.encode(serviceParameters), function(extendedInfoArray) {
					columnsConfig = this._getColumnsConfig(entities, extendedInfoArray);
					callback.call(scope, columnsConfig);
				}, this);
			},

			/**
			 * @param {BPMSoft.BaseViewModelCollection} entities Collection of MLModelColumn.
			 * @param {Array} extendedInfoArray Array of linked column info (caption, data value types, etc.)
			 * @private
			 */
			_getColumnsConfig: function(entities, extendedInfoArray) {
				return entities.mapArray(function(entity) {
					const extendedInfo = BPMSoft.findItem(extendedInfoArray, {
						key: entity.$ColumnPath
					});
					let columnConfig;
					const id = !this.$IsCardCopyMode ? entity.$Id : BPMSoft.generateGUID();
					if (extendedInfo) {
						const itemInfo = extendedInfo.item;
						const isBackward = entity.$AggregationType !== BPMSoft.AggregationType.NONE;
						columnConfig = {
							Id: id,
							ColumnPath: entity.$ColumnPath,
							AggregationType: entity.$AggregationType,
							SubFilters: entity.$SubFilters,
							Name: entity.$ColumnPath,
							SchemaCaption: itemInfo.columnCaption,
							Caption: entity.$Caption || itemInfo.columnCaption,
							ReferenceSchemaName: itemInfo.referenceSchemaName || itemInfo.parentSchemaName,
							IsBackward: isBackward,
							DataValueType: itemInfo.dataValueType
						};
						if (entity.$AggregationType === BPMSoft.AggregationType.COUNT) {
							columnConfig.DataValueType = BPMSoft.DataValueType.INTEGER;
						}
					} else {
						columnConfig = {
							Id: id,
							UId: entity.$ColumnUId,
							ColumnPath: entity.$ColumnPath,
							Caption: entity.$Caption
						};
					}
					return columnConfig;
				}, this);
			},

			/**
			 * @private
			 */
			_startWatchingForColumnCollectionChanged: function() {
				const collection = this.$ColumnCollection;
				if (!collection) {
					return;
				}
				collection.on("add", this._onColumnCollectionChanged, this);
				collection.on("remove", this._onColumnCollectionChanged, this);
				collection.on("clear", this._onColumnCollectionChanged, this);
			},

			/**
			 * @private
			 */
			_stopWatchingForColumnCollectionChanged: function() {
				const collection = this.$ColumnCollection;
				if (!collection) {
					return;
				}
				collection.un("add", this._onColumnCollectionChanged, this);
				collection.un("remove", this._onColumnCollectionChanged, this);
				collection.un("clear", this._onColumnCollectionChanged, this);
			},

			/**
			 * @private
			 */
			_onColumnCollectionChanged: function() {
				this.$IsColumnCollectionChanged = true;
				this.$IsColumnCollectionEmpty = this.$ColumnCollection.isEmpty();
				this.sandbox.publish("SelectedModelColumnsChanged", null);
			},

			/**
			 * @private
			 */
			_loadColumnCollection: function(columnsConfig) {
				const columnCollection = this.$ColumnCollection;
				this._stopWatchingForColumnCollectionChanged();
				columnCollection.clear();
				for (const column of columnsConfig) {
					this._addModelColumn(column);
				}
				this.set("IsColumnCollectionChanged", this.$IsCardCopyMode);
				this.$IsColumnCollectionEmpty = this.$ColumnCollection.isEmpty();
				this._startWatchingForColumnCollectionChanged();
				if (this.$IsCardCopyMode) {
					this.initialColumnCollectionIdentifiers = [];
				} else {
					this._updateInitialColumnCollectionIdentifiers(columnCollection);
				}
			},

			/**
			 * Updates columns's collection identifiers.
			 * @param {BPMSoft.Collection} columnCollection Model columns collection.
			 * @private
			 */
			_updateInitialColumnCollectionIdentifiers: function(columnCollection) {
				this.initialColumnCollectionIdentifiers = [];
				if (!columnCollection) {
					return;
				}
				this.BPMSoft.each(columnCollection, function(column) {
					if (!column.$IsNew) {
						this.initialColumnCollectionIdentifiers.push(column.$Id);
					}
				}, this);
			},

			/**
			 * Handles selection of column.
			 * @private
			 * @param {Object} columnInfo Selected column information.
			 */
			_onColumnSelected: function(columnInfo) {
				if (columnInfo.isBackward) {
					columnInfo.hideFilter = false;
					ColumnSettingsUtilities.Open(this.sandbox, columnInfo, function(newConfig) {
						this._addModelColumnByLinkedColumnSettings(newConfig, columnInfo.leftExpressionCaption,
							newConfig.title);
					}.bind(this), "centerPanel", this);
				} else {
					this._addModelColumnByLinkedColumnSettings(columnInfo, columnInfo.leftExpressionCaption);
				}
			},

			/**
			 * @return {Array} Identifiers of model columns that were removed.
			 * @private
			 */
			_getRemovedColumnIds: function() {
				return BPMSoft.difference(this.initialColumnCollectionIdentifiers,
					this.$ColumnCollection.getKeys());
			},

			/**
			 * @return {Array} Identifiers of model columns that were added.
			 * @private
			 */
			_getNewColumnIds: function() {
				return BPMSoft.difference(this.$ColumnCollection.getKeys(),
					this.initialColumnCollectionIdentifiers);
			},

			/**
			 * @return {Array} Identifiers of model columns that were modified.
			 * @private
			 */
			_getChangedColumnIds: function() {
				const changedColumns = this.$ColumnCollection.filter(function(column) {
					return column.$IsChanged;
				});
				return BPMSoft.intersect(changedColumns.getKeys(), this.initialColumnCollectionIdentifiers);
			},

			_addModelColumnByLinkedColumnSettings: function(linkedColumnInfo, schemaCaption, caption) {
				const columnConfig = {
					ColumnPath: linkedColumnInfo.leftExpressionColumnPath,
					Name: linkedColumnInfo.leftExpressionColumnPath,
					SchemaCaption: schemaCaption,
					Caption: caption,
					DataValueType: linkedColumnInfo.dataValueType,
					AggregationType: linkedColumnInfo.aggregationType || BPMSoft.AggregationType.NONE,
					IsBackward: linkedColumnInfo.isBackward,
					SubFilters: linkedColumnInfo.serializedFilter || "",
					ReferenceSchemaName: linkedColumnInfo.referenceSchemaName,
					IsNew: true
				};
				this._addModelColumn(columnConfig);
			},

			/**
			 * @param {Object} columnConfig Column info descriptor.
			 * @param {Guid} [columnConfig.UId] Entity schema column unique Id.
			 * @param {Guid} [columnConfig.Id] MLModelColumn unique Id.
			 * @param {String} [columnConfig.ColumnPath] Column path relative to Root schema.
			 * @param {String} [columnConfig.Caption] Custom caption for column.
			 * @private
			 */
			_addModelColumn: function(columnConfig) {
				let targetColumnConfig = columnConfig;
				const column = this._tryGetSelectionRootSchemaColumn(columnConfig);
				if (column) {
					targetColumnConfig = {
						UId: column.uId,
						ColumnPath: column.name,
						SchemaCaption: column.caption,
						Caption: columnConfig.Caption || column.caption,
						DataValueType: column.dataValueType,
						IsBackward: false,
						IsNew: columnConfig.IsNew
					};
				}
				targetColumnConfig.Id = columnConfig.Id || BPMSoft.generateGUID();
				targetColumnConfig.Caption = targetColumnConfig.Caption || targetColumnConfig.SchemaCaption;
				targetColumnConfig.ColumnType = this.$MLColumnType;
				const columnViewModel = this._createMLModelColumnViewModel(targetColumnConfig);
				this.$ColumnCollection.add(targetColumnConfig.Id, columnViewModel);
			},

			/**
			 * @private
			 */
			_createMLModelColumnViewModel: function(column) {
				const columnViewModel = this.Ext.create("BPMSoft.MLModelColumnViewModel", {
					sandbox: this.sandbox,
					Ext: this.Ext,
					BPMSoft: this.BPMSoft,
					values: column
				});
				columnViewModel.model.on("change", function() {
					columnViewModel.set("IsChanged", true);
					this.sandbox.publish("SelectedModelColumnsChanged", null);
				}, this);
				return columnViewModel;
			},

			/**
			 * @private
			 */
			_getSaveCollectionFunction: function() {
				const batchQuery = this.Ext.create("BPMSoft.BatchQuery");
				this._addDeleteColumnsQuery(batchQuery);
				this._addInsertNewColumnsQuery(batchQuery);
				this._addUpdateChangedColumnsQuery(batchQuery);
				const uniqueMaskId = "ml-model-page-save-columns";
				this.showBodyMask({
					uniqueMaskId: uniqueMaskId,
					timeout: 0
				});
				return function (callback, scope) {
					batchQuery.execute(function () {
						this.$ColumnCollection.each(function(column) {
							column.set("IsNew", false, {silent: true});
						}, this);
						this._updateInitialColumnCollectionIdentifiers(this.$ColumnCollection);
						this.set("IsColumnCollectionChanged", false);
						this.hideBodyMask({
							uniqueMaskId: uniqueMaskId
						});
						Ext.callback(callback, scope);
					}, this);
				}.bind(this);
			},

			/**
			 * @private
			 */
			_addDeleteColumnsQuery: function(batchQuery) {
				const removedColumnIds = this._getRemovedColumnIds();
				if (removedColumnIds.length === 0) {
					return;
				}
				const deleteQuery = this.Ext.create("BPMSoft.DeleteQuery", {
					rootSchemaName: "MLModelColumn"
				});
				const filters = deleteQuery.filters;
				filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "MLModel", this.$MLModelId));
				filters.addItem(BPMSoft.createColumnInFilterWithParameters("Id", removedColumnIds));
				batchQuery.add(deleteQuery);
			},

			/**
			 * @private
			 */
			_addInsertNewColumnsQuery: function(batchQuery) {
				const newColumnIds = this._getNewColumnIds();
				if (newColumnIds.length === 0) {
					return;
				}
				BPMSoft.each(newColumnIds, function(columnId) {
					const column = this.$ColumnCollection.get(columnId);
					const insertQuery = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "MLModelColumn"
					});
					insertQuery.setParameterValue("MLModel", this.$MLModelId, BPMSoft.DataValueType.GUID);
					insertQuery.setParameterValue("Id", column.$Id, BPMSoft.DataValueType.GUID);
					if (column.$UId) {
						insertQuery.setParameterValue("ColumnUId", column.$UId, BPMSoft.DataValueType.GUID);
					}
					insertQuery.setParameterValue("ColumnPath", column.$ColumnPath, BPMSoft.DataValueType.TEXT);
					if (column.$Caption !== column.$SchemaCaption) {
						insertQuery.setParameterValue("Caption", column.$Caption,
							BPMSoft.DataValueType.TEXT);
					}
					insertQuery.setParameterValue("AggregationType", column.$AggregationType,
						BPMSoft.DataValueType.INTEGER);
					insertQuery.setParameterValue("SubFilters", column.$SubFilters,
						BPMSoft.DataValueType.TEXT);
					insertQuery.setParameterValue("ColumnType", column.$ColumnType,
						BPMSoft.DataValueType.GUID);
					batchQuery.add(insertQuery);
				}, this);
			},

			/**
			 * @private
			 */
			_addUpdateChangedColumnsQuery: function(batchQuery) {
				const changedColumnIds = this._getChangedColumnIds();
				if (changedColumnIds.length === 0) {
					return;
				}
				BPMSoft.each(changedColumnIds, function(columnId) {
					const column = this.$ColumnCollection.get(columnId);
					const caption = column.$Caption !== column.$SchemaCaption ? column.$Caption : null;
					const updateQuery = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "MLModelColumn"
					});
					updateQuery.filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Id", columnId));
					updateQuery.setParameterValue("Caption", caption, BPMSoft.DataValueType.TEXT);
					updateQuery.setParameterValue("AggregationType", column.$AggregationType,
						BPMSoft.DataValueType.INTEGER);
					updateQuery.setParameterValue("SubFilters", column.$SubFilters,
						BPMSoft.DataValueType.TEXT);
					updateQuery.setParameterValue("ColumnType", column.$ColumnType,
						BPMSoft.DataValueType.GUID);
					batchQuery.add(updateQuery);
				}, this);
			},

			/**
			 * Returns 'Remove column' icon.
			 * @return {String} 'Remove column' icon.
			 * @private
			 */
			_getRemoveColumnIcon: function() {
				const resourceImage = this.get("Resources.Images.ClearIcon");
				return BPMSoft.ImageUrlBuilder.getUrl(resourceImage);
			},

			/**
			 * Returns root schema column collection, excluding already appended to model column list.
			 * @private
			 */
			_getAvailableRootSchemaColumnCollection: function() {
				const entityColumns = this.Ext.create("BPMSoft.Collection");
				delete this.$SelectionSchemaColumns.LinkedIn;
				delete this.$SelectionSchemaColumns.LinkedInAFDA;
				delete this.$SelectionSchemaColumns.LinkedInId;
				BPMSoft.each(this.$SelectionSchemaColumns, function(column) {
					const modelColumn = this.$ColumnCollection.findByFn(function(item) {
						return item.$UId === column.uId || item.$ColumnPath === column.name;
					}, this);
					if (!modelColumn && this.columnDataValueTypeFilter(column.dataValueType)) {
						entityColumns.add(column.uId, {
							"id": column.uId,
							"caption": column.caption,
							"icon": this.getColumnTypeIcon(column.dataValueType)
						});
					}
				}, this);
				return entityColumns;
			},

			/**
			 * @param {Object} columnConfig Column info descriptor.
			 * @param {Guid} columnConfig.UId Column unique Id.
			 * @param {String} columnConfig.ColumnPath Root schema column name.
			 * @private
			 */
			_tryGetSelectionRootSchemaColumn: function(columnConfig) {
				let column;
				const columnUId = columnConfig.UId;
				if (columnUId) {
					column = BPMSoft.findWhere(this.$SelectionSchemaColumns, {"uId": columnUId});
				} else {
					column = BPMSoft.findWhere(this.$SelectionSchemaColumns, {"name": columnConfig.ColumnPath});
				}
				return column;
			},

			_initColumnCollection: function(existingCollection) {
				this.set("ColumnCollection", existingCollection);
				this.$IsColumnCollectionEmpty = this.$ColumnCollection.isEmpty();
				this._startWatchingForColumnCollectionChanged();
				this._updateInitialColumnCollectionIdentifiers(this.$ColumnCollection);
			},

			_initColumnSelectionProperties: function(selectionSchemaInfo) {
				this.$SelectionRootSchema = selectionSchemaInfo.schema;
				this.$MLModelId = selectionSchemaInfo.modelId;
				this.$SelectionSchemaColumns = selectionSchemaInfo.schemaColumns;
				this.$ModuleTitle = selectionSchemaInfo.title;
				this.$HelpText = selectionSchemaInfo.helpText;
				this.$IsCardCopyMode = selectionSchemaInfo.isCardCopyMode;
				this.$SourceEntityId = selectionSchemaInfo.sourceEntityId;
				this.columnDataValueTypeFilter = selectionSchemaInfo.columnDataValueTypeFilter;
				this._initColumnCollection(selectionSchemaInfo.columnCollection);
			},

			_subscribeSandboxEvents: function() {
				this.sandbox.subscribe("MLModelSaved", function() {
					return this._getSaveCollectionFunction();
				}, this, [this.sandbox.id]);
			},

			init: function() {
				this.callParent(arguments);
				this._subscribeSandboxEvents();
				const selectionSchemaInfo = this.sandbox.publish("GetSelectionSchemaInfo", this.$SelectionRootSchemaAttributeName);
				if (!selectionSchemaInfo) {
					return;
				}
				this._initColumnSelectionProperties(selectionSchemaInfo);
				if (this.$ColumnCollection.isEmpty()) {
					this._queryModelColumns(this.$IsCardCopyMode ? this.$SourceEntityId : this.$MLModelId);
				}
			},

			/**
			 * Creates menu items for 'Add columns' button.
			 * @return {BPMSoft.BaseViewModelCollection} Menu with actions for adding columns.
			 */
			getAddColumnMenuItems: function() {
				const items = this.Ext.create("BPMSoft.BaseViewModelCollection");
				const addRootSchemaColumnsMenuItem = this.getButtonMenuItem({
					"Caption": "$Resources.Strings.AddRootSchemaMenuItemCaption",
					"Click": {"bindTo": "addSchemaColumnsClick"}
				});
				const addRootSchemaLinkedColumnMenuItem = this.getButtonMenuItem({
					"Caption": "$Resources.Strings.AddRootSchemaLinkedColumnCaption",
					"Click": {"bindTo": "openStructureExplorer"}
				});
				items.addItem(addRootSchemaColumnsMenuItem);
				items.addItem(addRootSchemaLinkedColumnMenuItem);
				return items;
			},

			/**
			 * Open entity structure explorer module for select column macros.
			 * @protected
			 * @virtual
			 */
			openStructureExplorer: function() {
				const schemaName = this.$SelectionRootSchema.name;
				const scope = this;
				BPMSoft.StructureExplorerUtilities.open({
					scope: scope,
					handlerMethod: this._onColumnSelected,
					moduleConfig: {
						useBackwards: true,
						schemaName: schemaName,
						columnsFiltrationMethod: scope.columnsFiltrationMethod.bind(scope),
						firstColumnsOnly: false
					}
				});
			},

			/**
			 * @param {Object} column Entity schema column config.
			 * @param {Object} config Structure explorer config.
			 * @private
			 */
			columnsFiltrationMethod: function(column, config) {
				const aggregatedDataValueTypes = [
					BPMSoft.DataValueType.DATE_TIME,
					BPMSoft.DataValueType.DATE,
					BPMSoft.DataValueType.TIME,
					BPMSoft.DataValueType.INTEGER,
					BPMSoft.DataValueType.MONEY,
					BPMSoft.DataValueType.FLOAT
				];
				if (!this.columnDataValueTypeFilter(column.dataValueType)) {
					return false;
				}
				if (config.schema.name !== this.$SelectionRootSchema.name) {
					if (config.hasBackwardElements) {
						return (BPMSoft.contains(aggregatedDataValueTypes, column.dataValueType));
					}
					return true;
				}
				const existingItem = this.$ColumnCollection.findByFn(function(item) {
					return item.$UId === column.uId || item.$ColumnPath === column.name;
				}, this);
				return Ext.isEmpty(existingItem);
			},

			addSchemaColumnsClick: function() {
				const schemaName = "EntityColumnLookupPage";
				const pageId = this.sandbox.id + schemaName;
				this.sandbox.subscribe("SetColumnsLookupInfo", function(lookupInfo) {
					if (lookupInfo) {
						BPMSoft.each(lookupInfo.selectedRows, function(item) {
							this._addModelColumn({UId: item, IsNew: true});
						}, this);
					}
					this.closeSchemaColumnSelectPage();
				}, this, [pageId]);
				const entityColumns = this._getAvailableRootSchemaColumnCollection();
				this.showEntitySchemaColumnSelectPage(entityColumns, {
					rootSchema: this.$SelectionRootSchema,
					isMultiSelect: true
				});
			},

			/**
			 * Returns column type icon.
			 * @param {BPMSoft.DataValueType} dataValueType Column data value type.
			 * @return {String} Column type icon.
			 */
			getColumnTypeIcon: function(dataValueType) {
				const imageName = BPMSoft.getImageNameByDataValueType(dataValueType);
				return BPMSoft.ImageUrlBuilder.getUrl({
					source: BPMSoft.ImageSources.RESOURCE_MANAGER,
					params: {
						resourceManagerName: "BPMSoft.Nui",
						resourceItemName: Ext.String.format("{0}{1}", "ProcessSchemaDesigner.", imageName)
					}
				});
			},

			/**
			 * Handler of the configuration row of the columns container list.
			 * @param {Object} itemConfig Config of the item.
			 * @param {BPMSoft.BaseViewModel} item ViewModel.
			 */
			onGetColumnItemConfig: function(itemConfig, item) {
				itemConfig.config = {
					"id": "MLColumn",
					"className": "BPMSoft.Container",
					"classes": {
						"wrapClassName": ["column-item-container"]
					},
					"markerValue": item.$ColumnPath + "-column",
					"items": [
						{
							"className": "BPMSoft.ImageView",
							"imageSrc": this.getColumnTypeIcon(item.$DataValueType),
							"classes": {"wrapClass": ["column-type-icon"]},
							"markerValue": item.$DataValueType + "-icon"
						},
						{
							"className": "BPMSoft.Hyperlink",
							"caption": {"bindTo": "Caption"},
							"classes": {
								"hyperlinkClass": ["column-link"]
							},
							"click": {"bindTo": "onColumnHyperlinkClick"},
							"markerValue": item.$ColumnPath + "-link"
						},
						{
							"className": "BPMSoft.Button",
							"click": {"bindTo": "onRemoveColumnClick"},
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"classes": {"wrapperClass": ["remove-column-icon"]},
							"styles": {
								"wrapperStyle": {
									"background":
										Ext.String.format("url({0}) 50% 50% no-repeat", this._getRemoveColumnIcon())
								}
							},
							"markerValue": item.$ColumnPath + "-clear"
						}
					]
				};
			},

			/**
			 * @inheritdoc BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this._stopWatchingForColumnCollectionChanged();
				this.callParent(arguments);
			},

			getContainerListId: function() {
				return "ContainerList" + this.sandbox.id;
			},

			getTipId: function() {
				return "ColumnsSelectionGroupInfoButton" + this.sandbox.id;
			}
		},
		diff: [
			{
				"name": "ColumnsSelectionFieldsGroup",
				"parentName": "ModelSettingsTab",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": {"bindTo": "ModuleTitle"},
					"classes": {
						"wrapContainerClass": ["column-selector"]
					},
					"controlConfig": {
						"classes": ["column-selector-fields-group"]
					},
					"tools": [],
					"items": [],
					"generateId": false
				}
			},
			{
				"name": "AddColumnMenuButton",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"index": 1,
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"menu": {
						"items": {"bindTo": "getAddColumnMenuItems"}
					},
					"caption": {"bindTo":"Resources.Strings.AddCaption"},
					"imageConfig": {"bindTo": "Resources.Images.AddColumnMenuIcon"},
					"classes": {
						"wrapperClass": "add-columns-menu-button"
					},
					"generateId": false
				}
			},
			{
				"name": "ColumnsSelectionGroupInfoButton",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"index": 1,
				"propertyName": "tools",
				"values": {
					"id": { "bindTo": "getTipId" },
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo":"HelpText"},
					"behaviour": {
						"displayEvent": BPMSoft.TipDisplayEvent.HOVER
					},
					"controlConfig": {
						"classes": {
							"wrapperClass": "column-selector-info-button-control-group"
						},
						"generateId": false
					},
					"generateId": false
				}
			},
			{
				"name": "ColumnsSelectionGroupNoDataLabel",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.NoData" },
					"visible": {
						"bindTo": "IsColumnCollectionEmpty"
					},
					"labelConfig": {
						"classes": ["placeholder-label"]
					},
					"generateId": false
				}
			},
			{
				"name": "ColumnContainerList",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"id": {"bindTo": "getContainerListId"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"className": "BPMSoft.ContainerList",
					"collection": {
						"bindTo": "ColumnCollection"
					},
					"idProperty": "Id",
					"wrapClass": ["columns-container-list"],
					"onGetItemConfig": {
						"bindTo": "onGetColumnItemConfig"
					},
					"itemPrefix": "MLColumnContainerList"
				}
			}
		]
	};
 });
