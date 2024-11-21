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

	#region Class: FileInFolderSchema

	/// <exclude/>
	public class FileInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public FileInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileInFolderSchema(FileInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileInFolderSchema(FileInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("32da2595-08cf-4aec-9a98-399a798e3db2");
			RealUId = new Guid("32da2595-08cf-4aec-9a98-399a798e3db2");
			Name = "FileInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("69c23357-0b7f-4e11-a6a8-41bd731bfb50")) == null) {
				Columns.Add(CreateFileColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("f1111d8f-0745-4b7f-8f23-f5631a25888b");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("32da2595-08cf-4aec-9a98-399a798e3db2");
			return column;
		}

		protected virtual EntitySchemaColumn CreateFileColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("69c23357-0b7f-4e11-a6a8-41bd731bfb50"),
				Name = @"File",
				ReferenceSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("32da2595-08cf-4aec-9a98-399a798e3db2"),
				ModifiedInSchemaUId = new Guid("32da2595-08cf-4aec-9a98-399a798e3db2"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FileInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("32da2595-08cf-4aec-9a98-399a798e3db2"));
		}

		#endregion

	}

	#endregion

	#region Class: FileInFolder

	/// <summary>
	/// File in folder.
	/// </summary>
	public class FileInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public FileInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileInFolder";
		}

		public FileInFolder(FileInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid FileId {
			get {
				return GetTypedColumnValue<Guid>("FileId");
			}
			set {
				SetColumnValue("FileId", value);
				_file = null;
			}
		}

		/// <exclude/>
		public string FileName {
			get {
				return GetTypedColumnValue<string>("FileName");
			}
			set {
				SetColumnValue("FileName", value);
				if (_file != null) {
					_file.Name = value;
				}
			}
		}

		private File _file;
		/// <summary>
		/// File.
		/// </summary>
		public File File {
			get {
				return _file ??
					(_file = LookupColumnEntities.GetEntity("File") as File);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FileInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("FileInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("FileInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("FileInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("FileInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("FileInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("FileInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FileInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class FileInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : FileInFolder
	{

		public FileInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileInFolder_BaseEventsProcess";
			SchemaUId = new Guid("32da2595-08cf-4aec-9a98-399a798e3db2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("32da2595-08cf-4aec-9a98-399a798e3db2");
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

	#region Class: FileInFolder_BaseEventsProcess

	/// <exclude/>
	public class FileInFolder_BaseEventsProcess : FileInFolder_BaseEventsProcess<FileInFolder>
	{

		public FileInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileInFolder_BaseEventsProcess

	public partial class FileInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileInFolderEventsProcess

	/// <exclude/>
	public class FileInFolderEventsProcess : FileInFolder_BaseEventsProcess
	{

		public FileInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

