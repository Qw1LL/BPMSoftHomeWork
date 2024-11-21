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

	#region Class: DaDataAccountTypeSchema

	/// <exclude/>
	public class DaDataAccountTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public DaDataAccountTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DaDataAccountTypeSchema(DaDataAccountTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaDataAccountTypeSchema(DaDataAccountTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa6cd5ce-7e10-4f08-8405-2ff653f1ecf8");
			RealUId = new Guid("fa6cd5ce-7e10-4f08-8405-2ff653f1ecf8");
			Name = "DaDataAccountType";
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
			return new DaDataAccountType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DaDataAccountType_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DaDataAccountTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DaDataAccountTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa6cd5ce-7e10-4f08-8405-2ff653f1ecf8"));
		}

		#endregion

	}

	#endregion

	#region Class: DaDataAccountType

	/// <summary>
	/// Тип организации (DaData).
	/// </summary>
	public class DaDataAccountType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public DaDataAccountType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataAccountType";
		}

		public DaDataAccountType(DaDataAccountType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DaDataAccountType_DaDataSuggestionsEventsProcess(UserConnection);
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
			return new DaDataAccountType(this);
		}

		#endregion

	}

	#endregion

	#region Class: DaDataAccountType_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class DaDataAccountType_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : DaDataAccountType
	{

		public DaDataAccountType_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DaDataAccountType_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("fa6cd5ce-7e10-4f08-8405-2ff653f1ecf8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fa6cd5ce-7e10-4f08-8405-2ff653f1ecf8");
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

	#region Class: DaDataAccountType_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class DaDataAccountType_DaDataSuggestionsEventsProcess : DaDataAccountType_DaDataSuggestionsEventsProcess<DaDataAccountType>
	{

		public DaDataAccountType_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DaDataAccountType_DaDataSuggestionsEventsProcess

	public partial class DaDataAccountType_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DaDataAccountTypeEventsProcess

	/// <exclude/>
	public class DaDataAccountTypeEventsProcess : DaDataAccountType_DaDataSuggestionsEventsProcess
	{

		public DaDataAccountTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

