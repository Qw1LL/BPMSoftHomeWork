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

	#region Class: SysAdminUnitInRoleSchema

	/// <exclude/>
	public class SysAdminUnitInRoleSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAdminUnitInRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnitInRoleSchema(SysAdminUnitInRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnitInRoleSchema(SysAdminUnitInRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_SysAdminUnitId_RoleIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("083aed8b-e58a-4d6c-8acd-59f8353eafb0");
			index.Name = "IX_SysAdminUnitId_RoleId";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("573e18ab-c37f-485f-ab08-ecf2443fc7f9");
			EntitySchemaIndexColumn sysAdminUnitIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("0eabdfc1-9e18-43b8-8a5b-3e19813d4429"),
				ColumnUId = new Guid("584b4fdf-e7a2-46f7-9535-a815953034ea"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("573e18ab-c37f-485f-ab08-ecf2443fc7f9"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysAdminUnitIdIndexColumn);
			EntitySchemaIndexColumn sysAdminUnitRoleIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("e945ca05-2e1a-401e-b430-9f45eff110be"),
				ColumnUId = new Guid("9c4879dd-36a9-41d9-b9d3-72bfaa200fb0"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("573e18ab-c37f-485f-ab08-ecf2443fc7f9"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysAdminUnitRoleIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4");
			RealUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4");
			Name = "SysAdminUnitInRole";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("584b4fdf-e7a2-46f7-9535-a815953034ea")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("9c4879dd-36a9-41d9-b9d3-72bfaa200fb0")) == null) {
				Columns.Add(CreateSysAdminUnitRoleIdColumn());
			}
			if (Columns.FindByUId(new Guid("c203a17e-a596-15d6-4628-200f6772e678")) == null) {
				Columns.Add(CreateSourceAdminUnitIdColumn());
			}
			if (Columns.FindByUId(new Guid("0feedd2c-819a-100f-7688-f682406511b8")) == null) {
				Columns.Add(CreateSourceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("584b4fdf-e7a2-46f7-9535-a815953034ea"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				ModifiedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitRoleIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9c4879dd-36a9-41d9-b9d3-72bfaa200fb0"),
				Name = @"SysAdminUnitRoleId",
				CreatedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				ModifiedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceAdminUnitIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c203a17e-a596-15d6-4628-200f6772e678"),
				Name = @"SourceAdminUnitId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				ModifiedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				CreatedInPackageId = new Guid("573e18ab-c37f-485f-ab08-ecf2443fc7f9")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0feedd2c-819a-100f-7688-f682406511b8"),
				Name = @"Source",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				ModifiedInSchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"),
				CreatedInPackageId = new Guid("573e18ab-c37f-485f-ab08-ecf2443fc7f9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_SysAdminUnitId_RoleIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnitInRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnitInRole_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnitInRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnitInRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitInRole

	/// <summary>
	/// User role.
	/// </summary>
	public class SysAdminUnitInRole : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAdminUnitInRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitInRole";
		}

		public SysAdminUnitInRole(SysAdminUnitInRole source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// User role Id.
		/// </summary>
		public Guid SysAdminUnitRoleId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitRoleId");
			}
			set {
				SetColumnValue("SysAdminUnitRoleId", value);
			}
		}

		/// <summary>
		/// Source admin unit.
		/// </summary>
		public Guid SourceAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SourceAdminUnitId");
			}
			set {
				SetColumnValue("SourceAdminUnitId", value);
			}
		}

		/// <summary>
		/// Source.
		/// </summary>
		public int Source {
			get {
				return GetTypedColumnValue<int>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminUnitInRole_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminUnitInRoleDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminUnitInRoleInserting", e);
			Validating += (s, e) => ThrowEvent("SysAdminUnitInRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnitInRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitInRole_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminUnitInRole_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysAdminUnitInRole
	{

		public SysAdminUnitInRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnitInRole_BaseEventsProcess";
			SchemaUId = new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("54be68f8-96c2-4418-b83b-286c226c0ac4");
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

	#region Class: SysAdminUnitInRole_BaseEventsProcess

	/// <exclude/>
	public class SysAdminUnitInRole_BaseEventsProcess : SysAdminUnitInRole_BaseEventsProcess<SysAdminUnitInRole>
	{

		public SysAdminUnitInRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnitInRole_BaseEventsProcess

	public partial class SysAdminUnitInRole_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminUnitInRoleEventsProcess

	/// <exclude/>
	public class SysAdminUnitInRoleEventsProcess : SysAdminUnitInRole_BaseEventsProcess
	{

		public SysAdminUnitInRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

