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

	#region Class: SysSettingsInFolderSchema

	/// <exclude/>
	public class SysSettingsInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public SysSettingsInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSettingsInFolderSchema(SysSettingsInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSettingsInFolderSchema(SysSettingsInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768");
			RealUId = new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768");
			Name = "SysSettingsInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9c2d094d-2f99-48cf-881b-00247dfb94d6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("34982036-bcf9-408a-a293-d6b35c45edd5")) == null) {
				Columns.Add(CreateSysSettingsColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("34982036-bcf9-408a-a293-d6b35c45edd5"),
				Name = @"SysSettings",
				ReferenceSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768"),
				ModifiedInSchemaUId = new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768"),
				CreatedInPackageId = new Guid("9c2d094d-2f99-48cf-881b-00247dfb94d6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSettingsInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSettingsInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSettingsInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSettingsInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsInFolder

	/// <summary>
	/// System setting in folder.
	/// </summary>
	public class SysSettingsInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public SysSettingsInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSettingsInFolder";
		}

		public SysSettingsInFolder(SysSettingsInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSettingsId {
			get {
				return GetTypedColumnValue<Guid>("SysSettingsId");
			}
			set {
				SetColumnValue("SysSettingsId", value);
				_sysSettings = null;
			}
		}

		/// <exclude/>
		public string SysSettingsName {
			get {
				return GetTypedColumnValue<string>("SysSettingsName");
			}
			set {
				SetColumnValue("SysSettingsName", value);
				if (_sysSettings != null) {
					_sysSettings.Name = value;
				}
			}
		}

		private SysSettings _sysSettings;
		/// <summary>
		/// System setting.
		/// </summary>
		public SysSettings SysSettings {
			get {
				return _sysSettings ??
					(_sysSettings = LookupColumnEntities.GetEntity("SysSettings") as SysSettings);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSettingsInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSettingsInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("SysSettingsInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSettingsInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class SysSettingsInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : SysSettingsInFolder
	{

		public SysSettingsInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSettingsInFolder_BaseEventsProcess";
			SchemaUId = new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fcd1648a-01fd-47f9-a42f-24f245d37768");
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

	#region Class: SysSettingsInFolder_BaseEventsProcess

	/// <exclude/>
	public class SysSettingsInFolder_BaseEventsProcess : SysSettingsInFolder_BaseEventsProcess<SysSettingsInFolder>
	{

		public SysSettingsInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSettingsInFolder_BaseEventsProcess

	public partial class SysSettingsInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSettingsInFolderEventsProcess

	/// <exclude/>
	public class SysSettingsInFolderEventsProcess : SysSettingsInFolder_BaseEventsProcess
	{

		public SysSettingsInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

