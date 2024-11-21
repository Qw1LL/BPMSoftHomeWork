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

	#region Class: VwAnniversarySchema

	/// <exclude/>
	public class VwAnniversarySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwAnniversarySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwAnniversarySchema(VwAnniversarySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwAnniversarySchema(VwAnniversarySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			RealUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			Name = "VwAnniversary";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4e1dac3c-e1c7-48d2-aca5-8d464830f2e4")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("23ff3869-b4ee-465b-b5e1-c59d867c1838")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("e714bd7b-415c-4d06-8a9b-eaec0c08d07f")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("988f58e6-3577-416a-b979-37cbb5c05965")) == null) {
				Columns.Add(CreateAnniversaryTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("4e1dac3c-e1c7-48d2-aca5-8d464830f2e4"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("23ff3869-b4ee-465b-b5e1-c59d867c1838"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e714bd7b-415c-4d06-8a9b-eaec0c08d07f"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd")
			};
		}

		protected virtual EntitySchemaColumn CreateAnniversaryTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("988f58e6-3577-416a-b979-37cbb5c05965"),
				Name = @"AnniversaryType",
				ReferenceSchemaUId = new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				ModifiedInSchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"),
				CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwAnniversary(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwAnniversary_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwAnniversarySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwAnniversarySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb"));
		}

		#endregion

	}

	#endregion

	#region Class: VwAnniversary

	/// <summary>
	/// Noteworthy event.
	/// </summary>
	public class VwAnniversary : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwAnniversary(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwAnniversary";
		}

		public VwAnniversary(VwAnniversary source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
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
		public Guid AnniversaryTypeId {
			get {
				return GetTypedColumnValue<Guid>("AnniversaryTypeId");
			}
			set {
				SetColumnValue("AnniversaryTypeId", value);
				_anniversaryType = null;
			}
		}

		/// <exclude/>
		public string AnniversaryTypeName {
			get {
				return GetTypedColumnValue<string>("AnniversaryTypeName");
			}
			set {
				SetColumnValue("AnniversaryTypeName", value);
				if (_anniversaryType != null) {
					_anniversaryType.Name = value;
				}
			}
		}

		private AnniversaryType _anniversaryType;
		/// <summary>
		/// Noteworthy event type.
		/// </summary>
		public AnniversaryType AnniversaryType {
			get {
				return _anniversaryType ??
					(_anniversaryType = LookupColumnEntities.GetEntity("AnniversaryType") as AnniversaryType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwAnniversary_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwAnniversaryDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwAnniversaryInserting", e);
			Validating += (s, e) => ThrowEvent("VwAnniversaryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwAnniversary(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwAnniversary_NUIEventsProcess

	/// <exclude/>
	public partial class VwAnniversary_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwAnniversary
	{

		public VwAnniversary_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwAnniversary_NUIEventsProcess";
			SchemaUId = new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("303f5779-e867-4e1c-8fdc-e4768f15b4eb");
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

	#region Class: VwAnniversary_NUIEventsProcess

	/// <exclude/>
	public class VwAnniversary_NUIEventsProcess : VwAnniversary_NUIEventsProcess<VwAnniversary>
	{

		public VwAnniversary_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwAnniversary_NUIEventsProcess

	public partial class VwAnniversary_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwAnniversaryEventsProcess

	/// <exclude/>
	public class VwAnniversaryEventsProcess : VwAnniversary_NUIEventsProcess
	{

		public VwAnniversaryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

