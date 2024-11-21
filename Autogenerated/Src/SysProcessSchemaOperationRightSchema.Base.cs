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

	#region Class: SysProcessSchemaOperationRightSchema

	/// <exclude/>
	public class SysProcessSchemaOperationRightSchema : BPMSoft.Configuration.SysBaseSchemaOperationRightSchema
	{

		#region Constructors: Public

		public SysProcessSchemaOperationRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessSchemaOperationRightSchema(SysProcessSchemaOperationRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessSchemaOperationRightSchema(SysProcessSchemaOperationRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_PcsSchemaUId_AdminUnitIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("5cc09fa3-9d83-4fea-bb48-568c1ad8dc77");
			index.Name = "IX_PcsSchemaUId_AdminUnit";
			index.CreatedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
			index.ModifiedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn rootProcessSchemaUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ab35f163-4e50-d12a-c3d8-257f4e0e0d3e"),
				ColumnUId = new Guid("8032e852-4c4f-511a-0406-7ecf2435e3b0"),
				CreatedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
				ModifiedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(rootProcessSchemaUIdIndexColumn);
			EntitySchemaIndexColumn sysAdminUnitIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("e8552c7f-df86-a200-ba3b-ffad54bf5390"),
				ColumnUId = new Guid("d27e9964-a7a6-46dd-9f9a-7cb470c33b98"),
				CreatedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
				ModifiedInSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysAdminUnitIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573");
			RealUId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573");
			Name = "SysProcessSchemaOperationRight";
			ParentSchemaUId = new Guid("233347ba-8fd9-990b-3ab7-a60e182c8a0d");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8032e852-4c4f-511a-0406-7ecf2435e3b0")) == null) {
				Columns.Add(CreateRootProcessSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("9cc217f6-e413-7eb2-6a30-f75a56f07a5e")) == null) {
				Columns.Add(CreateCanExecuteColumn());
			}
		}

		protected override EntitySchemaColumn CreateSysAdminUnitColumn() {
			EntitySchemaColumn column = base.CreateSysAdminUnitColumn();
			column.IsWeakReference = false;
			column.ModifiedInSchemaUId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573");
			return column;
		}

		protected virtual EntitySchemaColumn CreateRootProcessSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8032e852-4c4f-511a-0406-7ecf2435e3b0"),
				Name = @"RootProcessSchemaUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573"),
				ModifiedInSchemaUId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateCanExecuteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9cc217f6-e413-7eb2-6a30-f75a56f07a5e"),
				Name = @"CanExecute",
				CreatedInSchemaUId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573"),
				ModifiedInSchemaUId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_PcsSchemaUId_AdminUnitIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessSchemaOperationRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessSchemaOperationRight_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessSchemaOperationRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessSchemaOperationRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessSchemaOperationRight

	/// <summary>
	/// Process permissions.
	/// </summary>
	public class SysProcessSchemaOperationRight : BPMSoft.Configuration.SysBaseSchemaOperationRight
	{

		#region Constructors: Public

		public SysProcessSchemaOperationRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessSchemaOperationRight";
		}

		public SysProcessSchemaOperationRight(SysProcessSchemaOperationRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Root process schema UId.
		/// </summary>
		public Guid RootProcessSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("RootProcessSchemaUId");
			}
			set {
				SetColumnValue("RootProcessSchemaUId", value);
			}
		}

		/// <summary>
		/// Execute.
		/// </summary>
		public bool CanExecute {
			get {
				return GetTypedColumnValue<bool>("CanExecute");
			}
			set {
				SetColumnValue("CanExecute", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessSchemaOperationRight_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessSchemaOperationRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessSchemaOperationRight_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessSchemaOperationRight_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysBaseSchemaOperationRight_BaseEventsProcess<TEntity> where TEntity : SysProcessSchemaOperationRight
	{

		public SysProcessSchemaOperationRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessSchemaOperationRight_BaseEventsProcess";
			SchemaUId = new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("233adfa4-bbbc-d8e9-7a9d-807e70d5b573");
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

	#region Class: SysProcessSchemaOperationRight_BaseEventsProcess

	/// <exclude/>
	public class SysProcessSchemaOperationRight_BaseEventsProcess : SysProcessSchemaOperationRight_BaseEventsProcess<SysProcessSchemaOperationRight>
	{

		public SysProcessSchemaOperationRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessSchemaOperationRight_BaseEventsProcess

	public partial class SysProcessSchemaOperationRight_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessSchemaOperationRightEventsProcess

	/// <exclude/>
	public class SysProcessSchemaOperationRightEventsProcess : SysProcessSchemaOperationRight_BaseEventsProcess
	{

		public SysProcessSchemaOperationRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

