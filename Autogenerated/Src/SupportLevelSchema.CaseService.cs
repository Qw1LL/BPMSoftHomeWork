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

	#region Class: SupportLevelSchema

	/// <exclude/>
	public class SupportLevelSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SupportLevelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupportLevelSchema(SupportLevelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupportLevelSchema(SupportLevelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c30bd3d7-e9ea-4165-bedd-a23be5d59050");
			RealUId = new Guid("c30bd3d7-e9ea-4165-bedd-a23be5d59050");
			Name = "SupportLevel";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0e69a91d-b86d-4cf2-b98c-7f690db56e3a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
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
			return new SupportLevel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupportLevel_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupportLevelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupportLevelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c30bd3d7-e9ea-4165-bedd-a23be5d59050"));
		}

		#endregion

	}

	#endregion

	#region Class: SupportLevel

	/// <summary>
	/// Уровень поддержки.
	/// </summary>
	public class SupportLevel : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SupportLevel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupportLevel";
		}

		public SupportLevel(SupportLevel source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupportLevel_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SupportLevelDeleted", e);
			Validating += (s, e) => ThrowEvent("SupportLevelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SupportLevel(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupportLevel_CaseServiceEventsProcess

	/// <exclude/>
	public partial class SupportLevel_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SupportLevel
	{

		public SupportLevel_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupportLevel_CaseServiceEventsProcess";
			SchemaUId = new Guid("c30bd3d7-e9ea-4165-bedd-a23be5d59050");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c30bd3d7-e9ea-4165-bedd-a23be5d59050");
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

	#region Class: SupportLevel_CaseServiceEventsProcess

	/// <exclude/>
	public class SupportLevel_CaseServiceEventsProcess : SupportLevel_CaseServiceEventsProcess<SupportLevel>
	{

		public SupportLevel_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupportLevel_CaseServiceEventsProcess

	public partial class SupportLevel_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SupportLevelEventsProcess

	/// <exclude/>
	public class SupportLevelEventsProcess : SupportLevel_CaseServiceEventsProcess
	{

		public SupportLevelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

