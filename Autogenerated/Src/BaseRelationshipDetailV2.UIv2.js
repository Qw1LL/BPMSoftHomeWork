﻿define("BaseRelationshipDetailV2", ["BaseRelationshipDetailV2Resources", "ConfigurationEnums", "RightUtilities"],
		function(resources, enums, RightUtilities) {
			return {
				entitySchemaName: "Relationship",
				attributes: {
					/**
					 * Base relationship page schema name.
					 */
					BaseRelationshipPageSchemaName: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						value: "BaseRelationshipDetailPageV2"
					}
				},
				messages: {
					"GetAddMode": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"GetMasterRecordId": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.LookupQuickAddMixin#isSilentCreation
					 * @overridden
					 */
					isSilentCreation: function() {
						return true;
					},
					/**
					 * ########## ############# ######## ############## ######.
					 * @returns {String} ############# ######## ############## ######.
					 */
					getRelationshipEditPageModuleId: function() {
						var editPages = this.get("EditPages");
						var editPage = editPages.getByIndex(0);
						return editPage ? this.getEditPageSandboxId(editPage) : "";
					},
					/**
					 * ##### ########## ######
					 * @param {String} mode
					 */
					addRelation: function(mode) {
						this.mode = mode;
						var schemaName = this.get("BaseRelationshipPageSchemaName");
						var cardModuleId = this.getRelationshipEditPageModuleId();
						var defaultValueColumnName = this.get("CardPageName") === "ContactPageV2" ? "ContactA" : "AccountA";
						var openCardConfig = {
							moduleId: cardModuleId,
							schemaName: schemaName,
							defaultValues: [
								{
									name: defaultValueColumnName,
									value: this.get("MasterRecordId")
								}
							],
							operation: enums.CardStateV2.ADD
						};
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
							var args = {
								isSilent: true,
								messageTags: [this.sandbox.id]
							};
							this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						} else {
							this.sandbox.publish("OpenCard", openCardConfig, [this.sandbox.id]);
						}
					},
					/**
					 * ######## ## #########
					 * @overridden
					 */
					editRecord: function() {
						this.mode = null;
						var selectedItems = this.getSelectedItems();
						if (this.Ext.isEmpty(selectedItems)) {
							return;
						}
						var relationRecordId = selectedItems[0];
						var schemaName = this.get("BaseRelationshipPageSchemaName");
						var cardModuleId = this.getRelationshipEditPageModuleId();
						var openCardConfig = {
							moduleId: cardModuleId,
							schemaName: schemaName,
							operation: enums.CardStateV2.EDIT,
							id: relationRecordId
						};
						this.sandbox.publish("OpenCard", openCardConfig, [this.sandbox.id]);
					},

					/**
					 * ##### ########## ########
					 * @private
					 */
					addContactRelation: function() {
						this.addRelation("AddContact");
					},

					/**
					 * ##### ########## ###########
					 * @private
					 */
					addAccountRelation: function() {
						this.addRelation("AddAccount");
					},

					/**
					 * @inheritdoc BaseDetailV2#getCopyRecordMenuItem
					 * @overridden
					 */
					getCopyRecordMenuItem: function() {
						return this.get("CanAdd") ? this.callParent(arguments) : null;
					},

					/**
					 * @inheritdoc BaseDetailV2#getEditRecordMenuItem
					 * @overridden
					 */
					getEditRecordMenuItem: function() {
						return this.get("CanEdit") ? this.callParent(arguments) : null;
					},

					/**
					 * @inheritdoc BaseDetailV2#getDeleteRecordMenuItem
					 * @overridden
					 */
					getDeleteRecordMenuItem: function() {
						return this.get("CanDelete") ? this.callParent(arguments) : null;
					},

					/**
					 * @inheritdoc BaseDetailV2#init
					 * @overridden
					 */
					init: function(callback, scope) {
						const parentMethod = this.getParentMethod(this, [function() {
							this.sandbox.subscribe("GetAddMode", function() {
								return this.mode;
							}, this, [this.getRelationshipEditPageModuleId()]);
							this.sandbox.subscribe("GetMasterRecordId", function() {
								return this.get("MasterRecordId");
							}, this, [this.getRelationshipEditPageModuleId()]);
							Ext.callback(callback, scope);
						}, this]);
						RightUtilities.getSchemaOperationRightLevel(this.entitySchemaName, function(rightLevel) {
							this.set("CanDelete", RightUtilities.canDeleteSchemaData(rightLevel));
							this.set("CanAdd", RightUtilities.canAppendSchemaData(rightLevel));
							this.set("CanEdit", RightUtilities.canEditSchemaData(rightLevel));
							parentMethod();
						}, this);
					},

					/**
					 * ######### ###### ##### ######## ######.
					 * @overridden
					 */
					afterLoadGridDataUserFunction: function() {
						this.reloadGridData();
					},

					/**
					 * ########## ### ####### ### ########## ## #########.
					 * @overridden
					 * @return {String} ### #######.
					 */
					getFilterDefaultColumnName: function() {
						return "RelatedObjectName";
					},

					/**
					 * @inheritdoc BaseSchemaViewModel#initEditPages
					 * @overridden
					 */
					initEditPages: function() {
						var editPages = this.Ext.create("BPMSoft.BaseViewModelCollection");
						if (this.get("CanAdd")) {
							var item = this.getButtonMenuItem({
								Caption: {bindTo: "Resources.Strings.AddContactRelationMenuCaption"},
								Click: {bindTo: "addContactRelation"},
								Tag: "AddRelation",
								SchemaName: this.get("BaseRelationshipPageSchemaName")
							});
							editPages.add("AddContact", item);
							item = this.getButtonMenuItem({
								Caption: {bindTo: "Resources.Strings.AddAccountRelationMenuCaption"},
								Click: {bindTo: "addAccountRelation"},
								Tag: "AddRelation",
								SchemaName: this.get("BaseRelationshipPageSchemaName")
							});
							editPages.add("AddAccount", item);
						}
						this.set("EditPages", editPages);
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
										"name": "RelatedObjectListedGridColumn",
										"bindTo": "RelatedObjectName",
										"position": {"column": 0, "colSpan": 11},
										"type": BPMSoft.GridCellType.TITLE,
										"caption": resources.localizableStrings.RelatedObjectName
									},
									{
										"name": "RelationTypeListedGridColumn",
										"bindTo": "RelationType",
										"position": {"column": 13, "colSpan": 11}
									}
								]
							},
							"tiledConfig": {
								"name": "DataGridTiledConfig",
								"grid": {"columns": 24, "rows": 3},
								"items": [
									{
										"name": "RelatedObjectTiledGridColumn",
										"bindTo": "RelatedObjectName",
										"position": {"row": 1, "column": 0, "colSpan": 11},
										"type": BPMSoft.GridCellType.TITLE,
										"caption": resources.localizableStrings.RelatedObjectNameCaption
									},
									{
										"name": "RelationTypeTiledGridColumn",
										"bindTo": "RelationType",
										"position": {"row": 1, "column": 13, "colSpan": 11}
									}
								]
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
