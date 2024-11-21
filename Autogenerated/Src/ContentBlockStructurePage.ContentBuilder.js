define("ContentBlockStructurePage", ["ContentSectionItemViewModel", "ContentMjHeroItemViewModel",
		"css!ContentItemStylesPageCSS"],
	function() {
		return {
			modules: {
				ContentItemStylesPageModule: {
					moduleId: "ContentItemStylesPageModule",
					moduleName: "ConfigurationModuleV2",
					config: {
						schemaName: "ContentItemStylesPage",
						isSchemaConfigInitialized: true,
						useHistoryState: false,
						parameters: {
							viewModelConfig: {
								Config: {
									attributeValue: "Config"
								},
								PropertyName: "Styles"
							}
						}
					}
				},
			},
			
			properties: {
				/**
				 * @inheritdoc BaseContentItemStructurePage#itemViewModelNames
				 * @override
				 */
				itemViewModelNames: {
					section: "BPMSoft.ContentSectionItemViewModel",
					mjhero: "BPMSoft.ContentMjHeroItemViewModel"
				},
				/**
				 * @inheritdoc BaseContentItemStructurePage#sandboxId
				 * @override
				 */
				sandboxId: "ContentBlockStructurePage"
			},
			methods: {

				/**
				 * Handler for add section item action.
				 * @protected
				 */
				onAddSectionItemClick: function() {
					this.addStructureItem("section");
				},

				/**
				 * Handler for add hero item action.
				 * @protected
				 */
				onAddHeroItemClick: function() {
					this.addStructureItem("mjhero");
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "AddSectionItemButton",
					"parentName": "ActionsStructureContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"caption": "$Resources.Strings.AddStructureItemBtnCaption",
						"imageConfig": "$Resources.Images.AddButtonIcon",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": "$onAddSectionItemClick",
						"enabled": "$CanAddStructureItem",
						"classes": {
							wrapperClass: ["structure-button-control"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AddHeroItemButton",
					"parentName": "ActionsStructureContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"imageConfig": "$Resources.Images.AddButtonIcon",
						"caption": "$Resources.Strings.AddHeroButtonCaption",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": "$onAddHeroItemClick",
						"enabled": "$CanAddStructureItem",
						"classes": {
							wrapperClass: ["structure-button-control"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ContentItemStylesPageModule",
					"parentName": "BlockStylesContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE
					}
				}
			]
		};
	});
