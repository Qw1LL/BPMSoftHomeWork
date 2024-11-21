namespace BPMSoft.Configuration.ForecastService
{
	using Core.Factories;
	using ForecastV2;
	using System;
	using System.Data;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Web.Common;
	using ForecastItemValue = ForecastHelper.ForecastItemValue;
	using ForecastItemResponse = ForecastHelper.ForecastItemResponse;
	using ForecastItemValueResponse = ForecastHelper.ForecastItemValueResponse;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ForecastService : BaseService
	{
		#region Fields: Private

		private UserConnection _userConnection;
		private ForecastHelper _forecastHelper;

		#endregion

		#region Properties: Public

		public ForecastHelper ForecastHelper {
			get {
				return _forecastHelper ?? (_forecastHelper = new ForecastHelper(UserConnection));
			}
		}

		private IForecastProvider _forecastProvider;
		public IForecastProvider ForecastProvider => 
			_forecastProvider ?? (_forecastProvider = ClassFactory.Get<IForecastProvider>());

		private IForecastColumnRepository _columnRepository;
		public IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastSheetRepository _forecastSheetRepository;
		public IForecastSheetRepository ForecastSheetRepository =>
			_forecastSheetRepository ?? (_forecastSheetRepository = ClassFactory.Get<IForecastSheetRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IEntityInForecastCellRepository _entityInForecastCell;
		public IEntityInForecastCellRepository EntityInForecastCell =>
			_entityInForecastCell ?? (_entityInForecastCell = ClassFactory.Get<IEntityInForecastCellRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IPeriodRepository _periodRepository;
		public IPeriodRepository PeriodRepository =>
			_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		private void ScheduleRecalculateFact(Guid forecastId) {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			Guid currentUserContactId = currentUser.ContactId;
			string schedulerJobName = "CalculateForecastFactJob";
			string schedulerJobGroupName = "CalculateForecastFactGroup";
			string jobProcessName = "CalcForecastFactPotentialProcess";
			Dictionary<string, object> forecastParameters = new Dictionary<string, object> {
				{"ForecastId", forecastId}
			};
			if (currentUserContactId != Guid.Empty) {
				forecastParameters.Add("CurrentUserContactId", currentUserContactId);
			}
			AppScheduler.RemoveJob(schedulerJobName, schedulerJobGroupName);
			AppScheduler.TriggerJob(schedulerJobName, schedulerJobGroupName,
				jobProcessName, UserConnection.Workspace.Name, currentUser.Name, forecastParameters);
		}

		private void RecalculateFact(Guid forecastId, List<Guid> periodIds) {
			IDictionary<string, object> parameters = new Dictionary<string, object> {
				{"ForecastId", forecastId},
				{"PeriodIds", periodIds}
			};
			var jobGroup = $"{typeof(ForecastCalculator).Name}_{forecastId}";
			AppScheduler.RemoveJob(typeof(ForecastCalculator).AssemblyQualifiedName, jobGroup);
			AppScheduler.TriggerJob<ForecastCalculator>(jobGroup, UserConnection.Workspace.Name,
				UserConnection.CurrentUser.Name, parameters);
		}

		private ForecastItemValue CreateEmptyValue(Guid indicatorId, string indicatorCode, Guid periodId) {
			return new ForecastItemValue() {
				Id = Guid.Empty,
				Value = 0,
				ForecastIndicatorId = indicatorId,
				ForecastIndicatorCode = indicatorCode,
				PeriodId = periodId
			};
		}

		private ForecastItemValue CreateValueFromCell(Cell cell, string indicatorCode) {
			return new ForecastItemValue {
				PeriodId = cell.PeriodId,
				Value = cell.Value,
				ForecastIndicatorId = cell.IndicatorId,
				ForecastIndicatorCode = indicatorCode
			};
		}

		private ForecastHelper.ForecastItem[] GetDataCollection(ForecastData data) {
			return data.Rows.Select(row => {
				var item = new ForecastHelper.ForecastItem {
					Name = row.Value,
					Id = row.Id,
					RowId = row.Cells.First().RowId, 
					CanEdit = true
				};
				List<ForecastItemValue> values = new List<ForecastItemValue>();
				foreach (var column in data.Columns) {
					var cell = row.Cells.FirstOrDefault(e => e.PeriodId == column.Period.Id 
						&& e.IndicatorId == column.Indicator.Id);
					ForecastItemValue currentCellValue = cell == null 
						? CreateEmptyValue(column.Indicator.Id, column.Indicator.Code, column.Period.Id)
						: CreateValueFromCell(cell, column.Indicator.Code);
					values.Add(currentCellValue);
				}
				item.ForecastItemValues = values.ToArray();
				return item;
			}).ToArray();
		}

		private ForecastHelper.ColumnCaption[] GetColumns(ForecastData data) {
			return data.Columns.Select(e => new ForecastHelper.ColumnCaption {
				ColumnName = e.Indicator.Code + e.Period.Id,
				IndicatorName = e.Indicator.Name,
				IndicatorCode = e.Indicator.Code,
				PeriodId = e.Period.Id,
				PeriodName = e.Period.Name
			}).ToArray();
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RunRecalculateFact(Guid recordId) {
			ScheduleRecalculateFact(recordId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse RecalculateFact(Guid forecastId, string[] periods) {
			var response = new ConfigurationServiceResponse();
			try {
				IEnumerable<Guid> periodIds = periods.Select(p => new Guid(p));
				RecalculateFact(forecastId, periodIds.ToList());
			}
			catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public ForecastItemResponse GetForecastData(Guid forecastId, string[] periods) {
			var response = new ForecastItemResponse();
			try {
				if (UserConnection.GetIsFeatureEnabled("ForecastV2")) {
					var data = ForecastProvider.GetData(forecastId, periods.Select(e => new Guid(e)));
					response.ColumnCaptions = GetColumns(data);
					response.Collection = GetDataCollection(data);
				} else {
					Guid forecastPeriodTypeId = ForecastHelper.GetForecastPeriodType(forecastId);
					response.ColumnCaptions = ForecastHelper.GetHeaderColumnCaptions(periods, forecastPeriodTypeId);
					response.Collection = ForecastHelper.GetForecastItemResultCollection(forecastId, 
						forecastPeriodTypeId, periods, null);
				}
				response.Success = true;
			} catch (Exception ex) {
				response.Success = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public ForecastItemResponse GetForecastNewRows(Guid forecastId, string[] periods, string[] rows) {
			var response = new ForecastItemResponse();
			try {
				Guid forecastPeriodTypeId = ForecastHelper.GetForecastPeriodType(forecastId);
				response.Collection = ForecastHelper.GetForecastItemResultCollection(forecastId, forecastPeriodTypeId, periods, rows);
				response.Success = true;
			} catch (Exception ex) {
				response.Success = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public ForecastItemValueResponse GetForecastValue(Guid forecastItemValueId) {
			var response = new ForecastItemValueResponse();
			ForecastItemValue forecastItemValue = null;
			try {
				Entity itemValue = ForecastHelper.GetForecastValueEntity(forecastItemValueId);
				Guid forecastItemId = (Guid)itemValue.GetColumnValue("ForecastItemId");
				bool canRead = ForecastHelper.CheckForecastItemRights(forecastItemId, SchemaRecordRightLevels.CanRead);
				if (canRead) {
					forecastItemValue = ForecastHelper.GetForecastItemValue(itemValue);
				}
				response.Success = true;
			} catch (Exception ex) {
				response.Success = false;
				response.Message = ex.Message;
			}
			response.ForecastItemValue = forecastItemValue;
			return response;

		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public ForecastItemValueResponse UpdateForecastValue(Guid forecastItemValueId, decimal value) {
			var response = new ForecastItemValueResponse();
			try {
				Entity itemValue = ForecastHelper.GetForecastValueEntity(forecastItemValueId);
				Guid forecastItemId = (Guid)itemValue.GetColumnValue("ForecastItemId");
				bool canEdit = ForecastHelper.CheckForecastItemRights(forecastItemId, SchemaRecordRightLevels.CanEdit);
				if (canEdit) {
					response.Success = ForecastHelper.UpdateForecastValue(forecastItemValueId, value);
				}
			} catch (Exception ex) {
				response.Success = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public ForecastItemValueResponse InsertForecastValue(Guid forecastIndicatorId, Guid forecastItemId, Guid periodId, decimal value) {
			var response = new ForecastItemValueResponse();
			try {
				bool canEdit = ForecastHelper.CheckForecastItemRights(forecastItemId, SchemaRecordRightLevels.CanEdit);
				if (canEdit) {
					Guid forecastItemValueId = ForecastHelper.InsertForecastValue(forecastIndicatorId, forecastItemId, periodId, value);
					response.Success = (forecastItemValueId != Guid.Empty);
					response.ForecastItemValueId = forecastItemValueId;
				}
			} catch (Exception ex) {
				response.Success = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public ForecastItemValueResponse SaveForecastCell(Guid forecastId, Guid recordId, Guid periodId, Guid indicatorId, decimal value) {
			var response = new ForecastItemValueResponse();
			try {
				var sheet = ForecastSheetRepository.GetSheet(forecastId);
				EntityInForecastCell.SaveCell(sheet, recordId, indicatorId, periodId, new ValueInfo { Value = value });
			} catch (Exception ex) {
				response.Success = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public ForecastItemValueResponse AddDimensionToForecast(Guid forecastId, Guid dimensionId, int level) {
			var response = new ForecastItemValueResponse();
			try {
				Guid forecastDimensionId = ForecastHelper.AddDimensionToForecast(forecastId, dimensionId, level);
				response.Success = (forecastDimensionId != Guid.Empty);
			} catch (Exception ex) {
				response.Success = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetCanDeleteForecastItems(Guid forecastId) {
			Select selectData = new Select(UserConnection)
				.Column("Id")
				.From("ForecastItem")
				.Where("ForecastId").IsEqual(Column.Parameter(forecastId)) as Select;
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectData.ExecuteReader(executor)) {
					while (reader.Read()) {
						Guid forecastItemId = (Guid)reader["Id"];
						if (!ForecastHelper.CheckForecastItemRights(forecastItemId, SchemaRecordRightLevels.CanDelete)) {
							return "ExistForecastItemsCanNotDeleteMessage";
						}
					}
				}
			}
			return string.Empty;
		}

		#endregion
	}

	#region Class: ForecastHelper

	public class ForecastHelper
	{
		#region Classes: Public

		[DataContract]
		public class ForecastItemValue
		{
			[DataMember]
			public Guid Id { set; get; }
			[DataMember]
			public decimal Value { set; get; }
			[DataMember]
			public string ForecastIndicatorCode { set; get; }
			[DataMember]
			public string PeriodName { set; get; }
			[DataMember]
			public Guid ForecastIndicatorId { set; get; }
			[DataMember]
			public Guid ForecastItemId { set; get; }
			[DataMember]
			public Guid PeriodId { set; get; }
		}

		public class ForecastItemValueResponse
		{
			[DataMember]
			public ForecastItemValue[] Collection { set; get; }
			[DataMember]
			public bool Success { set; get; }
			[DataMember]
			public string Message { set; get; }
			[DataMember]
			public ForecastItemValue ForecastItemValue { set; get; }
			[DataMember]
			public Guid ForecastItemValueId { set; get; }
		}

		[DataContract]
		public class ForecastItem
		{
			[DataMember]
			public Guid Id { set; get; }
			[DataMember]
			public Guid RowId { set; get; }
			[DataMember]
			public string Name { set; get; }
			[DataMember]
			public Guid? ParentId { set; get; }
			[DataMember]
			public string ParentName { set; get; }
			[DataMember]
			public Guid DimensionValueId { set; get; }
			[DataMember]
			public bool CanEdit { set; get; }
			[DataMember]
			public ForecastItemValue[] ForecastItemValues { set; get; }
		}

		[DataContract]
		public class ForecastItemResponse
		{
			[DataMember]
			public ForecastItem[] Collection { set; get; }
			[DataMember]
			public ColumnCaption[] ColumnCaptions { set; get; }
			[DataMember]
			public bool Success { set; get; }
			[DataMember]
			public string Message { set; get; }
		}

		[DataContract]
		public class ColumnCaption
		{
			[DataMember]
			public Guid PeriodId { set; get; }
			[DataMember]
			public string PeriodName { set; get; }
			[DataMember]
			public string IndicatorName { set; get; }
			[DataMember]
			public string IndicatorCode { set; get; }
			[DataMember]
			public string ColumnName { set; get; }
		}

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public ForecastHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		#region Methods: Private

		private EntitySchemaQuery AddPeriodFilters(EntitySchemaQuery esq, string[] periods, string periodColumnPath) {
			string startDateColumnPath = "StartDate";
			if (periodColumnPath == string.Empty) {
				periodColumnPath = "Id";
			} else {
				startDateColumnPath = periodColumnPath + "." + startDateColumnPath;
			}
			if ((periods != null) && (periods.Length > 0)) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, periodColumnPath, periods));
			} else {
				int year = DateTime.Now.Year;
				DateTime startDate = new DateTime(year, 1, 1);
				DateTime endDate = new DateTime(year, 12, 31);
				IEntitySchemaQueryFilterItem periodFilter = esq.CreateFilterWithParameters(FilterComparisonType.Between, startDateColumnPath,
					startDate, endDate);
				esq.Filters.Add(periodFilter);
			}
			return esq;
		}

		private EntitySchemaQuery GetForecastPeriodSelectQuery(string[] periods, Guid periodTypeId) {
			var forecastPeriodEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Period");
			forecastPeriodEsq.AddColumn(forecastPeriodEsq.RootSchema.GetPrimaryColumnName());
			forecastPeriodEsq.AddColumn("Name");
			EntitySchemaQueryColumn startDateColumn = forecastPeriodEsq.AddColumn("StartDate");
			forecastPeriodEsq.AddColumn("DueDate");
			EntitySchemaQueryColumn parentColumn = forecastPeriodEsq.AddColumn("Parent");
			parentColumn.OrderByAsc(0);
			startDateColumn.OrderByAsc(1);
			forecastPeriodEsq.Filters.Add(forecastPeriodEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"PeriodType", periodTypeId));
			forecastPeriodEsq = AddPeriodFilters(forecastPeriodEsq, periods, string.Empty);
			return forecastPeriodEsq;
		}

		private EntitySchemaQuery GetForecastIndicatorSelectQuery() {
			var forecastIndicatorEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ForecastIndicator");
			forecastIndicatorEsq.AddColumn(forecastIndicatorEsq.RootSchema.GetPrimaryColumnName());
			forecastIndicatorEsq.AddColumn("Name");
			forecastIndicatorEsq.AddColumn("Code");
			EntitySchemaQueryColumn positionColumn = forecastIndicatorEsq.AddColumn("Position");
			positionColumn.OrderByAsc();
			return forecastIndicatorEsq;
		}

		private EntitySchemaQuery GetForecastItemValueSelectQuery() {
			var forecastItemValueEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ForecastItemValue");
			forecastItemValueEsq.AddColumn(forecastItemValueEsq.RootSchema.GetPrimaryColumnName());
			forecastItemValueEsq.AddColumn("ForecastIndicator");
			forecastItemValueEsq.AddColumn("ForecastIndicator.Code");
			EntitySchemaQueryColumn positionColumn = forecastItemValueEsq.AddColumn("ForecastIndicator.Position");
			forecastItemValueEsq.AddColumn("ForecastItem");
			forecastItemValueEsq.AddColumn("Value");
			forecastItemValueEsq.AddColumn("Period");
			EntitySchemaQueryColumn startDateColumn = forecastItemValueEsq.AddColumn("Period.StartDate");
			startDateColumn.OrderByDesc(0);
			positionColumn.OrderByAsc(1);
			return forecastItemValueEsq;
		}

		private EntityCollection GetForecastItemValueCollection(Guid forecastItemId, Guid forecastPeriodTypeId, string[] periods) {
			EntitySchemaQuery forecastItemValueEsq = GetForecastItemValueSelectQuery();
			forecastItemValueEsq.Filters.Add(forecastItemValueEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ForecastItem", forecastItemId));
			forecastItemValueEsq = AddPeriodFilters(forecastItemValueEsq, periods, "Period");
			forecastItemValueEsq.Filters.Add(forecastItemValueEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Period.PeriodType", forecastPeriodTypeId));
			EntityCollection entityCollection = forecastItemValueEsq.GetEntityCollection(_userConnection);
			return entityCollection;
		}

		private EntitySchemaQuery GetForecastItemSelectQuery(Guid forecastId, string dimensionEntitySchemaName) {
			var forecastItemEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ForecastItem");
			forecastItemEsq.AddColumn(forecastItemEsq.RootSchema.GetPrimaryColumnName());
			forecastItemEsq.AddColumn("[" + dimensionEntitySchemaName + ":Id:DimensionValueId].Name");
			forecastItemEsq.AddColumn("Forecast");
			forecastItemEsq.AddColumn("ForecastDimension");
			forecastItemEsq.AddColumn("DimensionValueId");
			forecastItemEsq.AddColumn("IsDeleted");
			forecastItemEsq.AddColumn("Parent");
			if (forecastId != Guid.Empty) {
				forecastItemEsq.Filters.Add(forecastItemEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Forecast", forecastId));
			}
			return forecastItemEsq;
		}

		private string GetDimensionEntitySchemaName(Guid forecastId) {
			var dimensionEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Dimension");
			EntitySchemaQueryColumn columnName = dimensionEsq.AddColumn("[SysSchema:UId:EntitySchemaUId].Name");
			dimensionEsq.Filters.Add(dimensionEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"[ForecastDimension:Dimension:Id].Forecast", forecastId));
			EntityCollection dimensions = dimensionEsq.GetEntityCollection(_userConnection);
			if (dimensions.Count == 0) {
				return string.Empty;
			}
			Entity dimension = dimensions.First();
			string entitySchemaName = (string)dimension.GetColumnValue(columnName.Name);
			return entitySchemaName;
		}

		private EntitySchemaQuery GetForecastSelectQuery() {
			var forecastEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Forecast");
			forecastEsq.AddColumn(forecastEsq.RootSchema.GetPrimaryColumnName());
			forecastEsq.AddColumn("Name");
			forecastEsq.AddColumn("EntitySchemaUId");
			forecastEsq.AddColumn("EntitySchemaName");
			forecastEsq.AddColumn("PeriodType");
			return forecastEsq;
		}

		private ForecastItemValue GetEmptyItemValue(Guid forecastItemId, Entity periodValue, Entity indicatorValue) {
			return new ForecastItemValue() {
				Id = Guid.Empty,
				Value = 0,
				ForecastIndicatorId = GetEntityPrimaryColumnValue(indicatorValue),
				ForecastIndicatorCode = (string)indicatorValue.GetColumnValue("Code"),
				ForecastItemId = forecastItemId,
				PeriodId = GetEntityPrimaryColumnValue(periodValue),
				PeriodName = (string)periodValue.GetColumnValue("Name")
			};
		}

		private ForecastItemValue FindItemValueByPeriodAndIndicator(EntityCollection itemValuesCollection,
				Guid periodId, Guid indicatorId) {
			ForecastItemValue searchItem = null;
			foreach (Entity itemValue in itemValuesCollection) {
				if ((periodId == (Guid)itemValue.GetColumnValue("PeriodId")) &&
						(indicatorId == (Guid)itemValue.GetColumnValue("ForecastIndicatorId"))) {
					searchItem = GetForecastItemValue(itemValue);
					break;
				}
			}
			return searchItem;
		}

		private ForecastItemValue[] GetForecastItemValuesFullData(Guid forecastItemId, string[] periods,
				Guid periodTypeId, EntityCollection itemValuesCollection) {
			EntitySchemaQuery periodEsq = GetForecastPeriodSelectQuery(periods, periodTypeId);
			EntityCollection periodCollection = periodEsq.GetEntityCollection(_userConnection);
			EntitySchemaQuery indicatorEsq = GetForecastIndicatorSelectQuery();
			EntityCollection indicatorCollection = indicatorEsq.GetEntityCollection(_userConnection);
			List<ForecastItemValue> forecastItemValues = new List<ForecastItemValue>();
			ForecastItemValue itemValue;
			foreach (Entity periodValue in periodCollection) {
				Guid periodId = GetEntityPrimaryColumnValue(periodValue);
				foreach (Entity indicatorValue in indicatorCollection) {
					Guid indicatorId = GetEntityPrimaryColumnValue(indicatorValue);
					itemValue = FindItemValueByPeriodAndIndicator(itemValuesCollection, periodId, indicatorId) ??
								GetEmptyItemValue(forecastItemId, periodValue, indicatorValue);
					forecastItemValues.Add(itemValue);
				}
			}
			return forecastItemValues.ToArray();
		}

		private ForecastItem GetForecastItemRowData(Entity forecastCollectionItem, Guid forecastPeriodTypeId, string[] periods,
					string dimensionEntitySchemaName) {
			Guid forecastItemId = GetEntityPrimaryColumnValue(forecastCollectionItem);
			Guid? parentId = (Guid?)forecastCollectionItem.GetColumnValue("ParentId");
			string columnName = string.Concat(dimensionEntitySchemaName, "_Id_DimensionValueId_Name");
			ForecastItem forecastItem = new ForecastItem() {
				Id = forecastItemId,
				Name = (string)forecastCollectionItem.GetColumnValue(columnName),
				ParentId = parentId,
				DimensionValueId = (Guid)forecastCollectionItem.GetColumnValue("DimensionValueId"),
				CanEdit = false,
				ForecastItemValues = null
			};
			forecastItem.CanEdit = CheckForecastItemRights(forecastItemId, SchemaRecordRightLevels.CanEdit);
			EntityCollection forecastItemValueCollection = GetForecastItemValueCollection(forecastItemId, forecastPeriodTypeId, periods);
			forecastItem.ForecastItemValues = GetForecastItemValuesFullData(forecastItemId, periods,
				forecastPeriodTypeId, forecastItemValueCollection);
			return forecastItem;
		}

		private string GetSchemaPrimaryColumnName() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Period");
			EntitySchemaQueryColumn idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			return idColumn.Name;
		}

		private Guid GetEntityPrimaryColumnValue(Entity entity) {
			string primaryColumnName = GetSchemaPrimaryColumnName();
			return (Guid)entity.GetColumnValue(primaryColumnName);
		}

		#endregion

		#endregion

		#region Methods: Public

		public Guid GetForecastPeriodType(Guid forecastId) {
			EntitySchemaQuery forecastEsq = GetForecastSelectQuery();
			IEntitySchemaQueryFilterItem forecastIdFilter =
					forecastEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", forecastId);
			forecastEsq.Filters.Add(forecastIdFilter);
			EntityCollection forecastEntity = forecastEsq.GetEntityCollection(_userConnection);
			Guid periodType = new Guid();
			foreach (Entity itemValue in forecastEntity) {
				periodType = (Guid)itemValue.GetColumnValue("PeriodTypeId");
			}
			return periodType;
		}

		public ColumnCaption[] GetHeaderColumnCaptions(string[] periods, Guid periodTypeId) {
			EntitySchemaQuery periodEsq = GetForecastPeriodSelectQuery(periods, periodTypeId);
			EntityCollection periodCollection = periodEsq.GetEntityCollection(_userConnection);
			EntitySchemaQuery indicatorEsq = GetForecastIndicatorSelectQuery();
			EntityCollection indicatorCollection = indicatorEsq.GetEntityCollection(_userConnection);
			List<ColumnCaption> columnCaptions = new List<ColumnCaption>();
			foreach (Entity periodValue in periodCollection) {
				Guid periodId = GetEntityPrimaryColumnValue(periodValue);
				foreach (Entity indicatorValue in indicatorCollection) {
					string indicatorCode = (string)indicatorValue.GetColumnValue("Code");
					ColumnCaption columnCaption = new ColumnCaption() {
						PeriodId = periodId,
						PeriodName = (string)periodValue.GetColumnValue("Name"),
						IndicatorName = (string)indicatorValue.GetColumnValue("Name"),
						IndicatorCode = indicatorCode,
						ColumnName = indicatorCode + periodId
					};
					columnCaptions.Add(columnCaption);
				}
			}
			return columnCaptions.ToArray();
		}

		public ForecastItem[] GetForecastItemResultCollection(Guid forecastId, Guid forecastPeriodTypeId,
				string[] periods, string[] rows) {
			string dimensionEntitySchemaName = GetDimensionEntitySchemaName(forecastId);
			EntitySchemaQuery forecastItemEsq = GetForecastItemSelectQuery(forecastId, dimensionEntitySchemaName);
			if ((rows != null) && (rows.Length > 0)) {
				forecastItemEsq.Filters.Add(forecastItemEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", rows));
			}
			EntityCollection forecastItemsCollection = forecastItemEsq.GetEntityCollection(_userConnection);
			ForecastItem forecastItem;
			List<ForecastItem> responseCollection = new List<ForecastItem>();
			foreach (Entity forecastCollectionItem in forecastItemsCollection) {
				forecastItem = GetForecastItemRowData(forecastCollectionItem, forecastPeriodTypeId, periods, dimensionEntitySchemaName);
				if (CheckForecastItemRights(forecastItem.Id, SchemaRecordRightLevels.CanRead)) {
					responseCollection.Add(forecastItem);
				}
			}
			return responseCollection.ToArray();
		}

		public Entity GetForecastValueEntity(Guid forecastItemValueId) {
			EntitySchemaQuery forecastItemEsq = GetForecastItemValueSelectQuery();
			Entity forecastEntities = forecastItemEsq.GetEntity(_userConnection, forecastItemValueId);
			return forecastEntities;
		}

		public bool CheckForecastItemRights(Guid forecastItemId, SchemaRecordRightLevels rightLevel) {
			bool result = true;
			DBSecurityEngine dbSecurityEngine = _userConnection.DBSecurityEngine;
			SchemaRecordRightLevels forecastItemRightLevel 
				= dbSecurityEngine.GetEntitySchemaRecordRightLevel("ForecastItem", forecastItemId);
			if ((forecastItemRightLevel & rightLevel) != rightLevel) {
				result = false;
			}
			return result;
		}

		public ForecastItemValue GetForecastItemValue(Entity itemValue) {
			var forecastItemValue = new ForecastItemValue() {
				Id = GetEntityPrimaryColumnValue(itemValue),
				Value = (decimal)itemValue.GetColumnValue("Value"),
				ForecastIndicatorCode = itemValue.GetColumnValue("ForecastIndicator_Code").ToString(),
				PeriodName = itemValue.GetColumnValue("PeriodName").ToString(),
				ForecastIndicatorId = (Guid)itemValue.GetColumnValue("ForecastIndicatorId"),
				ForecastItemId = (Guid)itemValue.GetColumnValue("ForecastItemId"),
				PeriodId = (Guid)itemValue.GetColumnValue("PeriodId")
			};
			return forecastItemValue;
		}

		public bool UpdateForecastValue(Guid forecastItemValueId, decimal value) {
			bool result = false;
			EntitySchema forecastItemValueSchema = _userConnection.EntitySchemaManager.GetInstanceByName("ForecastItemValue");
			Entity forecastItemValue = forecastItemValueSchema.CreateEntity(_userConnection);
			if (forecastItemValue.FetchFromDB(forecastItemValueId)) {
				forecastItemValue.SetColumnValue("Value", value);
				result = forecastItemValue.Save();
			}
			return result;
		}

		public Guid InsertForecastValue(Guid forecastIndicatorId, Guid forecastItemId, Guid periodId, decimal value) {
			Guid result = Guid.Empty;
			EntitySchema forecastItemValueSchema = _userConnection.EntitySchemaManager.GetInstanceByName("ForecastItemValue");
			Guid forecastItemValueId = Guid.NewGuid();
			Entity forecastItemValue = forecastItemValueSchema.CreateEntity(_userConnection);
			forecastItemValue.SetColumnValue("Id", forecastItemValueId);
			forecastItemValue.SetColumnValue("Value", value);
			forecastItemValue.SetColumnValue("ForecastIndicatorId", forecastIndicatorId);
			forecastItemValue.SetColumnValue("ForecastItemId", forecastItemId);
			forecastItemValue.SetColumnValue("PeriodId", periodId);
			if (forecastItemValue.Save()) {
				result = forecastItemValueId;
			}
			return result;
		}

		public Guid AddDimensionToForecast(Guid forecastId, Guid dimensionId, int level) {
			Guid result = Guid.Empty;
			EntitySchema forecastDimensionSchema = _userConnection.EntitySchemaManager.GetInstanceByName("ForecastDimension");
			Guid forecastDimensionId = Guid.NewGuid();
			Entity forecastDimension = forecastDimensionSchema.CreateEntity(_userConnection);
			forecastDimension.SetDefColumnValues();
			forecastDimension.SetColumnValue("Id", forecastDimensionId);
			forecastDimension.SetColumnValue("Level", level);
			forecastDimension.SetColumnValue("DimensionId", dimensionId);
			forecastDimension.SetColumnValue("ForecastId", forecastId);
			if (forecastDimension.Save()) {
				result = forecastDimensionId;
			}
			return result;
		}

		#endregion
	}

	#endregion
}

