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

	#region Class: SysEntityChangeTypeSchema

	/// <exclude/>
	public class SysEntityChangeTypeSchema : BPMSoft.Configuration.SysCodeLookupSchema
	{

		#region Constructors: Public

		public SysEntityChangeTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntityChangeTypeSchema(SysEntityChangeTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntityChangeTypeSchema(SysEntityChangeTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b");
			RealUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b");
			Name = "SysEntityChangeType";
			ParentSchemaUId = new Guid("28699730-9cf0-4702-87a9-c64d612e4b14");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7b215060-4c29-4eee-b94c-3b62875a8aa1")) == null) {
				Columns.Add(CreateEnumCodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEnumCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7b215060-4c29-4eee-b94c-3b62875a8aa1"),
				Name = @"EnumCode",
				CreatedInSchemaUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b"),
				ModifiedInSchemaUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntityChangeType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntityChangeType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntityChangeTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntityChangeTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityChangeType

	/// <summary>
	/// Type of Object Modification.
	/// </summary>
	public class SysEntityChangeType : BPMSoft.Configuration.SysCodeLookup
	{

		#region Constructors: Public

		public SysEntityChangeType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityChangeType";
		}

		public SysEntityChangeType(SysEntityChangeType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Enumeration code.
		/// </summary>
		public int EnumCode {
			get {
				return GetTypedColumnValue<int>("EnumCode");
			}
			set {
				SetColumnValue("EnumCode", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntityChangeType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntityChangeTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEntityChangeTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEntityChangeTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEntityChangeTypeInserting", e);
			Saved += (s, e) => ThrowEvent("SysEntityChangeTypeSaved", e);
			Saving += (s, e) => ThrowEvent("SysEntityChangeTypeSaving", e);
			Validating += (s, e) => ThrowEvent("SysEntityChangeTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntityChangeType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityChangeType_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntityChangeType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysEntityChangeType
	{

		public SysEntityChangeType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntityChangeType_BaseEventsProcess";
			SchemaUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b");
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

	#region Class: SysEntityChangeType_BaseEventsProcess

	/// <exclude/>
	public class SysEntityChangeType_BaseEventsProcess : SysEntityChangeType_BaseEventsProcess<SysEntityChangeType>
	{

		public SysEntityChangeType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntityChangeType_BaseEventsProcess

	public partial class SysEntityChangeType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntityChangeTypeEventsProcess

	/// <exclude/>
	public class SysEntityChangeTypeEventsProcess : SysEntityChangeType_BaseEventsProcess
	{

		public SysEntityChangeTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

