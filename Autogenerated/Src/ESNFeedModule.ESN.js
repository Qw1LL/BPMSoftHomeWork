define("ESNFeedModule", ["ext-base", "BPMSoft", "BaseSchemaModuleV2", "ImageView", "css!ESNFeedStyle"],
		function(Ext, BPMSoft) {
			return Ext.define("BPMSoft.configuration.SocialFeedModule", {

				extend: "BPMSoft.BaseSchemaModule",
				alternateClassName: "BPMSoft.SocialFeedModule",

				/**
				 * @inheritdoc BPMSoft.BaseSchemaModule#generateViewContainerId
				 * @overridden
				 */
				generateViewContainerId: false,

				/**
				 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
				 * @overridden
				 */
				initSchemaName: function() {
					this.schemaName = "SocialFeed";
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
				 * @overridden
				 */
				initHistoryState: BPMSoft.emptyFn,

				/**
				 * @inheritdoc
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initMessages();
				},

				/**
				 * ############# ######## ## ######### ######.
				 * @private
				 */
				initMessages: function() {
					this.sandbox.subscribe("RerenderModule", function(config) {
						if (this.viewModel) {
							this.render(this.Ext.get(config.renderTo));
							return true;
						}
					}, this, [this.sandbox.id]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaModule#createViewModel
				 * @overridden
				 */
				createViewModel: function() {
					var viewModel = this.callParent(arguments);
					this.initParameters(viewModel);
					return viewModel;
				},

				/**
				 * ############# ###### ############# ########### ######.
				 * @private
				 * @param {BPMSoft.BaseViewModel} viewModel ###### #############.
				 */
				initParameters: function(viewModel) {
					var parameters = this.parameters;
					var activeSocialMessageId;
					if (parameters) {
						activeSocialMessageId = parameters.activeSocialMessageId;
					}
					viewModel.activeSocialMessageId = activeSocialMessageId;
				}
			});
		});
