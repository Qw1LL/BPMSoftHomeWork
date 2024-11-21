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

	#region Class: ContactDuplicateSchema

	/// <exclude/>
	public class ContactDuplicateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContactDuplicateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactDuplicateSchema(ContactDuplicateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactDuplicateSchema(ContactDuplicateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618");
			RealUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618");
			Name = "ContactDuplicate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cc21c727-a64d-4dfa-b262-6653230456eb")) == null) {
				Columns.Add(CreateEntity1Column());
			}
			if (Columns.FindByUId(new Guid("8f42ffab-f73e-4de7-a662-14fbd3b458ad")) == null) {
				Columns.Add(CreateEntity2Column());
			}
			if (Columns.FindByUId(new Guid("40ac7a9e-50b8-41ad-8282-d841f238d32d")) == null) {
				Columns.Add(CreateStatusOfDuplicateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntity1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cc21c727-a64d-4dfa-b262-6653230456eb"),
				Name = @"Entity1",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618"),
				ModifiedInSchemaUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateEntity2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8f42ffab-f73e-4de7-a662-14fbd3b458ad"),
				Name = @"Entity2",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618"),
				ModifiedInSchemaUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusOfDuplicateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("40ac7a9e-50b8-41ad-8282-d841f238d32d"),
				Name = @"StatusOfDuplicate",
				ReferenceSchemaUId = new Guid("590f25a6-b7bf-4ca0-816a-415e3518a148"),
				CreatedInSchemaUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618"),
				ModifiedInSchemaUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactDuplicate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactDuplicate_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactDuplicateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactDuplicateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("afd8d870-9c6a-4482-b90e-53682aed6618"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactDuplicate

	/// <summary>
	/// Contact duplicate.
	/// </summary>
	public class ContactDuplicate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContactDuplicate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactDuplicate";
		}

		public ContactDuplicate(ContactDuplicate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid Entity1Id {
			get {
				return GetTypedColumnValue<Guid>("Entity1Id");
			}
			set {
				SetColumnValue("Entity1Id", value);
				_entity1 = null;
			}
		}

		/// <exclude/>
		public string Entity1Name {
			get {
				return GetTypedColumnValue<string>("Entity1Name");
			}
			set {
				SetColumnValue("Entity1Name", value);
				if (_entity1 != null) {
					_entity1.Name = value;
				}
			}
		}

		private Contact _entity1;
		/// <summary>
		/// Record 1.
		/// </summary>
		public Contact Entity1 {
			get {
				return _entity1 ??
					(_entity1 = LookupColumnEntities.GetEntity("Entity1") as Contact);
			}
		}

		/// <exclude/>
		public Guid Entity2Id {
			get {
				return GetTypedColumnValue<Guid>("Entity2Id");
			}
			set {
				SetColumnValue("Entity2Id", value);
				_entity2 = null;
			}
		}

		/// <exclude/>
		public string Entity2Name {
			get {
				return GetTypedColumnValue<string>("Entity2Name");
			}
			set {
				SetColumnValue("Entity2Name", value);
				if (_entity2 != null) {
					_entity2.Name = value;
				}
			}
		}

		private Contact _entity2;
		/// <summary>
		/// Record 2.
		/// </summary>
		public Contact Entity2 {
			get {
				return _entity2 ??
					(_entity2 = LookupColumnEntities.GetEntity("Entity2") as Contact);
			}
		}

		/// <exclude/>
		public Guid StatusOfDuplicateId {
			get {
				return GetTypedColumnValue<Guid>("StatusOfDuplicateId");
			}
			set {
				SetColumnValue("StatusOfDuplicateId", value);
				_statusOfDuplicate = null;
			}
		}

		/// <exclude/>
		public string StatusOfDuplicateName {
			get {
				return GetTypedColumnValue<string>("StatusOfDuplicateName");
			}
			set {
				SetColumnValue("StatusOfDuplicateName", value);
				if (_statusOfDuplicate != null) {
					_statusOfDuplicate.Name = value;
				}
			}
		}

		private DuplicateStatus _statusOfDuplicate;
		/// <summary>
		/// Record status.
		/// </summary>
		public DuplicateStatus StatusOfDuplicate {
			get {
				return _statusOfDuplicate ??
					(_statusOfDuplicate = LookupColumnEntities.GetEntity("StatusOfDuplicate") as DuplicateStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactDuplicate_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactDuplicateDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContactDuplicateDeleting", e);
			Inserted += (s, e) => ThrowEvent("ContactDuplicateInserted", e);
			Inserting += (s, e) => ThrowEvent("ContactDuplicateInserting", e);
			Saved += (s, e) => ThrowEvent("ContactDuplicateSaved", e);
			Saving += (s, e) => ThrowEvent("ContactDuplicateSaving", e);
			Validating += (s, e) => ThrowEvent("ContactDuplicateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactDuplicate(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactDuplicate_BaseEventsProcess

	/// <exclude/>
	public partial class ContactDuplicate_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContactDuplicate
	{

		public ContactDuplicate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactDuplicate_BaseEventsProcess";
			SchemaUId = new Guid("afd8d870-9c6a-4482-b90e-53682aed6618");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("afd8d870-9c6a-4482-b90e-53682aed6618");
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

	#region Class: ContactDuplicate_BaseEventsProcess

	/// <exclude/>
	public class ContactDuplicate_BaseEventsProcess : ContactDuplicate_BaseEventsProcess<ContactDuplicate>
	{

		public ContactDuplicate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactDuplicate_BaseEventsProcess

	public partial class ContactDuplicate_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactDuplicateEventsProcess

	/// <exclude/>
	public class ContactDuplicateEventsProcess : ContactDuplicate_BaseEventsProcess
	{

		public ContactDuplicateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

