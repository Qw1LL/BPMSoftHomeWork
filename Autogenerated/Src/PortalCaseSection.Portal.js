define("PortalCaseSection", [],
	function () {
		return {
			entitySchemaName: "Case",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "DataGridActiveRowDeleteAction"
				},
				{
					"operation": "remove",
					"name": "RightContainer"
				},
				{
					"operation": "remove",
					"name": "CombinedModeActionButtonsCardRightContainer"
				},
				{
					"operation": "insert",
					"name": "ComplainButton",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.Complain"},
						"caption": {
							"bindTo": "Resources.Strings.ComplainButtonCaption"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"wrapperClass": ["complain-button"]
						},
						"click": {"bindTo": "onComplainButtonClick"},
						"visible": {
							"bindTo": "getIsComplainButtonVisible"
						}
					},
					"index": 10
				}
			]/**SCHEMA_DIFF*/,
			messages: {
				/**
				 * @message OnComplainButtonClick
				 * Event Complain button clicked.
				 */
				"OnComplainButtonClick": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message ChangeComplainButtonVisibility
				 * Message for hide complain button.
				 */
				"ChangeComplainButtonVisibility": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Determines if folder filter is available.
				 */
				"UseFolderFilter": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * EnableComplainFunction SysSettings value.
				 */
				"EnableComplainFunction": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * EnableCancelAction menu item enabled value.
				 */
				"EnableCancelAction": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * EnableReopenAction menu item enabled value.
				 */
				"EnableReopenAction": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function () {
					this.callParent(arguments);
					this.sandbox.subscribe("ChangeComplainButtonVisibility",
						this.setEnableComplainFunctionAttribute, this, [this.sandbox.id + "_CardModuleV2"]);
				},

				/**
				 * Sets EnableComplainFunction attribute
				 * @param {Boolean} complainFunctionAvailability Availability of complain button
				 * @private
				 */
				setEnableComplainFunctionAttribute: function (complainFunctionAvailability) {
					this.set("EnableComplainFunction", complainFunctionAvailability);
				},

				/**
				 * Sets context help identifier.
				 * @overridden
				 * @protected
				 */
				initContextHelp: function () {
					this.enableContextHelp = false;
				},

				/**
				 * @overridden BPMSoft.BaseSectionV2#isVisibleDeleteAction
				 * @return {Boolean} Visible of delete action
				 */
				isVisibleDeleteAction: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
				 * @overridden
				 * @protected
				 * @return {Object}
				 */
				getDefaultDataViews: function () {
					var gridDataView = {
						name: this.get("GridDataViewName"),
						caption: this.getDefaultGridDataViewCaption(),
						icon: this.getDefaultGridDataViewIcon()
					};
					return {
						"GridDataView": gridDataView
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#initFixedFiltersConfig
				 * @overridden
				 */
				initFixedFiltersConfig: this.BPMSoft.emptyFn,

				/**
				 * Read required SysSettings values.
				 * @protected
				 */
				initSysSettings: function () {
					BPMSoft.SysSettings.querySysSettingsItem("EnableComplainFunction", function (value) {
						this.set("EnableComplainFunction", value);
					}, this);
				},

				/**
				 * Gets visibility of Complain button.
				 * @returns {Boolean}
				 */
				getIsComplainButtonVisible: function () {
					return this.get("EnableComplainFunction");
				},

				/**
				 * Complain button click handler.
				 */
				onComplainButtonClick: function () {
					this.sandbox.publish("OnComplainButtonClick", {},
						[this.sandbox.id + "_CardModuleV2"]);
				},

				/**
				 * Call service for canceling case.
				 * @protected
				 */
				cancelCase: function () {
					this.onCardAction("cancelCase");
				},

				/**
				 * Call service for closing case.
				 * @protected
				 */
				closeCase: function () {
					this.onCardAction("closeCase");
				},

				/**
				 * Call service for closing case.
				 * @protected
				 */
				reopenCase: function () {
					this.onCardAction("reopenCase");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function () {
					this.initSysSettings();
					this.set("UseFolderFilter", this.BPMSoft.Features.getIsEnabled("PortalColumnConfig"));
					this.callParent(arguments);
				}
			}

		};
	});
