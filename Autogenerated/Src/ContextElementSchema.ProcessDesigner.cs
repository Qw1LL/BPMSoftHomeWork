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

	#region Class: ContextElementSchema

	/// <exclude/>
	public class ContextElementSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContextElementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContextElementSchema(ContextElementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContextElementSchema(ContextElementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			RealUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			Name = "ContextElement";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
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
			if (Columns.FindByUId(new Guid("baf2be39-2fd5-487e-8864-be2cdf31791d")) == null) {
				Columns.Add(CreateClientUnitSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5cf57de2-8f47-4d48-90ea-07414707b694")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("cd6ce280-8f61-4f67-90e4-6b6ed9da6d0f")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			column.CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			column.CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			column.CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			column.CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			column.CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			column.CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20");
			return column;
		}

		protected virtual EntitySchemaColumn CreateClientUnitSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("baf2be39-2fd5-487e-8864-be2cdf31791d"),
				Name = @"ClientUnitSchemaUId",
				CreatedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1960723b-09ff-462a-adad-d8fd2195ac69"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5cf57de2-8f47-4d48-90ea-07414707b694"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				CreatedInPackageId = new Guid("9cb36bb0-ef94-4bd9-b530-e0e0d5d64a20"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cd6ce280-8f61-4f67-90e4-6b6ed9da6d0f"),
				Name = @"IsDefault",
				CreatedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				ModifiedInSchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"),
				CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContextElement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContextElement_ProcessDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContextElementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContextElementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4"));
		}

		#endregion

	}

	#endregion

	#region Class: ContextElement

	/// <summary>
	/// Context item.
	/// </summary>
	public class ContextElement : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContextElement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContextElement";
		}

		public ContextElement(ContextElement source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Widget module client schema UId.
		/// </summary>
		public Guid ClientUnitSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ClientUnitSchemaUId");
			}
			set {
				SetColumnValue("ClientUnitSchemaUId", value);
			}
		}

		/// <summary>
		/// Name.
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
		/// Show by default.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContextElement_ProcessDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContextElementDeleted", e);
			Inserting += (s, e) => ThrowEvent("ContextElementInserting", e);
			Validating += (s, e) => ThrowEvent("ContextElementValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContextElement(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContextElement_ProcessDesignerEventsProcess

	/// <exclude/>
	public partial class ContextElement_ProcessDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContextElement
	{

		public ContextElement_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContextElement_ProcessDesignerEventsProcess";
			SchemaUId = new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("de1889aa-69c4-4a40-b06e-88d03365e9d4");
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

	#region Class: ContextElement_ProcessDesignerEventsProcess

	/// <exclude/>
	public class ContextElement_ProcessDesignerEventsProcess : ContextElement_ProcessDesignerEventsProcess<ContextElement>
	{

		public ContextElement_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContextElement_ProcessDesignerEventsProcess

	public partial class ContextElement_ProcessDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContextElementEventsProcess

	/// <exclude/>
	public class ContextElementEventsProcess : ContextElement_ProcessDesignerEventsProcess
	{

		public ContextElementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

