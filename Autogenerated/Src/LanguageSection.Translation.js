define("LanguageSection", ["BPMSoft", "css!TranslationCSS", "SysLanguageSectionGridRowViewModel"],
		function(BPMSoft) {
	return {
		entitySchemaName: "SysCulture",
		attributes: {
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseSeparatedPageHeader
			 * @overridden
			 */
			"UseSeparatedPageHeader": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseSectionHeaderCaption
			 * @overridden
			 */
			"UseSectionHeaderCaption": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#SecurityOperationName
			 * @overridden
			 */
			"SecurityOperationName": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "CanManageLanguageSection"
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Navigates to translation.
			 * @private
			 */
			navigateToTranslation: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: "SectionModuleV2/TranslationSection"
				});
			},

			/**
			 * Exports translation.
			 * @private
			 */
			exportTranslation: function() {

			},

			/**
			 * Imports translation.
			 * @private
			 */
			importTranslation: function() {

			},

			/**
			 * Checks if cultures contain primary culture.
			 * @private
			 * @param {Array} cultures Cultures identifiers.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 */
			containsPrimaryCulture: function(cultures, callback, scope) {
				this.BPMSoft.SysSettings.querySysSettingsItem("PrimaryCulture", function(primaryCulture) {
					var containsPrimaryCulture = (cultures.indexOf(primaryCulture.value) > -1);
					callback.call(scope, containsPrimaryCulture);
				}, this);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initEditPages: function() {
				this.callParent(arguments);
				var editPages = this.Ext.create(this.BPMSoft.BaseViewModelCollection);
				var typeUId = this.BPMSoft.GUID_EMPTY;
				var item = this.getButtonMenuItem({
					Id: typeUId,
					Caption: this.get("Resources.Strings.NewLanguage"),
					Click: {
						bindTo: "addRecord"
					},
					Tag: typeUId,
					SchemaName: "LanguagePage"
				});
				editPages.add(typeUId, item);
				this.set("EditPages", editPages);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getModuleCaption: function() {
				return this.get("Resources.Strings.SectionCaption");
			},

			/**
			 * Gets data views.
			 * @protected
			 */
			getDataViews: function() {
				return this.Ext.create(BPMSoft.Collection);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			updateSectionHeader: function() {
				var caption = this.get("Resources.Strings.PageCaption");
				this.sandbox.publish("ChangeHeaderCaption", {
					caption: caption,
					dataViews: this.getDataViews(),
					moduleName: this.name
				});
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getSectionActions: function() {
				var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "navigateToTranslation"},
					"Caption": {"bindTo": "Resources.Strings.NavigateToTranslationCaption"},
					"Tag": "NavigateToTranslation"
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "exportTranslation"},
					"Caption": {"bindTo": "Resources.Strings.ExportCaption"},
					"Tag": "Export",
					"Visible": false
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "importTranslation"},
					"Caption": {"bindTo": "Resources.Strings.ImportCaption"},
					"Tag": "Import",
					"Visible": false
				}));
				return actionMenuItems;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
			 * @overridden
			 */
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getGridRowViewModelClassName
			 * @overridden
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.SysLanguageSectionGridRowViewModel";
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#checkCanDelete
			 * @overridden
			 */
			checkCanDelete: function(items, callback, scope) {
				this.callParent([items, function(result) {
					if (result) {
						callback.call(scope, result);
						return;
					}
					this.containsPrimaryCulture(items, function(containsPrimaryCulture) {
						if (!containsPrimaryCulture) {
							callback.call(scope, result);
							return;
						}
						var message = this.get("Resources.Strings.PrimaryCultureDeleteMessage");
						this.showInformationDialog(message);
					}, this);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getDefaultDeleteExceptionMessage
			 * @overridden
			 * @protected
			 */
			getDefaultDeleteExceptionMessage: function() {
				return this.get("Resources.Strings.DefaultExceptionMessage");
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getRecordDependencyWarningMessage
			 * @overridden
			 * @protected
			 */
			getRecordDependencyWarningMessage: function() {
				return this.get("Resources.Strings.DefaultExceptionMessage");
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "SeparateModeViewOptionsButton",
				"values": {"visible": false}
			},
			{
				"operation": "merge",
				"name": "CombinedModeViewOptionsButton",
				"values": {"visible": false}
			},
			{
				"operation": "merge",
				"name": "SortMenuContainer",
				"values": {"visible": false}
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			}
		]/**SCHEMA_DIFF*/
	};
});
