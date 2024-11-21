define("CampaignSchemaDesigner", ["CampaignSchemaDesignerResources", "CampaignSchemaDesignerViewModel",
		"CampaignSchemaDesignerLeftToolbar", "CampaignSchemaDiagram", "CampaignDiagramComponent",
		"CampaignElementSchemaManager", "CampaignElementSchemaManagerEx"], function(resources) {
	Ext.define("BPMSoft.Designers.CampaignSchemaDesigner", {
		extend: "BPMSoft.ProcessSchemaDesigner",
		alternateClassName: "BPMSoft.CampaignSchemaDesigner",

		/**
		 * @inheritdoc BPMSoft.Designers.ProcessSchemaDesigner#designerViewModelClassName
		 * @overridden
		 */
		designerViewModelClassName: "BPMSoft.CampaignSchemaDesignerViewModel",

		/**
		 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesigner#propertiesEditModule
		 * @overridden
		 */
		propertiesEditModule: "CampaignSchemaElementPropertiesEdit",

		/**
		 * Name of left toolbar class.
		 * @protected
		 * @type {String}
		 */
		leftToolbarClassName: "BPMSoft.CampaignSchemaDesignerLeftToolbar",

		/**
		 * @inheritdoc BPMSoft.Designers.ProcessSchemaDesigner#leftToolbarHeaderButtonCaption
		 * @overridden
		 */
		leftToolbarHeaderButtonCaption: resources.localizableStrings.LeftToolbarCaption,

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
		 * @inheritdoc BPMSoft.Designers.ProcessSchemaDesigner#schemaDiagramClassName
		 * @override
		 */
		schemaDiagramClassName: "BPMSoft.CampaignSchemaDiagram",

		/**
		 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#getDesignerViewModelConfig
		 * @override
		 */
		getDesignerViewModelConfig: function() {
			var config = this.callParent(arguments);
			config.values.EntitySchemaUId = this.entitySchemaUId;
			config.values.EntityId = this.entityId;
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#getSchemaPropertiesButtonConfig
		 * @override
		 */
		getSchemaPropertiesButtonConfig: function() {
			var config = this.callParent(arguments);
			config.hint = resources.localizableStrings.PropertiesButtonHint;
			return config;
		},

		/**
		 * Preload process images that are used for dragging.
		 * @override
		 */
		preloadDragImages: BPMSoft.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#initDesignerManagers
		 * @override
		 */
		initDesignerManagers: function(callback, scope) {
			this.superclass.superclass.initDesignerManagers(function() {
				BPMSoft.chain(
					function(next) {
						BPMSoft.ProcessFlowElementSchemaManager.initialize(next, this);
					},
					function(next) {
						BPMSoft.CampaignElementSchemaManager.initialize(next, this);
					},
					function() {
						callback.call(scope);
					}
				);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.ProcessSchemaDesigner#createToolbarLeftContainer
		 * @override
		 */
		createToolbarLeftContainer: function() {
			var lczStrings = resources.localizableStrings;
			var elementCopyMenuItem = Ext.create("BPMSoft.MenuItem", {
				caption: lczStrings.CopyElementMenuItemCaption,
				onItemClick: this.onCopyElementClick.bind(this),
				tag: "CopyElement"
			});
			var elementPasteMenuItem = Ext.create("BPMSoft.MenuItem", {
				caption: lczStrings.PasteElementMenuItemCaption,
				onItemClick: this.onPasteElementClick.bind(this),
				tag: "PasteElement"
			});
			return {
				className: "BPMSoft.Container",
				id: this.id + "-toolbar-left",
				classes: {
					wrapClassName: ["toolbar-left"]
				},
				items: [
					{
						className: "BPMSoft.Button",
						id: this.id + "-save-btn",
						caption: lczStrings.SaveButtonCaption,
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						click: {bindTo: "save"},
						hint: lczStrings.SaveButtonHint
					},
					{
						className: "BPMSoft.Button",
						id: this.id + "-run-btn",
						caption: lczStrings.RunButtonCaption,
						style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
						click: {bindTo: "onRunProcessClick"},
						hint: lczStrings.RunButtonHint,
						visible: false
					},
					{
						className: "BPMSoft.Button",
						id: this.id + "-actions-btn",
						caption: lczStrings.ActionsButtonCaption,
						classes: {
							wrapperClass: ["t-btn-actions"]
						},
						menu: {
							items: [
								elementCopyMenuItem,
								elementPasteMenuItem
							]
						}
					}
				]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseProcessSchemaDesigner#createCaptionContainer
		 * @override
		 */
		createCaptionContainer: function() {
			var captionLabel = Ext.create("BPMSoft.Label", {
				id: this.id + "-caption",
				caption: {
					bindTo: "SchemaCaption"
				},
				markerValue: "SchemaCaption",
				classes: {
					labelClass: ["label-caption"]
				}
			});
			var captionContainer = Ext.create("BPMSoft.Container", {
				id: this.id + "-diagram-caption-ct",
				classes: {
					wrapClassName: ["control-width-15 ts-box-sizing diagram-caption-ct"]
				},
				items: [
					captionLabel
				]
			});
			return captionContainer;
		}
	});
	return BPMSoft.CampaignSchemaDesigner;
});
