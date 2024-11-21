define("DashboardDesignViewGeneratorV2", ["ext-base", "BPMSoft", "DesignViewGeneratorV2"],
	function(Ext, BPMSoft) {
		var viewGenerator = Ext.define("BPMSoft.configuration.DashboardDesignViewGenerator", {
			extend: "BPMSoft.DesignViewGenerator",
			alternateClassName: "BPMSoft.DashboardDesignViewGenerator",

			/**
			 * @inheritDoc BPMSoft.DesignViewGenerator#generateAddButtonItems
			 * @overridden
			 */
			generateAddButtonItems: function(column, row, config) {
				var tag = [config.name, column, row].join(":");
				var result = [];
				BPMSoft.each(BPMSoft.DashboardEnums.WidgetType, function(typeConfig, typeName) {
					var addTag = tag + ":" + typeName;
					result.push({
						caption: { "bindTo": "Resources.Strings.Add" + typeName + "ButtonCaption" },
						click: { bindTo: "addWidget" },
						tag: addTag
					});
				}, this);
				return result;
			},

			/**
			 * ########## ############ ############# ### ##### {BPMSoft.ViewItemType.GRID_LAYOUT}.
			 * @override
			 * @param {Object} config ############ #####.
			 * @return {Object} ########## ############### ############# #####.
			 */
			generateGridLayout: function() {
				var result = this.callParent(arguments);
				var gridLayout = result[0];
				gridLayout.markerValue = "DashboardGridLayout";
				Ext.dd.DragDropManager.mode = 0;
				return result;
			},

			/**
			 * @inheritDoc BPMSoft.DesignViewGenerator#getLabelCaption
			 * @overridden
			 */
			getLabelCaption: function(config) {
				if (config.itemType === BPMSoft.ViewItemType.MODULE) {
					return { "bindTo": config.name + "Caption" };
				} else {
					return this.callParent(arguments);
				}
			},

			/**
			 * @inheritDoc BPMSoft.DesignViewGenerator#getGridLayoutChangePanelConfig
			 * @overridden
			 */
			getGridLayoutChangePanelConfig: function(config) {
				var gridLayoutName = config.name;
				var panelConfig = this.callParent(arguments);
				var configItem = {
					"name": gridLayoutName + "editItem",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": { "bindTo": "Resources.Strings.EditButtonCaption" },
					"tag": gridLayoutName,
					"markerValue": "editGridElement",
					"click": { "bindTo": "editItem"}
				};
				var copyItem = {
					"name": gridLayoutName + "copyItem",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": { "bindTo": "Resources.Strings.CopyButtonCaption" },
					"classes": { "textClass": ["copy-button"] },
					"tag": gridLayoutName,
					"markerValue": "copyGridElement",
					"click": { "bindTo": "copyItem"}
				};
				panelConfig.items.unshift(configItem, copyItem);
				return panelConfig;
			}

		});

		return Ext.create(viewGenerator);
	});
