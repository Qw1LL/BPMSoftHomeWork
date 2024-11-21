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
	using BPMSoft.Messaging.Common;
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

	#region Class: MailServer_Base_BPMSoftSchema

	/// <exclude/>
	public class MailServer_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MailServer_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailServer_Base_BPMSoftSchema(MailServer_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailServer_Base_BPMSoftSchema(MailServer_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4");
			RealUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4");
			Name = "MailServer_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("be4a6212-190c-4430-8b31-6972ac32503f")) == null) {
				Columns.Add(CreateAddressColumn());
			}
			if (Columns.FindByUId(new Guid("b9e6dfc3-cd79-4707-9f3d-9b6bedda3c5f")) == null) {
				Columns.Add(CreatePortColumn());
			}
			if (Columns.FindByUId(new Guid("773d7c26-389e-421c-a67e-9ca6a8b8a3e9")) == null) {
				Columns.Add(CreateUseSSLColumn());
			}
			if (Columns.FindByUId(new Guid("9a6b34c9-96b3-45f5-b005-dfcd12e79d6d")) == null) {
				Columns.Add(CreateEmailProtocolColumn());
			}
			if (Columns.FindByUId(new Guid("89e2b329-bf63-4d5c-a079-6cf6c5fa9430")) == null) {
				Columns.Add(CreateAllowEmailDownloadingColumn());
			}
			if (Columns.FindByUId(new Guid("411aaeae-43da-4e1c-8b1c-1655c25aac96")) == null) {
				Columns.Add(CreateAllowEmailSendingColumn());
			}
			if (Columns.FindByUId(new Guid("394009b0-7664-46b4-b052-5754522f03c3")) == null) {
				Columns.Add(CreateSMTPServerAddressColumn());
			}
			if (Columns.FindByUId(new Guid("c6d3e3b2-5552-4b06-9d5c-fe34b58ae7aa")) == null) {
				Columns.Add(CreateSMTPPortColumn());
			}
			if (Columns.FindByUId(new Guid("6094ebec-dee7-492e-8977-4e2748a9b4bb")) == null) {
				Columns.Add(CreateSMTPServerTimeoutColumn());
			}
			if (Columns.FindByUId(new Guid("33affd30-ab8b-4975-8917-9baa63d2d025")) == null) {
				Columns.Add(CreateUseSSLforSendingColumn());
			}
			if (Columns.FindByUId(new Guid("a017673a-f233-4df8-8ba8-fd299bae4e20")) == null) {
				Columns.Add(CreateIsStartTlsColumn());
			}
			if (Columns.FindByUId(new Guid("29f424ac-945a-4548-a60e-5e738cf01711")) == null) {
				Columns.Add(CreateUseLoginColumn());
			}
			if (Columns.FindByUId(new Guid("29d0de8b-d4db-45d1-b453-8241941d7b62")) == null) {
				Columns.Add(CreateLogoColumn());
			}
			if (Columns.FindByUId(new Guid("30e37f76-b60e-4975-89a0-befc3e75eeb7")) == null) {
				Columns.Add(CreateUseUserNameAsLoginColumn());
			}
			if (Columns.FindByUId(new Guid("38790f02-593c-4eb3-80be-2204877697a0")) == null) {
				Columns.Add(CreateUseEmailAddressAsLoginColumn());
			}
			if (Columns.FindByUId(new Guid("2e121c4b-83ff-40c4-9f0e-503cee9e5cae")) == null) {
				Columns.Add(CreateStrategyColumn());
			}
			if (Columns.FindByUId(new Guid("5826ac7a-d531-4540-a160-6408396cd88b")) == null) {
				Columns.Add(CreateOAuthApplicationColumn());
			}
			if (Columns.FindByUId(new Guid("a99c69ce-4b49-5488-5116-7054e222e995")) == null) {
				Columns.Add(CreateSubscriptionTtlColumn());
			}
			if (Columns.FindByUId(new Guid("ca1e9194-bf22-6c6d-34ec-aa37bdaf446e")) == null) {
				Columns.Add(CreateSmtpSecureOptionColumn());
			}
			if (Columns.FindByUId(new Guid("a60be2e0-94eb-9996-9d5c-f9f5d3a2f23e")) == null) {
				Columns.Add(CreateImapSecureOptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f0fec10e-c639-4ebb-b0d4-75ba7beb2b30"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("be4a6212-190c-4430-8b31-6972ac32503f"),
				Name = @"Address",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b9e6dfc3-cd79-4707-9f3d-9b6bedda3c5f"),
				Name = @"Port",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUseSSLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("773d7c26-389e-421c-a67e-9ca6a8b8a3e9"),
				Name = @"UseSSL",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailProtocolColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9a6b34c9-96b3-45f5-b005-dfcd12e79d6d"),
				Name = @"EmailProtocol",
				ReferenceSchemaUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"65beaf50-b599-4207-b6e2-586dfa9562a6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAllowEmailDownloadingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("89e2b329-bf63-4d5c-a079-6cf6c5fa9430"),
				Name = @"AllowEmailDownloading",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAllowEmailSendingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("411aaeae-43da-4e1c-8b1c-1655c25aac96"),
				Name = @"AllowEmailSending",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSMTPServerAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("394009b0-7664-46b4-b052-5754522f03c3"),
				Name = @"SMTPServerAddress",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSMTPPortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c6d3e3b2-5552-4b06-9d5c-fe34b58ae7aa"),
				Name = @"SMTPPort",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSMTPServerTimeoutColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6094ebec-dee7-492e-8977-4e2748a9b4bb"),
				Name = @"SMTPServerTimeout",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"40"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUseSSLforSendingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("33affd30-ab8b-4975-8917-9baa63d2d025"),
				Name = @"UseSSLforSending",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsStartTlsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a017673a-f233-4df8-8ba8-fd299bae4e20"),
				Name = @"IsStartTls",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("d96ae870-4bfc-40ec-921c-ada84236f3fa")
			};
		}

		protected virtual EntitySchemaColumn CreateUseLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("29f424ac-945a-4548-a60e-5e738cf01711"),
				Name = @"UseLogin",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("a6558c63-9ae0-4b9f-a2aa-711d80b4faa2")
			};
		}

		protected virtual EntitySchemaColumn CreateLogoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("29d0de8b-d4db-45d1-b453-8241941d7b62"),
				Name = @"Logo",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("fa2eb5ad-958f-4492-adde-c5914e708d28")
			};
		}

		protected virtual EntitySchemaColumn CreateUseUserNameAsLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("30e37f76-b60e-4975-89a0-befc3e75eeb7"),
				Name = @"UseUserNameAsLogin",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7")
			};
		}

		protected virtual EntitySchemaColumn CreateUseEmailAddressAsLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("38790f02-593c-4eb3-80be-2204877697a0"),
				Name = @"UseEmailAddressAsLogin",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7")
			};
		}

		protected virtual EntitySchemaColumn CreateStrategyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2e121c4b-83ff-40c4-9f0e-503cee9e5cae"),
				Name = @"Strategy",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateOAuthApplicationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5826ac7a-d531-4540-a160-6408396cd88b"),
				Name = @"OAuthApplication",
				ReferenceSchemaUId = new Guid("2d30ef0a-87fb-474a-a348-a8cb46e23e6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("50cc600a-f6aa-433b-8a0a-6a453519907c")
			};
		}

		protected virtual EntitySchemaColumn CreateSubscriptionTtlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a99c69ce-4b49-5488-5116-7054e222e995"),
				Name = @"SubscriptionTtl",
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSmtpSecureOptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ca1e9194-bf22-6c6d-34ec-aa37bdaf446e"),
				Name = @"SmtpSecureOption",
				ReferenceSchemaUId = new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateImapSecureOptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a60be2e0-94eb-9996-9d5c-f9f5d3a2f23e"),
				Name = @"ImapSecureOption",
				ReferenceSchemaUId = new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				ModifiedInSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailServer_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailServer_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailServer_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailServer_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"));
		}

		#endregion

	}

	#endregion

	#region Class: MailServer_Base_BPMSoft

	/// <summary>
	/// Email provider.
	/// </summary>
	public class MailServer_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MailServer_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailServer_Base_BPMSoft";
		}

		public MailServer_Base_BPMSoft(MailServer_Base_BPMSoft source)
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
		/// Incoming mail server name or IP.
		/// </summary>
		public string Address {
			get {
				return GetTypedColumnValue<string>("Address");
			}
			set {
				SetColumnValue("Address", value);
			}
		}

		/// <summary>
		/// Port.
		/// </summary>
		public int Port {
			get {
				return GetTypedColumnValue<int>("Port");
			}
			set {
				SetColumnValue("Port", value);
			}
		}

		/// <summary>
		/// Use SSL.
		/// </summary>
		public bool UseSSL {
			get {
				return GetTypedColumnValue<bool>("UseSSL");
			}
			set {
				SetColumnValue("UseSSL", value);
			}
		}

		/// <exclude/>
		public Guid EmailProtocolId {
			get {
				return GetTypedColumnValue<Guid>("EmailProtocolId");
			}
			set {
				SetColumnValue("EmailProtocolId", value);
				_emailProtocol = null;
			}
		}

		/// <exclude/>
		public string EmailProtocolName {
			get {
				return GetTypedColumnValue<string>("EmailProtocolName");
			}
			set {
				SetColumnValue("EmailProtocolName", value);
				if (_emailProtocol != null) {
					_emailProtocol.Name = value;
				}
			}
		}

		private EmailProtocol _emailProtocol;
		/// <summary>
		/// Connection protocol.
		/// </summary>
		public EmailProtocol EmailProtocol {
			get {
				return _emailProtocol ??
					(_emailProtocol = LookupColumnEntities.GetEntity("EmailProtocol") as EmailProtocol);
			}
		}

		/// <summary>
		/// Allow downloading emails.
		/// </summary>
		public bool AllowEmailDownloading {
			get {
				return GetTypedColumnValue<bool>("AllowEmailDownloading");
			}
			set {
				SetColumnValue("AllowEmailDownloading", value);
			}
		}

		/// <summary>
		/// Allow sending emails.
		/// </summary>
		public bool AllowEmailSending {
			get {
				return GetTypedColumnValue<bool>("AllowEmailSending");
			}
			set {
				SetColumnValue("AllowEmailSending", value);
			}
		}

		/// <summary>
		/// Outgoing mail server name or IP (SMTP).
		/// </summary>
		public string SMTPServerAddress {
			get {
				return GetTypedColumnValue<string>("SMTPServerAddress");
			}
			set {
				SetColumnValue("SMTPServerAddress", value);
			}
		}

		/// <summary>
		/// Port.
		/// </summary>
		public int SMTPPort {
			get {
				return GetTypedColumnValue<int>("SMTPPort");
			}
			set {
				SetColumnValue("SMTPPort", value);
			}
		}

		/// <summary>
		/// Interval of waiting for server response when sending mail, seconds.
		/// </summary>
		public int SMTPServerTimeout {
			get {
				return GetTypedColumnValue<int>("SMTPServerTimeout");
			}
			set {
				SetColumnValue("SMTPServerTimeout", value);
			}
		}

		/// <summary>
		/// Use SSL.
		/// </summary>
		public bool UseSSLforSending {
			get {
				return GetTypedColumnValue<bool>("UseSSLforSending");
			}
			set {
				SetColumnValue("UseSSLforSending", value);
			}
		}

		/// <summary>
		/// Create encrypted connection (STARTTLS).
		/// </summary>
		public bool IsStartTls {
			get {
				return GetTypedColumnValue<bool>("IsStartTls");
			}
			set {
				SetColumnValue("IsStartTls", value);
			}
		}

		/// <summary>
		/// Enter login manually.
		/// </summary>
		public bool UseLogin {
			get {
				return GetTypedColumnValue<bool>("UseLogin");
			}
			set {
				SetColumnValue("UseLogin", value);
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Logo.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = LookupColumnEntities.GetEntity("Logo") as SysImage);
			}
		}

		/// <summary>
		/// Use user name as login.
		/// </summary>
		public bool UseUserNameAsLogin {
			get {
				return GetTypedColumnValue<bool>("UseUserNameAsLogin");
			}
			set {
				SetColumnValue("UseUserNameAsLogin", value);
			}
		}

		/// <summary>
		/// Use email address as login.
		/// </summary>
		public bool UseEmailAddressAsLogin {
			get {
				return GetTypedColumnValue<bool>("UseEmailAddressAsLogin");
			}
			set {
				SetColumnValue("UseEmailAddressAsLogin", value);
			}
		}

		/// <summary>
		/// Strategy.
		/// </summary>
		public string Strategy {
			get {
				return GetTypedColumnValue<string>("Strategy");
			}
			set {
				SetColumnValue("Strategy", value);
			}
		}

		/// <exclude/>
		public Guid OAuthApplicationId {
			get {
				return GetTypedColumnValue<Guid>("OAuthApplicationId");
			}
			set {
				SetColumnValue("OAuthApplicationId", value);
				_oAuthApplication = null;
			}
		}

		/// <exclude/>
		public string OAuthApplicationName {
			get {
				return GetTypedColumnValue<string>("OAuthApplicationName");
			}
			set {
				SetColumnValue("OAuthApplicationName", value);
				if (_oAuthApplication != null) {
					_oAuthApplication.Name = value;
				}
			}
		}

		private OAuthApplications _oAuthApplication;
		/// <summary>
		/// OAuth application identifier.
		/// </summary>
		public OAuthApplications OAuthApplication {
			get {
				return _oAuthApplication ??
					(_oAuthApplication = LookupColumnEntities.GetEntity("OAuthApplication") as OAuthApplications);
			}
		}

		/// <summary>
		/// SubscriptionTtl.
		/// </summary>
		public int SubscriptionTtl {
			get {
				return GetTypedColumnValue<int>("SubscriptionTtl");
			}
			set {
				SetColumnValue("SubscriptionTtl", value);
			}
		}

		/// <exclude/>
		public Guid SmtpSecureOptionId {
			get {
				return GetTypedColumnValue<Guid>("SmtpSecureOptionId");
			}
			set {
				SetColumnValue("SmtpSecureOptionId", value);
				_smtpSecureOption = null;
			}
		}

		/// <exclude/>
		public string SmtpSecureOptionName {
			get {
				return GetTypedColumnValue<string>("SmtpSecureOptionName");
			}
			set {
				SetColumnValue("SmtpSecureOptionName", value);
				if (_smtpSecureOption != null) {
					_smtpSecureOption.Name = value;
				}
			}
		}

		private MailSecureOption _smtpSecureOption;
		/// <summary>
		/// Secure option for connection to smtp mail server.
		/// </summary>
		public MailSecureOption SmtpSecureOption {
			get {
				return _smtpSecureOption ??
					(_smtpSecureOption = LookupColumnEntities.GetEntity("SmtpSecureOption") as MailSecureOption);
			}
		}

		/// <exclude/>
		public Guid ImapSecureOptionId {
			get {
				return GetTypedColumnValue<Guid>("ImapSecureOptionId");
			}
			set {
				SetColumnValue("ImapSecureOptionId", value);
				_imapSecureOption = null;
			}
		}

		/// <exclude/>
		public string ImapSecureOptionName {
			get {
				return GetTypedColumnValue<string>("ImapSecureOptionName");
			}
			set {
				SetColumnValue("ImapSecureOptionName", value);
				if (_imapSecureOption != null) {
					_imapSecureOption.Name = value;
				}
			}
		}

		private MailSecureOption _imapSecureOption;
		/// <summary>
		/// Secure option for connection to imap mail server.
		/// </summary>
		public MailSecureOption ImapSecureOption {
			get {
				return _imapSecureOption ??
					(_imapSecureOption = LookupColumnEntities.GetEntity("ImapSecureOption") as MailSecureOption);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailServer_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailServer_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("MailServer_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("MailServer_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("MailServer_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("MailServer_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("MailServer_Base_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("MailServer_Base_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("MailServer_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailServer_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailServer_BaseEventsProcess

	/// <exclude/>
	public partial class MailServer_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MailServer_Base_BPMSoft
	{

		public MailServer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailServer_BaseEventsProcess";
			SchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _mailServerEventSubProcess;
		public ProcessFlowElement MailServerEventSubProcess {
			get {
				return _mailServerEventSubProcess ?? (_mailServerEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "MailServerEventSubProcess",
					SchemaElementUId = new Guid("dbb202ae-ead3-417b-b42f-f68b5bba50eb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailServerInsertingStartMessage;
		public ProcessFlowElement MailServerInsertingStartMessage {
			get {
				return _mailServerInsertingStartMessage ?? (_mailServerInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailServerInsertingStartMessage",
					SchemaElementUId = new Guid("4735dcb2-af8e-49b1-b3e7-aa8f7a4b0b49"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailServerSavingStartMessage;
		public ProcessFlowElement MailServerSavingStartMessage {
			get {
				return _mailServerSavingStartMessage ?? (_mailServerSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailServerSavingStartMessage",
					SchemaElementUId = new Guid("cc824bbe-8bc7-4df6-8d66-1eb1249c5014"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailServerDeletingStartMessage;
		public ProcessFlowElement MailServerDeletingStartMessage {
			get {
				return _mailServerDeletingStartMessage ?? (_mailServerDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailServerDeletingStartMessage",
					SchemaElementUId = new Guid("5299f902-4221-4a2a-9854-710fc519fddd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailServerInserted;
		public ProcessFlowElement MailServerInserted {
			get {
				return _mailServerInserted ?? (_mailServerInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailServerInserted",
					SchemaElementUId = new Guid("8608b349-cede-4e47-a276-69968153feda"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailServerDeleted;
		public ProcessFlowElement MailServerDeleted {
			get {
				return _mailServerDeleted ?? (_mailServerDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailServerDeleted",
					SchemaElementUId = new Guid("5b06e3c2-dc63-4f9a-9a5b-cf8b9d6375a7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailServerUpdated;
		public ProcessFlowElement MailServerUpdated {
			get {
				return _mailServerUpdated ?? (_mailServerUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailServerUpdated",
					SchemaElementUId = new Guid("dd16bb71-0766-4318-abdc-a7628669c10d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mailServerCheckCanExecuteOperationScriptTask;
		public ProcessScriptTask MailServerCheckCanExecuteOperationScriptTask {
			get {
				return _mailServerCheckCanExecuteOperationScriptTask ?? (_mailServerCheckCanExecuteOperationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailServerCheckCanExecuteOperationScriptTask",
					SchemaElementUId = new Guid("a745f5f1-c93e-416b-a961-601357bb4db3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailServerCheckCanExecuteOperationScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _sendUpdate;
		public ProcessScriptTask SendUpdate {
			get {
				return _sendUpdate ?? (_sendUpdate = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendUpdate",
					SchemaElementUId = new Guid("b82557dc-92aa-4510-ae91-4591a69f750f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SendUpdateExecute,
				});
			}
		}

		private ProcessScriptTask _sendInsert;
		public ProcessScriptTask SendInsert {
			get {
				return _sendInsert ?? (_sendInsert = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendInsert",
					SchemaElementUId = new Guid("b540fc09-d81f-491c-b09e-af9341bf34a0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SendInsertExecute,
				});
			}
		}

		private ProcessScriptTask _sendDelete;
		public ProcessScriptTask SendDelete {
			get {
				return _sendDelete ?? (_sendDelete = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendDelete",
					SchemaElementUId = new Guid("ccd758cd-4c94-4f2c-a833-8441b90e1e7b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SendDeleteExecute,
				});
			}
		}

		private ProcessTerminateEvent _terminateEvent1;
		public ProcessTerminateEvent TerminateEvent1 {
			get {
				return _terminateEvent1 ?? (_terminateEvent1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateEvent1",
					SchemaElementUId = new Guid("e2ed7e63-89a4-4877-84b9-ca3a7b9cb316"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[MailServerEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerEventSubProcess };
			FlowElements[MailServerInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerInsertingStartMessage };
			FlowElements[MailServerSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerSavingStartMessage };
			FlowElements[MailServerDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerDeletingStartMessage };
			FlowElements[MailServerInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerInserted };
			FlowElements[MailServerDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerDeleted };
			FlowElements[MailServerUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerUpdated };
			FlowElements[MailServerCheckCanExecuteOperationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerCheckCanExecuteOperationScriptTask };
			FlowElements[SendUpdate.SchemaElementUId] = new Collection<ProcessFlowElement> { SendUpdate };
			FlowElements[SendInsert.SchemaElementUId] = new Collection<ProcessFlowElement> { SendInsert };
			FlowElements[SendDelete.SchemaElementUId] = new Collection<ProcessFlowElement> { SendDelete };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "MailServerEventSubProcess":
						break;
					case "MailServerInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("MailServerCheckCanExecuteOperationScriptTask");
						break;
					case "MailServerSavingStartMessage":
						e.Context.QueueTasks.Enqueue("MailServerCheckCanExecuteOperationScriptTask");
						break;
					case "MailServerDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("MailServerCheckCanExecuteOperationScriptTask");
						break;
					case "MailServerInserted":
						e.Context.QueueTasks.Enqueue("SendInsert");
						break;
					case "MailServerDeleted":
						e.Context.QueueTasks.Enqueue("SendDelete");
						break;
					case "MailServerUpdated":
						e.Context.QueueTasks.Enqueue("SendUpdate");
						break;
					case "MailServerCheckCanExecuteOperationScriptTask":
						break;
					case "SendUpdate":
						e.Context.QueueTasks.Enqueue("TerminateEvent1");
						break;
					case "SendInsert":
						e.Context.QueueTasks.Enqueue("TerminateEvent1");
						break;
					case "SendDelete":
						e.Context.QueueTasks.Enqueue("TerminateEvent1");
						break;
					case "TerminateEvent1":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("MailServerInsertingStartMessage");
			ActivatedEventElements.Add("MailServerSavingStartMessage");
			ActivatedEventElements.Add("MailServerDeletingStartMessage");
			ActivatedEventElements.Add("MailServerInserted");
			ActivatedEventElements.Add("MailServerDeleted");
			ActivatedEventElements.Add("MailServerUpdated");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "MailServerEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "MailServerInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerInsertingStartMessage";
					result = MailServerInsertingStartMessage.Execute(context);
					break;
				case "MailServerSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerSavingStartMessage";
					result = MailServerSavingStartMessage.Execute(context);
					break;
				case "MailServerDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerDeletingStartMessage";
					result = MailServerDeletingStartMessage.Execute(context);
					break;
				case "MailServerInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerInserted";
					result = MailServerInserted.Execute(context);
					break;
				case "MailServerDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerDeleted";
					result = MailServerDeleted.Execute(context);
					break;
				case "MailServerUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerUpdated";
					result = MailServerUpdated.Execute(context);
					break;
				case "MailServerCheckCanExecuteOperationScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerCheckCanExecuteOperationScriptTask";
					result = MailServerCheckCanExecuteOperationScriptTask.Execute(context, MailServerCheckCanExecuteOperationScriptTaskExecute);
					break;
				case "SendUpdate":
					context.QueueTasks.Dequeue();
					context.SenderName = "SendUpdate";
					result = SendUpdate.Execute(context, SendUpdateExecute);
					break;
				case "SendInsert":
					context.QueueTasks.Dequeue();
					context.SenderName = "SendInsert";
					result = SendInsert.Execute(context, SendInsertExecute);
					break;
				case "SendDelete":
					context.QueueTasks.Dequeue();
					context.SenderName = "SendDelete";
					result = SendDelete.Execute(context, SendDeleteExecute);
					break;
				case "TerminateEvent1":
					context.QueueTasks.Dequeue();
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool MailServerCheckCanExecuteOperationScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageMailServers");
			var oauthApplicationId = Entity.GetTypedColumnValue<Guid>("OAuthApplicationId");
			var subscriptionTtl = Entity.GetTypedColumnValue<int>("SubscriptionTtl");
			if (oauthApplicationId.IsNotEmpty() && subscriptionTtl == 0) {
				Entity.SetColumnValue("SubscriptionTtl", 10);
			}
			return true;
		}

		public virtual bool SendUpdateExecute(ProcessExecutingContext context) {
			SendMessage("MailServerEdited");
			DeleteUnusedOAuthApplication(true);
			ClearMailboxSyncSettingsPasswords();
			return true;
		}

		public virtual bool SendInsertExecute(ProcessExecutingContext context) {
			SendMessage("MailServerAdded");
			return true;
		}

		public virtual bool SendDeleteExecute(ProcessExecutingContext context) {
			SendMessage("MailServerDeleted");
			DeleteUnusedOAuthApplication(false);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MailServer_Base_BPMSoftInserting":
							if (ActivatedEventElements.Contains("MailServerInsertingStartMessage")) {
							context.QueueTasks.Enqueue("MailServerInsertingStartMessage");
						}
						break;
					case "MailServer_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("MailServerSavingStartMessage")) {
							context.QueueTasks.Enqueue("MailServerSavingStartMessage");
						}
						break;
					case "MailServer_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("MailServerDeletingStartMessage")) {
							context.QueueTasks.Enqueue("MailServerDeletingStartMessage");
						}
						break;
					case "MailServer_Base_BPMSoftInserted":
							if (ActivatedEventElements.Contains("MailServerInserted")) {
							context.QueueTasks.Enqueue("MailServerInserted");
						}
						break;
					case "MailServer_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("MailServerDeleted")) {
							context.QueueTasks.Enqueue("MailServerDeleted");
						}
						break;
					case "MailServer_Base_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("MailServerUpdated")) {
							context.QueueTasks.Enqueue("MailServerUpdated");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: MailServer_BaseEventsProcess

	/// <exclude/>
	public class MailServer_BaseEventsProcess : MailServer_BaseEventsProcess<MailServer_Base_BPMSoft>
	{

		public MailServer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

