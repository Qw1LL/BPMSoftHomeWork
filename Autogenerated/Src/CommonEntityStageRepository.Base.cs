namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Common;
	using Core.DB;
	using Core.Factories;
	using Core.Store;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: CommonStageData

	/// <summary>
	/// Stage data contract.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.StageData" />
	[Serializable]
	public class CommonStageData : StageData
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets a value indicating whether stage is closed with won.
		/// </summary>
		/// <value>
		///   <c>true</c> if stage is closed with won; otherwise, <c>false</c>.
		/// </value>
		public bool IsSuccessful {
			get; set;
		}

		/// <summary>
		/// Gets or sets the display value.
		/// </summary>
		/// <value>
		/// The display value.
		/// </value>
		public string DisplayValue {
			get; set;
		}

		#endregion
	}

	#endregion

	#region Class: CommonEntityStageRepository

	/// <summary>
	/// /// Common configurable repository for entity stage object.
	/// </summary>
	/// <seealso cref="CommonStageData" />
	[DefaultBinding(typeof(IEntityRepository<CommonStageData>))]
	public class CommonEntityStageRepository : EntityStageRepository<CommonStageData>
	{

		#region Constructors: Public

		public CommonEntityStageRepository(UserConnection userConnection, StageHistorySetting entitySchemaConfig)
				: base(userConnection, entitySchemaConfig) {
		}

		#endregion

		#region Methods: Private

		private bool HasSuccessfulColumn() {
			return SchemaInstance.Columns.FindByName(StageHistorySetting.StageIsSuccessfulColumnName) != null;
		}

		#endregion

		#region Methods: Protected

		protected override CommonStageData CreateObjectFromEntity(Entity stage) {
			CommonStageData data = base.CreateObjectFromEntity(stage);
			if (HasSuccessfulColumn()) {
				data.IsSuccessful = stage.GetTypedColumnValue<bool>(StageHistorySetting.StageIsSuccessfulColumnName);
			}
			return data;
		}

		protected override EntitySchemaQuery GetEntityCollectionEsq() {
			var esq = base.GetEntityCollectionEsq();
			if (HasSuccessfulColumn()) {
				esq.AddColumn(StageHistorySetting.StageIsSuccessfulColumnName);
			}
			return esq;
		}

		#endregion
	}

	#endregion

}
