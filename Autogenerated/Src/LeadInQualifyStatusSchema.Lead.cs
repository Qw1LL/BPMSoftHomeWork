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

	#region Class: LeadInQualifyStatus_Lead_BPMSoftSchema

	/// <exclude/>
	public class LeadInQualifyStatus_Lead_BPMSoftSchema : BPMSoft.Configuration.BaseEntityInStageSchema
	{

		#region Constructors: Public

		public LeadInQualifyStatus_Lead_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadInQualifyStatus_Lead_BPMSoftSchema(LeadInQualifyStatus_Lead_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadInQualifyStatus_Lead_BPMSoftSchema(LeadInQualifyStatus_Lead_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1");
			RealUId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1");
			Name = "LeadInQualifyStatus_Lead_BPMSoft";
			ParentSchemaUId = new Guid("86cb4c67-4231-4904-be40-b9019d87311d");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f9fafc40-d3f4-4cb9-84c5-854e0eeffd97");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c206c35e-5504-4e34-905b-d59ab54f754e")) == null) {
				Columns.Add(CreateLeadColumn());
			}
			if (Columns.FindByUId(new Guid("e02b4e41-afa4-4124-9d4d-ba9b1ddf14a0")) == null) {
				Columns.Add(CreateQualifyStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c206c35e-5504-4e34-905b-d59ab54f754e"),
				Name = @"Lead",
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1"),
				ModifiedInSchemaUId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1"),
				CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06")
			};
		}

		protected virtual EntitySchemaColumn CreateQualifyStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e02b4e41-afa4-4124-9d4d-ba9b1ddf14a0"),
				Name = @"QualifyStatus",
				ReferenceSchemaUId = new Guid("22341cd1-5b33-4c40-9011-6f7693ef6e44"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1"),
				ModifiedInSchemaUId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1"),
				CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadInQualifyStatus_Lead_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadInQualifyStatus_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadInQualifyStatus_Lead_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadInQualifyStatus_Lead_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadInQualifyStatus_Lead_BPMSoft

	/// <summary>
	/// Стадия в лиде.
	/// </summary>
	public class LeadInQualifyStatus_Lead_BPMSoft : BPMSoft.Configuration.BaseEntityInStage
	{

		#region Constructors: Public

		public LeadInQualifyStatus_Lead_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadInQualifyStatus_Lead_BPMSoft";
		}

		public LeadInQualifyStatus_Lead_BPMSoft(LeadInQualifyStatus_Lead_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = LookupColumnEntities.GetEntity("Lead") as Lead);
			}
		}

		/// <exclude/>
		public Guid QualifyStatusId {
			get {
				return GetTypedColumnValue<Guid>("QualifyStatusId");
			}
			set {
				SetColumnValue("QualifyStatusId", value);
				_qualifyStatus = null;
			}
		}

		/// <exclude/>
		public string QualifyStatusName {
			get {
				return GetTypedColumnValue<string>("QualifyStatusName");
			}
			set {
				SetColumnValue("QualifyStatusName", value);
				if (_qualifyStatus != null) {
					_qualifyStatus.Name = value;
				}
			}
		}

		private QualifyStatus _qualifyStatus;
		/// <summary>
		/// Стадия лида.
		/// </summary>
		public QualifyStatus QualifyStatus {
			get {
				return _qualifyStatus ??
					(_qualifyStatus = LookupColumnEntities.GetEntity("QualifyStatus") as QualifyStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadInQualifyStatus_LeadEventsProcess(UserConnection);
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
			return new LeadInQualifyStatus_Lead_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadInQualifyStatus_LeadEventsProcess

	/// <exclude/>
	public partial class LeadInQualifyStatus_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInStage_BaseEventsProcess<TEntity> where TEntity : LeadInQualifyStatus_Lead_BPMSoft
	{

		public LeadInQualifyStatus_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadInQualifyStatus_LeadEventsProcess";
			SchemaUId = new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("071aba13-b2b4-4050-aa8f-dab49a65b4b1");
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

	#region Class: LeadInQualifyStatus_LeadEventsProcess

	/// <exclude/>
	public class LeadInQualifyStatus_LeadEventsProcess : LeadInQualifyStatus_LeadEventsProcess<LeadInQualifyStatus_Lead_BPMSoft>
	{

		public LeadInQualifyStatus_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadInQualifyStatus_LeadEventsProcess

	public partial class LeadInQualifyStatus_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

