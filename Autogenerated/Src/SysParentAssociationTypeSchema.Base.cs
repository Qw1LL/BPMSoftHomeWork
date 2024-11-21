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

	#region Class: SysParentAssociationTypeSchema

	/// <exclude/>
	public class SysParentAssociationTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysParentAssociationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysParentAssociationTypeSchema(SysParentAssociationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysParentAssociationTypeSchema(SysParentAssociationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d");
			RealUId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d");
			Name = "SysParentAssociationType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			if (Columns.FindByUId(new Guid("d86d9044-f2c1-4632-9909-5aa930408904")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("de2dd8e2-7d1d-4259-a594-6b503dd78b5b"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d"),
				ModifiedInSchemaUId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d86d9044-f2c1-4632-9909-5aa930408904"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d"),
				ModifiedInSchemaUId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysParentAssociationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysParentAssociationType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysParentAssociationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysParentAssociationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysParentAssociationType

	/// <summary>
	/// Parent connection type.
	/// </summary>
	public class SysParentAssociationType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysParentAssociationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysParentAssociationType";
		}

		public SysParentAssociationType(SysParentAssociationType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysParentAssociationType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysParentAssociationTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysParentAssociationTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysParentAssociationTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("SysParentAssociationTypeInserting", e);
			Saved += (s, e) => ThrowEvent("SysParentAssociationTypeSaved", e);
			Saving += (s, e) => ThrowEvent("SysParentAssociationTypeSaving", e);
			Validating += (s, e) => ThrowEvent("SysParentAssociationTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysParentAssociationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysParentAssociationType_BaseEventsProcess

	/// <exclude/>
	public partial class SysParentAssociationType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysParentAssociationType
	{

		public SysParentAssociationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysParentAssociationType_BaseEventsProcess";
			SchemaUId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d");
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

	#region Class: SysParentAssociationType_BaseEventsProcess

	/// <exclude/>
	public class SysParentAssociationType_BaseEventsProcess : SysParentAssociationType_BaseEventsProcess<SysParentAssociationType>
	{

		public SysParentAssociationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysParentAssociationType_BaseEventsProcess

	public partial class SysParentAssociationType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysParentAssociationTypeEventsProcess

	/// <exclude/>
	public class SysParentAssociationTypeEventsProcess : SysParentAssociationType_BaseEventsProcess
	{

		public SysParentAssociationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

