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

	#region Class: DaDataSuggestionsTypeSchema

	/// <exclude/>
	public class DaDataSuggestionsTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DaDataSuggestionsTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DaDataSuggestionsTypeSchema(DaDataSuggestionsTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaDataSuggestionsTypeSchema(DaDataSuggestionsTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f2d46613-3181-46dd-bacf-c10ef438c6b7");
			RealUId = new Guid("f2d46613-3181-46dd-bacf-c10ef438c6b7");
			Name = "DaDataSuggestionsType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72");
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
			return new DaDataSuggestionsType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DaDataSuggestionsType_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DaDataSuggestionsTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DaDataSuggestionsTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f2d46613-3181-46dd-bacf-c10ef438c6b7"));
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsType

	/// <summary>
	/// Тип подсказок DaData.
	/// </summary>
	public class DaDataSuggestionsType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DaDataSuggestionsType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataSuggestionsType";
		}

		public DaDataSuggestionsType(DaDataSuggestionsType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DaDataSuggestionsType_DaDataSuggestionsEventsProcess(UserConnection);
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
			return new DaDataSuggestionsType(this);
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsType_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class DaDataSuggestionsType_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : DaDataSuggestionsType
	{

		public DaDataSuggestionsType_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DaDataSuggestionsType_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("f2d46613-3181-46dd-bacf-c10ef438c6b7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f2d46613-3181-46dd-bacf-c10ef438c6b7");
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

	#region Class: DaDataSuggestionsType_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsType_DaDataSuggestionsEventsProcess : DaDataSuggestionsType_DaDataSuggestionsEventsProcess<DaDataSuggestionsType>
	{

		public DaDataSuggestionsType_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DaDataSuggestionsType_DaDataSuggestionsEventsProcess

	public partial class DaDataSuggestionsType_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DaDataSuggestionsTypeEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsTypeEventsProcess : DaDataSuggestionsType_DaDataSuggestionsEventsProcess
	{

		public DaDataSuggestionsTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

