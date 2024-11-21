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

	#region Class: TimeZoneSchema

	/// <exclude/>
	public class TimeZoneSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public TimeZoneSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TimeZoneSchema(TimeZoneSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TimeZoneSchema(TimeZoneSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f");
			RealUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f");
			Name = "TimeZone";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d76d123f-4b5e-4751-b093-10c91e4569d3")) == null) {
				Columns.Add(CreateOffsetColumn());
			}
			if (Columns.FindByUId(new Guid("6f350478-e465-4e81-8df2-59426ebd2890")) == null) {
				Columns.Add(CreateCodeAmericanColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOffsetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d76d123f-4b5e-4751-b093-10c91e4569d3"),
				Name = @"Offset",
				CreatedInSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				ModifiedInSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeAmericanColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6f350478-e465-4e81-8df2-59426ebd2890"),
				Name = @"CodeAmerican",
				CreatedInSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				ModifiedInSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TimeZone(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TimeZone_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TimeZoneSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TimeZoneSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"));
		}

		#endregion

	}

	#endregion

	#region Class: TimeZone

	/// <summary>
	/// Time zone.
	/// </summary>
	public class TimeZone : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public TimeZone(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TimeZone";
		}

		public TimeZone(TimeZone source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Time zone offset.
		/// </summary>
		public string Offset {
			get {
				return GetTypedColumnValue<string>("Offset");
			}
			set {
				SetColumnValue("Offset", value);
			}
		}

		/// <summary>
		/// American code.
		/// </summary>
		public string CodeAmerican {
			get {
				return GetTypedColumnValue<string>("CodeAmerican");
			}
			set {
				SetColumnValue("CodeAmerican", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TimeZone_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TimeZoneDeleted", e);
			Deleting += (s, e) => ThrowEvent("TimeZoneDeleting", e);
			Inserted += (s, e) => ThrowEvent("TimeZoneInserted", e);
			Inserting += (s, e) => ThrowEvent("TimeZoneInserting", e);
			Saved += (s, e) => ThrowEvent("TimeZoneSaved", e);
			Saving += (s, e) => ThrowEvent("TimeZoneSaving", e);
			Validating += (s, e) => ThrowEvent("TimeZoneValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TimeZone(this);
		}

		#endregion

	}

	#endregion

	#region Class: TimeZone_BaseEventsProcess

	/// <exclude/>
	public partial class TimeZone_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : TimeZone
	{

		public TimeZone_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TimeZone_BaseEventsProcess";
			SchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f");
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

	#region Class: TimeZone_BaseEventsProcess

	/// <exclude/>
	public class TimeZone_BaseEventsProcess : TimeZone_BaseEventsProcess<TimeZone>
	{

		public TimeZone_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TimeZone_BaseEventsProcess

	public partial class TimeZone_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TimeZoneEventsProcess

	/// <exclude/>
	public class TimeZoneEventsProcess : TimeZone_BaseEventsProcess
	{

		public TimeZoneEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

