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

	#region Class: SysProcessDisabledSchema

	/// <exclude/>
	public class SysProcessDisabledSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysProcessDisabledSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessDisabledSchema(SysProcessDisabledSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessDisabledSchema(SysProcessDisabledSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateSysProcessDisabled_SysSchemaIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("f23d1396-340c-4e55-9ad9-828da4c007fe");
			index.Name = "SysProcessDisabled_SysSchemaId";
			index.CreatedInSchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f");
			index.ModifiedInSchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn sysSchemaIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fff8496c-c9f5-4002-bc81-50534f4a3868"),
				ColumnUId = new Guid("56f69500-7667-4d74-9b5f-631c0158d1d3"),
				CreatedInSchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f"),
				ModifiedInSchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysSchemaIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f");
			RealUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f");
			Name = "SysProcessDisabled";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("280c479b-4214-48d2-8ad6-756cf8c224d7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("56f69500-7667-4d74-9b5f-631c0158d1d3")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("56f69500-7667-4d74-9b5f-631c0158d1d3"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f"),
				ModifiedInSchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f"),
				CreatedInPackageId = new Guid("280c479b-4214-48d2-8ad6-756cf8c224d7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateSysProcessDisabled_SysSchemaIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessDisabled(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessDisabled_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessDisabledSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessDisabledSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c27393c6-3bb9-47aa-a492-30d76109031f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessDisabled

	/// <summary>
	/// Disabled processes.
	/// </summary>
	public class SysProcessDisabled : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysProcessDisabled(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessDisabled";
		}

		public SysProcessDisabled(SysProcessDisabled source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Process.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessDisabled_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessDisabledDeleted", e);
			Validating += (s, e) => ThrowEvent("SysProcessDisabledValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessDisabled(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessDisabled_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessDisabled_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysProcessDisabled
	{

		public SysProcessDisabled_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessDisabled_BaseEventsProcess";
			SchemaUId = new Guid("c27393c6-3bb9-47aa-a492-30d76109031f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c27393c6-3bb9-47aa-a492-30d76109031f");
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

	#region Class: SysProcessDisabled_BaseEventsProcess

	/// <exclude/>
	public class SysProcessDisabled_BaseEventsProcess : SysProcessDisabled_BaseEventsProcess<SysProcessDisabled>
	{

		public SysProcessDisabled_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessDisabled_BaseEventsProcess

	public partial class SysProcessDisabled_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessDisabledEventsProcess

	/// <exclude/>
	public class SysProcessDisabledEventsProcess : SysProcessDisabled_BaseEventsProcess
	{

		public SysProcessDisabledEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

