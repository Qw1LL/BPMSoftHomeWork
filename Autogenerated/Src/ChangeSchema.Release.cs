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

	#region Class: ChangeSchema

	/// <exclude/>
	public class ChangeSchema : BPMSoft.Configuration.Change_Change_BPMSoftSchema
	{

		#region Constructors: Public

		public ChangeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangeSchema(ChangeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangeSchema(ChangeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("fbf0ba47-7c05-450b-a07e-ff07fc54862e");
			Name = "Change";
			ParentSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			ExtendParent = true;
			CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bb6e0447-6bad-45b9-aa2c-da2bff80cf3c")) == null) {
				Columns.Add(CreateReleaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateReleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bb6e0447-6bad-45b9-aa2c-da2bff80cf3c"),
				Name = @"Release",
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fbf0ba47-7c05-450b-a07e-ff07fc54862e"),
				ModifiedInSchemaUId = new Guid("fbf0ba47-7c05-450b-a07e-ff07fc54862e"),
				CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Change(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Change_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fbf0ba47-7c05-450b-a07e-ff07fc54862e"));
		}

		#endregion

	}

	#endregion

	#region Class: Change

	/// <summary>
	/// Изменение.
	/// </summary>
	public class Change : BPMSoft.Configuration.Change_Change_BPMSoft
	{

		#region Constructors: Public

		public Change(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Change";
		}

		public Change(Change source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релиз.
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = LookupColumnEntities.GetEntity("Release") as Release);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Change_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChangeDeleted", e);
			Validating += (s, e) => ThrowEvent("ChangeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Change(this);
		}

		#endregion

	}

	#endregion

	#region Class: Change_ReleaseEventsProcess

	/// <exclude/>
	public partial class Change_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.Change_ChangeEventsProcess<TEntity> where TEntity : Change
	{

		public Change_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Change_ReleaseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fbf0ba47-7c05-450b-a07e-ff07fc54862e");
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

	#region Class: Change_ReleaseEventsProcess

	/// <exclude/>
	public class Change_ReleaseEventsProcess : Change_ReleaseEventsProcess<Change>
	{

		public Change_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Change_ReleaseEventsProcess

	public partial class Change_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangeEventsProcess

	/// <exclude/>
	public class ChangeEventsProcess : Change_ReleaseEventsProcess
	{

		public ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

