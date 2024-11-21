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

	#region Class: AccountDuplicateSchema

	/// <exclude/>
	public class AccountDuplicateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AccountDuplicateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountDuplicateSchema(AccountDuplicateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountDuplicateSchema(AccountDuplicateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83");
			RealUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83");
			Name = "AccountDuplicate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a617af30-925f-4cc2-b5a3-15b838f6b321")) == null) {
				Columns.Add(CreateEntity1Column());
			}
			if (Columns.FindByUId(new Guid("e34dc26b-72cd-45ae-8790-4dba0e3e0ce1")) == null) {
				Columns.Add(CreateEntity2Column());
			}
			if (Columns.FindByUId(new Guid("961981ca-66e7-4d85-b25e-099fd86c55f1")) == null) {
				Columns.Add(CreateStatusOfDuplicateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntity1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a617af30-925f-4cc2-b5a3-15b838f6b321"),
				Name = @"Entity1",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83"),
				ModifiedInSchemaUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateEntity2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e34dc26b-72cd-45ae-8790-4dba0e3e0ce1"),
				Name = @"Entity2",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83"),
				ModifiedInSchemaUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusOfDuplicateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("961981ca-66e7-4d85-b25e-099fd86c55f1"),
				Name = @"StatusOfDuplicate",
				ReferenceSchemaUId = new Guid("590f25a6-b7bf-4ca0-816a-415e3518a148"),
				CreatedInSchemaUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83"),
				ModifiedInSchemaUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountDuplicate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountDuplicate_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountDuplicateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountDuplicateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountDuplicate

	/// <summary>
	/// Account duplicate.
	/// </summary>
	public class AccountDuplicate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AccountDuplicate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountDuplicate";
		}

		public AccountDuplicate(AccountDuplicate source)
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

		private Account _entity1;
		/// <summary>
		/// Record 1.
		/// </summary>
		public Account Entity1 {
			get {
				return _entity1 ??
					(_entity1 = LookupColumnEntities.GetEntity("Entity1") as Account);
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

		private Account _entity2;
		/// <summary>
		/// Record 2.
		/// </summary>
		public Account Entity2 {
			get {
				return _entity2 ??
					(_entity2 = LookupColumnEntities.GetEntity("Entity2") as Account);
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
			var process = new AccountDuplicate_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountDuplicateDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountDuplicateDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountDuplicateInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountDuplicateInserting", e);
			Saved += (s, e) => ThrowEvent("AccountDuplicateSaved", e);
			Saving += (s, e) => ThrowEvent("AccountDuplicateSaving", e);
			Validating += (s, e) => ThrowEvent("AccountDuplicateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountDuplicate(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountDuplicate_BaseEventsProcess

	/// <exclude/>
	public partial class AccountDuplicate_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AccountDuplicate
	{

		public AccountDuplicate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountDuplicate_BaseEventsProcess";
			SchemaUId = new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a477264b-2d69-48b7-9268-e9b4d39ebf83");
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

	#region Class: AccountDuplicate_BaseEventsProcess

	/// <exclude/>
	public class AccountDuplicate_BaseEventsProcess : AccountDuplicate_BaseEventsProcess<AccountDuplicate>
	{

		public AccountDuplicate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountDuplicate_BaseEventsProcess

	public partial class AccountDuplicate_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountDuplicateEventsProcess

	/// <exclude/>
	public class AccountDuplicateEventsProcess : AccountDuplicate_BaseEventsProcess
	{

		public AccountDuplicateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

