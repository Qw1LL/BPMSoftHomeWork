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

	#region Class: CommunicationType_Base_BPMSoftSchema

	/// <exclude/>
	public class CommunicationType_Base_BPMSoftSchema : BPMSoft.Configuration.BaseImageLookupSchema
	{

		#region Constructors: Public

		public CommunicationType_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CommunicationType_Base_BPMSoftSchema(CommunicationType_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CommunicationType_Base_BPMSoftSchema(CommunicationType_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			RealUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			Name = "CommunicationType_Base_BPMSoft";
			ParentSchemaUId = new Guid("b4a781bd-bacd-4ba1-a16b-48c09a21f087");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0da3b0de-9d19-47e8-89e4-e113dde44a8c")) == null) {
				Columns.Add(CreateHyperlinkTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("9583d17a-064d-402d-bdb1-7d377628d64b")) == null) {
				Columns.Add(CreateUseforAccountsColumn());
			}
			if (Columns.FindByUId(new Guid("07748e81-b1d1-4cdb-9e41-d5e0be2e13d9")) == null) {
				Columns.Add(CreateUseforContactsColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateImageColumn() {
			EntitySchemaColumn column = base.CreateImageColumn();
			column.ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateHyperlinkTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0da3b0de-9d19-47e8-89e4-e113dde44a8c"),
				Name = @"HyperlinkTemplate",
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUseforAccountsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9583d17a-064d-402d-bdb1-7d377628d64b"),
				Name = @"UseforAccounts",
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUseforContactsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("07748e81-b1d1-4cdb-9e41-d5e0be2e13d9"),
				Name = @"UseforContacts",
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
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
			return new CommunicationType_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CommunicationType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CommunicationType_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CommunicationType_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"));
		}

		#endregion

	}

	#endregion

	#region Class: CommunicationType_Base_BPMSoft

	/// <summary>
	/// Communication option type.
	/// </summary>
	public class CommunicationType_Base_BPMSoft : BPMSoft.Configuration.BaseImageLookup
	{

		#region Constructors: Public

		public CommunicationType_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CommunicationType_Base_BPMSoft";
		}

		public CommunicationType_Base_BPMSoft(CommunicationType_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Template for creating a hyperlink in text.
		/// </summary>
		public string HyperlinkTemplate {
			get {
				return GetTypedColumnValue<string>("HyperlinkTemplate");
			}
			set {
				SetColumnValue("HyperlinkTemplate", value);
			}
		}

		/// <summary>
		/// Use for accounts.
		/// </summary>
		public bool UseforAccounts {
			get {
				return GetTypedColumnValue<bool>("UseforAccounts");
			}
			set {
				SetColumnValue("UseforAccounts", value);
			}
		}

		/// <summary>
		/// Use for contacts.
		/// </summary>
		public bool UseforContacts {
			get {
				return GetTypedColumnValue<bool>("UseforContacts");
			}
			set {
				SetColumnValue("UseforContacts", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CommunicationType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CommunicationType_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("CommunicationType_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("CommunicationType_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("CommunicationType_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("CommunicationType_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("CommunicationType_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("CommunicationType_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CommunicationType_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: CommunicationType_BaseEventsProcess

	/// <exclude/>
	public partial class CommunicationType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseImageLookup_BaseEventsProcess<TEntity> where TEntity : CommunicationType_Base_BPMSoft
	{

		public CommunicationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CommunicationType_BaseEventsProcess";
			SchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
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

	#region Class: CommunicationType_BaseEventsProcess

	/// <exclude/>
	public class CommunicationType_BaseEventsProcess : CommunicationType_BaseEventsProcess<CommunicationType_Base_BPMSoft>
	{

		public CommunicationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CommunicationType_BaseEventsProcess

	public partial class CommunicationType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}

