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

	#region Class: SetControlContextMenuUserTask

	[DesignModeProperty(Name = "Page", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c00edf2e1e4948d88f0fea35d9b13da8", CaptionResourceItem = "Parameters.Page.Caption", DescriptionResourceItem = "Parameters.Page.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ControlClientID", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c00edf2e1e4948d88f0fea35d9b13da8", CaptionResourceItem = "Parameters.ControlClientID.Caption", DescriptionResourceItem = "Parameters.ControlClientID.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MenuClientID", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c00edf2e1e4948d88f0fea35d9b13da8", CaptionResourceItem = "Parameters.MenuClientID.Caption", DescriptionResourceItem = "Parameters.MenuClientID.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ClearMenuItems", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c00edf2e1e4948d88f0fea35d9b13da8", CaptionResourceItem = "Parameters.ClearMenuItems.Caption", DescriptionResourceItem = "Parameters.ClearMenuItems.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SetControlContextMenuUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public SetControlContextMenuUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("c00edf2e-1e49-48d8-8f0f-ea35d9b13da8");
		}

		#endregion

		#region Properties: Public

		public virtual Object Page {
			get;
			set;
		}

		public virtual string ControlClientID {
			get;
			set;
		}

		public virtual string MenuClientID {
			get;
			set;
		}

		public virtual Object ClearMenuItems {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var clearItemsList = ClearMenuItems as List<string>;
			var clearFunction = String.Empty;
			if (clearItemsList != null) {
				foreach (var clearItem in clearItemsList) {
					clearFunction += string.Format("{0}.getMenu().removeAll();",clearItem);
				}
			}
			if (clearFunction != String.Empty) {
				clearFunction = string.Format("{0}.on('contextmenu', function(){{ {1} }}, this);", ControlClientID, clearFunction);
			}
			if (Page == null) {
				return true;
			}
			var scriptManager = Page.GetPropertyValue("ScriptManager") as BPMSoft.UI.WebControls.Controls.ScriptManager;
			if (scriptManager != null) {
				scriptManager.AddScript(string.Format("{0}.contextMenuId = '{1}_menu';window['{1}_menu'] = {1}.menu;"+
											"{0}.enableContextMenu = true;{0}.initContextMenu();{2}", ControlClientID,
											MenuClientID, clearFunction));
			}
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
			if (!HasMapping("ControlClientID")) {
				writer.WriteValue("ControlClientID", ControlClientID, null);
			}
			if (!HasMapping("MenuClientID")) {
				writer.WriteValue("MenuClientID", MenuClientID, null);
			}
			if (ClearMenuItems != null) {
				if (ClearMenuItems.GetType().IsSerializable || ClearMenuItems.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ClearMenuItems", ClearMenuItems, null);
				}
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
				case "ControlClientID":
					ControlClientID = reader.GetStringValue();
				break;
				case "MenuClientID":
					MenuClientID = reader.GetStringValue();
				break;
				case "ClearMenuItems":
					ClearMenuItems = reader.GetSerializableObjectValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

