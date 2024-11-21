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

	#region Class: ContactFileSchema

	/// <exclude/>
	public class ContactFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public ContactFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactFileSchema(ContactFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactFileSchema(ContactFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
			RealUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
			Name = "ContactFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f442867d-73ca-49b3-a8ba-8a2566b1fc59")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f442867d-73ca-49b3-a8ba-8a2566b1fc59"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4"),
				ModifiedInSchemaUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactFile

	/// <summary>
	/// Contact attachment.
	/// </summary>
	public class ContactFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public ContactFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactFile";
		}

		public ContactFile(ContactFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("ContactFileInserting", e);
			Updated += (s, e) => ThrowEvent("ContactFileUpdated", e);
			Validating += (s, e) => ThrowEvent("ContactFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactFile_BaseEventsProcess

	/// <exclude/>
	public partial class ContactFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : ContactFile
	{

		public ContactFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactFile_BaseEventsProcess";
			SchemaUId = new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e9eafee9-c4e4-4793-ad0a-003bd2c6a9b4");
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

	#region Class: ContactFile_BaseEventsProcess

	/// <exclude/>
	public class ContactFile_BaseEventsProcess : ContactFile_BaseEventsProcess<ContactFile>
	{

		public ContactFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactFile_BaseEventsProcess

	public partial class ContactFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactFileEventsProcess

	/// <exclude/>
	public class ContactFileEventsProcess : ContactFile_BaseEventsProcess
	{

		public ContactFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

