namespace BPMSoft.Configuration
{

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

	#region Class: ContactCommunicationSchema

	/// <exclude/>
	public class ContactCommunicationSchema : BPMSoft.Configuration.ContactCommunication_SSP_BPMSoftSchema
	{

		#region Constructors: Public

		public ContactCommunicationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactCommunicationSchema(ContactCommunicationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactCommunicationSchema(ContactCommunicationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46");
			Name = "ContactCommunication";
			ParentSchemaUId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
			ExtendParent = true;
			CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ad63b6ff-8842-4d58-ba4a-8e4ff366964b")) == null) {
				Columns.Add(CreateNonActualColumn());
			}
			if (Columns.FindByUId(new Guid("88fe3140-5c42-4b10-898a-95b988e40720")) == null) {
				Columns.Add(CreateNonActualReasonColumn());
			}
			if (Columns.FindByUId(new Guid("dfed1095-db33-4c53-9a03-6fa884b9cc3f")) == null) {
				Columns.Add(CreateDateSetNonActualColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNonActualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ad63b6ff-8842-4d58-ba4a-8e4ff366964b"),
				Name = @"NonActual",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46"),
				ModifiedInSchemaUId = new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46"),
				CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b")
			};
		}

		protected virtual EntitySchemaColumn CreateNonActualReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("88fe3140-5c42-4b10-898a-95b988e40720"),
				Name = @"NonActualReason",
				ReferenceSchemaUId = new Guid("88029a14-efa8-4fa9-9c87-e5131319caef"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46"),
				ModifiedInSchemaUId = new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46"),
				CreatedInPackageId = new Guid("23e6b872-7cf2-4336-8046-3b06c9b28cbc")
			};
		}

