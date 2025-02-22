﻿define("LanguagePage", ["BPMSoft"], function(BPMSoft) {
	return {
		entitySchemaName: "SysCulture",
		attributes: {
			"PrimaryCulture": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			"Active": {
				dependencies: [
					{
						columns: ["Default"],
						methodName: "onIsLanguageDefaultChange"
					}
				]
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {

			//region Methods: Private

			/**
			 * Initializes primary culture.
			 * @private
			 * @param {Function} callback Callback.
			 * @param {Object} scope Callback execution scope.
			 */
			initPrimaryCulture: function(callback, scope) {
				this.BPMSoft.SysSettings.querySysSettingsItem("PrimaryCulture", function(primaryCulture) {
					this.set("PrimaryCulture", primaryCulture);
					callback.call(scope);
				}, this);
			},

			/**
			 * Navigates to translation.
			 * @private
			 */
			navigateToTranslation: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: "SectionModuleV2/TranslationSection"
				});
			},

			/**
			 * Exports translation.
			 * @private
			 */
			exportTranslation: function() {

			},

			/**
			 * Imports translation.
			 * @private
			 */
			importTranslation: function() {

			},

			/**
			 * Initializes entity schema query columns.
			 * @private
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			initSysLanguageQueryColumns: function(esq) {
				esq.addColumn("Name");
				var codeColumn = esq.addColumn("Code");
				codeColumn.orderPosition = 0;
				codeColumn.orderDirection = this.BPMSoft.OrderDirection.ASC;
			},

			/**
			 * Initializes entity schema query filters.
			 * @private
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 * @param {String} filter Filter.
			 */
			initSysLanguageQueryFilters: function(esq, filter) {
				var filters = esq.filters;
				var filterGroup = this.BPMSoft.createFilterGroup();
				filterGroup.addItem(this.BPMSoft.createNotExistsFilter("[SysCulture:Name:Code].Id"));
				filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.CONTAIN, "Name", filter));
				filters.add(filterGroup);
				var name = this.get("Name");
				if (name) {
					filters.logicalOperation = BPMSoft.LogicalOperatorType.OR;
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Code", name));
				}
			},

			/**
			 * Creates "SysLanguage" entity schema query.
			 * @param {String} filter Filter.
			 * @return {BPMSoft.EntitySchemaQuery}
			 */
			createSysLanguageQuery: function(filter) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysLanguage"
				});
				this.initSysLanguageQueryColumns(esq);
				this.initSysLanguageQueryFilters(esq, filter);
				return esq;
			},

			/**
			 * Returns url of default image.
			 * @private
			 * @return {String}
			 */
			getDefaultImage: function() {
				return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultFlag"));
			},

			/**
			 * Image loaded event handler.
			 * @private
			 * @param {String} imageId Image identifier.
			 */
			onImageUploaded: function(imageId) {
				this.set(this.primaryImageColumnName, {
					value: imageId
				});
			},

			/**
			 * Shows error message.
			 * @private
			 */
			_showErrorMessage: function(message) {
				BPMSoft.showInformation(message, null, this, {
					style: BPMSoft.MessageBoxStyles.ORANGE
				});
			},

			/**
			 * Builds all configuration.
			 * @private
			 */
			_buildAllConfiguration: function(callback) {
				var maskId = BPMSoft.Mask.show({
					caption: this.get("Resources.Strings.BuildingConfiguration"),
					clearMasks: true
				});
				BPMSoft.SchemaDesignerUtilities.buildAllConfiguration(function(buildResponse) {
					BPMSoft.Mask.hide(maskId);
					if (buildResponse && buildResponse.success) {
						callback();
					} else {
						var errorMessage = buildResponse.errorInfo.toString();
						this._showErrorMessage(errorMessage);
					}
				}, this);
			},

			_getCurrentLanguageId: function() {
				var lookupValue = this.get("Language");
				return lookupValue && lookupValue.value;
			},

			//endregion

			//region Methods: Protected

			/**
			 * Prepares language list.
			 * @protected
			 * @virtual
			 * @param {String} filter Filter.
			 * @param {BPMSoft.Collection} list Language list.
			 */
			prepareLanguageList: function(filter, list) {
				var esq = this.createSysLanguageQuery(filter);
				esq.getEntityCollection(function(response) {
					if (!response.success) {
						throw new this.BPMSoft.UnknownException();
					}
					var languageList = {};
					var languages = response.collection;
					languages.each(function(language) {
						var id = language.get("Id");
						languageList[id] = {
							value: id,
							displayValue: language.get("Name"),
							code: language.get("Code")
						};
					}, this);
					list.clear();
					list.loadAll(languageList);
				}, this);
			},

			/**
			 * Determines if status can be changed.
			 * @protected
			 * @virtual
			 * @return {Boolean}
			 */
			isStatusEditable: function() {
				if (!this.get("IsEntityInitialized")) {
					return false;
				}
				var primaryCulture = this.get("PrimaryCulture");
				var language = this.get("Name");
				var isPrimaryCultureSelected = (primaryCulture.displayValue === language);
				var isDefaultCultureSelected = this.get("Default");
				return !isPrimaryCultureSelected && !isDefaultCultureSelected;
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.set("LanguageList", this.Ext.create(this.BPMSoft.Collection));
					this.initPrimaryCulture(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getPrimaryDisplayColumnValue
			 * @overridden
			 */
			getPrimaryDisplayColumnValue: function() {
				var language = this.get("Language");
				if (language) {
					return language.displayValue;
				}
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getViewOptionsButtonVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "navigateToTranslation"},
					"Caption": {"bindTo": "Resources.Strings.NavigateToTranslationCaption"},
					"Tag": "NavigateToTranslation"
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "exportTranslation"},
					"Caption": {"bindTo": "Resources.Strings.ExportCaption"},
					"Tag": "Export",
					"Visible": false
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "importTranslation"},
					"Caption": {"bindTo": "Resources.Strings.ImportCaption"},
					"Tag": "Import",
					"Visible": false
				}));
				return actionMenuItems;
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initActionButtonMenu: function() {
				this.callParent(arguments);
				if (this.isAddMode()) {
					this.set("ActionsButtonVisible", false);
				}
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getHeader: function() {
				return this.get("Resources.Strings.PageCaption");
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			onSaved: function() {
				var parentOnSaved = this.getParentMethod(this, arguments);
				if (BPMSoft.useStaticFileContent) {
					var currentLanguageId = this._getCurrentLanguageId();
					var currentLanguageState = this.get("Active");
					var isLanguageChanged = currentLanguageId !== this._initialLanguageId;
					var isLanguageStateChanged = currentLanguageState !== this._initialLanguageState;
					if ((isLanguageChanged || isLanguageStateChanged) && currentLanguageState) {
						this._initialLanguageId = currentLanguageId;
						this._initialLanguageState = currentLanguageState;
						BPMSoft.chain(
							function(next) {
								this._buildAllConfiguration(next);
							}, function(next) {
								BPMSoft.ProcessUserTaskSchemaManager.reset(next, this);
							}, function() {
								parentOnSaved();
							}, this);
						return;
					}
				}
				parentOnSaved();
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this._initialLanguageId = this._getCurrentLanguageId();
				this._initialLanguageState = this.get("Active");
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns url image.
			 * @return {String}
			 */
			getImage: function() {
				var primaryImageColumnValue = this.get(this.primaryImageColumnName);
				if (primaryImageColumnValue) {
					return this.getSchemaImageUrl(primaryImageColumnValue);
				}
				return this.getDefaultImage();
			},

			/**
			 * Image loaded event handler.
			 * @param {Object} image Image object.
			 */
			onImageChange: function(image) {
				if (!image) {
					this.set(this.primaryImageColumnName, null);
					return;
				}
				this.BPMSoft.ImageApi.upload({
					file: image,
					onComplete: this.onImageUploaded,
					scope: this
				});
			},

			/**
			 * Language list change handler.
			 * @param {Object} language Language.
			 */
			onLanguageListChange: function(language) {
				if (!this.get("IsEntityInitialized") || !language || !language.code) {
					return;
				}
				this.set("Name", language.code);
			},

			onIsLanguageDefaultChange: function() {
				if (!this.get("IsEntityInitialized")) {
					return;
				}
				var isLanguageDefault = this.get("Default");
				var isLanguageActive = this.get("Active");
				if (!isLanguageActive && isLanguageDefault) {
					this.set("Active", true);
				}
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "ImageContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["image-edit-container"],
					"layout": {
						"column": 0,
						"row": 0,
						"rowSpan": 4,
						"colSpan": 4
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageContainer",
				"propertyName": "items",
				"name": "Photo",
				"values": {
					"markerValue": "UploadImage",
					"getSrcMethod": "getImage",
					"onPhotoChange": "onImageChange",
					"readonly": false,
					"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Language",
				"values": {
					"caption": {bindTo: "Resources.Strings.Language"},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"enabled": {"bindTo": "isAddMode"},
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {"bindTo": "prepareLanguageList"},
						"list": {"bindTo": "LanguageList"},
						"change": {bindTo: "onLanguageListChange"},
						"filterComparisonType": BPMSoft.StringFilterType.CONTAIN,
						"minSearchCharsCount": 3
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Active",
				"values": {
					"caption": {bindTo: "Resources.Strings.Active"},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					},
					"enabled": {bindTo: "isStatusEditable"}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Default",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
