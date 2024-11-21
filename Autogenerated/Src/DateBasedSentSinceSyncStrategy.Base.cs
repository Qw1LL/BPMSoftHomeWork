namespace BPMSoft.Mail
{
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: DateBasedSentSinceSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementaiton, delivered from <see cref="DateBasedSyncStrategy"/>.
	/// </summary>
	/// <remarks>
	/// DateBasedSentSinceSyncStrategy used to select all not-draft, not-deleted messages,
	/// since sent date.
	/// </remarks>
	public class DateBasedSentSinceSyncStrategy : DateBasedSyncStrategy
	{

		#region Property: Protected

		/// <summary>
		/// Search expression template.
		/// </summary>
		protected override string UnsyncMsgSearchQuery {
			get {
				return "UNDRAFT UNDELETED SENTSINCE {0}";
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates <see cref="DateBasedSentSinceSyncStrategy"/> instance.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="syncSettings"><see cref="MailboxSyncSettings"/> instance.</param>
		public DateBasedSentSinceSyncStrategy(UserConnection userConnection, Entity syncSettings)
			: base(userConnection, syncSettings) {
		}

		#endregion

	}

	#endregion
}
