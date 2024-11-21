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

	#region Class: ChannelProviderSchema

	/// <exclude/>
	public class ChannelProviderSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ChannelProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChannelProviderSchema(ChannelProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChannelProviderSchema(ChannelProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05");
			RealUId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05");
			Name = "ChannelProvider";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateIconColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8d89cfcc-5be7-446f-e28c-daa4c918da57")) == null) {
				Columns.Add(CreatePageUrlColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIconColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("1c87099b-a174-4c25-89e5-cfaa881b2ff3"),
				Name = @"Icon",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05"),
				ModifiedInSchemaUId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05"),
				CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae")
			};
		}

		protected virtual EntitySchemaColumn CreatePageUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8d89cfcc-5be7-446f-e28c-daa4c918da57"),
				Name = @"PageUrl",
				CreatedInSchemaUId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05"),
				ModifiedInSchemaUId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChannelProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChannelProvider_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChannelProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChannelProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05"));
		}

		#endregion

	}

	#endregion

	#region Class: ChannelProvider

	/// <summary>
	/// Channel provider.
	/// </summary>
	public class ChannelProvider : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ChannelProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChannelProvider";
		}

		public ChannelProvider(ChannelProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IconId {
			get {
				return GetTypedColumnValue<Guid>("IconId");
			}
			set {
				SetColumnValue("IconId", value);
				_icon = null;
			}
		}

		/// <exclude/>
		public string IconName {
			get {
				return GetTypedColumnValue<string>("IconName");
			}
			set {
				SetColumnValue("IconName", value);
				if (_icon != null) {
					_icon.Name = value;
				}
			}
		}

		private SysImage _icon;
		/// <summary>
		/// Icon.
		/// </summary>
		public SysImage Icon {
			get {
				return _icon ??
					(_icon = LookupColumnEntities.GetEntity("Icon") as SysImage);
			}
		}

		/// <summary>
		/// Url to new channel page.
		/// </summary>
		public string PageUrl {
			get {
				return GetTypedColumnValue<string>("PageUrl");
			}
			set {
				SetColumnValue("PageUrl", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChannelProvider_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new ChannelProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChannelProvider_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class ChannelProvider_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ChannelProvider
	{

		public ChannelProvider_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChannelProvider_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05");
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

	#region Class: ChannelProvider_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class ChannelProvider_OmnichannelMessagingEventsProcess : ChannelProvider_OmnichannelMessagingEventsProcess<ChannelProvider>
	{

		public ChannelProvider_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChannelProvider_OmnichannelMessagingEventsProcess

	public partial class ChannelProvider_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChannelProviderEventsProcess

	/// <exclude/>
	public class ChannelProviderEventsProcess : ChannelProvider_OmnichannelMessagingEventsProcess
	{

		public ChannelProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

