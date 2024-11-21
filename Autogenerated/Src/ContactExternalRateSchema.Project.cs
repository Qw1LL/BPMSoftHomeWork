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

	#region Class: ContactExternalRateSchema

	/// <exclude/>
	public class ContactExternalRateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContactExternalRateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactExternalRateSchema(ContactExternalRateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactExternalRateSchema(ContactExternalRateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			RealUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			Name = "ContactExternalRate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("156e609a-7dbd-4e26-afe8-e5fa96196410")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("13baab65-1b9c-4f7a-a054-8871d821ce08")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("ea66df6e-c03e-422d-9eb7-651363235ce6")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("a2c99f8a-c4ed-4b95-8ecf-9e774aa30eb3")) == null) {
				Columns.Add(CreateRateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			column.CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("156e609a-7dbd-4e26-afe8-e5fa96196410"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
				ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
				CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("13baab65-1b9c-4f7a-a054-8871d821ce08"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
				ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
				CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("ea66df6e-c03e-422d-9eb7-651363235ce6"),
				Name = @"DueDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
				ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
				CreatedInPackageId = new Guid("9f3f8b4f-d8ea-42e7-81d3-d7cfd66c54fc")
			};
		}

		protected virtual EntitySchemaColumn CreateRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("a2c99f8a-c4ed-4b95-8ecf-9e774aa30eb3"),
				Name = @"Rate",
				CreatedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
				ModifiedInSchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"),
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
			return new ContactExternalRate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactExternalRate_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactExternalRateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactExternalRateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactExternalRate

	/// <summary>
	/// Внешняя ставка сотрудника.
	/// </summary>
	public class ContactExternalRate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContactExternalRate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactExternalRate";
		}

		public ContactExternalRate(ContactExternalRate source)
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
		/// Сотрудник.
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
			var process = new ContactExternalRate_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactExternalRateDeleted", e);
			Inserting += (s, e) => ThrowEvent("ContactExternalRateInserting", e);
			Validating += (s, e) => ThrowEvent("ContactExternalRateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactExternalRate(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactExternalRate_ProjectEventsProcess

	/// <exclude/>
	public partial class ContactExternalRate_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContactExternalRate
	{

		public ContactExternalRate_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactExternalRate_ProjectEventsProcess";
			SchemaUId = new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7533ac53-9aae-4fb8-9b2b-2166a81d669c");
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

	#region Class: ContactExternalRate_ProjectEventsProcess

	/// <exclude/>
	public class ContactExternalRate_ProjectEventsProcess : ContactExternalRate_ProjectEventsProcess<ContactExternalRate>
	{

		public ContactExternalRate_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactExternalRate_ProjectEventsProcess

	public partial class ContactExternalRate_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactExternalRateEventsProcess

	/// <exclude/>
	public class ContactExternalRateEventsProcess : ContactExternalRate_ProjectEventsProcess
	{

		public ContactExternalRateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

