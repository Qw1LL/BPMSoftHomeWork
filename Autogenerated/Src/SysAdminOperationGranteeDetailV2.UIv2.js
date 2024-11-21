/**
 * Parent: BaseOperationGranteeDetail
 */
define("SysAdminOperationGranteeDetailV2", ["RightsServiceHelper", "SysAdminOperationGranteeDetailV2Resources"], function() {
	return {
		entitySchemaName: "SysAdminOperationGrantee",
		mixins: {
			RightsServiceHelper: "BPMSoft.RightsServiceHelper"
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#checkCanChangeGrantee
			 * @overridden
			 */
			checkCanChangeGrantee: function(callbackAllow, callbackDenied, scope) {
				this.checkCanChangeAdminOperationGrantee(callbackAllow, callbackDenied, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#deleteGrantees
			 * @overridden
			 */
			deleteGrantees: function(itemIds, callback, scope) {
				this.deleteAdminOperationGrantee(itemIds, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#insertGrantees
			 * @overridden
			 */
			setOperationGrantees: function(adminUnitIds, canExecute, callback, scope) {
				const adminOperationId = this.get("MasterRecordId");
				this.setAdminOperationGrantees(adminOperationId, adminUnitIds, canExecute, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#setGranteePosition
			 * @overridden
			 */
			setGranteePosition: function(itemId, position, callback, scope) {
				this.setAdminOperationGranteePosition(itemId, position, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#getAdminUnitLookupFilters
			 * @overridden
			 */
			getAdminUnitLookupFilters: function() {
				const filterGroup = this.callParent(arguments);
				const operationFilter = this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "SysAdminOperation", this.get("MasterRecordId"));
				filterGroup.subFilters.addItem(operationFilter);
				return filterGroup;
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
	};
});
