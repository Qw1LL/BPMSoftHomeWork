define("OpportunityMiniPage", ["LeadConfigurationConst", "CreateLeadForEntityUtilities"],
		function(LeadConfigurationConst) {
	return {
		entitySchemaName: "Opportunity",
		mixins: {
			/**
			 * @class CreateLeadForEntityUtilities
			 * Create lead for entity utilites mixin.
			 */
			CreateLeadForEntityUtilities: "BPMSoft.CreateLeadForEntityUtilities"
		},
		attributes: {
			"LeadType": {"isRequired": true}
		},
		methods: {
			/**
			 * @inheritDoc OpportunityMiniPage#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.mixins.CreateLeadForEntityUtilities.init.call(this);
			},

			/**
			 * Returns True if mini page is in add mode.
			 * @return {Boolean} Is minipage in add mode result.
			 */
			isNewMode: function() {
				return this.isAddMode();
			},

			/**
			 * @inheritDoc BPMSoft.CreateLeadForEntityUtilities#addQueryColumns
			 * @overridden
			 */
			addQueryColumns: function(insertQuery) {
				this.addLookupQueryColumn(insertQuery, {
					columnName: "Account",
					entityColumnName: "QualifiedAccount"
				});
				this.addLookupQueryColumn(insertQuery, {
					columnName: "Contact",
					entityColumnName: "QualifiedContact"
				});
				this.addLookupQueryColumn(insertQuery, {
					columnName: "LeadType",
					entityColumnName: "LeadType"
				});
				insertQuery.setParameterValue("QualifyStatus",
						LeadConfigurationConst.LeadConst.QualifyStatus.WaitingForSale,
						this.BPMSoft.DataValueType.GUID);
			},

			/**
			 * Adds lookup column to insert query.
			 * @param {BPMSoft.InsertQuery} insertQuery Insert query.
			 * @param {Object} config Column config.
			 * @param {String} config.columnName Column name.
			 * @param {String} config.entityColumnName Entity column name.
			 */
			addLookupQueryColumn: function(insertQuery, config) {
				var columnValue = this.get(config.columnName);
				if (columnValue && columnValue.value && config.entityColumnName) {
					insertQuery.setParameterValue(config.entityColumnName,
							columnValue.value, this.BPMSoft.DataValueType.GUID);
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseMiniPage#saveEntityInChain
			 * @overridden
			 */
			saveEntityInChain: function(callback, scope) {
				var createLeadCallback = this.createLeadAfterSave.bind(scope || this, callback);
				this.callParent([createLeadCallback]);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "LeadType",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"visible": {"bindTo": "isNotViewMode"}
					},
					"dataValueType": this.BPMSoft.DataValueType.ENUM,
					"layout": {"column": 0, "row": 3, "colSpan": 24},
					"isMiniPageModelItem": true,
					"placeholder": "Выберите тип потребности"
				}
			},
			{
				"operation": "merge",
				"name": "Stage",
				"values": {
					"layout": {"column": 0, "row": 4, "colSpan": 24}
				}
			},
			{
				"operation": "merge",
				"name": "Budget",
				"values": {
					"layout": {"column": 0, "row": 5, "colSpan": 24}
				}
			},
			{
				"operation": "merge",
				"name": "Account",
				"values": {
					"layout": {"column": 0, "row": 6, "colSpan": 18}
				}
			},
			{
				"operation": "merge",
				"name": "AccountContainer",
				"values": {
					"layout": {"column": 18, "row": 6, "colSpan": 6}
				}
			},
			{
				"operation": "merge",
				"name": "Contact",
				"values": {
					"layout": {"column": 0, "row": 7, "colSpan": 18}
				}
			},
			{
				"operation": "merge",
				"name": "ContactContainer",
				"values": {
					"layout": {"column": 18, "row": 7, "colSpan": 6}
				}
			},
			{
				"operation": "merge",
				"name": "Owner",
				"values": {
					"layout": {"column": 0, "row": 8, "colSpan": 18}
				}
			},
			{
				"operation": "merge",
				"name": "OwnerButtonContainer",
				"values": {
					"layout": {"column": 18, "row": 8, "colSpan": 6}
				}
			},
			{
				"operation": "merge",
				"name": "PrimaryContact",
				"values": {
					"layout": {"column": 0, "row": 9, "colSpan": 18}
				}
			},
			{
				"operation": "merge",
				"name": "PrimaryContactButtonContainer",
				"values": {
					"layout": {"column": 18, "row": 9, "colSpan": 6}
				}
			},
			{
				"operation": "merge",
				"name": "LastActivity",
				"values": {
					"layout": {"column": 0, "row": 10, "colSpan": 24}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
