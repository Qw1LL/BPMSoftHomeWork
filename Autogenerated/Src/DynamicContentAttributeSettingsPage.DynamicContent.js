﻿define("DynamicContentAttributeSettingsPage", ["DynamicContentAttributeSettingsPageResources",
		"LookupUtilities", "ConfigurationConstants", "FilterEditModule"],
	function(resources, LookupUtilities, ConfigurationConstants) {
		return {
			messages: {

				/**
				 * Gets config for FilterEditModule.
				 */
				"GetFilterModuleConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * Sets selected attribute for edit it's properties.
				 */
				"SetSelectedAttribute": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * Listens of filter edit module changes value.
				 */
				"OnFiltersChanged": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * Publishes when current attribute properties changed.
				 */
				"DCAttributeUpdated": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Flag indicates necessity to show controls for edit attibute when it selected.
				 */
				"IsAttributeEditorVisible": {
					"dataValueType": BPMSoft.core.enums.DataValueType.BOOLEAN,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Current selected attribute for edit.
				 */
				"SelectedAttribute": {
					"dataValueType": BPMSoft.core.enums.DataValueType.CUSTOM_OBJECT,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Attribute's caption.
				 */
				"Caption" : {
					"dataValueType": BPMSoft.core.enums.DataValueType.TEXT,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Attribute's filter data from FilterEditModule.
				 */
				"FilterData" : {
					"dataValueType": BPMSoft.core.enums.DataValueType.TEXT,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				// #region Methods: Private

				_subscribeOnEvents: function() {
					var filterModuleId = this._getFilterEditModuleId();
					this.sandbox.subscribe("SetSelectedAttribute", this.setSelectedAttribute, this, [this.sandbox.id]);
					this.sandbox.subscribe("GetFilterModuleConfig",
						this.onGetConditionFilterModuleConfig, this, [filterModuleId]);
					this.sandbox.subscribe("OnFiltersChanged", this.onFiltersChanged, this, [filterModuleId]);
					this.on("change:Caption", this.onCaptionChanged, this);
				},

				_saveValues: function() {
					if (this.$SelectedAttribute !== undefined) {
						this._saveCaption(this.$Caption);
						this._saveFilterData();
					}
				},

				_saveCaption: function(value) {
					if (this.$SelectedAttribute === undefined || this.$SelectedAttribute.Caption === value) {
						return;
					}
					this.$SelectedAttribute.Caption = BPMSoft.utils.html.sanitizeHTML(value);
					this.sandbox.publish("DCAttributeUpdated", this.$SelectedAttribute);
				},

				_saveFilterData: function() {
					if (this.$SelectedAttribute === undefined || this.$SelectedAttribute.Value === this.$FilterData) {
						return;
					}
					this.$SelectedAttribute.Value = this.$FilterData;
					this.sandbox.publish("DCAttributeUpdated", this.$SelectedAttribute);
				},

				_getFilterEditModuleId: function() {
					return this.sandbox.id + "_FilterEditModule";
				},

				_loadFilterModule: function() {
					if (!this.$IsAttributeEditorVisible) {
						return;
					}
					var moduleId = this._getFilterEditModuleId();
					this.sandbox.loadModule("FilterEditModule", {
						"renderTo": "AttributeFilterEditModule",
						"id": moduleId
					});
				},

				_unloadFilterModule: function() {
					if (this.$IsAttributeEditorVisible) {
						return;
					}
					var moduleId = this._getFilterEditModuleId();
					this.sandbox.unloadModule(moduleId, "AttributeFilterEditModule");
				},

				// #endregion

				// #region Methods: Protected

				/**
				 * @inheritDoc BaseSchemaViewModel#init
				 * @protected
				 */
				init: function() {
					this.callParent(arguments);
					this.setSelectedAttribute(undefined);
					this._subscribeOnEvents();
				},

				/**
				 * Handles changes of filter when FilterEditModule changed it.
				 * @protected
				 * @param filterConfig {Object} Contains information about changed value. Also contains new filter value.
				 */
				onFiltersChanged: function(filterConfig) {
					this.set("FilterData", filterConfig.serializedFilter);
					this._saveFilterData();
				},

				/**
				 * Returns config object for FilterEditModule on message GetFilterModuleConfig.
				 * @protected
				 * @returns
				 * {
				 * 		{
				 * 			rootSchemaName: string,
				 * 			filters: string,
				 * 			filterProviderClassName: string
				 * 		}
				 * 	}
				 */
				onGetConditionFilterModuleConfig: function() {
					return {
						rootSchemaName: "Contact",
						rightExpressionMenuAligned: true,
						filters: this.$FilterData,
						filterProviderClassName: "BPMSoft.EntitySchemaFilterProvider"
					};
				},

				/**
				 * Handles changes of Caption attribute.
				 * @protected
				 * @param eventArgs {Object} Event arguments object.
				 * Contains information about changed properies and new/old value.
				 */
				onCaptionChanged: function(eventArgs) {
					var newCaption = eventArgs.get("Caption");
					if (newCaption !== BPMSoft.emptyString && newCaption.replace(/\s/g,"") !== "") {
						this._saveCaption(newCaption);
					} else {
						BPMSoft.debounce(function () {
							if (!BPMSoft.isEmpty(this.$SelectedAttribute)) {
								this.$Caption = this.$SelectedAttribute.Caption;
							}
						}.bind(this))();
					}
				},

				/**
				 * Sets selected attribute when it changed in DynamicContentAttributesPropertiesPage.
				 * @param attribute Selected attribute.
				 * @protected
				 */
				setSelectedAttribute: function(attribute) {
					this._saveValues();
					this.$SelectedAttribute = attribute;
					if (attribute === undefined) {
						this.$IsAttributeEditorVisible = false;
						this.$Caption = "";
						this.$FilterData = "";
						this._unloadFilterModule();
					} else {
						this.$Caption = attribute.Caption;
						this.$FilterData = attribute.Value;
						this.$IsAttributeEditorVisible = true;
						this._loadFilterModule();
					}
				},

				/**
				 * Returns flag that describe visibility of blank slate.
				 * @protected
				 * @returns {boolean} Returns oposite value to IsAttributeEditorVisible.
				 */
				isBlankSlateVisible: function () {
					return !this.$IsAttributeEditorVisible;
				},

				/**
				 * Inits ContactFolder lookup filters.
				 * @protected
				 * @return {BPMSoft.FilterGroup} custom FilterGroup
				 */
				getFolderLookupFilters: function() {
					var filters = BPMSoft.createFilterGroup();
					filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "FolderType", ConfigurationConstants.Folder.Type.Search));
					return filters;
				},


				/**
				 * Gets ContactFolder lookup config
				 * @protected
				 * @return {object}
				 */
				getFolderLookupConfig: function() {
					var config = {
						entitySchemaName: "ContactFolder",
						columns: ["Name", "SearchData"],
						hideActions: true,
						settingsButtonVisible: false,
						multiSelect: false
					};
					var filters = this.getFolderLookupFilters();
					if (filters) {
						config.filters = filters;
					}
					return config;
				},

				/**
				 * Handles click on select filter button
				 * @protected
				 */
				onSelectFilterClick: function() {
					var config = this.getFolderLookupConfig();
					LookupUtilities.Open(this.sandbox, config, function(args) {
						var collection = args.selectedRows;
						if (collection.getCount() > 0) {
							var selectedItem = collection.getItems()[0];
							this.$Caption = selectedItem.Name || this.$Caption;
							this.$FilterData = selectedItem.SearchData;
							this._loadFilterModule();
						}
					}, this, null, false, false);
				},

				/**
				 * Returns blank slate image url.
				 * @protected
				 * @returns {string} Blank slate image URL.
				 */
				getBlankSlateImageUrl: function() {
					var config = resources.localizableImages["BlankSlate"];
					return BPMSoft.ImageUrlBuilder.getUrl(config);
				}

				// #endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "AttributeSettingsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "FilterConditionSettingsLabel",
					"parentName": "AttributeSettingsContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.FilterConditionSettingsLabel",
						"classes": {
							"labelClass": ["t-title-label-dc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "isBlankSlateVisible"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateImage",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onPhotoChange": BPMSoft.emptyFn,
						"getSrcMethod": "getBlankSlateImageUrl",
						"classes": {
							"wrapClass": ["attributes-blank-slate-image"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateLabel",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["attributes-blank-slate-label-container"],
						"items": [
							{
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {
									"labelClass": [
										"attributes-blank-slate-label"
									]
								},
								"caption": "$Resources.Strings.BlankSlateLabelText"
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "AttributeEditorContainer",
					"propertyName": "items",
					"parentName": "AttributeSettingsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["attribute-editor-container"],
						"visible" : "$IsAttributeEditorVisible",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributeNameContainer",
					"propertyName": "items",
					"parentName": "AttributeEditorContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "AttributeNameContainer",
					"propertyName": "items",
					"name": "Caption",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"value": "$Caption",
						"wrapClass": ["style-input attribute-inline-grid-caption"],
						"isRequired": true,
						"labelConfig": {
							"caption": "$Resources.Strings.AttributeNameLabel"
						}
					}
				},
				{
					"operation": "insert",
					"name": "AttributeFilterCaptionLabel",
					"parentName": "AttributeEditorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.AttributeFilterLabel",
						"classes": {
							"labelClass": ["label-wrap"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AttributeFilterButton",
					"parentName": "AttributeEditorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": "$Resources.Strings.FilterLookupButtonCaption",
						"click": "$onSelectFilterClick",
						"classes": {
							"textClass": ["lookup-button"]
						}

					}
				},
				{
					"id": "AttributeFilterEditModule",
					"operation": "insert",
					"name": "AttributeFilterEditModule",
					"parentName": "AttributeSettingsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"items": []
					}
				}
			]
		};
	});
