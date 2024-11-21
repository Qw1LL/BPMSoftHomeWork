namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;

	#region Class: QueueCacheHelper

	/// <summary>
	/// Provides a cache to store frequently accessed queue data.
	/// </summary>
	public class QueueCacheHelper
	{

		#region Fields: Private

		private static readonly string _expireGroupKey = "QueueDataGroupKey_05EA3D2D-EA69-43A7-9A92-F743B047E7D7";
		private static readonly string _cacheItemName = "QueueDataKey_05EA3D2D-EA69-43A7-9A92-F743B047E7D7";
		private static readonly ICacheStore _applicationCache = Store.Cache[CacheLevel.Application]
			.WithLocalCachingOnly(_expireGroupKey);
		private readonly EntitySchemaQuery _esq;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates a new instance of the <see cref="QueueCacheHelper"/> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="esq">Represents query for the queue object schema.</param>
		public QueueCacheHelper(UserConnection userConnection, EntitySchemaQuery esq) {
			userConnection.CheckArgumentNull("userConnection");
			esq.CheckArgumentNull("esq");
			_userConnection = userConnection;
			esq.Cache = _applicationCache;
			esq.CacheItemName = _cacheItemName;
			_esq = esq;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets data of the Queue.
		/// </summary>
		public EntityCollection Items {
			get {
				return _esq.GetEntityCollection(_userConnection);
			}
		}

		#endregion

		#region Methods: Public
		
		/// <summary>
		/// Clears cached data.
		/// </summary>
		public static void ClearCache() {
			_applicationCache.ExpireGroup(_expireGroupKey);
			_applicationCache.Remove(_cacheItemName);
		}

		#endregion

	}

	#endregion

}

