define("MarketingCalendarViewGenerator", ["ViewGeneratorV2", "MarketingCalendar"],
	function() {
		var viewGenerator = Ext.define("BPMSoft.configuration.MarketingCalendarViewGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.MarketingCalendarViewGenerator",

			/**
			 * ########## ############ ############# ### {BPMSoft.MultiCurrencyEdit}.
			 * @protected
			 * @virtual
			 * @param {Object} viewConfig ######## ############# ######## ##########.
			 * @param {Object} config ######## ######## ##########.
			 * @return {Object} ############### ############# MultiCurrencyEdit.
			 */
			generate: function(config) {
				var controlId = config.name;
				var marketingCalendarConfig = {
					className: "BPMSoft.MarketingCalendar",
					items: config.items,
					selectors: {wrapEl: "#" + controlId},
					selection: config.selection,
					selectedItems: config.selectedItems,
					columnsCaptionsConfig: config.columnsCaptionsConfig,
					scrollTop: config.scrollTop,
					useManualSelection: true,
					autoHeight: true,
					selectionType: BPMSoft.GridLayoutEditSelectionType.HORIZONTAL,
					columns: config.columns,
					maxRows: Number.MAX_VALUE,
					cellWidth: 10,
					allowItemsIntersection: true,
					changePositionForIntersectedItems: false,
					itemActionClick: {bindTo: "onItemActionClick"},
					itemConfig: {
						rowSpan: 1,
						itemId: BPMSoft.generateGUID(),
						content: "Content",
						/*jshint bitwise:false */
						dragActionsCode: BPMSoft.DragAction.MOVE | BPMSoft.DragAction.RESIZE_RIGHT |
						BPMSoft.DragAction.RESIZE_LEFT
						/*jshint bitwise:true */
					},
					itemBindingConfig: {
						itemId: {
							bindTo: "Id"
						},
						content: {
							bindTo: "Name"
						},
						row: {
							bindTo: "Row"
						},
						column: {
							bindTo: "Column"
						},
						colSpan: {
							bindTo: "Duration"
						}
					}
				};

				var serviceProperties = ["generator", "items", "schema", "viewModelClass"];
				var configWithoutServiceProperties = this.getConfigWithoutServiceProperties(config, serviceProperties);
				Ext.apply(marketingCalendarConfig, configWithoutServiceProperties);
				return marketingCalendarConfig;
			}
		});

		return Ext.create(viewGenerator);
	});
