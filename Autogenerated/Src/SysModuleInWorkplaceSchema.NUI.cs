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

	#region Class: SysModuleInWorkplaceSchema

	/// <exclude/>
	public class SysModuleInWorkplaceSchema : BPMSoft.Configuration.BaseEntityWithPositionSchema
	{

		#region Constructors: Public

		public SysModuleInWorkplaceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleInWorkplaceSchema(SysModuleInWorkplaceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleInWorkplaceSchema(SysModuleInWorkplaceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			RealUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			Name = "SysModuleInWorkplace";
			ParentSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0e3d3857-2203-40e4-b1ec-8e972007650e")) == null) {
				Columns.Add(CreateSysWorkplaceColumn());
			}
			if (Columns.FindByUId(new Guid("991cf5ef-ffb8-49a5-add3-074a595f6c43")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreatePositionColumn() {
			EntitySchemaColumn column = base.CreatePositionColumn();
			column.ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysWorkplaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0e3d3857-2203-40e4-b1ec-8e972007650e"),
				Name = @"SysWorkplace",
				ReferenceSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d"),
				ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d"),
				CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("991cf5ef-ffb8-49a5-add3-074a595f6c43"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d"),
				ModifiedInSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d"),
				CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleInWorkplace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleInWorkplace_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleInWorkplaceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleInWorkplaceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleInWorkplace

	/// <summary>
	/// Section in workplace.
	/// </summary>
	public class SysModuleInWorkplace : BPMSoft.Configuration.BaseEntityWithPosition
	{

		#region Constructors: Public

		public SysModuleInWorkplace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleInWorkplace";
		}

		public SysModuleInWorkplace(SysModuleInWorkplace source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysWorkplaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkplaceId");
			}
			set {
				SetColumnValue("SysWorkplaceId", value);
				_sysWorkplace = null;
			}
		}

		/// <exclude/>
		public string SysWorkplaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkplaceName");
			}
			set {
				SetColumnValue("SysWorkplaceName", value);
				if (_sysWorkplace != null) {
					_sysWorkplace.Name = value;
				}
			}
		}

		private SysWorkplace _sysWorkplace;
		/// <summary>
		/// Workplace.
		/// </summary>
		public SysWorkplace SysWorkplace {
			get {
				return _sysWorkplace ??
					(_sysWorkplace = LookupColumnEntities.GetEntity("SysWorkplace") as SysWorkplace);
			}
		}

		/// <exclude/>
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = LookupColumnEntities.GetEntity("SysModule") as SysModule);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleInWorkplace_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("SysModuleInWorkplaceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleInWorkplace(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleInWorkplace_NUIEventsProcess

	/// <exclude/>
	public partial class SysModuleInWorkplace_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityWithPosition_BaseEventsProcess<TEntity> where TEntity : SysModuleInWorkplace
	{

		public SysModuleInWorkplace_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleInWorkplace_NUIEventsProcess";
			SchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
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

	#region Class: SysModuleInWorkplace_NUIEventsProcess

	/// <exclude/>
	public class SysModuleInWorkplace_NUIEventsProcess : SysModuleInWorkplace_NUIEventsProcess<SysModuleInWorkplace>
	{

		public SysModuleInWorkplace_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleInWorkplace_NUIEventsProcess

	public partial class SysModuleInWorkplace_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		public override string GetGrouppingColumnNames() {
			return "SysWorkplaceId";
		}

		#endregion

	}

	#endregion


	#region Class: SysModuleInWorkplaceEventsProcess

	/// <exclude/>
	public class SysModuleInWorkplaceEventsProcess : SysModuleInWorkplace_NUIEventsProcess
	{

		public SysModuleInWorkplaceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

