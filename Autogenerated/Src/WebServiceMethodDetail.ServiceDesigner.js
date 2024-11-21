/**
 * Parent: BaseGridDetailV2
 */
define("WebServiceMethodDetail", ["ConfigurationEnums", "WebServiceMethodDetailResources",
	"css!ServiceDesignerStyles", "ServiceDesignerUtilities", "SortableGridViewModelMixin"
], function(ConfigurationEnums, resources) {
	return {
		messages: {
			/**
			 * Closed method page.
			 */
			"CloseMethodPage": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message OpenServiceClient
			 * Opens service client.
			 */
			"OpenServiceClient": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			sortableGrid: "BPMSoft.SortableGridViewModelMixin"
		},
		attributes: {
			/**
			 * Service schema UId.
			 */
			"ServiceSchemaUId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Service schema.
			 */
			"ServiceSchema": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Is allow edit fields.
			 */
			"CanEditSchema": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Is method page showed.
			 */
			"ShowMethodPage": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_deleteMethods: function(methods) {
				methods.forEach(function(methodUId) {
					this.$ServiceSchema.methods.remove(
						this.$ServiceSchema.methods.firstOrDefault(function(method) {
							return method.uId === methodUId;
						})
					);
				}, this);
				this.reloadGridData();
			},

			/**
			 * @private
			 */
			_getRowViewModelColumns: function() {
				return {
					Caption: {
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					Type: {
						dataValueType: BPMSoft.DataValueType.TEXT
					}
				};
			},

			/**
			 * @private
			 */
			_getRowViewModelValues: function(rowObject) {
				return {
					Id: rowObject.uId,
					Caption: rowObject.caption.getValue(),
					Type: rowObject.request.findHttpMethodTypeName()
				};
			},

			/**
			 * @private
			 */
			_getRowViewModel: function(rowObject) {
				return this.Ext.create("BPMSoft.BaseViewModel", {
					columns: this._getRowViewModelColumns(),
					values: this._getRowViewModelValues(rowObject)
				});
			},

			/**
			 * @private
			 */
			_getRowViewModelId: function(rowObject) {
				return rowObject.getPropertyValue("uId");
			},

			/**
			 * @private
			 */
			_getEnumerableObject: function() {
				return this.$ServiceSchema.methods;
			},

			/**
			 * @private
			 */
			_canLoadGridData: function() {
				return this.$ServiceSchema;
			},

			/**
			 * @private
			 */
			_findSchemaInstance: function(callback, scope) {
				var items = BPMSoft.ServiceSchemaManager.getItems();
				var item = items.findByPath("uId", this.$MasterRecordId);
				if (item) {
					item.getInstance(callback, scope);
				} else {
					callback.call(scope);
				}
			},

			/**
			 * @private
			 */
			_closeMethodPage: function() {
				this.$ShowMethodPage = false;
				this.reloadGridData();
			},

			/**
			 * @private
			 */
			_subscribeCloseMethodPageSandboxEvent: function() {
				this.sandbox.subscribe("CloseMethodPage", this._closeMethodPage, this);
			},

			/**
			 * Provides settings for sorting.
			 * @private
			 */
			_getSortSettingsConfig: function() {
				return {
					columnsToSort: ["Caption", "Type"],
					profileKey: "WebServiceMethodDetail_GridSortConfig"
				};
			},

			_registerEditPages: function () {
				let editPageUId = '09cfe46e-ba2d-4bba-9f0d-d9decef0e4ac';
				let schemaName = 'RestWebServiceMethodPage'
				if (this.$ServiceSchema && !this.$ServiceSchema.isRest()) {
					editPageUId = '0bcdcafd-c720-2cd4-9fc0-4aa2d1911e36';
					schemaName = 'SoapWebServiceMethodPage';
				}
				this.$EditPages = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.$EditPages.add(editPageUId, Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: editPageUId,
						Click: {bindTo: "addRecord"},
						Tag: editPageUId,
						MiniPage: {
							hasAddMiniPage: false
						},
						SchemaName: schemaName
					}
				}));
			},

			//endregion

			//region Methods: Protected

			/**
			 * @protected
			 */
			reinitEditPages: function() {
				this._registerEditPages();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getIsLinkColumn
			 * @override
			 */
			initEditPages: function() {
				this._registerEditPages();
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getIsLinkColumn
			 * @override
			 */
			getIsLinkColumn: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilities#sortColumn
			 * @override
			 */
			sortColumn: function(index) {
				this.sortByColumn(index);
			},

			/**
			 * @inheritdoc BPMSoft.SortableGridViewModelMixin#getDataCollection
			 * @override
			 */
			getColumnGetter: function(column) {
				if (column === "Type") {
					return function(item) {
						return item.request.httpMethodType;
					};
				} else {
					return function(item) {
						var value = item.caption.getValue();
						if (value) {
							value = value.toLowerCase();
						}
						return value;
					};
				}
			},

			/**
			 * @inheritdoc BPMSoft.SortableGridViewModelMixin#getDataCollection
			 * @override
			 */
			getDataCollection: function() {
				return this.$ServiceSchema.methods;
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @override
			 */
			addDetailWizardMenuItems: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSettingsMenuItem
			 * @override
			 */
			getGridSettingsMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
			 * @override
			 */
			getGridSortMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getShowQuickFilterButton
			 * @override
			 */
			getShowQuickFilterButton: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getHideQuickFilterButton
			 * @override
			 */
			getHideQuickFilterButton: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#setUpUserCanChangeRecordRight
			 * @override
			 */
			setUpUserCanChangeRecordRight: function(recordId, callback, scope) {
				Ext.callback(callback, scope, [{
					canChangeReadRight: true,
					canChangeEditRight: true,
					canChangeDeleteRight: true,
				}]);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#deleteRecords
			 * @override
			 */
			deleteRecords: function() {
				if (this.$CanEditSchema) {
					var items = this.getSelectedItems();
					if (items && items.length > 0) {
						this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
							function(result) {
								if (result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									this._deleteMethods(items);
								}
							}, [this.BPMSoft.MessageBoxButtons.NO.returnCode,
								this.BPMSoft.MessageBoxButtons.YES.returnCode], null);
					}
				} else {
					this.showInformationDialog(resources.localizableStrings.DenyAccess);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecord
			 * @override
			 */
			addRecord: function(editPageUId) {
				if (this.$CanEditSchema) {
					editPageUId = editPageUId || this.getFirstEditPageUId();
					this.set("CardState", ConfigurationEnums.CardStateV2.ADD);
					this.set("EditPageUId", editPageUId);
					this.set("PrimaryValueUId", null);
					this.openCardByMode();
				} else {
					this.showInformationDialog(resources.localizableStrings.DenyAccess);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#openCard
			 * @override
			 */
			openCard: function(operation) {
				var viewModelConfig = {
					ServiceUId: this.$ServiceSchema.uId,
					Operation: operation
				};
				if (operation !== ConfigurationEnums.CardStateV2.ADD) {
					viewModelConfig.MethodUId = this.getActiveRow() && this.getActiveRow().$Id;
				}
				const moduleName = this.$ServiceSchema.isRest() ? "WebServiceMethodModule" : "SoapServiceMethodModule";
				var moduleId = Ext.String.format("{0}{1}{2}", this.sandbox.id, "_WebServiceMethodModule_",
					this.$ServiceSchema.uId);
				this.$ShowMethodPage = true;
				this.sandbox.loadModule(moduleName, {
					renderTo: Ext.get("MethodPageContainer"),
					id: moduleId,
					instanceConfig: {
						parameters: {
							viewModelConfig: viewModelConfig
						}
					}
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getExportToExcelMenuVisibility
			 * @override
			 */
			getExportToExcelMenuVisibility: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#loadGridData
			 * @override
			 */
			loadGridData: function() {
				if (this._canLoadGridData()) {
					var result = new BPMSoft.Collection();
					this._getEnumerableObject().each(function(method) {
						result.add(this._getRowViewModelId(method), this._getRowViewModel(method));
					}, this);
					this.onGridDataLoaded({success: true, collection: result});
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#linkClicked
			 * @override
			 */
			linkClicked: function(recordId) {
				this.$ActiveRow = recordId;
				this.editRecord();
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this._subscribeCloseMethodPageSandboxEvent();
				this.set("EditPages", new BPMSoft.Collection());
				this.callParent([function() {
					BPMSoft.chain(
						function(next) {
							BPMSoft.ServiceSchemaManager.initialize(next, this);
						},
						function(next) {
							this._findSchemaInstance(next, this);
						},
						function(next, schema) {
							this.$ServiceSchema = schema;
							this.reinitEditPages();
							this.$ServiceSchema.on("changed", this.reloadGridData, this);
							BPMSoft.ServiceDesignerUtilities.canEditSchema(schema, function(result) {
								this.$CanEditSchema = result;
								this.$IsDetailCollapsed = false;
								this.$ServiceSchema.methods.suspendEvents();
								this.initSortingSettings(this._getSortSettingsConfig(), function() {
									this.$ServiceSchema.methods.resumeEvents();
									this.loadGridData();
									Ext.callback(callback, scope);
								}, this);
							}, this);
						},
						this
					);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getActiveRow
			 * @override
			 */
			getActiveRow: function() {
				if (this.$ActiveRow) {
					var gridData = this.getGridData();
					return gridData.findByFn(function(item) {
						return item.$Id === this.$ActiveRow;
					}, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#editRecord
			 * @override
			 */
			editRecord: function(record) {
				var activeRow = record || this.getActiveRow();
				if (!activeRow) {
					return;
				}
				var primaryColumnValue = activeRow.get(activeRow.primaryColumnName);
				var typeColumnValue = this.getTypeColumnValue(activeRow);
				this.setLastActiveRow(primaryColumnValue);
				this.openCard(ConfigurationEnums.CardStateV2.EDIT, typeColumnValue, primaryColumnValue);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#copyRecord
			 * @override
			 */
			copyRecord: function(editPageUId) {
				if (this.$CanEditSchema) {
					if (!this.isAnySelected() || !this.getIsCardValid()) {
						return;
					}
					var activeRow = this.getActiveRow();
					var typeColumnValue = this.getTypeColumnValue(activeRow);
					editPageUId = editPageUId || typeColumnValue === this.BPMSoft.GUID_EMPTY
						? this.getFirstEditPageUId()
						: typeColumnValue;
					var selectedItems = this.getSelectedItems();
					var copiedRecordId = selectedItems[0];
					this.setLastActiveRow(copiedRecordId);
					this.openCard(ConfigurationEnums.CardStateV2.COPY, editPageUId, copiedRecordId);
				} else {
					this.showInformationDialog(resources.localizableStrings.DenyAccess);
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @override
			 */
			getSwitchGridModeMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc GridUtilitiesV2#addColumnLink
			 * @override
			 */
			addColumnLink: function(item) {
				var onColumnLinkClickHandler = "onCaptionLinkClick";
				var scope = this;
				item[onColumnLinkClickHandler] = function() {
					return scope.createLink("VwWebServiceV2", "Caption", item.get("Caption"),
						scope.$MasterRecordId, item.$Id);
				};
			},

			/**
			 * @inheritdoc GridUtilitiesV2#createLink
			 * @override
			 */
			createLink: function(entitySchemaName, columnPath, displayValue) {
				return {
					caption: displayValue,
					target: "_self",
					title: displayValue,
					url: window.location.hash
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				if (this.$ServiceSchema) {
					this.$ServiceSchema.un("changed", this.reloadGridData, this);
				}
				this.callParent(arguments);
			},

			onOpenServiceClientButtonClicked: function() {
				const selectedMethod = this.getActiveRow();
				if (!!selectedMethod) {
					this.sandbox.publish("OpenServiceClient", selectedMethod.$Id);	
				}
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"parentName": "Detail",
				"propertyName": "tools",
				"name": "SendTestRequestButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "onOpenServiceClientButtonClicked"},
					"enabled": {"bindTo": "getActiveRow"},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": {"bindTo": "Resources.Strings.SendTestRequestCaption"}
				}
			},
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"rowDataItemMarkerColumnName": "Caption",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "Caption",
								"bindTo": "Caption",
								"caption": resources.localizableStrings.MethodNameColumnCaption,
								"position": {"column": 0, "colSpan": 11}
							},
							{
								"name": "Type",
								"bindTo": "Type",
								"caption": resources.localizableStrings.HttpMethodTypeColumnCaption,
								"position": {"column": 13, "colSpan": 11}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {},
						"items": []
					},
					"isEmptyCaption": resources.localizableStrings.EmptyGrid
				}
			},
			{
				"operation": "insert",
				"name": "MethodPageContainer",
				"values": {
					"id": "MethodPageContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["method-page-container"]},
					"items": [],
					"visible": {"bindTo": "ShowMethodPage"}
				}
			},
			{
				"operation": "merge",
				"name": "loadMore",
				"values": {
					"visible": {"bindTo": false}
				}
			}
		]
	};
});
