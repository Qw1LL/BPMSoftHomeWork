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
	using System.Text;

	#region Class: OpenPageUserTask

	[DesignModeProperty(Name = "PageUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.PageUId.Caption", DescriptionResourceItem = "Parameters.PageUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PageUrl", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.PageUrl.Caption", DescriptionResourceItem = "Parameters.PageUrl.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OpenerInstanceId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.OpenerInstanceId.Caption", DescriptionResourceItem = "Parameters.OpenerInstanceId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CloseOpenerOnLoad", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.CloseOpenerOnLoad.Caption", DescriptionResourceItem = "Parameters.CloseOpenerOnLoad.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PageParameters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.PageParameters.Caption", DescriptionResourceItem = "Parameters.PageParameters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Width", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.Width.Caption", DescriptionResourceItem = "Parameters.Width.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CloseMessage", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.CloseMessage.Caption", DescriptionResourceItem = "Parameters.CloseMessage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Height", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.Height.Caption", DescriptionResourceItem = "Parameters.Height.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Centered", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.Centered.Caption", DescriptionResourceItem = "Parameters.Centered.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseOpenerRegisterScript", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.UseOpenerRegisterScript.Caption", DescriptionResourceItem = "Parameters.UseOpenerRegisterScript.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseCurrentActivePage", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.UseCurrentActivePage.Caption", DescriptionResourceItem = "Parameters.UseCurrentActivePage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IgnoreProfile", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b7042ef4f468443eb3ea39ebbda1c828", CaptionResourceItem = "Parameters.IgnoreProfile.Caption", DescriptionResourceItem = "Parameters.IgnoreProfile.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class OpenPageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public OpenPageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828");
		}

		#endregion

		#region Properties: Public

		public virtual Guid PageUId {
			get;
			set;
		}

		public virtual string PageUrl {
			get;
			set;
		}

		public virtual string OpenerInstanceId {
			get;
			set;
		}

		public virtual bool CloseOpenerOnLoad {
			get;
			set;
		}

		public virtual Object PageParameters {
			get;
			set;
		}

		public virtual int Width {
			get;
			set;
		}

		public virtual string CloseMessage {
			get;
			set;
		}

		public virtual int Height {
			get;
			set;
		}

		public virtual Object Centered {
			get;
			set;
		}

		public virtual bool UseOpenerRegisterScript {
			get;
			set;
		}

		public virtual bool UseCurrentActivePage {
			get;
			set;
		}

		public virtual bool IgnoreProfile {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			// TODO: Generate exception if OpenerPage parameter is null
			/*
			BPMSoft.UI.WebControls.PageSchemaUserControl page = null;
			if (OpenerPage != null) {
				//return false;
				page = (BPMSoft.UI.WebControls.PageSchemaUserControl)OpenerPage;
			}
			*/
			//var page = (BPMSoft.UI.WebControls.PageSchemaUserControl)OpenerPage;
			
			// TODO: Generate exception if PageUId and PageUrl parameters are (null or empty) and at same time 
			if (PageUId.IsEmpty() && string.IsNullOrEmpty(PageUrl)) {	
				return false;
			}
			
			var sb = new StringBuilder();
			/*
			if (UseOpenerRegisterScript) {
				sb.Append("var currentOpener = window.opener != null ? window.opener : window;\r\n");
				sb.Append("currentOpener.");
			}
			*/
			sb.Append("BPMSoft.openWindow(");
			var sbCallback = new StringBuilder();
			var sbConfig = new StringBuilder();
			var nullString = "null";
			var callbackString = "function(wnd) {{ {0} }}";
			var window = "wnd";
			
			// windowUrl:
			if (!PageUId.IsEmpty()) {
				sb.Append("'");
				sb.Append("ViewPage.aspx");	
				sb.Append("'");
				// id:
				sb.Append(", ");
				sb.Append("'");
				sb.Append(PageUId.ToString());
				sb.Append("'");	
			} else {
				sb.Append("'");
				sb.Append(PageUrl);
				sb.Append("'");
				// id:
				sb.Append(", ");
				sb.Append(nullString);	
			}
			sb.Append(", ");
			
			// params:
			sb.Append("[");
			bool isFirst = true;
			if (PageParameters != null) {
				foreach (var parameter in (Dictionary<string, string>)PageParameters) {
					if (isFirst) {
						isFirst = false;
					} else {
						sb.Append(", ");
					}
					sb.Append("\n\t{name: ");
					sb.Append("'");
					sb.Append(parameter.Key);
					sb.Append("'");
					sb.Append(",");
					sb.Append(" value: ");
					sb.Append("'");
					sb.Append(parameter.Value);
					sb.Append("'");
					sb.Append("}");
				}
			}
			sb.Append("\t]");	
			sb.Append(", ");
			
			var pageSchemaManager = UserConnection.GetSchemaManager("PageSchemaManager") as PageSchemaManager;
			if (!PageUId.IsEmpty()) {
				var pageSchema = pageSchemaManager.GetInstanceByUId(PageUId);	
				if (!pageSchema.Maximized) {
					// width:
					sb.Append(pageSchema.Width.ToString(CultureInfo.InvariantCulture));
					sb.Append(", ");		
					// height:
					sb.Append(pageSchema.Height.ToString(CultureInfo.InvariantCulture));
					sb.Append(", ");
				} else {
					// width:
					sb.Append(nullString);
					sb.Append(", ");		
					// height:
					sb.Append(nullString);
					sb.Append(", ");
				}
			} else {
				// width:
				if (Width > 0) {
					sb.Append(Width.ToString(CultureInfo.InvariantCulture));
				} else {
					sb.Append(nullString);
				}
				sb.Append(", ");
				
				// height:
				if (Height > 0) {
					sb.Append(Height.ToString(CultureInfo.InvariantCulture));
				} else {
					sb.Append(nullString);
				}
				sb.Append(", ");
			}
			
			// isCenterWindow: 
			var centered = Centered as bool?;
			if (!centered.HasValue) {
				sb.Append("true");
			} else {	
				if (centered.Value) {
					sb.Append("true");
				} else {
					sb.Append("false");
				}
			}
			sb.Append(", ");
			
			// isToolBarVisible:
			sb.Append(nullString);
			sb.Append(", ");
			
			// openInExistingWindow:
			sb.Append(nullString);
			
			// key setting:
			sbCallback.Append("\nvar windowKey = ");
			// sbCallback.Append(window);
			// sbCallback.Append(".key = ");
			sbCallback.Append("'");
			if (!string.IsNullOrEmpty(OpenerInstanceId)) {
				sbCallback.Append(OpenerInstanceId);
			} else {
				/*
				if (page != null) {
					sbCallback.Append(((BPMSoft.UI.WebControls.Page)page.AspPage).InstanceId.ToString());
					sbCallback.Append(page.PageContainer.UniqueID);
				}*/
			}
			sbCallback.Append("'");
			sbCallback.Append(";");	
			sbCallback.Append("\nwnd.key = windowKey;");
			
			// opener closing:
			if (CloseOpenerOnLoad) {
				sbCallback.Append("\nif (window.mainPage != window) {");
				sbCallback.Append("\n\tExt.lib.Event.on(");	
				sbCallback.Append(window);
				sbCallback.Append(", 'load', function() {\n\t\twindow.close()\n});");
				sbCallback.Append("\n}");
			}
			
			// close message:
			if (!string.IsNullOrEmpty(CloseMessage)) {
				sbCallback.Append(@"
			var pickHoleInRegisterListener = function(attemptsCount) {
				setTimeout(function() {
					try {
						attemptsCount--;
						Ext.EventManager.on(wnd, 'beforeunload', function() {
							if (BPMSoft.AjaxMethods.ThrowClientEvent) {
								var wndKey = windowKey;
								setTimeout(function() {
									BPMSoft.AjaxMethods.ThrowClientEvent(wndKey,'");
				sbCallback.Append(CloseMessage);
				sbCallback.Append(@"');}, 10);
							}
						});
					} catch(e) {
						if (attemptsCount === 0) {
							throw e;
						}
						pickHoleInRegisterListener(attemptsCount);
					}
				}, 200);
			};
			pickHoleInRegisterListener(10);");
			}
			
			sb.Append(", ");
			sb.Append(string.Format(callbackString, sbCallback.ToString()));
			sb.Append(", ");
			
			// ignoreRequestId:
			sb.Append(nullString);
			sb.Append(", ");
			
			// windowName
			sb.Append(nullString);
			sb.Append(", ");
			
			// useApplicationPath
			sb.Append(nullString);
			sb.Append(", ");
			
			// config
			sbConfig.Append("\n{");
			
				// config:ignoreProfile
				sbConfig.Append(string.Format("ignoreProfile:{0}", IgnoreProfile ? "true" : "false"));
			
			sbConfig.Append("}");
			
			sb.Append(sbConfig);
			sb.Append(");");
			
			// script adding:
			/*
			ScriptManager scriptManager = null;
			if (page == null) {
			} else {
				scriptManager = page.GetPropertyValue("ScriptManager") as ScriptManager;
			}
			*/
			//ScriptManager scriptManager = ((BPMSoft.UI.WebControls.Page)System.Web.HttpContext.Current.CurrentHandler).FindControl("ScriptManager") as ScriptManager;
			//Hack: Asp.Net has an artificial limit on the size of the stack
			ScriptManager scriptManager = BPMSoft.UI.WebControls.Page.FindControlByClientId(((System.Web.UI.Control)System.Web.HttpContext.Current.CurrentHandler), "ScriptManager", true) as ScriptManager;
			string script = sb.ToString();
			if (!UseCurrentActivePage) {
				script = "var executePage = window.mainPage || window; executePage.eval('" + script.Replace(@"\", @"\\").Replace(@"'", @"\'").Replace("\n", " ").Replace("\r", " ")  + "');";
			}
			scriptManager.AddScript(script);
			//OpenerPage = null;
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
			if (!HasMapping("PageUId")) {
				writer.WriteValue("PageUId", PageUId, Guid.Empty);
			}
			if (!HasMapping("PageUrl")) {
				writer.WriteValue("PageUrl", PageUrl, null);
			}
			if (!HasMapping("OpenerInstanceId")) {
				writer.WriteValue("OpenerInstanceId", OpenerInstanceId, null);
			}
			if (!HasMapping("CloseOpenerOnLoad")) {
				writer.WriteValue("CloseOpenerOnLoad", CloseOpenerOnLoad, false);
			}
			if (PageParameters != null) {
				if (PageParameters.GetType().IsSerializable || PageParameters.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("PageParameters", PageParameters, null);
				}
			}
			if (!HasMapping("Width")) {
				writer.WriteValue("Width", Width, 0);
			}
			if (!HasMapping("CloseMessage")) {
				writer.WriteValue("CloseMessage", CloseMessage, null);
			}
			if (!HasMapping("Height")) {
				writer.WriteValue("Height", Height, 0);
			}
			if (Centered != null) {
				if (Centered.GetType().IsSerializable || Centered.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Centered", Centered, null);
				}
			}
			if (!HasMapping("UseOpenerRegisterScript")) {
				writer.WriteValue("UseOpenerRegisterScript", UseOpenerRegisterScript, false);
			}
			if (!HasMapping("UseCurrentActivePage")) {
				writer.WriteValue("UseCurrentActivePage", UseCurrentActivePage, false);
			}
			if (!HasMapping("IgnoreProfile")) {
				writer.WriteValue("IgnoreProfile", IgnoreProfile, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "PageUId":
					PageUId = reader.GetGuidValue();
				break;
				case "PageUrl":
					PageUrl = reader.GetStringValue();
				break;
				case "OpenerInstanceId":
					OpenerInstanceId = reader.GetStringValue();
				break;
				case "CloseOpenerOnLoad":
					CloseOpenerOnLoad = reader.GetBoolValue();
				break;
				case "PageParameters":
					PageParameters = reader.GetSerializableObjectValue();
				break;
				case "Width":
					Width = reader.GetIntValue();
				break;
				case "CloseMessage":
					CloseMessage = reader.GetStringValue();
				break;
				case "Height":
					Height = reader.GetIntValue();
				break;
				case "Centered":
					Centered = reader.GetSerializableObjectValue();
				break;
				case "UseOpenerRegisterScript":
					UseOpenerRegisterScript = reader.GetBoolValue();
				break;
				case "UseCurrentActivePage":
					UseCurrentActivePage = reader.GetBoolValue();
				break;
				case "IgnoreProfile":
					IgnoreProfile = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

