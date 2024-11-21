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

	#region Class: PlaybookSchema

	/// <exclude/>
	public class PlaybookSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PlaybookSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PlaybookSchema(PlaybookSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PlaybookSchema(PlaybookSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5");
			RealUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5");
			Name = "Playbook";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("71eff5a2-9fb7-403f-93aa-6f4f0c72caeb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e950c10d-11d4-b211-95e9-635f68ab2a62")) == null) {
				Columns.Add(CreateCultureColumn());
			}
			if (Columns.FindByUId(new Guid("b5722f44-34c3-a141-7322-b27be33622ab")) == null) {
				Columns.Add(CreateKnowledgeBaseColumn());
			}
			if (Columns.FindByUId(new Guid("5a19c0d4-8ff9-3f66-8e77-4eee0c3172dc")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("ea88b85b-bd96-3396-f054-95d50d1d33df")) == null) {
				Columns.Add(CreateStageIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e950c10d-11d4-b211-95e9-635f68ab2a62"),
				Name = @"Culture",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				ModifiedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				CreatedInPackageId = new Guid("71eff5a2-9fb7-403f-93aa-6f4f0c72caeb"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateKnowledgeBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b5722f44-34c3-a141-7322-b27be33622ab"),
				Name = @"KnowledgeBase",
				ReferenceSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				ModifiedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				CreatedInPackageId = new Guid("71eff5a2-9fb7-403f-93aa-6f4f0c72caeb")
			};
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5a19c0d4-8ff9-3f66-8e77-4eee0c3172dc"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				ModifiedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				CreatedInPackageId = new Guid("71eff5a2-9fb7-403f-93aa-6f4f0c72caeb")
			};
		}

		protected virtual EntitySchemaColumn CreateStageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ea88b85b-bd96-3396-f054-95d50d1d33df"),
				Name = @"StageId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				ModifiedInSchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"),
				CreatedInPackageId = new Guid("71eff5a2-9fb7-403f-93aa-6f4f0c72caeb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Playbook(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Playbook_PlaybookEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PlaybookSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PlaybookSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5"));
		}

		#endregion

	}

	#endregion

	#region Class: Playbook

	/// <summary>
	/// Сценарии.
	/// </summary>
	public class Playbook : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Playbook(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Playbook";
		}

		public Playbook(Playbook source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CultureId {
			get {
				return GetTypedColumnValue<Guid>("CultureId");
			}
			set {
				SetColumnValue("CultureId", value);
				_culture = null;
			}
		}

		/// <exclude/>
		public string CultureName {
			get {
				return GetTypedColumnValue<string>("CultureName");
			}
			set {
				SetColumnValue("CultureName", value);
				if (_culture != null) {
					_culture.Name = value;
				}
			}
		}

		private SysLanguage _culture;
		/// <summary>
		/// Культура.
		/// </summary>
		public SysLanguage Culture {
			get {
				return _culture ??
					(_culture = LookupColumnEntities.GetEntity("Culture") as SysLanguage);
			}
		}

		/// <exclude/>
		public Guid KnowledgeBaseId {
			get {
				return GetTypedColumnValue<Guid>("KnowledgeBaseId");
			}
			set {
				SetColumnValue("KnowledgeBaseId", value);
				_knowledgeBase = null;
			}
		}

		/// <exclude/>
		public string KnowledgeBaseName {
			get {
				return GetTypedColumnValue<string>("KnowledgeBaseName");
			}
			set {
				SetColumnValue("KnowledgeBaseName", value);
				if (_knowledgeBase != null) {
					_knowledgeBase.Name = value;
				}
			}
		}

		private KnowledgeBase _knowledgeBase;
		/// <summary>
		/// Статья базы знаний.
		/// </summary>
		public KnowledgeBase KnowledgeBase {
			get {
				return _knowledgeBase ??
					(_knowledgeBase = LookupColumnEntities.GetEntity("KnowledgeBase") as KnowledgeBase);
			}
		}

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseCaption {
			get {
				return GetTypedColumnValue<string>("CaseCaption");
			}
			set {
				SetColumnValue("CaseCaption", value);
				if (_case != null) {
					_case.Caption = value;
				}
			}
		}

		private SysSchema _case;
		/// <summary>
		/// Кейс раздела.
		/// </summary>
		public SysSchema Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as SysSchema);
			}
		}

		/// <summary>
		/// Стадия.
		/// </summary>
		public Guid StageId {
			get {
				return GetTypedColumnValue<Guid>("StageId");
			}
			set {
				SetColumnValue("StageId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Playbook_PlaybookEventsProcess(UserConnection);
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
			return new Playbook(this);
		}

		#endregion

	}

	#endregion

	#region Class: Playbook_PlaybookEventsProcess

	/// <exclude/>
	public partial class Playbook_PlaybookEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Playbook
	{

		public Playbook_PlaybookEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Playbook_PlaybookEventsProcess";
			SchemaUId = new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("03b6e0d3-5d54-4b4b-b27a-47cda46afbe5");
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

	#region Class: Playbook_PlaybookEventsProcess

	/// <exclude/>
	public class Playbook_PlaybookEventsProcess : Playbook_PlaybookEventsProcess<Playbook>
	{

		public Playbook_PlaybookEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Playbook_PlaybookEventsProcess

	public partial class Playbook_PlaybookEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PlaybookEventsProcess

	/// <exclude/>
	public class PlaybookEventsProcess : Playbook_PlaybookEventsProcess
	{

		public PlaybookEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

