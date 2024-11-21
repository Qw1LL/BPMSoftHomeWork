namespace BPMSoft.Mail
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: SyncStrategy

	/// <summary><see cref="ISyncStrategy"/> implementaiton.</summary>
	public abstract partial class SyncStrategy : ISyncStrategy
	{

		#region Constants: Internal

		/// <summary>
		/// Imap search query date format.
		/// </summary>
		internal const string _imapDateFormat = "dd-MMM-yyyy";

		#endregion

		#region Fields: Protected

		/// <summary>
		/// <see cref="Core.UserConnection"/> instance.
		/// </summary>
		protected UserConnection UserConnection;

		#endregion

		#region Proporties: Public

		/// <summary>
		/// Synchronization settings <see cref="Entity"/> instance.
		/// </summary>
		public Entity SyncSettings {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns <see cref="System.DateTime"/> value, used in serch query as since parameter.
		/// </summary>
		/// <returns><see cref="System.DateTime"/> value.</returns>
		protected virtual DateTime GetSyncSinceDate() {
			return new List<DateTime> {
				LoadFromDateType.GetInstance(UserConnection).GetLoadFromDate(SyncSettings),
				SyncSettings.GetTypedColumnValue<DateTime>("LastSyncDate")
			}.Max();
		}

		#endregion

		#region Methods: Public

		/// <summary><see cref="ISyncStrategy.GetFailoverMsgSearchQuery(DateTime)"/></summary>
		public virtual string GetFailoverMsgSearchQuery(DateTime sinceDate) {
			return GetUnsyncMsgSearchQuery();
		}

		/// <summary><see cref="ISyncStrategy.GetUnsyncMsgSearchQuery"/></summary>
		public abstract string GetUnsyncMsgSearchQuery();

		#endregion

	}

	#endregion

}
