define("TemplatePropertiesPage", ["TemplatePropertiesPageResources"], function(resources) {
	return {
		properties: {
			defaults: {
				width: 600,
				minWidth: 300,
				maxWidth: 1300,
				breakpointWidth: 480,
				minBreakpointWidth: 300,
				maxBreakpointWidth: 1300,
				background: "#ffffff"
			}
		},
		attributes: {
			/**
			 * Name of current template.
			 * @type {String}
			 */
			"TemplateName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			/**
			 * Actual template width.
			 * @type {Number}
			 */
			"Width": {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "onWidthChanged"
			},
			/**
			 * Actual template width.
			 * @type {Number}
			 */
			"BreakpointWidth": {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "onBreakpointWidthChanged"
			},
			/**
			 * Actual template background.
			 * @type {String}
			 */
			"BackgroundColor": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				onChange: "onBackgroundColorChanged"
			},

			/**
			 * Flag to indicate actual html mode state of content builder.
			 * @type {Boolean}
			 */
			"IsHtmlMode": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Toggle for content builder HTML state mode.
			 * @type {Boolean}
			 */
			"HtmlModeState": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				onChange: "onHtmlModeStateChanged",
				value: false
			}
		},
		messages: {
			/**
			 * @message HtmlContentBuilderModeChanged
			 */
			"HtmlContentBuilderModeChanged": {
				direction: BPMSoft.MessageDirectionType.PUBLISH,
				mode: BPMSoft.MessageMode.PTP
			}
		},
		methods: {

			/**
			 * Flag to indicate that template has own name.
			 * @private
			 * @returns {Boolean}
			 */
			_hasTemplateName: function() {
				return !BPMSoft.isEmpty(this.$TemplateName);
			},

			/**
			 * Returns validation message for template width new value.
			 * @private
			 * @param {Number} value Width value to validate.
			 * @returns {String} Validation result message.
			 */
			_getInvalidWidthMessage: function(value) {
				if (value > this.defaults.maxWidth) {
					return Ext.String.format(resources.localizableStrings.MaxWidthLimitExceptionText,
						this.defaults.maxWidth);
				}
				if (value < this.defaults.minWidth) {
					return Ext.String.format(resources.localizableStrings.MinWidthLimitExceptionText,
						this.defaults.minWidth);
				}
				return "";
			},

			/**
			 * Returns validation message for breakpoint new value.
			 * @private
			 * @param {Number} value Breakpoint width value to validate.
			 * @returns {String} Validation result message.
			 */
			_getInvalidBreakpointWidthMessage: function(value) {
				var maxValue = Math.min(this.defaults.maxBreakpointWidth, this.$Width);
				if (value > maxValue) {
					return Ext.String.format(resources.localizableStrings.MaxWidthLimitExceptionText, maxValue);
				}
				if (value < this.defaults.minBreakpointWidth) {
					return Ext.String.format(resources.localizableStrings.MinWidthLimitExceptionText,
						this.defaults.minBreakpointWidth);
				}
				return "";
			},

			/**
			 * Returns validation result object.
			 * @private
			 * @param {String} invalidMessage Message text.
			 * @returns {Object} Validation result.
			 */
			_getValidationResult: function(invalidMessage) {
				return {
					fullInvalidMessage: invalidMessage,
					invalidMessage: invalidMessage
				};
			},

			/**
			 * @private
			 */
			_isTemplateHtmlModeFeatureEnabled: function() {
				return BPMSoft.Features.getIsEnabled("HtmlContentBuilder");
			},

			/**
			 * @private
			 */
			_isTemplateSettingsVisible: function() {
				return !this.$IsHtmlMode;
			},

			/**
			 * @inheritdoc BPMSoft.ContentItemPropertiesPage#onContentBuilderStateChanged
			 * @override
			 */
			onContentBuilderStateChanged: function() {
				this.callParent(arguments);
				this.initHtmlModeState();
			},

			/**
			 * Validates input width value, if the validation has passed, sets width of template.
			 * @protected
			 * @param {Number} value Template Width.
			 * @return {Object} Validation result.
			 */
			widthRangeValidator: function(value) {
				var invalidMessage = this._getInvalidWidthMessage(value);
				return this._getValidationResult(invalidMessage);
			},

			/**
			 * Validates input breakpoint value, if the validation has passed, sets breakpoint of template.
			 * @protected
			 * @param {Number} value Template breakpoint.
			 * @return {Object} Validation result.
			 */
			breakpointRangeValidator: function(value) {
				var invalidMessage = this._getInvalidBreakpointWidthMessage(value);
				return this._getValidationResult(invalidMessage);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BasePageV2#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Width", this.widthRangeValidator);
				this.addColumnValidator("BreakpointWidth", this.breakpointRangeValidator);
			},

			/**
			 * Inits template props for HTML state mode based on actual content builder state.
			 */
			initHtmlModeState: function() {
				var isHtmlMode = Boolean(this.$ContentBuilderState === BPMSoft.ContentBuilderState.HTML);
				this.$IsHtmlMode = isHtmlMode;
				this.$HtmlModeState = isHtmlMode;
			},

			/**
			 * Sets initial values for template page attributes.
			 * @protected
			*/
			initAttributes: function() {
				this.$Width = this.$Config.Width || this.defaults.width;
				this.$BreakpointWidth = this.$Config.BreakpointWidth || this.defaults.breakpointWidth;
				this.$TemplateName = this.$Config.TemplateName;
				this.$BackgroundColor = this.$Config.BackgroundColor || this.defaults.background;
				this.initHtmlModeState();
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @override
			 */
			onContentItemConfigChanged: function(config) {
				this.callParent(arguments);
				if (config) {
					this.$Config = config;
					this.initAttributes();
				}
			},

			/**
			 * Handler on template width changed event.
			 * @protected
			 * @param {Object} changedItem Changed view model.
			 * @param {Number} value New value.
			 */
			onWidthChanged: function(changedItem, value) {
				if (this.$Config.Width === value) {
					return;
				}
				if (this.validateColumn("Width")) {
					this.$Config.Width = this.$Width;
					if (this.$BreakpointWidth > this.$Width) {
						this.$Config.BreakpointWidth = this.$Width;
						this.set("BreakpointWidth", this.$Width);
					}
					this.save();
				}
			},

			/**
			 * Handler on template breakpoint width changed event.
			 * @protected
			 * @param {Object} changedItem Changed view model.
			 * @param {Number} value New value.
			 */
			onBreakpointWidthChanged: function(changedItem, value) {
				if (this.$Config.BreakpointWidth === value) {
					return;
				}
				if (this.validateColumn("BreakpointWidth")) {
					this.$Config.BreakpointWidth = this.$BreakpointWidth;
					this.save();
				}
			},

			/**
			 * Handler on template background color changed event.
			 * @protected
			 * @param {Object} changedItem Changed view model.
			 * @param {Number} value New value.
			 */
			onBackgroundColorChanged: function(changedItem, value) {
				if (this.$Config.BackgroundColor === value) {
					return;
				}
				this.$Config.BackgroundColor = this.$BackgroundColor;
				this.save();
			},

			/**
			 * Handles HTML mode state change event based on user confirmation result.
			 * @param {String} returnCode Message box return code.
			 */
			htmlModeStateChangeHandler: function(returnCode) {
				if (returnCode === BPMSoft.MessageBoxButtons.OK.returnCode) {
					this.$IsHtmlMode = this.$HtmlModeState;
					this.sandbox.publish("HtmlContentBuilderModeChanged", this.$IsHtmlMode);
					return;
				}
				this.$HtmlModeState = !this.$HtmlModeState;
			},

			/**
			 * Handler on HTML mode state change event.
			 */
			onHtmlModeStateChanged: function() {
				if (this.$HtmlModeState === this.$IsHtmlMode) {
					return;
				}
				var message = this.$HtmlModeState
					? this.get("Resources.Strings.ToHtmlContentBuilderModeMessage")
					: this.get("Resources.Strings.ToMjmlContentBuilderModeMessage");
				this.showConfirmationDialog(message, this.htmlModeStateChangeHandler, [
					this.BPMSoft.MessageBoxButtons.OK.returnCode,
					this.BPMSoft.MessageBoxButtons.CANCEL.returnCode
				]);
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "TemplatePropertiesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-properties-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "TemplateSettingsContainer",
				"propertyName": "items",
				"parentName": "TemplatePropertiesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["template-settings-container"]
				}
			},
			{
				"operation": "insert",
				"name": "TemplateModeContainer",
				"propertyName": "items",
				"parentName": "TemplateSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": "$_isTemplateHtmlModeFeatureEnabled",
					"items": []
				}
			},
			{
				"name": "HtmlModeState",
				"parentName": "TemplateModeContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.ToggleEdit",
					"wrapClass": [
						"template-html-mode-toggle",
					],
					"classes": {
						"labelClass": ["template-html-mode-toggle-label"]
					},
					"caption": {"bindTo": "Resources.Strings.IsHtmlOnlyModeCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "TemplateNameContainer",
				"propertyName": "items",
				"parentName": "TemplateSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": "$_hasTemplateName",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "TemplateNameLabel",
				"parentName": "TemplateNameContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.TemplateNameCaption",
					"classes": {
						"labelClass": ["t-properties-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "TemplateName",
				"parentName": "TemplateNameContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": "$TemplateName",
					"wrapClass": ["template-name"]
				}
			},
			{
				"operation": "insert",
				"name": "TemplateSizeContainer",
				"propertyName": "items",
				"parentName": "TemplateSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": "$_isTemplateSettingsVisible",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "TemplateSizeGroup",
				"parentName": "TemplateSizeContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
					"wrapClass": ["t-properties-label"]
				}
			},
			{
				"operation": "insert",
				"name": "TemplateWidthContainer",
				"propertyName": "items",
				"parentName": "TemplateSizeContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "TemplateWidthLabel",
				"parentName": "TemplateWidthContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.TemplateWidthCaption",
					"classes": {
						"labelClass": ["t-sub-properties-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "Width",
				"parentName": "TemplateWidthContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"wrapClass": ["template-width-prop-wrap"]
				}
			},
			{
				"operation": "insert",
				"name": "TemplateBreakpointContainer",
				"propertyName": "items",
				"parentName": "TemplateSizeContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "TemplateBreakpointLabelContainer",
				"propertyName": "items",
				"parentName": "TemplateBreakpointContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["template-breakpoint-label-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "TemplateBreakpointLabel",
				"parentName": "TemplateBreakpointLabelContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.TemplateBreakpointCaption",
					"classes": {
						"labelClass": ["t-sub-properties-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "BreakpointPropertyInfoButton",
				"parentName": "TemplateBreakpointLabelContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$Resources.Strings.BreakpointHintText",
					"style": BPMSoft.TipStyle.WHITE,
					"behaviour": {
						"displayEvent": BPMSoft.controls.TipEnums.displayEvent.HOVER
							| BPMSoft.controls.TipEnums.displayEvent.CLICK
					},
					"tools": []
				}
			},
			{
				"operation": "insert",
				"name": "BreakpointWidth",
				"parentName": "TemplateBreakpointContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"wrapClass": ["template-width-prop-wrap"]
				}
			},
			{
				"operation": "insert",
				"name": "TemplateStylesContainer",
				"propertyName": "items",
				"parentName": "TemplateSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": "$_isTemplateSettingsVisible",
					"wrapClass": ["template-styles-container"]
				}
			},
			{
				"operation": "insert",
				"name": "TemplateBackgroundColorLabel",
				"parentName": "TemplateStylesContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.TemplateBackgroundCaption",
					"classes": {
						"labelClass": ["t-properties-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "BackgroundColorButton",
				"parentName": "TemplateStylesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.COLOR_BUTTON,
					"value": {"bindTo": "BackgroundColor"},
					"classes": {
						"wrapClasses": ["template-color-button"]
					},
					"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER
				}
			}
		]
	};
});
