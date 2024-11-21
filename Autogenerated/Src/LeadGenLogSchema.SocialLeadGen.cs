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

	#region Class: LeadGenLogSchema

	/// <exclude/>
	public class LeadGenLogSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LeadGenLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadGenLogSchema(LeadGenLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadGenLogSchema(LeadGenLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99");
			RealUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99");
			Name = "LeadGenLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9efd9284-398f-6278-342a-f1f1c0d6ed7f")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("941a092f-4e5e-cf29-dbcd-bfb060fe7a85")) == null) {
				Columns.Add(CreateLeadGenErrorTypeColumn());
			}
			if (Columns.FindByUId(new Guid("59dce265-e177-2b6d-6a23-bb9cc6b4929a")) == null) {
				Columns.Add(CreateIntegrationIdColumn());
			}
			if (Columns.FindByUId(new Guid("f9dcf5a9-aa43-4e9b-7509-61ba505b440d")) == null) {
				Columns.Add(CreateLeadGenLogTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9efd9284-398f-6278-342a-f1f1c0d6ed7f"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				ModifiedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenErrorTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("941a092f-4e5e-cf29-dbcd-bfb060fe7a85"),
				Name = @"LeadGenErrorType",
				ReferenceSchemaUId = new Guid("65568413-911a-4ea9-a3a1-d64037cfbaaf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				ModifiedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateIntegrationIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("59dce265-e177-2b6d-6a23-bb9cc6b4929a"),
				Name = @"IntegrationId",
				CreatedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				ModifiedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenLogTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f9dcf5a9-aa43-4e9b-7509-61ba505b440d"),
				Name = @"LeadGenLogType",
				ReferenceSchemaUId = new Guid("2d180cae-02a3-4027-b1b3-679e0fd39651"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				ModifiedInSchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadGenLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadGenLog_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadGenLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadGenLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c313d65d-d800-40e5-ba27-2f416894ae99"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenLog

	/// <summary>
	/// Логи лидогенерации.
	/// </summary>
	public class LeadGenLog : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LeadGenLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenLog";
		}

		public LeadGenLog(LeadGenLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <exclude/>
		public Guid LeadGenErrorTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenErrorTypeId");
			}
			set {
				SetColumnValue("LeadGenErrorTypeId", value);
				_leadGenErrorType = null;
			}
		}

		/// <exclude/>
		public string LeadGenErrorTypeName {
			get {
				return GetTypedColumnValue<string>("LeadGenErrorTypeName");
			}
			set {
				SetColumnValue("LeadGenErrorTypeName", value);
				if (_leadGenErrorType != null) {
					_leadGenErrorType.Name = value;
				}
			}
		}

		private LeadGenErrorType _leadGenErrorType;
		/// <summary>
		/// Error type.
		/// </summary>
		public LeadGenErrorType LeadGenErrorType {
			get {
				return _leadGenErrorType ??
					(_leadGenErrorType = LookupColumnEntities.GetEntity("LeadGenErrorType") as LeadGenErrorType);
			}
		}

		/// <summary>
		/// Id интеграции.
		/// </summary>
		public Guid IntegrationId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <exclude/>
		public Guid LeadGenLogTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenLogTypeId");
			}
			set {
				SetColumnValue("LeadGenLogTypeId", value);
				_leadGenLogType = null;
			}
		}

		/// <exclude/>
		public string LeadGenLogTypeName {
			get {
				return GetTypedColumnValue<string>("LeadGenLogTypeName");
			}
			set {
				SetColumnValue("LeadGenLogTypeName", value);
				if (_leadGenLogType != null) {
					_leadGenLogType.Name = value;
				}
			}
		}

		private LeadGenLogType _leadGenLogType;
		/// <summary>
		/// Тип лога.
		/// </summary>
		public LeadGenLogType LeadGenLogType {
			get {
				return _leadGenLogType ??
					(_leadGenLogType = LookupColumnEntities.GetEntity("LeadGenLogType") as LeadGenLogType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadGenLog_SocialLeadGenEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadGenLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenLog_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class LeadGenLog_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LeadGenLog
	{

		public LeadGenLog_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadGenLog_SocialLeadGenEventsProcess";
			SchemaUId = new Guid("c313d65d-d800-40e5-ba27-2f416894ae99");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c313d65d-d800-40e5-ba27-2f416894ae99");
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

	#region Class: LeadGenLog_SocialLeadGenEventsProcess

	/// <exclude/>
	public class LeadGenLog_SocialLeadGenEventsProcess : LeadGenLog_SocialLeadGenEventsProcess<LeadGenLog>
	{

		public LeadGenLog_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadGenLog_SocialLeadGenEventsProcess

	public partial class LeadGenLog_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadGenLogEventsProcess

	/// <exclude/>
	public class LeadGenLogEventsProcess : LeadGenLog_SocialLeadGenEventsProcess
	{

		public LeadGenLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

