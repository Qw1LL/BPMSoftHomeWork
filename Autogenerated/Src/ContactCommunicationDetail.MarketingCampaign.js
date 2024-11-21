define("ContactCommunicationDetail", ["ContactCommunicationDetailResources", "BPMSoft", "ViewUtilities",
		"ConfigurationConstants", "ServiceHelper", "MarketingEnums", "CheckedCommunicationViewModel"
		],
		function(resources, BPMSoft, ViewUtilities, ConfigurationConstants, ServiceHelper, MarketingEnums) {
			return {
				methods: {

					/**
					 * ############## ######.
					 * @inheritdoc BPMSoft.BaseCommunicationDetail#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.set("BaseCommunicationViewModelClassName", "BPMSoft.CheckedCommunicationViewModel");
					},

					/**
					 * ######### ############ ############# ######## ######## #####.
					 * @protected
					 * @overridden
					 * @param {Object} itemConfig ###### ## ############ ######## # ContainerList.
					 * @param {BPMSoft.BaseViewModel} item ####### ### ######## ###### ########## ########## view
					 */
					getItemViewConfig: function(itemConfig, item) {
						this.callParent(arguments);
						if (this.Ext.isEmpty(item.nonActualChanged)) {
							item.nonActualChanged = function(checked) {
								this.set("NonActual", !checked);
							};
							var nonActualCaption = resources.localizableStrings.NonActualCaption;
							item.getCommunicationTypeCaption = function() {
								var communicationType = this.get("CommunicationType");
								return (this.get("NonActual") === true)
										? Ext.String.format("{0} {1}", communicationType.displayValue,
										nonActualCaption)
										: communicationType.displayValue;
							};
						}
						var itemViewConfig = this.get("itemViewConfig");
						var config = itemConfig.config;
						config.items.forEach(function(configItem) {
							if (configItem.selectors &&
									configItem.selectors.wrapEl === "#type") {
								var nonActualMenuItem = null;
								var menu = configItem.menu;
								menu.items.forEach(function(menuItem) {
									if (menuItem.tag === "NonActual") {
										nonActualMenuItem = menuItem;
										return false;
									}
								}, this);
								var nonActual = item.get("NonActual");
								if (!nonActualMenuItem) {
									var separatorMenuItem = {
										className: "BPMSoft.MenuSeparator",
										caption: ""
									};
									nonActualMenuItem = {
										id: item.get("Id"),
										caption: resources.localizableStrings.TopicalAddressCaptionMenu,
										className: BPMSoft.MenuItemType.CHECK,
										checked: !nonActual,
										checkedChanged: {bindTo: "nonActualChanged"},
										tag: "NonActual"
									};
									if (!this.Ext.isEmpty(item.nonActualChanged)) {
										menu.items.splice(0, 0, nonActualMenuItem);
										menu.items.splice(1, 0, separatorMenuItem);
										configItem.caption = {bindTo: "getCommunicationTypeCaption"};
									}
								} else {
									nonActualMenuItem.checked = !nonActual;
								}
							} else if (configItem.className === "BPMSoft.TextEdit" && !itemViewConfig) {
								configItem.markerValue = {bindTo: "getCommunicationTypeCaption"};
							}
						}, this);

					},

					/**
					 * ############## ####### ########## #######.
					 * @protected
					 * @param {Object} esq ######, # ####### ##### ################### #######.
					 */
					initQueryColumns: function(esq) {
						this.callParent(arguments);
						esq.addColumn("NonActual");
						esq.addColumn("NonActualReason");
					},
					/**
					 * ######### ######### ######. ########### ### ####### ## ###### ######### ########, #######
					 * ######## ######.
					 * @overridden
					 */
					save: function() {
						var collection = this.get("Collection");
						var now = new Date();
						collection.each(function(item) {
							if (this.isActualStatusChangetTo(item, true)) {
								item.set("NonActualReason", {value: MarketingEnums.NonActualReason.FILLED_MANUALLY});
								item.set("DateSetNonActual", now);
							}
						}, this);
						return this.callParent(arguments);
					},

					/**
					 * ######### ### ## ####### ####### "## ##########" ## ######## ############### value.
					 * @protected
					 * @param {Object} item Entity ######## #####.
					 * @param {Boolean} value ######## ### ######## ## ######## "## ##########".
					 * @return {Boolean} ###### true, #### ### email # ######### ########## ############ # ### ##
					 * ##### ######, ##### false.
					 */
					isActualStatusChangetTo: function(item, value) {
						return (!item.isNew &&
								item.validate() &&
								item.changedValues &&
								item.changedValues.hasOwnProperty("NonActual") &&
								item.changedValues.NonActual === value);
					}
				}
			};
		});
