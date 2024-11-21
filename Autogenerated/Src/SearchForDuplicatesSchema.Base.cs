namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Globalization;

	#region Class: SearchForDuplicates

	[DesignModeProperty(Name = "SchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.SchemaId.Caption", DescriptionResourceItem = "Parameters.SchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DuplicateSchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.DuplicateSchemaId.Caption", DescriptionResourceItem = "Parameters.DuplicateSchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EditPageId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.EditPageId.Caption", DescriptionResourceItem = "Parameters.EditPageId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ContactSchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.ContactSchemaId.Caption", DescriptionResourceItem = "Parameters.ContactSchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AccountSchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.AccountSchemaId.Caption", DescriptionResourceItem = "Parameters.AccountSchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Duplicates", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.Duplicates.Caption", DescriptionResourceItem = "Parameters.Duplicates.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SearchParameters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.SearchParameters.Caption", DescriptionResourceItem = "Parameters.SearchParameters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DuplicatesFound", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.DuplicatesFound.Caption", DescriptionResourceItem = "Parameters.DuplicatesFound.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IdConstraints", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.IdConstraints.Caption", DescriptionResourceItem = "Parameters.IdConstraints.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReadSearchParameters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.ReadSearchParameters.Caption", DescriptionResourceItem = "Parameters.ReadSearchParameters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SearchParameterNames", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.SearchParameterNames.Caption", DescriptionResourceItem = "Parameters.SearchParameterNames.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InsertResults", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "dde01b4331dc47b2b249b8562a9ff203", CaptionResourceItem = "Parameters.InsertResults.Caption", DescriptionResourceItem = "Parameters.InsertResults.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SearchForDuplicates : ProcessUserTask
	{

		#region Constructors: Public

		public SearchForDuplicates(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("dde01b43-31dc-47b2-b249-b8562a9ff203");
		}

		#endregion

		#region Properties: Public

		public virtual Guid SchemaId {
			get;
			set;
		}

		public virtual Guid DuplicateSchemaId {
			get;
			set;
		}

		public virtual Guid EditPageId {
			get;
			set;
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		public virtual Guid ContactSchemaId {
			get;
			set;
		}

		public virtual Guid AccountSchemaId {
			get;
			set;
		}

		public virtual Object Duplicates {
			get;
			set;
		}

		public virtual Object SearchParameters {
			get;
			set;
		}

		public virtual bool DuplicatesFound {
			get;
			set;
		}

		public virtual Object IdConstraints {
			get;
			set;
		}

		public virtual bool ReadSearchParameters {
			get;
			set;
		}

		public virtual Object SearchParameterNames {
			get;
			set;
		}

		public virtual bool InsertResults {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ContactSchemaId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");
			AccountSchemaId = new Guid("25D7C1AB-1DE0-4501-B402-02E0E5A72D6E");
			DuplicateSchemaId = Guid.Empty;
			EditPageId = Guid.Empty;
			if (SchemaId == ContactSchemaId) {
				DuplicateSchemaId = new Guid("AFD8D870-9C6A-4482-B90E-53682AED6618");
				EditPageId = new Guid("10E5B380-25F3-474D-8DEC-6B4084180AC7");	
			} else if (SchemaId == AccountSchemaId) {
				DuplicateSchemaId = new Guid("A477264B-2D69-48B7-9268-E9B4D39EBF83");
				EditPageId = new Guid("CE234B7B-7A81-4D01-979E-32F048901BFD");
			} else {
				return true;
			}
			var storedProc = GetStoredProcedure();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = storedProc.ExecuteReader(dbExecutor)) {
					var result = new List<Guid>();		
					while (dr.Read()) {
						Guid entityId = UserConnection.DBTypeConverter.DBValueToGuid(dr.GetValue(0));
						result.Add(entityId);
					}		
					DuplicatesFound = result.Count > 0;
					Duplicates = result;
				}	
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public virtual StoredProcedure GetStoredProcedure() {
			var procName = string.Empty;
			var dataValueTypeManager = (DataValueTypeManager)UserConnection.AppManagerProvider.GetManager("DataValueTypeManager");
			var guidDataValueType = (GuidDataValueType)dataValueTypeManager.GetInstanceByName("Guid");
			var textDataValueType = (TextDataValueType)dataValueTypeManager.GetInstanceByName("Text");
			var booleanDataValueType = (BooleanDataValueType)dataValueTypeManager.GetInstanceByName("Boolean");
			var dateTimeDataValueType = (DateTimeDataValueType)dataValueTypeManager.GetInstanceByName("DateTime");
			if (SchemaId == AccountSchemaId) {
				procName = "tsp_SearchForAccountDuplicates";
			} else if (SchemaId == ContactSchemaId) {
				procName = "tsp_SearchForContactDuplicates";
			}
			if (ReadSearchParameters) {
				ReadSearchParams();
			}
			var storedProcedure = new StoredProcedure(UserConnection, procName);
			AddStoredProcedureParameter(storedProcedure, RecordId, guidDataValueType);
			AddStoredProcedureParameter(storedProcedure, InsertResults, booleanDataValueType);
			AddStoredProcedureParameter(storedProcedure, "false", booleanDataValueType);
			AddStoredProcedureParameter(storedProcedure, DateTime.MinValue, dateTimeDataValueType);
			AddStoredProcedureParameter(storedProcedure, GetConstraintsStr(), textDataValueType);
			var searchParameters = SearchParameters as List<string>;
			if (searchParameters != null) {
				foreach (var parameter in searchParameters) {		
					AddStoredProcedureParameter(storedProcedure, parameter, textDataValueType);
				}
			}
			return storedProcedure;
		}

		public virtual void AddStoredProcedureParameter(StoredProcedure storedProcedure, object value, DataValueType dataValueType) {
			bool isNull = false;
			if (dataValueType is TextDataValueType) {
				isNull = string.IsNullOrEmpty(value as string);
			} else if (dataValueType is GuidDataValueType) {
				isNull = ((Guid)value == Guid.Empty);
			} else {
				isNull = (value == null);
			}
			if (isNull) {
				storedProcedure.WithParameter(Column.Const(null));
			} else {
				storedProcedure.WithParameter(new QueryParameter { ValueType = dataValueType, Value = value });
			}
		}

		public virtual string GetConstraintsStr() {
			var idConstraints = IdConstraints as List<Guid>;
			string constraintList = string.Empty;
			if ((idConstraints != null) && (idConstraints.Count > 0)) {	
				foreach (var id in idConstraints) {
					constraintList += id.ToString("D");
				}
			}
			return constraintList;
		}

		public virtual void ReadSearchParams() {
			var searchParameters = new List<string>();
			SearchParameters = searchParameters;
			var schema = UserConnection.EntitySchemaManager.GetInstanceByUId(SchemaId);
			Entity entity = schema.CreateEntity(UserConnection);
			if (entity.FetchFromDB(RecordId)) {
				var searchParameterNames = SearchParameterNames as List<string>;
				foreach (var parameterName in searchParameterNames) {
					searchParameters.Add(entity.GetTypedColumnValue<string>(parameterName));
				}	
			}
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("SchemaId")) {
				writer.WriteValue("SchemaId", SchemaId, Guid.Empty);
			}
			if (!HasMapping("DuplicateSchemaId")) {
				writer.WriteValue("DuplicateSchemaId", DuplicateSchemaId, Guid.Empty);
			}
			if (!HasMapping("EditPageId")) {
				writer.WriteValue("EditPageId", EditPageId, Guid.Empty);
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
			}
			if (!HasMapping("ContactSchemaId")) {
				writer.WriteValue("ContactSchemaId", ContactSchemaId, Guid.Empty);
			}
			if (!HasMapping("AccountSchemaId")) {
				writer.WriteValue("AccountSchemaId", AccountSchemaId, Guid.Empty);
			}
			if (Duplicates != null) {
				if (Duplicates.GetType().IsSerializable || Duplicates.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Duplicates", Duplicates, null);
				}
			}
			if (SearchParameters != null) {
				if (SearchParameters.GetType().IsSerializable || SearchParameters.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("SearchParameters", SearchParameters, null);
				}
			}
			if (!HasMapping("DuplicatesFound")) {
				writer.WriteValue("DuplicatesFound", DuplicatesFound, false);
			}
			if (IdConstraints != null) {
				if (IdConstraints.GetType().IsSerializable || IdConstraints.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("IdConstraints", IdConstraints, null);
				}
			}
			if (!HasMapping("ReadSearchParameters")) {
				writer.WriteValue("ReadSearchParameters", ReadSearchParameters, false);
			}
			if (SearchParameterNames != null) {
				if (SearchParameterNames.GetType().IsSerializable || SearchParameterNames.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("SearchParameterNames", SearchParameterNames, null);
				}
			}
			if (!HasMapping("InsertResults")) {
				writer.WriteValue("InsertResults", InsertResults, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SchemaId":
					SchemaId = reader.GetGuidValue();
				break;
				case "DuplicateSchemaId":
					DuplicateSchemaId = reader.GetGuidValue();
				break;
				case "EditPageId":
					EditPageId = reader.GetGuidValue();
				break;
				case "RecordId":
					RecordId = reader.GetGuidValue();
				break;
				case "ContactSchemaId":
					ContactSchemaId = reader.GetGuidValue();
				break;
				case "AccountSchemaId":
					AccountSchemaId = reader.GetGuidValue();
				break;
				case "Duplicates":
					Duplicates = reader.GetSerializableObjectValue();
				break;
				case "SearchParameters":
					SearchParameters = reader.GetSerializableObjectValue();
				break;
				case "DuplicatesFound":
					DuplicatesFound = reader.GetBoolValue();
				break;
				case "IdConstraints":
					IdConstraints = reader.GetSerializableObjectValue();
				break;
				case "ReadSearchParameters":
					ReadSearchParameters = reader.GetBoolValue();
				break;
				case "SearchParameterNames":
					SearchParameterNames = reader.GetSerializableObjectValue();
				break;
				case "InsertResults":
					InsertResults = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

