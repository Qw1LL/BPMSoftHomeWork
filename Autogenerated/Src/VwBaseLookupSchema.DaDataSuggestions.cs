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

	#region Class: VwBaseLookupSchema

	/// <exclude/>
	public class VwBaseLookupSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwBaseLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwBaseLookupSchema(VwBaseLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwBaseLookupSchema(VwBaseLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c1fd6c93-1d53-4773-95b1-47950b920173");
			RealUId = new Guid("c1fd6c93-1d53-4773-95b1-47950b920173");
			Name = "VwBaseLookup";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("c1fd6c93-1d53-4773-95b1-47950b920173");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("c1fd6c93-1d53-4773-95b1-47950b920173");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwBaseLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwBaseLookup_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwBaseLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwBaseLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c1fd6c93-1d53-4773-95b1-47950b920173"));
		}

		#endregion

	}

	#endregion

	#region Class: VwBaseLookup

	/// <summary>
	/// Базовый справочник (представление).
	/// </summary>
	public class VwBaseLookup : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwBaseLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwBaseLookup";
		}

		public VwBaseLookup(VwBaseLookup source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwBaseLookup_DaDataSuggestionsEventsProcess(UserConnection);
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
			return new VwBaseLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwBaseLookup_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class VwBaseLookup_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VwBaseLookup
	{

		public VwBaseLookup_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwBaseLookup_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("c1fd6c93-1d53-4773-95b1-47950b920173");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c1fd6c93-1d53-4773-95b1-47950b920173");
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

	#region Class: VwBaseLookup_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class VwBaseLookup_DaDataSuggestionsEventsProcess : VwBaseLookup_DaDataSuggestionsEventsProcess<VwBaseLookup>
	{

		public VwBaseLookup_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwBaseLookup_DaDataSuggestionsEventsProcess

	public partial class VwBaseLookup_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwBaseLookupEventsProcess

	/// <exclude/>
	public class VwBaseLookupEventsProcess : VwBaseLookup_DaDataSuggestionsEventsProcess
	{

		public VwBaseLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

