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

	#region Class: SpecificationInLead_CoreLead_BPMSoftSchema

	/// <exclude/>
	public class SpecificationInLead_CoreLead_BPMSoftSchema : BPMSoft.Configuration.SpecificationInObjectSchema
	{

		#region Constructors: Public

		public SpecificationInLead_CoreLead_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SpecificationInLead_CoreLead_BPMSoftSchema(SpecificationInLead_CoreLead_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SpecificationInLead_CoreLead_BPMSoftSchema(SpecificationInLead_CoreLead_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260");
			RealUId = new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260");
			Name = "SpecificationInLead_CoreLead_BPMSoft";
			ParentSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			ExtendParent = false;
			CreatedInPackageId = new Guid("54134837-7fc8-4b56-b76f-58aae2c14bff");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("372c9ece-04d1-4a5c-a4c3-470c207c9000")) == null) {
				Columns.Add(CreateLeadColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("372c9ece-04d1-4a5c-a4c3-470c207c9000"),
				Name = @"Lead",
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260"),
				ModifiedInSchemaUId = new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260"),
				CreatedInPackageId = new Guid("54134837-7fc8-4b56-b76f-58aae2c14bff")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SpecificationInLead_CoreLead_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SpecificationInLead_CoreLeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SpecificationInLead_CoreLead_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SpecificationInLead_CoreLead_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260"));
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInLead_CoreLead_BPMSoft

	/// <summary>
	/// Характеристика потребности.
	/// </summary>
	public class SpecificationInLead_CoreLead_BPMSoft : BPMSoft.Configuration.SpecificationInObject
	{

		#region Constructors: Public

		public SpecificationInLead_CoreLead_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SpecificationInLead_CoreLead_BPMSoft";
		}

		public SpecificationInLead_CoreLead_BPMSoft(SpecificationInLead_CoreLead_BPMSoft source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SpecificationInLead_CoreLeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SpecificationInLead_CoreLead_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("SpecificationInLead_CoreLead_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SpecificationInLead_CoreLead_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInLead_CoreLeadEventsProcess

	/// <exclude/>
	public partial class SpecificationInLead_CoreLeadEventsProcess<TEntity> : BPMSoft.Configuration.SpecificationInObject_SpecificationEventsProcess<TEntity> where TEntity : SpecificationInLead_CoreLead_BPMSoft
	{

		public SpecificationInLead_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SpecificationInLead_CoreLeadEventsProcess";
			SchemaUId = new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260");
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

	#region Class: SpecificationInLead_CoreLeadEventsProcess

	/// <exclude/>
	public class SpecificationInLead_CoreLeadEventsProcess : SpecificationInLead_CoreLeadEventsProcess<SpecificationInLead_CoreLead_BPMSoft>
	{

		public SpecificationInLead_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SpecificationInLead_CoreLeadEventsProcess

	public partial class SpecificationInLead_CoreLeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

