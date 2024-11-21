define("DcmMixin", ["ext-base", "BPMSoft", "DcmMixinResources", "DcmUtilities", "WizardUtilities"
], function(Ext, BPMSoft, resources) {
	Ext.define("BPMSoft.configuration.mixins.DcmMixin", {
		alternateClassName: "BPMSoft.DcmMixin",

		mixins: {
			/**
			 * @class WizardUtilities Provides the ability to work with section wizard.
			 */
			WizardUtilities: "BPMSoft.WizardUtilities"
		},

		//region Methods: Public

		/**
		 * Init information about ability for use DCM page in section wizard.
		 * @param {Function} [callback] Callback method.
		 * @param {Object} [scope] Callback method context.
		 */
		initCanOpenDcmPageInSectionWizard: function(callback, scope) {
			var canCustomize = this.get("CanCustomize");
			var module = BPMSoft.configuration.ModuleStructure[this.entitySchemaName];
			if (module && canCustomize && this.entitySchemaName !== "Activity") {
				BPMSoft.DcmUtilities.checkCanManageDcmRights(function(isAllow) {
					this.set("CanOpenDcmPageInSectionWizard", isAllow);
					Ext.callback(callback, scope);
				}, this);
			} else {
				this.set("CanOpenDcmPageInSectionWizard", false);
				Ext.callback(callback, scope);
			}
		},

		/**
		 * Adds "Set section cases" menu item to "View" button menu.
		 * @param {BPMSoft.BaseViewModelCollection} viewOptions Menu items of "View" menu.
		 */
		addDcmPageInSectionWizardViewOptions: function(viewOptions) {
			viewOptions.addItem(this.getButtonMenuItem({
				"Caption": resources.localizableStrings.DcmPageInSectionWizardButtonCaption,
				"Click": {"bindTo": "openSectionWizard"},
				"Tag": {"pageName": BPMSoft.SectionWizardEnums.PageName.PAGE_CASES},
				"Visible": {"bindTo": "CanOpenDcmPageInSectionWizard"},
				"ImageConfig": resources.localizableImages.SetupSectionCasesIcon
			}));
		}

		//endregion

	});
	return Ext.create("BPMSoft.DcmMixin");
});
