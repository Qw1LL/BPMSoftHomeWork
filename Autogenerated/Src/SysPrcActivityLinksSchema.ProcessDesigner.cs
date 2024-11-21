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

	#region Class: SysPrcActivityLinksSchema

	/// <exclude/>
	public class SysPrcActivityLinksSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPrcActivityLinksSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcActivityLinksSchema(SysPrcActivityLinksSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcActivityLinksSchema(SysPrcActivityLinksSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			RealUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			Name = "SysPrcActivityLinks";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateActivityColumnNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c8fa17ce-92b8-4dcb-a5bb-f68ace90f826")) == null) {
				Columns.Add(CreateActivityColumnIdColumn());
			}
			if (Columns.FindByUId(new Guid("3bdb0a72-1eb5-445a-a9bc-0d2151ff756d")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("e1669a67-6399-4fd2-a514-704497a88dce")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			column.CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			column.CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			column.CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			column.CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			column.CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			column.CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateActivityColumnIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c8fa17ce-92b8-4dcb-a5bb-f68ace90f826"),
				Name = @"ActivityColumnId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6cbbfb0b-8a52-46a5-ac40-61fca4017949"),
				Name = @"ActivityColumnName",
				CreatedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3bdb0a72-1eb5-445a-a9bc-0d2151ff756d"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e1669a67-6399-4fd2-a514-704497a88dce"),
				Name = @"IsActive",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				ModifiedInSchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"),
				CreatedInPackageId = new Guid("f909d548-ea0a-4163-99d5-5d01014acefb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPrcActivityLinks(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcActivityLinks_ProcessDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcActivityLinksSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcActivityLinksSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("85a55635-eb65-4c32-a415-b95a05b510b1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcActivityLinks

	/// <summary>
	/// Connection fields for activity process item.
	/// </summary>
	public class SysPrcActivityLinks : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPrcActivityLinks(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcActivityLinks";
		}

		public SysPrcActivityLinks(SysPrcActivityLinks source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Activity column Id.
		/// </summary>
		public Guid ActivityColumnId {
			get {
				return GetTypedColumnValue<Guid>("ActivityColumnId");
			}
			set {
				SetColumnValue("ActivityColumnId", value);
			}
		}

		/// <summary>
		/// Activity column.
		/// </summary>
		public string ActivityColumnName {
			get {
				return GetTypedColumnValue<string>("ActivityColumnName");
			}
			set {
				SetColumnValue("ActivityColumnName", value);
			}
		}

		/// <summary>
		/// Number.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcActivityLinks_ProcessDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcActivityLinksDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysPrcActivityLinksInserting", e);
			Validating += (s, e) => ThrowEvent("SysPrcActivityLinksValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcActivityLinks(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcActivityLinks_ProcessDesignerEventsProcess

	/// <exclude/>
	public partial class SysPrcActivityLinks_ProcessDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPrcActivityLinks
	{

		public SysPrcActivityLinks_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcActivityLinks_ProcessDesignerEventsProcess";
			SchemaUId = new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("85a55635-eb65-4c32-a415-b95a05b510b1");
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

	#region Class: SysPrcActivityLinks_ProcessDesignerEventsProcess

	/// <exclude/>
	public class SysPrcActivityLinks_ProcessDesignerEventsProcess : SysPrcActivityLinks_ProcessDesignerEventsProcess<SysPrcActivityLinks>
	{

		public SysPrcActivityLinks_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcActivityLinks_ProcessDesignerEventsProcess

	public partial class SysPrcActivityLinks_ProcessDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcActivityLinksEventsProcess

	/// <exclude/>
	public class SysPrcActivityLinksEventsProcess : SysPrcActivityLinks_ProcessDesignerEventsProcess
	{

		public SysPrcActivityLinksEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

