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

	#region Class: AttributeReferenceSchemaSchema

	/// <exclude/>
	public class AttributeReferenceSchemaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AttributeReferenceSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AttributeReferenceSchemaSchema(AttributeReferenceSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AttributeReferenceSchemaSchema(AttributeReferenceSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
			RealUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
			Name = "AttributeReferenceSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("295c168c-9e91-4069-902f-549094289e50")) == null) {
				Columns.Add(CreateAttributeColumn());
			}
			if (Columns.FindByUId(new Guid("6a486d49-0085-453c-a57d-3cbc65619571")) == null) {
				Columns.Add(CreateReferenceSchemaColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAttributeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("295c168c-9e91-4069-902f-549094289e50"),
				Name = @"Attribute",
				ReferenceSchemaUId = new Guid("d37a89fc-7355-4900-aba8-94c22235a9fe"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb"),
				ModifiedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6a486d49-0085-453c-a57d-3cbc65619571"),
				Name = @"ReferenceSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb"),
				ModifiedInSchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AttributeReferenceSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AttributeReferenceSchema_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AttributeReferenceSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AttributeReferenceSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb"));
		}

		#endregion

	}

	#endregion

	#region Class: AttributeReferenceSchema

	/// <summary>
	/// Checkbox item.
	/// </summary>
	public class AttributeReferenceSchema : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AttributeReferenceSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AttributeReferenceSchema";
		}

		public AttributeReferenceSchema(AttributeReferenceSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid AttributeId {
			get {
				return GetTypedColumnValue<Guid>("AttributeId");
			}
			set {
				SetColumnValue("AttributeId", value);
				_attribute = null;
			}
		}

		/// <exclude/>
		public string AttributeName {
			get {
				return GetTypedColumnValue<string>("AttributeName");
			}
			set {
				SetColumnValue("AttributeName", value);
				if (_attribute != null) {
					_attribute.Name = value;
				}
			}
		}

		private Attribute _attribute;
		/// <summary>
		/// Checkbox.
		/// </summary>
		public Attribute Attribute {
			get {
				return _attribute ??
					(_attribute = LookupColumnEntities.GetEntity("Attribute") as Attribute);
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
		/// Schema.
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
			var process = new AttributeReferenceSchema_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AttributeReferenceSchemaDeleted", e);
			Deleting += (s, e) => ThrowEvent("AttributeReferenceSchemaDeleting", e);
			Inserted += (s, e) => ThrowEvent("AttributeReferenceSchemaInserted", e);
			Inserting += (s, e) => ThrowEvent("AttributeReferenceSchemaInserting", e);
			Saved += (s, e) => ThrowEvent("AttributeReferenceSchemaSaved", e);
			Saving += (s, e) => ThrowEvent("AttributeReferenceSchemaSaving", e);
			Validating += (s, e) => ThrowEvent("AttributeReferenceSchemaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AttributeReferenceSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: AttributeReferenceSchema_BaseEventsProcess

	/// <exclude/>
	public partial class AttributeReferenceSchema_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AttributeReferenceSchema
	{

		public AttributeReferenceSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AttributeReferenceSchema_BaseEventsProcess";
			SchemaUId = new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab5bc934-84fb-4f7b-8744-9e4f1a347fbb");
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

	#region Class: AttributeReferenceSchema_BaseEventsProcess

	/// <exclude/>
	public class AttributeReferenceSchema_BaseEventsProcess : AttributeReferenceSchema_BaseEventsProcess<AttributeReferenceSchema>
	{

		public AttributeReferenceSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AttributeReferenceSchema_BaseEventsProcess

	public partial class AttributeReferenceSchema_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AttributeReferenceSchemaEventsProcess

	/// <exclude/>
	public class AttributeReferenceSchemaEventsProcess : AttributeReferenceSchema_BaseEventsProcess
	{

		public AttributeReferenceSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

