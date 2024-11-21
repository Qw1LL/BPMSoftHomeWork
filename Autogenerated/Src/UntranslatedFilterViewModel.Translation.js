define("UntranslatedFilterViewModel", ["ext-base", "BPMSoft", "PredefinedFilterViewModel"], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.model.UntranslatedFilter", {
		extend: "BPMSoft.PredefinedFilter",
		alternateClassName: "BPMSoft.UntranslatedFilter",

		//region Fields: Private

		/**
		 * Primary column path.
		 * @type {String}
		 */
		primaryColumnPath: "",

		//endregion

		// region Constructors: Public

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			if (!this.primaryColumnPath) {
				throw new BPMSoft.NullOrEmptyException();
			}
		},

		//endregion

		//region Methods: Private

		/**
		 * Creates primary culture compare filter.
		 * @private
		 * @param {String} columnPath Column path.
		 * @return {BPMSoft.CompareFilter}
		 */
		createPrimaryCultureCompareFilter: function(columnPath) {
			var leftExpression = this.Ext.create("BPMSoft.ColumnExpression", {
				columnPath: this.primaryColumnPath
			});
			var rightExpression = this.Ext.create("BPMSoft.ColumnExpression", {
				columnPath: columnPath
			});
			return this.BPMSoft.createCompareFilter(BPMSoft.ComparisonType.EQUAL, leftExpression, rightExpression);
		},

		//endregion

		//region Methods: Protected

		/**
		 * Adds filter.
		 * @protected
		 * @param {String} columnPath Column path.
		 */
		addFilter: function(columnPath) {
			var rootFilterGroup = this.getFilters();
			rootFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			var subFilterGroup = this.BPMSoft.createFilterGroup();
			subFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			rootFilterGroup.add(columnPath, subFilterGroup);
			var predefinedFilter = this.createFilter(columnPath);
			subFilterGroup.addItem(predefinedFilter);
			if (columnPath === this.primaryColumnPath) {
				this.BPMSoft.each(this.columns, function(column) {
					if (column.columnPath === this.primaryColumnPath) {
						return;
					}
					subFilterGroup.addItem(this.createPrimaryCultureCompareFilter(column.columnPath));
				}, this);
			} else {
				subFilterGroup.addItem(this.createPrimaryCultureCompareFilter(columnPath));
			}
		}

		//endregion
	});
});

