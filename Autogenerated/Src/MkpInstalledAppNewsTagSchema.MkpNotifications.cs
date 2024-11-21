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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: MkpInstalledAppNewsTagSchema

	/// <exclude/>
	public class MkpInstalledAppNewsTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public MkpInstalledAppNewsTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MkpInstalledAppNewsTagSchema(MkpInstalledAppNewsTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MkpInstalledAppNewsTagSchema(MkpInstalledAppNewsTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			RealUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			Name = "MkpInstalledAppNewsTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42204ac4-9e89-423e-9f95-836c2df050a9");
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
			column.ModifiedInSchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MkpInstalledAppNewsTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MkpInstalledAppNewsTag_MkpNotificationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MkpInstalledAppNewsTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MkpInstalledAppNewsTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703"));
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsTag

	/// <summary>
	/// Installed app news section tag.
	/// </summary>
	public class MkpInstalledAppNewsTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public MkpInstalledAppNewsTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MkpInstalledAppNewsTag";
		}

		public MkpInstalledAppNewsTag(MkpInstalledAppNewsTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MkpInstalledAppNewsTag_MkpNotificationsEventsProcess(UserConnection);
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
			return new MkpInstalledAppNewsTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: MkpInstalledAppNewsTag_MkpNotificationsEventsProcess

	/// <exclude/>
	public partial class MkpInstalledAppNewsTag_MkpNotificationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : MkpInstalledAppNewsTag
	{

		public MkpInstalledAppNewsTag_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MkpInstalledAppNewsTag_MkpNotificationsEventsProcess";
			SchemaUId = new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("23664079-3182-4d42-8c61-e0d5ff7e0703");
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

	#region Class: MkpInstalledAppNewsTag_MkpNotificationsEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsTag_MkpNotificationsEventsProcess : MkpInstalledAppNewsTag_MkpNotificationsEventsProcess<MkpInstalledAppNewsTag>
	{

		public MkpInstalledAppNewsTag_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MkpInstalledAppNewsTag_MkpNotificationsEventsProcess

	public partial class MkpInstalledAppNewsTag_MkpNotificationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MkpInstalledAppNewsTagEventsProcess

	/// <exclude/>
	public class MkpInstalledAppNewsTagEventsProcess : MkpInstalledAppNewsTag_MkpNotificationsEventsProcess
	{

		public MkpInstalledAppNewsTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

