namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Mail.Sender;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;

	#region Class: SendEmailUserTask

	[DesignModeGroup(Name = "General", Position = 1, UseSolutionStorage = true, ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.Sender.Group", DescriptionResourceItem = "Parameters.Sender.Group")]
	[DesignModeProperty(Name = "Sender", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.Sender.Caption", DescriptionResourceItem = "Parameters.Sender.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Recepient", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.Recepient.Caption", DescriptionResourceItem = "Parameters.Recepient.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CopyRecepient", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.CopyRecepient.Caption", DescriptionResourceItem = "Parameters.CopyRecepient.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "BlindCopyRecepient", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.BlindCopyRecepient.Caption", DescriptionResourceItem = "Parameters.BlindCopyRecepient.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Subject", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.Subject.Caption", DescriptionResourceItem = "Parameters.Subject.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Body", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.Body.Caption", DescriptionResourceItem = "Parameters.Body.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Importance", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.Importance.Caption", DescriptionResourceItem = "Parameters.Importance.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsIgnoreErrors", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b749e6e7cde44a2eade00b8cf36b0926", CaptionResourceItem = "Parameters.IsIgnoreErrors.Caption", DescriptionResourceItem = "Parameters.IsIgnoreErrors.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SendEmailUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public SendEmailUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926");
		}

		#endregion

		#region Properties: Public

		public virtual Guid Sender {
			get;
			set;
		}

		public virtual string Recepient {
			get;
			set;
		}

		public virtual string CopyRecepient {
			get;
			set;
		}

		public virtual string BlindCopyRecepient {
			get;
			set;
		}

		private LocalizableString _subject;
		public virtual LocalizableString Subject {
			get {
				return _subject ?? (_subject = new LocalizableString());
			}
			set {
				_subject = value;
			}
		}

		private LocalizableString _body;
		public virtual LocalizableString Body {
			get {
				return _body ?? (_body = new LocalizableString());
			}
			set {
				_body = value;
			}
		}

		private int _importance = 1;
		public virtual int Importance {
			get {
				return _importance;
			}
			set {
				_importance = value;
			}
		}

		private bool _isIgnoreErrors = true;
		public virtual bool IsIgnoreErrors {
			get {
				return _isIgnoreErrors;
			}
			set {
				_isIgnoreErrors = value;
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
				if (Recepient == null) {
							return true;
						}
						var from = GetSenderName(Sender);
						List<string> recepients = GetEmailAddresses(Recepient);
						var emailPriority = (EmailPriority)Importance;
						List<string> ccRecipients = GetEmailAddresses(CopyRecepient);
						List<string> bccRecipients = GetEmailAddresses(BlindCopyRecepient);
						var message = new EmailMessage {
							From = from,
							To = recepients,
							Subject = Subject,
							Body = Body,
							Priority = emailPriority,
							Cc = ccRecipients,
							Bcc = bccRecipients
						};
						if (from.IsEmpty()) {
							SendEmailWithDefaultSender(message);
							return true;
						}
						var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection",
							UserConnection));
						var emailSender = new EmailSender(emailClientFactory, UserConnection);
						try {
							emailSender.Send(message);
						} catch {
							if (!IsIgnoreErrors) {
								throw;
							}
						}
						return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public virtual List<string> GetEmailAddresses(string addresses) {
						if (string.IsNullOrEmpty(addresses)) {
							return new List<string>();
						}
						var separators = new char[] { ';', ',' };
						return addresses.Split(separators)
							.Select(x => x.Trim())
							.Where(x => !string.IsNullOrEmpty(x))
							.ToList();
		}

		public virtual string GetSenderName(Guid mailboxId) {
						var mailboxTableESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "MailboxSyncSettings");
						var senderEmailAddressColumn = mailboxTableESQ.AddColumn("SenderEmailAddress");
						mailboxTableESQ.Filters.Add(mailboxTableESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", mailboxId));
						var mailboxEntities = mailboxTableESQ.GetEntityCollection(UserConnection);
						if (mailboxEntities.Count > 0) {
							return mailboxEntities[0].GetTypedColumnValue<string>(senderEmailAddressColumn.Name);
						}
						return "";
					
		}

		public virtual void SendEmailWithDefaultSender(EmailMessage emailMessage) {
			ConstructorArgument userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
			IEmailClientFactory emailClientFactory = ClassFactory.Get<EmailClientFactory>(userConnectionArg);
			if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
				try {
					var sender = new ActivityEmailSender(emailClientFactory, UserConnection);
					sender.Send(emailMessage, true);
				} catch {
					if (!IsIgnoreErrors) {
						throw;
					}
				}
			} else {
				var credentials = new BPMSoft.Mail.MailCredentials {
					Host = (string)Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpHost"),
					Port = int.Parse(Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpPort").ToString()),
					UseSsl = (bool)Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpEnableSsl"),
					UserName = (string)Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpUserName"),
					UserPassword = (string)Core.Configuration.SysSettings.GetValue(UserConnection, "SmtpUserPassword")
				};
				try {
					var emailClientFactoryArg = new ConstructorArgument("emailClientFactory", emailClientFactory);
					var emailSener = ClassFactory.Get<IEmailSender>(emailClientFactoryArg, userConnectionArg);
					emailSener.Send(emailMessage, credentials);
				} catch {
					if (!IsIgnoreErrors) {
						throw;
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
			if (!HasMapping("Sender")) {
				writer.WriteValue("Sender", Sender, Guid.Empty);
			}
			if (!HasMapping("Recepient")) {
				writer.WriteValue("Recepient", Recepient, null);
			}
			if (!HasMapping("CopyRecepient")) {
				writer.WriteValue("CopyRecepient", CopyRecepient, null);
			}
			if (!HasMapping("BlindCopyRecepient")) {
				writer.WriteValue("BlindCopyRecepient", BlindCopyRecepient, null);
			}
			if (!HasMapping("Importance")) {
				writer.WriteValue("Importance", Importance, 0);
			}
			if (!HasMapping("IsIgnoreErrors")) {
				writer.WriteValue("IsIgnoreErrors", IsIgnoreErrors, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Sender":
					Sender = reader.GetGuidValue();
				break;
				case "Recepient":
					Recepient = reader.GetStringValue();
				break;
				case "CopyRecepient":
					CopyRecepient = reader.GetStringValue();
				break;
				case "BlindCopyRecepient":
					BlindCopyRecepient = reader.GetStringValue();
				break;
				case "Subject":
					Subject = reader.GetLocalizableStringValue();
				break;
				case "Body":
					Body = reader.GetLocalizableStringValue();
				break;
				case "Importance":
					Importance = reader.GetIntValue();
				break;
				case "IsIgnoreErrors":
					IsIgnoreErrors = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

