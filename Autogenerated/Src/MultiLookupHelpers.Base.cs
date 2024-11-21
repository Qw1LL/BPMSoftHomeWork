namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.UI.WebControls.Controls;

	public static class MultiLookupHelpers
	{
		#region Customer MultilookupEdit Emulator

		//Implements filtering and auto-select for AccountEdit and ContactEdit to act as multilookup
		public static void CustomerMultilookupEditEmulator(LookupEdit accountEdit,
			LookupEdit contactEdit,
			UserConnection userConnection) {
			contactEdit.PrepareLookupFilter += (sender, e) => {
				e.Filters.Clear();
				var selectedAccountObject = accountEdit.Value;
				var accountId = selectedAccountObject != null
				                	? (Guid) selectedAccountObject
				                	: Guid.Empty;
				if (accountId == Guid.Empty) {
					return;
				}
				e.Filters.Add(new Dictionary<string, object> {
					{"comparisonType", FilterComparisonType.Equal},
					{"leftExpressionColumnPath", "Account"},
					{"useDisplayValue", false},
					{"rightExpressionParameterValues", new object[] {accountId}}
				});
			};

			contactEdit.AjaxEvents.Change.Event += (sender, e) => {
				var accountId = Guid.Empty;
				var accountName = string.Empty;
				var manager = userConnection.EntitySchemaManager;
				var query = new EntitySchemaQuery(manager, "Account");
				var primaryColumnName = query.AddColumn("Id").Name;
				var primaryDisplayColumnName = query.AddColumn("Name").Name;
				query.Filters.Add(query.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"[Contact:Account:Id].Id",
					(Guid) contactEdit.Value));
				var entities = query.GetEntityCollection(userConnection);
				if (entities.Count > 0) {
					accountId = entities[0].GetTypedColumnValue<Guid>(primaryColumnName);
					accountName =
						entities[0].GetTypedColumnValue<string>(primaryDisplayColumnName);
				} else {
					return;
				}
				accountEdit.SuspendAjaxEvents();
				accountEdit.SetValueAndText(accountId, accountName);
				accountEdit.ResumeAjaxEvents();
			};
		}

		#endregion
		
		#region Customer IsRequired

		public delegate void AddScriptDelegate(string script);

		//Sets one of Edits required. Intended to be called from Init.
		public static void IsRequiredRegisterScript(LookupEdit accountEdit, LookupEdit contactEdit,
			MessagePanel messagePanel, DataSource dataSource, AddScriptDelegate addScript) {
			messagePanel.Links.Add(new LinkConfig {
				LinkId = accountEdit.ClientID,
				Caption = dataSource.Schema.Columns.GetByName("Account").Caption
			});
			messagePanel.Links.Add(new LinkConfig {
				LinkId = contactEdit.ClientID,
				Caption = dataSource.Schema.Columns.GetByName("Contact").Caption
			});
			addScript(messagePanel.ClientID + ".on('linkclick', function(e, linkId){"
					  + "var cmp = Ext.getCmp(linkId);"
					  + "if (cmp && cmp.focus) {"
					  + "cmp.focus();}}, this)");
		}

		//Validate isRequired
		public static bool IsRequiredValidate(LookupEdit accountEdit, LookupEdit contactEdit,
			MessagePanel messagePanel, UserConnection userConnection) {
			if (accountEdit.Value.Equals(Guid.Empty) && contactEdit.Value.Equals(Guid.Empty)) {
				var sb = new StringBuilder();
				//###, ####### ############# ###### # Workspace CR172891
				var resourceStorage = userConnection.Workspace.ResourceStorage;
				var alertMessage = new LocalizableString(resourceStorage,
						"MultiLookupHelpers", "LocalizableStrings.AlertMessage.Value");
				var alertMessageCaption = new LocalizableString(resourceStorage,
						"MultiLookupHelpers", "LocalizableStrings.AlertMessageCaption.Value");
				sb.AppendFormat(alertMessage, "{" + accountEdit.ClientID + "}", "{" + contactEdit.ClientID + "}");
				messagePanel.AddMessage(alertMessageCaption, sb.ToString(), MessageType.Warning);
				return false;
			}
			return true;
		}

		#endregion
	}
}

