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

	#region Class: OAuth20AppTagSchema

	/// <exclude/>
	public class OAuth20AppTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public OAuth20AppTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuth20AppTagSchema(OAuth20AppTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuth20AppTagSchema(OAuth20AppTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			RealUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			Name = "OAuth20AppTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
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
			column.ModifiedInSchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuth20AppTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuth20AppTag_OAuth20IntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuth20AppTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuth20AppTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("12a05fec-9266-4e44-a28a-617916256908"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuth20AppTag

	/// <summary>
	/// OAuth 2.0 section tag.
	/// </summary>
	public class OAuth20AppTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public OAuth20AppTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuth20AppTag";
		}

		public OAuth20AppTag(OAuth20AppTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuth20AppTag_OAuth20IntegrationEventsProcess(UserConnection);
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
			return new OAuth20AppTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuth20AppTag_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public partial class OAuth20AppTag_OAuth20IntegrationEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : OAuth20AppTag
	{

		public OAuth20AppTag_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuth20AppTag_OAuth20IntegrationEventsProcess";
			SchemaUId = new Guid("12a05fec-9266-4e44-a28a-617916256908");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("12a05fec-9266-4e44-a28a-617916256908");
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

	#region Class: OAuth20AppTag_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public class OAuth20AppTag_OAuth20IntegrationEventsProcess : OAuth20AppTag_OAuth20IntegrationEventsProcess<OAuth20AppTag>
	{

		public OAuth20AppTag_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuth20AppTag_OAuth20IntegrationEventsProcess

	public partial class OAuth20AppTag_OAuth20IntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuth20AppTagEventsProcess

	/// <exclude/>
	public class OAuth20AppTagEventsProcess : OAuth20AppTag_OAuth20IntegrationEventsProcess
	{

		public OAuth20AppTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

