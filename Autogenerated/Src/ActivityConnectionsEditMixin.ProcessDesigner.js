define("ActivityConnectionsEditMixin", ["ActivityConnectionsEditMixinResources", "Activity",
		"ProcessSchemaUserTaskUtilities", "ProcessSchemaParameterViewConfig", "ProcessLookupPageMixin",
		"MappingEditMixin"],
	function(resources, activityEntitySchema, userTaskUtilities) {
		/**
		 * @class BPMSoft.configuration.mixins.ActivityConnectionsEditMixin
		 * Process schema parameters edit mixin.
		 */
		Ext.define("BPMSoft.configuration.mixins.ActivityConnectionsEditMixin", {
			alternateClassName: "BPMSoft.ActivityConnectionsEditMixin",

			mixins: {
				processLookupPageMixin: "BPMSoft.ProcessLookupPageMixin",
				mappingEditMixin: "BPMSoft.MappingEditMixin"
			},

			//region Methods: Private

			/**
			 * Returns data connections for ProcessLookupPage.
			 * @private
			 * @return {BPMSoft.Collection} Data connections.
			 */
			_getDataConnections: function() {
				const entityConnections = Ext.create("BPMSoft.Collection");
				const viewModels = this.get("ActivityConnectionViewModels");
				viewModels.each(function(viewModel) {
					const id = viewModel.get("Id");
					const caption = viewModel.get("Caption");
					const selected = viewModel.get("Visible");
					entityConnections.add(id, {
						id: id,
						caption: caption,
						selected: selected
					});
				}, this);
				return entityConnections;
			},

			/**
			 * Shows or hides the controls for editing connections parameter.
			 * @private
			 * @param {Array} items Array identifiers selected connections.
			 */
			_showActivityConnectionControls: function(items) {
				const viewModels = this.get("ActivityConnectionViewModels");
				viewModels.each(function(viewModel) {
					const id = viewModel.get("Id");
					const visible = items.indexOf(id) > -1;
					if (!visible) {
						viewModel.clearParameterValue();
					}
					viewModel.set("Visible", visible);
				}, this);
			},

			/**
			 * Adds subscriptions  on SetParametersInfo.
			 * @private
			 */
			_addSubscriptionsToParametersInfo: function() {
				const schemaName = "ProcessLookupPage";
				const pageId = this.sandbox.id + schemaName;
				this.sandbox.subscribe("SetParametersInfo", function(parametersInfo) {
					if (parametersInfo) {
						this._showActivityConnectionControls(parametersInfo.selectedRows);
					}
					this.closeSchemaColumnSelectPage();
				}, this, [pageId]);
			},

			/**
			 * @private
			 */
			_initActivityUserTaskStore: function() {
				const storeConfig = {
					"levelName": "ActivityConnections",
					"type": "BPMSoft.MemoryStore",
					"isCache": false
				};
				if (Ext.isEmpty(BPMSoft.ActivityConnectionsStore)) {
					BPMSoft.StoreManager.registerStore(storeConfig);
				}
			},

			/**
			 * @private
			 */
			_createDynamicParameter: function(connection, column, element) {
				const parameter = Ext.create("BPMSoft.DynamicProcessSchemaParameter", {
					uId: connection.id,
					caption: new BPMSoft.LocalizableString(connection.caption),
					createdInSchemaUId: element.parentSchema.uId,
					modifiedInSchemaUId: element.parentSchema.uId,
					tag: "ActivityConnection",
					name: connection.name,
					dataValueType: column.dataValueType,
					sourceValue: { source: BPMSoft.ProcessSchemaParameterValueSource.None }
				});
				if (column.isLookup) {
					const managerItem =
						BPMSoft.EntitySchemaManager.findRootSchemaItemByName(column.referenceSchemaName);
					parameter.referenceSchemaUId = managerItem.uId;
					parameter.sourceValue.referenceSchemaUId = managerItem.uId;
				}
				parameter.processFlowElementSchema = element;
				return parameter;
			},

			/**
			 * @private
			 */
			_findActivityConnectionParameter: function(element, connection) {
				let parameter = element.findParameterByName(connection.name) ||
					element.findParameterByUId(connection.id);
				if (parameter) {
					return parameter;
				}
				const column = activityEntitySchema.findColumnByUId(connection.id);
				if (column) {
					parameter = this._createDynamicParameter(connection, column, element);
					element.parameters.add(parameter.uId, parameter);
					return parameter;
				}
				return null;
			},

			/**
			 * @private
			 */
			_getShowConnectionControl: function(parameter, processElementUId) {
				const value = parameter.getValue();
				let show = !Ext.isEmpty(value);
				const visibleControls = this._getActivityConnectionsFromStore(processElementUId) || [];
				show = show || (visibleControls.indexOf(parameter.name) > -1);
				return show;
			},

			/**
			 * @private
			 */
			_onHideParameter: function() {
				this.set("Visible", false);
				this.clearParameterValue();
			},

			/**
			 * @private
			 */
			 _findReferenceSchemaUId: function(parameter) {
				let initialReferenceSchemaUId;
				const initialConfig = parameter.initialConfig;
				if (initialConfig) {
					const sourceValue = initialConfig.sourceValue;
					const sourceReferenceSchemaUId = sourceValue ? sourceValue.referenceSchemaUId : null;
					initialReferenceSchemaUId = initialConfig.referenceSchemaUId || sourceReferenceSchemaUId;
				}
				return initialReferenceSchemaUId;
			},

			/**
			 * @private
			 */
			_getConnectionParameterViewModelConfig: function(parameter) {
				const name = parameter.name;
				const dataValueType = parameter.dataValueType;
				const parameterInvokerUId = this.get("ProcessElement") instanceof BPMSoft.ProcessSchema
					? parameter.uId
					: this.getInvokerUId();
				const value = parameter.value || parameter.getMappingValue();
				const toolsButtonMenu = Ext.create("BPMSoft.BaseViewModelCollection", {
					items: {}
				});
				const element = this.get("ProcessElement");
				const parentSchema = element && element.parentSchema;
				const entitySchema = parentSchema && parentSchema.entitySchema;
				return {
					Id: name,
					UId: parameter.uId,
					Name: name,
					Caption: parameter.getDisplayValue(),
					DataValueType: dataValueType,
					IsRequired: parameter.isRequired,
					ReferenceSchemaUId: parameter.referenceSchemaUId,
					InitialReferenceSchemaUId: this._findReferenceSchemaUId(parameter),
					Value: value,
					ParameterEditToolsButtonMenu: toolsButtonMenu,
					Enabled: false,
					packageUId: this.getPackageUId(),
					InvokerUId: parameterInvokerUId,
					Parameters: this.get("ActivityConnectionViewModels"),
					ProcessElement: element,
					ItemProperties: Ext.create("BPMSoft.ProcessSchemaParameterCollection"),
					EntitySchema: entitySchema,
					Direction: BPMSoft.ProcessSchemaParameterDirection.VARIABLE,
					AllowedCollectionItemNestingLevel: 1,
					CanAssignSourceValue: true,
					HasCollectionMapping: false
				};
			},

			/**
			 * Creates connection parameter ViewModel.
			 * @private
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Parameter.
			 * @param {Boolean} visible If 'true' is visible control.
			 * @return {BPMSoft.ProcessSchemaParameterViewModel}
			 */
			_createConnectionParameterViewModel: function(parameter, visible) {
				const parameterViewModelConfig = this._getConnectionParameterViewModelConfig(parameter);
				const viewModel = Ext.create("BPMSoft.ProcessSchemaParameterViewModel", {
					values: parameterViewModelConfig,
					sandbox: this.sandbox,
					methods: {
						onItemFocused: this.onItemFocused
					}
				});
				viewModel.on("change", function(config) {
					if (config) {
						this.set(config.propertyName, config.propertyValue);
					}
				}, this);
				const toolsButtonMenu = viewModel.get("ParameterEditToolsButtonMenu");
				toolsButtonMenu.clear();
				const deleteMenuItem = this._getDeleteMenuItem(parameter.name);
				toolsButtonMenu.add(deleteMenuItem);
				viewModel.set("Visible", visible, { silent: true });
				const elementId = Ext.String.format("{0}-{1}", viewModel.get("Name"), BPMSoft.generateGUID());
				viewModel.set("ElementId", elementId);
				viewModel.onParameterDeleteClick = this._onHideParameter;
				viewModel.validate();
				return viewModel;
			},

			/**
			 * @private
			 */
			_getDeleteMenuItem: function(parameterName) {
				const config = {
					caption: resources.localizableStrings.DeleteMenuItemCaption,
					tag: parameterName,
					click: { "bindTo": "onParameterDeleteClick" }
				};
				return Ext.create("BPMSoft.BaseViewModel", {
					values: Ext.apply({}, config, {
						Id: BPMSoft.generateGUID(),
						Tag: config.tag,
						Caption: config.caption,
						Click: config.click,
						MarkerValue: config.caption,
						ImageConfig: config.imageConfig,
						Items: config.items
					})
				});
			},

			/**
			 * Adds view model for editing connections parameter.
			 * @private
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 * @param {Boolean} visible If 'true' is visible control.
			 */
			_addConnectionParameterViewModel: function(parameter, visible) {
				const viewModels = this.get("ActivityConnectionViewModels");
				const viewModel = this._createConnectionParameterViewModel(parameter, visible);
				viewModels.add(parameter.name, viewModel);
			},

			/**
			 * Returns array activity connections from storage.
			 * @private
			 * @param {Guid} processElementUId Unique identifier of the process element.
			 * @return {Array}
			 */
			_getActivityConnectionsFromStore: function(processElementUId) {
				return BPMSoft.ActivityConnectionsStore.getItem(processElementUId);
			},

			/**
			 * Shows default controls for editing connections parameter.
			 * @private
			 */
			_showDefaultConnectionControls: function() {
				this._showConnectionControl("Account");
				this._showConnectionControl("Contact");
			},

			/**
			 * Shows control for editing connections parameter.
			 * @private
			 */
			_showConnectionControl: function(connectionColumnName) {
				const activityConnectionViewModels = this.get("ActivityConnectionViewModels");
				const viewModel = activityConnectionViewModels.find(connectionColumnName);
				if (viewModel) {
					viewModel.set("Visible", true);
				} else {
					console.error(`EntityConnection table has ho record for Activity object with ${connectionColumnName} column`);
				}
			},

			/**
			 * Saves activity connections to storage.
			 * @private
			 * @param {Guid} processElementUId Unique identifier of the process element.
			 * @param {Array} activityConnections Activity connections.
			 */
			_setActivityConnectionsToStore: function(processElementUId, activityConnections) {
				BPMSoft.ActivityConnectionsStore.setItem(processElementUId, activityConnections);
			},

			/**
			 * Returns label configuration for connection parameter.
			 * @private
			 */
			_getConnectionParameterLabelConfig: function() {
				return {
					id: "Caption",
					className: "BPMSoft.Label",
					caption: { bindTo: "Caption" },
					isRequired: { bindTo: "IsRequired" },
					classes: { labelClass: ["t-label-proc", "t-label-proc-param"] }
				};
			},

			//endregion

			//region Methods: Protected

			/**
			 * Generates a configuration connection parameter representation element.
			 * @protected
			 * @param {Object} parameterConfig Link to the configuration element in the Container List.
			 */
			getConnectionParameterViewConfig: function(parameterConfig) {
				const container = BPMSoft.ProcessSchemaParameterViewConfig.getContainerConfig.bind(
					BPMSoft.ProcessSchemaParameterViewConfig);
				parameterConfig.config = container("item", [], [
						container("item-view", ["parameter-ct"], [
							container("ParameterValueContainer", ["parameter-value-ct"], [
								container("ToolsContainer", ["tools-container-wrapClass"], [
									container("LabelWrap", ["label-container-wrapClass"], [
										this._getConnectionParameterLabelConfig()
									]),
									container("ToolsButtonWrap", ["tools-button-container-wrapClass"],
										[this.getParameterToolsButtonConfig("ConnectionParameterEditToolsButton")])
								]),
								this.getParameterMappingEditConfig()
							])
						], { bindTo: "Visible" })
					]
				);
			},

			/**
			 * Initializes the mixin.
			 * @protected
			 * @param {Boolean} shouldInitEntityConnections Flag, determines whether an entity connections should be
			 * initialized or not.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Scope object.
			 */
			init: function(shouldInitEntityConnections, callback, scope) {
				BPMSoft.EntitySchemaManager.initialize(function() {
					userTaskUtilities.loadEntityConnectionColumns(function(entityConnections) {
						this.set("EntityConnections", entityConnections);
						if (shouldInitEntityConnections) {
							this._initEntityConnections();
						}
						Ext.callback(callback, scope);
					}, this);
				}, this);
			},

			/**
			 * Creates controls for editing connections parameter.
			 * @protected
			 */
			onInitActivityConnection: function() {
				const entityConnections = this.get("EntityConnections");
				const processElement = this.get("ProcessElement");
				let shownCount = 0;
				entityConnections.each(function(item) {
					const parameter = this._findActivityConnectionParameter(processElement, item);
					if (parameter) {
						const visible = this._getShowConnectionControl(parameter, processElement.uId);
						if (visible) {
							shownCount++;
						}
						this._addConnectionParameterViewModel(parameter, visible);
					}
				}, this);
				const visibleControls = this._getActivityConnectionsFromStore(processElement.uId);
				if (shownCount === 0 && !visibleControls) {
					this._showDefaultConnectionControls();
				}
			},

			/**
			 * @private
			 */
			_initEntityConnections: function() {
				const viewModels = this.get("ActivityConnectionViewModels");
				viewModels.clear();
				this._initActivityUserTaskStore();
				this.onInitActivityConnection();
			},

			/**
			 * Save connection parameters.
			 * @protected
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 */
			saveActivityConnectionParameters: function(element) {
				const viewModels = this.get("ActivityConnectionViewModels");
				const elementParameters = element.parameters;
				const visibleControls = [];
				viewModels.each(function(viewModel) {
					const uId = viewModel.get("UId");
					const parameter = elementParameters.get(uId);
					const parameterValue = viewModel.get("Value");
					if (viewModel.get("Visible")) {
						visibleControls.push(parameter.name);
					}
					parameter.setMappingValue(parameterValue);
				}, this);
				this._setActivityConnectionsToStore(element.uId, visibleControls);
			},

			/**
			 * Open lookup activity connection window handler.
			 * @protected
			 */
			openLookupActivityConnectionWindow: function() {
				const entityColumns = this._getDataConnections();
				this._addSubscriptionsToParametersInfo();
				this.showEntitySchemaColumnSelectPage(entityColumns);
			},

			/**
			 * Returns flag that indicates if activity task is visible.
			 * @protected
			 * @return {boolean}
			 */
			getIsActivityTaskVisible: function() {
				return true;
			}

			//endregion

		});

	});
