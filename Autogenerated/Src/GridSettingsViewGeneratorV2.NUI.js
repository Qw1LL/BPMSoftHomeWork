define("GridSettingsViewGeneratorV2", ["ext-base", "BPMSoft", "GridSettingsViewGeneratorV2Resources"],
	function(Ext, BPMSoft, resources) {
		/**
		 * ###### ### ############ ####### (Tiled)
		 * @type {Array}
		 */
		var tiledTpl = [
			"<div id='{id}' class='grid'>",
			"<div class='grid-row grid-pad grid-active-selectable' id='columnsSettingsGrid'>",
			"<tpl for='viewCollection'>",
			"<div id='row-{row}' class='grid-row grid-module'>",
			"<tpl if='xindex != xcount'>",
			"<tpl for='cells'>",
			"<tpl if='isNew'>",
			"<div id='element-plus-{parent.row}-{column}' class='grid-cols-{width}'>",
			"<div class='empty-inner-div'>",
			"+",
			"</div>",
			"</div>",
			"<tpl elseif='isEmpty'>",
			"<div id='element-empty-{parent.row}-{column}' class='grid-cols-{width}'>",
			"<div class='empty-inner-div'>",
			"",
			"</div>",
			"</div>",
			"<tpl else>",
			"<div id='element-column-{parent.row}-{column}' class='grid-cols-{width}" +
				"<tpl if='isCurrent'> selected-column<tpl else> unchosen-column</tpl>' data-item-marker='{caption}'>" +
				"<div class='column-inner-div" +
				"<tpl if='isTitleText'> grid-header</tpl>" +
				"<tpl if='isURLType'> column-url</tpl>'>",
			"{caption}",
			"</div>",
			"</div>",
			"</tpl>",
			"</tpl>",
			"<tpl elseif='parent.isTiled || xcount == 1'>",
			"<div id='element-plus-{row}' class='grid-cols-2'>",
			"<div class='empty-inner-div'>",
			"+",
			"</div>",
			"</div>",
			"<tpl for='cells'>",
			"<div id='element-empty-{parent.row}-{column}' class='grid-cols-{width}'> " +
				"<div class='empty-inner-div'>",
			"",
			"</div>",
			"</div>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"</tpl>",
			"</div>",
			"</div>"
		];

		/**
		 * ###### ### ############ ####### (Listed)
		 * @type {Array}
		 */
		var listedTpl =  [
			"<div id='{id}' class='grid'>",
			"<div class='grid-row grid-pad grid-active-selectable' id='columnsSettingsGrid'>",
			"<tpl for='listedViewCollection'>",
			"<div id='row-{row}' class='grid-row grid-module'>",
			"<tpl if='xindex != xcount'>",
			"<tpl for='cells'>",
			"<tpl if='isNew'>",
			"<div id='element-plus-{parent.row}-{column}' class='grid-cols-{width}'>",
			"<div class='empty-inner-div'>",
			"+",
			"</div>",
			"</div>",
			"<tpl elseif='isEmpty'>",
			"<div id='element-empty-{parent.row}-{column}' class='grid-cols-{width}'>",
			"<div class='empty-inner-div'>",
			"",
			"</div>",
			"</div>",
			"<tpl else>",
			"<div id='element-column-{parent.row}-{column}' class='grid-cols-{width}" +
				"<tpl if='isCurrent'> selected-column<tpl else> unchosen-column</tpl>' data-item-marker='{caption}'>" +
				"<div class='column-inner-div" +
				"<tpl if='isTitleText'> grid-header</tpl>" +
				"<tpl if='isURLType'> column-url</tpl>'>",
			"{caption}",
			"</div>",
			"</div>",
			"</tpl>",
			"</tpl>",
			"<tpl elseif='xcount == 1'>",
			"<div id='element-plus-{row}' class='grid-cols-2'>",
			"<div class='empty-inner-div'>",
			"+",
			"</div>",
			"</div>",
			"<tpl for='cells'>",
			"<div id='element-empty-{parent.row}-{column}' class='grid-cols-{width}'> " +
				"<div class='empty-inner-div'>",
			"",
			"</div>",
			"</div>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"</tpl>",
			"</div>",
			"</div>"
		];

		/**
		 * ######## ###### ############ ######### ########## ############# ###### ######### #######
		 * @private
		 * @returns {Array}
		 */
		function getMenuItems() {
			var items = [];
			if (!this.hideButtons) {
				var saveButtonConfig = {
					id: "SaveButton",
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					caption: resources.localizableStrings.SaveButtonCaption,
					click: {
						bindTo: "saveSettings"
					},
					markerValue: resources.localizableStrings.SaveButtonCaption
				};
				if (this.isSysAdmin && !this.hideAllUsersSaveButton) {
					saveButtonConfig.classes = {wrapperClass: "save-btn-wrapperClass"};
					saveButtonConfig.menu = {
						items: [{
							id: "SaveForAllButton",
							caption: resources.localizableStrings.SaveForAllButtonButtonCaption,
							click: {bindTo: "saveSettingsForAllUsers"},
							markerValue: resources.localizableStrings.SaveForAllButtonButtonCaption
						}]
					};
				} else {
					saveButtonConfig.classes = {textClass: "save-btn-textClass"};
				}
				items.push({
					className: "BPMSoft.Container",
					id: "topSettings",
					selectors: {
						wrapEl: "#topSettings"
					},
					classes: {
						wrapClassName: ["top-settings-container"]
					},
					items: [
						saveButtonConfig,
						{
							id: "CancelButton",
							className: "BPMSoft.Button",
							style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
							caption: resources.localizableStrings.CancelButtonCaption,
							classes: {
								textClass: ["cancel-button-custom"]
							},
							click: {
								bindTo: "cancelSettings"
							}
						}
					]
				});
			}
			if (!this.hideGridType && !this.isCardVisible) {
				items.push(generateTypeSelectConfig());
			}
			items.push({
				className: "BPMSoft.Container",
				id: "columnsSettings",
				selectors: {
					wrapEl: "#columnsSettings"
				},
				classes: {
					wrapClassName: ["columns-settings-container"]
				},
				tpl: (this.gridType === BPMSoft.GridType.LISTED) ? listedTpl : tiledTpl,
				tplData: this
			});
			var buttons = [];

			buttons.push({
					id: "SetupButton",
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					caption: resources.localizableStrings.SetButtonCaption,
					classes: {
						textClass: ["setup-button"]
					},
					click: {
						bindTo: "setupElement"
					}
				}
			);
			addNarrowExpandOrUpDownButtons(buttons, this);
			buttons.push(
				{
					id: "DeleteButton",
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
					caption: resources.localizableStrings.DeleteButtonCaption,
					classes: {
						textClass: ["delete-button"]
					},
					click: {
						bindTo: "deleteElement"
					}
				}
			);
			items.push({
				className: "BPMSoft.Container",
				id: "bottomSettings",
				selectors: {
					wrapEl: "#bottomSettings"
				},
				classes: {
					wrapClassName: ["bottom-settings-container"]
				},
				items: buttons
			});
			return items;
		}

		/**
		 * ######### ###### ######## ########## #########
		 * @private
		 * @param {Object[]} buttons
		 * @param {Object} scope
		 */
		function addNarrowExpandOrUpDownButtons(buttons, scope) {
			buttons.push(
				{
					id: "ExpandButton",
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					imageConfig: resources.localizableImages.PlusButtonImage,
					hint: resources.localizableStrings.ColumnWidthHint,
					classes: {textClass: ["expand-button"]},
					markerValue: "incrementWidth",
					click: {
						bindTo: (scope.isCardVisible) ? "moveElementDown" : "expandElement"
					}
				},
				{
					id: "NarrowButton",
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					imageConfig: resources.localizableImages.MinusButtonImage,
					hint: resources.localizableStrings.ColumnWidthHint,
					classes: {textClass: ["narrow-button"]},
					markerValue: "decrementWidth",
					click: {
						bindTo: (scope.isCardVisible) ? "moveElementUp" : "narrowElement"
					}
				}
			);
		}

		/**
		 * ################## ########## ###### #### #######
		 * @private
		 * @returns {Object}
		 */
		function generateTypeSelectConfig() {
			return {
				className: "BPMSoft.Container",
				id: "typeSelectContainer",
				markerValue: "ChangeViewMode",
				selectors: {
					wrapEl: "#typeSelectContainer"
				},
				classes: {
					wrapClassName: ["columns-settings-type-select-container"]
				},
				visible: {
					bindTo: "isSingleTypeMode",
					bindConfig: {
						converter: function(value) {
							return !value;
						}
					}
				},
				items: [{
					className: "BPMSoft.Container",
					id: "tiledRadioContainer",
					selectors: {
						wrapEl: "#tiledRadioContainer"
					},
					classes: {
						wrapClassName: ["columns-settings-type-item-container"]
					},
					items: [{
						id: "tiledRadio",
						className: "BPMSoft.RadioButton",
						tag: BPMSoft.GridType.TILED,
						checked: {
							bindTo: "GridType",
							bindConfig: {
								converter: function() {
									return this.get("GridType") === BPMSoft.GridType.TILED;
								}
							}
						}
					}, {
						className: "BPMSoft.Label",
						caption: resources.localizableStrings.TiledCaption,
						inputId: "tiledRadio-el"
					}]
				}, {
					className: "BPMSoft.Container",
					id: "listedRadioContainer",
					selectors: {
						wrapEl: "#listedRadioContainer"
					},
					classes: {
						wrapClassName: ["columns-settings-type-item-container"]
					},
					items: [{
						id: "listedRadio",
						className: "BPMSoft.RadioButton",
						tag: BPMSoft.GridType.LISTED,
						checked: {
							bindTo: "GridType",
							bindConfig: {
								converter: function() {
									return this.get("GridType") === BPMSoft.GridType.LISTED;
								}
							}
						}
					}, {
						className: "BPMSoft.Label",
						caption: resources.localizableStrings.ListedCaption,
						inputId: "listedRadio-el"
					}]
				}]
			};
		}

		/**
		 * ######## ############ ############# ###### ######### #######
		 * @returns {Object}
		 */
		function getViewConfig() {
			var view = {
				className: "BPMSoft.Container",
				id: "gridSettings",
				selectors: {
					wrapEl: "#gridSettings"
				},
				classes: {
					wrapClassName: ["grid-settings"]
				},
				items: getMenuItems.call(this)
			};
			return view;
		}

		return {
			generate: getViewConfig,
			listedTpl: listedTpl,
			tiledTpl: tiledTpl
		};
	});
