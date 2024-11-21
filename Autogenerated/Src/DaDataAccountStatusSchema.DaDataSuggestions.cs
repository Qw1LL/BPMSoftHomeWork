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

	#region Class: DaDataAccountStatusSchema

	/// <exclude/>
	public class DaDataAccountStatusSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public DaDataAccountStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DaDataAccountStatusSchema(DaDataAccountStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaDataAccountStatusSchema(DaDataAccountStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6e21e39b-f8af-4def-bfb6-4000fcfdc837");
			RealUId = new Guid("6e21e39b-f8af-4def-bfb6-4000fcfdc837");
			Name = "DaDataAccountStatus";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0abb8b26-e64d-48d6-983e-7f98a4c95f9f");
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
			return new DaDataAccountStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DaDataAccountStatus_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DaDataAccountStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DaDataAccountStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6e21e39b-f8af-4def-bfb6-4000fcfdc837"));
		}

		#endregion

	}

	#endregion

	#region Class: DaDataAccountStatus

	/// <summary>
	/// Статус организации (DaData).
	/// </summary>
	public class DaDataAccountStatus : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public DaDataAccountStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataAccountStatus";
		}

		public DaDataAccountStatus(DaDataAccountStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DaDataAccountStatus_DaDataSuggestionsEventsProcess(UserConnection);
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
			return new DaDataAccountStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: DaDataAccountStatus_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class DaDataAccountStatus_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : DaDataAccountStatus
	{

		public DaDataAccountStatus_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DaDataAccountStatus_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("6e21e39b-f8af-4def-bfb6-4000fcfdc837");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6e21e39b-f8af-4def-bfb6-4000fcfdc837");
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

	#region Class: DaDataAccountStatus_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class DaDataAccountStatus_DaDataSuggestionsEventsProcess : DaDataAccountStatus_DaDataSuggestionsEventsProcess<DaDataAccountStatus>
	{

		public DaDataAccountStatus_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DaDataAccountStatus_DaDataSuggestionsEventsProcess

	public partial class DaDataAccountStatus_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DaDataAccountStatusEventsProcess

	/// <exclude/>
	public class DaDataAccountStatusEventsProcess : DaDataAccountStatus_DaDataSuggestionsEventsProcess
	{

		public DaDataAccountStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

