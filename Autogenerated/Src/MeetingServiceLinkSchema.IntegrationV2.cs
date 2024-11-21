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

	#region Class: MeetingServiceLinkSchema

	/// <exclude/>
	public class MeetingServiceLinkSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MeetingServiceLinkSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MeetingServiceLinkSchema(MeetingServiceLinkSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MeetingServiceLinkSchema(MeetingServiceLinkSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("07367c59-0d61-4560-92d2-226b0e36fece");
			RealUId = new Guid("07367c59-0d61-4560-92d2-226b0e36fece");
			Name = "MeetingServiceLink";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("53a64f50-911e-4e24-83fd-d5af8c28bfa3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cf5c9f37-7bca-7571-40a9-b5d8a22c9ff9")) == null) {
				Columns.Add(CreateLinkMaskColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("07367c59-0d61-4560-92d2-226b0e36fece");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLinkMaskColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cf5c9f37-7bca-7571-40a9-b5d8a22c9ff9"),
				Name = @"LinkMask",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("07367c59-0d61-4560-92d2-226b0e36fece"),
				ModifiedInSchemaUId = new Guid("07367c59-0d61-4560-92d2-226b0e36fece"),
				CreatedInPackageId = new Guid("53a64f50-911e-4e24-83fd-d5af8c28bfa3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MeetingServiceLink(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MeetingServiceLink_IntegrationV2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new MeetingServiceLinkSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MeetingServiceLinkSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07367c59-0d61-4560-92d2-226b0e36fece"));
		}

		#endregion

	}

	#endregion

	#region Class: MeetingServiceLink

	/// <summary>
	/// Meeting service link.
	/// </summary>
	public class MeetingServiceLink : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MeetingServiceLink(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MeetingServiceLink";
		}

		public MeetingServiceLink(MeetingServiceLink source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Link mask.
		/// </summary>
		public string LinkMask {
			get {
				return GetTypedColumnValue<string>("LinkMask");
			}
			set {
				SetColumnValue("LinkMask", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MeetingServiceLink_IntegrationV2EventsProcess(UserConnection);
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
			return new MeetingServiceLink(this);
		}

		#endregion

	}

	#endregion

	#region Class: MeetingServiceLink_IntegrationV2EventsProcess

	/// <exclude/>
	public partial class MeetingServiceLink_IntegrationV2EventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MeetingServiceLink
	{

		public MeetingServiceLink_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MeetingServiceLink_IntegrationV2EventsProcess";
			SchemaUId = new Guid("07367c59-0d61-4560-92d2-226b0e36fece");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("07367c59-0d61-4560-92d2-226b0e36fece");
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

	#region Class: MeetingServiceLink_IntegrationV2EventsProcess

	/// <exclude/>
	public class MeetingServiceLink_IntegrationV2EventsProcess : MeetingServiceLink_IntegrationV2EventsProcess<MeetingServiceLink>
	{

		public MeetingServiceLink_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MeetingServiceLink_IntegrationV2EventsProcess

	public partial class MeetingServiceLink_IntegrationV2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MeetingServiceLinkEventsProcess

	/// <exclude/>
	public class MeetingServiceLinkEventsProcess : MeetingServiceLink_IntegrationV2EventsProcess
	{

		public MeetingServiceLinkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

