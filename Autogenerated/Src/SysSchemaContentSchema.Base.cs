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

	#region Class: SysSchemaContentSchema

	/// <exclude/>
	public class SysSchemaContentSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSchemaContentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchemaContentSchema(SysSchemaContentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchemaContentSchema(SysSchemaContentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c");
			RealUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c");
			Name = "SysSchemaContent";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("65cf9b10-832a-41e7-bbbc-13e3f06f9103")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("9dd4bd2d-470a-4c19-9476-25849ed9c562")) == null) {
				Columns.Add(CreateContentTypeColumn());
			}
			if (Columns.FindByUId(new Guid("7ab0506e-165b-4200-98be-efb65d268a49")) == null) {
				Columns.Add(CreateContentColumn());
			}
			if (Columns.FindByUId(new Guid("539c029a-3831-40b3-9a37-550a883186b8")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("65cf9b10-832a-41e7-bbbc-13e3f06f9103"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
				ModifiedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateContentTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9dd4bd2d-470a-4c19-9476-25849ed9c562"),
				Name = @"ContentType",
				CreatedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
				ModifiedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("7ab0506e-165b-4200-98be-efb65d268a49"),
				Name = @"Content",
				CreatedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
				ModifiedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("539c029a-3831-40b3-9a37-550a883186b8"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
				ModifiedInSchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"),
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
			return new SysSchemaContent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchemaContent_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchemaContentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchemaContentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaContent

	/// <summary>
	/// System schema source code.
	/// </summary>
	public class SysSchemaContent : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSchemaContent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchemaContent";
		}

		public SysSchemaContent(SysSchemaContent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// ContentType.
		/// </summary>
		public int ContentType {
			get {
				return GetTypedColumnValue<int>("ContentType");
			}
			set {
				SetColumnValue("ContentType", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// SysSchema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSchemaContent_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSchemaContentDeleted", e);
			Validating += (s, e) => ThrowEvent("SysSchemaContentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSchemaContent(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaContent_BaseEventsProcess

	/// <exclude/>
	public partial class SysSchemaContent_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSchemaContent
	{

		public SysSchemaContent_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchemaContent_BaseEventsProcess";
			SchemaUId = new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ac07cfdd-6e32-4bc5-bd87-70cb57d5b85c");
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

	#region Class: SysSchemaContent_BaseEventsProcess

	/// <exclude/>
	public class SysSchemaContent_BaseEventsProcess : SysSchemaContent_BaseEventsProcess<SysSchemaContent>
	{

		public SysSchemaContent_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchemaContent_BaseEventsProcess

	public partial class SysSchemaContent_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSchemaContentEventsProcess

	/// <exclude/>
	public class SysSchemaContentEventsProcess : SysSchemaContent_BaseEventsProcess
	{

		public SysSchemaContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

