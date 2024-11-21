/**
 */
define("CampaignSchemaDesignerNew", ["CampaignSchemaDesignerNewResources", "CampaignSchemaDesignerViewModelNew",
		"CampaignElementSchemaManagerEx", "CampaignDiagramElementManager", "css!CampaignSchemaDesignerNew"],
	function(resources) {
		Ext.define("BPMSoft.Designers.CampaignSchemaDesignerNew", {
			extend: "BPMSoft.Designers.ProcessSchemaDesignerNew",
			alternateClassName: "BPMSoft.CampaignSchemaDesignerNew",

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#schemaDiagramClassName
			 * @override
			 */
			schemaDiagramClassName: "BPMSoft.CampaignDiagramComponent",

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#designerViewModelClassName
			 * @override
			 */
			designerViewModelClassName: "BPMSoft.CampaignSchemaDesignerViewModelNew",

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesigner#propertiesEditModule
			 * @overridden
			 */
			propertiesEditModule: "CampaignSchemaElementPropertiesEdit",

			/**
			 * Default campaign entity schema unique identifier.
			 * @type {String}
			 */
			entitySchemaUId: null,

			/**
			 * Default campaign unique identifier.
			 * @type {String}
			 */
			entityId: null,

			/**
			 * Flag to indicate diagram readonly mode.
			 * @type {Boolean}
			 */
			readOnly: false,

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#cancelButtonToBottomContainer
			 * @override
			 */
			cancelButtonToBottomContainer: true,

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#saveButtonToBottomContainer
			 * @override
			 */
			saveButtonToBottomContainer: true,

			/**
			 * @private
			 */
			_onHighlightConnection: function(event) {
				var connectionId = event.id;
				var state = event.state;
				this.diagram.highlightConnection(connectionId, state);
			},

			/**
			 * @private
			 */
			_onElementDescriptionChanged: function(event) {
				var elementId = event.id;
				var description = event.description;
				this.diagram.updateDescription(elementId, description);
			},

			/**
			 * @private
			 */
			_addImportTemplateMenuItem: function(menuItems) {
				menuItems.push(Ext.create("BPMSoft.MenuItem", {
					id: this.id + "-action-item-import-template",
					caption: "$getImportFromTemplateCaption",
					click: "$onImportTemplateClick",
					markerValue: "import-campaign-template"
				}));
			},

			/**
			 * @private
			 */
			_addSaveTemplateMenuItem: function(menuItems) {
				menuItems.push(Ext.create("BPMSoft.MenuItem", {
					id: this.id + "-action-item-save-template",
					caption: "$getSaveAsTemplateCaption",
					click: "$saveAsTemplate",
					markerValue: "save-campaign-template",
					tag: this.entityId
				}));
			},

			/**
			 * @private
			 */
			_addRestoreVersionMenuItem: function(menuItems) {
				menuItems.push(Ext.create("BPMSoft.MenuItem", {
					id: this.id + "-action-item-restore-version",
					caption: "$getManageCampaignVersionCaption",
					click: {bindTo: "onManageCampaignVersion"}
				}));
			},

			/**
			 * Returns list of actual action menu items to display.
			 * @protected
			 * @returns {Array}
			 */
			getActionMenuItems: function() {
				var menuItems = [];
				if (BPMSoft.Features.getIsEnabled("CampaignTemplate")) {
					this._addImportTemplateMenuItem(menuItems);
					this._addSaveTemplateMenuItem(menuItems);
				}
				if (BPMSoft.Features.getIsEnabled("CampaignVersionManaging")) {
					this._addRestoreVersionMenuItem(menuItems);
				}
				return menuItems;
			},

			/**
			 * Returns base description toggle button config.
			 * @protected
			 * @returns {Object}
			 */
			getBaseDescriptionToggleButtonConfig: function() {
				return {
					classes: {
						wrapperClass: "t-btn-image margin-right-0px t-btn-image-left description-toggle-btn"
					},
					click: { bindTo: "onToggleDescriptions" },
					imageConfig: resources.localizableImages.ToggleDescriptionsButtonHint,
					hint: resources.localizableStrings.ToggleDescriptionsButtonHint,
					markerValue: "ToggleDescriptionsButton"
				};
			},


			/**
			 * Returns description toggle button config.
			 * @protected
			 * @returns {Object}
			 */
			getDescriptionToggleButtonConfig: function() {
				var config = this.getBaseDescriptionToggleButtonConfig();
				return Ext.apply(config, {
					id: this.id + "-description-toggle-btn",
					visible: { bindTo: "ShowDescriptions" }
				});
			},

			/**
			 * Returns base description untoggle button config.
			 * @protected
			 * @returns {Object}
			 */
			getDescriptionUntoggleButtonConfig: function() {
				var config = this.getBaseDescriptionToggleButtonConfig();
				config.classes.wrapperClass += " untoggle";
				return Ext.apply(config, {
					id: this.id + "-description-untoggle-btn",
					visible: {
						bindTo: "ShowDescriptions",
						bindConfig: {"converter": "invertBooleanValue"}
					}
				});
			},

			/**
			 * Extends toolbox with description toggle buttons.
			 * @protected
			 */
			addDescriptionToggleButton: function(toolbar) {
				if (!BPMSoft.Features.getIsEnabled("CampaignConditionalTransitionDescription")) {
					return;
				}
				var toggleBtn = Ext.create("BPMSoft.Button", this.getDescriptionToggleButtonConfig());
				var untoggleBtn = Ext.create("BPMSoft.Button", this.getDescriptionUntoggleButtonConfig());
				var index = toolbar.items.findIndex(function(el) {
					return el.markerValue === "SchemaPropertiesButton"
				});
				toolbar.items.splice(index, 0, toggleBtn);
				toolbar.items.splice(index, 0, untoggleBtn);
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#getDiagramConfig
			 * @override
			 */
			getDiagramConfig: function() {
				const baseConfig = this.callParent(arguments);
				if (baseConfig.importData || baseConfig.importError || baseConfig.diagramImportStart
					|| baseConfig.updateStudioFreeDiagramUrl) {
					delete baseConfig.importError;
					delete baseConfig.importData;
					delete baseConfig.diagramImportStart;
					delete baseConfig.updateStudioFreeDiagramUrl;
				}
				return Ext.apply(baseConfig, {
					readOnly: this.readOnly
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#getDesignerViewModelConfig
			 * @override
			 */
			getDesignerViewModelConfig: function() {
				var config = this.callParent(arguments);
				config.values.EntitySchemaUId = this.entitySchemaUId;
				config.values.EntityId = this.entityId;
				config.values.IsReadOnly = this.readOnly;
				config.values.ShowDescriptions = true;
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#getSchemaPropertiesButtonConfig
			 * @override
			 */
			getSchemaPropertiesButtonConfig: function() {
				var config = this.callParent(arguments);
				Ext.apply(config, {
					hint: resources.localizableStrings.PropertiesButtonHint
				});
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#initDesignerManagers
			 * @override
			 */
			initDesignerManagers: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						BPMSoft.ProcessFlowElementSchemaManager.initialize(next, this);
					},
					function(next) {
						BPMSoft.CampaignElementSchemaManager.initialize(next, this);
					},
					function(next) {
						BPMSoft.CampaignDiagramElementManager.initialize(next, this);
					},
					function() {
						callback.call(scope);
					},
					this
				);
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#createToolbarLeftContainer
			 * @override
			 */
			createToolbarLeftContainer: function() {
				var container = this.callParent(arguments);
				var actionsButtonId = Ext.String.format("{0}-actions-btn", this.id);
				var menuItems = this.getActionMenuItems();
				if (menuItems.length > 0) {
					var actionBtn = container.items.find(function(el) {
						return el.id === actionsButtonId;
					}, this);
					actionBtn.menu.items = menuItems;
					return container;
				}
				container.items = Ext.Array.filter(container.items, function(el) {
					if(el.id === "schema-designer-save-btn") {
						el.style = "orange"
					}
					return el.id !== actionsButtonId;
				}, this);
				return container;
			},
			
			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#createToolbarRightContainer
			 * @override
			 */
			createToolbarRightContainer: function () {
				var rightToolbar = this.callParent(arguments);
				this.addDescriptionToggleButton(rightToolbar);
				return rightToolbar;
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#createToolbarRightContainer
			 * @override
			 */
			createToolbarRightContainer: function() {
				var rightToolbar = this.callParent(arguments);
				this.addDescriptionToggleButton(rightToolbar);
				return rightToolbar;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#createCaptionContainer
			 * @override
			 */
			createCaptionContainer: function() {
				var captionLabel = Ext.create("BPMSoft.Label", {
					id: this.id + "-caption",
					caption: "$SchemaCaption",
					markerValue: "SchemaCaption",
					classes: {
						labelClass: ["label-caption"]
					}
				});
				return Ext.create("BPMSoft.Container", {
					id: this.id + "-diagram-caption-ct",
					classes: {
						wrapClassName: ["control-width-15 ts-box-sizing diagram-caption-ct"]
					},
					items: [captionLabel]
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#renderDesignContainer
			 * @override
			 */
			renderDesignContainer: function() {
				this.callParent(arguments);
				this.designerViewModel.on("highlightConnection", this._onHighlightConnection, this);
				this.designerViewModel.on("elementDescriptionChange", this._onElementDescriptionChanged, this);
				this.designerViewModel.on("change:ShowDescriptions", this.onShowDescriptionsChanged, this);
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#getRunButton
			 * @override
			 */
			getRunButton: function() {
				return {
					visible: false
				};
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesigner#getSaveButton
			 * @override
			 */
			getSaveButton: function() {
				const saveButton = this.callParent(arguments);
				saveButton.style = BPMSoft.controls.ButtonEnums.style.ORANGE;
				
				return saveButton;
			},

			/**
			 * Handler on show description toggle state change event.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} model Changed model.
			 * @param {Boolean} value Toggle state.
			 */
			onShowDescriptionsChanged: function(model, value) {
				this.diagram.useExtendedMode = Boolean(value);
				var flows = this.designerViewModel.$Items.filterByFn(function(item) {
					return (item instanceof BPMSoft.ProcessCampaignConditionalSequenceFlowSchema
							|| item instanceof BPMSoft.ProcessCampaignSequenceFlowSchema)
						&& item.description;
				}, this);
				BPMSoft.each(flows, function(flow) {
					this.diagram.updateDescription(flow.uId, value ? flow.description.toString() : "");
				}, this);
			}
		});
	});
