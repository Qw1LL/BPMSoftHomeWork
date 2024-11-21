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

	#region Class: LDAPUserInLDAPGroupSchema

	/// <exclude/>
	public class LDAPUserInLDAPGroupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LDAPUserInLDAPGroupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LDAPUserInLDAPGroupSchema(LDAPUserInLDAPGroupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LDAPUserInLDAPGroupSchema(LDAPUserInLDAPGroupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6");
			RealUId = new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6");
			Name = "LDAPUserInLDAPGroup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("10e3f151-1fb0-4f3a-9c3a-02a77792882c")) == null) {
				Columns.Add(CreateLDAPUserColumn());
			}
			if (Columns.FindByUId(new Guid("55927007-3e61-4aae-a3c8-89576ae87b06")) == null) {
				Columns.Add(CreateLDAPGroupColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLDAPUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("10e3f151-1fb0-4f3a-9c3a-02a77792882c"),
				Name = @"LDAPUser",
				ReferenceSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6"),
				ModifiedInSchemaUId = new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("55927007-3e61-4aae-a3c8-89576ae87b06"),
				Name = @"LDAPGroup",
				ReferenceSchemaUId = new Guid("2811d726-f327-44be-9548-c8d90edee2cb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6"),
				ModifiedInSchemaUId = new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LDAPUserInLDAPGroup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LDAPUserInLDAPGroup_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LDAPUserInLDAPGroupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LDAPUserInLDAPGroupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6"));
		}

		#endregion

	}

	#endregion

	#region Class: LDAPUserInLDAPGroup

	/// <summary>
	/// LDAP user in LDAP group.
	/// </summary>
	public class LDAPUserInLDAPGroup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LDAPUserInLDAPGroup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LDAPUserInLDAPGroup";
		}

		public LDAPUserInLDAPGroup(LDAPUserInLDAPGroup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LDAPUserId {
			get {
				return GetTypedColumnValue<Guid>("LDAPUserId");
			}
			set {
				SetColumnValue("LDAPUserId", value);
				_lDAPUser = null;
			}
		}

		/// <exclude/>
		public string LDAPUserName {
			get {
				return GetTypedColumnValue<string>("LDAPUserName");
			}
			set {
				SetColumnValue("LDAPUserName", value);
				if (_lDAPUser != null) {
					_lDAPUser.Name = value;
				}
			}
		}

		private LDAPElement _lDAPUser;
		/// <summary>
		/// LDAP user.
		/// </summary>
		public LDAPElement LDAPUser {
			get {
				return _lDAPUser ??
					(_lDAPUser = LookupColumnEntities.GetEntity("LDAPUser") as LDAPElement);
			}
		}

		/// <exclude/>
		public Guid LDAPGroupId {
			get {
				return GetTypedColumnValue<Guid>("LDAPGroupId");
			}
			set {
				SetColumnValue("LDAPGroupId", value);
				_lDAPGroup = null;
			}
		}

		/// <exclude/>
		public string LDAPGroupName {
			get {
				return GetTypedColumnValue<string>("LDAPGroupName");
			}
			set {
				SetColumnValue("LDAPGroupName", value);
				if (_lDAPGroup != null) {
					_lDAPGroup.Name = value;
				}
			}
		}

		private LDAPElement _lDAPGroup;
		/// <summary>
		/// LDAP group.
		/// </summary>
		public LDAPElement LDAPGroup {
			get {
				return _lDAPGroup ??
					(_lDAPGroup = LookupColumnEntities.GetEntity("LDAPGroup") as LDAPElement);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LDAPUserInLDAPGroup_LDAPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LDAPUserInLDAPGroupDeleted", e);
			Validating += (s, e) => ThrowEvent("LDAPUserInLDAPGroupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LDAPUserInLDAPGroup(this);
		}

		#endregion

	}

	#endregion

	#region Class: LDAPUserInLDAPGroup_LDAPEventsProcess

	/// <exclude/>
	public partial class LDAPUserInLDAPGroup_LDAPEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LDAPUserInLDAPGroup
	{

		public LDAPUserInLDAPGroup_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LDAPUserInLDAPGroup_LDAPEventsProcess";
			SchemaUId = new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5b4fa189-8f4e-44e7-b0b9-2bb16ed96ab6");
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

	#region Class: LDAPUserInLDAPGroup_LDAPEventsProcess

	/// <exclude/>
	public class LDAPUserInLDAPGroup_LDAPEventsProcess : LDAPUserInLDAPGroup_LDAPEventsProcess<LDAPUserInLDAPGroup>
	{

		public LDAPUserInLDAPGroup_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LDAPUserInLDAPGroup_LDAPEventsProcess

	public partial class LDAPUserInLDAPGroup_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LDAPUserInLDAPGroupEventsProcess

	/// <exclude/>
	public class LDAPUserInLDAPGroupEventsProcess : LDAPUserInLDAPGroup_LDAPEventsProcess
	{

		public LDAPUserInLDAPGroupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

