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

	#region Class: EsnNotificationSettingsSchema

	/// <exclude/>
	public class EsnNotificationSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EsnNotificationSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EsnNotificationSettingsSchema(EsnNotificationSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EsnNotificationSettingsSchema(EsnNotificationSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9e4335ab-f556-4792-984c-220cf7a78508");
			RealUId = new Guid("9e4335ab-f556-4792-984c-220cf7a78508");
			Name = "EsnNotificationSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0a08182-f260-49ff-9532-682c4ec084fe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f65b1159-42f8-b6b6-277c-612bcd79f597")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("f51294f9-3943-b0c8-08b1-aff103a192e0")) == null) {
				Columns.Add(CreateDenyNotifyOfNewSocialMessagesColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f65b1159-42f8-b6b6-277c-612bcd79f597"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9e4335ab-f556-4792-984c-220cf7a78508"),
				ModifiedInSchemaUId = new Guid("9e4335ab-f556-4792-984c-220cf7a78508"),
				CreatedInPackageId = new Guid("e0a08182-f260-49ff-9532-682c4ec084fe")
			};
		}

		protected virtual EntitySchemaColumn CreateDenyNotifyOfNewSocialMessagesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f51294f9-3943-b0c8-08b1-aff103a192e0"),
				Name = @"DenyNotifyOfNewSocialMessages",
				CreatedInSchemaUId = new Guid("9e4335ab-f556-4792-984c-220cf7a78508"),
				ModifiedInSchemaUId = new Guid("9e4335ab-f556-4792-984c-220cf7a78508"),
				CreatedInPackageId = new Guid("e0a08182-f260-49ff-9532-682c4ec084fe")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EsnNotificationSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EsnNotificationSettings_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EsnNotificationSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EsnNotificationSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9e4335ab-f556-4792-984c-220cf7a78508"));
		}

		#endregion

	}

	#endregion

	#region Class: EsnNotificationSettings

	/// <summary>
	/// EsnNotificationSettings.
	/// </summary>
	public class EsnNotificationSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EsnNotificationSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EsnNotificationSettings";
		}

		public EsnNotificationSettings(EsnNotificationSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Deny notify of new social messages.
		/// </summary>
		public bool DenyNotifyOfNewSocialMessages {
			get {
				return GetTypedColumnValue<bool>("DenyNotifyOfNewSocialMessages");
			}
			set {
				SetColumnValue("DenyNotifyOfNewSocialMessages", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EsnNotificationSettings_ESNEventsProcess(UserConnection);
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
			return new EsnNotificationSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: EsnNotificationSettings_ESNEventsProcess

	/// <exclude/>
	public partial class EsnNotificationSettings_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EsnNotificationSettings
	{

		public EsnNotificationSettings_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EsnNotificationSettings_ESNEventsProcess";
			SchemaUId = new Guid("9e4335ab-f556-4792-984c-220cf7a78508");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9e4335ab-f556-4792-984c-220cf7a78508");
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

	#region Class: EsnNotificationSettings_ESNEventsProcess

	/// <exclude/>
	public class EsnNotificationSettings_ESNEventsProcess : EsnNotificationSettings_ESNEventsProcess<EsnNotificationSettings>
	{

		public EsnNotificationSettings_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EsnNotificationSettings_ESNEventsProcess

	public partial class EsnNotificationSettings_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EsnNotificationSettingsEventsProcess

	/// <exclude/>
	public class EsnNotificationSettingsEventsProcess : EsnNotificationSettings_ESNEventsProcess
	{

		public EsnNotificationSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

