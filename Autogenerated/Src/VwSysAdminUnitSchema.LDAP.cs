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

	#region Class: VwSysAdminUnit_LDAP_BPMSoftSchema

	/// <exclude/>
	public class VwSysAdminUnit_LDAP_BPMSoftSchema : BPMSoft.Configuration.VwSysAdminUnit_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public VwSysAdminUnit_LDAP_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysAdminUnit_LDAP_BPMSoftSchema(VwSysAdminUnit_LDAP_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysAdminUnit_LDAP_BPMSoftSchema(VwSysAdminUnit_LDAP_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("666ef293-9b46-486b-8e1d-05603efdc45d");
			Name = "VwSysAdminUnit_LDAP_BPMSoft";
			ParentSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7ac00ac8-4704-4c6a-999a-db94daccf6cd");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("84e7273c-fa59-4025-a99f-0ed3948c7d47")) == null) {
				Columns.Add(CreateLDAPElementColumn());
			}
		}

		protected override EntitySchemaColumn CreateLDAPEntryColumn() {
			EntitySchemaColumn column = base.CreateLDAPEntryColumn();
			column.ModifiedInSchemaUId = new Guid("666ef293-9b46-486b-8e1d-05603efdc45d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLDAPElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("84e7273c-fa59-4025-a99f-0ed3948c7d47"),
				Name = @"LDAPElement",
				ReferenceSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("666ef293-9b46-486b-8e1d-05603efdc45d"),
				ModifiedInSchemaUId = new Guid("666ef293-9b46-486b-8e1d-05603efdc45d"),
				CreatedInPackageId = new Guid("7ac00ac8-4704-4c6a-999a-db94daccf6cd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysAdminUnit_LDAP_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysAdminUnit_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysAdminUnit_LDAP_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysAdminUnit_LDAP_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("666ef293-9b46-486b-8e1d-05603efdc45d"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminUnit_LDAP_BPMSoft

	/// <summary>
	/// Users/roles (view).
	/// </summary>
	public class VwSysAdminUnit_LDAP_BPMSoft : BPMSoft.Configuration.VwSysAdminUnit_Base_BPMSoft
	{

		#region Constructors: Public

		public VwSysAdminUnit_LDAP_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysAdminUnit_LDAP_BPMSoft";
		}

		public VwSysAdminUnit_LDAP_BPMSoft(VwSysAdminUnit_LDAP_BPMSoft source)
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
			var process = new VwSysAdminUnit_LDAPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("VwSysAdminUnit_LDAP_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysAdminUnit_LDAP_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminUnit_LDAPEventsProcess

	/// <exclude/>
	public partial class VwSysAdminUnit_LDAPEventsProcess<TEntity> : BPMSoft.Configuration.VwSysAdminUnit_BaseEventsProcess<TEntity> where TEntity : VwSysAdminUnit_LDAP_BPMSoft
	{

		public VwSysAdminUnit_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysAdminUnit_LDAPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("666ef293-9b46-486b-8e1d-05603efdc45d");
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

	#region Class: VwSysAdminUnit_LDAPEventsProcess

	/// <exclude/>
	public class VwSysAdminUnit_LDAPEventsProcess : VwSysAdminUnit_LDAPEventsProcess<VwSysAdminUnit_LDAP_BPMSoft>
	{

		public VwSysAdminUnit_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysAdminUnit_LDAPEventsProcess

	public partial class VwSysAdminUnit_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}

