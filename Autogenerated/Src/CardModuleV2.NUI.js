define("CardModuleV2", ["BusinessRulesApplierV2", "BaseSchemaModuleV2", "HistoryStateUtilities",
		"ProcessCardModuleMixin", "AdditionalDiffUtilities"], function(BusinessRulesApplier) {
	/**
	 * ### #####, ####### ############ ### ######## ###### ########
	 */
	Ext.define("BPMSoft.configuration.CardModule", {
		alternateClassName: "BPMSoft.CardModule",
		extend: "BPMSoft.BaseSchemaModule",

		mixins: {
			historyStateUtilities: "BPMSoft.HistoryStateUtilities",
			processCardModuleMixin: "BPMSoft.configuration.mixins.ProcessCardModuleMixin",
			AdditionalDiffUtilities: "BPMSoft.AdditionalDiffUtilities",
			PageUtilities: "BPMSoft.PageUtilities"
		},

		/**
		 * ####, ########### ## ##, ### ######## ## ######## ####.
		 * #### ######## false, ## ## ######## ############ SectionModule
		 * @protected
		 * @type {Boolean}
		 */
		isSeparateMode: true,

		/**
		 * Is use separated page header flag.
		 * @protected
		 * @type {Boolean}
		 */
		useSeparatedPageHeader: false,

		/**
		 * Determines if {@link BPMSoft.configuration.CardModule#isSeparateMode isSeparateMode} property
		 * is initialized.
		 * @private
		 * @type {Boolean}
		 */
		isSeparateModeInitialized: false,

		/**
		 * ######## ##### #######.
		 * @protected
		 * @type {String}
		 */
		entitySchemaName: "",

		/**
		 * ######## ######### #######
		 * @protected
		 * @type {String}
		 */
		primaryColumnValue: BPMSoft.GUID_EMPTY,

		/**
		 * ##### ###### ########.
		 * ConfigurationEnums.CardStateV2.ADD|EDIT|COPY
		 * @protected
		 * @type {String}
		 */
		operation: "",

		/**
		 * ####, ########### ## ##, ### ######## ####### # #######
		 * @protected
		 * @type {Boolean}
		 */
		isInChain: false,

		/**
		 * @inheritdoc BPMSoft.configuration.BaseSchemaModule#init
		 * @overridden
		 */
		init: function() {
			const historyHash = this._getHistoryHash();
			if (this.getCanTryShowProcessCard(historyHash)) {
				const parentInit = this.getParentMethod(this, arguments);
				this.tryShowProcessCard({
					recordId: historyHash.recordId
				}, function(isRedirected) {
					if (!isRedirected) {
						parentInit();
					}
				});
				return;
			}
			this.callParent(arguments);
			this.activateMediaHeader();
		},

		/**
		 * ######## ######### ####### # ####### #########, #### ### ############# ###### ########## ## ########
		 * @protected
		 * @overridden
		 */
		initHistoryState: function() {
			var sandbox = this.sandbox;
			var historyState = sandbox.publish("GetHistoryState");
			var state = historyState.state || {};
			var isSeparateMode = this.getIsSeparateMode();
			if (state.isInChain || isSeparateMode) {
				this.callParent(arguments);
			}
		},

		/**
		 * Gets {@link BPMSoft.configuration.CardModule#isSeparateMode isSeparateMode} property value.
		 * @private
		 * @return {Boolean}
		 */
		getIsSeparateMode: function() {
			if (this.isSeparateModeInitialized) {
				return this.isSeparateMode;
			}
			var historyState = this.sandbox.publish("GetHistoryState");
			return (historyState.hash.moduleName === "CardModuleV2");
		},

		/**
		 * Sets {@link BPMSoft.configuration.CardModule#isSeparateMode isSeparateMode} property value.
		 * @private
		 * @param {Boolean} value New value.
		 */
		setIsSeparateMode: function(value) {
			this.isSeparateMode = value;
			this.isSeparateModeInitialized = true;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseSchemaModule#initSchemaName
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			var historyState = this.sandbox.publish("GetHistoryState");
			var state = historyState.state || {};
			this.isInChain = state.isInChain;
			if (this.Ext.isEmpty(state.schemaName) && !this.isInChain) {
				var isSeparateMode = this.getIsSeparateMode();
				this.setIsSeparateMode(isSeparateMode);
				var historyStateInfo = this.getHistoryStateInfo();
				this.schemaName = historyStateInfo.schemas.pop();
				this.operation = historyStateInfo.operation;
				this.primaryColumnValue = historyStateInfo.primaryColumnValue;
			} else {
				this.setIsSeparateMode(state.isSeparateMode);
				if (state.entitySchemaName) {
					this.entitySchemaName = state.entitySchemaName;
				}
				this.schemaName = state.schemaName;
				this.operation = state.operation;
				this.primaryColumnValue = state.primaryColumnValue;
			}
		},

		/**
		 * Returns a view model settings.
		 * @return {Object} View model settings.
		 */
		getViewModelConfig: function() {
			var viewModelConfig = this.callParent(arguments);
			if (viewModelConfig) {
				viewModelConfig.values = viewModelConfig.values || {};
				this._applyValues(viewModelConfig.values);
			}
			return viewModelConfig;
		},

		/**
		 * @private
		 */
		_applyValues: function(valuesConfig) {
			Ext.apply(valuesConfig, {
				IsSeparateMode: this.isSeparateMode,
				PrimaryColumnValue: this.primaryColumnValue,
				Operation: this.operation,
				IsInChain: this.isInChain,
				UseSeparatedPageHeader: this.useSeparatedPageHeader
			});
		},

		/**
		 * @private
		 */
		_getHistoryHash: function() {
			const history = this.sandbox.publish("GetHistoryState");
			const historyHash = history.hash;
			const historyState = history.state;
			if (Ext.isEmpty(historyState) || !historyState.isInChain) {
				return historyHash;
			}
			return {
				entityName: historyState.schemaName,
				recordId: historyState.primaryColumnValue,
				operationType: historyState.operation
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#createViewModel
		 * Method for card schemes, applies depending on the columns.
		 * (see {@link BPMSoft.BusinessRulesApplier.applyDependencies}).
		 * @protected
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			if (viewModel.type === BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA) {
				BusinessRulesApplier.applyDependencies(viewModel);
			}
			return viewModel;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getAdditionalDiff
		 * @override
		 */
		getAdditionalDiff: function() {
			return this.mixins.AdditionalDiffUtilities.getAdditionalDiff.apply(this, arguments);
		}

	});
	return BPMSoft.CardModule;
});
