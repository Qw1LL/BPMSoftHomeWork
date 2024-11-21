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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: WSColourOfFieldTagSchema

	/// <exclude/>
	public class WSColourOfFieldTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public WSColourOfFieldTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSColourOfFieldTagSchema(WSColourOfFieldTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSColourOfFieldTagSchema(WSColourOfFieldTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			RealUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			Name = "WSColourOfFieldTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"8d7f6d6c-4ca5-4b43-bdd9-a5e01a582260"
			};
			column.ModifiedInSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSColourOfFieldTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSColourOfFieldTag_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSColourOfFieldTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSColourOfFieldTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f"));
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldTag

	/// <summary>
	/// Тег раздела Правила цветового выделения.
	/// </summary>
	public class WSColourOfFieldTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public WSColourOfFieldTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSColourOfFieldTag";
		}

		public WSColourOfFieldTag(WSColourOfFieldTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSColourOfFieldTag_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSColourOfFieldTagDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSColourOfFieldTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldTag_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSColourOfFieldTag_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : WSColourOfFieldTag
	{

		public WSColourOfFieldTag_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSColourOfFieldTag_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
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

	#region Class: WSColourOfFieldTag_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSColourOfFieldTag_WSFieldsmanagementEventsProcess : WSColourOfFieldTag_WSFieldsmanagementEventsProcess<WSColourOfFieldTag>
	{

		public WSColourOfFieldTag_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSColourOfFieldTag_WSFieldsmanagementEventsProcess

	public partial class WSColourOfFieldTag_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSColourOfFieldTagEventsProcess

	/// <exclude/>
	public class WSColourOfFieldTagEventsProcess : WSColourOfFieldTag_WSFieldsmanagementEventsProcess
	{

		public WSColourOfFieldTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

