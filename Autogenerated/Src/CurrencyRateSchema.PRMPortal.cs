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

	#region Class: CurrencyRate_PRMPortal_BPMSoftSchema

	/// <exclude/>
	public class CurrencyRate_PRMPortal_BPMSoftSchema : BPMSoft.Configuration.CurrencyRate_UIv2_BPMSoftSchema
	{

		#region Constructors: Public

		public CurrencyRate_PRMPortal_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CurrencyRate_PRMPortal_BPMSoftSchema(CurrencyRate_PRMPortal_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CurrencyRate_PRMPortal_BPMSoftSchema(CurrencyRate_PRMPortal_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("43248feb-f6c3-42e6-b4f5-1be1fa15d8c0");
			Name = "CurrencyRate_PRMPortal_BPMSoft";
			ParentSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("5dec8cf0-d427-4401-87b1-204c8e96d1d4");
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
			return new CurrencyRate_PRMPortal_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CurrencyRate_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CurrencyRate_PRMPortal_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CurrencyRate_PRMPortal_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("43248feb-f6c3-42e6-b4f5-1be1fa15d8c0"));
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyRate_PRMPortal_BPMSoft

	/// <summary>
	/// Курс валюты.
	/// </summary>
	public class CurrencyRate_PRMPortal_BPMSoft : BPMSoft.Configuration.CurrencyRate_UIv2_BPMSoft
	{

		#region Constructors: Public

		public CurrencyRate_PRMPortal_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CurrencyRate_PRMPortal_BPMSoft";
		}

		public CurrencyRate_PRMPortal_BPMSoft(CurrencyRate_PRMPortal_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CurrencyRate_PRMPortalEventsProcess(UserConnection);
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
			return new CurrencyRate_PRMPortal_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyRate_PRMPortalEventsProcess

	/// <exclude/>
	public partial class CurrencyRate_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.CurrencyRate_UIv2EventsProcess<TEntity> where TEntity : CurrencyRate_PRMPortal_BPMSoft
	{

		public CurrencyRate_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CurrencyRate_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("43248feb-f6c3-42e6-b4f5-1be1fa15d8c0");
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

	#region Class: CurrencyRate_PRMPortalEventsProcess

	/// <exclude/>
	public class CurrencyRate_PRMPortalEventsProcess : CurrencyRate_PRMPortalEventsProcess<CurrencyRate_PRMPortal_BPMSoft>
	{

		public CurrencyRate_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CurrencyRate_PRMPortalEventsProcess

	public partial class CurrencyRate_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

