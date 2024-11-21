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

	#region Class: VwDuplicatesRuleTypeSchema

	/// <exclude/>
	public class VwDuplicatesRuleTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwDuplicatesRuleTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwDuplicatesRuleTypeSchema(VwDuplicatesRuleTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwDuplicatesRuleTypeSchema(VwDuplicatesRuleTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b");
			RealUId = new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b");
			Name = "VwDuplicatesRuleType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("891b85fe-ef15-418d-a66c-ac70369b4f0c");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5f5aed60-650a-4968-a232-64193df55289")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5f5aed60-650a-4968-a232-64193df55289"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b"),
				ModifiedInSchemaUId = new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b"),
				CreatedInPackageId = new Guid("891b85fe-ef15-418d-a66c-ac70369b4f0c")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a12a50e5-3690-47e5-947c-c5368c29b386"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b"),
				ModifiedInSchemaUId = new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b"),
				CreatedInPackageId = new Guid("891b85fe-ef15-418d-a66c-ac70369b4f0c"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwDuplicatesRuleType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwDuplicatesRuleType_DeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwDuplicatesRuleTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwDuplicatesRuleTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b"));
		}

		#endregion

	}

	#endregion

	#region Class: VwDuplicatesRuleType

	/// <summary>
	/// Duplicates rule type.
	/// </summary>
	public class VwDuplicatesRuleType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwDuplicatesRuleType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwDuplicatesRuleType";
		}

		public VwDuplicatesRuleType(VwDuplicatesRuleType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwDuplicatesRuleType_DeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwDuplicatesRuleTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("VwDuplicatesRuleTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwDuplicatesRuleType(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwDuplicatesRuleType_DeduplicationEventsProcess

	/// <exclude/>
	public partial class VwDuplicatesRuleType_DeduplicationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwDuplicatesRuleType
	{

		public VwDuplicatesRuleType_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwDuplicatesRuleType_DeduplicationEventsProcess";
			SchemaUId = new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7b529ef9-ace8-4808-a567-8cd121bedf9b");
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

	#region Class: VwDuplicatesRuleType_DeduplicationEventsProcess

	/// <exclude/>
	public class VwDuplicatesRuleType_DeduplicationEventsProcess : VwDuplicatesRuleType_DeduplicationEventsProcess<VwDuplicatesRuleType>
	{

		public VwDuplicatesRuleType_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwDuplicatesRuleType_DeduplicationEventsProcess

	public partial class VwDuplicatesRuleType_DeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwDuplicatesRuleTypeEventsProcess

	/// <exclude/>
	public class VwDuplicatesRuleTypeEventsProcess : VwDuplicatesRuleType_DeduplicationEventsProcess
	{

		public VwDuplicatesRuleTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

