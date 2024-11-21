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

	#region Class: LeadRegisterMethodSchema

	/// <exclude/>
	public class LeadRegisterMethodSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadRegisterMethodSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadRegisterMethodSchema(LeadRegisterMethodSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadRegisterMethodSchema(LeadRegisterMethodSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e1ccd88-7f69-456e-af1a-915ffacb033d");
			RealUId = new Guid("5e1ccd88-7f69-456e-af1a-915ffacb033d");
			Name = "LeadRegisterMethod";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2f566863-6a05-41ae-bb68-b647818b8f61");
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
			return new LeadRegisterMethod(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadRegisterMethod_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadRegisterMethodSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadRegisterMethodSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e1ccd88-7f69-456e-af1a-915ffacb033d"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadRegisterMethod

	/// <summary>
	/// Способ регистрации лида.
	/// </summary>
	public class LeadRegisterMethod : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadRegisterMethod(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadRegisterMethod";
		}

		public LeadRegisterMethod(LeadRegisterMethod source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadRegisterMethod_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadRegisterMethodDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadRegisterMethodValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadRegisterMethod(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadRegisterMethod_LeadEventsProcess

	/// <exclude/>
	public partial class LeadRegisterMethod_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadRegisterMethod
	{

		public LeadRegisterMethod_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadRegisterMethod_LeadEventsProcess";
			SchemaUId = new Guid("5e1ccd88-7f69-456e-af1a-915ffacb033d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5e1ccd88-7f69-456e-af1a-915ffacb033d");
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

	#region Class: LeadRegisterMethod_LeadEventsProcess

	/// <exclude/>
	public class LeadRegisterMethod_LeadEventsProcess : LeadRegisterMethod_LeadEventsProcess<LeadRegisterMethod>
	{

		public LeadRegisterMethod_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadRegisterMethod_LeadEventsProcess

	public partial class LeadRegisterMethod_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadRegisterMethodEventsProcess

	/// <exclude/>
	public class LeadRegisterMethodEventsProcess : LeadRegisterMethod_LeadEventsProcess
	{

		public LeadRegisterMethodEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

