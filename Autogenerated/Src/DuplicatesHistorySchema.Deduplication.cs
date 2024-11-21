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

	#region Class: DuplicatesHistorySchema

	/// <exclude/>
	public class DuplicatesHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DuplicatesHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DuplicatesHistorySchema(DuplicatesHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DuplicatesHistorySchema(DuplicatesHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f552974d-688c-4e40-a54c-443e39761a00");
			RealUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00");
			Name = "DuplicatesHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b4492df1-0149-4d4b-a643-21f84c084c9c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("257eb661-03c4-4e02-826d-0741e07f8521")) == null) {
				Columns.Add(CreateOldRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("d056f084-8b9c-4b02-8be1-2b0da78b6c54")) == null) {
				Columns.Add(CreateNewRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("93577fe4-b7c8-48cb-98dd-707bf21fcc72")) == null) {
				Columns.Add(CreateSchemaTableNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOldRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("257eb661-03c4-4e02-826d-0741e07f8521"),
				Name = @"OldRecordId",
				CreatedInSchemaUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00"),
				ModifiedInSchemaUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00"),
				CreatedInPackageId = new Guid("b4492df1-0149-4d4b-a643-21f84c084c9c")
			};
		}

		protected virtual EntitySchemaColumn CreateNewRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d056f084-8b9c-4b02-8be1-2b0da78b6c54"),
				Name = @"NewRecordId",
				CreatedInSchemaUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00"),
				ModifiedInSchemaUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00"),
				CreatedInPackageId = new Guid("b4492df1-0149-4d4b-a643-21f84c084c9c")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaTableNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("93577fe4-b7c8-48cb-98dd-707bf21fcc72"),
				Name = @"SchemaTableName",
				CreatedInSchemaUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00"),
				ModifiedInSchemaUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00"),
				CreatedInPackageId = new Guid("b4492df1-0149-4d4b-a643-21f84c084c9c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DuplicatesHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DuplicatesHistory_DeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DuplicatesHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DuplicatesHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f552974d-688c-4e40-a54c-443e39761a00"));
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesHistory

	/// <summary>
	/// Duplicates history.
	/// </summary>
	public class DuplicatesHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DuplicatesHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesHistory";
		}

		public DuplicatesHistory(DuplicatesHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// OldRecordId.
		/// </summary>
		public Guid OldRecordId {
			get {
				return GetTypedColumnValue<Guid>("OldRecordId");
			}
			set {
				SetColumnValue("OldRecordId", value);
			}
		}

		/// <summary>
		/// NewRecordId.
		/// </summary>
		public Guid NewRecordId {
			get {
				return GetTypedColumnValue<Guid>("NewRecordId");
			}
			set {
				SetColumnValue("NewRecordId", value);
			}
		}

		/// <summary>
		/// SchemaTableName.
		/// </summary>
		public string SchemaTableName {
			get {
				return GetTypedColumnValue<string>("SchemaTableName");
			}
			set {
				SetColumnValue("SchemaTableName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DuplicatesHistory_DeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DuplicatesHistoryDeleted", e);
			Validating += (s, e) => ThrowEvent("DuplicatesHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DuplicatesHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesHistory_DeduplicationEventsProcess

	/// <exclude/>
	public partial class DuplicatesHistory_DeduplicationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DuplicatesHistory
	{

		public DuplicatesHistory_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DuplicatesHistory_DeduplicationEventsProcess";
			SchemaUId = new Guid("f552974d-688c-4e40-a54c-443e39761a00");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f552974d-688c-4e40-a54c-443e39761a00");
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

	#region Class: DuplicatesHistory_DeduplicationEventsProcess

	/// <exclude/>
	public class DuplicatesHistory_DeduplicationEventsProcess : DuplicatesHistory_DeduplicationEventsProcess<DuplicatesHistory>
	{

		public DuplicatesHistory_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DuplicatesHistory_DeduplicationEventsProcess

	public partial class DuplicatesHistory_DeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DuplicatesHistoryEventsProcess

	/// <exclude/>
	public class DuplicatesHistoryEventsProcess : DuplicatesHistory_DeduplicationEventsProcess
	{

		public DuplicatesHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

