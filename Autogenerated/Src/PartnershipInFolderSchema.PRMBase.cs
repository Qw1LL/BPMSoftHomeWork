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

	#region Class: PartnershipInFolder_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class PartnershipInFolder_PRMBase_BPMSoftSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public PartnershipInFolder_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipInFolder_PRMBase_BPMSoftSchema(PartnershipInFolder_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipInFolder_PRMBase_BPMSoftSchema(PartnershipInFolder_PRMBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			RealUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			Name = "PartnershipInFolder_PRMBase_BPMSoft";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("18a4f306-cef1-4e59-93d2-81e2e92a1f3a")) == null) {
				Columns.Add(CreatePartnershipColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("11d0998f-b8a2-4777-95eb-66043ddea0cd");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePartnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("18a4f306-cef1-4e59-93d2-81e2e92a1f3a"),
				Name = @"Partnership",
				ReferenceSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b"),
				ModifiedInSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b"),
				CreatedInPackageId = new Guid("047f00c4-7c65-4fe2-bb2b-f56703cb1187")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PartnershipInFolder_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipInFolder_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipInFolder_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipInFolder_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipInFolder_PRMBase_BPMSoft

	/// <summary>
	/// Partnership in Folder.
	/// </summary>
	public class PartnershipInFolder_PRMBase_BPMSoft : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public PartnershipInFolder_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipInFolder_PRMBase_BPMSoft";
		}

		public PartnershipInFolder_PRMBase_BPMSoft(PartnershipInFolder_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PartnershipId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipId");
			}
			set {
				SetColumnValue("PartnershipId", value);
				_partnership = null;
			}
		}

		/// <exclude/>
		public string PartnershipName {
			get {
				return GetTypedColumnValue<string>("PartnershipName");
			}
			set {
				SetColumnValue("PartnershipName", value);
				if (_partnership != null) {
					_partnership.Name = value;
				}
			}
		}

		private Partnership _partnership;
		/// <summary>
		/// Partnership.
		/// </summary>
		public Partnership Partnership {
			get {
				return _partnership ??
					(_partnership = LookupColumnEntities.GetEntity("Partnership") as Partnership);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipInFolder_PRMBaseEventsProcess(UserConnection);
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
			return new PartnershipInFolder_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipInFolder_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnershipInFolder_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : PartnershipInFolder_PRMBase_BPMSoft
	{

		public PartnershipInFolder_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipInFolder_PRMBaseEventsProcess";
			SchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
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

	#region Class: PartnershipInFolder_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnershipInFolder_PRMBaseEventsProcess : PartnershipInFolder_PRMBaseEventsProcess<PartnershipInFolder_PRMBase_BPMSoft>
	{

		public PartnershipInFolder_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipInFolder_PRMBaseEventsProcess

	public partial class PartnershipInFolder_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

