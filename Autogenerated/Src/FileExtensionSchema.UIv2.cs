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

	#region Class: FileExtensionSchema

	/// <exclude/>
	public class FileExtensionSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public FileExtensionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileExtensionSchema(FileExtensionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileExtensionSchema(FileExtensionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			RealUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			Name = "FileExtension";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bfd868fd-dabd-469b-8c9b-d7b1e81cdf24")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("0e83b942-0bff-4334-bb22-dc4dd2099f0d")) == null) {
				Columns.Add(CreateFileNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			column.CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("bfd868fd-dabd-469b-8c9b-d7b1e81cdf24"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf"),
				ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf"),
				CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40")
			};
		}

		protected virtual EntitySchemaColumn CreateFileNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0e83b942-0bff-4334-bb22-dc4dd2099f0d"),
				Name = @"FileName",
				CreatedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf"),
				ModifiedInSchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf"),
				CreatedInPackageId = new Guid("605bfcc9-12b3-4d76-9818-dcfc2bec6a40")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FileExtension(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileExtension_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileExtensionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileExtensionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf"));
		}

		#endregion

	}

	#endregion

	#region Class: FileExtension

	/// <summary>
	/// File resolution.
	/// </summary>
	public class FileExtension : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public FileExtension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileExtension";
		}

		public FileExtension(FileExtension source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// File name.
		/// </summary>
		public string FileName {
			get {
				return GetTypedColumnValue<string>("FileName");
			}
			set {
				SetColumnValue("FileName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileExtension_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FileExtensionDeleted", e);
			Inserting += (s, e) => ThrowEvent("FileExtensionInserting", e);
			Validating += (s, e) => ThrowEvent("FileExtensionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FileExtension(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileExtension_UIv2EventsProcess

	/// <exclude/>
	public partial class FileExtension_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : FileExtension
	{

		public FileExtension_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileExtension_UIv2EventsProcess";
			SchemaUId = new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f38efa52-ca4b-4d43-bae4-0f52fda57daf");
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

	#region Class: FileExtension_UIv2EventsProcess

	/// <exclude/>
	public class FileExtension_UIv2EventsProcess : FileExtension_UIv2EventsProcess<FileExtension>
	{

		public FileExtension_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileExtension_UIv2EventsProcess

	public partial class FileExtension_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileExtensionEventsProcess

	/// <exclude/>
	public class FileExtensionEventsProcess : FileExtension_UIv2EventsProcess
	{

		public FileExtensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

