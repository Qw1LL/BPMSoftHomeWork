define("DcmSchemaDesigner", ["ext-base", "DcmSchemaDesignerResources", "DcmSchemaDesignerViewModel",
		"DcmElementSchemaManager", "DcmStageContainer", "css!DcmSchemaDesigner", "SysDcmSettingsManager",
		"SysDcmSchemaInSettingsManager", "DcmSchemaManager"], function(Ext, resources) {
		/**
		 * @class BPMSoft.Designers.DcmSchemaDesigner
		 */
		Ext.define("BPMSoft.Designers.DcmSchemaDesigner", {

			extend: "BPMSoft.BaseProcessSchemaDesigner",

			alternateClassName: "BPMSoft.DcmSchemaDesigner",

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#designerViewModelClassName
			 * @overridden
			 */
			designerViewModelClassName: "BPMSoft.DcmSchemaDesignerViewModel",

			/**
			 * SysDcmSettingsId.
			 * @type {String}
			 */
			dcmSettingsId: null,

			/**
			 * Default package unique identifier.
			 * @type {String}
			 */
			packageUId: null,

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#propertiesEditModule
			 * @overridden
			 */
			propertiesEditModule: "DcmSchemaElementPropertiesEdit",

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#createDesignContainer
			 * @overridden
			 */
			getDesignerViewModelConfig: function() {
				var config = this.callParent(arguments);
				config.values.DcmSettingsId = this.dcmSettingsId;
				config.values.PackageUId = this.packageUId;
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#initDesignerManagers
			 * @overridden
			 */
			initDesignerManagers: function(callback, scope) {
				this.callParent([function() {
					BPMSoft.chain(
						function(next) {
							BPMSoft.DcmElementSchemaManager.initialize(next, this);
						},
						function(next) {
							BPMSoft.SysDcmSchemaInSettingsManager.initialize({}, next, this);
						},
						function() {
							BPMSoft.SysDcmSettingsManager.initialize({}, callback, scope);
						},
						this
					);
				}, this]);
			},

			/**
			 * Returns config for toolbar save button.
			 * @protected
			 * @return {Object}
			 */
			getSaveButtonConfig: function() {
				return {
					className: "BPMSoft.Button",
					id: this.id + "-save-btn",
					caption: resources.localizableStrings.SaveButtonCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					click: {bindTo: "save"},
					hint: resources.localizableStrings.SaveButtonHint,
					menu: {
						items: {
							bindTo: "SaveButtonMenuItems"
						}
					}
				};
			},

			/**
			 * Returns config for toolbar close button.
			 * @protected
			 * @return {Object}
			 */
			getCloseButtonConfig: function() {
				return {
					className: "BPMSoft.Button",
					id: this.id + "-close-btn",
					caption: resources.localizableStrings.CloseButtonCaption,
					click: {bindTo: "close"}
				};
			},

			/**
			 * Returns config for toolbar Actions button.
			 * @protected
			 * @return {Object}
			 */
			getActionsButtonConfig: function() {
				var coreResources = BPMSoft.Resources.SchemaDesigner;
				return {
					className: "BPMSoft.Button",
					id: this.id + "-actions-btn",
					caption: resources.localizableStrings.ActionsButtonCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					classes: {
						wrapperClass: ["t-btn-actions"]
					},
					menu: {
						items: [
							Ext.create("BPMSoft.MenuItem", {
								id: this.id + "-dcm-meta-data-mi",
								caption: coreResources.MetaDataMenuItemCaption,
								click: {bindTo: "onOpenMetaDataClick"}
							}),
							Ext.create("BPMSoft.MenuItem", {
								id: this.id + "-dcm-export-to-md",
								caption: coreResources.ExportMetaDataItemCaption,
								click: {bindTo: "onExportSchemaClick"}
							})
						]
					}
				};
			},

			/**
			 * Creates toolbar left container.
			 * @private
			 */
			createToolbarLeftContainer: function() {
				return {
					className: "BPMSoft.Container",
					id: this.id + "-toolbar-left",
					classes: {
						wrapClassName: [
							"toolbar-left",
							"load-dcm-properties-page-on-click"
						]
					},
					items: [
						this.getActionsButtonConfig()
					]
				};
			},

			createToolbarBottomContainer: function() {
				return {
					className: "BPMSoft.Container",
					id: this.id + "-toolbar-bottom",
					classes: {
						wrapClassName: [
							"toolbar-bottom",
							"load-dcm-properties-page-on-click"
						]
					},
					items: [
						this.getSaveButtonConfig(),
						this.getCloseButtonConfig()
					]
				};
			},

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesigner#getSchemaPropertiesButtonConfig
			 * @overridden
			 */
			getSchemaPropertiesButtonConfig: function() {
				return {
					id: this.id + "-process-properties-btn",
					classes: {
						wrapperClass: "dcm-schema-properties-button"
					},
					click: {
						bindTo: "onShowPropertyPage"
					},
					markerValue: "SchemaPropertiesButton",
					hint: resources.localizableStrings.CasePropertiesButtonHint,
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					imageConfig: resources.localizableImages.DcmSchemaPropertiesPageIcon
				};
			},

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesigner#getHelpButtonConfig
			 * @overridden
			 */
			getHelpButtonConfig: function() {
				return {
					id: this.id + "-help-btn",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					classes: {
						wrapperClass: "dcm-help-button"
					},
					click: {
						bindTo: "onHelpClick"
					},
					hint: BPMSoft.Resources.SchemaDesigner.HelpButtonHint,
					markerValue: "HelpButton",
					imageConfig: resources.localizableImages.DcmHelpIcon
				};
			},

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesigner#getESNFeedButtonConfig
			 * @overridden
			 */
			getESNFeedButtonConfig: function() {
				return {
					id: this.id + "-feed-btn",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					classes: {
						wrapperClass: "dcm-feed-button"
					},
					click: {
						bindTo: "onESNFeedClick"
					},
					hint: BPMSoft.Resources.SchemaDesigner.FeedButtonHint,
					markerValue: "FeedButton",
					imageConfig: resources.localizableImages.DcmFeedIcon
				};
			},

			/**
			 * Creates toolbar right container.
			 * @private
			 */
			createToolbarRightContainer: function() {
				var propertiesButton = Ext.create("BPMSoft.Button", this.getSchemaPropertiesButtonConfig());
				var helpButton = Ext.create("BPMSoft.Button", this.getHelpButtonConfig());
				var items = [
					propertiesButton,
					helpButton
				];
				if (BPMSoft.Features.getIsEnabled("ProcessESN")) {
					var feedButton = Ext.create("BPMSoft.Button", this.getESNFeedButtonConfig());
					items.splice(0, 0, feedButton);
				}
				return {
					className: "BPMSoft.Container",
					id: this.id + "-toolbar-right",
					classes: {
						wrapClassName: [
							"toolbar-right",
							"load-dcm-properties-page-on-click"
						]
					},
					items: items
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#createToolbar
			 * @overridden
			 */
			createToolbarContainer: function() {
				var toolbarContainer = this.callParent(arguments);
				var leftToolbar = this.createToolbarLeftContainer();
				var rightToolbar = this.createToolbarRightContainer();
				var bootomToolbar = this.createToolbarBottomContainer();
				toolbarContainer.add(leftToolbar);
				toolbarContainer.add(rightToolbar);
				toolbarContainer.add(bootomToolbar);
				return toolbarContainer;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#createDesignContainer
			 * @overridden
			 */
			createDesignContainer: function() {
				var designMainContainer = this.callParent(arguments);
				var dcmStageContainer = this.createDcmStageContainer();
				this.diagramContainer.add(dcmStageContainer);
				return designMainContainer;
			},

			/**
			 * Creates DCM stage container.
			 * @private
			 * @return {BPMSoft.DcmStageContainer}
			 */
			createDcmStageContainer: function() {
				return Ext.create("BPMSoft.DcmStageContainer", {
					id: this.id,
					viewModelItems: {bindTo: "ViewModelItems"},
					reorderableIndex: {bindTo: "ReorderableIndex"},
					classes: {
						wrapClassName: [
							"dcm-stage-container",
							"load-dcm-properties-page-on-click"
						]
					},
					dropGroupName: "dcm-stages",
					onDragEnter: {bindTo: "onDragOver"},
					onDragOver: {bindTo: "onDragOver"},
					onDragDrop: {bindTo: "onDragDrop"},
					onDragOut: {bindTo: "onDragOut"},
					onElementSelected: {bindTo: "onItemSelected"},
					onElementRemoveButtonClick: {bindTo: "onElementRemoveButtonClick"},
					onElementDblClick: {bindTo: "onElementDblClick"},
					onStageDblClick: {bindTo: "onStageDblClick"},
					onStageSelected: {bindTo: "onItemSelected"},
					elementDragDrop: {bindTo: "onItemSelected"}
				});
			}

		});
		return BPMSoft.Designers.DcmSchemaDesigner;
	}
);

