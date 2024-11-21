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

	#region Class: CampaignSignalSchema

	/// <exclude/>
	public class CampaignSignalSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignSignalSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignSignalSchema(CampaignSignalSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignSignalSchema(CampaignSignalSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496");
			RealUId = new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496");
			Name = "CampaignSignal";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4bdf01c0-8e86-4241-acd2-68d1107dc66a")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("587e4f60-a63b-44a5-bb40-7a1383bde167")) == null) {
				Columns.Add(CreateCampaignItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4bdf01c0-8e86-4241-acd2-68d1107dc66a"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496"),
				ModifiedInSchemaUId = new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496"),
				CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("587e4f60-a63b-44a5-bb40-7a1383bde167"),
				Name = @"CampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496"),
				ModifiedInSchemaUId = new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496"),
				CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignSignal(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignSignal_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignSignalSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignSignalSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignSignal

	/// <summary>
	/// Элемент очереди сигналов для кампаний.
	/// </summary>
	public class CampaignSignal : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignSignal(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignSignal";
		}

		public CampaignSignal(CampaignSignal source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid CampaignItemId {
			get {
				return GetTypedColumnValue<Guid>("CampaignItemId");
			}
			set {
				SetColumnValue("CampaignItemId", value);
				_campaignItem = null;
			}
		}

		/// <exclude/>
		public string CampaignItemName {
			get {
				return GetTypedColumnValue<string>("CampaignItemName");
			}
			set {
				SetColumnValue("CampaignItemName", value);
				if (_campaignItem != null) {
					_campaignItem.Name = value;
				}
			}
		}

		private CampaignItem _campaignItem;
		/// <summary>
		/// Шаг кампании.
		/// </summary>
		public CampaignItem CampaignItem {
			get {
				return _campaignItem ??
					(_campaignItem = LookupColumnEntities.GetEntity("CampaignItem") as CampaignItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignSignal_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignSignalDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignSignal(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignSignal_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignSignal_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignSignal
	{

		public CampaignSignal_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignSignal_CampaignsEventsProcess";
			SchemaUId = new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3bc0bc0a-a60b-4aff-86f9-f9cbd6969496");
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

	#region Class: CampaignSignal_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignSignal_CampaignsEventsProcess : CampaignSignal_CampaignsEventsProcess<CampaignSignal>
	{

		public CampaignSignal_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignSignal_CampaignsEventsProcess

	public partial class CampaignSignal_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignSignalEventsProcess

	/// <exclude/>
	public class CampaignSignalEventsProcess : CampaignSignal_CampaignsEventsProcess
	{

		public CampaignSignalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

