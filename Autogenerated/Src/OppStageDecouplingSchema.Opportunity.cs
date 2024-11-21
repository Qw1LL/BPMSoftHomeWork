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

	#region Class: OppStageDecouplingSchema

	/// <exclude/>
	public class OppStageDecouplingSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OppStageDecouplingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppStageDecouplingSchema(OppStageDecouplingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppStageDecouplingSchema(OppStageDecouplingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4");
			RealUId = new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4");
			Name = "OppStageDecoupling";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a37c3c35-b417-42d8-8c73-63c31edbc258")) == null) {
				Columns.Add(CreateCurrentStageColumn());
			}
			if (Columns.FindByUId(new Guid("5529de49-dda4-4235-bfd4-6a31f3f6739a")) == null) {
				Columns.Add(CreateAvailableStageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCurrentStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a37c3c35-b417-42d8-8c73-63c31edbc258"),
				Name = @"CurrentStage",
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4"),
				ModifiedInSchemaUId = new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4"),
				CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340")
			};
		}

		protected virtual EntitySchemaColumn CreateAvailableStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5529de49-dda4-4235-bfd4-6a31f3f6739a"),
				Name = @"AvailableStage",
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4"),
				ModifiedInSchemaUId = new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4"),
				CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OppStageDecoupling(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppStageDecoupling_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppStageDecouplingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppStageDecouplingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4"));
		}

		#endregion

	}

	#endregion

	#region Class: OppStageDecoupling

	/// <summary>
	/// Доступные переходы стадий.
	/// </summary>
	public class OppStageDecoupling : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OppStageDecoupling(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppStageDecoupling";
		}

		public OppStageDecoupling(OppStageDecoupling source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CurrentStageId {
			get {
				return GetTypedColumnValue<Guid>("CurrentStageId");
			}
			set {
				SetColumnValue("CurrentStageId", value);
				_currentStage = null;
			}
		}

		/// <exclude/>
		public string CurrentStageName {
			get {
				return GetTypedColumnValue<string>("CurrentStageName");
			}
			set {
				SetColumnValue("CurrentStageName", value);
				if (_currentStage != null) {
					_currentStage.Name = value;
				}
			}
		}

		private OpportunityStage _currentStage;
		/// <summary>
		/// Текущая стадия.
		/// </summary>
		public OpportunityStage CurrentStage {
			get {
				return _currentStage ??
					(_currentStage = LookupColumnEntities.GetEntity("CurrentStage") as OpportunityStage);
			}
		}

		/// <exclude/>
		public Guid AvailableStageId {
			get {
				return GetTypedColumnValue<Guid>("AvailableStageId");
			}
			set {
				SetColumnValue("AvailableStageId", value);
				_availableStage = null;
			}
		}

		/// <exclude/>
		public string AvailableStageName {
			get {
				return GetTypedColumnValue<string>("AvailableStageName");
			}
			set {
				SetColumnValue("AvailableStageName", value);
				if (_availableStage != null) {
					_availableStage.Name = value;
				}
			}
		}

		private OpportunityStage _availableStage;
		/// <summary>
		/// Доступная стадия.
		/// </summary>
		public OpportunityStage AvailableStage {
			get {
				return _availableStage ??
					(_availableStage = LookupColumnEntities.GetEntity("AvailableStage") as OpportunityStage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppStageDecoupling_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OppStageDecouplingDeleted", e);
			Validating += (s, e) => ThrowEvent("OppStageDecouplingValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OppStageDecoupling(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppStageDecoupling_OpportunityEventsProcess

	/// <exclude/>
	public partial class OppStageDecoupling_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OppStageDecoupling
	{

		public OppStageDecoupling_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppStageDecoupling_OpportunityEventsProcess";
			SchemaUId = new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b1f8b03d-3260-45fc-9040-5723673e36d4");
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

	#region Class: OppStageDecoupling_OpportunityEventsProcess

	/// <exclude/>
	public class OppStageDecoupling_OpportunityEventsProcess : OppStageDecoupling_OpportunityEventsProcess<OppStageDecoupling>
	{

		public OppStageDecoupling_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppStageDecoupling_OpportunityEventsProcess

	public partial class OppStageDecoupling_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OppStageDecouplingEventsProcess

	/// <exclude/>
	public class OppStageDecouplingEventsProcess : OppStageDecoupling_OpportunityEventsProcess
	{

		public OppStageDecouplingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

