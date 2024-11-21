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

	#region Class: SysOperationResultSchema

	/// <exclude/>
	public class SysOperationResultSchema : BPMSoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public SysOperationResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysOperationResultSchema(SysOperationResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysOperationResultSchema(SysOperationResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_SysOperationResultCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("218135df-d179-4f44-85ea-7ccb70d11c27");
			index.Name = "IX_SysOperationResultCode";
			index.CreatedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			index.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			index.CreatedInPackageId = new Guid("097f7d5f-7a55-4df4-9734-034f9246a1c2");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1631418b-80b6-42d8-84ef-5fe1173fbd75"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e"),
				ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e"),
				CreatedInPackageId = new Guid("097f7d5f-7a55-4df4-9734-034f9246a1c2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			RealUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			Name = "SysOperationResult";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override EntitySchemaColumn CreateImageColumn() {
			EntitySchemaColumn column = base.CreateImageColumn();
			column.ModifiedInSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			column.CreatedInPackageId = new Guid("a46a47cf-e8b1-4478-9d05-9dd8d463a60f");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_SysOperationResultCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysOperationResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysOperationResult_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysOperationResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysOperationResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationResult

	/// <summary>
	/// Event results.
	/// </summary>
	public class SysOperationResult : BPMSoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public SysOperationResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysOperationResult";
		}

		public SysOperationResult(SysOperationResult source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysOperationResult_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysOperationResultDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysOperationResultInserting", e);
			Validating += (s, e) => ThrowEvent("SysOperationResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysOperationResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationResult_BaseEventsProcess

	/// <exclude/>
	public partial class SysOperationResult_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeImageLookup_BaseEventsProcess<TEntity> where TEntity : SysOperationResult
	{

		public SysOperationResult_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysOperationResult_BaseEventsProcess";
			SchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e");
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

	#region Class: SysOperationResult_BaseEventsProcess

	/// <exclude/>
	public class SysOperationResult_BaseEventsProcess : SysOperationResult_BaseEventsProcess<SysOperationResult>
	{

		public SysOperationResult_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysOperationResult_BaseEventsProcess

	public partial class SysOperationResult_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysOperationResultEventsProcess

	/// <exclude/>
	public class SysOperationResultEventsProcess : SysOperationResult_BaseEventsProcess
	{

		public SysOperationResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

