namespace BPMSoft.Mail
{
	using System;
	using System.Globalization;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: UidBasedSinceSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementatiton, delivered from <see cref="UidBasedSyncStrategy"/>.
	/// </summary>
	[DefaultBinding(typeof(ISyncStrategy), Name = "UidBasedSinceSyncStrategy")]
	public class UidBasedSinceSyncStrategy : UidBasedSyncStrategy
	{

		#region Properties: Protected

		/// <summary>
		/// Search expression template.
		/// </summary>
		protected override string UnsyncMsgSearchQuery {
			get {
				return "UNDRAFT UNDELETED SINCE {0}";
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates new <see cref="UidBasedSinceSyncStrategy"/> instance.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="syncSettings"><see cref="MailboxSyncSettings"/> instance.</param>
		public UidBasedSinceSyncStrategy(UserConnection userConnection, Entity syncSettings)
			: base(userConnection, syncSettings) {
		}

		#endregion

		#region Methods: Public

		/// <summary><see cref="ISyncStrategy.GetUnsyncMsgSearchQuery"/></summary>
		public override string GetUnsyncMsgSearchQuery() {
			if (string.IsNullOrEmpty(CurrentMessageUidInFolder) || CurrentMessageUidInFolder == "0") {
				DateTime loadEmailsFromDate = GetSyncSinceDate();
				return GetFailoverMsgSearchQuery(loadEmailsFromDate);
			}
			return base.GetUnsyncMsgSearchQuery();
		}

		/// <summary><see cref="ISyncStrategy.GetFailoverMsgSearchQuery(DateTime)"/></summary>
		public override string GetFailoverMsgSearchQuery(DateTime sinceDate) {
			return string.Format(UnsyncMsgSearchQuery, sinceDate.ToString(_imapDateFormat, CultureInfo.InvariantCulture));
		}

		#endregion

	}

	#endregion
}

