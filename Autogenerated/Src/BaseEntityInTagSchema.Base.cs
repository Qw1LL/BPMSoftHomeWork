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

	#region Class: BaseEntityInTagSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseEntityInTagSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseEntityInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEntityInTagSchema(BaseEntityInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEntityInTagSchema(BaseEntityInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			RealUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			Name = "BaseEntityInTag";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b48bfc16-bdfd-4658-b339-1f02b5a7f342")) == null) {
				Columns.Add(CreateTagColumn());
			}
			if (Columns.FindByUId(new Guid("a3eb8e36-6d55-4d8d-9c14-102bc79fe48a")) == null) {
				Columns.Add(CreateEntityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b48bfc16-bdfd-4658-b339-1f02b5a7f342"),
				Name = @"Tag",
				ReferenceSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				ModifiedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3eb8e36-6d55-4d8d-9c14-102bc79fe48a"),
				Name = @"Entity",
				ReferenceSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				ModifiedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseEntityInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEntityInTag_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEntityInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEntityInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5894a2b0-51d5-419a-82bb-238674634270"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityInTag

	/// <summary>
	/// Base tag in base object.
	/// </summary>
	public class BaseEntityInTag : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseEntityInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEntityInTag";
		}

		public BaseEntityInTag(BaseEntityInTag source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TagId {
			get {
				return GetTypedColumnValue<Guid>("TagId");
			}
			set {
				SetColumnValue("TagId", value);
				_tag = null;
			}
		}

		/// <exclude/>
		public string TagName {
			get {
				return GetTypedColumnValue<string>("TagName");
			}
			set {
				SetColumnValue("TagName", value);
				if (_tag != null) {
					_tag.Name = value;
				}
			}
		}

		private Lookup _tag;
		/// <summary>
		/// Tag.
		/// </summary>
		public Lookup Tag {
			get {
				return _tag ??
					(_tag = LookupColumnEntities.GetEntity("Tag") as Lookup);
			}
		}

		/// <exclude/>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
				_entity = null;
			}
		}

		/// <exclude/>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
				if (_entity != null) {
					_entity.Name = value;
				}
			}
		}

		private Lookup _entity;
		/// <summary>
		/// Object.
		/// </summary>
		public Lookup Entity {
			get {
				return _entity ??
					(_entity = LookupColumnEntities.GetEntity("Entity") as Lookup);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseEntityInTag_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseEntityInTagDeleted", e);
			Validating += (s, e) => ThrowEvent("BaseEntityInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseEntityInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityInTag_BaseEventsProcess

	/// <exclude/>
	public partial class BaseEntityInTag_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseEntityInTag
	{

		public BaseEntityInTag_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEntityInTag_BaseEventsProcess";
			SchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5894a2b0-51d5-419a-82bb-238674634270");
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

	#region Class: BaseEntityInTag_BaseEventsProcess

	/// <exclude/>
	public class BaseEntityInTag_BaseEventsProcess : BaseEntityInTag_BaseEventsProcess<BaseEntityInTag>
	{

		public BaseEntityInTag_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseEntityInTag_BaseEventsProcess

	public partial class BaseEntityInTag_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseEntityInTagEventsProcess

	/// <exclude/>
	public class BaseEntityInTagEventsProcess : BaseEntityInTag_BaseEventsProcess
	{

		public BaseEntityInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

