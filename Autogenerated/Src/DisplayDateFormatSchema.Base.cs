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

	#region Class: DisplayDateFormatSchema

	/// <exclude/>
	public class DisplayDateFormatSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DisplayDateFormatSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DisplayDateFormatSchema(DisplayDateFormatSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DisplayDateFormatSchema(DisplayDateFormatSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
			RealUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
			Name = "DisplayDateFormat";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateFormatColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateFormatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7d253e86-83f1-41da-9a8b-e9c8077b78ff"),
				Name = @"Format",
				CreatedInSchemaUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56"),
				ModifiedInSchemaUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56"),
				CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DisplayDateFormat(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DisplayDateFormat_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DisplayDateFormatSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DisplayDateFormatSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56"));
		}

		#endregion

	}

	#endregion

	#region Class: DisplayDateFormat

	/// <summary>
	/// Display date format.
	/// </summary>
	public class DisplayDateFormat : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DisplayDateFormat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DisplayDateFormat";
		}

		public DisplayDateFormat(DisplayDateFormat source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Display format datetime.
		/// </summary>
		public string Format {
			get {
				return GetTypedColumnValue<string>("Format");
			}
			set {
				SetColumnValue("Format", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DisplayDateFormat_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DisplayDateFormatDeleted", e);
			Validating += (s, e) => ThrowEvent("DisplayDateFormatValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DisplayDateFormat(this);
		}

		#endregion

	}

	#endregion

	#region Class: DisplayDateFormat_BaseEventsProcess

	/// <exclude/>
	public partial class DisplayDateFormat_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DisplayDateFormat
	{

		public DisplayDateFormat_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DisplayDateFormat_BaseEventsProcess";
			SchemaUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
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

	#region Class: DisplayDateFormat_BaseEventsProcess

	/// <exclude/>
	public class DisplayDateFormat_BaseEventsProcess : DisplayDateFormat_BaseEventsProcess<DisplayDateFormat>
	{

		public DisplayDateFormat_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DisplayDateFormat_BaseEventsProcess

	public partial class DisplayDateFormat_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DisplayDateFormatEventsProcess

	/// <exclude/>
	public class DisplayDateFormatEventsProcess : DisplayDateFormat_BaseEventsProcess
	{

		public DisplayDateFormatEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

