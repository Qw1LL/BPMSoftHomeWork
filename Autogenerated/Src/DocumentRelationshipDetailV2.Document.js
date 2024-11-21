define("DocumentRelationshipDetailV2", ["ConfigurationEnums"], function(enums) {
	return {
		entitySchemaName: "DocumentRelationship",
		attributes: {},
		methods: {
			/**
			 * ########## ######### ## ########## ############ ######## ############## # ########## #####
			 * ######## ########### ########## ### ##### # #########.
			 * @private
			 */
			linkWithExisting: function() {
				var editPages = this.get("EditPages");
				if (editPages.getCount() === 0) {
					return;
				}
				var editPage = editPages.getByIndex(0);
				var editPageUId = editPage.get("Tag");
				var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
				var isNew = (cardState.state === enums.CardStateV2.ADD ||
				cardState.state === enums.CardStateV2.COPY);
				if (isNew) {
					this.set("CardState", enums.CardStateV2.ADD);
					this.set("EditPageUId", editPageUId);
					var scope = this;
					var args = {
						isSilent: true,
						callback: function() {
							scope.openDocumentLookupToLink();
						},
						messageTags: [this.sandbox.id]
					};
					this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
				} else {
					this.openDocumentLookupToLink();
				}
			},

			/**
			 * ######### ########## ########## ### ###### #######,
			 * ####### ########## ####### # ####### ##########.
			 * @private
			 */
			openDocumentLookupToLink: function() {
				var config = {
					entitySchemaName: "Document",
					multiSelect: true,
					columns: ["Number", "Account", "Type", "State"]
				};
				var recordId = this.get("MasterRecordId");
				var filters = this.BPMSoft.createFilterGroup();
				var idFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.NOT_EQUAL,
					"Id", recordId);
				filters.addItem(idFilter);
				var notExistsFilter = this.BPMSoft.createNotExistsFilter("[DocumentRelationship:DocumentB].DocumentA");
				filters.addItem(notExistsFilter);
				config.filters = filters;
				this.openLookup(config, this.linkSelectedRecords, this);
			},

			/**
			 * ######### ##### ### ######### ####### # ####### ##########.
			 * ########## ####### ########### ####### # # ##### ########## #########,
			 * ####### ########## #### #########.
			 * @param {Object} args ###### #### {columnName: string, selectedRows: []}.
			 * ######## ###### ######### ####### ## ###########.
			 * @private
			 */
			linkSelectedRecords: function(args) {
				var selectedRows = args.selectedRows.getItems();
				var totalCount = selectedRows.length;
				var addedCount = 0;
				var callsCount = 0;
				this.BPMSoft.each(selectedRows, function(item) {
					callsCount++;
					var insert = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "DocumentRelationship"
					});
					insert.setParameterValue("DocumentA", this.get("MasterRecordId"), this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("DocumentB", item.value, this.BPMSoft.DataValueType.GUID);
					insert.execute(function(response) {
						if (response && response.success) {
							addedCount++;
						}
						if (callsCount === totalCount) {
							var resultMessage =
								this.Ext.String.format(this.get("Resources.Strings.AddedLinksCountMessage"),
									addedCount, totalCount);
							this.BPMSoft.showInformation(resultMessage);
							this.reloadGridData();
						}
					}, this);
				}, this);
			},

			/**
			 * ####### ##### ############ ######## # ####### #########.
			 * @private
			 */
			deleteLinkWithDocuments: function() {
				this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
						function(returnCode) {
					if (returnCode !== this.BPMSoft.MessageBoxButtons.YES.returnCode) {
						return;
					}
					this.showBodyMask();
					var selectedRows = this.getSelectedItems();
					var deleteQuery = this.Ext.create("BPMSoft.DeleteQuery", {
						rootSchemaName: "DocumentRelationship"
					});
					var masterRecordId = this.get("MasterRecordId");
					var filters = this.getDeleteRelationFilters(masterRecordId, selectedRows);
					deleteQuery.filters.add("DocumentsFilter", filters);
					deleteQuery.execute(function() {
						this.hideBodyMask();
						this.deselectRows();
						this.reloadGridData();
					}, this);
				}, [this.BPMSoft.MessageBoxButtons.YES.returnCode, this.BPMSoft.MessageBoxButtons.NO.returnCode]);
			},

			/**
			 * ########## ###### ### ######## ###### ########## ## DocumentRelationship ## Id ####### ####### Document.
			 * @protected
			 * @param {GUID} masterRecordId Id ###### #######.
			 * @param {Array} relatedDocumentIds Id ######### ####### ######.
			 * @return {BPMSoft.FilterGroup} ###### ### ######## ###### ########## ## DocumentRelationship
			 * ## Id ####### ####### Document.
			 */
			getDeleteRelationFilters: function(masterRecordId, relatedDocumentIds) {
				var mainFilter = this.BPMSoft.createFilterGroup();
				mainFilter.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				var createRelationFilterFn = function(columnA, columnB) {
					var filter = this.BPMSoft.createFilterGroup();
					filter.addItem(this.BPMSoft.createColumnInFilterWithParameters(columnA, relatedDocumentIds));
					filter.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							columnB, masterRecordId));
					return filter;
				}.bind(this);
				mainFilter.addItem(createRelationFilterFn("DocumentA", "DocumentB"));
				mainFilter.addItem(createRelationFilterFn("DocumentB", "DocumentA"));
				return mainFilter;
			},

			/**
			 * ##########/######## ###### ##### # ############ #########.
			 * @private
			 * @returns {boolean} ########## ####### ######### ######.
			 */
			getLinkButtonVisible: function() {
				return (this.get("CardPageName") === "DocumentPageV2");
			},

			/**
			 ** ######### ######## ############### ######## # ######### ########### ###### ############## ######.
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
			 * @overridden
			 */
			addRecordOperationsMenuItems: function(toolsButtonMenu) {
				this.callParent(arguments);
				toolsButtonMenu.addItem(this.getButtonMenuSeparator());
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {"bindTo": "Resources.Strings.LinkWithExistingCaption"},
					Click: {"bindTo": "linkWithExisting"},
					Visible: {"bindTo": "getLinkButtonVisible"}
				}));
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {"bindTo": "Resources.Strings.DeleteLinkWithDocumentsCaption"},
					Click: {"bindTo": "deleteLinkWithDocuments"},
					Visible: {"bindTo": "getLinkButtonVisible"},
					Enabled: {"bindTo": "getSelectedItems"}
				}));
			},

			init: function() {
				this.entitySchema.primaryDisplayColumnName = this.entitySchema.primaryDisplayColumnName || "DocumentB";
				this.callParent(arguments);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
