define("LookupSection", ["ConfigurationEnums", "LookupSectionGridRowViewModel"],
function(ConfigurationEnums) {
	return {
		entitySchemaName: "Lookup",
		messages: {
			/**
			 * @message GetExtendedFilterConfig
			 * Generates config for quick filters.
			 */
			"GetExtendedFilterConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * ######## ######## ###### ## ####### ###### #### # ############ ### ############# ######
			 */
			SecurityOperationName: {
				dataValueType: BPMSoft.DataValueType.STRING,
				value: "CanManageLookups"
			},

			/**
			 * ########## ############# ########### #######.
			 */
			ContextHelpId: {
				dataValueType: BPMSoft.DataValueType.STRING,
				value: "271"
			}
		},
		methods: {

			/**
			 * @param {Object} viewModel
			 * @param {Object} currentFolder
			 * @private
			 */
			_onCurrentFolderChanged: function(viewModel, currentFolder) {
				this.set("activeFolderId", currentFolder && currentFolder.value);
			},

			/**
			 * Forms feature code to not use angular for lookup entity.
			 * @private
			 * @param {String} entityName  Lookup entity name.
			 */
			_getAngularLookupFeatureCode: function(entityName) {
				return this.Ext.String.format("DoNotUseAngular{0}Lookup", entityName);
			},

			/**
			 * Checks whether can open lookup in angular
			 * @param viewModel
			 * @returns {Boolean}
			 * @private
			 */
			_canOpenAngularSection: function(viewModel) {
				const angularLookups= ["SysModuleReport", "MailServer"];
				const featureCode = this._getAngularLookupFeatureCode(viewModel.$EntitySchemaName);
				const isAngularLookupDisabled = this.getIsFeatureEnabled(featureCode);
				return angularLookups.indexOf(viewModel.$EntitySchemaName) !== -1 && !isAngularLookupDisabled;
			},

			/**
			 * Opens lookup in angular
			 * @param viewModel
			 * @private
			 */
			_openAngularSection: function(viewModel) {
				const url = this.BPMSoft.workspaceBaseUrl + "/ClientApp/#/" + viewModel.$SysLookup.displayValue;
				window.open(url, "_blank");
			},

			/**
			 * Checks whether can open lookup in old configuration
			 * @param entitySchemaName Entity schema name
			 * @returns {boolean}
			 * @private
			 */
			_canOpenOldLookupConfiguration: function(entitySchemaName) {
				const isNewLookUpEnabledFeatureName = this.formFeatureCode(entitySchemaName);
				return this.getIsFeatureEnabled("AllowUseOldLookupInterface") &&
					!this.getIsFeatureEnabled(isNewLookUpEnabledFeatureName);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#isMergeVisible
			 * @override
			 */
			isMergeVisible: function () {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#init
			 * @override
			 */
			init: function() {
				this.subscribeOnColumnChange("CurrentFolder", this._onCurrentFolderChanged, this);
				this.callParent(arguments);
				this.set("UseTagModule", false);
				this.set("UseStaticFolders", true);
				this.set("TagButtonVisible", false);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObjectV2#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.unsubscribeOnColumnChange("CurrentFolder", this._onCurrentFolderChanged, this);
				this.callParent(arguments);
			},

			/**
			 * ######### ###### ########### # #######.
			 * @protected
			 * @param {Object} config ############ ############## ######.
			 */
			openSectionInChain: function(config) {
				this.showBodyMask();
				this.saveCardScroll();
				this.scrollCardTop();
				const schemaName = config.schemaName || "BaseLookupConfigurationSection";
				const newHash = BPMSoft.combinePath("LookupSectionModule", schemaName);
				this.sandbox.publish("PushHistoryState", {
					hash: newHash,
					silent: true,
					stateObj: {
						caption: config.caption,
						entitySchemaName: config.entitySchemaName
					}
				});
				this.sandbox.loadModule("LookupSectionModule", {
					renderTo: this.renderTo,
					id: config.moduleId,
					keepAlive: true
				});
			},

			/**
			 * ######### ######### ########### # ###### ##########.
			 * @protected
			 * @param {String} sysLookup ########## ############# ########### # ###### ##########.
			 */
			openOldLookupConfiguration: function(sysLookup) {
				const sysLookupValue = (sysLookup && sysLookup.value) || sysLookup;
				const entitySchemaQuery = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "SysLookup"});
				entitySchemaQuery.addColumn("Id");
				entitySchemaQuery.addColumn("SysEditPageSchemaUId");
				entitySchemaQuery.addColumn("SysEntitySchemaUId");
				entitySchemaQuery.addColumn("SysGridPageSchemaUId");
				entitySchemaQuery.getEntity(sysLookupValue, function(result) {
					if (result.success) {
						const entity = result.entity;
						const sysGridPageSchemaUId = entity.get("SysGridPageSchemaUId");
						const parameters = {
							editMode: "true"
						};
						if (!Ext.isEmpty(sysGridPageSchemaUId)) {
							Ext.apply(parameters, {Id: sysGridPageSchemaUId});
						} else {
							const sysEditPageSchemaUId = entity.get("SysEntitySchemaUId");
							Ext.apply(parameters, {
								Id: "33cc4a3a-babb-464d-82a0-1b904d198d31",
								schemaUId: sysEditPageSchemaUId
							});
						}
						const parameterString = [];
						BPMSoft.each(parameters, function(parameterValue, parameterName) {
							parameterString.push(Ext.String.format("{0}={1}", parameterName, parameterValue));
						}, this);
						const url = this.BPMSoft.workspaceBaseUrl + "/ViewPage.aspx?" + parameterString.join("&");
						const width = 600;
						const height = 400;
						const left = screen.availLeft + (screen.availWidth - width) / 2;
						const top = screen.availTop + (screen.availHeight - height) / 2;
						const windowParams = Ext.String.format("resizable,width={0},height={1},left={2},top={3}",
							width, height, left, top);
						window.open(url, "_blank", windowParams);
					}
				}, this);
			},

			/**
			 * Forms feature code for lookup entity.
			 * @protected
			 * @param {String} entityName  Lookup entity name.
			 */
			formFeatureCode: function(entityName) {
				return this.Ext.String.format("New{0}Lookup", entityName);
			},

			/**
			 * ######### ######## ############## ######
			 * @protected
			 * @param {String} primaryColumnValue ########## ############# ######
			 */
			editRecord: function(primaryColumnValue) {
				const gridData = this.getGridData();
				const activeRow = gridData.get(primaryColumnValue);
				const sysLookup = activeRow.get("SysLookup");
				const entitySchemaName = activeRow.get("EntitySchemaName");
				if (this._canOpenAngularSection(activeRow)) {
					this._openAngularSection(activeRow);
					return;
				}
				if (sysLookup && this._canOpenOldLookupConfiguration(entitySchemaName)) {
					this.openOldLookupConfiguration(sysLookup);
					return;
				}
				if (!entitySchemaName) {
					this.log("cann't find entity");
					return;
				}
				const schemaName = activeRow.get("PageSchemaName");
				const caption = activeRow.get("Name");
				const config = {
					caption: caption,
					entitySchemaName: entitySchemaName,
					schemaName: schemaName,
					moduleId: this.sandbox.id + "_BaseLookupConfigurationSection"
				};
				this.openSectionInChain(config);
			},

			/**
			 * @inheritodoc BaseSectionV2#onActiveRowAction
			 * @override
			 */
			onActiveRowAction: function(buttonTag, primaryColumnValue) {
				switch (buttonTag) {
					case "openConfiguration":
						this.openConfiguration(primaryColumnValue);
						break;
					default:
						this.callParent(arguments);
						break;
				}
			},

			/**
			 * @inheritodoc BaseSectionV2#getGridRowViewModelClassName
			 * @override
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.LookupSectionGridRowViewModel";
			},

			/**
			 * @inheritodoc BaseSectionV2#getDefaultDataViews
			 * @override
			 */
			getDefaultDataViews: function() {
				const dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},

			/**
			 * ######### # ###### ####### ##### #####.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq ###### #######.
			 * @param {String} columnPath #### # #######.
			 * @param {String} columnAlias ######### #######.
			 */
			addSchemaNameColumn: function(esq, columnPath, columnAlias) {
				const expressionConfig = {
					columnPath: columnPath,
					parentCollection: this,
					aggregationType: BPMSoft.AggregationType.NONE
				};
				const column = Ext.create("BPMSoft.SubQueryExpression", expressionConfig);
				const filter = BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value
				);
				column.subFilters.addItem(filter);
				const esqColumn = esq.addColumn(columnAlias);
				esqColumn.expression = column;
			},

			
			// Исключает справочники, не относящиеся к Studio. Потом нужно будет добавить какой-то атрибут, который будет проверять бандл
			addFilterIsNotAvailableInStudio: function(esq){
				var esqIsNotAvailableInStudio = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "IsNotAvailableInStudio", false);
				esq.filters.add("esqIsNotAvailableInStudio", esqIsNotAvailableInStudio);
			},
			
			// Скрывает ненужные справочники по Id
			addFilterHiddenLookup: function(esq){
				var esqHiddenLookup = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL, "Id", '956AE37D-63BA-4292-9EE2-84622F9D0729');
				esq.filters.add("esqHiddenLookup", esqHiddenLookup);
			},
			
			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#initQueryColumns
			 * @override
			 */
			initQueryColumns: function(esq) {
				this.callParent(arguments);
				this.addSchemaNameColumn(esq, "[VwSysSchemaInfo:UId:SysEntitySchemaUId].Name", "EntitySchemaName");
				this.addSchemaNameColumn(esq, "[VwSysSchemaInfo:UId:SysPageSchemaUId].Name", "PageSchemaName");
				this.addFilterHiddenLookup(esq);

				// Получаем версию бандла
				let productEdition = "";
				BPMSoft.SysSettings.querySysSettings(["ProductEdition"], function(values) {
					productEdition = values.ProductEdition;
				}, this);

				if(productEdition === "Constructor" || productEdition === "ServiceEnterprise" || productEdition === "studio"){
					this.addFilterIsNotAvailableInStudio(esq);
				}


				esq.addColumn("SysLookup");
			},


			/**
			 * ######### ######## ######### ###########.
			 * @protected
			 * @param {String} primaryColumnValue ########## ############# ############# ######.
			 */
			openConfiguration: function(primaryColumnValue) {
				const activeRow = this.getActiveRow();
				const typeColumnValue = this.getTypeColumnValue(activeRow);
				const schemaName = this.getEditPageSchemaName(typeColumnValue);
				this.set("ShowCloseButton", true);
				this.openCard(schemaName, ConfigurationEnums.CardStateV2.EDIT, primaryColumnValue);
			},

			/**
			 * @inheritodoc BaseSectionV2#initFilters
			 * @override
			 */
			initFilters: function() {
				const sandbox = this.sandbox;
				const quickFilterModuleId = this.getQuickFilterModuleId();
				sandbox.subscribe("GetExtendedFilterConfig", function() {
					const foldersVisible = this.get("IsFolderManagerActionsContainerVisible");
					return {
						isExtendedModeHidden: foldersVisible,
						isFoldersHidden: !foldersVisible
					};
				}, this, [quickFilterModuleId]);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addSectionDesignerViewOptions
			 * @override
			 */
			addSectionDesignerViewOptions: BPMSoft.emptyFn
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "DataGridActiveRowOpenConfigurationAction",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"index": 1,
				"values": {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": {"bindTo": "Resources.Strings.OpenConfigurationButtonCaption"},
					"tag": "openConfiguration"
				}
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			},
			{
				"operation": "merge",
				"name": "CombinedModeActionsButton",
				"values": {
					"visible": false
				}
			},
			{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
