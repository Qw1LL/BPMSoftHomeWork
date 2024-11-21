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

	#region Class: UnitSchema

	/// <exclude/>
	public class UnitSchema : BPMSoft.Configuration.Unit_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public UnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UnitSchema(UnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UnitSchema(UnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("87569044-48dd-42b9-938d-0ec954e16444");
			Name = "Unit";
			ParentSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
			ExtendParent = true;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
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
			return new Unit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Unit_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("87569044-48dd-42b9-938d-0ec954e16444"));
		}

		#endregion

	}

	#endregion

	#region Class: Unit

	/// <summary>
	/// Единицы измерения.
	/// </summary>
	public class Unit : BPMSoft.Configuration.Unit_Base_BPMSoft
	{

		#region Constructors: Public

		public Unit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Unit";
		}

		public Unit(Unit source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Unit_PRMOrderEventsProcess(UserConnection);
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
			return new Unit(this);
		}

		#endregion

	}

	#endregion

	#region Class: Unit_PRMOrderEventsProcess

	/// <exclude/>
	public partial class Unit_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.Unit_BaseEventsProcess<TEntity> where TEntity : Unit
	{

		public Unit_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Unit_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("87569044-48dd-42b9-938d-0ec954e16444");
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

	#region Class: Unit_PRMOrderEventsProcess

	/// <exclude/>
	public class Unit_PRMOrderEventsProcess : Unit_PRMOrderEventsProcess<Unit>
	{

		public Unit_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Unit_PRMOrderEventsProcess

	public partial class Unit_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UnitEventsProcess

	/// <exclude/>
	public class UnitEventsProcess : Unit_PRMOrderEventsProcess
	{

		public UnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

