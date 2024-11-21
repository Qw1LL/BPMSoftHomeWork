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

	#region Class: SysPackageDataLczSchema

	/// <exclude/>
	public class SysPackageDataLczSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageDataLczSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageDataLczSchema(SysPackageDataLczSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageDataLczSchema(SysPackageDataLczSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d");
			RealUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d");
			Name = "SysPackageDataLcz";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ef5ac0dc-d2a4-49e0-9584-7ab11653581f")) == null) {
				Columns.Add(CreateSysPackageSchemaDataColumn());
			}
			if (Columns.FindByUId(new Guid("f78f231a-f6a3-4e7a-9213-c4b8d7eb202a")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("4bfcb848-d71d-4e9c-bfde-1de7ca43bbe5")) == null) {
				Columns.Add(CreateDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPackageSchemaDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ef5ac0dc-d2a4-49e0-9584-7ab11653581f"),
				Name = @"SysPackageSchemaData",
				ReferenceSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d"),
				ModifiedInSchemaUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f78f231a-f6a3-4e7a-9213-c4b8d7eb202a"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d"),
				ModifiedInSchemaUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("4bfcb848-d71d-4e9c-bfde-1de7ca43bbe5"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d"),
				ModifiedInSchemaUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPackageDataLcz(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageDataLcz_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageDataLczSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageDataLczSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5844a220-f33e-4758-bbce-0c66444ca76d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageDataLcz

	/// <summary>
	/// Localization of package schema data.
	/// </summary>
	public class SysPackageDataLcz : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageDataLcz(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageDataLcz";
		}

		public SysPackageDataLcz(SysPackageDataLcz source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysPackageSchemaDataId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageSchemaDataId");
			}
			set {
				SetColumnValue("SysPackageSchemaDataId", value);
				_sysPackageSchemaData = null;
			}
		}

		private SysPackageSchemaData _sysPackageSchemaData;
		/// <summary>
		/// Package schema data.
		/// </summary>
		public SysPackageSchemaData SysPackageSchemaData {
			get {
				return _sysPackageSchemaData ??
					(_sysPackageSchemaData = LookupColumnEntities.GetEntity("SysPackageSchemaData") as SysPackageSchemaData);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageDataLcz_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPackageDataLczDeleted", e);
			Validating += (s, e) => ThrowEvent("SysPackageDataLczValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPackageDataLcz(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageDataLcz_BaseEventsProcess

	/// <exclude/>
	public partial class SysPackageDataLcz_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPackageDataLcz
	{

		public SysPackageDataLcz_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageDataLcz_BaseEventsProcess";
			SchemaUId = new Guid("5844a220-f33e-4758-bbce-0c66444ca76d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5844a220-f33e-4758-bbce-0c66444ca76d");
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

	#region Class: SysPackageDataLcz_BaseEventsProcess

	/// <exclude/>
	public class SysPackageDataLcz_BaseEventsProcess : SysPackageDataLcz_BaseEventsProcess<SysPackageDataLcz>
	{

		public SysPackageDataLcz_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageDataLcz_BaseEventsProcess

	public partial class SysPackageDataLcz_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageDataLczEventsProcess

	/// <exclude/>
	public class SysPackageDataLczEventsProcess : SysPackageDataLcz_BaseEventsProcess
	{

		public SysPackageDataLczEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

