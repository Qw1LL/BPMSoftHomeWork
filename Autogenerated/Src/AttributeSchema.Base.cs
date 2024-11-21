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

	#region Class: AttributeSchema

	/// <exclude/>
	public class AttributeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AttributeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AttributeSchema(AttributeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AttributeSchema(AttributeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe");
			RealUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe");
			Name = "Attribute";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1eaec39e-dbba-4241-80e6-084c8a8bf98d")) == null) {
				Columns.Add(CreateOwnerSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("0c037038-1544-42c9-a543-22bc346ad772")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("232c4528-76b5-4385-8e09-e19b66404db9")) == null) {
				Columns.Add(CreateValueTypeColumn());
			}
			if (Columns.FindByUId(new Guid("6ec5a0d1-c38b-4da8-80b7-25114b8736d5")) == null) {
				Columns.Add(CreateReferenceSchemaColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOwnerSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1eaec39e-dbba-4241-80e6-084c8a8bf98d"),
				Name = @"OwnerSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				ModifiedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0c037038-1544-42c9-a543-22bc346ad772"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				ModifiedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateValueTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("232c4528-76b5-4385-8e09-e19b66404db9"),
				Name = @"ValueType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				ModifiedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6ec5a0d1-c38b-4da8-80b7-25114b8736d5"),
				Name = @"ReferenceSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				ModifiedInSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
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
			return new Attribute(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Attribute_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AttributeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AttributeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"));
		}

		#endregion

	}

	#endregion

	#region Class: Attribute

	/// <summary>
	/// Checkbox.
	/// </summary>
	public class Attribute : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Attribute(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Attribute";
		}

		public Attribute(Attribute source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OwnerSchemaId {
			get {
				return GetTypedColumnValue<Guid>("OwnerSchemaId");
			}
			set {
				SetColumnValue("OwnerSchemaId", value);
				_ownerSchema = null;
			}
		}

		/// <exclude/>
		public string OwnerSchemaCaption {
			get {
				return GetTypedColumnValue<string>("OwnerSchemaCaption");
			}
			set {
				SetColumnValue("OwnerSchemaCaption", value);
				if (_ownerSchema != null) {
					_ownerSchema.Caption = value;
				}
			}
		}

		private SysSchema _ownerSchema;
		/// <summary>
		/// Schema.
		/// </summary>
		public SysSchema OwnerSchema {
			get {
				return _ownerSchema ??
					(_ownerSchema = LookupColumnEntities.GetEntity("OwnerSchema") as SysSchema);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Data type.
		/// </summary>
		public Guid ValueType {
			get {
				return GetTypedColumnValue<Guid>("ValueType");
			}
			set {
				SetColumnValue("ValueType", value);
			}
		}

		/// <exclude/>
		public Guid ReferenceSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ReferenceSchemaId");
			}
			set {
				SetColumnValue("ReferenceSchemaId", value);
				_referenceSchema = null;
			}
		}

		/// <exclude/>
		public string ReferenceSchemaCaption {
			get {
				return GetTypedColumnValue<string>("ReferenceSchemaCaption");
			}
			set {
				SetColumnValue("ReferenceSchemaCaption", value);
				if (_referenceSchema != null) {
					_referenceSchema.Caption = value;
				}
			}
		}

		private SysSchema _referenceSchema;
		/// <summary>
		/// Lookup.
		/// </summary>
		public SysSchema ReferenceSchema {
			get {
				return _referenceSchema ??
					(_referenceSchema = LookupColumnEntities.GetEntity("ReferenceSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Attribute_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AttributeDeleted", e);
			Deleting += (s, e) => ThrowEvent("AttributeDeleting", e);
			Inserted += (s, e) => ThrowEvent("AttributeInserted", e);
			Inserting += (s, e) => ThrowEvent("AttributeInserting", e);
			Saved += (s, e) => ThrowEvent("AttributeSaved", e);
			Saving += (s, e) => ThrowEvent("AttributeSaving", e);
			Validating += (s, e) => ThrowEvent("AttributeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Attribute(this);
		}

		#endregion

	}

	#endregion

	#region Class: Attribute_BaseEventsProcess

	/// <exclude/>
	public partial class Attribute_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Attribute
	{

		public Attribute_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Attribute_BaseEventsProcess";
			SchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe");
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

	#region Class: Attribute_BaseEventsProcess

	/// <exclude/>
	public class Attribute_BaseEventsProcess : Attribute_BaseEventsProcess<Attribute>
	{

		public Attribute_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Attribute_BaseEventsProcess

	public partial class Attribute_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AttributeEventsProcess

	/// <exclude/>
	public class AttributeEventsProcess : Attribute_BaseEventsProcess
	{

		public AttributeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

