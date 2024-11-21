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

	#region Class: VwClientAddressSchema

	/// <exclude/>
	public class VwClientAddressSchema : BPMSoft.Configuration.VwClientAddress_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public VwClientAddressSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwClientAddressSchema(VwClientAddressSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwClientAddressSchema(VwClientAddressSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c4c2ffd8-f403-4d88-81d6-aebebb2a793c");
			Name = "VwClientAddress";
			ParentSchemaUId = new Guid("38249e0b-deeb-4f6c-a1aa-52e9961567ae");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d6ad04c1-fa0b-4adb-bfd8-17ec17775a03");
			IsDBView = true;
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
			return new VwClientAddress(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwClientAddress_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwClientAddressSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwClientAddressSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c4c2ffd8-f403-4d88-81d6-aebebb2a793c"));
		}

		#endregion

	}

	#endregion

	#region Class: VwClientAddress

	/// <summary>
	/// Адрес клиента.
	/// </summary>
	public class VwClientAddress : BPMSoft.Configuration.VwClientAddress_Order_BPMSoft
	{

		#region Constructors: Public

		public VwClientAddress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwClientAddress";
		}

		public VwClientAddress(VwClientAddress source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwClientAddress_PRMOrderEventsProcess(UserConnection);
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
			return new VwClientAddress(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwClientAddress_PRMOrderEventsProcess

	/// <exclude/>
	public partial class VwClientAddress_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.VwClientAddress_OrderEventsProcess<TEntity> where TEntity : VwClientAddress
	{

		public VwClientAddress_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwClientAddress_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c4c2ffd8-f403-4d88-81d6-aebebb2a793c");
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

	#region Class: VwClientAddress_PRMOrderEventsProcess

	/// <exclude/>
	public class VwClientAddress_PRMOrderEventsProcess : VwClientAddress_PRMOrderEventsProcess<VwClientAddress>
	{

		public VwClientAddress_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwClientAddress_PRMOrderEventsProcess

	public partial class VwClientAddress_PRMOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwClientAddressEventsProcess

	/// <exclude/>
	public class VwClientAddressEventsProcess : VwClientAddress_PRMOrderEventsProcess
	{

		public VwClientAddressEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

