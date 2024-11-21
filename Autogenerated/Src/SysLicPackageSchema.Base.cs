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

	#region Class: SysLicPackageSchema

	/// <exclude/>
	public class SysLicPackageSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysLicPackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLicPackageSchema(SysLicPackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLicPackageSchema(SysLicPackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysPackageNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("d791fdd6-07fb-464e-ae0a-75f2b118617a");
			index.Name = "IUSysPackageName";
			index.CreatedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
			index.ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("dd5bde58-808b-404b-b270-90eaeb005c4e"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
			RealUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
			Name = "SysLicPackage";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bf7700a2-13ed-4e65-a81a-e689ecca648a")) == null) {
				Columns.Add(CreatePublicKeyColumn());
			}
			if (Columns.FindByUId(new Guid("ad0ce0c5-e593-4030-a4ec-c36555c23387")) == null) {
				Columns.Add(CreateOperationsColumn());
			}
			if (Columns.FindByUId(new Guid("e8f5499a-3c62-4365-848d-23e4d58a24da")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("e5c0c98c-e9f3-40db-958b-68e951a75943")) == null) {
				Columns.Add(CreateUseUserAssociationColumn());
			}
			if (Columns.FindByUId(new Guid("738cf244-7982-4dc3-a468-3b2589c4f7ac")) == null) {
				Columns.Add(CreateIsSspColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePublicKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("bf7700a2-13ed-4e65-a81a-e689ecca648a"),
				Name = @"PublicKey",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ad0ce0c5-e593-4030-a4ec-c36555c23387"),
				Name = @"Operations",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e8f5499a-3c62-4365-848d-23e4d58a24da"),
				Name = @"Key",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUseUserAssociationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e5c0c98c-e9f3-40db-958b-68e951a75943"),
				Name = @"UseUserAssociation",
				CreatedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsSspColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("738cf244-7982-4dc3-a468-3b2589c4f7ac"),
				Name = @"IsSsp",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				ModifiedInSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysPackageNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLicPackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLicPackage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLicPackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLicPackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLicPackage

	/// <summary>
	/// Licensed configuration .
	/// </summary>
	public class SysLicPackage : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysLicPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLicPackage";
		}

		public SysLicPackage(SysLicPackage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Public key.
		/// </summary>
		public string PublicKey {
			get {
				return GetTypedColumnValue<string>("PublicKey");
			}
			set {
				SetColumnValue("PublicKey", value);
			}
		}

		/// <summary>
		/// Operations.
		/// </summary>
		public string Operations {
			get {
				return GetTypedColumnValue<string>("Operations");
			}
			set {
				SetColumnValue("Operations", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Licensed by users.
		/// </summary>
		public bool UseUserAssociation {
			get {
				return GetTypedColumnValue<bool>("UseUserAssociation");
			}
			set {
				SetColumnValue("UseUserAssociation", value);
			}
		}

		/// <summary>
		/// License for ssp users.
		/// </summary>
		public bool IsSsp {
			get {
				return GetTypedColumnValue<bool>("IsSsp");
			}
			set {
				SetColumnValue("IsSsp", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLicPackage_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLicPackageDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysLicPackageDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysLicPackageInserted", e);
			Inserting += (s, e) => ThrowEvent("SysLicPackageInserting", e);
			Saved += (s, e) => ThrowEvent("SysLicPackageSaved", e);
			Saving += (s, e) => ThrowEvent("SysLicPackageSaving", e);
			Validating += (s, e) => ThrowEvent("SysLicPackageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLicPackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLicPackage_BaseEventsProcess

	/// <exclude/>
	public partial class SysLicPackage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysLicPackage
	{

		public SysLicPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLicPackage_BaseEventsProcess";
			SchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a");
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

	#region Class: SysLicPackage_BaseEventsProcess

	/// <exclude/>
	public class SysLicPackage_BaseEventsProcess : SysLicPackage_BaseEventsProcess<SysLicPackage>
	{

		public SysLicPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLicPackage_BaseEventsProcess

	public partial class SysLicPackage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: SysLicPackageEventsProcess

	/// <exclude/>
	public class SysLicPackageEventsProcess : SysLicPackage_BaseEventsProcess
	{

		public SysLicPackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

