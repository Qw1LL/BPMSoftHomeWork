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

	#region Class: OpportunityOfferResultSchema

	/// <exclude/>
	public class OpportunityOfferResultSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OpportunityOfferResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityOfferResultSchema(OpportunityOfferResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityOfferResultSchema(OpportunityOfferResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fb5aa2be-bcb5-4b99-a2f6-5ba7850c0560");
			RealUId = new Guid("fb5aa2be-bcb5-4b99-a2f6-5ba7850c0560");
			Name = "OpportunityOfferResult";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("264efbd2-8a08-4761-9e2e-c87c3e9aa3f8")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("264efbd2-8a08-4761-9e2e-c87c3e9aa3f8"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("fb5aa2be-bcb5-4b99-a2f6-5ba7850c0560"),
				ModifiedInSchemaUId = new Guid("fb5aa2be-bcb5-4b99-a2f6-5ba7850c0560"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityOfferResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityOfferResult_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityOfferResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityOfferResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb5aa2be-bcb5-4b99-a2f6-5ba7850c0560"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityOfferResult

	/// <summary>
	/// Результат предложения.
	/// </summary>
	public class OpportunityOfferResult : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OpportunityOfferResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityOfferResult";
		}

		public OpportunityOfferResult(OpportunityOfferResult source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Значение.
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
			var process = new OpportunityOfferResult_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityOfferResultDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityOfferResultDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityOfferResultInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityOfferResultInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityOfferResultSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityOfferResultSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityOfferResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityOfferResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityOfferResult_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityOfferResult_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OpportunityOfferResult
	{

		public OpportunityOfferResult_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityOfferResult_OpportunityEventsProcess";
			SchemaUId = new Guid("fb5aa2be-bcb5-4b99-a2f6-5ba7850c0560");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fb5aa2be-bcb5-4b99-a2f6-5ba7850c0560");
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

	#region Class: OpportunityOfferResult_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityOfferResult_OpportunityEventsProcess : OpportunityOfferResult_OpportunityEventsProcess<OpportunityOfferResult>
	{

		public OpportunityOfferResult_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityOfferResult_OpportunityEventsProcess

	public partial class OpportunityOfferResult_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityOfferResultEventsProcess

	/// <exclude/>
	public class OpportunityOfferResultEventsProcess : OpportunityOfferResult_OpportunityEventsProcess
	{

		public OpportunityOfferResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

