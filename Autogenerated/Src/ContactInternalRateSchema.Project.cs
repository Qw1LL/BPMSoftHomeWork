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

	#region Class: ContactInternalRateSchema

	/// <exclude/>
	public class ContactInternalRateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContactInternalRateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactInternalRateSchema(ContactInternalRateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactInternalRateSchema(ContactInternalRateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			RealUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			Name = "ContactInternalRate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5187aba0-4cb3-4b4c-9749-12155cf1f8be")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("1026ea1d-5c1d-4387-ae30-51a2ccc30d0d")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("45c85960-b456-4c35-bd32-7b1a003916c4")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("2ca15d8b-d409-4544-958c-90a36bd441e8")) == null) {
				Columns.Add(CreateRateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5187aba0-4cb3-4b4c-9749-12155cf1f8be"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("1026ea1d-5c1d-4387-ae30-51a2ccc30d0d"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("45c85960-b456-4c35-bd32-7b1a003916c4"),
				Name = @"DueDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc")
			};
		}

		protected virtual EntitySchemaColumn CreateRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("2ca15d8b-d409-4544-958c-90a36bd441e8"),
				Name = @"Rate",
				CreatedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				ModifiedInSchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"),
				CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactInternalRate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactInternalRate_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactInternalRateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactInternalRateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactInternalRate

	/// <summary>
	/// Внутренняя ставка сотрудника.
	/// </summary>
	public class ContactInternalRate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContactInternalRate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactInternalRate";
		}

		public ContactInternalRate(ContactInternalRate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Cотрудник.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// С.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// По.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Ставка, б.в.
		/// </summary>
		public Decimal Rate {
			get {
				return GetTypedColumnValue<Decimal>("Rate");
			}
			set {
				SetColumnValue("Rate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactInternalRate_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactInternalRateDeleted", e);
			Inserting += (s, e) => ThrowEvent("ContactInternalRateInserting", e);
			Validating += (s, e) => ThrowEvent("ContactInternalRateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactInternalRate(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactInternalRate_ProjectEventsProcess

	/// <exclude/>
	public partial class ContactInternalRate_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContactInternalRate
	{

		public ContactInternalRate_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactInternalRate_ProjectEventsProcess";
			SchemaUId = new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5f9c3e78-8e43-4222-bac8-64f48bb6da3c");
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

	#region Class: ContactInternalRate_ProjectEventsProcess

	/// <exclude/>
	public class ContactInternalRate_ProjectEventsProcess : ContactInternalRate_ProjectEventsProcess<ContactInternalRate>
	{

		public ContactInternalRate_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactInternalRate_ProjectEventsProcess

	public partial class ContactInternalRate_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactInternalRateEventsProcess

	/// <exclude/>
	public class ContactInternalRateEventsProcess : ContactInternalRate_ProjectEventsProcess
	{

		public ContactInternalRateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

