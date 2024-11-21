define("SpecificationFilterView", ["SpecificationFilterViewResources", "ViewGeneratorV2", "ContainerListEx"],
	function(resources, ViewGeneratorV2) {

		/**
		 * ######## ############ ##########
		 * @private
		 * @param id
		 * @param wrapClass
		 * @param items
		 * @returns {Object}
		 */
		function getContainerConfig(id, wrapClass, items, config) {
			var container = {
				className: "BPMSoft.Container",
				id: id,
				classes: {
					wrapClassName: Ext.isArray(wrapClass) ? wrapClass : [wrapClass]
				},
				selectors: {
					wrapEl: "#" + id
				},
				items: items ? items : []
			};
			if (config) {
				Ext.apply(container, config);
			}
			return container;
		}

		/**
		 * ########## ############ ############# ###### ########### ########## #############
		 * @returns {Object}
		 */
		function generate() {
			var backImageUrl =
				BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.BackImage);
			var folderImageUrl =
				BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.FolderIcon);

			var diffConfig = [
				{
					"operation": "insert",
					"name": "specificationFilterContainer",
					"values": {
						"id": "specificationFilterContainer",
						"selectors": {"wrapEl": "#specificationFilterContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["specification-filter-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "specificationFilterContainer",
					"name": "filter-edit-toolbar",
					"propertyName": "items",
					"values": {
						"id": "filter-edit-toolbar",
						"selectors": {"wrapEl": "#filter-edit-toolbar"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["filter-edit-toolbar"],
						"classes": {
							"wrapClassName": "extended-filter-attributes-button-container"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "filter-edit-toolbar",
					"propertyName": "items",
					"name": "extended-filter-back-button",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": resources.localizableStrings.BackButtonCaption,
						"classes": { "wrapperClass": "extended-filter-back-button" },
						"click": { "bindTo": "onGoBackToFolders" }
					}
				},
				{
					"operation": "insert",
					"parentName": "filter-edit-toolbar",
					"propertyName": "items",
					"name": "extended-filter-apply-button",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": resources.localizableStrings.ApplyButtonCaption,
						"classes": { "textClass": "extended-filter-apply-button" },
						"click": { "bindTo": "applyButton" }
					}
				},
				{
					"operation": "insert",
					"parentName": "specificationFilterContainer",
					"propertyName": "items",
					"name": "extended-filter-path-label",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "CataloguePath"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": { "wrapperClass": "extended-filter-path-label" },
						"imageConfig": {
							"source": BPMSoft.ImageSources.URL,
							"url": folderImageUrl
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "specificationFilterContainer",
					"name": "filterElementsContainer",
					"propertyName": "items",
					"values": {
						"id": "filterElementsContainer",
						"selectors": {"wrapEl": "#filterElementsContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["filter-elements-container"],
						"classes": {
							"wrapClassName": "filter-elements-container"
						},
						"items": []
					}
				}
			];
			return generateViewConfig(diffConfig);
		}

		/**
		 * ######## ######### ######## #######
		 * @private
		 * @param column #######
		 * @returns {Object}
		 */
		function getLabelControlConfig(column) {
			var className = "Label";
			var id = ["caption", column.name.replace(".", "_"), className.toLowerCase()].join("-");
			var config = {
				className: "BPMSoft." + className,
				id: id,
				selectors: {wrapEl: "#" + id},
				markerValue: column.caption
			};
			config.caption = column.caption;
			config.classes = {labelClass: [column.name.replace(".", "_") + "Сaption", "label-filter-caption"]};
			return config;
		}

		/**
		 * ######## ############ ######## #######
		 * @private
		 * @param column ######## #######
		 * @param className ######## ###### ######## ##########
		 * @returns {Object}
		 */
		function getEditControlConfig(column, className) {
			var id = ["edit", column.name.replace(".", "_"), className.toLowerCase()].join("-");
			var config = {
				className: "BPMSoft." + className,
				id: id,
				selectors: {wrapEl: "#" + id},
				tag: column.name,
				classes: {wrapClass: [column.name.replace(".", "_") + "Edit", className.toLowerCase() + "-filter-edit"]},
				enterkeypressed: {bindTo: "on" + column.name.replace(".", "_") + "EnterPressed"},
				value: {bindTo: column.name + "Value"},
				markerValue: column.caption
			};
			return config;
		}

		/**
		 * ########## ############# ########## ######## ##########
		 * @private
		 * @param config
		 * @returns {Object}
		 */
		function generateTextView(config) {
			var label = getLabelControlConfig(config);
			var edit = getEditControlConfig(config, "TextEdit");

			var advConf = {
				markerValue: (config && config.caption) ? config.caption : undefined
			};
			var viewConfig = getContainerConfig(
				config.name.replace(".", "_") + "Container",
				[config.name.replace(".", "_") + "-container text-filter-container"],
				[label, edit],
				advConf
			);
			return viewConfig;
		}
		/**
		 * ######### ##### ####### ## ############# ############ #####
		 * @protected
		 * @param {Object[]} parentView ############ ############# ############ #####
		 * @param {Object[]} diff ##### #######. ############ ##### ###### ######## ########### ############ #####
		 * @return {Object[]} ########## ######### ############# # ########### ####### #######
		 */
		function applyViewDiff(parentView, diff) {
			return BPMSoft.JsonApplier.applyDiff(parentView, diff);
		}

		/**
		 * ########## ############# ## ###### ###### #######
		 * @private
		 * @param diffConfig
		 * @returns {*}
		 */
		function generateViewConfig(diffConfig) {
			var config = ViewGeneratorV2.generateView(applyViewDiff([], diffConfig));
			if (config.length) {
				return Ext.create(config[0].className, config[0]);
			}
			return null;
		}

		/**
		 * ########## ###### ### #######
		 * @param column ######## #######
		 * @param className ######## ###### ######## ##########
		 * @param columnCount ########## ########## #######
		 * @param advancedConfig ############## ############ ######## ##########
		 * @returns {Object}
		 */
		function getEditableControlConfig(column, className, columnCount, advancedConfig) {
			var id = ["row", column, className.toLowerCase()].join("-");
			var config = {
				className: "BPMSoft." + className,
				id: id,
				markerValue: id,
				selectors: {wrapEl: "#" + id}
			};
			switch (className) {
				case ("Label") :
					config.caption = {bindTo: column};
					config.classes = {labelClass: ["grid-cols-" + columnCount, "data-label", "gridRow" + column + className]};
					break;
				case ("ImageView") :
					config.tpl = [
						/*jshint white:false */
						"<div id='{id}-wrap-view' class='{wrapClass}'>"+
							"<img id='{id}-image-view' class='image-view-class' src='{imageSrc}' title='{imageTitle}' /></div>"
						/*jshint white:true */
					];
					config.wrapClasses = ["grid-cols-" + columnCount + " " + "gridRow" + column + className];
					break;
				case ("CheckBoxEdit"):
					config.checked = {bindTo: column};
					config.classes = {wrapClass: ["grid-cols-" + columnCount, "gridRow" + column + className]};
					break;
				default :
					config.value = {bindTo: column};
					config.classes = {wrapClass: ["grid-cols-" + columnCount, "gridRow" + column + className]};
					break;
			}
			if (advancedConfig) {
				Ext.apply(config, advancedConfig);
			}
			return config;
		}

		/**
		 * ########## ############# ####### ########### ####
		 * @private
		 * @param config
		 * @returns {Object}
		 */
		function generateLookupFilterView(config) {
			var itemName = config.name.replace(".", "_");
			var itemNameID = "ID_" + config.name.replace(".", "_");
			var diffConfig = [
				{
					"operation": "insert",
					"name": itemNameID + "Container",
					"values": {
						"id": itemNameID + "Container",
						"selectors": {"wrapEl": "#" + itemNameID + "Container"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": [itemNameID + "Container", "lookup-filter-view-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": itemNameID + "Container",
					"name": itemNameID + "ControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": config.caption,
						"items": [],
						"tools": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": itemNameID + "ToolsContainer",
					"parentName": itemNameID + "ControlGroup",
					"propertyName": "items",
					"values": {
						"id": itemNameID + "ToolsContainer",
						"selectors": {"wrapEl": "#" + itemNameID + "ToolsContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": [itemNameID + "ToolsContainer"],
						"items": [],
						"visible": {"bindTo": "IsToolsButtonVisible" + itemName}
					}
				},
				{
					"operation": "insert",
					"parentName": itemNameID + "ToolsContainer",
					"propertyName": "items",
					"name": "AllSelectButton" + itemNameID,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": resources.localizableStrings.SelectAllButtonCaption,
						"tag": {"key": true, "id": itemName},
						"classes": {"textClass": "tools-button"},
						"click": {"bindTo": "selectUnselectSpecification"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"visible": {"bindTo": "IsToolsButtonVisible" + itemName}
					}
				},
				{
					"operation": "insert",
					"parentName": itemNameID + "ToolsContainer",
					"propertyName": "items",
					"name": "AllDeselectButton" + itemNameID,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": resources.localizableStrings.DeselectButtonCaption,
						"classes": {"textClass": "tools-button"},
						"click": {"bindTo": "selectUnselectSpecification"},
						"tag": {"key": false, "id": itemName},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"visible": {"bindTo": "IsToolsButtonVisible" + itemName}
					}
				},
				{
					"operation": "insert",
					"name": itemNameID + "ContainerList",
					"parentName": itemNameID + "ControlGroup",
					"propertyName": "items",
					"values": {
						"id": itemNameID + "ContainerList",
						"selectors": {"wrapEl": "#" + itemNameID + "ContainerList"},
						"itemType": "BPMSoft.ContainerListEx",
						"generator": "generateContainerListEx",
						"idProperty": "Id",
						"collection": {"bindTo": "GridData" + itemName},
						"classes": {"wrapClassName": [itemNameID + "ContainerList"] },
						"onGetItemConfig": {"bindTo": "onGetItemConfig" + itemName},
						"isAsync": false,
						"markerValue": "LookupFilterListGrid" + itemName
					}
				}
			];
			ViewGeneratorV2.customGenerators = ViewGeneratorV2.customGenerators || {};
			ViewGeneratorV2.customGenerators[itemNameID + "ContainerList"] = function(config) {
				var controlId = ViewGeneratorV2.getControlId(config, "BPMSoft.ContainerListEx");
				var result = {
					className: "BPMSoft.ContainerListEx",
					id: controlId,
					selectors: {
						wrapEl: "#" + controlId
					},
					items: []
				};
				Ext.apply(result, ViewGeneratorV2.getConfigWithoutServiceProperties(config, []));
				delete result.generator;
				ViewGeneratorV2.applyControlConfig(result, config);
				return result;
			};
			return generateViewConfig(diffConfig);
		}

		/**
		 * ########## ############# ######## ####### ########### ####
		 * @param model
		 * @returns {Object}
		 */
		function generateLookupElementView(model) {
			var columnPath = model.get("ColumnPath");
			var specification = model.get("Specification");
			var advCheckboxConfig = {
				tag: Ext.isEmpty(columnPath) ? specification.value : columnPath,
				checkedchanged: {bindTo: "checkedchanged"}
			};
			var defaultRowConfig = {
				className: "BPMSoft.Container",
				id: "gridRow-container",
				selectors: {wrapEl: "#gridRow-container"},
				classes: {wrapClassName: ["rowContainer", "grid-listed-row", "grid-active-selectable"]},
				items: [
					getEditableControlConfig("CheckBox", "CheckBoxEdit", 4, advCheckboxConfig),
					getEditableControlConfig("Name", "Label", 20)
				]
			};
			return defaultRowConfig;
		}

		/**
		 * ########## ############# ####### ######## ####
		 * @returns {Object}
		 */
		function generateFloatFilterView() {
			return null;
		}
		return {
			generate: generate,
			generateTextView: generateTextView,
			generateLookupFilterView: generateLookupFilterView,
			generateLookupElementView: generateLookupElementView,
			generateFloatFilterView: generateFloatFilterView
		};
	});
