namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: ContactCommunication_BaseEventsProcess

	public partial class ContactCommunication_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void SetNewContactCommunication() {
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(communicationTypeId);
			string typedColumnName = columnNames["TypeColumnName"];
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			UpdateCommunicationParentEntity("Contact", contactId, typedColumnName);
		}

		public virtual void ClearOldContactCommunication() {
			var oldCommunicationTypeId = Entity.GetTypedOldColumnValue<Guid>("CommunicationTypeId");
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			if (!oldCommunicationTypeId.Equals(Guid.Empty) && !oldCommunicationTypeId.Equals(communicationTypeId)) {
				ActualizePrimaryState();
				Entity.SetColumnValue("IsCreatedBySynchronization", true);
				var columnName = string.Empty;
				Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(oldCommunicationTypeId);
				var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
				string typedColumnName = columnNames["TypeColumnName"];
				string newCommunicationValue = Entity.GetTypedColumnValue<string>("Number");
				bool isCanEdit = GetCanEditColumn("Contact", typedColumnName);
				if (isCanEdit && !string.IsNullOrEmpty(typedColumnName)) {
					var update = new Update(UserConnection, "Contact")
					.Set(typedColumnName, Column.Const(string.Empty))
					.Where("Id").IsEqual(Column.Parameter(contactId)).And(typedColumnName).IsEqual(Column.Parameter(newCommunicationValue));
					update.Execute();
				}
			}
		}

		public virtual void OnContactCommunicationDeleted() {
			Guid contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			string number = Entity.GetTypedColumnValue<string>("Number");
			Guid communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			bool isPrimary = Entity.GetTypedColumnValue<bool>("IsCreatedBySynchronization");
			Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(communicationTypeId);
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var contactEntity = contactSchema.CreateEntity(UserConnection);
			string typedColumnName = columnNames["TypeColumnName"];
			string socialColumnName = columnNames["SocialColumnName"];
			bool isCanEdit = GetCanEditColumn("Contact", typedColumnName);
			if (contactEntity.FetchFromDB(contactId) && isPrimary) {
				if (isCanEdit && !string.IsNullOrEmpty(typedColumnName)) {
					string value = contactEntity.GetTypedColumnValue<string>(typedColumnName);
					if (value == number) {
						contactEntity.SetColumnValue(typedColumnName, string.Empty);
						if (!string.IsNullOrEmpty(socialColumnName)) {
							contactEntity.SetColumnValue(socialColumnName, string.Empty);
						}
					}
				}
				contactEntity.SetColumnValue("ModifiedOn", DateTime.UtcNow);
				contactEntity.Save();
			}
		}

		public virtual Dictionary<string, string> GetColumnNameByCommunicationType(Guid communicationType) {
			var values = new Dictionary<string, string>();
			values.Add("TypeColumnName", string.Empty);
			values.Add("SocialColumnName", string.Empty);
			switch (communicationType.ToString()) {
				case CommunicationTypeConsts.LinkedInId:
			 		values["TypeColumnName"] = "LinkedIn";
					values["SocialColumnName"] = "LinkedInId";
					break;
				case CommunicationTypeConsts.TwitterId:
					values["TypeColumnName"] = "Twitter";
					values["SocialColumnName"] = "TwitterId";
					break;
				case CommunicationTypeConsts.FacebookId:
					values["TypeColumnName"] = "Facebook";
					values["SocialColumnName"] = "FacebookId";
					break;
				case CommunicationTypeConsts.EmailId:
					values["TypeColumnName"] = "Email";
					break;
				case CommunicationTypeConsts.SkypeId:
			 		values["TypeColumnName"] = "Skype";
					break;
				case CommunicationTypeConsts.HomePhoneId:
					values["TypeColumnName"] = "HomePhone";
					break;
				case CommunicationTypeConsts.MobilePhoneId:
					values["TypeColumnName"] = "MobilePhone";
					break;
				case CommunicationTypeConsts.WorkPhoneId:
					values["TypeColumnName"] = "Phone";
					break;
			}
			return values;
		}

		public virtual void ActualizeExternalCommunicationType() {
			if (Entity.GetTypedOldColumnValue<Guid>("CommunicationTypeId") != Entity.GetTypedColumnValue<Guid>("CommunicationTypeId")) {
				Entity.SetColumnValue("ExternalCommunicationType", string.Empty);
			}
		}

		public virtual void OnContactCommunicationSaving() {
			IsNew = GetIsNew();
			if (IsNew) {
				ActualizePrimaryState();
				Entity.SetColumnValue("IsCreatedBySynchronization", true);
			} else {
				ClearOldContactCommunication();
			}
		}

		public virtual void ActualizePrimaryState() {
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			
			var update = new Update(UserConnection, "ContactCommunication")
				.Set("IsCreatedBySynchronization", Column.Parameter(false))
			.Where("ContactId").IsEqual(Column.Parameter(contactId))
			.And("CommunicationTypeId").IsEqual(Column.Parameter(communicationTypeId)) as Update;
			update.Execute();
		}

		public virtual bool GetIsNew() {
			string oldNumber = Entity.GetTypedOldColumnValue<string>("Number");
			string newNumber = Entity.GetTypedColumnValue<string>("Number");
			return (string.IsNullOrEmpty(oldNumber) && !newNumber.Equals(oldNumber));
		}

		public virtual void RemoveDuplicates() {
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			var number = Entity.GetTypedColumnValue<string>("Number");
			var id = Entity.GetTypedColumnValue<Guid>("Id");
			var del = new Delete(UserConnection).From("ContactCommunication")
				.Where("ContactId").IsEqual(Column.Parameter(contactId)).
				And("CommunicationTypeId").IsEqual(Column.Parameter(communicationTypeId)).
				And("Number").IsEqual(Column.Parameter(number)).
				And("Id").Not().IsEqual(Column.Parameter(id)) as Delete;
			del.Execute();
		}

		public override void SetCommunicationParentEntityColumns(Entity parentEntity) {
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(communicationTypeId);
			string typedColumnName = columnNames["TypeColumnName"];
			string socialColumnName = columnNames["SocialColumnName"];
			var socialColumnValue = Entity.GetTypedColumnValue<string>("SocialMediaId");
			var isPrimary = Entity.GetTypedColumnValue<bool>("IsCreatedBySynchronization");
			if (string.IsNullOrEmpty(typedColumnName) || !isPrimary) {
				return;
			}
			var number = Entity.GetTypedColumnValue<string>("Number");
			parentEntity.SetColumnValue(typedColumnName, number);
			if (!string.IsNullOrEmpty(socialColumnName)) {
				parentEntity.SetColumnValue(socialColumnName, socialColumnValue);
			}
		}

		#endregion

	}

	#endregion

}

