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

	#region Class: SysTranslationInFolderSchema

	/// <exclude/>
	public class SysTranslationInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public SysTranslationInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTranslationInFolderSchema(SysTranslationInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTranslationInFolderSchema(SysTranslationInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c");
			RealUId = new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c");
			Name = "SysTranslationInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9a2dd422-afdd-47c6-b4b8-0841efbfcb9a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0a305d12-731a-48d0-8e02-f20e8bc5df62")) == null) {
				Columns.Add(CreateSysTranslationColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("d42038d3-367c-4023-80c1-d4305157b5ae");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysTranslationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0a305d12-731a-48d0-8e02-f20e8bc5df62"),
				Name = @"SysTranslation",
				ReferenceSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c"),
				ModifiedInSchemaUId = new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c"),
				CreatedInPackageId = new Guid("9a2dd422-afdd-47c6-b4b8-0841efbfcb9a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTranslationInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTranslationInFolder_TranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTranslationInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTranslationInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationInFolder

	/// <summary>
	/// SysTranslation in folder.
	/// </summary>
	public class SysTranslationInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public SysTranslationInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTranslationInFolder";
		}

		public SysTranslationInFolder(SysTranslationInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysTranslationId {
			get {
				return GetTypedColumnValue<Guid>("SysTranslationId");
			}
			set {
				SetColumnValue("SysTranslationId", value);
				_sysTranslation = null;
			}
		}

		/// <exclude/>
		public string SysTranslationKey {
			get {
				return GetTypedColumnValue<string>("SysTranslationKey");
			}
			set {
				SetColumnValue("SysTranslationKey", value);
				if (_sysTranslation != null) {
					_sysTranslation.Key = value;
				}
			}
		}

		private SysTranslation _sysTranslation;
		/// <summary>
		/// SysTranslation.
		/// </summary>
		public SysTranslation SysTranslation {
			get {
				return _sysTranslation ??
					(_sysTranslation = LookupColumnEntities.GetEntity("SysTranslation") as SysTranslation);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTranslationInFolder_TranslationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysTranslationInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("SysTranslationInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysTranslationInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationInFolder_TranslationEventsProcess

	/// <exclude/>
	public partial class SysTranslationInFolder_TranslationEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : SysTranslationInFolder
	{

		public SysTranslationInFolder_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTranslationInFolder_TranslationEventsProcess";
			SchemaUId = new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("385aba31-8acb-47c6-8c84-b172abce5a8c");
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

	#region Class: SysTranslationInFolder_TranslationEventsProcess

	/// <exclude/>
	public class SysTranslationInFolder_TranslationEventsProcess : SysTranslationInFolder_TranslationEventsProcess<SysTranslationInFolder>
	{

		public SysTranslationInFolder_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTranslationInFolder_TranslationEventsProcess

	public partial class SysTranslationInFolder_TranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysTranslationInFolderEventsProcess

	/// <exclude/>
	public class SysTranslationInFolderEventsProcess : SysTranslationInFolder_TranslationEventsProcess
	{

		public SysTranslationInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

