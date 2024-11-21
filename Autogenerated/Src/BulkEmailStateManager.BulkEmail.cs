namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using global::Common.Logging;

	#region Interface: IBulkEmailStateCheck

	public interface IBulkEmailStateCheck
	{
		#region Properties: Public

		/// <summary>
		/// Unique identifier of current bulk email audience schema.
		/// </summary>
		Guid AudienceSchemaId { get; }

		/// <summary>
		/// Sign becomes True when any recipirnts were added to audience.
		/// </summary>
		bool IsAudienceInited { get; }

		#endregion

		#region Methods: Publics

		/// <summary>
		/// Defines if audience can be added into email due to current state.
		/// </summary>
		/// <returns>True/false</returns>
		bool CanAddAudience();

		/// <summary>
		/// Defines if audience can be removed from email due to current state.
		/// </summary>
		/// <returns>True/false</returns>
		bool CanRemoveAudience();

		/// <summary>
		/// Defines if it is allowed to schedule job to start sending an email.
		/// </summary>
		/// <returns>True/false</returns>
		bool CanStartSending();

		#endregion

	}

	#endregion

	#region Interface: IBulkEmailStateManager

	public interface IBulkEmailStateManager : IBulkEmailStateCheck
	{

		#region Methods: Publics

		bool TrySetAudienceSchema(Guid audienceSchemaId);

		#endregion

	}

	#endregion

	#region Class: BulkEmailStateManager

	/// <summary>
	/// Defines if state of bulk/trigger email allows to process <see cref="BulkEmailQueueMessage"/>.
	/// Operates with <see cref="BulkEmailStatus"/>.Id, <see cref="BulkEmailCategory"/>.Id
	/// and <see cref="BulkEmailAudienceSchema"/>.Id.
	/// </summary>
	public class BulkEmailStateManager : IBulkEmailStateManager
	{

		#region Class: BaseEmailStateCheck

		private abstract class BaseEmailStateCheck : IBulkEmailStateCheck
		{

			#region Fields: Private

			/// <summary>
			/// Bulk email status identifier.
			/// </summary>
			private Guid _statusId;

			/// <summary>
			/// Bulk email audience schema identifier.
			/// </summary>
			private Guid _audienceSchemaId;

			/// <summary>
			/// Sign becomes True when any recipirnts were added to audience.
			/// </summary>
			private bool _isAudienceInited;

			#endregion

			#region Constructors: Public

			/// <summary>
			/// Constructor for <see cref="BaseEmailStateCheck"/>.
			/// </summary>
			/// <param name="statusId">Id of bulk email status.</param>
			/// <param name="audienceSchemaId">Id of bulk email audience schema.</param>
			/// <param name="isAudienceInited">Sign is True when any recipirnts were added to audience.</param>
			public BaseEmailStateCheck(Guid statusId, Guid audienceSchemaId, bool isAudienceInited) {
				_statusId = statusId;
				_audienceSchemaId = audienceSchemaId;
				_isAudienceInited = isAudienceInited;
			}

			#endregion

			#region Properties: Protected

			/// <summary>
			/// Collection of allowed statuses for audience adding.
			/// </summary>
			protected abstract IEnumerable<Guid> AddAudienceAllowedStatuses { get; }

			/// <summary>
			/// Collection of bulk email allowed statuses for audience removing.
			/// </summary>
			protected abstract IEnumerable<Guid> RemoveAudienceAllowedStatuses { get; }

			/// <summary>
			/// Collection of bulk email allowed statuses for start sending.
			/// </summary>
			protected abstract IEnumerable<Guid> StartSendingAllowedStatuses { get; }

			#endregion

			#region Properties: Public

			/// <summary>
			/// Unique identifier of current bulk email audience schema.
			/// </summary>
			public Guid AudienceSchemaId => _audienceSchemaId;

			/// <summary>
			/// Sign becomes True when any recipirnts were added to audience.
			/// </summary>
			public bool IsAudienceInited => _isAudienceInited;

			#endregion

			#region Methods: Public

			/// <summary>
			/// Defines if audience can be added into email due to current state.
			/// </summary>
			/// <returns>True/false</returns>
			public virtual bool CanAddAudience() {
				return AddAudienceAllowedStatuses.Contains(_statusId);
			}

			/// <summary>
			/// Defines if audience can be removed from email due to current state.
			/// </summary>
			/// <returns>True/false</returns>
			public virtual bool CanRemoveAudience() {
				return RemoveAudienceAllowedStatuses.Contains(_statusId);
			}

			/// <summary>
			/// Defines if it is allowed to schedule job to start sending an email.
			/// </summary>
			/// <returns>True/false</returns>
			public virtual bool CanStartSending() {
				return StartSendingAllowedStatuses.Contains(_statusId);
			}

			#endregion

		}

		#endregion

		#region Class: BulkEmailStateCheck

		private class BulkEmailStateCheck : BaseEmailStateCheck
		{

			#region Constructors: Public

			public BulkEmailStateCheck(Guid statusId, Guid audienceSchemaId, bool isAudienceInited)
				: base(statusId, audienceSchemaId, isAudienceInited) { }

			#endregion

			#region Properties: Protected

			/// <summary>
			/// Collection of allowed statuses for audience adding to bulk email.
			/// </summary>
			protected override IEnumerable<Guid> AddAudienceAllowedStatuses => new[] {
				MailingConsts.BulkEmailStatusDraftId,
				MailingConsts.BulkEmailStatusPlannedId,
				MailingConsts.BulkEmailStatusStartPlanedId
			};

			/// <summary>
			/// Collection of bulk email allowed statuses for audience removing from bulk email.
			/// </summary>
			protected override IEnumerable<Guid> RemoveAudienceAllowedStatuses => new[] {
				MailingConsts.BulkEmailStatusDraftId,
				MailingConsts.BulkEmailStatusPlannedId,
				MailingConsts.BulkEmailStatusStartPlanedId
			};

			/// <summary>
			/// Collection of allowed statuses for bulk email start sending.
			/// </summary>
			protected override IEnumerable<Guid> StartSendingAllowedStatuses => new[] {
				MailingConsts.BulkEmailStatusPlannedId,
				MailingConsts.BulkEmailStatusStartPlanedId
			};

			#endregion

		}

		#endregion
		
		#region Class: BulkEmailOperationsStateCheck

		private class BulkEmailOperationsStateCheck : BaseEmailStateCheck
		{

			#region Constructors: Public

			public BulkEmailOperationsStateCheck(Guid statusId, Guid audienceSchemaId, bool isAudienceInited)
				: base(statusId, audienceSchemaId, isAudienceInited) { }

			#endregion

			#region Properties: Protected

			/// <summary>
			/// Collection of allowed statuses for audience adding to bulk email.
			/// </summary>
			protected override IEnumerable<Guid> AddAudienceAllowedStatuses => new[] {
				MailingConsts.BulkEmailStatusDraftId,
				MailingConsts.BulkEmailStatusPlannedId,
				MailingConsts.BulkEmailStatusStartPlanedId,
				MailingConsts.BulkEmailStatusStoppedId
			};

			/// <summary>
			/// Collection of bulk email allowed statuses for audience removing from bulk email.
			/// </summary>
			protected override IEnumerable<Guid> RemoveAudienceAllowedStatuses => new[] {
				MailingConsts.BulkEmailStatusDraftId,
				MailingConsts.BulkEmailStatusPlannedId,
				MailingConsts.BulkEmailStatusStartPlanedId,
				MailingConsts.BulkEmailStatusStoppedId
			};

			/// <summary>
			/// Collection of allowed statuses for bulk email start sending.
			/// </summary>
			protected override IEnumerable<Guid> StartSendingAllowedStatuses => new[] {
				MailingConsts.BulkEmailStatusPlannedId,
				MailingConsts.BulkEmailStatusStartPlanedId,
				MailingConsts.BulkEmailStatusStoppedId
			};

			#endregion

		}

		#endregion

		#region Class: TriggerEmailStateCheck

		private class TriggerEmailStateCheck : BaseEmailStateCheck
		{

			#region Constructors: Public

			public TriggerEmailStateCheck(Guid statusId, Guid audienceSchemaId)
				: base(statusId, audienceSchemaId, true) { }

			#endregion

			#region Properties: Protected

			/// <summary>
			/// Collection of allowed statuses for audience adding to bulk email.
			/// </summary>
			protected override IEnumerable<Guid> AddAudienceAllowedStatuses => new[] {
				MailingConsts.BulkEmailStatusActiveId
			};

			/// <summary>
			/// Collection of bulk email allowed statuses for audience removing from bulk email.
			/// </summary>
			protected override IEnumerable<Guid> RemoveAudienceAllowedStatuses => new Guid[] { };

			/// <summary>
			/// Collection of allowed statuses for bulk email start sending.
			/// </summary>
			protected override IEnumerable<Guid> StartSendingAllowedStatuses =>
				new[] {
					MailingConsts.BulkEmailStatusActiveId,
					MailingConsts.BulkEmailStatusHardStoppedId,
					MailingConsts.BulkEmailStatusExpiredId,
					MailingConsts.BulkEmailStatusExpiredInProgressId
				};

			#endregion

		}

		#endregion

		#region Fields: Private

		private readonly Guid _contactAudienceSchemaId = Guid.Parse("2DB96695-3D62-40E4-9F31-2F1FFF23EEFB");

		#endregion

		#region Constructors: Public

		public BulkEmailStateManager(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection _userConnection { get; }

		/// <summary>
		/// Concrete implementation of state checker. Depends on bulk email category.
		/// </summary>
		private IBulkEmailStateCheck _emailStateCheck { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Logger.
		/// </summary>
		private ILog _logger;
		public ILog Logger {
			get => _logger ?? (_logger = MailingUtilities.Log);
			set => _logger = value;
		}

		/// <summary>
		/// Bulk email identifier to initialize state manager.
		/// </summary>
		private Guid _bulkEmailId;
		public Guid BulkEmailId {
			get => _bulkEmailId;
			set {
				_bulkEmailId = value;
				InitStateManager();
			}
		}

		
		private IEnumerable<Guid> _allowedAudienceSchemaIds;
		/// <summary>
		/// Collection of allowed bulk email audience schemas' unique identifiers.
		/// </summary>
		private IEnumerable<Guid> AllowedAudienceSchemaIds =>
			_allowedAudienceSchemaIds ?? (_allowedAudienceSchemaIds = GetAllowedAudienceSchemaIds());

		/// <summary>
		/// Unique identifier of current bulk email audience schema.
		/// </summary>
		public Guid AudienceSchemaId => _emailStateCheck.AudienceSchemaId;

		/// <summary>
		/// Sign becomes True when any recipirnts were added to audience.
		/// </summary>
		public bool IsAudienceInited => _emailStateCheck.IsAudienceInited;

		#endregion

		#region Methods: Private

		private IEnumerable<Guid> GetAllowedAudienceSchemaIds() {
			return new Select(_userConnection)
				.Column("Id")
				.From(nameof(BulkEmailAudienceSchema))
				.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id"));
		}

		/// <param name="categoryId">Bulk email category like Bulk, Trigger etc.</param>
		/// <param name="statusId">Bulk email status like Active, Draft, Plans etc.</param>
		/// <param name="audienceSchemaId">Bulk email audience schema like Contact, Lead etc.</param>
		/// <param name="isAudienceInited">Sign is True when any recipirnts were added to audience.</param>
		private void InitEmailStateCheckInstance(Guid categoryId, Guid statusId, Guid audienceSchemaId,
				bool isAudienceInited) {
			if (categoryId == MailingConsts.TriggeredEmailBulkEmailCategoryId) {
				_emailStateCheck = new TriggerEmailStateCheck(statusId, audienceSchemaId);
			} else if (categoryId == MailingConsts.MassmailingBulkEmailCategoryId) {
				GetBulkEmailStateCheckInstance(statusId, audienceSchemaId, isAudienceInited);
			}
		}

		private void GetBulkEmailStateCheckInstance(Guid statusId, Guid audienceSchemaId, bool isAudienceInited) {
			var isPausedFeatureEnabled = _userConnection.GetIsFeatureEnabled("BulkEmailPause");
			if (isPausedFeatureEnabled) {
				_emailStateCheck = new BulkEmailOperationsStateCheck(statusId, audienceSchemaId, isAudienceInited);
			} else {
				_emailStateCheck = new BulkEmailStateCheck(statusId, audienceSchemaId, isAudienceInited);
			}
		}

		private void InitStateManager() {
			var select = new Select(_userConnection)
				.Column("CategoryId")
				.Column("StatusId")
				.Column("AudienceSchemaId")
				.Column("IsAudienceInited")
				.From(nameof(BulkEmail))
				.Where("Id").IsEqual(Column.Parameter(BulkEmailId)) as Select;
			select.SpecifyNoLockHints();
			select.ExecuteReader(dr => {
				var categoryId = dr.GetColumnValue<Guid>("CategoryId");
				var statusId = dr.GetColumnValue<Guid>("StatusId");
				var audienceSchemaId = dr.GetColumnValue<Guid>("AudienceSchemaId");
				var isAudienceInited = dr.GetColumnValue<bool>("IsAudienceInited");
				InitEmailStateCheckInstance(categoryId, statusId, audienceSchemaId, isAudienceInited);
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines if audience can be added into email due to current state.
		/// </summary>
		/// <returns>True/false</returns>
		public virtual bool CanAddAudience() => _emailStateCheck.CanAddAudience();

		/// <summary>
		/// Defines if audience can be removed from email due to current state.
		/// </summary>
		/// <returns>True/false</returns>
		public virtual bool CanRemoveAudience() => _emailStateCheck.CanRemoveAudience();

		/// <summary>
		/// Defines if it is allowed to schedule job to start sending an email.
		/// </summary>
		/// <returns>True/false</returns>
		public virtual bool CanStartSending() => _emailStateCheck.CanStartSending();

		/// <summary>
		/// Verifies provided audience schema to set and updates bulk email audience schema column
		/// for current value when this column is empty.
		/// </summary>
		/// <param name="audienceSchemaId">Unique identifier of bulk email audience schema to set.</param>
		/// <returns>True if provided audience schema is valid
		/// and bulk email audience schema state is actual.</returns>
		public virtual bool TrySetAudienceSchema(Guid audienceSchemaId) {
			if (!AllowedAudienceSchemaIds.Contains(audienceSchemaId)) {
				return false;
			}
			if (_emailStateCheck.IsAudienceInited) {
				return _emailStateCheck.AudienceSchemaId == audienceSchemaId;
			}
			return new Update(_userConnection, nameof(BulkEmail))
				.Set("AudienceSchemaId", Column.Parameter(audienceSchemaId))
				.Set("IsAudienceInited", Column.Parameter(true))
				.Where("Id").IsEqual(Column.Parameter(BulkEmailId))
				.And("IsAudienceInited").IsEqual(Column.Parameter(false))
				.Execute() > 0;
		}

		#endregion

	}

	#endregion

}

