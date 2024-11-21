 define("BaseDataView", ["PortalFolderManagerViewModel", "SSPGridMixin", "SspMiniPageListener"], function() {
		return {
			messages: {
				/**
				 * @message GetExtendedFilterConfig
				 * Quick filters settings generate.
				 */
				"GetExtendedFilterConfig": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				/**
				 * Provides methods for grid handling in ssp sections.
				 */
				"SSPGridMixin": "BPMSoft.SSPGridMixin"
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getEntitySchemaFilterProviderModuleName
				 * @overridden
				 */
				getEntitySchemaFilterProviderModuleName: function() {
					if (this.BPMSoft.isCurrentUserSsp()) {
						return "PortalEntitySchemaFilterProviderModule";
					}
					return this.callParent();
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function () {
					this.callParent(arguments);
					const quickFilterModuleId = this.getQuickFilterModuleId();
					this.sandbox.subscribe("GetExtendedFilterConfig", this.onGetExtendedFilterConfigForSSPUser,
						this, [quickFilterModuleId]);
				},

				/**
				 * Returns quick filters current section settings.
				 * @protected
				 * @return {Object} Filter settings.
				 */
				onGetExtendedFilterConfigForSSPUser: function () {
					return {
						hasExtendedMode: !this.BPMSoft.isCurrentUserSsp(),
						allowedColumns: this.mixins.SSPGridMixin.getAllowedColumns(this.entitySchemaName)
					};
				},

				/**
				 * @inheritDoc BPMSoft.BaseDataView#init.
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.$IsImportDisabled = this.BPMSoft.isCurrentUserSsp();
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.initPrintButtonsMenu#init.
				 * @override
				*/
				initPrintButtonsMenu: function(callback, scope) {
					if (this.BPMSoft.isCurrentUserSsp()) {
						this.Ext.callback(callback, scope || this);
						return;
					}
					this.callParent(arguments);
				}

				//endregion

			},
			properties: {
				folderManagerViewModelClassName: "BPMSoft.PortalFolderManagerViewModel"
			}
		};
	}
);
