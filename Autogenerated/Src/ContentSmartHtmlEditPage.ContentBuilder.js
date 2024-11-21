/**
 * Page to edit smart html element in content builder.
 */
define("ContentSmartHtmlEditPage", ["ContentSmartHtmlEditPageResources", "AcademyUtilities", "SourceCodeEditEnums",
		"SmartHtmlSourceCodeEdit", "css!ContentSmartHtmlEditPageCSS", "ContentSmartHtmlMacroListItemViewModel",
		"ObservableContainerList"],
	function(resources, AcademyUtilities, sourceCodeEditEnums) {
		return {
			properties: {
				/**
				 * Editor DOM id.
				 * @type {String}
				 */
				editorId: "SmartHtmlSourceCodeEditor",
				/**
				 * Class for menu with available macro actions.
				 * @type {String}
				 */
				macroMenuClassName: "smart-html-macros-menu"
			},
			messages: {
				/**
				 * @message SmartHtmlContentSaved
				 * Message indicates need save current smart html.
				 */
				"SmartHtmlContentSaved": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message SaveBlockCancel
				 * Message for canceling smart html saving process.
				 */
				"SmartHtmlEditCancel": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			attributes: {
				/**
				 * Initial string macros collection representation
				 */
				"MacrosConfig": {
					type: BPMSoft.ViewModelColumnType.TEXT
				},

				/**
				 * Element macros collection.
				 */
				"Macros": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					value: Ext.create("BPMSoft.BaseViewModelCollection")
				},
				/**
				 * Unique identifier of current active macro item.
				 */
				"ActiveMacroId": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Current edited macro name.
				 */
				"EditedMacroName": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT,
					onChange: "onEditedMacroNameChanged"
				},

				/**
				 * Current edited macro value.
				 */
				"EditedMacroValue": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT,
					onChange: "onEditedMacroValueChanged"
				},

				/**
				 * Current edited macro description.
				 */
				"EditedMacroDescription": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT,
					onChange: "onEditedMacroDescriptionChanged"
				},

				/**
				 * Current edited macro data type logo.
				 */
				"SelectedMacroTypeLogo": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Academy context help identifier.
				 */
				"ContextHelpId": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.INTEGER
				},

				/**
				 * Flag indicates that need show macros list.
				 */
				"IsMacroValuesListVisible": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * Source HTML to edit.
				 */
				"HtmlSrc": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},
				/**
				 * Selected text in HTML editor.
				 */
				"SelectedText": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Defines if Save button is enabled.
				 */
				"IsSaveAllowed": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Collection of errors or warnings.
				 */
				"Annotations": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					value: Ext.create("BPMSoft.Collection")
				},
				/**
				 * Total number of errors and warnings.
				 */
				"AnnotationsCount": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 0
				},
				/**
				 * Config for macros menu create actions.
				 */
				"MacrosMenu": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				}
			},
			methods: {

				/**
				 * @private
				 */
				_subscribeEvents: function() {
					this.$Macros.on("remove", this.onMacroRemoved, this);
					this.$Macros.on("changed", this.onMacrosCollectionChanged, this);
					this.$Macros.on("dataLoaded", this.onMacrosCollectionLoaded, this);
				},

				/**
				 * @private
				 */
				_unsubscribeEvents: function() {
					this.$Macros.un("remove", this.onMacroRemoved, this);
					this.$Macros.un("changed", this.onMacrosCollectionChanged, this);
					this.$Macros.un("dataLoaded", this.onMacrosCollectionLoaded, this);
				},

				/**
				 * Inits macro values.
				 * @private
				 */
				_initMacros: function() {
					if (this.$MacrosConfig === undefined || this.$MacrosConfig === BPMSoft.emptyString) {
						return;
					}
					var macros = JSON.parse(this.$MacrosConfig);
					var values = new BPMSoft.BaseViewModelCollection();
					BPMSoft.each(macros, function(macro) {
						macro.TypeLogo = this.getLogoByType(macro.DataValueType);
						var listItem = this._createMacroListItemViewModel(macro);
						values.add(listItem.$Id, listItem);
					}, this);
					this.$Macros.reloadAll(values);
				},

				/**
				 * Returns instance of the list item view model.
				 * @private
				 * @param {Object} macro Macro object.
				 * @returns {BPMSoft.BaseMacroListItemViewModel} List item view model.
				 */
				_createMacroListItemViewModel: function(macro) {
					return new BPMSoft.ContentSmartHtmlMacroListItemViewModel({values: macro});
				},

				/**
				 * @private
				 */
				_initMacroPropertiesForEdit: function(config) {
					this.$EditedMacroName = config.Name;
					this.$EditedMacroValue = config.Value;
					this.$EditedMacroDescription = config.Description;
				},

				/**
				 * @private
				 */
				_clearEditedMacro: function() {
					BPMSoft.each(this.$Macros, function(macro) {
						macro.$Selected = false;
					}, this);
					this.$ActiveMacroId = null;
					this.$EditedMacroName = null;
					this.$EditedMacroValue = null;
					this.$EditedMacroDescription = null;
				},

				/**
				 * @private
				 */
				_getImageConfig: function(localizableImage) {
					var imageUrl = BPMSoft.ImageUrlBuilder.getUrl(localizableImage);
					return {
						"source": BPMSoft.ImageSources.URL,
						"url": imageUrl
					};
				},

				/**
				 * @private
				 */
				_getMenuItemClassName: function(macro) {
					var dataTypeName;
					switch (macro.$DataValueType) {
						case BPMSoft.DataValueType.LONG_TEXT:
						case BPMSoft.DataValueType.STRING:
							dataTypeName = "text";
							break;
						case BPMSoft.DataValueType.IMAGE:
						case BPMSoft.DataValueType.COLOR:
							dataTypeName = "image";
							break;
						default:
							dataTypeName = "text";
							break;
					}
					return Ext.String.format("menu-item macro-menu-item-{0}", dataTypeName);
				},

				/**
				 * @private
				 */
				_updateMacrosListVisibility: function() {
					this.$IsMacroValuesListVisible = !this.$Macros.isEmpty();
				},

				/**
				 * @private
				 */
				_actualizeMacroMenuCollection: function() {
					var list = this.getDefaultActionsConfig();
					this.extendWithExistingMacros(list);
					this.$MacrosMenu = {
						items: list,
						ulClass: this.macroMenuClassName
					};
				},

				/**
				 * @private
				 */
				_actualizePageAttributes: function() {
					this._updateMacrosListVisibility();
					this._actualizeMacroMenuCollection();
				},

				/**
				 * Triggers event to replace source text with params.
				 * @private
				 * @param {String} oldText
				 * @param {String} newText
				 */
				_replaceMacro: function(oldText, newText) {
					var editorComponent = Ext.getCmp(this.editorId);
					editorComponent.fireEvent("replacemacro", {
						oldText: oldText,
						newText: newText
					}, this);
				},

				/**
				 * @param macroConfig Macro config to select or null, to clear selection.
				 * @private
				 */
				_setMacroSelected: function(macroConfig) {
					var editorComponent = Ext.getCmp(this.editorId);
					if (editorComponent) {
						editorComponent.fireEvent("selectmacro", macroConfig, this);
					}
				},

				/**
				 * @private
				 */
				_isValidMacroName: function(name) {
					return name !== BPMSoft.emptyString;
				},

				/**
				 * @private
				 */
				_getNewMacroId: function() {
					if (this.$Macros.isEmpty()) {
						return 1;
					}
					var ids = this.$Macros.mapArray(function(el) { return el.$Id; });
					return Ext.Array.max(ids) + 1;
				},

				/**
				 * @private
				 */
				_getMacroById: function(id) {
					return this.$Macros.get(id);
				},

				/**
				 * @private
				 */
				_getActiveMacro: function() {
					if (!this.$ActiveMacroId) {
						return null;
					}
					return this._getMacroById(this.$ActiveMacroId);
				},

				/**
				 * @private
				 */
				_addNewMacro: function(macroViewModel) {
					this.$Macros.add(macroViewModel.$Id, macroViewModel);
				},

				/**
				 * Replaces selected text in source HTML with existing macro text.
				 * @private
				 * @param {BPMSoft.ContentSmartHtmlMacroListItemViewModel} macro Current macro.
				 */
				_replaceSelectedTextWithMacro: function(macro) {
					var macroText = macro.getMacroText();
					var editorComponent = Ext.getCmp(this.editorId);
					editorComponent.fireEvent("replacewithmacro", macroText, this);
				},

				/**
				 * Add or remove selected class for specified macro container.
				 * @protected
				 * @param {Number} macroId
				 * @param {Boolean} isSelected Defines to add or to remove macro.
				 */
				setMacroSelectedClass: function(macroId, isSelected) {
					var currentItem = Ext.get(macroId + "-" + macroId + "-macro-item");
					if (isSelected) {
						currentItem.addCls("selected");
					} else {
						currentItem.removeCls("selected");
					}
				},

				/**
				 * Handles macro selection at source code editor.
				 * @protected
				 * @param {String} macroText Text of selected macro.
				 */
				onMacroSelected: function(macroText) {
					var activeMacro = this._getActiveMacro();
					if (activeMacro) {
						if (activeMacro.getMacroText() === macroText) {
							return;
						}
						activeMacro.$Selected = false;
						this.setMacroSelectedClass(activeMacro.$Id, false);
					}
					BPMSoft.each(this.$Macros, function(macro) {
						if (macro.getMacroText() === macroText) {
							macro.$Selected = true;
							this.onSelectedItemChanged(macro, true);
							this.setMacroSelectedClass(macro.$Id, true);
							return false;
						}
					}, this);

				},
				/**
				 * Validator for macro name.
				 * @protected
				 * @param {String} name Name value.
				 * @returns {Object} Validation result.
				 */
				macroNameValidator: function(name) {
					var message = this._isValidMacroName(name) ? "" : resources.localizableStrings.WrongNameMessage;
					return {invalidMessage: message};
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("EditedMacroName", this.macroNameValidator);
				},

				/**
				 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this.initHelpUrl();
					this._subscribeEvents();
					this._initMacros();
				},

				/**
				 * @inheritdoc BPMSoft.BaseObject#onDestroy
				 * @override
				 */
				onDestroy: function() {
					this._unsubscribeEvents();
					this.$Macros.clear();
					this.callParent(arguments);
				},

				/**
				 * Initialize help url.
				 * @protected
				 */
				initHelpUrl: function() {
					var contextHelpCode = "ContentRawHtmlProperties";
					var helpConfig = {
						callback: function(url) {
							this.set("HelpUrl", url);
						},
						scope: this,
						contextHelpCode: contextHelpCode
					};
					AcademyUtilities.getUrl(helpConfig);
				},

				/**
				 * Returns macro type image config for specified data value type.
				 * @protected
				 * @param {BPMSoft.DataValueType} dataValueType Macro data value type.
				 * @returns {Object} Type logo image config.
				 */
				getLogoByType: function(dataValueType) {
					switch (dataValueType) {
						case BPMSoft.DataValueType.STRING:
						case BPMSoft.DataValueType.LONG_TEXT:
							return this._getImageConfig(resources.localizableImages.TextMacroImage);
						case BPMSoft.DataValueType.IMAGE:
						case BPMSoft.DataValueType.COLOR:
							return this._getImageConfig(resources.localizableImages.PictureMacroImage);
						default:
							return this._getImageConfig(resources.localizableImages.TextMacroImage);
					}
				},

				/**
				 * Returns default action config for menu item.
				 * @protected
				 * @param {String} caption Menu item action caption.
				 * @param {BPMSoft.DataValueType} dataValueType Menu item data value type for tag.
				 * @param {Function} handler Menu item click event handler.
				 * @returns {Object}
				 */
				getDefaultActionConfig: function(caption, dataValueType, handler) {
					return {
						caption: caption,
						tag: dataValueType,
						imageConfig: this.getLogoByType(dataValueType),
						handler: handler || this.onAddMacroClick.bind(this)
					};
				},

				/**
				 * Returns default menu separator config.
				 * @protected
				 * @returns {Object} Menu separator config.
				 */
				getDefaultMenuSeparatorConfig: function() {
					return {
						visible: !this.$Macros.isEmpty(),
						className: "BPMSoft.MenuSeparator"
					};
				},

				/**
				 * Returns array of default macros menu actions.
				 * @protected
				 * @returns {Array} List of available default macros menu actions.
				 */
				getDefaultActionsConfig: function() {
					return [
						this.getDefaultActionConfig(resources.localizableStrings.StringMacroMenuItemCaption,
							BPMSoft.DataValueType.STRING),
						this.getDefaultActionConfig(resources.localizableStrings.TextMacroMenuItemCaption,
							BPMSoft.DataValueType.LONG_TEXT),
						this.getDefaultActionConfig(resources.localizableStrings.PictureMacroMenuItemCaption,
							BPMSoft.DataValueType.IMAGE),
						this.getDefaultActionConfig(resources.localizableStrings.ColorMacroMenuItemCaption,
							BPMSoft.DataValueType.COLOR),
						this.getDefaultMenuSeparatorConfig()
					];
				},

				/**
				 * Extends macros menu actions with existing macros.
				 * @protected
				 * @param {Array} list Macros menu actions' list to extend.
				 */
				extendWithExistingMacros: function(list) {
					BPMSoft.each(this.$Macros, function(macro) {
						list.push({
							caption: macro.$Name,
							tag: macro.$Id,
							imageConfig: this._getImageConfig(macro.$TypeLogo),
							handler: this.applyExistingMacro.bind(this),
							baseMenuItemClass: this._getMenuItemClassName(macro)
						});
					}, this);
				},

				/**
				 * Returns serialized collection of selected macro values.
				 * @protected
				 * @returns {Object} Serialized selected macro values.
				 */
				getMacroValues: function() {
					var macros =  this.$Macros.mapArray(function(item) {
						return item.getMacroConfig();
					});
					return {
						macros: macros,
						htmlSrc: BPMSoft.utils.html.sanitizeHTML(this.$HtmlSrc)
					};
				},

				/**
				 * Handler on use existing macro menu click event.
				 * Finds existing macro for current nemu item
				 * and replaces selected text in source HTML with existing macro.
				 * @param {BPMSoft.Menu} menu
				 * @param {BPMSoft.MenuItem} menuItem
				 */
				applyExistingMacro: function(menu, menuItem) {
					var macroId = menuItem.tag;
					var macro = this._getMacroById(macroId);
					this._replaceSelectedTextWithMacro(macro);
				},

				/**
				 * Handler on add macro menu item click event.
				 * @protected
				 * @param {BPMSoft.Menu} menu Menu instance.
				 * @param {BPMSoft.MenuItem} menuItem Menu item instance.
				 */
				onAddMacroClick: function(menu, menuItem) {
					var config = {
						DataValueType: menuItem.tag,
						TypeLogo: this.getLogoByType(menuItem.tag),
						Value: this.$SelectedText,
						Id: this._getNewMacroId(),
						Name: resources.localizableStrings.NewMacroDefaultName,
						Selected: true
					};
					var macroViewModel = this._createMacroListItemViewModel(config);
					this._replaceSelectedTextWithMacro(macroViewModel);
					this._addNewMacro(macroViewModel);
				},

				/**
				 * Handles removed action.
				 * @protected
				 * @param {BPMSoft.ContentSmartHtmlMacroListItemViewModel} macro Removed view model.
				 */
				onMacroRemoved: function(macro) {
					var macroText = macro.getMacroText();
					this._replaceMacro(macroText, macro.$Value);
					this._actualizePageAttributes();
				},

				/**
				 * Handles changes Macros collection event.
				 * @protected
				 */
				onMacrosCollectionChanged: function() {
					this._actualizePageAttributes();
				},

				/**
				 * Handles loaded Macros collection event.
				 * @protected
				 */
				onMacrosCollectionLoaded: function() {
					this._actualizePageAttributes();
				},

				/**
				 * Handles save button click.
				 * @protected
				 */
				onSaveButtonClick: function() {
					this.sandbox.publish("SmartHtmlContentSaved", this.getMacroValues(), [this.sandbox.id]);
				},

				/**
				 * Handles cancel button click.
				 * @protected
				 */
				onCancelButtonClick: function() {
					this.sandbox.publish("SmartHtmlEditCancel", null, [this.sandbox.id]);
				},

				/**
				 * Handles selected item change event on macros list control.
				 * @protected
				 * @param {BPMSoft.ContentSmartHtmlMacroListItemViewModel} item Current selected item.
				 * @param {Boolean} isSilentMode Defines if event have to be fired.
				 */
				onSelectedItemChanged: function(item, isSilentMode) {
					if (item) {
						var config = item.getMacroConfig();
						config.Text = item.getMacroText();
						this.$ActiveMacroId = config.Id;
						this.$SelectedMacroTypeLogo = item.$TypeLogo;
						this._initMacroPropertiesForEdit(config);
						if (!isSilentMode) {
							this._setMacroSelected(config);
						}
					} else {
						this._clearEditedMacro();
						this._setMacroSelected(null);
					}
				},

				/**
				 * Handler on macro name change event.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} model Binding model.
				 * @param {String} value New macro name value.
				 */
				onEditedMacroNameChanged: function(model, value) {
					var activeMacro = this._getActiveMacro();
					if (!value || activeMacro.$Name === value) {
						return;
					}
					var oldMacroText = activeMacro.getMacroText();
					activeMacro.$Name = this.$EditedMacroName;
					var newMacroText = activeMacro.getMacroText();
					this._replaceMacro(oldMacroText, newMacroText);
					this._actualizeMacroMenuCollection();
				},

				/**
				 * Handler on macro value change event.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} model Binding model.
				 * @param {String} value New macro value.
				 */
				onEditedMacroValueChanged: function(model, value) {
					var activeMacro = this._getActiveMacro();
					if (!value || activeMacro.$Value === value) {
						return;
					}
					activeMacro.$Value = this.$EditedMacroValue;
				},

				/**
				 * Handler on macro description change event.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} model Binding model.
				 * @param {String} value New macro description value.
				 */
				onEditedMacroDescriptionChanged: function(model, value) {
					var activeMacro = this._getActiveMacro();
					if (!value || activeMacro.$Description === value) {
						return;
					}
					activeMacro.$Description = this.$EditedMacroDescription;
				},

				/**
				 * Handler on editor selected text change event.
				 * @protected
				 * @param {String} selectedText New selected text value.
				 */
				onSelectedTextChanged: function(selectedText) {
					if (this.$SelectedText !== selectedText) {
						this.$SelectedText = selectedText;
					}
				},

				/**
				 * Handler on editors errors, warnings or info annotations changes.
				 * @protected
				 * @param {BPMSoft.core.collections.Collection} annotations Collection of annotations.
				 */
				onAnnotationsChanged: function(annotations) {
					this.$IsSaveAllowed = !annotations.any(function(annotation) {
						return annotation.type === "error";
					});
					this.$Annotations.reloadAll(annotations);
					this.$AnnotationsCount = this.$Annotations.getCount();
				},

				/**
				 * @private
				 */
				getAnnotationLabelText: function() {
					return Ext.String.format(resources.localizableStrings.AnnotationsLabel, this.get("AnnotationsCount"));
				},

				/**
				 * @private
				 */
				onNextButtonClick: function() {
					var editorComponent = Ext.getCmp(this.editorId);
					if (editorComponent) {
						editorComponent.fireEvent("nextannotation", null, this);
					}
				},

				/**
				 * @private
				 */
				onPrevButtonClick: function() {
					var editorComponent = Ext.getCmp(this.editorId);
					if (editorComponent) {
						editorComponent.fireEvent("prevannotation", null, this);
					}
				},

				/**
				 * Defines need show macro editor.
				 * @protected
				 * @returns {Boolean} Returns true when has macro for edit. False in otherwise.
				 */
				isMacroEditorVisible: function () {
					return Boolean(this.$ActiveMacroId);
				},

				/**
				 * Gets text of placeholder.
				 * @protected
				 * @return {String} Text of placeholder.
				 */
				getBlankSlateLabelText: function() {
					return Ext.String.format(resources.localizableStrings.BlankSlateLabel, this.get("HelpUrl"));
				},

				/**
				 * Gets image of placeholder.
				 * @protected
				 * @return {String} Image of placeholder.
				 */
				getNoMacrosImage: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.MacrosCollectionBlankSlate);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SmartHtmlEditPageContainer",
					"propertyName": "items",
					"values": {
						"id": "SmartHtmlEditPageContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HeaderContainer",
					"parentName": "SmartHtmlEditPageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["smart-html-header-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EditPageCaption",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"markerValue": "EditPageCaption",
						"caption": "$Resources.Strings.EditPageCaption",
						"classes": {
							"labelClass": ["t-title-label-smart-html-edit-page"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "MainContainer",
					"parentName": "SmartHtmlEditPageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["smart-html-main-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SmartHtmlEditorContainer",
					"parentName": "MainContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["smart-html-editor-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HtmlSrc",
					"parentName": "SmartHtmlEditorContainer",
					"propertyName": "items",
					"values": {
						"id": "SmartHtmlSourceCodeEditor",
						"generateId": false,
						"generator": "SmartHtmlSourceCodeEditGenerator.generate",
						"language": sourceCodeEditEnums.Language.HTML,
						"printMargin": null,
						"markerValue": "SourceCodeEdit",
						"theme": sourceCodeEditEnums.Theme.CRIMSON_EDITOR,
						"showWhitespaces": true,
						"selectedtextchanged": "$onSelectedTextChanged",
						"macroselected": "$onMacroSelected",
						"annotationschanged": "$onAnnotationsChanged",
						"macrosMenu": "$MacrosMenu"
					}
				},
				{
					"operation": "insert",
					"name": "EditorMacrosContainer",
					"parentName": "MainContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["smart-html-macros-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MacrosContainerCaption",
					"parentName": "EditorMacrosContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"markerValue": "MacrosContainerCaption",
						"caption": "$Resources.Strings.MacrosContainerCaption",
						"classes": {
							"labelClass": ["t-title-label-macro-container"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "MacrosListContainer",
					"parentName": "EditorMacrosContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["smart-html-macros-list-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MacrosListLabel",
					"parentName": "MacrosListContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.MacrosListCaption",
						"classes": {
							"labelClass": ["t-title-label macros-list-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateContainer",
					"parentName": "MacrosListContainer",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "IsMacroValuesListVisible",
							"bindConfig": { converter: "invertBooleanValue" }
						},
						"classes": {
							"wrapClassName": ["blank-slate-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotSelectedImage",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"markerValue": "NotSelectedImage",
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onPhotoChange": BPMSoft.emptyFn,
						"getSrcMethod": "getNoMacrosImage",
						"classes": {
							"wrapClass": ["not-selected-image"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotSelectedLabel",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.MultilineLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$getBlankSlateLabelText",
						"contentVisible": true,
						"showLinks": true,
						"classes": {
							"labelClass": ["description-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "MacrosListValuesContainer",
					"parentName": "MacrosListContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.ObservableContainerList",
						"collection": "$Macros",
						"itemPrefix": "macro-item",
						"classes": {"wrapClassName": ["macros-container-list"]},
						"idProperty": "Id",
						"rowCssSelector": ".macro-item-container.selectable",
						"onSelectedItemChanged": "$onSelectedItemChanged",
						"visible": "$IsMacroValuesListVisible",
						"itemSortPropertyName": "Name"
					}
				},
				{
					"operation": "insert",
					"name": "ConcreteMacroEditorContainer",
					"parentName": "EditorMacrosContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["concrete-macro-editor-container"]
						},
						"visible": "$isMacroEditorVisible",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MacroEditorTypeLogoContainer",
					"parentName": "ConcreteMacroEditorContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["macro-editor-type-logo-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MacroEditorTypeLogoButton",
					"parentName": "MacroEditorTypeLogoContainer",
					"propertyName": "items",
					"values": {
						"imageConfig": "$SelectedMacroTypeLogo",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"imageClass": ["button-background-no-repeat"],
							"wrapperClass": ["t-btn-disabled macro-type-logo"]
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"name": "MacroEditorMainContainer",
					"parentName": "ConcreteMacroEditorContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["macro-editor-main-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MacroEditorFieldsContainer",
					"parentName": "MacroEditorMainContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["macro-editor-fields-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EditedMacroName",
					"parentName": "MacroEditorFieldsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"value": "$EditedMacroName",
						"markerValue": "EditedMacroName",
						"wrapClass": ["style-input"],
						"isRequired": true,
						"labelConfig": {
							"caption": "$Resources.Strings.EditedMacroNameCaption"
						}
					}
				},
				{
					"operation": "insert",
					"name": "EditedMacroValue",
					"parentName": "MacroEditorFieldsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"value": "$EditedMacroValue",
						"markerValue": "EditedMacroValue",
						"wrapClass": ["style-input"],
						"labelConfig": {
							"caption": "$Resources.Strings.EditedMacroValueCaption"
						}
					}
				},
				{
					"operation": "insert",
					"name": "EditedMacroDescription",
					"parentName": "MacroEditorFieldsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"value": "$EditedMacroDescription",
						"markerValue": "EditedMacroDescription",
						"wrapClass": ["style-input"],
						"labelConfig": {
							"caption": "$Resources.Strings.EditedMacroDescriptionCaption"
						}
					}
				},
				{
					"operation": "insert",
					"name": "AnnotationsContainer",
					"parentName": "FooterContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "IsSaveAllowed",
							"bindConfig": { converter: "invertBooleanValue" }
						},
						"classes": {
							"wrapClassName": ["smart-html-annotations-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AnnotationsCount",
					"parentName": "AnnotationsContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.TIP_LABEL,
						"markerValue": "AnnotationsCount",
						"caption": "$getAnnotationLabelText",
						"classes": {
							"labelClass": ["t-annotations-count"]
						},
						"tip": {
							"content": {
								"bindTo": "Resources.Strings.AnnotationsTip"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "PrevButton",
					"parentName": "AnnotationsContainer",
					"propertyName": "items",
					"values": {
						"caption": "$Resources.Strings.AnnotationsPreviousCaption",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"click": "$onPrevButtonClick"
					}
				},
				{
					"operation": "insert",
					"name": "NextButton",
					"parentName": "AnnotationsContainer",
					"propertyName": "items",
					"values": {
						"caption": "$Resources.Strings.AnnotationsNextCaption",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"click": "$onNextButtonClick"
					}
				},
				{
					"operation": "insert",
					"name": "FooterContainer",
					"parentName": "SmartHtmlEditPageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["smart-html-footer-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ButtonsContainer",
					"parentName": "FooterContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["smart-html-buttons-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "ButtonsContainer",
					"propertyName": "items",
					"values": {
						"caption": "$Resources.Strings.CancelButtonCaption",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"click": "$onCancelButtonClick"
					}
				},
				{
					"operation": "insert",
					"name": "SaveButton",
					"parentName": "ButtonsContainer",
					"propertyName": "items",
					"values": {
						"enabled": "$IsSaveAllowed",
						"caption": "$Resources.Strings.SaveButtonCaption",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"click": "$onSaveButtonClick"
					}
				}
			]
		};
	});
