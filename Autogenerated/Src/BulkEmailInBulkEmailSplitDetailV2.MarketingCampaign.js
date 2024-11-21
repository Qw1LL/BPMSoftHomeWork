define("BulkEmailInBulkEmailSplitDetailV2", ["BulkEmailInBulkEmailSplitDetailV2Resources", "ConfigurationEnums",
		"MarketingEnums"],
	function(resources, configurationEnums, MarketingEnums) {
		return {
			entitySchemaName: "BulkEmail",
			attributes: {
				/**
				 * ####, ########### ## ########### ############## ###### ########.
				 * */
				"IsBulkEmailEditable": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				}
			},
			messages: {
				/**
				 * @message SetBulkEmailDetailEditable
				 * ############# ####### ########### ############## ####### ## ######.
				 */
				"SetBulkEmailDetailEditable": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetBulkEmailDetailEditable
				 * ######## ####### ########### ############## ####### ## ######.
				 */
				"GetBulkEmailDetailEditable": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddTypedRecordButtonVisible
				 * @overridden
				 */
				getAddTypedRecordButtonVisible: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.DeleteMenuCaption"},
						Click: {"bindTo": "onDeleteAccept"},
						Visible: {"bindTo": "IsBulkEmailEditable"}
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#onCardSaved
				 * @overridden
				 */
				onCardSaved: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "getSwitchGridModeMenuCaption"},
						Click: {"bindTo": "switchGridMode"},
						Visible: {"bindTo": "IsBulkEmailEditable"}
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.getBulkEmailEditable();
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("SetBulkEmailDetailEditable", function(value) {
						this.set("IsBulkEmailEditable", value);
					}, this, [this.sandbox.id]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecord
				 * @overridden
				 */
				addRecord: function() {
					var masterCardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNewRecord = (masterCardState.state === configurationEnums.CardStateV2.ADD ||
					masterCardState.state === configurationEnums.CardStateV2.COPY);
					if (isNewRecord === true) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id],
							callback: this.openBulkEmailLookup,
							scope: this
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					this.openBulkEmailLookup();
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#onDeleteAccept
				 * @overridden
				 */
				onDeleteAccept: function() {
					this.showBodyMask();
					var primaryColumnValues = this.getSelectedItems();
					if (primaryColumnValues && primaryColumnValues.length) {
						var bq = this.Ext.create("BPMSoft.BatchQuery");
						primaryColumnValues.forEach(function(item) {
							var deleteItem = {
								SplitTestId: null,
								BulkEmailId: item
							};
							bq.add(this.getBulkEmailSplitUpdateQuery(deleteItem));
						}, this);
						if (bq.queries.length) {
							bq.execute(function() {								
								this.removeGridRecords(primaryColumnValues);
								this.sandbox.publish("DetailChanged", null, [this.sandbox.id]);
							}, this);
						}
					}
					this.hideBodyMask.call(this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDetailInfo
				 * @overridden
				 */
				getDetailInfo: function() {
					var detailInfo = this.callParent(arguments);
					this.getBulkEmailEditable();
					return detailInfo;
				},

				/**
				 * ######### ########## ########.
				 * @private
				 */
				openBulkEmailLookup: function() {
					var config = {
						entitySchemaName: "BulkEmail",
						multiSelect: true,
						columns: ["Name"],
						excludedTypes: [MarketingEnums.BulkEmailCategory.TRIGGERED_EMAIL]
					};
					var filters = BPMSoft.createFilterGroup();
					var filterBulkEmailPlanned = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Status", MarketingEnums.BulkEmailStatus.PLANNED);
					var filterHaveRecipien = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "RecipientCount", 0);
					var filterHaveNoTest = BPMSoft.createIsNullFilter(Ext.create("BPMSoft.ColumnExpression", {
						columnPath: "SplitTest"
					}));
					var filterCategory = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Category", MarketingEnums.BulkEmailCategory.MASS_MAILING);
					filters.addItem(filterBulkEmailPlanned);
					filters.addItem(filterHaveRecipien);
					filters.addItem(filterHaveNoTest);
					filters.addItem(filterCategory);
					config.filters = filters;
					this.openLookup(config, this.addCallBack, this);
				},

				/**
				 * ########## ######### ######## ## ######.
				 * @private
				 * @param {Object} args ###### ########## ######### ####### # #### ###########.
				 */
				addCallBack: function(args) {
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					var bulkEmailSplitId = this.get("MasterRecordId");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						item.BulkEmailId = item.value;
						item.SplitTestId = bulkEmailSplitId;
						bq.add(this.getBulkEmailSplitUpdateQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						this.showBodyMask.call(this);
						bq.execute(this.onBulkEmailSplitInsert, this);
					}
				},

				/**
				 * ########## ###### ## ########## ########.
				 * @param {Object} item ############# #####-##### # ######### ###### # ########### ########.
				 * {SplitTestId, BulkEmailId}
				 * @private
				 */
				getBulkEmailSplitUpdateQuery: function(item) {
					var update = Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: this.entitySchemaName
					});
					update.setParameterValue("SplitTest", item.SplitTestId, BPMSoft.DataValueType.GUID);
					var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id",
						item.BulkEmailId);
					update.filters.add("IdFilter", idFilter);
					return update;
				},

				/**
				 * ######## ####### # ######.
				 * @private
				 */
				onBulkEmailSplitInsert: function() {
					this.hideBodyMask.call(this);
					this.beforeLoadGridData();
					var filterCollection = [];
					this.selectedRows.forEach(function(item) {
						filterCollection.push(item.value);
					});
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					this.initQueryColumns(esq);
					esq.filters.add("recordId", BPMSoft.createColumnInFilterWithParameters("Id", filterCollection));
					this.initQueryEvents(esq);
					esq.getEntityCollection(function(response) {
						this.afterLoadGridData();
						if (response.success) {
							var responseCollection = response.collection;
							this.prepareResponseCollection(responseCollection);
							this.addItemsToGridData(responseCollection, {"mode": "top"});
							this.sandbox.publish("DetailChanged", null, [this.sandbox.id]);
						}
					}, this);
				},

				/**
				 * ########## ####### ########### ############## ####### ## ######.
				 * @private
				 * @return {Boolean}
				 */
				getBulkEmailEditable: function() {
					var isDetailEditable = this.sandbox.publish("GetBulkEmailDetailEditable", null,
						[this.sandbox.id]);
					this.set("IsBulkEmailEditable", isDetailEditable);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "addRecord"},
						"visible": {"bindTo": "IsBulkEmailEditable"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
