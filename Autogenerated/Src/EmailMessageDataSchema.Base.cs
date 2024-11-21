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

	#region Class: EmailMessageDataSchema

	/// <exclude/>
	public class EmailMessageDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailMessageDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailMessageDataSchema(EmailMessageDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailMessageDataSchema(EmailMessageDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateId_ActivityIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("f9b59b14-5f07-4093-adee-c75e4ea5d19f");
			index.Name = "Id_Activity";
			index.CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn idIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2cb893a9-173e-4517-bb81-b2d22fca4737"),
				ColumnUId = new Guid("ae0e45ca-c495-4fe7-a39d-3ab7278e1617"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(idIndexColumn);
			EntitySchemaIndexColumn activityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("e658d399-591d-4d63-9b4f-a08ab6545911"),
				ColumnUId = new Guid("593747ea-b4c5-497b-8f1e-0aecc9ba023b"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(activityIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateId_MessageId_InReplyToIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("fea0304d-a214-4cf2-9779-706fa869fc54");
			index.Name = "Id_MessageId_InReplyTo";
			index.CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn idIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("21393c9a-3bc7-47df-b755-1036e3aa7470"),
				ColumnUId = new Guid("ae0e45ca-c495-4fe7-a39d-3ab7278e1617"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(idIndexColumn);
			EntitySchemaIndexColumn messageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("73055d6a-569b-4ebb-9f73-cb76ce45ea13"),
				ColumnUId = new Guid("d3e7065a-85fb-442f-8f45-54399af7a517"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(messageIdIndexColumn);
			EntitySchemaIndexColumn inReplyToIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1eab51c3-8076-487f-988c-7f54577a7cce"),
				ColumnUId = new Guid("9b6128d9-24ed-44ce-afaf-3d9588221b50"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(inReplyToIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateId_ParentMessageId_ActivityIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("674c04d7-5b54-473e-b4ef-d8b7ab3f00a1");
			index.Name = "Id_ParentMessageId_ActivityId";
			index.CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn idIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7c48087f-0068-4a6b-a05a-3ff19d3c70d6"),
				ColumnUId = new Guid("ae0e45ca-c495-4fe7-a39d-3ab7278e1617"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(idIndexColumn);
			EntitySchemaIndexColumn parentMessageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("67603286-c465-4f0e-96e9-2797410beeb0"),
				ColumnUId = new Guid("324cddd2-7eab-4838-9bb8-4d2eac6f84ad"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(parentMessageIdIndexColumn);
			EntitySchemaIndexColumn activityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d12294ab-4df8-4b16-9a35-409de4ed1a67"),
				ColumnUId = new Guid("593747ea-b4c5-497b-8f1e-0aecc9ba023b"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(activityIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateThreadPosition_ThreadIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("cb2bbc08-2c8e-459d-856d-aec6cc438374");
			index.Name = "ThreadPosition_ThreadId";
			index.CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			index.CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f");
			EntitySchemaIndexColumn exchangeThreadPositionIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("62e0cf15-1624-4e91-bab2-1c9d52b41529"),
				ColumnUId = new Guid("2720e24c-c065-4196-a5f1-b036efbf7ac7"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(exchangeThreadPositionIndexColumn);
			EntitySchemaIndexColumn exchangeThreadIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8996840a-5f32-4130-8e78-2f5ebcf1ab5f"),
				ColumnUId = new Guid("9ed2272f-1273-4c95-a1ac-3575806dc3a5"),
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(exchangeThreadIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			RealUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			Name = "EmailMessageData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateMessageIdColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("593747ea-b4c5-497b-8f1e-0aecc9ba023b")) == null) {
				Columns.Add(CreateActivityColumn());
			}
			if (Columns.FindByUId(new Guid("4e8a7d7e-efd7-4cfd-83f8-7a141b736525")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("29828f20-9dbf-4731-b12f-79111d4a6ed5")) == null) {
				Columns.Add(CreateRoleColumn());
			}
			if (Columns.FindByUId(new Guid("32d95dc9-9962-467c-907f-ea831d419c11")) == null) {
				Columns.Add(CreateHeadersColumn());
			}
			if (Columns.FindByUId(new Guid("27d93a81-5dad-4130-a748-b19eeb4e9612")) == null) {
				Columns.Add(CreateIsNeedProcessColumn());
			}
			if (Columns.FindByUId(new Guid("d72d0bdd-f8f8-4a18-8812-fcd128bce85a")) == null) {
				Columns.Add(CreateMailboxSyncSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("9b6128d9-24ed-44ce-afaf-3d9588221b50")) == null) {
				Columns.Add(CreateInReplyToColumn());
			}
			if (Columns.FindByUId(new Guid("324cddd2-7eab-4838-9bb8-4d2eac6f84ad")) == null) {
				Columns.Add(CreateParentMessageColumn());
			}
			if (Columns.FindByUId(new Guid("8fd6f559-3d65-41e5-910d-f19e2c4aa633")) == null) {
				Columns.Add(CreateSyncSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("9ed2272f-1273-4c95-a1ac-3575806dc3a5")) == null) {
				Columns.Add(CreateExchangeThreadIdColumn());
			}
			if (Columns.FindByUId(new Guid("2720e24c-c065-4196-a5f1-b036efbf7ac7")) == null) {
				Columns.Add(CreateExchangeThreadPositionColumn());
			}
			if (Columns.FindByUId(new Guid("4ad47c60-a5c6-4f06-953a-a8ec16bb8712")) == null) {
				Columns.Add(CreateReferencesColumn());
			}
			if (Columns.FindByUId(new Guid("7ca7d624-5624-4414-8146-54d95b54e851")) == null) {
				Columns.Add(CreateConversationIdColumn());
			}
			if (Columns.FindByUId(new Guid("f8b6d415-7b35-4c3d-ab55-97f05f811d5c")) == null) {
				Columns.Add(CreateSendDateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("593747ea-b4c5-497b-8f1e-0aecc9ba023b"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4e8a7d7e-efd7-4cfd-83f8-7a141b736525"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("29828f20-9dbf-4731-b12f-79111d4a6ed5"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("01e72783-64d7-4fac-9d9a-1648eacd51c9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateHeadersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("32d95dc9-9962-467c-907f-ea831d419c11"),
				Name = @"Headers",
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsNeedProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("27d93a81-5dad-4130-a748-b19eeb4e9612"),
				Name = @"IsNeedProcess",
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateMailboxSyncSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d72d0bdd-f8f8-4a18-8812-fcd128bce85a"),
				Name = @"MailboxSyncSettings",
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d3e7065a-85fb-442f-8f45-54399af7a517"),
				Name = @"MessageId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateInReplyToColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("9b6128d9-24ed-44ce-afaf-3d9588221b50"),
				Name = @"InReplyTo",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateParentMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("324cddd2-7eab-4838-9bb8-4d2eac6f84ad"),
				Name = @"ParentMessage",
				ReferenceSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSyncSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8fd6f559-3d65-41e5-910d-f19e2c4aa633"),
				Name = @"SyncSessionId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateExchangeThreadIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9ed2272f-1273-4c95-a1ac-3575806dc3a5"),
				Name = @"ExchangeThreadId",
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateExchangeThreadPositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2720e24c-c065-4196-a5f1-b036efbf7ac7"),
				Name = @"ExchangeThreadPosition",
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateReferencesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4ad47c60-a5c6-4f06-953a-a8ec16bb8712"),
				Name = @"References",
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0")
			};
		}

		protected virtual EntitySchemaColumn CreateConversationIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7ca7d624-5624-4414-8146-54d95b54e851"),
				Name = @"ConversationId",
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0")
			};
		}

		protected virtual EntitySchemaColumn CreateSendDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f8b6d415-7b35-4c3d-ab55-97f05f811d5c"),
				Name = @"SendDate",
				CreatedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				ModifiedInSchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"),
				CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateId_ActivityIndex());
			Indexes.Add(CreateId_MessageId_InReplyToIndex());
			Indexes.Add(CreateId_ParentMessageId_ActivityIdIndex());
			Indexes.Add(CreateThreadPosition_ThreadIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailMessageData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailMessageData_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailMessageDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailMessageDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailMessageData

	/// <summary>
	/// Email message.
	/// </summary>
	public class EmailMessageData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailMessageData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailMessageData";
		}

		public EmailMessageData(EmailMessageData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <exclude/>
		public Guid RoleId {
			get {
				return GetTypedColumnValue<Guid>("RoleId");
			}
			set {
				SetColumnValue("RoleId", value);
				_role = null;
			}
		}

		/// <exclude/>
		public string RoleName {
			get {
				return GetTypedColumnValue<string>("RoleName");
			}
			set {
				SetColumnValue("RoleName", value);
				if (_role != null) {
					_role.Name = value;
				}
			}
		}

		private ActivityParticipantRole _role;
		/// <summary>
		/// Role.
		/// </summary>
		public ActivityParticipantRole Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as ActivityParticipantRole);
			}
		}

		/// <summary>
		/// Headers.
		/// </summary>
		public string Headers {
			get {
				return GetTypedColumnValue<string>("Headers");
			}
			set {
				SetColumnValue("Headers", value);
			}
		}

		/// <summary>
		/// IsNeedProcess.
		/// </summary>
		public bool IsNeedProcess {
			get {
				return GetTypedColumnValue<bool>("IsNeedProcess");
			}
			set {
				SetColumnValue("IsNeedProcess", value);
			}
		}

		/// <summary>
		/// MailboxSyncSettings.
		/// </summary>
		public Guid MailboxSyncSettings {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettings");
			}
			set {
				SetColumnValue("MailboxSyncSettings", value);
			}
		}

		/// <summary>
		/// MessageId.
		/// </summary>
		public string MessageId {
			get {
				return GetTypedColumnValue<string>("MessageId");
			}
			set {
				SetColumnValue("MessageId", value);
			}
		}

		/// <summary>
		/// InReplyTo.
		/// </summary>
		public string InReplyTo {
			get {
				return GetTypedColumnValue<string>("InReplyTo");
			}
			set {
				SetColumnValue("InReplyTo", value);
			}
		}

		/// <exclude/>
		public Guid ParentMessageId {
			get {
				return GetTypedColumnValue<Guid>("ParentMessageId");
			}
			set {
				SetColumnValue("ParentMessageId", value);
				_parentMessage = null;
			}
		}

		/// <exclude/>
		public string ParentMessageMessageId {
			get {
				return GetTypedColumnValue<string>("ParentMessageMessageId");
			}
			set {
				SetColumnValue("ParentMessageMessageId", value);
				if (_parentMessage != null) {
					_parentMessage.MessageId = value;
				}
			}
		}

		private EmailMessageData _parentMessage;
		/// <summary>
		/// ParentMessage.
		/// </summary>
		public EmailMessageData ParentMessage {
			get {
				return _parentMessage ??
					(_parentMessage = LookupColumnEntities.GetEntity("ParentMessage") as EmailMessageData);
			}
		}

		/// <summary>
		/// SyncSessionId.
		/// </summary>
		public string SyncSessionId {
			get {
				return GetTypedColumnValue<string>("SyncSessionId");
			}
			set {
				SetColumnValue("SyncSessionId", value);
			}
		}

		/// <summary>
		/// ExchangeThreadId.
		/// </summary>
		public Guid ExchangeThreadId {
			get {
				return GetTypedColumnValue<Guid>("ExchangeThreadId");
			}
			set {
				SetColumnValue("ExchangeThreadId", value);
			}
		}

		/// <summary>
		/// ExchangeThreadPosition.
		/// </summary>
		public int ExchangeThreadPosition {
			get {
				return GetTypedColumnValue<int>("ExchangeThreadPosition");
			}
			set {
				SetColumnValue("ExchangeThreadPosition", value);
			}
		}

		/// <summary>
		/// References.
		/// </summary>
		public string References {
			get {
				return GetTypedColumnValue<string>("References");
			}
			set {
				SetColumnValue("References", value);
			}
		}

		/// <summary>
		/// ConversationId.
		/// </summary>
		public Guid ConversationId {
			get {
				return GetTypedColumnValue<Guid>("ConversationId");
			}
			set {
				SetColumnValue("ConversationId", value);
			}
		}

		/// <summary>
		/// SendDate.
		/// </summary>
		public DateTime SendDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDate");
			}
			set {
				SetColumnValue("SendDate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailMessageData_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailMessageDataDeleted", e);
			Inserted += (s, e) => ThrowEvent("EmailMessageDataInserted", e);
			Inserting += (s, e) => ThrowEvent("EmailMessageDataInserting", e);
			Saved += (s, e) => ThrowEvent("EmailMessageDataSaved", e);
			Saving += (s, e) => ThrowEvent("EmailMessageDataSaving", e);
			Updated += (s, e) => ThrowEvent("EmailMessageDataUpdated", e);
			Updating += (s, e) => ThrowEvent("EmailMessageDataUpdating", e);
			Validating += (s, e) => ThrowEvent("EmailMessageDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailMessageData(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailMessageData_BaseEventsProcess

	/// <exclude/>
	public partial class EmailMessageData_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmailMessageData
	{

		public EmailMessageData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailMessageData_BaseEventsProcess";
			SchemaUId = new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d586ebed-2570-4fc6-89b5-88f55402e04c");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _emailMessageDataInsertingSubProcess;
		public ProcessFlowElement EmailMessageDataInsertingSubProcess {
			get {
				return _emailMessageDataInsertingSubProcess ?? (_emailMessageDataInsertingSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmailMessageDataInsertingSubProcess",
					SchemaElementUId = new Guid("64922012-230e-4cf9-8bd0-e99f89f19bc0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onEmailMessageDataInserting;
		public ProcessScriptTask OnEmailMessageDataInserting {
			get {
				return _onEmailMessageDataInserting ?? (_onEmailMessageDataInserting = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnEmailMessageDataInserting",
					SchemaElementUId = new Guid("59350997-9aff-40c4-bc84-5871ebe3cc43"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnEmailMessageDataInsertingExecute,
				});
			}
		}

		private ProcessFlowElement _emailMessageDataInserting;
		public ProcessFlowElement EmailMessageDataInserting {
			get {
				return _emailMessageDataInserting ?? (_emailMessageDataInserting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmailMessageDataInserting",
					SchemaElementUId = new Guid("91d493fb-dcf1-4c54-adf5-1e768e05e858"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _emailMessageDataUpdating;
		public ProcessFlowElement EmailMessageDataUpdating {
			get {
				return _emailMessageDataUpdating ?? (_emailMessageDataUpdating = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmailMessageDataUpdating",
					SchemaElementUId = new Guid("6912690c-b303-4c1b-960b-b46f5b11f237"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _emailMessageDataInsertedSubProcess;
		public ProcessFlowElement EmailMessageDataInsertedSubProcess {
			get {
				return _emailMessageDataInsertedSubProcess ?? (_emailMessageDataInsertedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmailMessageDataInsertedSubProcess",
					SchemaElementUId = new Guid("caa623b9-421a-4c01-b6cf-5bc4765d454c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onEmailMessageDataInserted;
		public ProcessScriptTask OnEmailMessageDataInserted {
			get {
				return _onEmailMessageDataInserted ?? (_onEmailMessageDataInserted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnEmailMessageDataInserted",
					SchemaElementUId = new Guid("1d2fa185-4c78-4622-9a45-fc6a1bf1dfb1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnEmailMessageDataInsertedExecute,
				});
			}
		}

		private ProcessFlowElement _emailMessageDataUpdated;
		public ProcessFlowElement EmailMessageDataUpdated {
			get {
				return _emailMessageDataUpdated ?? (_emailMessageDataUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmailMessageDataUpdated",
					SchemaElementUId = new Guid("6af6e89d-fd4e-4e87-827a-f4e5d0874bea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _emailMessageDataInserted;
		public ProcessFlowElement EmailMessageDataInserted {
			get {
				return _emailMessageDataInserted ?? (_emailMessageDataInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmailMessageDataInserted",
					SchemaElementUId = new Guid("f97f8476-0d8c-4ac2-8d14-a7b287e749e5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EmailMessageDataInsertingSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailMessageDataInsertingSubProcess };
			FlowElements[OnEmailMessageDataInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEmailMessageDataInserting };
			FlowElements[EmailMessageDataInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailMessageDataInserting };
			FlowElements[EmailMessageDataUpdating.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailMessageDataUpdating };
			FlowElements[EmailMessageDataInsertedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailMessageDataInsertedSubProcess };
			FlowElements[OnEmailMessageDataInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEmailMessageDataInserted };
			FlowElements[EmailMessageDataUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailMessageDataUpdated };
			FlowElements[EmailMessageDataInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailMessageDataInserted };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EmailMessageDataInsertingSubProcess":
						break;
					case "OnEmailMessageDataInserting":
						break;
					case "EmailMessageDataInserting":
						e.Context.QueueTasks.Enqueue("OnEmailMessageDataInserting");
						break;
					case "EmailMessageDataUpdating":
						e.Context.QueueTasks.Enqueue("OnEmailMessageDataInserting");
						break;
					case "EmailMessageDataInsertedSubProcess":
						break;
					case "OnEmailMessageDataInserted":
						break;
					case "EmailMessageDataUpdated":
						e.Context.QueueTasks.Enqueue("OnEmailMessageDataInserted");
						break;
					case "EmailMessageDataInserted":
						e.Context.QueueTasks.Enqueue("OnEmailMessageDataInserted");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("EmailMessageDataInserting");
			ActivatedEventElements.Add("EmailMessageDataUpdating");
			ActivatedEventElements.Add("EmailMessageDataUpdated");
			ActivatedEventElements.Add("EmailMessageDataInserted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EmailMessageDataInsertingSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "OnEmailMessageDataInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnEmailMessageDataInserting";
					result = OnEmailMessageDataInserting.Execute(context, OnEmailMessageDataInsertingExecute);
					break;
				case "EmailMessageDataInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmailMessageDataInserting";
					result = EmailMessageDataInserting.Execute(context);
					break;
				case "EmailMessageDataUpdating":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmailMessageDataUpdating";
					result = EmailMessageDataUpdating.Execute(context);
					break;
				case "EmailMessageDataInsertedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "OnEmailMessageDataInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnEmailMessageDataInserted";
					result = OnEmailMessageDataInserted.Execute(context, OnEmailMessageDataInsertedExecute);
					break;
				case "EmailMessageDataUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmailMessageDataUpdated";
					result = EmailMessageDataUpdated.Execute(context);
					break;
				case "EmailMessageDataInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmailMessageDataInserted";
					result = EmailMessageDataInserted.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool OnEmailMessageDataInsertingExecute(ProcessExecutingContext context) {
			EmailMessageHelper helper = GetEmailMessageHelper();
			helper.OnEmailMessageDataInserting(Entity);
			return true;
		}

		public virtual bool OnEmailMessageDataInsertedExecute(ProcessExecutingContext context) {
			EmailMessageHelper helper = GetEmailMessageHelper();
			helper.OnEmailMessageDataInserted(Entity);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "EmailMessageDataInserting":
							if (ActivatedEventElements.Contains("EmailMessageDataInserting")) {
							context.QueueTasks.Enqueue("EmailMessageDataInserting");
						}
						break;
					case "EmailMessageDataUpdating":
							if (ActivatedEventElements.Contains("EmailMessageDataUpdating")) {
							context.QueueTasks.Enqueue("EmailMessageDataUpdating");
						}
						break;
					case "EmailMessageDataUpdated":
							if (ActivatedEventElements.Contains("EmailMessageDataUpdated")) {
							context.QueueTasks.Enqueue("EmailMessageDataUpdated");
						}
						break;
					case "EmailMessageDataInserted":
							if (ActivatedEventElements.Contains("EmailMessageDataInserted")) {
							context.QueueTasks.Enqueue("EmailMessageDataInserted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: EmailMessageData_BaseEventsProcess

	/// <exclude/>
	public class EmailMessageData_BaseEventsProcess : EmailMessageData_BaseEventsProcess<EmailMessageData>
	{

		public EmailMessageData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailMessageData_BaseEventsProcess

	public partial class EmailMessageData_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual EmailMessageHelper GetEmailMessageHelper() {
			return ClassFactory.Get<EmailMessageHelper>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

	}

	#endregion


	#region Class: EmailMessageDataEventsProcess

	/// <exclude/>
	public class EmailMessageDataEventsProcess : EmailMessageData_BaseEventsProcess
	{

		public EmailMessageDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

