define("SysAdminUnitChiefIPRangeDetailV2", ["BPMSoft", "ConfigurationConstants", "ConfigurationGrid",
		"ConfigurationGridGenerator", "ConfigurationGridUtilities"],
		function(BPMSoft, ConfigurationConstants) {
		return {
			mixins: {
				ConfigurationGridUtilities: "BPMSoft.ConfigurationGridUtilities"
			},
			attributes: {
				IsEditable: {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			entitySchemaName: "SysAdminUnitIPRange",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"className": "BPMSoft.ConfigurationGrid",
						"generator": "ConfigurationGridGenerator.generatePartial",
						"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
						"changeRow": {"bindTo": "changeRow"},
						"unSelectRow": {"bindTo": "unSelectRow"},
						"onGridClick": {"bindTo": "onGridClick"},
						"activeRowActions": [
							{
								"className": "BPMSoft.Button",
								"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "save",
								"markerValue": "save",
								"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "cancel",
								"markerValue": "cancel",
								"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "remove",
								"markerValue": "remove",
								"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
							}
						],
						"listedZebra": true,
						"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"multiSelect": false,
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "SysAdminUnitNameListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.SysAdminUnitNameCaption"},
									"bindTo": "SysAdminUnit.Name",
									"type": "text",
									"position": {
										"column": 0,
										"colSpan": 9
									}
								},
								{
									"name": "BeginIPListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.BeginIPCaption"},
									"bindTo": "BeginIP",
									"type": "text",
									"position": {
										"column": 9,
										"colSpan": 6
									}
								},
								{
									"name": "EndIPListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.EndIPCaption"},
									"bindTo": "EndIP",
									"type": "text",
									"position": {
										"column": 15,
										"colSpan": 6
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				/**
				 * ########### ########## ###### ####### ## ####### ###. #### ############ ### ####### ####.
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonEnabled
				 * @overridden
				 */
				getAddRecordButtonEnabled: function() {
					return this.get("IsChiefRoleExists");
				},

				/**
				 * @inheritdoc GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 * @return {Object} ########## ###### ########-############ #######.
				 */
				// jscs:disable
				/* jshint ignore:start */
				getGridDataColumns: function() {
					var config = this.callParent(arguments);
					config["SysAdminUnit.Name"] = {path: "SysAdminUnit.Name"};
					config["BeginIP"] = {path: "BeginIP"};
					config["EndIP"] = {path: "EndIP"};
					return config;
				},
				// jscs:enable
				/* jshint ignore:end */

				/**
				 * @protected
				 * @inheritdoc GridUtilitiesV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					if (this.get("ChiefOrgRoleIdLoaded")) {
						this.set("ChiefOrgRoleIdLoaded", false);
						if (this.get("IsChiefRoleExists")) {
							this.callParent(arguments);
						}
						return;
					}
					this.getChiefOrgRoleId(this.loadGridData);
				},

				/**
				 * @protected
				 * @inheritdoc BaseGridDetailV2#getFilters
				 * @overridden
				 * @return {BPMSoft.FilterGroup} ###### ######## filters.
				 **/
				getFilters: function() {
					var filters = this.get("DetailFilters");
					var serializationInfo = filters.getDefSerializationInfo();
					serializationInfo.serializeFilterManagerInfo = true;
					var deserializedFilters = BPMSoft.deserialize(filters.serialize(serializationInfo));
					var item = this.get("ChiefOrgRoleId");
					deserializedFilters.addItem(this.BPMSoft.createColumnInFilterWithParameters(
						"SysAdminUnit.Id", [item]));
					return deserializedFilters;
				},

				/**
				 * ######### ######, ####### ########## ############# ############### #### #############
				 * ### ######### ############### ####.
				 * @protected
				 * @param {Function} callback ####### ######### ######, ####### ########## ##### ####,
				 * ### ####### #############.
				 */
				getChiefOrgRoleId: function(callback) {
					var parentId = this.get("MasterRecordId");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysAdminUnit"
					});
					esq.addColumn("Id");
					esq.filters.addItem(this.BPMSoft.createColumnInFilterWithParameters(
						"ParentRole.Id", [parentId]));
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "SysAdminUnitTypeValue",
						ConfigurationConstants.SysAdminUnit.Type.Manager));
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							var collection = response.collection;
							if (collection.getCount() > 0) {
								this.set("IsChiefRoleExists", true);
								var chiefOrgRoleId = collection.getByIndex(0).get("Id");
								var chiefOrgRoleValue = {
									name: "SysAdminUnit",
									value: chiefOrgRoleId
								};
								this.set("DefaultValues", [chiefOrgRoleValue]);
								this.set("ChiefOrgRoleId", chiefOrgRoleId);
								this.set("IsChiefRoleExists", true);
							} else {
								this.set("IsChiefRoleExists", false);
								var gridData = this.getGridData();
								gridData.clear();
							}
							this.set("ChiefOrgRoleIdLoaded", true);
							if (this.Ext.isFunction(callback)) {
								callback.call(this);
							}
						}
					}, this);
				},

				/**
				 * @overridden
				 * @return {String} ### #######.
				 */
				getFilterDefaultColumnName: function() {
					return "BeginIP";
				}
			}
		};
	});
