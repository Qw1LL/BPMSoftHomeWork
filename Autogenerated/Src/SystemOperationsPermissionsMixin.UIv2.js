define("SystemOperationsPermissionsMixin", ["RightUtilities", "SystemOperationsPermissionsMixinResources"],
	function(RightUtilities, resources) {
		Ext.define("BPMSoft.configuration.mixins.SystemOperationsPermissionsMixin", {
			alternateClassName: "BPMSoft.SystemOperationsPermissionsMixin",

			//region Methods: Private

			/**
			 * Returns query for getting identifier of system operation by Code.
 			 * @param {String} operationCode Code of operation.
			 * @return {BPMSoft.EntitySchemaQuery} Select query.
			 */
			_getSysAdminOperationQuery: function(operationCode) {
				var query = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysAdminOperation",
					rowCount: 1
				});
				query.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				query.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Code", operationCode));
				return query;
			},

			//endregion

			//region Methods: Protected

			/**
			 * Callback function of check operations permissions.
			 * @protected
 			 * @param {String} operationCode Code of operation.
 			 * @param {Object} result Result of checking.
			 */
			checkCanExecuteOperationsCallback: function(operationCode, result) {
				var canChange = result.CanChangeAdminOperationGrantee && result.CanManageAdministration;
				var canChangeMessage = canChange
					? resources.localizableStrings.CanChangeAdminOperationMessage
					: resources.localizableStrings.CanNotChangeAdminOperationMessage;
				var message = resources.localizableStrings.RightsErrorMessage +
					Ext.String.format(canChangeMessage, operationCode);
				if (canChange) {
					var changeButtonCaption = resources.localizableStrings.ChangeButtonCaption;
					var changeButton = BPMSoft.getButtonConfig("change", changeButtonCaption);
					BPMSoft.showConfirmation(message, function(returnCode) {
						if (returnCode === "change") {
							var operationQuery = this._getSysAdminOperationQuery(operationCode);
							operationQuery.getEntityCollection(function(response) {
								this.showErrorMessage(response);
							}, this);
						}
					}, [changeButton, "cancel"], this);
				} else {
					BPMSoft.showInformation(message);
				}
				BPMSoft.MaskHelper.hideBodyMask();
			},

			/**
			 * Shows error message.
			 * @protected
			 * @param {Object} response System operation requested.
			 */
			showErrorMessage: function(response) {
				var entity = response.collection.first();
				this.openOperationEditPage(entity.$Id);
			},

			/**
			 * Opens System operation edit page.
			 * @protected
			 * @param {String} operationId System operation identifier.
			 */
			openOperationEditPage: function(operationId) {
				var hash = "CardModuleV2/SysAdminOperationPageV2/edit/" + operationId;
				this.sandbox.publish("PushHistoryState", {hash: hash});
			},

			//endregion

			//region Methods: Public

			/**
			 * Shows message about the deficiency rights to the operation.
 			 * @param {String} operationCode Code of operation.
			 */
			showPermissionsErrorMessage: function(operationCode) {
				RightUtilities.checkCanExecuteOperations(["CanChangeAdminOperationGrantee", "CanManageAdministration"],
					function(result) {
						this.checkCanExecuteOperationsCallback(operationCode, result);
					}, this);
			}

			//endregion

		});
		return Ext.create("BPMSoft.SystemOperationsPermissionsMixin");
	});
