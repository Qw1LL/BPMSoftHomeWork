namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using System.Threading;
	using System.Threading.Tasks;
	using BPMSoft.Core.Factories;

	#region  Class: BaseActualizerAge

	/// <summary>
	/// Abstract class for implements actualize entity item age.
	/// </summary>
	public abstract class BaseActualizerAge
	{

		#region Class: Private

		private class AgeActualizerWorker
		{

			#region Properties: Private

			/// <summary>
			/// UserConnection.
			/// </summary>
			/// <returns><see cref="UserConnection"/>.</returns>
			private UserConnection UserConnection
			{
				get; set;
			}

			/// <summary>
			/// Entity name.
			/// </summary>
			/// <returns><see cref="string"/>entity name.</returns>
			private string EntityName
			{
				get; set;
			}

			/// <summary>
			/// Entity column name.
			/// </summary>
			/// <returns><see cref="string"/>entity column name.</returns>
			private string UpdateColumnName
			{
				get; set;
			}

			#endregion

			#region Constructors: Public

			public AgeActualizerWorker(UserConnection userConnection, string EntityName, string UpdateColumnName) {
				UserConnection = userConnection;
				this.EntityName = EntityName;
				this.UpdateColumnName = UpdateColumnName;
			}

			#endregion

			#region Methods: Private

			/// <summary>
			/// Executes update query.
			/// </summary>
			/// <param name="dbExecutor">Database executor.</param>
			/// <param name="actualizeAgeItems"><see cref="ActualizeAgeItem"/>ActualizeAgeItem list.</param>
			private void ExecuteUpdateTable(DBExecutor dbExecutor, IEnumerable<ActualizeAgeItem> actualizeAgeItems) {
				foreach (ActualizeAgeItem ageItem in actualizeAgeItems) {
					Update updateAgeItemQuery =
						new Update(UserConnection, EntityName)
							.Set(UpdateColumnName, Column.Parameter(ageItem.CalculatedAge))
						.Where("Id").IsEqual(Column.Parameter(ageItem.Id)) as Update;
					updateAgeItemQuery.Execute();
				}
			}

			#endregion

			#region Methods: Public

			/// <summary>
			/// Actualizes age in input batch of object records.
			/// </summary>
			/// <param name="actualizeAgeItems">ActualizeAgeItem list.</param>
			public void ActualizeAgeFieldBatch(IEnumerable<ActualizeAgeItem> actualizeAgeItems) {
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					dbExecutor.StartTransaction();
					ExecuteUpdateTable(dbExecutor, actualizeAgeItems);
					dbExecutor.CommitTransaction();
				}
			}

			#endregion

		}

		#endregion

		#region Class: Public 

		#region  Class: ActualizeAgeItem

		/// <summary>
		/// Class ActualizeAgeItem.
		/// </summary>
		public class ActualizeAgeItem
		{

			#region Constructors: Public

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="Id"><see cref="Guid"/>Entity unique identifier.</param>
			/// <param name="CalculatedAge"><see cref="int"/>Calculated field value.</param>
			/// <param name="CurrentAge"><see cref="int"/>Current age field value.</param>
			/// <param name="ItemDate"><see cref="DateTime"/>Date field for calculate age.</param>
			/// <returns><see cref="Id"/>.</returns>
			public ActualizeAgeItem(Guid Id, int CalculatedAge, int CurrentAge, DateTime ItemDate) {
				this.Id = Id;
				this.CalculatedAge = CalculatedAge;
				this.CurrentAge = CurrentAge;
				this.ItemDate = ItemDate;
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// Entity unique identifier.
			/// </summary>
			/// <returns><see cref="Id"/>.</returns>
			public Guid Id
			{
				get; private set;
			}

			/// <summary>
			/// Calculated field value
			/// </summary>
			/// <returns><see cref="int"/>.</returns>
			public int CalculatedAge
			{
				get; private set;
			}

			/// <summary>
			/// Current age field value
			/// </summary>
			/// <returns><see cref="int"/>.</returns>
			public int CurrentAge
			{
				get; private set;
			}

			/// <summary>
			/// Date field for calculate age
			/// </summary>
			/// <returns><see cref="DateTime"/>.</returns>
			public DateTime ItemDate
			{
				get; private set;
			}

			/// <summary>
			/// Check if calculated age field differ from value in DB
			/// </summary>
			/// <returns><see cref="bool"/>.</returns>
			public bool NeedUpdate => !CalculatedAge.Equals(CurrentAge);

			#endregion

		}

		#endregion

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// <param name="UserConnection">UserConnection instance.</param>
		/// </summary>
		public BaseActualizerAge(UserConnection UserConnection) {
			this.UserConnection = UserConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// UserConnection
		/// </summary>
		/// <returns><see cref="UserConnection"/>.</returns>
		private UserConnection UserConnection
		{
			get; set;
		}

		private List<IEnumerable<ActualizeAgeItem>> Parts
		{
			get; set;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		///	Return Entity Name.
		/// </summary>
		/// <returns><see cref="string"/>if not empty - value.</returns>
		protected abstract string EntityName
		{
			get;
		}

		/// <summary>
		///	Return column name for Update.
		/// </summary>
		/// <returns><see cref="string"/>if not empty - value </returns>
		protected abstract string UpdateEntityColumnName
		{
			get;
		}

		/// <summary>
		///	Return entity date column for update.
		/// </summary>
		protected abstract string EntityDateColumnName
		{
			get;
		}

		/// <summary>
		/// Count item in chunk.
		/// </summary>
		/// <returns><see cref="int"/>.</returns>
		protected virtual int ChunkSize { get; set; } = 1000;

		/// <summary>
		/// Max Degree Of Parallelism.
		/// </summary>
		/// <returns><see cref="int"/>.</returns>
		protected virtual int MaxDegreeOfParallelism { get; set; } = 10;

		/// <summary>
		/// Chunk processing delay.
		/// </summary>
		/// <returns><see cref="int"/>.</returns>
		protected virtual int ChunkProcessingDelay { get; set; } = 100;

		/// <summary>
		/// Entity name for actualize age column.
		/// </summary>
		/// <returns><see cref="string"/>entity name.</returns>
		private EntitySchema _entitySchema;
		private EntitySchema EntitySchema
		{
			get
			{
				if (_entitySchema == null) {
					_entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(EntityName);
				}
				return _entitySchema;

			}
		}

		/// <summary>
		/// Entity age column name.
		/// </summary>
		/// <returns><see cref="string"/>entity column name.</returns>
		private EntitySchemaColumn _updateEntityColumn;
		private EntitySchemaColumn UpdateEntityColumn
		{
			get
			{
				if (_updateEntityColumn == null) {
					_updateEntityColumn = EntitySchema.Columns.FindByName(UpdateEntityColumnName);
				}
				return _updateEntityColumn;
			}
		}

		/// <summary>
		/// Entity date column name.
		/// </summary>
		/// <returns><see cref="string"/>entity date name.</returns>
		private EntitySchemaColumn _entityDateColumn;
		protected EntitySchemaColumn EntityDateColumn
		{
			get
			{
				if (_entityDateColumn == null) {
					_entityDateColumn = EntitySchema.Columns.FindByName(EntityDateColumnName);
				}
				return _entityDateColumn;
			}
		}

		/// <summary>
		/// Class instance CalculateAgeHelper
		/// </summary>
		/// <returns><see cref="CalculateAgeHelper"/>.</returns>
		private CalculateAgeHelper _calculateAgeHelper;
		protected CalculateAgeHelper CalculateAgeHelper
		{
			get
			{
				if (_calculateAgeHelper == null) {
					_calculateAgeHelper = ClassFactory.Get<CalculateAgeHelper>();
				}
				return _calculateAgeHelper;
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks if date is not equals to MinValue
		/// </summary>
		protected virtual bool IsDateNotMinValue(DateTime date) {
			return !date.Equals(DateTime.MinValue);
		}

		protected virtual bool IsStartDateLessOrEqualThanEndDate(DateTime startDate, DateTime endDate) {
			return startDate.Date <= endDate.Date;
		}

		/// <summary>
		/// Checks if period is valid
		/// </summary>
		protected virtual bool IsPeriodValid(DateTime startDate, DateTime endDate) {
			return IsDateNotMinValue(startDate)
				&& IsDateNotMinValue(endDate)
				&& IsStartDateLessOrEqualThanEndDate(startDate, endDate);
		}

		/// <summary>
		///	Set filters for entity schema query.
		/// </summary>
		/// <returns><see cref="EntitySchemaQuery"/>.</returns>
		protected virtual void SetFilters(EntitySchemaQuery esq) {
			esq.Filters.Add(esq.CreateIsNotNullFilter(EntityDateColumnName));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Greater, EntityDateColumnName, DateTime.MinValue));
		}

		/// <summary>
		///	Set filters for select query.
		/// </summary>
		protected virtual void SetFiltersByDate(EntitySchemaQuery esq, DateTime startDate, DateTime endDate) {
			var dateFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			for (var date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1)) {
				dateFilterGroup.Add(new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
					esq.CreateFilter(FilterComparisonType.Equal, EntityDateColumn.Name, EntitySchemaQueryMacrosType.Month, date.Month),
					esq.CreateFilter(FilterComparisonType.Equal, EntityDateColumn.Name, EntitySchemaQueryMacrosType.DayOfMonth, date.Day)
				});
			}
			esq.Filters.Add(dateFilterGroup);
		}

		/// <summary>
		/// Create entity schema query instance.
		/// </summary>
		/// <returns><see cref="EntitySchemaQuery"/>.</returns>
		protected virtual EntitySchemaQuery GetActualizeEntityColectionQuery() {
			var esq = new EntitySchemaQuery(EntitySchema) {
				UseAdminRights = false,
				UseLocalization = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn(EntityDateColumn.Name);
			esq.AddColumn(UpdateEntityColumn.Name);
			return esq;
		}

		/// <summary>
		/// Get list type of ActualizeAgeItems and calculate age field
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>Entity schema query</param>
		/// <returns><list of <see cref="ActualizeAgeItem"/>.</returns>
		protected virtual List<ActualizeAgeItem> GetItemForActualize(EntitySchemaQuery esq) {
			var resultItems = new List<ActualizeAgeItem>();
			Select selectAgeItems = esq.GetSelectQuery(UserConnection);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = selectAgeItems.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var itemId = dr.GetColumnValue<Guid>("Id");
						var dateItem = dr.GetColumnValue<DateTime>(EntityDateColumn.Name);
						var age = CalculateAgeHelper.GetFullAgeYears(dateItem);
						var currentAge = dr.GetColumnValue<int>(UpdateEntityColumn.Name);
						resultItems.Add(new ActualizeAgeItem(itemId, age, currentAge, dateItem));
					}
				}
			}
			return resultItems;
		}

		/// <summary>
		/// Get filters records by boolean parameter NeedUpdate == true.
		/// </summary>
		/// <param name="records"><see cref="EntitySchemaQuery"/>Entity schema query.</param>
		/// <returns><list of <see cref="ActualizeAgeItem"/>.</returns>
		protected IEnumerable<ActualizeAgeItem> GetRecordsThatNeedUpdate(List<ActualizeAgeItem> records) {
			return records.FindAll(e => e.NeedUpdate);
		}

		/// <summary>
		/// Split input collection on chunks and run parallel tasks for update.
		/// </summary>
		/// <param name="records"><IEnumerable collection of <see cref="ActualizeAgeItem"/>Entity schema query.</param>
		protected virtual void ActualizeEntity(IEnumerable<ActualizeAgeItem> records) {
			Parts = new List<IEnumerable<ActualizeAgeItem>>(records.SplitOnChunks(ChunkSize));
			Parallel.For(0, Parts.Count, new ParallelOptions { MaxDegreeOfParallelism = MaxDegreeOfParallelism },
				i => {
					Thread.Sleep(ChunkProcessingDelay);
					var worker = new AgeActualizerWorker(UserConnection, EntitySchema.Name, UpdateEntityColumn.Name);
					worker.ActualizeAgeFieldBatch(Parts[i]);
				});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get entity schema query.
		/// Set filters and load collection 
		/// Get records depending on the need update parameter
		/// Actualize entities
		/// </summary>
		public virtual void RunActualize() {
			EntitySchemaQuery esq = GetActualizeEntityColectionQuery();
			SetFilters(esq);
			List<ActualizeAgeItem> records = GetItemForActualize(esq);
			IEnumerable<ActualizeAgeItem> filtersRecords = GetRecordsThatNeedUpdate(records);
			ActualizeEntity(filtersRecords);
		}

		/// <summary>
		/// Actualize entities filtered by period.
		/// </summary>
		public virtual void RunActualizeByPeriod(DateTime startDate, DateTime endDate) {
			if (!IsPeriodValid(startDate, endDate)) {
				var message = new LocalizableString(this.UserConnection.Workspace.ResourceStorage,
					"BaseActualizerAge", "LocalizableStrings.InputPeriodInvalidCaption.Value");
				throw new Exception(message);
			}
			EntitySchemaQuery esq = GetActualizeEntityColectionQuery();
			SetFiltersByDate(esq, startDate, endDate);
			List<ActualizeAgeItem> records = GetItemForActualize(esq);
			IEnumerable<ActualizeAgeItem> filtersRecords = GetRecordsThatNeedUpdate(records);
			ActualizeEntity(filtersRecords);
		}

		#endregion

	}

	#endregion

}
