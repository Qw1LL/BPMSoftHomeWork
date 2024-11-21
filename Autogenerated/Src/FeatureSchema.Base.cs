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

	#region Class: FeatureSchema

	/// <exclude/>
	public class FeatureSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public FeatureSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FeatureSchema(FeatureSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FeatureSchema(FeatureSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			RealUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			Name = "Feature";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Feature(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Feature_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FeatureSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FeatureSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f"));
		}

		#endregion

	}

	#endregion

	#region Class: Feature

	/// <summary>
	/// Новая функциональность.
	/// </summary>
	public class Feature : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public Feature(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Feature";
		}

		public Feature(Feature source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Feature_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FeatureDeleted", e);
			Validating += (s, e) => ThrowEvent("FeatureValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Feature(this);
		}

		#endregion

	}

	#endregion

	#region Class: Feature_BaseEventsProcess

	/// <exclude/>
	public partial class Feature_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : Feature
	{

		public Feature_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Feature_BaseEventsProcess";
			SchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
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

	#region Class: Feature_BaseEventsProcess

	/// <exclude/>
	public class Feature_BaseEventsProcess : Feature_BaseEventsProcess<Feature>
	{

		public Feature_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Feature_BaseEventsProcess

	public partial class Feature_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FeatureEventsProcess

	/// <exclude/>
	public class FeatureEventsProcess : Feature_BaseEventsProcess
	{

		public FeatureEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

