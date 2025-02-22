﻿define("EmailDetailV2", ["BPMSoft", "ProcessModuleUtilities", "ConfigurationConstants", "ConfigurationEnums"],
		function(BPMSoft, ProcessModuleUtilities, ConfigurationConstants, Enums) {
			return {
				/**
				 * Entity schema name.
				 * @type {String}
				 */
				entitySchemaName: "Activity",

				messages: {
					/**
					 * @message ProcessExecDataChanged
					 * Defines that process parameters must be send.
					 * @param {Object} processExecData additional data for the opening page.
					 * @param {String} processExecData.procElUId process element uid.
					 * @param {String} processExecData.recordId record id.
					 * @param {Object} processExecData.scope execution scope.
					 * @param {Object|Array} processExecData.parentMethodArguments parent methods arguments.
					 * @param {Function} processExecData.parentMethod parent method.
					 */
					"ProcessExecDataChanged": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				attributes: {
				},
				methods: {

					/**
					 * @inheritdoc BPMSoft.BasePageV2#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.callParent([function() {
							this.setDefaultRecipientEmail(callback, scope);
						}, this]);
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#updateDetail
					 * @overridden
					 */
					updateDetail: function() {
						this.callParent(arguments);
						this.setDefaultRecipientEmail();
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#onCardSaved
					 * @overridden
					 */
					onCardSaved: function() {
						var cardState = this.get("CardState");
						var editPageUId = this.get("EditPageUId");
						if (this.getIsEditable() && cardState !== Enums.CardStateV2.EDIT) {
							this.addRow(editPageUId);
						} else {
							this.setDefaultRecipientEmail(function() {
								this.openCard(cardState, editPageUId, this.get("PrimaryValueUId"));
							}, this);
						}
					},

					/**
					 * Sets default value for Recipient column.
					 * @param {Function} callback callback-function.
					 * @param {BPMSoft.BaseSchemaViewModel} scope Callback execution scope.
					 */
					setDefaultRecipientEmail: function(callback, scope) {
						var currentPage = this.get("DetailColumnName");
						var schema, equalColumn;
						switch (currentPage) {
							case "Contact":
								schema = "ContactCommunication";
								equalColumn = "Contact";
								break;
							case "Account":
								schema = "AccountCommunication";
								equalColumn = "Account";
								break;
							default :
								if (callback) {
									callback.call(scope || this);
								}
								return;
						}
						var esq = this.getDefaultEmailQuery(schema, equalColumn);
						esq.getEntityCollection(function(result) {
							this.setDefaultEmailToRecipient(result, equalColumn);
							if (!callback) {
								return;
							}
							callback.call(scope);
						}, this);
					},

					/**
					 * Request query of default value for Recipient column.
					 * @param {String} schema Column for query-request.
					 * @param {String} equalColumn Column for filtration query-request.
					 * @return {BPMSoft.EntitySchemaQuery} esq Request query.
					 */
					getDefaultEmailQuery: function(schema, equalColumn) {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: schema
						});
						var column = esq.addColumn("Number");
						column.orderDirection = this.BPMSoft.OrderDirection.ASC;
						esq.addColumn(equalColumn);
						var emailConstantType = ConfigurationConstants.CommunicationTypes.Email;
						var masterColumnValue = this.get("MasterRecordId");
						esq.filters.addItem(esq.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "CommunicationType", emailConstantType));
						esq.filters.addItem(esq.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, equalColumn, masterColumnValue));
						return esq;
					},

					/**
					 * Sets data to Recipient default value.
					 * @param {String} result Query result.
					 * @param {String} equalColumn Column for filtration query-request.
					 */
					setDefaultEmailToRecipient: function(result, equalColumn) {
						if (result.success) {
							var defaultValues = this.get("DefaultValues") || [];
							var recipientDefault = defaultValues.filter(function(item) {
									return item.name === "Recepient";
								}
							);
							var items = [];
							var entities = result.collection;
							entities.each(function(item) {
								var userName = item.get(equalColumn).displayValue;
								items.push(userName + " <" + item.get("Number") + ">");
							}, this);
							items = items.sort();
							var itemsRow = items.join("; ");
							var defaultEmails;
							if (recipientDefault.length > 0) {
								defaultEmails = recipientDefault[0];
								defaultEmails.value = itemsRow;
							} else {
								defaultEmails = {
									name: "Recepient",
									value: itemsRow
								};
								defaultValues.push(defaultEmails);
							}
						}
					},

					/**
					 * If active row is process activity - open process step page.
					 * @param {Object} config Config.
					 * @param {String} config.activeRow The Id of the current entity.
					 * @param {Object} config.scope Scope for the calling method.
					 * @param {Object|Array} config.parentMethodArguments Arguments of the parent method.
					 * @param {Function} config.parentMethod Parent method.
					 * @return {Boolean} True if process card opened.
					 * @private
					 */
					tryOpenProcessCard: function(config) {
						var activeRow = config.activeRow;
						var processCardConfig = this.getProcessCardConfig(activeRow);
						if (this.Ext.isEmpty(processCardConfig)) {
							return false;
						}
						processCardConfig.scope = config.scope;
						processCardConfig.parentMethodArguments = config.parentMethodArguments;
						processCardConfig.parentMethod = config.parentMethod;
						return ProcessModuleUtilities.tryShowProcessCard.call(this, processCardConfig);
					},

					/**
					 * Gets process card config.
					 * @param {String} activeRow The Id of the current entity.
					 * @return {Object} Process card config.
					 * @private
					 */
					getProcessCardConfig: function(activeRow) {
						var config = {};
						if (activeRow) {
							var gridData = this.getGridData();
							var activeRowModel = gridData.get(activeRow);
							config.procElUId = activeRowModel.get("ProcessElementId");
							config.recordId = activeRowModel.get(this.primaryColumnName);
						}
						return config;
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#editRecord
					 * @overridden
					 */
					editRecord: function(record) {
						var activeRow = null;
						if (!this.Ext.isEmpty(record)) {
							activeRow = record.get(record.primaryColumnName);
						}
						var config = {
							activeRow: activeRow,
							scope: this,
							parentMethodArguments: arguments,
							parentMethod: this.getParentMethod()
						};
						if (this.tryOpenProcessCard(config)) {
							return true;
						}
						this.callParent(arguments);
					},

					/**
					 * @overridden
					 */
					getGridDataColumns: function() {
						var gridDataColumns = this.callParent(arguments);
						if (!gridDataColumns.ProcessElementId) {
							gridDataColumns.ProcessElementId = {
								path: "ProcessElementId"
							};
						}
						return gridDataColumns;
					},

					linkClicked: function(href, columnName) {
						if (columnName !== this.primaryDisplayColumnName &&
								columnName !== ("on" + this.primaryDisplayColumnName + "LinkClick")) {
							return this.callParent(arguments);
						}
						var linkParams = href.split("/");
						var recordId = linkParams[linkParams.length - 1];
						var config = {
							activeRow: recordId,
							scope: this,
							parentMethodArguments: arguments,
							parentMethod: this.getParentMethod()
						};
						if (this.tryOpenProcessCard(config)) {
							return false;
						}
						return this.callParent(arguments);
					},

					/**
					 * Returns default filter column name.
					 * @overridden
					 * @return {String} Column name.
					 */
					getFilterDefaultColumnName: function() {
						return "Title";
					},

					/**
					 * Creates edit pages collection.
					 * @overridden
					 */
					initEditPages: function() {
						var collection = Ext.create("BPMSoft.BaseViewModelCollection");
						var entityStructure = this.getEntityStructure(this.entitySchemaName);
						if (entityStructure) {
							BPMSoft.each(entityStructure.pages, function(editPage) {
								var typeUId = editPage.UId || BPMSoft.GUID_EMPTY;
								if (editPage.cardSchema === "EmailPageV2") {
									collection.add(typeUId, Ext.create("BPMSoft.BaseViewModel", {
										values: {
											Id: typeUId,
											Caption: editPage.caption,
											Click: {bindTo: "addRecord"},
											Tag: typeUId,
											SchemaName: editPage.cardSchema
										}
									}));
								}
							}, this);
						}
						this.set("EditPages", collection);
					}
				},

				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"type": "listed",
							"listedConfig": {
								"name": "DataGridListedConfig",
								"items": [
									{
										"name": "TitleListedGridColumn",
										"bindTo": "Title",
										"type": BPMSoft.GridCellType.TEXT,
										"position": {
											"column": 1,
											"colSpan": 11
										}
									},
									{
										"name": "StartDateListedGridColumn",
										"bindTo": "StartDate",
										"type": BPMSoft.GridCellType.TEXT,
										"position": {
											"column": 13,
											"colSpan": 6
										}
									},
									{
										"name": "StatusDateListedGridColumn",
										"bindTo": "Status",
										"type": BPMSoft.GridCellType.TEXT,
										"position": {
											"column": 19,
											"colSpan": 6
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
										"name": "TitleTiledGridColumn",
										"bindTo": "Title",
										"type": BPMSoft.GridCellType.TEXT,
										"position": {
											"row": 1,
											"column": 1,
											"colSpan": 24
										},
										"captionConfig": {
											"visible": true
										}
									},
									{
										"name": "StartDateTiledGridColumn",
										"bindTo": "StartDate",
										"type": BPMSoft.GridCellType.TEXT,
										"position": {
											"row": 2,
											"column": 1,
											"colSpan": 6
										}
									},
									{
										"name": "OwnerTiledGridColumn",
										"bindTo": "Owner",
										"type": BPMSoft.GridCellType.Text,
										"position": {
											"row": 2,
											"column": 7,
											"colSpan": 11
										}
									},
									{
										"name": "StatusDateTiledGridColumn",
										"bindTo": "Status",
										"type": BPMSoft.GridCellType.TEXT,
										"position": {
											"column": 19,
											"colSpan": 6
										}
									}
								]
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
