define("CustomCronExpressionPage", ["CustomCronExpressionPageResources",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function() {
	return {
		methods: {

			/**
			 * Custom cron expression validator.
			 * @private
			 * @param {String} mappingValue User cron expression.
			 * @return {Object} Validation info.
			 */
			_cronExpressionValidator: function(mappingValue) {
				var info = this.getCronValidationInfo(mappingValue);
				return {
					invalidMessage: info.error
				};
			},

			/**
			 * Returns full validation info for process designer.
			 * @protected
			 * @param {String} cronString Source cron string.
			 * @return {Object} Validation info.
			 */
			getCronValidationInfo: function(cronString) {
				var cron = BPMSoft.CronExpression.from(cronString);
				var validationInfo = cron.validate();
				if (validationInfo.isValid) {
					var secondsParameter = cron.getParameter(BPMSoft.cron.Parameters.Seconds);
					var allowedSecondsCharacter = "0";
					if (secondsParameter !== allowedSecondsCharacter) {
						var exceptions = BPMSoft.Resources.ProcessSchemaDesigner.Exceptions;
						validationInfo.error = exceptions.InvalidCronSecondsException;
					}
				}
				return validationInfo;
			},

			/**
			 * Returns custom cron expression description visibility.
			 * @return {Boolean} Description visibility.
			 */
			isCronExpressionValid: function() {
				var cronString = this.get("CronExpression");
				var validationInfo = BPMSoft.CronExpression.validate(cronString);
				return validationInfo.isValid;
			},

			/**
			 * Returns custom cron expression description.
			 * @return {String} Custom cron expression description.
			 */
			getCronExpressionDescription: function() {
				var cronString = this.get("CronExpression");
				var cron = BPMSoft.CronExpression.from(cronString);
				return BPMSoft.CronExpressionDescriptor.describe(cron);
			},

			/**
			 * Returns cron expression info text.
			 * @return {String} Cron expression info text.
			 */
			getCustomCronExpressionInfoText: function() {
				var pattern = this.get("Resources.Strings.CronExpressionInfoButtonPattern");
				var readMore = this.get("Resources.Strings.ReadMoreCaption");
				var caption = this.get("Resources.Strings.CronExpressionInfoButtonCaption");
				return Ext.String.format(pattern, readMore, caption);
			},

			/**
			 * @inheritdoc ProcessBaseEventPropertiesPage#setValidationConfig
			 * @overriden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("CronExpression", this._cronExpressionValidator);
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "CustomCronExpressionContainer",
				"parentName": "SectionContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomCronExpressionContainer",
				"propertyName": "items",
				"name": "CustomCronExpressionGroup",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "CustomCronExpressionLabel",
				"parentName": "CustomCronExpressionGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 22
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.CustomCronExpressionLabel"},
					"classes": {"labelClass": ["start-timer-properties-page-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "CronExpression",
				"parentName": "CustomCronExpressionGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 23
					},
					"labelConfig": {"visible": false},
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"value": {"bindTo": "CronExpression"},
						"focused": true
					},
					"wrapClass": []
				}
			},
			{
				"operation": "insert",
				"name": "CronExpressionInfoButton",
				"parentName": "CustomCronExpressionGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 23,
						"row": 1,
						"colSpan": 2
					},
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo": "getCustomCronExpressionInfoText"},
					"behaviour": {"displayEvent": BPMSoft.controls.TipEnums.displayEvent.CLICK}
				}
			},
			{
				"operation": "insert",
				"name": "CustomCronExpressionDescriptorContainer",
				"parentName": "SectionContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 26
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {"bindTo": "isCronExpressionValid"}
				}
			},
			{
				"operation": "insert",
				"name": "CustomCronExpressionDescriptorLabel",
				"parentName": "CustomCronExpressionDescriptorContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getCronExpressionDescription"},
					"classes": {"labelClass": ["custom-cron-description-box"]},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
				}
			}
		]
	};
});