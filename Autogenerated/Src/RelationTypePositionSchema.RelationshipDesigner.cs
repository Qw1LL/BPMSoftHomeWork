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

	#region Class: RelationTypePositionSchema

	/// <exclude/>
	public class RelationTypePositionSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public RelationTypePositionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationTypePositionSchema(RelationTypePositionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationTypePositionSchema(RelationTypePositionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb");
			RealUId = new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb");
			Name = "RelationTypePosition";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2da77960-63f3-47e9-b231-8c186dcb507d")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2da77960-63f3-47e9-b231-8c186dcb507d"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb"),
				ModifiedInSchemaUId = new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb"),
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RelationTypePosition(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationTypePosition_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationTypePositionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationTypePositionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationTypePosition

	/// <summary>
	/// Relationship type position.
	/// </summary>
	public class RelationTypePosition : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public RelationTypePosition(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationTypePosition";
		}

		public RelationTypePosition(RelationTypePosition source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public int Value {
			get {
				return GetTypedColumnValue<int>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationTypePosition_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationTypePosition(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationTypePosition_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationTypePosition_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : RelationTypePosition
	{

		public RelationTypePosition_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationTypePosition_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("06b24f1f-c1d3-44aa-b3fa-2a074edd6efb");
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

	#region Class: RelationTypePosition_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationTypePosition_RelationshipDesignerEventsProcess : RelationTypePosition_RelationshipDesignerEventsProcess<RelationTypePosition>
	{

		public RelationTypePosition_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationTypePosition_RelationshipDesignerEventsProcess

	public partial class RelationTypePosition_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationTypePositionEventsProcess

	/// <exclude/>
	public class RelationTypePositionEventsProcess : RelationTypePosition_RelationshipDesignerEventsProcess
	{

		public RelationTypePositionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

