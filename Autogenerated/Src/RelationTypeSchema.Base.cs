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

	#region Class: RelationType_Base_BPMSoftSchema

	/// <exclude/>
	public class RelationType_Base_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public RelationType_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationType_Base_BPMSoftSchema(RelationType_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationType_Base_BPMSoftSchema(RelationType_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23");
			RealUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23");
			Name = "RelationType_Base_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f4e69913-fe63-4238-bf3c-1107f516ed75")) == null) {
				Columns.Add(CreateForContactContactColumn());
			}
			if (Columns.FindByUId(new Guid("a4671b71-f200-4c14-b7fa-2cb2fe5492b4")) == null) {
				Columns.Add(CreateForAccountContactColumn());
			}
			if (Columns.FindByUId(new Guid("09ad639a-d97b-457f-89a6-7a173badefb5")) == null) {
				Columns.Add(CreateForContactAccountColumn());
			}
			if (Columns.FindByUId(new Guid("6838568d-88cd-402c-bddf-c798342238f0")) == null) {
				Columns.Add(CreateForAccountAccountColumn());
			}
			if (Columns.FindByUId(new Guid("46e3c8e9-74e4-4da6-af3f-06ec44c5dc73")) == null) {
				Columns.Add(CreateReverseRelationTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateForContactContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f4e69913-fe63-4238-bf3c-1107f516ed75"),
				Name = @"ForContactContact",
				CreatedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				ModifiedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateForAccountContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a4671b71-f200-4c14-b7fa-2cb2fe5492b4"),
				Name = @"ForAccountContact",
				CreatedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				ModifiedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateForContactAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("09ad639a-d97b-457f-89a6-7a173badefb5"),
				Name = @"ForContactAccount",
				CreatedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				ModifiedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateForAccountAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6838568d-88cd-402c-bddf-c798342238f0"),
				Name = @"ForAccountAccount",
				CreatedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				ModifiedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateReverseRelationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("46e3c8e9-74e4-4da6-af3f-06ec44c5dc73"),
				Name = @"ReverseRelationType",
				ReferenceSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				CreatedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
				ModifiedInSchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"),
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
			return new RelationType_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationType_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationType_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationType_Base_BPMSoft

	/// <summary>
	/// Relationship type.
	/// </summary>
	public class RelationType_Base_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public RelationType_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationType_Base_BPMSoft";
		}

		public RelationType_Base_BPMSoft(RelationType_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Contact-Contact.
		/// </summary>
		public bool ForContactContact {
			get {
				return GetTypedColumnValue<bool>("ForContactContact");
			}
			set {
				SetColumnValue("ForContactContact", value);
			}
		}

		/// <summary>
		/// Account-Contact.
		/// </summary>
		public bool ForAccountContact {
			get {
				return GetTypedColumnValue<bool>("ForAccountContact");
			}
			set {
				SetColumnValue("ForAccountContact", value);
			}
		}

		/// <summary>
		/// Contact-Account.
		/// </summary>
		public bool ForContactAccount {
			get {
				return GetTypedColumnValue<bool>("ForContactAccount");
			}
			set {
				SetColumnValue("ForContactAccount", value);
			}
		}

		/// <summary>
		/// Account-Account.
		/// </summary>
		public bool ForAccountAccount {
			get {
				return GetTypedColumnValue<bool>("ForAccountAccount");
			}
			set {
				SetColumnValue("ForAccountAccount", value);
			}
		}

		/// <exclude/>
		public Guid ReverseRelationTypeId {
			get {
				return GetTypedColumnValue<Guid>("ReverseRelationTypeId");
			}
			set {
				SetColumnValue("ReverseRelationTypeId", value);
				_reverseRelationType = null;
			}
		}

		/// <exclude/>
		public string ReverseRelationTypeName {
			get {
				return GetTypedColumnValue<string>("ReverseRelationTypeName");
			}
			set {
				SetColumnValue("ReverseRelationTypeName", value);
				if (_reverseRelationType != null) {
					_reverseRelationType.Name = value;
				}
			}
		}

		private RelationType _reverseRelationType;
		/// <summary>
		/// Inverse relationship.
		/// </summary>
		public RelationType ReverseRelationType {
			get {
				return _reverseRelationType ??
					(_reverseRelationType = LookupColumnEntities.GetEntity("ReverseRelationType") as RelationType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("RelationType_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("RelationType_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("RelationType_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("RelationType_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("RelationType_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("RelationType_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("RelationType_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new RelationType_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationType_BaseEventsProcess

	/// <exclude/>
	public partial class RelationType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : RelationType_Base_BPMSoft
	{

		public RelationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationType_BaseEventsProcess";
			SchemaUId = new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fd62ea78-5401-4cbc-8a6c-c87d0c097e23");
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

	#region Class: RelationType_BaseEventsProcess

	/// <exclude/>
	public class RelationType_BaseEventsProcess : RelationType_BaseEventsProcess<RelationType_Base_BPMSoft>
	{

		public RelationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationType_BaseEventsProcess

	public partial class RelationType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

