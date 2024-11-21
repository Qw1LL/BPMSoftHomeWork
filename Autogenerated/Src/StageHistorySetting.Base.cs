namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.Entities;
	using BPMSoft.Common;

	#region Class: StageHistorySetting

	[Serializable]
	public partial class StageHistorySetting
	{

		#region Fields: Private

		private readonly string _defStageColumnName = "Stage";
		private readonly string _defStageIsFinalColumnName = "End";
		private readonly string _defStageIsSuccessfulColumnName = "Successful";
		private readonly string _defStageOrderColumnName = "Number";
		private readonly string _defStageHistoryStartDateColumnName = "StartDate";
		private readonly string _defStageHistoryDueDateColumnName = "DueDate";
		private readonly string _defStageHistoryHistoricalColumnName = "Historical";
		private readonly string _defStageHistoryStageColumnName = "Stage";
		[NonSerialized]
		private EntitySchema _entitySchema;
		[NonSerialized]
		private EntitySchema _stageSchema;
		[NonSerialized]
		private EntitySchema _stageHistorySchema;
		[NonSerialized]
		private UserConnection _userConnection;

		#endregion

		#region Constructor: Public

		public StageHistorySetting(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected EntitySchema EntitySchema => _entitySchema ??
			(_entitySchema = UserConnection.EntitySchemaManager.FindInstanceByUId(EntitySchemaUId));

		protected EntitySchema StageSchema => _stageSchema ??
			(_stageSchema = UserConnection.EntitySchemaManager.FindInstanceByUId(StageSchemaUId));

		protected EntitySchema StageHistorySchema => _stageHistorySchema ??
			(_stageHistorySchema = UserConnection.EntitySchemaManager.FindInstanceByUId(StageHistorySchemaUId));

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get {
				return _userConnection;
			}
			set {
				value.CheckArgumentNull("userConnection");
				_userConnection = value;
			}
		}

		public Guid Id { get; set; }

		public Guid EntitySchemaUId { get; set; }

		public Guid StageSchemaUId { get; set; }

		public Guid StageHistorySchemaUId { get; set; }

		public Guid StageColUId { get; set; }

		public Guid StageIsFinalColUId { get; set; }

		public Guid StageIsSuccessfulColUId { get; set; }

		public Guid StageOrderColUId { get; set; }

		public Guid StageHistoryStartDateColUId { get; set; }

		public Guid StageHistoryDueDateColUId { get; set; }

		public Guid StageHistoryHistoricalColUId { get; set; }

		public Guid StageHistoryMainEntityColUId { get; set; }

		public Guid StageHistoryStageColUId { get; set; }

		public bool IsActive { get; set; }

		public string EntitySchemaName => EntitySchema?.Name;

		public string StageSchemaName => StageSchema?.Name;

		public string StageHistorySchemaName => StageHistorySchema?.Name;

		public string StageColumnName => EntitySchema?.Columns.FindByUId(StageColUId).Name ?? _defStageColumnName;

		public string StageIsFinalColumnName => StageSchema?.Columns.FindByUId(StageIsFinalColUId).Name ??
			_defStageIsFinalColumnName;

		public string StageIsSuccessfulColumnName => StageSchema?.Columns.FindByUId(StageIsSuccessfulColUId).Name ??
			_defStageIsSuccessfulColumnName;

		public string StageOrderColumnName => StageSchema?.Columns.FindByUId(StageOrderColUId).Name ??
			_defStageOrderColumnName;

		public string StageHistoryStartDateColumnName =>
			StageHistorySchema?.Columns.FindByUId(StageHistoryStartDateColUId).Name ??
			_defStageHistoryStartDateColumnName;

		public string StageHistoryDueDateColumnName =>
			StageHistorySchema?.Columns.FindByUId(StageHistoryDueDateColUId).Name ?? _defStageHistoryDueDateColumnName;

		public string StageHistoryHistoricalColumnName =>
			StageHistorySchema?.Columns.FindByUId(StageHistoryHistoricalColUId).Name ??
			_defStageHistoryHistoricalColumnName;

		public string StageHistoryMainEntityColumnName =>
			StageHistorySchema?.Columns.FindByUId(StageHistoryMainEntityColUId).Name;

		public string StageHistoryStageColumnName =>
			StageHistorySchema?.Columns.FindByUId(StageHistoryStageColUId).Name ?? _defStageHistoryStageColumnName;

		#endregion

		/// <summary>
		/// Fills settings from entity.
		/// </summary>
		/// <param name="source">Entity.</param>
		public virtual void FillFromEntity(Entity source) {
			Id = source.PrimaryColumnValue;
			IsActive = source.GetTypedColumnValue<bool>("Active");
			EntitySchemaUId = source.GetTypedColumnValue<Guid>("EntitySchemaUId");
			StageSchemaUId = source.GetTypedColumnValue<Guid>("StageSchemaUId");
			StageHistorySchemaUId = source.GetTypedColumnValue<Guid>("StageHistorySchemaUId");


			StageColUId = source.GetTypedColumnValue<Guid>("StageColUId");
			StageIsFinalColUId = source.GetTypedColumnValue<Guid>("StageIsFinalColUId");
			StageIsSuccessfulColUId = source.GetTypedColumnValue<Guid>("StageIsSuccessfulColUId");
			StageOrderColUId = source.GetTypedColumnValue<Guid>("StageOrderColUId");

			StageHistoryStartDateColUId = source.GetTypedColumnValue<Guid>("StageHistoryStartDateColUId");
			StageHistoryDueDateColUId = source.GetTypedColumnValue<Guid>("StageHistoryDueDateColUId");
			StageHistoryHistoricalColUId = source.GetTypedColumnValue<Guid>("StageHistoryHistoricalColUId");
			StageHistoryMainEntityColUId = source.GetTypedColumnValue<Guid>("StageHistoryMainEntityColUId");
			StageHistoryStageColUId = source.GetTypedColumnValue<Guid>("StageHistoryStageColUId");

		}

		/// <summary>
		/// Fills entity with settings values.
		/// </summary>
		/// <param name="entity">Entity.</param>
		public virtual void FillEntity(Entity entity) {
			entity.SetColumnValue("Id", Id);
			entity.SetColumnValue("Active", IsActive);
			entity.SetColumnValue("EntitySchemaUId", EntitySchemaUId);
			entity.SetColumnValue("StageSchemaUId", StageSchemaUId);
			entity.SetColumnValue("StageHistorySchemaUId", StageHistorySchemaUId);


			entity.SetColumnValue("StageColUId", StageColUId);
			entity.SetColumnValue("StageIsFinalColUId", StageIsFinalColUId);
			entity.SetColumnValue("StageIsSuccessfulColUId", StageIsSuccessfulColUId);
			entity.SetColumnValue("StageOrderColUId", StageOrderColUId);

			entity.SetColumnValue("StageHistoryStartDateColUId", StageHistoryStartDateColUId);
			entity.SetColumnValue("StageHistoryDueDateColUId", StageHistoryDueDateColUId);
			entity.SetColumnValue("StageHistoryHistoricalColUId", StageHistoryHistoricalColUId);
			entity.SetColumnValue("StageHistoryMainEntityColUId", StageHistoryMainEntityColUId);
			entity.SetColumnValue("StageHistoryStageColUId", StageHistoryStageColUId);
		}
	}

	#endregion
}
