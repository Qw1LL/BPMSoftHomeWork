define("AngularGridLayoutEditItemModel", ["ModalBox", "GridLayoutEditItemModel", "MaskHelper"], function(ModalBox) {

	/**
	 * @class BPMSoft.configuration.AngularGridLayoutEditItemModel
	 * Class of AngularGridLayoutEditItemModel.
	 */
	Ext.define("BPMSoft.configuration.AngularGridLayoutEditItemModel", {
		extend: "BPMSoft.GridLayoutEditItemModel",
		alternateClassName: "BPMSoft.AngularGridLayoutEditItemModel",

		/**
		 * Widget type.
		 * @type {String}
		 */
		itemType: null,

		/**
		 * Widget caption.
		 * @type {String}
		 */
		itemCaption: null,

		parentViewModel: null,

		inputName: null,

		/**
		 * Widget caption.
		 * @type {Array}
		 */
		itemProps: [],

		inputs: [],

		labelProps: [],

		schemaModelItemDesignerName: null,

		angularParameters: [],

		validationError: null,

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#getImageConfig
		 * @overridden
		 */
		getImageConfig: function() {
			var { fileName, sysSchemaId, imageData } = this.getAngularModuleData() || {};

		    if (!imageData || Object.keys(imageData).length === 0) {
				return this.get("Resources.Images.AngularImage");
			}

			return {
				params: {
					hash: sysSchemaId,
					resourceItemName: imageData.name,
					schemaName: fileName
				},
				source: BPMSoft.ImageSources.SOURCE_CODE_SCHEMA
			};
		},

		getAngularModuleData: function() {
			var angularModuleData = (this.designSchema ? this.designSchema.get("AngularModules") : this.itemConfig) || {};
			var { fileName, sysSchemaId, imageData } = angularModuleData;
		
			if (this.designSchema && angularModuleData[this.itemConfig.sysSchemaUId]) {
				return angularModuleData[this.itemConfig.sysSchemaUId];
			}
		
			return {
				fileName: fileName || this.itemConfig.name,
				sysSchemaId,
				imageData
			};
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getCaption
		 * @overridden
		 */
		getCaption: function() {
			if (this.itemConfig?.markerValue === "AngularModule") {
				return this.itemConfig.displayValue;
			} else {
				return this.itemCaption;
			}
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getMessages
		 * @overridden
		 */
		getMessages: function() {
			var designerModuleId = this.getDesignerModuleId();
			return [
		   {
				ownerId: this.instanceId,
				messageName: "GetModuleInfo",
				moduleId: designerModuleId,
				handler: this.getConfigureModelItemModuleConfig
		   },
           {
				ownerId: this.instanceId,
				messageName: "OnDesignerSaved",
				moduleId: designerModuleId,
				handler: this.onDesignerSave
			},
            {
				ownerId: this.instanceId,
				messageName: "WidgetDesignerCancel",
				moduleId: designerModuleId,
				handler: this.onDesignerCancel
			},
			{
				ownerId: this.instanceId,
				messageName: "GetColumnConfig",
				moduleId: designerModuleId,
				handler: this.getConfigureModelItemColumnConfig
			},
        ];
		},

        addItemToDesignSchemaCollection: function(layoutName) {
			const designSchema = this.designSchema;
			const collection = designSchema.getGridLayoutEditCollection(layoutName);
			const itemConfig = this.itemConfig;
			collection.add(itemConfig.name, this);
			const usedColumns = designSchema.get("UsedColumns");
			if (Ext.isEmpty(usedColumns[itemConfig.bindTo])) {
				usedColumns[itemConfig.bindTo] = 0;
			}
			usedColumns[itemConfig.bindTo]++;
		},

		/**
		 * Returns designer module item.
		 * @protected
		 * @virtual
		 * @return {Object} Designer module item.
		 */
		getConfigureModelItemColumnConfig: function() {
			return this;
		},

		getConfigureModelItemModuleConfig: function() {
			return {schemaName: this.schemaModelItemDesignerName};
		},

		/**
		 * Designer save event handler.
		 * @protected
		 */
        onDesignerSave: function(itemConfig) {
			this.set("content", itemConfig.displayValue);
			if (this.designSchema.get("ActionLayoutCreate")) {
				this.designSchema.set("ActionLayoutCreate", false);
				this._saveNewWidget(itemConfig);
			}
			this.designSchema.sandbox.unloadModule(this.getDesignerModuleId());
        },

		getConfigurationButtonVisible: function() {
			const isItemParent = this.itemConfig.isParent;
			return !isItemParent;
		},

		_saveNewWidget: function(widgetConfig) {
			var layoutName = this.designSchema.get("ActionLayoutName");
			var collection = this.designSchema.getGridLayoutEditCollection(layoutName);
			const nameExists = collection.collection.items.some(item => {
				return item.itemConfig && item.itemConfig.name === widgetConfig.name;
			});
			if (nameExists) {
				this._addWidgetToSchemaModules(widgetConfig);
			} else {
				collection.add(widgetConfig.name, this);
				this._addWidgetToSchemaModules(widgetConfig);
			}
		},

		/**
		 * @private
		 */
		_addWidgetToSchemaModules: function(widgetConfig) {
			if (!this.designSchema.$Schema.angularModules) {
				this.designSchema.$Schema.angularModules = {};
			}
			const pageSchemaUId = this.designSchema.$Schema.schemaUId;
			if (this.designSchema.$Schema.angularModules[widgetConfig.name]) {
				console.log(`Key ${widgetConfig.name} already exists, updating value.`);
				this.designSchema.$Schema.angularModules[widgetConfig.name].angularParameters = widgetConfig.angularParameters;
				this.designSchema.$Schema.angularModules[widgetConfig.name].displayValue = widgetConfig.displayValue;
			} else {
				this.designSchema.$Schema.angularModules[widgetConfig.name] = {
					name: widgetConfig.name,
					moduleName: "AngularModule",
					displayValue: widgetConfig.displayValue,
					sysSchemaId: widgetConfig.sysSchemaId,
					sysSchemaUId: widgetConfig.sysSchemaUId,
					sysSchemaName: widgetConfig.existName,
					pageSchemaUId: pageSchemaUId,
					appWrapperUId: widgetConfig.appWrapperUId,
					angularParameters: widgetConfig.angularParameters,
					isNeedBuild: widgetConfig.isNeedBuild
				};
			}
			// delete widgetConfig.angularProperties;
			delete widgetConfig.sysSchemaId;
			// delete widgetConfig.existName;
			delete widgetConfig.pageSchemaUId;
		},

		/**
		 * Designer cancel event handler.
		 * @protected
		 */
		onDesignerCancel: function() {
			var designSchema = this.designSchema;
			designSchema.sandbox.unloadModule(this.getDesignerModuleId());
			designSchema.set("ActionLayoutItem", null);
			designSchema.set("ActionLayoutCreate", false);
		},

		/**
		 * Returns card widget designer module id.
		 * @protected
		 * @return {String} Card designer module id.
		 */
        getDesignerModuleId: function() {
			return this.designSchema.sandbox.id + "_ModelItemConfigModule";
		},

		closeList: function() {
			ModalBox.close();
		},
	
		saveModalProps: function () {
			if (this.validationError) {
				this.showInformationDialog(this.validationError);
				return;
			}
			if (this.inputName) {
				this.itemConfig.displayValue = this.inputName.getValue();
			}

			if (this.itemConfig && this.itemConfig.angularParameters) {
				this.itemConfig.angularParameters.forEach(function(property, index) {
					var input = Ext.getCmp("input" + index);
					if (input) {
						property.value = input.getValue() || null;
					}
				})
			}
		
			this.onDesignerSave(this.itemConfig);
			ModalBox.close();
		},
		
		createLabelInputContainer: function(caption, key, value, index) {
			var label = Ext.create("BPMSoft.Label", {
				caption: caption,
				classes: { labelClass: ["angular-props-item-label"] }
			});
		
			var input = Ext.create("BPMSoft.TextEdit", {
				id: "input" + index,
				value: value,
				classes: { wrapClass: ["angular-props-item-input"] }
			});
		
			return Ext.create("BPMSoft.Container", {
				id: "itemContainer" + index,
				classes: { wrapClassName: ["angular-props-item-container"] },
				items: [label, input]
			});
		},

		getModalBoxView: function() {
			var closeButton = Ext.create("BPMSoft.Button", {
				imageConfig: {bindTo: "getCloseImageConfig"},
				classes: {
					wrapperClass: "angular-controls-list-close-icon"
				}
			});
			closeButton.on("click", this.closeList, this);
			var mainContainer = Ext.create("BPMSoft.Container", {
				id: "MainAngularContainer",
				selectors: {
					wrapEl: "#MainAngularContainer"
				},
				classes: {
					wrapClassName: ["main-angular-container"]
				},
				items: []
			});
		
			var content = Ext.create("BPMSoft.Container", {
				id: "AngularPropsContentcontainer",
				selectors: {
					wrapEl: "#AngularPropsContentcontainer"
				},
				classes: {
					wrapClassName: ["angular-list-content-container"]
				},
				items: []
			});
			var headerContainer = Ext.create("BPMSoft.Container", {
				id: "AngularViewHeaderContainer",
				selectors: {
					wrapEl: "#AngularViewHeaderContainer"
				},
				classes: {
					wrapClassName: ["angular-list-header-container"]
				},
				items: []
			});
			var label = Ext.create("BPMSoft.Label", {
				caption: 'Параметры',
				classes: {
					labelClass: ["angular-props-header-caption-label label-in-header-container"]
				}
			});
			var saveButton = Ext.create("BPMSoft.Button", {
				markerValue: "saveButton",
				caption: "Сохранить",
				style: BPMSoft.controls.ButtonEnums.style.ORANGE,
				click: {
					bindTo: "onSendClick"
				},
				classes: {
					textClass: ["actions-button-margin-right"]
				}
			});
			saveButton.on("click", this.saveModalProps, this);		
			var closeButtonFooter = Ext.create("BPMSoft.Button", {
				markerValue: "closeButtonFooter",
				caption: "Отмена",
				click: {
					bindTo: "onCancelClick"
				},
				classes: {
					textClass: ["actions-button-margin-right"]
				}
			});
			closeButtonFooter.on("click", this.closeList, this);
			var buttonsContainer = Ext.create("BPMSoft.Container", {
				id: "buttonsContainer",
				selectors: {
					wrapEl: "#buttonsContainer"
				},
				classes: {
					wrapClassName: ["control-buttons"]
				},
				items: [saveButton, closeButtonFooter]
			});
			var labelName = Ext.create("BPMSoft.Label", {
				caption: "Наименование экземпляра",
				classes: {
					labelClass: ["angular-props-item-label label t-label-is-required"]
				}
			});
			this.inputName = Ext.create("BPMSoft.TextEdit", {
				id: "inputName",
				value: this.itemConfig.displayValue,
				classes: {
					wrapClass: ["angular-props-item-input"]
				},
				listeners: {
					change: function(field, newValue) {
						if (newValue.value === '') {
							this.validationError = 'Поле наименование экземпляра обязательно для заполнения.';
						} else {
							this.validationError = null;
						}
					}.bind(this)
				}
			});
			var LabelNameContainer = Ext.create("BPMSoft.Container", {
				id: "LabelNameContainer",
				selectors: {
					wrapEl: "#LabelNameContainer"
				},
				classes: {
					wrapClassName: ["label-name-container"]
				},
				items: [labelName, this.inputName]
			});
			if (BPMSoft.getIsRtlMode()) {
				label.direction = 'rtl';
			}
			headerContainer.add(label);
			headerContainer.add(closeButton);
			content.add(LabelNameContainer);
			if (this.itemConfig && this.itemConfig.angularParameters) {
				var angularParameters = this.itemConfig.angularParameters;
				angularParameters.forEach(function(property, index) {
					var key = property.name;
					var caption = property.caption;
					var inputValue = (property.value !== undefined && property.value !== null) ? property.value : property.defaultValue;
					
					var container = this.createLabelInputContainer(caption, key, inputValue, index);
					content.add(container);
				}, this);
			}

			var footerContainer = Ext.create("BPMSoft.Container", {
				id: "AngularViewFooterContainer",
				classes: {
					wrapClassName: ["angular-list-footer-container"]
				},
				items: [buttonsContainer]
			});
			mainContainer.add(headerContainer);
			mainContainer.add(content);
			mainContainer.add(footerContainer);
			return mainContainer;
		},

		openDesigner: function(config, itemConfig, callback, scope) {
			var designSchema = this.designSchema;
			designSchema.set("ActionLayoutName", config.layoutName);
			designSchema.set("ActionLayoutItem", this);
			designSchema.set("ActionLayoutCreate", true);

			const renderTo = ModalBox.show({
				widthPixels: 550,
				heightPixels: 610,
				allowClickPropagation: true
			});
			var view = this.getModalBoxView();
			view.render(renderTo);
		},

		addUniqueIdToAngularParameters:function (angularParameters, guId) {
			if (angularParameters && Array.isArray(angularParameters)) {
				angularParameters.forEach(function(param) {
					param.uId = BPMSoft.generateGUID();
				});
			}
		},
		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#createDesignItem
		 * @overridden
		 */
		createDesignItem: function(designSchema, config) {
			const guId = BPMSoft.generateGUID();
			var newLayout = designSchema.get(config.layoutName + "Selection");
			var itemConfig = BPMSoft.deepClone(this.itemConfig);
			// Добавление uId к каждому объекту в angularParameters
			this.addUniqueIdToAngularParameters(itemConfig.angularParameters);
			const generatedName = itemConfig.caption + '_' + guId;
			Ext.apply(itemConfig.layout, newLayout);
			itemConfig.itemType = BPMSoft.ViewItemType.MODULE;
			const uniqueGuid = "uniqueGuid-" + guId;
			const sysSchemaUId = "sysSchemaUId-" + itemConfig.sysSchemaUId;
			const tabName = "tabName-" + designSchema.get("ActiveTabName");
			itemConfig.classes = {
				wrapClassName: [
					"angular-grid-layout-item",
					itemConfig.caption,
					uniqueGuid,
					sysSchemaUId,
					tabName
				]
			};
			itemConfig.appWrapperUId = guId;
			itemConfig.isNeedBuild = true;
			itemConfig.name = generatedName;
			itemConfig.id = generatedName;
			itemConfig.existName = this.itemConfig.caption;
			itemConfig.markerValue = "AngularModule";
			itemConfig.displayValue = generatedName;
			delete itemConfig.caption;
			return Ext.create("BPMSoft.AngularGridLayoutEditItemModel", {
				designSchema: designSchema,
				angularParameters: itemConfig.angularParameters,
				itemConfig: itemConfig,
				itemType: this.itemType,
				itemCaption: this.itemCaption,
			});
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#addToDesignSchema
		 * @overridden
		 */
		addToDesignSchema: function(config, callback, scope) {
			var designSchema = this.designSchema;
			var itemConfig = this.itemConfig;
			designSchema.set("ActionLayoutName", config.layoutName);
			designSchema.set("ActionLayoutItem", this);
			designSchema.set("ActionLayoutCreate", true);
			this.openDesigner(config, itemConfig, callback, scope);
		},

		edit: function(config) {
			var itemConfig = this.itemConfig;
			if (itemConfig) {
				itemConfig.isNeedBuild = false;
				var designSchema = this.designSchema;
				designSchema.set("ActionLayoutName", config.layoutName);
				designSchema.set("ActionLayoutItem", this);
				designSchema.set("ActionLayoutCreate", false);
				this.openDesigner(config, itemConfig);
			}
		},

		/**
		 * @private
		 */
		_removeWidgetItemFromModules: function() {
			delete this.designSchema.$Schema.angularModules[this.itemConfig.name];
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#removeFromDesignSchema
		 * @overridden
		 */
		removeFromDesignSchema: function() {
			this.callParent(arguments);
			if (this.designSchema.$Schema.angularModules) {
				this._removeWidgetItemFromModules();
			}
		}
	});

	return BPMSoft.AngularGridLayoutEditItemModel;
});
