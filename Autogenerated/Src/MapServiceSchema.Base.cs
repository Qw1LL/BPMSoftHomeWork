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

	#region Class: MapServiceSchema

	/// <exclude/>
	public class MapServiceSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public MapServiceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MapServiceSchema(MapServiceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MapServiceSchema(MapServiceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08");
			RealUId = new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08");
			Name = "MapService";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MapService(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MapService_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MapServiceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MapServiceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08"));
		}

		#endregion

	}

	#endregion

	#region Class: MapService

	/// <summary>
	/// Map service.
	/// </summary>
	public class MapService : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public MapService(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MapService";
		}

		public MapService(MapService source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MapService_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MapServiceDeleted", e);
			Inserting += (s, e) => ThrowEvent("MapServiceInserting", e);
			Validating += (s, e) => ThrowEvent("MapServiceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MapService(this);
		}

		#endregion

	}

	#endregion

	#region Class: MapService_BaseEventsProcess

	/// <exclude/>
	public partial class MapService_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : MapService
	{

		public MapService_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MapService_BaseEventsProcess";
			SchemaUId = new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b261274b-ac22-426c-a8b0-91444d9bbc08");
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

	#region Class: MapService_BaseEventsProcess

	/// <exclude/>
	public class MapService_BaseEventsProcess : MapService_BaseEventsProcess<MapService>
	{

		public MapService_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MapService_BaseEventsProcess

	public partial class MapService_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MapServiceEventsProcess

	/// <exclude/>
	public class MapServiceEventsProcess : MapService_BaseEventsProcess
	{

		public MapServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

