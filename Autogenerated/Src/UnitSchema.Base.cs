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

	#region Class: Unit_Base_BPMSoftSchema

	/// <exclude/>
	public class Unit_Base_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public Unit_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Unit_Base_BPMSoftSchema(Unit_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Unit_Base_BPMSoftSchema(Unit_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
			RealUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
			Name = "Unit_Base_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4a41775a-ee6f-4bb5-9725-025397d02775")) == null) {
				Columns.Add(CreateShortNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateShortNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4a41775a-ee6f-4bb5-9725-025397d02775"),
				Name = @"ShortName",
				CreatedInSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b"),
				ModifiedInSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Unit_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Unit_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Unit_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Unit_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38f2220e-7085-494d-b4c9-396666b6327b"));
		}

		#endregion

	}

	#endregion

	#region Class: Unit_Base_BPMSoft

	/// <summary>
	/// Units of Measure.
	/// </summary>
	public class Unit_Base_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Unit_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Unit_Base_BPMSoft";
		}

		public Unit_Base_BPMSoft(Unit_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Short Name.
		/// </summary>
		public string ShortName {
			get {
				return GetTypedColumnValue<string>("ShortName");
			}
			set {
				SetColumnValue("ShortName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Unit_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Unit_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Unit_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Unit_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Unit_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Unit_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Unit_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Unit_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Unit_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Unit_BaseEventsProcess

	/// <exclude/>
	public partial class Unit_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Unit_Base_BPMSoft
	{

		public Unit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Unit_BaseEventsProcess";
			SchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
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

	#region Class: Unit_BaseEventsProcess

	/// <exclude/>
	public class Unit_BaseEventsProcess : Unit_BaseEventsProcess<Unit_Base_BPMSoft>
	{

		public Unit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Unit_BaseEventsProcess

	public partial class Unit_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

