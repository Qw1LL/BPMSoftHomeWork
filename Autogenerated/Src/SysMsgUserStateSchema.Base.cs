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

	#region Class: SysMsgUserState_Base_BPMSoftSchema

	/// <exclude/>
	public class SysMsgUserState_Base_BPMSoftSchema : BPMSoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public SysMsgUserState_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMsgUserState_Base_BPMSoftSchema(SysMsgUserState_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMsgUserState_Base_BPMSoftSchema(SysMsgUserState_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			RealUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			Name = "SysMsgUserState_Base_BPMSoft";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e67359d9-76c4-4118-a79c-46e421b11c62")) == null) {
				Columns.Add(CreateIsDisplayOnlyColumn());
			}
			if (Columns.FindByUId(new Guid("a987423b-a858-4feb-885e-00db8293f227")) == null) {
				Columns.Add(CreateIconColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("ShortText");
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsDisplayOnlyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e67359d9-76c4-4118-a79c-46e421b11c62"),
				Name = @"IsDisplayOnly",
				CreatedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				CreatedInPackageId = new Guid("cc041c70-8b15-43b4-a62a-30f4563cef27")
			};
		}

		protected virtual EntitySchemaColumn CreateIconColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a987423b-a858-4feb-885e-00db8293f227"),
				Name = @"Icon",
				ReferenceSchemaUId = new Guid("14169d59-d673-4d47-a481-2b98bec51aec"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				CreatedInPackageId = new Guid("099a46f5-4272-4576-a215-4895a200b20c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysMsgUserState_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMsgUserState_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMsgUserState_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMsgUserState_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserState_Base_BPMSoft

	/// <summary>
	/// User status when exchanging messages.
	/// </summary>
	public class SysMsgUserState_Base_BPMSoft : BPMSoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public SysMsgUserState_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserState_Base_BPMSoft";
		}

		public SysMsgUserState_Base_BPMSoft(SysMsgUserState_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Display only.
		/// </summary>
		public bool IsDisplayOnly {
			get {
				return GetTypedColumnValue<bool>("IsDisplayOnly");
			}
			set {
				SetColumnValue("IsDisplayOnly", value);
			}
		}

		/// <exclude/>
		public Guid IconId {
			get {
				return GetTypedColumnValue<Guid>("IconId");
			}
			set {
				SetColumnValue("IconId", value);
				_icon = null;
			}
		}

		/// <exclude/>
		public string IconName {
			get {
				return GetTypedColumnValue<string>("IconName");
			}
			set {
				SetColumnValue("IconName", value);
				if (_icon != null) {
					_icon.Name = value;
				}
			}
		}

		private SysMsgUserStateIcon _icon;
		/// <summary>
		/// Icon.
		/// </summary>
		public SysMsgUserStateIcon Icon {
			get {
				return _icon ??
					(_icon = LookupColumnEntities.GetEntity("Icon") as SysMsgUserStateIcon);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMsgUserState_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysMsgUserState_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysMsgUserState_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysMsgUserState_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("SysMsgUserState_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("SysMsgUserState_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("SysMsgUserState_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("SysMsgUserState_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysMsgUserState_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserState_BaseEventsProcess

	/// <exclude/>
	public partial class SysMsgUserState_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeImageLookup_BaseEventsProcess<TEntity> where TEntity : SysMsgUserState_Base_BPMSoft
	{

		public SysMsgUserState_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMsgUserState_BaseEventsProcess";
			SchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
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

	#region Class: SysMsgUserState_BaseEventsProcess

	/// <exclude/>
	public class SysMsgUserState_BaseEventsProcess : SysMsgUserState_BaseEventsProcess<SysMsgUserState_Base_BPMSoft>
	{

		public SysMsgUserState_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMsgUserState_BaseEventsProcess

	public partial class SysMsgUserState_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}

