define("PageItemPropertiesPageModule", [
  		"PageItemPropertiesPageModuleResources",
		"BasePropertiesPageModule"
	],
	function(resources) {
		Ext.define("BPMSoft.PageItemPropertiesPageModule", {
			extend: "BPMSoft.BasePropertiesPageModule",

			mixins: {
				customEvent: "BPMSoft.CustomEventDomMixin"
			},

			/**
			 * Name of message to obtain page item config.
			 * @protected
			 */
			getItemConfigMessageName: null,

			/**
			 * Name of message to save page item config.
			 * @protected
			 */
			saveItemConfigMessageName: null,

			/**
			 * Returns an array of localizable string model
			 * @protected
			 * @return {Array} Array of localizable string model.
			 */
			getCaptionStringModel: function (config, callback, scope) {
				if (!config.captionResourcesName) {
					return Ext.callback(callback, scope);
				}
				const pageSchema = config.pageSchema;
				const resourceArray = config.captionResourcesName.split(".");
				const resourceName= resourceArray[resourceArray.length -1];
				let localizableString = pageSchema.localizableStrings.find(resourceName);
				if (!localizableString) {
					const schemaUId = pageSchema.isNew() ? pageSchema.parentSchemaUId : pageSchema.uId;
					const instanceConfig = {schemaUId, packageUId: pageSchema.packageUId};
					BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(instanceConfig, (item) => {
						localizableString = item.localizableStrings.find(resourceName);
						const captionModel = this.toLocalizableStringModel(localizableString);
						return Ext.callback(callback, scope, [captionModel]);
					}, this);
				} else {
					return Ext.callback(callback, scope, [this.toLocalizableStringModel(localizableString)]);
				}
			},

			/**
			 * Returns page item validation config.
			 * @return {Object} Page item validation config.
			 * @protected
			 */
			getValidationConfig: function(config) {
				return {
					maxColumnNameLength: 50,
					maxColumnCaptionLength: 50,
					schemaColumnsNames: config.existedNames
				};
			},

			/**
			 * Returns page item config.
			 * @return {Object} Page item config.
			 * @protected
			 */
			getPageItemConfig: function() {
				const config = this.sandbox.publish(this.getItemConfigMessageName, null, [this.sandbox.id]);
				const customEvent = this.mixins.customEvent;
				const validationConfig = this.getValidationConfig(config);
				this.getCaptionStringModel(config, (caption) => {
					customEvent.publish("GetColumnConfig", {
						itemType: this.getPageItemType(),
						validationConfig,
						name: config.name,
						caption,
						disableNameEditing: !config.canEditName,
					}, this);
				}, this);
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#save
			 * @override
			 */
			save: function(data) {
				this.callParent(arguments);
				let caption;
				if (data.caption.length > 0) {
					caption = new BPMSoft.LocalizableString({
						cultureValues: this.getCultureValues(data.caption)
					});
				} else {
					caption = new BPMSoft.LocalizableString();
				}
				this.sandbox.publish(this.saveItemConfigMessageName, {caption, name: data.name}, [this.sandbox.id]);
				this.close();
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#initCustomEvents
			 * @override
			 */
			initCustomEvents: function() {
				this.callParent(arguments);
				const customEvent = this.mixins.customEvent;
				customEvent.subscribe("GetColumnConfig").subscribe(this.getPageItemConfig.bind(this));
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#getPropertiesPageTranslation
			 * @override
			 */
			getPropertiesPageTranslation: function() {
				const baseConfig = this.callParent(arguments);
				const config = {
					"duplicateColumnName": this.resources.localizableStrings.DuplicateNameMessage
				};
				return Object.assign({}, baseConfig, config);
			},

			/**
			 * @override
			 */
			init: function() {
				this.initResources(resources);
				this.callParent(arguments);
			}

		});
		return BPMSoft.PageItemPropertiesPageModule;
	});
