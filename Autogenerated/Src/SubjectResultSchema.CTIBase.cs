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

	#region Class: SubjectResultSchema

	/// <exclude/>
	public class SubjectResultSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SubjectResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SubjectResultSchema(SubjectResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SubjectResultSchema(SubjectResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			RealUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			Name = "SubjectResult";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			column.CreatedInPackageId = new Guid("cc523c7a-05f8-49ae-82e3-7e8817b1decf");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SubjectResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SubjectResult_CTIBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SubjectResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SubjectResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a751c2e7-865b-4645-92e1-75a737015b54"));
		}

		#endregion

	}

	#endregion

	#region Class: SubjectResult

	/// <summary>
	/// Subject consultation result.
	/// </summary>
	public class SubjectResult : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SubjectResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SubjectResult";
		}

		public SubjectResult(SubjectResult source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SubjectResult_CTIBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SubjectResultDeleted", e);
			Inserting += (s, e) => ThrowEvent("SubjectResultInserting", e);
			Validating += (s, e) => ThrowEvent("SubjectResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SubjectResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: SubjectResult_CTIBaseEventsProcess

	/// <exclude/>
	public partial class SubjectResult_CTIBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SubjectResult
	{

		public SubjectResult_CTIBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SubjectResult_CTIBaseEventsProcess";
			SchemaUId = new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a751c2e7-865b-4645-92e1-75a737015b54");
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

	#region Class: SubjectResult_CTIBaseEventsProcess

	/// <exclude/>
	public class SubjectResult_CTIBaseEventsProcess : SubjectResult_CTIBaseEventsProcess<SubjectResult>
	{

		public SubjectResult_CTIBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SubjectResult_CTIBaseEventsProcess

	public partial class SubjectResult_CTIBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SubjectResultEventsProcess

	/// <exclude/>
	public class SubjectResultEventsProcess : SubjectResult_CTIBaseEventsProcess
	{

		public SubjectResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