		protected virtual EntitySchemaColumn CreateDateSetNonActualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("dfed1095-db33-4c53-9a03-6fa884b9cc3f"),
				Name = @"DateSetNonActual",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46"),
				ModifiedInSchemaUId = new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46"),
				CreatedInPackageId = new Guid("23e6b872-7cf2-4336-8046-3b06c9b28cbc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactCommunication(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactCommunication_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactCommunicationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactCommunicationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactCommunication

	/// <summary>
	/// Средство связи контакта.
	/// </summary>
	public class ContactCommunication : BPMSoft.Configuration.ContactCommunication_SSP_BPMSoft
	{

		#region Constructors: Public

		public ContactCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactCommunication";
		}

		public ContactCommunication(ContactCommunication source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Не актуальный.
		/// </summary>
		public bool NonActual {
			get {
				return GetTypedColumnValue<bool>("NonActual");
			}
			set {
				SetColumnValue("NonActual", value);
			}
		}

		/// <exclude/>
		public Guid NonActualReasonId {
			get {
				return GetTypedColumnValue<Guid>("NonActualReasonId");
			}
			set {
				SetColumnValue("NonActualReasonId", value);
				_nonActualReason = null;
			}
		}

		/// <exclude/>
		public string NonActualReasonName {
			get {
				return GetTypedColumnValue<string>("NonActualReasonName");
			}
			set {
				SetColumnValue("NonActualReasonName", value);
				if (_nonActualReason != null) {
					_nonActualReason.Name = value;
				}
			}
		}

		private NonActualReason _nonActualReason;
		/// <summary>
		/// Причина неактуальности.
		/// </summary>
		public NonActualReason NonActualReason {
			get {
				return _nonActualReason ??
					(_nonActualReason = LookupColumnEntities.GetEntity("NonActualReason") as NonActualReason);
			}
		}

		/// <summary>
		/// Не актуален с.
		/// </summary>
		public DateTime DateSetNonActual {
			get {
				return GetTypedColumnValue<DateTime>("DateSetNonActual");
			}
			set {
				SetColumnValue("DateSetNonActual", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactCommunication_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactCommunication(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCommunication_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class ContactCommunication_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.ContactCommunication_SSPEventsProcess<TEntity> where TEntity : ContactCommunication
	{

		public ContactCommunication_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactCommunication_MarketingCampaignEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e8a3ae69-cdec-485b-b17c-0a9a38443d46");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid OldCommunicationTypeId {
			get;
			set;
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCommunication_MarketingCampaignEventsProcess

	/// <exclude/>
	public class ContactCommunication_MarketingCampaignEventsProcess : ContactCommunication_MarketingCampaignEventsProcess<ContactCommunication>
	{

		public ContactCommunication_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactCommunication_MarketingCampaignEventsProcess

	public partial class ContactCommunication_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void SetNewContactCommunication() {
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			var contactESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			contactESQ.AddAllSchemaColumns();
			var contact = contactESQ.GetEntity(UserConnection, contactId);
			if (contact != null) {
				var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId").ToString();
				var number = Entity.GetTypedColumnValue<string>("Number");
				var socialColumnValue = Entity.GetTypedColumnValue<string>("SocialMediaId");
				var isPrimary = Entity.GetTypedColumnValue<bool>("IsCreatedBySynchronization");
				var typeColumnName = string.Empty;
				var socialColumnName = string.Empty;
				switch (communicationTypeId) {
					case CommunicationTypeConsts.LinkedInId:
				 		typeColumnName = "LinkedIn";
						socialColumnName = "LinkedInId";
						break;
					case CommunicationTypeConsts.TwitterId:
						typeColumnName = "Twitter";
						socialColumnName = "TwitterId";
						break;
					case CommunicationTypeConsts.FacebookId:
						typeColumnName = "Facebook";
						socialColumnName = "FacebookId";
						break;
					case CommunicationTypeConsts.EmailId:
						typeColumnName = "Email";
						break;
					case CommunicationTypeConsts.SkypeId:
				 		typeColumnName = "Skype";
						break;
					case CommunicationTypeConsts.HomePhoneId:
						typeColumnName = "HomePhone";
						break;
					case CommunicationTypeConsts.MobilePhoneId:
						typeColumnName = "MobilePhone";
						break;
					case CommunicationTypeConsts.WorkPhoneId:
						typeColumnName = "Phone";
						break;
					case CommunicationTypeConsts.WebId:
						typeColumnName = "Web";
						break;
				}
				if (!typeColumnName.Equals(string.Empty)) {
					bool isCanEdit = GetCanEditColumn("Contact", typeColumnName);
					if (!isCanEdit) {
						return;
					}
					bool isCurrentTypeEmail = communicationTypeId.Equals(CommunicationTypeConsts.EmailId);
					bool isOldTypeEmail = OldCommunicationTypeId.ToString().Equals(CommunicationTypeConsts.EmailId);
					bool isCurrentTypeWeb = communicationTypeId.Equals(CommunicationTypeConsts.WebId);
					bool isNotEmailOrWeb = !isCurrentTypeEmail && !isCurrentTypeWeb;
					if (!(isCurrentTypeEmail || isOldTypeEmail) && !isNotEmailOrWeb) {
						return;
					}
					string currentContactCommunicationValue = contact.GetTypedColumnValue<string>(typeColumnName);
					var update = new Update(UserConnection, "Contact") as Update;
					if (isCurrentTypeEmail || isOldTypeEmail) {
							KeyValuePair<string, bool> kvp = GetActualContactEmail(contactId);
							if(!currentContactCommunicationValue.Equals(kvp.Key)) {
								update.Set("Email", Column.Parameter(kvp.Key));
							}
							update.Set("IsNonActualEmail", Column.Parameter(kvp.Value));
					}
					if (isNotEmailOrWeb) {
						if (!currentContactCommunicationValue.Equals(number) && isPrimary) {
							update.Set(typeColumnName, Column.Parameter(number));
							if (!socialColumnName.Equals(string.Empty)) {
								update.Set(socialColumnName, Column.Parameter(socialColumnValue));
							}
						} else if (!isOldTypeEmail) {
							return;
						}
					}
					update.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow));
					update.Where("Id").IsEqual(Column.Parameter(contactId));
					update.Execute();
				}
			}
		}

		public override void ClearOldContactCommunication() {
			if (Entity.GetIsColumnValueLoaded("NonActual")) {
				bool nonActual = Entity.GetTypedColumnValue<bool>("NonActual");
				if (!nonActual) {
					Entity.SetColumnValue("NonActualReasonId", null);
					Entity.SetColumnValue("DateSetNonActual", null);
				} else {
					bool typeChanged = Entity.GetChangedColumnValues().Any(column => column.Name == "CommunicationTypeId");
					if (typeChanged) {
						Entity.SetColumnValue("NonActualReasonId", MarketingConsts.ManuallyNonActualReasonId);
					}
				}
			}
			OldCommunicationTypeId = Entity.GetTypedOldColumnValue<Guid>("CommunicationTypeId");
			base.ClearOldContactCommunication();
		}

		public override void OnContactCommunicationDeleted() {
			var contactESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			EntitySchemaQueryColumn communicationColumn = null;
			EntitySchemaQueryColumn communicationIdColumn = null;
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			var number = Entity.GetTypedColumnValue<string>("Number");
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId").ToString();
			var isPrimary = Entity.GetTypedColumnValue<bool>("IsCreatedBySynchronization");
			switch (communicationTypeId) {
				case CommunicationTypeConsts.LinkedInId:
					communicationColumn = contactESQ.AddColumn("LinkedIn");
					communicationIdColumn = contactESQ.AddColumn("LinkedInId");
					break;
				case CommunicationTypeConsts.TwitterId:
					communicationColumn = contactESQ.AddColumn("Twitter");
					communicationIdColumn = contactESQ.AddColumn("TwitterId");
					break;
				case CommunicationTypeConsts.FacebookId:
					communicationColumn = contactESQ.AddColumn("Facebook");
					communicationIdColumn = contactESQ.AddColumn("FacebookId");
					break;
				case CommunicationTypeConsts.EmailId:
					communicationColumn = contactESQ.AddColumn("Email");
					break;
				case CommunicationTypeConsts.SkypeId:
					communicationColumn = contactESQ.AddColumn("Skype");
					break;
				case CommunicationTypeConsts.HomePhoneId:
					communicationColumn = contactESQ.AddColumn("HomePhone");
					break;
				case CommunicationTypeConsts.MobilePhoneId:
					communicationColumn = contactESQ.AddColumn("MobilePhone");
					break;
				case CommunicationTypeConsts.WorkPhoneId:
					communicationColumn = contactESQ.AddColumn("Phone");
					break;
				default:
					return;
			}
			contactESQ.AddAllSchemaColumns();
			var contactEntity = contactESQ.GetEntity(UserConnection, contactId);
			if (contactEntity != null) {
				var value = contactEntity.GetTypedColumnValue<string>(communicationColumn.Name);
				if (value.Equals(number)) {
					string contactCommunicationValue = string.Empty;
					if (communicationTypeId.Equals(CommunicationTypeConsts.EmailId)) {
						KeyValuePair<string, bool> kvp = GetActualContactEmail(contactId);
						contactCommunicationValue = kvp.Key;
						contactEntity.SetColumnValue("IsNonActualEmail", kvp.Value);
					}
					if (isPrimary) {
						contactEntity.SetColumnValue(communicationColumn.Name, contactCommunicationValue);
						if (communicationIdColumn != null) {
							contactEntity.SetColumnValue(communicationIdColumn.Name, string.Empty);
						}
					}
					contactEntity.Save();
				}
			}
		}

		public virtual KeyValuePair<string, bool> GetActualContactEmail(Guid contactId) {
			KeyValuePair<string, bool> result = new KeyValuePair<string, bool>(string.Empty, false);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactCommunication");
			esq.RowCount = 1;
			EntitySchemaQueryColumn nonActualColumn = esq.AddColumn("NonActual").OrderByAsc(1);
			EntitySchemaQueryColumn orderByDescColumn = esq.AddColumn("CreatedOn").OrderByDesc(2);
			EntitySchemaQueryColumn numberColumn = esq.AddColumn("Number");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "CommunicationType", 
				CommunicationTypeConsts.EmailId));
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			foreach (Entity entity in entityCollection) {
				return new KeyValuePair<string, bool>(entity.GetTypedColumnValue<string>(numberColumn.Name), 
					 entity.GetTypedColumnValue<bool>(nonActualColumn.Name));
			}
			return result;
		}

		public override void OnContactCommunicationSaving() {
			base.OnContactCommunicationSaving();
			if (Entity.GetTypedColumnValue<bool>("NonActual")) {
			                Entity.SetColumnValue("IsCreatedBySynchronization", false);
			}
		}

		#endregion

	}

	#endregion


	#region Class: ContactCommunicationEventsProcess

	/// <exclude/>
	public class ContactCommunicationEventsProcess : ContactCommunication_MarketingCampaignEventsProcess
	{

		public ContactCommunicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

