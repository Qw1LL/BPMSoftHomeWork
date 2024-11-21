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

	#region Class: CallSchema

	/// <exclude/>
	public class CallSchema : BPMSoft.Configuration.Call_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public CallSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallSchema(CallSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallSchema(CallSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateICallCreatedOnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8f49136d-4605-4a5e-94bf-dec8cd6b8c60");
			index.Name = "ICallCreatedOn";
			index.CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fbd9727b-1533-41f4-b11a-e3e7a77a63e9"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("670fb312-08ae-4ca2-9e35-2f08589d3062");
			Name = "Call";
			ParentSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			ExtendParent = true;
			CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3da6c48a-3d15-48a9-4c18-06400ab8e716")) == null) {
				Columns.Add(CreateCallRecordLinkColumn());
			}
		}

		protected override EntitySchemaColumn CreateDirectionColumn() {
			EntitySchemaColumn column = base.CreateDirectionColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"c072be2c-3d82-4468-9d4a-6db47d1f4cca"
			};
			column.ModifiedInSchemaUId = new Guid("670fb312-08ae-4ca2-9e35-2f08589d3062");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCallRecordLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3da6c48a-3d15-48a9-4c18-06400ab8e716"),
				Name = @"CallRecordLink",
				CreatedInSchemaUId = new Guid("670fb312-08ae-4ca2-9e35-2f08589d3062"),
				ModifiedInSchemaUId = new Guid("670fb312-08ae-4ca2-9e35-2f08589d3062"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateICallCreatedOnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Call(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Call_WebRTCCoreEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("670fb312-08ae-4ca2-9e35-2f08589d3062"));
		}

		#endregion

	}

	#endregion

	#region Class: Call

	/// <summary>
	/// Звонок.
	/// </summary>
	public class Call : BPMSoft.Configuration.Call_Order_BPMSoft
	{

		#region Constructors: Public

		public Call(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call";
		}

		public Call(Call source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Ссылка на запись разговора.
		/// </summary>
		public string CallRecordLink {
			get {
				return GetTypedColumnValue<string>("CallRecordLink");
			}
			set {
				SetColumnValue("CallRecordLink", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Call_WebRTCCoreEventsProcess(UserConnection);
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
			return new Call(this);
		}

		#endregion

	}

	#endregion

	#region Class: Call_WebRTCCoreEventsProcess

	/// <exclude/>
	public partial class Call_WebRTCCoreEventsProcess<TEntity> : BPMSoft.Configuration.Call_OrderEventsProcess<TEntity> where TEntity : Call
	{

		public Call_WebRTCCoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Call_WebRTCCoreEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("670fb312-08ae-4ca2-9e35-2f08589d3062");
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

	#region Class: Call_WebRTCCoreEventsProcess

	/// <exclude/>
	public class Call_WebRTCCoreEventsProcess : Call_WebRTCCoreEventsProcess<Call>
	{

		public Call_WebRTCCoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Call_WebRTCCoreEventsProcess

	public partial class Call_WebRTCCoreEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CallEventsProcess

	/// <exclude/>
	public class CallEventsProcess : Call_WebRTCCoreEventsProcess
	{

		public CallEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

