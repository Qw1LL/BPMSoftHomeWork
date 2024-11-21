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

	#region Class: RelationshipGroupSchema

	/// <exclude/>
	public class RelationshipGroupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RelationshipGroupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RelationshipGroupSchema(RelationshipGroupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RelationshipGroupSchema(RelationshipGroupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9");
			RealUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9");
			Name = "RelationshipGroup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a2e8b2de-3b11-4b16-8053-9cd68a9b98de")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("39a671cf-9728-4a30-b11d-f1632829c5b2")) == null) {
				Columns.Add(CreateColorColumn());
			}
			if (Columns.FindByUId(new Guid("f1e40ca0-3633-431c-8bae-a669c71f9274")) == null) {
				Columns.Add(CreateCommentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a2e8b2de-3b11-4b16-8053-9cd68a9b98de"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"),
				ModifiedInSchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"),
				CreatedInPackageId = new Guid("7bb0c95b-a3ab-47dd-bb72-806dfee59bfe")
			};
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("39a671cf-9728-4a30-b11d-f1632829c5b2"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"),
				ModifiedInSchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"),
				CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f1e40ca0-3633-431c-8bae-a669c71f9274"),
				Name = @"Comment",
				CreatedInSchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"),
				ModifiedInSchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"),
				CreatedInPackageId = new Guid("b81aa09a-4bef-424b-9192-2333ac450804")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RelationshipGroup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RelationshipGroup_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RelationshipGroupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RelationshipGroupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9"));
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipGroup

	/// <summary>
	/// Relationship group.
	/// </summary>
	public class RelationshipGroup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RelationshipGroup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationshipGroup";
		}

		public RelationshipGroup(RelationshipGroup source)
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
		/// Color.
		/// </summary>
		public string Color {
			get {
				return GetTypedColumnValue<string>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Comment.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RelationshipGroup_RelationshipDesignerEventsProcess(UserConnection);
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
			return new RelationshipGroup(this);
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipGroup_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class RelationshipGroup_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RelationshipGroup
	{

		public RelationshipGroup_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RelationshipGroup_RelationshipDesignerEventsProcess";
			SchemaUId = new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("18d80e5d-cc8d-4e2d-ba05-c6e42bc462c9");
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

	#region Class: RelationshipGroup_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class RelationshipGroup_RelationshipDesignerEventsProcess : RelationshipGroup_RelationshipDesignerEventsProcess<RelationshipGroup>
	{

		public RelationshipGroup_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RelationshipGroup_RelationshipDesignerEventsProcess

	public partial class RelationshipGroup_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RelationshipGroupEventsProcess

	/// <exclude/>
	public class RelationshipGroupEventsProcess : RelationshipGroup_RelationshipDesignerEventsProcess
	{

		public RelationshipGroupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

