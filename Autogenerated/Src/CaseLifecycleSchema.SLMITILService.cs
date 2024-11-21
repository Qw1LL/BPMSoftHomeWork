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

	#region Class: CaseLifecycleSchema

	/// <exclude/>
	public class CaseLifecycleSchema : BPMSoft.Configuration.CaseLifecycle_SLM_BPMSoftSchema
	{

		#region Constructors: Public

		public CaseLifecycleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseLifecycleSchema(CaseLifecycleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseLifecycleSchema(CaseLifecycleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_CaseRecordId_EndDateIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("d832ee65-a541-4638-98b6-25d3d1ffbf9f");
			index.Name = "IX_CaseRecordId_EndDate";
			index.CreatedInSchemaUId = new Guid("9e784f54-ca3c-4052-81da-c3eb95cabfaf");
			index.ModifiedInSchemaUId = new Guid("9e784f54-ca3c-4052-81da-c3eb95cabfaf");
			index.CreatedInPackageId = new Guid("5c519463-1fa4-4c1e-acaf-02bcff203125");
			EntitySchemaIndexColumn caseRecordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("054d23a6-276d-fd6d-099c-418b845103d2"),
				ColumnUId = new Guid("bb326767-708c-4218-803e-3c27a854b4a5"),
				CreatedInSchemaUId = new Guid("9e784f54-ca3c-4052-81da-c3eb95cabfaf"),
				ModifiedInSchemaUId = new Guid("9e784f54-ca3c-4052-81da-c3eb95cabfaf"),
				CreatedInPackageId = new Guid("5c519463-1fa4-4c1e-acaf-02bcff203125"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(caseRecordIdIndexColumn);
			EntitySchemaIndexColumn endDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fc285a80-e179-afa5-96f2-4ccf10e4e832"),
				ColumnUId = new Guid("7ab897fc-723d-4308-a5d5-7a14c468b68a"),
				CreatedInSchemaUId = new Guid("9e784f54-ca3c-4052-81da-c3eb95cabfaf"),
				ModifiedInSchemaUId = new Guid("9e784f54-ca3c-4052-81da-c3eb95cabfaf"),
				CreatedInPackageId = new Guid("5c519463-1fa4-4c1e-acaf-02bcff203125"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(endDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("eb075ee7-4ffc-4c9d-822a-65bab75ae764");
			Name = "CaseLifecycle";
			ParentSchemaUId = new Guid("9e784f54-ca3c-4052-81da-c3eb95cabfaf");
			ExtendParent = true;
			CreatedInPackageId = new Guid("5be0374d-f3b5-4c63-b887-7fd46e962c93");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1769840a-0346-4e19-9860-08f03aee638f")) == null) {
				Columns.Add(CreateSupportLevelColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSupportLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1769840a-0346-4e19-9860-08f03aee638f"),
				Name = @"SupportLevel",
				ReferenceSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eb075ee7-4ffc-4c9d-822a-65bab75ae764"),
				ModifiedInSchemaUId = new Guid("eb075ee7-4ffc-4c9d-822a-65bab75ae764"),
				CreatedInPackageId = new Guid("5be0374d-f3b5-4c63-b887-7fd46e962c93")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_CaseRecordId_EndDateIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseLifecycle(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseLifecycle_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseLifecycleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseLifecycleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb075ee7-4ffc-4c9d-822a-65bab75ae764"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseLifecycle

	/// <summary>
	/// Жизненный цикл обращения.
	/// </summary>
	public class CaseLifecycle : BPMSoft.Configuration.CaseLifecycle_SLM_BPMSoft
	{

		#region Constructors: Public

		public CaseLifecycle(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseLifecycle";
		}

		public CaseLifecycle(CaseLifecycle source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SupportLevelId {
			get {
				return GetTypedColumnValue<Guid>("SupportLevelId");
			}
			set {
				SetColumnValue("SupportLevelId", value);
				_supportLevel = null;
			}
		}

		/// <exclude/>
		public string SupportLevelName {
			get {
				return GetTypedColumnValue<string>("SupportLevelName");
			}
			set {
				SetColumnValue("SupportLevelName", value);
				if (_supportLevel != null) {
					_supportLevel.Name = value;
				}
			}
		}

		private RoleInServiceTeam _supportLevel;
		/// <summary>
		/// Уровень поддержки.
		/// </summary>
		public RoleInServiceTeam SupportLevel {
			get {
				return _supportLevel ??
					(_supportLevel = LookupColumnEntities.GetEntity("SupportLevel") as RoleInServiceTeam);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseLifecycle_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CaseLifecycleDeleted", e);
			Validating += (s, e) => ThrowEvent("CaseLifecycleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseLifecycle(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseLifecycle_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class CaseLifecycle_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.CaseLifecycle_SLMEventsProcess<TEntity> where TEntity : CaseLifecycle
	{

		public CaseLifecycle_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseLifecycle_SLMITILServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eb075ee7-4ffc-4c9d-822a-65bab75ae764");
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

	#region Class: CaseLifecycle_SLMITILServiceEventsProcess

	/// <exclude/>
	public class CaseLifecycle_SLMITILServiceEventsProcess : CaseLifecycle_SLMITILServiceEventsProcess<CaseLifecycle>
	{

		public CaseLifecycle_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseLifecycle_SLMITILServiceEventsProcess

	public partial class CaseLifecycle_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CaseLifecycleEventsProcess

	/// <exclude/>
	public class CaseLifecycleEventsProcess : CaseLifecycle_SLMITILServiceEventsProcess
	{

		public CaseLifecycleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

