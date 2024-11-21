define("PageDesignerUtilities", ["ext-base", "BPMSoft", "PageDesignerUtilitiesResources", "ModalBox", "ColumnHelper",
	"SectionDesignDataModule", "SectionDesignerUtils", "BaseLookup", "MaskHelper", "ConfigurationEnums",
	"css!PageDesignerUtilities"],
	function(Ext, BPMSoft, resources, ModalBox, ColumnHelper, SectionDesignDataModule, SectionDesignerUtils,
			BaseLookup, MaskHelper, ConfigurationEnums) {
		var viewModel;
		var entityColumnType;
		var entityColumnConfig;
		var storage = BPMSoft.DomainCache;
		var localizableStrings = resources.localizableStrings;
		var localizableImages = resources.localizableImages;

		/**
		 * ############# ####### ######### # Grid Layout.
		 * @param {Object[]} config.items ######## Grid Layout.
		 * @returns {Array} matrix ####### #########.
		 */
		function getFillingGridMatrix(config) {
			var matrix = [];
			var items = config.items || config;
			BPMSoft.each(items, function(item) {
				var layout = item.layout;
				if (!layout.rowSpan) {
					layout.rowSpan = 1;
				}
				if (!layout.colSpan) {
					layout.colSpan = 12;
				}
				for (var i = layout.row; i < layout.row + layout.rowSpan; i++) {
					if (!matrix[i]) {
						matrix[i] = new Array(24);
					}
					for (var k = layout.column; k < layout.column + layout.colSpan; k++) {
						matrix[i][k] = true;
					}
				}
			});
			for (var i = 0, ln = matrix.length; i < ln; i++) {
				if (!matrix[i]) {
					matrix[i] = new Array(24);
				}
			}
			return matrix;
		}

		/**
		 * ######## ########## ## #######.
		 *
		 * @param {Function} callback ####### ######### ######.
		 * @param {BPMSoft.BaseViewModel} scope ######## ########## callback.
		 */
		function getDetailsInfo(callback, scope) {
			var detailsInfo = storage.getItem("SectionDesigner_DetailsInfo");
			if (!detailsInfo) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysDetail"
				});
				esq.addColumn("Id");
				esq.addColumn("Caption");
				esq.addColumn("DetailSchemaUId");
				esq.addColumn("EntitySchemaUId");
				esq.addColumn("[VwSysSchemaInWorkspace:UId:DetailSchemaUId].Name", "schemaName");
				esq.addColumn("[VwSysSchemaInWorkspace:UId:DetailSchemaUId].Caption", "schemaCaption");
				esq.addColumn("[VwSysSchemaInWorkspace:UId:EntitySchemaUId].Name", "entitySchemaName");
				esq.addColumn("[VwSysSchemaInWorkspace:UId:EntitySchemaUId].Caption", "entitySchemaCaption");
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "[VwSysSchemaInWorkspace:UId:DetailSchemaUId].SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value));
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "[VwSysSchemaInWorkspace:UId:EntitySchemaUId].SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value));
				var collection = Ext.create("BPMSoft.Collection");
				esq.getEntityCollection(function(result) {
					if (result.success) {
						result.collection.each(function(item) {
							collection.add(item.values);
						}, this);
						detailsInfo = collection.getItems();
						storage.setItem("SectionDesigner_DetailsInfo", BPMSoft.encode(detailsInfo));
						callback.call(scope, detailsInfo);
					}
				}, this);
			} else {
				callback.call(scope, BPMSoft.decode(detailsInfo));
			}
		}

		/**
		 * ######## ######### ############ ##### ####### ########### # #####.
		 *
		 * @param {Object} schema #####.
		 * @param {String} typeColumnUId ############# ####### # DesignData.
		 * @returns {BPMSoft.Collection} ######### #########.
		 */
		function getRequireFieldNotInSchema(schema, typeColumnUId) {
			var entityColumns = schema.entitySchema.columns;
			var viewConfig = schema.viewConfig;
			var collection = new BPMSoft.Collection();
			BPMSoft.each(entityColumns, function(column) {
				if (column.isRequired && !column.defaultValue && column.uId !== typeColumnUId) {
					var columnName = column.name;
					var item = getSchemaItemInfoByName(columnName, viewConfig) ||
						getElementByPropertyValue(viewConfig, "bindTo", columnName);
					if (!item) {
						collection.add(column.caption);
					}
				}
			});
			return collection;
		}

		/**
		 * Get scheme information by property name.
		 *
		 * @param {Object} obj Element.
		 * @param {String} propertyName Property name.
		 * @param {String} propertyValue Property value.
		 * @returns {BPMSoft.Collection} Element collection.
		 */
		function getElementByPropertyValue(obj, propertyName, propertyValue) {
			var result = null;
			BPMSoft.iterateChildItems(obj, function(iterationConfig) {
				var item = iterationConfig.item;
				if (item[propertyName] === propertyValue) {
					result = {
						item: item,
						parent: iterationConfig.parent,
						propertyName: iterationConfig.propertyName
					};
				}
				return Ext.isEmpty(result);
			}, this);
			return result;
		}

		/**
		 * Get schema information by name.
		 *
		 * @param {String} name Schema.
		 * @param {Object} parent Parent element.
		 * @returns {BPMSoft.Collection} Element collection.
		 */
		function getSchemaItemInfoByName(name, parent) {
			return getElementByPropertyValue(parent, "name", name);
		}

		/**
		 * ####### ####### ######### # #########.
		 * @private
		 *
		 * @returns {Object}
		 */
		function createPrefixLabel() {
			var prefix = SectionDesignerUtils.getSchemaNamePrefix();
			var visible = (Ext.isEmpty(prefix)) ? false : true;
			var prefixLabel = {
				id: "prefix-label",
				className: "BPMSoft.Label",
				caption: localizableStrings.PrefixMask + " " + prefix,
				visible: visible,
				selectors: {
					wrapEl: "#prefix-label"
				}
			};
			return prefixLabel;
		}

		/**
		 * ####### #########.
		 * @private
		 *
		 * @param {Object} config ################ ######.
		 * @param {String} config.name ### ##########.
		 * @param {Array} config.classes ###### ##########.
		 * @returns {BPMSoft.Container} ############## ############# ##########.
		 */
		function createContainer(config) {
			var result = Ext.create("BPMSoft.Container", {
				id: config.name,
				selectors: {
					wrapEl: "#" + config.name
				},
				classes: {wrapClassName: config.classes},
				items: []
			});
			return result;
		}

		/**
		 * ####### ################ ###### ######## ########## TextEdit.
		 * @private
		 *
		 * @param {Object} config
		 * @param {String} config.name ### ######## ##########.
		 * @param {String} config.caption ######### ######## ##########(##### ## ########).
		 * @param {Boolean} config.enabled ######## ########### ##############.
		 * @param {String} config.bindTo ######## ######## ######## ##########.
		 * @returns {Object} ################ ###### ######## TextEdit.
		 */
		function createTextEdit(config) {
			var placeholder = (config.placeholder) ? {bindTo: config.placeholder} : "";
			var result = {
				className: "BPMSoft.Container",
				id: config.name + "-container",
				selectors: {wrapEl: "#" + config.name + "-container"},
				classes: {wrapClassName: ["base-element"]},
				items: [
					{
						id: config.name + "Label",
						className: "BPMSoft.Label",
						caption: config.caption,
						selectors: {
							wrapEl: "#" + config.name + "Label"
						},
						isRequired: config.isRequired,
						classes: {labelClass: ["base-element-left"]}
					}, {
						className: "BPMSoft.TextEdit",
						id: config.name + "TextEdit",
						value: {
							bindTo: config.bindTo || config.name
						},
						selectors: {
							wrapEl: "#" + config.name + "TextEdit"
						},
						markerValue: config.name,
						placeholder: placeholder,
						enabled: config.enabled,
						classes: {wrapClass: ["base-element-right"]}
					}
				]
			};
			return result;
		}

		/**
		 * ####### ################ ###### ######## ########## RadioButton.
		 * @private
		 *
		 * @param {Object} config.
		 * @param {String} config.name ### ######## ##########.
		 * @param {String} config.caption ######### ######## ##########.
		 * @param {Boolean} config.checked ####### #########(##########) ######## ##########.
		 * @param {Array} config.items ######## ####### ##### ######### # ######### ### ######### ##########.
		 * @returns {Object} ################ ###### ######## RadioButton.
		 */
		function createRadioButton(config) {
			var result = {
				className: "BPMSoft.Container",
				id: config.name + "Container",
				selectors: {wrapEl: "#" + config.name + "Container"},
				classes: {wrapClassName: ["base-element"]},
				items: [
					{
						id: config.name + "RadioButton",
						className: "BPMSoft.RadioButton",
						enabled: config.enabled,
						checked: {bindTo: config.checked},
						tag: config.tag,
						selectors: {wrapEl: "#" + config.name + "RadioButton"}
					}, {
						id: config.name + "Label",
						className: "BPMSoft.Label",
						caption: config.caption,
						selectors: {wrapEl: "#" + config.name + "Label"},
						classes: {labelClass: ["radio-button-label"]}
					}, {
						className: "BPMSoft.Container",
						id: config.name + "ContentContainer",
						selectors: {wrapEl: "#" + config.name + "ContentContainer"},
						items: config.items,
						visible: {bindTo: config.containerVisible},
						markerValue: config.name,
						classes: {wrapClassName: ["radio-button-container"]}
					}
				]
			};
			return result;
		}

		/**
		 * ####### ################ ###### ######## ########## CheckBox.
		 * @private
		 *
		 * @param {Object} config.
		 * @param {String} config.name ### ######## ##########.
		 * @param {String} config.caption ######### ######## ##########.
		 * @returns {Object} ################ ###### ######## CheckBox.
		 */
		function createCheckBox(config) {
			var result = {
				className: "BPMSoft.Container",
				id: config.name + "Container",
				selectors: {wrapEl: "#" + config.name + "Container"},
				classes: {wrapClassName: ["base-element"]},
				items: [
					{
						id: config.name + "Label",
						className: "BPMSoft.Label",
						caption: config.caption,
						selectors: {wrapEl: "#" + config.name + "Label"},
						classes: {labelClass: ["check-box-left"]}
					}, {
						className: "BPMSoft.CheckBoxEdit",
						id: config.name + "CheckBoxEdit",
						selectors: {wrapEl: "#" + config.name + "CheckBoxEdit"},
						markerValue: config.name,
						checked: {bindTo: config.name}
					}
				]
			};
			return result;
		}

		/**
		 * ####### ################ ###### ######## ########## ComboBox.
		 * @private
		 *
		 * @param {Object} config.
		 * @param {String} config.name ### ######## ##########.
		 * @param {String} config.caption ######### ######## ##########.
		 * @param {Boolean} config.enabled ######## ########### ##############.
		 * @param {String} config.list ######## ###### ### ######## ##########.
		 * @param {Function} config.prepareList ####### ######## ###### ### ######## #########.
		 * @returns {Object} ################ ###### ######## ComboBox.
		 */
		function createComboBox(config) {
			var result = {
				className: "BPMSoft.Container",
				id: config.name + "Container",
				selectors: {wrapEl: "#" + config.name + "Container"},
				classes: {wrapClassName: ["base-element"]},
				items: [
					{
						id: config.name + "Label",
						className: "BPMSoft.Label",
						caption: config.caption,
						selectors: {wrapEl: "#" + config.name + "Label"},
						isRequired: config.isRequired,
						classes: {labelClass: ["base-element-left"]}
					}, {
						className: "BPMSoft.ComboBoxEdit",
						id: config.name + "ComboBoxEdit",
						enabled: config.enabled,
						selectors: {wrapEl: "#" + config.name + "ComboBoxEdit"},
						classes: {wrapClass: ["base-element-right"]},
						value: {bindTo: config.name},
						list: {bindTo: config.list},
						markerValue: config.name,
						prepareList: {bindTo: config.prepareList}
					}
				]
			};
			return result;
		}

		/**
		 * ######## ####### ########## ###### ###########.
		 * @private
		 * @param {String} name ### ######## ##########.
		 * @param {Array} classes ###### ######.
		 * @param {Array} items ######## # #### ######.
		 * @returns {BPMSoft.ControlGroup} ########## ############## ############# ###### ###########.
		 */
		function createControlGroup(name, classes, items) {
			var result = Ext.create("BPMSoft.ControlGroup", {
				id: name + "ControlGroup",
				selectors: {wrapEl: "#" + name + "ControlGroup"},
				collapsed: false,
				caption: localizableStrings.StyleCaption,
				bottomLine: false,
				items: items
			});
			if (BPMSoft.isArray(classes)) {
				result.classes = {
					wrapClassName: classes
				};
			}
			return result;
		}

		/**
		 * ####### ##### ### ########## #### (##### ######## ######### #### # ###### ########## # ######).
		 * @private
		 *
		 * @returns {BPMSoft.Container} ############## ############# ##### ########## ####.
		 */
		function createHeaderContainer() {
			var headerContainer = createContainer({name: "captionContainer"});
			headerContainer.add([{
				className: "BPMSoft.Label",
				id: "caption-label",
				selectors: {wrapEl: "#caption-label"},
				caption: {bindTo: "headerCaption"}
			}, {
				className: "BPMSoft.Button",
				id: "closeButton",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: localizableImages.CloseIcon,
				markerValue: "closeButton",
				classes: {wrapperClass: ["closeIcon"]},
				selectors: {wrapEl: "#closeButton"},
				click: {bindTo: "onCancelClick"}
			}]);
			return headerContainer;
		}

		/**
		 * ####### ####### ############# ########## ####.
		 * @private
		 *
		 * @returns {BPMSoft.Container} ########## ############## #############.
		 */
		function createMainView() {
			var content = [];
			var mainContainer = createContainer({name: "mainContainer"});
			var headerContainer = createHeaderContainer();
			content.push(headerContainer);
			mainContainer.add(content);
			return mainContainer;
		}

		/**
		 * ####### ############# ########## #### ### #### "##########".
		 * @private
		 *
		 * @returns {BPMSoft.Container} ############## ############# ########## #### ### #### "##########".
		 */
		function createLookupView() {
			var checkBoxContainer = createContainer({
				name: "contentContainer",
				classes: ["top-container-margin"]
			});
			checkBoxContainer.add([
				createCheckBox({
					name: "isListView",
					caption: localizableStrings.UseListViewCaption
				}),
				createCheckBox({
					name: "require",
					caption: localizableStrings.IsRequiredCaption
				}),
				createCheckBox({
					name: "readOnly",
					caption: localizableStrings.IsReadOnlyCaption
				})
			]);
			var controlGroupItems = {
				className: "BPMSoft.Container",
				id: "styleControlGroupContainer",
				selectors: {
					wrapEl: "#styleControlGroupContainer"
				},
				items: [
					createCheckBox({
						name: "hideCaption",
						caption: localizableStrings.HideLookupCaptionLabel
					}),
					createComboBox({
						name: "textSize",
						caption: localizableStrings.TextSizeLabel,
						list: "textSizeList",
						prepareList: "prepareTextSize",
						enabled: true
					})
				]
			};
			var view = createContainer({name: "contentContainer"});
			view.add([
				createTextEdit({
					name: "columnCaption",
					placeholder: "columnCaptionPlaceholder",
					isRequired: true,
					caption: localizableStrings.TitleCaption,
					enabled: true
				}),
				createTextEdit({
					name: "columnName",
					bindTo: "columnName",
					enabled: {bindTo: "isEditMode"},
					isRequired: true,
					caption: localizableStrings.NameCaption
				}),
				createPrefixLabel(),
				createRadioButton({
					name: "existLookup",
					caption: localizableStrings.LookupExistedCaption,
					checked: "isNewLookup",
					containerVisible: "isExistLookup",
					tag: false,
					enabled: {bindTo: "isEditMode"},
					items: [createComboBox({
						name: "lookup",
						list: "lookupList",
						prepareList: "prepareLookupList",
						isRequired: true,
						caption: getCaptionByDataValueType(BPMSoft.DataValueType.LOOKUP),
						enabled: {bindTo: "isEditMode"}
					})]
				}),
				createRadioButton({
					name: "newLookup",
					caption: localizableStrings.LookupNewCaption,
					checked: "isNewLookup",
					containerVisible: "isNewLookup",
					tag: true,
					enabled: {bindTo: "isEditMode"},
					items: [createTextEdit({
						name: "lookupCaption",
						caption: localizableStrings.TitleCaption,
						isRequired: true,
						enabled: true
					}),
					createTextEdit({
						name: "lookupName",
						caption: localizableStrings.NameCaption,
						isRequired: true,
						enabled: true
					})]
				}),
				checkBoxContainer,
				createControlGroup("style", ["control-group-container"], controlGroupItems)
			]);
			return view;
		}

		/**
		 * ####### ############# ########## #### ### #### "######".
		 * @private
		 *
		 * @returns {BPMSoft.Container} ############## ############# ########## #### ### #### "######".
		 */
		function createTextView() {
			var checkBoxContainer = createContainer({
				name: "contentContainer",
				classes: ["top-container-margin"]
			});
			var controlGroupItems = {
				className: "BPMSoft.Container",
				id: "styleControlGroupContainer",
				selectors: {
					wrapEl: "#styleControlGroupContainer"
				},
				items: [
					createCheckBox({
						name: "hideCaption",
						caption: localizableStrings.HideLookupCaptionLabel
					}),
					createComboBox({
						name: "textSize",
						caption: localizableStrings.TextSizeLabel,
						list: "textSizeList",
						prepareList: "prepareTextSize",
						enabled: true
					})
				]
			};
			checkBoxContainer.add([
				createCheckBox({
					name: "multiLine",
					caption: localizableStrings.IsMultilineCaption
				}),
				createCheckBox({
					name: "require",
					caption: localizableStrings.IsRequiredCaption
				}),
				createCheckBox({
					name: "readOnly",
					caption: localizableStrings.IsReadOnlyCaption
				})
			]);
			var view = createContainer({name: "contentContainer"});
			view.add([
				createTextEdit({
					name: "columnCaption",
					placeholder: "columnCaptionPlaceholder",
					enabled: true,
					isRequired: true,
					caption: localizableStrings.TitleCaption
				}),
				createTextEdit({
					name: "columnName",
					enabled: {bindTo: "isEditMode"},
					bindTo: "columnName",
					isRequired: true,
					caption: localizableStrings.NameCaption
				}),
				createPrefixLabel(),
				createComboBox({
					name: "lineSize",
					list: "lineSizeList",
					prepareList: "prepareLineSize",
					caption: localizableStrings.StringLengthCaption,
					enabled: {bindTo: "isEditMode"}
				}),
				checkBoxContainer,
				createControlGroup("style", ["control-group-container"], controlGroupItems)
			]);
			return view;
		}

		/**
		 * ####### ############# ########## #### ### #### "##### #####".
		 * @private
		 *
		 * @returns {BPMSoft.Container} view ############## ############# ########## #### ### #### #### "##### #####".
		 */
		function createIntegerView() {
			var checkBoxContainer = createContainer({
				name: "checkBoxContainer",
				classes: ["top-container-margin"]
			});
			var controlGroupItems = {
				className: "BPMSoft.Container",
				id: "styleControlGroupContainer",
				selectors: {
					wrapEl: "#styleControlGroupContainer"
				},
				items: [
					createCheckBox({
						name: "hideCaption",
						caption: localizableStrings.HideLookupCaptionLabel
					}),
					createComboBox({
						name: "textSize",
						caption: localizableStrings.TextSizeLabel,
						list: "textSizeList",
						prepareList: "prepareTextSize",
						enabled: true
					})
				]
			};
			checkBoxContainer.add([
				createCheckBox({
					name: "require",
					caption: localizableStrings.IsRequiredCaption
				}),
				createCheckBox({
					name: "readOnly",
					caption: localizableStrings.IsReadOnlyCaption
				})
			]);
			var view = createContainer({name: "contentContainer"});
			view.add([
				createTextEdit({
					name: "columnCaption",
					placeholder: "columnCaptionPlaceholder",
					enabled: true,
					isRequired: true,
					caption: localizableStrings.TitleCaption
				}),
				createTextEdit({
					name: "columnName",
					enabled: {bindTo: "isEditMode"},
					bindTo: "columnName",
					isRequired: true,
					caption: localizableStrings.NameCaption
				}),
				createPrefixLabel(),
				checkBoxContainer,
				createControlGroup("style", ["control-group-container"], controlGroupItems)
			]);
			return view;
		}

		/**
		 * ####### ############# ########## #### ### #### "####### #####".
		 * @private
		 *
		 * @returns {BPMSoft.Container} ############## ############# ########## #### ### #### "####### #####".
		 */
		function createFloatView() {
			var checkBoxContainer = createContainer({
				name: "checkBoxContainer",
				classes: ["top-container-margin"]
			});
			checkBoxContainer.add([
				createCheckBox({
					name: "require",
					caption: localizableStrings.IsRequiredCaption
				}),
				createCheckBox({
					name: "readOnly",
					caption: localizableStrings.IsReadOnlyCaption
				})
			]);
			var controlGroupItems = {
				className: "BPMSoft.Container",
				id: "styleControlGroupContainer",
				selectors: {
					wrapEl: "#styleControlGroupContainer"
				},
				items: [
					createCheckBox({
						name: "hideCaption",
						caption: localizableStrings.HideLookupCaptionLabel
					}),
					createComboBox({
						name: "textSize",
						caption: localizableStrings.TextSizeLabel,
						list: "textSizeList",
						prepareList: "prepareTextSize",
						enabled: true
					})
				]
			};
			var view = createContainer({name: "contentContainer"});
			view.add([
				createTextEdit({
					name: "columnCaption",
					placeholder: "columnCaptionPlaceholder",
					enabled: true,
					isRequired: true,
					caption: localizableStrings.TitleCaption
				}),
				createTextEdit({
					name: "columnName",
					enabled: {bindTo: "isEditMode"},
					bindTo: "columnName",
					isRequired: true,
					caption: localizableStrings.NameCaption
				}),
				createPrefixLabel(),
				createComboBox({
					name: "precision",
					list: "precisionList",
					prepareList: "preparePrecision",
					caption: localizableStrings.FloatTypeCaption,
					enabled: {bindTo: "isEditMode"}
				}),
				checkBoxContainer,
				createControlGroup("style", ["control-group-container"], controlGroupItems)
			]);
			return view;
		}

		/**
		 * ####### ############# ########## #### ### #### "####".
		 * @private
		 *
		 * @returns {BPMSoft.Container} ############## ############# ########## #### ### #### "####".
		 */
		function createDateView() {
			var checkBoxContainer = createContainer({
				name: "checkBoxContainer",
				classes: ["top-container-margin"]
			});
			checkBoxContainer.add([
				createCheckBox({
					name: "require",
					caption: localizableStrings.IsRequiredCaption
				}),
				createCheckBox({
					name: "readOnly",
					caption: localizableStrings.IsReadOnlyCaption
				})
			]);
			var controlGroupItems = {
				className: "BPMSoft.Container",
				id: "styleControlGroupContainer",
				selectors: {
					wrapEl: "#styleControlGroupContainer"
				},
				items: [
					createCheckBox({
						name: "hideCaption",
						caption: localizableStrings.HideLookupCaptionLabel
					}),
					createComboBox({
						name: "textSize",
						caption: localizableStrings.TextSizeLabel,
						list: "textSizeList",
						prepareList: "prepareTextSize",
						enabled: true
					})
				]
			};
			var view = createContainer({name: "contentContainer"});
			view.add([
				createTextEdit({
					name: "columnCaption",
					placeholder: "columnCaptionPlaceholder",
					enabled: true,
					isRequired: true,
					caption: localizableStrings.TitleCaption
				}),
				createTextEdit({
					name: "columnName",
					enabled: {bindTo: "isEditMode"},
					bindTo: "columnName",
					isRequired: true,
					caption: localizableStrings.NameCaption
				}),
				createPrefixLabel(),
				createComboBox({
					name: "format",
					list: "formatList",
					prepareList: "prepareFormatList",
					caption: localizableStrings.DateTypeCaption,
					enabled: {bindTo: "isEditMode"}
				}),
				checkBoxContainer,
				createControlGroup("style", ["control-group-container"], controlGroupItems)
			]);
			return view;
		}

		/**
		 * ####### ############# ########## #### ### #### "##########".
		 * @private
		 *
		 * @returns {BPMSoft.Container} ############## ############# ########## #### ### #### "##########".
		 */
		function createBoolView() {
			var checkBoxContainer = createContainer({
				name: "contentContainer",
				classes: ["top-container-margin"]
			});
			checkBoxContainer.add([
				createCheckBox({
					name: "readOnly",
					caption: localizableStrings.IsReadOnlyCaption
				})
			]);
			var controlGroupItems = {
				className: "BPMSoft.Container",
				id: "styleControlGroupContainer",
				selectors: {
					wrapEl: "#styleControlGroupContainer"
				},
				items: [
					createCheckBox({
						name: "hideCaption",
						caption: localizableStrings.HideLookupCaptionLabel
					}),
					createComboBox({
						name: "textSize",
						caption: localizableStrings.TextSizeLabel,
						list: "textSizeList",
						prepareList: "prepareTextSize",
						enabled: true
					})
				]
			};
			var view = createContainer({name: "contentContainer"});
			view.add([
				createTextEdit({
					name: "columnCaption",
					placeholder: "columnCaptionPlaceholder",
					enabled: true,
					isRequired: true,
					caption: localizableStrings.TitleCaption
				}),
				createTextEdit({
					name: "columnName",
					enabled: {bindTo: "isEditMode"},
					bindTo: "columnName",
					isRequired: true,
					caption: localizableStrings.NameCaption
				}),
				checkBoxContainer,
				createPrefixLabel(),
				createControlGroup("style", ["control-group-container"], controlGroupItems)
			]);
			return view;
		}

		/**
		 * ####### ############# ########## #### ### ###### ############ #######.
		 * @private
		 *
		 * @returns {BPMSoft.Container} ############## ############# ########## #### ### ###### ############ #######.
		 */
		function createExistingColumnView() {
			var view = createContainer({name: "contentContainer"});
			view.add([
				{
					id: "objectNameLabel",
					className: "BPMSoft.Label",
					selectors: {wrapEl: "#objectNameLabel"},
					caption: {bindTo: "objectName"}
				}, {
					id: "column",
					className: "BPMSoft.Label",
					caption: localizableStrings.Column,
					selectors: {wrapEl: "#column"}
				}, {
					className: "BPMSoft.ComboBoxEdit",
					id: "columns",
					selectors: {wrapEl: "#columns"},
					value: {bindTo: "existColumnName"},
					list: {bindTo: "columnList"},
					prepareList: {bindTo: "prepareColumnList"},
					markerValue: "columnName"
				}
			]);
			return view;
		}

		var existingColumnCallback;
		var existingColumnScope;

		/**
		 * ####### ######### #### ### ###### ############ #######.
		 *
		 * @param {Object} schema #####.
		 * @param {Function} callback ####### ######### ######.
		 * @param {BPMSoft.BaseViewModel} scope ###### ############# #########.
		 */
		function showExistingColumnWindow(schema, callback, scope) {
			existingColumnCallback = callback;
			existingColumnScope = scope;
			var container = ModalBox.show({
				widthPixels: "550px",
				heightPixels: "670px"
			});
			var view = createMainView();
			view.add(createExistingColumnView());
			ModalBox.setSize(550, 250);
			viewModel = generateExistingColumnViewModel(schema);
			viewModel.set("schema", schema);
			viewModel.set("pvm", this);
			viewModel.set("objectName", schema.entitySchema.caption);
			view.bind(viewModel);
			view.render(container);
		}

		/**
		 * ####### ###### ############# #### ### ###### ############ #######.
		 * @private
		 *
		 * @returns {BPMSoft.BaseViewModel} ###############  ###### #############.
		 */
		function generateExistingColumnViewModel() {
			var viewModelConfig = {
				columns: {
					schema: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					headerCaption: {
						type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					existColumnName: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						isRequired: true
					},
					objectName: {
						type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					columnList: {
						dataValueType: BPMSoft.DataValueType.ENUM,
						isCollection: true
					}
				},
				values: {
					columnList: new BPMSoft.Collection(),
					schema: null,
					headerCaption: localizableStrings.SelectColumn
				},
				methods: {
					onSaveClick: existingColumnSave,
					onCancelClick: onCancelClick,
					prepareColumnList: prepareColumnList
				}
			};
			viewModel = Ext.create("BPMSoft.BaseViewModel", viewModelConfig);
			return viewModel;
		}

		/**
		 * ####### ########## ######## ############ #######.
		 */
		function existingColumnSave() {
			var columnName = this.get("existColumnName");
			existingColumnCallback.call(existingColumnScope, columnName);
			ModalBox.close();
		}

		/**
		 * ####### ######## ########## #### ### ######## ##### #######.
		 * @param {BPMSoft.DataValueType} config.dataValueType - ### ####.
		 * @param {BPMSoft.BaseEntitySchema} config.entitySchema - ##### ########.
		 * @param {Object} config.column - #######.
		 */
		function showNewColumnWindow(config) {
			entityColumnConfig = config;
			var container = ModalBox.show({
				widthPixels: "550px",
				heightPixels: "670px"
			});
			var view = createMainView();
			var type = parseInt(config.dataValueType, 10);
			switch (type) {
				case BPMSoft.DataValueType.TEXT:
					view.add(createTextView());
					ModalBox.setSize(550, 575);
					break;
				case BPMSoft.DataValueType.INTEGER:
					view.add(createIntegerView());
					ModalBox.setSize(550, 495);
					break;
				case BPMSoft.DataValueType.FLOAT:
				case BPMSoft.DataValueType.MONEY:
					view.add(createFloatView());
					ModalBox.setSize(550, 545);
					break;
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.TIME:
				case BPMSoft.DataValueType.DATE_TIME:
					view.add(createDateView());
					ModalBox.setSize(550, 545);
					break;
				case BPMSoft.DataValueType.LOOKUP:
					view.add(createLookupView());
					ModalBox.setSize(550, 735);
					break;
				case BPMSoft.DataValueType.BOOLEAN:
					view.add(createBoolView());
					ModalBox.setSize(550, 455);
					break;
				default:
					view.add(createBoolView());
					ModalBox.setSize(550, 455);
					break;
			}
			viewModel = createNewColumnViewModel(config.entitySchema, type, config.schema);
			viewModel.set("entityColumn", config.column);
			viewModel.set("readOnly", config.readOnly);
			entityColumnType = ColumnHelper.GetTypeByDataValueType(config.column.dataValueType);
			if (!config.isNew) {
				setViewModelValues(config, viewModel);
				viewModel.set("headerCaption", localizableStrings.Column);
			} else {
				var textSize = {
					value: 2,
					displayValue: localizableStrings.DefaultCaption
				};
				var dateFormat = {
					value: "DateTime",
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.DATE_TIME)
				};
				viewModel.set("textSize", textSize);
				viewModel.set("format", dateFormat);
				viewModel.set("headerCaption", localizableStrings.NewColumnWindowHeaderCaption);
			}
			subscribeEvents();
			view.bind(viewModel);
			view.render(container);
		}

		/**
		 * ####### ######## ###### ############# #### ### ########## ##### #######.
		 * @param {Object} entitySchema ##### ########.
		 * @param {BPMSoft.DataValueType} type ### ###### #######.
		 * @param {Object} schema ##### ########.
		 * @returns ########## ############## ###### #############.
		 */
		function createNewColumnViewModel(entitySchema, type, schema) {
			var viewModelConfig = {
				entitySchema: entitySchema,
				columns: {
					entityColumn: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					columnCaption: {
						type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					},
					columnCaptionPlaceholder: {
						type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: false
					},
					columnName: {
						type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					},
					hideCaption: {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
					textSizeList: {
						dataValueType: BPMSoft.DataValueType.ENUM,
						isCollection: true
					},
					textSize: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.LOOKUP
					},
					require: {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
					readOnly: {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
					headerCaption: {
						type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					isEditMode: {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					}
				},
				values: {
					entityColumn: null,
					columnCaption: null,
					columnCaptionPlaceholder: null,
					columnName: null,
					hideCaption: false,
					textSizeList: new BPMSoft.Collection(),
					textSize: null,
					require: false,
					headerCaption: false,
					isEditMode: true,
					lineSizeList: new BPMSoft.Collection(),
					lineSize: null,
					multiLine: false,
					precisionList: new BPMSoft.Collection(),
					precision: null,
					formatList: new BPMSoft.Collection(),
					format: null,
					isNewLookup: false,
					isExistLookup: true,
					lookup: null,
					lookupList: new BPMSoft.Collection(),
					lookupCaption: null,
					lookupName: null,
					isListView: false,
					isFireEvent: false
				},
				validationConfig: {
					columnName: [
						function(value) {
							var isEditMode = this.get("isEditMode");
							if (!isEditMode) {
								return {
									invalidMessage: ""
								};
							}
							var result = SectionDesignerUtils.validateSystemName(value, {
								maxLength: 30
							});
							if (!result.isValid) {
								return {
									invalidMessage: result.invalidMessage
								};
							}
							var prefix = SectionDesignerUtils.getSchemaNamePrefix();
							if (prefix) {
								if (!SectionDesignerUtils.validateNamePrefix(value)) {
									value = prefix + value;
								}
							}
							var schemaItem = getSchemaItemInfoByName(value, schema.viewConfig);
							var columns = this.entitySchema.columns;
							var duplicateInList = false;
							BPMSoft.each(columns, function(item, key) {
								if (key === value) {
									duplicateInList = true;
								}
							}, this);
							var invalidMessage = (!schemaItem && !duplicateInList)
								? {invalidMessage: ""}
								: {invalidMessage: localizableStrings.DuplicatedItemNameMessage};
							return invalidMessage;
						}
					]
				},
				methods: {
					onSaveClick: onSaveClick,
					onCancelClick: onCancelClick,
					prepareTextSize: prepareTextSize,
					setViewModelValues: setViewModelValues,
					prepareLineSize: prepareLineSize,
					preparePrecision: preparePrecision,
					prepareFormatList: prepareFormatList,
					subscribeEvents: subscribeEvents,
					prepareLookupList: prepareLookupList
				}
			};
			var config = getViewModelConfigByDataValueType(type);
			Ext.apply(viewModelConfig.columns, config.columns);
			if (!viewModelConfig.validationConfig) {
				viewModelConfig.validationConfig = config.validationConfig;
			} else {
				Ext.apply(viewModelConfig.validationConfig, config.validationConfig);
			}
			viewModel = Ext.create("BPMSoft.BaseViewModel", viewModelConfig);
			return viewModel;
		}

		/**
		 * ############# ###### # ###### ###### # ###.
		 * @private
		 */
		function setDataValueTypesStorage() {
			var cachedConfig = storage.getItem("SectionDesigner_DataValueTypes");
			if (!cachedConfig) {
				SectionDesignerUtils.postServiceRequest({
					methodName: "GetDataValueTypes",
					callback: function(request, success, response) {
						if (success) {
							var typesConfig =
								BPMSoft.decode(response.responseText).GetDataValueTypesResult.DataValueTypeInfoList;
							storage.setItem("SectionDesigner_DataValueTypes", BPMSoft.encode(typesConfig));
						}
					}
				});
			}
		}

		/**
		 * ######## ######### ## #### ### #######.
		 * @private
		 * @param {BPMSoft.DataValueType} dataValueType ######## ####.
		 * @param {Number} subTypeValue ######## ######## ####### (Size ### Precision).
		 * @return {String} ######### #### ### #######.
		 */
		function getCaptionByDataValueType(dataValueType, subTypeValue) {
			var typesConfig = BPMSoft.decode(storage.getItem("SectionDesigner_DataValueTypes"));
			if (!typesConfig) {
				return null;
			}
			var typeItem = getItemByAttribute(typesConfig, dataValueType, "DataValueType");
			if (!typeItem) {
				return null;
			}
			if (this.Ext.isEmpty(subTypeValue)) {
				return typeItem.Caption;
			}
			var subTypesConfig = typeItem.DataValueSubTypeInfo;
			if (!subTypesConfig) {
				return null;
			}
			var subTypeItem;
			if (dataValueType === BPMSoft.DataValueType.TEXT) {
				subTypeItem = getItemByAttribute(subTypesConfig, subTypeValue, "Size");
				return subTypeItem.Caption;
			} else if (dataValueType === BPMSoft.DataValueType.FLOAT) {
				subTypeItem = getItemByAttribute(subTypesConfig, subTypeValue, "Precision");
				return subTypeItem.Caption;
			} else {
				return null;
			}
		}

		/**
		 * ######## ####### ## ###### ## ######## # ########.
		 * @private
		 * @param {Array} arr ####### #####.
		 * @param {Number} value ######## ######## ####### (Size ### Precision).
		 * @param {String} attr A###### #### ### #######.
		 * @return {Object} ####### ######.
		 */
		function getItemByAttribute(arr, value, attr) {
			var itemConf = null;
			BPMSoft.each(arr, function(item) {
				if (item[attr] === value) {
					itemConf = item;
					return false;
				}
			});
			return itemConf;
		}

		/**
		 * ####### ######### ###### ###### ############# # ########### ## #### ###### #######.
		 * @param {BPMSoft.DataValueType} dataValueType - ### ###### #######
		 */
		function getViewModelConfigByDataValueType(dataValueType) {
			var maxEntitySchemaNameLength;
			SectionDesignerUtils.getMaxEntitySchemaNameLength(function(maxSchemaNameLengthValue) {
				maxEntitySchemaNameLength = maxSchemaNameLengthValue;
			});
			var config = {};
			switch (dataValueType) {
				case BPMSoft.DataValueType.TEXT:
					config.columns = {
						lineSizeList: {
							dataValueType: BPMSoft.DataValueType.ENUM,
							isCollection: true
						},
						lineSize: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							dataValueType: BPMSoft.DataValueType.LOOKUP
						},
						multiLine: {
							dataValueType: BPMSoft.DataValueType.BOOLEAN
						}
					};
					break;
				case BPMSoft.DataValueType.FLOAT:
				case BPMSoft.DataValueType.MONEY:
					config.columns = {
						precisionList: {
							dataValueType: BPMSoft.DataValueType.ENUM,
							isCollection: true
						},
						precision: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							dataValueType: BPMSoft.DataValueType.LOOKUP
						}
					};
					break;
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.TIME:
				case BPMSoft.DataValueType.DATE_TIME:
					config.columns = {
						formatList: {
							dataValueType: BPMSoft.DataValueType.ENUM,
							isCollection: true
						},
						format: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							dataValueType: BPMSoft.DataValueType.LOOKUP
						}
					};
					break;
				case BPMSoft.DataValueType.LOOKUP:
					config.columns = {
						isNewLookup: {
							dataValueType: BPMSoft.DataValueType.BOOLEAN
						},
						isExistLookup: {
							dataValueType: BPMSoft.DataValueType.BOOLEAN
						},
						lookup: {
							dataValueType: BPMSoft.DataValueType.LOOKUP,
							isLookup: true,
							referenceSchema: {
								name: "VwSysEntitySchemaInWorkspace",
								primaryColumnName: "Id",
								primaryDisplayColumnName: "Name"
							},
							referenceSchemaName: "VwSysEntitySchemaInWorkspace"
						},
						lookupList: {
							isCollection: true,
							name: "lookupList",
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						},
						lookupCaption: {
							type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
							dataValueType: BPMSoft.DataValueType.TEXT
						},
						lookupName: {
							type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
							dataValueType: BPMSoft.DataValueType.TEXT
						},
						isListView: {
							dataValueType: BPMSoft.DataValueType.BOOLEAN
						},
						likeNames: {
							dataValueType: BPMSoft.DataValueType.ENUM,
							isCollection: true
						}
					};

					config.validationConfig = {
						lookupName: [
							function(value) {
								var isNewLookup = this.get("isNewLookup");
								if (isNewLookup && Ext.isEmpty(value)) {
									return {
										invalidMessage: localizableStrings.InvalidRequireMessage
									};
								}
								return {
									invalidMessage: ""
								};
							},
							function(value) {
								var isNewLookup = this.get("isNewLookup");
								if (!isNewLookup) {
									return {
										invalidMessage: ""
									};
								}
								var valid = SectionDesignerUtils.validateNamePrefix(value);
								if (!valid) {
									var invalidMessage = Ext.String.format(localizableStrings.WrongPrefixMessage,
										SectionDesignerUtils.getSchemaNamePrefix());
									return {
										invalidMessage: invalidMessage
									};
								}
								return {
									invalidMessage: ""
								};
							},
							function(value) {
								var result = SectionDesignerUtils.validateSystemName(value, {
									maxLength: maxEntitySchemaNameLength
								});

								var invalidMessage = localizableStrings.WrongSchemaNameMessage;
								if (!result.isValid) {
									return {
										invalidMessage: invalidMessage
									};
								}
								return {
									invalidMessage: ""
								};
							},
							function(value) {
								var likeNames = this.get("likeNames");
								var invalidMessage = localizableStrings.WrongMessageExistSchem;
								if (likeNames) {
									if (likeNames.length > 0) {
										if (likeNames.indexOf(value) !== -1) {
											return {
												invalidMessage: invalidMessage
											};
										}
									}
								}
								return {
									invalidMessage: ""
								};
							}
						],
						lookupCaption: [
							function(value) {
								var isNewLookup = this.get("isNewLookup");
								if (isNewLookup && Ext.isEmpty(value)) {
									return {
										invalidMessage: localizableStrings.InvalidRequireMessage
									};
								}
								return {
									invalidMessage: ""
								};
							}
						],
						lookup: [
							function(value) {
								var isExistLookup = this.get("isExistLookup");
								if (isExistLookup && Ext.isEmpty(value)) {
									return {
										invalidMessage: localizableStrings.InvalidRequireMessage
									};
								}
								return {
									invalidMessage: ""
								};
							}
						]
					};
					break;
			}
			return config;
		}

		/**
		 * ####### ######### ######## # ###### ############# ### ############## #######.
		 * @param {Object} config - ###### ############# #######
		 * @param {BPMSoft.BaseViewModel} viewModel - ###### #############
		 */
		function setViewModelValues(config, viewModel) {
			viewModel.set("hasConverter", false);
			viewModel.set("columnName", config.column.name, {preventValidation: true});
			var designerViewModel = config.scope;
			var itemConfig = designerViewModel.getSchemaItemInfoByName(config.itemName);
			var itemCaption = itemConfig.item.caption;
			if (itemCaption && itemCaption.bindConfig && itemCaption.bindConfig.converter) {
				viewModel.set("hasConverter", true);
				viewModel.set("columnCaptionPlaceholder", localizableStrings.BusinessLogicMessage);
			} else {
				viewModel.set("columnCaption", config.column.caption);
			}
			setConverterFlag(itemConfig.item);
			if (config.dataValueType === BPMSoft.DataValueType.TEXT) {
				var lineSize;
				if (Ext.isObject(config.column.size)) {
					lineSize = config.column.size;
				} else {
					lineSize = {
						value: config.column.size || 0,
						displayValue: getDisplayValueLineSize(config.column.size)
					};
				}
				viewModel.set("lineSize", lineSize);
			}
			if (!Ext.isEmpty(config.contentType)) {
				switch (config.contentType) {
					case 0:
						viewModel.set("multiLine", true);
						break;
					case 3:
						viewModel.set("isListView", true);
						break;
					default:
						viewModel.set("multiLine", false);
						viewModel.set("isListView", false);
						break;
				}
			}

			viewModel.set("require", config.column.isRequired);
			viewModel.set("readOnly", config.readOnly);
			var precision;
			if	(Ext.isObject(config.column.precision)) {
				precision = config.column.precision;
			} else {
				precision = {
					value: config.column.precision,
					displayValue: getDisplayValuePrecision(config.column.precision)
				};
			}
			viewModel.set("precision", precision);
			var format = getDateFormatByDataValueType(config.dataValueType);
			viewModel.set("format", format);
			var hideCaption = (config.labelConfig.visible === false);
			viewModel.set("hideCaption", hideCaption);
			var textSize = getTextSizeByValue(config.textSize);
			viewModel.set("textSize", textSize);
			function entitySchemaCallback(schema) {
				viewModel.set("lookup", {
					value: schema.uId,
					displayValue: schema.caption,
					name: schema.name
				});
				BPMSoft.Mask.hide(maskId);
			}

			if (config.column.referenceSchema) {
				var maskId;

				var referenceSchemaName = config.column.referenceSchemaName;
				if (!referenceSchemaName) {
					var schema = config.column.referenceSchema;
					viewModel.set("lookup", {
						value: schema.uId,
						displayValue: schema.caption,
						name: schema.name
					});
				} else {
					var element = ModalBox.getFixedBox();
					var elementSelector = "#" + element.id;
					maskId = BPMSoft.Mask.show({
						selector: elementSelector
					});
					SectionDesignDataModule.getEntitySchemaByName({
						name: referenceSchemaName,
						callback: entitySchemaCallback
					});
				}
			}

			var callback = function(value) {
				viewModel.set("isEditMode", value);
			};
			SectionDesignerUtils.isExistColumn({
				schemaName: config.entitySchema.name,
				name: config.column.name,
				callback: callback
			});
		}

		/**
		 * ############# ####### ##########, #### ####### ######## ######## "converter".
		 * @param {Object} obj ########### ######.
		 * @return {Boolean} ########## true, #### ######## #######.
		 */
		function setConverterFlag(obj) {
			BPMSoft.each(obj, function(item, key) {
				if (Ext.isObject(item)) {
					setConverterFlag(item, "converter");
				}
				if (key === "converter") {
					viewModel.set("hasConverter", true);
					return false;
				}
			}, this);
		}

		function getTextSizeByValue(value) {
			var textSize = {};
			switch (value) {
				case BPMSoft.TextSize.STANDARD:
					textSize = {
						value: BPMSoft.TextSize.STANDARD,
						displayValue: localizableStrings.StandardTextSizeCaption
					};
					break;
				case BPMSoft.TextSize.LARGE:
					textSize = {
						value: BPMSoft.TextSize.LARGE,
						displayValue: localizableStrings.LargeTextSizeCaption
					};
					break;
				default:
					textSize = {
						value: "Default",
						displayValue: localizableStrings.DefaultCaption
					};
					break;
			}
			return textSize;
		}

		/**
		 * ####### ############ ###### ######### ######### ######## ### ####### #### "####### #####".
		 * @param {Number} value - ########.
		 * @returns ########## ###### ## ########### ######## ### ######### # ########## ######.
		 */
		function getDisplayValuePrecision(value) {
			var displayValue = getCaptionByDataValueType(BPMSoft.DataValueType.FLOAT, value);
			return displayValue;
		}

		/**
		 * ####### ############ ###### ######### ######### ##### ###### ### ####### #### "######".
		 * @param {String} value - ########.
		 * @returns ########## ###### ## ########### ######## ### ######### # ########## ######.
		 */
		function getDisplayValueLineSize(value) {
			var displayValue = getCaptionByDataValueType(BPMSoft.DataValueType.TEXT, value);
			return displayValue;
		}

		function prepareColumnList() {
			var collection = this.get("columnList");
			var schema = this.get("schema");
			collection.clear();
			var columnCollection = Ext.create("BPMSoft.Collection");
			BPMSoft.each(schema.entitySchema.columns, function(item) {
				if (item.usageType !== 0 ||
					item.dataValueType === BPMSoft.DataValueType.GUID ||
					item.dataValueType === BPMSoft.DataValueType.BLOB ||
					item.dataValueType === BPMSoft.DataValueType.IMAGE ||
					item.dataValueType === BPMSoft.DataValueType.CUSTOM_OBJECT ||
					item.dataValueType === BPMSoft.DataValueType.IMAGELOOKUP ||
					item.dataValueType === BPMSoft.DataValueType.COLLECTION ||
					item.dataValueType === BPMSoft.DataValueType.COLOR) {
					return;
				}
				var columnConfig = {
					value: item.name,
					displayValue: item.caption
				};
				columnCollection.add(item.name, columnConfig);
			});
			if (schema.attributes) {
				BPMSoft.each(schema.attributes, function(item) {
					if (!columnCollection.find(item.name)) {
						var columnConfig = {
							value: item.name,
							displayValue: item.caption || item.name
						};
						columnCollection.add(item.name, columnConfig);
					}
				});
			}
			collection.loadAll(columnCollection);
		}

		function prepareLookupList() {
			var lookupCollection = viewModel.get("lookupList");
			lookupCollection.clear();
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "VwSysEntitySchemaInWorkspace"
			});
			select.isDistinct = true;
			select.addColumn("UId");
			select.addColumn("Caption");
			select.addColumn("Name");
			select.filters.add(getLookupFilters());
			select.getEntityCollection(function(result) {
				if (result.success) {
					var collection = Ext.create("BPMSoft.Collection");
					var items = result.collection.collection.items;
					BPMSoft.each(items, function(item) {
						var config = {
							value: item.values.UId,
							name: item.values.Name,
							displayValue: item.values.Caption
						};
						collection.add(item.values.Id, config);
					});
					lookupCollection.loadAll(collection);
				}
			}, this);
		}

		function getLookupFilters() {
			var filterCollection = BPMSoft.createFilterGroup();
			filterCollection.add("SysWorkspaceId", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "SysWorkspace", BPMSoft.SysValue.CURRENT_WORKSPACE.value));
			filterCollection.add("ExtendParent", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "ExtendParent", false));
			return filterCollection;
		}

		function subscribeEvents() {
			viewModel.on("change:isNewLookup", onSwitchLookup, this);
		}

		var isFireEvent = false;
		function onSwitchLookup() {
			var value = arguments[1];
			//var isFireEvent = viewModel.get("isFireEvent");
			if (isFireEvent) {
				viewModel.set("isExistLookup", !value);
			} else {
				isFireEvent = true;
				viewModel.set("isNewLookup", !value);
				viewModel.set("isExistLookup", value);
			}
		}

		function prepareTextSize() {
			var collection = this.get("textSizeList");
			collection.clear();
			var sizes = {
				"Default": {
					value: 2,
					displayValue: localizableStrings.DefaultCaption
				},
				"LARGE": {
					value: BPMSoft.TextSize.LARGE,
					displayValue: localizableStrings.LargeTextSizeCaption
				},
				"STANDARD": {
					value: BPMSoft.TextSize.STANDARD,
					displayValue: localizableStrings.StandardTextSizeCaption
				}
			};
			collection.loadAll(sizes);
		}

		function prepareFormatList() {
			var collection = this.get("formatList");
			collection.clear();
			var formats = {
				"DateTime": {
					value: "DateTime",
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.DATE_TIME)
				},
				"Date": {
					value: "Date",
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.DATE)
				},
				"Time": {
					value: "Time",
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.TIME)
				}
			};
			collection.loadAll(formats);
		}

		function preparePrecision() {
			var collection = this.get("precisionList");
			collection.clear();
			var precisions = {
				"1": {
					value: 1,
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.FLOAT, 1)
				},
				"2": {
					value: 2,
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.FLOAT, 2)
				},
				"3": {
					value: 3,
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.FLOAT, 3)
				},
				"4": {
					value: 4,
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.FLOAT, 4)
				}
			};
			collection.loadAll(precisions);
		}

		function prepareLineSize() {
			var collection = this.get("lineSizeList");
			collection.clear();
			var sizes = {
				"50": {
					value: 50,
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.TEXT, 50)
				},
				"250": {
					value: 250,
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.TEXT, 250)
				},
				"500": {
					value: 500,
					displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.TEXT, 500)
				}
			};
			var maxSize = getMaxSizeForString();
			sizes[maxSize] = {
				value: maxSize,
				displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.TEXT, maxSize)
			};
			collection.loadAll(sizes);
		}

		/**
		 * Returns value for max size of string (0 in oracle or -1 in mssql).
		 * @return {Number} Returns value for max size of string.
		 * @private
		 */
		function getMaxSizeForString() {
			var typesConfig = BPMSoft.decode(storage.getItem("SectionDesigner_DataValueTypes"));
			var typeItem = getItemByAttribute(typesConfig, BPMSoft.DataValueType.TEXT, "DataValueType");
			var subTypesConfig = typeItem.DataValueSubTypeInfo;
			var maxSize;
			for (var i = 0; i < subTypesConfig.length; i++) {
				if (subTypesConfig[i].Size === 0 || subTypesConfig[i].Size === -1) {
					maxSize = subTypesConfig[i].Size;
					break;
				}
			}
			return maxSize;
		}

		/**
		 * ########## ####### ####### ## ###### ##########.
		 * @private
		 */
		function onSaveClick() {
			var hasConverter = this.get("hasConverter");
			if (hasConverter && viewModel.validate()) {
				BPMSoft.utils.showMessage({
					caption: localizableStrings.SaveColumnWarning,
					buttons: ["Yes", "No"],
					defaultButton: 0,
					style: BPMSoft.MessageBoxStyles.ORANGE,
					handler: function(val) {
						if (val === "no") {
							ModalBox.close();
							MaskHelper.HideBodyMask();
						} else if (val === "yes") {
							saveColumn.call(this);
						}
					}
				});
			} else {
				saveColumn.call(this);
			}
		}

		/**
		 * ########## ####### ####### ## ###### ##########.
		 * @private
		 */
		function saveColumn() {
			var entityColumn = viewModel.get("entityColumn");
			MaskHelper.ShowBodyMask();
			var lookupName = viewModel.get("lookupName");
			var self = this;
			if (lookupName && entityColumn.isNew) {
				SectionDesignDataModule.loadLikeSchemaNames(lookupName, function(codeLikeSchema) {
					self.set("likeNames", codeLikeSchema);
					if (self.validate()) {
						var entityColumn = self.get("entityColumn");
						generateItemConfig(entityColumn);
						ModalBox.close();
					}
				});
			} else {
				if (!viewModel.validate()) {
					MaskHelper.HideBodyMask();
					return;
				}
				generateItemConfig(entityColumn);
				ModalBox.close();
			}
			MaskHelper.HideBodyMask();
		}

		function generateItemConfig(entityColumn) {
			var name = viewModel.get("columnName");
			var caption = viewModel.get("columnCaption");
			var designerViewModel = entityColumnConfig.scope;
			var captionResourceName = "Resources.Strings." + name + "Caption";
			designerViewModel.set(captionResourceName, caption, {"columnName": captionResourceName});
			var prefix = SectionDesignerUtils.getSchemaNamePrefix();
			if (entityColumn.isNew && !Ext.isEmpty(prefix)) {
				if (!SectionDesignerUtils.validateNamePrefix(name)) {
					name = prefix + name;
				}
			}
			entityColumn.name = name;
			entityColumn.caption = caption;
			entityColumn.isRequired = viewModel.get("require");
			entityColumn.usageType = ConfigurationEnums.EntitySchemaColumnUsageType.General;
			var extColumnConfig = {};
			var textSize = viewModel.get("textSize");
			if (!textSize || textSize.value === 2) {
				textSize = 0;
			} else {
				textSize = textSize.value;
			}
			var itemConfig = {
				caption: {
					bindTo: captionResourceName
				},
				labelConfig: {
					visible: !viewModel.get("hideCaption")
				},
				readOnly: viewModel.get("readOnly"),
				textSize: textSize
			};
			var type = parseInt(entityColumn.dataValueType, 10);
			var value;
			switch (type) {
				case BPMSoft.DataValueType.TEXT:
					var size = viewModel.get("lineSize");
					if (!size) {
						value = 250;
					} else {
						value = size.value;
					}
					if (value !== 0) {
						extColumnConfig = {
							size: value
						};
					}
					var multiLine = viewModel.get("multiLine");
					itemConfig.contentType = (multiLine) ? BPMSoft.ContentType.LONG_TEXT :
						BPMSoft.ContentType.SHORT_TEXT;
					break;
				case BPMSoft.DataValueType.FLOAT:
					var precision = viewModel.get("precision");
					if (!precision) {
						value = 2;
					} else {
						value = precision.value;
					}
					extColumnConfig = {
						precision: value
					};
					break;
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.TIME:
				case BPMSoft.DataValueType.DATE_TIME:
					var dataValueType = viewModel.get("format");
					if (!dataValueType) {
						entityColumn.dataValueType = BPMSoft.DataValueType.DATE_TIME;
					} else {
						entityColumn.dataValueType = getDataValueTypeFromBaseDataType(dataValueType.value);
					}
					break;
				case BPMSoft.DataValueType.LOOKUP:
					var isNewLookup = viewModel.get("isNewLookup");
					var referenceSchemaName = viewModel.get("lookupName");
					var referenceSchemaCaption = viewModel.get("lookupCaption");
					if (isNewLookup) {
						extColumnConfig = {
							referenceSchema: {},
							referenceSchemaName: referenceSchemaName,
							referenceSchemaCaption: referenceSchemaCaption
						};
						SectionDesignDataModule.createEntitySchema({
							name: referenceSchemaName,
							caption: referenceSchemaCaption,
							rootEntitySchema: BaseLookup
						});
					} else {
						var lookup = viewModel.get("lookup");
						var reference = entityColumn.referenceSchema || {};
						var referenceSchemaUid = lookup.value;
						Ext.apply(reference, {
							uId: referenceSchemaUid,
							name: lookup.name,
							caption: lookup.displayValue
						});
						extColumnConfig = {
							referenceSchema: reference,
							referenceSchemaName: lookup.name,
							referenceSchemaCaption: "",
							referenceSchemaUid: referenceSchemaUid
						};
					}
					var isListView = viewModel.get("isListView");
					itemConfig.contentType = (isListView) ? BPMSoft.ContentType.ENUM :
						BPMSoft.ContentType.LOOKUP;
					break;
			}
			Ext.apply(entityColumn, extColumnConfig);
			Ext.apply(entityColumnConfig, itemConfig);
			entityColumnConfig.callback.call(entityColumnConfig.scope, entityColumnConfig);
		}

		function getDataValueTypeFromBaseDataType(baseDataType) {
			switch (baseDataType) {
				case "DateTime":
					return BPMSoft.DataValueType.DATE_TIME;
				case "Date":
					return BPMSoft.DataValueType.DATE;
				case "Time":
					return BPMSoft.DataValueType.TIME;
			}
			return null;
		}

		function getDateFormatByDataValueType(dataValueType) {
			var format;
			switch (dataValueType) {
				case BPMSoft.DataValueType.DATE_TIME:
					format = {
						value: "DateTime",
						displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.DATE_TIME)
					};
					break;
				case BPMSoft.DataValueType.DATE:
					format = {
						value: "Date",
						displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.DATE)
					};
					break;
				case BPMSoft.DataValueType.TIME:
					format = {
						value: "Time",
						displayValue: getCaptionByDataValueType(BPMSoft.DataValueType.TIME)
					};
					break;
			}
			return format;
		}

		function onCancelClick() {
			ModalBox.close();
		}

		function generateEntityColumnByDataValueType(dataValueType) {
			return {
				isNew: true,
				uId: BPMSoft.generateGUID(),
				name: "",
				caption: "",
				dataValueType: dataValueType,
				isLookup: dataValueType === BPMSoft.DataValueType.LOOKUP ||
					dataValueType === BPMSoft.DataValueType.ENUM,
				isRequired: false
			};
		}

		/**
		 * ####### ######## ###### ############# #### ########## ### ############## ######.
		 * @param {Object} groupConfig ################ ###### ######.
		 * @param {String} groupConfig.name ### ######.
		 * @param {String} groupConfig.caption ######### ######.
		 * @returns {BPMSoft.BaseViewModel} ############### ###### #############.
		 */
		function createGroupWindowViewModel(groupConfig) {
			var viewModel;
			var cfg = {
				values: {
					headerCaption: localizableStrings.GroupHeaderCaption,
					GroupCaption: groupConfig.caption
				},
				methods: {
					onSaved: Ext.emptyFn,

					/**
					 * ########## ####### ####### ## ###### "#########".
					 * @private
					 */
					onSaveClick: function() {
						var validation = this.validate();
						if (!validation) {
							return;
						}
						var group = {
							caption: this.get("GroupCaption"),
							name: groupConfig.name
						};
						this.onSaved(group);
						ModalBox.close();
					},

					/**
					 * ########## ####### ####### ## ###### "########".
					 * @private
					 */
					onCancelClick: function() {
						ModalBox.close();
					}
				}
			};
			viewModel = Ext.create("BPMSoft.BaseViewModel", cfg);
			return viewModel;
		}

		/**
		 * ####### ######## ############# #### ########## ### ############## ######.
		 * @returns {BPMSoft.Container} ############### ############# ####.
		 */
		function createGroupWindowView() {
			var view;
			var headerContainer = createHeaderContainer();
			var cfg = {
				className: "BPMSoft.Container",
				id: "groupMainContainer",
				selectors: {
					el: "#groupMainContainer",
					wrapEl: "#groupMainContainer"
				},
				classes: {
					wrapClassName: ["mainContainer"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "captionContainer",
						selectors: {
							wrapEl: "#captionContainer"
						},
						classes: {
							wrapClassName: ["captionContainer"]
						},
						items: headerContainer
					},
					{
						className: "BPMSoft.Container",
						id: "contentContainer",
						selectors: {
							wrapEl: "#contentContainer"
						},
						classes: {
							wrapClassName: ["contentContainer"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "GroupNameLabeledContainer",
								selectors: {
									wrapEl: "#GroupNameLabeledContainer"
								},
								classes: {
									wrapClassName: ["base-element"]
								},
								items: [
									{
										className: "BPMSoft.Label",
										id: "GroupNameControlLabel",
										caption: localizableStrings.TitleCaption,
										classes: {labelClass: ["base-element-left"]}
									},
									{
										className: "BPMSoft.TextEdit",
										id: "GroupNameControl",
										markerValue: "groupName",
										classes: {
											wrapClass: ["base-element-right"]
										},
										value: {bindTo: "GroupCaption"}
									}
								]
							}
						]
					}
				]
			};
			view = Ext.create("BPMSoft.Container", cfg);
			return view;
		}

		/**
		 * ####### ######## ########## #### ########## ### ############## ######.
		 * @param {BPMSoft.BaseViewModel} scope ###### ############# ######### ########.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} groupConfig ################ ###### ######.
		 * @param {String} groupConfig.name - ### ######.
		 * @param {String} groupConfig.caption - ######### ######.
		 */
		function showEditGroupWindow(scope, callback, groupConfig) {
			var name = groupConfig.name || "group";
			var caption = groupConfig.caption || null;
			var groupConf = {
				name: name,
				caption: caption
			};
			var vm = createGroupWindowViewModel(groupConf);
			vm.onSaved = function(group) {
				callback.call(scope, group);
			};
			var view = createGroupWindowView();
			var modalBoxConfig = {};
			modalBoxConfig.container = ModalBox.show({
				widthPixels: 550,
				heightPixels: 200
			});
			view.bind(vm);
			view.render(modalBoxConfig.container);
		}

		/**
		 * ####### ######## ###### ############# #### ########## ### ############## ######.
		 * @param {Object} parentSchema C#### ######### ########.
		 * @returns {BPMSoft.BaseViewModel} ############### ###### #############.
		 */
		function createDetailWindowViewModel(parentSchema) {
			var viewModel;
			var cfg = {
				values: {
					headerCaption: localizableStrings.DetailHeaderCaption,
					parentSchema: parentSchema,
					detailCaption: null,
					selectedDetailName: null,
					selectedDetailColumn: null,
					selectedCurrentEntityColumn: null,
					detailNamesList: new BPMSoft.Collection(),
					detailColumnsList: new BPMSoft.Collection(),
					currentEntityColumnsList: new BPMSoft.Collection(),
					detailKey: null
				},
				columns: {
					"selectedDetailName": {
						isRequired: true
					},
					"selectedDetailColumn": {
						isRequired: true
					},
					"selectedCurrentEntityColumn": {
						isRequired: true
					}
				},
				validationConfig: {
					"selectedDetailName": [
						function(value) {
							return this.getValidationConfig(value);
						}
					],
					"selectedDetailColumn": [
						function(value) {
							return this.getValidationConfig(value);
						}
					],
					"selectedCurrentEntityColumn": [
						function(value) {
							return this.getValidationConfig(value);
						}
					]
				},
				methods: {
					/**
					 * ####### ######### ############ ##########
					 * @private
					 * @returns {Object} ########## ################ ###### ##########
					 */
					getValidationConfig: function(value) {
						return Ext.Object.isEmpty(value)
							? {invalidMessage: localizableStrings.ValidatorInfo}
							: {invalidMessage: ""};
					},

					/**
					 * ####### ######### ###### ####### ## #### ######.
					 * @private
					 * @param {Object} filter ######
					 * @param {BPMSoft.Collection} list ######### ########### ###### #### #######.
					 * @param {Object} addConf ################ ######.
					 * @param {Function} addConf.completeDetailConfig ####### ######### ###### ### ##########
					 * ################# ####### ######.
					 * @param {Object} addConf.selectedDetailConf ################ ###### ######### ######.
					 */
					getDetailNamesList: function(filter, list, addConf) {
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "SysDetail"
						});
						select.isDistinct = true;
						var primaryDisplayColumn = Ext.create("BPMSoft.EntityQueryColumn", {
							columnPath: "Caption",
							orderDirection: BPMSoft.OrderDirection.ASC,
							orderPosition: 0
						});
						select.addColumn(primaryDisplayColumn, "Caption");
						select.addColumn("Id");
						select.addColumn("DetailSchemaUId");
						select.addColumn("EntitySchemaUId");
						select.addColumn("[VwSysSchemaInfo:UId:DetailSchemaUId].Name", "Name");
						select.addColumn("[SysSchema:UId:EntitySchemaUId].Name", "SchemaName");
						select.getEntityCollection(function(result) {
							if (result.success) {
								if (!addConf) {
									this.fillDetailNamesList(result, filter, list);
								} else {
									var callback = addConf.completeDetailConfig;
									var selectedDetailConf = addConf.selectedDetailConf;
									callback.call(this, result, selectedDetailConf);
								}
							}
						}, this);
					},

					/**
					 * ####### ########## ######### ########### ###### #### #######.
					 * @private
					 * @param {BPMSoft.Collection} response ######### ####### ####### ## #### ######.
					 * @param {Object} filter ######.
					 * @param {BPMSoft.Collection} list ######### ########### ###### #### #######.
					 */
					fillDetailNamesList: function(response, filter, list) {
						var detailNamesArray = response.collection.collection.items;
						if (list === null) {
							return;
						}
						list.clear();
						var columns = {};
						BPMSoft.each(detailNamesArray, function(detailItem) {
							var id = detailItem.get("Id");
							var caption = detailItem.get("Caption");
							var entitySchemaUId = detailItem.get("EntitySchemaUId");
							var entitySchemaName = detailItem.get("SchemaName");
							var detailName = detailItem.get("Name");
							var item = {
								displayValue: caption,
								detailCaption: caption,
								value: id,
								detailName: detailName,
								entitySchemaUId: entitySchemaUId,
								entitySchemaName: entitySchemaName
							};
							columns[id] = item;
							if (!list.contains(id)) {
								columns[id] = item;
							}
						}, this);
						list.loadAll(columns);
					},

					/**
					 * ####### ########## ###### ####### ######### ######.
					 * @private
					 * @param {Object} filter ######.
					 * @param {BPMSoft.Collection} list ######### ########### ###### #### #######.
					 */
					getDetailColumnsList: function(filter, list) {
						var selectedDetailName = this.get("selectedDetailName");
						var entitySchemaUId = selectedDetailName && selectedDetailName.entitySchemaUId;
						if (!entitySchemaUId || list === null) {
							return;
						}
						var config = {
							id: entitySchemaUId,
							callback: function(entitySchema) {
								var entitySchemaColumns = entitySchema.columns;
								var columns = {};
								list.clear();
								BPMSoft.each(entitySchemaColumns, function(item) {
									var it = {
										displayValue: item.caption,
										value: item.name
									};
									if (!list.contains(item.name)) {
										columns[item.name] = it;
									}
								}, this);
								list.loadAll(columns);
							},
							scope: this
						};
						SectionDesignDataModule.getEntitySchemaByUId(config);
					},

					/**
					 * ######### ####### ## ######.
					 * @private
					 * @param {Object} selectedDetail ###### ######### ######.
					 * @return {Boolean} ########## true #### ###### #######, false - # ######## ######.
					 */
					checkOrDetailSelected: function(selectedDetail) {
						return !Ext.isEmpty(selectedDetail);
					},

					/**
					 * ####### ########## ###### ####### ######## #######.
					 * @private
					 * @param {Object} filter ######.
					 * @param {BPMSoft.Collection} list ######### ########### ###### #### #######.
					 */
					getCurrentEntityColumnsList: function(filter, list) {
						if (list === null) {
							return;
						}
						var entitySchemaColumns = this.get("parentSchema").entitySchema.columns;
						var columns = {};
						list.clear();
						BPMSoft.each(entitySchemaColumns, function(item) {
							var it = {
								displayValue: item.caption,
								value: item.name
							};
							if (!list.contains(item.name)) {
								columns[item.name] = it;
							}
						}, this);
						list.loadAll(columns);
					},

					onSaved: Ext.emptyFn,

					/**
					 * ########## ####### ####### ## ###### "#########".
					 * @private
					 */
					onSaveClick: function() {
						var validation = this.validate();
						if (!validation) {
							return;
						}
						var detail = {};
						var selectedDetail = this.get("selectedDetailName");
						var detailColumn = this.get("selectedDetailColumn").value;
						var masterColumn = this.get("selectedCurrentEntityColumn").value;
						detail.entitySchema = selectedDetail.entitySchemaName;
						detail.name = selectedDetail.detailName;
						detail.caption = this.get("detailCaption");
						detail.filter = {
							detailColumn: detailColumn,
							masterColumn: masterColumn
						};
						detail.detailKey = this.get("detailKey");
						this.createDetailGridSettings(selectedDetail, function(gridSettings) {
							detail.gridSettings = gridSettings;
							this.onSaved(detail);
							ModalBox.close();
						}, this);
					},

					/**
					 * ####### ######### ####### ######.
					 * @private
					 * @param {Object} selectedDetail ######.
					 * @param {Function} callback ####### ######### ######.
					 * @param {Function} scope ######## ###### ####### ######### ######.
					 */
					createDetailGridSettings: function(selectedDetail, callback, scope) {
						BPMSoft.require([selectedDetail.entitySchemaName], function(entitySchema) {
							var columnName = entitySchema.primaryDisplayColumnName || entitySchema.primaryColumnName;
							var entitySchemaColumns = entitySchema.columns;
							var column = entitySchemaColumns[columnName];
							var parentSchema = this.get("parentSchema");
							var parentSchemaName = parentSchema.schemaName;
							var detailName = selectedDetail.detailName;
							if (!detailName || !parentSchemaName) {
								callback.call(scope);
								return;
							}
							var profileKey = parentSchemaName + detailName;
							var columnConfig = {
								bindTo: columnName,
								caption: column.caption,
								captionConfig: {
									visible: true
								},
								orderDirection: BPMSoft.OrderDirection.ASC,
								orderPosition: 1,
								position: {
									column: 0,
									colSpan: 24,
									row: 1
								}
							};
							var gridSettings = {
								key: profileKey,
								data: BPMSoft.encode({
									key: profileKey,
									isCollapsed: false,
									DataGrid: {
										isTiled: false,
										type: BPMSoft.GridType.LISTED,
										key: profileKey,
										listedConfig: BPMSoft.encode({
											items: [
												columnConfig
											]
										}),
										tiledConfig: BPMSoft.encode({
											grid: {
												columns: 24,
												rows: 1
											},
											items: [
												columnConfig
											]
										})
									}
								}),
								isDef: true
							};
							callback.call(scope, gridSettings);
						}, this);
					},

					/**
					 * ########## ####### ####### ## ###### "########".
					 * @private
					 */
					onCancelClick: function() {
						ModalBox.close();
					},

					/**
					 * ####### ######### ######### #### "####### #######".
					 * @private
					 */
					getCurrentEntityCaption: function() {
						var schema = this.get("parentSchema");
						var objCaption = schema.entitySchema.caption;
						return localizableStrings.DetailObjectColumnCaption + " '" + objCaption + "'";
					}
				}
			};
			viewModel = Ext.create("BPMSoft.BaseViewModel", cfg);
			viewModel.on("change:selectedDetailName", function(val) {
				var detail = val.get("selectedDetailName");
				if (!detail) {
					return;
				}
				var detailCaption = detail.detailCaption;
				this.set("detailCaption", detailCaption);
				this.set("detailColumnsList", new BPMSoft.Collection());
				this.set("selectedDetailColumn", null);
			}, viewModel);
			return viewModel;
		}

		/**
		 * ####### ######## ############# #### ########## ### ############## ######.
		 * @param {Object} config ################ ###### ############# #### ######.
		 * @param {Boolean} config.isCaptionEditable ####### ####, ### ######### #############.
		 * @returns {BPMSoft.Container} ############## ############# ####.
		 */
		function createDetailWindowView(config) {
			if (!config) {
				config = {};
			}
			var view;
			var headerContainer = createHeaderContainer();
			var cfg = {
				className: "BPMSoft.Container",
				id: "detailMainContainer",
				selectors: {
					el: "#detailMainContainer",
					wrapEl: "#detailMainContainer"
				},
				classes: {
					wrapClassName: ["mainContainer"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "captionContainer",
						selectors: {
							wrapEl: "#captionContainer"
						},
						classes: {
							wrapClassName: ["captionContainer"]
						},
						items: headerContainer
					},
					{
						className: "BPMSoft.Container",
						id: "contentContainer",
						selectors: {
							wrapEl: "#contentContainer"
						},
						classes: {
							wrapClassName: ["contentContainer"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "DetailNameLabeledContainer",
								selectors: {
									wrapEl: "#DetailNameLabeledContainer"
								},
								classes: {
									wrapClassName: ["base-element"]
								},
								items: [
									{
										className: "BPMSoft.Label",
										id: "DetailNameControlLabel",
										caption: localizableStrings.DetailNameCaption,
										classes: {labelClass: ["base-element-left"]},
										isRequired: true
									},
									{
										className: "BPMSoft.ComboBoxEdit",
										id: "DetailNameControl",
										list: {
											bindTo: "detailNamesList"
										},
										prepareList: {
											bindTo: "getDetailNamesList"
										},
										value: {
											bindTo: "selectedDetailName"
										},
										classes: {
											wrapClass: ["base-element-right"]
										},
										markerValue: "detailName"
									}
								]
							}, {
								className: "BPMSoft.Container",
								id: "CaptionLabeledContainer",
								selectors: {
									wrapEl: "#CaptionLabeledContainer"
								},
								classes: {
									wrapClassName: ["base-element"]
								},
								items: [
									{
										className: "BPMSoft.Label",
										id: "CaptionControlLabel",
										caption: localizableStrings.TitleCaption,
										classes: {labelClass: ["base-element-left"]}
									},
									{
										className: "BPMSoft.TextEdit",
										id: "CaptionControl",
										classes: {wrapClass: ["base-element-right"]},
										value: {bindTo: "detailCaption"},
										readonly: (config.isCaptionEditable !== true)
									}
								]
							}, {
								className: "BPMSoft.Container",
								id: "DetailColumnLabeledContainer",
								selectors: {
									wrapEl: "#DetailColumnLabeledContainer"
								},
								classes: {
									wrapClassName: ["base-element"]
								},
								items: [
									{
										className: "BPMSoft.Label",
										id: "DetailColumnControlLabel",
										caption: localizableStrings.DetailColumnsCaption,
										classes: {labelClass: ["base-element-left"]},
										isRequired: true
									},
									{
										className: "BPMSoft.ComboBoxEdit",
										id: "DetailColumnControl",
										list: {bindTo: "detailColumnsList"},
										prepareList: {bindTo: "getDetailColumnsList"},
										value: {bindTo: "selectedDetailColumn"},
										enabled: {
											bindTo: "selectedDetailName",
											bindConfig: {converter: "checkOrDetailSelected"}
										},
										classes: {wrapClass: ["base-element-right"]},
										markerValue: "detailColumnName"
									}
								]
							}, {
								className: "BPMSoft.Container",
								id: "ObjectColumnLabeledContainer",
								selectors: {
									wrapEl: "#ObjectColumnLabeledContainer"
								},
								classes: {
									wrapClassName: ["base-element"]
								},
								items: [
									{
										className: "BPMSoft.Label",
										id: "ObjectColumnControlLabel",
										caption: {bindTo: "getCurrentEntityCaption"},
										classes: {labelClass: ["base-element-left"]},
										isRequired: true
									}, {
										className: "BPMSoft.ComboBoxEdit",
										id: "ObjectColumnControl",
										classes: {
											wrapClass: ["base-element-right"]
										},
										value: {bindTo: "selectedCurrentEntityColumn"},
										list: {bindTo: "currentEntityColumnsList"},
										prepareList: {bindTo: "getCurrentEntityColumnsList"},
										markerValue: "objectColumnName"
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "ActionsContainer",
								selectors: {
									wrapEl: "#ActionsContainer"
								},
								classes: {
									wrapClassName: ["actions-container"]
								},
								items: [
									{
										id: "saveButton",
										className: "BPMSoft.Button",
										caption: localizableStrings.SaveButtonCaption,
										style: BPMSoft.controls.ButtonEnums.style.ORANGE,
										tag: "saveButton",
										markerValue: "saveButton",
										selectors: {wrapEl: "#saveButton"},
										click: {bindTo: "onSaveClick"}
									}, {
										className: "BPMSoft.Button",
										id: "cancelButton",
										markerValue: "cancelButton",
										selectors: {wrapEl: "#cancelButton"},
										caption: localizableStrings.CancelButtonCaption,
										tag: "cancelButton",
										click: {bindTo: "onCancelClick"}
									}
								]
							}
						]
					}
				]
			};
			view = Ext.create("BPMSoft.Container", cfg);
			return view;
		}

		/**
		 * ####### ######## ########## #### ########## ### ############## ######.
		 * @param {BPMSoft.BaseViewModel} scope ###### ############# ######### ########.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} selectedDetailConf ################ ###### ######### ######.
		 * @param {String} selectedDetailConf.detailKey - ### ######.
		 * @param {String} selectedDetailConf.detailSchemaName - ### ##### ######.
		 * @param {String} selectedDetailConf.detailColumn - ####### ####### ######.
		 * @param {String} selectedDetailConf.masterColumn - ####### ######## #######.
		 * @param {Object} windowViewConfig ################ ###### ############# #### ######.
		 */
		function showEditDetailWindow(scope, callback, selectedDetailConf, windowViewConfig) {
			var parentSchema = scope.get("schema");
			var vm = createDetailWindowViewModel(parentSchema);
			vm.onSaved = function(detail) {
				callback.call(scope, detail);
			};
			var view = createDetailWindowView(windowViewConfig);
			var modalBoxConfig = {};
			modalBoxConfig.container = ModalBox.show({
				widthPixels: 550,
				heightPixels: 471
			});
			view.bind(vm);
			view.render(modalBoxConfig.container);
			if (!selectedDetailConf) {
				return;
			}
			vm.set("detailKey", selectedDetailConf.detailKey);
			var addConf = {
				completeDetailConfig: completeDetailConfig,
				selectedDetailConf: selectedDetailConf
			};
			vm.getDetailNamesList(null, vm.get("detailNamesList"), addConf);
			var masterSchemaName = scope.get("schema").entitySchemaName;
			var config = {
				name: masterSchemaName,
				callback: function(entitySchema) {
					if (!selectedDetailConf.masterColumn) {
						return;
					}
					var selectedMasterColumnCaption = entitySchema.columns[selectedDetailConf.masterColumn].caption;
					var selectedMasterColumn = {
						value: selectedDetailConf.masterColumn,
						displayValue: selectedMasterColumnCaption,
						customHtml: selectedDetailConf.masterColumn
					};
					vm.set("selectedCurrentEntityColumn", selectedMasterColumn);
				}
			};
			SectionDesignDataModule.getEntitySchemaByName(config);
		}

		/**
		 * ####### ############ ##### ################# ####### ### ######### ###### ## ###### ####### ## #### ######.
		 * @param {BPMSoft.Collection} list ####### #### #######.
		 * @param {Object} selectedDetailConf ################ ###### ######### ######.
		 * @param {String} selectedDetailConf.id ########## ############# ########.
		 * @param {String} selectedDetailConf.detailSchemaName ### ##### ######### ######.
		 * @param {String} selectedDetailConf.detailCaption ######### ######### ######.
		 * @param {String} selectedDetailConf.entitySchemaUId UId ####### ######.
		 * @param {String} selectedDetailConf.entitySchemaName ### #####.
		 * @param {String} selectedDetailConf.displayValue ######### ###### # ########## ######.
		 */
		function completeDetailConfig(list, selectedDetailConf) {
			var items = list.collection.collection.items;
			var detailSchemaName = selectedDetailConf.detailSchemaName;
			var entitySchemaName = selectedDetailConf.entitySchemaName;
			BPMSoft.each(items, function(item) {
				var values = item.values;
				if (values.Name === detailSchemaName && values.SchemaName === entitySchemaName) {
					if (Ext.isEmpty(selectedDetailConf.detailCaption)) {
						selectedDetailConf.detailCaption = item.values.Caption;
					}
					selectedDetailConf.displayValue = values.Caption;
					selectedDetailConf.entitySchemaUId = values.EntitySchemaUId;
					selectedDetailConf.id = item.get("Id");
					setSelectedDetailFields(selectedDetailConf, this);
					return false;
				}
			}, this);
		}

		/**
		 * ####### ######### ##### ###### # #######  ###### ############# ### ######### ######.
		 * @param {Object} selectedDetailConf ################ ###### ######### ######.
		 * @param {String} selectedDetailConf.entitySchemaUId UId ####### ######### ######.
		 * @param {String} selectedDetailConf.detailSchemaName ### ##### ######### ######.
		 * @param {String} selectedDetailConf.detailCaption ######### ######### ######.
		 * @param {String} selectedDetailConf.detailColumn ####### ######.
		 * @param {String} selectedDetailConf.masterColumn ####### ######## #######.
		 * @param {BPMSoft.BaseViewModel} vm ###### ############# ########## ####.
		 */
		function setSelectedDetailFields(selectedDetailConf, vm) {
			var config = {
				id: selectedDetailConf.entitySchemaUId,
				callback: function(entitySchema) {
					var selectedDetail = {
						value: selectedDetailConf.id,
						displayValue: selectedDetailConf.displayValue,
						detailName: selectedDetailConf.detailSchemaName,
						detailCaption: selectedDetailConf.detailCaption,
						entitySchemaUId: entitySchema.uId,
						entitySchemaName: selectedDetailConf.entitySchemaName
					};
					vm.set("selectedDetailName", selectedDetail);
					if (!selectedDetailConf.detailColumn) {
						return;
					}
					var selectedDetailColumnCaption = entitySchema.columns[selectedDetailConf.detailColumn].caption;
					var selectedDetailColumn = {
						value: selectedDetailConf.detailColumn,
						displayValue: selectedDetailColumnCaption,
						customHtml: selectedDetailConf.detailColumn
					};
					vm.set("selectedDetailColumn", selectedDetailColumn);
				},
				scope: this
			};
			SectionDesignDataModule.getEntitySchemaByUId(config);
		}

		/**
		 * ####### ######## ###### ############# ####.
		 * @param {Object} item ################ ###### ########.
		 * @param {String} item.caption ######## ####### #########.
		 * @param {String} item.name ######## ####### ###.
		 * @param {Number} item.position ####### ####.
		 * @param {Function} onEdit ####### ######### ###### ############## ####.
		 * @param {Function} onDelete ####### ######### ###### ######## ####.
		 * @param {BPMSoft.BaseViewModel} scope ###### ############# ####.
		 * @param {Boolean} extendedMode ####### ############ ######.
		 * @param {Boolean} showCode ####### ########### ####### "###".
		 * @returns {BPMSoft.BaseViewModel} resultViewModel ############### ###### #############.
		 */
		function createRowViewModel(item, onEdit, onDelete, scope, extendedMode, showCode) {
			var config = {
				values: {
					caption: item.caption || item.name,
					name: item.name || null,
					visible: true,
					allowDelete: true,
					position: item.position,
					extendedMode: extendedMode || false,
					showCode: showCode || false,
					windowViewModel: scope
				},
				methods: {
					onItemClick: onEdit,
					onItemDeleteButtonClick: onDelete,

					/**
					 * ####### ######### ######## ##### # ######### ######## ####.
					 * @private
					 * @returns {Object} ###### ## ########## ##### # #########.
					 */
					getValue: function() {
						return {
							caption: this.get("caption"),
							name: this.get("name")
						};
					},

					/**
					 * ####### ######### ####### ######## ####.
					 * @private
					 * @returns {Number} ####### ######## ####.
					 */
					getPosition: function() {
						return this.get("position");
					},

					/**
					 * ####### ######### ############# ####.
					 * @private
					 * @returns {BPMSoft.Container} ############# ####.
					 */
					getView: function() {
						var view;
						var uid = "i-" + BPMSoft.generateGUID();
						var config = {
							id: uid + "-ItemContainer",
							selectors: {
								wrapEl: "#" + uid + "-ItemContainer"
							},
							classes: {
								wrapClassName: ["tab-item-container"]
							},
							visible: {
								bindTo: "visible"
							},
							items: [
								{
									id: uid + "-ItemLabelContainer",
									className: "BPMSoft.Container",
									selectors: {
										wrapEl: "#" + uid + "-ItemLabelContainer"
									},
									classes: {
										wrapClassName: ["tab-item-left-container"]
									},
									items: [
										{
											className: "BPMSoft.Label",
											classes: {
												labelClass: "cell-left"
											},
											caption: {
												bindTo: "caption"
											},
											markerValue: {bindTo: "caption"},
											click: {
												bindTo: "onItemClick"
											}
										},
										{
											className: "BPMSoft.Label",
											classes: {
												labelClass: "cell-right"
											},
											caption: {
												bindTo: "name"
											},
											visible: {
												bindTo: "showCode"
											},
											click: {
												bindTo: "onItemClick"
											}
										}
									]
								},
								{
									id: uid + "-ItemButtonsContainer",
									className: "BPMSoft.Container",
									selectors: {
										wrapEl: "#" + uid + "-ItemButtonsContainer"
									},
									classes: {
										wrapClassName: ["tab-item-right-container"]
									},
									items: [
										{
											className: "BPMSoft.Button",
											imageConfig: localizableImages.CloseIcon,
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											classes: {
												wrapperClass: ["tab-delete-button", "tab-float-right"]
											},
											visible: {bindTo: "allowDelete"},
											click: {bindTo: "onItemDeleteButtonClick"}
										}
									]
								}
							],
							afterrender: {bindTo: "onVisualized"},
							afterrerender: {bindTo: "onVisualized"}
						};
						view = Ext.create("BPMSoft.Container", config);
						return view;
					},

					/**
					 * ####### ######### ####.
					 * @private
					 */
					visualize: function() {
						var windowViewModel = this.get("windowViewModel");
						var tabListContainer = windowViewModel.get("tabListContainer");
						if (tabListContainer) {
							var view = this.view;
							var position = this.getPosition();
							if (!view || view.destroyed) {
								view = this.getView();
								this.view = view;
								view.bind(this);
							}
							if (view.rendered) {
								view.reRender(position, tabListContainer.getRenderToEl());
							} else {
								view.render(tabListContainer.getRenderToEl(), position);
							}
						}
					},

					/**
					 * ########## ####### #########.
					 * @private
					 */
					onVisualized: function() {
						var windowViewModel = this.get("windowViewModel");
						var tabsView = windowViewModel.get("rowsView");
						var value = this.get("value");
						if (!tabsView.contains(value)) {
							tabsView.add(value, this.view);
						}
					},

					/**
					 * ########## ####### ######### ####### ####.
					 * @private
					 */
					onPositionChanged: function(model, value) {
						var windowViewModel = this.get("windowViewModel");
						var name = this.get("name");
						var rows = windowViewModel.get("rows");
						if (rows.indexOf(this) !== value) {
							rows.remove(this);
							rows.insert(value, name, this);
						}
					}
				}
			};
			var resultViewModel = Ext.create("BPMSoft.BaseViewModel", config);
			resultViewModel.on("change:position", resultViewModel.onPositionChanged, resultViewModel);
			return resultViewModel;
		}

		/**
		 * ####### ######## ###### ############# ############## ####.
		 * @param {Object} config ################ ###### ############## ####.
		 * @param {BPMSoft.Container} config.renderTo ####### ##########.
		 * @param {Function} config.onApply ####### ######### ###### ### ##########.
		 * @param {Function} config.onPositionChanged ####### ######### ###### ### ######### ####### ####.
		 * @param {Function} config.onViewDestroyed ####### ######### ###### ### ######## #############.
		 * @param {Number} config.position ####### ####.
		 * @param {Object} config.value ################ ###### ####.
		 * @param {Boolean} config.extendedMode ####### ############ ######.
		 * @param {BPMSoft.BaseViewModel} config.scope ###### ############# ####.
		 * @returns {BPMSoft.BaseViewModel} ############### ###### #############.
		 */
		function createEditRowViewModel(config) {
			var viewModel;
			var view;
			var rowConfig = config.value || {};
			var cfg = {
				columns: {
					caption: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					},
					name: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					}
				},
				validationConfig: {
					name: [
						function(value) {
							var isEditMode = this.get("isEditMode");
							var extendedMode = this.get("extendedMode");
							if (isEditMode || !extendedMode) {
								return {invalidMessage: ""};
							}
							var result = SectionDesignerUtils.validateSystemName(value, {
								maxLength: 30
							});
							if (!result.isValid) {
								return {
									invalidMessage: result.invalidMessage
								};
							}
							var windowViewModel = this.get("windowViewModel");
							var designerViewModel = windowViewModel.get("designerViewModel");
							var schemaItem = designerViewModel.getSchemaItemInfoByName(value);
							var rows = windowViewModel.get("rows").getItems();
							var duplicateInList = false;
							BPMSoft.each(rows, function(item) {
								var name = item.values.name;
								if (name === value) {
									duplicateInList = true;
								}
							}, this);
							var invalidMessage = (!schemaItem && !duplicateInList)
								? {invalidMessage: ""}
								: {invalidMessage: localizableStrings.DuplicatedColumnNameMessage};
							return invalidMessage;
						}
					]
				},
				values: {
					view: null,
					caption: rowConfig.caption || rowConfig.name || null,
					name: rowConfig.name || null,
					textEditFocused: false,
					isEditMode: BPMSoft.isEmptyObject(rowConfig) ? false : true,
					position: config.position,
					extendedMode: config.extendedMode || false,
					showCode: config.showCode || false,
					windowViewModel: config.scope
				},
				methods: {
					onApply: config.onApply,
					onViewDestroyed: config.onViewDestroyed,
					onPositionChanged: config.onPositionChanged,

					/**
					 * ####### ######### ############# ############## ####.
					 * @private
					 * @returns {BPMSoft.Container} ############# ############## ####.
					 */
					getView: function() {
						var view;
						var config = {
							id: "itemEditInnerContainer",
							selectors: {
								wrapEl: "#itemEditInnerContainer"
							},
							classes: {
								wrapClassName: ["tab-edit-container"]
							},
							items: [
								{
									id: "itemEditInnerElementContainer",
									className: "BPMSoft.Container",
									selectors: {
										wrapEl: "#itemEditInnerElementContainer"
									},
									classes: {
										wrapClassName: ["tab-edit"]
									},
									items: [
										{
											id: "editRow1",
											className: "BPMSoft.TextEdit",
											classes: {
												wrapClass: ["tab-edit-full"]
											},
											value: {
												bindTo: "caption"
											},
											keydown: {
												bindTo: "onKeyDown"
											},
											focused: {
												bindTo: "textEditFocused"
											},
											enabled: {
												bindTo: "extendedMode"
											},
											markerValue: "captionEdit",
											visible: {
												bindTo: "showCode",
												bindConfig: {
													converter: function(value) {
														return !value;
													}
												}
											}
										},
										{
											id: "editRow2",
											className: "BPMSoft.TextEdit",
											classes: {
												wrapClass: ["tab-edit-left"]
											},
											value: {
												bindTo: "caption"
											},
											keydown: {
												bindTo: "onKeyDown"
											},
											focused: {
												bindTo: "textEditFocused"
											},
											markerValue: "codeEdit",
											visible: {
												bindTo: "showCode"
											}
										},
										{
											className: "BPMSoft.TextEdit",
											classes: {
												wrapClass: ["tab-edit-right"]
											},
											value: {
												bindTo: "name"
											},
											keydown: {
												bindTo: "onKeyDown"
											},
											visible: {
												bindTo: "showCode"
											},
											markerValue: "nameEdit",
											enabled: {
												bindTo: "isEditMode",
												bindConfig: {
													converter: function(value) {
														return !value;
													}
												}
											}
										}
									]
								},
								{
									id: "itemEditInnerButtonsContainer",
									className: "BPMSoft.Container",
									selectors: {
										wrapEl: "#itemEditInnerButtonsContainer"
									},
									classes: {
										wrapClassName: ["tab-buttons"]
									},
									items: [
										{
											className: "BPMSoft.Button",
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											classes: {
												textClass: ["page-type-button", "page-type-padding-left-0px"]
											},
											caption: localizableStrings.SaveButtonCaption,
											click: {
												bindTo: "onItemEditApplyButtonClick"
											},
											markerValue: "saveItemButton"
										},
										{
											className: "BPMSoft.Button",
											caption: localizableStrings.CancelButtonCaption,
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											classes: {
												textClass: ["page-type-button"]
											},
											click: {
												bindTo: "onItemEditCancelButtonClick"
											},
											markerValue: "cancelItemButton"
										},
										{
											className: "BPMSoft.Button",
											caption: localizableStrings.DownButtonCaption,
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											classes: {
												textClass: [
													"page-type-button",
													"page-type-float-right",
													"page-type-padding-right-0px"
												]
											},
											click: {
												bindTo: "onItemEditDownButtonClick"
											},
											enabled: {
												bindTo: "isItemEditDownButtonEnabled"
											},
											markerValue: "downItemButton"
										},
										{
											className: "BPMSoft.Button",
											caption: localizableStrings.UpButtonCaption,
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											classes: {
												textClass: ["page-type-button", "page-type-float-right"]
											},
											click: {
												bindTo: "onItemEditUpButtonClick"
											},
											enabled: {
												bindTo: "isItemEditUpButtonEnabled"
											},
											markerValue: "upItemButton"
										}
									]
								}
							],
							destroy: {
								bindTo: "internalOnViewDestroyed"
							},
							afterrender: {
								bindTo: "onViewRendered"
							}
						};
						view = Ext.create("BPMSoft.Container", config);
						return view;
					},

					/**
					 * ########## ####### ####### ## ###### ###### ##############.
					 * @private
					 */
					onItemEditCancelButtonClick: function() {
						this.get("view").destroy();
						ModalBox.updateSizeByContent();
					},

					/**
					 * ########## ####### ########### #############.
					 * @private
					 */
					internalOnViewDestroyed: function() {
						if (this.onViewDestroyed) {
							this.onViewDestroyed();
						}
					},

					/**
					 * ########## ####### ####### ## ###### ########## ############## ####.
					 * @private
					 */
					onItemEditApplyButtonClick: function() {
						var caption = this.get("caption");
						var name = this.get("name");
						if (this.validate()) {
							if (this.onApply) {
								this.onApply({
									caption: caption,
									name: name
								});
							}
							this.onItemEditCancelButtonClick();
							ModalBox.updateSizeByContent();
						}
					},

					/**
					 * Event handler for generated view.
					 * @private
					 */
					onViewRendered: function() {
						this.set("textEditFocused", true);
						var isEditMode = this.get("isEditMode");
						if (!isEditMode) {
							this.set("name", this.generateTabName());
						}
					},

					/**
					 * Returns generated tab code.
					 * @private
					 * @returns {String} Generated tab code.
					*/
					generateTabName: function() {
						var windowViewModel = this.get("windowViewModel");
						var currentObjectName = windowViewModel.get("currentObjectName");
						var tabStr = "Tab";
						var pattern = "^" + currentObjectName + "[0-9]+" + tabStr + "$";
						var regExp = new RegExp(pattern);
						var rows = windowViewModel.get("rows");
						var maxIndex = 0;
						rows.filterByFn(function(row) {
							var value = row.getValue();
							return regExp.test(value.name);
						}).each(function(row) {
							var value = row.getValue();
							var name = value.name;
							var currentIndex = parseInt(name.substring(currentObjectName.length,
								name.length - tabStr.length), 10);
							if (currentIndex > maxIndex) {
								maxIndex = currentIndex;
							}
						});
						maxIndex++;
						var generatedName = currentObjectName + maxIndex + tabStr;
						return generatedName;
					},

					/**
					 * ########## ####### ####### ###### ##########.
					 * @private
					 */
					onKeyDown: function(e) {
						var key = e.getKey();
						switch (key) {
							case e.ESC:
								this.onItemEditCancelButtonClick();
								break;
							case e.ENTER:
								this.onItemEditApplyButtonClick();
								break;
							default:
								break;
						}
					},

					/**
					 * ########## ####### ####### ## ###### "#####".
					 * @private
					 */
					onItemEditUpButtonClick: function() {
						var position = this.get("position") - 1;
						this.changePosition(position);
					},

					/**
					 * ########## ####### ####### ## ###### "####".
					 * @private
					 */
					onItemEditDownButtonClick: function() {
						var position = this.get("position") + 1;
						this.changePosition(position);
					},

					/**
					 * ########## ####### ######### #######.
					 * @private
					 */
					changePosition: function(position) {
						this.set("position", position);
						this.get("view").reRender(position);
					},

					/**
					 * ####### ############ ######## ## ###### "#####".
					 * @private
					 * @returns {Boolean} ######## ## ######.
					 */
					isItemEditUpButtonEnabled: function() {
						return this.get("position") > 0;
					},

					/**
					 * ####### ############ ######## ## ###### "####".
					 * @private
					 * @returns {Boolean} ######## ## ######.
					 */
					isItemEditDownButtonEnabled: function() {
						var windowViewModel = this.get("windowViewModel");
						var rows = windowViewModel.get("rows");
						return this.get("position") + 1 < rows.getCount();
					}
				}
			};
			viewModel = Ext.create("BPMSoft.BaseViewModel", cfg);
			view = viewModel.getView();
			view.bind(viewModel);
			view.render(config.renderTo, config.position);
			viewModel.set("view", view);
			return viewModel;
		}

		/**
		 * ####### ######## ###### ############# #### ########## ### ############## #######.
		 * @param {Array} tabsConf ###### ########.
		 * @param {Boolean} extendedMode ####### ############ ######.
		 * @param {Boolean} showCode ####### ########### ####### "###".
		 * @param {Object} addConfig ################ ######.
		 * @param {String} addConfig.tabCaption ######### ####### #######.
		 * @param {String} addConfig.currentObjectName ### ######## #######.
		 * @returns {BPMSoft.BaseViewModel} ############### ###### #############.
		 */
		function createTabsWindowViewModel(tabsConf, extendedMode, showCode, addConfig) {
			var viewModel;
			var tabCaption;
			var currentObjectName;
			if (addConfig) {
				tabCaption = addConfig.tabCaption;
				currentObjectName = addConfig.currentObjectName;
			}
			var cfg = {
				values: {
					headerCaption: tabCaption || localizableStrings.TabsHeaderCaption,
					rows: new BPMSoft.Collection(),
					rowsView: new BPMSoft.Collection(),
					editRowViewModel: null,
					addItemContainer: null,
					tabListContainer: null,
					currentObjectName: currentObjectName || null,
					extendedMode: extendedMode || false,
					showCode: showCode || false,
					activePosition: null
				},
				methods: {
					/**
					 * ####### ########## ######### ######.
					 * @private
					 */
					fillRowsCollection: function() {
						var rows = this.get("rows");
						BPMSoft.each(tabsConf, function(item) {
							var tabViewModel = this.getRowViewModel(item);
							rows.add(item.name, tabViewModel);
						}, this);
					},

					/**
					 * ########## ####### ####### ## ###### ##########.
					 * @private
					 */
					onAddItemButtonClick: function() {
						if (this.get("editRowViewModel")) {
							var vm = this.get("editRowViewModel");
							vm.get("view").destroy();
						}
						var extendedMode = this.get("extendedMode");
						var showCode = this.get("showCode");
						var addItemContainer = this.get("addItemContainer");
						this.set("editRowViewModel",
							createEditRowViewModel({
								renderTo: addItemContainer.getRenderToEl(),
								onApply: this.onAddItemApplyButtonClick,
								extendedMode: extendedMode,
								showCode: showCode,
								scope: this
							})
						);
						ModalBox.updateSizeByContent();
					},

					/**
					 * ####### ######### ########## ########## ########.
					 * @private
					 */
					setAddItemContainer: function() {
						this.set("addItemContainer", Ext.getCmp("addItemContainer"));
					},

					/**
					 * ####### ####### ########## ########## ########.
					 * @private
					 */
					clearAddItemContainer: function() {
						this.set("addItemContainer", null);
					},

					/**
					 * ####### ######### ########## ###### ########.
					 * @private
					 */
					setTabListContainer: function() {
						this.set("tabListContainer", Ext.getCmp("tabListContainer"));
						var rows = this.get("rows");
						rows.each(function(row) {
							row.visualize();
						});
					},

					/**
					 * ####### ####### ########## ###### ########.
					 * @private
					 */
					clearTabListContainer: function() {
						this.set("tabListContainer", null);
					},

					/**
					 * ######### ###### ############# ####.
					 * @private
					 * @param {Object} value ######## ####.
					 */
					getRowViewModel: function(value) {
						var onEditApply = function(item) {
							rowViewModel.set("caption", item.caption);
							rowViewModel.set("name", item.name);
							rowViewModel.set("position", this.get("position"));
							ModalBox.updateSizeByContent();
						};
						var onViewDestroyed = function() {
							rowViewModel.set("visible", true);
							rowViewModel.visualize();
						};
						var onPositionChanged = function(item) {
							rowViewModel.set("position", item.position);
						};
						var onEdit = function() {
							this.view.destroy();
							var windowViewModel = this.get("windowViewModel");
							var rows = windowViewModel.get("rows");
							var currentPosition = rows.indexOf(this);
							this.set("position", currentPosition);
							var value = this.getValue();
							var renderPosition = this.getPosition();
							var extendedMode = windowViewModel.get("extendedMode");
							var showCode = windowViewModel.get("showCode");
							var tabListContainer = windowViewModel.get("tabListContainer");
							var prevVm = windowViewModel.get("editRowViewModel");
							if (prevVm) {
								prevVm.get("view").destroy();
							}
							windowViewModel.set("editRowViewModel",
								createEditRowViewModel({
									renderTo: tabListContainer.getRenderToEl(),
									onApply: onEditApply,
									onPositionChanged: onPositionChanged,
									onViewDestroyed: onViewDestroyed,
									position: renderPosition,
									value: value,
									extendedMode: extendedMode,
									showCode: showCode,
									scope: windowViewModel
								})
							);
							ModalBox.updateSizeByContent();
						};
						var onDelete = function() {
							var windowViewModel = this.get("windowViewModel");
							windowViewModel.get("rows").remove(this);
							ModalBox.updateSizeByContent();
						};
						var extendedMode = this.get("extendedMode");
						var showCode = this.get("showCode");
						var rowViewModel = createRowViewModel(value, onEdit, onDelete, this, extendedMode, showCode);
						return rowViewModel;
					},

					/**
					 * ########## ####### ####### ## ###### ########## ############## ####.
					 * @private
					 * @param {Object} value ######## ####.
					 */
					onAddItemApplyButtonClick: function(value) {
						var windowViewModel = this.get("windowViewModel");
						var rows = windowViewModel.get("rows");
						if (!rows.contains(value.name)) {
							value.position = rows.getCount();
							var rowViewModel = windowViewModel.getRowViewModel(value);
							rows.add(value.name, rowViewModel);
							return true;
						}
						return false;
					},

					/**
					 * ########### ## #######.
					 * @private
					 */
					subscribeEvents: function() {
						var rows = this.get("rows");
						var rowsView = this.get("rowsView");
						var onTabAdded = function(row) {
							row.visualize();
						};
						rows.on("add", onTabAdded);
						rows.on("remove", function(row) {
							if (!row.view.destroyed) {
								row.view.destroy();
							}
							delete row.view;
							rowsView.remove(row.view);
						});
						rows.on("clear", function() {
							rowsView.each(function(view) {
								view.destroy();
							});
							rowsView.clear();
						});
						rows.on("clear", function() {
							rows.each(onTabAdded);
						});
						this.on("change:showCode", function() {
							var showCode = this.get("showCode");
							var rowsView = this.get("rowsView");
							var rows = this.get("rows");
							rowsView.each(function(view) {
								view.destroy();
							});
							rowsView.clear();
							rows.each(function(row) {
								row.set("showCode", showCode);
								row.visualize();
							});
							var editViewModel = this.get("editRowViewModel");
							if (editViewModel) {
								editViewModel.set("showCode", showCode);
							}
						});
					},

					onSaved: Ext.emptyFn,

					/**
					 * ########## ####### ####### ## ###### ##########.
					 * @private
					 */
					onSaveClick: function() {
						var validation = this.validate();
						if (!validation) {
							return;
						}
						var rowItems = this.get("rows").getItems();
						var result = [];
						BPMSoft.each(rowItems, function(row, key) {
							var position = parseInt(key, 10);
							var item = {
								name: row.get("name") || null,
								caption: row.get("caption"),
								position: position
							};
							result.push(item);
						});
						this.onSaved(result);
						ModalBox.close();
					},

					/**
					 * ########## ####### ####### ## ###### ######
					 * @private
					 */
					onCancelClick: function() {
						ModalBox.close();
					},
					/**
					 * ######## ######## ######### #### ### ## ###############
					 * @private
					 */
					toggleCodeVisibility: function() {
						var showCode = this.get("showCode");
						this.set("showCode", !showCode);
					},

					/**
					 * ############# ######### ###### ############ ######### ####### ###.
					 * @private
					 */
					setButtonCaption: function() {
						var caption;
						var showCode = this.get("showCode");
						if (showCode) {
							caption = localizableStrings.HideCodeButtonCaption;
						} else {
							caption = localizableStrings.ShowCodeButtonCaption;
						}
						return caption;
					}
				}
			};
			viewModel = Ext.create("BPMSoft.BaseViewModel", cfg);
			viewModel.subscribeEvents();
			viewModel.fillRowsCollection();
			return viewModel;
		}

		/**
		 * ####### ######## ############# #### ############## #######.
		 * @returns {BPMSoft.Container} ############## ############# ####.
		 */
		function createTabsWindowView() {
			var view;
			var headerContainer = createHeaderContainer();
			headerContainer.add({
				className: "BPMSoft.Button",
				id: "toggleCodeVisibilityButton",
				selectors: {
					wrapEl: "#toggleCodeVisibilityButton"
				},
				caption: {
					bindTo: "setButtonCaption"
				},
				classes: {
					textClass: ["toggleButton"]
				},
				tag: "toggleCodeVisibility",
				markerValue: "toggleCodeVisibility",
				visible: {
					bindTo: "extendedMode"
				},
				click: {
					bindTo: "toggleCodeVisibility"
				}
			});
			var cfg = {
				className: "BPMSoft.Container",
				id: "tabsMainContainer",
				selectors: {
					el: "#tabsMainContainer",
					wrapEl: "#tabsMainContainer"
				},
				classes: {
					wrapClassName: ["mainContainer"]
				},
				items: [
					headerContainer,
					{
						className: "BPMSoft.Container",
						id: "contentContainer",
						selectors: {
							wrapEl: "#contentContainer"
						},
						classes: {
							wrapClassName: ["contentContainer"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "captionRowContainer",
								selectors: {
									wrapEl: "#captionRowContainer"
								},
								classes: {
									wrapClassName: ["caption-row-container"]
								},
								items: [
									{
										className: "BPMSoft.Label",
										classes: {
											labelClass: ["caption-row-left"]
										},
										caption: localizableStrings.TitleCaption
									},
									{
										className: "BPMSoft.Label",
										classes: {
											labelClass: ["caption-row-right"]
										},
										visible: {
											bindTo: "showCode"
										},
										caption: localizableStrings.CodeCaption
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "tabListContainer",
								selectors: {
									wrapEl: "#tabListContainer"
								},
								afterrender: {
									bindTo: "setTabListContainer"
								},
								destroy: {
									bindTo: "clearTabListContainer"
								},
								items: []
							},
							{
								className: "BPMSoft.Container",
								id: "addItemContainer",
								selectors: {
									wrapEl: "#addItemContainer"
								},
								afterrender: {
									bindTo: "setAddItemContainer"
								},
								destroy: {
									bindTo: "clearAddItemContainer"
								},
								items: []
							},
							{
								className: "BPMSoft.Container",
								id: "addButtonContainer",
								selectors: {
									wrapEl: "#addButtonContainer"
								},
								classes: {
									wrapClassName: ["addButtonContainer"]
								},
								visible: {
									bindTo: "extendedMode"
								},
								items: [
									{
										className: "BPMSoft.Button",
										caption: localizableStrings.AddButtonCaption,
										click: {
											bindTo: "onAddItemButtonClick"
										},
										markerValue: "addButton",
										classes: {
											wrapperClass: ["tab-add-button"]
										}
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "footer",
								selectors: {
									wrapEl: "#footer"
								},
								classes: {
									wrapClassName: ["footer"]
								}
							}
						]
					}
				]
			};
			view = Ext.create("BPMSoft.Container", cfg);
			return view;
		}

		/**
		 * ####### ######## ########## #### ############## #######.
		 * @param {BPMSoft.BaseViewModel} scope ###### ############# ######### ########.
		 * @param {Array} tabsConf ###### ########.
		 * @param {Object} addConfig ################ ######.
		 * @param {String} addConfig.currentObjectName ### ######## #######.
		 * @param {Function} callback ####### ######### ######.
		 */
		function showEditTabsWindow(scope, tabsConf, addConfig, callback) {
			var extendedMode = true;
			var showCode = false;
			var vm = createTabsWindowViewModel(tabsConf, extendedMode, showCode, addConfig);
			vm.set("designerViewModel", scope);
			vm.onSaved = function(tabs) {
				callback.call(scope, tabs);
			};
			var view = createTabsWindowView(extendedMode);
			var modalBoxConfig = {};
			modalBoxConfig.container = ModalBox.show({
				minWidth: 1,
				maxWidth: 99,
				minHeight: 1,
				maxHeight: 99
			});
			view.bind(vm);
			view.render(modalBoxConfig.container);
			ModalBox.updateSizeByContent();
		}

		/**
		 * ####### ######## ########## #### ############## ####### #######.
		 * @param {BPMSoft.BaseViewModel} scope ###### ############# ######### ########.
		 * @param {Array} itemsConf ###### ######### ########.
		 * @param {Object} addConf ################ ######.
		 * @param {String} addConf.tabCaption ######### ####### #######.
		 * @param {Function} callback ####### ######### ######.
		 */
		function showEditTabItemsWindow(scope, itemsConf, addConf, callback) {
			var extendedMode = false;
			var showCode = false;
			var vm = createTabsWindowViewModel(itemsConf, extendedMode, showCode, addConf);
			vm.onSaved = function(items) {
				callback.call(scope, items);
			};
			var view = createTabsWindowView(extendedMode);
			var modalBoxConfig = {};
			modalBoxConfig.container = ModalBox.show({
				minWidth: 1,
				maxWidth: 99,
				minHeight: 1,
				maxHeight: 99
			});
			view.bind(vm);
			view.render(modalBoxConfig.container);
			ModalBox.updateSizeByContent();
		}

		function initializeGridLayoutDragAndDrop(callback) {
			var elementsList = Ext.select(".grid-layout .item-cell > .dragdrop-element", false);

			var elements = [];
			for (var i = 0, ii = elementsList.elements.length; i < ii; i++) {
				var element = elementsList.elements[i];
				elements.push(Ext.get(element));
			}
			var targetsList = Ext.select(".grid-layout .empty-element-class, .grid-layout .add-button", false);
			var targets = [];
			for (var j = 0, jj = targetsList.elements.length; j < jj; j++) {
				var target = targetsList.elements[j];
				targets.push(Ext.get(target));
			}
			Ext.create("BPMSoft.DragDropHelper", {
				elements: elements,
				targets: targets,
				listeners: {
					dragdrop: function(targetElement, element) {
						var itemColumnEl = targetElement.parent();
						var newRow = parseInt(itemColumnEl.getAttribute("data-row"), 10);
						var newColumn = parseInt(itemColumnEl.getAttribute("data-column"), 10);
						var gridLayoutEl = itemColumnEl.parent(".grid-layout");
						var newGridLayout = Ext.getCmp(gridLayoutEl.id);
						var itemContainer = Ext.getCmp(element.id);
						var item = itemContainer.items.getAt(0);
						if (item) {
							callback.call(this, newGridLayout.tag, item.tag, newRow, newColumn);
						}
					}
				}
			});
		}

		/**
		 * Gets allowed schema tab names.
		 * @protected
		 * @returns {string[]} Tab names
		 */
		function getAllowedSchemaTabNames() {
			return ["Tabs", "RightTabs", "OpenCasesTabs"];
		}

		return {
			showNewColumnWindow: showNewColumnWindow,
			showExistingColumnWindow: showExistingColumnWindow,
			showEditGroupWindow: showEditGroupWindow,
			showEditDetailWindow: showEditDetailWindow,
			showEditTabsWindow: showEditTabsWindow,
			showEditTabItemsWindow: showEditTabItemsWindow,
			initializeGridLayoutDragAndDrop: initializeGridLayoutDragAndDrop,
			getFillingGridMatrix: getFillingGridMatrix,
			generateEntityColumnByDataValueType: generateEntityColumnByDataValueType,
			getSchemaItemInfoByName: getSchemaItemInfoByName,
			getDetailsInfo: getDetailsInfo,
			setDataValueTypesStorage: setDataValueTypesStorage,
			getRequireFieldNotInSchema: getRequireFieldNotInSchema,
			getAllowedSchemaTabNames: getAllowedSchemaTabNames,
			getElementByPropertyValue: getElementByPropertyValue
		};
	});
