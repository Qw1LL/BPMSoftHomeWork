define("OperatorSingleWindowSocialMessageViewModel", ["SocialMessageViewModel"], function() {

		/**
		 * @class BPMSoft.configuration.OperatorSingleWindowSocialMessageViewModel
		 */
		Ext.define("BPMSoft.model.OperatorSingleWindowSocialMessageViewModel", {

			extend: "BPMSoft.SocialMessageViewModel",
			alternateClassName: "BPMSoft.OperatorSingleWindowSocialMessageViewModel",

			/**
			 * Operator Single WindoW sandbox id.
			 */
			esnOperatorSingleWindowSandboxId: "OperatorSingleWindowModule_SingleWindow_ESNFeedModule",

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.SocialFeedUtilities#getIsRightPanel
			 */
			getIsRightPanel: function() {
				return (this.callParent(arguments) || this.sandbox.id === this.esnOperatorSingleWindowSandboxId);
			}

			//endregion

		});
	});
