define("ButtonPropertiesPageModule", [
		"ButtonPropertiesPageModuleResources",
		"PageItemPropertiesPageModule"
	],
	function(resources) {
		Ext.define("BPMSoft.ButtonPropertiesPageModule", {
			extend: "BPMSoft.PageItemPropertiesPageModule",

			messages: {
				/**
				 * @message GetDesignSchema
				 */
				"GetDesignSchema": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SaveButtonConfig
				 */
				"SaveButtonConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			// region Fields: Private

			/**
			 * @private
			 */
			_colorsList: null,

			/**
			 * @private
			 */
			_pageSchema: null,

			/**
			 * @private
			 */
			_designerSchemaItem: null,

			// endregion

			// region Fields: Protected

			/**
			 * @inheritdoc PageItemPropertiesPageModule#getItemConfigMessageName
			 * @override
			 */
			getItemConfigMessageName: "GetDesignSchema",

			/**
			 * @inheritdoc PageItemPropertiesPageModule#saveItemConfigMessageName
			 * @override
			 */
			saveItemConfigMessageName: "SaveButtonConfig",

			// endregion

			// region Methods: Private

			/**
			 * @private
			 */
			_initColorsList: function () {
				const buttonColors = BPMSoft.controls.ButtonEnums.style;
				const exceptColors = [buttonColors.GREY, buttonColors.TRANSPARENT];
				this._colorsList = Object.values(buttonColors).filter(color => !exceptColors.includes(color)).map(color => {
					return {
						name: BPMSoft.Button.getStyleCaption(color),
						value: color
					};
				});
			},

			/**
			 * @private
			 */
			_initDesignerSchemaItem: function () {
				const designSchema = this.sandbox.publish("GetDesignSchema");
				this._pageSchema = designSchema.$PageSchema;
				this._designerSchemaItem = designSchema && designSchema.$ActionLayoutItem;
			},

			/**
			 * @private
			 */
			_getButtonCaptionStringModel: function(item, callback, scope) {
				this.getCaptionStringModel({
						captionResourcesName: item.Tag + "ButtonCaption",
						pageSchema: this._pageSchema
					}, (caption) => {
					if (caption.length === 0) {
						const buttonParameter = this._pageSchema.findParameterByName("Buttons");
						if (buttonParameter?.uId && this._pageSchema.resources) {
							const resourceKey = `Parameters.${buttonParameter.uId}.Value.${item.Id}.Caption`;
							const resource = this._pageSchema.resources[resourceKey];
							caption = this.toLocalizableStringModel({
								cultureValues: resource
							});
						}
						const currentCulture = BPMSoft.SysValue.CURRENT_USER_CULTURE.displayValue;
						const currentCultureValue = caption.find(x => x.cultureName === currentCulture);
						if (!currentCultureValue) {
							caption.push({
								cultureName: currentCulture,
								value: item.Caption
							});
						}
					}
					Ext.callback(callback, scope, [caption]);
				}, this);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc PageItemPropertiesPageModule#getPageItemConfig
			 */
			getPageItemConfig: function() {
				const item = {};
				BPMSoft.each(this._designerSchemaItem.columns, function(attribute, name) {
					item[name] = this._designerSchemaItem.get(name);
				}, this);
				this._getButtonCaptionStringModel(item, (caption) => {
					this.mixins.customEvent.publish("GetColumnConfig", {
						caption,
						name: item.Tag,
						color: item.Style,
						performClosePage: item.PerformClosePage,
						performSaveData: item.PerformSaveData,
						generateSignal: item.GenerateSignal,
						active: item.Enabled,
						colorsList: this._colorsList,
						validationConfig: {},
						itemType: this.getPageItemType(),
					}, this);
				});
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#getPropertiesPageTranslation
			 * @override
			 */
			getPropertiesPageTranslation: function() {
				const baseConfig = this.callParent(arguments);
				return {
					...baseConfig,
					"caption": resources.localizableStrings.ButtonCaption,
					"activeCaption": resources.localizableStrings.ActiveCaption,
					"generateSignalCaption": resources.localizableStrings.GenerateSignalCaption,
					"performSaveDataCaption": resources.localizableStrings.PerformSaveDataCaption,
					"performClosePageCaption": resources.localizableStrings.PerformClosePageCaption,
					"colorCaption": resources.localizableStrings.ColorCaption
				};
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#getPageItemType
			 * @override
			 */
			getPageItemType: function() {
				return "button";
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#save
			 * @override
			 */
			save: function(data) {
				const caption = new BPMSoft.LocalizableString({
					cultureValues: this.getCultureValues(data.caption)
				});
				this._designerSchemaItem.set("Caption", caption.getValue());
				this._designerSchemaItem.set("CaptionLcz", caption);
				this._designerSchemaItem.set("Tag", data.name);
				this._designerSchemaItem.set("Style", data.color);
				this._designerSchemaItem.set("PerformClosePage", data.performClosePage);
				this._designerSchemaItem.set("PerformSaveData", data.performSaveData);
				this._designerSchemaItem.set("PerformClosePage", data.performClosePage);
				this._designerSchemaItem.set("GenerateSignal", data.generateSignal);
				this._designerSchemaItem.set("Enabled", data.active);
				this.sandbox.publish("SaveButtonConfig", null, [this.sandbox.id]);
				this.close();
			},

			// endregion

			// region Methods: Public

			/**
			 * @override
			 */
			init: function() {
				this.initResources(resources);
				this.callParent(arguments);
				this._initDesignerSchemaItem();
				this._initColorsList();
			}

			// endregion

		});
		return BPMSoft.ButtonPropertiesPageModule;
	});
