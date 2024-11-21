define("ContactPageV2", ["ContactPageV2Resources", "css!ContactPageV2CSS", "EmailEnrichmentMixin"], function() {
		return {
			entitySchemaName: "Contact",
			messages: {

				/**
				 * Update contact enrichment page visibility.
				 */
				"ContactEnrichmentPageVisibilityChanged": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {
				/**
				 * @class BPMSoft.EmailEnrichmentMixin
				 * Email enrichment mixin.
				 */
				EmailEnrichmentMixin: "BPMSoft.EmailEnrichmentMixin"
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.set("CallerSource", "ContactPageV2");
					this.subscribeCloudUpdateEvents();
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.unsubscribeCloudUpdateEvents();
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					BPMSoft.delay(this.getContactsFromServer, this, 1000);
					this.callParent(arguments);
				},

				/**
				 * Returns additional enrich actions request config.
				 * @protected
				 * @virtual
				 * @return {Object} Aditional enrich actions request config.
				 */
				getAdditionalActionsRequestConfig: function() {
					return {
						methodName: "GetCloudStateForContact",
						data: {
							contactId: this.get("Id")
						}
					};
				},

				/**
				 * Enrich contact button click handler.
				 * @protected
				 * @virtual
				 */
				onEnrichContact: function() {
					var config = this.getOpenWindowConfig({
						ContactId: this.get("Id")
					}, {
						value: this.get("Name")
					});
					var tag = this.Ext.encode(config);
					this.openEnrichmentWindow(tag);
				},

				/**
				 * Removes viewmodel subscription to server messages.
				 * @protected
				 */
				unsubscribeCloudUpdateEvents: function() {
					this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE,
						this.onCloudUpdateMessage, this);
				},

				/**
				 * Subscribes viewmodel to server messages.
				 * @protected
				 */
				subscribeCloudUpdateEvents: function() {
					this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE,
						this.onCloudUpdateMessage, this);
				},

				/**
				 * Server message handler. Reloads contact page after enrich events.
				 * @protected
				 * @param {Object} scope Message scope.
				 * @param {Object} message Server messsage.
				 */
				onCloudUpdateMessage: function(scope, message) {
					if (message && message.Header && message.Header.Sender !== "EmailMining") {
						return;
					}
					var receivedMessage = this.Ext.decode(message.Body);
					var contactId = this.get("Id");
					var currentContactItems = this.Ext.Array.findBy(receivedMessage, function(item) {
							return item.contactId === contactId;
						}, this);
					if (message.Header.BodyTypeName === this.BPMSoft.EmailMiningEnums.EnrichMessageBodyType.SAVED &&
							this.isNotEmpty(currentContactItems)) {
						this.reloadEntity();
					}
				},

				/**
				 * Returns visibility of enrichment button.
				 * @protected
				 * @virtual
				 * @return {Boolean} Sign of enrichment button visibility.
				 */
				getCloudVisible: function() {
					return this.get("IsEntityInitialized") && this.get("isCloudVisible");
				}

				//endregion

			},
			details: /**SCHEMA_DETAILS*/ {} /**SCHEMA_DETAILS*/ ,
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "PhotoTimeZoneContainer",
					"values": {
						"classes": {
							"wrapClassName": ["photo-timezone-container", "enrichment"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "EnrichCloudAndTimezoneContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["timezone-enrichment-container"],
						"items": [],
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "move",
					"name": "TimezoneContactPage",
					"parentName": "EnrichCloudAndTimezoneContainer",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "EnrichCloudAndTimezoneContainer",
					"propertyName": "items",
					"name": "EnrichCloudIcon",
					"index": 2,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.EnrichCloudIcon"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"markerValue": "EnrichContactButton",
						"click": {bindTo: "onEnrichContact"},
						"visible": {"bindTo": "getCloudVisible"},
						"classes": {
							wrapperClass: ["enrich-contact-cloud"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EnrichCloudAndTimezoneContainer",
					"propertyName": "items",
					"name": "EnrichCloudCaption",
					"index": 3,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"markerValue": "EnrichContactButtonCaption",
						"click": {bindTo: "onEnrichContact"},
						"visible": {"bindTo": "getCloudVisible"},
						"caption": {"bindTo": "Resources.Strings.EnrichCloudCaption"},
						"classes": {
							textClass: ["enrich-contact-cloud-caption"]
						}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
