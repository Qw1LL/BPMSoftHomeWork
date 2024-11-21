namespace BPMSoft.Mail
{
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: UidSinceSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementaiton, delivered from <see cref="UidBasedSyncStrategy"/>.
	/// </summary>
	/// <remarks>
	/// UidBasedSyncStrategy used to select all messages indexes from since sent date.
	/// </remarks>
	[DefaultBinding(typeof(ISyncStrategy), Name = "UidSinceSyncStrategy")]
	public class UidSinceSyncStrategy : UidBasedSyncStrategy
	{

		#region Property: Protected

		/// <summary>
		/// Search expression template.
		/// </summary>
		protected override string UnsyncMsgSearchQuery {
			get {
				return "SINCE {0}";
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="syncSettings"><see cref="MailboxSyncSettings"/> instance.</param>
		public UidSinceSyncStrategy(UserConnection userConnection, Entity syncSettings)
			: base(userConnection, syncSettings) {
		}

		#endregion

	}

	#endregion
	
}
