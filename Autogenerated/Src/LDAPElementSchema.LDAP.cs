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

	#region Class: LDAPElementSchema

	/// <exclude/>
	public class LDAPElementSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LDAPElementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LDAPElementSchema(LDAPElementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LDAPElementSchema(LDAPElementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb");
			RealUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb");
			Name = "LDAPElement";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9455e8ee-c1b2-4f85-8263-bcf4e7ad4866");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bba6f929-b032-47e6-b76c-4cb9d3a8fcce")) == null) {
				Columns.Add(CreateLDAPEntryIdColumn());
			}
			if (Columns.FindByUId(new Guid("618fc314-1662-4d00-8235-7f8571a488e8")) == null) {
				Columns.Add(CreateLDAPEntryDNColumn());
			}
			if (Columns.FindByUId(new Guid("9f0e8450-bf80-4261-8bea-91a4a0e451a5")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("8339497f-6132-4a4d-941f-2977ad5e2c7e")) == null) {
				Columns.Add(CreateFullNameColumn());
			}
			if (Columns.FindByUId(new Guid("f474acfb-f0b9-4bd0-8489-8bd9b604ef91")) == null) {
				Columns.Add(CreateCompanyColumn());
			}
			if (Columns.FindByUId(new Guid("6e42f252-a516-46aa-9fef-041bd6585b44")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("106226b4-7044-4525-a664-9c9930b5e325")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("9b020abb-bff7-49f8-8d29-cc180847128f")) == null) {
				Columns.Add(CreateJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("6c4cca34-44bb-4fa8-bfab-0aec32048eb5")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bba6f929-b032-47e6-b76c-4cb9d3a8fcce"),
				Name = @"LDAPEntryId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("9455e8ee-c1b2-4f85-8263-bcf4e7ad4866")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryDNColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("618fc314-1662-4d00-8235-7f8571a488e8"),
				Name = @"LDAPEntryDN",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("9455e8ee-c1b2-4f85-8263-bcf4e7ad4866")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9f0e8450-bf80-4261-8bea-91a4a0e451a5"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("d1304e55-520c-4566-9530-483a3299e343")
			};
		}

		protected virtual EntitySchemaColumn CreateFullNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("8339497f-6132-4a4d-941f-2977ad5e2c7e"),
				Name = @"FullName",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("7ac00ac8-4704-4c6a-999a-db94daccf6cd")
			};
		}

		protected virtual EntitySchemaColumn CreateCompanyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f474acfb-f0b9-4bd0-8489-8bd9b604ef91"),
				Name = @"Company",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("7ac00ac8-4704-4c6a-999a-db94daccf6cd")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("6e42f252-a516-46aa-9fef-041bd6585b44"),
				Name = @"Email",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("7ac00ac8-4704-4c6a-999a-db94daccf6cd")
			};
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("106226b4-7044-4525-a664-9c9930b5e325"),
				Name = @"Phone",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("7ac00ac8-4704-4c6a-999a-db94daccf6cd")
			};
		}

		protected virtual EntitySchemaColumn CreateJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("9b020abb-bff7-49f8-8d29-cc180847128f"),
				Name = @"JobTitle",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("7ac00ac8-4704-4c6a-999a-db94daccf6cd")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6c4cca34-44bb-4fa8-bfab-0aec32048eb5"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				ModifiedInSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LDAPElement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LDAPElement_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LDAPElementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LDAPElementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2811d726-f327-44be-9548-c8d90edee2cb"));
		}

		#endregion

	}

	#endregion

	#region Class: LDAPElement

	/// <summary>
	/// LDAP element.
	/// </summary>
	public class LDAPElement : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LDAPElement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LDAPElement";
		}

		public LDAPElement(LDAPElement source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// LDAP element Id.
		/// </summary>
		public string LDAPEntryId {
			get {
				return GetTypedColumnValue<string>("LDAPEntryId");
			}
			set {
				SetColumnValue("LDAPEntryId", value);
			}
		}

		/// <summary>
		/// LDAP element unique name.
		/// </summary>
		public string LDAPEntryDN {
			get {
				return GetTypedColumnValue<string>("LDAPEntryDN");
			}
			set {
				SetColumnValue("LDAPEntryDN", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Full name.
		/// </summary>
		public string FullName {
			get {
				return GetTypedColumnValue<string>("FullName");
			}
			set {
				SetColumnValue("FullName", value);
			}
		}

		/// <summary>
		/// Company.
		/// </summary>
		public string Company {
			get {
				return GetTypedColumnValue<string>("Company");
			}
			set {
				SetColumnValue("Company", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// Phone.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <summary>
		/// Job title.
		/// </summary>
		public string JobTitle {
			get {
				return GetTypedColumnValue<string>("JobTitle");
			}
			set {
				SetColumnValue("JobTitle", value);
			}
		}

		/// <summary>
		/// Active user.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LDAPElement_LDAPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LDAPElementDeleted", e);
			Validating += (s, e) => ThrowEvent("LDAPElementValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LDAPElement(this);
		}

		#endregion

	}

	#endregion

	#region Class: LDAPElement_LDAPEventsProcess

	/// <exclude/>
	public partial class LDAPElement_LDAPEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LDAPElement
	{

		public LDAPElement_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LDAPElement_LDAPEventsProcess";
			SchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2811d726-f327-44be-9548-c8d90edee2cb");
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

	#region Class: LDAPElement_LDAPEventsProcess

	/// <exclude/>
	public class LDAPElement_LDAPEventsProcess : LDAPElement_LDAPEventsProcess<LDAPElement>
	{

		public LDAPElement_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LDAPElement_LDAPEventsProcess

	public partial class LDAPElement_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LDAPElementEventsProcess

	/// <exclude/>
	public class LDAPElementEventsProcess : LDAPElement_LDAPEventsProcess
	{

		public LDAPElementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

