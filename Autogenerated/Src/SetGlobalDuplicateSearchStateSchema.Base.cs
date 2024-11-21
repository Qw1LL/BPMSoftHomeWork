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

	#region Class: SetGlobalDuplicateSearchState

	[DesignModeProperty(Name = "SearchSchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f3600c2bcc024ab0b395a1f077697f01", CaptionResourceItem = "Parameters.SearchSchemaName.Caption", DescriptionResourceItem = "Parameters.SearchSchemaName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SearchStatusCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f3600c2bcc024ab0b395a1f077697f01", CaptionResourceItem = "Parameters.SearchStatusCode.Caption", DescriptionResourceItem = "Parameters.SearchStatusCode.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SetGlobalDuplicateSearchState : ProcessUserTask
	{

		#region Constructors: Public

		public SetGlobalDuplicateSearchState(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("f3600c2b-cc02-4ab0-b395-a1f077697f01");
		}

		#endregion

		#region Properties: Public

		public virtual string SearchSchemaName {
			get;
			set;
		}

		public virtual string SearchStatusCode {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			Update update = new Update(UserConnection, "GlobalDuplicateSearchState")
							.Set("SearchStatusId",
								new Select(UserConnection).Top(1)
									.Column("Id")
								.From("GlobalDuplicateSearchStatus")
								.Where("Code").IsEqual(Column.Parameter(SearchStatusCode)))
							.Where("SchemaToSearchName").IsEqual(Column.Parameter(SearchSchemaName)) as Update;
			update.Execute();
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
			if (!HasMapping("SearchStatusCode")) {
				writer.WriteValue("SearchStatusCode", SearchStatusCode, null);
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
				case "SearchStatusCode":
					SearchStatusCode = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

