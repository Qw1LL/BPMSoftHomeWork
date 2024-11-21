/**
 * Parent: EmailContentBuilder
 */
define("EmailTemplateContentBuilder", [
	"ContentBuilderHelper",
	"css!ContentBuilderCSS",
	"ContentExporterFactory"
], function() {
	return {
		attributes: {
			/**
			 * Current content exporter factory.
			 */
			ContentExporterFactory: {
				dataValueType: BPMSoft.core.enums.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
				value: Ext.create("BPMSoft.ContentExporterFactory")
			}
		},
		messages: {
			"CloseEmailTemplateBuilder": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"SetEmailTemplateData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"GetEmailTemplateData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"SetParametersInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			//region Methods: protected

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#getContentSheetConfig
			 * @override
			 */
			getContentSheetConfig: function(callback, scope) {
				var templateData = this.sandbox.publish("GetEmailTemplateData");
				if (templateData) {
					this.setContentSheetConfig(templateData, callback, scope);
				}
			},

			/**
			 * Sets configuration of the content sheet.
			 * @protected
			 * @param {Object} emailTemplateData Template data.
			 * @param {String} emailTemplateData.bodyConfig Content builder configuration.
			 * @param {String} emailTemplateData.body Html body.
			 * @param {Object} callback Callback-function.
			 * @param {Object} scope Context of the callback-function.
			 */
			setContentSheetConfig: function(emailTemplateData, callback, scope) {
				var config = this.prepareConfig(emailTemplateData);
				Ext.callback(callback, scope || this, [config]);
			},

			/**
			 * Validates object template parameters, html-layout configuration and prepares the content item.
			 * @protected
			 * @param {Object} emailTemplateData Template data.
			 * @param {String} emailTemplateData.bodyConfig Content builder configuration.
			 * @param {String} emailTemplateData.body Html body.
			 * @return {Object} Configuration of the content item.
			 */
			prepareConfig: function(emailTemplateData) {
				var config = {
					"ItemType": "sheet"
				};
				var configText = emailTemplateData.bodyConfig;
				if (Ext.isEmpty(configText)) {
					var html = emailTemplateData.body;
					if (Ext.isEmpty(html)) {
						config.Items = [];
					} else {
						var block = this.getHtmlBlockConfig(html);
						config.Items = [block];
					}
				} else {
					config = BPMSoft.decode(configText);
				}
				return config;
			},

			/**
			 * Returns configuration of the content item for html-markup.
			 * @protected
			 * @param {String} html Html-markup.
			 * @return {Object} Configuration of the content item.
			 */
			getHtmlBlockConfig: function(html) {
				var item = {
					"ItemType": "html",
					"Column": 0,
					"Row": 0,
					"ColSpan": 24,
					"RowSpan": 0,
					"Content": html
				};
				var block = {
					"ItemType": "block",
					"Items": [item]
				};
				return block;
			},

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#cancel
			 * @override
			 */
			cancel: function() {
				this.showInformationDialog(this.get("Resources.Strings.ExitMessage"), this.cancelHandler);
			},

			/**
			 * @inheritdoc BPMSoft.ContentBuilder#save
			 * @override
			 */
			save: function() {
				if (this.validateEmptyItems()) {
					this.showInformationDialog(this.get("Resources.Strings.SaveMessage"), this.saveHandler);
				}
			},

			/**
			 * @protected
			 * @return {boolean}
			 */
			validateEmptyItems: function() {
				var config = this.getContentBuilderConfig();
				if (Ext.isEmpty(config.Items)) {
					var emptyTemplateMessage = this.get("Resources.Strings.EmptyTemplateMessage");
					BPMSoft.utils.showInformation(emptyTemplateMessage);
					return false;
				}
				return true;
			},

			/**
			 * Returns the canvas content configuration.
			 * @protected
			 * @return {Object} Configuration of the content item.
			 */
			getContentBuilderConfig: function() {
				return this.isMjmlConfig()
					? this.serializeViewModel()
					: Ext.create("BPMSoft.ContentBuilderHelper").toJSON(this);
			},

			//endregion

			//region Methods: private

			/**
			 * @private
			 */
			_asyncActionsHandler: function(config) {
				var emailContentExporter = this.$ContentExporterFactory.getExporter(config);
				var configText = BPMSoft.encode(config);
				var displayHtml = emailContentExporter.exportData(config);
				var messageConfig = {
					body: displayHtml,
					bodyConfig: configText
				};
				this.sandbox.publish("SetEmailTemplateData", messageConfig);
				this.sandbox.publish("CloseEmailTemplateBuilder");
			},

			/**
			 * Handler for cancel message box result.
			 * @private
			 * @param {String} buttonCode Message button return code.
			 */
			cancelHandler: function(buttonCode) {
				if (buttonCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
					this.sandbox.publish("CloseEmailTemplateBuilder");
				}
			},

			/**
			 * Shows information dialog.
			 * @private
			 * @param {String} message Information message.
			 * @param {Function} handler Handler for result.
			 */
			showInformationDialog: function(message, handler) {
				BPMSoft.utils.showMessage({
					caption: message,
					buttons: [BPMSoft.MessageBoxButtons.YES, BPMSoft.MessageBoxButtons.NO],
					defaultButton: 0,
					style: BPMSoft.MessageBoxStyles.ORANGE,
					handler: handler,
					scope: this
				});
			},

			/**
			 * Handler for save message box result.
			 * @private
			 * @param {String} buttonCode Message button return code.
			 */
			saveHandler: function(buttonCode) {
				if (buttonCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
					this.forceSave();
				}
			},

			/**
			 * @protected
			 */
			forceSave: function() {
				const config = this.getContentBuilderConfig();
				const images = {};
				const asyncActions = this.getHandlersForAllImages(config, images);
				asyncActions.push(this._asyncActionsHandler.bind(this, config));
				BPMSoft.chain.apply(this, asyncActions);
			}

			//endregion

		}
	}
});
