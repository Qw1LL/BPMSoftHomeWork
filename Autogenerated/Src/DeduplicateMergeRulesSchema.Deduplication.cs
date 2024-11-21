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

	#region Class: DeduplicateMergeRulesSchema

	/// <exclude/>
	public class DeduplicateMergeRulesSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DeduplicateMergeRulesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DeduplicateMergeRulesSchema(DeduplicateMergeRulesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DeduplicateMergeRulesSchema(DeduplicateMergeRulesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873");
			RealUId = new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873");
			Name = "DeduplicateMergeRules";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2bccf296-28ac-4fb9-9305-bd0b56b97b98");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("dd137541-a236-4bd6-bc22-c957d93324f8")) == null) {
				Columns.Add(CreateSQLTextColumn());
			}
			if (Columns.FindByUId(new Guid("33f8e5da-0e0f-4c79-a83e-616c74cd469c")) == null) {
				Columns.Add(CreateAdditionalMergeConfigColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSQLTextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("dd137541-a236-4bd6-bc22-c957d93324f8"),
				Name = @"SQLText",
				CreatedInSchemaUId = new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873"),
				ModifiedInSchemaUId = new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873"),
				CreatedInPackageId = new Guid("2bccf296-28ac-4fb9-9305-bd0b56b97b98")
			};
		}

		protected virtual EntitySchemaColumn CreateAdditionalMergeConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("33f8e5da-0e0f-4c79-a83e-616c74cd469c"),
				Name = @"AdditionalMergeConfig",
				CreatedInSchemaUId = new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873"),
				ModifiedInSchemaUId = new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873"),
				CreatedInPackageId = new Guid("ca0e9b58-391f-43cb-96ab-6943b000d1f4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DeduplicateMergeRules(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DeduplicateMergeRules_DeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DeduplicateMergeRulesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DeduplicateMergeRulesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873"));
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateMergeRules

	/// <summary>
	/// Deduplicate merge rules.
	/// </summary>
	public class DeduplicateMergeRules : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DeduplicateMergeRules(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeduplicateMergeRules";
		}

		public DeduplicateMergeRules(DeduplicateMergeRules source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// SQL Text.
		/// </summary>
		public string SQLText {
			get {
				return GetTypedColumnValue<string>("SQLText");
			}
			set {
				SetColumnValue("SQLText", value);
			}
		}

		/// <summary>
		/// AdditionalMergeConfig.
		/// </summary>
		public string AdditionalMergeConfig {
			get {
				return GetTypedColumnValue<string>("AdditionalMergeConfig");
			}
			set {
				SetColumnValue("AdditionalMergeConfig", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DeduplicateMergeRules_DeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DeduplicateMergeRulesDeleted", e);
			Validating += (s, e) => ThrowEvent("DeduplicateMergeRulesValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DeduplicateMergeRules(this);
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateMergeRules_DeduplicationEventsProcess

	/// <exclude/>
	public partial class DeduplicateMergeRules_DeduplicationEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : DeduplicateMergeRules
	{

		public DeduplicateMergeRules_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeduplicateMergeRules_DeduplicationEventsProcess";
			SchemaUId = new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4cd81be3-384c-4ea4-abcf-50132df3a873");
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

	#region Class: DeduplicateMergeRules_DeduplicationEventsProcess

	/// <exclude/>
	public class DeduplicateMergeRules_DeduplicationEventsProcess : DeduplicateMergeRules_DeduplicationEventsProcess<DeduplicateMergeRules>
	{

		public DeduplicateMergeRules_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DeduplicateMergeRules_DeduplicationEventsProcess

	public partial class DeduplicateMergeRules_DeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DeduplicateMergeRulesEventsProcess

	/// <exclude/>
	public class DeduplicateMergeRulesEventsProcess : DeduplicateMergeRules_DeduplicationEventsProcess
	{

		public DeduplicateMergeRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

