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

	#region Class: PartnershipSchema

	/// <exclude/>
	public class PartnershipSchema : BPMSoft.Configuration.Partnership_PRMBase_BPMSoftSchema
	{

		#region Constructors: Public

		public PartnershipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipSchema(PartnershipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipSchema(PartnershipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("715e031e-7f63-4784-a323-c0ea3ada5192");
			Name = "Partnership";
			ParentSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d");
			ExtendParent = true;
			CreatedInPackageId = new Guid("0fffc5a3-cd85-4e12-bfdb-f47322f14e3d");
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
			return new Partnership(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Partnership_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("715e031e-7f63-4784-a323-c0ea3ada5192"));
		}

		#endregion

	}

	#endregion

	#region Class: Partnership

	/// <summary>
	/// Партнерство.
	/// </summary>
	public class Partnership : BPMSoft.Configuration.Partnership_PRMBase_BPMSoft
	{

		#region Constructors: Public

		public Partnership(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Partnership";
		}

		public Partnership(Partnership source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Partnership_PRMPortalEventsProcess(UserConnection);
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
			return new Partnership(this);
		}

		#endregion

	}

	#endregion

	#region Class: Partnership_PRMPortalEventsProcess

	/// <exclude/>
	public partial class Partnership_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.Partnership_PRMBaseEventsProcess<TEntity> where TEntity : Partnership
	{

		public Partnership_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Partnership_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("715e031e-7f63-4784-a323-c0ea3ada5192");
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

	#region Class: Partnership_PRMPortalEventsProcess

	/// <exclude/>
	public class Partnership_PRMPortalEventsProcess : Partnership_PRMPortalEventsProcess<Partnership>
	{

		public Partnership_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Partnership_PRMPortalEventsProcess

	public partial class Partnership_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PartnershipEventsProcess

	/// <exclude/>
	public class PartnershipEventsProcess : Partnership_PRMPortalEventsProcess
	{

		public PartnershipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

