namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwMandrillRecipientV2Schema

	/// <exclude/>
	public class VwMandrillRecipientV2Schema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwMandrillRecipientV2Schema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwMandrillRecipientV2Schema(VwMandrillRecipientV2Schema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwMandrillRecipientV2Schema(VwMandrillRecipientV2Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a");
			RealUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a");
			Name = "VwMandrillRecipientV2";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("05964f3e-a121-4462-bc41-7576b05d4023");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2a2d4805-f09a-4959-910d-56a95602efff")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("02d6c691-72a6-494d-97f7-c43c7abb2b5c")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("d39b5f65-b988-4bda-992a-ae5591ffffa1")) == null) {
				Columns.Add(CreateLinkedEntityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2a2d4805-f09a-4959-910d-56a95602efff"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				ModifiedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				CreatedInPackageId = new Guid("29541596-ea83-4c00-89eb-6c01cd654a20")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("02d6c691-72a6-494d-97f7-c43c7abb2b5c"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				ModifiedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				CreatedInPackageId = new Guid("29541596-ea83-4c00-89eb-6c01cd654a20")
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d78e81c1-a5b0-4d73-90d1-57eecfcb2fe3"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				ModifiedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				CreatedInPackageId = new Guid("29541596-ea83-4c00-89eb-6c01cd654a20"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLinkedEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d39b5f65-b988-4bda-992a-ae5591ffffa1"),
				Name = @"LinkedEntity",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				ModifiedInSchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwMandrillRecipientV2(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwMandrillRecipientV2_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwMandrillRecipientV2Schema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwMandrillRecipientV2Schema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwMandrillRecipientV2

	/// <summary>
	/// Участник рассылки.
	/// </summary>
	public class VwMandrillRecipientV2 : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwMandrillRecipientV2(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwMandrillRecipientV2";
		}

		public VwMandrillRecipientV2(VwMandrillRecipientV2 source)
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
		/// Email.
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
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid LinkedEntityId {
			get {
				return GetTypedColumnValue<Guid>("LinkedEntityId");
			}
			set {
				SetColumnValue("LinkedEntityId", value);
				_linkedEntity = null;
			}
		}

		/// <exclude/>
		public string LinkedEntityName {
			get {
				return GetTypedColumnValue<string>("LinkedEntityName");
			}
			set {
				SetColumnValue("LinkedEntityName", value);
				if (_linkedEntity != null) {
					_linkedEntity.Name = value;
				}
			}
		}

		private Contact _linkedEntity;
		/// <summary>
		/// Связанная сущность.
		/// </summary>
		public Contact LinkedEntity {
			get {
				return _linkedEntity ??
					(_linkedEntity = LookupColumnEntities.GetEntity("LinkedEntity") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwMandrillRecipientV2_MarketingCampaignEventsProcess(UserConnection);
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
			return new VwMandrillRecipientV2(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwMandrillRecipientV2_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwMandrillRecipientV2_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwMandrillRecipientV2
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwMandrillRecipientV2_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwMandrillRecipientV2_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("aae86796-66f6-4430-9099-26c3b8e8ff8a");
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

	#region Class: VwMandrillRecipientV2_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwMandrillRecipientV2_MarketingCampaignEventsProcess : VwMandrillRecipientV2_MarketingCampaignEventsProcess<VwMandrillRecipientV2>
	{

		public VwMandrillRecipientV2_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwMandrillRecipientV2_MarketingCampaignEventsProcess

	public partial class VwMandrillRecipientV2_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwMandrillRecipientV2EventsProcess

	/// <exclude/>
	public class VwMandrillRecipientV2EventsProcess : VwMandrillRecipientV2_MarketingCampaignEventsProcess
	{

		public VwMandrillRecipientV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

