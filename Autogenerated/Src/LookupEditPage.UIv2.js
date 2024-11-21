define("LookupEditPage", ["LookupManager"],
function() {
	return {
		entitySchemaName: "Lookup",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		attributes: {
			/**
			 * ########### ####### ##### ###########.
			 */
			SysEntitySchema: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				isRequired: true,
				lookupListConfig: {
					columns: ["UId", "Caption"],
					filter: function() {
						var filters = this.Ext.create("BPMSoft.FilterGroup");
						filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							"SysWorkspace",
							BPMSoft.SysValue.CURRENT_WORKSPACE.value
						));
						if (!BPMSoft.Features.getIsEnabled("UseVwWorkspaceObjects")) {
							filters.addItem(BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL,
								"ManagerName",
								"EntitySchemaManager"
							));
						}
						filters.addItem(BPMSoft.createColumnIsNotNullFilter("Caption"));
						return filters;
					}
				},
				referenceSchema: {
					name: BPMSoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
						"VwWorkspaceObjects" :
						"VwSysSchemaInfo",
					primaryColumnName: "Name",
					primaryDisplayColumnName: "Caption"
				},
				referenceSchemaName: BPMSoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
					"VwWorkspaceObjects" :
					"VwSysSchemaInfo"
			},
			/**
			 * ####### ##### ###########.
			 */
			"SysEntitySchemaUId": {
				dependencies: [{
					columns: ["SysEntitySchema"],
					methodName: "sysEntitySchemaChanged"
				}]
			},

			/**
			 * ########### ####### ######## ###########.
			 */
			SysPageSchema: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				lookupListConfig: {
					columns: ["UId", "Caption"],
					filter: function() {
						var filters = this.Ext.create("BPMSoft.FilterGroup");
						filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							"SysWorkspace",
							BPMSoft.SysValue.CURRENT_WORKSPACE.value
						));
						filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							"ManagerName",
							"ClientUnitSchemaManager"
						));
						filters.addItem(BPMSoft.createColumnIsNotNullFilter("Caption"));
						return filters;
					}
				},
				referenceSchema: {
					name: "VwSysSchemaInfoForLookups",
					primaryColumnName: "Name",
					primaryDisplayColumnName: "Caption"
				},
				referenceSchemaName: "VwSysSchemaInfoForLookups"
			},
			/**
			 * ####### ######## ###########.
			 */
			"SysPageSchemaUId": {
				dependencies: [{
					columns: ["SysPageSchema"],
					methodName: "sysPageSchemaChanged"
				}]
			}
		},
		methods: {

			/**
			 * @inheritdoc BasePageV2#getPageHeaderCaption
			 * @overridden
			 */
			getPageHeaderCaption: function() {
				var headerTemplate = this.get("Resources.Strings.PageHeaderTemplate");
				return this.Ext.String.format(headerTemplate, this.get(this.primaryDisplayColumnName) || "",
						this.get("Resources.Strings.LookupPropertiesPageHeader")).replace(/^\s\/\s|\s\/\s$/g, "");
			},

			/**
			 * ############ ######### ########### ####### #####, ############# ##### ######## # ####### #####.
			 * @protected
			 * @virtual
			 */
			sysEntitySchemaChanged: function() {
				var schema = this.get("SysEntitySchema");
				var uid = Ext.isEmpty(schema) ? null : schema.UId;
				this.set("SysEntitySchemaUId", uid);
			},

			/**
			 * ############ ######### ########### ####### ########, ############# ##### ######## # ####### #####.
			 * @protected
			 * @virtual
			 */
			sysPageSchemaChanged: function() {
				var schema = this.get("SysPageSchema");
				var uid = Ext.isEmpty(schema) ? null : schema.UId;
				this.set("SysPageSchemaUId", uid);
			},

			/**
			 * @inheritdoc BasePageV2#getLookupPageConfig
			 * @overridden
			 */
			getLookupPageConfig: function(args, columnName) {
				var config = this.callParent(arguments);
				var lookupHeader = this.get(Ext.String.format("Resources.Strings.{0}UIdLookupHeader", columnName));
				if (lookupHeader) {
					Ext.apply(config, {captionLookup: lookupHeader});
				}
				return config;
			},

			/**
			 * ########## ######## ##### ########### ####.
			 * @protected
			 * @overridden
			 * @param {Object} args #########.
			 * @param {String} columnName ######## #######.
			 * @return {Object|null} ######## ##### ########### ####.
			 */
			getLookupEntitySchemaName: function(args, columnName) {
				var entityColumn = this.columns[columnName];
				return args.schemaName || entityColumn.referenceSchemaName;
			},

			/**
			 * ######### ######## ########### ####### ####.
			 * @protected
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			loadSchemaNames: function(callback, scope) {
				var columnNames = {
					"SysEntitySchemaUId": "SysEntitySchema",
					"SysPageSchemaUId": "SysPageSchema"
				};
				var bq = Ext.create("BPMSoft.BatchQuery");
				BPMSoft.each(columnNames, function(lookupName, columnName) {
					var column = this.columns[lookupName];
					var columnValue = this.get(columnName);
					if (!Ext.isEmpty(columnValue) && BPMSoft.isGUID(columnValue)) {
						var lookupQuery = this.getLookupQuery(null, column.name, column.isLookup);
						lookupQuery.filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "UId", columnValue));
						bq.add(lookupQuery, function(result) {
							var value = null;
							if (result.success && !result.collection.isEmpty()) {
								var resultValue = result.collection.getByIndex(0);
								value = resultValue.values;
							}
							this.set(lookupName, value);
						}, this);
					} else {
						this.set(lookupName, null);
					}
				}, this);
				if (bq.queries.length) {
					bq.execute(callback, scope);
				} else {
					if (callback) {
						callback.call(scope || this, this);
					}
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#loadEntity
			 * @overridden
			 */
			loadEntity: function(primaryColumnValue, callback, scope) {
				this.callParent([primaryColumnValue, function() {
					this.loadSchemaNames(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#addSectionDesignerViewOptions
			 * @overridden
			 */
			addSectionDesignerViewOptions: BPMSoft.emptyFn

		},
		rules: {},
		userCode: {},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "actions",
				"values": {
					"visible": false
				}
			},
			{
				"operation": "insert",
				"name": "Name",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"layout": {
						"colSpan": 24,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "insert",
				"name": "SysEntitySchema",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.SysEntitySchemaUIdLabel"}
					},
					"layout": {
						"colSpan": 24,
						"column": 0,
						"row": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "SysPageSchema",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.SysPageSchemaUIdLabel"}
					},
					"layout": {
						"colSpan": 24,
						"column": 0,
						"row": 2
					}
				}
			},
			{
				"operation": "insert",
				"name": "Description",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					},
					"contentType": BPMSoft.ContentType.LONG_TEXT
				}
			}
		]/**SCHEMA_DIFF*/

	};
});
