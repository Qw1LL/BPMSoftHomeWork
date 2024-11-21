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

	#region Class: EnrchFoundAccountSchema

	/// <exclude/>
	public class EnrchFoundAccountSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EnrchFoundAccountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EnrchFoundAccountSchema(EnrchFoundAccountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EnrchFoundAccountSchema(EnrchFoundAccountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af");
			RealUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af");
			Name = "EnrchFoundAccount";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("52892006-dc64-49ff-8d7f-a70f57bce8c6")) == null) {
				Columns.Add(CreateEnrchTextEntityColumn());
			}
			if (Columns.FindByUId(new Guid("cc5b89e2-fb3e-426a-b5bf-be6f40f90ad1")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("b148feb0-a5bf-4e5f-b147-0443f25e625c")) == null) {
				Columns.Add(CreateIdentificationTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEnrchTextEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("52892006-dc64-49ff-8d7f-a70f57bce8c6"),
				Name = @"EnrchTextEntity",
				ReferenceSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af"),
				ModifiedInSchemaUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cc5b89e2-fb3e-426a-b5bf-be6f40f90ad1"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af"),
				ModifiedInSchemaUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateIdentificationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("b148feb0-a5bf-4e5f-b147-0443f25e625c"),
				Name = @"IdentificationType",
				CreatedInSchemaUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af"),
				ModifiedInSchemaUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EnrchFoundAccount(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EnrchFoundAccount_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EnrchFoundAccountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EnrchFoundAccountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af"));
		}

		#endregion

	}

	#endregion

	#region Class: EnrchFoundAccount

	/// <summary>
	/// Identified account.
	/// </summary>
	public class EnrchFoundAccount : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EnrchFoundAccount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchFoundAccount";
		}

		public EnrchFoundAccount(EnrchFoundAccount source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EnrchTextEntityId {
			get {
				return GetTypedColumnValue<Guid>("EnrchTextEntityId");
			}
			set {
				SetColumnValue("EnrchTextEntityId", value);
				_enrchTextEntity = null;
			}
		}

		/// <exclude/>
		public string EnrchTextEntityHash {
			get {
				return GetTypedColumnValue<string>("EnrchTextEntityHash");
			}
			set {
				SetColumnValue("EnrchTextEntityHash", value);
				if (_enrchTextEntity != null) {
					_enrchTextEntity.Hash = value;
				}
			}
		}

		private EnrchTextEntity _enrchTextEntity;
		/// <summary>
		/// Mined entity.
		/// </summary>
		public EnrchTextEntity EnrchTextEntity {
			get {
				return _enrchTextEntity ??
					(_enrchTextEntity = LookupColumnEntities.GetEntity("EnrchTextEntity") as EnrchTextEntity);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <summary>
		/// Identification type.
		/// </summary>
		public string IdentificationType {
			get {
				return GetTypedColumnValue<string>("IdentificationType");
			}
			set {
				SetColumnValue("IdentificationType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EnrchFoundAccount_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EnrchFoundAccountDeleted", e);
			Validating += (s, e) => ThrowEvent("EnrchFoundAccountValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EnrchFoundAccount(this);
		}

		#endregion

	}

	#endregion

	#region Class: EnrchFoundAccount_EmailMiningEventsProcess

	/// <exclude/>
	public partial class EnrchFoundAccount_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EnrchFoundAccount
	{

		public EnrchFoundAccount_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EnrchFoundAccount_EmailMiningEventsProcess";
			SchemaUId = new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("83095328-1d0c-41f3-8abf-ad1fafde38af");
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

	#region Class: EnrchFoundAccount_EmailMiningEventsProcess

	/// <exclude/>
	public class EnrchFoundAccount_EmailMiningEventsProcess : EnrchFoundAccount_EmailMiningEventsProcess<EnrchFoundAccount>
	{

		public EnrchFoundAccount_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EnrchFoundAccount_EmailMiningEventsProcess

	public partial class EnrchFoundAccount_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EnrchFoundAccountEventsProcess

	/// <exclude/>
	public class EnrchFoundAccountEventsProcess : EnrchFoundAccount_EmailMiningEventsProcess
	{

		public EnrchFoundAccountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

