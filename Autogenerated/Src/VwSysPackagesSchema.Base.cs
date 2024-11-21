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

	#region Class: VwSysPackagesSchema

	/// <exclude/>
	public class VwSysPackagesSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysPackagesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysPackagesSchema(VwSysPackagesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysPackagesSchema(VwSysPackagesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95c5a559-0f91-4d4f-b0b3-62d226875916");
			RealUId = new Guid("95c5a559-0f91-4d4f-b0b3-62d226875916");
			Name = "VwSysPackages";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("1234f32b-eaf1-4f76-b06d-73277e6c9746");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("19feb774-4458-4375-b47e-49a26f0d5548"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("95c5a559-0f91-4d4f-b0b3-62d226875916"),
				ModifiedInSchemaUId = new Guid("95c5a559-0f91-4d4f-b0b3-62d226875916"),
				CreatedInPackageId = new Guid("1234f32b-eaf1-4f76-b06d-73277e6c9746")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysPackages(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysPackages_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysPackagesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysPackagesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95c5a559-0f91-4d4f-b0b3-62d226875916"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysPackages

	/// <summary>
	/// Packages (view).
	/// </summary>
	public class VwSysPackages : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysPackages(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysPackages";
		}

		public VwSysPackages(VwSysPackages source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysPackages_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysPackagesDeleted", e);
			Validating += (s, e) => ThrowEvent("VwSysPackagesValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysPackages(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysPackages_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysPackages_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysPackages
	{

		public VwSysPackages_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysPackages_BaseEventsProcess";
			SchemaUId = new Guid("95c5a559-0f91-4d4f-b0b3-62d226875916");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("95c5a559-0f91-4d4f-b0b3-62d226875916");
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

	#region Class: VwSysPackages_BaseEventsProcess

	/// <exclude/>
	public class VwSysPackages_BaseEventsProcess : VwSysPackages_BaseEventsProcess<VwSysPackages>
	{

		public VwSysPackages_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysPackages_BaseEventsProcess

	public partial class VwSysPackages_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysPackagesEventsProcess

	/// <exclude/>
	public class VwSysPackagesEventsProcess : VwSysPackages_BaseEventsProcess
	{

		public VwSysPackagesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

