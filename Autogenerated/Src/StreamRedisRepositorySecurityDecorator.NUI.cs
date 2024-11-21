namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: StreamRedisRepositorySecurityDecorator

	/// <summary>
	/// Security decorator for <see cref="StreamRedisRepository"/>
	/// </summary>
	public class StreamRedisRepositorySecurityDecorator : IRepository<StorableStreamEntity>
	{

		#region Fields: Private

		private StreamRedisRepository _streamRedisRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;

		#endregion

		#region Properties: Protected

		protected StreamRedisRepository StreamRedisRepository {
			get {
				if (_streamRedisRepository == null) {
					_streamRedisRepository = ClassFactory.Get<StreamRedisRepository>(
						new ConstructorArgument("cacheStore", UserConnection.SessionCache));
				}
				_streamRedisRepository.CheckArgumentNull("StreamRedisRepositorySecurityDecorator.StreamRedisRepository");
				return _streamRedisRepository;
			}
		}

		private UserConnection _userConnection;
		protected UserConnection UserConnection {
			get {
				HttpContext httpContext = _httpContextAccessor.GetInstance();
				httpContext.CheckArgumentNull("StreamRedisRepositorySecurityDecorator.UserConnection httpContext");
				if (_userConnection == null) {
					_userConnection = (UserConnection)httpContext.Session["UserConnection"];
				}
				_userConnection.CheckArgumentNull("StreamRedisRepositorySecurityDecorator.UserConnection");
				return _userConnection;
			}
		}

		#endregion

		#region Constructors: Public

		public StreamRedisRepositorySecurityDecorator(IHttpContextAccessor httpContextAccessor) {
			httpContextAccessor.CheckArgumentNull("StreamRedisRepositorySecurityDecorator.Constructor argument");
			_httpContextAccessor = httpContextAccessor;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Decorates find request for Find method.
		/// </summary>
		/// <param name="id">Entity id.</param>
		/// <returns>Entity.</returns>
		public StorableStreamEntity Find(Guid id) {
			var decoratedId = id.Xor(UserConnection.CurrentUser.Id);
			return StreamRedisRepository.Find(decoratedId);
		}

		/// <summary>
		/// Decorates create request for Create method.
		/// Returns non decorated id.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <returns>Non decorated id.</returns>
		public Guid Create(StorableStreamEntity entity) {
			entity.CheckArgumentNull("StreamRedisRepositorySecurityDecorator.Create entity");
			UserConnection.CurrentUser.CheckArgumentNull("StreamRedisRepositorySecurityDecorator.Create UserConnection.CurrentUser");
			var entityId = entity.Id;
			var decoratedId = entityId.Xor(UserConnection.CurrentUser.Id);
			entity.Id = decoratedId;
			StreamRedisRepository.Create(entity);
			return entityId;
		}

		/// <summary>
		/// Decorates remove request for Remove method.
		/// </summary>
		/// <param name="id">Entity id.</param>
		/// <returns>Removal result.</returns>
		public void Remove(Guid id) {
			var decoratedId = id.Xor(UserConnection.CurrentUser.Id);
			StreamRedisRepository.Remove(decoratedId);
		}

		public IEnumerable<StorableStreamEntity> Where(Func<StorableStreamEntity, bool> predicaticate) {
			throw new NotImplementedException();
		}

		public IEnumerable<StorableStreamEntity> GetAll() {
			throw new NotImplementedException();
		}

		#endregion

	}

	#endregion
}
