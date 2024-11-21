namespace BPMSoft.Configuration.ForecastV2
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastRowRepository

	/// <summary>
	/// Provides methods to get information from forecast row.
	/// </summary>
	public interface IForecastRowRepository
	{
		/// <summary>
		/// The user connection.
		/// </summary>
		/// <returns>Row identifier.</returns>
		UserConnection UserConnection { get; set; }

		/// <summary>
		/// Creates row and return identifier.
		/// </summary>
		/// <returns>Row identifier.</returns>
		Guid Create();

		/// <summary>
		/// Get the list of row ids.
		/// </summary>
		/// <param name="sheet">Forecast sheet info.</param>
		/// <param name="config">Filter configuration.</param>
		/// <returns></returns>
		IEnumerable<Guid> Get(Sheet sheet, FilterConfig config);

		/// <summary>
		/// Remove row by id..
		/// </summary>
		/// <param name="id">Row id.</param>
		/// <returns></returns>
		bool Remove(Guid id);
	}

	#endregion

	#region Interface: IRemoveEntityForecastRepository

	/// <summary>
	/// Provides method to delete {Entity}Forecast record
	/// </summary>
	public interface IRemoveEntityForecastRepository
	{
		/// <summary>
		/// Remove {Entity}Forecast record by 
		/// </summary>
		/// <param name="args">Config with ForecastRowId and ForecastId</param>
		/// <returns>true if entity(s) has been successfully deleted, false otherwise</returns>
		bool Remove(RemoveEntityForecastParams args);
	}

	#endregion

	#region Class: RemoveEntityForecastParams

	/// <summary>
	/// IRemoveEntityForecastRepository.Remove method parameters
	/// </summary>
	public class RemoveEntityForecastParams
	{

		#region Properties: Public

		/// <summary>
		/// Forecast row to be removed
		/// </summary>
		public Guid ForecastRowId { get; set; }

		/// <summary>
		/// Forecast that has forecast row to be removed
		/// </summary>
		public Guid ForecastId { get; set; }
		
		#endregion

	}

	#endregion

	#region Class: ForecastRowRepository
	[DefaultBinding(typeof(IRemoveEntityForecastRepository), Name = "Default")]
	[DefaultBinding(typeof(IForecastRowRepository))]
	public class ForecastRowRepository : IForecastRowRepository, IRemoveEntityForecastRepository
	{
		#region Properties: Private

		private static readonly ILog logger = LogManager.GetLogger<ForecastRowRepository>();
		private Sheet _forecastSheet;

		#endregion

		#region Properties: Public

		private UserConnection _userConnection;

		///<inheritdoc />
		public UserConnection UserConnection {
			get => _userConnection;
			set {
				value.CheckArgumentNull(nameof(UserConnection));
				_userConnection = value;
			}
		}

		#endregion

		#region Properties: Protected

		protected Sheet ForecastSheet {
			get { return _forecastSheet; }
			set {
				value.CheckArgumentNull(nameof(ForecastSheet));
				_forecastSheet = value;
			}
		}

		private IForecastSheetRepository _sheetRepository;

		/// <summary>Gets the forecast sheet repository.</summary>
		/// <value>The forecast sheet repository.</value>
		protected IForecastSheetRepository SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>(new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		private EntitySchemaQuery GetEsq(string schemaName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			return esq;
		}

		private string GetSchemaName(Guid uId) {
			return UserConnection.EntitySchemaManager.FindInstanceByUId(uId).Name;
		}

		private void AddGetMethodFilters(Guid sheetId, FilterConfig config, EntitySchemaQuery esq,
			string entitySchemaName) {
			esq.Filters.LogicalOperation = LogicalOperationStrict.And;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, entitySchemaName,
				config.RecordIds.Cast<object>()));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Sheet", sheetId));
			esq.Filters.Add(esq.CreateIsNullFilter("Period"));
			esq.Filters.Add(esq.CreateIsNullFilter("ForecastColumn"));
		}

		private string GetReferenceColumnName(EntitySchemaQuery esq, string entitySchemaName) {
			var refColumn = ForecastSheet.GetEntityReferenceColumn(UserConnection);
			if (refColumn == null) {
				string message = $"Reference column for schema {entitySchemaName} not found";
				logger.Error(message);
				throw new ItemNotFoundException(message);
			}
			return refColumn.Name;
		}

		private void AddColumns(EntitySchemaQuery esq, string refColumn) {
			esq.AddColumn(refColumn);
			esq.AddColumn("Row");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates row and return identifier.
		/// </summary>
		/// <returns>Row identifier.</returns>
		public Guid Create() {
			EntitySchema schema = UserConnection.EntitySchemaManager.FindInstanceByName("ForecastRow");
			Entity entity = schema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.Save();
			return entity.PrimaryColumnValue;
		}

		///<inheritdoc />
		public IEnumerable<Guid> Get(Sheet sheet, FilterConfig config) {
			sheet.CheckArgumentNull(nameof(sheet));
			config.CheckArgumentNull(nameof(config));
			config.RecordIds.CheckArgumentNullOrEmpty(nameof(config.RecordIds));
			ForecastSheet = sheet;
			string inCellSchemaName = GetSchemaName(ForecastSheet.ForecastEntityInCellUId);
			EntitySchemaQuery esq = GetEsq(inCellSchemaName);
			string entitySchemaName = GetSchemaName(sheet.ForecastEntityUId);
			string refColumnName = GetReferenceColumnName(esq, entitySchemaName);
			AddColumns(esq, refColumnName);
			AddGetMethodFilters(ForecastSheet.Id, config, esq, refColumnName);
			var rowsId = new List<Guid>();
			esq.GetEntityCollection(UserConnection).ForEach(item =>
				rowsId.Add(item.GetTypedColumnValue<Guid>("RowId"))
			);
			return rowsId;
		}

		///<inheritdoc />
		[Obsolete("7.17 | Method is deprecated. Use Remove(RemoveEntityForecastParams args)")]
		public bool Remove(Guid id) {
			return false;
		}

		///<inheritdoc />
		public bool Remove(RemoveEntityForecastParams args) {
			args.CheckArgumentNull(nameof(args));
			args.ForecastId.CheckArgumentNull(nameof(args.ForecastId));
			args.ForecastRowId.CheckArgumentNull(nameof(args.ForecastRowId));
			EntitySchemaQuery rowEsq = GetEsq("ForecastRow");
			var deletedOnColumn = "DeletedOn";
			rowEsq.AddColumn(deletedOnColumn);
			var row = rowEsq.GetEntity(UserConnection, args.ForecastRowId);
			if (row == null) {
				return false;
			}
			var sheet = SheetRepository.GetSheet(args.ForecastId);
			string inCellSchemaName = GetSchemaName(sheet.ForecastEntityInCellUId);
			EntitySchemaQuery esq = GetEsq(inCellSchemaName);
			var filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Row", args.ForecastRowId);
			esq.Filters.Add(filter);
			var entityCollection = esq.GetEntityCollection(UserConnection);
			bool res = true;
			using (DBExecutor dBExecutor = UserConnection.EnsureDBConnection()) {
				dBExecutor.StartTransaction();
				try {
					for (int i = entityCollection.Count; i > 0; i--) {
						res &= entityCollection[i - 1].Delete();
					}
					if (res) {
						row.SetColumnValue(deletedOnColumn, DateTime.UtcNow);
						row.Save();
					}
					dBExecutor.CommitTransaction();
					return res;
				}
				catch {
					dBExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		#endregion

	}

	#endregion

}

