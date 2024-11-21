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

	#region Class: ParticipationStatusSchema

	/// <exclude/>
	public class ParticipationStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ParticipationStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ParticipationStatusSchema(ParticipationStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ParticipationStatusSchema(ParticipationStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fd47deef-2ba0-4c9b-a237-6cfbae4e028b");
			RealUId = new Guid("fd47deef-2ba0-4c9b-a237-6cfbae4e028b");
			Name = "ParticipationStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ParticipationStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ParticipationStatus_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ParticipationStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ParticipationStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fd47deef-2ba0-4c9b-a237-6cfbae4e028b"));
		}

		#endregion

	}

	#endregion

	#region Class: ParticipationStatus

	/// <summary>
	/// Статус участия.
	/// </summary>
	public class ParticipationStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ParticipationStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ParticipationStatus";
		}

		public ParticipationStatus(ParticipationStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ParticipationStatus_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ParticipationStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("ParticipationStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ParticipationStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: ParticipationStatus_PRMBaseEventsProcess

	/// <exclude/>
	public partial class ParticipationStatus_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ParticipationStatus
	{

		public ParticipationStatus_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ParticipationStatus_PRMBaseEventsProcess";
			SchemaUId = new Guid("fd47deef-2ba0-4c9b-a237-6cfbae4e028b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fd47deef-2ba0-4c9b-a237-6cfbae4e028b");
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

	#region Class: ParticipationStatus_PRMBaseEventsProcess

	/// <exclude/>
	public class ParticipationStatus_PRMBaseEventsProcess : ParticipationStatus_PRMBaseEventsProcess<ParticipationStatus>
	{

		public ParticipationStatus_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ParticipationStatus_PRMBaseEventsProcess

	public partial class ParticipationStatus_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ParticipationStatusEventsProcess

	/// <exclude/>
	public class ParticipationStatusEventsProcess : ParticipationStatus_PRMBaseEventsProcess
	{

		public ParticipationStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

