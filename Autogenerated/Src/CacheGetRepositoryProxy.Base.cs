namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Store;

	#region Class: CacheGetRepositoryProxy

	/// <summary>
	/// Provides methods to obtain data from cache.
	/// </summary>
	/// <typeparam name="TData">Data</typeparam>
	public class CacheGetRepositoryProxy<TData> : IGetRepository<TData>
		where TData : EntityData, new()
	{

		#region Fields: Private

		private readonly string _cacheKeyTemplate = "CacheGetRepositoryProxy_{0}_{1}_{2}";

		private ICacheStore _cacheStore;

		#endregion

		#region Constructors: Public

		public CacheGetRepositoryProxy(UserConnection userConnection, IGetRepository<TData> repository, string schemaName) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			repository.CheckArgumentNull(nameof(repository));
			schemaName.CheckArgumentNullOrWhiteSpace(nameof(schemaName));
			UserConnection = userConnection;
			Repository = repository;
			SchemaName = schemaName;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get;
		}

		protected IGetRepository<TData> Repository {
			get;
		}

		protected string SchemaName {
			get;
		}

		protected ICacheStore CacheStore {
			get {
				if (_cacheStore == null) {
					_cacheStore = UserConnection.ApplicationCache.WithLocalCaching(SchemaName);
				}
				return _cacheStore;
			}
		}

		#endregion

		#region Methods: Private

		private string GetKey() {
			var culture = UserConnection.CurrentUser.Culture.Name;
			return string.Format(_cacheKeyTemplate, Repository.GetType().Name, SchemaName, culture);
		}

		private IEnumerable<TData> GetDataFromCache() {
			var key = GetKey();
			return CacheStore[key] as IEnumerable<TData> ?? new List<TData>();
		}

		private void SetDataToCache(IEnumerable<TData> data) {
			var key = GetKey();
			CacheStore[key] = data;
		}

		private IEnumerable<TData> GetDatas() {
			IEnumerable<TData> datas = GetDataFromCache().ToArray();
			if (datas.IsNullOrEmpty()) {
				datas = Repository.GetAll().ToArray();
				SetDataToCache(datas);
			}
			return datas;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets entity data by identifier.
		/// </summary>
		/// <param name="id">The item identifier.</param>
		/// <returns>The entity data.</returns>
		public TData Get(Guid id) {
			var datas = GetDatas();
			return datas.FirstOrDefault(member => member.Id.Equals(id));
		}

		/// <summary>
		/// Gets all entity data.
		/// </summary>
		/// <returns>Collection of entity data.</returns>
		public IEnumerable<TData> GetAll() {
			return GetDatas();
		}

		#endregion

	}

	#endregion

}

