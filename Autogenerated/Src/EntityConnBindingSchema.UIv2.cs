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

	#region Class: EntityConnBindingSchema

	/// <exclude/>
	public class EntityConnBindingSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EntityConnBindingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EntityConnBindingSchema(EntityConnBindingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EntityConnBindingSchema(EntityConnBindingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1");
			RealUId = new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1");
			Name = "EntityConnBinding";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("808b22f9-982c-4559-bdd8-9644b07fb5aa");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("940f3fba-0b00-4792-be9e-0de8ca4a86e9")) == null) {
				Columns.Add(CreateEntityConnectionParentIdColumn());
			}
			if (Columns.FindByUId(new Guid("d8d3579c-43bc-46d9-9638-d392b54bac53")) == null) {
				Columns.Add(CreateEntityConnectionChildIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntityConnectionParentIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("940f3fba-0b00-4792-be9e-0de8ca4a86e9"),
				Name = @"EntityConnectionParentId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1"),
				ModifiedInSchemaUId = new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityConnectionChildIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d8d3579c-43bc-46d9-9638-d392b54bac53"),
				Name = @"EntityConnectionChildId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1"),
				ModifiedInSchemaUId = new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EntityConnBinding(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EntityConnBinding_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new EntityConnBindingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EntityConnBindingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1"));
		}

		#endregion

	}

	#endregion

	#region Class: EntityConnBinding

	/// <summary>
	/// EntityConnection resolution table.
	/// </summary>
	public class EntityConnBinding : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EntityConnBinding(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntityConnBinding";
		}

		public EntityConnBinding(EntityConnBinding source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Parent Id for connection .
		/// </summary>
		public Guid EntityConnectionParentId {
			get {
				return GetTypedColumnValue<Guid>("EntityConnectionParentId");
			}
			set {
				SetColumnValue("EntityConnectionParentId", value);
			}
		}

		/// <summary>
		/// Id for connection.
		/// </summary>
		public Guid EntityConnectionChildId {
			get {
				return GetTypedColumnValue<Guid>("EntityConnectionChildId");
			}
			set {
				SetColumnValue("EntityConnectionChildId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EntityConnBinding_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EntityConnBindingDeleted", e);
			Validating += (s, e) => ThrowEvent("EntityConnBindingValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EntityConnBinding(this);
		}

		#endregion

	}

	#endregion

	#region Class: EntityConnBinding_UIv2EventsProcess

	/// <exclude/>
	public partial class EntityConnBinding_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EntityConnBinding
	{

		public EntityConnBinding_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EntityConnBinding_UIv2EventsProcess";
			SchemaUId = new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cb0d1e59-1166-4bcc-80df-7d2747300fd1");
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

	#region Class: EntityConnBinding_UIv2EventsProcess

	/// <exclude/>
	public class EntityConnBinding_UIv2EventsProcess : EntityConnBinding_UIv2EventsProcess<EntityConnBinding>
	{

		public EntityConnBinding_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EntityConnBinding_UIv2EventsProcess

	public partial class EntityConnBinding_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EntityConnBindingEventsProcess

	/// <exclude/>
	public class EntityConnBindingEventsProcess : EntityConnBinding_UIv2EventsProcess
	{

		public EntityConnBindingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

