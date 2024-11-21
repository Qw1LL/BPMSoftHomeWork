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

	#region Class: BulkEmailRecipientMacroSchema

	/// <exclude/>
	public class BulkEmailRecipientMacroSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailRecipientMacroSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailRecipientMacroSchema(BulkEmailRecipientMacroSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailRecipientMacroSchema(BulkEmailRecipientMacroSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988");
			RealUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988");
			Name = "BulkEmailRecipientMacro";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4595cd2e-1797-4032-bb70-576c1e89ad53")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("986d4d56-88d3-4654-b50a-fd10208b6309")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("c064095f-9dae-4f62-ba39-52cfec26b764")) == null) {
				Columns.Add(CreateRecipientUIdColumn());
			}
			if (Columns.FindByUId(new Guid("3b649001-34f9-4547-901d-2d7c9e0fd685")) == null) {
				Columns.Add(CreateMacrosColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4595cd2e-1797-4032-bb70-576c1e89ad53"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				ModifiedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("986d4d56-88d3-4654-b50a-fd10208b6309"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				ModifiedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c064095f-9dae-4f62-ba39-52cfec26b764"),
				Name = @"RecipientUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				ModifiedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateMacrosColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3b649001-34f9-4547-901d-2d7c9e0fd685"),
				Name = @"Macros",
				CreatedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				ModifiedInSchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailRecipientMacro(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailRecipientMacro_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailRecipientMacroSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailRecipientMacroSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailRecipientMacro

	/// <summary>
	/// BulkEmailRecipientMacro.
	/// </summary>
	public class BulkEmailRecipientMacro : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailRecipientMacro(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailRecipientMacro";
		}

		public BulkEmailRecipientMacro(BulkEmailRecipientMacro source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// BulkEmail.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
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

		/// <summary>
		/// RecipientUId.
		/// </summary>
		public Guid RecipientUId {
			get {
				return GetTypedColumnValue<Guid>("RecipientUId");
			}
			set {
				SetColumnValue("RecipientUId", value);
			}
		}

		/// <summary>
		/// Macros.
		/// </summary>
		public string Macros {
			get {
				return GetTypedColumnValue<string>("Macros");
			}
			set {
				SetColumnValue("Macros", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailRecipientMacro_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailRecipientMacro(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailRecipientMacro_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailRecipientMacro_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailRecipientMacro
	{

		public BulkEmailRecipientMacro_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailRecipientMacro_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a8b9ddb1-6ca6-4dec-94b4-bc0a00eff988");
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

	#region Class: BulkEmailRecipientMacro_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailRecipientMacro_MarketingCampaignEventsProcess : BulkEmailRecipientMacro_MarketingCampaignEventsProcess<BulkEmailRecipientMacro>
	{

		public BulkEmailRecipientMacro_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailRecipientMacro_MarketingCampaignEventsProcess

	public partial class BulkEmailRecipientMacro_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailRecipientMacroEventsProcess

	/// <exclude/>
	public class BulkEmailRecipientMacroEventsProcess : BulkEmailRecipientMacro_MarketingCampaignEventsProcess
	{

		public BulkEmailRecipientMacroEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

