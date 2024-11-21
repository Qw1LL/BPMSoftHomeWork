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

	#region Class: ExcelFileDataInLookupsSchema

	/// <exclude/>
	public class ExcelFileDataInLookupsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ExcelFileDataInLookupsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExcelFileDataInLookupsSchema(ExcelFileDataInLookupsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExcelFileDataInLookupsSchema(ExcelFileDataInLookupsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8");
			RealUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8");
			Name = "ExcelFileDataInLookups";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4be45828-978b-4473-988f-276ea3484655")) == null) {
				Columns.Add(CreateFileValueColumn());
			}
			if (Columns.FindByUId(new Guid("33792c84-0b35-4ba6-879e-8434afe9e322")) == null) {
				Columns.Add(CreateLookupNameColumn());
			}
			if (Columns.FindByUId(new Guid("13179879-4384-45a3-8279-7ced655b39c0")) == null) {
				Columns.Add(CreateLookupValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFileValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("4be45828-978b-4473-988f-276ea3484655"),
				Name = @"FileValue",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8"),
				ModifiedInSchemaUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("33792c84-0b35-4ba6-879e-8434afe9e322"),
				Name = @"LookupName",
				CreatedInSchemaUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8"),
				ModifiedInSchemaUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("13179879-4384-45a3-8279-7ced655b39c0"),
				Name = @"LookupValue",
				CreatedInSchemaUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8"),
				ModifiedInSchemaUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8"),
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
			return new ExcelFileDataInLookups(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExcelFileDataInLookups_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExcelFileDataInLookupsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExcelFileDataInLookupsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8"));
		}

		#endregion

	}

	#endregion

	#region Class: ExcelFileDataInLookups

	/// <summary>
	/// Data value from file in lookup.
	/// </summary>
	public class ExcelFileDataInLookups : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ExcelFileDataInLookups(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExcelFileDataInLookups";
		}

		public ExcelFileDataInLookups(ExcelFileDataInLookups source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value in file.
		/// </summary>
		public string FileValue {
			get {
				return GetTypedColumnValue<string>("FileValue");
			}
			set {
				SetColumnValue("FileValue", value);
			}
		}

		/// <summary>
		/// Lookup name.
		/// </summary>
		public string LookupName {
			get {
				return GetTypedColumnValue<string>("LookupName");
			}
			set {
				SetColumnValue("LookupName", value);
			}
		}

		/// <summary>
		/// Value in lookup.
		/// </summary>
		public string LookupValue {
			get {
				return GetTypedColumnValue<string>("LookupValue");
			}
			set {
				SetColumnValue("LookupValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ExcelFileDataInLookups_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ExcelFileDataInLookupsDeleted", e);
			Deleting += (s, e) => ThrowEvent("ExcelFileDataInLookupsDeleting", e);
			Inserted += (s, e) => ThrowEvent("ExcelFileDataInLookupsInserted", e);
			Inserting += (s, e) => ThrowEvent("ExcelFileDataInLookupsInserting", e);
			Saved += (s, e) => ThrowEvent("ExcelFileDataInLookupsSaved", e);
			Saving += (s, e) => ThrowEvent("ExcelFileDataInLookupsSaving", e);
			Validating += (s, e) => ThrowEvent("ExcelFileDataInLookupsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ExcelFileDataInLookups(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExcelFileDataInLookups_BaseEventsProcess

	/// <exclude/>
	public partial class ExcelFileDataInLookups_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ExcelFileDataInLookups
	{

		public ExcelFileDataInLookups_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExcelFileDataInLookups_BaseEventsProcess";
			SchemaUId = new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("463eddd8-ef41-4a2a-9963-1e131327faf8");
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

	#region Class: ExcelFileDataInLookups_BaseEventsProcess

	/// <exclude/>
	public class ExcelFileDataInLookups_BaseEventsProcess : ExcelFileDataInLookups_BaseEventsProcess<ExcelFileDataInLookups>
	{

		public ExcelFileDataInLookups_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExcelFileDataInLookups_BaseEventsProcess

	public partial class ExcelFileDataInLookups_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExcelFileDataInLookupsEventsProcess

	/// <exclude/>
	public class ExcelFileDataInLookupsEventsProcess : ExcelFileDataInLookups_BaseEventsProcess
	{

		public ExcelFileDataInLookupsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

