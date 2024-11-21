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

	#region Class: ContactCorrespondenceSchema

	/// <exclude/>
	public class ContactCorrespondenceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContactCorrespondenceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactCorrespondenceSchema(ContactCorrespondenceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactCorrespondenceSchema(ContactCorrespondenceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			RealUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			Name = "ContactCorrespondence";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1283089a-a4ff-4c97-9007-af5fe276bdde")) == null) {
				Columns.Add(CreateSourceContactIdColumn());
			}
			if (Columns.FindByUId(new Guid("811c39ae-0996-44e6-b581-273b1a9ff65e")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("0438f5bf-2e14-4866-b679-70f55be1bfae")) == null) {
				Columns.Add(CreateSourceAccountColumn());
			}
			if (Columns.FindByUId(new Guid("f2f8c264-0a7f-49ef-aa75-48f6443b2d0d")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("92306301-054b-43d3-8e19-6443cbb77ad1")) == null) {
				Columns.Add(CreateIsDeletedColumn());
			}
			if (Columns.FindByUId(new Guid("a11c226f-20c4-426b-838a-3efe54afd2d9")) == null) {
				Columns.Add(CreateSocialAccountNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSourceContactIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("1283089a-a4ff-4c97-9007-af5fe276bdde"),
				Name = @"SourceContactId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("811c39ae-0996-44e6-b581-273b1a9ff65e"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0438f5bf-2e14-4866-b679-70f55be1bfae"),
				Name = @"SourceAccount",
				ReferenceSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f2f8c264-0a7f-49ef-aa75-48f6443b2d0d"),
				Name = @"Source",
				ReferenceSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDeletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("92306301-054b-43d3-8e19-6443cbb77ad1"),
				Name = @"IsDeleted",
				CreatedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialAccountNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a11c226f-20c4-426b-838a-3efe54afd2d9"),
				Name = @"SocialAccountName",
				CreatedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				ModifiedInSchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"),
				CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactCorrespondence(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactCorrespondence_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactCorrespondenceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactCorrespondenceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactCorrespondence

	/// <summary>
	/// Contact in External Resources.
	/// </summary>
	public class ContactCorrespondence : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContactCorrespondence(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactCorrespondence";
		}

		public ContactCorrespondence(ContactCorrespondence source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// External Resource Contact ID.
		/// </summary>
		public string SourceContactId {
			get {
				return GetTypedColumnValue<string>("SourceContactId");
			}
			set {
				SetColumnValue("SourceContactId", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid SourceAccountId {
			get {
				return GetTypedColumnValue<Guid>("SourceAccountId");
			}
			set {
				SetColumnValue("SourceAccountId", value);
				_sourceAccount = null;
			}
		}

		/// <exclude/>
		public string SourceAccountLogin {
			get {
				return GetTypedColumnValue<string>("SourceAccountLogin");
			}
			set {
				SetColumnValue("SourceAccountLogin", value);
				if (_sourceAccount != null) {
					_sourceAccount.Login = value;
				}
			}
		}

		private SocialAccount _sourceAccount;
		/// <summary>
		/// External Resource User Account ID.
		/// </summary>
		public SocialAccount SourceAccount {
			get {
				return _sourceAccount ??
					(_sourceAccount = LookupColumnEntities.GetEntity("SourceAccount") as SocialAccount);
			}
		}

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private CommunicationType _source;
		/// <summary>
		/// Resource.
		/// </summary>
		public CommunicationType Source {
			get {
				return _source ??
					(_source = LookupColumnEntities.GetEntity("Source") as CommunicationType);
			}
		}

		/// <summary>
		/// Deleted.
		/// </summary>
		public bool IsDeleted {
			get {
				return GetTypedColumnValue<bool>("IsDeleted");
			}
			set {
				SetColumnValue("IsDeleted", value);
			}
		}

		/// <summary>
		/// Social account name.
		/// </summary>
		public string SocialAccountName {
			get {
				return GetTypedColumnValue<string>("SocialAccountName");
			}
			set {
				SetColumnValue("SocialAccountName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactCorrespondence_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactCorrespondenceDeleted", e);
			Inserting += (s, e) => ThrowEvent("ContactCorrespondenceInserting", e);
			Validating += (s, e) => ThrowEvent("ContactCorrespondenceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactCorrespondence(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCorrespondence_BaseEventsProcess

	/// <exclude/>
	public partial class ContactCorrespondence_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContactCorrespondence
	{

		public ContactCorrespondence_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactCorrespondence_BaseEventsProcess";
			SchemaUId = new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fc7305a2-ef55-4d53-9f55-4ed4744d37c4");
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

	#region Class: ContactCorrespondence_BaseEventsProcess

	/// <exclude/>
	public class ContactCorrespondence_BaseEventsProcess : ContactCorrespondence_BaseEventsProcess<ContactCorrespondence>
	{

		public ContactCorrespondence_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactCorrespondence_BaseEventsProcess

	public partial class ContactCorrespondence_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactCorrespondenceEventsProcess

	/// <exclude/>
	public class ContactCorrespondenceEventsProcess : ContactCorrespondence_BaseEventsProcess
	{

		public ContactCorrespondenceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

