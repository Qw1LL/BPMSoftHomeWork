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
	using BPMSoft.Core.OperationLog;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using BPMSoft.Web.Common;
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

	#region Class: VwGroupSysAdminUnitSchema

	/// <exclude/>
	public class VwGroupSysAdminUnitSchema : BPMSoft.Configuration.SysAdminUnitSchema
	{

		#region Constructors: Public

		public VwGroupSysAdminUnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwGroupSysAdminUnitSchema(VwGroupSysAdminUnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwGroupSysAdminUnitSchema(VwGroupSysAdminUnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysAdminUnitNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("a09035f6-13ab-41d9-af1c-c095e5cf9ac1");
			index.Name = "IUSysAdminUnitName";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5c950219-374c-425c-8082-7e7de785ba20"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			EntitySchemaIndexColumn parentRoleIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3c1b73d7-6adf-4567-88c8-8b95952dc03c"),
				ColumnUId = new Guid("fa4483b3-a2db-4651-a462-689be18351e7"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("81adfa8e-1f43-43a3-9652-1b782e1a0cf1"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(parentRoleIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISAULoggedInActiveIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("cf9e2407-d54a-4930-bdfc-ce9bc64ddfb4");
			index.Name = "ISAULoggedInActive";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn loggedInIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d9c799ef-023d-492c-879d-52d11308d0e8"),
				ColumnUId = new Guid("b0cc6131-e034-4562-9526-3f3a81f0a161"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(loggedInIndexColumn);
			EntitySchemaIndexColumn activeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("670a80ef-4ebe-4c5d-a5d1-e03f9edc4367"),
				ColumnUId = new Guid("48f37442-a2da-4407-9178-72073ba6b09f"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(activeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			RealUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			Name = "VwGroupSysAdminUnit";
			ParentSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateSysAdminUnitTypeValueColumn() {
			EntitySchemaColumn column = base.CreateSysAdminUnitTypeValueColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateParentRoleColumn() {
			EntitySchemaColumn column = base.CreateParentRoleColumn();
			column.ReferenceSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.ColumnValueName = @"ParentRoleId";
			column.DisplayColumnValueName = @"ParentRoleName";
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateContactColumn() {
			EntitySchemaColumn column = base.CreateContactColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateAccountColumn() {
			EntitySchemaColumn column = base.CreateAccountColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateIsDirectoryEntryColumn() {
			EntitySchemaColumn column = base.CreateIsDirectoryEntryColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateTimeZoneIdColumn() {
			EntitySchemaColumn column = base.CreateTimeZoneIdColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateUserPasswordColumn() {
			EntitySchemaColumn column = base.CreateUserPasswordColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateActiveColumn() {
			EntitySchemaColumn column = base.CreateActiveColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateSynchronizeWithLDAPColumn() {
			EntitySchemaColumn column = base.CreateSynchronizeWithLDAPColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateLDAPEntryColumn() {
			EntitySchemaColumn column = base.CreateLDAPEntryColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateLDAPEntryIdColumn() {
			EntitySchemaColumn column = base.CreateLDAPEntryIdColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateLDAPEntryDNColumn() {
			EntitySchemaColumn column = base.CreateLDAPEntryDNColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateLoggedInColumn() {
			EntitySchemaColumn column = base.CreateLoggedInColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateSysCultureColumn() {
			EntitySchemaColumn column = base.CreateSysCultureColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateLoginAttemptCountColumn() {
			EntitySchemaColumn column = base.CreateLoginAttemptCountColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateSourceControlLoginColumn() {
			EntitySchemaColumn column = base.CreateSourceControlLoginColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateSourceControlPasswordColumn() {
			EntitySchemaColumn column = base.CreateSourceControlPasswordColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreatePasswordExpireDateColumn() {
			EntitySchemaColumn column = base.CreatePasswordExpireDateColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateHomePageColumn() {
			EntitySchemaColumn column = base.CreateHomePageColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateConnectionTypeColumn() {
			EntitySchemaColumn column = base.CreateConnectionTypeColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateUnblockTimeColumn() {
			EntitySchemaColumn column = base.CreateUnblockTimeColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override EntitySchemaColumn CreateForceChangePasswordColumn() {
			EntitySchemaColumn column = base.CreateForceChangePasswordColumn();
			column.ModifiedInSchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			column.CreatedInPackageId = new Guid("3148fb3e-f2dd-48f6-9b89-0b40779627d9");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysAdminUnitNameIndex());
			Indexes.Add(CreateISAULoggedInActiveIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwGroupSysAdminUnit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwGroupSysAdminUnit_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwGroupSysAdminUnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwGroupSysAdminUnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11"));
		}

		#endregion

	}

	#endregion

	#region Class: VwGroupSysAdminUnit

	/// <summary>
	/// Объект администрирования группа (представление).
	/// </summary>
	public class VwGroupSysAdminUnit : BPMSoft.Configuration.SysAdminUnit
	{

		#region Constructors: Public

		public VwGroupSysAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwGroupSysAdminUnit";
		}

		public VwGroupSysAdminUnit(VwGroupSysAdminUnit source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwGroupSysAdminUnit_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("VwGroupSysAdminUnitInserted", e);
			Saving += (s, e) => ThrowEvent("VwGroupSysAdminUnitSaving", e);
			Updated += (s, e) => ThrowEvent("VwGroupSysAdminUnitUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwGroupSysAdminUnit(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwGroupSysAdminUnit_CaseEventsProcess

	/// <exclude/>
	public partial class VwGroupSysAdminUnit_CaseEventsProcess<TEntity> : BPMSoft.Configuration.SysAdminUnit_SSPEventsProcess<TEntity> where TEntity : VwGroupSysAdminUnit
	{

		public VwGroupSysAdminUnit_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwGroupSysAdminUnit_CaseEventsProcess";
			SchemaUId = new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1ff32a7e-ed74-4fc7-948d-a3aa014d6e11");
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

	#region Class: VwGroupSysAdminUnit_CaseEventsProcess

	/// <exclude/>
	public class VwGroupSysAdminUnit_CaseEventsProcess : VwGroupSysAdminUnit_CaseEventsProcess<VwGroupSysAdminUnit>
	{

		public VwGroupSysAdminUnit_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwGroupSysAdminUnit_CaseEventsProcess

	public partial class VwGroupSysAdminUnit_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwGroupSysAdminUnitEventsProcess

	/// <exclude/>
	public class VwGroupSysAdminUnitEventsProcess : VwGroupSysAdminUnit_CaseEventsProcess
	{

		public VwGroupSysAdminUnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

