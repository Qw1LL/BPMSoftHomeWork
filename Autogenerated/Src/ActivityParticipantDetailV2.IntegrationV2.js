define("ActivityParticipantDetailV2", ["ActivityParticipantDetailV2Resources", "ControlGridModule",
		"ActivityParticipantGridViewModel", "ActivityParticipantDetailGridGenerator", "MeetingInvitationsMixin"],
		function(resources, informationButtonResources) {
	return {
		entitySchemaName: "ActivityParticipant",
		mixins: {
			"MeetingInvitationsMixin": "BPMSoft.MeetingInvitationsMixin"
		},
		attributes: {

			/**
			 * Hint about disabled synchronization.
			 */
			"SynchronizationNotEnabledHint": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": BPMSoft.emptyString
			},

			/**
			 * Id of the article about Exchange calendars at the academy.
			 */
			 "ExchangeCalendarArticleId": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": 1421
			},

			/**
			 * Id of the article about Google caledars at the academy.
			 */
			"GoogleCalendarArticleId": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": 1424
			},

			/**
			 * Invitation button visibility enabled.
			 */
			"InvitationButtonEnabled": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Flag that indicates meeting participants exist.
			 */
			"ParticipantsExist": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Flag that indicates a notification has already been sent to participants.
			 */
			"ParticipantsInvited": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Flag that indicates the meeting has been exported to an external calendar.
			 */
			"MeetingExported": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Meeting is out of date.
			 */
			"OutdatedMeeting": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Meeting calendar synchronization since date.
			 */
			"CalendarSyncSinceDate": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": ""
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * Get a link to the academy by identifier.
			 * @param {Number} articleId Article identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			_getAcademyUrl: function(articleId, callback, scope) {
				const config = {
					scope: scope || this,
					contextHelpId: articleId,
					callback: callback
				};
				BPMSoft.AcademyUtilities.getUrl(config);
			},

			/**
			 * Generate a hint about disabled synchronization.
			 */
			_initSynchronizationNotEnabledHint: function() {
				BPMSoft.chain(
					function(next) {
						this._getAcademyUrl(this.get("ExchangeCalendarArticleId"), next, this);
					},
					function(next, exchangeArticleUrl) {
						this._getAcademyUrl(this.get("GoogleCalendarArticleId"), function(googleArticleUrl) {
							next(exchangeArticleUrl, googleArticleUrl);
						}, this);
					},
					function(next, exchangeArticleUrl, googleArticleUrl) {
						this.set("SynchronizationNotEnabledHint", 
							Ext.String.format(resources.localizableStrings.SynchronizationNotEnabledHintTemplate, exchangeArticleUrl,
								googleArticleUrl));
					}, this
				);
			},

			/**
			 * Checking that the current user is the meeting organizer.
			 * @returns {Boolean} True if user is organizer.
			 * @private
			 */
			_userIsOrganizer: function() {
				const organizer = this.get("Organizer");
				return this.isNotEmpty(organizer) &&
					organizer.value === BPMSoft.SysValue.CURRENT_USER_CONTACT.value; 
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				if (this.getIsFeatureEnabled("MeetingInvitation")) {
					this.subscribeServerChannelEvents();
					this._initSynchronizationNotEnabledHint();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
			 * @overridden
			 */
			destroy: function() {
				this.unsubscribeServerChannelEvents();
				this.callParent(arguments);
			},

			/**
			 * Removes viewmodel subscription to server messages.
			 * @protected
			 */
			unsubscribeServerChannelEvents: function() {
				this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE,
					this.onServerChannelMessage, this);
			},

			/**
			 * Subscribes viewmodel to server messages.
			 * @protected
			 */
			subscribeServerChannelEvents: function() {
				this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE,
					this.onServerChannelMessage, this);
			},

			/**
			 * Server message handler.
			 * @protected
			 * @param {Object} scope Message scope.
			 * @param {Object} message Server messsage.
			 */
			 onServerChannelMessage: function(scope, message) {
				if ((this.isEmpty(message) || this.isEmpty(message.Header)) && 
					message.Header.Sender !== "RecordOperationsNotificator") {
					return;
				}
				const body = this.Ext.decode(message.Body);
				const activityRecordChangeMessage = Ext.String.format("{0}RecordChange", this.$DetailColumnName);
				switch (message.Header.BodyTypeName) {
					case activityRecordChangeMessage:
						if (body.RecordId === this.get("MasterRecordId")) {
							this.reloadGridData();
						}
						break;
					default:
						break;
				}
			},

			/**
			 * Check send invitations button visibility.
			 * @protected
			 */
			getInvitationButtonVisible: function() {
				if (!this._userIsOrganizer() || this.getIsFeatureDisabled("MeetingInvitation") ||
					!this.get("ParticipantsExist")) {
					return false;
				}
				return !this.get("InvitationButtonEnabled") || this.get("MeetingExported");
			},

			/**
			 * Send invitations to activity participants.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			onSendInvitationsClick: function(callback, scope) {
				const meetingId = this.get("MasterRecordId");
				BPMSoft.chain(
					function(next) {
						if (this.get("OutdatedMeeting")) {
							this.showConfirmationDialog(resources.localizableStrings.SendingInvitationToOldMeeting,
								function (returnCode) {
									if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
										next();
									}
								}, [BPMSoft.MessageBoxButtons.YES, BPMSoft.MessageBoxButtons.NO]);
						} else {
							next();
						}
					},
					function(next) {
						this.sendInvitations(meetingId, next, this);
					},
					function() {
						this.reloadGridData();
						Ext.callback(callback, scope);
					},
				this);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#onGridLoaded
			 * @protected
			 * @override
			 */
			onGridLoaded: function() {
				this.callParent(arguments);
				if (this.getIsFeatureEnabled("MeetingInvitation")) {
					this.initMeetingInvitationInfo(this.get("MasterRecordId"), BPMSoft.emptyFn, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelClassName
			 * @overridden
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.ActivityParticipantGridViewModel";
			},

			/**
			 * Creates participant column control config.
			 * @protected
			 * @param {Object} control Column control options object.
			 */
			getParticipantControlConfig: function(control) {
				const participantNameLabel = {
					"className": "BPMSoft.Hyperlink",
					"caption": {"bindTo": "Participant"},
					"markerValue": {"bindTo": "getParticipantName"},
					"href": {"bindTo": "getParticipantLink"},
					"linkMouseOver": {bindTo: "linkMouseOver"},
					"target": "_self",
					"classes": {
						"hyperlinkClass": ["name-label"]
					},
					"tag": {
						"columnName": "Participant",
						"referenceSchemaName": "Contact"
					}
				};
				control.config = {
					"className": "BPMSoft.Container",
					"classes": {
						"wrapClassName": ["participant-name-container"]
					},
					"items": [
						participantNameLabel,
						{
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"markerValue": {"bindTo": "getStateIconMarekValue"},
							"imageConfig": {"bindTo": "getStateIconConfig"},
							"classes": {
								"wrapperClass": ["invitation-state"]
							},
							"visible": {"bindTo": "InviteParticipant"},
							"tips": [{"tip": {"content": {"bindTo": "getStateIconTip"}}}]
						}
					]
				};
			},

			/**
			 * @inheritdoc BPMSoft.ActivityParticipantDetailV2#onContactInsert
			 * @overridden
			 */
			onContactInsert: function() {
				const parentMethod = this.getParentMethod();
				const parentArgs = arguments;
				if (this.isInvitationsSent()) {
					this.sendInvitations(this.$MasterRecordId, function () {
						Ext.callback(parentMethod, this, parentArgs)
					}, this);
				} else {
					Ext.callback(parentMethod, this, parentArgs)
				}
			},

			/**
			 * @inheritdoc BPMSoft.ActivityParticipantDetailV2#openContactLookup
			 * @overridden
			 */
			openContactLookup: function() {
				const parentMethod = this.getParentMethod();
				const parentArgs = arguments;
				if (this.getIsFeatureEnabled("MeetingInvitation") && this.isInvitationsSent()) {
					if (this._userIsOrganizer()) {
						const columnsValues = this.sandbox.publish("GetColumnsValues", ["DueDate"], [this.sandbox.id]);
						const dialogMessage = columnsValues.DueDate > new Date()
							? resources.localizableStrings.CanUserChangeMeetingResolveMessage
							: resources.localizableStrings.CanUserChangeObsolteMeetingResolveMessage;
						return this.showConfirmationDialog(dialogMessage,
							function(returnCode) {
								if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
									Ext.callback(parentMethod, this, parentArgs);
								}
						}, [BPMSoft.MessageBoxButtons.YES, BPMSoft.MessageBoxButtons.NO]);
					} else {
						return this.showInformationDialog(resources.localizableStrings.CanNotChangeMeetingMessage);
					}
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getDeleteConfirmationMessage
			 * @overridden
			 */
			getDeleteConfirmationMessage: function(items, callback, scope) {
				const startDate = this.sandbox.publish("GetColumnsValues", ["StartDate"], [this.sandbox.id]);
				if (this.getIsFeatureEnabled("MeetingInvitation") && this.isInvitationsSent() && items
						&& items.length && startDate.StartDate >= new Date(this.$CalendarSyncSinceDate)) {
					if (this._userIsOrganizer()) {
						const message = (items.length > 1)
							? resources.localizableStrings.MultiDeleteMeetingWithInvitationsConfirmationMessage
							: resources.localizableStrings.DeleteMeetingWithInvitationsConfirmationMessage;
						return Ext.callback(callback, scope || this, [message]);
					} else {
						return this.showInformationDialog(resources.localizableStrings.CanNotChangeMeetingMessage);
					}
				}
				this.callParent(arguments);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"generator": "ActivityParticipantDetailGridGenerator.generatePartial",
					"type": "listed"
				}
			},
			{
				"operation": "insert",
				"name": "SendInvitationsButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {
						"bindTo": "ParticipantsInvited",
						"bindConfig": {
							"converter": function(participantsInvited) {
								return participantsInvited
									? resources.localizableStrings.ResendInvitationsButtonCaption
									: resources.localizableStrings.SendInvitationsButtonCaption;
							}
						}
					},
					"imageConfig": {
						"bindTo": "ParticipantsInvited",
						"bindConfig": {
							"converter": function(participantsInvited) {
								return participantsInvited
									? resources.localizableImages.ResendInvitationsImage
									: resources.localizableImages.SendInvitationsImage;
							}
						}
					},
					"enabled": { "bindTo": "InvitationButtonEnabled" },
					"visible": { "bindTo": "getInvitationButtonVisible" },
					"click": { "bindTo": "onSendInvitationsClick" },
					"hint": {
						"bindTo": "InvitationButtonEnabled",
						"bindConfig": {
							"converter": function(invitationButtonEnabled) {
								return invitationButtonEnabled
									? BPMSoft.emptyString
									: this.get("SynchronizationNotEnabledHint");
							}
						}
					},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
				},
				"parentName": "Detail",
				"propertyName": "tools"
			}
		]/**SCHEMA_DIFF*/
	};
});
