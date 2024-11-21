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

	#region Class: VwMobileSysSchemaSchema

	/// <exclude/>
	public class VwMobileSysSchemaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwMobileSysSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwMobileSysSchemaSchema(VwMobileSysSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwMobileSysSchemaSchema(VwMobileSysSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95c3f0b4-158b-44dc-8877-f342363022ca");
			RealUId = new Guid("95c3f0b4-158b-44dc-8877-f342363022ca");
			Name = "VwMobileSysSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b65e6f51-e44a-4dfb-b0a0-020aebe079c4");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("49a2f994-327c-47c3-8fd7-885166a425c2")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("49a2f994-327c-47c3-8fd7-885166a425c2"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("95c3f0b4-158b-44dc-8877-f342363022ca"),
				ModifiedInSchemaUId = new Guid("95c3f0b4-158b-44dc-8877-f342363022ca"),
				CreatedInPackageId = new Guid("b65e6f51-e44a-4dfb-b0a0-020aebe079c4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwMobileSysSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwMobileSysSchema_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwMobileSysSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwMobileSysSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95c3f0b4-158b-44dc-8877-f342363022ca"));
		}

		#endregion

	}

	#endregion

	#region Class: VwMobileSysSchema

	/// <summary>
	/// View of schemas (Mobile).
	/// </summary>
	public class VwMobileSysSchema : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwMobileSysSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwMobileSysSchema";
		}

		public VwMobileSysSchema(VwMobileSysSchema source)
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
			var process = new VwMobileSysSchema_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwMobileSysSchemaDeleted", e);
			Validating += (s, e) => ThrowEvent("VwMobileSysSchemaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwMobileSysSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwMobileSysSchema_ESNEventsProcess

	/// <exclude/>
	public partial class VwMobileSysSchema_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwMobileSysSchema
	{

		public VwMobileSysSchema_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwMobileSysSchema_ESNEventsProcess";
			SchemaUId = new Guid("95c3f0b4-158b-44dc-8877-f342363022ca");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("95c3f0b4-158b-44dc-8877-f342363022ca");
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

	#region Class: VwMobileSysSchema_ESNEventsProcess

	/// <exclude/>
	public class VwMobileSysSchema_ESNEventsProcess : VwMobileSysSchema_ESNEventsProcess<VwMobileSysSchema>
	{

		public VwMobileSysSchema_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwMobileSysSchema_ESNEventsProcess

	public partial class VwMobileSysSchema_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwMobileSysSchemaEventsProcess

	/// <exclude/>
	public class VwMobileSysSchemaEventsProcess : VwMobileSysSchema_ESNEventsProcess
	{

		public VwMobileSysSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

