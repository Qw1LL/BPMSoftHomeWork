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

	#region Class: SysSqlScriptDependencySchema

	/// <exclude/>
	public class SysSqlScriptDependencySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSqlScriptDependencySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSqlScriptDependencySchema(SysSqlScriptDependencySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSqlScriptDependencySchema(SysSqlScriptDependencySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysSqlScriptDependencyIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("0c928959-ae31-4207-b372-a16c9e677bf7");
			index.Name = "IUSysSqlScriptDependency";
			index.CreatedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			index.ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			index.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			EntitySchemaIndexColumn sysSqlScriptIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7c5d864f-3656-4f7a-bfcf-02862076d088"),
				ColumnUId = new Guid("55306f65-4d03-4020-823a-b8c90b740375"),
				CreatedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysSqlScriptIdIndexColumn);
			EntitySchemaIndexColumn dependOnSqlScriptIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("0226d7dc-843a-4f6d-9a8c-4eaff46ad91f"),
				ColumnUId = new Guid("365d9065-6c2d-475d-8962-6ec682fe8c2f"),
				CreatedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(dependOnSqlScriptIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			RealUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			Name = "SysSqlScriptDependency";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("55306f65-4d03-4020-823a-b8c90b740375")) == null) {
				Columns.Add(CreateSysSqlScriptColumn());
			}
			if (Columns.FindByUId(new Guid("365d9065-6c2d-475d-8962-6ec682fe8c2f")) == null) {
				Columns.Add(CreateDependOnSqlScriptColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSqlScriptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("55306f65-4d03-4020-823a-b8c90b740375"),
				Name = @"SysSqlScript",
				ReferenceSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateDependOnSqlScriptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("365d9065-6c2d-475d-8962-6ec682fe8c2f"),
				Name = @"DependOnSqlScript",
				ReferenceSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				ModifiedInSchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysSqlScriptDependencyIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSqlScriptDependency(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSqlScriptDependency_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSqlScriptDependencySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSqlScriptDependencySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSqlScriptDependency

	/// <summary>
	/// SQL script dependencies.
	/// </summary>
	public class SysSqlScriptDependency : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSqlScriptDependency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSqlScriptDependency";
		}

		public SysSqlScriptDependency(SysSqlScriptDependency source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSqlScriptId {
			get {
				return GetTypedColumnValue<Guid>("SysSqlScriptId");
			}
			set {
				SetColumnValue("SysSqlScriptId", value);
				_sysSqlScript = null;
			}
		}

		/// <exclude/>
		public string SysSqlScriptName {
			get {
				return GetTypedColumnValue<string>("SysSqlScriptName");
			}
			set {
				SetColumnValue("SysSqlScriptName", value);
				if (_sysSqlScript != null) {
					_sysSqlScript.Name = value;
				}
			}
		}

		private SysPackageSqlScript _sysSqlScript;
		/// <summary>
		/// SQL script.
		/// </summary>
		public SysPackageSqlScript SysSqlScript {
			get {
				return _sysSqlScript ??
					(_sysSqlScript = LookupColumnEntities.GetEntity("SysSqlScript") as SysPackageSqlScript);
			}
		}

		/// <exclude/>
		public Guid DependOnSqlScriptId {
			get {
				return GetTypedColumnValue<Guid>("DependOnSqlScriptId");
			}
			set {
				SetColumnValue("DependOnSqlScriptId", value);
				_dependOnSqlScript = null;
			}
		}

		/// <exclude/>
		public string DependOnSqlScriptName {
			get {
				return GetTypedColumnValue<string>("DependOnSqlScriptName");
			}
			set {
				SetColumnValue("DependOnSqlScriptName", value);
				if (_dependOnSqlScript != null) {
					_dependOnSqlScript.Name = value;
				}
			}
		}

		private SysPackageSqlScript _dependOnSqlScript;
		/// <summary>
		/// Depends on SQL script.
		/// </summary>
		public SysPackageSqlScript DependOnSqlScript {
			get {
				return _dependOnSqlScript ??
					(_dependOnSqlScript = LookupColumnEntities.GetEntity("DependOnSqlScript") as SysPackageSqlScript);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSqlScriptDependency_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSqlScriptDependencyDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysSqlScriptDependencyInserting", e);
			Validating += (s, e) => ThrowEvent("SysSqlScriptDependencyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSqlScriptDependency(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSqlScriptDependency_BaseEventsProcess

	/// <exclude/>
	public partial class SysSqlScriptDependency_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSqlScriptDependency
	{

		public SysSqlScriptDependency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSqlScriptDependency_BaseEventsProcess";
			SchemaUId = new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("59b473c1-b952-4f6c-b6e3-285cedf4f31c");
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

	#region Class: SysSqlScriptDependency_BaseEventsProcess

	/// <exclude/>
	public class SysSqlScriptDependency_BaseEventsProcess : SysSqlScriptDependency_BaseEventsProcess<SysSqlScriptDependency>
	{

		public SysSqlScriptDependency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSqlScriptDependency_BaseEventsProcess

	public partial class SysSqlScriptDependency_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSqlScriptDependencyEventsProcess

	/// <exclude/>
	public class SysSqlScriptDependencyEventsProcess : SysSqlScriptDependency_BaseEventsProcess
	{

		public SysSqlScriptDependencyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

