  define("CallPageV2", ["CallPageV2Resources", "BusinessRuleModule", "ConfigurationConstants", 
						"CtiConstants", "CallRecordUtilities", "AudioPlayer"],
	function(resources, BusinessRuleModule, ConfigurationConstants, ctiConstants) {
		return {
			entitySchemaName: "Call",
			rules: {},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {

				/**
				 * Indicates whether audio file can be downloaded.
				 * @protected
				 * @type {Boolean}
				 */
				"CanDownloadAudioFile": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			columns: {

				/**
				 * ####### ########### ########### ###### ######.
				 * @type {Boolean}
				 */
				"IsRecordPlayAvailable": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				/**
				 * Url ###########.
				 * @type {String}
				 */
				"SourceUrl": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				}
			},
			mixins: {

				/**
				 * @class BPMSoft.CallRecordUtilities Implements call records utilities.
				 */
				CallRecordUtilities: "BPMSoft.CallRecordUtilities"

			},
			messages: {

				/**
				 * @message GetCallRecords
				 * ########## # ############# ######### ####### ########## ######.
				 * @param {Object} ########## # ########## ######.
				 */
				"GetCallRecords": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.initializePlayer();
				},
				
				/**
				 * Initializing the ability to download calls.
				 */
				initializePlayer: function() {
					this.prepareRowCallRecord(this.get("Id"), false, function(canGetCallRecords, callRecords) {
							this.set("CanDownloadAudioFile",
								canGetCallRecords && Ext.isArray(callRecords) && (callRecords.length > 0));
						}.bind(this));	
				},
				
				/**
				 * Requests call records and prepares audio player in grid row.
				 * @protected
				 * @param {String} [primaryColumnValue] Call record primary column value. If not set - active row will be
				 * selected.
				 * @param {Boolean} [autoStartPlay] Indicates that after receiving call record player should start play it.
				 * @param {Function} [callback] The callback function.
				 * @param {Boolean} [callback.canGetCallRecords] Indicates that recorded call files are available.
				 * @param {String[]} [callback.callRecords] Array of recorded call file urls.
				 */
				prepareRowCallRecord: function(primaryColumnValue, autoStartPlay, callback) {
					if (!this.canPlayRecordsInCalls) {
						return;
					}
					var callId = this.$IntegrationId;
					this.requestCallRecordUrl(callId, function(canGetCallRecords, callRecords) {
						this.prepareAudioPlayer(autoStartPlay, canGetCallRecords, callRecords);
						if (callback) {
							callback(canGetCallRecords, callRecords);
						}
					}.bind(this));
				},
				
				/**
				 * ########## ############# ###########.
				 * @return {String} ############# ###########.
				 */
				getSourceId: function() {
					return this.get("Id");
				},

				/**
				 * ########### ###### ##########.
				 * @param {Boolean} [autoStartPlay] ####### ############# ######### ########### ##### ##### ######### ######
				 * ## ###### #########.
				 */
				requestCallRecords: function(autoStartPlay) {
					var args = {
						callId: this.get("IntegrationId"),
						callback: this.prepareAudioPlayer.bind(this, autoStartPlay)
					};
					this.sandbox.publish("GetCallRecords", args, [ctiConstants.CallRecordsContextMessageId]);
				},

				/**
				 * ########## ######### ###### ############ ######.
				 * @return {String} ######### ######.
				 */
				getPlayerButtonCaption: function() {
					return resources.localizableStrings.PlayCaption;
				},

				/**
				 * ########## ############ ###### ###### ############ ######.
				 * @return {Object} ############ ######.
				 */
				getPlayerButtonImageConfig: function() {
					return resources.localizableImages.PlayImage;
				},

				/**
				 * ############ ####### ######### ############### ######.
				 */
				onPlaybackEnded: function() {
					this.set("IsRecordPlayAvailable", true);
				},

				/**
				 * ############ ####### ###### ### ############### ######.
				 * @protected
				 * @param {Number} errorCode ### ######.
				 */
				onPlayError: function(errorCode) {
					this.error(Ext.String.format(resources.localizableStrings.PlayErrorMessage, errorCode));
				},

				/**
				 * ############ ####### ######### ####### ##########.
				 * @param {Boolean} autoStartPlay ####### ############# ######### ########### ##### ##### ######### ######
				 * ## ###### #########.
				 * @param {Boolean} canGetCallRecords #######, ### #### ########### ######## ###### ########## ######.
				 * @param {String[]} callRecords ###### ###### ## ###### ########## ######.
				 * @deprecated
				 */
				onGetCallRecords: function(autoStartPlay, canGetCallRecords, callRecords) {
					this.prepareAudioPlayer(autoStartPlay, canGetCallRecords, callRecords);
				},

				/**
				 * ############## ######### ###########.
				 * @param {Boolean} autoStartPlay ####### ############# ######### ########### ##### ##### ######### ######
				 * ## ###### #########.
				 * @param {Boolean} canGetCallRecords #######, ### #### ########### ######## ###### ########## ######.
				 * @param {String[]} callRecords ###### ###### ## ###### ########## ######.
				 */
				prepareAudioPlayer: function(autoStartPlay, canGetCallRecords, callRecords) {
					if (!canGetCallRecords || !Ext.isArray(callRecords) || (callRecords.length === 0) || !callRecords[0]) {
						this.set("IsRecordPlayAvailable", false);
						return;
					}
					this.set({
						"IsRecordPlayAvailable": !autoStartPlay,
						"SourceUrl": callRecords[0]
					});
					if(this.get("CallRecordLink") === "" || callRecords[0] !== this.get("CallRecordLink")) {
						this.set("CallRecordLink", callRecords[0]);
						this.save();
					}
					if (autoStartPlay === true) {
						var player = Ext.getCmp("CallPageV2AudioPlayerComponent");
						player.setControlsEnabled();
						player.play();
					}
				},

				/**
				 * ############ ####### ####### ###### ############ ######.
				 */
				onRecordPlayerClick: function() {
					var player = Ext.getCmp("CallPageV2AudioPlayerComponent");
					if (!player) {
						return;
					}
					this.requestCallRecords(true);
				},
				
				getActions: function () {
					this.callParent(arguments);
					var actionMenuItems = this.callParent(arguments);
						actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": this.getCallRecordUtilitiesStringResource("SaveToFileMenuItemCaption"),
						"Tag": "onSaveToFileMenuItemClick",
						"Enabled": {bindTo: "CanDownloadAudioFile"}
					}));
					return actionMenuItems;
				},
				
				/**
				 * Handles "Save to file" menu item click event.
				 * @protected
				 */
				onSaveToFileMenuItemClick: function() {
					this.requestAndDownloadCallRecord();
				},
				
				/**
				 * Requests call record file urls and starts downloading them.
				 * @protected
				 */
				requestAndDownloadCallRecord: function() {
					if (!this.canPlayRecordsInCalls) {
						return;
					}
					var callId = this.$IntegrationId;
					var fileName = this.getCallFileName();
					this.requestCallRecordUrl(callId, this.downloadCallRecordFile.bind(this, fileName));
				},
				
				
				/**
				 * Generates file name as following:
				 * <Date> <Time> <Operator_number> <Subscriber_number> <Operator> <Account> <Contact>.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} rowViewModel View model of the grid row.
				 * @return {String} File name.
				 */
				getCallFileName: function() {
					var callData = [];
					var createdOn = this.get("CreatedOn");
					var cultureSettings = BPMSoft.Resources.CultureSettings;
					callData.push(
						this.Ext.Date.format(createdOn, cultureSettings.dateFormat),
						this.Ext.Date.format(createdOn, cultureSettings.timeFormat)
					);
					var callerId = this.get("CallerId");
					var calledId = this.get("CalledId");
					var directionId = this.get("Direction").value;
					if (directionId === ctiConstants.CallDirection.Incoming) {
						callData.push(callerId, calledId);
					} else {
						callData.push(calledId, callerId);
					}
					var createdBy = this.get("CreatedBy");
					if (createdBy && createdBy.displayValue) {
						callData.push(createdBy.displayValue);
					}
					var account = this.get("Account");
					if (account && account.displayValue) {
						callData.push(account.displayValue);
					}
					var contact = this.get("Contact");
					if (contact && contact.displayValue) {
						callData.push(contact.displayValue);
					}
					return callData.join(" ");
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "PlayRecordButton",
					"parentName": "Header",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.GREY,
						"classes": {"textClass": ["audio-player-button"]},
						"caption": {"bindTo": "getPlayerButtonCaption"},
						"click": {"bindTo": "onRecordPlayerClick"},
						"visible": {"bindTo": "IsRecordPlayAvailable"},
						"imageConfig": {"bindTo": "getPlayerButtonImageConfig"},
						"layout": {
							"colSpan": 12,
							"column": 0,
							"rowSpan": 1,
							"row": 2
						}
					}
				},
				{
					"operation": "insert",
					"name": "AudioPlayer",
					"parentName": "Header",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.AudioPlayer",
							"selectors": {"wrapEl": "#AudioPlayer"},
							"sourceUrl": {"bindTo": "SourceUrl"},
						"layout": {
							"colSpan": 12,
							"column": 0,
							"rowSpan": 1,
							"row": 2
						}
					}
				},
			]/**SCHEMA_DIFF*/
		};
	}
);