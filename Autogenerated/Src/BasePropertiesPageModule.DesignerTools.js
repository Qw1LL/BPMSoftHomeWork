define("BasePropertiesPageModule", [
	"MaskHelper",
	"ModalBox",
	"BasePropertiesPageModuleResources",
	"page-wizard-component"
	],
	function(MaskHelper, ModalBox, resources) {
		Ext.define("BPMSoft.BasePropertiesPageModule", {
			extend: "BPMSoft.configuration.BaseModule",

			mixins: {
				customEvent: "BPMSoft.CustomEventDomMixin"
			},

			/**
			 * @type {Object} Resources.
			 * @protected
			 */
			resources: null,

			/**
			 * @type {Object} Current package identifier.
			 * @protected
			 */
			packageUId: null,

			/**
			 * @type {Object} Messages.
			 * @protected
			 */
			messages: {
				"GetNewLookupPackageUId": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
			},



			//region Methods: Protected

			/**
			 * Return a type of editable page item.
			 * @protected
			 * @abstract
			 * @return {String} Page item type.
			 */
			getPageItemType: BPMSoft.abstractFn,

			/**
			 * Returned some not empty culture value.
			 * @protected
			 */
			getSomeNotEmptyCultureValue: function(cultureValues) {
				return Object.values(cultureValues).find(function(cultureValue) {
					return !Ext.isEmpty(cultureValue);
				});
			},

			/**
			 * Returned page translations.
			 * @protected
			 */
			getPropertiesPageTranslation: function() {
				return {
					"saveButton": this.resources.localizableStrings.SaveButtonCaption,
					"cancelButton": this.resources.localizableStrings.CancelButtonCaption,
					"LocalizableStringsDialog.Cancel": this.resources.localizableStrings.CancelButtonCaption,
					"LocalizableStringsDialog.Apply": this.resources.localizableStrings.ApplyButtonCaption,
					"LocalizableStringsDialog.ShowAllLanguages": this.resources.localizableStrings.ShowAllLanguages,
					"LocalizableStringsDialog.HideInactiveLanguages": this.resources.localizableStrings.HideInactiveLanguages,
					"generalCaption": this.resources.localizableStrings.GeneralCaption,
					"appearenceCaption": this.resources.localizableStrings.AppearenceCaption,
					"advancedCaption": this.resources.localizableStrings.AdvancedCaption,
					"wrongCaptionLength": this.resources.localizableStrings.WrongCaptionLengthMessage,
					"columnEmpty": BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage,
					"wrongColumnName": this.resources.localizableStrings.WrongColumnNameMessage,
					"wrongColumnNameWithPrefix": this.resources.localizableStrings.WrongColumnNameWithPrefixMessage,
                  	"captionLabel": this.resources.localizableStrings.CaptionLabel,
					"nameLabel": this.resources.localizableStrings.CodeLabel,
					"tooltipLabel": this.resources.localizableStrings.TooltipLabel
				};
			},

			/**
			 * Initializes resources.
			 * @param {Object} schemaResources Resources
			 * @protected
			 */
			initResources: function(schemaResources) {
				Ext.applyIf(this.resources.localizableImages, schemaResources.localizableImages);
				Ext.applyIf(this.resources.localizableStrings, schemaResources.localizableStrings);
			},

			/**
			 * Initializes custom event.
			 * @protected
			 */
			initCustomEvents: function() {
				this.sandbox.registerMessages(this.messages);
				const customEvent = this.mixins.customEvent;
				customEvent.init();
				customEvent.subscribe("Cancel").subscribe(this.cancel.bind(this));
				customEvent.subscribe("Save").subscribe(this.save.bind(this));
			},

			/**
			 * Save event handler.
			 * @protected
			 */
			save: BPMSoft.emptyFn,

			/**
			 * Cancel event handler.
			 * @protected
			 */
			cancel: function() {
				this.close();
			},

			/**
			 * Close MessageBox.
			 * @protected
			 */
			close: function() {
				ModalBox.close();
			},

			/**
			 * Initializes translation.
			 * @protected
			 */
			initPageDesignerTranslation: function() {
				const translation = this.getPropertiesPageTranslation();
				this.mixins.customEvent.publish("GetPageWizardTranslation", translation);
			},

			/**
			 * Returns culture values.
			 * @protected
			 * @param localizableStringModel
			 */
			getCultureValues: function(localizableStringModel) {
				const cultureValues = {};
				const primaryCulture = BPMSoft.SysValue.PRIMARY_CULTURE.displayValue;
				const currentUserCulture = BPMSoft.SysValue.CURRENT_USER_CULTURE.displayValue;
				localizableStringModel.forEach(function (model) {
					cultureValues[model.cultureName] = model.value;
				}, this);
				if (!cultureValues[primaryCulture]) {
					if (cultureValues[currentUserCulture]) {
						cultureValues[primaryCulture] = cultureValues[currentUserCulture];
					} else {
						cultureValues[primaryCulture] = this.getSomeNotEmptyCultureValue(cultureValues);
					}
				}
				return cultureValues;
			},

			/**
			 * Convert localizable string to localizable string model.
			 * @param {BPMSoft.LocalizableString} localizableString Localizable string
			 */
			toLocalizableStringModel: function (localizableString) {
				const cultureValues = (localizableString && localizableString.cultureValues) || {};
				return Object.entries(cultureValues).map(function(cultureValue) {
					return {
						cultureName: cultureValue[0],
						value: cultureValue[1]
					};
				});
			},

			/**
			 * Publish lookup options list.
			 * @protected
			 */
			getLookupList: function({packageUId}) {
				BPMSoft.EntitySchemaManager.findPackageItems(packageUId, (items) => {
					const resultConfig = {};
					items.each(function(item) {
						resultConfig[item.getUId()] = {
							value: item.getUId(),
							name: item.getCaption()?.toString(),
							code: item.getName(),
							allowEdit: item.isNew()
						};
					}, this);
					const list = BPMSoft.sortObj(resultConfig, "name");
					const options = Object.values(list);
					this.mixins.customEvent.publish("GetLookupList", options);
				}, this);
			},

			/**
			 * Publish lookup names list.
			 * @protected
			 */
			getLookupNameList: function({packageUId}) {
				BPMSoft.EntitySchemaManager.findPackageItems(packageUId, (items) => {
					const options = items?.mapArray((item) => item.name, this);
					this.mixins.customEvent.publish("GetLookupNameList", options);
				}, this);
			},

			/**
			 * Publish lookup infos.
			 * @protected
			 */
			getLookupInfo: function({schemaUId, packageUId}) {
				BPMSoft.EntitySchemaManager.findBundleSchemaInstance({
					schemaUId,
					packageUId
				}, (schema) => {
					this.mixins.customEvent.publish("GetLookupInfo", {
						caption: this.toLocalizableStringModel(schema.caption),
						name: schema.name
					});
				}, this);
			},

			/**
			 * Publish current package identifier.
			 * @protected
			 */
			getCurrentPackageUId: function() {
				return this.sandbox.publish("GetNewLookupPackageUId", null, [this.sandbox.id]);
			},

			// endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseObject#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.resources = {
					localizableImages: {},
					localizableStrings: {}
				};
			},

			/**
			 * @override
			 */
			render: function(renderTo) {
				this.callParent(arguments);
				const propertiesPage = document.createElement("ts-page-item-properties-page-host");
				propertiesPage.setAttribute("item-type", this.getPageItemType());
				propertiesPage.setAttribute("current-culture",
					BPMSoft.SysValue.CURRENT_USER_CULTURE.displayValue);
				renderTo.appendChild(propertiesPage);
				MaskHelper.hideBodyMask();
			},

			/**
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this.initResources(resources);
				this.initCustomEvents();
				this.initPageDesignerTranslation();
			},

			/**
			 * @override
			 */
			onDestroy: function() {
				this.mixins.customEvent.destroy();
				this.callParent(arguments);
			}

			// endregion



		});
		return BPMSoft.BasePropertiesPageModule;
	});
