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

	#region Class: SocialMentionSearchRuleSchema

	/// <exclude/>
	public class SocialMentionSearchRuleSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialMentionSearchRuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialMentionSearchRuleSchema(SocialMentionSearchRuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialMentionSearchRuleSchema(SocialMentionSearchRuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117");
			RealUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117");
			Name = "SocialMentionSearchRule";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c726abc-cc67-49b0-9345-f38bdff9ced8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b44aeabb-f8ea-4dae-bca3-4cda437996c2")) == null) {
				Columns.Add(CreateEntitySchemaColumn());
			}
			if (Columns.FindByUId(new Guid("e70ce46d-1e78-4d67-b2c5-8094ffef6fdb")) == null) {
				Columns.Add(CreateFilterByColumnColumn());
			}
			if (Columns.FindByUId(new Guid("90030f86-60c5-4383-ad2d-713dc96e4cba")) == null) {
				Columns.Add(CreateUserColumnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b44aeabb-f8ea-4dae-bca3-4cda437996c2"),
				Name = @"EntitySchema",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117"),
				ModifiedInSchemaUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117"),
				CreatedInPackageId = new Guid("3c726abc-cc67-49b0-9345-f38bdff9ced8")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterByColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e70ce46d-1e78-4d67-b2c5-8094ffef6fdb"),
				Name = @"FilterByColumn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117"),
				ModifiedInSchemaUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117"),
				CreatedInPackageId = new Guid("3c726abc-cc67-49b0-9345-f38bdff9ced8")
			};
		}

		protected virtual EntitySchemaColumn CreateUserColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("90030f86-60c5-4383-ad2d-713dc96e4cba"),
				Name = @"UserColumn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117"),
				ModifiedInSchemaUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117"),
				CreatedInPackageId = new Guid("3c726abc-cc67-49b0-9345-f38bdff9ced8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialMentionSearchRule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialMentionSearchRule_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialMentionSearchRuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialMentionSearchRuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialMentionSearchRule

	/// <summary>
	/// User social mention search rule.
	/// </summary>
	public class SocialMentionSearchRule : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialMentionSearchRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialMentionSearchRule";
		}

		public SocialMentionSearchRule(SocialMentionSearchRule source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object.
		/// </summary>
		public string EntitySchema {
			get {
				return GetTypedColumnValue<string>("EntitySchema");
			}
			set {
				SetColumnValue("EntitySchema", value);
			}
		}

		/// <summary>
		/// Current user fitler by column.
		/// </summary>
		public string FilterByColumn {
			get {
				return GetTypedColumnValue<string>("FilterByColumn");
			}
			set {
				SetColumnValue("FilterByColumn", value);
			}
		}

		/// <summary>
		/// User column.
		/// </summary>
		public string UserColumn {
			get {
				return GetTypedColumnValue<string>("UserColumn");
			}
			set {
				SetColumnValue("UserColumn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialMentionSearchRule_ESNEventsProcess(UserConnection);
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
			return new SocialMentionSearchRule(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMentionSearchRule_ESNEventsProcess

	/// <exclude/>
	public partial class SocialMentionSearchRule_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialMentionSearchRule
	{

		public SocialMentionSearchRule_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialMentionSearchRule_ESNEventsProcess";
			SchemaUId = new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ca035eb2-97bc-467d-819d-1b6c9caa3117");
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

	#region Class: SocialMentionSearchRule_ESNEventsProcess

	/// <exclude/>
	public class SocialMentionSearchRule_ESNEventsProcess : SocialMentionSearchRule_ESNEventsProcess<SocialMentionSearchRule>
	{

		public SocialMentionSearchRule_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialMentionSearchRule_ESNEventsProcess

	public partial class SocialMentionSearchRule_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialMentionSearchRuleEventsProcess

	/// <exclude/>
	public class SocialMentionSearchRuleEventsProcess : SocialMentionSearchRule_ESNEventsProcess
	{

		public SocialMentionSearchRuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

