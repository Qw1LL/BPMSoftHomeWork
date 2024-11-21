using System;
using System.Linq;
using System.Collections.Generic;
using BPMSoft.Core;
using BPMSoft.Core.Entities;
using BPMSoft.Configuration;
using BPMSoft.Common;

public static class MacrosHelper {

	private static UserConnection _userConnection;
	private static List<EmailTemplateMacros> _macrosCollection;

	public static UserConnection UserConnection
	{
		set {_userConnection = value; _macrosCollection = GetMacrosCollection();}
	}
	
	public static List<EmailTemplateMacros> MacrosCollection {
		get
		{
			return _macrosCollection;
		}
	}
	
	public static List<EmailTemplateMacros> GetMacrosCollection() {
		var macrosSchema = _userConnection.EntitySchemaManager.GetInstanceByName("EmailTemplateMacros");
		var macrosESQ = new EntitySchemaQuery(macrosSchema); 
		var macros_IdColumn = macrosESQ.AddColumn("Id"); 
		var macros_NameColumn = macrosESQ.AddColumn("Name");
		var macros_ParentColumn = macrosESQ.AddColumn("Parent.Id");
		var macros_ColumnPathColumn = macrosESQ.AddColumn("ColumnPath");
		var macros_AccountCommunicationTypeColumn = macrosESQ.AddColumn("AccountCommunicationType.Id");
		var macros_CodeColumn = macrosESQ.AddColumn("Code");

		var list = macrosESQ.GetEntityCollection(_userConnection);
			
		_macrosCollection = new List<EmailTemplateMacros>();		
		foreach (var item in list) {
			var id = item.GetTypedColumnValue<Guid>(macros_IdColumn.Name);
			var name = item.GetTypedColumnValue<string>(macros_NameColumn.Name);
			var parentId = item.GetTypedColumnValue<Guid>(macros_ParentColumn.Name);
			var columnPath = item.GetTypedColumnValue<string>(macros_ColumnPathColumn.Name);	
			var accountCommunicationType = item.GetTypedColumnValue<string>(macros_AccountCommunicationTypeColumn.Name);
			var code = item.GetTypedColumnValue<string>(macros_CodeColumn.Name);
				
			var newMacros = (EmailTemplateMacros)macrosSchema.CreateEntity(_userConnection);
			newMacros.SetColumnValue("Id", id);
			newMacros.SetColumnValue("Name", name);
			newMacros.SetColumnValue("ParentId", parentId);
			newMacros.SetColumnValue("ColumnPath", columnPath);
			newMacros.SetColumnValue("AccountCommunicationTypeId", accountCommunicationType);
			newMacros.SetColumnValue("Code", code);			
			_macrosCollection.Add(newMacros);
		}
		return _macrosCollection;
	}
	
	public static Dictionary<string, string> GetCodeValues(Guid currentUserId, Guid recipientUserId) {
		var result = new Dictionary<string, string>();
		
		_currentUserContact = null;
		_recipientUserContact = null;
		_currentUserAccountCommunication = null;
		_macrosCollection = GetMacrosCollection();

		foreach (var macros in _macrosCollection) {
			if (string.IsNullOrEmpty(macros.ColumnPath)) {
				continue;
			}
			var value = string.Empty;
			var rootNodeId = GetRootNodeId(macros);
			if (rootNodeId.Equals(_currentUserNodeId)) {
				_currentUserContact = GetUserContact(_currentUserContact, currentUserId, rootNodeId);	
				if (!macros.AccountCommunicationTypeId.Equals(Guid.Empty)) {
					value = GetCommunicationColumnValue(_currentUserContact, macros);
				}
				else {
					value = GetCurrentUserContactColumnValue(_currentUserContact, macros);
				}
			}
			else {
				_recipientUserContact = GetUserContact(_recipientUserContact, recipientUserId, rootNodeId);	
				value = GetRecipientUserContactColumnValue(_recipientUserContact, macros);
			}
			result.Add(macros.Code, value);
		}
		return result;		
	}
	
	public static string ReplaceTextWithCodes(string text, string codeFormat) {//, out List<EmailTemplateMacros> usedMacroses) {
		//usedMacroses = new List<EmailTemplateMacros>();
		_macrosCollection = GetMacrosCollection();
		foreach (var macros in _macrosCollection) {
			if (string.IsNullOrEmpty(macros.ColumnPath)) {
				continue;
			}
			var template = GetTag(macros.Id);			
			text = text.Replace(template, string.Format(codeFormat, macros.Code));
		//	usedMacroses.Add(macros);
		}
		return text;
	}
	
