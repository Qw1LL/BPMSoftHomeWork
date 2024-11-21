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

	#region Class: TrackingDomainSchema

	/// <exclude/>
	public class TrackingDomainSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TrackingDomainSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TrackingDomainSchema(TrackingDomainSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TrackingDomainSchema(TrackingDomainSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("110fde2b-c119-4bd6-b051-16af4fb0107f");
			RealUId = new Guid("110fde2b-c119-4bd6-b051-16af4fb0107f");
			Name = "TrackingDomain";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("47949cd8-6780-414e-8fda-4fa996b6db3c");
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
			return new TrackingDomain(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TrackingDomain_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TrackingDomainSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TrackingDomainSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("110fde2b-c119-4bd6-b051-16af4fb0107f"));
		}

		#endregion

	}

	#endregion

	#region Class: TrackingDomain

	/// <summary>
	/// Отслеживание доменов.
	/// </summary>
	public class TrackingDomain : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TrackingDomain(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TrackingDomain";
		}

		public TrackingDomain(TrackingDomain source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TrackingDomain_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TrackingDomainDeleted", e);
			Validating += (s, e) => ThrowEvent("TrackingDomainValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TrackingDomain(this);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingDomain_EventTrackingEventsProcess

	/// <exclude/>
	public partial class TrackingDomain_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : TrackingDomain
	{

		public TrackingDomain_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TrackingDomain_EventTrackingEventsProcess";
			SchemaUId = new Guid("110fde2b-c119-4bd6-b051-16af4fb0107f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("110fde2b-c119-4bd6-b051-16af4fb0107f");
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

	#region Class: TrackingDomain_EventTrackingEventsProcess

	/// <exclude/>
	public class TrackingDomain_EventTrackingEventsProcess : TrackingDomain_EventTrackingEventsProcess<TrackingDomain>
	{

		public TrackingDomain_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TrackingDomain_EventTrackingEventsProcess

	public partial class TrackingDomain_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TrackingDomainEventsProcess

	/// <exclude/>
	public class TrackingDomainEventsProcess : TrackingDomain_EventTrackingEventsProcess
	{

		public TrackingDomainEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

