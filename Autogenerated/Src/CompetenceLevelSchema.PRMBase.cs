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

	#region Class: CompetenceLevelSchema

	/// <exclude/>
	public class CompetenceLevelSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CompetenceLevelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CompetenceLevelSchema(CompetenceLevelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CompetenceLevelSchema(CompetenceLevelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54c499af-04aa-4eb5-9815-f23e12685d68");
			RealUId = new Guid("54c499af-04aa-4eb5-9815-f23e12685d68");
			Name = "CompetenceLevel";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
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
			return new CompetenceLevel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CompetenceLevel_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CompetenceLevelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CompetenceLevelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54c499af-04aa-4eb5-9815-f23e12685d68"));
		}

		#endregion

	}

	#endregion

	#region Class: CompetenceLevel

	/// <summary>
	/// Уровень компетенции.
	/// </summary>
	public class CompetenceLevel : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CompetenceLevel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CompetenceLevel";
		}

		public CompetenceLevel(CompetenceLevel source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CompetenceLevel_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CompetenceLevelDeleted", e);
			Validating += (s, e) => ThrowEvent("CompetenceLevelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CompetenceLevel(this);
		}

		#endregion

	}

	#endregion

	#region Class: CompetenceLevel_PRMBaseEventsProcess

	/// <exclude/>
	public partial class CompetenceLevel_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CompetenceLevel
	{

		public CompetenceLevel_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CompetenceLevel_PRMBaseEventsProcess";
			SchemaUId = new Guid("54c499af-04aa-4eb5-9815-f23e12685d68");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("54c499af-04aa-4eb5-9815-f23e12685d68");
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

	#region Class: CompetenceLevel_PRMBaseEventsProcess

	/// <exclude/>
	public class CompetenceLevel_PRMBaseEventsProcess : CompetenceLevel_PRMBaseEventsProcess<CompetenceLevel>
	{

		public CompetenceLevel_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CompetenceLevel_PRMBaseEventsProcess

	public partial class CompetenceLevel_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CompetenceLevelEventsProcess

	/// <exclude/>
	public class CompetenceLevelEventsProcess : CompetenceLevel_PRMBaseEventsProcess
	{

		public CompetenceLevelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

