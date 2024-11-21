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

	#region Class: OpenLookupUserTask

	[DesignModeProperty(Name = "PageParameters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1aac6458231840e58592778f3a94fdae", CaptionResourceItem = "Parameters.PageParameters.Caption", DescriptionResourceItem = "Parameters.PageParameters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ProcessKey", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1aac6458231840e58592778f3a94fdae", CaptionResourceItem = "Parameters.ProcessKey.Caption", DescriptionResourceItem = "Parameters.ProcessKey.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UserContextKey", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1aac6458231840e58592778f3a94fdae", CaptionResourceItem = "Parameters.UserContextKey.Caption", DescriptionResourceItem = "Parameters.UserContextKey.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseCurrentActivePage", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1aac6458231840e58592778f3a94fdae", CaptionResourceItem = "Parameters.UseCurrentActivePage.Caption", DescriptionResourceItem = "Parameters.UseCurrentActivePage.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class OpenLookupUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public OpenLookupUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae");
		}

		#endregion

		#region Properties: Public

		public virtual Object PageParameters {
			get;
			set;
		}

		public virtual string ProcessKey {
			get;
			set;
		}

		public virtual string UserContextKey {
			get;
			set;
		}

		public virtual bool UseCurrentActivePage {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			object schemaName;
			object schemaUId;
			object sender;
			object callbackFunction;
			object referenceSchemaList;
			object editMode;
			object lookupFilters;
			object searchValue;
			object customClosedEvent;
			object lookupGridPageCaption;
			object lookupPageSchemaUId;
			object multiSelectMode;
			object multiSelectLookupFilters;
			object useHierarchy;
			object hideButtons;
			object  columns;
			UserContextKey = Guid.NewGuid().ToString();
			var userConnection = context.UserConnection;
			var pageParameters = (Dictionary <string, object>)PageParameters;
			pageParameters.TryGetValue("schemaName", out schemaName);
			pageParameters.TryGetValue("schemaUId", out schemaUId);
			pageParameters.TryGetValue("sender", out sender);
			pageParameters.TryGetValue("callbackFunction", out callbackFunction);
			pageParameters.TryGetValue("referenceSchemaList", out referenceSchemaList);
			pageParameters.TryGetValue("editMode", out editMode);
			pageParameters.TryGetValue("LookupFilters", out lookupFilters);
			pageParameters.TryGetValue("multiSelectLookupFilters", out multiSelectLookupFilters);
			pageParameters.TryGetValue("customClosedEvent", out customClosedEvent);
			pageParameters.TryGetValue("searchValue", out searchValue);
			pageParameters.TryGetValue("lookupGridPageCaption", out lookupGridPageCaption);
			pageParameters.TryGetValue("lookupPageSchemaUId", out lookupPageSchemaUId);
			pageParameters.TryGetValue("multiSelectMode", out multiSelectMode);
			pageParameters.TryGetValue("useHierarchy", out useHierarchy);
			pageParameters.TryGetValue("hideButtons", out hideButtons);
			pageParameters.TryGetValue("showColumns", out columns);
			bool isVirtualMode = false;
			if (pageParameters.ContainsKey("IsVirtualMode")) {
				isVirtualMode = (bool)pageParameters["IsVirtualMode"];
			}
			var tempValues = new Dictionary<string, object>();
			if (!isVirtualMode) {
				if (schemaName != null){
					if (!string.IsNullOrEmpty(schemaName.ToString())){
						var manager = userConnection.GetSchemaManager("EntitySchemaManager") as BPMSoft.Core.Entities.EntitySchemaManager;
							schemaUId = manager.GetInstanceByName(schemaName.ToString()).UId.ToString();
					}
				}
				if (schemaUId == null || string.IsNullOrEmpty(schemaUId.ToString())) {
				    return true;
				}
			} else {
				tempValues.Add("IsVirtualMode", isVirtualMode);
				string virtualModeContextKey = string.Empty;
				if (pageParameters.ContainsKey("IsVirtualMode")) {
					virtualModeContextKey = pageParameters["VirtualModeContextKey"].ToString();
				}
				tempValues.Add("VirtualModeContextKey", virtualModeContextKey);
			}
			if (hideButtons != null) {
				tempValues.Add("hideButtons", hideButtons);
			}
			tempValues.Add("openLookupSelectedValues", new Dictionary<string, object>());
			tempValues.Add("openLookupProcessKey", ProcessKey);
			tempValues.Add("LookupFilters", lookupFilters);
			tempValues.Add("multiSelectLookupFilters", multiSelectLookupFilters);
			tempValues.Add("lookupGridPageCaption", lookupGridPageCaption);
			tempValues.Add("customClosedEvent", customClosedEvent);
			tempValues.Add("useHierarchy", useHierarchy ?? true);
			tempValues.Add("showColumns", columns);
			userConnection.SessionData[UserContextKey] = tempValues;
			string script = @"
			var schemaUId = '" + (schemaUId == null ? Guid.Empty.ToString() : schemaUId.ToString()) + @"';
			var sender = " + (sender == null ? "window" : sender.ToString()) + @";
			var key = (Ext.isEmpty(key)) ? (sender.name + schemaUId.replace(/-/g,'')) : key;
			var callbackFunction = " +  (callbackFunction == null ?  "null" : callbackFunction.ToString()) + @";
			var referenceSchemaList = " + (referenceSchemaList == null ? "null" : referenceSchemaList.ToString()) + @";
			var searchValue = " +  (searchValue == null ?  "null" : string.Concat("'", searchValue.ToString(), "'")) + @";
			var editMode = "  + (editMode == null ? "null" : editMode.ToString().ToLower()) + @";
			var userContextUId = '" + UserContextKey + @"';
			var lookupPageSchemaUId = " + (lookupPageSchemaUId == null ? "null" : lookupPageSchemaUId.ToString()) + @";
			var multiSelectMode = "  + (multiSelectMode == null ? "null" : "'" + multiSelectMode.ToString().ToLower() + "'") + @";
			BPMSoft.LookupGridPage.show(key, sender, callbackFunction, schemaUId, referenceSchemaList, editMode, searchValue, userContextUId, lookupPageSchemaUId, multiSelectMode);
			";
			var page = (BPMSoft.UI.WebControls.Page)System.Web.HttpContext.Current.CurrentHandler;
			var scriptManager = (BPMSoft.UI.WebControls.Controls.ScriptManager)page.Page.FindControl("ScriptManager");
			/*if (!UseCurrentActivePage) {
				script = "var executePage = window.mainPage || window; executePage.eval('" + script.Replace(@"\", @"\\").Replace(@"'", @"\'").Replace("\n", " ") + "');";
			}*/
			scriptManager.AddScript(script);
			page.TempUserContext.Add(UserContextKey);
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual Dictionary<string, object> GetSelectedValues(UserConnection userConnection) {
			var values = new Dictionary<string, object>();
			if (UserContextKey != null) {
				var parameters = userConnection.SessionData[UserContextKey.ToString()] as Dictionary<string, object>;
				if (parameters != null && parameters.ContainsKey("openLookupSelectedValues")) {
					values = parameters["openLookupSelectedValues"] as Dictionary<string, object>;
				}
			}
			return values;
		}

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
			if (PageParameters != null) {
				if (PageParameters.GetType().IsSerializable || PageParameters.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("PageParameters", PageParameters, null);
				}
			}
			if (!HasMapping("ProcessKey")) {
				writer.WriteValue("ProcessKey", ProcessKey, null);
			}
			if (!HasMapping("UserContextKey")) {
				writer.WriteValue("UserContextKey", UserContextKey, null);
			}
			if (!HasMapping("UseCurrentActivePage")) {
				writer.WriteValue("UseCurrentActivePage", UseCurrentActivePage, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "PageParameters":
					PageParameters = reader.GetSerializableObjectValue();
				break;
				case "ProcessKey":
					ProcessKey = reader.GetStringValue();
				break;
				case "UserContextKey":
					UserContextKey = reader.GetStringValue();
				break;
				case "UseCurrentActivePage":
					UseCurrentActivePage = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

