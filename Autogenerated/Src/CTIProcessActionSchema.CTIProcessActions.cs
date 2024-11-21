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

	#region Class: CTIProcessActionSchema

	/// <exclude/>
	public class CTIProcessActionSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CTIProcessActionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CTIProcessActionSchema(CTIProcessActionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CTIProcessActionSchema(CTIProcessActionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01");
			RealUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01");
			Name = "CTIProcessAction";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ccb8f7c7-6ff2-443f-9c1f-d56a09d4a46e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4ae77582-8fe4-4bfd-a257-d702ec30eedb")) == null) {
				Columns.Add(CreateProcessSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("d4084ad4-f993-438f-a2f7-6caf85cf845e")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4ae77582-8fe4-4bfd-a257-d702ec30eedb"),
				Name = @"ProcessSchema",
				ReferenceSchemaUId = new Guid("842e74a2-e737-476c-b3d0-8aa3d5ddd229"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01"),
				ModifiedInSchemaUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01"),
				CreatedInPackageId = new Guid("ccb8f7c7-6ff2-443f-9c1f-d56a09d4a46e")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d4084ad4-f993-438f-a2f7-6caf85cf845e"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01"),
				ModifiedInSchemaUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01"),
				CreatedInPackageId = new Guid("ccb8f7c7-6ff2-443f-9c1f-d56a09d4a46e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CTIProcessAction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CTIProcessAction_CTIProcessActionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CTIProcessActionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CTIProcessActionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0245e67-492f-4805-b212-5ba4b722ef01"));
		}

		#endregion

	}

	#endregion

	#region Class: CTIProcessAction

	/// <summary>
	/// Действие cti панели.
	/// </summary>
	public class CTIProcessAction : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CTIProcessAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CTIProcessAction";
		}

		public CTIProcessAction(CTIProcessAction source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProcessSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaId");
			}
			set {
				SetColumnValue("ProcessSchemaId", value);
				_processSchema = null;
			}
		}

		/// <exclude/>
		public string ProcessSchemaCaption {
			get {
				return GetTypedColumnValue<string>("ProcessSchemaCaption");
			}
			set {
				SetColumnValue("ProcessSchemaCaption", value);
				if (_processSchema != null) {
					_processSchema.Caption = value;
				}
			}
		}

		private VwSysProcess _processSchema;
		/// <summary>
		/// Процесс.
		/// </summary>
		public VwSysProcess ProcessSchema {
			get {
				return _processSchema ??
					(_processSchema = LookupColumnEntities.GetEntity("ProcessSchema") as VwSysProcess);
			}
		}

		/// <summary>
		/// Позиция сортировки.
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
			var process = new CTIProcessAction_CTIProcessActionsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CTIProcessActionDeleted", e);
			Validating += (s, e) => ThrowEvent("CTIProcessActionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CTIProcessAction(this);
		}

		#endregion

	}

	#endregion

	#region Class: CTIProcessAction_CTIProcessActionsEventsProcess

	/// <exclude/>
	public partial class CTIProcessAction_CTIProcessActionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CTIProcessAction
	{

		public CTIProcessAction_CTIProcessActionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CTIProcessAction_CTIProcessActionsEventsProcess";
			SchemaUId = new Guid("b0245e67-492f-4805-b212-5ba4b722ef01");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b0245e67-492f-4805-b212-5ba4b722ef01");
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

	#region Class: CTIProcessAction_CTIProcessActionsEventsProcess

	/// <exclude/>
	public class CTIProcessAction_CTIProcessActionsEventsProcess : CTIProcessAction_CTIProcessActionsEventsProcess<CTIProcessAction>
	{

		public CTIProcessAction_CTIProcessActionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CTIProcessAction_CTIProcessActionsEventsProcess

	public partial class CTIProcessAction_CTIProcessActionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CTIProcessActionEventsProcess

	/// <exclude/>
	public class CTIProcessActionEventsProcess : CTIProcessAction_CTIProcessActionsEventsProcess
	{

		public CTIProcessActionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

