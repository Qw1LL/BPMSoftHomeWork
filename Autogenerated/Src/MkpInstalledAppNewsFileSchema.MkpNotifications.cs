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

	#region Class: MkpInstalledAppNewsFileSchema

	/// <exclude/>
	public class MkpInstalledAppNewsFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public MkpInstalledAppNewsFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MkpInstalledAppNewsFileSchema(MkpInstalledAppNewsFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MkpInstalledAppNewsFileSchema(MkpInstalledAppNewsFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			RealUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			Name = "MkpInstalledAppNewsFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42204ac4-9e89-423e-9f95-836c2df050a9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ef6b190c-a09f-41ce-8eb4-09de60e05405")) == null) {
				Columns.Add(CreateMkpInstalledAppNewsColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMkpInstalledAppNewsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ef6b190c-a09f-41ce-8eb4-09de60e05405"),
				Name = @"MkpInstalledAppNews",
				ReferenceSchemaUId = new Guid("0c92974f-4dbe-4990-968e-3d1fa1719a53"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d"),
				ModifiedInSchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d"),
				CreatedInPackageId = new Guid("42204ac4-9e89-423e-9f95-836c2df050a9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MkpInstalledAppNewsFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MkpInstalledAppNewsFile_MkpNotificationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MkpInstalledAppNewsFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MkpInstalledAppNewsFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("09369470-a73c-4fa7-b2f2-112820428f7d"));
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsFile

	/// <summary>
	/// File and link of installed app news.
	/// </summary>
	public class MkpInstalledAppNewsFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public MkpInstalledAppNewsFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MkpInstalledAppNewsFile";
		}

		public MkpInstalledAppNewsFile(MkpInstalledAppNewsFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MkpInstalledAppNewsId {
			get {
				return GetTypedColumnValue<Guid>("MkpInstalledAppNewsId");
			}
			set {
				SetColumnValue("MkpInstalledAppNewsId", value);
				_mkpInstalledAppNews = null;
			}
		}

		private MkpInstalledAppNews _mkpInstalledAppNews;
		/// <summary>
		/// Installed app news.
		/// </summary>
		public MkpInstalledAppNews MkpInstalledAppNews {
			get {
				return _mkpInstalledAppNews ??
					(_mkpInstalledAppNews = LookupColumnEntities.GetEntity("MkpInstalledAppNews") as MkpInstalledAppNews);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MkpInstalledAppNewsFile_MkpNotificationsEventsProcess(UserConnection);
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
			return new MkpInstalledAppNewsFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsFile_MkpNotificationsEventsProcess

	/// <exclude/>
	public partial class MkpInstalledAppNewsFile_MkpNotificationsEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : MkpInstalledAppNewsFile
	{

		public MkpInstalledAppNewsFile_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MkpInstalledAppNewsFile_MkpNotificationsEventsProcess";
			SchemaUId = new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("09369470-a73c-4fa7-b2f2-112820428f7d");
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

	#region Class: MkpInstalledAppNewsFile_MkpNotificationsEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsFile_MkpNotificationsEventsProcess : MkpInstalledAppNewsFile_MkpNotificationsEventsProcess<MkpInstalledAppNewsFile>
	{

		public MkpInstalledAppNewsFile_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MkpInstalledAppNewsFile_MkpNotificationsEventsProcess

	public partial class MkpInstalledAppNewsFile_MkpNotificationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MkpInstalledAppNewsFileEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsFileEventsProcess : MkpInstalledAppNewsFile_MkpNotificationsEventsProcess
	{

		public MkpInstalledAppNewsFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

