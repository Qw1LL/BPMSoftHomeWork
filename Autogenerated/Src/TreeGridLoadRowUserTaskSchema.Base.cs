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

	#region Class: TreeGridLoadRowUserTask

	[DesignModeProperty(Name = "Page", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f75d27753c5340fcb123f437981440a5", CaptionResourceItem = "Parameters.Page.Caption", DescriptionResourceItem = "Parameters.Page.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TreeGridClientID", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f75d27753c5340fcb123f437981440a5", CaptionResourceItem = "Parameters.TreeGridClientID.Caption", DescriptionResourceItem = "Parameters.TreeGridClientID.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PrimaryColumnValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f75d27753c5340fcb123f437981440a5", CaptionResourceItem = "Parameters.PrimaryColumnValue.Caption", DescriptionResourceItem = "Parameters.PrimaryColumnValue.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "LoadRows", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f75d27753c5340fcb123f437981440a5", CaptionResourceItem = "Parameters.LoadRows.Caption", DescriptionResourceItem = "Parameters.LoadRows.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class TreeGridLoadRowUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public TreeGridLoadRowUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("f75d2775-3c53-40fc-b123-f437981440a5");
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

		public virtual Guid PrimaryColumnValue {
			get;
			set;
		}

		public virtual bool LoadRows {
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
			
			// TODO: Generate exception if PrimaryColumnValue is empty
			if (PrimaryColumnValue == Guid.Empty) {
				 return false;
			}
			
			var page = Page as BPMSoft.UI.WebControls.PageSchemaUserControl;
			var scriptManager = page.GetPropertyValue("ScriptManager") as ScriptManager;
			var src = String.Empty;
			if (LoadRows) {
				/*pageScript = 
					@"var treeGrid = null;
					if (window.opener) {
						treeGrid = window.opener.window.Ext.getCmp('" + TreeGridClientID + @"');
					}
					if (treeGrid) {
						dataSource = treeGrid.dataSource;
						if (dataSource) {
							treeGrid.clear();
							dataSource.load({});
						}	
					}";*/
				src = String.Format("var treeGrid = Ext.getCmp('{0}'); if (treeGrid) {{ var ds = treeGrid.dataSource; if (ds) {{ treeGrid.clear(); ds.load({{}}); }}}}", TreeGridClientID, PrimaryColumnValue);	
			} else {
				/*pageScript = 
					@"var treeGrid = null;
					if (window.opener) {
						treeGrid = window.opener.window.eval(Ext.getCmp('" + TreeGridClientID + @"');
					}
					if (treeGrid) {
						dataSource = treeGrid.dataSource;
						if (dataSource) {
							dataSource.loadRow({primaryColumnValue:'" + PrimaryColumnValue.ToString() + @"'});
						}	
					}";*/
				/*pageScript = @"
					var wnd = window.opener || window;
					var src = 'var treeGrid = Ext.getCmp(\\'" + TreeGridClientID + @"\\');';
					src += 'var ds = treeGrid.dataSource';
					src += 'ds && ds.loadRow({primaryColumnValue:\\'" + PrimaryColumnValue.ToString() + @"\\'});';
					wnd.eval(src);";*/
				src = String.Format("var treeGrid = Ext.getCmp('{0}'); if (treeGrid) {{ var ds = treeGrid.dataSource; ds && ds.loadRow({{primaryColumnValue:'{1}'}}); }}", TreeGridClientID, PrimaryColumnValue);	
			}
			var pageScript = String.Format("var wnd = window.opener || window; var src = {0}; wnd.eval(src);", BPMSoft.Common.Json.Json.Serialize(src));
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
			if (!HasMapping("PrimaryColumnValue")) {
				writer.WriteValue("PrimaryColumnValue", PrimaryColumnValue, Guid.Empty);
			}
			if (!HasMapping("LoadRows")) {
				writer.WriteValue("LoadRows", LoadRows, false);
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
				case "PrimaryColumnValue":
					PrimaryColumnValue = reader.GetGuidValue();
				break;
				case "LoadRows":
					LoadRows = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

