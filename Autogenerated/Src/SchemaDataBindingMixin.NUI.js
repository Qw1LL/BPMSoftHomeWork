define("SchemaDataBindingMixin", ["SchemaDataBindingMixinResources", "ServiceHelper", "RightUtilities", "ModalBox"],
	function(resources, ServiceHelper, RightUtilities, ModalBox) {
		/**
		 * @class BPMSoft.configuration.mixins.SchemaDataBindingMixin
		 */
		Ext.define("BPMSoft.configuration.mixins.SchemaDataBindingMixin", {
			alternateClassName: "BPMSoft.SchemaDataBindingMixin",

			// region Methods: Private

			_getActiveRowsId: function() {
				var activeRow = this.getActiveRow();
				var activeRowId = activeRow && activeRow.$Id;
				return activeRowId ? [activeRowId] : [];
			},

			_getBindDataConfig: function(sysPackageUId) {
				var config = {
					"schemaName": this.entitySchemaName,
					"sysPackageUId": sysPackageUId
				};
				var selectedRecordsConfig = this.getSelectedRecordsConfig();
				if (this.get("MultiSelect") && !this.Ext.isEmpty(selectedRecordsConfig.filtersConfig)) {
					config.filterConfig = selectedRecordsConfig.filtersConfig;
				} else {
					config.recordIds = this.get("MultiSelect") ? selectedRecordsConfig.selectedItems : this._getActiveRowsId();
				}
				return config;
			},

			getBindDataActionCaption: function() {
				return resources.localizableStrings.DataBindingActionCaption;
			},

			_getSelectedPackageModalBoxConfig: function(modalBoxContainer) {
				return {
					moduleName: "BaseSchemaModuleV2",
					containerId: modalBoxContainer,
					instanceConfig: {
						schemaName: "PackageSelectionModalBoxSchema",
						useHistoryState: false,
						generateViewContainerId: false,
						isSchemaConfigInitialized: true
					}
				};
			},

			_subscribeSelectPackageMessage: function(callback, scope) {
				const moduleId = this.sandbox.id + "_module_BaseSchemaModuleV2";
				this.sandbox.subscribe("SelectedPackageResult", function(result) {
					var sysPackage = result && result.SysPackage;
					if (sysPackage && sysPackage.UId) {
						callback.call(scope, sysPackage.UId);
					}
				}, scope, [moduleId]);
			},

			/**
			 * Return bind data action menu item.
			 * @protected
			 */
			getDataBindingButtonMenuConfig: function() {
				return {
					"Click": {"bindTo": "showSelectedPackageModalBoxDialog"},
					"Caption": this.getBindDataActionCaption(),
					"Enabled": {"bindTo": "isAnySelected"},
					"Visible": {"bindTo": "isDataBindingMenuItemVisible"},
					"IsEnabledForSelectedAll": true
				};
			},

			/**
			 * Return bind data action menu item.
			 * @protected
			 * @param {String} methodName Method name.
			 * @param {Object} response Response.
			 */
			dataBindingResultCallback: function(methodName, response) {
				var errorMessage = response && response[methodName + "Result"].errorInfo;
				if (!this.Ext.isEmpty(errorMessage)) {
					this.BPMSoft.showInformation(errorMessage.message);
					return;
				}
				this.BPMSoft.showInformation(resources.localizableStrings.SuccessMessage);
			},

			/**
			 * Call SchemaDataBindingService for selected rows.
			 * @protected
			 * @param {Guid} sysPackageUId Package UId.
			 */
			runDataBindingService: function(sysPackageUId) {
				var config = this._getBindDataConfig(sysPackageUId);
				if (config && this.Ext.isEmpty(config.recordIds) && this.Ext.isEmpty(config.filterConfig)) {
					return;
				}

				var methodName = this.Ext.isEmpty(config.filterConfig) ? "GenerateBindings" : "GenerateBindingsByFilter";
				ServiceHelper.callService("SchemaDataBindingService",
					methodName,
					this.dataBindingResultCallback.bind(this, methodName),
					config,
					this
				);
			},

			/**
			 * Get CanManageSolution operation value.
			 * @protected
			 */
			initCanManageSolution: function() {
				RightUtilities.checkCanExecuteOperation({
					operation: "CanManageSolution"
				}, this.initCanManageSolutionCallback, this);
			},

			/**
			 * Set CanManageSolution operation value.
			 * @protected
			 * @param {Boolean} value Value.
			 */
			initCanManageSolutionCallback: function(value) {
				this.$CanManageSolution = value;
			},

			// endregion

			// region Methods: Public

			/**
			 * Shows dialog to select package for data binding.
			 */
			showSelectedPackageModalBoxDialog: function() {
				var modalBoxContainer = ModalBox.show({
					widthPixels: 420,
					heightPixels: 245
				});
				this._subscribeSelectPackageMessage(this.runDataBindingService, this);
				var selectedPackageConfig = this._getSelectedPackageModalBoxConfig(modalBoxContainer);
				this.loadModule(selectedPackageConfig);
			},

			/**
			 * Check whether data binding menu item should be displayed.
			 * @return {boolean}
			 */
			isDataBindingMenuItemVisible: function() {
				return this.$CanManageSolution;
			},

			/**
			 * Initialization of all needed attributes.
			 */
			initializeDataBinding: function() {
				this.initCanManageSolution();
			}

			// endregion

		});
	});
