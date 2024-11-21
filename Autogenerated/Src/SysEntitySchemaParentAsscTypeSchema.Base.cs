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

	#region Class: SysEntitySchemaParentAsscTypeSchema

	/// <exclude/>
	public class SysEntitySchemaParentAsscTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysEntitySchemaParentAsscTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntitySchemaParentAsscTypeSchema(SysEntitySchemaParentAsscTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntitySchemaParentAsscTypeSchema(SysEntitySchemaParentAsscTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34106734-ae04-4d51-961c-4c54b459e852");
			RealUId = new Guid("34106734-ae04-4d51-961c-4c54b459e852");
			Name = "SysEntitySchemaParentAsscType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysEntitySchParentAsscTypeLcz";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntitySchemaParentAsscType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntitySchemaParentAsscType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntitySchemaParentAsscTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntitySchemaParentAsscTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34106734-ae04-4d51-961c-4c54b459e852"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaParentAsscType

	/// <summary>
	/// Inheritance Type.
	/// </summary>
	public class SysEntitySchemaParentAsscType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysEntitySchemaParentAsscType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaParentAsscType";
		}

		public SysEntitySchemaParentAsscType(SysEntitySchemaParentAsscType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntitySchemaParentAsscType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntitySchemaParentAsscTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEntitySchemaParentAsscTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEntitySchemaParentAsscTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEntitySchemaParentAsscTypeInserting", e);
			Saved += (s, e) => ThrowEvent("SysEntitySchemaParentAsscTypeSaved", e);
			Saving += (s, e) => ThrowEvent("SysEntitySchemaParentAsscTypeSaving", e);
			Validating += (s, e) => ThrowEvent("SysEntitySchemaParentAsscTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntitySchemaParentAsscType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaParentAsscType_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntitySchemaParentAsscType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysEntitySchemaParentAsscType
	{

		public SysEntitySchemaParentAsscType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntitySchemaParentAsscType_BaseEventsProcess";
			SchemaUId = new Guid("34106734-ae04-4d51-961c-4c54b459e852");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("34106734-ae04-4d51-961c-4c54b459e852");
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

	#region Class: SysEntitySchemaParentAsscType_BaseEventsProcess

	/// <exclude/>
	public class SysEntitySchemaParentAsscType_BaseEventsProcess : SysEntitySchemaParentAsscType_BaseEventsProcess<SysEntitySchemaParentAsscType>
	{

		public SysEntitySchemaParentAsscType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntitySchemaParentAsscType_BaseEventsProcess

	public partial class SysEntitySchemaParentAsscType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntitySchemaParentAsscTypeEventsProcess

	/// <exclude/>
	public class SysEntitySchemaParentAsscTypeEventsProcess : SysEntitySchemaParentAsscType_BaseEventsProcess
	{

		public SysEntitySchemaParentAsscTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

