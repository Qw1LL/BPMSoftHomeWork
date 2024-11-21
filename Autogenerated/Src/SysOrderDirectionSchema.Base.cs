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

	#region Class: SysOrderDirectionSchema

	/// <exclude/>
	public class SysOrderDirectionSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysOrderDirectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysOrderDirectionSchema(SysOrderDirectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysOrderDirectionSchema(SysOrderDirectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
			RealUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
			Name = "SysOrderDirection";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysOrderDirection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysOrderDirection_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysOrderDirectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysOrderDirectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122"));
		}

		#endregion

	}

	#endregion

	#region Class: SysOrderDirection

	/// <summary>
	/// Sorting Order.
	/// </summary>
	public class SysOrderDirection : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysOrderDirection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysOrderDirection";
		}

		public SysOrderDirection(SysOrderDirection source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysOrderDirection_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysOrderDirectionDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysOrderDirectionDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysOrderDirectionInserted", e);
			Inserting += (s, e) => ThrowEvent("SysOrderDirectionInserting", e);
			Saved += (s, e) => ThrowEvent("SysOrderDirectionSaved", e);
			Saving += (s, e) => ThrowEvent("SysOrderDirectionSaving", e);
			Validating += (s, e) => ThrowEvent("SysOrderDirectionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysOrderDirection(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysOrderDirection_BaseEventsProcess

	/// <exclude/>
	public partial class SysOrderDirection_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysOrderDirection
	{

		public SysOrderDirection_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysOrderDirection_BaseEventsProcess";
			SchemaUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122");
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

	#region Class: SysOrderDirection_BaseEventsProcess

	/// <exclude/>
	public class SysOrderDirection_BaseEventsProcess : SysOrderDirection_BaseEventsProcess<SysOrderDirection>
	{

		public SysOrderDirection_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysOrderDirection_BaseEventsProcess

	public partial class SysOrderDirection_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysOrderDirectionEventsProcess

	/// <exclude/>
	public class SysOrderDirectionEventsProcess : SysOrderDirection_BaseEventsProcess
	{

		public SysOrderDirectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

