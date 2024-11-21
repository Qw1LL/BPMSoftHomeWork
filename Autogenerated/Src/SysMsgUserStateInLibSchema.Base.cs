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

	#region Class: SysMsgUserStateInLibSchema

	/// <exclude/>
	public class SysMsgUserStateInLibSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysMsgUserStateInLibSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMsgUserStateInLibSchema(SysMsgUserStateInLibSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMsgUserStateInLibSchema(SysMsgUserStateInLibSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
			RealUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
			Name = "SysMsgUserStateInLib";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c8b8a0a3-cd6a-402d-8916-091e2b69a857")) == null) {
				Columns.Add(CreateSysMsgLibColumn());
			}
			if (Columns.FindByUId(new Guid("d12bbe21-ad0a-4533-9df4-b70e9fcaf440")) == null) {
				Columns.Add(CreateSysMsgUserStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysMsgLibColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c8b8a0a3-cd6a-402d-8916-091e2b69a857"),
				Name = @"SysMsgLib",
				ReferenceSchemaUId = new Guid("89b9f170-8aed-4f41-8659-c787b50df837"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf"),
				ModifiedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysMsgUserStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d12bbe21-ad0a-4533-9df4-b70e9fcaf440"),
				Name = @"SysMsgUserState",
				ReferenceSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf"),
				ModifiedInSchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf"),
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
			return new SysMsgUserStateInLib(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMsgUserStateInLib_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMsgUserStateInLibSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMsgUserStateInLibSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("da807457-7105-4735-84f0-8915c70fe5bf"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserStateInLib

	/// <summary>
	/// User status in message exchange library.
	/// </summary>
	public class SysMsgUserStateInLib : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysMsgUserStateInLib(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserStateInLib";
		}

		public SysMsgUserStateInLib(SysMsgUserStateInLib source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysMsgLibId {
			get {
				return GetTypedColumnValue<Guid>("SysMsgLibId");
			}
			set {
				SetColumnValue("SysMsgLibId", value);
				_sysMsgLib = null;
			}
		}

		/// <exclude/>
		public string SysMsgLibName {
			get {
				return GetTypedColumnValue<string>("SysMsgLibName");
			}
			set {
				SetColumnValue("SysMsgLibName", value);
				if (_sysMsgLib != null) {
					_sysMsgLib.Name = value;
				}
			}
		}

		private SysMsgLib _sysMsgLib;
		/// <summary>
		/// Message exchange library.
		/// </summary>
		public SysMsgLib SysMsgLib {
			get {
				return _sysMsgLib ??
					(_sysMsgLib = LookupColumnEntities.GetEntity("SysMsgLib") as SysMsgLib);
			}
		}

		/// <exclude/>
		public Guid SysMsgUserStateId {
			get {
				return GetTypedColumnValue<Guid>("SysMsgUserStateId");
			}
			set {
				SetColumnValue("SysMsgUserStateId", value);
				_sysMsgUserState = null;
			}
		}

		/// <exclude/>
		public string SysMsgUserStateName {
			get {
				return GetTypedColumnValue<string>("SysMsgUserStateName");
			}
			set {
				SetColumnValue("SysMsgUserStateName", value);
				if (_sysMsgUserState != null) {
					_sysMsgUserState.Name = value;
				}
			}
		}

		private SysMsgUserState _sysMsgUserState;
		/// <summary>
		/// User status.
		/// </summary>
		public SysMsgUserState SysMsgUserState {
			get {
				return _sysMsgUserState ??
					(_sysMsgUserState = LookupColumnEntities.GetEntity("SysMsgUserState") as SysMsgUserState);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMsgUserStateInLib_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysMsgUserStateInLibDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysMsgUserStateInLibDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysMsgUserStateInLibInserted", e);
			Inserting += (s, e) => ThrowEvent("SysMsgUserStateInLibInserting", e);
			Saved += (s, e) => ThrowEvent("SysMsgUserStateInLibSaved", e);
			Saving += (s, e) => ThrowEvent("SysMsgUserStateInLibSaving", e);
			Validating += (s, e) => ThrowEvent("SysMsgUserStateInLibValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysMsgUserStateInLib(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserStateInLib_BaseEventsProcess

	/// <exclude/>
	public partial class SysMsgUserStateInLib_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysMsgUserStateInLib
	{

		public SysMsgUserStateInLib_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMsgUserStateInLib_BaseEventsProcess";
			SchemaUId = new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("da807457-7105-4735-84f0-8915c70fe5bf");
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

	#region Class: SysMsgUserStateInLib_BaseEventsProcess

	/// <exclude/>
	public class SysMsgUserStateInLib_BaseEventsProcess : SysMsgUserStateInLib_BaseEventsProcess<SysMsgUserStateInLib>
	{

		public SysMsgUserStateInLib_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMsgUserStateInLib_BaseEventsProcess

	public partial class SysMsgUserStateInLib_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysMsgUserStateInLibEventsProcess

	/// <exclude/>
	public class SysMsgUserStateInLibEventsProcess : SysMsgUserStateInLib_BaseEventsProcess
	{

		public SysMsgUserStateInLibEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

