define("AudienceSectionModule", ["SectionModuleV2", "css!SectionModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.AudienceSectionModule
	 */
	Ext.define("BPMSoft.configuration.AudienceSectionModule", {
		alternateClassName: "BPMSoft.AudienceSectionModule",
		extend: "BPMSoft.SectionModule",

		/**
		 * Suffix to indicate section type for module.
		 * @type {String}
		 */
		sectionSuffix: "SectionV2",

		/**
		 * Suffix to indicate grid view name.
		 * @type {String}
		 */
		gridViewSuffix: "GridSettingsGridDataView",

		/**
		 * @inheritdoc BPMSoft.SectionModule#getProfileKey
		 * @override
		 */
		getProfileKey: function() {
			return this.entitySchemaName + this.sectionSuffix + this.gridViewSuffix;
		},

		/**
		 * Inits entity schema name property from historyState.
		 * @protected
		 */
		initEntitySchemaName: function() {
			var historyState = this.sandbox.publish("GetHistoryState");
			this.entitySchemaName = historyState.state.entitySchema;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @override
		 */
		init: function(callback, scope) {
			this.initEntitySchemaName();
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.SectionModule#actualizeCardHistoryState
		 * @override
		 */
		actualizeCardHistoryState: BPMSoft.emptyFn

	});
	return BPMSoft.AudienceSectionModule;
});
