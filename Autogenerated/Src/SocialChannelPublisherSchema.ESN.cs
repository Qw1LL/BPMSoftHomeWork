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

	#region Class: SocialChannelPublisherSchema

	/// <exclude/>
	public class SocialChannelPublisherSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialChannelPublisherSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialChannelPublisherSchema(SocialChannelPublisherSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialChannelPublisherSchema(SocialChannelPublisherSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			RealUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			Name = "SocialChannelPublisher";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7def91e3-e8bd-4db1-9428-55a966de424d")) == null) {
				Columns.Add(CreateChannelColumn());
			}
			if (Columns.FindByUId(new Guid("76ab6eee-da33-4f32-a3ed-03e9bc2867a9")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7def91e3-e8bd-4db1-9428-55a966de424d"),
				Name = @"Channel",
				ReferenceSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4"),
				ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("76ab6eee-da33-4f32-a3ed-03e9bc2867a9"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4"),
				ModifiedInSchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialChannelPublisher(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialChannelPublisher_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialChannelPublisherSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialChannelPublisherSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannelPublisher

	/// <summary>
	/// Channel publisher.
	/// </summary>
	public class SocialChannelPublisher : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialChannelPublisher(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialChannelPublisher";
		}

		public SocialChannelPublisher(SocialChannelPublisher source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ChannelId {
			get {
				return GetTypedColumnValue<Guid>("ChannelId");
			}
			set {
				SetColumnValue("ChannelId", value);
				_channel = null;
			}
		}

		/// <exclude/>
		public string ChannelTitle {
			get {
				return GetTypedColumnValue<string>("ChannelTitle");
			}
			set {
				SetColumnValue("ChannelTitle", value);
				if (_channel != null) {
					_channel.Title = value;
				}
			}
		}

		private SocialChannel _channel;
		/// <summary>
		/// Channel.
		/// </summary>
		public SocialChannel Channel {
			get {
				return _channel ??
					(_channel = LookupColumnEntities.GetEntity("Channel") as SocialChannel);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User/role.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialChannelPublisher_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialChannelPublisherDeleted", e);
			Inserting += (s, e) => ThrowEvent("SocialChannelPublisherInserting", e);
			Validating += (s, e) => ThrowEvent("SocialChannelPublisherValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialChannelPublisher(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannelPublisher_ESNEventsProcess

	/// <exclude/>
	public partial class SocialChannelPublisher_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialChannelPublisher
	{

		public SocialChannelPublisher_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialChannelPublisher_ESNEventsProcess";
			SchemaUId = new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f1eec00b-313d-4870-b068-031cf1fcccd4");
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

	#region Class: SocialChannelPublisher_ESNEventsProcess

	/// <exclude/>
	public class SocialChannelPublisher_ESNEventsProcess : SocialChannelPublisher_ESNEventsProcess<SocialChannelPublisher>
	{

		public SocialChannelPublisher_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialChannelPublisher_ESNEventsProcess

	public partial class SocialChannelPublisher_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialChannelPublisherEventsProcess

	/// <exclude/>
	public class SocialChannelPublisherEventsProcess : SocialChannelPublisher_ESNEventsProcess
	{

		public SocialChannelPublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

