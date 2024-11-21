namespace BPMSoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core.Store;

	#region Class: StreamRedisRepository

	/// <summary>
	/// Class that implements repository to redis for <see cref="StorableStream"/> entity.
	/// </summary>
	public class StreamRedisRepository: IRepository<StorableStreamEntity>
	{

		#region Fields: Private

		private ICacheStore _cacheStore;

		#endregion

		#region Properties: Protected

		private ILog _log;
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("commonAppender"));

		#endregion

		#region Constructors: Public

		public StreamRedisRepository() { }

		public StreamRedisRepository(ICacheStore cacheStore) {
			cacheStore.CheckArgumentNull("StreamRedisRepository.Constructor argument");
			_cacheStore = cacheStore;
		}

		#endregion

		#region Methods: Protected

		protected ICacheStore GetCacheStore() {
			if (_cacheStore != null) {
				return _cacheStore;
			}
			var sessionStore = Store.Cache[CacheLevel.Session];
			if (sessionStore == null) {
				var errorMessage = "There is no redis storage.";
				Log.Error(errorMessage);
				throw new NullReferenceException(errorMessage);
			}
			return sessionStore;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates entity to the storage. 
		/// Throws ItemAlreadyExistException if entity is already exists.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <returns>Entity id.</returns>
		public virtual Guid Create(StorableStreamEntity entity) {
			if (GetCacheStore().GetValue<StorableStreamEntity>(entity.Id.ToString()) != null) {
				throw new ItemAlreadyExistException();
			}
			GetCacheStore()[entity.Id.ToString()] = entity;
			return entity.Id;
		}
		
		/// <summary>
		/// Finds by id item in storage.
		/// If item is found and matches type returns item,
		/// othervise returns null.
		/// </summary>
		/// <param name="id">Item id.</param>
		/// <returns>Item.</returns>
		public virtual StorableStreamEntity Find(Guid id) {
			var entity = GetCacheStore()[id.ToString()];
			if (entity is StorableStreamEntity storableStream) {
				return storableStream;
			} else {
				return null;
			}
		}

		/// <summary>
		/// Removes item from storage by id.
		/// If item was deleted returns true.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual void Remove(Guid id) {
			GetCacheStore().Remove(id.ToString());
		}

		public virtual IEnumerable<StorableStreamEntity> Where(Func<StorableStreamEntity, bool> predicaticate) {
			throw new NotImplementedException();
		}

		public virtual IEnumerable<StorableStreamEntity> GetAll() {
			throw new NotImplementedException();
		}

		#endregion

	}

	#endregion

} 
