namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;

	#region Class: BulkEmailResponseMapping

	public static class BulkEmailResponseMapping
	{

		#region Fields: Private

		private static readonly string _bulkEmailResponseCollectionCacheItemName = "BulkEmailResponseCollectionCache";

		#endregion

		#region Methods: Private

		private static Entity GetBulkEmailResponseByCode(UserConnection userConnection, ICacheStore cache, int code) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "BulkEmailResponse") {
				IgnoreDisplayValues = true,
				CacheItemName = _bulkEmailResponseCollectionCacheItemName,
				Cache = cache
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var codeColumnName = esq.AddColumn("Code").Name;
			var responseCollection = esq.GetEntityCollection(userConnection);
			return responseCollection.FirstOrDefault(x => x.GetTypedColumnValue<int>(codeColumnName) == code);
		}

		#endregion

		#region Methods: Public

		public static Guid GetResponseIdByCode(UserConnection userConnection, int code) {
			var cache = userConnection.ApplicationCache.WithLocalCaching();
			var response = GetBulkEmailResponseByCode(userConnection, cache, code);
			if (response == null) {
				cache.Remove(_bulkEmailResponseCollectionCacheItemName);
				response = GetBulkEmailResponseByCode(userConnection, cache, code);
			}
			return response.PrimaryColumnValue;
		}

		#endregion

	}

	#endregion

}

