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

	#region Class: SysDetailSchema

	/// <exclude/>
	public class SysDetailSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDetailSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDetailSchema(SysDetailSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDetailSchema(SysDetailSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			RealUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			Name = "SysDetail";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8585929c-62ae-4673-ae8d-bb37f87e5144")) == null) {
				Columns.Add(CreateDetailSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("631e7238-2751-4a21-b6d6-9f1ac0c84f95")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			column.CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			column.CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			column.CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			column.CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			column.CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			column.CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("49ad8ee2-65a6-4cdd-b8f6-85c2f10a54dc"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDetailSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8585929c-62ae-4673-ae8d-bb37f87e5144"),
				Name = @"DetailSchemaUId",
				CreatedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("631e7238-2751-4a21-b6d6-9f1ac0c84f95"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				ModifiedInSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				CreatedInPackageId = new Guid("e63e45b4-0bf6-4e6f-9a89-2f7851e26fd2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDetail(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDetail_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDetailSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDetailSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDetail

	/// <summary>
	/// Details lookup.
	/// </summary>
	public class SysDetail : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDetail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDetail";
		}

		public SysDetail(SysDetail source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Detail schema.
		/// </summary>
		public Guid DetailSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("DetailSchemaUId");
			}
			set {
				SetColumnValue("DetailSchemaUId", value);
			}
		}

		/// <summary>
		/// Object schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDetail_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDetailDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysDetailInserting", e);
			Validating += (s, e) => ThrowEvent("SysDetailValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDetail(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDetail_BaseEventsProcess

	/// <exclude/>
	public partial class SysDetail_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysDetail
	{

		public SysDetail_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDetail_BaseEventsProcess";
			SchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a");
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

	#region Class: SysDetail_BaseEventsProcess

	/// <exclude/>
	public class SysDetail_BaseEventsProcess : SysDetail_BaseEventsProcess<SysDetail>
	{

		public SysDetail_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDetail_BaseEventsProcess

	public partial class SysDetail_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDetailEventsProcess

	/// <exclude/>
	public class SysDetailEventsProcess : SysDetail_BaseEventsProcess
	{

		public SysDetailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

