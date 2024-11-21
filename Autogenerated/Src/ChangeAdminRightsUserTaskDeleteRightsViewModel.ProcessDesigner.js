define("ChangeAdminRightsUserTaskDeleteRightsViewModel", ["ChangeAdminRightsUserTaskBaseItemViewModel"],
	function() {
		/**
		 * @class BPMSoft.model.ChangeAdminRightsUserTaskDeleteRightsViewModel
		 * Model delete rights for the change admin rights user task.
		 */
		Ext.define("BPMSoft.model.ChangeAdminRightsUserTaskDeleteRightsViewModel", {
			extend: "BPMSoft.ChangeAdminRightsUserTaskBaseItemViewModel",
			alternateClassName: "BPMSoft.ChangeAdminRightsUserTaskDeleteRightsViewModel",

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getActiveItemEditName
			 * @overridden
			 */
			getActiveItemEditName: function() {
				return "ProcessDeleteRightsEditName";
			},

			/**
			 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getProcessMiniEditPageId
			 * @overridden
			 */
			getProcessMiniEditPageId: function() {
				return this.sandbox.id + "deleterightsedit";
			},

			/**
			 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getAddButtonEnabledProperyName
			 * @overridden
			 */
			getAddButtonEnabledProperyName: function() {
				return "IsDeleteRightsToolsButtonEnabled";
			},

			/**
			 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getBlockName
			 * @overridden
			 */
			getBlockName: function() {
				return "DeleteRights";
			}

			//endregion
		});

		return BPMSoft.ChangeAdminRightsUserTaskDeleteRightsViewModel;
	});
