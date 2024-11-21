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

	#region Class: MkpInstalledAppNewsInTagSchema

	/// <exclude/>
	public class MkpInstalledAppNewsInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public MkpInstalledAppNewsInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MkpInstalledAppNewsInTagSchema(MkpInstalledAppNewsInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MkpInstalledAppNewsInTagSchema(MkpInstalledAppNewsInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			RealUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			Name = "MkpInstalledAppNewsInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42204ac4-9e89-423e-9f95-836c2df050a9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			RightSchemaName = @"SysMkpInstAppNewsInTagRight";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("0c92974f-4dbe-4990-968e-3d1fa1719a53");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"Entity";
			column.ModifiedInSchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MkpInstalledAppNewsInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MkpInstalledAppNewsInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MkpInstalledAppNewsInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094"));
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsInTag

	/// <summary>
	/// Installed app news section record tag.
	/// </summary>
	public class MkpInstalledAppNewsInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public MkpInstalledAppNewsInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MkpInstalledAppNewsInTag";
		}

		public MkpInstalledAppNewsInTag(MkpInstalledAppNewsInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess(UserConnection);
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
			return new MkpInstalledAppNewsInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess

	/// <exclude/>
	public partial class MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : MkpInstalledAppNewsInTag
	{

		public MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess";
			SchemaUId = new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c5e9c453-faed-4bc6-b261-1448f84f9094");
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

	#region Class: MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess : MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess<MkpInstalledAppNewsInTag>
	{

		public MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess

	public partial class MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MkpInstalledAppNewsInTagEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsInTagEventsProcess : MkpInstalledAppNewsInTag_MkpNotificationsEventsProcess
	{

		public MkpInstalledAppNewsInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

