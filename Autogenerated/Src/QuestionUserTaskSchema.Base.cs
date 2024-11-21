namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
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

	#region Class: QuestionUserTask

	[DesignModeProperty(Name = "Page", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.Page.Caption", DescriptionResourceItem = "Parameters.Page.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Icon", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.Icon.Caption", DescriptionResourceItem = "Parameters.Icon.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Buttons", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.Buttons.Caption", DescriptionResourceItem = "Parameters.Buttons.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "WindowCaption", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.WindowCaption.Caption", DescriptionResourceItem = "Parameters.WindowCaption.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageText", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.MessageText.Caption", DescriptionResourceItem = "Parameters.MessageText.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResponseMessages", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.ResponseMessages.Caption", DescriptionResourceItem = "Parameters.ResponseMessages.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ProcessInstanceId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.ProcessInstanceId.Caption", DescriptionResourceItem = "Parameters.ProcessInstanceId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PageParameters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "496a664f3aab43d7ab1b2521ab601aab", CaptionResourceItem = "Parameters.PageParameters.Caption", DescriptionResourceItem = "Parameters.PageParameters.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class QuestionUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public QuestionUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab");
		}

		#endregion

		#region Properties: Public

		public virtual Object Page {
			get;
			set;
		}

		public virtual string Icon {
			get;
			set;
		}

		public virtual string Buttons {
			get;
			set;
		}

		public virtual string WindowCaption {
			get;
			set;
		}

		public virtual string MessageText {
			get;
			set;
		}

		public virtual Object ResponseMessages {
			get;
			set;
		}

		public virtual string ProcessInstanceId {
			get;
			set;
		}

		public virtual Object PageParameters {
			get;
			set;
		}

		private LocalizableString _infoCaption;
		public LocalizableString InfoCaption {
			get {
				return _infoCaption ?? (_infoCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.InfoCaption.Value"));
			}
		}

		private LocalizableString _warningCaption;
		public LocalizableString WarningCaption {
			get {
				return _warningCaption ?? (_warningCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.WarningCaption.Value"));
			}
		}

		private LocalizableString _questionCaption;
		public LocalizableString QuestionCaption {
			get {
				return _questionCaption ?? (_questionCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.QuestionCaption.Value"));
			}
		}

		private LocalizableString _errorCaption;
		public LocalizableString ErrorCaption {
			get {
				return _errorCaption ?? (_errorCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ErrorCaption.Value"));
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			string buttonsJsString;
			string iconJsString;
			string messageBoxString = "Ext.MessageBox";
			string defaultButtons = "OK";
			string[] defaultButtonsArray = { "ok" };
			string defaultIcon = "INFO";
			string defaultMessage = "DefaultQuestionMessage";
			var page = Page as BPMSoft.UI.WebControls.PageSchemaUserControl;
			if (MessageText == null) {
				return false;
			}
			if (ProcessInstanceId == null && page != null) {
				var instanceId = ((BPMSoft.UI.WebControls.Page)page.AspPage).InstanceId.ToString();
				ProcessInstanceId = instanceId + page.PageContainer.UniqueID;
			}
			var responseMessages = ResponseMessages as Dictionary<string, string>;
			if (responseMessages == null) {
				responseMessages = new Dictionary<string,string>();
			} 
			
			var parameters = PageParameters as Dictionary<string, object>;
			if (parameters == null) {
				parameters = new Dictionary<string, object>();
			} 
			
			if (!string.IsNullOrEmpty(Buttons)) {
				switch (Buttons) {
					case "OK":
						if (!responseMessages.ContainsKey("ok")) {
							responseMessages.Add("ok", defaultMessage);
						}
						buttonsJsString = messageBoxString + "." + Buttons;
						break;
					case "OKCANCEL":
						if (!responseMessages.ContainsKey("ok")) {
							responseMessages.Add("ok", defaultMessage);
						}
						if (!responseMessages.ContainsKey("cancel")) {
							responseMessages.Add("cancel", defaultMessage);
						}
						buttonsJsString = messageBoxString + "." + Buttons;
						break;
					case "YESNO":
						if (!responseMessages.ContainsKey("yes")) {
							responseMessages.Add("yes", defaultMessage);
						}
						if (!responseMessages.ContainsKey("no")) {
							responseMessages.Add("no", defaultMessage);
						}
						buttonsJsString = messageBoxString + "." + Buttons;
						break;
					case "YESNOCANCEL":
						if (!responseMessages.ContainsKey("yes")) {
							responseMessages.Add("yes", defaultMessage);
						}
						if (!responseMessages.ContainsKey("no")) {
							responseMessages.Add("no", defaultMessage);
						}
						if (!responseMessages.ContainsKey("cancel")) {
							responseMessages.Add("cancel", defaultMessage);
						}
						buttonsJsString = messageBoxString + "." + Buttons;
						break;
					default:
						foreach (string button in defaultButtonsArray) {
							if (!responseMessages.ContainsKey(button)) {
								responseMessages.Add(button, defaultMessage);
							}
						}
						buttonsJsString = messageBoxString + "." + defaultButtons;
						break;
				}
			} else {
				foreach (string button in defaultButtonsArray) {
					if (!responseMessages.ContainsKey(button)) {
						responseMessages.Add(button, defaultMessage);
					}
				}
				buttonsJsString = messageBoxString + "." + defaultButtons;
			}
			if (!string.IsNullOrEmpty(Icon)) {
				switch (Icon) {
					case "INFO":
					case "WARNING":
					case "QUESTION":
					case "ERROR":			
						iconJsString = messageBoxString + "." + Icon;
						break;
					default:			
						iconJsString = messageBoxString + "." + defaultIcon;
						break;
				}
			} else {	
				iconJsString = messageBoxString + "." + defaultIcon;
			}
			
			var functionJsStringBuilder = new StringBuilder();
			functionJsStringBuilder.Append("function(btn) {");
				
			var isUpload = false;
			if (parameters.ContainsKey("IsUpload") && parameters["IsUpload"] != null) {
				isUpload = (bool)parameters["IsUpload"];
			}
			
			foreach(KeyValuePair<string, string> responseMessage in responseMessages){
				functionJsStringBuilder.Append("if (btn == '" + responseMessage.Key + 
													"') {window.BPMSoft.AjaxMethods.ThrowClientEvent('" + 
													ProcessInstanceId + "','" + responseMessage.Value + "', '', { isUpload : " + Json.Serialize(isUpload) + " });} else ");
			}
			functionJsStringBuilder.Append("{window.BPMSoft.AjaxMethods.ThrowClientEvent('" + ProcessInstanceId + 
											"','DefaultQuestionMessage');}}");
			WindowCaption = GetCaption();
			ScriptManager scriptManager = null;
			if (page == null) {
				scriptManager = ((BPMSoft.UI.WebControls.Page)System.Web.HttpContext.Current.CurrentHandler).FindControl("ScriptManager") as ScriptManager;
			} else {
				scriptManager = page.GetPropertyValue("ScriptManager") as ScriptManager;
			}
			scriptManager.AddScript("Ext.MessageBox.message('" + WindowCaption.ToString() + "','" + MessageText.ToString().Replace("'", @"\'") + "'," +
				buttonsJsString + "," + iconJsString + "," + functionJsStringBuilder.ToString() + ", this);");
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual string GetCaption() {
			if (WindowCaption != null){
				if (!string.IsNullOrEmpty(WindowCaption.ToString())){
					return WindowCaption;
				}
			}
			var caption = "";
			if (Icon == null){
				return caption;
			}
			switch(Icon.ToString()){
				case "INFO":
					caption = InfoCaption;
					break;
				case "WARNING":
					caption = WarningCaption;
					break;
				case "QUESTION":
					caption = QuestionCaption;
					break;
				case "ERROR":
					caption = ErrorCaption;
					break;
			}
			return caption;
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
			if (Page != null) {
				if (Page.GetType().IsSerializable || Page.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Page", Page, null);
				}
			}
			if (!HasMapping("Icon")) {
				writer.WriteValue("Icon", Icon, null);
			}
			if (!HasMapping("Buttons")) {
				writer.WriteValue("Buttons", Buttons, null);
			}
			if (!HasMapping("WindowCaption")) {
				writer.WriteValue("WindowCaption", WindowCaption, null);
			}
			if (!HasMapping("MessageText")) {
				writer.WriteValue("MessageText", MessageText, null);
			}
			if (ResponseMessages != null) {
				if (ResponseMessages.GetType().IsSerializable || ResponseMessages.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ResponseMessages", ResponseMessages, null);
				}
			}
			if (!HasMapping("ProcessInstanceId")) {
				writer.WriteValue("ProcessInstanceId", ProcessInstanceId, null);
			}
			if (PageParameters != null) {
				if (PageParameters.GetType().IsSerializable || PageParameters.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("PageParameters", PageParameters, null);
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
				case "Icon":
					Icon = reader.GetStringValue();
				break;
				case "Buttons":
					Buttons = reader.GetStringValue();
				break;
				case "WindowCaption":
					WindowCaption = reader.GetStringValue();
				break;
				case "MessageText":
					MessageText = reader.GetStringValue();
				break;
				case "ResponseMessages":
					ResponseMessages = reader.GetSerializableObjectValue();
				break;
				case "ProcessInstanceId":
					ProcessInstanceId = reader.GetStringValue();
				break;
				case "PageParameters":
					PageParameters = reader.GetSerializableObjectValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

