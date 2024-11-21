define("CommunicationPanel", ["BPMSoft", "CommunicationPanelHelper", "CtiBaseHelper"],
	function(BPMSoft, CommunicationPanelHelper, CtiBaseHelper) {
		return {
			messages: {

				/**
				 * @message SelectCommunicationPanelItem
				 * ######## ##### # ################ ######.
				 * @param {Object} ########## # ######### ###### ################ ######.
				 */
				"SelectCommunicationPanelItem": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message CallDurationChanged
				 * ######## ###### # ############# ################ ######.
				 * @param {String} ############ ######.
				 */
				"CallDurationChanged": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * #######, ############ ####### ## ##### #### «CTI ######».
				 * @type {Boolean}
				 */
				"CtiPanelActive": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * ####### ########### #######.
				 * @type {String}
				 */
				"CtiPanelCounter": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ##### ######### # ####### mm:ss.
				 * @type {String}
				 */
				"CallDuration": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * #######, ############ ##### ## ##### #### «CTI ######».
				 * @type {Boolean}
				 */
				"CtiPanelVisible": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * #######, ############ ############# ######## cti-###### ### ########### ########.
				 * @type {Boolean}
				 */
				"CtiPanelModuleKeepAlive": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				}
			},
			methods: {

				/**
				 * ############## ######### ########## ##### ####.
				 * @protected
				 * @overridden
				 * @param {function} callback ####### ######### ######. ########## # ####### ########## ### ##########
				 * ###### ####.
				 */
				initSelectedMenuItem: function(callback) {
					this.sandbox.subscribe("SelectCommunicationPanelItem", this.selectItem.bind(this));
					this.sandbox.subscribe("CallDurationChanged", this.onCallDurationChanged.bind(this));
					if (BPMSoft.isCurrentUserSsp()) {
						this.callParent(arguments);
					} else {
						this.callParent([function(selectedMenuItemTag) {
							CtiBaseHelper.GetIsTelephonyEnabled(function(isEnabled) {
								this.set("CtiPanelVisible", isEnabled);
								if (!isEnabled && (selectedMenuItemTag === "CtiPanel")) {
									selectedMenuItemTag = "";
								}
								if (isEnabled && (selectedMenuItemTag !== "CtiPanel")) {
									var itemConfig = this.getPanelItemConfig("CtiPanelModule");
									itemConfig.loadHidden = true;
									this.sandbox.publish("CommunicationPanelItemSelected", itemConfig);
								}
								callback(selectedMenuItemTag);
							}.bind(this));
						}.bind(this)]);
					}
				},

				/**
				 * ############ ######### # ###, ### ############ ######## ###### ##########.
				 * @param {String} callDuration ############ ###### # ####### mm:ss.
				 */
				onCallDurationChanged: function(callDuration) {
					this.set("CallDuration", callDuration);
				},

				/**
				 * @inheritDoc BPMSoft.CommunicationPanel#getPanelItemConfig
				 * @overridden
				 */
				getPanelItemConfig: function(moduleName) {
					var config = this.callParent(arguments);
					if (moduleName !== "CtiPanelModule") {
						return config;
					}
					return Ext.apply(config, {
						keepAlive: true
					});
				},

				/**
				 * ############# ######### ##### ####.
				 * @private
				 * @param {Object} config ################ ###### ########## ###### ####.
				 */
				selectItem: function(config) {
					this.set("SelectedMenuItem", config.selectedItem);
				},

				/**
				 * ########## ############ ########### ######## #### CtiPanel ## ### #########.
				 * @private
				 * @param {String} itemTag ############# ######## ####.
				 * @returns {Object} ############ ###########.
				 */
				getCtiPanelImageConfig: function(itemTag) {
					var resourceName = "";
					var menuItemIconNameTemplate = this.get("MenuItemIconNameTemplate");
					if (!this.getIsFeatureEnabled("OldUI")) {
						resourceName = this.Ext.String.format(menuItemIconNameTemplate, itemTag, "", "");
						return this.get("Resources.Images." + resourceName + "SVG");
					}
					var isItemPressed = this.get("SelectedMenuItem") === itemTag;
					var ctiPanelCounter = this.get(itemTag + "Counter");
					var pressedSuffix = isItemPressed ? "Pressed" : Ext.emptyString;
					var counterSuffix = !Ext.isEmpty(ctiPanelCounter) ? "Counter" : Ext.emptyString;
					var callDuration = this.get("CallDuration");
					if (!isItemPressed) {
						counterSuffix = !Ext.isEmpty(callDuration) ? "CallDuration" : counterSuffix;
					}
					resourceName = Ext.String.format(menuItemIconNameTemplate, itemTag, pressedSuffix, counterSuffix);
					return this.get("Resources.Images." + resourceName);
				},

				/**
				 * ########## ##### ######## #### CtiPanel ## ### #########.
				 * @private
				 * @param {String} itemTag ############# ######## ####.
				 * @returns {String} ##### ###########.
				 */
				getCtiPanelStyle: function(itemTag) {
					var isItemPressed = this.get("SelectedMenuItem") === itemTag;
					var callDuration = this.get("CallDuration");
					var itemWithCallDuration = (!isItemPressed && !Ext.isEmpty(callDuration));
					return itemWithCallDuration ? "with-call-duration" : "without-call-duration";
				},

				/**
				 * ########## ####### ###### #### "Cti ######". ##### ####### #### ########## ########## #######,
				 * ####, ### ####### ###### # ######### ###### - ############ ######.
				 * @private
				 * @returns {String} ####### ###### #### "Cti ######".
				 */
				getCtiPanelCaption: function(itemTag) {
					var isItemPressed = this.get("SelectedMenuItem") === itemTag;
					var ctiPanelCounter = this.get(itemTag + "Counter");
					var callDuration = this.get("CallDuration");
					if (!isItemPressed) {
						return !Ext.isEmpty(callDuration) ? callDuration : ctiPanelCounter;
					}
					return ctiPanelCounter;
				}
			},
			diff: [
				{
					"operation": "insert",
					"index": 0,
					"parentName": "communicationPanelContent",
					"propertyName": "items",
					"name": "ctiPanel",
					"values": {
						"tag": "CtiPanel",
						"visible": {"bindTo": "CtiPanelVisible"},
						"imageConfig": {"bindTo": "getCtiPanelImageConfig"},
						"caption": {"bindTo": "getCtiPanelCaption"},
						"style": {"bindTo": "getCtiPanelStyle"},
						"generator": "CommunicationPanelHelper.generateMenuItem"
					}
				}
			]
		};
	});
