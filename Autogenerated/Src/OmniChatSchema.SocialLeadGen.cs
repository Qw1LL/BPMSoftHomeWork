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

	#region Class: OmniChatSchema

	/// <exclude/>
	public class OmniChatSchema : BPMSoft.Configuration.OmniChat_CaseService_BPMSoftSchema
	{

		#region Constructors: Public

		public OmniChatSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChatSchema(OmniChatSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChatSchema(OmniChatSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("a2e60687-655a-4a73-b0d6-8e88f01f170f");
			Name = "OmniChat";
			ParentSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			ExtendParent = true;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("21174400-e09d-7cfb-7f05-9e660c07844c")) == null) {
				Columns.Add(CreateLeadColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("21174400-e09d-7cfb-7f05-9e660c07844c"),
				Name = @"Lead",
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a2e60687-655a-4a73-b0d6-8e88f01f170f"),
				ModifiedInSchemaUId = new Guid("a2e60687-655a-4a73-b0d6-8e88f01f170f"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmniChat(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChat_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChatSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChatSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a2e60687-655a-4a73-b0d6-8e88f01f170f"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat

	/// <summary>
	/// Чат.
	/// </summary>
	public class OmniChat : BPMSoft.Configuration.OmniChat_CaseService_BPMSoft
	{

		#region Constructors: Public

		public OmniChat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChat";
		}

		public OmniChat(OmniChat source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		/// <remarks>
		/// Лид связанный с чатом.
		/// </remarks>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = LookupColumnEntities.GetEntity("Lead") as Lead);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniChat_SocialLeadGenEventsProcess(UserConnection);
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
			return new OmniChat(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class OmniChat_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.OmniChat_CaseServiceEventsProcess<TEntity> where TEntity : OmniChat
	{

		public OmniChat_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChat_SocialLeadGenEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a2e60687-655a-4a73-b0d6-8e88f01f170f");
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

	#region Class: OmniChat_SocialLeadGenEventsProcess

	/// <exclude/>
	public class OmniChat_SocialLeadGenEventsProcess : OmniChat_SocialLeadGenEventsProcess<OmniChat>
	{

		public OmniChat_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniChat_SocialLeadGenEventsProcess

	public partial class OmniChat_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniChatEventsProcess

	/// <exclude/>
	public class OmniChatEventsProcess : OmniChat_SocialLeadGenEventsProcess
	{

		public OmniChatEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

