using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using BPMSoft.Core;
using BPMSoft.Common;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{
	public class MailboxSettingsLoader {
		public class SmtpSettings {
			public string Host { get; set; }
			public int Port { get; set; }
			public string UserName { get; set; }
			public string UserPassword { get; set; }
			public bool UseSSL { get; set; }
			public int ServerTimeout { get; set; }
		};
		
		private readonly UserConnection _userConnection;
		
		public MailboxSettingsLoader(UserConnection userConnection) {
			if (userConnection == null) {
				throw new ArgumentNullException("userConnection");
			}			
			_userConnection = userConnection;
		}
		
		public SmtpSettings LoadSettingsByEmail(string email) {
			var mailAddress = new MailAddress(email);
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "MailboxSyncSettings");
			esq.AddColumn("UserName");
			esq.AddColumn("UserPassword");
			esq.AddColumn("MailServer.SMTPServerAddress");
			esq.AddColumn("MailServer.SMTPPort");
			esq.AddColumn("MailServer.UseSSLforSending");
			esq.AddColumn("MailServer.SMTPServerTimeout");

			var listFilter = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And);
			listFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.Contain, "UserName", mailAddress.User));
			listFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.Contain, "MailServer.SMTPServerAddress", mailAddress.Host));
			esq.Filters.Add(listFilter);
			var col = esq.GetEntityCollection(_userConnection);
			if (col.Count == 0) {
				return null;
			}
			var entity = col[0];
			var result = new SmtpSettings
			{
				Host = entity.GetTypedColumnValue<string>("MailServer_SMTPServerAddress"),
				Port = entity.GetTypedColumnValue<int>("MailServer_SMTPPort"),
				UserName = entity.GetTypedColumnValue<string>("UserName"),
				UserPassword = entity.GetTypedColumnValue<string>("UserPassword"),
				UseSSL = entity.GetTypedColumnValue<bool>("MailServer_UseSSLforSending"),
				ServerTimeout = entity.GetTypedColumnValue<int>("MailServer_SMTPServerTimeout")
			};

			return result;
		}
	}
}
