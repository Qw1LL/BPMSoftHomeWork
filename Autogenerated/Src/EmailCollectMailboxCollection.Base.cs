using System;
using System.Data;
using BPMSoft.Core;
using BPMSoft.Common;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;
using System.Collections.Generic;
#if !NETSTANDARD2_0
using BPMSoft.UI.WebControls.Controls;
#endif

namespace BPMSoft.Configuration
{
	public class EmailCollectMailboxCollection {
		private Guid _contactId;
		private UserConnection _userConnection;
		
		public EmailCollectMailboxCollection(UserConnection userConnection, Guid contactId)
		{
			if (contactId == Guid.Empty) {
				throw new ArgumentEmptyException("contactId");
			}
			if (userConnection == null) {
				throw new ArgumentException("userConnection");
			}
			_userConnection = userConnection;
			_contactId = contactId;
		}
		
		public EntityCollection Collect() {
			var entitySchemaManager = _userConnection.EntitySchemaManager;
			var mailboxES = entitySchemaManager.GetInstanceByName("MailboxSyncSettings"); 
			var mailboxESQ = new EntitySchemaQuery(entitySchemaManager, mailboxES.Name);
			var IdColumn = mailboxESQ.AddColumn(mailboxES.GetPrimaryColumnName());
			var nameColumnName = mailboxESQ.AddColumn("UserName").Name;
			var isDefaultColumnName = mailboxESQ.AddColumn("IsDefault").Name;
			var sysAdminIdColumnName = mailboxESQ.AddColumn("SysAdminUnit.Id").Name;
			var sysAdminNameColumnName = mailboxESQ.AddColumn("SysAdminUnit.Name").Name;
			var contactNameColumnName = mailboxESQ.AddColumn("SysAdminUnit.Contact.Name").Name;
			var contactIdColumnName = mailboxESQ.AddColumn("SysAdminUnit.Contact.Id").Name;
						
			mailboxESQ.Filters.Clear();
#if !NETSTANDARD2_0
			DataSourceFilterCollection filterCollection = new DataSourceFilterCollection()
				{
					LogicalOperation = LogicalOperationStrict.Or
				};
			var mailboxFilterGroug = filterCollection.ToEntitySchemaQueryFilterCollection(mailboxESQ);
			mailboxFilterGroug.Add(mailboxESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnit.Contact.Id", _contactId));
			mailboxFilterGroug.Add(mailboxESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "IsShared", true));
			mailboxESQ.Filters.Add(mailboxFilterGroug);	
#endif
			var mailboxCollection = mailboxESQ.GetEntityCollection(_userConnection);
			return mailboxCollection;
		}
	}
	
	public static class EmailCollectMailboxUtilities {
		
		public static Entity GetMailProviderByName (UserConnection userConnection, string name) {
			if (!string.IsNullOrEmpty(name)) {
				var entitySchemaManager = userConnection.EntitySchemaManager;
				var mailProviderES = entitySchemaManager.GetInstanceByName("MailServer"); 
				var mailProviderESQ = new EntitySchemaQuery(entitySchemaManager, mailProviderES.Name);
				var IdColumn = mailProviderESQ.AddColumn(mailProviderES.GetPrimaryColumnName());
				var nameColumn = mailProviderESQ.AddColumn("Name");
				mailProviderESQ.AddColumn("Address");
				mailProviderESQ.AddColumn("Port");
				mailProviderESQ.AddColumn("UseSSL");
				mailProviderESQ.AddColumn("AllowEmailDownloading");
				mailProviderESQ.AddColumn("AllowEmailSending");
				mailProviderESQ.AddColumn("SMTPServerAddress");
				mailProviderESQ.AddColumn("SMTPPort");
				mailProviderESQ.AddColumn("UseSSLforSending");
						
				mailProviderESQ.Filters.Add(mailProviderESQ.CreateFilterWithParameters(FilterComparisonType.Equal, nameColumn.Name, name));
						
				var mailProviderCollection = mailProviderESQ.GetEntityCollection(userConnection);
				if (mailProviderCollection.Count > 0)
					return mailProviderCollection[0];
			}
			return null;
		}
		
		public static Entity GetMailProviderByUId (UserConnection userConnection, Guid id) {
			if (id != Guid.Empty) {
				var entitySchemaManager = userConnection.EntitySchemaManager;
				var mailProviderES = entitySchemaManager.GetInstanceByName("MailServer"); 
				var mailProviderESQ = new EntitySchemaQuery(entitySchemaManager, mailProviderES.Name);
				var IdColumn = mailProviderESQ.AddColumn(mailProviderES.GetPrimaryColumnName());
				var nameColumn = mailProviderESQ.AddColumn("Name");
				mailProviderESQ.AddColumn("Address");
				mailProviderESQ.AddColumn("Port");
				mailProviderESQ.AddColumn("UseSSL");
				mailProviderESQ.AddColumn("AllowEmailDownloading");
				mailProviderESQ.AddColumn("AllowEmailSending");
				mailProviderESQ.AddColumn("SMTPServerAddress");
				mailProviderESQ.AddColumn("SMTPPort");
				mailProviderESQ.AddColumn("UseSSLforSending");
						
				mailProviderESQ.Filters.Add(mailProviderESQ.CreateFilterWithParameters(FilterComparisonType.Equal, mailProviderES.GetPrimaryColumnName(), id));
						
				var mailProviderCollection = mailProviderESQ.GetEntityCollection(userConnection);
				if (mailProviderCollection.Count > 0)
					return mailProviderCollection[0];
			}
			return null;
		}
	}
}
