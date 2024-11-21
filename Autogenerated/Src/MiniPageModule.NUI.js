define("MiniPageModule", ["BusinessRulesApplierV2", "BaseSchemaModuleV2", "MiniPageViewGenerator"],
	function(BusinessRulesApplier) {
		Ext.define("BPMSoft.configuration.MiniPageModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.MiniPageModule",

			Ext: null,

			sandbox: null,

			BPMSoft: null,

			parameters: null,

			useHistoryState: false,

			showMask: true,

			messages: {

				"GetMiniPageMasterEntityInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateCardProperty
				 * Sets attributes for card.
				 * @type {Object}
				 */
				"UpdateCardProperty": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetLookupListConfig
				 * Get information about lookup column.
				 */
				"GetLookupListConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetLookupQueryFilters
				 * Get lookup query filters.
				 */
				"GetLookupQueryFilters": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#getViewModelConfig
			 * @overridden
			 */
			getViewModelConfig: function() {
				var viewModelConfig = this.callParent(arguments);
				var parameters = this.parameters;
				Ext.apply(viewModelConfig, {
					values: {
						PrimaryColumnValue: parameters && parameters.primaryColumnValue,
						RowId: parameters && parameters.rowId,
						IsSectionGrid: parameters && parameters.isSectionGrid,
						MiniPageSourceSandboxId: parameters && parameters.miniPageSourceSandboxId
					}
				});
				return viewModelConfig;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#createViewModel
			 * @overridden
			 */
			createViewModel: function() {
				var viewModel = this.callParent(arguments);
				BusinessRulesApplier.applyDependencies(viewModel);
				return viewModel;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#getSchemaBuilder
			 * @overridden
			 */
			getSchemaBuilder: function() {
				const parameters = this.parameters;
				const viewGeneratorClassName = (parameters && parameters.viewGeneratorClassName) ||
					"BPMSoft.MiniPageViewGenerator";
				return this.Ext.create("BPMSoft.SchemaBuilder", {
					"viewGeneratorClassName": viewGeneratorClassName
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				var parameters = this.parameters;
				this.schemaName = (parameters && parameters.schemaName) || "";
				this.entitySchemaName = (parameters && parameters.entitySchemaName) || "";
				this.registerMessages();
			},

			/**
			 * Register MiniPageModule messages.
			 * @private
			 */
			registerMessages: function() {
				if (this.messages) {
					this.sandbox.registerMessages(this.messages);
				}
			}

		});

		return BPMSoft.MiniPageModule;
	});
