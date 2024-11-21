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

	#region Class: VwRelationshipSchema

	/// <exclude/>
	public class VwRelationshipSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwRelationshipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwRelationshipSchema(VwRelationshipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwRelationshipSchema(VwRelationshipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2");
			RealUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2");
			Name = "VwRelationship";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("772cc7bf-33cf-47fc-8974-8fb30f347cb1")) == null) {
				Columns.Add(CreateOurColumn());
			}
			if (Columns.FindByUId(new Guid("96fb2789-0c6f-4224-a8b1-adaf3f1333ff")) == null) {
				Columns.Add(CreateRelatedColumn());
			}
			if (Columns.FindByUId(new Guid("64c36ec4-8aa4-4956-8ec1-84f77109cbd1")) == null) {
				Columns.Add(CreateOutputRelationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("c1906647-8f51-421c-bd72-15274c685c4e")) == null) {
				Columns.Add(CreateOutputReverseRelationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("40c11f7d-777d-4824-8c81-478edba4adc7")) == null) {
				Columns.Add(CreateContactAColumn());
			}
			if (Columns.FindByUId(new Guid("0f033282-0eb8-4d85-aea1-e5e90e776364")) == null) {
				Columns.Add(CreateAccountAColumn());
			}
			if (Columns.FindByUId(new Guid("e2ccc5c6-cb0e-41c4-86f6-c295a6ee9fe5")) == null) {
				Columns.Add(CreateContactBColumn());
			}
			if (Columns.FindByUId(new Guid("957df48d-b997-445e-90b3-90201edeaf28")) == null) {
				Columns.Add(CreateAccountBColumn());
			}
			if (Columns.FindByUId(new Guid("0c47c5a9-172d-4306-9f3d-463cb56b6e1c")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("af999a48-8fff-44e0-aca1-5314a2f2cf52")) == null) {
				Columns.Add(CreateActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOurColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("772cc7bf-33cf-47fc-8974-8fb30f347cb1"),
				Name = @"Our",
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRelatedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("96fb2789-0c6f-4224-a8b1-adaf3f1333ff"),
				Name = @"Related",
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOutputRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("64c36ec4-8aa4-4956-8ec1-84f77109cbd1"),
				Name = @"OutputRelationType",
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOutputReverseRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c1906647-8f51-421c-bd72-15274c685c4e"),
				Name = @"OutputReverseRelationType",
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("40c11f7d-777d-4824-8c81-478edba4adc7"),
				Name = @"ContactA",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0f033282-0eb8-4d85-aea1-e5e90e776364"),
				Name = @"AccountA",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e2ccc5c6-cb0e-41c4-86f6-c295a6ee9fe5"),
				Name = @"ContactB",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("957df48d-b997-445e-90b3-90201edeaf28"),
				Name = @"AccountB",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0c47c5a9-172d-4306-9f3d-463cb56b6e1c"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("5e998412-5e01-46d8-be42-5973a05fadaa")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("af999a48-8fff-44e0-aca1-5314a2f2cf52"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				ModifiedInSchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"),
				CreatedInPackageId = new Guid("5e998412-5e01-46d8-be42-5973a05fadaa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwRelationship(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwRelationship_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwRelationshipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwRelationshipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2"));
		}

		#endregion

	}

	#endregion

	#region Class: VwRelationship

	/// <summary>
	/// Relationship (view).
	/// </summary>
	public class VwRelationship : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRelationship";
		}

		public VwRelationship(VwRelationship source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Our.
		/// </summary>
		public string Our {
			get {
				return GetTypedColumnValue<string>("Our");
			}
			set {
				SetColumnValue("Our", value);
			}
		}

		/// <summary>
		/// Connected.
		/// </summary>
		public string Related {
			get {
				return GetTypedColumnValue<string>("Related");
			}
			set {
				SetColumnValue("Related", value);
			}
		}

		/// <summary>
		/// Relationship type.
		/// </summary>
		public string OutputRelationType {
			get {
				return GetTypedColumnValue<string>("OutputRelationType");
			}
			set {
				SetColumnValue("OutputRelationType", value);
			}
		}

		/// <summary>
		/// Inverse relationship type.
		/// </summary>
		public string OutputReverseRelationType {
			get {
				return GetTypedColumnValue<string>("OutputReverseRelationType");
			}
			set {
				SetColumnValue("OutputReverseRelationType", value);
			}
		}

		/// <exclude/>
		public Guid ContactAId {
			get {
				return GetTypedColumnValue<Guid>("ContactAId");
			}
			set {
				SetColumnValue("ContactAId", value);
				_contactA = null;
			}
		}

		/// <exclude/>
		public string ContactAName {
			get {
				return GetTypedColumnValue<string>("ContactAName");
			}
			set {
				SetColumnValue("ContactAName", value);
				if (_contactA != null) {
					_contactA.Name = value;
				}
			}
		}

		private Contact _contactA;
		/// <summary>
		/// Contact A.
		/// </summary>
		public Contact ContactA {
			get {
				return _contactA ??
					(_contactA = LookupColumnEntities.GetEntity("ContactA") as Contact);
			}
		}

		/// <exclude/>
		public Guid AccountAId {
			get {
				return GetTypedColumnValue<Guid>("AccountAId");
			}
			set {
				SetColumnValue("AccountAId", value);
				_accountA = null;
			}
		}

		/// <exclude/>
		public string AccountAName {
			get {
				return GetTypedColumnValue<string>("AccountAName");
			}
			set {
				SetColumnValue("AccountAName", value);
				if (_accountA != null) {
					_accountA.Name = value;
				}
			}
		}

		private Account _accountA;
		/// <summary>
		/// Account A.
		/// </summary>
		public Account AccountA {
			get {
				return _accountA ??
					(_accountA = LookupColumnEntities.GetEntity("AccountA") as Account);
			}
		}

		/// <exclude/>
		public Guid ContactBId {
			get {
				return GetTypedColumnValue<Guid>("ContactBId");
			}
			set {
				SetColumnValue("ContactBId", value);
				_contactB = null;
			}
		}

		/// <exclude/>
		public string ContactBName {
			get {
				return GetTypedColumnValue<string>("ContactBName");
			}
			set {
				SetColumnValue("ContactBName", value);
				if (_contactB != null) {
					_contactB.Name = value;
				}
			}
		}

		private Contact _contactB;
		/// <summary>
		/// Contact B.
		/// </summary>
		public Contact ContactB {
			get {
				return _contactB ??
					(_contactB = LookupColumnEntities.GetEntity("ContactB") as Contact);
			}
		}

		/// <exclude/>
		public Guid AccountBId {
			get {
				return GetTypedColumnValue<Guid>("AccountBId");
			}
			set {
				SetColumnValue("AccountBId", value);
				_accountB = null;
			}
		}

		/// <exclude/>
		public string AccountBName {
			get {
				return GetTypedColumnValue<string>("AccountBName");
			}
			set {
				SetColumnValue("AccountBName", value);
				if (_accountB != null) {
					_accountB.Name = value;
				}
			}
		}

		private Account _accountB;
		/// <summary>
		/// Account B.
		/// </summary>
		public Account AccountB {
			get {
				return _accountB ??
					(_accountB = LookupColumnEntities.GetEntity("AccountB") as Account);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Actual.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwRelationship_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwRelationshipDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwRelationshipInserting", e);
			Validating += (s, e) => ThrowEvent("VwRelationshipValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwRelationship(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwRelationship_BaseEventsProcess

	/// <exclude/>
	public partial class VwRelationship_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwRelationship
	{

		public VwRelationship_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwRelationship_BaseEventsProcess";
			SchemaUId = new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8409eced-ba37-4a6a-a031-671fcb7be3e2");
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

	#region Class: VwRelationship_BaseEventsProcess

	/// <exclude/>
	public class VwRelationship_BaseEventsProcess : VwRelationship_BaseEventsProcess<VwRelationship>
	{

		public VwRelationship_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwRelationship_BaseEventsProcess

	public partial class VwRelationship_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwRelationshipEventsProcess

	/// <exclude/>
	public class VwRelationshipEventsProcess : VwRelationship_BaseEventsProcess
	{

		public VwRelationshipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

