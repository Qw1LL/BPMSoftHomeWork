namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Mail;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	#region Class: OpportunityVisaSchema

	/// <exclude/>
	public class OpportunityVisaSchema : BPMSoft.Configuration.BaseVisaSchema
	{

		#region Constructors: Public

		public OpportunityVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityVisaSchema(OpportunityVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityVisaSchema(OpportunityVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ed0b26f0-6d99-4aab-8b99-37921e73f2eb");
			RealUId = new Guid("ed0b26f0-6d99-4aab-8b99-37921e73f2eb");
			Name = "OpportunityVisa";
			ParentSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			ExtendParent = false;
			CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d3c7775b-e96a-4661-8da6-41911e7a69e6")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d3c7775b-e96a-4661-8da6-41911e7a69e6"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ed0b26f0-6d99-4aab-8b99-37921e73f2eb"),
				ModifiedInSchemaUId = new Guid("ed0b26f0-6d99-4aab-8b99-37921e73f2eb"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityVisa_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ed0b26f0-6d99-4aab-8b99-37921e73f2eb"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityVisa

	/// <summary>
	/// Виза продажи .
	/// </summary>
	public class OpportunityVisa : BPMSoft.Configuration.BaseVisa
	{

		#region Constructors: Public

		public OpportunityVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityVisa";
		}

		public OpportunityVisa(OpportunityVisa source)
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
			var process = new OpportunityVisa_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("OpportunityVisaInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityVisaInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityVisaSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityVisaSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityVisaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityVisa_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityVisa_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseVisa_NUIEventsProcess<TEntity> where TEntity : OpportunityVisa
	{

		public OpportunityVisa_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityVisa_OpportunityEventsProcess";
			SchemaUId = new Guid("ed0b26f0-6d99-4aab-8b99-37921e73f2eb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ed0b26f0-6d99-4aab-8b99-37921e73f2eb");
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

	#region Class: OpportunityVisa_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityVisa_OpportunityEventsProcess : OpportunityVisa_OpportunityEventsProcess<OpportunityVisa>
	{

		public OpportunityVisa_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityVisa_OpportunityEventsProcess

	public partial class OpportunityVisa_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		public override List<string> GetVisaTemplateSchemaQueryColumns() {
			List<string> columns = base.GetVisaTemplateSchemaQueryColumns();
			columns.AddRange( new string[] {
				"Opportunity.Title",
				"Opportunity.Revenue",
				"Opportunity.Probability.Name",
				"Opportunity.Owner.Name",
				"Opportunity.Contact.Name",
				"Opportunity.Account.Name"
			});
			return columns;
		}

		#endregion

	}

	#endregion


	#region Class: OpportunityVisaEventsProcess

	/// <exclude/>
	public class OpportunityVisaEventsProcess : OpportunityVisa_OpportunityEventsProcess
	{

		public OpportunityVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

