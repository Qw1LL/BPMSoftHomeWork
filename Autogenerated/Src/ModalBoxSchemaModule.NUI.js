define("ModalBoxSchemaModule", ["ext-base", "ModalBox", "BaseSchemaModuleV2"], function(Ext, ModalBox) {

	/**
	 * Class of ModalBoxSchemaModule.
	 */
	Ext.define("BPMSoft.configuration.ModalBoxSchemaModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.ModalBoxSchemaModule",

		/**
		 * Modal window default sizes range configuration.
		 * @protected
		 * @type {Object}
		 */
		modalBoxSize: {
			minHeight: "1",
			minWidth: "1",
			maxHeight: "100",
			maxWidth: "100"
		},

		/**
		 * Default modal window size (in pixels).
		 * @protected
		 * @type {Object}
		 */
		initialSize: {
			width: 820,
			height: 600
		},

		/**
		 * Main container css classes.
		 * @protected
		 * @type {Array}
		 */
		mainContainerWrapClasses: null,

		/**
		 * Header container css classes.
		 * @protected
		 * @type {Array}
		 */
		headerWrapClasses: null,

		/**
		 * Container name to render into.
		 * @type {String}
		 */
		renderTo: "ModalBox",

		/**
		 * Container to render module into.
		 * @protected
		 * @type {Object}
		 */
		modalBoxContainer: null,

		/**
		 * Module header view.
		 * @protected
		 * @type {Object}
		 */
		headerView: null,

		/**
		 * Module configuration.
		 * @protected
		 * @type {Object}
		 */
		moduleInfo: null,

		/**
		 * ModalBox css custom classes.
		 * @protected
		 * @type {Array}
		 */
		customBoxClasses: null,

		/**
		 * Returns ModalBox module instance.
		 * @protected
		 * @return {Object}
		 */
		getModalBox: function() {
			return ModalBox;
		},

		/**
		 * Unloads current module instance from sandbox, fires ModalBoxClosing message.
		 * @private
		 */
		onModalBoxClosed: function() {
			const viewModel = this.viewModel;
			if (viewModel && Ext.isFunction(viewModel.beforeModalBoxClosing)) {
				viewModel.beforeModalBoxClosing();
			}
			this.sandbox.unloadModule(this.sandbox.id);
		},

		/**
		 * Returns fixed container inside modal window.
		 * @protected
		 * @return {Object} Fixed size container.
		 */
		getFixedHeaderContainer: function() {
			const modalBox = this.getModalBox();
			return modalBox.getFixedBox();
		},

		/**
		 * Returns main container inside modal window.
		 * @protected
		 * @return {Object} Main container.
		 */
		getContentContainer: function() {
			return this.modalBoxContainer;
		},

		/**
		 * Updates window size depending on arguments or window content (in case no arguments defined).
		 * @protected
		 * @param {Number} width Window width.
		 * @param {Number} height Window height.
		 */
		updateSize: function(width, height) {
			const modalBox = this.getModalBox();
			if (width && height) {
				modalBox.setSize(width, height);
			} else {
				modalBox.updateSizeByContent();
			}
		},

		/**
		 * Combines (or overrides) default modal size settings with schema specific settings.
		 * @protected
		 * @param {Object} [modalConfig] Modal window custom configuration.
		 * @return {Object} Modal schema configuration.
		 */
		getModalConfig: function(modalConfig) {
			const moduleInfo = this.moduleInfo || {};
			const modalBoxConfig = moduleInfo.modalBoxConfig ? this.moduleInfo.modalBoxConfig : {};
			const config = Ext.apply(this.modalBoxSize, modalBoxConfig);
			if (modalConfig) {
				Ext.apply(config, modalConfig);
			}
			
			//config.boxClasses = ["schema-module-modal"];
			
			config.boxClasses = modalConfig
			? modalConfig.boxClasses
			: ["schema-module-modal"];

			const customBoxClasses = this.customBoxClasses;
			customBoxClasses?.forEach((customClass) => {
				config.boxClasses.push(customClass);
			})

			return config;
		},

		/**
		 * Prepares modal box for rendering. Sets default window size and applies config.
		 * @protected
		 * @param {Object} [config] Modal window cutom parameters.
		 * @param {Object} [config.modalBoxConfig] Modal box parameters.
		 * @param {Object} [config.initialSize] Modal box initial size.
		 */
		prepareModalBox: function(config) {
			if (!this.modalBoxContainer) {
				config = config || {};
				const modalBox = this.getModalBox();
				const modalBoxConfig = this.getModalConfig(config.modalBoxConfig);
				this.modalBoxContainer = modalBox.show(modalBoxConfig, this.onModalBoxClosed, this);
				const initialSize = config.initialSize || this.initialSize;
				modalBox.setSize(initialSize.width, initialSize.height);
			}
		},

		/**
		 * Makes modal window close.
		 * @protected
		 */
		closeModalBox: function() {
			if (this.modalBoxContainer) {
				const modalBox = this.getModalBox();
				modalBox.close(true);
				this.modalBoxContainer = null;
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			if (!this.moduleInfo) {
				this.moduleInfo = this.sandbox.publish("GetModuleInfo", null, [this.sandbox.id]);
			}
			this.schemaName = this.moduleInfo.schemaName;
			this.entitySchemaName = this.moduleInfo.entitySchemaName;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#createViewModel
		 * @override
		 */
		createViewModel: function() {
			const viewModel = this.callParent(arguments);
			viewModel.destroyModule = this.destroyModule.bind(this);
			viewModel.updateSize = this.updateSize.bind(this);
			return viewModel;
		},

		/**
		 * Returns view model configuration.
		 * @protected
		 * @return {Object} View model configuration object.
		 */
		getViewModelConfig: function() {
			const viewModelConfig = this.callParent(arguments);
			Ext.merge(viewModelConfig, {
				values: {moduleInfo: this.moduleInfo}
			});
			return viewModelConfig;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#render
		 * @override
		 */
		render: function() {
			const viewModel = this.viewModel;
			const modalBoxConfig = Ext.isFunction(viewModel.getModalBoxInitialConfig)
				? viewModel.getModalBoxInitialConfig()
				: undefined;
			this.prepareModalBox(modalBoxConfig);
			const renderTo = this.getContentContainer();
			const headerRenderTo = this.getFixedHeaderContainer();
			const containerName = this.schemaName + this.autoGeneratedContainerSuffix;
			const headerContainerName = this.schemaName + this.autoGeneratedContainerSuffix + "header";
			let view = this.view;
			let headerView = this.headerView;
			if (!view || view.destroyed || !headerView || headerView.destroyed) {
				view = this.view = this.Ext.create("BPMSoft.Container", {
					id: containerName,
					selectors: {wrapEl: "#" + containerName},
					classes: {
						wrapClassName: Ext.Array.merge(this.mainContainerWrapClasses || [],
							["modal-box-schema-module-content", "schema-wrap", "one-el"])
					},
					items: BPMSoft.deepClone(this.viewConfig[0])
				});
				headerView = this.headerView = this.Ext.create("BPMSoft.Container", {
					id: headerContainerName,
					selectors: {wrapEl: "#" + headerContainerName},
					classes: {
						wrapClassName: Ext.Array.merge(this.headerWrapClasses || [],
							["modal-box-schema-module-header", "schema-wrap", "one-el"])
					},
					items: BPMSoft.deepClone(this.viewConfig[1])
				});
				view.bind(viewModel);
				view.render(renderTo);
				headerView.bind(viewModel);
				headerView.render(headerRenderTo);
			} else {
				view.reRender(0, renderTo);
				headerView.reRender(0, headerRenderTo);
			}
			viewModel.headerRenderTo = headerRenderTo.id;
			viewModel.renderTo = renderTo.id;
			viewModel.onRender();
		},

		/**
		 * Closes modal window.
		 */
		destroyModule: function() {
			this.closeModalBox();
		}

	});

	return BPMSoft.ModalBoxSchemaModule;
});
