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

	#region Class: PRMTransactionType_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class PRMTransactionType_PRMBase_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public PRMTransactionType_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PRMTransactionType_PRMBase_BPMSoftSchema(PRMTransactionType_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PRMTransactionType_PRMBase_BPMSoftSchema(PRMTransactionType_PRMBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("49361e32-f6a5-4eb0-b0b2-7e13b1e2ed30");
			RealUId = new Guid("49361e32-f6a5-4eb0-b0b2-7e13b1e2ed30");
			Name = "PRMTransactionType_PRMBase_BPMSoft";
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
			return new PRMTransactionType_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PRMTransactionType_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PRMTransactionType_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PRMTransactionType_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("49361e32-f6a5-4eb0-b0b2-7e13b1e2ed30"));
		}

		#endregion

	}

	#endregion

	#region Class: PRMTransactionType_PRMBase_BPMSoft

	/// <summary>
	/// Тип транзакции.
	/// </summary>
	public class PRMTransactionType_PRMBase_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public PRMTransactionType_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PRMTransactionType_PRMBase_BPMSoft";
		}

		public PRMTransactionType_PRMBase_BPMSoft(PRMTransactionType_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PRMTransactionType_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PRMTransactionType_PRMBase_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("PRMTransactionType_PRMBase_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PRMTransactionType_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: PRMTransactionType_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PRMTransactionType_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : PRMTransactionType_PRMBase_BPMSoft
	{

		public PRMTransactionType_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PRMTransactionType_PRMBaseEventsProcess";
			SchemaUId = new Guid("49361e32-f6a5-4eb0-b0b2-7e13b1e2ed30");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("49361e32-f6a5-4eb0-b0b2-7e13b1e2ed30");
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

	#region Class: PRMTransactionType_PRMBaseEventsProcess

	/// <exclude/>
	public class PRMTransactionType_PRMBaseEventsProcess : PRMTransactionType_PRMBaseEventsProcess<PRMTransactionType_PRMBase_BPMSoft>
	{

		public PRMTransactionType_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PRMTransactionType_PRMBaseEventsProcess

	public partial class PRMTransactionType_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

