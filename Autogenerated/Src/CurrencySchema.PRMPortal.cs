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
	using BPMSoft.Core.Store;
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

	#region Class: Currency_PRMPortal_BPMSoftSchema

	/// <exclude/>
	public class Currency_PRMPortal_BPMSoftSchema : BPMSoft.Configuration.Currency_UIv2_BPMSoftSchema
	{

		#region Constructors: Public

		public Currency_PRMPortal_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Currency_PRMPortal_BPMSoftSchema(Currency_PRMPortal_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Currency_PRMPortal_BPMSoftSchema(Currency_PRMPortal_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("db75449a-d22e-4214-9ea9-437c22cdf436");
			Name = "Currency_PRMPortal_BPMSoft";
			ParentSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d");
			ExtendParent = true;
			CreatedInPackageId = new Guid("667fe825-207f-46da-8fb7-a082f81fd079");
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
			return new Currency_PRMPortal_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Currency_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Currency_PRMPortal_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Currency_PRMPortal_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("db75449a-d22e-4214-9ea9-437c22cdf436"));
		}

		#endregion

	}

	#endregion

	#region Class: Currency_PRMPortal_BPMSoft

	/// <summary>
	/// Валюта.
	/// </summary>
	public class Currency_PRMPortal_BPMSoft : BPMSoft.Configuration.Currency_UIv2_BPMSoft
	{

		#region Constructors: Public

		public Currency_PRMPortal_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Currency_PRMPortal_BPMSoft";
		}

		public Currency_PRMPortal_BPMSoft(Currency_PRMPortal_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Currency_PRMPortalEventsProcess(UserConnection);
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
			return new Currency_PRMPortal_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Currency_PRMPortalEventsProcess

	/// <exclude/>
	public partial class Currency_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.Currency_UIv2EventsProcess<TEntity> where TEntity : Currency_PRMPortal_BPMSoft
	{

		public Currency_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Currency_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("db75449a-d22e-4214-9ea9-437c22cdf436");
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

	#region Class: Currency_PRMPortalEventsProcess

	/// <exclude/>
	public class Currency_PRMPortalEventsProcess : Currency_PRMPortalEventsProcess<Currency_PRMPortal_BPMSoft>
	{

		public Currency_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Currency_PRMPortalEventsProcess

	public partial class Currency_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

