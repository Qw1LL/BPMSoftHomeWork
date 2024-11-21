define("MLColumnSelectionModule", ["BaseSchemaModuleV2"],
	function() {
		/**
		 * @class BPMSoft.configuration.ProductSelectionModule
		 */
		Ext.define("BPMSoft.configuration.MLColumnSelectionModule", {
			alternateClassName: "BPMSoft.MLColumnSelectionModule",
			extend: "BPMSoft.BaseSchemaModule",
			schemaName: "MLColumnSelectionSchema",
			Ext: null,
			sandbox: null,
			BPMSoft: null,
			messages: null,
			useHistoryState: false,
			isSchemaConfigInitialized: true,
			entitySchemaName: "MLModelColumn",
			rootSchema: null,
			columnType: null,
			title: null,
			helpText: null,

			createViewModel: function() {
				const viewModel = this.callParent(arguments);
				viewModel.$SelectionRootSchemaAttributeName = this.rootSchema;
				viewModel.$MLColumnType = this.columnType;
				viewModel.$ModuleTitle = this.title;
				viewModel.$HelpText = this.helpText;
				return viewModel;
			}
		});

		return BPMSoft.MLColumnSelectionModule;
	});
