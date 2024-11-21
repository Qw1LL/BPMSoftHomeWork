namespace BPMSoft.Configuration {
	using System;

	#region Class: CampaignConsts

	/// <summary>
	/// Contains a constant values for campaigns from a configuation dictionaries.
	/// </summary>
	public static class CampaignConsts {

		/// <summary>
		/// Campaign step type - create lead.
		/// </summary>
		public static readonly Guid CreateLeadCampaignStepTypeId = new Guid("12C48DA4-8305-4AA7-92A9-2C75DC5D458B");

		/// <summary>
		/// Campaign step type - Email
		/// </summary>
		public static readonly Guid BulkEmailCampaignStepTypeId = new Guid("0270A11D-534C-40EC-8A72-C4902D6AFB09");

		/// <summary>
		/// Campaign step type - event
		/// </summary>
		public static readonly Guid EventCampaignStepTypeId = new Guid("75B0F8D2-A3F4-4715-AD37-A501543AF26C"); 

		/// <summary>
		/// Campaign step type - audience
		/// </summary>
		public static readonly Guid AudienceCampaignStepTypeId = new Guid("36503C76-9542-45B6-A934-A61F2B9BCE48"); 

		/// <summary>
		/// Campaign step type - goal
		/// </summary>
		public static readonly Guid GoalCampaignStepTypeId = new Guid("30EB28EB-BB1F-4D18-9358-55556D80D833"); 

		/// <summary>
		/// Campaign step type - exit
		/// </summary>
		public static readonly Guid ExitCampaignStepTypeId = new Guid("B748CDC5-B478-4ED1-8B52-51513EE49ED9");

		/// <summary>
		/// Campaign participant status - participating
		/// </summary>
		[Obsolete("7.12.1 | Use BPMSoft.Core.Campaign.CampaignConstants.CampaignParticipantParticipatingStatusId instead")]
		public static readonly Guid CampaignParticipantParticipatingStatusId = new Guid("58B91B66-256B-48CF-A56A-A5B7036825E6");

		/// <summary>
		/// Campaign participant status - exiting
		/// </summary>
		[Obsolete("7.12.1 | Use BPMSoft.Core.Campaign.CampaignConstants.CampaignParticipantExitedStatusId instead")]
		public static readonly Guid CampaignParticipantExitedStatusId = new Guid("0F7B1179-3EC4-4F3F-94E6-F59A23ADD381");

		/// <summary>
		/// Campaign step type - landing
		/// </summary>
		public static readonly Guid LendingCampaignStepTypeId = new Guid("5E9D3401-8047-4833-B9F0-C2C8D3DBBE62");

		/// <summary>
		///  Campaign status - planned
		/// </summary>
		public static readonly Guid PlannedCampaignStatusId = new Guid("24B80784-2172-4903-94AD-CA1FDDF368DD");

		/// <summary>
		///  Campaign status - scheduled
		/// </summary>
		public static readonly Guid ScheduledCampaignStatusId = new Guid("D55A44BB-FA64-45F5-B83D-C5EF7CD76208");

		/// <summary>
		///  Campaign status - started
		/// </summary>
		public static readonly Guid RunCampaignStatusId = new Guid("49CC0A4F-75DF-4B47-953B-0FAA4983321D");

		/// <summary>
		///  Campaign status - stopped.
		/// </summary>
		public static readonly Guid CompletedCampaignStatusId = new Guid("5B792494-D40F-4B2B-8CFD-AB75AC5D33AA");

		/// <summary>
		///  Campaign status - stopping.
		/// </summary>
		public static readonly Guid StoppingCampaignStatusId = new Guid("D1B59429-008B-4B28-83CF-D93A6825792A");

		/// <summary>
		/// Campaign target status - planned
		/// </summary>
		public static readonly Guid CampaignTargetStatusPlannedId = new Guid("7D7EF797-CDA6-4BD8-BE03-BAC67FBF73D7");

		/// <summary>
		/// Campaign step filter for landing - form submited
		/// </summary>
		public static readonly Guid LandingFormSubmitedCampaignFilterId = new Guid("71EB567E-4342-4442-BD28-70F0F32F7267"); 

		/// <summary>
		/// Campaign step filter for landing - form not submited
		/// </summary>
		public static readonly Guid LandingFormNotSubmitedCampaignFilterId = new Guid("B5BEA8F2-04DE-4A8F-A6C3-A35C14DF6881");

		/// <summary>
		/// Campaign step filter for BulkEmail - hyperlink clicked
		/// </summary>
		public static readonly Guid HyperlinkClickedCampaignFilterId = new Guid("7EAFF636-EAB8-4EBD-817A-5FB82A728F17");

		/// <summary>
		/// The lead landing type identifier.
		/// </summary>
		public static readonly Guid LeadLandingTypeId = new Guid("62B81C7E-BC2B-4EC5-8441-D486B384F57D");

		/// <summary>
		/// The event target landing type identifier.
		/// </summary>
		public static readonly Guid EventTargetLandingTypeId = new Guid("CA022B3D-23FF-4486-8392-8D65204B0143");
		
		/// <summary>
		/// Old campaign type identifier.
		/// </summary>
		public static readonly Guid OldCampaignTypeId = new Guid("389EB587-52D4-4AB6-B4AD-E7E2F0D62EAC");

		/// <summary>
		/// Campaign log status: Error.
		/// </summary>
		public static readonly Guid CampaignLogStatusError = new Guid("EC16102A-E946-4353-A7B7-678DA6E278E2");

		/// <summary>
		/// Campaign log status: Success.
		/// </summary>
		public static readonly Guid CampaignLogStatusSuccess = new Guid("6E988AAE-5EC3-4582-B0D3-1CB4CA6F40E2");

		/// <summary>
		/// Campaign log item type: Participant adding (manually).
		/// </summary>
		public static readonly Guid CampaignLogTypeManualAdd = new Guid("FB157777-D095-4A63-8DCA-82FE6D0C703B");

		/// <summary>
		/// Campaign log item type: Campaign start.
		/// </summary>
		public static readonly Guid CampaignLogTypeCampaignStart = new Guid("ED69D8A5-8554-4735-8ABF-40DE95C7005F");

		/// <summary>
		/// Campaign log item type: Campaign stop.
		/// </summary>
		public static readonly Guid CampaignLogTypeCampaignStop = new Guid("3A69C145-64DE-4030-ADFC-CEF443393F7D");

		/// <summary>
		/// Campaign log item type: Campaign scheduled start.
		/// </summary>
		public static readonly Guid CampaignLogTypeScheduledStart = new Guid("6C992CCF-AC92-483E-BF71-EFEAED7EC95C");

		/// <summary>
		/// Campaign log item type: Campaign scheduled stop.
		/// </summary>
		public static readonly Guid CampaignLogTypeScheduledStop = new Guid("CD37E55A-5579-4F24-8435-54296B34F62B");

		/// <summary>
		/// Campaign log item type: Campaign scheduled execution.
		/// </summary>
		public static readonly Guid CampaignLogTypeScheduledRun = new Guid("33424FD5-EC64-41DC-8C00-C557135EA12B");

		/// <summary>
		/// Campaign log item type: Campaign stopped according to schedule.
		/// </summary>
		public static readonly Guid CampaignLogTypeStoppedBySchedule = new Guid("6B8BC80F-689F-4EF0-8EFB-9C9FE5788A4F");

		/// <summary>
		/// Campaign log item type: Campaign restart.
		/// </summary>
		public static readonly Guid CampaignLogTypeCampaignRestart = new Guid("D077A55B-10D6-41D2-AEAE-23DA0A533500");

		/// <summary>
		/// Campaign log item type: Campaign execution.
		/// </summary>
		public static readonly Guid CampaignLogTypeCampaign = new Guid("20071B3A-F7FC-438D-BD7E-884C3A352C70");

		/// <summary>
		/// Campaign log item type: Element execution: Condition flow.
		/// </summary>
		public static readonly Guid CampaignLogTypeConditionFlow = new Guid("3D624318-D88F-4A1F-866B-65C89D7C4364");

		/// <summary>
		/// Campaign log item type: Element execution: Sequence flow.
		/// </summary>
		public static readonly Guid CampaignLogTypeSequenceFlow = new Guid("7A6D6EF5-92EA-4B23-AA82-BCFFFEEC247F");

		/// <summary>
		/// Campaign log item type: Element execution: Add from folder.
		/// </summary>
		public static readonly Guid CampaignLogTypeAddAudience = new Guid("6BEE65FB-2F44-494D-A03A-7DAEF612FDAB");

		/// <summary>
		/// Campaign log item type: Element execution: Start signal.
		/// </summary>
		public static readonly Guid CampaignLogTypeStartSignal = new Guid("44B514A0-B6AC-433E-9E17-2DFE6BECA499");

		/// <summary>
		/// Campaign log item type: Element execution: Marketing email.
		/// </summary>
		public static readonly Guid CampaignLogTypeMailing = new Guid("601DA5EA-FD9A-467F-AA44-B7577011F891");

		/// <summary>
		/// Campaign log item type: Element execution: Exit according to folder conditions.
		/// </summary>
		public static readonly Guid CampaignLogTypeMoveAudience = new Guid("97C6E6F3-9CB8-4168-8D7E-4DA0DA028EDA");

		/// <summary>
		/// Campaign log item type: Element execution: Landing page.
		/// </summary>
		public static readonly Guid CampaignLogTypeLanding = new Guid("B547A9D3-DE45-4DB0-97FF-228507D96E7D");

		/// <summary>
		/// Campaign log item type: Element execution: Add from Landing page.
		/// </summary>
		public static readonly Guid CampaignLogTypeAddLandingAudience = new Guid("2192313D-A4EA-4B41-94BA-57A5F4695506");

		/// <summary>
		/// Campaign log item type: Element execution: Add to Event.
		/// </summary>
		public static readonly Guid CampaignLogTypeEvent = new Guid("4B22E17F-6CAA-498C-8D98-735273B904A8");

		/// <summary>
		/// Campaign log item type: Element execution: Add from Event.
		/// </summary>
		public static readonly Guid CampaignLogTypeAddEventAudience = new Guid("A7E5C6D2-915B-4C74-9672-89BF3FB02756");

		/// <summary>
		/// Campaign log item type: Element execution: Timer.
		/// </summary>
		public static readonly Guid CampaignLogTypeTimer = new Guid("C48EE420-8FF5-4811-A293-0E3498DD7E47");

		/// <summary>
		/// Campaign log item type: Campaign execution was skipped.
		/// </summary>
		public static readonly Guid CampaignLogTypeSkippedRun = new Guid("2F541B8C-D71C-4934-800C-8D0A63538336");

		/// <summary>
		/// Campaign log item type: Campaign element execution was skipped.
		/// </summary>
		public static readonly Guid CampaignLogTypeSkippedElement = new Guid("B5E52C4C-290A-442A-823C-62602AA40DD5");

		/// <summary>
		/// Campaign log item type: Campaign critical lateness.
		/// </summary>
		public static readonly Guid CampaignLogTypeCriticalLateness = new Guid("C3AEDB3F-E607-423E-B919-353455332B04");

		/// <summary>
		/// Campaign log item type: Element execution: update reach the goal status.
		/// </summary>
		public static readonly Guid CampaignLogTypeReachCampaignGoal = new Guid("D43D0CA1-037D-4EEE-ABDF-8A755D79B01E");

		/// <summary>
		/// Campaign log item type: Element execution: update exited from campaign status.
		/// </summary>
		public static readonly Guid CampaignLogTypeExitFromCampaign = new Guid("E72DF722-49C1-4285-BD41-CF511340B5F2");

		/// <summary>
		/// Campaign log item type: Element execution: add object.
		/// </summary>
		public static readonly Guid CampaignLogTypeAddObject = new Guid("5577C650-C252-49FA-8457-32DE81ED2E02");

		/// <summary>
		/// Campaign log item type: Element execution: update object.
		/// </summary>
		public static readonly Guid CampaignLogTypeUpdateObject = new Guid("15A5B75C-925D-4650-A6B7-75F4413D26FF");

		/// <summary>
		/// Campaign log item type: Element execution: split gateway.
		/// </summary>
		public static readonly Guid CampaignLogTypeSplitGateway = new Guid("0A017F2E-7314-490E-B444-EE2F0A160330");

		/// <summary>
		/// Campaign log item type: Element execution: deduplicator.
		/// </summary>
		public static readonly Guid CampaignLogTypeDeduplicator = new Guid("29EBD715-6052-490E-A3AA-2B3688337E34");

		/// <summary>
		/// Campaign status error message.
		/// </summary>
		public static readonly string CampaignStatusErrorMessage = "One or multiple elements failed to execute.";

		/// <summary>
		/// Campaign scheduled mode - run manually.
		/// </summary>
		public static readonly Guid CampaignRunManuallyModeId = new Guid("229D71CF-80C8-4158-AE9D-B0DA644ED6A8");

		/// <summary>
		/// Campaign Scheduled mode - at the specified time.
		/// </summary>
		public static readonly Guid CampaingSpecifiedTimeModeId = new Guid("5EE38934-D028-4C1E-A1C8-2B039991BAEA");

		/// <summary>
		/// Name of the campaign job group in quartz.
		/// </summary>
		public static readonly string CampaignJobGroupName = "CampaignJobGroup";

		/// <summary>
		/// Unique identifier of campaign entity schema macros worker.
		/// </summary>
		public static readonly Guid CampaignEntitySchemaMacrosWorkerId = new Guid("64CFA82A-4C12-4D13-8CE7-0E5831E75670");

	}

	#endregion

}
