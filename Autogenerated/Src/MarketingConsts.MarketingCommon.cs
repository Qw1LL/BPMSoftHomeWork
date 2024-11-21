namespace BPMSoft.Configuration {
	using System;

	#region Class: MarketingConsts

	/// <summary>
	/// Contains constant values from the configuration directories.
	/// </summary>
	public static class MarketingConsts {

		/// <summary>
		/// Mailing state (Marketing) - Waiting before send to give a chance to stop mailing.
		/// </summary>
		public static readonly Guid BulkEmailStatusWaitingBeforeSendId = new Guid("46de8ebd-16ce-4900-b309-0d3fc70ee20a");
		/// <summary>
		/// The status of the bulk email (Marketing) - Planned.
		/// </summary>
		public static readonly Guid BulkEmailStatusPlannedId = new Guid("392D3CF8-8D7A-42B1-857C-E4EF36F989AF"); 

		/// <summary>
		/// The status of the bulk email (Marketing) - Launched.
		/// </summary>
		public static readonly Guid BulkEmailStatusLaunchedId = new Guid("7789AC0C-450B-40A3-B341-3D6B799649B4"); 

		/// <summary>
		/// The status of the bulk email (Marketing) - Finished.
		/// </summary>
		public static readonly Guid BulkEmailStatusFinishedId = new Guid("42328932-9AD6-4512-9950-662FFBA2C53C"); 

		/// <summary>
		/// The status of the bulk email (Marketing) - Preparing to send.
		/// </summary>
		public static readonly Guid BulkEmailStatusStartsId = new Guid("C6E21AD8-E243-4656-AAFC-1312F97C4521");

		/// <summary>
		/// The status of the bulk email (Marketing) - Breaking.
		/// </summary>
		public static readonly Guid BulkEmailStatusBreakingId = new Guid("68865284-A613-4158-91BC-9CC306393D2B");

		/// <summary>
		/// The status of the bulk email (Marketing) - Stopped.
		/// </summary>
		public static readonly Guid BulkEmailStatusStoppedId = new Guid("A89E3500-3E51-4B68-B512-80ADF19738E7");

		/// <summary>
		/// The status of the bulk email (Marketing) - Scheduled to be sent.
		/// </summary>
		public static readonly Guid BulkEmailStatusStartPlanedId = new Guid("EE792AA5-1A7C-40AE-9C4F-B3A33EC18AEA");

		/// <summary>
		/// The status of the bulk email (Marketing) - Draft.
		/// </summary>
		public static readonly Guid BulkEmailStatusDraftId = new Guid("32848D61-3792-4B06-A183-EAF1D1769897");

		/// <summary>
		/// The status of the bulk email (Marketing) - Error sending.
		/// </summary>
		public static readonly Guid BulkEmailStatusErrorId = new Guid("48C20AA0-8277-4610-BB2C-FF934F1B1237");

		/// <summary>
		/// The status of the bulk email (Marketing) - Active.
		/// </summary>
		public static readonly Guid BulkEmailStatusActiveId = new Guid("C467C44F-345E-42EB-8385-8CE383699B52");

		/// <summary>
		/// Event status (Marketing) - In progress.
		/// </summary>
		public static readonly Guid EventStatusInWorkId = new Guid("7FDFD0A8-1EF4-4B89-A379-FC7C66A0E42E");

		/// <summary>
		/// Event status (Marketing) - Cancelled.
		/// </summary>
		public static readonly Guid EventStatusCancelledId = new Guid("BFCF33EF-12A6-4AC1-827E-8F8BFE64F5D7");

		/// <summary>
		/// Event status (Marketing) - Planned.
		/// </summary>
		public static readonly Guid EventStatusPlannedId = new Guid("02D383FB-CE9B-4C5A-8C5A-C3E0F2989251");
 
		/// <summary>
		/// Event status (Marketing) - Finished.
		/// </summary>
		public static readonly Guid EventStatusFinishedId = new Guid("33331615-9343-4DA7-834A-862E28B49516");

		/// <summary>
		/// Response from email (Marketing) - Planned.
		/// </summary>
		public static readonly Guid BulkEmailResponsePlannedId = new Guid("14769602-EBDA-40B1-91D5-EA9D623E2400"); 

		/// <summary>
		/// Response from email (Marketing) - Sending is delayed.
		/// </summary>
		public static readonly Guid BulkEmailResponseDeferralId = new Guid("D45EA798-45C7-44BE-8B41-2C6ABB2CC4DE");

		/// <summary>
		/// Response from email (Marketing) - Cancelled.
		/// </summary>
		public static readonly Guid BulkEmailResponseCanceledId = new Guid("31AAED28-5789-43FF-9801-9FF6B5956B9B");

		/// <summary>
		/// Response from email (Marketing) - Common request error.
		/// </summary>
		public static readonly Guid BulkEmailResponseRequestFailedId = new Guid("C2248D51-84ED-44B3-8E05-001B570BB517"); 
		
		/// <summary>
		/// Response from email (Marketing) - Sent.
		/// </summary>
		public static readonly Guid BulkEmailResponseSentId = new Guid("9C56DB88-D16A-438F-B223-148B00C66C80"); 

		/// <summary>
		/// Response from email (Marketing) - Rejected.
		/// </summary>
		public static readonly Guid BulkEmailResponseRejectedId = new Guid("EDD1CED0-ABDB-4B5A-89A2-46CFDBE33D7F"); 

		/// <summary>
		/// Response from email (Marketing) - Accepted by the service provider.
		/// </summary>
		public static readonly Guid BulkEmailResponseQueuedId = new Guid("CEDB7FDA-B9A1-463A-9735-6562B789EE5A");

		/// <summary>
		/// Response from email (Marketing) - Sent to the service provider.
		/// </summary>
		public static readonly Guid BulkEmailResponsePostedProviderId = new Guid("899AA74A-785C-4A26-B41C-6C30486FEBB9");

		/// <summary>
		/// Response from email (Marketing) - Invalid recipient.
		/// </summary>
		public static readonly Guid BulkEmailResponseInvalidId = new Guid("86D520BB-0EB2-493E-B8C5-55523AC31705"); 

		/// <summary>
		/// Response from email (Marketing) - Soft Bounce.
		/// </summary>
		public static readonly Guid BulkEmailResponseSoftBounceId = new Guid("9BA89F3B-6041-4E81-8F1A-B666CFB5BF7B");

		/// <summary>
		/// Response from email (Marketing) - Sent to spam.
		/// </summary>
		public static readonly Guid BulkEmailResponseSpamId = new Guid("DC5FED60-4C3B-46BD-BF12-7F3DEFC099B2"); 
		
		/// <summary>
		/// Response from email (Marketing) - Unsubscribed.
		/// </summary>
		public static readonly Guid BulkEmailResponseUnsubId = new Guid("A670EE81-2166-4C85-9E41-88901CA9CA38");

		/// <summary>
		/// Response from email (Marketing) - Hard Bounce.
		/// </summary>
		public static readonly Guid BulkEmailResponseHardBounceId = new Guid("CBA985B0-32B8-48F7-924E-7F33E8BD45B8"); 

		/// <summary>
		/// Response from email (Marketing) - Opened.
		/// </summary>
		public static readonly Guid BulkEmailResponseOpenedId = new Guid("5788B052-74AB-481D-8D0F-EFE87A19848F");

		/// <summary>
		/// Response from email (Marketing) - Link has been clicked.
		/// </summary>
		public static readonly Guid BulkEmailResponseClickedId = new Guid("62A08686-CC06-4B4D-88E2-A6DF4D4F6B77");

		/// <summary>
		/// Response from email (Marketing) - Reply has been received.
		/// </summary>
		public static readonly Guid BulkEmailResponseRepliedId = new Guid("59C7E5E9-3EEC-456F-823F-D9B68E8203CE");

		/// <summary>
		/// Response from event (Marketing) - Planned.
		/// </summary>
		public static readonly Guid EventResponsePlannedId = new Guid("C6EAE023-2778-49C6-8273-6B015C1CC611");

		/// <summary>
		/// Response from event (Marketing) - Cancelled.
		/// </summary>
		public static readonly Guid EventResponseCanceledId = new Guid("2EA76342-B8CB-4B7D-86CE-19E14F350617");

		/// <summary>
		/// Parent group for all filters at the campaign.
		/// </summary>
		public static readonly Guid CampaignFiltersContactFolderId = new Guid("2930C953-9A31-42BA-8AAF-8DE9DCA1F6B9");

		/// <summary>
		/// Group type - Dynamic.
		/// </summary>
		public static readonly Guid FolderTypeDynamicId = new Guid("65CA0946-0084-4874-B117-C13199AF3B95");

		/// <summary>
		/// Group Type - Static.
		/// </summary>
		public static readonly Guid FolderTypeStaticId = new Guid("9DC5F6E6-2A61-4DE8-A059-DE30F4E74F24");

		/// <summary>
		/// The unique user ID for integration with Mandrill.
		/// </summary>
		public static readonly Guid MandrillUserId = new Guid("8AB1343F-CB58-49C7-95A2-058B5F60ACD3");

		/// <summary>
		/// Status updating segment - Updated.
		/// </summary>
		public static readonly Guid SegmentStatusUpdatedId = new Guid("FA360D2C-1658-49AD-9152-22479FDC0C12");

		/// <summary>
		/// Status updating segment - Updating.
		/// </summary>
		public static readonly Guid SegmentStatusUpdatingId = new Guid("64ECD6EB-17DA-472B-A000-0809D49348F3");

		/// <summary>
		/// Status updating segment - Requires upgrade.
		/// </summary>
		public static readonly Guid SegmentStatusRequiresUpdatingId = new Guid("DFB4E827-1B9B-4EA7-B4EB-898F592451F9");

		/// <summary>
		/// Message template macro - Owner.
		/// </summary>
		public static readonly Guid EmailTemplateMacrosParentGlobalId = new Guid("1D151866-0C45-413E-B288-9654F44113AE");

		/// <summary>
		/// Message template macro - Recipient.
		/// </summary>
		public static readonly Guid EmailTemplateMacrosParentContactId = new Guid("EBB220F0-F36B-1410-3088-1C6F65E24DB2");

		/// <summary>
		/// Message template macro - Unsubscribe.
		/// </summary>
		public static readonly Guid EmailTemplateMacrosParentUnsubscribeId = new Guid("0C5FCD38-9171-4030-ABE7-B8A7ACAF8B38");

		/// <summary>
		/// Message template macro - Unsubscribe.URL.
		/// </summary>
		public static readonly Guid EmailTemplateMacrosUnsubscribeUrlId = new Guid("392C7FC2-925E-46ED-A2A6-F2E89D047236");
		
		/// <summary>
		/// Reason irrelevance communications - Soft Bounce.
		/// </summary>
		public static readonly Guid SoftBounceNonActualReasonId = new Guid("064BBCBD-0D14-4150-9AFB-D504E27CCBCE");

		/// <summary>
		/// Reason irrelevance communications - Hard Bounce.
		/// </summary>
		public static readonly Guid HardBounceNonActualReasonId = new Guid("4B604BD3-46BF-4F3C-AEDD-38D318765C5A");

		/// <summary>
		/// Reason irrelevance communications - Rejected.
		/// </summary>
		public static readonly Guid RejectedNonActualReasonId = new Guid("E0A76A46-C931-4553-956A-159294609A72");

		/// <summary>
		/// Reason irrelevance communications - Set manually.
		/// </summary>
		public static readonly Guid ManuallyNonActualReasonId = new Guid("FE0B394D-9403-4D08-BC55-068528B2DE45");

		/// <summary>
		/// Status contact subscription - Unsubscribed.
		/// </summary>
		public static readonly Guid BulkEmailContactUnsubscribed = new Guid("C8947F80-A374-412A-BBC8-EA9068A8B78E");

		/// <summary>
		/// The contact status at the campaign - Planned.
		/// </summary>
		public static readonly Guid CampaignTargetStatusPlannedId = new Guid("7D7EF797-CDA6-4BD8-BE03-BAC67FBF73D7");

		/// <summary>
		/// Email category - Bulk email.
		/// </summary>
		public static readonly Guid MassmailingBulkEmailCategoryId = new Guid("8CEC06ED-2643-46F7-AB00-352ACBC3BD8A");

		/// <summary>
		/// Email category - Triggered email.
		/// </summary>
		public static readonly Guid TriggeredEmailBulkEmailCategoryId = new Guid("2DF24C22-B596-4994-A0CD-E2FA1D8ECDEB");

		/// <summary>
		/// Startup option for bulk email - start manually.
		/// </summary>
		public static readonly Guid BulkEmailManaulLaunchOptionId = new Guid("6F72C1B4-810B-4EF9-BC20-879372C8E2C2");

		/// <summary>
		/// Startup option for bulk email - at the specified time.
		/// </summary>
		public static readonly Guid BulkEmailScheduledaunchOptionId = new Guid("936B2D84-CF46-404F-8726-D377E4896774");

		/// <summary>
		/// Startup option for trigger email - instantly.
		/// </summary>
		public static readonly Guid TriggerEmailImmediateLaunchOptionId = new Guid("F1E82AFB-8820-4A13-8BC3-22B1A8180AB1");

		/// <summary>
		/// Startup option for trigger email - at the specified time.
		/// </summary>
		public static readonly Guid TriggerEmailScheduledLaunchOptionId = new Guid("5A3CEB77-64B9-446E-AE64-F78D358E42A8");

		/// <summary>
		/// Startup option for trigger email - from campaign.
		/// </summary>
		public static readonly Guid TriggerEmailFromCampaignLaunchOptionId = new Guid("17EC7FB4-C709-469B-A332-59656695082E");

		/// <summary>
		/// The State of split-test - In plans.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusPlannedId = new Guid("CB26ED70-E6F7-4E48-BC7B-560B2676FCC6");

		/// <summary>
		/// The State of split-test - Launched.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusLaunchedId = new Guid("30E71DF7-D9F7-4A9A-861B-A6A26E59D19E");

		/// <summary>
		/// The State of split-test - Scheduled to launch.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusStartPlanedId = new Guid("069579CF-AA28-497A-AE48-7DB6A61E33FC");

		/// <summary>
		/// The State of split-test - Finished.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusFinishedId = new Guid("43DDFB49-C9A5-4D63-8294-D54419456C0B");
	}

	#endregion
	
	#region Enum: BulkEmailResponseCode

	/// <summary>
	/// Response from the bulk email.
	/// </summary>
	[Obsolete]
	public enum BulkEmailResponseCode {
		/// <summary>
		/// Error while sending.
		/// </summary>
		DeliveryError = 1,

		/// <summary>
		/// Sent.
		/// </summary>
		Sent = 7,

		/// <summary>
		/// Accepted by the service provider (delayed).
		/// </summary>
		Deferral = 3,

		/// <summary>
		/// Rejected.
		/// </summary>
		Rejected = 4,
		
		/// <summary>
		/// Invalid recipient.
		/// </summary>
		Invalid = 5,
		
		/// <summary>
		/// Accepted by the provider (queued).
		/// </summary>
		Queued = 6,
		
		/// <summary>
		/// Delivered.
		/// </summary>
		Delivered = 2,

		/// <summary>
		/// Hard Bounce.
		/// </summary>
		HardBounce = 8,

		/// <summary>
		/// Sent to spam.
		/// </summary>
		Spam = 9,

		/// <summary>
		/// Unsubscribed.
		/// </summary>
		Unsub = 10,

		/// <summary>
		/// Link has been clicked.
		/// </summary>
		Clicked = 12,

		/// <summary>
		/// Soft Bounce.
		/// </summary>
		SoftBounce = 13,

		/// <summary>
		/// Planned.
		/// </summary>
		Planned = 14,

		/// <summary>
		/// Opened.
		/// </summary>
		Opened = 15
	}

	#endregion
}
