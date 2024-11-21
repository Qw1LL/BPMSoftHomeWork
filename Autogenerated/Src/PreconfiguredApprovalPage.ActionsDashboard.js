/**
 * Parent: BaseMiniPage
 */
define("PreconfiguredApprovalPage", ["ConfigurationConstants", "PreconfiguredApprovalPageResources"],
	function(ConfigurationConstants, resources) {
		return {
			attributes: {
				/**
				 * @inheritdoc BaseMiniPage#MiniPageModes
				 * @override
				 */
				"MiniPageModes": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: [BPMSoft.ConfigurationEnums.CardOperation.EDIT]
				}
			},
			methods: {

				// region Methods: Private

				/**
				 * Initializes status.
				 * @private
				 */
				_initStatus: function() {
					var defaultValues = this.getDefaultValues();
					BPMSoft.each(defaultValues, function(defaultValue) {
						var name = defaultValue.name;
						this.set(name, defaultValue.value);
					}, this);
					var defaultStatus = this.get("DefaultStatus");
					this.set("Status", defaultStatus);
				},

				// endregion

				// region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseMiniPage#init
				 * @override
				 */
				init: function(callback, scope) {
					this.callParent([
						function() {
							this._initStatus();
							this.Ext.callback(callback, scope || this);
						}, this
					]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMiniPage#initEntity
				 * @override
				 */
				initEntity: function(callback, scope) {
					this.callParent([
						function() {
							var status = this.get("DefaultStatus");
							this.set("Status", status);
							this.set("SetBy", BPMSoft.SysValue.CURRENT_USER_CONTACT);
							this.set("SetDate", new Date());
							Ext.callback(callback, scope || this);
						}, this
					]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMiniPage#adjustMiniPagePosition
				 * @override
				 */
				adjustMiniPagePosition: Ext.callback,

				/**
				 * Handler for click on button.
				 * @protected
				 */
				onButtonClick: function() {
					var config = arguments[3];
					var status = config.status;
					this.set("Status", status);
				},
				
				/**
				 * Get positive icon from status
				 * @protected
				 */
				getPositiveImageIcon: function() {
					let {status} = this.getDomAttribute();
					if(status === 'negative') {
						return resources.localizableImages.ApproveButtonImage
					} else if(status === 'positive') {
						return resources.localizableImages.ApproveButtonImageFilled
					}
				},
				
				/**
				 * Get negative icon from status
				 * @protected
				 */
				getNegativeImageIcon: function() {
					let {status} = this.getDomAttribute();
					if(status === 'negative') {
						return resources.localizableImages.RejectButtonImage
					} else if(status === 'positive') {
						return resources.localizableImages.RejectButtonImageFilled
					}
				},

				/**
				 * Returns background image url.
				 * @protected
				 * @return {String}
				 */
				getBackgroundImageUrl: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.BackgroundImage);
				},

				/**
				 * Returns dom attribute.
				 * @protected
				 * @return {Object}
				 */
				getDomAttribute: function() {
					var status = this.get("Status");
					return {
						status: status && status.value === ConfigurationConstants.VisaStatus.positive.value
							? "positive"
							: "negative"
					};
				},

				/**
				 * Returns true if pressed button status equals to current status.
				 * @protected
				 * @param {Object} buttonConfig Button config.
				 * @param {String} buttonConfig.status Button status.
				 * @return {Boolean} Check result.
				 */
				getIsPressedButton: function(buttonConfig) {
					var buttonStatus = buttonConfig.status;
					var status = this.get("Status");
					return buttonStatus.value === status.value;
				}

				// endregion

			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "remove",
					"name": "MiniPage"
				},
				{
					"operation": "remove",
					"name": "RequiredColumnsContainer"
				},
				{
					"operation": "merge",
					"name": "AlignableMiniPageContainer",
					"values": {
						"alignOrder": [BPMSoft.AlignType.TOP_LEFT],
						"autoAdjustSize": {"width": false}
					}
				},
				{
					"operation": "insert",
					"name": "ApprovePageContainer",
					"values": {
						"id": "ApprovePageContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["approve-minipage-container"],
						"domAttributes": {"bindTo": "getDomAttribute"},
						"items": []
					}
				},
				{
					"operation": "move",
					"name": "AlignableMiniPageContainer",
					"parentName": "ApprovePageContainer",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "MiniPageContentContainer",
					"propertyName": "items",
					"name": "GeneralHeaderContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header", "header-container"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "GeneralHeaderContainer",
					"propertyName": "items",
					"name": "HeaderCaptionContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header-caption-container"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "remove",
					"name": "HeaderBackground",
					"parentName": "GeneralHeaderContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getBackgroundImageUrl",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {"wrapClass": ["background-img"]}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "HeaderCaptionContainer",
					"propertyName": "items",
					"name": "Caption",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Objective"},
						"markerValue": {"bindTo": "Objective"}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "GeneralHeaderContainer",
					"propertyName": "items",
					"name": "HeaderActionsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header-actions-container"],
						"items": []
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ApproveButton",
					"parentName": "HeaderActionsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "Resources.Strings.ApproveButtonCaption"},
						"tag": {"status": ConfigurationConstants.VisaStatus.positive},
						"click": {"bindTo": "onButtonClick"},
						"imageConfig": {"bindTo": "getPositiveImageIcon"},
						"markerValue": "ApproveIconButton",
						"classes": {"wrapperClass": ["action-btn approve-btn"]},
						"pressed": {"bindTo": "getIsPressedButton"}
					}
				},
				{
					"operation": "insert",
					"name": "RejectButton",
					"parentName": "HeaderActionsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "Resources.Strings.RejectButtonCaption"},
						"tag": {"status": ConfigurationConstants.VisaStatus.negative},
						"click": {"bindTo": "onButtonClick"},
						"imageConfig": {"bindTo": "getNegativeImageIcon"},
						"markerValue": "RejectIconButton",
						"classes": {"wrapperClass": ["action-btn reject-btn"]},
						"pressed": {"bindTo": "getIsPressedButton"}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPageContentContainer",
					"name": "BodyContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["body-container"],
						"items": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Comment",
					"parentName": "BodyContainer",
					"propertyName": "items",
					"values": {
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {"visible": false},
						"placeholder": {"bindTo": "Resources.Strings.CommentPlaceholder"},
						"wrapClass": ["square-border"]
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
