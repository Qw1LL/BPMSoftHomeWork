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

	#region Class: CTISearchResultSchema

	/// <exclude/>
	public class CTISearchResultSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CTISearchResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CTISearchResultSchema(CTISearchResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CTISearchResultSchema(CTISearchResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			RealUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			Name = "CTISearchResult";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d5c928d2-ad4e-49cd-8dbb-4a87679f863d")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("59c44c04-8ad3-42c2-9c62-37800f62f399")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("84e5e215-316b-43d7-a5c3-3838e2f7aa35")) == null) {
				Columns.Add(CreateSearchIdColumn());
			}
			if (Columns.FindByUId(new Guid("c499ab1a-e8d9-4d9e-865b-e72dbfb71847")) == null) {
				Columns.Add(CreateCommunicationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("ed1e7965-6099-4a96-8215-67e87a9f0b38")) == null) {
				Columns.Add(CreateNumberColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			column.CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			column.CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			column.CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			column.CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			column.CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			column.CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d5c928d2-ad4e-49cd-8dbb-4a87679f863d"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("59c44c04-8ad3-42c2-9c62-37800f62f399"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("84e5e215-316b-43d7-a5c3-3838e2f7aa35"),
				Name = @"SearchId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea")
			};
		}

		protected virtual EntitySchemaColumn CreateCommunicationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c499ab1a-e8d9-4d9e-865b-e72dbfb71847"),
				Name = @"CommunicationType",
				ReferenceSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				CreatedInPackageId = new Guid("e19d0b53-b1c2-4c69-a493-d6c3bb8ab730")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ed1e7965-6099-4a96-8215-67e87a9f0b38"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				ModifiedInSchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"),
				CreatedInPackageId = new Guid("e19d0b53-b1c2-4c69-a493-d6c3bb8ab730")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CTISearchResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CTISearchResult_CTIBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CTISearchResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CTISearchResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24"));
		}

		#endregion

	}

	#endregion

	#region Class: CTISearchResult

	/// <summary>
	/// Search result.
	/// </summary>
	public class CTISearchResult : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CTISearchResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CTISearchResult";
		}

		public CTISearchResult(CTISearchResult source)
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

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <summary>
		/// Search Id.
		/// </summary>
		public Guid SearchId {
			get {
				return GetTypedColumnValue<Guid>("SearchId");
			}
			set {
				SetColumnValue("SearchId", value);
			}
		}

		/// <exclude/>
		public Guid CommunicationTypeId {
			get {
				return GetTypedColumnValue<Guid>("CommunicationTypeId");
			}
			set {
				SetColumnValue("CommunicationTypeId", value);
				_communicationType = null;
			}
		}

		/// <exclude/>
		public string CommunicationTypeName {
			get {
				return GetTypedColumnValue<string>("CommunicationTypeName");
			}
			set {
				SetColumnValue("CommunicationTypeName", value);
				if (_communicationType != null) {
					_communicationType.Name = value;
				}
			}
		}

		private CommunicationType _communicationType;
		/// <summary>
		/// Communication option type.
		/// </summary>
		public CommunicationType CommunicationType {
			get {
				return _communicationType ??
					(_communicationType = LookupColumnEntities.GetEntity("CommunicationType") as CommunicationType);
			}
		}

		/// <summary>
		/// Number.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CTISearchResult_CTIBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CTISearchResultDeleted", e);
			Inserting += (s, e) => ThrowEvent("CTISearchResultInserting", e);
			Validating += (s, e) => ThrowEvent("CTISearchResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CTISearchResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: CTISearchResult_CTIBaseEventsProcess

	/// <exclude/>
	public partial class CTISearchResult_CTIBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CTISearchResult
	{

		public CTISearchResult_CTIBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CTISearchResult_CTIBaseEventsProcess";
			SchemaUId = new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5698a84b-4500-4a6e-ada2-e6b293327c24");
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

	#region Class: CTISearchResult_CTIBaseEventsProcess

	/// <exclude/>
	public class CTISearchResult_CTIBaseEventsProcess : CTISearchResult_CTIBaseEventsProcess<CTISearchResult>
	{

		public CTISearchResult_CTIBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CTISearchResult_CTIBaseEventsProcess

	public partial class CTISearchResult_CTIBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CTISearchResultEventsProcess

	/// <exclude/>
	public class CTISearchResultEventsProcess : CTISearchResult_CTIBaseEventsProcess
	{

		public CTISearchResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

