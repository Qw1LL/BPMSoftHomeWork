define("LeadContactsInFolderDetailV2", ["ext-base", "BPMSoft", "sandbox",  "ConfigurationConstants",
		"ConfigurationEnums"],
	function(Ext, BPMSoft, sandbox, ConfigurationConstants, Enums) {
		return {
			entitySchemaName: "ContactInFolder",
			methods: {

				/**
				 * ########## #######, ####### ###### ########## ########.
				 * @protected
				 * @overriden
				 * @return {Object} ########## ###### ########-############ #######.
				 */
				getGridDataColumns: function() {
					return {
						"Id": {path: "Id"},
						"Folder": {path: "Folder"}
					};
				},

				/**
				 * ##### ######## "######## ##### #########".
				 * @private
				 */
				addContactFolder: function() {
					var masterColumnValue = this.get("MasterRecordId");
					var config = {
						entitySchemaName: "ContactFolder",
						multiSelect: true,
						columns: ["FolderType", "Id"]
					};
					var existsFilterGroup = this.BPMSoft.createFilterGroup();
					existsFilterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Contact", masterColumnValue.value));
					var existsFilter = this.BPMSoft.createNotExistsFilter("[ContactInFolder:Folder:Id].Contact",
						existsFilterGroup);
					var filterGroup = this.BPMSoft.createFilterGroup();
					filterGroup.addItem(existsFilter);
					var folderFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "FolderType", ConfigurationConstants.Folder.Type.General);
					filterGroup.addItem(folderFilter);
					config.filters = filterGroup;
					this.openLookup(config, this.addContactCallback, this);
				},

				/**
				 * Callback-#######, ############# ##### ########## ##### #########.
				 * @private
				 * @param {Object} args #########.
				 */
				addContactCallback: function(args) {
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					var contactId = this.get("MasterRecordId");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						item.ContactId = contactId;
						bq.add(this.getContactInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length > 0) {
						bq.execute(function(response) {
							if (response && response.success) {
								this.reloadGridData();
							}
						}, this);
					}
				},

				/*
				 * ########## ###### ## ########## ######## # ########### ######.
				 * @param args {Object} ############# ######## # ######### # ########### ###### {ContactId, value}				 *
				 * @private
				 * return {Object} ###### ######.
				 */
				getContactInsertQuery:  function(item) {
					var insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "ContactInFolder"
					});
					insert.setParameterValue("Contact", item.ContactId, BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Folder", item.value, BPMSoft.DataValueType.GUID);
					return insert;
				},

				/**
				 * ########## ######## ########### ######.
				 * @protected
				 * @return {Boolean} ######## ########### ######.
				 */
				getAddRecordButtonVisible: function() {
					return this.getToolsVisible();
				},

				/**
				 * ######### ######### ###### ## ###########.
				 * @protected
				 * @overriden
				 */
				addRecord: function() {
					var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNew = (cardState.state === Enums.CardStateV2.ADD ||
						cardState.state === Enums.CardStateV2.COPY);
					if (isNew) {
						this.set("CardState", Enums.CardStateV2.ADD);
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
					} else {
						this.addContactFolder();
					}
				},

				/**
				 * ######## ##### ########## ######### # ###### ##### ########## ########.
				 * @protected
				 * @overridden
				 */
				onCardSaved: function() {
					this.addContactFolder();
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
				getEditRecordMenuItem: BPMSoft.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "addContactFolder"},
						"visible": {"bindTo": "getAddRecordButtonVisible"},
						"enabled": {"bindTo": "getAddRecordButtonEnabled"}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
