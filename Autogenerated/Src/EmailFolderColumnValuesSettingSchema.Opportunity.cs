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

	#region Class: EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema : BPMSoft.Configuration.EmailFolderColumnValuesSetting_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema(EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema(EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("69532f7a-527b-44ac-833d-61570d0ad673");
			Name = "EmailFolderColumnValuesSetting_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("14699c41-c4ed-4648-aec6-9ebffd3fcee6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("62283f71-c300-41f6-aa2b-0bd2cb7348ea")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("62283f71-c300-41f6-aa2b-0bd2cb7348ea"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("69532f7a-527b-44ac-833d-61570d0ad673"),
				ModifiedInSchemaUId = new Guid("69532f7a-527b-44ac-833d-61570d0ad673"),
				CreatedInPackageId = new Guid("14699c41-c4ed-4648-aec6-9ebffd3fcee6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("69532f7a-527b-44ac-833d-61570d0ad673"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_Opportunity_BPMSoft

	/// <summary>
	/// Настройка значений полей в группе e-mail.
	/// </summary>
	public class EmailFolderColumnValuesSetting_Opportunity_BPMSoft : BPMSoft.Configuration.EmailFolderColumnValuesSetting_Base_BPMSoft
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSetting_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailFolderColumnValuesSetting_Opportunity_BPMSoft";
		}

		public EmailFolderColumnValuesSetting_Opportunity_BPMSoft(EmailFolderColumnValuesSetting_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailFolderColumnValuesSetting_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Opportunity_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Opportunity_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailFolderColumnValuesSetting_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_OpportunityEventsProcess

	/// <exclude/>
	public partial class EmailFolderColumnValuesSetting_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.EmailFolderColumnValuesSetting_BaseEventsProcess<TEntity> where TEntity : EmailFolderColumnValuesSetting_Opportunity_BPMSoft
	{

		public EmailFolderColumnValuesSetting_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailFolderColumnValuesSetting_OpportunityEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("69532f7a-527b-44ac-833d-61570d0ad673");
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

	#region Class: EmailFolderColumnValuesSetting_OpportunityEventsProcess

	/// <exclude/>
	public class EmailFolderColumnValuesSetting_OpportunityEventsProcess : EmailFolderColumnValuesSetting_OpportunityEventsProcess<EmailFolderColumnValuesSetting_Opportunity_BPMSoft>
	{

		public EmailFolderColumnValuesSetting_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_OpportunityEventsProcess

	public partial class EmailFolderColumnValuesSetting_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

