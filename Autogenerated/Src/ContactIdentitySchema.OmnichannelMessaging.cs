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

	#region Class: ContactIdentitySchema

	/// <exclude/>
	public class ContactIdentitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContactIdentitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactIdentitySchema(ContactIdentitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactIdentitySchema(ContactIdentitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIChannelIdentityIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("6b7d9304-1469-4a27-bcd8-5dbc7554b65f");
			index.Name = "IChannelIdentity";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("6f05d58c-8c35-4460-8cdc-92bf987e5f26");
			EntitySchemaIndexColumn channelIdentityIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("dff56016-a7a0-da58-3bcc-7119624f0d82"),
				ColumnUId = new Guid("676b4757-a5e6-45f7-8e5e-957c9cbc7961"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("6f05d58c-8c35-4460-8cdc-92bf987e5f26"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(channelIdentityIndexColumn);
			EntitySchemaIndexColumn channelIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("6ea8ed2b-5789-e8af-4021-98ae0930d5f2"),
				ColumnUId = new Guid("d64de4f8-26a1-4a08-b2a2-897b1bd44f5e"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("6f05d58c-8c35-4460-8cdc-92bf987e5f26"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(channelIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34");
			RealUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34");
			Name = "ContactIdentity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f4bb87b8-a7da-4196-8cb4-692e5702c6f2")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("d64de4f8-26a1-4a08-b2a2-897b1bd44f5e")) == null) {
				Columns.Add(CreateChannelColumn());
			}
			if (Columns.FindByUId(new Guid("676b4757-a5e6-45f7-8e5e-957c9cbc7961")) == null) {
				Columns.Add(CreateChannelIdentityColumn());
			}
			if (Columns.FindByUId(new Guid("02a39b2c-2ed4-7f11-609d-ed929eb921bc")) == null) {
				Columns.Add(CreateIsGuestUserColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f4bb87b8-a7da-4196-8cb4-692e5702c6f2"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				ModifiedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae")
			};
		}

		protected virtual EntitySchemaColumn CreateChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d64de4f8-26a1-4a08-b2a2-897b1bd44f5e"),
				Name = @"Channel",
				ReferenceSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				ModifiedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae")
			};
		}

		protected virtual EntitySchemaColumn CreateChannelIdentityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("676b4757-a5e6-45f7-8e5e-957c9cbc7961"),
				Name = @"ChannelIdentity",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				ModifiedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae")
			};
		}

		protected virtual EntitySchemaColumn CreateIsGuestUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("02a39b2c-2ed4-7f11-609d-ed929eb921bc"),
				Name = @"IsGuestUser",
				CreatedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				ModifiedInSchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIChannelIdentityIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactIdentity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactIdentity_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactIdentitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactIdentitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactIdentity

	/// <summary>
	/// Contact identity.
	/// </summary>
	public class ContactIdentity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContactIdentity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactIdentity";
		}

		public ContactIdentity(ContactIdentity source)
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
		public string ChannelName {
			get {
				return GetTypedColumnValue<string>("ChannelName");
			}
			set {
				SetColumnValue("ChannelName", value);
				if (_channel != null) {
					_channel.Name = value;
				}
			}
		}

		private Channel _channel;
		/// <summary>
		/// Channel.
		/// </summary>
		public Channel Channel {
			get {
				return _channel ??
					(_channel = LookupColumnEntities.GetEntity("Channel") as Channel);
			}
		}

		/// <summary>
		/// Channel identity.
		/// </summary>
		public string ChannelIdentity {
			get {
				return GetTypedColumnValue<string>("ChannelIdentity");
			}
			set {
				SetColumnValue("ChannelIdentity", value);
			}
		}

		/// <summary>
		/// Is user in guest mode.
		/// </summary>
		/// <remarks>
		/// Determines is user in guest mode.
		/// </remarks>
		public bool IsGuestUser {
			get {
				return GetTypedColumnValue<bool>("IsGuestUser");
			}
			set {
				SetColumnValue("IsGuestUser", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactIdentity_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new ContactIdentity(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactIdentity_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class ContactIdentity_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContactIdentity
	{

		public ContactIdentity_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactIdentity_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b6ad0ee5-5a1a-445b-8b34-94373fc7db34");
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

	#region Class: ContactIdentity_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class ContactIdentity_OmnichannelMessagingEventsProcess : ContactIdentity_OmnichannelMessagingEventsProcess<ContactIdentity>
	{

		public ContactIdentity_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactIdentity_OmnichannelMessagingEventsProcess

	public partial class ContactIdentity_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactIdentityEventsProcess

	/// <exclude/>
	public class ContactIdentityEventsProcess : ContactIdentity_OmnichannelMessagingEventsProcess
	{

		public ContactIdentityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

