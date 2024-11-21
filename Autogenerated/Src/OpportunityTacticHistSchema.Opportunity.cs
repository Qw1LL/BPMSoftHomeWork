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

	#region Class: OpportunityTacticHistSchema

	/// <exclude/>
	public class OpportunityTacticHistSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OpportunityTacticHistSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityTacticHistSchema(OpportunityTacticHistSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityTacticHistSchema(OpportunityTacticHistSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			RealUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			Name = "OpportunityTacticHist";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("beceea29-c777-4c3c-8f75-1dcf744669f1")) == null) {
				Columns.Add(CreateTacticsColumn());
			}
			if (Columns.FindByUId(new Guid("e8795bde-27ed-4fd4-8f16-c65a2fc3916e")) == null) {
				Columns.Add(CreateCheckDateColumn());
			}
			if (Columns.FindByUId(new Guid("7c4a4905-83b5-46ce-8e55-91462c2d11dc")) == null) {
				Columns.Add(CreateModifyDateColumn());
			}
			if (Columns.FindByUId(new Guid("22fce03b-6a18-46ef-b5fc-24f55aa83663")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			column.CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			column.CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			column.CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			column.CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			column.CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			column.CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTacticsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("beceea29-c777-4c3c-8f75-1dcf744669f1"),
				Name = @"Tactics",
				CreatedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a")
			};
		}

		protected virtual EntitySchemaColumn CreateCheckDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("e8795bde-27ed-4fd4-8f16-c65a2fc3916e"),
				Name = @"CheckDate",
				CreatedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a")
			};
		}

		protected virtual EntitySchemaColumn CreateModifyDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("7c4a4905-83b5-46ce-8e55-91462c2d11dc"),
				Name = @"ModifyDate",
				CreatedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a")
			};
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("22fce03b-6a18-46ef-b5fc-24f55aa83663"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				ModifiedInSchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"),
				CreatedInPackageId = new Guid("e899430a-48fa-4f6a-9b67-5894fb68c21a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityTacticHist(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityTacticHist_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityTacticHistSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityTacticHistSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityTacticHist

	/// <summary>
	/// История изменения тактики продажи.
	/// </summary>
	public class OpportunityTacticHist : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OpportunityTacticHist(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityTacticHist";
		}

		public OpportunityTacticHist(OpportunityTacticHist source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Тактика продажи.
		/// </summary>
		public string Tactics {
			get {
				return GetTypedColumnValue<string>("Tactics");
			}
			set {
				SetColumnValue("Tactics", value);
			}
		}

		/// <summary>
		/// Дата проверки руководителем.
		/// </summary>
		public DateTime CheckDate {
			get {
				return GetTypedColumnValue<DateTime>("CheckDate");
			}
			set {
				SetColumnValue("CheckDate", value);
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifyDate {
			get {
				return GetTypedColumnValue<DateTime>("ModifyDate");
			}
			set {
				SetColumnValue("ModifyDate", value);
			}
		}

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityTacticHist_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityTacticHistDeleted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityTacticHistInserting", e);
			Validating += (s, e) => ThrowEvent("OpportunityTacticHistValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityTacticHist(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityTacticHist_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityTacticHist_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OpportunityTacticHist
	{

		public OpportunityTacticHist_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityTacticHist_OpportunityEventsProcess";
			SchemaUId = new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fa59b9ec-2339-465b-80c3-b4928fa0ea33");
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

	#region Class: OpportunityTacticHist_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityTacticHist_OpportunityEventsProcess : OpportunityTacticHist_OpportunityEventsProcess<OpportunityTacticHist>
	{

		public OpportunityTacticHist_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityTacticHist_OpportunityEventsProcess

	public partial class OpportunityTacticHist_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityTacticHistEventsProcess

	/// <exclude/>
	public class OpportunityTacticHistEventsProcess : OpportunityTacticHist_OpportunityEventsProcess
	{

		public OpportunityTacticHistEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

