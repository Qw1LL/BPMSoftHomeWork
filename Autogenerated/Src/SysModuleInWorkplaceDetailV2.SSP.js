define("SysModuleInWorkplaceDetailV2", ["PortalClientConstants"], function(PortalClientConstants) {
	return {
		methods: {
			/**
			 * @inheritDoc BPMSoft.SysModuleInWorkplaceDetailV2#tryOpenSectionWizard
			 * @override
			 */
			tryOpenSectionWizard: function(record) {
				const module = record.get("SysModule");
				const moduleId = module.value;
				if (moduleId === PortalClientConstants.SysModule.PortalMainSectionId) {
					const url = this.BPMSoft.combinePath(
						this.BPMSoft.workspaceBaseUrl,
						"Nui",
						"ViewModule.aspx#PortalMainPageModule");
					window.open(url);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritDoc BPMSoft.SysModuleInWorkplaceDetailV2#processedGeneralAndSspSections
			 * @override
			 */
			processedGeneralAndSspSections: function(result, selectedRows) {
				const generalAndSspSections = result.GetGeneralAndSspSectionsResult;
				const sectionId = selectedRows && selectedRows.getByIndex(0).value;
				if (generalAndSspSections && sectionId === PortalClientConstants.SysModule.PortalMainSectionId) {
					this._addSectionsToWorkplace(selectedRows);
				} else {
					this.callParent(arguments);
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
