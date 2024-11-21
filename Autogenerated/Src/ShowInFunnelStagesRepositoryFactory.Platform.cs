namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Interface: IGetRepositoryFactory

	/// <summary>
	/// Provides methods of return instance of <see cref="IGetRepository{TEntityData}"/>>
	/// </summary>
	/// <typeparam name="TData">Data, inheritor of <see cref="EntityData"/></typeparam>
	public interface IGetRepositoryFactory<out TData> where TData : EntityData, new()
	{

		#region Methods: Public

		/// <summary>
		/// Returns instance of <see cref="IGetRepository{TEntityData}"/>
		/// </summary>
		/// <param name="stageHistorySetting"><see cref="StageHistorySetting"/></param>
		/// <returns>instance of <see cref="IGetRepository{TEntityData}"/></returns>
		IGetRepository<TData> GetRepository(StageHistorySetting stageHistorySetting);

		#endregion

	}

	#endregion

	#region Class : ShowInFunnelStagesRepositoryFactory 

	/// <summary>
	/// Provides method of return instance of <see cref="FullPipelineStageGetRepository"/>
	/// </summary>
	[DefaultBinding(typeof(IGetRepositoryFactory<CommonStageData>))]
	public class ShowInFunnelStagesRepositoryFactory : IGetRepositoryFactory<CommonStageData>
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion
		
		#region Constructors: Public

		public ShowInFunnelStagesRepositoryFactory(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion
		
		#region Methods: Public

		/// <summary>
		/// Returns proxy <see cref="CacheGetRepositoryProxy{TData}"/> of <see cref="FullPipelineStageGetRepository"/>
		/// </summary>
		/// <param name="stageHistorySetting"><see cref="StageHistorySetting"/></param>
		/// <returns>proxy <see cref="CacheGetRepositoryProxy{TData}"/> of <see cref="FullPipelineStageGetRepository"/></returns>
		public IGetRepository<CommonStageData> GetRepository(StageHistorySetting stageHistorySetting) {
			var repository = ClassFactory
				.Get<FullPipelineStageGetRepository>(
					new ConstructorArgument("userConnection", _userConnection),
					new ConstructorArgument("stageHistorySetting", stageHistorySetting));
			var cacheRepository = ClassFactory
				.Get<CacheGetRepositoryProxy<CommonStageData>>(
					new ConstructorArgument("userConnection", _userConnection),
					new ConstructorArgument("repository", repository),
					new ConstructorArgument("schemaName", stageHistorySetting.StageSchemaName));
			return cacheRepository;
		}

		#endregion

	}

	#endregion

}

