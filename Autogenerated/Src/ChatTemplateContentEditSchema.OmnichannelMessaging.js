define("ChatTemplateContentEditSchema", ["ChatTemplateContentEditSchemaResources", "MacrosUtilities",
	"css!EmailTemplatePageV2V2Styles", "css!EmailMLangContentEditSchemaStyles", "css!DetailModule"
], function(resources) {
	return {
		attributes: {

			/**
			 * Template body.
			 */
			"Body": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"dependencies": [{
					"columns": ["Body"],
					"methodName": "bodyTemplateChanged"
				}]
			}
		},
		mixins: {
			/**
			 * @class BPMSoft.MacrosUtilities
			 * Mixin for processing email macroses.
			 */
			MacrosUtilities: "BPMSoft.MacrosUtilities"
		},
		messages: {

			/**
			 * @message MacroSelected
			 * Handles macros selected event from macroses modalbox page.
			 */
			"MacroSelected": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "MainContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClassName": ["mlang-content-main-container"]
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ContentGridGroup",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": {
						"bindTo": "Resources.Strings.ModuleEditCaption"
					},
					"items": [],
					"tools": [],
					"controlConfig": {
						"collapsed": false,
						"classes": ["detail"]
					}
				},
				"parentName": "MainContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ContentGridLayout",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "ContentGridGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TemplateBodyContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24,
						"rowSpan": 1
					},
					"wrapClass": ["control-width-15 control-left"],
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				},
				"parentName": "ContentGridLayout",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "TemplateBodyWrap",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["control-wrap"],
					"items": []
				},
				"parentName": "TemplateBodyContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Body",
				"values": {
					"tag": "Body",
					"bindTo": "Body",
					"contentType": this.BPMSoft.ContentType.RICH_TEXT,
					"generator": "InlineTextEditViewGenerator.generate",
					"labelConfig": {
						"visible": true
					},
					"selectedText": {
						"bindTo": "SelectedText"
					},
					"markerValue": "Body",
					"controlConfig": {
						"macrobuttonclicked": {
							"bindTo": "onOpenMacrosPage"
						},
						"hasFullScreen": true,
						"inlineTextControlConfig": {
							"ckeditorDefaultConfig": {
								"allowedContent": true,
								"removeButtons": "JustifyCenter,JustifyLeft,JustifyRight,Font,FontSize,Link" +
									",FontSize,JustifyBlock,TextColor,bpmcrmemailtemplatelink," +
									"Indent,Outdent,bpmcrmsource,lineheight,letterspacing,lineheightpanel,"+
									"letterspacingpanel,indentpanel,NumberedList,BulletedList,Bold,Italic,Underline"
							}
						}
					},
				},
				"parentName": "TemplateBodyWrap",
				"propertyName": "items"
			}
		],
		methods: {

			/**
			 * Handles changes on body property.
			 */
			bodyTemplateChanged: function() {
				this.onControlValueChanged(this.$Body, "Body");
			},

			/**
			 * Opens selecting macroses.
			 */
			onOpenMacrosPage: function(macrosType) {
				switch (macrosType) {
					case "macros":
						this.openMacrosPage();
						break;
					case "column":
						this.openMacrosColumnsPage();
						break;
					default:
						throw Ext.create("BPMSoft.UnsupportedTypeException " + macrosType);
				}
			},

			/**
			 * Open entity structure explorer module for select column macros.
			 * @protected
			 */
			openMacrosColumnsPage: function() {
				BPMSoft.StructureExplorerUtilities.open({
					scope: this,
					handlerMethod: this.onMacrosColumnSelected,
					moduleConfig: {
						useBackwards: false,
						schemaName: "OmniChat"
					}
				});
			},

			/**
			 * Subscribes on events of sandbox.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				var macrosModuleId = this.getMacrosModuleId();
				this.sandbox.subscribe("MacroSelected", this.onGetMacros, this, [macrosModuleId]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModule#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.subscribeSandboxEvents();
			},

			/**
			 * Processes the macros selection.
			 * @protected
			 * @param {String} macros Macros.
			 */
			onGetMacros: function(macros) {
				this.set("SelectedText", macros);
			}
		}
	};
});
