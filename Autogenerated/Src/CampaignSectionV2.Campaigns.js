define("CampaignSectionV2", ["CampaignSectionV2Resources", "MarketingEnums", "ConfigurationEnums", "GridUtilitiesV2"],
	function(resources, MarketingEnums) {
		return {
			entitySchemaName: "Campaign",
			attributes: {
				/**
				 * Identifier of old campaign designer type.
				 */
				"OldDesignerTypeId": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.STRING,
					value: "389eb587-52d4-4ab6-b4ad-e7e2f0d62eac"
				},

				/**
				 * Identifier of new campaign designer type.
				 */
				"NewDesignerTypeId": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.STRING,
					value: "235273bb-91cb-47fc-8a34-01f0002e38d4"
				}
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#openCard
				 * @overriden
				 */
				openCard: function(schemaName, operation, primaryColumnValue) {
					this.set("ShowGridMask", true);
					var schemaStructure = this.getModuleStructure();
					var moduleName = schemaStructure ?
						(schemaStructure.cardModule || schemaStructure.sectionModule) : "CardModuleV2";
					this.sandbox.publish("PushHistoryState", {
						hash: Ext.String.format("{0}/{1}/{2}/{3}",
							moduleName, schemaName, operation, primaryColumnValue)
					});
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#initAddRecordButtonParameters
				 * @overriden
				 */
				initAddRecordButtonParameters: function() {
					var caption = this.get("Resources.Strings.AddRecordButtonCaption");
					var editPages = this.get("EditPages");
					var newDesignerType = this.get("NewDesignerTypeId");
					var editPage = editPages.get(newDesignerType);
					var tag = editPage.get("Tag");
					this.set("AddRecordButtonCaption", editPage.get("Caption") || caption);
					this.set("AddRecordButtonTag", tag);
					this.set("IsAddRecordButtonVisible", true);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#addRecord
				 * @overriden
				 */
				addRecord: function() {
					var tag = this.get("AddRecordButtonTag");
					return this.callParent([tag]);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilities#getGridDataColumns
				 * @overriden
				 */
				getGridDataColumns: function() {
					var defColumnsConfig = this.callParent(arguments);
					defColumnsConfig.CampaignStatus = {path: "CampaignStatus"};
					return defColumnsConfig;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getSectionActions
				 * @overriden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.createOpenCampaignLogMenuItem());
					return actionMenuItems;
				},

				/**
				 * Creates "OpenCampaignLog" menu item.
				 * @return {BPMSoft.BaseViewModel} Menu item.
				 */
				createOpenCampaignLogMenuItem: function() {
					return this.getButtonMenuItem({
						Click: {bindTo: "openCampaignLog"},
						Caption: {bindTo: "Resources.Strings.OpenCampaignLogCaption"}
					});
				},

				/**
				 * Opens campaign log.
				 */
				openCampaignLog: function() {
					this.sandbox.publish("PushHistoryState", {hash: "SectionModuleV2/CampaignLogSectionV2"});
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#addColumnLink
				 * @overriden
				 */
				addColumnLink: function(item) {
					var self = this;
					item.getCopyGridRowButtonVisible = function() {
						return self.getCopyGridRowButtonVisible(item);
					};
					return this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#deleteRecords
				 * @overriden
				 */
				deleteRecords: function() {
					var isMultiSelectAccept = this.get("MultiSelect");
					var canDelete = this._checkCanDelete(isMultiSelectAccept);
					if (!canDelete) {
						var message = this._getCanNotDeleteCampaignMessage(isMultiSelectAccept);
						return this.showInformationDialog(message);
					}
					this.callParent(arguments);
				},

				/**
				 * Checks selected campaign record to be deleted.
				 * If campaign is in active status it cannot be removed.
				 * @private
				 * @param {BaseSectionGridRowViewModel} record CampaignSectionGridRowViewModel by Campaign entity.
				 * @returns {Boolean} True if deleted campaign record isn't in active status.
				 */
				_validateCampaignBeforeDelete: function(record) {
					var currentStatus = record.get("CampaignStatus");
					return currentStatus.value === MarketingEnums.CampaignStatus.PLANNED;
				},

				/**
				 * Validates selected campaign records to be deleted.
				 * @private
				 * @param {Boolean} isMultiSelectAccept MultiSelect mode is active.
				 * @returns {Boolean} True if record(s) can be deleted.
				 */
				_checkCanDelete: function(isMultiSelectAccept) {
					var canDelete = true;
					if (isMultiSelectAccept) {
						var recordsToDelete = this.getSelectedItems();
						BPMSoft.each(recordsToDelete, function(id) {
							var campaign = this.getGridDataRow(id);
							canDelete = this._validateCampaignBeforeDelete(campaign);
							return canDelete;
						}, this);
					} else {
						var item = this.getActiveRow();
						canDelete = this._validateCampaignBeforeDelete(item);
					}
					return canDelete;
				},

				/**
				 * Returns message with info that active campaigns can not be remeved.
				 * @private
				 * @param {Boolean} isMultiSelectAccept MultiSelect mode is active.
				 * @returns {String} Message to display.
				 */
				_getCanNotDeleteCampaignMessage: function(isMultiSelectAccept) {
					if (isMultiSelectAccept) {
						var recordsToDelete = this.getSelectedItems();
						if (recordsToDelete.length > 1) {
							return resources.localizableStrings.RemoveMultipleActiveCampaignsValidationMessage;
						}
					}
					return resources.localizableStrings.RemoveActiveCampaignValidationMessage;
				},

				/**
				 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getIsDeduplicationEnable
				 * @override
				 */
				getIsDeduplicationEnable: function() {
					return false;
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"values": {
						"controlConfig": {
							"menu": {
								"items": {
									"bindTo": "EditPages",
									"bindConfig": {
										"converter": function() {
											return null;
										}
									}
								}
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
