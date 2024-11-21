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

	#region Class: ExternalAccessInFolderSchema

	/// <exclude/>
	public class ExternalAccessInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ExternalAccessInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExternalAccessInFolderSchema(ExternalAccessInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExternalAccessInFolderSchema(ExternalAccessInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			RealUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			Name = "ExternalAccessInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("386ac9f6-07c1-4d11-8d16-e4e9424ba4e8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ba93a69c-25ad-4087-ad7d-de212af40ed7")) == null) {
				Columns.Add(CreateExternalAccessColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("70eabe3c-3b27-4aa4-a5fc-e4378abeb01f");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateExternalAccessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ba93a69c-25ad-4087-ad7d-de212af40ed7"),
				Name = @"ExternalAccess",
				ReferenceSchemaUId = new Guid("f3858e46-ea38-412e-af4a-2011f08718ae"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e"),
				ModifiedInSchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e"),
				CreatedInPackageId = new Guid("386ac9f6-07c1-4d11-8d16-e4e9424ba4e8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ExternalAccessInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExternalAccessInFolder_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExternalAccessInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExternalAccessInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("712961b3-fecf-46bb-a564-6081c867e92e"));
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessInFolder

	/// <summary>
	/// External access in Folder.
	/// </summary>
	public class ExternalAccessInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ExternalAccessInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessInFolder";
		}

		public ExternalAccessInFolder(ExternalAccessInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ExternalAccessId {
			get {
				return GetTypedColumnValue<Guid>("ExternalAccessId");
			}
			set {
				SetColumnValue("ExternalAccessId", value);
				_externalAccess = null;
			}
		}

		/// <exclude/>
		public string ExternalAccessAccessReason {
			get {
				return GetTypedColumnValue<string>("ExternalAccessAccessReason");
			}
			set {
				SetColumnValue("ExternalAccessAccessReason", value);
				if (_externalAccess != null) {
					_externalAccess.AccessReason = value;
				}
			}
		}

		private ExternalAccess _externalAccess;
		/// <summary>
		/// External access.
		/// </summary>
		public ExternalAccess ExternalAccess {
			get {
				return _externalAccess ??
					(_externalAccess = LookupColumnEntities.GetEntity("ExternalAccess") as ExternalAccess);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ExternalAccessInFolder_ExternalAccessEventsProcess(UserConnection);
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
			return new ExternalAccessInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessInFolder_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class ExternalAccessInFolder_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ExternalAccessInFolder
	{

		public ExternalAccessInFolder_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExternalAccessInFolder_ExternalAccessEventsProcess";
			SchemaUId = new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("712961b3-fecf-46bb-a564-6081c867e92e");
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

	#region Class: ExternalAccessInFolder_ExternalAccessEventsProcess

	/// <exclude/>
	public class ExternalAccessInFolder_ExternalAccessEventsProcess : ExternalAccessInFolder_ExternalAccessEventsProcess<ExternalAccessInFolder>
	{

		public ExternalAccessInFolder_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExternalAccessInFolder_ExternalAccessEventsProcess

	public partial class ExternalAccessInFolder_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExternalAccessInFolderEventsProcess

	/// <exclude/>
	public class ExternalAccessInFolderEventsProcess : ExternalAccessInFolder_ExternalAccessEventsProcess
	{

		public ExternalAccessInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

