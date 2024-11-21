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

	#region Class: TreeGridSetFirstPageUserTask

	[DesignModeProperty(Name = "Page", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6600988eb41646b7a3b4382610a1626a", CaptionResourceItem = "Parameters.Page.Caption", DescriptionResourceItem = "Parameters.Page.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TreeGridClientID", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6600988eb41646b7a3b4382610a1626a", CaptionResourceItem = "Parameters.TreeGridClientID.Caption", DescriptionResourceItem = "Parameters.TreeGridClientID.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class TreeGridSetFirstPageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public TreeGridSetFirstPageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("6600988e-b416-46b7-a3b4-382610a1626a");
		}

		#endregion

		#region Properties: Public

		public virtual Object Page {
			get;
			set;
		}

		public virtual string TreeGridClientID {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			// TODO: Generate exception if Page is null or empty
			if (Page == null) {
				return false;
			}
			
			// TODO: Generate exception if TreeGridClientID is null or empty
			if (TreeGridClientID == null) {
				return false;
			}
			
			var page = Page as BPMSoft.UI.WebControls.PageSchemaUserControl;
			var scriptManager = page.GetPropertyValue("ScriptManager") as ScriptManager;
			var pageScript = 
			@"var treeGrid = window.opener.window.Ext.getCmp('" + TreeGridClientID + @"');
			if (treeGrid) {
				dataSource = treeGrid.dataSource;
				if (dataSource) {
					dataSource.setFirstPage();;
				}	
			}";
			
			scriptManager.AddScript(pageScript);
			
			Page = null;
			
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process, DataSourceFilterCollection filters) {
			foreach (var filter in filters) {
				if (filter is DataSourceFilterCollection) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, (DataSourceFilterCollection)filter);
					continue;
				}	
				var dataSourcefilter = (DataSourceFilter)filter;
				if (dataSourcefilter.RightExpression == null) {
					continue;
				}
				if (dataSourcefilter.RightExpression.Type == DataSourceFilterExpressionType.Custom) {
					dataSourcefilter.RightExpression.Type = DataSourceFilterExpressionType.Parameter;
					if (dataSourcefilter.RightExpression.Parameters.Count == 2) {
						var parameters = dataSourcefilter.RightExpression.Parameters;
						var metaPath = parameters[1].Value;
						parameters[1].Value = process.GetParameterValueByMetaPath((string)metaPath);
						parameters.RemoveAt(0);
					}
					if (dataSourcefilter.SubFilters != null && dataSourcefilter.SubFilters.Count > 0) {
						UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourcefilter.SubFilters);
					}
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
			if (Page != null) {
				if (Page.GetType().IsSerializable || Page.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Page", Page, null);
				}
			}
			if (!HasMapping("TreeGridClientID")) {
				writer.WriteValue("TreeGridClientID", TreeGridClientID, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Page":
					Page = reader.GetSerializableObjectValue();
				break;
				case "TreeGridClientID":
					TreeGridClientID = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

