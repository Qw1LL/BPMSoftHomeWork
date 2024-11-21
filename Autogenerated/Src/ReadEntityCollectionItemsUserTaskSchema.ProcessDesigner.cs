namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;

	#region Class: ReadEntityCollectionItemsUserTask

	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultType.Caption", DescriptionResourceItem = "Parameters.ResultType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FunctionType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.FunctionType.Caption", DescriptionResourceItem = "Parameters.FunctionType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AggregationColumnName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.AggregationColumnName.Caption", DescriptionResourceItem = "Parameters.AggregationColumnName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OrderInfo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.OrderInfo.Caption", DescriptionResourceItem = "Parameters.OrderInfo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultEntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultEntityCollection.Caption", DescriptionResourceItem = "Parameters.ResultEntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultCount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultCount.Caption", DescriptionResourceItem = "Parameters.ResultCount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.EntityCollection.Caption", DescriptionResourceItem = "Parameters.EntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultIntegerFunction", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultIntegerFunction.Caption", DescriptionResourceItem = "Parameters.ResultIntegerFunction.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultFloatFunction", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultFloatFunction.Caption", DescriptionResourceItem = "Parameters.ResultFloatFunction.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultDateTimeFunction", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultDateTimeFunction.Caption", DescriptionResourceItem = "Parameters.ResultDateTimeFunction.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultRowsCount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultRowsCount.Caption", DescriptionResourceItem = "Parameters.ResultRowsCount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReadSomeTopRecords", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ReadSomeTopRecords.Caption", DescriptionResourceItem = "Parameters.ReadSomeTopRecords.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NumberOfRecords", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.NumberOfRecords.Caption", DescriptionResourceItem = "Parameters.NumberOfRecords.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultEntity", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d83279bffb3f4b199cbe23c4742e0533", CaptionResourceItem = "Parameters.ResultEntity.Caption", DescriptionResourceItem = "Parameters.ResultEntity.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class ReadEntityCollectionItemsUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ReadEntityCollectionItemsUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("d83279bf-fb3f-4b19-9cbe-23c4742e0533");
		}

		#endregion

		#region Properties: Public

		public virtual string DataSourceFilters {
			get;
			set;
		}

		public virtual int ResultType {
			get;
			set;
		}

		public virtual int FunctionType {
			get;
			set;
		}

		public virtual string AggregationColumnName {
			get;
			set;
		}

		public virtual string OrderInfo {
			get;
			set;
		}

		public virtual EntityCollection ResultEntityCollection {
			get;
			set;
		}

		public virtual int ResultCount {
			get;
			set;
		}

		public virtual EntityCollection EntityCollection {
			get;
			set;
		}

		public virtual int ResultIntegerFunction {
			get;
			set;
		}

		public virtual Decimal ResultFloatFunction {
			get;
			set;
		}

		public virtual DateTime ResultDateTimeFunction {
			get;
			set;
		}

		public virtual int ResultRowsCount {
			get;
			set;
		}

		public virtual bool ReadSomeTopRecords {
			get;
			set;
		}

		public virtual int NumberOfRecords {
			get;
			set;
		}

		private Entity _resultEntity;
		public virtual Entity ResultEntity {
			get {
				return _resultEntity ?? (_resultEntity = new Entity(UserConnection));
			}
			set {
				_resultEntity = value;
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			EntitySchema entitySchema = EntityCollection.Schema;
			if (entitySchema == null) {
				return true;
			}
			DataSourceFilterCollection filters = null;
			if (!string.IsNullOrEmpty(DataSourceFilters)) {
				filters = ProcessUserTaskUtilities.ConvertToProcessDataSourceFilterCollection(
					UserConnection, entitySchema, this, DataSourceFilters);
			}
			var orderByInfo = new Dictionary<string, OrderDirectionStrict>(8);
			if (OrderInfo != null &&
					(ProcessReadDataResultType)ResultType == ProcessReadDataResultType.Entity && OrderInfo.Length > 0) {
				string[] orders = OrderInfo.Split(',');
				orders = orders.OrderBy(item => {
					var items = item.Split(':');
					if (items.Length == 3) {
						return items[2];
					}
					return null;
				}).ToArray();
				string[,] orderInfoWithZeroPosition = new string[orders.Length, 2];
				int index = -1;
				for (int i = 0; i < orders.Length; i++) {
					string[] order = orders[i].Split(':');
					if (order.Length != 3) {
						continue;
					}
					EntitySchemaColumn column = entitySchema.Columns.FindByName(order[0]);
					if (column == null) {
						continue;
					}
					var orderDirection = (OrderDirection)Enum.Parse(typeof(OrderDirection), order[1]);
					if (orderDirection == OrderDirection.None) {
						continue;
					}
					OrderDirectionStrict orderDirectionStrict = orderDirection == OrderDirection.Descending ?
						OrderDirectionStrict.Descending : OrderDirectionStrict.Ascending;
					if (order[2].Trim() != "0") {
						orderByInfo.Add(order[0], orderDirectionStrict);
					} else {
						index++;
						orderInfoWithZeroPosition[index, 0] = order[0];
						orderInfoWithZeroPosition[index, 1] = order[1];
					}
				}
				while (index > -1) {
					var orderDirection = (OrderDirection)Enum.Parse(typeof(OrderDirection),
						orderInfoWithZeroPosition[index, 1]);
					OrderDirectionStrict orderDirectionStrict;
					if (orderDirection == OrderDirection.None || orderDirection == OrderDirection.Ascending) {
						orderDirectionStrict = OrderDirectionStrict.Ascending;
					} else {
						orderDirectionStrict = OrderDirectionStrict.Descending;
					}
					orderByInfo.Add(orderInfoWithZeroPosition[index, 0], orderDirectionStrict);
					index--;
				}
			}
			var linqConverter = new DataSourceFilterLinqConverter(UserConnection);
			switch ((ProcessReadDataResultType)ResultType) {
				case ProcessReadDataResultType.Entity:
					IQueryable<Entity> resultQuery = ReadSomeTopRecords ?
						linqConverter.BuildQuery(EntityCollection, filters, orderByInfo, NumberOfRecords)
						: resultQuery = linqConverter.BuildQuery(EntityCollection, filters, orderByInfo);
					var resultEntityCollection = new EntityCollection(UserConnection, EntityCollection.Schema);
					foreach (Entity entity in resultQuery) {
						resultEntityCollection.Add(entity);
					}
					ResultRowsCount = resultEntityCollection.Count;
					ResultEntityCollection = resultEntityCollection;
					if (resultEntityCollection.Count > 0) {
						ResultEntity = resultEntityCollection.First.Value;
					}
					break;
				case ProcessReadDataResultType.Function:
					var aggregationType = (AggregationTypeStrict)FunctionType;
					object result = linqConverter.ExecuteQuery(EntityCollection, filters, AggregationColumnName, aggregationType);
					ResultRowsCount = 1;
					switch (aggregationType) {
						case AggregationTypeStrict.Count:
							ResultCount = (int)result;
							break;
						case AggregationTypeStrict.Avg:
						case AggregationTypeStrict.Sum:
						case AggregationTypeStrict.Max:
						case AggregationTypeStrict.Min:
							Type columnValueType = EntityCollection.Schema.Columns.GetByName(AggregationColumnName).DataValueType.ValueType;
							if (columnValueType == typeof(DateTime)) {
								ResultDateTimeFunction = (DateTime)result;
							} else {
								ResultFloatFunction = Convert.ToDecimal(result);
							}
							break;
					}
					break;
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
			}
			if (!HasMapping("ResultType")) {
				writer.WriteValue("ResultType", ResultType, 0);
			}
			if (!HasMapping("FunctionType")) {
				writer.WriteValue("FunctionType", FunctionType, 0);
			}
			if (!HasMapping("AggregationColumnName")) {
				writer.WriteValue("AggregationColumnName", AggregationColumnName, null);
			}
			if (!HasMapping("OrderInfo")) {
				writer.WriteValue("OrderInfo", OrderInfo, null);
			}
			if (!HasMapping("ResultCount")) {
				writer.WriteValue("ResultCount", ResultCount, 0);
			}
			if (!HasMapping("ResultIntegerFunction")) {
				writer.WriteValue("ResultIntegerFunction", ResultIntegerFunction, 0);
			}
			if (!HasMapping("ResultFloatFunction")) {
				writer.WriteValue("ResultFloatFunction", ResultFloatFunction, 0m);
			}
			if (!HasMapping("ResultDateTimeFunction")) {
				writer.WriteValue("ResultDateTimeFunction", ResultDateTimeFunction, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("ResultRowsCount")) {
				writer.WriteValue("ResultRowsCount", ResultRowsCount, 0);
			}
			if (!HasMapping("ReadSomeTopRecords")) {
				writer.WriteValue("ReadSomeTopRecords", ReadSomeTopRecords, false);
			}
			if (!HasMapping("NumberOfRecords")) {
				writer.WriteValue("NumberOfRecords", NumberOfRecords, 0);
			}
			if (ResultEntity != null && ResultEntity.Schema != null) {
				if (UseFlowEngineMode) {
					ResultEntity.Write(writer, "ResultEntity");
				} else {
					string serializedEntity = Entity.SerializeToJson(ResultEntity);
					writer.WriteValue("ResultEntity", serializedEntity, null);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "ResultType":
					ResultType = reader.GetIntValue();
				break;
				case "FunctionType":
					FunctionType = reader.GetIntValue();
				break;
				case "AggregationColumnName":
					AggregationColumnName = reader.GetStringValue();
				break;
				case "OrderInfo":
					OrderInfo = reader.GetStringValue();
				break;
				case "ResultCount":
					ResultCount = reader.GetIntValue();
				break;
				case "ResultIntegerFunction":
					ResultIntegerFunction = reader.GetIntValue();
				break;
				case "ResultFloatFunction":
					ResultFloatFunction = reader.GetValue<System.Decimal>();
				break;
				case "ResultDateTimeFunction":
					ResultDateTimeFunction = reader.GetDateTimeValue();
				break;
				case "ResultRowsCount":
					ResultRowsCount = reader.GetIntValue();
				break;
				case "ReadSomeTopRecords":
					ReadSomeTopRecords = reader.GetBoolValue();
				break;
				case "NumberOfRecords":
					NumberOfRecords = reader.GetIntValue();
				break;
				case "ResultEntity":
					if (UseFlowEngineMode) {
						ResultEntity = reader.GetValue<Entity>();
					} else {
						ResultEntity = Entity.DeserializeFromJson(UserConnection, reader.GetValue<System.String>());
					}
				break;
			}
		}

		#endregion

	}

	#endregion

}

