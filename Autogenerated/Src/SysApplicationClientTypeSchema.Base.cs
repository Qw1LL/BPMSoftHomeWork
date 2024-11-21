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

	#region Class: SysApplicationClientTypeSchema

	/// <exclude/>
	public class SysApplicationClientTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysApplicationClientTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysApplicationClientTypeSchema(SysApplicationClientTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysApplicationClientTypeSchema(SysApplicationClientTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			RealUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			Name = "SysApplicationClientType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			column.CreatedInPackageId = new Guid("8c2b6e29-4d90-42e1-ae92-db7c684023f9");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysApplicationClientType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysApplicationClientType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysApplicationClientTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysApplicationClientTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba"));
		}

		#endregion

	}

	#endregion

	#region Class: SysApplicationClientType

	/// <summary>
	/// Application client type.
	/// </summary>
	public class SysApplicationClientType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysApplicationClientType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysApplicationClientType";
		}

		public SysApplicationClientType(SysApplicationClientType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysApplicationClientType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysApplicationClientTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysApplicationClientTypeInserting", e);
			Validating += (s, e) => ThrowEvent("SysApplicationClientTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysApplicationClientType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysApplicationClientType_BaseEventsProcess

	/// <exclude/>
	public partial class SysApplicationClientType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysApplicationClientType
	{

		public SysApplicationClientType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysApplicationClientType_BaseEventsProcess";
			SchemaUId = new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7d37b67c-f2b0-47d1-a0c5-6215d21984ba");
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

	#region Class: SysApplicationClientType_BaseEventsProcess

	/// <exclude/>
	public class SysApplicationClientType_BaseEventsProcess : SysApplicationClientType_BaseEventsProcess<SysApplicationClientType>
	{

		public SysApplicationClientType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysApplicationClientType_BaseEventsProcess

	public partial class SysApplicationClientType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysApplicationClientTypeEventsProcess

	/// <exclude/>
	public class SysApplicationClientTypeEventsProcess : SysApplicationClientType_BaseEventsProcess
	{

		public SysApplicationClientTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

