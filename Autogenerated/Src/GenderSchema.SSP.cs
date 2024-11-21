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

	#region Class: GenderSchema

	/// <exclude/>
	public class GenderSchema : BPMSoft.Configuration.Gender_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public GenderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GenderSchema(GenderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GenderSchema(GenderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("bfa99d2e-0c38-447b-ab22-b94cc2e58bc4");
			Name = "Gender";
			ParentSchemaUId = new Guid("0bc5d826-8e8f-48cd-b087-30b33d133120");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
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
			return new Gender(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Gender_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GenderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GenderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bfa99d2e-0c38-447b-ab22-b94cc2e58bc4"));
		}

		#endregion

	}

	#endregion

	#region Class: Gender

	/// <summary>
	/// Gender.
	/// </summary>
	public class Gender : BPMSoft.Configuration.Gender_Base_BPMSoft
	{

		#region Constructors: Public

		public Gender(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Gender";
		}

		public Gender(Gender source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Gender_SSPEventsProcess(UserConnection);
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
			return new Gender(this);
		}

		#endregion

	}

	#endregion

	#region Class: Gender_SSPEventsProcess

	/// <exclude/>
	public partial class Gender_SSPEventsProcess<TEntity> : BPMSoft.Configuration.Gender_BaseEventsProcess<TEntity> where TEntity : Gender
	{

		public Gender_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Gender_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bfa99d2e-0c38-447b-ab22-b94cc2e58bc4");
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

	#region Class: Gender_SSPEventsProcess

	/// <exclude/>
	public class Gender_SSPEventsProcess : Gender_SSPEventsProcess<Gender>
	{

		public Gender_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Gender_SSPEventsProcess

	public partial class Gender_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GenderEventsProcess

	/// <exclude/>
	public class GenderEventsProcess : Gender_SSPEventsProcess
	{

		public GenderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

