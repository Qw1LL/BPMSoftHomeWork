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

	#region Class: OppContactMotivator_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OppContactMotivator_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OppContactMotivator_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppContactMotivator_Opportunity_BPMSoftSchema(OppContactMotivator_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppContactMotivator_Opportunity_BPMSoftSchema(OppContactMotivator_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			RealUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			Name = "OppContactMotivator_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ac7e6ce7-f6de-4e65-974a-b0db30b9ba94")) == null) {
				Columns.Add(CreateContactMotivatorColumn());
			}
			if (Columns.FindByUId(new Guid("1671e4c6-5101-4669-bf1b-08f20f5b2237")) == null) {
				Columns.Add(CreateOpportunityContactColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			column.CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactMotivatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac7e6ce7-f6de-4e65-974a-b0db30b9ba94"),
				Name = @"ContactMotivator",
				ReferenceSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3"),
				ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateOpportunityContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1671e4c6-5101-4669-bf1b-08f20f5b2237"),
				Name = @"OpportunityContact",
				ReferenceSchemaUId = new Guid("fa274f3d-57a3-44ee-b644-d93441a31de2"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3"),
				ModifiedInSchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OppContactMotivator_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppContactMotivator_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppContactMotivator_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppContactMotivator_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3"));
		}

		#endregion

	}

	#endregion

	#region Class: OppContactMotivator_Opportunity_BPMSoft

	/// <summary>
	/// Мотиватор контакта продажи.
	/// </summary>
	public class OppContactMotivator_Opportunity_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OppContactMotivator_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppContactMotivator_Opportunity_BPMSoft";
		}

		public OppContactMotivator_Opportunity_BPMSoft(OppContactMotivator_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactMotivatorId {
			get {
				return GetTypedColumnValue<Guid>("ContactMotivatorId");
			}
			set {
				SetColumnValue("ContactMotivatorId", value);
				_contactMotivator = null;
			}
		}

		/// <exclude/>
		public string ContactMotivatorName {
			get {
				return GetTypedColumnValue<string>("ContactMotivatorName");
			}
			set {
				SetColumnValue("ContactMotivatorName", value);
				if (_contactMotivator != null) {
					_contactMotivator.Name = value;
				}
			}
		}

		private OppContactMotivators _contactMotivator;
		/// <summary>
		/// Мотиватор.
		/// </summary>
		public OppContactMotivators ContactMotivator {
			get {
				return _contactMotivator ??
					(_contactMotivator = LookupColumnEntities.GetEntity("ContactMotivator") as OppContactMotivators);
			}
		}

		/// <exclude/>
		public Guid OpportunityContactId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityContactId");
			}
			set {
				SetColumnValue("OpportunityContactId", value);
				_opportunityContact = null;
			}
		}

		private OpportunityContact _opportunityContact;
		/// <summary>
		/// Контакт продажи.
		/// </summary>
		public OpportunityContact OpportunityContact {
			get {
				return _opportunityContact ??
					(_opportunityContact = LookupColumnEntities.GetEntity("OpportunityContact") as OpportunityContact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppContactMotivator_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OppContactMotivator_Opportunity_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("OppContactMotivator_Opportunity_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("OppContactMotivator_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OppContactMotivator_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppContactMotivator_OpportunityEventsProcess

	/// <exclude/>
	public partial class OppContactMotivator_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OppContactMotivator_Opportunity_BPMSoft
	{

		public OppContactMotivator_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppContactMotivator_OpportunityEventsProcess";
			SchemaUId = new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9f22a125-ab73-43ed-a5fa-b1b9d7bdbdc3");
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

	#region Class: OppContactMotivator_OpportunityEventsProcess

	/// <exclude/>
	public class OppContactMotivator_OpportunityEventsProcess : OppContactMotivator_OpportunityEventsProcess<OppContactMotivator_Opportunity_BPMSoft>
	{

		public OppContactMotivator_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppContactMotivator_OpportunityEventsProcess

	public partial class OppContactMotivator_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

