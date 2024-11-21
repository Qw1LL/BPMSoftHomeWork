define("CaseSearchRowSchema", [], function() {
	return {
		attributes: {},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#initAttributeValues
			 * @overridden
			 */
			initAttributeValues: function() {
				this.callParent(arguments);
				this._initSupportLevel();
			},

			/**
			 * @private
			 */
			_initSupportLevel: function () {
				var primaryColumnValue = this.get(this.primaryColumnName);
				if (!primaryColumnValue) {
					return;
				}
				var esq = this.Ext.create(BPMSoft.EntitySchemaQuery, {
					rootSchemaName: "Case"
				});
				esq.addColumn("SupportLevel");
				esq.enablePrimaryColumnFilter(primaryColumnValue);
				esq.execute(function (response) {
					if (response.success) {
						var caseItem = response.collection.first();
						this.set("SupportLevel", caseItem.get("SupportLevel"));
					}
				}, this);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "SupportLevel",
				"values": {
					"layout": {
						"column": 13,
						"row": 2,
						"colSpan": 6
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
