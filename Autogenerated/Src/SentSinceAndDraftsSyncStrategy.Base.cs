namespace BPMSoft.Mail
{
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: SentSinceAndDraftsSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementaiton, delivered from <see cref="DateBasedSentSinceSyncStrategy"/>.
	/// </summary>
	/// <remarks>
	/// SentSinceAndDraftsSyncStrategy used to select all not-deleted messages,
	/// since sent date.
	/// </remarks>
	[DefaultBinding(typeof(ISyncStrategy), Name = "SentSinceAndDraftsSyncStrategy")]
	public class SentSinceAndDraftsSyncStrategy : DateBasedSentSinceSyncStrategy
	{

		#region Property: Protected

		/// <summary>
		/// Search expression template.
		/// </summary>
		protected override string UnsyncMsgSearchQuery {
			get {
				return "UNDELETED SENTSINCE {0}";
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates <see cref="SentSinceAndDraftsSyncStrategy"/> instance.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="syncSettings"><see cref="MailboxSyncSettings"/> instance.</param>
		public SentSinceAndDraftsSyncStrategy(UserConnection userConnection, Entity syncSettings)
			: base(userConnection, syncSettings) {
		}

		#endregion

	}

	#endregion
}
