using System;
using System.Collections.Generic;
using System.Text;
using BPMSoft.Common;
using BPMSoft.Common.Json;

namespace BPMSoft.Configuration
{
	public enum MessageBoxButtons 
	{		
		Ok,
		OkCancel,
		YesNo,
		YesNoCancel
	}
	
	public enum MessageBoxIcon
	{
		Information,
		Question,
		Warning
	}
	
	public static class ClientScriptUtilities 
	{
		private static Dictionary<MessageBoxButtons , string> MessageBoxButtonss = new Dictionary<MessageBoxButtons, string> {
			{MessageBoxButtons.Ok, "Ext.MessageBox.OK"},
			{MessageBoxButtons.OkCancel, "Ext.MessageBox.OKCANCEL"},
			{MessageBoxButtons.YesNo, "Ext.MessageBox.YESNO"},
			{MessageBoxButtons.YesNoCancel, "Ext.MessageBox.YESNOCANCEL"}
		};
		
		private static Dictionary<MessageBoxIcon, string> MessageBoxIcons = new Dictionary<MessageBoxIcon, string> {
			{MessageBoxIcon.Information, "Ext.MessageBox.INFORMATION"},
			{MessageBoxIcon.Question, "Ext.MessageBox.QUESTION"},
			{MessageBoxIcon.Warning, "Ext.MessageBox.WARNING"}
		};
		
		public static string GetMessageScript(LocalizableString caption, LocalizableString message,
				MessageBoxButtons buttons, MessageBoxIcon icon, string callbackFunction, string scope = "this") {
			string script = string.Format("Ext.MessageBox.message({0},{1},{2},{3},{4},{5});",
					string.Format("{0}", Json.Serialize(caption)), string.Format("{0}", Json.Serialize(message)),
					MessageBoxButtonss[buttons], MessageBoxIcons[icon], callbackFunction, scope);
			return script;
		}
		
		public static string GetOpenPageScript(Guid pageSchemaUId, Dictionary<string, object> openPageParameters, 
			Dictionary<string, string> queryStringParameters, int width = 0, int height = 0) {
			var sb = new StringBuilder();
			sb.Append("BPMSoft.openWindow(");
			var sbCallback = new StringBuilder();
			var nullString = "null";
			var callbackString = "function(wnd) {{ {0} }}";
			var window = "wnd";
			sb.Append("'");
			sb.Append("ViewPage.aspx");	
			sb.Append("'");
			sb.Append(", ");
			sb.Append("'");
			sb.Append(pageSchemaUId.ToString());
			sb.Append("'");	
			sb.Append(", ");
			sb.Append("[");
			bool isFirst = true;
			foreach (var parameter in queryStringParameters) {
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
				sb.Append(parameter.Value);
				sb.Append("}");
			}
			sb.Append("\t]");	
			sb.Append(", ");
			if (width > 0 && height > 0) {
				sb.Append(width.ToString());
				sb.Append(", ");		
				sb.Append(height.ToString());
				sb.Append(", ");
			} else {
				sb.Append("null, null, ");
			}
			sb.Append("true");
			sb.Append(", ");
			sb.Append(nullString);
			sb.Append(", ");
			sb.Append(nullString);
			sbCallback.Append("\nvar windowKey = ");
			sbCallback.Append("'");
			if (openPageParameters.ContainsKey("OpenerInstanceId")) {
				sbCallback.Append(openPageParameters["OpenerInstanceId"].ToString());
			}
			sbCallback.Append("'");
			sbCallback.Append(";");	
			sbCallback.Append("\nwnd.key = windowKey;");
			if (openPageParameters.ContainsKey("CloseMessage")) {
				var closeMessageObj = openPageParameters["CloseMessage"];
				if (closeMessageObj != null) {
					var closeMessage = closeMessageObj.ToString();
					if (closeMessage.Length > 0) {
						sbCallback.Append("\nExt.EventManager.on(");	
						sbCallback.Append(window);
						sbCallback.Append(", 'beforeunload', function() {\n\t");
						sbCallback.Append("if (BPMSoft.AjaxMethods.ThrowClientEvent)");
						sbCallback.Append("\n\t\t{\n\tBPMSoft.AjaxMethods.ThrowClientEvent(");	
						sbCallback.Append("windowKey");
						sbCallback.Append(",");
						sbCallback.Append("'");
						sbCallback.Append(closeMessage);
						sbCallback.Append("'");
						sbCallback.Append(");}");
						sbCallback.Append("\n});");				
					}
				}
			}
			sb.Append(", ");
			sb.Append(string.Format(callbackString, sbCallback.ToString()));
			sb.Append(");");
			return sb.ToString();
		}
		
