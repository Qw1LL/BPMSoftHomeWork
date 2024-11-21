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

	#region Class: DaDataBranchTypeSchema

	/// <exclude/>
	public class DaDataBranchTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public DaDataBranchTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DaDataBranchTypeSchema(DaDataBranchTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaDataBranchTypeSchema(DaDataBranchTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b7b2ec98-cb97-4d53-9bf8-3c1bb0a03270");
			RealUId = new Guid("b7b2ec98-cb97-4d53-9bf8-3c1bb0a03270");
			Name = "DaDataBranchType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e3b59104-673b-45e6-b0f8-6c6cb2eb2c0c");
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
			return new DaDataBranchType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DaDataBranchType_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DaDataBranchTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DaDataBranchTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b7b2ec98-cb97-4d53-9bf8-3c1bb0a03270"));
		}

		#endregion

	}

	#endregion

	#region Class: DaDataBranchType

	/// <summary>
	/// Тип подразделения (DaData).
	/// </summary>
	public class DaDataBranchType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public DaDataBranchType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataBranchType";
		}

		public DaDataBranchType(DaDataBranchType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DaDataBranchType_DaDataSuggestionsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("DaDataBranchTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("DaDataBranchTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("DaDataBranchTypeInserting", e);
			Saved += (s, e) => ThrowEvent("DaDataBranchTypeSaved", e);
			Saving += (s, e) => ThrowEvent("DaDataBranchTypeSaving", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DaDataBranchType(this);
		}

		#endregion

	}

	#endregion

	#region Class: DaDataBranchType_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class DaDataBranchType_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : DaDataBranchType
	{

		public DaDataBranchType_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DaDataBranchType_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("b7b2ec98-cb97-4d53-9bf8-3c1bb0a03270");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b7b2ec98-cb97-4d53-9bf8-3c1bb0a03270");
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

	#region Class: DaDataBranchType_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class DaDataBranchType_DaDataSuggestionsEventsProcess : DaDataBranchType_DaDataSuggestionsEventsProcess<DaDataBranchType>
	{

		public DaDataBranchType_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DaDataBranchType_DaDataSuggestionsEventsProcess

	public partial class DaDataBranchType_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DaDataBranchTypeEventsProcess

	/// <exclude/>
	public class DaDataBranchTypeEventsProcess : DaDataBranchType_DaDataSuggestionsEventsProcess
	{

		public DaDataBranchTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

