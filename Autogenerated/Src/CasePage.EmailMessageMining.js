define("CasePage", ["EmailMiningEnums"], function() {
		return {

			messages: {

				/**
				 * Update case contact.
				 */
				"CaseContactUpdate": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},

			methods: {

				//region Methods: Private

				/**
				 * Returns "UpdateCaseByContact" query.
				 * @private
				 * @param {String} contactId Sender contact identifier.
				 * @return {Object} "UpdateCaseByContact" query.
				 */
				_getUpdateCaseByContactQuery: function(contactId) {
					var update = Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "Case"
					});
					var caseId = this.get("Id");
					update.enablePrimaryColumnFilter(caseId);
					update.setParameterValue("Contact", contactId, this.BPMSoft.DataValueType.LOOKUP);
					return update;
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.subscribeCloudUpdateEvents();
					this.callParent(arguments);
					this.sandbox.subscribe("CaseContactUpdate", function(contactId) {
						this.updateCaseByContact(contactId);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.unsubscribeCloudUpdateEvents();
					this.callParent(arguments);

					Ext.get("communicationPanelContent").dom.querySelectorAll(".t-btn-wrapper").forEach((item)=>{
						item.removeEventListener('click', this.setOffsetMethod);
					});
					Ext.EventManager.removeListener(window, 'resize', this.setOffsetMethod);
					this.initOffsetMethod().disconnect();

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
					var enrichMessageBodyType = this.BPMSoft.EmailMiningEnums.EnrichMessageBodyType.SAVED;
					if (!message || !message.Header || message.Header.Sender !== "EmailMining" ||
							message.Header.BodyTypeName !== enrichMessageBodyType) {
						return;
					}
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Activity"
					});
					esq.addMacrosColumn(this.BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Case", this.get("Id")));
					esq.getEntityCollection(function(response) {
						if (response.success) {
							var receivedMessage = this.Ext.decode(message.Body);
							response.collection.each(function(item) {
								var activityId = item.get("Id");
								var currentActivityItems = BPMSoft.findItem(receivedMessage, {activityId: activityId});
								if (this.isNotEmpty(currentActivityItems)) {
									var currentActivityItem = currentActivityItems.item;
									var contactId = currentActivityItem.contactId;
									if (this.isEmpty(this.get("Contact")) && this.isNotEmpty(contactId)) {
										this.showSetCaseContactMessageConfirmationDialog(contactId,
											currentActivityItem.contactName);
									} else {
										this.reloadEntity();
									}
									return false;
								}
							}, this);
						}
					}, this);
				},

				/**
				 * Show "Set case contact message" confirmation dialog.
				 * @param {String} contactId Sender contact identifier.
				 * @param {String} contactName Sender contact name.
				 * @protected
				 */
				showSetCaseContactMessageConfirmationDialog: function(contactId, contactName) {
					var setCaseContactMessage = this.Ext.String.format(
						this.get("Resources.Strings.SetCaseContactMessage"), contactName);
					this.showConfirmationDialog(setCaseContactMessage, function(returnCode) {
						if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
							this.updateCaseByContact(contactId);
						} else {
							this.reloadEntity();
						}
					}, ["yes", "no"]);
				},

				/**
				 * Connect selected contact to case.
				 * @param {String} contactId Sender contact identifier.
				 * @protected
				 */
				updateCaseByContact: function(contactId) {
					var update = this._getUpdateCaseByContactQuery(contactId);
					update.execute(this.reloadEntity, this);
				},

				//endregion

				setOffsetMethod: function() {
					var buttonsContainer = Ext.get("CasePageActionButtonsContainerContainer");
					var cardContentWrapper = Ext.get("CardContentWrapper");
					var containers = [
						Ext.get("LeftModulesContainer"),
						Ext.get("CardContentContainer")
					];
					
					if(buttonsContainer && cardContentWrapper && containers.length === 2) {
						var cardContentWrapperOffset = 
							parseInt(getComputedStyle(cardContentWrapper.dom).marginTop, 10) + 
							parseInt(getComputedStyle(cardContentWrapper.dom).paddingTop, 10);
						
						var offset = `${buttonsContainer.dom.offsetHeight - cardContentWrapperOffset + 8}` + "px";

						containers.forEach((container) => {
							container.setStyle("margin-top", offset);
						})
					}
				},
			
				initOffsetMethod: function() {
					Ext.EventManager.addListener(window, 'resize', this.setOffsetMethod);
					Ext.get("communicationPanelContent").dom.querySelectorAll(".t-btn-wrapper").forEach((item)=>{
						item.addEventListener("click", this.setOffsetMethod);
					});
					var observer = new MutationObserver(this.setOffsetMethod);
					observer.observe(Ext.get("CasePageActionButtonsContainerContainer").dom, {
						childList: true,
						subtree: true
					});

					return observer;
				},
				
			},
			details: /**SCHEMA_DETAILS*/ {} /**SCHEMA_DETAILS*/ ,
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "ActionButtonsContainer",
					"values": {
						"afterrender": {"bindTo": "initOffsetMethod"}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
