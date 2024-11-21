namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
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

	#region Class: ContactFolderSchema

	/// <exclude/>
	public class ContactFolderSchema : BPMSoft.Configuration.ContactFolder_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public ContactFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactFolderSchema(ContactFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactFolderSchema(ContactFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("aa35afc4-cb11-42a9-b17e-2ffef173eeb6");
			Name = "ContactFolder";
			ParentSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d85e35ee-2806-46ef-b091-5e59d47f9067");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4734b415-deb5-458f-a5e2-25326d8246cd")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4734b415-deb5-458f-a5e2-25326d8246cd"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("aa35afc4-cb11-42a9-b17e-2ffef173eeb6"),
				ModifiedInSchemaUId = new Guid("aa35afc4-cb11-42a9-b17e-2ffef173eeb6"),
				CreatedInPackageId = new Guid("d85e35ee-2806-46ef-b091-5e59d47f9067")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactFolder_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aa35afc4-cb11-42a9-b17e-2ffef173eeb6"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactFolder

	/// <summary>
	/// Группа контакта.
	/// </summary>
	public class ContactFolder : BPMSoft.Configuration.ContactFolder_Base_BPMSoft
	{

		#region Constructors: Public

		public ContactFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactFolder";
		}

		public ContactFolder(ContactFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactFolder_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("ContactFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactFolder_CampaignsEventsProcess

	/// <exclude/>
	public partial class ContactFolder_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.ContactFolder_BaseEventsProcess<TEntity> where TEntity : ContactFolder
	{

		public ContactFolder_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactFolder_CampaignsEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("aa35afc4-cb11-42a9-b17e-2ffef173eeb6");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
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

	#region Class: ContactFolder_CampaignsEventsProcess

	/// <exclude/>
	public class ContactFolder_CampaignsEventsProcess : ContactFolder_CampaignsEventsProcess<ContactFolder>
	{

		public ContactFolder_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactFolder_CampaignsEventsProcess

	public partial class ContactFolder_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactFolderEventsProcess

	/// <exclude/>
	public class ContactFolderEventsProcess : ContactFolder_CampaignsEventsProcess
	{

		public ContactFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

