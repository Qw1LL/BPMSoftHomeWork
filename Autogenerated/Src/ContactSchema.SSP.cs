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

	#region Class: Contact_SSP_BPMSoftSchema

	/// <exclude/>
	public class Contact_SSP_BPMSoftSchema : BPMSoft.Configuration.Contact_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public Contact_SSP_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_SSP_BPMSoftSchema(Contact_SSP_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_SSP_BPMSoftSchema(Contact_SSP_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d1f9c4f6-45cc-40f6-b0df-65096814f6d6");
			Name = "Contact_SSP_BPMSoft";
			ParentSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
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
			return new Contact_SSP_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_SSP_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_SSP_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d1f9c4f6-45cc-40f6-b0df-65096814f6d6"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_SSP_BPMSoft

	/// <summary>
	/// Contact.
	/// </summary>
	public class Contact_SSP_BPMSoft : BPMSoft.Configuration.Contact_Lead_BPMSoft
	{

		#region Constructors: Public

		public Contact_SSP_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_SSP_BPMSoft";
		}

		public Contact_SSP_BPMSoft(Contact_SSP_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contact_SSPEventsProcess(UserConnection);
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
			return new Contact_SSP_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_SSPEventsProcess

	/// <exclude/>
	public partial class Contact_SSPEventsProcess<TEntity> : BPMSoft.Configuration.Contact_LeadEventsProcess<TEntity> where TEntity : Contact_SSP_BPMSoft
	{

		public Contact_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d1f9c4f6-45cc-40f6-b0df-65096814f6d6");
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

	#region Class: Contact_SSPEventsProcess

	/// <exclude/>
	public class Contact_SSPEventsProcess : Contact_SSPEventsProcess<Contact_SSP_BPMSoft>
	{

		public Contact_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contact_SSPEventsProcess

	public partial class Contact_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

