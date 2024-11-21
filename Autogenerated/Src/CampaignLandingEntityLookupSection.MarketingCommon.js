define("CampaignLandingEntityLookupSection", [],
	function() {
		return {
			attributes: {},
			methods: {

				/**
				 * @inheritdoc BPMSoft.LinkedEntitySchemaLookupSection#columnsFiltrationMethod
				 * @override
				 */
				columnsFiltrationMethod: function(column) {
					const dataValueType = column.dataValueType;
					var allowedTypes = [];
					if (this.columnName === "WebFormColumn") {
						allowedTypes = [
							BPMSoft.DataValueType.LOOKUP,
							BPMSoft.DataValueType.GUID
						];
					}
					if (this.columnName === "ContactColumn") {
						allowedTypes = [
							BPMSoft.DataValueType.LOOKUP
						];
					}
					return Ext.Array.contains(allowedTypes, dataValueType);
				},

				/**
				 * @inheritdoc BPMSoft.LinkedEntitySchemaLookupSection#updateColumnHandler
				 * @override
				 */
				updateColumnHandler: function(result, row, columnName) {
					row.set(columnName, result.leftExpressionColumnPath);
				},

				/**
				 * @inheritdoc BPMSoft.LinkedEntitySchemaLookupSection#getIsReadonlyColumn
				 * @override
				 */
				getIsReadonlyColumn: function(columnName) {
					return columnName === "ContactColumn" || columnName === "WebFormColumn";
				}
			},
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	});
