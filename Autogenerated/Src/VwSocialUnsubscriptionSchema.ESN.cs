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

	#region Class: VwSocialUnsubscriptionSchema

	/// <exclude/>
	public class VwSocialUnsubscriptionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSocialUnsubscriptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSocialUnsubscriptionSchema(VwSocialUnsubscriptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSocialUnsubscriptionSchema(VwSocialUnsubscriptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25");
			RealUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25");
			Name = "VwSocialUnsubscription";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66326954-397a-44f2-be96-bb060853af34");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("144a4778-ecc9-43f4-89ba-3f5583f46f2b")) == null) {
				Columns.Add(CreateSocialMessageColumn());
			}
			if (Columns.FindByUId(new Guid("03a9298f-38ac-4e39-9417-191b6a6afcb7")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("ebc174eb-67ac-4ddf-9772-4f6a7009909b")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSocialMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("144a4778-ecc9-43f4-89ba-3f5583f46f2b"),
				Name = @"SocialMessage",
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25"),
				ModifiedInSchemaUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25"),
				CreatedInPackageId = new Guid("66326954-397a-44f2-be96-bb060853af34")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("03a9298f-38ac-4e39-9417-191b6a6afcb7"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25"),
				ModifiedInSchemaUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25"),
				CreatedInPackageId = new Guid("66326954-397a-44f2-be96-bb060853af34")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ebc174eb-67ac-4ddf-9772-4f6a7009909b"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25"),
				ModifiedInSchemaUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25"),
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
			return new VwSocialUnsubscription(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSocialUnsubscription_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSocialUnsubscriptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSocialUnsubscriptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSocialUnsubscription

	/// <summary>
	/// View of unsubscriptions (Mobile).
	/// </summary>
	public class VwSocialUnsubscription : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSocialUnsubscription(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSocialUnsubscription";
		}

		public VwSocialUnsubscription(VwSocialUnsubscription source)
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
			var process = new VwSocialUnsubscription_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSocialUnsubscriptionDeleted", e);
			Validating += (s, e) => ThrowEvent("VwSocialUnsubscriptionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSocialUnsubscription(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSocialUnsubscription_ESNEventsProcess

	/// <exclude/>
	public partial class VwSocialUnsubscription_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSocialUnsubscription
	{

		public VwSocialUnsubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSocialUnsubscription_ESNEventsProcess";
			SchemaUId = new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("81926e4f-f7d8-46d5-9ca0-0781c3383d25");
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

	#region Class: VwSocialUnsubscription_ESNEventsProcess

	/// <exclude/>
	public class VwSocialUnsubscription_ESNEventsProcess : VwSocialUnsubscription_ESNEventsProcess<VwSocialUnsubscription>
	{

		public VwSocialUnsubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSocialUnsubscription_ESNEventsProcess

	public partial class VwSocialUnsubscription_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSocialUnsubscriptionEventsProcess

	/// <exclude/>
	public class VwSocialUnsubscriptionEventsProcess : VwSocialUnsubscription_ESNEventsProcess
	{

		public VwSocialUnsubscriptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

