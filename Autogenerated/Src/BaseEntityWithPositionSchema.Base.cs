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

	#region Class: BaseEntityWithPositionSchema

	/// <exclude/>
	public class BaseEntityWithPositionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseEntityWithPositionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEntityWithPositionSchema(BaseEntityWithPositionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEntityWithPositionSchema(BaseEntityWithPositionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			RealUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			Name = "BaseEntityWithPosition";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bd12ea8e-2bc2-42bf-925a-3ab766cc0b9f")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			column.CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			column.CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			column.CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			column.CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			column.CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			column.CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bd12ea8e-2bc2-42bf-925a-3ab766cc0b9f"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96"),
				ModifiedInSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96"),
				CreatedInPackageId = new Guid("ebb032c2-3bb4-4c12-8c8f-06bf89edc886")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseEntityWithPosition(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEntityWithPosition_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEntityWithPositionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEntityWithPositionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityWithPosition

	/// <summary>
	/// Base object with position.
	/// </summary>
	public class BaseEntityWithPosition : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseEntityWithPosition(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEntityWithPosition";
		}

		public BaseEntityWithPosition(BaseEntityWithPosition source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new BaseEntityWithPosition_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseEntityWithPositionDeleted", e);
			Inserting += (s, e) => ThrowEvent("BaseEntityWithPositionInserting", e);
			Validating += (s, e) => ThrowEvent("BaseEntityWithPositionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseEntityWithPosition(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityWithPosition_BaseEventsProcess

	/// <exclude/>
	public partial class BaseEntityWithPosition_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseEntityWithPosition
	{

		public BaseEntityWithPosition_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEntityWithPosition_BaseEventsProcess";
			SchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("a5c75974-954a-44a7-b7b1-b7037b7a51bb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityWithPositionInsertingMessage;
		public ProcessFlowElement BaseEntityWithPositionInsertingMessage {
			get {
				return _baseEntityWithPositionInsertingMessage ?? (_baseEntityWithPositionInsertingMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityWithPositionInsertingMessage",
					SchemaElementUId = new Guid("41cb22eb-a906-41e3-9eb0-669bde29d29a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityWithPositionDeletedMessage;
		public ProcessFlowElement BaseEntityWithPositionDeletedMessage {
			get {
				return _baseEntityWithPositionDeletedMessage ?? (_baseEntityWithPositionDeletedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityWithPositionDeletedMessage",
					SchemaElementUId = new Guid("9996a79b-d08b-46a0-9f67-2762996b1184"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEntityWithPositionInsertingScript;
		public ProcessScriptTask BaseEntityWithPositionInsertingScript {
			get {
				return _baseEntityWithPositionInsertingScript ?? (_baseEntityWithPositionInsertingScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntityWithPositionInsertingScript",
					SchemaElementUId = new Guid("12409027-1538-4f00-ae12-1b71898a4401"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntityWithPositionInsertingScriptExecute,
				});
			}
		}

		private ProcessScriptTask _baseEntityWithPositionDeletedScript;
		public ProcessScriptTask BaseEntityWithPositionDeletedScript {
			get {
				return _baseEntityWithPositionDeletedScript ?? (_baseEntityWithPositionDeletedScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntityWithPositionDeletedScript",
					SchemaElementUId = new Guid("ca7b49f2-04eb-4e9b-af9e-4f1a62d61fa5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntityWithPositionDeletedScriptExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[BaseEntityWithPositionInsertingMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityWithPositionInsertingMessage };
			FlowElements[BaseEntityWithPositionDeletedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityWithPositionDeletedMessage };
			FlowElements[BaseEntityWithPositionInsertingScript.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityWithPositionInsertingScript };
			FlowElements[BaseEntityWithPositionDeletedScript.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityWithPositionDeletedScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "BaseEntityWithPositionInsertingMessage":
						e.Context.QueueTasks.Enqueue("BaseEntityWithPositionInsertingScript");
						break;
					case "BaseEntityWithPositionDeletedMessage":
						e.Context.QueueTasks.Enqueue("BaseEntityWithPositionDeletedScript");
						break;
					case "BaseEntityWithPositionInsertingScript":
						break;
					case "BaseEntityWithPositionDeletedScript":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseEntityWithPositionInsertingMessage");
			ActivatedEventElements.Add("BaseEntityWithPositionDeletedMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityWithPositionInsertingMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityWithPositionInsertingMessage";
					result = BaseEntityWithPositionInsertingMessage.Execute(context);
					break;
				case "BaseEntityWithPositionDeletedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityWithPositionDeletedMessage";
					result = BaseEntityWithPositionDeletedMessage.Execute(context);
					break;
				case "BaseEntityWithPositionInsertingScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityWithPositionInsertingScript";
					result = BaseEntityWithPositionInsertingScript.Execute(context, BaseEntityWithPositionInsertingScriptExecute);
					break;
				case "BaseEntityWithPositionDeletedScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityWithPositionDeletedScript";
					result = BaseEntityWithPositionDeletedScript.Execute(context, BaseEntityWithPositionDeletedScriptExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool BaseEntityWithPositionInsertingScriptExecute(ProcessExecutingContext context) {
			BaseEntityWithPositionInserting();
			return true;
		}

		public virtual bool BaseEntityWithPositionDeletedScriptExecute(ProcessExecutingContext context) {
			BaseEntityWithPositionDeleted();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseEntityWithPositionInserting":
							if (ActivatedEventElements.Contains("BaseEntityWithPositionInsertingMessage")) {
							context.QueueTasks.Enqueue("BaseEntityWithPositionInsertingMessage");
						}
						break;
					case "BaseEntityWithPositionDeleted":
							if (ActivatedEventElements.Contains("BaseEntityWithPositionDeletedMessage")) {
							context.QueueTasks.Enqueue("BaseEntityWithPositionDeletedMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityWithPosition_BaseEventsProcess

	/// <exclude/>
	public class BaseEntityWithPosition_BaseEventsProcess : BaseEntityWithPosition_BaseEventsProcess<BaseEntityWithPosition>
	{

		public BaseEntityWithPosition_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseEntityWithPosition_BaseEventsProcess

	public partial class BaseEntityWithPosition_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void BaseEntityWithPositionInserting() {
			Entity.SetColumnValue("Position", GetMaxPosition(Entity));
		}

		public virtual void BaseEntityWithPositionDeleted() {
			Guid primaryColumnvalue = GetFirstEntityPrimaryColumnValue(Entity);
			if (!primaryColumnvalue.Equals(Guid.Empty)) {
				var setRecordPositionProcedure =
					(StoredProcedure)new StoredProcedure(UserConnection, "tsp_SetRecordPosition")
					.WithParameter("TableName", Entity.Schema.Name)
					.WithParameter("PrimaryColumnName", Entity.Schema.GetDBPrimaryColumnName())
					.WithParameter("PrimaryColumnValue", primaryColumnvalue)
					.WithParameter("GrouppingColumnNames", GetGrouppingColumnNames())
					.WithParameter("Position", 0);
				setRecordPositionProcedure.PackageName = UserConnection.DBEngine.SystemPackageName;
				setRecordPositionProcedure.Execute();
			}
		}

		public virtual EntitySchemaQueryFilterCollection GetDetailFilter(Entity entity, EntitySchemaQuery esq) {
			return null;
		}

		public virtual Guid GetFirstEntityPrimaryColumnValue(Entity entity) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entity.Schema.Name);
			esq.RowCount = 1;
			esq.PrimaryQueryColumn.IsAlwaysSelect  = true;
			esq.AddColumn("Position").OrderByAsc();
			
			var groupFilter = GetDetailFilter(entity, esq);
			if (groupFilter != null) {
				esq.Filters.Add(groupFilter);
			}
			
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				return entities[0].GetTypedColumnValue<Guid>(entity.Schema.GetDBPrimaryColumnName());
			}
			return Guid.Empty;
		}

		public virtual string GetGrouppingColumnNames() {
			// Format of string: "column1,column2"
			return string.Empty;
		}

		public virtual int GetMaxPosition(Entity entity) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entity.Schema.Name);
			esq.RowCount = 1;
			var positionColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Max, "Position"));
			var countColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Count, entity.Schema.GetDBPrimaryColumnName()));
			var groupFilter = GetDetailFilter(entity, esq);
			if (groupFilter != null) {
				esq.Filters.Add(groupFilter);
			}
			
			var entities = esq.GetEntityCollection(UserConnection);
			int count = entities[0].GetTypedColumnValue<int>(countColumn.Name);
			if (count > 0) {
				return entities[0].GetTypedColumnValue<int>(positionColumn.Name) + 1;
			}
			return count;
		}

		#endregion

	}

	#endregion


	#region Class: BaseEntityWithPositionEventsProcess

	/// <exclude/>
	public class BaseEntityWithPositionEventsProcess : BaseEntityWithPosition_BaseEventsProcess
	{

		public BaseEntityWithPositionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

