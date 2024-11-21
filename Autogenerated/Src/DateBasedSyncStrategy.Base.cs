namespace BPMSoft.Mail
{
	using System;
	using System.Globalization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: DateBasedSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementaiton, delivered from <see cref="SyncStrategy"/>.
	/// </summary>
	/// <remarks>
	/// DateBasedSyncStrategy used to select all not-draft, not-deleted messages,
	/// since <see cref="DateBasedSyncStrategy._lastSyncDate"/>.
	/// </remarks>
	[DefaultBinding(typeof(ISyncStrategy), Name = "DateBasedSyncStrategy")]
	public class DateBasedSyncStrategy : SyncStrategy
	{

		#region Property: Protected

		/// <summary>
		/// Search expression template.
		/// </summary>
		protected virtual string UnsyncMsgSearchQuery {
			get {
				return "UNDRAFT UNDELETED SINCE {0}";
			}
		}

		#endregion

		#region Constructors: Public

		public DateBasedSyncStrategy(UserConnection userConnection, Entity syncSettings) {
			if (syncSettings == null) {
#if !NETSTANDARD2_0
				throw new ImapException(new LocalizableString(userConnection.ResourceStorage, "DateBasedSyncStrategy",
					"LocalizableStrings.LocNoSettings.Value").ToString());
#else
				throw new NotImplementedException();
#endif
			}
			UserConnection = userConnection;
			SyncSettings = syncSettings;
		}

		#endregion

		#region Methods: Public

		/// <summary><see cref="ISyncStrategy.GetUnsyncMsgSearchQuery"/></summary>
		public override string GetUnsyncMsgSearchQuery() {
			var syncSinceDate = GetSyncSinceDate();
			return GetFailoverMsgSearchQuery(syncSinceDate);
		}

		/// <summary><see cref="ISyncStrategy.GetFailoverMsgSearchQuery(DateTime)"/></summary>
		public override string GetFailoverMsgSearchQuery(DateTime sinceDate) {
			return string.Format(UnsyncMsgSearchQuery,
				sinceDate.ToString(_imapDateFormat, CultureInfo.InvariantCulture));
		}

		#endregion

	}

	#endregion
}
