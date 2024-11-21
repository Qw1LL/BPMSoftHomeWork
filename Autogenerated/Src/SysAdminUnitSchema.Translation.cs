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
	using BPMSoft.Core.OperationLog;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using BPMSoft.Web.Common;
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

	#region Class: SysAdminUnit_Translation_BPMSoftSchema

	/// <exclude/>
	public class SysAdminUnit_Translation_BPMSoftSchema : BPMSoft.Configuration.SysAdminUnit_LDAP_BPMSoftSchema
	{

		#region Constructors: Public

		public SysAdminUnit_Translation_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnit_Translation_BPMSoftSchema(SysAdminUnit_Translation_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnit_Translation_BPMSoftSchema(SysAdminUnit_Translation_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysAdminUnitNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("a09035f6-13ab-41d9-af1c-c095e5cf9ac1");
			index.Name = "IUSysAdminUnitName";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5c950219-374c-425c-8082-7e7de785ba20"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			EntitySchemaIndexColumn parentRoleIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3c1b73d7-6adf-4567-88c8-8b95952dc03c"),
				ColumnUId = new Guid("fa4483b3-a2db-4651-a462-689be18351e7"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("81adfa8e-1f43-43a3-9652-1b782e1a0cf1"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(parentRoleIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISAULoggedInActiveIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("cf9e2407-d54a-4930-bdfc-ce9bc64ddfb4");
			index.Name = "ISAULoggedInActive";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn loggedInIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d9c799ef-023d-492c-879d-52d11308d0e8"),
				ColumnUId = new Guid("b0cc6131-e034-4562-9526-3f3a81f0a161"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(loggedInIndexColumn);
			EntitySchemaIndexColumn activeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("670a80ef-4ebe-4c5d-a5d1-e03f9edc4367"),
				ColumnUId = new Guid("48f37442-a2da-4407-9178-72073ba6b09f"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(activeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d6ab5682-2462-490a-91f7-ea9344af2a2c");
			Name = "SysAdminUnit_Translation_BPMSoft";
			ParentSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			ExtendParent = true;
			CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateSysCultureColumn() {
			EntitySchemaColumn column = base.CreateSysCultureColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("d6ab5682-2462-490a-91f7-ea9344af2a2c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysAdminUnitNameIndex());
			Indexes.Add(CreateISAULoggedInActiveIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnit_Translation_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnit_TranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnit_Translation_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnit_Translation_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d6ab5682-2462-490a-91f7-ea9344af2a2c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_Translation_BPMSoft

	/// <summary>
	/// System administration object.
	/// </summary>
	public class SysAdminUnit_Translation_BPMSoft : BPMSoft.Configuration.SysAdminUnit_LDAP_BPMSoft
	{

		#region Constructors: Public

		public SysAdminUnit_Translation_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnit_Translation_BPMSoft";
		}

		public SysAdminUnit_Translation_BPMSoft(SysAdminUnit_Translation_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminUnit_TranslationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("SysAdminUnit_Translation_BPMSoftInserted", e);
			Saving += (s, e) => ThrowEvent("SysAdminUnit_Translation_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("SysAdminUnit_Translation_BPMSoftUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnit_Translation_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_TranslationEventsProcess

	/// <exclude/>
	public partial class SysAdminUnit_TranslationEventsProcess<TEntity> : BPMSoft.Configuration.SysAdminUnit_LDAPEventsProcess<TEntity> where TEntity : SysAdminUnit_Translation_BPMSoft
	{

		public SysAdminUnit_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnit_TranslationEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d6ab5682-2462-490a-91f7-ea9344af2a2c");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_55e01e3f9a55428eb509973525da177a;
		public ProcessFlowElement EventSubProcess3_55e01e3f9a55428eb509973525da177a {
			get {
				return _eventSubProcess3_55e01e3f9a55428eb509973525da177a ?? (_eventSubProcess3_55e01e3f9a55428eb509973525da177a = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_55e01e3f9a55428eb509973525da177a",
					SchemaElementUId = new Guid("55e01e3f-9a55-428e-b509-973525da177a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitSavingStartMessage;
		public ProcessFlowElement SysAdminUnitSavingStartMessage {
			get {
				return _sysAdminUnitSavingStartMessage ?? (_sysAdminUnitSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitSavingStartMessage",
					SchemaElementUId = new Guid("5c9aea74-8229-4335-a925-600449cf450b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysAdminUnitSavingScriptTask;
		public ProcessScriptTask SysAdminUnitSavingScriptTask {
			get {
				return _sysAdminUnitSavingScriptTask ?? (_sysAdminUnitSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysAdminUnitSavingScriptTask",
					SchemaElementUId = new Guid("a008aee2-aea4-4146-9332-4794350a44cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysAdminUnitSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_55e01e3f9a55428eb509973525da177a.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_55e01e3f9a55428eb509973525da177a };
			FlowElements[SysAdminUnitSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitSavingStartMessage };
			FlowElements[SysAdminUnitSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_55e01e3f9a55428eb509973525da177a":
						break;
					case "SysAdminUnitSavingStartMessage":
						e.Context.QueueTasks.Enqueue("SysAdminUnitSavingScriptTask");
						break;
					case "SysAdminUnitSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysAdminUnitSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_55e01e3f9a55428eb509973525da177a":
					context.QueueTasks.Dequeue();
					break;
				case "SysAdminUnitSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitSavingStartMessage";
					result = SysAdminUnitSavingStartMessage.Execute(context);
					break;
				case "SysAdminUnitSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitSavingScriptTask";
					result = SysAdminUnitSavingScriptTask.Execute(context, SysAdminUnitSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SysAdminUnitSavingScriptTaskExecute(ProcessExecutingContext context) {
			EntitySchemaColumn sysCultureColumn = Entity.Schema.Columns.GetByName("SysCulture");
			var sysCultureId = Entity.GetTypedColumnValue<Guid>(sysCultureColumn.ColumnValueName);
			if (sysCultureId == Guid.Empty) {
				var sysCultureUtilities = new SysCultureUtilities(UserConnection);
				Guid sysDefaultCultureId = sysCultureUtilities.GetDefaultCulture();
				Entity.SetColumnValue(sysCultureColumn.ColumnValueName, sysDefaultCultureId);
			} 
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysAdminUnit_Translation_BPMSoftSaving":
							if (ActivatedEventElements.Contains("SysAdminUnitSavingStartMessage")) {
							context.QueueTasks.Enqueue("SysAdminUnitSavingStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_TranslationEventsProcess

	/// <exclude/>
	public class SysAdminUnit_TranslationEventsProcess : SysAdminUnit_TranslationEventsProcess<SysAdminUnit_Translation_BPMSoft>
	{

		public SysAdminUnit_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnit_TranslationEventsProcess

	public partial class SysAdminUnit_TranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

