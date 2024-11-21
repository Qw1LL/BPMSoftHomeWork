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

	#region Class: CompletenessSchema

	/// <exclude/>
	public class CompletenessSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CompletenessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CompletenessSchema(CompletenessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CompletenessSchema(CompletenessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0");
			RealUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0");
			Name = "Completeness";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce");
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
			if (Columns.FindByUId(new Guid("197d5ede-8749-4adb-878e-76fc19282593")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("943f5f8c-cb2c-4146-a580-46a8633d0e96")) == null) {
				Columns.Add(CreateTypeColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("8394ccd2-d73c-4004-af96-27ef6ac8a821")) == null) {
				Columns.Add(CreateTypeColumnValueColumn());
			}
			if (Columns.FindByUId(new Guid("e53c3bbf-037b-49cc-8fe4-2e07388512a8")) == null) {
				Columns.Add(CreateResultColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("73402440-6a06-4811-9143-8e425be82aad")) == null) {
				Columns.Add(CreateScaleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9d9a6e26-772b-423f-a126-4479f11fce2d"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				ModifiedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("197d5ede-8749-4adb-878e-76fc19282593"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				ModifiedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("943f5f8c-cb2c-4146-a580-46a8633d0e96"),
				Name = @"TypeColumnName",
				CreatedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				ModifiedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8394ccd2-d73c-4004-af96-27ef6ac8a821"),
				Name = @"TypeColumnValue",
				CreatedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				ModifiedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f")
			};
		}

		protected virtual EntitySchemaColumn CreateResultColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("e53c3bbf-037b-49cc-8fe4-2e07388512a8"),
				Name = @"ResultColumnName",
				CreatedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				ModifiedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				CreatedInPackageId = new Guid("37401b15-d755-4de2-9a31-d493a123233f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"Completeness"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateScaleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("73402440-6a06-4811-9143-8e425be82aad"),
				Name = @"Scale",
				CreatedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				ModifiedInSchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Completeness(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Completeness_CompletenessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CompletenessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CompletenessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0"));
		}

		#endregion

	}

	#endregion

	#region Class: Completeness

	/// <summary>
	/// Data entry compliance.
	/// </summary>
	public class Completeness : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Completeness(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Completeness";
		}

		public Completeness(Completeness source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Section.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Schema.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <summary>
		/// Type column name.
		/// </summary>
		public string TypeColumnName {
			get {
				return GetTypedColumnValue<string>("TypeColumnName");
			}
			set {
				SetColumnValue("TypeColumnName", value);
			}
		}

		/// <summary>
		/// Type column value.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <summary>
		/// Resulting column name.
		/// </summary>
		public string ResultColumnName {
			get {
				return GetTypedColumnValue<string>("ResultColumnName");
			}
			set {
				SetColumnValue("ResultColumnName", value);
			}
		}

		/// <summary>
		/// Scale.
		/// </summary>
		public string Scale {
			get {
				return GetTypedColumnValue<string>("Scale");
			}
			set {
				SetColumnValue("Scale", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Completeness_CompletenessEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CompletenessDeleted", e);
			Validating += (s, e) => ThrowEvent("CompletenessValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Completeness(this);
		}

		#endregion

	}

	#endregion

	#region Class: Completeness_CompletenessEventsProcess

	/// <exclude/>
	public partial class Completeness_CompletenessEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Completeness
	{

		public Completeness_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Completeness_CompletenessEventsProcess";
			SchemaUId = new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ebed4408-f780-4a36-9e21-68c7e20c04e0");
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

	#region Class: Completeness_CompletenessEventsProcess

	/// <exclude/>
	public class Completeness_CompletenessEventsProcess : Completeness_CompletenessEventsProcess<Completeness>
	{

		public Completeness_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Completeness_CompletenessEventsProcess

	public partial class Completeness_CompletenessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CompletenessEventsProcess

	/// <exclude/>
	public class CompletenessEventsProcess : Completeness_CompletenessEventsProcess
	{

		public CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

