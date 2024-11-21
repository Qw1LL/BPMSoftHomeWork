define("MobileDesignerViewGenerator", ["ext-base", "BPMSoft", "MobileDesignerViewGeneratorResources", "DesignViewGeneratorV2"],
	function(Ext, BPMSoft, resources) {
		/**
		 * ##### ######## # ##### ######### ########## ##########.
		 * @class BPMSoft.configuration.MobileDesignerGridLayoutEditItem
		 */
		Ext.define("BPMSoft.configuration.MobileDesignerGridLayoutEditItem", {
			extend: "BPMSoft.controls.GridLayoutEditItem",
			alternateClassName: "BPMSoft.MobileDesignerGridLayoutEditItem",

			/**
			 * @inheritDoc BPMSoft.GridLayoutEditItem#b4StartDrag
			 * @overridden
			 */
			b4StartDrag: function() {
				this.callParent(arguments);
				this.wrapEl.setVisible(true);
			}
		});

		/**
		 * @class BPMSoft.configuration.MobileDesignerViewGenerator
		 * Class that generates view for mobile designer.
		 */
		var viewGenerator = Ext.define("BPMSoft.configuration.MobileDesignerViewGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.MobileDesignerViewGenerator",

			/**
			 * @private
			 */
			notConfigurable: ["SocialMessageDetailV2StandartDetail", "SocialMessageDetailV2StandardDetail"],

			/**
			 * @inheritDoc BPMSoft.ViewGenerator#generateControlGroup
			 * @overridden
			 */
			generateControlGroup: function(config) {
				var wrapClass = config.wrapClass || [];
				wrapClass.push("detail");
				var caption = config.caption;
				var controlGroup = {
					className: "BPMSoft.ControlGroup",
					caption: caption,
					collapsed: { bindTo: config.name + "Collapsed" },
					collapsedchanged: { bindTo: config.name + "CollapseChange" },
					items: [],
					wrapClass: wrapClass.join(" "),
					markerValue: caption
				};
				BPMSoft.each(config.items, function(childItem) {
					var childItemConfig = this.generateItem(childItem);
					controlGroup.items = controlGroup.items.concat(childItemConfig);
				}, this);
				if (!config.disableTools) {
					controlGroup.tools = this.generateControlGroupTools(config);
				}
				return controlGroup;
			},

			/**
			 * ########## ############ ######### ######### ### ###### #########.
			 * @protected
			 * @virtual
			 * @param {Object} config ############ ###### #########.
			 * @return {Object[]} ############### ############# ######### #########.
			 */
			generateControlGroupTools: function(config) {
				var itemName = config.name;
				var itemIsConfigurable = (!Ext.Array.contains(this.notConfigurable, itemName));
				var result = [];
				if (config.useOrderTools) {
					var moveUpButton = this.generateButton({
						name: itemName + "MoveUp",
						imageConfig: { "bindTo": "Resources.Images.MoveUpButtonImage" },
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						tag: itemName,
						click: { bindTo: "onMoveUpControlGroupButtonClick" }
					});
					result.push(moveUpButton);
					var moveDownButton = this.generateButton({
						name: itemName + "MoveDown",
						imageConfig: { "bindTo": "Resources.Images.MoveDownButtonImage" },
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						tag: itemName,
						click: { bindTo: "onMoveDownControlGroupButtonClick" }
					});
					result.push(moveDownButton);
				}
				if (config.useEditTools && itemIsConfigurable) {
					var configurationButton = this.generateButton({
						name: itemName + "Configuration",
						imageConfig: resources.localizableImages.SettingsButtonImage,
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						tag: itemName,
						click: { bindTo: "onConfigureControlGroupButtonClick" }
					});
					result.push(configurationButton);
				}
				if (config.useEditTools) {
					var removeButton = this.generateButton({
						name: itemName + "Remove",
						imageConfig: resources.localizableImages.TrashButtonImage,
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						tag: itemName,
						click: { bindTo: "onRemoveControlGroupButtonClick" }
					});
					result.push(removeButton);
				}
				return result;
			},

			/**
			 * ########## ############ ############# ### ##### {BPMSoft.ViewItemType.GRID_LAYOUT}.
			 * @protected
			 * @overridden
			 * @param {Object} config ############ #####.
			 * @return {Object} ############### ############# #####.
			 */
			generateGridLayout: function(config) {
				var controlId = config.name;
				var result = {
					className: "BPMSoft.GridLayoutEdit",
					itemClassName: "BPMSoft.MobileDesignerGridLayoutEditItem",
					id: controlId,
					selectors: { wrapEl: "#" + controlId },
					rows: { bindTo: config.name + "Rows" },
					columns: 1,
					items: { bindTo: config.name + "ItemsCollection" },
					selectedItemsChange: { bindTo: config.name + "SelectedItemsChange" },
					selectionChanged: { bindTo: config.name + "SelectionChanged" },
					visible: { bindTo: config.name + "Visible" },
					autoHeight: true,
					autoWidth: false,
					multipleSelection: false,
					allowItemsIntersection: false,
					changePositionForIntersectedItems: true,
					minRows: 1,
					maxRows: config.maxRows,
					selectionType: BPMSoft.GridLayoutEditSelectionType.HORIZONTAL
				};
				this.applyControlConfig(result, config);
				return result;
			}

		});
		return Ext.create(viewGenerator);
	});
