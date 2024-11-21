define("LookupSectionGridRowViewModel", ["ext-base", "LookupSectionGridRowViewModelResources",
	"BaseSectionGridRowViewModel"], function(Ext, resources) {

	/**
	 * @class BPMSoft.configuration.LookupSectionGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.LookupSectionGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.LookupSectionGridRowViewModel",

		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#getEntitySchemaQuery
		 * @overridden
		 */
		getEntitySchemaQuery: function() {
			var entitySchemaQuery = this.callParent(arguments);
			this.addSchemaNameColumn(entitySchemaQuery, "[VwSysSchemaInfo:UId:SysEntitySchemaUId].Name", "EntitySchemaName");
			this.addSchemaNameColumn(entitySchemaQuery, "[VwSysSchemaInfo:UId:SysPageSchemaUId].Name", "PageSchemaName");
			var columnName = "SysLookup";
			if (!entitySchemaQuery.columns.contains(columnName)) {
				entitySchemaQuery.addColumn(columnName);
			}
			return entitySchemaQuery;
		},

		/**
		 * ######### # ###### ####### ##### #####.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.EntitySchemaQuery} esq ###### #######.
		 * @param {String} columnPath #### # #######.
		 * @param {String} columnAlias ######### #######.
		 */
		addSchemaNameColumn: function(esq, columnPath, columnAlias) {
			var expressionConfig = {
				columnPath: columnPath,
				parentCollection: this,
				aggregationType: BPMSoft.AggregationType.NONE
			};
			var column = Ext.create("BPMSoft.SubQueryExpression", expressionConfig);
			var filter = BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL,
				"SysWorkspace",
				BPMSoft.SysValue.CURRENT_WORKSPACE.value
			);
			column.subFilters.addItem(filter);
			var esqColumn = esq.addColumn(columnAlias);
			esqColumn.expression = column;
		},

		/**
		 * ############## ###### ########## ######## ## ####### ########.
		 * @protected
		 * @virtual
		 * @param {Object} resourcesObj ###### ########.
		 */
		initResourcesValues: function(resourcesObj) {
			var resourcesSuffix = "Resources";
			BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
				resourceGroupName = resourceGroupName.replace("localizable", "");
				BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
					var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
					this.set(viewModelResourceName, resourceValue);
				}, this);
			}, this);
		}
	});

	return BPMSoft.BaseSectionGridRowViewModel;
});
