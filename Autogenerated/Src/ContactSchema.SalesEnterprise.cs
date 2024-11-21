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

	#region Class: Contact_SalesEnterprise_BPMSoftSchema

	/// <exclude/>
	public class Contact_SalesEnterprise_BPMSoftSchema : BPMSoft.Configuration.Contact_MarketingCampaign_BPMSoftSchema
	{

		#region Constructors: Public

		public Contact_SalesEnterprise_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_SalesEnterprise_BPMSoftSchema(Contact_SalesEnterprise_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_SalesEnterprise_BPMSoftSchema(Contact_SalesEnterprise_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5426b243-3e54-41e2-9db1-818dfe27d291");
			Name = "Contact_SalesEnterprise_BPMSoft";
			ParentSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("6ee8d7b1-3226-4f2d-bb21-2207f8a78f18");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contact_SalesEnterprise_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_SalesEnterpriseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_SalesEnterprise_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_SalesEnterprise_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5426b243-3e54-41e2-9db1-818dfe27d291"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_SalesEnterprise_BPMSoft

	/// <summary>
	/// Контакт.
	/// </summary>
	public class Contact_SalesEnterprise_BPMSoft : BPMSoft.Configuration.Contact_MarketingCampaign_BPMSoft
	{

		#region Constructors: Public

		public Contact_SalesEnterprise_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_SalesEnterprise_BPMSoft";
		}

		public Contact_SalesEnterprise_BPMSoft(Contact_SalesEnterprise_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contact_SalesEnterpriseEventsProcess(UserConnection);
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
			return new Contact_SalesEnterprise_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_SalesEnterpriseEventsProcess

	/// <exclude/>
	public partial class Contact_SalesEnterpriseEventsProcess<TEntity> : BPMSoft.Configuration.Contact_MarketingCampaignEventsProcess<TEntity> where TEntity : Contact_SalesEnterprise_BPMSoft
	{

		public Contact_SalesEnterpriseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_SalesEnterpriseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5426b243-3e54-41e2-9db1-818dfe27d291");
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

	#region Class: Contact_SalesEnterpriseEventsProcess

	/// <exclude/>
	public class Contact_SalesEnterpriseEventsProcess : Contact_SalesEnterpriseEventsProcess<Contact_SalesEnterprise_BPMSoft>
	{

		public Contact_SalesEnterpriseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contact_SalesEnterpriseEventsProcess

	public partial class Contact_SalesEnterpriseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

