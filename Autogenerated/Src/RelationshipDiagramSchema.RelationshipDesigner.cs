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

	#region Class: RelationshipDiagramSchema

	/// <exclude/>
	public class RelationshipDiagramSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationshipDiagramSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationshipDiagramSchema(RelationshipDiagramSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationshipDiagramSchema(RelationshipDiagramSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("76d539d4-1372-4065-8863-d63177e087b8");
			RealUId = new Guid("76d539d4-1372-4065-8863-d63177e087b8");
			Name = "RelationshipDiagram";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe");
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
			return new RelationshipDiagram(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationshipDiagram_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationshipDiagramSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationshipDiagramSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76d539d4-1372-4065-8863-d63177e087b8"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipDiagram

	/// <summary>
	/// Relationship diagram.
	/// </summary>
	public class RelationshipDiagram : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RelationshipDiagram(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationshipDiagram";
		}

		public RelationshipDiagram(RelationshipDiagram source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationshipDiagram_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationshipDiagram(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipDiagram_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationshipDiagram_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RelationshipDiagram
	{

		public RelationshipDiagram_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationshipDiagram_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("76d539d4-1372-4065-8863-d63177e087b8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("76d539d4-1372-4065-8863-d63177e087b8");
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

	#region Class: RelationshipDiagram_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationshipDiagram_RelationshipDesignerEventsProcess : RelationshipDiagram_RelationshipDesignerEventsProcess<RelationshipDiagram>
	{

		public RelationshipDiagram_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationshipDiagram_RelationshipDesignerEventsProcess

	public partial class RelationshipDiagram_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationshipDiagramEventsProcess

	/// <exclude/>
	public class RelationshipDiagramEventsProcess : RelationshipDiagram_RelationshipDesignerEventsProcess
	{

		public RelationshipDiagramEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

