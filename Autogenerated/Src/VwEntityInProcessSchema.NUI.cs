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

	#region Class: VwEntityInProcessSchema

	/// <exclude/>
	public class VwEntityInProcessSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwEntityInProcessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwEntityInProcessSchema(VwEntityInProcessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwEntityInProcessSchema(VwEntityInProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2");
			RealUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2");
			Name = "VwEntityInProcess";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("573faf8d-eac5-46bd-a14e-bfa97ad3578e")) == null) {
				Columns.Add(CreateProcessCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("1005cc47-4026-4088-8409-7c2b64ef34a6")) == null) {
				Columns.Add(CreateProcessDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("fea5dcb2-0e6a-4d97-bd0d-0a92a6fb359d")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("fed365ce-80f0-4ce1-9490-4db37237fcb8")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ReferenceSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProcessCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("573faf8d-eac5-46bd-a14e-bfa97ad3578e"),
				Name = @"ProcessCaption",
				CreatedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				ModifiedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1005cc47-4026-4088-8409-7c2b64ef34a6"),
				Name = @"ProcessDescription",
				CreatedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				ModifiedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fea5dcb2-0e6a-4d97-bd0d-0a92a6fb359d"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				ModifiedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fed365ce-80f0-4ce1-9490-4db37237fcb8"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				ModifiedInSchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"),
				CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwEntityInProcess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwEntityInProcess_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwEntityInProcessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwEntityInProcessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2"));
		}

		#endregion

	}

	#endregion

	#region Class: VwEntityInProcess

	/// <summary>
	/// Used entities in the processes.
	/// </summary>
	public class VwEntityInProcess : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwEntityInProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwEntityInProcess";
		}

		public VwEntityInProcess(VwEntityInProcess source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Caption of the process.
		/// </summary>
		public string ProcessCaption {
			get {
				return GetTypedColumnValue<string>("ProcessCaption");
			}
			set {
				SetColumnValue("ProcessCaption", value);
			}
		}

		/// <summary>
		/// Description of the process.
		/// </summary>
		public string ProcessDescription {
			get {
				return GetTypedColumnValue<string>("ProcessDescription");
			}
			set {
				SetColumnValue("ProcessDescription", value);
			}
		}

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Entity schema name.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwEntityInProcess_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwEntityInProcessDeleted", e);
			Validating += (s, e) => ThrowEvent("VwEntityInProcessValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwEntityInProcess(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwEntityInProcess_NUIEventsProcess

	/// <exclude/>
	public partial class VwEntityInProcess_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwEntityInProcess
	{

		public VwEntityInProcess_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwEntityInProcess_NUIEventsProcess";
			SchemaUId = new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0195d99c-c259-45e1-b27f-d2145a8838e2");
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

	#region Class: VwEntityInProcess_NUIEventsProcess

	/// <exclude/>
	public class VwEntityInProcess_NUIEventsProcess : VwEntityInProcess_NUIEventsProcess<VwEntityInProcess>
	{

		public VwEntityInProcess_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwEntityInProcess_NUIEventsProcess

	public partial class VwEntityInProcess_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwEntityInProcessEventsProcess

	/// <exclude/>
	public class VwEntityInProcessEventsProcess : VwEntityInProcess_NUIEventsProcess
	{

		public VwEntityInProcessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

