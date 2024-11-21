define("BaseGridRowViewModel", ["EmailHelper", "BPMSoft", "MiniPageUtilities"], function(EmailHelper, BPMSoft) {

	/**
	 * @class BPMSoft.configuration.BaseGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.BaseGridRowViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.BaseGridRowViewModel",

		"mixins": {
			/**
			 * @class MiniPageUtilities
			 */
			"MiniPageUtilitiesMixin": "BPMSoft.MiniPageUtilities"
		},

		/**
		 * ######### ####### ###### ########## ##### #####
		 * @overridden
		 */
		getEntitySchemaQuery: function() {
			var entitySchemaQuery = this.callParent(arguments);
			this.addProcessEntryPointColumn(entitySchemaQuery);
			return entitySchemaQuery;
		},

		/**
		 *
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResources();
		},

		/**
		 * ############## ######.
		 * @param {Array} strings #######
		 * @protected
		 */
		initResources: function(strings) {
			strings = strings || {};
			BPMSoft.each(strings, function(value, key) {
				this.set("Resources.Strings." + key, value);
			}, this);
		},

		/**
		 * ######### #########, ####### ######### ########## ######## ##### ##### ## ########
		 * @param esq
		 */
		addProcessEntryPointColumn: function(esq) {
			var itemConfig = {
				columnPath: "[EntryPoint:EntityId].Id",
				parentCollection: this,
				aggregationType: BPMSoft.AggregationType.COUNT
			};
			var column = Ext.create("BPMSoft.SubQueryExpression", itemConfig);
			var filter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "IsActive", true);
			column.subFilters.addItem(filter);
			var esqColumn = esq.addColumn("EntryPointsCount");
			esqColumn.expression = column;
		},

		/**
		 * Return entity column link config for grid by value.
		 * @param {BPMSoft.EntitySchemaColumn} column Entity column.
		 */
		getLinkColumnConfig: function(column) {
			var value = this.get(column.columnPath);
			var config = {
				title: value,
				caption: value,
				target: "_blank"
			};
			if (EmailHelper.isEmailAddress(value)) {
				config.target = "_self";
				config.url = EmailHelper.getEmailUrl(value);
				return config;
			}
			var valueUrls = BPMSoft.getUrls(value);
			var hasCustomUrls = valueUrls.length > 0;
			if (BPMSoft.isUrl(value) || hasCustomUrls) {
				config.url = value;
				config.customUrlsExists = hasCustomUrls;
				config.customUrls = valueUrls;
				return config;
			}
			return null;
		},

		/**
		 * Returns row cell hint config by column.
		 * @returns {Object} Row cell hint config by column.
		 */
		getRowCellsHintConfig: function() {
			var hintConfig = {};
			BPMSoft.each(this.columns, function(column, columnName) {
				var type = this.getColumnDataType(columnName);
				if (!this._isNeedColumnHint(column, columnName, type)) {
					return;
				}
				var columnHintValue = this.get(columnName);
				if (!Ext.isEmpty(columnHintValue)) {
					var precision = Ext.isEmpty(column) ? null : column.precision;
					hintConfig[columnName] = BPMSoft.getTypedStringValue(columnHintValue, type,
						{decimalPrecision: precision});
				}
			}, this);
			return hintConfig;
		},

		/**
		 * Returns need hint value tag.
		 * @private
		 * @param {Object} column Column configuration.
		 * @param {String} columnName Column name.
		 * @param {BPMSoft.DataValueType} type Data value type.
		 * @returns {boolean}
		 */
		_isNeedColumnHint: function(column, columnName, type) {
			if (type === BPMSoft.DataValueType.IMAGELOOKUP || type === BPMSoft.DataValueType.IMAGE) {
				return false;
			}
			var isPrimaryColumn = Boolean(columnName === this.primaryDisplayColumnName && this.entitySchema);
			var isLookupColumn = column && column.isLookup;
			var checkMiniPage = isPrimaryColumn || isLookupColumn;
			if (checkMiniPage) {
				var miniPageEntityName = isPrimaryColumn ? this.entitySchema.name : column.referenceSchemaName;
				return !this.hasMiniPage(miniPageEntityName);
			}
			return true;
		}
	});

	return BPMSoft.BaseGridRowViewModel;
});
