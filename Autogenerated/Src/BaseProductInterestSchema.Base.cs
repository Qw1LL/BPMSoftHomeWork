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

	#region Class: BaseProductInterestSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseProductInterestSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseProductInterestSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseProductInterestSchema(BaseProductInterestSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseProductInterestSchema(BaseProductInterestSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7");
			RealUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7");
			Name = "BaseProductInterest";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f7dba1f9-106d-4109-91ed-e5bf0425611d")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("0d71fb26-6979-40fc-b54d-e7f465a2d767")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("81e1ebf2-5012-4841-9e49-452747fd7fda")) == null) {
				Columns.Add(CreateDateOfProposalColumn());
			}
			if (Columns.FindByUId(new Guid("703411de-845b-46d1-a4d7-13bcd105a3d1")) == null) {
				Columns.Add(CreateResultOfProposalColumn());
			}
			if (Columns.FindByUId(new Guid("0cc772ae-1d06-4c9c-97ca-e71b9cc140b7")) == null) {
				Columns.Add(CreateCommentsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f7dba1f9-106d-4109-91ed-e5bf0425611d"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				ModifiedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("0d71fb26-6979-40fc-b54d-e7f465a2d767"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				ModifiedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDateOfProposalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("81e1ebf2-5012-4841-9e49-452747fd7fda"),
				Name = @"DateOfProposal",
				CreatedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				ModifiedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateResultOfProposalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("703411de-845b-46d1-a4d7-13bcd105a3d1"),
				Name = @"ResultOfProposal",
				ReferenceSchemaUId = new Guid("801a201c-7040-4489-a705-5896b20d2f52"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				ModifiedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0cc772ae-1d06-4c9c-97ca-e71b9cc140b7"),
				Name = @"Comments",
				CreatedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
				ModifiedInSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"),
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
			return new BaseProductInterest(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseProductInterest_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseProductInterestSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseProductInterestSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseProductInterest

	/// <summary>
	/// Base interest to product.
	/// </summary>
	public class BaseProductInterest : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseProductInterest(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseProductInterest";
		}

		public BaseProductInterest(BaseProductInterest source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Product.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as Product);
			}
		}

		/// <summary>
		/// Quantity.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Quoted on.
		/// </summary>
		public DateTime DateOfProposal {
			get {
				return GetTypedColumnValue<DateTime>("DateOfProposal");
			}
			set {
				SetColumnValue("DateOfProposal", value);
			}
		}

		/// <exclude/>
		public Guid ResultOfProposalId {
			get {
				return GetTypedColumnValue<Guid>("ResultOfProposalId");
			}
			set {
				SetColumnValue("ResultOfProposalId", value);
				_resultOfProposal = null;
			}
		}

		/// <exclude/>
		public string ResultOfProposalName {
			get {
				return GetTypedColumnValue<string>("ResultOfProposalName");
			}
			set {
				SetColumnValue("ResultOfProposalName", value);
				if (_resultOfProposal != null) {
					_resultOfProposal.Name = value;
				}
			}
		}

		private PropositionResult _resultOfProposal;
		/// <summary>
		/// Interest.
		/// </summary>
		public PropositionResult ResultOfProposal {
			get {
				return _resultOfProposal ??
					(_resultOfProposal = LookupColumnEntities.GetEntity("ResultOfProposal") as PropositionResult);
			}
		}

		/// <summary>
		/// Comments.
		/// </summary>
		public string Comments {
			get {
				return GetTypedColumnValue<string>("Comments");
			}
			set {
				SetColumnValue("Comments", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseProductInterest_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseProductInterestDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseProductInterestDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseProductInterestInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseProductInterestInserting", e);
			Saved += (s, e) => ThrowEvent("BaseProductInterestSaved", e);
			Saving += (s, e) => ThrowEvent("BaseProductInterestSaving", e);
			Validating += (s, e) => ThrowEvent("BaseProductInterestValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseProductInterest(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseProductInterest_BaseEventsProcess

	/// <exclude/>
	public partial class BaseProductInterest_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseProductInterest
	{

		public BaseProductInterest_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseProductInterest_BaseEventsProcess";
			SchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7");
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

	#region Class: BaseProductInterest_BaseEventsProcess

	/// <exclude/>
	public class BaseProductInterest_BaseEventsProcess : BaseProductInterest_BaseEventsProcess<BaseProductInterest>
	{

		public BaseProductInterest_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseProductInterest_BaseEventsProcess

	public partial class BaseProductInterest_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseProductInterestEventsProcess

	/// <exclude/>
	public class BaseProductInterestEventsProcess : BaseProductInterest_BaseEventsProcess
	{

		public BaseProductInterestEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

