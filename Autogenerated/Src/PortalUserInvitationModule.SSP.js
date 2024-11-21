define("PortalUserInvitationModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.PortalUserInvitationModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.PortalUserInvitationModule",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "PortalUserInvitationModuleSchema";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#createViewModel
		 * @protected
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			var parameters = this.parameters;
			if (parameters) {
				viewModel.$PortalAccountId = parameters.PortalAccountId;
			}
			return viewModel;
		},

		/**
		 * @inheritDoc BaseSchemaModuleV2#render
		 * @override
		 */
		render: function() {
			this.callParent(arguments);
			this.centerInviteContainerPosition();
		},

		/**
		 * Centres alignable invitation container.
		 * @protected
		 */
		centerInviteContainerPosition: function () {
			var alignContainerEl = Ext.get("AlignableInviteContainer");
			if (alignContainerEl) {
				alignContainerEl.center(Ext.getBody());
				alignContainerEl.addCls("invite-alignable-container-background");
			}
		}
	});
	return BPMSoft.PortalUserInvitationModule;
});
