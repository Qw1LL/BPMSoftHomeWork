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

	#region Class: OAuth20AppInTagSchema

	/// <exclude/>
	public class OAuth20AppInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public OAuth20AppInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuth20AppInTagSchema(OAuth20AppInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuth20AppInTagSchema(OAuth20AppInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			RealUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			Name = "OAuth20AppInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69832cb9-4518-407d-8490-ad1baa6b0193");
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
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("2d30ef0a-87fb-474a-a348-a8cb46e23e6e");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuth20AppInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuth20AppInTag_OAuth20IntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuth20AppInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuth20AppInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuth20AppInTag

	/// <summary>
	/// OAuth 2.0 application tag.
	/// </summary>
	public class OAuth20AppInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public OAuth20AppInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuth20AppInTag";
		}

		public OAuth20AppInTag(OAuth20AppInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuth20AppInTag_OAuth20IntegrationEventsProcess(UserConnection);
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
			return new OAuth20AppInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuth20AppInTag_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public partial class OAuth20AppInTag_OAuth20IntegrationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : OAuth20AppInTag
	{

		public OAuth20AppInTag_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuth20AppInTag_OAuth20IntegrationEventsProcess";
			SchemaUId = new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9d6b2836-6a87-4a56-a771-b98890dc343a");
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

	#region Class: OAuth20AppInTag_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public class OAuth20AppInTag_OAuth20IntegrationEventsProcess : OAuth20AppInTag_OAuth20IntegrationEventsProcess<OAuth20AppInTag>
	{

		public OAuth20AppInTag_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuth20AppInTag_OAuth20IntegrationEventsProcess

	public partial class OAuth20AppInTag_OAuth20IntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuth20AppInTagEventsProcess

	/// <exclude/>
	public class OAuth20AppInTagEventsProcess : OAuth20AppInTag_OAuth20IntegrationEventsProcess
	{

		public OAuth20AppInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

