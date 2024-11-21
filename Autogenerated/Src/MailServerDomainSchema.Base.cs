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

	#region Class: MailServerDomainSchema

	/// <exclude/>
	public class MailServerDomainSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MailServerDomainSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailServerDomainSchema(MailServerDomainSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailServerDomainSchema(MailServerDomainSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e");
			RealUId = new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e");
			Name = "MailServerDomain";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("eb755552-28ff-4cf3-ae84-2b35afc8ed12")) == null) {
				Columns.Add(CreateDomainColumn());
			}
			if (Columns.FindByUId(new Guid("18c17bbf-d237-49ce-95e7-db40c3d7842a")) == null) {
				Columns.Add(CreateMailServerColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDomainColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("eb755552-28ff-4cf3-ae84-2b35afc8ed12"),
				Name = @"Domain",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e"),
				ModifiedInSchemaUId = new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateMailServerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("18c17bbf-d237-49ce-95e7-db40c3d7842a"),
				Name = @"MailServer",
				ReferenceSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e"),
				ModifiedInSchemaUId = new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailServerDomain(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailServerDomain_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailServerDomainSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailServerDomainSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e"));
		}

		#endregion

	}

	#endregion

	#region Class: MailServerDomain

	/// <summary>
	/// Mail server domains.
	/// </summary>
	public class MailServerDomain : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MailServerDomain(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailServerDomain";
		}

		public MailServerDomain(MailServerDomain source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Domain.
		/// </summary>
		public string Domain {
			get {
				return GetTypedColumnValue<string>("Domain");
			}
			set {
				SetColumnValue("Domain", value);
			}
		}

		/// <exclude/>
		public Guid MailServerId {
			get {
				return GetTypedColumnValue<Guid>("MailServerId");
			}
			set {
				SetColumnValue("MailServerId", value);
				_mailServer = null;
			}
		}

		/// <exclude/>
		public string MailServerName {
			get {
				return GetTypedColumnValue<string>("MailServerName");
			}
			set {
				SetColumnValue("MailServerName", value);
				if (_mailServer != null) {
					_mailServer.Name = value;
				}
			}
		}

		private MailServer _mailServer;
		/// <summary>
		/// Mail server.
		/// </summary>
		public MailServer MailServer {
			get {
				return _mailServer ??
					(_mailServer = LookupColumnEntities.GetEntity("MailServer") as MailServer);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailServerDomain_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailServerDomainDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailServerDomain(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailServerDomain_BaseEventsProcess

	/// <exclude/>
	public partial class MailServerDomain_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MailServerDomain
	{

		public MailServerDomain_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailServerDomain_BaseEventsProcess";
			SchemaUId = new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5ff928e9-4615-4485-808e-8d58a2d7414e");
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

	#region Class: MailServerDomain_BaseEventsProcess

	/// <exclude/>
	public class MailServerDomain_BaseEventsProcess : MailServerDomain_BaseEventsProcess<MailServerDomain>
	{

		public MailServerDomain_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailServerDomain_BaseEventsProcess

	public partial class MailServerDomain_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailServerDomainEventsProcess

	/// <exclude/>
	public class MailServerDomainEventsProcess : MailServerDomain_BaseEventsProcess
	{

		public MailServerDomainEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

