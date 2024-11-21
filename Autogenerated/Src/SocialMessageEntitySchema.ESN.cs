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

	#region Class: SocialMessageEntitySchema

	/// <exclude/>
	public class SocialMessageEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialMessageEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialMessageEntitySchema(SocialMessageEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialMessageEntitySchema(SocialMessageEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			RealUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			Name = "SocialMessageEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("320e2849-1819-450c-be23-b6f3225a54f3")) == null) {
				Columns.Add(CreateSocialMessageColumn());
			}
			if (Columns.FindByUId(new Guid("1249c7cf-5887-4799-af67-f8a88fcdcab8")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("6146d0e5-3b08-4967-a643-5e2c5b4d0c8d")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSocialMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("320e2849-1819-450c-be23-b6f3225a54f3"),
				Name = @"SocialMessage",
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922"),
				ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1249c7cf-5887-4799-af67-f8a88fcdcab8"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922"),
				ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6146d0e5-3b08-4967-a643-5e2c5b4d0c8d"),
				Name = @"EntityId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922"),
				ModifiedInSchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialMessageEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialMessageEntity_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialMessageEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialMessageEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessageEntity

	/// <summary>
	/// Object in message/comment.
	/// </summary>
	public class SocialMessageEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialMessageEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialMessageEntity";
		}

		public SocialMessageEntity(SocialMessageEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SocialMessageId {
			get {
				return GetTypedColumnValue<Guid>("SocialMessageId");
			}
			set {
				SetColumnValue("SocialMessageId", value);
				_socialMessage = null;
			}
		}

		/// <exclude/>
		public string SocialMessageMessage {
			get {
				return GetTypedColumnValue<string>("SocialMessageMessage");
			}
			set {
				SetColumnValue("SocialMessageMessage", value);
				if (_socialMessage != null) {
					_socialMessage.Message = value;
				}
			}
		}

		private SocialMessage _socialMessage;
		/// <summary>
		/// Message/comment.
		/// </summary>
		public SocialMessage SocialMessage {
			get {
				return _socialMessage ??
					(_socialMessage = LookupColumnEntities.GetEntity("SocialMessage") as SocialMessage);
			}
		}

		/// <summary>
		/// Schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Object instance.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialMessageEntity_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialMessageEntityDeleted", e);
			Inserting += (s, e) => ThrowEvent("SocialMessageEntityInserting", e);
			Validating += (s, e) => ThrowEvent("SocialMessageEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialMessageEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessageEntity_ESNEventsProcess

	/// <exclude/>
	public partial class SocialMessageEntity_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialMessageEntity
	{

		public SocialMessageEntity_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialMessageEntity_ESNEventsProcess";
			SchemaUId = new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1f59318b-e3d8-4b04-a5ae-b5c1623cf922");
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

	#region Class: SocialMessageEntity_ESNEventsProcess

	/// <exclude/>
	public class SocialMessageEntity_ESNEventsProcess : SocialMessageEntity_ESNEventsProcess<SocialMessageEntity>
	{

		public SocialMessageEntity_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialMessageEntity_ESNEventsProcess

	public partial class SocialMessageEntity_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialMessageEntityEventsProcess

	/// <exclude/>
	public class SocialMessageEntityEventsProcess : SocialMessageEntity_ESNEventsProcess
	{

		public SocialMessageEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

