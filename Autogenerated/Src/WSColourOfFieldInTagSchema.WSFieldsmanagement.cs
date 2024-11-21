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

	#region Class: WSColourOfFieldInTagSchema

	/// <exclude/>
	public class WSColourOfFieldInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public WSColourOfFieldInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSColourOfFieldInTagSchema(WSColourOfFieldInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSColourOfFieldInTagSchema(WSColourOfFieldInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			RealUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			Name = "WSColourOfFieldInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d");
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
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("952d6942-a38a-4ea7-b85f-2f6d1b317a1f");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityWSName";
			column.ModifiedInSchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSColourOfFieldInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSColourOfFieldInTag_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSColourOfFieldInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSColourOfFieldInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("39d5b238-0006-4232-92e3-2f840a540704"));
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldInTag

	/// <summary>
	/// Тег в записи раздела Правила цветового выделения.
	/// </summary>
	public class WSColourOfFieldInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public WSColourOfFieldInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSColourOfFieldInTag";
		}

		public WSColourOfFieldInTag(WSColourOfFieldInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSColourOfFieldInTag_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSColourOfFieldInTagDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSColourOfFieldInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfFieldInTag_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSColourOfFieldInTag_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : WSColourOfFieldInTag
	{

		public WSColourOfFieldInTag_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSColourOfFieldInTag_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("39d5b238-0006-4232-92e3-2f840a540704");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("39d5b238-0006-4232-92e3-2f840a540704");
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

	#region Class: WSColourOfFieldInTag_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSColourOfFieldInTag_WSFieldsmanagementEventsProcess : WSColourOfFieldInTag_WSFieldsmanagementEventsProcess<WSColourOfFieldInTag>
	{

		public WSColourOfFieldInTag_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSColourOfFieldInTag_WSFieldsmanagementEventsProcess

	public partial class WSColourOfFieldInTag_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSColourOfFieldInTagEventsProcess

	/// <exclude/>
	public class WSColourOfFieldInTagEventsProcess : WSColourOfFieldInTag_WSFieldsmanagementEventsProcess
	{

		public WSColourOfFieldInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

