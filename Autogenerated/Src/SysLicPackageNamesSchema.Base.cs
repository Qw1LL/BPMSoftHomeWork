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

	#region Class: SysLicPackageNamesSchema

	/// <exclude/>
	public class SysLicPackageNamesSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLicPackageNamesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLicPackageNamesSchema(SysLicPackageNamesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLicPackageNamesSchema(SysLicPackageNamesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0");
			RealUId = new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0");
			Name = "SysLicPackageNames";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a4b62059-7221-435f-8ef1-717262990b9a")) == null) {
				Columns.Add(CreateOldPackageNameColumn());
			}
			if (Columns.FindByUId(new Guid("e9b3d46e-9ed1-4236-9ad0-a2b7c2d8bc4b")) == null) {
				Columns.Add(CreateNewPackageNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOldPackageNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a4b62059-7221-435f-8ef1-717262990b9a"),
				Name = @"OldPackageName",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0"),
				ModifiedInSchemaUId = new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateNewPackageNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("e9b3d46e-9ed1-4236-9ad0-a2b7c2d8bc4b"),
				Name = @"NewPackageName",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0"),
				ModifiedInSchemaUId = new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0"),
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
			return new SysLicPackageNames(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLicPackageNames_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLicPackageNamesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLicPackageNamesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLicPackageNames

	/// <summary>
	/// SysLicPackageNames.
	/// </summary>
	public class SysLicPackageNames : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLicPackageNames(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLicPackageNames";
		}

		public SysLicPackageNames(SysLicPackageNames source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Old package name.
		/// </summary>
		public string OldPackageName {
			get {
				return GetTypedColumnValue<string>("OldPackageName");
			}
			set {
				SetColumnValue("OldPackageName", value);
			}
		}

		/// <summary>
		/// New package name.
		/// </summary>
		public string NewPackageName {
			get {
				return GetTypedColumnValue<string>("NewPackageName");
			}
			set {
				SetColumnValue("NewPackageName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLicPackageNames_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLicPackageNames(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLicPackageNames_BaseEventsProcess

	/// <exclude/>
	public partial class SysLicPackageNames_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysLicPackageNames
	{

		public SysLicPackageNames_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLicPackageNames_BaseEventsProcess";
			SchemaUId = new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("892f3df4-a8b5-4751-b518-5d3859fe95f0");
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

	#region Class: SysLicPackageNames_BaseEventsProcess

	/// <exclude/>
	public class SysLicPackageNames_BaseEventsProcess : SysLicPackageNames_BaseEventsProcess<SysLicPackageNames>
	{

		public SysLicPackageNames_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLicPackageNames_BaseEventsProcess

	public partial class SysLicPackageNames_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLicPackageNamesEventsProcess

	/// <exclude/>
	public class SysLicPackageNamesEventsProcess : SysLicPackageNames_BaseEventsProcess
	{

		public SysLicPackageNamesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

