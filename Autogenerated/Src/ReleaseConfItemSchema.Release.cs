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

	#region Class: ReleaseConfItemSchema

	/// <exclude/>
	public class ReleaseConfItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ReleaseConfItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseConfItemSchema(ReleaseConfItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseConfItemSchema(ReleaseConfItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a");
			RealUId = new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a");
			Name = "ReleaseConfItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8f6c7b14-ae87-449c-8189-cf99b9eef0e5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b3794b39-2815-4cc7-9f8c-fcf8c64d0bb6")) == null) {
				Columns.Add(CreateReleaseColumn());
			}
			if (Columns.FindByUId(new Guid("c006a261-54f3-4ff9-a2b1-f4ac0d652751")) == null) {
				Columns.Add(CreateConfItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateReleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b3794b39-2815-4cc7-9f8c-fcf8c64d0bb6"),
				Name = @"Release",
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a"),
				ModifiedInSchemaUId = new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a"),
				CreatedInPackageId = new Guid("8f6c7b14-ae87-449c-8189-cf99b9eef0e5")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c006a261-54f3-4ff9-a2b1-f4ac0d652751"),
				Name = @"ConfItem",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a"),
				ModifiedInSchemaUId = new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a"),
				CreatedInPackageId = new Guid("8f6c7b14-ae87-449c-8189-cf99b9eef0e5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReleaseConfItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseConfItem_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseConfItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseConfItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseConfItem

	/// <summary>
	/// Конфигурационные единицы релиза.
	/// </summary>
	public class ReleaseConfItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ReleaseConfItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseConfItem";
		}

		public ReleaseConfItem(ReleaseConfItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релиз.
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = LookupColumnEntities.GetEntity("Release") as Release);
			}
		}

		/// <exclude/>
		public Guid ConfItemId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemId");
			}
			set {
				SetColumnValue("ConfItemId", value);
				_confItem = null;
			}
		}

		/// <exclude/>
		public string ConfItemName {
			get {
				return GetTypedColumnValue<string>("ConfItemName");
			}
			set {
				SetColumnValue("ConfItemName", value);
				if (_confItem != null) {
					_confItem.Name = value;
				}
			}
		}

		private ConfItem _confItem;
		/// <summary>
		/// Конфигурационная единица.
		/// </summary>
		public ConfItem ConfItem {
			get {
				return _confItem ??
					(_confItem = LookupColumnEntities.GetEntity("ConfItem") as ConfItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReleaseConfItem_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseConfItemDeleted", e);
			Validating += (s, e) => ThrowEvent("ReleaseConfItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReleaseConfItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseConfItem_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseConfItem_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ReleaseConfItem
	{

		public ReleaseConfItem_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseConfItem_ReleaseEventsProcess";
			SchemaUId = new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("713e5ffe-9aa5-4697-8d21-4238ef41277a");
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

	#region Class: ReleaseConfItem_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseConfItem_ReleaseEventsProcess : ReleaseConfItem_ReleaseEventsProcess<ReleaseConfItem>
	{

		public ReleaseConfItem_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseConfItem_ReleaseEventsProcess

	public partial class ReleaseConfItem_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseConfItemEventsProcess

	/// <exclude/>
	public class ReleaseConfItemEventsProcess : ReleaseConfItem_ReleaseEventsProcess
	{

		public ReleaseConfItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

