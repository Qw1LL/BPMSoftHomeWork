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

	#region Class: SatisfactionUpdateSchema

	/// <exclude/>
	public class SatisfactionUpdateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SatisfactionUpdateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SatisfactionUpdateSchema(SatisfactionUpdateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SatisfactionUpdateSchema(SatisfactionUpdateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			RealUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			Name = "SatisfactionUpdate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c7d63a2b-e6a8-408b-8bb7-87df2d90fe9f")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("5cf5a8e7-42a0-4465-9198-0df25f0f30ee")) == null) {
				Columns.Add(CreatePointColumn());
			}
			if (Columns.FindByUId(new Guid("bbc97078-3ca2-4845-9cb4-c1229e427c92")) == null) {
				Columns.Add(CreateCommentColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			column.CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			column.CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			column.CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			column.CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			column.CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			column.CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7d63a2b-e6a8-408b-8bb7-87df2d90fe9f"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24"),
				ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22")
			};
		}

		protected virtual EntitySchemaColumn CreatePointColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5cf5a8e7-42a0-4465-9198-0df25f0f30ee"),
				Name = @"Point",
				CreatedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24"),
				ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24"),
				CreatedInPackageId = new Guid("9141d462-7675-4656-8ea8-25b81010cd22")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("bbc97078-3ca2-4845-9cb4-c1229e427c92"),
				Name = @"Comment",
				CreatedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24"),
				ModifiedInSchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SatisfactionUpdate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SatisfactionUpdate_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SatisfactionUpdateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SatisfactionUpdateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24"));
		}

		#endregion

	}

	#endregion

	#region Class: SatisfactionUpdate

	/// <summary>
	/// Настройка уровня удовлетворенности.
	/// </summary>
	public class SatisfactionUpdate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SatisfactionUpdate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SatisfactionUpdate";
		}

		public SatisfactionUpdate(SatisfactionUpdate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		/// <summary>
		/// Оценка.
		/// </summary>
		public int Point {
			get {
				return GetTypedColumnValue<int>("Point");
			}
			set {
				SetColumnValue("Point", value);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SatisfactionUpdate_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SatisfactionUpdateDeleted", e);
			Inserting += (s, e) => ThrowEvent("SatisfactionUpdateInserting", e);
			Validating += (s, e) => ThrowEvent("SatisfactionUpdateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SatisfactionUpdate(this);
		}

		#endregion

	}

	#endregion

	#region Class: SatisfactionUpdate_CaseEventsProcess

	/// <exclude/>
	public partial class SatisfactionUpdate_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SatisfactionUpdate
	{

		public SatisfactionUpdate_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SatisfactionUpdate_CaseEventsProcess";
			SchemaUId = new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("baf02fa5-bd26-45bf-b78d-c5eefbffdb24");
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

	#region Class: SatisfactionUpdate_CaseEventsProcess

	/// <exclude/>
	public class SatisfactionUpdate_CaseEventsProcess : SatisfactionUpdate_CaseEventsProcess<SatisfactionUpdate>
	{

		public SatisfactionUpdate_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SatisfactionUpdate_CaseEventsProcess

	public partial class SatisfactionUpdate_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SatisfactionUpdateEventsProcess

	/// <exclude/>
	public class SatisfactionUpdateEventsProcess : SatisfactionUpdate_CaseEventsProcess
	{

		public SatisfactionUpdateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

