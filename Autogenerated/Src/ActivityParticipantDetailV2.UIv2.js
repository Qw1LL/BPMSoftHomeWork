﻿define("ActivityParticipantDetailV2", ["ConfigurationConstants", "ConfigurationEnums"],
	function(ConfigurationConstants, configurationEnums) {
		return {
			entitySchemaName: "ActivityParticipant",

			attributes: {
				/**
				 * Has current user exchange appointment integration.
				 */
				"HasExchangeAppointmentIntegration": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * Is current user owner or organizer of master activity.
				 */
				"IsOwnerOrOrganizer": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * Master activity owner.
				 */
				"Owner": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP
				},

				/**
				 * Master activity organizer.
				 */
				"Organizer": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP
				}
			},

			messages: {
				/**
				 * @message GetColumnsValues
				 * Master record columns values request message.
				 */
				"GetColumnsValues": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			methods: {
				/**
				 * @inheritdoc BPMSoft.configuration.mixins.GridUtilities#deselectRows
				 * @overridden
				 */
				deselectRows: function() {
					this.set("SelectedRows", []);
					this.set("ActiveRow", "");
				},

				/**
				 * @inheritdoc BPMSoft.configuration.mixins.GridUtilities#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					return {
						"Id": {path: "Id"},
						"Participant": {path: "Participant"},
						"Participant.Name": {path: "Participant.Name"},
						"Participant.JobTitle": {path: "Participant.JobTitle"},
						"Participant.Phone": {path: "Participant.Phone"},
						"Participant.MobilePhone": {path: "Participant.MobilePhone"},
						"Participant.Email": {path: "Participant.Email"},
						"Role": {path: "Role"},
						"InviteParticipant": {path: "InviteParticipant"},
						"InviteResponse": {path: "InviteResponse"}
					};
				},

				/**
				 * Opens contacts lookup window.
				 * @private
				 */
				openContactLookup: function() {
					var BPMSoft = this.BPMSoft;
					var activityId = this.get("MasterRecordId");
					var roleId = ConfigurationConstants.Activity.ParticipantRole.Participant;
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					esq.addColumn("Id");
					esq.addColumn("Participant.Id", "ContactId");
					esq.filters.add("filterActivity", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Activity", activityId));
					esq.filters.add("filterRole", this.BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Role", roleId));
					esq.getEntityCollection(function(result) {
						var existsContactsCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								existsContactsCollection.push(item.get("ContactId"));
							});
						}
						var config = {
							entitySchemaName: "Contact",
							multiSelect: true,
							columns: ["JobTitle", "MobilePhone", "Email", "[SysAdminUnit:Contact].Id"]
						};
						if (existsContactsCollection.length > 0) {
							var existsFilter = BPMSoft.createColumnInFilterWithParameters("Id",
								existsContactsCollection);
							existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
							existsFilter.Name = "existsFilter";
							config.filters = existsFilter;
						}
						this.openLookup(config, this.addCallBack, this);
					}, this);
				},

				/**
				 * @overridden
				 */
				onCardSaved: function() {
					this.openContactLookup();
				},

				/**
				* Opens contact lookup window if activity page saved, calls activity page save otherwise.
				* @overridden
				**/
				addRecord: function() {
					var masterCardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNewRecord = (masterCardState.state === configurationEnums.CardStateV2.ADD ||
						masterCardState.state === configurationEnums.CardStateV2.COPY);
					if (isNewRecord === true) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					this.openContactLookup();
				},

				/**
				* Creates activity participants from selected values.
				* @protected
				**/
				addCallBack: function(args) {
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					var activityId = this.get("MasterRecordId");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						item.ActivityId = activityId;
						bq.add(this.getContactInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						this.showBodyMask.call(this);
						bq.execute(this.onContactInsert, this);
					}
				},

				/**
				* Creates activity participant insert query.
				* @param {Object} item Actitity and contact unique id {ActivityId, value}
				* @private
				**/
				getContactInsertQuery: function(item) {
					var roleId = ConfigurationConstants.Activity.ParticipantRole.Participant;
					var insert = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: this.entitySchemaName
					});
					insert.setParameterValue("Activity", item.ActivityId, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Participant", item.value, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Role", roleId, this.BPMSoft.DataValueType.GUID);
					return insert;
				},

				/**
				* Add created participants into grid.
				* @protected
				**/
				onContactInsert: function(response) {
					this.hideBodyMask.call(this);
					if (this.get("IsGridLoading")) {
						return;
					}
					this.beforeLoadGridData();
					var filterCollection = [];
					response.queryResults.forEach(function(item) {
						filterCollection.push(item.id);
					});
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					this.initQueryColumns(esq);
					esq.filters.add("recordId", BPMSoft.createColumnInFilterWithParameters("Id", filterCollection));
					esq.getEntityCollection(function(response) {
						this.afterLoadGridData();
						if (response.success) {
							var responseCollection = response.collection;
							this.prepareResponseCollection(responseCollection);
							this.getGridData().loadAll(responseCollection);
						}
					}, this);
				},

				/**
				 * Checks can delete participant.
				 * @param {Object} owner Activity owner.
				 * @param {Object} participant Activity participant.
				 * @returns {boolean}
				 */
				canDeleteParticipant: function(owner, participant) {
					return (this.Ext.isEmpty(owner) || participant.value !== owner);
				},

				/**
				 * Deletes selected records, except Owner and Organizer.
				 * @overridden
				 **/
				deleteRecords: function() {
					var selectedRows = this.getSelectedItems();
					var deleteRows = [];
					var gridData = this.getGridData();
					var owner = this.get("Owner");
					owner = owner && owner.value;
					var isResponsibleExists = false;
					selectedRows.forEach(function(rowId) {
						var row = gridData.get(rowId);
						var participant = row.get("Participant");
						if (this.canDeleteParticipant(owner, participant)) {
							deleteRows.push(rowId);
						} else {
							isResponsibleExists = true;
						}
					}, this);
					if (isResponsibleExists) {
						this.showInformationDialog(this.get("Resources.Strings.WarningResponsibleDelete"));
					}
					if (deleteRows.length > 0) {
						this.set("SelectedRows", deleteRows);
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * Returns filtration column name.
				 * @overridden
				 * @return {String} Column name.
				 */
				getFilterDefaultColumnName: function() {
					return "Participant";
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.initOwnerAndOrganizerProperties();
					this.callParent([function() {
						this.initHasExchangeIntegrationProperty(callback, scope);
					}, this]);
				},

				/**
				 * Initializes HasExchangeAppointmentIntegration attribute.
				 * @param {Function} callback Callback function
				 * @param {Object} scope Callback function scope.
				 */
				initHasExchangeIntegrationProperty: function(callback, scope) {
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ActivitySyncSettings"
					});
					select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"MailboxSyncSettings.SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value));
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filterGroup.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"ImportAppointments", true));
					filterGroup.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"ExportActivities", true));
					select.filters.addItem(filterGroup);
					select.getEntityCollection(function(response) {
						var result = response.success ? !response.collection.isEmpty() : false;
						this.set("HasExchangeAppointmentIntegration", result);
						callback.call(scope);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#initToolsButtonMenu
				 * @overridden
				 */
				initToolsButtonMenu: function() {
					this.callParent(arguments);
					var toolsButtonMenu = this.get("ToolsButtonMenu");
					var inviteParticipant = this.getInviteParticipantMenuItem();
					toolsButtonMenu.addItem(inviteParticipant);
					var notInviteParticipant = this.getNotInviteParticipantMenuItem();
					toolsButtonMenu.addItem(notInviteParticipant);
					var inviteSelectedParticipants = this.getInviteSelectedParticipantsMenuItem();
					toolsButtonMenu.addItem(inviteSelectedParticipants);
					var dontInviteSelectedParticipants = this.getDontInviteSelectedParticipantsMenuItem();
					toolsButtonMenu.addItem(dontInviteSelectedParticipants);
				},

				/**
				 * Generates "Invite participant" menu item.
				 * @return {BPMSoft.BaseViewModel}
				 */
				getInviteParticipantMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.InviteParticipant"},
						Click: {"bindTo": "setInviteSelectedParticipants"},
						Tag: true,
						Visible: {bindTo: "isInviteParticipantActionVisible"},
						Enabled: {bindTo: "isInviteParticipantEnabled"}
					});
				},

				/**
				 * Generates "Don't invite participant" menu item.
				 * @return {BPMSoft.BaseViewModel}
				 */
				getNotInviteParticipantMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.DontInviteParticipant"},
						Click: {"bindTo": "setInviteSelectedParticipants"},
						Visible: {bindTo: "isDontInviteParticipantActionVisible"},
						Enabled: {bindTo: "isInviteParticipantEnabled"}
					});
				},

				/**
				 * Generates "Invite selected participants" menu item.
				 * @return {BPMSoft.BaseViewModel}
				 */
				getInviteSelectedParticipantsMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.InviteSelectedParticipants"},
						Click: {"bindTo": "setInviteSelectedParticipants"},
						Tag: true,
						Visible: {bindTo: "isInviteParticipantsActionVisible"},
						Enabled: {bindTo: "isInviteParticipantEnabled"}
					});
				},

				/**
				 * Generates "Don't invite selected participants" menu item.
				 * @return {BPMSoft.BaseViewModel}
				 */
				getDontInviteSelectedParticipantsMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.DontInviteSelectedParticipants"},
						Click: {"bindTo": "setInviteSelectedParticipants"},
						Visible: {bindTo: "isInviteParticipantsActionVisible"},
						Enabled: {bindTo: "isInviteParticipantEnabled"}
					});
				},

				/**
				 * Checks, if invite participant menu items enabled.
				 * @return {Boolean} Menu item enabled.
				 */
				isInviteParticipantEnabled: function() {
					var selectedRows = this.getSelectedRowsWithoutOwnerAndOrganizer();
					return !this.Ext.isEmpty(selectedRows);
				},

				/**
				 * Returns "Invite participant" tools button menu item visibility.
				 * @return {Boolean} "Invite participant" tools button menu item visibility.
				 */
				isInviteParticipantActionVisible: function() {
					var multiSelect = this.get("MultiSelect");
					var hasIntegration = this.get("HasExchangeAppointmentIntegration");
					var isOwnerOrOrganizer = this.get("IsOwnerOrOrganizer");
					var isVisible = hasIntegration && isOwnerOrOrganizer && !multiSelect;
					if (!isVisible) {
						return false;
					}
					var primaryColumnValue = this.get("ActiveRow");
					if (!primaryColumnValue) {
						return isVisible;
					}
					var gridData = this.getGridData();
					var selectedRow = gridData.get(primaryColumnValue);
					var inviteSelected = selectedRow.get("InviteParticipant");
					return isVisible && !inviteSelected;
				},

				/**
				 * Returns "Don't invite participant" tools button menu item visibility.
				 * @return {Boolean} "Don't invite participant" tools button menu item visibility.
				 */
				isDontInviteParticipantActionVisible: function() {
					var multiSelect = this.get("MultiSelect");
					var hasIntegration = this.get("HasExchangeAppointmentIntegration");
					var primaryColumnValue = this.get("ActiveRow");
					var isOwnerOrOrganizer = this.get("IsOwnerOrOrganizer");
					var isVisible = hasIntegration && isOwnerOrOrganizer && !multiSelect;
					if (!isVisible || !primaryColumnValue) {
						return false;
					}
					var gridData = this.getGridData();
					var selectedRow = gridData.get(primaryColumnValue);
					var inviteSelected = selectedRow.get("InviteParticipant");
					return isVisible && inviteSelected;
				},

				/**
				 * Returns "Invite participants", "Don't invite participants" tools button menu item visibility.
				 * @return {Boolean} "Invite participants", "Don't invite participants" tools button menu item
				 * visibility.
				 */
				isInviteParticipantsActionVisible: function() {
					var multiSelect = this.get("MultiSelect");
					var hasIntegration = this.get("HasExchangeAppointmentIntegration");
					var isOwnerOrOrganizer = this.get("IsOwnerOrOrganizer");
					var isVisible = hasIntegration && isOwnerOrOrganizer && multiSelect;
					return isVisible;
				},

				/**
				 * Set "InviteParticipant" column value for selected participants.
				 * @param {Boolean|*} tag Value to set.
				 */
				setInviteSelectedParticipants: function(tag) {
					if (!this.isAnySelected()) {
						return;
					}
					var setValue = tag || false;
					var selectedRows = this.getSelectedRowsWithoutOwnerAndOrganizer();
					if (this.Ext.isEmpty(selectedRows)) {
						return;
					}
					var update = this.Ext.create("BPMSoft.UpdateQuery", {rootSchemaName: this.entitySchemaName});
					update.filters.add("SelectedParticipantsFilter",
						this.BPMSoft.createColumnInFilterWithParameters("Id", selectedRows));
					update.setParameterValue("InviteParticipant", setValue, this.BPMSoft.DataValueType.BOOLEAN);
					this.showBodyMask();
					update.execute(this.onInviteParticipantSaved, this);
				},

				/**
				 * Checks if contact is owner or organizer of master record.
				 * @param {Guid} contactId Contact id.
				 * @return {boolean} True, if contact is owner or organizer of master record, false otherwise.
				 */
				isContactOwnerOrOrganizer: function(contactId) {
					var organizer = this.get("Organizer");
					organizer = organizer ? organizer.value : null;
					var owner = this.get("Owner");
					owner = owner ? owner.value : null;
					if ((!this.Ext.isEmpty(organizer) && organizer === contactId) ||
							(!this.Ext.isEmpty(owner) && owner === contactId)) {
						return true;
					}
					return false;
				},

				/**
				 * Handles "InviteParticipant" column update response.
				 */
				onInviteParticipantSaved: function() {
					this.hideBodyMask();
					this.updateDetail({reloadAll: true});
				},

				/**
				 * Initializes Owner, Organizer and IsOwnerOrOrganizer attributes.
				 */
				initOwnerAndOrganizerProperties: function() {
					var sandbox = this.sandbox;
					var columns = ["Owner", "Organizer"];
					var isOwnerOrOrganizer = false;
					var currentContact = this.BPMSoft.SysValue.CURRENT_USER_CONTACT;
					var values = sandbox.publish("GetColumnsValues", columns, [sandbox.id]);
					this.BPMSoft.each(columns, function(column) {
						if (values.hasOwnProperty(column) && !this.Ext.isEmpty(values[column])) {
							var columnValue = values[column];
							this.set(column, columnValue);
							if (currentContact.value === columnValue.value) {
								isOwnerOrOrganizer = true;
							}
						}
					}, this);
					this.set("IsOwnerOrOrganizer", isOwnerOrOrganizer);
				},

				/**
				 * Returns selected rows, except owner and organizer participants.
				 * @return {Array} Selected rows, except owner and organizer participants.
				 */
				getSelectedRowsWithoutOwnerAndOrganizer: function() {
					var selectedRows = this.getSelectedItems();
					if (this.Ext.isEmpty(selectedRows)) {
						return null;
					}
					var gridData = this.getGridData();
					selectedRows = selectedRows.filter(function(rowId) {
						var row = gridData.get(rowId);
						var inviteResponse = row.get("InviteResponse");
						var inviteConfirmation = ConfigurationConstants.Activity.ParticipantInviteResponse;
						var contact = row.get("Participant");
						return !BPMSoft.contains([inviteConfirmation.Confirmed, inviteConfirmation.Declined],
								inviteResponse.value) && !this.isContactOwnerOrOrganizer(contact.value);
					}, this);
					return selectedRows;
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#updateDetail
				 * @overridden
				 */
				updateDetail: function(config) {
					this.callParent(arguments);
					if (config.reloadAll) {
						this.initOwnerAndOrganizerProperties();
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseDetailV2#getToolsVisible
				 */
				getToolsVisible: function() {
					return this.callParent(arguments) && this.get("CanEditMasterRecord");
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"primaryDisplayColumnName": "Participant.Name",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "ParticipantListedGridColumn",
									"bindTo": "Participant",
									"position": {
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "ParticipantJobTitleListedGridColumn",
									"bindTo": "Participant.JobTitle",
									"position": {
										"column": 13,
										"colSpan": 11
									}
								},
								{
									"name": "RoleListedGridColumn",
									"bindTo": "Role",
									"position": {
										"column": 25,
										"colSpan": 8
									}
								},
								{
									"name": "ParticipantPhoneListedGridColumn",
									"bindTo": "Participant.Phone",
									"position": {
										"column": 33,
										"colSpan": 8
									}
								},
								{
									"name": "ParticipantMobilePhoneListedGridColumn",
									"bindTo": "Participant.MobilePhone",
									"position": {
										"column": 41,
										"colSpan": 8
									}
								},
								{
									"name": "ParticipantEmailListedGridColumn",
									"bindTo": "Participant.Email",
									"position": {
										"column": 49,
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
									"name": "ParticipantTiledGridColumn",
									"bindTo": "Participant",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "ParticipantJobTitleTiledGridColumn",
									"bindTo": "Participant.JobTitle",
									"position": {
										"row": 1,
										"column": 13,
										"colSpan": 11
									}
								},
								{
									"name": "RoleTiledGridColumn",
									"bindTo": "Role",
									"position": {
										"row": 1,
										"column": 25,
										"colSpan": 8
									}
								},
								{
									"name": "ParticipantPhoneTiledGridColumn",
									"bindTo": "Participant.Phone",
									"position": {
										"row": 1,
										"column": 33,
										"colSpan": 8
									}
								},
								{
									"name": "ParticipantMobilePhoneTiledGridColumn",
									"bindTo": "Participant.MobilePhone",
									"position": {
										"row": 1,
										"column": 41,
										"colSpan": 8
									}
								},
								{
									"name": "ParticipantEmailTiledGridColumn",
									"bindTo": "Participant.Email",
									"position": {
										"row": 1,
										"column": 49,
										"colSpan": 8
									}
								}
							]
						}
					}
				},
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"values": {
						"visible": {"bindTo": "getToolsVisible"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
