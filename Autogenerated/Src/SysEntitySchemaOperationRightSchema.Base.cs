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

	#region Class: SysEntitySchemaOperationRightSchema

	/// <exclude/>
	public class SysEntitySchemaOperationRightSchema : BPMSoft.Configuration.SysBaseSchemaOperationRightSchema
	{

		#region Constructors: Public

		public SysEntitySchemaOperationRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntitySchemaOperationRightSchema(SysEntitySchemaOperationRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntitySchemaOperationRightSchema(SysEntitySchemaOperationRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527");
			RealUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527");
			Name = "SysEntitySchemaOperationRight";
			ParentSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a3dc68d6-f74e-4a57-8411-77a88dfe0bbb")) == null) {
				Columns.Add(CreateCanReadColumn());
			}
			if (Columns.FindByUId(new Guid("21a61238-45dc-4089-9882-cc1be097cbf8")) == null) {
				Columns.Add(CreateCanAppendColumn());
			}
			if (Columns.FindByUId(new Guid("379b41a2-dfb5-4069-a267-88ec0653e391")) == null) {
				Columns.Add(CreateCanEditColumn());
			}
			if (Columns.FindByUId(new Guid("2cda2c20-d48a-44d0-b266-5542730b1ad9")) == null) {
				Columns.Add(CreateCanDeleteColumn());
			}
			if (Columns.FindByUId(new Guid("134c280f-f7a7-4ac5-beeb-4ab1ed9e4ff5")) == null) {
				Columns.Add(CreateSubjectSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCanReadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a3dc68d6-f74e-4a57-8411-77a88dfe0bbb"),
				Name = @"CanRead",
				CreatedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				ModifiedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				CreatedInPackageId = new Guid("7a22b6a0-37cb-4535-8949-1111b2b1ad98")
			};
		}

		protected virtual EntitySchemaColumn CreateCanAppendColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("21a61238-45dc-4089-9882-cc1be097cbf8"),
				Name = @"CanAppend",
				CreatedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				ModifiedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				CreatedInPackageId = new Guid("7a22b6a0-37cb-4535-8949-1111b2b1ad98")
			};
		}

		protected virtual EntitySchemaColumn CreateCanEditColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("379b41a2-dfb5-4069-a267-88ec0653e391"),
				Name = @"CanEdit",
				CreatedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				ModifiedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				CreatedInPackageId = new Guid("7a22b6a0-37cb-4535-8949-1111b2b1ad98")
			};
		}

		protected virtual EntitySchemaColumn CreateCanDeleteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2cda2c20-d48a-44d0-b266-5542730b1ad9"),
				Name = @"CanDelete",
				CreatedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				ModifiedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				CreatedInPackageId = new Guid("7a22b6a0-37cb-4535-8949-1111b2b1ad98")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("134c280f-f7a7-4ac5-beeb-4ab1ed9e4ff5"),
				Name = @"SubjectSchemaUId",
				CreatedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				ModifiedInSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"),
				CreatedInPackageId = new Guid("7a22b6a0-37cb-4535-8949-1111b2b1ad98")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntitySchemaOperationRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntitySchemaOperationRight_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntitySchemaOperationRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntitySchemaOperationRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaOperationRight

	/// <summary>
	/// Operation permissions.
	/// </summary>
	public class SysEntitySchemaOperationRight : BPMSoft.Configuration.SysBaseSchemaOperationRight
	{

		#region Constructors: Public

		public SysEntitySchemaOperationRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaOperationRight";
		}

		public SysEntitySchemaOperationRight(SysEntitySchemaOperationRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Read.
		/// </summary>
		public bool CanRead {
			get {
				return GetTypedColumnValue<bool>("CanRead");
			}
			set {
				SetColumnValue("CanRead", value);
			}
		}

		/// <summary>
		/// New.
		/// </summary>
		public bool CanAppend {
			get {
				return GetTypedColumnValue<bool>("CanAppend");
			}
			set {
				SetColumnValue("CanAppend", value);
			}
		}

		/// <summary>
		/// Edit.
		/// </summary>
		public bool CanEdit {
			get {
				return GetTypedColumnValue<bool>("CanEdit");
			}
			set {
				SetColumnValue("CanEdit", value);
			}
		}

		/// <summary>
		/// Delete.
		/// </summary>
		public bool CanDelete {
			get {
				return GetTypedColumnValue<bool>("CanDelete");
			}
			set {
				SetColumnValue("CanDelete", value);
			}
		}

		/// <summary>
		/// Object.
		/// </summary>
		public Guid SubjectSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SubjectSchemaUId");
			}
			set {
				SetColumnValue("SubjectSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntitySchemaOperationRight_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntitySchemaOperationRightDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEntitySchemaOperationRightDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEntitySchemaOperationRightInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEntitySchemaOperationRightInserting", e);
			Saved += (s, e) => ThrowEvent("SysEntitySchemaOperationRightSaved", e);
			Saving += (s, e) => ThrowEvent("SysEntitySchemaOperationRightSaving", e);
			Validating += (s, e) => ThrowEvent("SysEntitySchemaOperationRightValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntitySchemaOperationRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaOperationRight_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntitySchemaOperationRight_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysBaseSchemaOperationRight_BaseEventsProcess<TEntity> where TEntity : SysEntitySchemaOperationRight
	{

		public SysEntitySchemaOperationRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntitySchemaOperationRight_BaseEventsProcess";
			SchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527");
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

	#region Class: SysEntitySchemaOperationRight_BaseEventsProcess

	/// <exclude/>
	public class SysEntitySchemaOperationRight_BaseEventsProcess : SysEntitySchemaOperationRight_BaseEventsProcess<SysEntitySchemaOperationRight>
	{

		public SysEntitySchemaOperationRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntitySchemaOperationRight_BaseEventsProcess

	public partial class SysEntitySchemaOperationRight_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntitySchemaOperationRightEventsProcess

	/// <exclude/>
	public class SysEntitySchemaOperationRightEventsProcess : SysEntitySchemaOperationRight_BaseEventsProcess
	{

		public SysEntitySchemaOperationRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