		public static string GetRegisterAddPageScript(Guid editPageUId, Dictionary<string, object> parameters) {
			var openPageParameters = new Dictionary<string, object>();
			if(parameters.ContainsKey("openerProcessInstanceId")) {
				openPageParameters["OpenerInstanceId"] = parameters["openerProcessInstanceId"];
			}
			var queryStringParameters = new Dictionary<string, string>() {
				{"recordId", string.Format("'{0}'", Guid.Empty)},
			};
			if (parameters.ContainsKey("entitySchemaUId")) {
				queryStringParameters["entitySchemaUId"] = string.Format("'{0}'", parameters["entitySchemaUId"]);
			}
			if (parameters.ContainsKey("treeGridClientId")) {
				queryStringParameters["treeGridId"] = string.Format("'{0}'", parameters["treeGridClientId)"]);
			}
			if (parameters.ContainsKey("sysModuleEditId")) {
				queryStringParameters["SysModuleEditId"] = string.Format("'{0}'", parameters["sysModuleEditId"]);
			}
			if (parameters.ContainsKey("typeColumnUId") && (Guid)parameters["typeColumnUId"] != Guid.Empty) {
				queryStringParameters.Add("typeColumnUId", Json.Serialize(parameters["typeColumnUId"]));
				queryStringParameters.Add("typeId", Json.Serialize(parameters["typeId"]));
			}
			if (parameters.ContainsKey("isDetailGrid") && (bool)parameters["isDetailGrid"]) {
				string dataSourceClientId = "window[Ext.decode(Ext.get('customDataField').dom.value)['SysModule_activeDataSource']]";
				queryStringParameters.Add("SysModuleDetailId", string.Format("'{0}'", parameters["sysModuleDetailId"]));
				queryStringParameters.Add("ParentEntityId", "Ext.isEmpty(" + dataSourceClientId + ".activeRow) ? '" + Guid.Empty + "' : " + dataSourceClientId + ".activeRow.getPrimaryColumnValue()");
				queryStringParameters.Add("ParentEntitySchemaId", string.Format("'{0}'", parameters["sysEntitySchemaId"]));
				queryStringParameters.Add("UseModuleDetail", string.Format("'{0}'", parameters["useModuleDetails"]));	
			} else if (parameters.ContainsKey("selectedFolderId")) {
				var selectedFolderValue = "Ext.decode(Ext.get('customDataField').dom.value)['SysModule_selectedFolderId']";
				string selectedFolderId = string.Format("{0} ? {0} : ''", selectedFolderValue);
				queryStringParameters.Add("folderId", string.Format("{0}", parameters["selectedFolderId"]));	
			}
			if (parameters.ContainsKey("parentModuleId")) {
				queryStringParameters.Add("parentModuleId", string.Format("'{0}'", parameters["parentModuleId"]));
				string dataSourceClientId = "!window[Ext.decode(Ext.get('customDataField').dom.value)['SysModule_activeDataSource']] ? '' : window[Ext.decode(Ext.get('customDataField').dom.value)['SysModule_activeDataSource']]";
				queryStringParameters.Add("ParentEntityId", "Ext.isEmpty(" + dataSourceClientId + ".activeRow) ? '" + Guid.Empty + "' : " + dataSourceClientId + ".activeRow.getPrimaryColumnValue()");
			}
			return GetOpenPageScript(editPageUId, openPageParameters, queryStringParameters);
		}
	}
}

