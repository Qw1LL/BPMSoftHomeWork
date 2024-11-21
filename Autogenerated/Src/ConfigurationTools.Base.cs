using BPMSoft.Core.Process.Configuration;
using BPMSoft.Core;
using System.Text;
using System;
using BPMSoft.Core.Entities;
using BPMSoft.Common.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ConfigurationTools
{
	private readonly UserConnection _userConnection;
	public UserConnection UserConnection {
		get {
			return _userConnection;
		}
	}
		
	public ConfigurationTools(UserConnection userConnection) {
		_userConnection = userConnection;
	}
	
	public string GetShowWarningMessageScript(string messageText) {
		var sb = new StringBuilder();
		var questionTask = new QuestionUserTask(UserConnection);
		var caption = questionTask.WarningCaption;
		sb.AppendLine("Ext.MessageBox.message(");
		sb.AppendLine("'" + caption + "',");
		sb.AppendLine("'" + messageText.Replace("'", @"\'") + "',");
		sb.AppendLine("Ext.MessageBox.OK,");
		sb.AppendLine("Ext.MessageBox.WARNING,");
		sb.AppendLine("function(btn) {;}" + ",");
		sb.AppendLine("this");
		sb.AppendLine(");");
		return sb.ToString();
	}
	
	public void FillComboBoxByValueListSchema(BPMSoft.UI.WebControls.Controls.ComboBoxEdit comboBoxEdit, ValueListSchema comboBoxSchema) {
		foreach (var comboBoxSchemaItem in comboBoxSchema.Items) {
			var comboBoxEditItem = new BPMSoft.UI.WebControls.Controls.ListItem(
				comboBoxSchemaItem.Caption, comboBoxSchemaItem.UId.ToString());
			comboBoxEdit.Items.Add(comboBoxEditItem);
		}
	}
	
	public object GetValueListEnumValueBySchemaItemUId(ValueListSchema valueListSchema, Guid valueListSchemaItemUId, Type enumType) {
		var valueListSchemaItem = valueListSchema.Items.GetByUId(valueListSchemaItemUId);
		var valueListSchemaItemValue = valueListSchemaItem.Value;
		object result = Enum.Parse(enumType, valueListSchemaItemValue.ToString());
		if (!Enum.IsDefined(enumType, result)) {
			return null;		
		}
		return result;
	}
	
	public Guid GetContactAccountUId(Guid contactUId) {
		var accountUId = Guid.Empty;
		var contact = new BPMSoft.Configuration.Contact(UserConnection);
		var contactEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
		var contactEntitySchemaPrimaryColumnName = contactEntitySchema.GetPrimaryColumnName();
		var contactEntitySchemaPrimaryColumn = contactEntitySchema.Columns.GetByName(contactEntitySchemaPrimaryColumnName);
		var columnsToFetch = new EntitySchemaColumn[] {
			contactEntitySchema.Columns.GetByName("Account")
		};
		if (contact.FetchFromDB(contactEntitySchemaPrimaryColumn, contactUId, columnsToFetch)) {
			accountUId = contact.AccountId;
		}
		return accountUId;
	}
	
	public void GetCurrentUserContactAndCompanyNames(out string contactName, out string companyName) {		
		companyName = contactName = string.Empty;
		
		var contact = new BPMSoft.Configuration.Contact(UserConnection);
		var account = new BPMSoft.Configuration.Account(UserConnection);				
		var contactEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
		var contactEntitySchemaPrimaryColumnName = contactEntitySchema.GetPrimaryColumnName();
		var contactEntitySchemaPrimaryColumn = contactEntitySchema.Columns.GetByName(contactEntitySchemaPrimaryColumnName);		
		var accountEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Account");
		var accountEntitySchemaPrimaryColumnName = accountEntitySchema.GetPrimaryColumnName();
		var accountEntitySchemaPrimaryColumn = accountEntitySchema.Columns.GetByName(accountEntitySchemaPrimaryColumnName);
		
		var nameColumnsToFetch = new EntitySchemaColumn[] {
			contactEntitySchema.Columns.GetByName("Name")
		};
		var nameAccountColumnsToFetch = new EntitySchemaColumn[] {
			contactEntitySchema.Columns.GetByName("Name"),
			contactEntitySchema.Columns.GetByName("Account")
		};
		var currentUserContactUId = UserConnection.CurrentUser.ContactId;
		if (contact.FetchFromDB(contactEntitySchemaPrimaryColumn, currentUserContactUId, nameAccountColumnsToFetch)) {
			contactName = contact.Name;
			var currentUserCompanyUId = contact.AccountId;
			if (account.FetchFromDB(accountEntitySchemaPrimaryColumn, currentUserCompanyUId, nameColumnsToFetch)) {
				companyName = account.Name;
			}
		}
	}
	
	public string FormAddressString(string country, string region, string city, string address) { // TODO: ##### ######## ######## ####### # ######### ####### ############
		var sb = new StringBuilder();
		var hasAddress = !string.IsNullOrEmpty(address);
		var hasCity = !string.IsNullOrEmpty(city);
		var hasRegion = !string.IsNullOrEmpty(region);
		var hasCountry = !string.IsNullOrEmpty(country);
		var cityFirst = true;
		var regionFirst = true;
		var countryFirst = true;

		if (hasAddress) {
			sb.Append(address);
			cityFirst = regionFirst = countryFirst = false;
		}
		if (hasCity) {
			if (!cityFirst) {
				sb.Append(", ");
			}
			sb.Append(city);
			regionFirst = countryFirst = false;
		}
		if (hasRegion) {
			if (!regionFirst) {
				sb.Append(", ");
			}
			sb.Append(region);
			countryFirst = false;
		}
		if (hasCountry) {
			if (!countryFirst) {
				sb.Append(", ");
			}
			sb.Append(country);
		}
		var addressString = sb.ToString();
		return addressString;	
	}
	
	public string GetCustomData(BPMSoft.UI.WebControls.PageSchemaUserControl page, string clientID, string customDataKey) {
		string result = null;
		var aspPage = page.AspPage as BPMSoft.UI.WebControls.Page;
		JObject tempData = null;
		string tempDataKey = "tempData";
		if (aspPage.CustomData.ContainsKey(tempDataKey)) {
			tempData = aspPage.CustomData[tempDataKey] as JObject;
			if (tempData != null) {
				var controlTempData = tempData[clientID];
				if (controlTempData != null) {				
					var tdkValue = controlTempData[customDataKey];
					if (tdkValue != null) {
						var jValue = (Newtonsoft.Json.Linq.JValue)tdkValue;
						result = jValue.Value.ToString();
					}
				}
			}
		}
		return result;
	}
	
}
