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

	#region Class: SysBaseProcessEntitySchema

	/// <exclude/>
	[IsVirtual]
	public class SysBaseProcessEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysBaseProcessEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysBaseProcessEntitySchema(SysBaseProcessEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysBaseProcessEntitySchema(SysBaseProcessEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
			RealUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
			Name = "SysBaseProcessEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("36dc520e-160c-4d05-916b-2c4d4c0b0689")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ccb4f408-62bb-4d5c-8a37-a43ca99eb3c9")) == null) {
				Columns.Add(CreateEntityDisplayValueColumn());
			}
			if (Columns.FindByUId(new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("36dc520e-160c-4d05-916b-2c4d4c0b0689"),
				Name = @"EntitySchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518"),
				ModifiedInSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityDisplayValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ccb4f408-62bb-4d5c-8a37-a43ca99eb3c9"),
				Name = @"EntityDisplayValue",
				CreatedInSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518"),
				ModifiedInSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518"),
				ModifiedInSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysBaseProcessEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysBaseProcessEntity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysBaseProcessEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysBaseProcessEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518"));
		}

		#endregion

	}

	#endregion

	#region Class: SysBaseProcessEntity

	/// <summary>
	/// Base object in process.
	/// </summary>
	public class SysBaseProcessEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysBaseProcessEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysBaseProcessEntity";
		}

		public SysBaseProcessEntity(SysBaseProcessEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object diagram.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Primary object name.
		/// </summary>
		public string EntityDisplayValue {
			get {
				return GetTypedColumnValue<string>("EntityDisplayValue");
			}
			set {
				SetColumnValue("EntityDisplayValue", value);
			}
		}

		/// <summary>
		/// Entity.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysBaseProcessEntity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysBaseProcessEntityDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysBaseProcessEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysBaseProcessEntity_BaseEventsProcess

	/// <exclude/>
	public partial class SysBaseProcessEntity_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysBaseProcessEntity
	{

		public SysBaseProcessEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysBaseProcessEntity_BaseEventsProcess";
			SchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
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

	#region Class: SysBaseProcessEntity_BaseEventsProcess

	/// <exclude/>
	public class SysBaseProcessEntity_BaseEventsProcess : SysBaseProcessEntity_BaseEventsProcess<SysBaseProcessEntity>
	{

		public SysBaseProcessEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysBaseProcessEntity_BaseEventsProcess

	public partial class SysBaseProcessEntity_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysBaseProcessEntityEventsProcess

	/// <exclude/>
	public class SysBaseProcessEntityEventsProcess : SysBaseProcessEntity_BaseEventsProcess
	{

		public SysBaseProcessEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

