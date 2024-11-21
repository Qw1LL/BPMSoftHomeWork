define("PortalClientAccountProfileSchema", ["ProfileSchemaMixin"], function() {
		return {
			entitySchemaName: "Account",
			messages: {
				/**
				 * Message, which is emmited in PortalAccountMiniPage in saved entity event.
				 */
				"AccountSaved": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				ProfileSchemaMixin: "BPMSoft.ProfileSchemaMixin"
			},
			methods: {
				/**
				 * @inheritDoc BaseProfileSchema#getMiniPageConfig
				 * @override
				 */
				getMiniPageConfig: function() {
					const parentConfig = this.callParent(arguments);
					parentConfig.miniPageSchemaName = "PortalAccountMiniPage";
					parentConfig.operation = BPMSoft.ConfigurationEnums.CardOperation.EDIT;
					return parentConfig;
				},

				/**
				 * @inheritDoc BaseProfileSchema#onProfileHeaderClick
				 * @override
				 */
				onProfileHeaderClick: function(options) {
					const config = this.getMiniPageConfig(options);
					this.openMiniPage(config);
					return false;
				},

				/**
				 * @inheritDoc BaseProfileSchema#subscribeSandboxEvents
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this._subscribeUpdateProfile();
				},

				/**
				 * @private
				 */
				_subscribeUpdateProfile: function() {
					this.sandbox.subscribe("AccountSaved", this.updateProfile, this, [this.sandbox.id]);
				},

				/**
				 * Updates profile entity state after manipulation in mini page
				 * @protected
				 */
				updateProfile: function() {
					this.initEntity();
				},

				/**
				 * @inheritDoc BaseProfileSchema#onProfileLinkMouseOver
				 * @override
				 */
				onProfileLinkMouseOver: BPMSoft.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
