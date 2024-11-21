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

	#region Class: SupplyPaymentTemplateSchema

	/// <exclude/>
	public class SupplyPaymentTemplateSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SupplyPaymentTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupplyPaymentTemplateSchema(SupplyPaymentTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupplyPaymentTemplateSchema(SupplyPaymentTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("69262e8a-b4fc-4a03-bab9-5720e19291ef");
			RealUId = new Guid("69262e8a-b4fc-4a03-bab9-5720e19291ef");
			Name = "SupplyPaymentTemplate";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("95c2c84b-bfbc-40cb-9e93-5fad29a6591d");
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
			return new SupplyPaymentTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupplyPaymentTemplate_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupplyPaymentTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupplyPaymentTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("69262e8a-b4fc-4a03-bab9-5720e19291ef"));
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentTemplate

	/// <summary>
	/// Шаблон графика поставок и оплат.
	/// </summary>
	public class SupplyPaymentTemplate : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SupplyPaymentTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPaymentTemplate";
		}

		public SupplyPaymentTemplate(SupplyPaymentTemplate source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupplyPaymentTemplate_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SupplyPaymentTemplateDeleted", e);
			Validating += (s, e) => ThrowEvent("SupplyPaymentTemplateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SupplyPaymentTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentTemplate_PassportEventsProcess

	/// <exclude/>
	public partial class SupplyPaymentTemplate_PassportEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SupplyPaymentTemplate
	{

		public SupplyPaymentTemplate_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupplyPaymentTemplate_PassportEventsProcess";
			SchemaUId = new Guid("69262e8a-b4fc-4a03-bab9-5720e19291ef");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("69262e8a-b4fc-4a03-bab9-5720e19291ef");
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

	#region Class: SupplyPaymentTemplate_PassportEventsProcess

	/// <exclude/>
	public class SupplyPaymentTemplate_PassportEventsProcess : SupplyPaymentTemplate_PassportEventsProcess<SupplyPaymentTemplate>
	{

		public SupplyPaymentTemplate_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupplyPaymentTemplate_PassportEventsProcess

	public partial class SupplyPaymentTemplate_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SupplyPaymentTemplateEventsProcess

	/// <exclude/>
	public class SupplyPaymentTemplateEventsProcess : SupplyPaymentTemplate_PassportEventsProcess
	{

		public SupplyPaymentTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

