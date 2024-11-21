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

	#region Class: SiteEventTypeInTagSchema

	/// <exclude/>
	public class SiteEventTypeInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public SiteEventTypeInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventTypeInTagSchema(SiteEventTypeInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventTypeInTagSchema(SiteEventTypeInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("383d9f06-ce56-4125-bc30-d35ce3f0ce93");
			RealUId = new Guid("383d9f06-ce56-4125-bc30-d35ce3f0ce93");
			Name = "SiteEventTypeInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("3e628a72-8770-4b42-841a-5eadf01323ce");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("383d9f06-ce56-4125-bc30-d35ce3f0ce93");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("e7274000-f0ef-4995-991a-37f0ace69fe3");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("383d9f06-ce56-4125-bc30-d35ce3f0ce93");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEventTypeInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventTypeInTag_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventTypeInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventTypeInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("383d9f06-ce56-4125-bc30-d35ce3f0ce93"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeInTag

	/// <summary>
	/// События сайта в теге.
	/// </summary>
	public class SiteEventTypeInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public SiteEventTypeInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventTypeInTag";
		}

		public SiteEventTypeInTag(SiteEventTypeInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventTypeInTag_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventTypeInTagDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEventTypeInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventTypeInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeInTag_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SiteEventTypeInTag_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : SiteEventTypeInTag
	{

		public SiteEventTypeInTag_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventTypeInTag_EventTrackingEventsProcess";
			SchemaUId = new Guid("383d9f06-ce56-4125-bc30-d35ce3f0ce93");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("383d9f06-ce56-4125-bc30-d35ce3f0ce93");
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

	#region Class: SiteEventTypeInTag_EventTrackingEventsProcess

	/// <exclude/>
	public class SiteEventTypeInTag_EventTrackingEventsProcess : SiteEventTypeInTag_EventTrackingEventsProcess<SiteEventTypeInTag>
	{

		public SiteEventTypeInTag_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventTypeInTag_EventTrackingEventsProcess

	public partial class SiteEventTypeInTag_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SiteEventTypeInTagEventsProcess

	/// <exclude/>
	public class SiteEventTypeInTagEventsProcess : SiteEventTypeInTag_EventTrackingEventsProcess
	{

		public SiteEventTypeInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

