namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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
	using System.Linq;

	#region Class: ExternalAccessFileSchema

	/// <exclude/>
	public class ExternalAccessFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public ExternalAccessFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExternalAccessFileSchema(ExternalAccessFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExternalAccessFileSchema(ExternalAccessFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			RealUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			Name = "ExternalAccessFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("386ac9f6-07c1-4d11-8d16-e4e9424ba4e8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9517149f-8ff3-4f74-8e21-fc232694ee4f")) == null) {
				Columns.Add(CreateExternalAccessColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			return column;
		}

		protected virtual EntitySchemaColumn CreateExternalAccessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9517149f-8ff3-4f74-8e21-fc232694ee4f"),
				Name = @"ExternalAccess",
				ReferenceSchemaUId = new Guid("f3858e46-ea38-412e-af4a-2011f08718ae"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85"),
				ModifiedInSchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85"),
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
			return new ExternalAccessFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExternalAccessFile_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExternalAccessFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExternalAccessFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85"));
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessFile

	/// <summary>
	/// External access attachment.
	/// </summary>
	public class ExternalAccessFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public ExternalAccessFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessFile";
		}

		public ExternalAccessFile(ExternalAccessFile source)
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
			var process = new ExternalAccessFile_ExternalAccessEventsProcess(UserConnection);
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
			return new ExternalAccessFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessFile_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class ExternalAccessFile_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : ExternalAccessFile
	{

		public ExternalAccessFile_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExternalAccessFile_ExternalAccessEventsProcess";
			SchemaUId = new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b8e4b6ae-0200-4be2-823c-01ceee0e6b85");
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

	#region Class: ExternalAccessFile_ExternalAccessEventsProcess

	/// <exclude/>
	public class ExternalAccessFile_ExternalAccessEventsProcess : ExternalAccessFile_ExternalAccessEventsProcess<ExternalAccessFile>
	{

		public ExternalAccessFile_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExternalAccessFile_ExternalAccessEventsProcess

	public partial class ExternalAccessFile_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExternalAccessFileEventsProcess

	/// <exclude/>
	public class ExternalAccessFileEventsProcess : ExternalAccessFile_ExternalAccessEventsProcess
	{

		public ExternalAccessFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

