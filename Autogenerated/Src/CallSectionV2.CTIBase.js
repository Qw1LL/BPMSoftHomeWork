define("CallSectionV2", ["CallRecordUtilities", "CallSectionV2Resources", "AudioPlayer",
	"CallSectionGridRowViewModel", "css!CallSectionGridRowViewModel"],
	function() {
		return {
			entitySchemaName: "Call",
			mixins: {

				/**
				 * @class BPMSoft.CallRecordUtilities Implements call records utilities.
				 */
				CallRecordUtilities: "BPMSoft.CallRecordUtilities"

			},
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

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator"
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						Caption: this.getCallRecordUtilitiesStringResource("SaveToFileMenuItemCaption"),
						Click: {bindTo: "onSaveToFileMenuItemClick"},
						Enabled: {bindTo: "getIsDownloadAudioFileMenuItemEnabled"}
					}));
					return actionMenuItems;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.mixins.CallRecordUtilities.init.call(this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#initContextHelp
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1024);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelConfig
				 * @overridden
				 */
				getGridRowViewModelConfig: function() {
					var gridRowViewModelConfig = this.callParent(arguments);
					this.Ext.apply(gridRowViewModelConfig, {
						Ext: this.Ext,
						BPMSoft: this.BPMSoft,
						sandbox: this.sandbox
					});
					return gridRowViewModelConfig;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#getGridRowViewModelClassName
				 * @overridden
				 */
				getGridRowViewModelClassName: function() {
					return "BPMSoft.CallSectionGridRowViewModel";
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilities#initQueryColumns
				 * @overridden
				 */
				initQueryColumns: function(entitySchemaQuery) {
					this.callParent(arguments);
					if (!entitySchemaQuery.columns.contains("IntegrationId")) {
						entitySchemaQuery.addColumn("IntegrationId");
					}
				},

				/**
				 * Indicates whether "Download audio file" menu item is enabled.
				 * @protected
				 * @return {Boolean} True if enabled, otherwise - false.
				 */
				getIsDownloadAudioFileMenuItemEnabled: function() {
					return this.isSingleSelected() && !this.get("MultiSelect") && this.get("CanDownloadAudioFile");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#onCardVisibleChanged
				 * @overridden
				 */
				onCardVisibleChanged: function() {
					this.callParent(arguments);
					this.stopPlaying();
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilities#onGridDataLoaded
				 * @overridden
				 */
				onGridDataLoaded: function() {
					this.callParent(arguments);
					this.set("CanDownloadAudioFile", false);
					this.prepareRowCallRecord(null, false, function(canGetCallRecords, callRecords) {
						this.set("CanDownloadAudioFile",
							canGetCallRecords && Ext.isArray(callRecords) && (callRecords.length > 0));
					}.bind(this));
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#rowSelected
				 * @overridden
				 */
				rowSelected: function(primaryColumnValue) {
					this.callParent([primaryColumnValue]);
					this.stopPlaying();
					this.set("CanDownloadAudioFile", false);
					this.prepareRowCallRecord(primaryColumnValue, false, function(canGetCallRecords, callRecords) {
						this.set("CanDownloadAudioFile",
							canGetCallRecords && Ext.isArray(callRecords) && (callRecords.length > 0));
					}.bind(this));
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#changeDataView
				 * @overridden
				 */
				changeDataView: function() {
					this.callParent(arguments);
					this.stopPlaying();
				},

				/**
				 * Handles the grid 'unSelectRow' event.
				 * @protected
				 * @param {String} id The identifier of the previous record.
				 */
				onGridUnSelectRow: function(id) {
					this.stopPlaying(id);
				},

				/**
				 * Handles "Save to file" menu item click event.
				 * @protected
				 */
				onSaveToFileMenuItemClick: function() {
					this.requestAndDownloadCallRecord();
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "SeparateModeAddRecordButton"
				},
				{
					"operation": "remove",
					"name": "CombinedModeAddRecordButton"
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowCopyAction"
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"unSelectRow": {"bindTo": "onGridUnSelectRow"},
						"className": "BPMSoft.AudioGrid"
					}
				},
				{
					"operation": "insert",
					"name": "AudioPlayer",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"index": 1,
					"values": {
						"className": "BPMSoft.AudioPlayer",
						"selectors": {"wrapEl": "#AudioPlayer"},
						"sourceId": {"bindTo": "getSourceId"},
						"sourceUrl": {"bindTo": "SourceUrl"},
						"playbackended": {"bindTo": "onPlaybackEnded"},
						"error": {"bindTo": "onPlayError"}
					}
				},
				{
					"operation": "insert",
					"name": "PlayRecordButton",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"index": 1,
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"classes": {"textClass": ["audio-player-button"]},
						"visible": {"bindTo": "IsRecordPlayAvailable"},
						"caption": {"bindTo": "getPlayerButtonCaption"},
						"imageConfig": {"bindTo": "getPlayerButtonImageConfig"},
						"iconAlign": BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
						"click": {"bindTo": "onRecordPlayerClick"},
						"markerValue": {"bindTo": "getPlayerButtonCaption"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
