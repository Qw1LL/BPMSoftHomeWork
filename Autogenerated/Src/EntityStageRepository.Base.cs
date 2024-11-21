namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: StageData

	/// <summary>
	/// Stage data contract.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityData" />
	[Serializable]
	public class StageData : EntityData
	{
		/// <summary>
		/// Gets or sets stage number.
		/// </summary>
		/// <value>
		/// The stage number.
		/// </value>
		public int Number { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether stage is end.
		/// </summary>
		/// <value>
		///   <c>true</c> if stage is end; otherwise, <c>false</c>.
		/// </value>
		public bool IsEnd { get; set; }
	}

	#endregion

	#region Class: EntityStageRepository

	/// <summary>
	/// The repository for entity stage data.
	/// </summary>
	/// <typeparam name="TStageData">The type of the stage data.</typeparam>
	/// <seealso cref="BPMSoft.Configuration.EntityRepository{TStageData}" />
	/// <seealso cref="BPMSoft.Configuration.IEntityStageRepository{TStageData}" />
	public class EntityStageRepository<TStageData> : CachedEntityRepository<TStageData>
		where TStageData : StageData, new()
	{

		private StageHistorySetting _stageHistorySetting;
		protected StageHistorySetting StageHistorySetting {
			get {
				if (_stageHistorySetting == null) {
					_stageHistorySetting = ClassFactory.Get<StageHistorySetting>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _stageHistorySetting;
			}
			set {
				_stageHistorySetting = value;
			}
		}

		#region Constructors: Public

		public EntityStageRepository(UserConnection userConnection, string entitySchemaName, string cacheGroupName = "")
				: base(userConnection, entitySchemaName, cacheGroupName) {
		}

		public EntityStageRepository(UserConnection userConnection, StageHistorySetting stageHistorySetting)
				: base(userConnection, stageHistorySetting.StageSchemaName, stageHistorySetting.StageSchemaName) {
			StageHistorySetting = stageHistorySetting;
		}

		#endregion

		#region Methods: Protected

		protected override EntitySchemaQuery GetEntityCollectionEsq() {
			var esq = base.GetEntityCollectionEsq();
			esq.AddColumn(StageHistorySetting.StageOrderColumnName).OrderByAsc();
			esq.AddColumn(StageHistorySetting.StageIsFinalColumnName);
			return esq;
		}

		protected override TStageData CreateObjectFromEntity(Entity stage) {
			var item = base.CreateObjectFromEntity(stage);
			item.Number = stage.GetTypedColumnValue<int>(StageHistorySetting.StageOrderColumnName);
			item.IsEnd = stage.GetTypedColumnValue<bool>(StageHistorySetting.StageIsFinalColumnName);
			return item;
		}

		#endregion

	}

	#endregion
}
