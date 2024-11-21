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

	#region Class: ProcessInDetailsSchema

	/// <exclude/>
	public class ProcessInDetailsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProcessInDetailsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProcessInDetailsSchema(ProcessInDetailsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProcessInDetailsSchema(ProcessInDetailsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1");
			RealUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1");
			Name = "ProcessInDetails";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b6dd8d56-fd8d-40e5-b50e-aecf2d262cac");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("84fb9a32-2aca-43ff-94b3-b4a4341a661c")) == null) {
				Columns.Add(CreateSysDetailColumn());
			}
			if (Columns.FindByUId(new Guid("7a2937e6-2e2a-490e-9dd9-861310dea9d5")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5a304ad7-4188-4bd4-93d6-dcf9b208637b")) == null) {
				Columns.Add(CreateParameterUIdColumn());
			}
			if (Columns.FindByUId(new Guid("73b7150a-64e1-4276-bd2d-0841d946a4ab")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysDetailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("84fb9a32-2aca-43ff-94b3-b4a4341a661c"),
				Name = @"SysDetail",
				ReferenceSchemaUId = new Guid("363c2008-c733-407d-9b01-9e6a7cd9a77a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				ModifiedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				CreatedInPackageId = new Guid("b6dd8d56-fd8d-40e5-b50e-aecf2d262cac")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7a2937e6-2e2a-490e-9dd9-861310dea9d5"),
				Name = @"SysSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				ModifiedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				CreatedInPackageId = new Guid("b6dd8d56-fd8d-40e5-b50e-aecf2d262cac")
			};
		}

		protected virtual EntitySchemaColumn CreateParameterUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5a304ad7-4188-4bd4-93d6-dcf9b208637b"),
				Name = @"ParameterUId",
				CreatedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				ModifiedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				CreatedInPackageId = new Guid("b6dd8d56-fd8d-40e5-b50e-aecf2d262cac")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("73b7150a-64e1-4276-bd2d-0841d946a4ab"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				ModifiedInSchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1"),
				CreatedInPackageId = new Guid("b6dd8d56-fd8d-40e5-b50e-aecf2d262cac")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProcessInDetails(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProcessInDetails_WizardsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProcessInDetailsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProcessInDetailsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("71b8901e-bf90-466c-95a2-7970888556f1"));
		}

		#endregion

	}

	#endregion

	#region Class: ProcessInDetails

	/// <summary>
	/// ProcessInDetails.
	/// </summary>
	public class ProcessInDetails : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProcessInDetails(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProcessInDetails";
		}

		public ProcessInDetails(ProcessInDetails source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Detail.
		/// </summary>
		public SysDetail SysDetail {
			get {
				return _sysDetail ??
					(_sysDetail = LookupColumnEntities.GetEntity("SysDetail") as SysDetail);
			}
		}

		/// <summary>
		/// Process.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		/// <summary>
		/// Parameter.
		/// </summary>
		public Guid ParameterUId {
			get {
				return GetTypedColumnValue<Guid>("ParameterUId");
			}
			set {
				SetColumnValue("ParameterUId", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProcessInDetails_WizardsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProcessInDetailsDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProcessInDetails(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProcessInDetails_WizardsEventsProcess

	/// <exclude/>
	public partial class ProcessInDetails_WizardsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ProcessInDetails
	{

		public ProcessInDetails_WizardsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProcessInDetails_WizardsEventsProcess";
			SchemaUId = new Guid("71b8901e-bf90-466c-95a2-7970888556f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("71b8901e-bf90-466c-95a2-7970888556f1");
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

	#region Class: ProcessInDetails_WizardsEventsProcess

	/// <exclude/>
	public class ProcessInDetails_WizardsEventsProcess : ProcessInDetails_WizardsEventsProcess<ProcessInDetails>
	{

		public ProcessInDetails_WizardsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProcessInDetails_WizardsEventsProcess

	public partial class ProcessInDetails_WizardsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProcessInDetailsEventsProcess

	/// <exclude/>
	public class ProcessInDetailsEventsProcess : ProcessInDetails_WizardsEventsProcess
	{

		public ProcessInDetailsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

