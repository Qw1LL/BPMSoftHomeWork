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

	#region Class: DCRecipientSchema

	/// <exclude/>
	public class DCRecipientSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DCRecipientSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCRecipientSchema(DCRecipientSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCRecipientSchema(DCRecipientSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIKXVrInAdMT0UDnUi2ShQoChlrG8Index() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("6cdd9518-52a1-495c-9ac6-f450330395fe");
			index.Name = "IKXVrInAdMT0UDnUi2ShQoChlrG8";
			index.CreatedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c");
			index.ModifiedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c");
			index.CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			EntitySchemaIndexColumn recipientIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ec090bc2-b35f-4aa3-93a0-53dd0c681ca6"),
				ColumnUId = new Guid("dbdd88df-33ec-4559-8069-445cacb25c05"),
				CreatedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c"),
				ModifiedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(recipientIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c");
			RealUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c");
			Name = "DCRecipient";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3f3b7920-f7b1-49b5-80d8-f9f1e6c6fe5c")) == null) {
				Columns.Add(CreateDCReplicaColumn());
			}
			if (Columns.FindByUId(new Guid("dbdd88df-33ec-4559-8069-445cacb25c05")) == null) {
				Columns.Add(CreateRecipientIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDCReplicaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3f3b7920-f7b1-49b5-80d8-f9f1e6c6fe5c"),
				Name = @"DCReplica",
				ReferenceSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c"),
				ModifiedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dbdd88df-33ec-4559-8069-445cacb25c05"),
				Name = @"RecipientId",
				CreatedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c"),
				ModifiedInSchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIKXVrInAdMT0UDnUi2ShQoChlrG8Index());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DCRecipient(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCRecipient_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCRecipientSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCRecipientSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c"));
		}

		#endregion

	}

	#endregion

	#region Class: DCRecipient

	/// <summary>
	/// DCRecipient.
	/// </summary>
	public class DCRecipient : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DCRecipient(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCRecipient";
		}

		public DCRecipient(DCRecipient source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DCReplicaId {
			get {
				return GetTypedColumnValue<Guid>("DCReplicaId");
			}
			set {
				SetColumnValue("DCReplicaId", value);
				_dCReplica = null;
			}
		}

		/// <exclude/>
		public string DCReplicaCaption {
			get {
				return GetTypedColumnValue<string>("DCReplicaCaption");
			}
			set {
				SetColumnValue("DCReplicaCaption", value);
				if (_dCReplica != null) {
					_dCReplica.Caption = value;
				}
			}
		}

		private DCReplica _dCReplica;
		/// <summary>
		/// DCReplica.
		/// </summary>
		public DCReplica DCReplica {
			get {
				return _dCReplica ??
					(_dCReplica = LookupColumnEntities.GetEntity("DCReplica") as DCReplica);
			}
		}

		/// <summary>
		/// RecipientId.
		/// </summary>
		public Guid RecipientId {
			get {
				return GetTypedColumnValue<Guid>("RecipientId");
			}
			set {
				SetColumnValue("RecipientId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCRecipient_MarketingCampaignEventsProcess(UserConnection);
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
			return new DCRecipient(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCRecipient_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class DCRecipient_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DCRecipient
	{

		public DCRecipient_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCRecipient_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7255525b-7b9a-48bb-85cf-4c0ea072e89c");
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

	#region Class: DCRecipient_MarketingCampaignEventsProcess

	/// <exclude/>
	public class DCRecipient_MarketingCampaignEventsProcess : DCRecipient_MarketingCampaignEventsProcess<DCRecipient>
	{

		public DCRecipient_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCRecipient_MarketingCampaignEventsProcess

	public partial class DCRecipient_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCRecipientEventsProcess

	/// <exclude/>
	public class DCRecipientEventsProcess : DCRecipient_MarketingCampaignEventsProcess
	{

		public DCRecipientEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

