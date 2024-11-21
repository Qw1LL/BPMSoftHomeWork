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

	#region Class: TermDayTypeSchema

	/// <exclude/>
	public class TermDayTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TermDayTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TermDayTypeSchema(TermDayTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TermDayTypeSchema(TermDayTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			RealUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			Name = "TermDayType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TermDayType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TermDayType_SLMEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TermDayTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TermDayTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab"));
		}

		#endregion

	}

	#endregion

	#region Class: TermDayType

	/// <summary>
	/// Тип дня сроков.
	/// </summary>
	public class TermDayType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TermDayType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TermDayType";
		}

		public TermDayType(TermDayType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TermDayType_SLMEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TermDayTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("TermDayTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TermDayType(this);
		}

		#endregion

	}

	#endregion

	#region Class: TermDayType_SLMEventsProcess

	/// <exclude/>
	public partial class TermDayType_SLMEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : TermDayType
	{

		public TermDayType_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TermDayType_SLMEventsProcess";
			SchemaUId = new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("444ebbdc-fcc1-41f0-b7d9-5db7fae4c1ab");
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

	#region Class: TermDayType_SLMEventsProcess

	/// <exclude/>
	public class TermDayType_SLMEventsProcess : TermDayType_SLMEventsProcess<TermDayType>
	{

		public TermDayType_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TermDayType_SLMEventsProcess

	public partial class TermDayType_SLMEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: TermDayTypeEventsProcess

	/// <exclude/>
	public class TermDayTypeEventsProcess : TermDayType_SLMEventsProcess
	{

		public TermDayTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