	public static string ProcessText(string text, Guid currentUserId, Guid recipientUserId) {	
		_currentUserContact = null;
		_recipientUserContact = null;
		_currentUserAccountCommunication = null;
		_macrosCollection = GetMacrosCollection();

		foreach (var macros in _macrosCollection) {
			if (string.IsNullOrEmpty(macros.ColumnPath)) {
				continue;
			}
			var template = GetTag(macros.Id);
			var value = string.Empty;
			var rootNodeId = GetRootNodeId(macros);
			if (rootNodeId.Equals(_currentUserNodeId)) {
				_currentUserContact = GetUserContact(_currentUserContact, currentUserId, rootNodeId);	
				if (!macros.AccountCommunicationTypeId.Equals(Guid.Empty)) {
					value = GetCommunicationColumnValue(_currentUserContact, macros);
				}
				else {
					value = GetCurrentUserContactColumnValue(_currentUserContact, macros);
				}
			}
			else {
				_recipientUserContact = GetUserContact(_recipientUserContact, recipientUserId, rootNodeId);	
				value = GetRecipientUserContactColumnValue(_recipientUserContact, macros);
			}
			text = text.Replace(template, value);
		}
		return text;
	}
	
	public static string GetTag(Guid id) {
		if (IsBranchNode(id)) {
			return string.Empty;
		}
		var macros = GetMacros(id);
		if (macros == null) {
			return string.Empty;
		}		
		return string.Format("[#{0}#]", GetFullTag((EmailTemplateMacros)macros));
	}
	
#region Private helper methods
	private static Guid _currentUserNodeId = new Guid("3C5A2014-F46B-1410-2288-1C6F65E24DB2");
	private static Guid _accountCommunicationNodeId = new Guid("BB521FC2-F36B-1410-2C88-1C6F65E24DB2");
	private static Guid _recipientUserNodeId = new Guid("EBB220F0-F36B-1410-3088-1C6F65E24DB2");
	
	private static Entity _currentUserContact;
	private static Dictionary<string, string> _currentUserContact_ColumnNameList;
	private static Entity _recipientUserContact;
	private static Dictionary<string, string> _recipientUserContact_ColumnNameList;
	private static Dictionary<Guid, string> _currentUserAccountCommunication;

	private static EmailTemplateMacros GetMacros(Guid id) {
		return _macrosCollection.Where(m => m.Id.Equals(id)).First();
	}
	
	private static bool IsBranchNode(Guid id) {
		return id.Equals(_currentUserNodeId) 
			|| id.Equals(_accountCommunicationNodeId) 
			|| id.Equals(_recipientUserNodeId);
	}
	
	private static string GetFullTag(EmailTemplateMacros macros) {
		var result = string.Empty;
		if (!macros.ParentId.Equals(Guid.Empty)) {
			result = string.Format("{0}.", GetFullTag(GetMacros(macros.ParentId)));
		}
		return string.Concat(result, macros.Name);
	}
	
	private static Guid GetRootNodeId(EmailTemplateMacros macros) {
		if (macros.ParentId.Equals(Guid.Empty)) {
			return macros.Id;
		}
		return GetRootNodeId(GetMacros(macros.ParentId));
	}
	
	private static Dictionary<Guid, string> GetCurrentUserAccountCommunicationList(Entity contact, Guid rootMacrosId) {
		var result = new Dictionary<Guid, string>();
		var accountCommunicationSchema = _userConnection.EntitySchemaManager.GetInstanceByName("AccountCommunication");
		var accountCommunicationESQ = new EntitySchemaQuery(accountCommunicationSchema); 
		accountCommunicationESQ.PrimaryQueryColumn.IsAlwaysSelect = true;  
		var communicationType_Column = accountCommunicationESQ.AddColumn("CommunicationType.Id");
		var number_Column = accountCommunicationESQ.AddColumn("Number");
		var position_Column = accountCommunicationESQ.AddColumn("Position").OrderByDesc();
		var contactIdFilter = accountCommunicationESQ.CreateFilterWithParameters(FilterComparisonType.Equal, 
			"Account.Id", 
			contact.GetTypedColumnValue<Guid>("AccountId"));

		accountCommunicationESQ.Filters.Add(contactIdFilter);		
		var communicationTypeFilter = GetAccountCommunicationTypeFilter(accountCommunicationESQ, rootMacrosId);
		accountCommunicationESQ.Filters.Add(communicationTypeFilter); 
		
		var list = accountCommunicationESQ.GetEntityCollection(_userConnection);
		foreach(var item in list) {
			var communicationTypeId = item.GetTypedColumnValue<Guid>(communicationType_Column.Name);
			if (!result.ContainsKey(communicationTypeId)) {
				result.Add(
					communicationTypeId, 
					item.GetTypedColumnValue<string>(number_Column.Name));
			}
		}
		return result; 
	}
	
