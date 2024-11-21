define("SysModuleInWorkplaceDetailV2", ["LocalizableHelper", "ServiceHelper", "SysModuleInWorkplaceDetailV2Resources",
	"InformationButtonResources", "RightUtilities", "GridUtilities", "DesignTimeEnums",
	"SectionServiceMixin", "ControlGridModule", "SectionInWorkplaceGridViewModel",
	"SystemOperationsPermissionsMixin"
], function(LocalizableHelper, ServiceHelper, resources, informationButtonResources, RightUtilities) {
	return {
		entitySchemaName: "SysModuleInWorkplace",

		properties: {

			/**
			 * Use Detail wizard for detail
			 */
			useDetailWizard: false
		},

		messages: {
			/**
			 * @message UpdateWorkplaceType
			 * Calls workplace type update for page and detail.
			 */
			"UpdateWorkplaceType": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.BIDIRECTIONAL
			},

			/**
			 * @message HideRightsErrorTip
			 * Hides rights errors tip.
			 */
			"HideRightsErrorTip": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		mixins: {
			/**
			 * @class SectionServiceMixin
			 * Section service mixin.
			 */
			SectionServiceMixin: BPMSoft.SectionServiceMixin,

			/**
			 * @class SystemOperationsPermissionsMixin
			 * System operations permissions mixin.
			 */
			SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin"
		},

		attributes: {
			/**
			 * Sign that current workplace is portal.
			 */
			"IsCurrentWorkplaceSSP": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Section types enum.
			 * @protected
			 */
			"SectionTypes": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Sections those have no ssp sections.
			 * @protected
			 */
			"SectionsWithoutSspSectionIds": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			}
		},

		methods: {
			
			//region Methods: Private
			
			/**
			 * Check that all selected rows can be added without designer.
			 * @private
			 * @param {Object} selectedRows Selected rows in section lookup page.
			 * @returns {Boolean} True if all selected record can use new Interface Designer. Returns false otherwise.
			 */
			_isAllRowsHasNewDesignerInterface: function(selectedRows) {
				var rows = selectedRows.getItems();
				return Ext.Array.every(rows, function(item) {
					return this._isNewInterfaceDesignerSection(item);
				}, this);
			},
			/**
			 * @private
			 * @param {object} module SysModule data.
			 * @returns {Boolean} True if selected record can use new Interface Designer. Returns false otherwise.
			 */
			_isNewInterfaceDesignerSection: function(module) {
				var isNewInterfaceDesignerSection = false;
				if (module && module.value) {
					var structureData = Object.values(BPMSoft.configuration.ModuleStructure)
							.find(function (item) {
								if (item.moduleId === module.value) {
									return item;
								}
							});
					if (!structureData || !structureData.cardModule) return isNewInterfaceDesignerSection;	
					isNewInterfaceDesignerSection = structureData.cardModule === "CardSchemaViewModule";
				}
				return isNewInterfaceDesignerSection;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#onCardSaved
			 * @override
			 */
			onCardSaved: function() {
				this.openSysModuleLookup();
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
			 * @override
			 */
			getAddRecordButtonVisible: function() {
				return this.getToolsVisible();
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecord
			 * @override
			 */
			addRecord: function() {
				this.sandbox.publish("SaveRecord", {
					isSilent: true,
					messageTags: [this.sandbox.id]
				}, [this.sandbox.id]);
			},

			/**
			 * Gets hidden (system) modules filter.
			 * @private
			 * @return {BPMSoft.FilterGroup}
			 */
			getHiddenModulesFilter: function() {
				var hiddenModuleCodes = this.getHiddenModuleCodes();
				var hiddenModulesFilter = BPMSoft.createColumnInFilterWithParameters("Code", hiddenModuleCodes);
				hiddenModulesFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				return hiddenModulesFilter;
			},

			/**
			 * Opens modules lookup.
			 * @private
			 */
			openSysModuleLookup: function() {
				var esq = new BPMSoft.EntitySchemaQuery("SysModuleInWorkplace");
				esq.addColumn("SysModule.Id", "SysModuleId");
				var workplaceId = this.get("MasterRecordId");
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter("SysWorkplace", workplaceId));
				esq.getEntityCollection(function(result) {
					var existsCollection = [];
					if (result.success) {
						result.collection.each(function(item) {
							existsCollection.push(item.get("SysModuleId"));
						});
					}
					var filterGroup = BPMSoft.createFilterGroup();
					filterGroup.addItem(BPMSoft.createColumnIsNotNullFilter("SectionModuleSchemaUId"));
					var hiddenModulesFilter = this.getHiddenModulesFilter();
					filterGroup.addItem(hiddenModulesFilter);
					if (this.$IsCurrentWorkplaceSSP) {
						this.addSspSectionFilterGroup(filterGroup);
					} else {
						if (this.getIsFeatureEnabled("UseTypedWorkplaces")) {
							this.addGeneralSectionFilters(filterGroup);
						}
					}
					if (existsCollection.length > 0) {
						var existsFilter = BPMSoft.createColumnInFilterWithParameters("Id", existsCollection);
						existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
						filterGroup.addItem(existsFilter);
					}
					var config = {
						entitySchemaName: "SysModule",
						multiSelect: !this.$IsCurrentWorkplaceSSP,
						filters: filterGroup
					};
					this.openLookup(config, this.onSectionsSelected, this);
				}, this);
			},

			/**
			 * Adds selected sections to workplace.
			 * @private
			 * @param {Object} selectedRows Selected rows in section lookup page.
			 */
			_addSectionsToWorkplace: function(selectedRows) {
				var rows = this.selectedRows = selectedRows.getItems();
				this._addSectionsToWorkplaceUsingApi(rows);
			},

			/**
			 * Adds selected sections to workplace using workplace API.
			 * @private
			 * @param {Array} selectedRows Selected sections array.
			 */
			_addSectionsToWorkplaceUsingApi: function(rows) {
				var newSectionInWorkplace = [];
				var workplaceId = this.get("MasterRecordId");
				rows.forEach(function(item) {
					newSectionInWorkplace.push({
						"workplaceId": workplaceId,
						"sectionId": item.value
					});
				}, this);
				var generatorFn = function(newItem) {
					return function(next) {
						this._addSectionToWorkplaceUsingApi(newItem, next, this);
					}.bind(this);
				}.bind(this);
				BPMSoft.chainForArray(newSectionInWorkplace, generatorFn, function() {
					this.reloadGridData();
					this.sandbox.publish("UpdateWorkplaceType");
				}, this);
			},

			/**
			 * Adds section to workplace using workplace API.
			 * @private
			 * @param {Object} sectionConfig Section config.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			_addSectionToWorkplaceUsingApi: function(sectionConfig, callback, scope) {
				var serviceConfig = {
					data: {
						"workplaceId": sectionConfig.workplaceId,
						"sectionId": sectionConfig.sectionId
					},
					serviceName: "WorkplaceService",
					methodName: "AddSectionToWorkplace"
				};
				this.callService(serviceConfig, callback, scope);
			},

			/**
			 * Gets module insert query.
			 * @private
			 * @param {Object} item Selected item.
			 */
			getInsertQuery: function(item) {
				var insert = Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "SysModuleInWorkplace"
				});
				insert.setParameterValue("SysModule", item.value, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("SysWorkplace", this.get("MasterRecordId"), BPMSoft.DataValueType.GUID);
				return insert;
			},

			/**
			 * Processes item insert query result.
			 * @private
			 * @param {Object} response Response.
			 */
			onItemInsert: function(response) {
				if (!response.success) {
					this.hideBodyMask();
					var errorInfo = response.errorInfo;
					throw new BPMSoft.UnknownException({
						message: errorInfo.message
					});
				}
				var queryResult = response.queryResults;
				var rowIds = [];
				BPMSoft.each(queryResult, function(item) {
					if (item.id) {
						rowIds.push(item.id);
					}
				});
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchema: this.entitySchema
				});
				this.initQueryColumns(esq);
				this.initQuerySorting(esq);
				var filter = BPMSoft.createColumnInFilterWithParameters(this.primaryColumnName, rowIds);
				filter.comparisonType = BPMSoft.ComparisonType.EQUAL;
				esq.filters.addItem(filter);
				esq.getEntityCollection(function(response) {
					this.hideBodyMask();
					this.onGridDataLoaded(response);
				}, this);
			},

			/**
			 * Set row count for load grid data.
			 * @private
			 */
			_setRowCount: function() {
				var gridData = this.getGridData();
				var count = gridData && gridData.getCount();
				if (!count) {
					return;
				}
				if (!this.$CanLoadMoreData) {
					count++;
				}
				var profile = this.get("Profile");
				var isTiledGrid = profile && profile.DataGrid && profile.DataGrid.isTiled;
				this.set("RowCount", isTiledGrid ? count : count / 2);
			},

			/**
			* Set right level for operation "CanManageWorkplaceSettings".
			* @private
			*/
			_setCanManageWorkplaceSettings: function () {
				RightUtilities.checkCanExecuteOperation({ operation: "CanManageWorkplaceSettings" }, function (result) {
					this.set("CanManageWorkplaceSettings", result);
				}, this);
			},

			/**
			 * Sets module position.
			 * @private
			 * @param {String} recordId Record identifier.
			 * @param {Number} position Position.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 */
			setPosition: function(recordId, position, callback, scope) {
				if (this.get("CanManageWorkplaceSettings") === true) {
					var data = {
						tableName: "SysModuleInWorkplace",
						primaryColumnValue: recordId,
						position: position,
						grouppingColumnNames: "SysWorkplaceId"
					};
					this._setRowCount();
					ServiceHelper.callService("RightsService", "SetCustomRecordPosition", callback, data, scope);
				}
				else
					this.showPermissionsErrorMessage("CanManageWorkplaceSettings");
			},

			/**
			 * Processes active row action.
			 * @private
			 * @param {String} buttonTag Button tag.
			 */
			onActiveRowAction: function(buttonTag) {
				var position;
				var activeRow = this.getActiveRow();
				switch (buttonTag) {
					case "Up":
						position = activeRow.get("Position");
						if (position > 0) {
							position--;
							this.setPosition(activeRow.get("Id"), position, this.reloadGridData, this);
						}
						break;
					case "Down":
						position = activeRow.get("Position");
						position++;
						this.setPosition(activeRow.get("Id"), position, this.reloadGridData, this);
						break;
					case "PageWizard":
						this.tryOpenSectionWizard(activeRow);
						break;
					case "PageWizardV2":
						this.tryOpenInterfaceDesigner(activeRow, "SysModule.CardSchemaUId");
						break;
					case "ListWizardV2":
						this.tryOpenInterfaceDesigner(activeRow,"SysModule.SectionSchemaUId");
						break;
					default:
						break;
				}
			},

			/**
			 * Returns record last changed values attribute name.
			 * @private
			 * @param {String} recordId Record identifier.
			 * @return {String} Record last changed values attribute name.
			 */
			_getChangedValuesKey: function(recordId) {
				return Ext.String.format("{0}_Changes", recordId);
			},

			/**
			 * Returns record last changed values object.
			 * @private
			 * @param {String} recordId Record identifier.
			 * @return {Object} Record last changed values object.
			 */
			_getRowLastChange: function(recordId) {
				var key = this._getChangedValuesKey(recordId);
				return this.get(key) || {};
			},

			/**
			 * Saves record last changed values object.
			 * @private
			 * @param {String} recordId Record identifier.
			 * @param {Object} changedValues Record changed values.
			 * @return {Object} Record last changed values object.
			 */
			_setRowLastChange: function(recordId, changedValues) {
				var changes = BPMSoft.deepClone(changedValues);
				delete changes.HasErrorsTipVisible;
				var key = this._getChangedValuesKey(recordId);
				this.set(key, changes);
				return changes;
			},

			/**
			 * Opens SSP section wizard tab for selected section.
			 * @private
			 * @param {String} sectionId Section unique identifier.
			 */
			_openSspSectionWizard: function(sectionId) {
				this.openSectionWindow(sectionId, "SspMainSettings", null,
					"/AddSsp/" + this.get("MasterRecordId"));
			},

			//endregion

			//region Methods: Protected

			/**
			 * Subscribes viewmodel to server messages.
			 * @protected
			 */
			subscribeServerChannelEvents: function() {
				this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE,
					this.onServerChannelMessage, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
			 * @overridden
			 */
			destroy: function() {
				this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE,
					this.onServerChannelMessage, this);
				this.callParent(arguments);
			},

			/**
			 * Server message handler. If sender UpdateSectionInWorkplace, updates grid.
			 * @protected
			 * @param {Object} scope Message scope.
			 * @param {Object} message Server messsage.
			 */
			onServerChannelMessage: function(scope, message) {
				if (this.isEmpty(message) || this.isEmpty(message.Header)) {
					return;
				}
				this.processNewSectionMessage(message);
			},

			/**
			 * Updates grid on server message.
			 * @protected
			 * @param {Object} message Server channel message.
			 */
			processNewSectionMessage: function(message) {
				if (message.Header.Sender === "UpdateSectionInWorkplace") {
					this.reloadGridData();
				}
			},

			/**
			 * Gets system modules.
			 * @protected
			 * @return {String[]}
			 */
			getHiddenModuleCodes: function() {
				var hiddenModuleCodes = ["SysAdminOperation", "SysAdminUnit", "FuncRoles", "VwSysDcmLib", "OAuth20App"];
				if (this.$IsCurrentWorkplaceSSP) {
					hiddenModuleCodes.push("Contact", "Account", "Activity");
				}
				return hiddenModuleCodes;
			},

			/**
			 * Processes module select result.
			 * @potected
			 * @param {Object} args Module select information.
			 */
			onSectionsSelected: function(args) {
				var selectedRows = args.selectedRows;
				var isIgnoreOpenWizard = this._isAllRowsHasNewDesignerInterface(args.selectedRows);
				if (!this.$IsCurrentWorkplaceSSP || isIgnoreOpenWizard) {
					this._addSectionsToWorkplace(selectedRows);
				} else {
					this.initGeneralAndSspSections(selectedRows);
				}
			},

			/**
			 * Processed receiving general and portal sections from service.
			 * @overridden
			 * @param {Object} result General and portal sections.
			 * @param {Object} selectedRows Selected rows in section lookup page.
			 */
			processedGeneralAndSspSections: function(result, selectedRows) {
				var generalAndSspSections = result.GetGeneralAndSspSectionsResult;
				if (generalAndSspSections) {
					var sectionId = selectedRows.getByIndex(0).value;
					if (generalAndSspSections.length === 2) {
						var isSspSectionExists = false;
						var isSelectedSectionSSP = Ext.Array.findBy(generalAndSspSections, function(item) {
							var selectedSection = JSON.parse(item);
							var sectionTypes = this.$SectionTypes || {};
							isSspSectionExists = isSspSectionExists || selectedSection.Type === sectionTypes.SSP;
							return selectedSection.Id === sectionId && selectedSection.Type === sectionTypes.SSP;
						}, this);
						if (isSelectedSectionSSP) {
							this._addSectionsToWorkplace(selectedRows);
						} else if (isSspSectionExists) {
							this.showInformationDialog(
								this.get("Resources.Strings.SelectedSectionAlreadyRegisteredAsSSP"));
						} else {
							this._openSspSectionWizard(sectionId);
						}
					} else {
						this._openSspSectionWizard(sectionId);
					}
				}
			},

			/**
			 * Opens section wizard for selected section.
			 * @protected
			 * @param {BPMSoft.configuration.BaseGridRowViewModel} record Active record in detail.
			 */
			tryOpenSectionWizard: function(record) {
				var module = record.get("SysModule");
				var stepName = this.$IsCurrentWorkplaceSSP ? "SspMainSettings" : null;
				if (module && module.value) {
					this.openSectionWindow(module.value, stepName);
				}
			},
			/**
			 * Opens section wizard for selected section.
			 * @protected
			 * @param {BPMSoft.configuration.BaseGridRowViewModel} record Active record in detail.
			 * @param {String} designerColumn Opened schema UId column.
			 */
			tryOpenInterfaceDesigner: function(record, designerColumn) {
				const wizardUrlEnum = BPMSoft.DesignTimeEnums.WizardUrl;
				var schemaId = record.get(designerColumn);
				this.openWizardWindow(wizardUrlEnum.INTERFACE_DESIGNER_URL, null, schemaId);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridDataColumns
			 * @override
			 */
			getGridDataColumns: function() {
				var gridDataColumns = this.callParent(arguments);
				if (!gridDataColumns.Position) {
					gridDataColumns.Position = {
						path: "Position",
						orderPosition: 0,
						orderDirection: BPMSoft.OrderDirection.ASC
					};
				}
				return gridDataColumns;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#initQueryColumns
			 * @overridde
			 */
			 initQueryColumns: function(esq) {
				this.callParent(arguments);
				esq.addColumn("SysModule.SectionSchemaUId");
				esq.addColumn("SysModule.CardSchemaUId");
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this._setCanManageWorkplaceSettings();
				this.callParent([
					function() {
						this.setDetailAttributes();
						this.subscribeServerChannelEvents();
						if (this.$IsCurrentWorkplaceSSP) {
							this.setSectionsWithoutSspSection(callback, scope || this);
							return;
						}
						this.Ext.callback(callback, scope || this);
					}, this
				]);
			},

			/**
			 * Sets SectionsWithoutSspSectionIds.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			setSectionsWithoutSspSection: function(callback, scope) {
				var config = {
					serviceName: "SectionService",
					methodName: "GetSectionsWithoutSspView"
				};
				this.callService(config, function(result) {
					if (result && result.GetSectionsWithoutSspViewResult) {
						this.$SectionsWithoutSspSectionIds = [];
						this.Ext.Array.each(result.GetSectionsWithoutSspViewResult, function(item) {
							this.$SectionsWithoutSspSectionIds.push(JSON.parse(item).Id);
						}, this);
					}
					this.Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Sets detail attributes.
			 * @protected
			 */
			setDetailAttributes: function() {
				var defaultValues = this.$DefaultValues;
				var isWorkplaceSSPDefValue = Ext.Array.findBy(defaultValues, function(item) {
					return item.name === "IsCurrentWorkplaceSSP";
				}, this);
				this.$IsCurrentWorkplaceSSP = isWorkplaceSSPDefValue ? isWorkplaceSSPDefValue.value : false;
				var sectionTypesDefValue = Ext.Array.findBy(defaultValues, function(item) {
					return item.name === "SectionTypes";
				}, this);
				this.$SectionTypes = sectionTypesDefValue ? sectionTypesDefValue.value : {};
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("UpdateWorkplaceType", this.updateWorkplaceType, this, [this.sandbox.id]);
			},

			/**
			 * Sets current workplace type property.
			 * @protected
			 * @param {Integer} value Workplace type.
			 */
			updateWorkplaceType: function(value) {
				this.$IsCurrentWorkplaceSSP = value;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @override
			 */
			getEditRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @override
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelClassName
			 * @override
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.SectionInWorkplaceGridViewModel";
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelConfig
			 * @override
			 */
			getGridRowViewModelConfig: function(data) {
				var gridRowViewModelConfig = this.callParent(arguments);
				this.Ext.apply(gridRowViewModelConfig, {
					sandbox: this.sandbox
				});
				var newInterfaceDesignerButtonConfig = {
					IsNewInterfaceDesignerSection: false
				};
				if (Ext.isFunction(this._isNewInterfaceDesignerSection) && data && data.rawData && data.rawData.SysModule) {
					newInterfaceDesignerButtonConfig = {
						IsNewInterfaceDesignerSection: this._isNewInterfaceDesignerSection(data.rawData.SysModule) 
					};
				}
				Ext.apply(gridRowViewModelConfig.values, newInterfaceDesignerButtonConfig);
				return gridRowViewModelConfig;
			},

			/**
			 * Creates SysModule column control config.
			 * @protected
			 * @param {Object} control Column control options object.
			 */
			getSysModuleControlConfig: function(control) {
				var sectionNameLabel = {
					"className": "BPMSoft.Label",
					"caption": {"bindTo": "SysModule"},
					"markerValue": {"bindTo": "getSysModuleName"},
					"classes": {
						"labelClass": ["sysmodule-name-label"]
					}
				};
				if (!this.$IsCurrentWorkplaceSSP) {
					control.config = sectionNameLabel;
					return;
				}
				control.config = {
					"className": "BPMSoft.Container",
					"classes": {
						"wrapClassName": ["sysmodule-name-container"]
					},
					"items": [
						sectionNameLabel,
						{
							"className": "BPMSoft.InformationButton",
							"imageConfig": informationButtonResources.localizableImages.WarningIcon,
							"visible": {"bindTo": "HasErrors"},
							"markerValue": {"bindTo": "getInformationButtonMarker"},
							"tips": [{
								"tip": {
									"style": BPMSoft.TipStyle.RED,
									"restrictAlignType": BPMSoft.AlignType.RIGHT,
									"markerValue": "SysModuleRightsErrorTip",
									"visible": {"bindTo": "HasErrorsTipVisible"},
									"items": [{
										"className": "BPMSoft.Container",
										"classes": {
											"wrapClassName": ["information-container-wrap"]
										},
										"markerValue": {"bindTo": "Id"},
										"afterrender": {"bindTo": "loadInformationModule"},
										"afterrerender": {"bindTo": "loadInformationModule"},
										"items": []
									}]
								},
								"settings": {
									"displayEvent": BPMSoft.TipDisplayEvent.CLICK
								}
							}]
						}
					]
				};
			},

			/**
			 * Checks is record grid row update needed.
			 * @protected
			 * @param {String} recordId Record identifier.
			 * @param {Object} changedValues Record changed values object.
			 * @return {Boolean} True if update needed. Returns false otherwise.
			 */
			getNeedUpdateRow: function(recordId, changedValues) {
				var prevChange = this._getRowLastChange(recordId);
				var currentChange = this._setRowLastChange(recordId, changedValues);
				return !Ext.Object.equals(prevChange, currentChange);
			},

			/**
			 * Adds ssp section filterGroup with type filter and SectionsWithoutSspSectionIds filter into filterGroup.
			 * @protected
			 * @param {Object} filterGroup filterGroup for SysModuleLookup.
			 */
			addSspSectionFilterGroup: function(filterGroup) {
				const sspFilterGroup = this.BPMSoft.createFilterGroup();
				sspFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				sspFilterGroup.addItem(this.BPMSoft.createColumnInFilterWithParameters("Id",
					this.$SectionsWithoutSspSectionIds));
				sspFilterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter("Type", this.$SectionTypes.SSP));
				filterGroup.addItem(sspFilterGroup);
			},

			/**
			 * Adds GENERAL type section filters.
			 * @protected
			 * @param {Object} filterGroup filterGroup for SysModuleLookup.
			 */
			addGeneralSectionFilters: function(filterGroup) {
				const generalFilterGroup = this.BPMSoft.createFilterGroup("IsGeneralSectionFilters");
				generalFilterGroup.add("IsGeneralTypeFilter", this.BPMSoft.createColumnFilterWithParameter("Type",
					this.$SectionTypes.GENERAL));
				filterGroup.addItem(generalFilterGroup);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Detail",
				"values": {
					"wrapClass": ["hide-grid-caption-wrapClass"]
				}
			},
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "BPMSoft.ControlGrid",
					"controlColumnName": "SysModule",
					"applyControlConfig": {"bindTo": "getSysModuleControlConfig"},
					"needUpdateRow": {"bindTo": "getNeedUpdateRow"},
					"activeRowActions": [],
					"activeRowAction": {"bindTo": "onActiveRowAction"},
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "SysModuleGridColumn",
								"bindTo": "SysModule",
								"position": {
									"column": 0,
									"colSpan": 8
								}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {
							"columns": 24,
							"rows": 3
						},
						"items": [
							{
								"name": "SysModuleGridColumn",
								"bindTo": "SysModule",
								"position": {"column": 0, "colSpan": 8}
							}
						]
					}
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowUpButton",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": LocalizableHelper.localizableStrings.UpButtonHint,
					"tag": "Up"
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowDownButton",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": LocalizableHelper.localizableStrings.DownButtonHint,
					"tag": "Down"
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowOpenWizardButton",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"visible": {
						"bindTo": "IsNewInterfaceDesignerSection",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": resources.localizableStrings.OpenSectionWizardButtonCaption,
					"tag": "PageWizard"
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowOpenListWizardV2Button",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"visible": {"bindTo": "IsNewInterfaceDesignerSection"},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": resources.localizableStrings.OpenListWizardButtonCaption,
					"tag": "ListWizardV2"
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowOpenPageWizardV2Button",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"visible": {"bindTo": "IsNewInterfaceDesignerSection"},
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": resources.localizableStrings.OpenPageWizardButtonCaption,
					"tag": "PageWizardV2"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});

