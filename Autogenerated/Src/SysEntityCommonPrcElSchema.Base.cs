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

	#region Class: SysEntityCommonPrcElSchema

	/// <exclude/>
	public class SysEntityCommonPrcElSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntityCommonPrcElSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntityCommonPrcElSchema(SysEntityCommonPrcElSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntityCommonPrcElSchema(SysEntityCommonPrcElSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateRecordId_SchemaUIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("125aeca0-b427-4042-9f97-52f82d8d8ca6");
			index.Name = "RecordId_SchemaUId";
			index.CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa");
			index.ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn recordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ebbf8a70-136b-c27c-ea19-e833c4968567"),
				ColumnUId = new Guid("2fb1dd9a-631b-4de5-848b-864da401622e"),
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(recordIdIndexColumn);
			EntitySchemaIndexColumn entitySchemaUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("942a98d8-3237-d822-0e8b-402ae9f91d4e"),
				ColumnUId = new Guid("6d61aa94-cfae-4c1f-8eb8-f7e393a6257a"),
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entitySchemaUIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa");
			RealUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa");
			Name = "SysEntityCommonPrcEl";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2fb1dd9a-631b-4de5-848b-864da401622e")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("4221321d-f854-4a7a-a5bf-79ccb6e0c25f")) == null) {
				Columns.Add(CreateProcessElementColumn());
			}
			if (Columns.FindByUId(new Guid("ed345527-3139-4274-885d-c79980210801")) == null) {
				Columns.Add(CreateConditionDataColumn());
			}
			if (Columns.FindByUId(new Guid("1fe74aef-615c-42eb-9a90-489a49b4d78c")) == null) {
				Columns.Add(CreateChangedColumnsColumn());
			}
			if (Columns.FindByUId(new Guid("75a9960c-432d-4b4a-ac8a-2c9fd5a902b8")) == null) {
				Columns.Add(CreateRecordChangeTypeColumn());
			}
			if (Columns.FindByUId(new Guid("6d61aa94-cfae-4c1f-8eb8-f7e393a6257a")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2fb1dd9a-631b-4de5-848b-864da401622e"),
				Name = @"RecordId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4221321d-f854-4a7a-a5bf-79ccb6e0c25f"),
				Name = @"ProcessElement",
				ReferenceSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateConditionDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ed345527-3139-4274-885d-c79980210801"),
				Name = @"ConditionData",
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateChangedColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("1fe74aef-615c-42eb-9a90-489a49b4d78c"),
				Name = @"ChangedColumns",
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordChangeTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("75a9960c-432d-4b4a-ac8a-2c9fd5a902b8"),
				Name = @"RecordChangeType",
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6d61aa94-cfae-4c1f-8eb8-f7e393a6257a"),
				Name = @"EntitySchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				ModifiedInSchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"),
				CreatedInPackageId = new Guid("f22d92fb-0351-4268-afec-308cab404801")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateRecordId_SchemaUIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntityCommonPrcEl(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntityCommonPrcEl_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntityCommonPrcElSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntityCommonPrcElSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityCommonPrcEl

	/// <summary>
	/// Process item finishing conditions.
	/// </summary>
	public class SysEntityCommonPrcEl : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntityCommonPrcEl(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityCommonPrcEl";
		}

		public SysEntityCommonPrcEl(SysEntityCommonPrcEl source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object record.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <exclude/>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
				_processElement = null;
			}
		}

		private SysProcessElementData _processElement;
		/// <summary>
		/// Process item.
		/// </summary>
		public SysProcessElementData ProcessElement {
			get {
				return _processElement ??
					(_processElement = LookupColumnEntities.GetEntity("ProcessElement") as SysProcessElementData);
			}
		}

		/// <summary>
		/// Finishing conditions.
		/// </summary>
		public string ConditionData {
			get {
				return GetTypedColumnValue<string>("ConditionData");
			}
			set {
				SetColumnValue("ConditionData", value);
			}
		}

		/// <summary>
		/// Completing condition by modified column.
		/// </summary>
		public string ChangedColumns {
			get {
				return GetTypedColumnValue<string>("ChangedColumns");
			}
			set {
				SetColumnValue("ChangedColumns", value);
			}
		}

		/// <summary>
		/// Modification type.
		/// </summary>
		public int RecordChangeType {
			get {
				return GetTypedColumnValue<int>("RecordChangeType");
			}
			set {
				SetColumnValue("RecordChangeType", value);
			}
		}

		/// <summary>
		/// Object schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntityCommonPrcEl_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntityCommonPrcElDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEntityCommonPrcElDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEntityCommonPrcElInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEntityCommonPrcElInserting", e);
			Saved += (s, e) => ThrowEvent("SysEntityCommonPrcElSaved", e);
			Saving += (s, e) => ThrowEvent("SysEntityCommonPrcElSaving", e);
			Validating += (s, e) => ThrowEvent("SysEntityCommonPrcElValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntityCommonPrcEl(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityCommonPrcEl_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntityCommonPrcEl_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysEntityCommonPrcEl
	{

		public SysEntityCommonPrcEl_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntityCommonPrcEl_BaseEventsProcess";
			SchemaUId = new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6522ab5b-d5b7-4f10-9f18-6ad2af4bd0aa");
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

	#region Class: SysEntityCommonPrcEl_BaseEventsProcess

	/// <exclude/>
	public class SysEntityCommonPrcEl_BaseEventsProcess : SysEntityCommonPrcEl_BaseEventsProcess<SysEntityCommonPrcEl>
	{

		public SysEntityCommonPrcEl_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntityCommonPrcEl_BaseEventsProcess

	public partial class SysEntityCommonPrcEl_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntityCommonPrcElEventsProcess

	/// <exclude/>
	public class SysEntityCommonPrcElEventsProcess : SysEntityCommonPrcEl_BaseEventsProcess
	{

		public SysEntityCommonPrcElEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

