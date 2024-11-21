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

	#region Class: ConfItemInTagSchema

	/// <exclude/>
	public class ConfItemInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public ConfItemInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfItemInTagSchema(ConfItemInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfItemInTagSchema(ConfItemInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6d604486-4d41-4287-9956-7c1853956fc3");
			RealUId = new Guid("6d604486-4d41-4287-9956-7c1853956fc3");
			Name = "ConfItemInTag";
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
			column.ReferenceSchemaUId = new Guid("2b50d963-51c6-45ec-b40d-a317449dd947");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("6d604486-4d41-4287-9956-7c1853956fc3");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("6d604486-4d41-4287-9956-7c1853956fc3");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfItemInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfItemInTag_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfItemInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfItemInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6d604486-4d41-4287-9956-7c1853956fc3"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemInTag

	/// <summary>
	/// Тег в записи раздела конфигурации.
	/// </summary>
	public class ConfItemInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public ConfItemInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfItemInTag";
		}

		public ConfItemInTag(ConfItemInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfItemInTag_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfItemInTagDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfItemInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemInTag_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfItemInTag_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : ConfItemInTag
	{

		public ConfItemInTag_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfItemInTag_CMDBEventsProcess";
			SchemaUId = new Guid("6d604486-4d41-4287-9956-7c1853956fc3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6d604486-4d41-4287-9956-7c1853956fc3");
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

	#region Class: ConfItemInTag_CMDBEventsProcess

	/// <exclude/>
	public class ConfItemInTag_CMDBEventsProcess : ConfItemInTag_CMDBEventsProcess<ConfItemInTag>
	{

		public ConfItemInTag_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfItemInTag_CMDBEventsProcess

	public partial class ConfItemInTag_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfItemInTagEventsProcess

	/// <exclude/>
	public class ConfItemInTagEventsProcess : ConfItemInTag_CMDBEventsProcess
	{

		public ConfItemInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

