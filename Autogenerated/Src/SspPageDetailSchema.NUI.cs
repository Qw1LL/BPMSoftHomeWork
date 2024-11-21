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

	#region Class: SspPageDetailSchema

	/// <exclude/>
	public class SspPageDetailSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SspPageDetailSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SspPageDetailSchema(SspPageDetailSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SspPageDetailSchema(SspPageDetailSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07");
			RealUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07");
			Name = "SspPageDetail";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("479f70b4-9acf-4e9e-85c9-3a190e2b8f8d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f8cd1f5c-b6e0-4a37-88ee-05929d09b2e8")) == null) {
				Columns.Add(CreateCardSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("8f11220c-7647-4c8c-90b9-b79e03e8f6ee")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("3205952e-7126-45fa-b720-9cd99f7875ae")) == null) {
				Columns.Add(CreateSysDetailColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCardSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f8cd1f5c-b6e0-4a37-88ee-05929d09b2e8"),
				Name = @"CardSchemaUId",
				CreatedInSchemaUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07"),
				ModifiedInSchemaUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07"),
				CreatedInPackageId = new Guid("479f70b4-9acf-4e9e-85c9-3a190e2b8f8d")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8f11220c-7647-4c8c-90b9-b79e03e8f6ee"),
				Name = @"EntitySchemaUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07"),
				ModifiedInSchemaUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07"),
				CreatedInPackageId = new Guid("479f70b4-9acf-4e9e-85c9-3a190e2b8f8d")
			};
		}

		protected virtual EntitySchemaColumn CreateSysDetailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3205952e-7126-45fa-b720-9cd99f7875ae"),
				Name = @"SysDetail",
				ReferenceSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07"),
				ModifiedInSchemaUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07"),
				CreatedInPackageId = new Guid("479f70b4-9acf-4e9e-85c9-3a190e2b8f8d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SspPageDetail(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SspPageDetail_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SspPageDetailSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SspPageDetailSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07"));
		}

		#endregion

	}

	#endregion

	#region Class: SspPageDetail

	/// <summary>
	/// SspPageDetail.
	/// </summary>
	public class SspPageDetail : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SspPageDetail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SspPageDetail";
		}

		public SspPageDetail(SspPageDetail source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// CardSchemaUId.
		/// </summary>
		public Guid CardSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("CardSchemaUId");
			}
			set {
				SetColumnValue("CardSchemaUId", value);
			}
		}

		/// <summary>
		/// EntitySchemaUId.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid SysDetailId {
			get {
				return GetTypedColumnValue<Guid>("SysDetailId");
			}
			set {
				SetColumnValue("SysDetailId", value);
				_sysDetail = null;
			}
		}

		/// <exclude/>
		public string SysDetailCaption {
			get {
				return GetTypedColumnValue<string>("SysDetailCaption");
			}
			set {
				SetColumnValue("SysDetailCaption", value);
				if (_sysDetail != null) {
					_sysDetail.Caption = value;
				}
			}
		}

		private SysDetail _sysDetail;
		/// <summary>
		/// SysDetail.
		/// </summary>
		public SysDetail SysDetail {
			get {
				return _sysDetail ??
					(_sysDetail = LookupColumnEntities.GetEntity("SysDetail") as SysDetail);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SspPageDetail_NUIEventsProcess(UserConnection);
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
			return new SspPageDetail(this);
		}

		#endregion

	}

	#endregion

	#region Class: SspPageDetail_NUIEventsProcess

	/// <exclude/>
	public partial class SspPageDetail_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SspPageDetail
	{

		public SspPageDetail_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SspPageDetail_NUIEventsProcess";
			SchemaUId = new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8974e567-f0e1-4ce6-96f5-d663ca93cb07");
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

	#region Class: SspPageDetail_NUIEventsProcess

	/// <exclude/>
	public class SspPageDetail_NUIEventsProcess : SspPageDetail_NUIEventsProcess<SspPageDetail>
	{

		public SspPageDetail_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SspPageDetail_NUIEventsProcess

	public partial class SspPageDetail_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SspPageDetailEventsProcess

	/// <exclude/>
	public class SspPageDetailEventsProcess : SspPageDetail_NUIEventsProcess
	{

		public SspPageDetailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

