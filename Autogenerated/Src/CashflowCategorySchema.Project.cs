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

	#region Class: CashflowCategorySchema

	/// <exclude/>
	public class CashflowCategorySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CashflowCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CashflowCategorySchema(CashflowCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CashflowCategorySchema(CashflowCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			RealUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			Name = "CashflowCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c62a12cb-b285-45a3-9811-7f0a05477232")) == null) {
				Columns.Add(CreateCashflowTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCashflowTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c62a12cb-b285-45a3-9811-7f0a05477232"),
				Name = @"CashflowType",
				ReferenceSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac"),
				ModifiedInSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CashflowCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CashflowCategory_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CashflowCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CashflowCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("31bad651-347e-4d44-90c6-70b79b83dbac"));
		}

		#endregion

	}

	#endregion

	#region Class: CashflowCategory

	/// <summary>
	/// Категория операции.
	/// </summary>
	public class CashflowCategory : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CashflowCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CashflowCategory";
		}

		public CashflowCategory(CashflowCategory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CashflowTypeId {
			get {
				return GetTypedColumnValue<Guid>("CashflowTypeId");
			}
			set {
				SetColumnValue("CashflowTypeId", value);
				_cashflowType = null;
			}
		}

		/// <exclude/>
		public string CashflowTypeName {
			get {
				return GetTypedColumnValue<string>("CashflowTypeName");
			}
			set {
				SetColumnValue("CashflowTypeName", value);
				if (_cashflowType != null) {
					_cashflowType.Name = value;
				}
			}
		}

		private CashflowType _cashflowType;
		/// <summary>
		/// Тип операции.
		/// </summary>
		public CashflowType CashflowType {
			get {
				return _cashflowType ??
					(_cashflowType = LookupColumnEntities.GetEntity("CashflowType") as CashflowType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CashflowCategory_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CashflowCategoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("CashflowCategoryInserting", e);
			Validating += (s, e) => ThrowEvent("CashflowCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CashflowCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: CashflowCategory_ProjectEventsProcess

	/// <exclude/>
	public partial class CashflowCategory_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CashflowCategory
	{

		public CashflowCategory_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CashflowCategory_ProjectEventsProcess";
			SchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("31bad651-347e-4d44-90c6-70b79b83dbac");
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

	#region Class: CashflowCategory_ProjectEventsProcess

	/// <exclude/>
	public class CashflowCategory_ProjectEventsProcess : CashflowCategory_ProjectEventsProcess<CashflowCategory>
	{

		public CashflowCategory_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CashflowCategory_ProjectEventsProcess

	public partial class CashflowCategory_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CashflowCategoryEventsProcess

	/// <exclude/>
	public class CashflowCategoryEventsProcess : CashflowCategory_ProjectEventsProcess
	{

		public CashflowCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

