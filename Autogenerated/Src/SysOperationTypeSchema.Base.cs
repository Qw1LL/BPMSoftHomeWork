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

	#region Class: SysOperationTypeSchema

	/// <exclude/>
	public class SysOperationTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysOperationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysOperationTypeSchema(SysOperationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysOperationTypeSchema(SysOperationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_SysOperationTypeCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("22734e83-f293-4325-870d-39bc0373b0cb");
			index.Name = "IX_SysOperationTypeCode";
			index.CreatedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			index.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			index.CreatedInPackageId = new Guid("097f7d5f-7a55-4df4-9734-034f9246a1c2");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1a7afe71-9f33-43bd-8360-3b9d06634b6d"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40"),
				ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40"),
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
			UId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			RealUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			Name = "SysOperationType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_SysOperationTypeCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysOperationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysOperationType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysOperationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysOperationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40"));
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationType

	/// <summary>
	/// Event type.
	/// </summary>
	public class SysOperationType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysOperationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysOperationType";
		}

		public SysOperationType(SysOperationType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysOperationType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysOperationTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysOperationTypeInserting", e);
			Validating += (s, e) => ThrowEvent("SysOperationTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysOperationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationType_BaseEventsProcess

	/// <exclude/>
	public partial class SysOperationType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysOperationType
	{

		public SysOperationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysOperationType_BaseEventsProcess";
			SchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40");
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

	#region Class: SysOperationType_BaseEventsProcess

	/// <exclude/>
	public class SysOperationType_BaseEventsProcess : SysOperationType_BaseEventsProcess<SysOperationType>
	{

		public SysOperationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysOperationType_BaseEventsProcess

	public partial class SysOperationType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysOperationTypeEventsProcess

	/// <exclude/>
	public class SysOperationTypeEventsProcess : SysOperationType_BaseEventsProcess
	{

		public SysOperationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

