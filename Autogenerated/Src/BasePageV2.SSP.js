define("BasePageV2", ["PortalClientConstants", "SchemaAccessControllerMixin"], function (PortalConsts) {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		mixins: {
			"SchemaAccessControllerMixin": "BPMSoft.SchemaAccessControllerMixin"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function () {
				if (this._isNeedToCheckAccess()) {
					const historyState = this.getHistoryStateInfo();
					const hash = this.BPMSoft.combinePath("CardModuleV2", "cardSchema",
						historyState.operation, historyState.primaryColumnValue);
					const isRedirected = this.redirectIfDenied("cardSchema", hash);
					if (isRedirected) {
						return;
					}
				}
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_isNeedToCheckAccess: function() {
				return this.BPMSoft.isCurrentUserSsp() &&
					this._checkDesignerPages() &&
					!(this.$IsProcessMode || this.$IsInChain);
			},

			/**
			 * @private
			 */
			_checkDesignerPages: function () {
				return !this.BPMSoft.contains(Object.values(PortalConsts.DesignerPagesName), this.name);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
