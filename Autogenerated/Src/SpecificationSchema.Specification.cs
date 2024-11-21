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

	#region Class: Specification_Specification_BPMSoftSchema

	/// <exclude/>
	public class Specification_Specification_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Specification_Specification_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Specification_Specification_BPMSoftSchema(Specification_Specification_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Specification_Specification_BPMSoftSchema(Specification_Specification_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			RealUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			Name = "Specification_Specification_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fb8e1b40-dec1-4ea7-851d-4225fc9ead06")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("d1509949-c97b-4560-8b90-f257f9511d14")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3c956bc9-fc5b-422b-9eec-2d3806df2e5b"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb8e1b40-dec1-4ea7-851d-4225fc9ead06"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("787ae6a1-f727-4c4e-964a-c09e24083810"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d1509949-c97b-4560-8b90-f257f9511d14"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				ModifiedInSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Specification_Specification_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Specification_SpecificationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Specification_Specification_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Specification_Specification_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"));
		}

		#endregion

	}

	#endregion

	#region Class: Specification_Specification_BPMSoft

	/// <summary>
	/// Характеристика.
	/// </summary>
	public class Specification_Specification_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Specification_Specification_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Specification_Specification_BPMSoft";
		}

		public Specification_Specification_BPMSoft(Specification_Specification_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SpecificationType _type;
		/// <summary>
		/// Тип значения.
		/// </summary>
		public SpecificationType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SpecificationType);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Specification_SpecificationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Specification_Specification_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Specification_Specification_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Specification_Specification_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Specification_Specification_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Specification_SpecificationEventsProcess

	/// <exclude/>
	public partial class Specification_SpecificationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Specification_Specification_BPMSoft
	{

		public Specification_SpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Specification_SpecificationEventsProcess";
			SchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef");
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

	#region Class: Specification_SpecificationEventsProcess

	/// <exclude/>
	public class Specification_SpecificationEventsProcess : Specification_SpecificationEventsProcess<Specification_Specification_BPMSoft>
	{

		public Specification_SpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Specification_SpecificationEventsProcess

	public partial class Specification_SpecificationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

