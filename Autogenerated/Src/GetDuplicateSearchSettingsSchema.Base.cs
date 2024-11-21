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

	#region Class: GetDuplicateSearchSettings

	[DesignModeProperty(Name = "SearchSchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "2cdf118b200441c880d0d8d69b9a6f48", CaptionResourceItem = "Parameters.SearchSchemaName.Caption", DescriptionResourceItem = "Parameters.SearchSchemaName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PerformSearchOnSave", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "2cdf118b200441c880d0d8d69b9a6f48", CaptionResourceItem = "Parameters.PerformSearchOnSave.Caption", DescriptionResourceItem = "Parameters.PerformSearchOnSave.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class GetDuplicateSearchSettings : ProcessUserTask
	{

		#region Constructors: Public

		public GetDuplicateSearchSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("2cdf118b-2004-41c8-80d0-d8d69b9a6f48");
		}

		#endregion

		#region Properties: Public

		public virtual string SearchSchemaName {
			get;
			set;
		}

		public virtual bool PerformSearchOnSave {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			Select settingsSelectQuery = new Select(UserConnection)				                    
												.Column("PerformSearchOnSave")									
							                    .From("DuplicatesSearchParameter")									
							                    .Where("SchemaToSearchName").In(Column.Parameter(SearchSchemaName)) as Select;									
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using(IDataReader dr = settingsSelectQuery.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						PerformSearchOnSave = UserConnection.DBTypeConverter.DBValueToBool(dr.GetValue(0));		
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
			if (!HasMapping("PerformSearchOnSave")) {
				writer.WriteValue("PerformSearchOnSave", PerformSearchOnSave, false);
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
				case "PerformSearchOnSave":
					PerformSearchOnSave = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

