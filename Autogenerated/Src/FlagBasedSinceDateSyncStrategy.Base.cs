namespace BPMSoft.Mail
{
	using System;
	using System.Globalization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: FlagBasedSinceDateSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementaiton, delivered from <see cref="FlagBasedSyncStrategy"/>.
	/// </summary>
	/// <remarks>
	/// FlagBasedSinceDateSyncStrategy used to select all not-draft, not-deleted messages,
	/// not marked by <see cref="FlagBasedSyncStrategy.SyncFlag"/> keyword
	/// since <see cref="DateBasedSyncStrategy._sinceDate"/>.
	/// </remarks>
	[DefaultBinding(typeof(ISyncStrategy), Name = "FlagBasedSinceDateSyncStrategy")]
	public class FlagBasedSinceDateSyncStrategy : FlagBasedSyncStrategy
	{

		#region Constants: Private

		/// <summary>
		/// Search expression template.
		/// </summary>
		private const string _searchQueryTpl = "UNDRAFT UNDELETED UNKEYWORD {0} SINCE {1}";

		#endregion

		#region Constructors: Public

		public FlagBasedSinceDateSyncStrategy(UserConnection userConnection, Entity syncSettings) :
			base(userConnection) {
			UserConnection = userConnection;
			SyncSettings = syncSettings;
		}

		#endregion

		#region Methods: Public

		/// <summary><see cref="ISyncStrategy.GetUnsyncMsgSearchQuery"/></summary>
		public override string GetUnsyncMsgSearchQuery() {
			var sinceDate = GetSyncSinceDate();
			if (sinceDate != DateTimeUtilities.JavascriptMinDateTime && sinceDate != DateTime.MinValue) {
				return GetFailoverMsgSearchQuery(sinceDate);
			}
			return base.GetUnsyncMsgSearchQuery();
		}

		/// <summary><see cref="ISyncStrategy.GetFailoverMsgSearchQuery(DateTime)"/></summary>
		public override string GetFailoverMsgSearchQuery(DateTime sinceDate) {
			return string.Format(_searchQueryTpl, _syncFlag, sinceDate.ToString(_imapDateFormat,
				CultureInfo.InvariantCulture));
		}

		#endregion
	}

	#endregion

}
