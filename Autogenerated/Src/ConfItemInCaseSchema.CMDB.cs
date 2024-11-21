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

	#region Class: ConfItemInCaseSchema

	/// <exclude/>
	public class ConfItemInCaseSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ConfItemInCaseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfItemInCaseSchema(ConfItemInCaseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfItemInCaseSchema(ConfItemInCaseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			RealUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			Name = "ConfItemInCase";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f7bfa2dc-fea9-46aa-b05f-4b25804685fa")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("2133095c-635d-4422-8020-a60bd2ceaf56")) == null) {
				Columns.Add(CreateConfItemColumn());
			}
			if (Columns.FindByUId(new Guid("61e2d581-f639-4a9b-a1e1-814c8872425d")) == null) {
				Columns.Add(CreateMajorColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f7bfa2dc-fea9-46aa-b05f-4b25804685fa"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2133095c-635d-4422-8020-a60bd2ceaf56"),
				Name = @"ConfItem",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateMajorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("61e2d581-f639-4a9b-a1e1-814c8872425d"),
				Name = @"Major",
				CreatedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				ModifiedInSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				CreatedInPackageId = new Guid("f903ed7d-efff-4bea-98a9-8ff46e81b434")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfItemInCase(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfItemInCase_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfItemInCaseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfItemInCaseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemInCase

	/// <summary>
	/// Конфигурационная единица в Обращении.
	/// </summary>
	public class ConfItemInCase : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ConfItemInCase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfItemInCase";
		}

		public ConfItemInCase(ConfItemInCase source)
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

		/// <exclude/>
		public Guid ConfItemId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemId");
			}
			set {
				SetColumnValue("ConfItemId", value);
				_confItem = null;
			}
		}

		/// <exclude/>
		public string ConfItemName {
			get {
				return GetTypedColumnValue<string>("ConfItemName");
			}
			set {
				SetColumnValue("ConfItemName", value);
				if (_confItem != null) {
					_confItem.Name = value;
				}
			}
		}

		private ConfItem _confItem;
		/// <summary>
		/// Конфигурационная единица.
		/// </summary>
		public ConfItem ConfItem {
			get {
				return _confItem ??
					(_confItem = LookupColumnEntities.GetEntity("ConfItem") as ConfItem);
			}
		}

		/// <summary>
		/// Основная.
		/// </summary>
		public bool Major {
			get {
				return GetTypedColumnValue<bool>("Major");
			}
			set {
				SetColumnValue("Major", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfItemInCase_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfItemInCaseDeleted", e);
			Inserting += (s, e) => ThrowEvent("ConfItemInCaseInserting", e);
			Validating += (s, e) => ThrowEvent("ConfItemInCaseValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfItemInCase(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemInCase_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfItemInCase_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ConfItemInCase
	{

		public ConfItemInCase_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfItemInCase_CMDBEventsProcess";
			SchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678");
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

	#region Class: ConfItemInCase_CMDBEventsProcess

	/// <exclude/>
	public class ConfItemInCase_CMDBEventsProcess : ConfItemInCase_CMDBEventsProcess<ConfItemInCase>
	{

		public ConfItemInCase_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfItemInCase_CMDBEventsProcess

	public partial class ConfItemInCase_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfItemInCaseEventsProcess

	/// <exclude/>
	public class ConfItemInCaseEventsProcess : ConfItemInCase_CMDBEventsProcess
	{

		public ConfItemInCaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

