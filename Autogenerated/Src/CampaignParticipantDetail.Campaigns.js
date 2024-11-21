define("CampaignParticipantDetail", [], function() {
			return {
				entitySchemaName: "CampaignParticipant",
				attributes: {},
				messages: {},
				methods: {

					// #region Methods: Private

					_isManualParticipantsManipulationAllowed: function() {
						return BPMSoft.Features.getIsEnabled("ManualCampaignParticipantsManipulation");
					},

					// #endregion

					//#region Methods: Protected

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
					 * @override
					 */
					getCopyRecordMenuItem: BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
					 * @override
					 */
					getEditRecordMenuItem: function () {
						if (this._isManualParticipantsManipulationAllowed()) {
							return this.callParent(arguments);
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
					 * @override
					 */
					getDeleteRecordMenuItem: function () {
						if (this._isManualParticipantsManipulationAllowed()) {
							return this.callParent(arguments);
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
					 * @overridden
					 */
					addDetailWizardMenuItems: BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
					 * @override
					 */
					getAddRecordButtonVisible: function () {
						if (this._isManualParticipantsManipulationAllowed()) {
							return this.callParent(arguments);
						}
						return false;
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#editRecord
					 * @override
					 */
					editRecord: function() {
						if (this._isManualParticipantsManipulationAllowed()) {
							return this.callParent(arguments);
						}
					}

					// #endregion

				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"rowDataItemMarkerColumnName": "Contact"
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
