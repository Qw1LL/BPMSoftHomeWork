define("DuplicatesRuleSectionV2", ["DuplicatesRuleSectionV2Resources"],
	function() {
		return {
			entitySchemaName: "DuplicatesRule",
			attributes: {
				/**
				 * Menu sorting columns collection.
				 */
				"DuplicatesRuleTypes": {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},
				"EnableEsDeduplication": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: BPMSoft.Features.getIsEnabled("ESDeduplication")
				},
				SecurityOperationName: {
					dataValueType: BPMSoft.DataValueType.STRING,
					value: "CanManageDuplicatesRules",
				}
			},
			methods: {

				//region Methods: Public

				/**
				 * @inheritdoc
				 * @override
				 */
				checkCanDelete: function() {
					if (!this.get("CanManageDuplicatesRules"))
					{
						this.showPermissionsErrorMessage("CanManageDuplicatesRules");
						return false;
					}
					if (!this.canBeDeletedActiveRow()) {
						const message = this.get("Resources.Strings.NotPossibleDeleteRuleCaption");
						this.showInformationDialog(message);
						return false;
					}
					this.callParent(arguments);
				},

				//endregion

				//region Methods: Protected

				/*
				 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
				 * @overridden
				 */
				getDefaultDataViews: function() {
					var dataViews = this.callParent(arguments);
					delete dataViews.AnalyticsDataView;
					return dataViews;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ContactsDuplicatesSearchCaption"
						},
						"Click": {
							"bindTo": "openContactDuplicatesModule"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.AccountsDuplicatesSearchCaption"
						},
						"Click": {
							"bindTo": "openAccountDuplicatesModule"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuSeparator());
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ScheduleCaption"
						},
						"Click": {
							"bindTo": "openScheduleSettingPage"
						}
					}));
					return actionMenuItems;
				},

				/**
				 * Goes to contact duplicates search page.
				 * @protected
				 */
				openContactDuplicatesModule: function() {
					this.openDuplicatesModule("Contact");
				},

				/**
				 * Goes to account duplicates search page.
				 * @protected
				 */
				openAccountDuplicatesModule: function() {
					this.openDuplicatesModule("Account");
				},

				/**
				 * @inheritdoc
				 * @overridden
				 */
				openDuplicatesModule: function(entityName) {
					this.mixins.DuplicatesSearchUtilities.openDuplicatesModule.call(this, entityName);
				},

				/**
				 * @inheritdoc BaseSectionV2#addSectionDesignerViewOptions
				 * @overridden
				 */
				addSectionDesignerViewOptions: BPMSoft.emptyFn,

				/**
				 * Opens duplicates search schedule page setup.
				 * @protected
				 */
				openScheduleSettingPage: function() {
					const scheduledDuplicatesSearchSettingsSchemaName =
						BPMSoft.Features.getIsEnabled("BulkESDeduplication")
							? "CardModuleV2/ScheduledDuplicatesSearchSettingsPage"
							: "SearchDuplicatesSettingsPage";
					this.sandbox.publish("PushHistoryState", {
						hash: scheduledDuplicatesSearchSettingsSchemaName
					});
				},

				/**
				 * @inheritdoc
				 * @override
				 */
				getGridDataColumns: function(esq) {
					const parentColumns = this.callParent(arguments);
					const columns = {
						Object: {path: "Object"},
						SearchObject: {path: "SearchObject"}
					};
					Ext.apply(parentColumns, columns);
					return parentColumns;
				},

				/**
				 * Gets is possible delete active row.
				 * @protected
				 * @return {Boolean} True if active row is can be deleted.
				 */
				canBeDeletedActiveRow: function() {
					const activeRow = this.getActiveRow();
					const object = activeRow && activeRow.get("Object") || {};
					const searchObject = activeRow && activeRow.get("SearchObject") || {};
					if (this.isEmpty(object.value) || this.isEmpty(searchObject.value)) {
						return true;
					}
					return Boolean(object.value === searchObject.value);
				},

				//endregion
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"values": {
						"visible": {
							"bindTo": "EnableEsDeduplication"
						}
					}
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowCopyAction"
				},
				{
					"operation": "remove",
					"name": "CombinedModeAddRecordButton"
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"canChangeMultiSelectWithGridClick": false
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
