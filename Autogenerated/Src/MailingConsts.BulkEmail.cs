namespace BPMSoft.Configuration {
	using System;

	#region Class: MailingConsts

	/// <summary>
	/// Contains constatnts from configurational lookups.
	/// </summary>
	public static class MailingConsts {
		/// <summary>
		/// Mailing state (Marketing) - Queued.
		/// </summary>
		public static readonly Guid BulkEmailStatusQueuedId = new Guid("A27BD9F6-72F3-4A22-8D67-9CBDC5848C11");

		/// <summary>
		/// Mailing state (Marketing) - Expired.
		/// </summary>
		public static readonly Guid BulkEmailStatusExpiredId = new Guid("C8F9D725-FA83-4576-8B2A-8489DECA0C5E");

		/// <summary>
		/// Mailing state (Marketing) - Expired in progress.
		/// </summary>
		public static readonly Guid BulkEmailStatusExpiredInProgressId = new Guid("4C59E6E7-CE25-45B0-8EF8-B17E3C5CCA28");

		/// <summary>
		/// Mailing state (Marketing) - Planned.
		/// </summary>
		public static readonly Guid BulkEmailStatusPlannedId = new Guid("392D3CF8-8D7A-42B1-857C-E4EF36F989AF");

		/// <summary>
		/// Mailing state (Marketing) - Planned.
		/// </summary>
		public static readonly Guid BulkEmailStatusDraftId = new Guid("32848D61-3792-4B06-A183-EAF1D1769897");

		/// <summary>
		/// Mailing state (Marketing) - Launched.
		/// </summary>
		public static readonly Guid BulkEmailStatusLaunchedId = new Guid("7789AC0C-450B-40A3-B341-3D6B799649B4"); 

		/// <summary>
		/// Mailing state (Marketing) - Completed.
		/// </summary>
		public static readonly Guid BulkEmailStatusFinishedId = new Guid("42328932-9AD6-4512-9950-662FFBA2C53C"); 

		/// <summary>
		/// Mailing state (Marketing) - Preparing to start.
		/// </summary>
		public static readonly Guid BulkEmailStatusStartsId = new Guid("C6E21AD8-E243-4656-AAFC-1312F97C4521");
		
		/// <summary>
		/// Mailing state (Marketing) - Waiting before send to give a chance to stop mailing.
		/// </summary>
		public static readonly Guid BulkEmailStatusWaitingBeforeSendId = new Guid("46de8ebd-16ce-4900-b309-0d3fc70ee20a");

		/// <summary>
		/// Mailing state (Marketing) - Prepating to stop.
		/// </summary>
		public static readonly Guid BulkEmailStatusBreakingId = new Guid("68865284-A613-4158-91BC-9CC306393D2B");

		/// <summary>
		/// Mailing state (Marketing) - Paused. 
		/// </summary>
		public static readonly Guid BulkEmailStatusStoppedId = new Guid("A89E3500-3E51-4B68-B512-80ADF19738E7");

		/// <summary>
		/// Mailing state (Marketing) - Stopped.
		/// </summary>
		public static readonly Guid BulkEmailStatusHardStoppedId = new Guid("7037D63E-7D78-4123-9108-A641C9325AD8");

		/// <summary>
		/// Mailing state (Marketing) - Planning to send,
		/// </summary>
		public static readonly Guid BulkEmailStatusStartPlanedId = new Guid("EE792AA5-1A7C-40AE-9C4F-B3A33EC18AEA");

		/// <summary>
		/// Mailing state (Marketing) - Send failure.
		/// </summary>
		public static readonly Guid BulkEmailStatusErrorId = new Guid("48C20AA0-8277-4610-BB2C-FF934F1B1237");

		/// <summary>
		/// Mailing state (Marketing) - Active.
		/// </summary>
		public static readonly Guid BulkEmailStatusActiveId = new Guid("C467C44F-345E-42EB-8385-8CE383699B52");

		/// <summary>
		/// Mailing response (Marketing) - Planned
		/// </summary>
		public static readonly Guid BulkEmailResponsePlannedId = new Guid("14769602-EBDA-40B1-91D5-EA9D623E2400"); 

		/// <summary>
		/// Mailing response (Marketing) - Send deffered.
		/// </summary>
		public static readonly Guid BulkEmailResponseDeferralId = new Guid("D45EA798-45C7-44BE-8B41-2C6ABB2CC4DE");

		/// <summary>
		/// Mailing response (Marketing) - Cancelled.
		/// </summary>
		[Obsolete]
		public static readonly Guid BulkEmailResponseCanceledId = new Guid("31AAED28-5789-43FF-9801-9FF6B5956B9B");

		/// <summary>
		/// Mailing response - Cancelled due to communication limit.
		/// </summary>
		public static readonly Guid BulkEmailResponseLimitedId = new Guid("31AAED28-5789-43FF-9801-9FF6B5956B9B");

		/// <summary>
		/// Mailing response (Marketing) - Canceled (unsubscribed list).
		/// </summary>
		public static readonly Guid BulkEmailResponseCanceledUnsubId = new Guid("BBFB3947-54FF-48C0-A1E5-F46F01A54E6D");

		/// <summary>
		/// Mailing response (Marketing) - Canceled (invalid email).
		/// </summary>
		public static readonly Guid BulkEmailResponseCanceledInvalidEmailId =
			new Guid("59ACDA79-1ACD-47CC-8655-8E74BD2D00D0");

		/// <summary>
		/// Mailing response (Marketing) - Canceled (incorrect email).
		/// </summary>
		public static readonly Guid BulkEmailResponseCanceledIncorrectEmailId =
			new Guid("F83922C2-C8A3-4DD0-A688-D59A41E1AB2B");

		/// <summary>
		/// Mailing response (Marketing) - Canceled (blank email).
		/// </summary>
		public static readonly Guid BulkEmailResponseCanceledBlankEmailId =
			new Guid("8FFDE5F0-CB75-4D90-A757-7E4748491ABF");

		/// <summary>
		/// Mailing response (Marketing) - General request failure.
		/// </summary>
		public static readonly Guid BulkEmailResponseRequestFailedId = new Guid("C2248D51-84ED-44B3-8E05-001B570BB517");

		/// <summary>
		/// Mailing response (Marketing) - Sent.
		/// </summary>
		public static readonly Guid BulkEmailResponseSentId = new Guid("9C56DB88-D16A-438F-B223-148B00C66C80"); 

		/// <summary>
		/// Mailing response (Marketing) - Rejected.
		/// </summary>
		public static readonly Guid BulkEmailResponseRejectedId = new Guid("EDD1CED0-ABDB-4B5A-89A2-46CFDBE33D7F"); 

		/// <summary>
		/// Mailing response (Marketing) - Recived by provier.
		/// </summary>
		public static readonly Guid BulkEmailResponseQueuedId = new Guid("CEDB7FDA-B9A1-463A-9735-6562B789EE5A");

		/// <summary>
		/// Mailing response (Marketing) - Sent to provier.
		/// </summary>
		public static readonly Guid BulkEmailResponsePostedProviderId = new Guid("899AA74A-785C-4A26-B41C-6C30486FEBB9");

		/// <summary>
		/// Mailing response (Marketing) - Invalid addressee.
		/// </summary>
		public static readonly Guid BulkEmailResponseInvalidId = new Guid("86D520BB-0EB2-493E-B8C5-55523AC31705"); 

		/// <summary>
		/// Mailing response (Marketing) - Soft Bounce.
		/// </summary>
		public static readonly Guid BulkEmailResponseSoftBounceId = new Guid("9BA89F3B-6041-4E81-8F1A-B666CFB5BF7B");

		/// <summary>
		/// Mailing response (Marketing) - Spam.
		/// </summary>
		public static readonly Guid BulkEmailResponseSpamId = new Guid("DC5FED60-4C3B-46BD-BF12-7F3DEFC099B2"); 
		
		/// <summary>
		/// Mailing response (Marketing) - Unsubscribe.
		/// </summary>
		public static readonly Guid BulkEmailResponseUnsubId = new Guid("A670EE81-2166-4C85-9E41-88901CA9CA38");

		/// <summary>
		/// Mailing response (Marketing) - Hard Bounce.
		/// </summary>
		public static readonly Guid BulkEmailResponseHardBounceId = new Guid("CBA985B0-32B8-48F7-924E-7F33E8BD45B8"); 

		/// <summary>
		/// Mailing response (Marketing) - Opened.
		/// </summary>
		public static readonly Guid BulkEmailResponseOpenedId = new Guid("5788B052-74AB-481D-8D0F-EFE87A19848F"); 

		/// <summary>
		/// Mailing response (Marketing) - Link click.
		/// </summary>
		public static readonly Guid BulkEmailResponseClickedId = new Guid("62A08686-CC06-4B4D-88E2-A6DF4D4F6B77");

		/// <summary>
		/// Mailing response (Marketing) - Ready to send.
		/// </summary>
		public static readonly Guid BulkEmailResponseReadyToSendId = new Guid("D3C5AF47-40B6-4CA0-AA5A-AFC9F49BD811");

		/// <summary>
		/// Mailing response (Marketing) - Stopped manually.
		/// </summary>
		public static readonly Guid BulkEmailResponseStoppedManually = new Guid("13244973-D412-42BE-B4E7-99B040AB793F");

		/// <summary>
		/// Mailing response (Marketing) - Stopped (time to send expired).
		/// </summary>
		public static readonly Guid BulkEmailResponseStoppedExpired = new Guid("ABC2C0D7-7FBC-49C8-8E9E-AB7358FC7044");

		/// <summary>
		/// Unique user id for Mandrill integration.
		/// </summary>
		public static readonly Guid MandrillUserId = new Guid("8AB1343F-CB58-49C7-95A2-058B5F60ACD3");

		/// <summary>
		/// Message template macro - Owner
		/// </summary>
		public static readonly Guid EmailTemplateMacrosParentGlobalId = new Guid("1D151866-0C45-413E-B288-9654F44113AE");

		/// <summary>
		/// Message template macro - Linked entity
		/// </summary>
		public static readonly Guid EmailTemplateMacrosParentEntityId = new Guid("AB5BB833-CF8F-4D36-B81C-5FE8B1185CF6");

		/// <summary>
		/// Message template macro - Recipient
		/// </summary>
		public static readonly Guid EmailTemplateMacrosParentContactId = new Guid("EBB220F0-F36B-1410-3088-1C6F65E24DB2");

		/// <summary>
		/// Message template macro - Unsubscribe
		/// </summary>
		public static readonly Guid EmailTemplateMacrosParentUnsubscribeId = new Guid("0C5FCD38-9171-4030-ABE7-B8A7ACAF8B38");

		/// <summary>
		/// Message template macro - Unsubscribe.URL
		/// </summary>
		public static readonly Guid EmailTemplateMacrosUnsubscribeUrlId = new Guid("392C7FC2-925E-46ED-A2A6-F2E89D047236");
		
		/// <summary>
		/// Reason for non actual communiacation type - Soft Bounce
		/// </summary>
		public static readonly Guid SoftBounceNonActualReasonId = new Guid("064BBCBD-0D14-4150-9AFB-D504E27CCBCE");

		/// <summary>
		/// Reason for non actual communiacation type - Hard Bounce
		/// </summary>
		public static readonly Guid HardBounceNonActualReasonId = new Guid("4B604BD3-46BF-4F3C-AEDD-38D318765C5A");

		/// <summary>
		/// Reason for non actual communiacation type - Invalid Email
		/// </summary>
		public static readonly Guid InvalidEmailNonActualReasonId = new Guid("EB8CB207-B331-4BFD-9812-14D0BF50E8FE");

		/// <summary>
		/// Reason for non actual communiacation type - Rejected
		/// </summary>
		public static readonly Guid RejectedNonActualReasonId = new Guid("E0A76A46-C931-4553-956A-159294609A72");

		/// <summary>
		/// Reason for non actual communiacation type - Set manually.
		/// </summary>
		public static readonly Guid ManuallyNonActualReasonId = new Guid("FE0B394D-9403-4D08-BC55-068528B2DE45");

		/// <summary>
		/// Contact subscription status - Unsubscribed.
		/// </summary>
		public static readonly Guid BulkEmailContactUnsubscribed = new Guid("C8947F80-A374-412A-BBC8-EA9068A8B78E");

		/// <summary>
		/// Mailing category - Bulk email.
		/// </summary>
		public static readonly Guid MassmailingBulkEmailCategoryId = new Guid("8CEC06ED-2643-46F7-AB00-352ACBC3BD8A");

		/// <summary>
		/// Mailing category - Trigger email.
		/// </summary>
		public static readonly Guid TriggeredEmailBulkEmailCategoryId = new Guid("2DF24C22-B596-4994-A0CD-E2FA1D8ECDEB");

		/// <summary>
		/// Bulk email launch option - launch manually.
		/// </summary>
		public static readonly Guid BulkEmailManaulLaunchOptionId = new Guid("6F72C1B4-810B-4EF9-BC20-879372C8E2C2");

		/// <summary>
		/// Bulk email launch option - in specified time.
		/// </summary>
		public static readonly Guid BulkEmailScheduledaunchOptionId = new Guid("936B2D84-CF46-404F-8726-D377E4896774");

		/// <summary>
		/// Trigger email launch option - immediately.
		/// </summary>
		public static readonly Guid TriggerEmailImmediateLaunchOptionId = new Guid("F1E82AFB-8820-4A13-8BC3-22B1A8180AB1");

		/// <summary>
		/// Trigger email launch option - in specified time.
		/// </summary>
		public static readonly Guid TriggerEmailScheduledLaunchOptionId = new Guid("5A3CEB77-64B9-446E-AE64-F78D358E42A8");

		/// <summary>
		/// Trigger email launch option - from campaign.
		/// </summary>
		public static readonly Guid TriggerEmailFromCampaignLaunchOptionId = new Guid("17EC7FB4-C709-469B-A332-59656695082E");

		/// <summary>
		/// Split test state - Planned.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusPlannedId = new Guid("CB26ED70-E6F7-4E48-BC7B-560B2676FCC6");

		/// <summary>
		/// Split test state - Launched.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusLaunchedId = new Guid("30E71DF7-D9F7-4A9A-861B-A6A26E59D19E");

		/// <summary>
		/// Split test state - Planned to launch.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusStartPlanedId = new Guid("069579CF-AA28-497A-AE48-7DB6A61E33FC");

		/// <summary>
		/// Split test state - Completed.
		/// </summary>
		public static readonly Guid BulkEmailSplitStatusFinishedId = new Guid("43DDFB49-C9A5-4D63-8294-D54419456C0B");
		
		/// <summary>
		/// Segment actualization state - Updated
		/// </summary>
		public static readonly Guid SegmentStatusUpdatedId = new Guid("FA360D2C-1658-49AD-9152-22479FDC0C12");

		/// <summary>
		/// Segment actualization state - Updating
		/// </summary>
		public static readonly Guid SegmentStatusUpdatingId = new Guid("64ECD6EB-17DA-472B-A000-0809D49348F3");

		/// <summary>
		/// Segment actualization state - Requires updating
		/// </summary>
		public static readonly Guid SegmentStatusRequiresUpdatingId = new Guid("DFB4E827-1B9B-4EA7-B4EB-898F592451F9");

		/// <summary>
		/// Alias for macros from sender name 
		/// </summary>
		public static readonly string FromNameMacroKey = "FROM_NAME";

		/// <summary>
		/// Alias for macros from sender email 
		/// </summary>
		public static readonly string FromEmailMacroKey = "FROM_EMAIL";

		/// <summary>
		/// Name of quartz scheduler to manage bulk emails.
		/// </summary>
		public static readonly string BulkEmailQuartzScheduler = "BulkEmailQuartzScheduler";

		/// <summary>
		/// Job group name for mailing. 
		/// </summary>
		public static readonly string BulkEmailQuartzJobGroupName = "Mailing";

		/// <summary>
		/// Identifier of manual limit throttling mode for email.
		/// </summary>
		public static readonly Guid ManualLimitThrottlingMode = new Guid("4D162409-3D58-4C52-9D5E-4CD4052D2AE8");

		/// <summary>
		/// Array of the Mailing statuses when email cannot be processed due to final state.
		/// </summary>
		public static Guid[] FinalStatuses {
			get {
				return new[] {
					BulkEmailStatusExpiredId, BulkEmailStatusHardStoppedId, BulkEmailStatusFinishedId
				};
			}
		}
	}

	#endregion
}


