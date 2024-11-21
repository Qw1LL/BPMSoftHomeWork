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

	#region Class: EmailTemplateInTagSchema

	/// <exclude/>
	public class EmailTemplateInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public EmailTemplateInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateInTagSchema(EmailTemplateInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateInTagSchema(EmailTemplateInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			RealUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			Name = "EmailTemplateInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a47bce9d-aced-4280-8524-3a778ba32af0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("9a2a0695-1dc5-4f8b-aee2-4d439df9e146");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailTemplateInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateInTag_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateInTag

	/// <summary>
	/// Email message template section record tag.
	/// </summary>
	public class EmailTemplateInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public EmailTemplateInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateInTag";
		}

		public EmailTemplateInTag(EmailTemplateInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplateInTag_BaseEventsProcess(UserConnection);
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
			return new EmailTemplateInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateInTag_BaseEventsProcess

	/// <exclude/>
	public partial class EmailTemplateInTag_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : EmailTemplateInTag
	{

		public EmailTemplateInTag_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateInTag_BaseEventsProcess";
			SchemaUId = new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e63a08ed-c67e-4a5c-bc60-b50c25aebefc");
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

	#region Class: EmailTemplateInTag_BaseEventsProcess

	/// <exclude/>
	public class EmailTemplateInTag_BaseEventsProcess : EmailTemplateInTag_BaseEventsProcess<EmailTemplateInTag>
	{

		public EmailTemplateInTag_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateInTag_BaseEventsProcess

	public partial class EmailTemplateInTag_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateInTagEventsProcess

	/// <exclude/>
	public class EmailTemplateInTagEventsProcess : EmailTemplateInTag_BaseEventsProcess
	{

		public EmailTemplateInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

