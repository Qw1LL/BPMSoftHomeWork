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

	#region Class: EmailRelationSchema

	/// <exclude/>
	public class EmailRelationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailRelationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailRelationSchema(EmailRelationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailRelationSchema(EmailRelationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f");
			RealUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f");
			Name = "EmailRelation";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("da888dec-52da-4214-a124-4f0c679b3ce5")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("87c0af40-0cfb-407e-8832-5278747bbe03")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5b69c23d-ab85-4c75-8621-a4d22d1d44b3")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("da888dec-52da-4214-a124-4f0c679b3ce5"),
				Name = @"Email",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f"),
				ModifiedInSchemaUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("87c0af40-0cfb-407e-8832-5278747bbe03"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f"),
				ModifiedInSchemaUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f"),
				CreatedInPackageId = new Guid("93ee616e-e44a-4ac3-9178-cdca5a3a4303")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5b69c23d-ab85-4c75-8621-a4d22d1d44b3"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f"),
				ModifiedInSchemaUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f"),
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
			return new EmailRelation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailRelation_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailRelationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailRelationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailRelation

	/// <summary>
	/// EmailRelation.
	/// </summary>
	public class EmailRelation : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailRelation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailRelation";
		}

		public EmailRelation(EmailRelation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EmailId {
			get {
				return GetTypedColumnValue<Guid>("EmailId");
			}
			set {
				SetColumnValue("EmailId", value);
				_email = null;
			}
		}

		/// <exclude/>
		public string EmailTitle {
			get {
				return GetTypedColumnValue<string>("EmailTitle");
			}
			set {
				SetColumnValue("EmailTitle", value);
				if (_email != null) {
					_email.Title = value;
				}
			}
		}

		private Activity _email;
		/// <summary>
		/// Email.
		/// </summary>
		public Activity Email {
			get {
				return _email ??
					(_email = LookupColumnEntities.GetEntity("Email") as Activity);
			}
		}

		/// <summary>
		/// EntitySchemaUId.
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
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailRelation_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailRelationDeleted", e);
			Validating += (s, e) => ThrowEvent("EmailRelationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailRelation(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailRelation_UIv2EventsProcess

	/// <exclude/>
	public partial class EmailRelation_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmailRelation
	{

		public EmailRelation_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailRelation_UIv2EventsProcess";
			SchemaUId = new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6c47d4bf-74d5-4ae6-bcb5-ea138550ee8f");
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

	#region Class: EmailRelation_UIv2EventsProcess

	/// <exclude/>
	public class EmailRelation_UIv2EventsProcess : EmailRelation_UIv2EventsProcess<EmailRelation>
	{

		public EmailRelation_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailRelation_UIv2EventsProcess

	public partial class EmailRelation_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailRelationEventsProcess

	/// <exclude/>
	public class EmailRelationEventsProcess : EmailRelation_UIv2EventsProcess
	{

		public EmailRelationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

