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

	#region Class: CitySchema

	/// <exclude/>
	public class CitySchema : BPMSoft.Configuration.City_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public CitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CitySchema(CitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CitySchema(CitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6fd3d1b7-94d5-4b45-a0a8-80769ffe3541");
			Name = "City";
			ParentSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe");
			ExtendParent = true;
			CreatedInPackageId = new Guid("1bc37faf-30bf-4d4a-b067-5fd52b4ccffd");
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
			return new City(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new City_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6fd3d1b7-94d5-4b45-a0a8-80769ffe3541"));
		}

		#endregion

	}

	#endregion

	#region Class: City

	/// <summary>
	/// City.
	/// </summary>
	public class City : BPMSoft.Configuration.City_Base_BPMSoft
	{

		#region Constructors: Public

		public City(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "City";
		}

		public City(City source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new City_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CityDeleted", e);
			Validating += (s, e) => ThrowEvent("CityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new City(this);
		}

		#endregion

	}

	#endregion

	#region Class: City_SSPEventsProcess

	/// <exclude/>
	public partial class City_SSPEventsProcess<TEntity> : BPMSoft.Configuration.City_BaseEventsProcess<TEntity> where TEntity : City
	{

		public City_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "City_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6fd3d1b7-94d5-4b45-a0a8-80769ffe3541");
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

	#region Class: City_SSPEventsProcess

	/// <exclude/>
	public class City_SSPEventsProcess : City_SSPEventsProcess<City>
	{

		public City_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: City_SSPEventsProcess

	public partial class City_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CityEventsProcess

	/// <exclude/>
	public class CityEventsProcess : City_SSPEventsProcess
	{

		public CityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

