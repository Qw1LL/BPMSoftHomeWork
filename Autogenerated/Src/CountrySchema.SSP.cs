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

	#region Class: CountrySchema

	/// <exclude/>
	public class CountrySchema : BPMSoft.Configuration.Country_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public CountrySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CountrySchema(CountrySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CountrySchema(CountrySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("2dbcc8f8-57ca-47c0-8d3c-71476373b22b");
			Name = "Country";
			ParentSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
			ExtendParent = true;
			CreatedInPackageId = new Guid("10676561-1f93-46bf-90be-fe5cd67025e0");
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
			return new Country(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Country_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CountrySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CountrySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2dbcc8f8-57ca-47c0-8d3c-71476373b22b"));
		}

		#endregion

	}

	#endregion

	#region Class: Country

	/// <summary>
	/// Country.
	/// </summary>
	public class Country : BPMSoft.Configuration.Country_Base_BPMSoft
	{

		#region Constructors: Public

		public Country(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Country";
		}

		public Country(Country source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Country_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CountryDeleted", e);
			Validating += (s, e) => ThrowEvent("CountryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Country(this);
		}

		#endregion

	}

	#endregion

	#region Class: Country_SSPEventsProcess

	/// <exclude/>
	public partial class Country_SSPEventsProcess<TEntity> : BPMSoft.Configuration.Country_BaseEventsProcess<TEntity> where TEntity : Country
	{

		public Country_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Country_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2dbcc8f8-57ca-47c0-8d3c-71476373b22b");
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

	#region Class: Country_SSPEventsProcess

	/// <exclude/>
	public class Country_SSPEventsProcess : Country_SSPEventsProcess<Country>
	{

		public Country_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Country_SSPEventsProcess

	public partial class Country_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CountryEventsProcess

	/// <exclude/>
	public class CountryEventsProcess : Country_SSPEventsProcess
	{

		public CountryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

