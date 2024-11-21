define("PortalSchemaAccessListEditPage", ["PortalSchemaAccessListEditPageResources"],
	function() {
		return {
			entitySchemaName: "PortalSchemaAccessList",
			attributes: {
				"SysEntitySchema": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isLookup: true,
					lookupListConfig: {
						columns: ["UId", "Caption", "Name"],
						filter: function() {
							return this.getSysEntitySchemaFilter();
						}
					},
					referenceSchema: {
						name: "VwSysSchemaInfo",
						primaryColumnName: "Name",
						primaryDisplayColumnName: "Caption"
					},
					referenceSchemaName: "VwSysSchemaInfo"
				},
				"SysEntitySchemaUId": {
					dependencies: [{
						columns: ["SysEntitySchema"],
						methodName: "onSysEntitySchemaChanged"
					}]
				},
				"Name": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "Name"
				},
				"IsDetailVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},
				"IsAddMode": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"PortalSchemaAccessListDetail": {
					"schemaName": "PortalSchemaAccessListDetail",
					"entitySchemaName": "PortalColumnAccessList",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "PortalSchemaList"
					}
				}
			}/**SCHEMA_DETAILS*/,
			messages: {
				"UpdatePageHeaderCaption": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			diff: [
				{
				"operation": "remove",
				"name": "Name"
				},
				{
					"operation": "remove",
					"name": "Description"
				},
				{
					"operation": "insert",
					"name": "PortalSchemaAccessListTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.PortalAccessColumnsTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PortalSchemaAccessListTab",
					"propertyName": "items",
					"name": "PortalSchemaAccessListDetail",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "IsDetailVisible"}
					}
				}
			],

			methods: {

				/**
				 * Returns SysEntitySchema filter.
				 * @protected
				 * @returns {BPMSoft.FilterGroup} Filter group
				 */
				getSysEntitySchemaFilter: function(){
					var filters = this.Ext.create("BPMSoft.FilterGroup");
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"SysWorkspace",
							this.BPMSoft.SysValue.CURRENT_WORKSPACE.value
					));
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"ManagerName",
							"EntitySchemaManager"
					));
					return filters;
				},

				/**
				 * On SysEntitySchema field change handler.
				 * @protected
				 */
				onSysEntitySchemaChanged: function() {
					var schema = this.get("SysEntitySchema");
					var uid = schema.UId;
					var name = schema.Name;
					this.set("SchemaUId", uid);
					this.set("AccessEntitySchemaName", name);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.setPageCaptionHeader();
					var entitySchemaName = this.get("AccessEntitySchemaName");
					this.BPMSoft.require([entitySchemaName], function(){
						this.set("IsDetailVisible", true);
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#initActionButtonMenu
				 * @overridden
				 */
				initActionButtonMenu: function() {
					this.set("ActionsButtonVisible", false);
				},

				/**
				 * Set page caption.
				 * @protected
				 * @virtual
				 */
				setPageCaptionHeader: function() {
					var selectQuery = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysSchema"
					});
					selectQuery.addColumn("Caption");
					selectQuery.filters.add("SysSchemaCaptionFilter",
							selectQuery.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
									"UId", this.get("SchemaUId")));
					selectQuery.getEntityCollection(function(response) {
						if (response && response.success) {
							var collection = response.collection;
							if (collection.getCount() > 0) {
								var entitySchema = collection.getByIndex(0);
								var entitySchemaCaption = entitySchema.get("Caption");
								this.sandbox.publish("UpdatePageHeaderCaption", {
									pageHeaderCaption: entitySchemaCaption
								});
							}
						}
					}, this);
				}
			}
		};
	});
