namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.EntitySynchronization;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
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
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: Contact_MarketingCampaign_BPMSoftSchema

	/// <exclude/>
	public class Contact_MarketingCampaign_BPMSoftSchema : BPMSoft.Configuration.Contact_SSP_BPMSoftSchema
	{

		#region Constructors: Public

		public Contact_MarketingCampaign_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_MarketingCampaign_BPMSoftSchema(Contact_MarketingCampaign_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_MarketingCampaign_BPMSoftSchema(Contact_MarketingCampaign_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateI84ciI9ljAEY9JBteoJcHEeIc1KUIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("606284af-5c43-4e46-b7d4-a01d00ffe9bc");
			index.Name = "I84ciI9ljAEY9JBteoJcHEeIc1KU";
			index.CreatedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae");
			index.ModifiedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae");
			index.CreatedInPackageId = new Guid("5b53fbff-9be6-434d-a91a-0bac8907d8d7");
			EntitySchemaIndexColumn emailIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("72478faa-6bb8-4b94-8e73-064baf7d1017"),
				ColumnUId = new Guid("dbf202ec-c444-479b-bcf4-d8e5b1863201"),
				CreatedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				ModifiedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				CreatedInPackageId = new Guid("5b53fbff-9be6-434d-a91a-0bac8907d8d7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(emailIndexColumn);
			EntitySchemaIndexColumn doNotUseEmailIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("437041e4-308e-4f07-8bf3-edd30fa9cc9c"),
				ColumnUId = new Guid("1b1d8f33-4d26-4353-a1ed-07e11fc82112"),
				CreatedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				ModifiedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				CreatedInPackageId = new Guid("5b53fbff-9be6-434d-a91a-0bac8907d8d7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(doNotUseEmailIndexColumn);
			EntitySchemaIndexColumn isNonActualEmailIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3fd12b70-0a1c-4bc7-92c5-c165ddfc5ebe"),
				ColumnUId = new Guid("65db5bf4-c253-4bd3-8988-ca1c6397a7ee"),
				CreatedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				ModifiedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				CreatedInPackageId = new Guid("5b53fbff-9be6-434d-a91a-0bac8907d8d7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(isNonActualEmailIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae");
			Name = "Contact_MarketingCampaign_BPMSoft";
			ParentSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ad50bca2-4b1b-4d20-9ed9-9c5500cdd145");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("65db5bf4-c253-4bd3-8988-ca1c6397a7ee")) == null) {
				Columns.Add(CreateIsNonActualEmailColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsNonActualEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("65db5bf4-c253-4bd3-8988-ca1c6397a7ee"),
				Name = @"IsNonActualEmail",
				CreatedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				ModifiedInSchemaUId = new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"),
				CreatedInPackageId = new Guid("ad50bca2-4b1b-4d20-9ed9-9c5500cdd145")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateI84ciI9ljAEY9JBteoJcHEeIc1KUIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contact_MarketingCampaign_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_MarketingCampaign_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_MarketingCampaign_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_MarketingCampaign_BPMSoft

	/// <summary>
	/// Контакт.
	/// </summary>
	public class Contact_MarketingCampaign_BPMSoft : BPMSoft.Configuration.Contact_SSP_BPMSoft
	{

		#region Constructors: Public

		public Contact_MarketingCampaign_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_MarketingCampaign_BPMSoft";
		}

		public Contact_MarketingCampaign_BPMSoft(Contact_MarketingCampaign_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Email не актуальный.
		/// </summary>
		public bool IsNonActualEmail {
			get {
				return GetTypedColumnValue<bool>("IsNonActualEmail");
			}
			set {
				SetColumnValue("IsNonActualEmail", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contact_MarketingCampaignEventsProcess(UserConnection);
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
			return new Contact_MarketingCampaign_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class Contact_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.Contact_SSPEventsProcess<TEntity> where TEntity : Contact_MarketingCampaign_BPMSoft
	{

		public Contact_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_MarketingCampaignEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1182f753-e867-4869-93a2-69d7a9eef7ae");
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

	#region Class: Contact_MarketingCampaignEventsProcess

	/// <exclude/>
	public class Contact_MarketingCampaignEventsProcess : Contact_MarketingCampaignEventsProcess<Contact_MarketingCampaign_BPMSoft>
	{

		public Contact_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contact_MarketingCampaignEventsProcess

	public partial class Contact_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

