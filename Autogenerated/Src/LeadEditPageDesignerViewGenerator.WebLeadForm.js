define('LeadEditPageDesignerViewGenerator', ['ext-base', 'BPMSoft', 'sandbox', 'CardViewGenerator',
	'ConfigurationEnums', 'LeadEditPageDesignerViewGeneratorResources', 'Lead', 'EditPageDesignerViewGenerator'],
	function(Ext, BPMSoft, sandbox, CardViewGenerator, ConfigurationEnums, resources, Lead) {
		Ext.define('BPMSoft.Configuration.LeadEditPageDesignerViewGenerator', {
			alternateClassName: 'BPMSoft.LeadEditPageDesignerViewGenerator',
			extend: 'BPMSoft.EditPageDesignerViewGenerator',
			action: null,

			getFullViewModelSchema: function(sourceViewModelSchema) {
				var schema = BPMSoft.utils.common.deepClone(sourceViewModelSchema);
				return schema;
			},
			generateHeaderConfig: function() {
				var headerConfig = this.getContainerConfig('header', ['header']);
				var headerNameContainer = this.getContainerConfig('header-name-container', ['header-name-container']);
				var cardCommandLineContainer = this.getContainerConfig('card-command-line-container', ['card-command-line']);
				headerNameContainer.items = [{
					className: 'BPMSoft.Label',
					id: 'header-name',
					caption: {
						bindTo: 'getHeader'
					}
				}];
				headerConfig.items = [headerNameContainer, cardCommandLineContainer];
				cardCommandLineContainer.visible = false;
				return headerConfig;
			},
			generateUtilsConfig: function() {
				var utilsConfig = this.getContainerConfig('utils');

				var utilsLeftConfig = this.getContainerConfig('utils-left');
				var firstButtonConfig = {
					className: 'BPMSoft.Button',
					caption: resources.localizableStrings.SaveButtonCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					click: {
						bindTo: 'save'
					},
					visible: {
						bindTo: 'getIsInEditMode'
					}
				};
				utilsLeftConfig.items.push(firstButtonConfig);
				var firstViewModeButtonConfig = {
					className: 'BPMSoft.Button',
					caption: resources.localizableStrings.EditButtonCaption,
					click: {
						bindTo: 'edit'
					},
					visible: {
						bindTo: 'getIsNotInEditMode'
					}
				};
				utilsLeftConfig.items.push(firstViewModeButtonConfig);
				var secondButton = {
					className: 'BPMSoft.Button',
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					caption: resources.localizableStrings.CancelButtonCaption,
					click: {
						bindTo: 'cancel'
					}
				};
				utilsLeftConfig.items.push(secondButton);

				var addMenuItems = [];
				var columns = Lead.columns;
				BPMSoft.each(columns, function(item) {
					if (item.dataValueType === BPMSoft.DataValueType.TEXT) {
						addMenuItems.push({
							caption: item.caption,
							tag: item.name,
							click: {
								bindTo: "addColumn"
							},
							enabled: {
								bindTo: "addItemEnabled" + item.name
							}
						});
					}
				});

				var addButton = {
					className: 'BPMSoft.Button',
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					caption: resources.localizableStrings.AddColumnButtonCaption,
					menu: {
						items: addMenuItems
					},
					visible: {
						bindTo: "getIsInEditMode"
					}
				};
				utilsLeftConfig.items.push(addButton);

				var utilsRightConfig = this.getContainerConfig('utils-right');
				utilsConfig.items.push(utilsLeftConfig);
				utilsConfig.items.push(utilsRightConfig);
				return utilsConfig;
			},
			getItemActionsConfig: function() {
				return [{
					className: 'BPMSoft.Button',
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					imageConfig: resources.localizableImages.UpButtonImage,
					tag: 'upField',
					tabIndex: -1,
					classes: {
						wrapperClass: ['designer-action-button']
					}
				}, {
					className: 'BPMSoft.Button',
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					imageConfig: resources.localizableImages.DownButtonImage,
					tag: 'downField',
					tabIndex: -1,
					classes: {
						wrapperClass: ['designer-action-button']
					}
				}, {
					className: 'BPMSoft.Button',
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					imageConfig: resources.localizableImages.EditButtonImage,
					tag: 'edit',
					tabIndex: -1,
					classes: {
						wrapperClass: ['designer-action-button']
					}
				}, {
					className: 'BPMSoft.Button',
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					imageConfig: resources.localizableImages.HideButtonImage,
					tag: 'hide',
					tabIndex: -1,
					classes: {
						wrapperClass: ['designer-action-button']
					}
				}];
			},
			generate: function() {
				var viewConfig = this.callParent(arguments);
				var recommendationConfig = this.getContainerConfig('usertask-recommendation');
				recommendationConfig.items = [Ext.create('BPMSoft.Label', {
					id: 'usertask-recommendation-label',
					selectors: {
						wrapEl: '#usertask-recommendation-label'
					},
					caption: {
						bindTo: "getRecommendationCaption"
					},
					visible: {
						bindTo: "getRecommendationIsVisible"
					}
				})];
				viewConfig.items.splice(2, 0, recommendationConfig);

				return viewConfig;
			},
			getTabbedContainerConfig: function(schemaItem) {
				if (this.action === ConfigurationEnums.CardState.EditStructure) {
					return this.callParent(arguments);
				}
				var containerId = schemaItem.EditStructureContainerId;
				var containerConfig = this.getContainerConfig(containerId, ['designer-item-container']);
				return containerConfig;
			},
			generateCardView: function(viewModelSchema, info) {
				var fullViewModelSchema = this.getFullViewModelSchema(viewModelSchema);
				var entitySchema = fullViewModelSchema.entitySchema;
				var leftPanelConfig = this.getContainerConfig('autoGeneratedLeftContainer');
				this.action = (fullViewModelSchema.action !== ConfigurationEnums.CardState.View)
					? ConfigurationEnums.CardState.EditStructure
					: ConfigurationEnums.CardState.Edit;
				this.generateView(
					leftPanelConfig,
					fullViewModelSchema.schema.leftPanel,
					fullViewModelSchema.bindings,
					this.action,
					entitySchema,
					info);
				var cardViewConfig = this.getContainerConfig('autoGeneratedCardViewContainer');
				cardViewConfig.items = [leftPanelConfig];
				return cardViewConfig;
			}
		});

		var editPageViewGenerator = Ext.create('BPMSoft.LeadEditPageDesignerViewGenerator');
		return editPageViewGenerator;
	});
