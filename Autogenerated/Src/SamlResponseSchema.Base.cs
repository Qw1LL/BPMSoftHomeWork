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

	#region Class: SamlResponseSchema

	/// <exclude/>
	public class SamlResponseSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SamlResponseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SamlResponseSchema(SamlResponseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SamlResponseSchema(SamlResponseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c829c077-9dce-4819-82f7-566088d6d581");
			RealUId = new Guid("c829c077-9dce-4819-82f7-566088d6d581");
			Name = "SamlResponse";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d4dfcb12-99fe-92eb-0416-da7683213595")) == null) {
				Columns.Add(CreateResponseColumn());
			}
			if (Columns.FindByUId(new Guid("8c9aafc4-6bc9-9bdb-6b28-06ca2b70732d")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d4dfcb12-99fe-92eb-0416-da7683213595"),
				Name = @"Response",
				CreatedInSchemaUId = new Guid("c829c077-9dce-4819-82f7-566088d6d581"),
				ModifiedInSchemaUId = new Guid("c829c077-9dce-4819-82f7-566088d6d581"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8c9aafc4-6bc9-9bdb-6b28-06ca2b70732d"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c829c077-9dce-4819-82f7-566088d6d581"),
				ModifiedInSchemaUId = new Guid("c829c077-9dce-4819-82f7-566088d6d581"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SamlResponse(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SamlResponse_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SamlResponseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SamlResponseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c829c077-9dce-4819-82f7-566088d6d581"));
		}

		#endregion

	}

	#endregion

	#region Class: SamlResponse

	/// <summary>
	/// Saml response.
	/// </summary>
	public class SamlResponse : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SamlResponse(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SamlResponse";
		}

		public SamlResponse(SamlResponse source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// SAML response.
		/// </summary>
		public string Response {
			get {
				return GetTypedColumnValue<string>("Response");
			}
			set {
				SetColumnValue("Response", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SamlResponse_BaseEventsProcess(UserConnection);
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
			return new SamlResponse(this);
		}

		#endregion

	}

	#endregion

	#region Class: SamlResponse_BaseEventsProcess

	/// <exclude/>
	public partial class SamlResponse_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SamlResponse
	{

		public SamlResponse_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SamlResponse_BaseEventsProcess";
			SchemaUId = new Guid("c829c077-9dce-4819-82f7-566088d6d581");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c829c077-9dce-4819-82f7-566088d6d581");
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

	#region Class: SamlResponse_BaseEventsProcess

	/// <exclude/>
	public class SamlResponse_BaseEventsProcess : SamlResponse_BaseEventsProcess<SamlResponse>
	{

		public SamlResponse_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SamlResponse_BaseEventsProcess

	public partial class SamlResponse_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SamlResponseEventsProcess

	/// <exclude/>
	public class SamlResponseEventsProcess : SamlResponse_BaseEventsProcess
	{

		public SamlResponseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

