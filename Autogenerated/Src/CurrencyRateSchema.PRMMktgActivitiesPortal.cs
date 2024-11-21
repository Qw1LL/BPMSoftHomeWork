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

	#region Class: CurrencyRateSchema

	/// <exclude/>
	public class CurrencyRateSchema : BPMSoft.Configuration.CurrencyRate_PRMPortal_BPMSoftSchema
	{

		#region Constructors: Public

		public CurrencyRateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CurrencyRateSchema(CurrencyRateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CurrencyRateSchema(CurrencyRateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("4db56493-b205-4b39-931c-5379058adc23");
			Name = "CurrencyRate";
			ParentSchemaUId = new Guid("e14c6037-56bb-4724-95b6-3dc29d7f6b4f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("4e15e06f-c041-4f32-96e5-36c4e75dc6e5");
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
			return new CurrencyRate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CurrencyRate_PRMMktgActivitiesPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CurrencyRateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CurrencyRateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4db56493-b205-4b39-931c-5379058adc23"));
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyRate

	/// <summary>
	/// Курс валюты.
	/// </summary>
	public class CurrencyRate : BPMSoft.Configuration.CurrencyRate_PRMPortal_BPMSoft
	{

		#region Constructors: Public

		public CurrencyRate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CurrencyRate";
		}

		public CurrencyRate(CurrencyRate source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CurrencyRate_PRMMktgActivitiesPortalEventsProcess(UserConnection);
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
			return new CurrencyRate(this);
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyRate_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public partial class CurrencyRate_PRMMktgActivitiesPortalEventsProcess<TEntity> : BPMSoft.Configuration.CurrencyRate_PRMPortalEventsProcess<TEntity> where TEntity : CurrencyRate
	{

		public CurrencyRate_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CurrencyRate_PRMMktgActivitiesPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4db56493-b205-4b39-931c-5379058adc23");
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

	#region Class: CurrencyRate_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public class CurrencyRate_PRMMktgActivitiesPortalEventsProcess : CurrencyRate_PRMMktgActivitiesPortalEventsProcess<CurrencyRate>
	{

		public CurrencyRate_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CurrencyRate_PRMMktgActivitiesPortalEventsProcess

	public partial class CurrencyRate_PRMMktgActivitiesPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CurrencyRateEventsProcess

	/// <exclude/>
	public class CurrencyRateEventsProcess : CurrencyRate_PRMMktgActivitiesPortalEventsProcess
	{

		public CurrencyRateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

