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

	#region Class: ParameterTypeSchema

	/// <exclude/>
	public class ParameterTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ParameterTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ParameterTypeSchema(ParameterTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ParameterTypeSchema(ParameterTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab9ef8b5-8cff-4a02-88e8-a6e8e926f152");
			RealUId = new Guid("ab9ef8b5-8cff-4a02-88e8-a6e8e926f152");
			Name = "ParameterType";
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
			return new ParameterType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ParameterType_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ParameterTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ParameterTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab9ef8b5-8cff-4a02-88e8-a6e8e926f152"));
		}

		#endregion

	}

	#endregion

	#region Class: ParameterType

	/// <summary>
	/// Тип параметра.
	/// </summary>
	public class ParameterType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ParameterType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ParameterType";
		}

		public ParameterType(ParameterType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ParameterType_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ParameterTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("ParameterTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ParameterType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ParameterType_PRMBaseEventsProcess

	/// <exclude/>
	public partial class ParameterType_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ParameterType
	{

		public ParameterType_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ParameterType_PRMBaseEventsProcess";
			SchemaUId = new Guid("ab9ef8b5-8cff-4a02-88e8-a6e8e926f152");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab9ef8b5-8cff-4a02-88e8-a6e8e926f152");
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

	#region Class: ParameterType_PRMBaseEventsProcess

	/// <exclude/>
	public class ParameterType_PRMBaseEventsProcess : ParameterType_PRMBaseEventsProcess<ParameterType>
	{

		public ParameterType_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ParameterType_PRMBaseEventsProcess

	public partial class ParameterType_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ParameterTypeEventsProcess

	/// <exclude/>
	public class ParameterTypeEventsProcess : ParameterType_PRMBaseEventsProcess
	{

		public ParameterTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

