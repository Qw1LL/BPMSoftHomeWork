BPMSoft.PageCache.addItem("PortalMessagePublisherPage", {
	controllerName: "BPMSoft.configuration.controller.PortalMessagePublisherPage",
	pageSchemaName: "PortalMessagePublisherPage",
	viewXClass: "BPMSoft.configuration.view.PortalMessagePublisherPage"
});

/**
 * @class BPMSoft.configuration.view.PortalMessagePublisherPage
 */
Ext.define("BPMSoft.configuration.view.PortalMessagePublisherPage", {
	extend: "BPMSoft.view.BasePage",

	config: {

		/**
		 * @inheritdoc
		 */
		id: "PortalMessagePublisherPage",

		/**
		 * @inheritdoc
		 */
		scrollable: "vertical",

		/**
		 * @inheritdoc
		 */
		navigationPanel: {
			backButton: true
		},

		/**
		 * @cfg {Object} messageComponent Publication button.
		 */
		messageComponent: {
			xtype: "tstextarea",
			cls: "cf-portal-message",
			minRows: 5
		},

		/**
		 * @cfg {Object} publishButton Publication button.
		 */
		publishButton: {
			xtype: "button",
			cls: "cf-portal-message-publish-button"
		}

	},

	/**
	 * @cfg-applier
	 * @protected
	 * @virtual
	 */
	applyMessageComponent: function(config) {
		config.placeHolder = config.label = BPMSoft.LS["PortalMessagePublisherPage.MessagePlaceHolder"];
		return Ext.factory(config);
	},

	/**
	 * @cfg-updater
	 * @protected
	 * @virtual
	 */
	updateMessageComponent: function(component) {
		this.add(component);
	},

	/**
	 * @cfg-applier
	 * @protected
	 * @virtual
	 */
	applyPublishButton: function(config) {
		config.text = BPMSoft.LS["PortalMessagePublisherPage.PublishButton.Text"];
		var navigationPanel = this.getNavigationPanel();
		return navigationPanel.addButton(config);
	}

});

/**
 * @class BPMSoft.configuration.controller.PortalMessagePublisherPage
 */
Ext.define("BPMSoft.configuration.controller.PortalMessagePublisherPage", {
	extend: "BPMSoft.controller.BasePage",

	config: {

		/**
		 * @inheritdoc
		 */
		refs: {
			view: "#PortalMessagePublisherPage"
		}

	},

	/**
	 * @private
	 */
	record: null,

	/**
	 * @private
	 */
	entitySchemaUId: null,

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	initializeView: function(view) {
		this.callParent(arguments);
		this.initializeNavigationTitle();
		var publishButton = view.getPublishButton();
		publishButton.on("tap", this.onPublishButtonTap, this);
		var messageComponent = view.getMessageComponent();
		messageComponent.on("painted", this.onMessageComponentPainted, this);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getTitle: function() {
		return BPMSoft.LS["PortalMessagePublisherPage.Title"];
	},

	/**
	 * Called when publication button has been tapped.
	 * @param {Ext.Button} button Instance of component.
	 * @inheritdoc
	 * @protected
	 * @virtual
	 */
	onPublishButtonTap: function(button) {
		BPMSoft.Mask.show();
		button.setDisabled(true);
		this.publish(function() {
			BPMSoft.Mask.hide();
			button.setDisabled(false);
			BPMSoft.Router.back();
		}, function(exception) {
			BPMSoft.Mask.hide();
			button.setDisabled(false);
			exception = Ext.create("BPMSoft.Exception", {
				message: BPMSoft.LS["PortalMessagePublisherPage.PublicationError"],
				innerException: exception
			});
			BPMSoft.MessageBox.showException(exception);
		});
	},

	/**
	 * Called when message component has been painted.
	 * @inheritdoc
	 * @protected
	 * @virtual
	 */
	onMessageComponentPainted: function() {
		var view = this.getView();
		var messageComponent = view.getMessageComponent();
		messageComponent.focus();
	},

	/**
	 * Publishes message.
	 * @protected
	 * @param {Function} success Callback function.
	 * @param {Function} failure Callback function.
	 */
	publish: function(success, failure) {
		var data = this.getPublishData();
		BPMSoft.ServiceHelper.issueRequest({
			serviceName: "MessagePublisherService",
			methodName: this.getServiceMethodName(),
			data: {
				className: "BPMSoft.Configuration.PortalMessagePublisher",
				fieldsData: data
			},
			success: function(response) {
				if (response.PublishMessageResult.success === true) {
					Ext.callback(success, this);
				} else {
					var exception = Ext.create("BPMSoft.Exception", {
						message: Ext.JSON.encode(response.PublishMessageResult.errorInfo)
					});
					Ext.callback(failure, this, [exception]);
				}
			},
			failure: failure,
			scope: this
		});
	},

	/**
	 * Returns data for request to service.
	 * @return {Object} Data for request to service.
	 */
	getPublishData: function() {
		var view = this.getView();
		var messageComponent = view.getMessageComponent();
		return [
			{Key: "EntitySchemaUId", Value: this.entitySchemaUId},
			{Key: "EntityId", Value: this.record.getId()},
			{Key: "Id", Value: BPMSoft.util.genGuid()},
			{Key: "Message", Value: messageComponent.getValue()}
		];
	},

	/**
	 * Returns method of service.
	 * @return {String} Method name.
	 */
	getServiceMethodName: function() {
		return BPMSoft.Features.getIsEnabled("HandleMessagePublishingExceptions")
			? "PublishMessage" : "Publish";
	},

	/**
	 * @inheritdoc
	 */
	pageLoadComplete: function() {
		this.callParent(arguments);
		var pageHistoryItem = this.getPageHistoryItem();
		var config = pageHistoryItem.getRawConfig();
		this.record = config.record;
		this.entitySchemaUId = config.entitySchemaUId;
	}

});
