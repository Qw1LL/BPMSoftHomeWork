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
	using System.Globalization;

	#region Class: GetGlobalDuplicateSearchState

	[DesignModeProperty(Name = "SearchSchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a3c617aef962410fb2f5c623fc3fd34a", CaptionResourceItem = "Parameters.SearchSchemaName.Caption", DescriptionResourceItem = "Parameters.SearchSchemaName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SearchProgress", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a3c617aef962410fb2f5c623fc3fd34a", CaptionResourceItem = "Parameters.SearchProgress.Caption", DescriptionResourceItem = "Parameters.SearchProgress.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SearchStatusCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a3c617aef962410fb2f5c623fc3fd34a", CaptionResourceItem = "Parameters.SearchStatusCode.Caption", DescriptionResourceItem = "Parameters.SearchStatusCode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SearchStatusChangedOn", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a3c617aef962410fb2f5c623fc3fd34a", CaptionResourceItem = "Parameters.SearchStatusChangedOn.Caption", DescriptionResourceItem = "Parameters.SearchStatusChangedOn.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class GetGlobalDuplicateSearchState : ProcessUserTask
	{

		#region Constructors: Public

		public GetGlobalDuplicateSearchState(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("a3c617ae-f962-410f-b2f5-c623fc3fd34a");
		}

		#endregion

		#region Properties: Public

		public virtual string SearchSchemaName {
			get;
			set;
		}

		public virtual int SearchProgress {
			get;
			set;
		}

		public virtual string SearchStatusCode {
			get;
			set;
		}

		public virtual DateTime SearchStatusChangedOn {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			Select duplicateSearchStateSelect = new Select(UserConnection)				                    
												.Column("SearchState", "ProcessedCount")
												.Column("SearchStatus", "Code")
												.Column("SearchState", "SearchStatusChangedOn")
												.Column("SearchState", "TotalCount")
							                    .From("GlobalDuplicateSearchState").As("SearchState")
												.Join(JoinType.Inner, "GlobalDuplicateSearchStatus").As("SearchStatus")
													.On("SearchState", "SearchStatusId").IsEqual("SearchStatus", "Id")
							                    .Where("SchemaToSearchName").IsEqual(new QueryParameter(SearchSchemaName)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using(var dataReader = duplicateSearchStateSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						int processedCount = UserConnection.DBTypeConverter.DBValueToInt(dataReader.GetValue(0));
						SearchStatusCode = (string)dataReader.GetValue(1);
						SearchStatusChangedOn = (DateTime)dataReader.GetValue(2);
						int totalCount = UserConnection.DBTypeConverter.DBValueToInt(dataReader.GetValue(3));
						SearchProgress = (totalCount == 0) ? 0 : (processedCount * 100) / totalCount;
					}
				}
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("SearchSchemaName")) {
				writer.WriteValue("SearchSchemaName", SearchSchemaName, null);
			}
			if (!HasMapping("SearchProgress")) {
				writer.WriteValue("SearchProgress", SearchProgress, 0);
			}
			if (!HasMapping("SearchStatusCode")) {
				writer.WriteValue("SearchStatusCode", SearchStatusCode, null);
			}
			if (!HasMapping("SearchStatusChangedOn")) {
				writer.WriteValue("SearchStatusChangedOn", SearchStatusChangedOn, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SearchSchemaName":
					SearchSchemaName = reader.GetStringValue();
				break;
				case "SearchProgress":
					SearchProgress = reader.GetIntValue();
				break;
				case "SearchStatusCode":
					SearchStatusCode = reader.GetStringValue();
				break;
				case "SearchStatusChangedOn":
					SearchStatusChangedOn = reader.GetDateTimeValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