	private static EntitySchemaQueryFilterCollection GetAccountCommunicationTypeFilter(EntitySchemaQuery entitySchemaQuery, Guid rootMacrosId) {
		var result = new EntitySchemaQueryFilterCollection(
			entitySchemaQuery, 
			LogicalOperationStrict.Or);		
		foreach(var commTypeId in GetAccountCommunicationTypeListByNodeId(rootMacrosId)) {
			var filter = entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"CommunicationType.Id", 
				commTypeId);
			result.Add(filter);
		}
		return result;
	}
	
	private static List<Guid> GetAccountCommunicationTypeListByNodeId(Guid macrosId) {
		var result = new List<Guid>();
		var macros = GetMacros(macrosId);
		if (!macros.AccountCommunicationTypeId.Equals(Guid.Empty)) {
			result.Add(macros.AccountCommunicationTypeId);
		}
		
		foreach(var macrosChild in _macrosCollection.Where(m => m.ParentId.Equals(macrosId))) {
			result.AddRange(GetAccountCommunicationTypeListByNodeId(macrosChild.Id));
		}
		return result;
	}
	
	private static Entity GetUserContact(Entity contact, Guid contactId, Guid rootMacrosId) {
		if (contact == null || !contact.PrimaryColumnValue.Equals(contactId)) {
			var contactSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var contactESQ = new EntitySchemaQuery(contactSchema); 
			contactESQ.PrimaryQueryColumn.IsAlwaysSelect = true;  
			BuildContactColumns(contactESQ, rootMacrosId);
			contactESQ.AddColumn("Account");
			
			var contactIdFilter = contactESQ.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"Id", 
				contactId);
			contactESQ.Filters.Add(contactIdFilter);  
			
			var list = contactESQ.GetEntityCollection(_userConnection);
			if (list != null && list.Count > 0) {
				contact = list[0];				
			}	
			if (rootMacrosId.Equals(_currentUserNodeId)) {
				_currentUserAccountCommunication = GetCurrentUserAccountCommunicationList(contact, rootMacrosId);
			}
		}
		return contact;
	}
	
	private static void BuildContactColumns(EntitySchemaQuery entitySchemaQuery, Guid rootMacrosId) {		
		if (rootMacrosId.Equals(_currentUserNodeId)) {
			_currentUserContact_ColumnNameList = BuildColumnsMap(entitySchemaQuery, rootMacrosId);
		}
		else {
			_recipientUserContact_ColumnNameList = BuildColumnsMap(entitySchemaQuery, rootMacrosId);
		}
	}
	
	private static Dictionary<string, string> BuildColumnsMap(EntitySchemaQuery entitySchemaQuery, Guid rootMacrosId) {
		var result = new Dictionary<string, string>();
		foreach(var columnPath in GetColumnPathListByNodeId(rootMacrosId)) {
			result.Add(columnPath, entitySchemaQuery.AddColumn(columnPath).Name);
		}
		return result;
	}
	
	
	private static List<string> GetColumnPathListByNodeId(Guid id) {
		var result = new List<string>();
		var macros = GetMacros(id);
		if (!string.IsNullOrEmpty(macros.ColumnPath) && macros.AccountCommunicationTypeId.Equals(Guid.Empty)) {
			result.Add(macros.ColumnPath);
		}
		
		foreach(var macrosChild in _macrosCollection.Where(m => m.ParentId.Equals(id))) {
			result.AddRange(GetColumnPathListByNodeId(macrosChild.Id));
		}
		return result;
	}
	
	private static string GetCurrentUserContactColumnValue (Entity contact, EmailTemplateMacros macros) {
		return GetColumnValue(contact, macros, _currentUserContact_ColumnNameList);
	}
	
	private static string GetRecipientUserContactColumnValue (Entity contact, EmailTemplateMacros macros) {
		return GetColumnValue(contact, macros, _recipientUserContact_ColumnNameList);
	}
	
	private static string GetColumnValue(Entity contact, EmailTemplateMacros macros, Dictionary<string, string> columnMap) {
		object result = contact.GetColumnValue(columnMap[macros.ColumnPath]);
		return Convert.ToString(result);
	}	
	
	private static string GetCommunicationColumnValue(Entity contact, EmailTemplateMacros macros) {
		if (!_currentUserAccountCommunication.ContainsKey(macros.AccountCommunicationTypeId)) {
			return string.Empty;
		}
		return _currentUserAccountCommunication[macros.AccountCommunicationTypeId];		
	}
	
#endregion

}
