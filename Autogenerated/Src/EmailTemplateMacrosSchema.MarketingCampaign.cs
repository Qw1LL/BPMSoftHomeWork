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

	#region Class: EmailTemplateMacrosSchema

	/// <exclude/>
	public class EmailTemplateMacrosSchema : BPMSoft.Configuration.EmailTemplateMacros_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public EmailTemplateMacrosSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateMacrosSchema(EmailTemplateMacrosSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateMacrosSchema(EmailTemplateMacrosSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("3454c58c-8bdd-4536-8aff-9451b62cac67");
			Name = "EmailTemplateMacros";
			ParentSchemaUId = new Guid("e92a62ec-f0bb-422f-9a33-6d79532edc21");
			ExtendParent = true;
			CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("31f443f0-9862-45d4-82b1-3646b7be7e80")) == null) {
				Columns.Add(CreateTemplateColumn());
			}
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ModifiedInSchemaUId = new Guid("3454c58c-8bdd-4536-8aff-9451b62cac67");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("31f443f0-9862-45d4-82b1-3646b7be7e80"),
				Name = @"Template",
				CreatedInSchemaUId = new Guid("3454c58c-8bdd-4536-8aff-9451b62cac67"),
				ModifiedInSchemaUId = new Guid("3454c58c-8bdd-4536-8aff-9451b62cac67"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailTemplateMacros(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateMacros_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateMacrosSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateMacrosSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3454c58c-8bdd-4536-8aff-9451b62cac67"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateMacros

	/// <summary>
	/// Макрос шаблона сообщения.
	/// </summary>
	public class EmailTemplateMacros : BPMSoft.Configuration.EmailTemplateMacros_Base_BPMSoft
	{

		#region Constructors: Public

		public EmailTemplateMacros(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateMacros";
		}

		public EmailTemplateMacros(EmailTemplateMacros source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Шаблон.
		/// </summary>
		public string Template {
			get {
				return GetTypedColumnValue<string>("Template");
			}
			set {
				SetColumnValue("Template", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplateMacros_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailTemplateMacrosDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailTemplateMacrosInserting", e);
			Validating += (s, e) => ThrowEvent("EmailTemplateMacrosValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplateMacros(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateMacros_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EmailTemplateMacros_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.EmailTemplateMacros_BaseEventsProcess<TEntity> where TEntity : EmailTemplateMacros
	{

		public EmailTemplateMacros_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateMacros_MarketingCampaignEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3454c58c-8bdd-4536-8aff-9451b62cac67");
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

	#region Class: EmailTemplateMacros_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EmailTemplateMacros_MarketingCampaignEventsProcess : EmailTemplateMacros_MarketingCampaignEventsProcess<EmailTemplateMacros>
	{

		public EmailTemplateMacros_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateMacros_MarketingCampaignEventsProcess

	public partial class EmailTemplateMacros_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateMacrosEventsProcess

	/// <exclude/>
	public class EmailTemplateMacrosEventsProcess : EmailTemplateMacros_MarketingCampaignEventsProcess
	{

		public EmailTemplateMacrosEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

