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

	#region Class: OrgStructureUnitSchema

	/// <exclude/>
	public class OrgStructureUnitSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OrgStructureUnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrgStructureUnitSchema(OrgStructureUnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrgStructureUnitSchema(OrgStructureUnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78");
			RealUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78");
			Name = "OrgStructureUnit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3ca63a6c-408e-4eda-8709-b90f6e53b100")) == null) {
				Columns.Add(CreateHeadColumn());
			}
			if (Columns.FindByUId(new Guid("df2a3551-db10-4978-b899-7a39b12d8cba")) == null) {
				Columns.Add(CreateFullNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8858643f-8a0c-4296-9a67-5554a18ca191"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				ModifiedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateHeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3ca63a6c-408e-4eda-8709-b90f6e53b100"),
				Name = @"Head",
				ReferenceSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				ModifiedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("862f87f3-a9a3-43a5-9757-e02462c4af43"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				ModifiedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateFullNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("df2a3551-db10-4978-b899-7a39b12d8cba"),
				Name = @"FullName",
				CreatedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				ModifiedInSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrgStructureUnit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrgStructureUnit_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrgStructureUnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrgStructureUnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"));
		}

		#endregion

	}

	#endregion

	#region Class: OrgStructureUnit

	/// <summary>
	/// Organization structure item.
	/// </summary>
	public class OrgStructureUnit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OrgStructureUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrgStructureUnit";
		}

		public OrgStructureUnit(OrgStructureUnit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid HeadId {
			get {
				return GetTypedColumnValue<Guid>("HeadId");
			}
			set {
				SetColumnValue("HeadId", value);
				_head = null;
			}
		}

		/// <exclude/>
		public string HeadName {
			get {
				return GetTypedColumnValue<string>("HeadName");
			}
			set {
				SetColumnValue("HeadName", value);
				if (_head != null) {
					_head.Name = value;
				}
			}
		}

		private Employee _head;
		/// <summary>
		/// Head.
		/// </summary>
		public Employee Head {
			get {
				return _head ??
					(_head = LookupColumnEntities.GetEntity("Head") as Employee);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private OrgStructureUnit _parent;
		/// <summary>
		/// Parent department.
		/// </summary>
		public OrgStructureUnit Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as OrgStructureUnit);
			}
		}

		/// <summary>
		/// Full name.
		/// </summary>
		public string FullName {
			get {
				return GetTypedColumnValue<string>("FullName");
			}
			set {
				SetColumnValue("FullName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrgStructureUnit_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OrgStructureUnitDeleted", e);
			Saved += (s, e) => ThrowEvent("OrgStructureUnitSaved", e);
			Saving += (s, e) => ThrowEvent("OrgStructureUnitSaving", e);
			Validating += (s, e) => ThrowEvent("OrgStructureUnitValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrgStructureUnit(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrgStructureUnit_BaseEventsProcess

	/// <exclude/>
	public partial class OrgStructureUnit_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OrgStructureUnit
	{

		public OrgStructureUnit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrgStructureUnit_BaseEventsProcess";
			SchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _saving;
		public ProcessFlowElement Saving {
			get {
				return _saving ?? (_saving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "Saving",
					SchemaElementUId = new Guid("048a5ac7-1dcb-4a4d-ba2f-0626a2b6489f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _orgStructureUnitSaving;
		public ProcessFlowElement OrgStructureUnitSaving {
			get {
				return _orgStructureUnitSaving ?? (_orgStructureUnitSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OrgStructureUnitSaving",
					SchemaElementUId = new Guid("0fba99de-2a87-4039-a504-d681b523d964"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateFullName;
		public ProcessScriptTask UpdateFullName {
			get {
				return _updateFullName ?? (_updateFullName = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateFullName",
					SchemaElementUId = new Guid("7011afe9-1b23-4e29-9d31-aff6b12bfaae"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateFullNameExecute,
				});
			}
		}

		private ProcessFlowElement _saved;
		public ProcessFlowElement Saved {
			get {
				return _saved ?? (_saved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "Saved",
					SchemaElementUId = new Guid("72f5e463-789a-4e91-a155-d20b4c7d53d0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _orgStructureUnitSaved;
		public ProcessFlowElement OrgStructureUnitSaved {
			get {
				return _orgStructureUnitSaved ?? (_orgStructureUnitSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OrgStructureUnitSaved",
					SchemaElementUId = new Guid("588d1821-3d16-4313-bd01-e2f0b675e2ec"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateFullNameChild;
		public ProcessScriptTask UpdateFullNameChild {
			get {
				return _updateFullNameChild ?? (_updateFullNameChild = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateFullNameChild",
					SchemaElementUId = new Guid("bd06ab1d-0fe7-4c45-8f65-37a50b0a5806"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateFullNameChildExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Saving.SchemaElementUId] = new Collection<ProcessFlowElement> { Saving };
			FlowElements[OrgStructureUnitSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { OrgStructureUnitSaving };
			FlowElements[UpdateFullName.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateFullName };
			FlowElements[Saved.SchemaElementUId] = new Collection<ProcessFlowElement> { Saved };
			FlowElements[OrgStructureUnitSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { OrgStructureUnitSaved };
			FlowElements[UpdateFullNameChild.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateFullNameChild };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Saving":
						break;
					case "OrgStructureUnitSaving":
						e.Context.QueueTasks.Enqueue("UpdateFullName");
						break;
					case "UpdateFullName":
						break;
					case "Saved":
						break;
					case "OrgStructureUnitSaved":
						e.Context.QueueTasks.Enqueue("UpdateFullNameChild");
						break;
					case "UpdateFullNameChild":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("OrgStructureUnitSaving");
			ActivatedEventElements.Add("OrgStructureUnitSaved");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "Saving":
					context.QueueTasks.Dequeue();
					break;
				case "OrgStructureUnitSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "OrgStructureUnitSaving";
					result = OrgStructureUnitSaving.Execute(context);
					break;
				case "UpdateFullName":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateFullName";
					result = UpdateFullName.Execute(context, UpdateFullNameExecute);
					break;
				case "Saved":
					context.QueueTasks.Dequeue();
					break;
				case "OrgStructureUnitSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "OrgStructureUnitSaved";
					result = OrgStructureUnitSaved.Execute(context);
					break;
				case "UpdateFullNameChild":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateFullNameChild";
					result = UpdateFullNameChild.Execute(context, UpdateFullNameChildExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool UpdateFullNameExecute(ProcessExecutingContext context) {
			UpdateFullNameColumn();
			return true;
		}

		public virtual bool UpdateFullNameChildExecute(ProcessExecutingContext context) {
			UpdateFullNameColumnChild(Entity);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "OrgStructureUnitSaving":
							if (ActivatedEventElements.Contains("OrgStructureUnitSaving")) {
							context.QueueTasks.Enqueue("OrgStructureUnitSaving");
						}
						break;
					case "OrgStructureUnitSaved":
							if (ActivatedEventElements.Contains("OrgStructureUnitSaved")) {
							context.QueueTasks.Enqueue("OrgStructureUnitSaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OrgStructureUnit_BaseEventsProcess

	/// <exclude/>
	public class OrgStructureUnit_BaseEventsProcess : OrgStructureUnit_BaseEventsProcess<OrgStructureUnit>
	{

		public OrgStructureUnit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrgStructureUnit_BaseEventsProcess

	public partial class OrgStructureUnit_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateFullNameColumn() {
			string fullName = Entity.PrimaryDisplayColumnValue;
						Guid parentId = Entity.HierarchyColumnValue;
						if (parentId.IsNotEmpty()) {
							EntitySchema parentSchema = UserConnection.EntitySchemaManager.GetInstanceByName("OrgStructureUnit");
							Entity parentEntity = parentSchema.CreateEntity(UserConnection);
							if (parentEntity.FetchFromDB(parentSchema.PrimaryColumn.Name, parentId)) {
								string parentFullName = parentEntity.GetTypedColumnValue<string>("FullName");
								fullName = string.Concat(fullName, "/", parentFullName);
							}
						}
						Entity.SetColumnValue("FullName", fullName);
		}

		public virtual void UpdateFullNameColumnChild(Entity parentEntity) {
			Guid parentId = parentEntity.PrimaryColumnValue;
			string fullName = parentEntity.GetTypedColumnValue<string>("FullName");
			EntityCollection children = GetChildOrgStructureUnit(parentId);
			foreach (Entity child in children) {
				string childName = child.PrimaryDisplayColumnValue;
				string childFullName = string.Concat(childName, '/', fullName);
				child.SetColumnValue("FullName", childFullName);
				child.Save();
			}
		}

		public virtual EntityCollection GetChildOrgStructureUnit(Guid parentId) {
			EntitySchemaQuery esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OrgStructureUnit");
						esq.AddAllSchemaColumns();
						IEntitySchemaQueryFilterItem filter = esq.CreateFilterWithParameters(
						FilterComparisonType.Equal, esq.RootSchema.HierarchyColumn.Name, parentId);
						esq.Filters.Add(filter);
						return esq.GetEntityCollection(UserConnection);
		}

		#endregion

	}

	#endregion


	#region Class: OrgStructureUnitEventsProcess

	/// <exclude/>
	public class OrgStructureUnitEventsProcess : OrgStructureUnit_BaseEventsProcess
	{

		public OrgStructureUnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

