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
	using BPMSoft.Core.OperationLog;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using BPMSoft.Web.Common;
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

	#region Class: SysAdminUnit_LDAP_BPMSoftSchema

	/// <exclude/>
	public class SysAdminUnit_LDAP_BPMSoftSchema : BPMSoft.Configuration.SysAdminUnit_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysAdminUnit_LDAP_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnit_LDAP_BPMSoftSchema(SysAdminUnit_LDAP_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnit_LDAP_BPMSoftSchema(SysAdminUnit_LDAP_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysAdminUnitNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("a09035f6-13ab-41d9-af1c-c095e5cf9ac1");
			index.Name = "IUSysAdminUnitName";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5c950219-374c-425c-8082-7e7de785ba20"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			EntitySchemaIndexColumn parentRoleIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3c1b73d7-6adf-4567-88c8-8b95952dc03c"),
				ColumnUId = new Guid("fa4483b3-a2db-4651-a462-689be18351e7"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("81adfa8e-1f43-43a3-9652-1b782e1a0cf1"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(parentRoleIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISAULoggedInActiveIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("cf9e2407-d54a-4930-bdfc-ce9bc64ddfb4");
			index.Name = "ISAULoggedInActive";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn loggedInIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d9c799ef-023d-492c-879d-52d11308d0e8"),
				ColumnUId = new Guid("b0cc6131-e034-4562-9526-3f3a81f0a161"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(loggedInIndexColumn);
			EntitySchemaIndexColumn activeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("670a80ef-4ebe-4c5d-a5d1-e03f9edc4367"),
				ColumnUId = new Guid("48f37442-a2da-4407-9178-72073ba6b09f"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(activeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5945745f-3879-4d46-aff9-4b5e7eee7897");
			Name = "SysAdminUnit_LDAP_BPMSoft";
			ParentSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			ExtendParent = true;
			CreatedInPackageId = new Guid("9455e8ee-c1b2-4f85-8263-bcf4e7ad4866");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3b22d4df-9327-416d-b318-9e1d49334a6f")) == null) {
				Columns.Add(CreateLDAPElementColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLDAPElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3b22d4df-9327-416d-b318-9e1d49334a6f"),
				Name = @"LDAPElement",
				ReferenceSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5945745f-3879-4d46-aff9-4b5e7eee7897"),
				ModifiedInSchemaUId = new Guid("5945745f-3879-4d46-aff9-4b5e7eee7897"),
				CreatedInPackageId = new Guid("9455e8ee-c1b2-4f85-8263-bcf4e7ad4866")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysAdminUnitNameIndex());
			Indexes.Add(CreateISAULoggedInActiveIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnit_LDAP_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnit_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnit_LDAP_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnit_LDAP_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5945745f-3879-4d46-aff9-4b5e7eee7897"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_LDAP_BPMSoft

	/// <summary>
	/// System administration object.
	/// </summary>
	public class SysAdminUnit_LDAP_BPMSoft : BPMSoft.Configuration.SysAdminUnit_Base_BPMSoft
	{

		#region Constructors: Public

		public SysAdminUnit_LDAP_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnit_LDAP_BPMSoft";
		}

		public SysAdminUnit_LDAP_BPMSoft(SysAdminUnit_LDAP_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LDAPElementId {
			get {
				return GetTypedColumnValue<Guid>("LDAPElementId");
			}
			set {
				SetColumnValue("LDAPElementId", value);
				_lDAPElement = null;
			}
		}

		/// <exclude/>
		public string LDAPElementName {
			get {
				return GetTypedColumnValue<string>("LDAPElementName");
			}
			set {
				SetColumnValue("LDAPElementName", value);
				if (_lDAPElement != null) {
					_lDAPElement.Name = value;
				}
			}
		}

		private LDAPElement _lDAPElement;
		/// <summary>
		/// LDAP element.
		/// </summary>
		public LDAPElement LDAPElement {
			get {
				return _lDAPElement ??
					(_lDAPElement = LookupColumnEntities.GetEntity("LDAPElement") as LDAPElement);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminUnit_LDAPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("SysAdminUnit_LDAP_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysAdminUnit_LDAP_BPMSoftInserted", e);
			Saving += (s, e) => ThrowEvent("SysAdminUnit_LDAP_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("SysAdminUnit_LDAP_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("SysAdminUnit_LDAP_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnit_LDAP_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_LDAPEventsProcess

	/// <exclude/>
	public partial class SysAdminUnit_LDAPEventsProcess<TEntity> : BPMSoft.Configuration.SysAdminUnit_BaseEventsProcess<TEntity> where TEntity : SysAdminUnit_LDAP_BPMSoft
	{

		public SysAdminUnit_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnit_LDAPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5945745f-3879-4d46-aff9-4b5e7eee7897");
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

	#region Class: SysAdminUnit_LDAPEventsProcess

	/// <exclude/>
	public class SysAdminUnit_LDAPEventsProcess : SysAdminUnit_LDAPEventsProcess<SysAdminUnit_LDAP_BPMSoft>
	{

		public SysAdminUnit_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnit_LDAPEventsProcess

	public partial class SysAdminUnit_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}

