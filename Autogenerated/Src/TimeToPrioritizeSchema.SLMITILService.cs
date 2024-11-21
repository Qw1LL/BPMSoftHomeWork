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

	#region Class: TimeToPrioritizeSchema

	/// <exclude/>
	public class TimeToPrioritizeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TimeToPrioritizeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TimeToPrioritizeSchema(TimeToPrioritizeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TimeToPrioritizeSchema(TimeToPrioritizeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c");
			RealUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c");
			Name = "TimeToPrioritize";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b1b5135e-fd3e-44e4-800e-77e2e4ea1dc7")) == null) {
				Columns.Add(CreateCasePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("063dffcd-c5db-49d4-be17-325e1933c532")) == null) {
				Columns.Add(CreateReactionTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("90bded78-97f2-4922-a5c5-b7dbed3b2fa2")) == null) {
				Columns.Add(CreateReactionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("eab15b3f-a9be-4d9f-893a-ed4637ea145f")) == null) {
				Columns.Add(CreateSolutionTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("7d9d92cb-2044-4e16-8ad8-0674199646c0")) == null) {
				Columns.Add(CreateSolutionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("6a37ee82-3cac-42a4-859f-64998d01f90e")) == null) {
				Columns.Add(CreateServiceInServicePactColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCasePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b1b5135e-fd3e-44e4-800e-77e2e4ea1dc7"),
				Name = @"CasePriority",
				ReferenceSchemaUId = new Guid("e662865c-728f-40db-b3dd-15dcf46d47df"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				ModifiedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("063dffcd-c5db-49d4-be17-325e1933c532"),
				Name = @"ReactionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				ModifiedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("90bded78-97f2-4922-a5c5-b7dbed3b2fa2"),
				Name = @"ReactionTimeValue",
				CreatedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				ModifiedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eab15b3f-a9be-4d9f-893a-ed4637ea145f"),
				Name = @"SolutionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				ModifiedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7d9d92cb-2044-4e16-8ad8-0674199646c0"),
				Name = @"SolutionTimeValue",
				CreatedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				ModifiedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceInServicePactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6a37ee82-3cac-42a4-859f-64998d01f90e"),
				Name = @"ServiceInServicePact",
				ReferenceSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				ModifiedInSchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"),
				CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TimeToPrioritize(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TimeToPrioritize_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TimeToPrioritizeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TimeToPrioritizeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c"));
		}

		#endregion

	}

	#endregion

	#region Class: TimeToPrioritize

	/// <summary>
	/// Сроки по приоритетам.
	/// </summary>
	public class TimeToPrioritize : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TimeToPrioritize(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TimeToPrioritize";
		}

		public TimeToPrioritize(TimeToPrioritize source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CasePriorityId {
			get {
				return GetTypedColumnValue<Guid>("CasePriorityId");
			}
			set {
				SetColumnValue("CasePriorityId", value);
				_casePriority = null;
			}
		}

		/// <exclude/>
		public string CasePriorityName {
			get {
				return GetTypedColumnValue<string>("CasePriorityName");
			}
			set {
				SetColumnValue("CasePriorityName", value);
				if (_casePriority != null) {
					_casePriority.Name = value;
				}
			}
		}

		private CasePriority _casePriority;
		/// <summary>
		/// Приоритет обращения.
		/// </summary>
		public CasePriority CasePriority {
			get {
				return _casePriority ??
					(_casePriority = LookupColumnEntities.GetEntity("CasePriority") as CasePriority);
			}
		}

		/// <exclude/>
		public Guid ReactionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("ReactionTimeUnitId");
			}
			set {
				SetColumnValue("ReactionTimeUnitId", value);
				_reactionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string ReactionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("ReactionTimeUnitName");
			}
			set {
				SetColumnValue("ReactionTimeUnitName", value);
				if (_reactionTimeUnit != null) {
					_reactionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _reactionTimeUnit;
		/// <summary>
		/// Единица времени реакции.
		/// </summary>
		public TimeUnit ReactionTimeUnit {
			get {
				return _reactionTimeUnit ??
					(_reactionTimeUnit = LookupColumnEntities.GetEntity("ReactionTimeUnit") as TimeUnit);
			}
		}

		/// <summary>
		/// Значение времени реакции.
		/// </summary>
		public int ReactionTimeValue {
			get {
				return GetTypedColumnValue<int>("ReactionTimeValue");
			}
			set {
				SetColumnValue("ReactionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid SolutionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("SolutionTimeUnitId");
			}
			set {
				SetColumnValue("SolutionTimeUnitId", value);
				_solutionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string SolutionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("SolutionTimeUnitName");
			}
			set {
				SetColumnValue("SolutionTimeUnitName", value);
				if (_solutionTimeUnit != null) {
					_solutionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _solutionTimeUnit;
		/// <summary>
		/// Единица времени разрешения.
		/// </summary>
		public TimeUnit SolutionTimeUnit {
			get {
				return _solutionTimeUnit ??
					(_solutionTimeUnit = LookupColumnEntities.GetEntity("SolutionTimeUnit") as TimeUnit);
			}
		}

		/// <summary>
		/// Значение времени разрешения.
		/// </summary>
		public int SolutionTimeValue {
			get {
				return GetTypedColumnValue<int>("SolutionTimeValue");
			}
			set {
				SetColumnValue("SolutionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid ServiceInServicePactId {
			get {
				return GetTypedColumnValue<Guid>("ServiceInServicePactId");
			}
			set {
				SetColumnValue("ServiceInServicePactId", value);
				_serviceInServicePact = null;
			}
		}

		/// <exclude/>
		public string ServiceInServicePactConcatName {
			get {
				return GetTypedColumnValue<string>("ServiceInServicePactConcatName");
			}
			set {
				SetColumnValue("ServiceInServicePactConcatName", value);
				if (_serviceInServicePact != null) {
					_serviceInServicePact.ConcatName = value;
				}
			}
		}

		private ServiceInServicePact _serviceInServicePact;
		/// <summary>
		/// Сервис в сервисном договоре.
		/// </summary>
		public ServiceInServicePact ServiceInServicePact {
			get {
				return _serviceInServicePact ??
					(_serviceInServicePact = LookupColumnEntities.GetEntity("ServiceInServicePact") as ServiceInServicePact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TimeToPrioritize_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TimeToPrioritizeDeleted", e);
			Validating += (s, e) => ThrowEvent("TimeToPrioritizeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TimeToPrioritize(this);
		}

		#endregion

	}

	#endregion

	#region Class: TimeToPrioritize_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class TimeToPrioritize_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TimeToPrioritize
	{

		public TimeToPrioritize_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TimeToPrioritize_SLMITILServiceEventsProcess";
			SchemaUId = new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f0740e3e-3dce-4594-9495-b306e3d1751c");
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

	#region Class: TimeToPrioritize_SLMITILServiceEventsProcess

	/// <exclude/>
	public class TimeToPrioritize_SLMITILServiceEventsProcess : TimeToPrioritize_SLMITILServiceEventsProcess<TimeToPrioritize>
	{

		public TimeToPrioritize_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TimeToPrioritize_SLMITILServiceEventsProcess

	public partial class TimeToPrioritize_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TimeToPrioritizeEventsProcess

	/// <exclude/>
	public class TimeToPrioritizeEventsProcess : TimeToPrioritize_SLMITILServiceEventsProcess
	{

		public TimeToPrioritizeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

