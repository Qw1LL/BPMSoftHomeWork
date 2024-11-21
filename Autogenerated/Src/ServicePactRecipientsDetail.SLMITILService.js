define("ServicePactRecipientsDetail", ["ServiceDeskConstants"],
	function(ServiceDeskConstants) {
		return {
			entitySchemaName: "ServiceInServicePact",
			messages: {
				/*
				* @message
				* Updates service recipients detail.
				* */
				"UpdateServiceRecepientsDetail": {
					"mode": this.BPMSoft.MessageMode.PTP,
					"direction": this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * Inititialize detail lookup and section schema name.
				 * @protected
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "ServicePact";
					config.sectionEntitySchema = this.get("DetailColumnName");
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				},

				/**
				 * @inheritdoc BPMSoft.BaseManyToManyGridDetail#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.DeleteMenuCaption"},
						Click: {"bindTo": "deleteRecords"},
						Enabled: {bindTo: "getDeleteRecordMenuItemEnabled"}
					});
				},

				/**
				 * Returns delete record button menu item enabled.
				 * @protected
				 * @returns {BPMSoft.FilterGroup} Button menu item enabled.
				 */
				getDeleteRecordMenuItemEnabled: function() {
					if (!this.isAnySelected()) {
						return false;
					}
					var detailColumnName = this.get("DetailColumnName");
					if (detailColumnName === "Contact") {
						var activeRow = this.getActiveRow();
						if (activeRow) {
							var contact = activeRow.get("Contact");
							return contact && contact !== this.BPMSoft.GUID_EMPTY;
						}
					}
					return true;
				},

				/**
				 * @inheritdoc BPMSoft.BaseManyToManyGridDetail#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					if (!gridDataColumns.Contact) {
						gridDataColumns.Contact = {
							path: "Contact"
						};
					}
					return gridDataColumns;
				},

				/**
				 * @inheritdoc BPMSoft.BaseManyToManyGridDetail#getSchemaInsertQuery
				 * @overridden
				 */
				getSchemaInsertQuery: function() {
					var insert = this.callParent(arguments);
					var detailColumnName = this.get("DetailColumnName");
					if (detailColumnName) {
						var detailColumnType = detailColumnName === "Contact" ?
								ServiceDeskConstants.ServiceObjectType.Contact :
								ServiceDeskConstants.ServiceObjectType.Account;
						insert.setParameterValue("Type", detailColumnType,
							this.BPMSoft.DataValueType.GUID);
					}
					return insert;
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return !BPMSoft.isCurrentUserSsp() && this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseManyToManyGridDetail#onRecordsInserted
				 * @overridden
				 */
				onRecordsInserted: function() {
					this.callParent(arguments);
					this.sandbox.publish("UpdateServiceRecepientsDetail");
				},

				/**
				 * @inheritdoc BPMSoft.BaseManyToManyGridDetail#onRecordsInserted
				 * @overridden
				 */
				onDeleted: function() {
					this.callParent(arguments);
					this.sandbox.publish("UpdateServiceRecepientsDetail");
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#initDefaultCaption
				 * @override
				 */
				initDefaultCaption: function() {
					if (this.BPMSoft.isCurrentUserSsp()) {
						this.set("Caption", this.get("Resources.Strings.ActiveServicePacts"));
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getFilters
				 * @override
				 */
				getFilters: function() {
					const filters = this.callParent(arguments);
					if (this.BPMSoft.isCurrentUserSsp()) {
						const filterGroup = new BPMSoft.createFilterGroup();
						filterGroup.add("Active", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "ServicePact.Status.IsActive", true)
						);
						filterGroup.add("EndDate", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.GREATER_OR_EQUAL,
							"ServicePact.EndDate", this.BPMSoft.endOfDay(new Date()))
						);
						filters.add(filterGroup);
					}
					return filters;
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
