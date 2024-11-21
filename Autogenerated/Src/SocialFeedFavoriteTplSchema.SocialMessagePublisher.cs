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

	#region Class: SocialFeedFavoriteTplSchema

	/// <exclude/>
	public class SocialFeedFavoriteTplSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialFeedFavoriteTplSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialFeedFavoriteTplSchema(SocialFeedFavoriteTplSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialFeedFavoriteTplSchema(SocialFeedFavoriteTplSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509");
			RealUId = new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509");
			Name = "SocialFeedFavoriteTpl";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("38b993f5-fb4f-409b-b873-259a2a32ef6a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5c09bcdd-6d05-4ca1-bfa6-51072a1739ea")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("be88df04-0621-4dd4-b951-14d843c587d3")) == null) {
				Columns.Add(CreateEmailTemplateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c09bcdd-6d05-4ca1-bfa6-51072a1739ea"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509"),
				ModifiedInSchemaUId = new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509"),
				CreatedInPackageId = new Guid("38b993f5-fb4f-409b-b873-259a2a32ef6a")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("be88df04-0621-4dd4-b951-14d843c587d3"),
				Name = @"EmailTemplate",
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509"),
				ModifiedInSchemaUId = new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509"),
				CreatedInPackageId = new Guid("38b993f5-fb4f-409b-b873-259a2a32ef6a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialFeedFavoriteTpl(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialFeedFavoriteTplSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialFeedFavoriteTplSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialFeedFavoriteTpl

	/// <summary>
	/// Favorites social feed templates.
	/// </summary>
	public class SocialFeedFavoriteTpl : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialFeedFavoriteTpl(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialFeedFavoriteTpl";
		}

		public SocialFeedFavoriteTpl(SocialFeedFavoriteTpl source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid EmailTemplateId {
			get {
				return GetTypedColumnValue<Guid>("EmailTemplateId");
			}
			set {
				SetColumnValue("EmailTemplateId", value);
				_emailTemplate = null;
			}
		}

		/// <exclude/>
		public string EmailTemplateName {
			get {
				return GetTypedColumnValue<string>("EmailTemplateName");
			}
			set {
				SetColumnValue("EmailTemplateName", value);
				if (_emailTemplate != null) {
					_emailTemplate.Name = value;
				}
			}
		}

		private EmailTemplate _emailTemplate;
		/// <summary>
		/// Email message template.
		/// </summary>
		public EmailTemplate EmailTemplate {
			get {
				return _emailTemplate ??
					(_emailTemplate = LookupColumnEntities.GetEntity("EmailTemplate") as EmailTemplate);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess(UserConnection);
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
			return new SocialFeedFavoriteTpl(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess

	/// <exclude/>
	public partial class SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialFeedFavoriteTpl
	{

		public SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess";
			SchemaUId = new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6b1c99e8-d0c0-441c-8d82-14e5cb59b509");
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

	#region Class: SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess

	/// <exclude/>
	public class SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess : SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess<SocialFeedFavoriteTpl>
	{

		public SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess

	public partial class SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialFeedFavoriteTplEventsProcess

	/// <exclude/>
	public class SocialFeedFavoriteTplEventsProcess : SocialFeedFavoriteTpl_SocialMessagePublisherEventsProcess
	{

		public SocialFeedFavoriteTplEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

