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

	#region Class: CampaignStepTypeSchema

	/// <exclude/>
	public class CampaignStepTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignStepTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignStepTypeSchema(CampaignStepTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignStepTypeSchema(CampaignStepTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441");
			RealUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441");
			Name = "CampaignStepType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3f44064e-7f37-41bb-a648-4f90693a6d57")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f7e813a4-8c82-4c3b-b07c-3593cba3ef48"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441"),
				ModifiedInSchemaUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3f44064e-7f37-41bb-a648-4f90693a6d57"),
				Name = @"SysSchemaUId",
				CreatedInSchemaUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441"),
				ModifiedInSchemaUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignStepType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignStepType_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignStepTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignStepTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("92569be4-cc39-48a3-a577-0bdb22f31441"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignStepType

	/// <summary>
	/// Тип шага кампании.
	/// </summary>
	public class CampaignStepType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignStepType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignStepType";
		}

		public CampaignStepType(CampaignStepType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Схема.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignStepType_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignStepTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignStepTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignStepType(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignStepType_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignStepType_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignStepType
	{

		public CampaignStepType_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignStepType_CampaignsEventsProcess";
			SchemaUId = new Guid("92569be4-cc39-48a3-a577-0bdb22f31441");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("92569be4-cc39-48a3-a577-0bdb22f31441");
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

	#region Class: CampaignStepType_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignStepType_CampaignsEventsProcess : CampaignStepType_CampaignsEventsProcess<CampaignStepType>
	{

		public CampaignStepType_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignStepType_CampaignsEventsProcess

	public partial class CampaignStepType_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignStepTypeEventsProcess

	/// <exclude/>
	public class CampaignStepTypeEventsProcess : CampaignStepType_CampaignsEventsProcess
	{

		public CampaignStepTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

