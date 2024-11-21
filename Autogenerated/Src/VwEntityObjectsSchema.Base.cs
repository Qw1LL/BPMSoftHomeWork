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

	#region Class: VwEntityObjectsSchema

	/// <exclude/>
	public class VwEntityObjectsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwEntityObjectsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwEntityObjectsSchema(VwEntityObjectsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwEntityObjectsSchema(VwEntityObjectsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417");
			RealUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417");
			Name = "VwEntityObjects";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("99645d16-5fa5-4efe-84a2-7e57dc32ad53")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("99645d16-5fa5-4efe-84a2-7e57dc32ad53"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				ModifiedInSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f5cea5a0-d905-472e-827e-0f76e4e03fdc"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				ModifiedInSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwEntityObjects(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwEntityObjects_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwEntityObjectsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwEntityObjectsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"));
		}

		#endregion

	}

	#endregion

	#region Class: VwEntityObjects

	/// <summary>
	/// Entity objects (view).
	/// </summary>
	public class VwEntityObjects : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwEntityObjects(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwEntityObjects";
		}

		public VwEntityObjects(VwEntityObjects source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwEntityObjects_BaseEventsProcess(UserConnection);
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
			return new VwEntityObjects(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwEntityObjects_BaseEventsProcess

	/// <exclude/>
	public partial class VwEntityObjects_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwEntityObjects
	{

		public VwEntityObjects_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwEntityObjects_BaseEventsProcess";
			SchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417");
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

	#region Class: VwEntityObjects_BaseEventsProcess

	/// <exclude/>
	public class VwEntityObjects_BaseEventsProcess : VwEntityObjects_BaseEventsProcess<VwEntityObjects>
	{

		public VwEntityObjects_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwEntityObjects_BaseEventsProcess

	public partial class VwEntityObjects_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwEntityObjectsEventsProcess

	/// <exclude/>
	public class VwEntityObjectsEventsProcess : VwEntityObjects_BaseEventsProcess
	{

		public VwEntityObjectsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

