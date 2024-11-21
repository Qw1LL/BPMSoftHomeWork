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

	#region Class: WSColourOfFieldFileSchema

	/// <exclude/>
	public class WSColourOfFieldFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public WSColourOfFieldFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSColourOfFieldFileSchema(WSColourOfFieldFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSColourOfFieldFileSchema(WSColourOfFieldFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			RealUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			Name = "WSColourOfFieldFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("507f5a79-7f4b-47da-9353-76671a86aad4")) == null) {
				Columns.Add(CreateWSColourOfFieldColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWSColourOfFieldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("507f5a79-7f4b-47da-9353-76671a86aad4"),
				Name = @"WSColourOfField",
				ReferenceSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6"),
				ModifiedInSchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSColourOfFieldFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSColourOfFieldFile_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSColourOfFieldFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSColourOfFieldFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6"));
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldFile

	/// <summary>
	/// Файл и ссылка объекта Правила цветового выделения.
	/// </summary>
	public class WSColourOfFieldFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public WSColourOfFieldFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSColourOfFieldFile";
		}

		public WSColourOfFieldFile(WSColourOfFieldFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid WSColourOfFieldId {
			get {
				return GetTypedColumnValue<Guid>("WSColourOfFieldId");
			}
			set {
				SetColumnValue("WSColourOfFieldId", value);
				_wSColourOfField = null;
			}
		}

		/// <exclude/>
		public string WSColourOfFieldWSName {
			get {
				return GetTypedColumnValue<string>("WSColourOfFieldWSName");
			}
			set {
				SetColumnValue("WSColourOfFieldWSName", value);
				if (_wSColourOfField != null) {
					_wSColourOfField.WSName = value;
				}
			}
		}

		private WSColourOfField _wSColourOfField;
		/// <summary>
		/// Правила цветового выделения.
		/// </summary>
		public WSColourOfField WSColourOfField {
			get {
				return _wSColourOfField ??
					(_wSColourOfField = LookupColumnEntities.GetEntity("WSColourOfField") as WSColourOfField);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSColourOfFieldFile_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSColourOfFieldFileDeleted", e);
			Updated += (s, e) => ThrowEvent("WSColourOfFieldFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSColourOfFieldFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldFile_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSColourOfFieldFile_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : WSColourOfFieldFile
	{

		public WSColourOfFieldFile_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSColourOfFieldFile_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce6c7ba0-48e6-43e6-8663-c5dddbf297d6");
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

	#region Class: WSColourOfFieldFile_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSColourOfFieldFile_WSFieldsmanagementEventsProcess : WSColourOfFieldFile_WSFieldsmanagementEventsProcess<WSColourOfFieldFile>
	{

		public WSColourOfFieldFile_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSColourOfFieldFile_WSFieldsmanagementEventsProcess

	public partial class WSColourOfFieldFile_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSColourOfFieldFileEventsProcess

	/// <exclude/>
	public class WSColourOfFieldFileEventsProcess : WSColourOfFieldFile_WSFieldsmanagementEventsProcess
	{

		public WSColourOfFieldFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

