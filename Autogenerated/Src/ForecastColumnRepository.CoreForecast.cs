namespace BPMSoft.Configuration.ForecastV2 {
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;

	#region Interface: IForecastColumnRepository

	/// <summary>
	/// Provides methods for receiving column data of forecast.
	/// </summary>
	public interface IForecastColumnRepository
	{
		/// <summary>
		/// Gets the columns of forecast.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <returns>Collection of <see cref="ForecastColumn"/></returns>
		IEnumerable<ForecastColumn> GetColumns(Guid forecastId);

		/// <summary>
		/// Updates forecast column.
		/// </summary>
		/// <param name="columns">Forecast columns.</param>
		void UpdateColumns(IEnumerable<ForecastColumn> columns);

		/// <summary>
		/// Deletes column.
		/// </summary>
		/// <param name="sheet">The forecast sheet <see cref="Sheet"/>.</param>
		/// <param name="columnId">The column identifier.</param>
		/// <returns>Sign of delete status.</returns>
		bool Delete(Sheet sheet, Guid columnId);

	}

	/// <summary>
	/// Forecast column.
	/// </summary>
	public class ForecastColumn
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>
		/// Column order in the forecast.
		/// </value>
		public int Position { get; set; }

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		/// <value>
		/// Column settings in the forecast.
		/// </value>
		public string Settings { get; set; }

		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>
		/// Unique text code of column indicator.
		/// </value>
		public string Code { get; set; }

		/// <summary>
		/// Gets or sets the type identifier.
		/// </summary>
		/// <value>
		/// Column type identifier.
		/// </value>
		public Guid TypeId { get; set; }

		/// <summary>
		/// Gets or sets sign of hiding column.
		/// </summary>
		/// <value>
		/// Sign of hiding.
		/// </value>
		public bool IsHide { get; set; }

		/// <summary>
		/// Deserializes Settings json to get ColumnSetting object.
		/// </summary>
		/// <returns></returns>
		public T GetColumnSettings<T>() where T : BaseColumnSetting, new() {
			return Json.Deserialize<T>(Settings ?? "{}") ?? new T();
		}

	}

	#endregion

	#region Class: ForecastColumnRepository

	/// <summary>
	/// Provides methods for receiving column data of forecast.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ForecastV2.IForecastColumnRepository" />
	[DefaultBinding(typeof(IForecastColumnRepository))]
	public class ForecastColumnRepository : IForecastColumnRepository
	{

		#region Constants: Private

		private const string ForecastColumn = "ForecastColumn";
		private const string ForecastIndicator = "ForecastIndicator";
		private const string Id = "Id";
		private const string Name = "Name";
		private const string Title = "Title";
		private const string Settings = "Settings";
		private const string Position = "Position";
		private const string Code = "Code";
		private const string Type = "Type";

		#endregion

		#region Constructors: Public

		public ForecastColumnRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		protected bool ForecastUIV2Enabled => UserConnection.GetIsFeatureEnabled("ForecastUIV2");

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		private IForecastCellRepository _cellRepository;
		/// <summary>Gets the forecast cell repository.</summary>
		/// <value>The forecast cell repository.</value>
		protected IForecastCellRepository CellRepository =>
			_cellRepository ?? (_cellRepository = ClassFactory.Get<IForecastCellRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		private IEnumerable<ForecastColumn> ObsoleteInnerGetColumns(Guid forecastId) {
			var result = new List<ForecastColumn>();
			var path = $"[{ForecastIndicator}:Id:Indicator].";
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, ForecastColumn);
			var idColumnName = esq.AddColumn(path + Id).Name;
			var nameColumnName = esq.AddColumn(path + Name).Name;
			var codeColumnName = esq.AddColumn(path + Code).Name;
			var settingColumnName = esq.AddColumn(Settings).Name;
			var positionColumn = esq.AddColumn(Position);
			positionColumn.OrderByAsc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Sheet", forecastId));
			var collection = esq.GetEntityCollection(UserConnection);
			foreach (var item in collection) {
				result.Add(new ForecastColumn {
					Id = item.GetTypedColumnValue<Guid>(idColumnName),
					Name = item.GetTypedColumnValue<string>(nameColumnName),
					Code = item.GetTypedColumnValue<string>(codeColumnName),
					Settings = item.GetTypedColumnValue<string>(settingColumnName),
					Position = item.GetTypedColumnValue<int>(positionColumn.Name)
				});
			}
			return result;
		}

		private IEnumerable<ForecastColumn> InnerGetColumns(Guid forecastId) {
			var result = new List<ForecastColumn>();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, ForecastColumn);
			var path = $"[{ForecastIndicator}:Id:Indicator].";
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn(Title);
			esq.AddColumn(Settings);
			esq.AddColumn(Type);
			esq.AddColumn("IsHide");
			var idColumnName = esq.AddColumn(path + Id).Name;
			var nameColumnName = esq.AddColumn(path + Name).Name;
			var codeColumnName = esq.AddColumn(path + Code).Name;
			var positionColumn = esq.AddColumn(Position);
			positionColumn.OrderByAsc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Sheet", forecastId));
			var collection = esq.GetEntityCollection(UserConnection);
			foreach (var item in collection) {
				var name = item.GetTypedColumnValue<string>(Title);
				var id = item.GetTypedColumnValue<Guid>(Id);
				var code = id.ToString();
				if (string.IsNullOrEmpty(name)) {
					id = item.GetTypedColumnValue<Guid>(idColumnName);
					name = item.GetTypedColumnValue<string>(nameColumnName);
					code = item.GetTypedColumnValue<string>(codeColumnName);
				}
				result.Add(new ForecastColumn {
					Id = id,
					Name = name,
					Code = code,
					Settings = item.GetTypedColumnValue<string>(Settings),
					Position = item.GetTypedColumnValue<int>(Position),
					TypeId = item.GetTypedColumnValue<Guid>($"{Type}Id"),
					IsHide = item.GetTypedColumnValue<bool>("IsHide")
				});
			}
			return result;
		}

		private void UpdateColumn(ForecastColumn column) {
			var update = new Update(UserConnection, "ForecastColumn")
				.Set("Position", Column.Parameter(column.Position))
				.Where("Id").IsEqual(Column.Parameter(new Guid(column.Code))) as Update;
			update.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the columns of forecast.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <returns>
		/// Collection of <see cref="ForecastColumn" />
		/// </returns>
		public IEnumerable<ForecastColumn> GetColumns(Guid forecastId) {
			forecastId.CheckArgumentEmpty(nameof(forecastId));
			if (ForecastUIV2Enabled) {
				return InnerGetColumns(forecastId);
			}
			return ObsoleteInnerGetColumns(forecastId);
		}

		///<inheritdoc />
		public void UpdateColumns(IEnumerable<ForecastColumn> columns) {
			foreach (var column in columns) {
				UpdateColumn(column);
			}
		}

		///<inheritdoc />
		public bool Delete(Sheet sheet, Guid columnId) {
			var columnSchema = UserConnection.EntitySchemaManager.GetInstanceByName("ForecastColumn");
			var column = columnSchema.CreateEntity(UserConnection);
			var isSuccess = false;
			if (column.FetchFromDB(columnId)) {
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					dbExecutor.StartTransaction();
					try {
						CellRepository.DeleteCells(sheet, new List<Period>(), new[] { new ForecastColumn() { Id = columnId } });
						isSuccess = column.Delete(columnId);
						dbExecutor.CommitTransaction();
					} catch (DbOperationException ex) {
						dbExecutor.RollbackTransaction();
						throw;
					}
				}

			}
			return isSuccess;
		}

		#endregion

	}

	#endregion

}

