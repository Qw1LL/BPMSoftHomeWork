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

	#region Class: VwSocialSubscriptionSchema

	/// <exclude/>
	public class VwSocialSubscriptionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSocialSubscriptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSocialSubscriptionSchema(VwSocialSubscriptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSocialSubscriptionSchema(VwSocialSubscriptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a");
			RealUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a");
			Name = "VwSocialSubscription";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66326954-397a-44f2-be96-bb060853af34");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a27e6ade-52ed-43f9-ba13-49d804aef06e")) == null) {
				Columns.Add(CreateSocialMessageColumn());
			}
			if (Columns.FindByUId(new Guid("96ad580b-d6c3-4de0-9ede-22b495d272d2")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("23d60a8b-00f0-440a-8199-033bc90139de")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSocialMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a27e6ade-52ed-43f9-ba13-49d804aef06e"),
				Name = @"SocialMessage",
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a"),
				ModifiedInSchemaUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a"),
				CreatedInPackageId = new Guid("66326954-397a-44f2-be96-bb060853af34")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("96ad580b-d6c3-4de0-9ede-22b495d272d2"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a"),
				ModifiedInSchemaUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a"),
				CreatedInPackageId = new Guid("66326954-397a-44f2-be96-bb060853af34")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("23d60a8b-00f0-440a-8199-033bc90139de"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a"),
				ModifiedInSchemaUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a"),
				CreatedInPackageId = new Guid("66326954-397a-44f2-be96-bb060853af34")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSocialSubscription(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSocialSubscription_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSocialSubscriptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSocialSubscriptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSocialSubscription

	/// <summary>
	/// View of subscriptions (Mobile).
	/// </summary>
	public class VwSocialSubscription : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSocialSubscription(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSocialSubscription";
		}

		public VwSocialSubscription(VwSocialSubscription source)
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
		/// SocialMessage.
		/// </summary>
		public SocialMessage SocialMessage {
			get {
				return _socialMessage ??
					(_socialMessage = LookupColumnEntities.GetEntity("SocialMessage") as SocialMessage);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// SysAdminUnit.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// EntityId.
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
			var process = new VwSocialSubscription_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSocialSubscriptionDeleted", e);
			Validating += (s, e) => ThrowEvent("VwSocialSubscriptionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSocialSubscription(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSocialSubscription_ESNEventsProcess

	/// <exclude/>
	public partial class VwSocialSubscription_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSocialSubscription
	{

		public VwSocialSubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSocialSubscription_ESNEventsProcess";
			SchemaUId = new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6c220a57-9656-465d-a2a4-a4dd8b4bc79a");
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

	#region Class: VwSocialSubscription_ESNEventsProcess

	/// <exclude/>
	public class VwSocialSubscription_ESNEventsProcess : VwSocialSubscription_ESNEventsProcess<VwSocialSubscription>
	{

		public VwSocialSubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSocialSubscription_ESNEventsProcess

	public partial class VwSocialSubscription_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSocialSubscriptionEventsProcess

	/// <exclude/>
	public class VwSocialSubscriptionEventsProcess : VwSocialSubscription_ESNEventsProcess
	{

		public VwSocialSubscriptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

