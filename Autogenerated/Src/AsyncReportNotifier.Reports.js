define("AsyncReportNotifier", ["PrintReportUtilitiesResources", "DesktopPopupNotification", 
	"MaskHelper", "ReportStorage"],
		function(resources, DesktopPopupNotification) {

	Ext.define("BPMSoft.AsyncReportNotifier", {
		extend: "BPMSoft.BaseModule",
		Ext: null,
		sandbox: null,
		BPMSoft: null,
		
		//region Methods: Private
		
		/**
		 * @private
		 */
		_showErrorNotification: function(msgBody) {
			const popupConfig = DesktopPopupNotification.createConfig();
			const body = Ext.String.format(resources.localizableStrings.AsynGenerationErrorPopupBodyTpl,
					msgBody.reportName);
			DesktopPopupNotification.show(Ext.apply(popupConfig, {
				title: resources.localizableStrings.AsynGenerationPopupTitle,
				body: body,
				icon: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.AsynGenerationPopupIcon)
			}));
		},
		
		//endregion
		
		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseModule#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onNotifyMessageReceived, this);
		},
		
		/**
		 * @inheritdoc BPMSoft.BaseModule#onDestroy
		 * @override
		 */
		onDestroy: function() {
			BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE, this.onNotifyMessageReceived, this);
			this.callParent(arguments);
		},

		/**
		 * Handles the message of generate report process finish.
		 * @param {BPMSoft.ServerChannel} channel Channel messaging server.
		 * @param {Object} message Channel message.
		 */
		onNotifyMessageReceived: function(channel, message) {
			if (message.Header && message.Header.Sender === "AsyncReportNotifier") {
				const msgBody = message.Body || {};
				clearTimeout(BPMSoft.ReportStorage.getReportTimeoutId(msgBody.taskId));
				BPMSoft.MaskHelper.hideBodyMask();
				if (!document.hasFocus()) {
					this.error("Could not download report in unfocussed browser tab.");
					return;
				}
				if (!msgBody.success) {
					this._showErrorNotification(msgBody);
					return;
				}
				const href = Ext.String.format("../rest/{0}/{1}/{2}",
						msgBody.serviceName,
						msgBody.methodName,
						msgBody.taskId);
				BPMSoft.download(href, msgBody.reportName);
			}
		}

		//endregion

	});

	return BPMSoft.AsyncReportNotifier;
});
