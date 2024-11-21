define("FileImportProcessingPage", ["FileImportServerChannelResponse"],
	function() {
		return {
			attributes: {
				/**
				 * File import message header.
				 */
				FileImportMessageHeader: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "FileImport"
				},
				/**
				 * File import complete message.
				 */
				FileImportCompleteMessage: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "complete"
				},
				/**
				 * Percent of processing.
				 */
				ProcessingPercent: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					value: 0
				},
				NextStepPageName: {
					value: "FileImportResultPage"
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Initializes server channel events.
				 * @private
				 */
				initServerChannelEvents: function() {
					this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE,
						this.onServerChannelMessageReceived, this);
				},

				/**
				 * Destroys server channel events.
				 * @private
				 */
				destroyServerChannelEvents: function() {
					this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE,
						this.onServerChannelMessageReceived, this);
				},

				//endregion

				//region Methods: Protected

				/**
				 * Creates server channel response.
				 * @protected
				 * @virtual
				 * @param {Object} responseConfig Response configuration.
				 * @return {Object} Server channel response.
				 */
				createServerChannelResponse: function(responseConfig) {
					return this.Ext.create(this.get("ServerChannelResponseClassName"), responseConfig);
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc BPMSoft.BaseWizardStepPage#init
				 * @overridden
				 */
				init: function() {
					this.initServerChannelEvents();
					this.callParent(arguments);
					this.set("ServerChannelResponseClassName", "BPMSoft.FileImportServerChannelResponse");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.destroyServerChannelEvents();
					this.callParent(arguments);
				},

				/**
				 * Handles server channel message.
				 * @param {BPMSoft.core.ServerChannel} channel Messaging channel.
				 * @param {Object} message Server message.
				 * @param {Object} message.Header Message header.
				 * @param {Object} message.Body Message body.
				 */
				onServerChannelMessageReceived: function(channel, message) {
					var serverResponse = this.createServerChannelResponse({
						message: message
					});
					var fileImportCompleteMessage = this.get("FileImportCompleteMessage");
					var fileImportMessageHeader = this.get("FileImportMessageHeader");
					if (!serverResponse.validateSender(fileImportMessageHeader)) {
						return;
					}
					var importSessionId = this.get("ImportSessionId");
					if (importSessionId !== serverResponse.getImportSessionId()) {
						return;
					}
					var status = serverResponse.getStatus();
					if (this.BPMSoft.isEmptyObject(status)) {
						return;
					}
					if (status.stage === fileImportCompleteMessage) {
						this.switchToNextStep();
					} else {
						var percent = status.percent;
						this.set("ProcessingPercent", percent);
					}
				},

				/**
				 * Gets import processing percent label caption.
				 * @return {String}
				 */
				getProcessingStatusLabelCaption: function() {
					var format = this.get("Resources.Strings.ProcessingStatusLabelFormat");
					var processingPercent = this.get("ProcessingPercent");
					return this.Ext.String.format(format, processingPercent);
				}

				//endregion

			},
			diff: [
				{
					"operation": "merge",
					"name": "HeaderContainer",
					"values": {
						"classes": {"wrapClassName": ["header-container", "processing"]}
					}
				},
				{
					"operation": "merge",
					"name": "CenterContainer",
					"values": {
						"classes": {"wrapClassName": ["center-container", "processing"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "CenterContainer",
					"name": "ProcessingContainer",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["processing-wrapper"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ProcessingStatusLabel",
					"parentName": "ProcessingContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getProcessingStatusLabelCaption"},
						"classes": {
							"labelClass": ["processing-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ThanksLabel",
					"parentName": "ProcessingContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.ThanksLabelCaption"},
						"classes": {
							"labelClass": ["thanks-label"]
						}
					}
				},
				{
					"operation": "remove",
					"name": "FooterContainer"
				}
			]
		};
	}
);
