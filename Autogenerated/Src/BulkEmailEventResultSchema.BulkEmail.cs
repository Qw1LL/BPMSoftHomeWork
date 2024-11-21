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

	#region Class: BulkEmailEventResultSchema

	/// <exclude/>
	public class BulkEmailEventResultSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailEventResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailEventResultSchema(BulkEmailEventResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailEventResultSchema(BulkEmailEventResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("278b8de5-eb1e-4b54-9a1d-c32ae35e033f");
			RealUId = new Guid("278b8de5-eb1e-4b54-9a1d-c32ae35e033f");
			Name = "BulkEmailEventResult";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("047a9257-bd59-41e6-8705-ec422d051419");
			IsDBView = false;
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
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("01baf2e4-42de-434f-97b2-73912201104a"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("278b8de5-eb1e-4b54-9a1d-c32ae35e033f"),
				ModifiedInSchemaUId = new Guid("278b8de5-eb1e-4b54-9a1d-c32ae35e033f"),
				CreatedInPackageId = new Guid("047a9257-bd59-41e6-8705-ec422d051419"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailEventResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailEventResult_BulkEmailEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailEventResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailEventResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("278b8de5-eb1e-4b54-9a1d-c32ae35e033f"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailEventResult

	/// <summary>
	/// Тип события в журнале рассылок.
	/// </summary>
	public class BulkEmailEventResult : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailEventResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailEventResult";
		}

		public BulkEmailEventResult(BulkEmailEventResult source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
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
			var process = new BulkEmailEventResult_BulkEmailEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailEventResultDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailEventResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailEventResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailEventResult_BulkEmailEventsProcess

	/// <exclude/>
	public partial class BulkEmailEventResult_BulkEmailEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailEventResult
	{

		public BulkEmailEventResult_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailEventResult_BulkEmailEventsProcess";
			SchemaUId = new Guid("278b8de5-eb1e-4b54-9a1d-c32ae35e033f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("278b8de5-eb1e-4b54-9a1d-c32ae35e033f");
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

	#region Class: BulkEmailEventResult_BulkEmailEventsProcess

	/// <exclude/>
	public class BulkEmailEventResult_BulkEmailEventsProcess : BulkEmailEventResult_BulkEmailEventsProcess<BulkEmailEventResult>
	{

		public BulkEmailEventResult_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailEventResult_BulkEmailEventsProcess

	public partial class BulkEmailEventResult_BulkEmailEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailEventResultEventsProcess

	/// <exclude/>
	public class BulkEmailEventResultEventsProcess : BulkEmailEventResult_BulkEmailEventsProcess
	{

		public BulkEmailEventResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

