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

	#region Class: RuleRelationSchema

	/// <exclude/>
	public class RuleRelationSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public RuleRelationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RuleRelationSchema(RuleRelationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RuleRelationSchema(RuleRelationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd");
			RealUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd");
			Name = "RuleRelation";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("409f998a-e2f9-45d5-80f0-72e58f6f5714")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("81cc6ff9-b3c0-41ac-9532-b2f8c8109b70")) == null) {
				Columns.Add(CreateEntitySchemaColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("660da5c1-37dd-4913-8e53-abf546136159")) == null) {
				Columns.Add(CreateEntitySchemaSearchUIdColumn());
			}
			if (Columns.FindByUId(new Guid("7d180e22-277d-4ddb-aedd-5b41c0f3019a")) == null) {
				Columns.Add(CreateEntitySchemaSearchColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("822820d3-efdf-40c9-ad63-6540c275d28d")) == null) {
				Columns.Add(CreateRuleColumn());
			}
			if (Columns.FindByUId(new Guid("a9098506-c700-415f-ad51-2d48879df1f4")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("409f998a-e2f9-45d5-80f0-72e58f6f5714"),
				Name = @"EntitySchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				ModifiedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("81cc6ff9-b3c0-41ac-9532-b2f8c8109b70"),
				Name = @"EntitySchemaColumnUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				ModifiedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaSearchUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("660da5c1-37dd-4913-8e53-abf546136159"),
				Name = @"EntitySchemaSearchUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				ModifiedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaSearchColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7d180e22-277d-4ddb-aedd-5b41c0f3019a"),
				Name = @"EntitySchemaSearchColumnUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				ModifiedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreateRuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("822820d3-efdf-40c9-ad63-6540c275d28d"),
				Name = @"Rule",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				ModifiedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a9098506-c700-415f-ad51-2d48879df1f4"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				ModifiedInSchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"),
				CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RuleRelation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RuleRelation_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new RuleRelationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RuleRelationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd"));
		}

		#endregion

	}

	#endregion

	#region Class: RuleRelation

	/// <summary>
	/// Rules for connecting emails to system sections.
	/// </summary>
	public class RuleRelation : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public RuleRelation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RuleRelation";
		}

		public RuleRelation(RuleRelation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Connect to entity.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Column to search notification in.
		/// </summary>
		public Guid EntitySchemaColumnUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaColumnUId");
			}
			set {
				SetColumnValue("EntitySchemaColumnUId", value);
			}
		}

		/// <summary>
		/// Search entity.
		/// </summary>
		public Guid EntitySchemaSearchUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaSearchUId");
			}
			set {
				SetColumnValue("EntitySchemaSearchUId", value);
			}
		}

		/// <summary>
		/// Column for comparison.
		/// </summary>
		public Guid EntitySchemaSearchColumnUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaSearchColumnUId");
			}
			set {
				SetColumnValue("EntitySchemaSearchColumnUId", value);
			}
		}

		/// <summary>
		/// Rule.
		/// </summary>
		public string Rule {
			get {
				return GetTypedColumnValue<string>("Rule");
			}
			set {
				SetColumnValue("Rule", value);
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
			var process = new RuleRelation_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("RuleRelationDeleted", e);
			Validating += (s, e) => ThrowEvent("RuleRelationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new RuleRelation(this);
		}

		#endregion

	}

	#endregion

	#region Class: RuleRelation_UIv2EventsProcess

	/// <exclude/>
	public partial class RuleRelation_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : RuleRelation
	{

		public RuleRelation_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RuleRelation_UIv2EventsProcess";
			SchemaUId = new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1be83bef-9c97-43f4-a578-a2fe0f45d7fd");
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

	#region Class: RuleRelation_UIv2EventsProcess

	/// <exclude/>
	public class RuleRelation_UIv2EventsProcess : RuleRelation_UIv2EventsProcess<RuleRelation>
	{

		public RuleRelation_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RuleRelation_UIv2EventsProcess

	public partial class RuleRelation_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RuleRelationEventsProcess

	/// <exclude/>
	public class RuleRelationEventsProcess : RuleRelation_UIv2EventsProcess
	{

		public RuleRelationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

