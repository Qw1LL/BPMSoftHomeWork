define("CaseNextStatusDetail", ["ConfigurationEnums"],
	function(enums) {
		return {
			entitySchemaName: "CaseNextStatus",
			attributes: {},
			diff: /**SCHEMA_DIFF*/[],/**SCHEMA_DIFF*/
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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,
				/**
				 * ######### ###### ## ####### ### ############ ## ###### #######.
				 * @returns {BPMSoft.EntitySchemaQuery}
				 */
				getAlreadyExistsRecordsQuery: function() {
					var masterRecordId = this.get("MasterRecordId");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "CaseNextStatus"
					});
					esq.addColumn("NextStatus");
					esq.filters.add("sectionSchemaFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Status", masterRecordId));
					return esq;
				},
				/**
				 * ########## ########### ###### ########## ######.
				 * @overridden
				 * @return {Boolean}
				 */
				getAddRecordButtonEnabled: function() {
					var isFinalStaus = this.sandbox.publish("UpdateIsFinalStatus", null, [this.sandbox.id]);
					return !isFinalStaus;
				},
				/**
				 * ########## #######
				 * @overridden
				 * */
				addRecord: function() {
					this.set("CardState", enums.CardStateV2.ADD);
					var args = {
						isSilent: true,
						messageTags: [this.sandbox.id]
					};
					this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
				},
				/**
				 * ######### ########## ####### ##### LookupEntitySchema ##### ##########
				 * ##### ###### ####### # ###### ########## ####### ## ######.
				 * @overridden
				 * @protected
				 * @virtual
				 */
				onCardSaved: function() {
					this.addDetailRecord();
				},
				/**
				 * ######### ########## ####### ##### LookupEntitySchema.
				 */
				addDetailRecord: function() {
					var lookupConfig = {
						entitySchemaName: "CaseStatus",
						multiSelect: true,
						valuePairs: this.get("DefaultValues")
					};
					var esq = this.getAlreadyExistsRecordsQuery();
					esq.getEntityCollection(function(result) {
						var existsCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								var record = item.get("NextStatus");
								existsCollection.push(record.value);
							}, this);
						}
						var filterGroup = BPMSoft.createFilterGroup();
						if (existsCollection.length > 0) {
							var existsFilter = this.BPMSoft.createColumnInFilterWithParameters("Id",
								existsCollection);
							existsFilter.Name = "existsFilter";
							existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
							filterGroup.add("existsFilter", existsFilter);
						}
						filterGroup.add("notSelfFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", this.get("MasterRecordId")));
						lookupConfig.filters = filterGroup;
						this.openLookup(lookupConfig, this.addRecordCallback, this);
					}, this);
				},
				/**
				 * ######### ###### # ####### ##### ########.
				 * @param {Object} args ######### ######.
				 */
				addRecordCallback: function(args) {
					var bq = Ext.create("BPMSoft.BatchQuery");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						bq.add(this.getSchemaInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						bq.execute(this.onRecordsInserted, this);
					}
				},
				/**
				 * #### ######### ########## ####### ## ######.
				 */
				onRecordsInserted: function() {
					this.updateDetail({reloadAll: true});
				},
				/**
				 * ######### # ########## ###### ## ########## ####### # ####### ##### ########.
				 * @param {Object} item ###### ### ##########.
				 * @returns {BPMSoft.InsertQuery} ###### ## ##########.
				 */
				getSchemaInsertQuery: function(item) {
					var masterRecordId = this.get("MasterRecordId");
					var insert = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "CaseNextStatus"
					});
					insert.setParameterValue("Status", masterRecordId,
						this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("NextStatus", item.value, this.BPMSoft.DataValueType.GUID);
					return insert;
				},
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return true;
				}
			},
			messages: {
				/**
				 * @message UpdateIsFinalStatus
				 * ######## ###### ## ######### ######## ######### #########.
				 */
				"UpdateIsFinalStatus": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			}
		};
	}
);
