namespace BPMSoft.Mail
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Store;

	#region Class: FlagBasedSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementaiton, delivered from <see cref="SyncStrategy"/>.
	/// </summary>
	/// <remarks>
	/// FlagBasedSyncStrategy used to select all not-draft, not-deleted messages,
	/// not marked by <see cref="FlagBasedSyncStrategy.SyncFlag"/> keyword.
	/// </remarks>
	public partial class FlagBasedSyncStrategy : SyncStrategy
	{

		#region Constants: Private
		
		/// <summary>
		/// Lock object for sync flag initalization.
		/// </summary>
		private static readonly object _syncFlagLockObject = new object();

		/// <summary>
		/// Sync flag application cache key.
		/// </summary>
		private const string _syncFlagCacheKey = "ImapMailSyncKey";

		#endregion

		#region Fields: Private

		/// <summary>
		/// Search expression template.
		/// </summary>
		private readonly string _searchQueryTpl = "UNDRAFT UNDELETED UNKEYWORD {0}";
		
		#endregion
		
		#region Fields: Protected
		
		/// <summary> 
		/// Synchronized message keyword.
		/// </summary>
		protected string _syncFlag;

		#endregion

		#region Constructors: Public

		public FlagBasedSyncStrategy(UserConnection userConnection) {
			_syncFlag = GetEmailSynchronizedFlag(userConnection);
		}
		
		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns sync flag value for imap message.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns>
		/// Sync flag for imap message.
		/// </returns>
		/// <remarks>
		/// SyncFlag value stored in application cache and database. First synchronization must create unique value,
		/// and store it in application cache and database.
		/// </remarks>
		private string GetEmailSynchronizedFlag(UserConnection userConnection) {
			var cachedKey = GetSyncKeyFromCache(userConnection);
			if (!string.IsNullOrEmpty(cachedKey)) {
				return cachedKey;
			}
			var dbKey = GetSyncKeyFromDB(userConnection);
			if (!string.IsNullOrEmpty(dbKey)) {
				SetSyncKeyToCache(dbKey, userConnection);
				return dbKey;
			}
			lock (_syncFlagLockObject) {
				cachedKey = GetSyncKeyFromCache(userConnection);
				if (!string.IsNullOrEmpty(cachedKey)) {
					return cachedKey;
				}
				var generatedKey = Guid.NewGuid().ToString();
				SetSyncKeyToDB(generatedKey, userConnection);
				SetSyncKeyToCache(generatedKey, userConnection);
				return generatedKey;
			}
		}
		
		/// <summary>
		/// Returns sync flag value from application cache.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns>
		/// Sync flag value from application cache.
		/// </returns>
		private string GetSyncKeyFromCache(UserConnection userConnection) {
			IDataStore store = userConnection.ApplicationData;
			return store[_syncFlagCacheKey] as string;
		}
		
		/// <summary>
		/// Returns sync flag value from database.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns>
		/// Sync flag value from application database.
		/// </returns>
		private string GetSyncKeyFromDB(UserConnection userConnection) {
			var result = string.Empty;
			var select = new Select(userConnection)
				.Column("Name")
				.From("EmailSynchronizedKey")
				.OrderByAsc("CreatedOn") as Select;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						result = reader.GetString(0);
					}
				}
			}
			return result;
		}
		
		/// <summary>
		/// Sets sync flag value to application cache.
		/// </summary>
		/// <param name="value">Sync flag value.</param>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		private void SetSyncKeyToCache(string value, UserConnection userConnection) {
			IDataStore store = userConnection.ApplicationData;
			store[_syncFlagCacheKey] = value;
		}
		
		/// <summary>
		/// Sets sync flag value to database.
		/// </summary>
		/// <param name="value">Sync flag value.</param>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		private void SetSyncKeyToDB(string value, UserConnection userConnection) {
			var insert = new Insert(userConnection)
					.Into("EmailSynchronizedKey")
					.Set("Name", Column.Parameter(value));
			insert.Execute();
		}
		
		#endregion
		
		#region Methods: Public

		/// <summary><see cref="ISyncStrategy.GetUnsyncMsgSearchQuery"/></summary>
		public override string GetUnsyncMsgSearchQuery() {
			return string.Format(_searchQueryTpl, _syncFlag);
		}

		#endregion
	}

	#endregion
}
