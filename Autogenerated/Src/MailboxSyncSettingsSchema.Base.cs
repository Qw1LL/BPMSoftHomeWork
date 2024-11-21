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

	#region Class: MailboxSyncSettings_Base_BPMSoftSchema

	/// <exclude/>
	public class MailboxSyncSettings_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MailboxSyncSettings_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxSyncSettings_Base_BPMSoftSchema(MailboxSyncSettings_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxSyncSettings_Base_BPMSoftSchema(MailboxSyncSettings_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315");
			RealUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315");
			Name = "MailboxSyncSettings_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateUserNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateCreatedByColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b238f1d8-39c2-4498-b0a1-d63f123309ea")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("04423276-208b-4661-8602-6b6eadd409b9")) == null) {
				Columns.Add(CreateMailServerColumn());
			}
			if (Columns.FindByUId(new Guid("6f989bb4-4185-4531-87c8-62927005896b")) == null) {
				Columns.Add(CreateUserPasswordColumn());
			}
			if (Columns.FindByUId(new Guid("ead0a7dd-f3e3-4679-b766-d8a9f70b2b53")) == null) {
				Columns.Add(CreateEnableMailSynhronizationColumn());
			}
			if (Columns.FindByUId(new Guid("1dd6b43d-22e9-49f5-9676-f4e93fffc0a5")) == null) {
				Columns.Add(CreateAutomaticallyAddNewEmailsColumn());
			}
			if (Columns.FindByUId(new Guid("5b147af6-5886-41cd-b7aa-2ba9a253aab5")) == null) {
				Columns.Add(CreateCyclicallyAddNewEmailsColumn());
			}
			if (Columns.FindByUId(new Guid("04e621fc-8584-4c36-b616-5e790d2d28ca")) == null) {
				Columns.Add(CreateEmailsCyclicallyAddingIntervalColumn());
			}
			if (Columns.FindByUId(new Guid("c8b179f9-5a7e-4c20-944e-b6930162b98f")) == null) {
				Columns.Add(CreateIsCustomFlagsNotSuportedColumn());
			}
			if (Columns.FindByUId(new Guid("64ef7eb3-9995-497d-9c61-e4e09e951132")) == null) {
				Columns.Add(CreateLastSyncDateColumn());
			}
			if (Columns.FindByUId(new Guid("bd47456d-aeb5-4454-b2ce-f6dff54a7794")) == null) {
				Columns.Add(CreateIsSharedColumn());
			}
			if (Columns.FindByUId(new Guid("e727b47c-883f-4fdf-94aa-e85369c2f8f1")) == null) {
				Columns.Add(CreateSendEmailsViaThisAccountColumn());
			}
			if (Columns.FindByUId(new Guid("2b8a9515-0fd9-40ea-84d2-ba1fa641e03e")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
			if (Columns.FindByUId(new Guid("d52de6c0-104f-4d78-8e92-3376e97a8268")) == null) {
				Columns.Add(CreateLoadAllEmailsFromMailBoxColumn());
			}
			if (Columns.FindByUId(new Guid("705a60bf-aee9-4168-993d-ed634328174c")) == null) {
				Columns.Add(CreateLoadEmailsFromDateColumn());
			}
			if (Columns.FindByUId(new Guid("06c19861-2ce5-4eb7-88b0-117c28deecf4")) == null) {
				Columns.Add(CreateMailboxNameColumn());
			}
			if (Columns.FindByUId(new Guid("1400f977-628f-4ebe-bcdb-9fbd661d4799")) == null) {
				Columns.Add(CreateSenderEmailAddressColumn());
			}
			if (Columns.FindByUId(new Guid("f13ef65d-d5d7-4ef4-af7f-0091a818d68d")) == null) {
				Columns.Add(CreateIsAnonymousAuthenticationColumn());
			}
			if (Columns.FindByUId(new Guid("70615ebe-d19c-4f72-bc86-bfb4df3d0e7e")) == null) {
				Columns.Add(CreateSenderDisplayValueColumn());
			}
			if (Columns.FindByUId(new Guid("7a199eeb-e500-49fd-b0ad-9b67a46c2954")) == null) {
				Columns.Add(CreateSignatureColumn());
			}
			if (Columns.FindByUId(new Guid("a1893376-351f-4313-ac3c-9cce40a90fb7")) == null) {
				Columns.Add(CreateUseSignatureColumn());
			}
			if (Columns.FindByUId(new Guid("15fdc6ab-dabd-4cae-bd25-8a43e6b9e4e2")) == null) {
				Columns.Add(CreateActualizeMessageRelationsColumn());
			}
			if (Columns.FindByUId(new Guid("286e13db-feea-4cb1-94eb-1243692da2b1")) == null) {
				Columns.Add(CreateErrorCodeColumn());
			}
			if (Columns.FindByUId(new Guid("2c6db188-9b8b-4f1c-8be7-150749951df2")) == null) {
				Columns.Add(CreateLastErrorColumn());
			}
			if (Columns.FindByUId(new Guid("1117201b-9272-4977-b4bb-fb4e958c272b")) == null) {
				Columns.Add(CreateRetryCounterColumn());
			}
			if (Columns.FindByUId(new Guid("ce5f1f0d-f5f9-42b6-b855-8ec26bc97177")) == null) {
				Columns.Add(CreateOAuthTokenStorageColumn());
			}
			if (Columns.FindByUId(new Guid("13a7f989-c37b-415d-a681-84d0f520eb87")) == null) {
				Columns.Add(CreateSendWebsocketNotificationsColumn());
			}
			if (Columns.FindByUId(new Guid("a5839346-f78d-43e6-964a-e108f8f129d8")) == null) {
				Columns.Add(CreateSynchronizationStoppedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b238f1d8-39c2-4498-b0a1-d63f123309ea"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUser")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMailServerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("04423276-208b-4661-8602-6b6eadd409b9"),
				Name = @"MailServer",
				ReferenceSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUserNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3490d31d-b9b4-4017-a5c4-3019416d0c0e"),
				Name = @"UserName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUserPasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("6f989bb4-4185-4531-87c8-62927005896b"),
				Name = @"UserPassword",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEnableMailSynhronizationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ead0a7dd-f3e3-4679-b766-d8a9f70b2b53"),
				Name = @"EnableMailSynhronization",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAutomaticallyAddNewEmailsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1dd6b43d-22e9-49f5-9676-f4e93fffc0a5"),
				Name = @"AutomaticallyAddNewEmails",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCyclicallyAddNewEmailsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5b147af6-5886-41cd-b7aa-2ba9a253aab5"),
				Name = @"CyclicallyAddNewEmails",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailsCyclicallyAddingIntervalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("04e621fc-8584-4c36-b616-5e790d2d28ca"),
				Name = @"EmailsCyclicallyAddingInterval",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCustomFlagsNotSuportedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c8b179f9-5a7e-4c20-944e-b6930162b98f"),
				Name = @"IsCustomFlagsNotSuported",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLastSyncDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("64ef7eb3-9995-497d-9c61-e4e09e951132"),
				Name = @"LastSyncDate",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsSharedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bd47456d-aeb5-4454-b2ce-f6dff54a7794"),
				Name = @"IsShared",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSendEmailsViaThisAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e727b47c-883f-4fdf-94aa-e85369c2f8f1"),
				Name = @"SendEmailsViaThisAccount",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2b8a9515-0fd9-40ea-84d2-ba1fa641e03e"),
				Name = @"IsDefault",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLoadAllEmailsFromMailBoxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d52de6c0-104f-4d78-8e92-3376e97a8268"),
				Name = @"LoadAllEmailsFromMailBox",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLoadEmailsFromDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("705a60bf-aee9-4168-993d-ed634328174c"),
				Name = @"LoadEmailsFromDate",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMailboxNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("06c19861-2ce5-4eb7-88b0-117c28deecf4"),
				Name = @"MailboxName",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderEmailAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1400f977-628f-4ebe-bcdb-9fbd661d4799"),
				Name = @"SenderEmailAddress",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("02c41552-6138-41c7-b1d8-208f324fe99a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsAnonymousAuthenticationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f13ef65d-d5d7-4ef4-af7f-0091a818d68d"),
				Name = @"IsAnonymousAuthentication",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("9c993461-5823-4a8d-8ebf-57b39ee436fa"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSenderDisplayValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("70615ebe-d19c-4f72-bc86-bfb4df3d0e7e"),
				Name = @"SenderDisplayValue",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSignatureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7a199eeb-e500-49fd-b0ad-9b67a46c2954"),
				Name = @"Signature",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915")
			};
		}

		protected virtual EntitySchemaColumn CreateUseSignatureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a1893376-351f-4313-ac3c-9cce40a90fb7"),
				Name = @"UseSignature",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915")
			};
		}

		protected virtual EntitySchemaColumn CreateActualizeMessageRelationsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("15fdc6ab-dabd-4cae-bd25-8a43e6b9e4e2"),
				Name = @"ActualizeMessageRelations",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateErrorCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("286e13db-feea-4cb1-94eb-1243692da2b1"),
				Name = @"ErrorCode",
				ReferenceSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateLastErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2c6db188-9b8b-4f1c-8be7-150749951df2"),
				Name = @"LastError",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateRetryCounterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1117201b-9272-4977-b4bb-fb4e958c272b"),
				Name = @"RetryCounter",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateOAuthTokenStorageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ce5f1f0d-f5f9-42b6-b855-8ec26bc97177"),
				Name = @"OAuthTokenStorage",
				ReferenceSchemaUId = new Guid("44bea56e-8a8f-4e29-9494-83253eff2594"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("50cc600a-f6aa-433b-8a0a-6a453519907c")
			};
		}

		protected virtual EntitySchemaColumn CreateSendWebsocketNotificationsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("13a7f989-c37b-415d-a681-84d0f520eb87"),
				Name = @"SendWebsocketNotifications",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSynchronizationStoppedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a5839346-f78d-43e6-964a-e108f8f129d8"),
				Name = @"SynchronizationStopped",
				CreatedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				ModifiedInSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailboxSyncSettings_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxSyncSettings_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxSyncSettings_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxSyncSettings_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_Base_BPMSoft

	/// <summary>
	/// Mailbox synchronization settings.
	/// </summary>
	public class MailboxSyncSettings_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MailboxSyncSettings_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxSyncSettings_Base_BPMSoft";
		}

		public MailboxSyncSettings_Base_BPMSoft(MailboxSyncSettings_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid MailServerId {
			get {
				return GetTypedColumnValue<Guid>("MailServerId");
			}
			set {
				SetColumnValue("MailServerId", value);
				_mailServer = null;
			}
		}

		/// <exclude/>
		public string MailServerName {
			get {
				return GetTypedColumnValue<string>("MailServerName");
			}
			set {
				SetColumnValue("MailServerName", value);
				if (_mailServer != null) {
					_mailServer.Name = value;
				}
			}
		}

		private MailServer _mailServer;
		/// <summary>
		/// Email provider.
		/// </summary>
		public MailServer MailServer {
			get {
				return _mailServer ??
					(_mailServer = LookupColumnEntities.GetEntity("MailServer") as MailServer);
			}
		}

		/// <summary>
		/// Username.
		/// </summary>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string UserPassword {
			get {
				return GetTypedColumnValue<string>("UserPassword");
			}
			set {
				SetColumnValue("UserPassword", value);
			}
		}

		/// <summary>
		/// Download emails to BPMStudio.
		/// </summary>
		public bool EnableMailSynhronization {
			get {
				return GetTypedColumnValue<bool>("EnableMailSynhronization");
			}
			set {
				SetColumnValue("EnableMailSynhronization", value);
			}
		}

		/// <summary>
		/// Automatically download new emails.
		/// </summary>
		public bool AutomaticallyAddNewEmails {
			get {
				return GetTypedColumnValue<bool>("AutomaticallyAddNewEmails");
			}
			set {
				SetColumnValue("AutomaticallyAddNewEmails", value);
			}
		}

		/// <summary>
		/// Load new messages repeatedly.
		/// </summary>
		public bool CyclicallyAddNewEmails {
			get {
				return GetTypedColumnValue<bool>("CyclicallyAddNewEmails");
			}
			set {
				SetColumnValue("CyclicallyAddNewEmails", value);
			}
		}

		/// <summary>
		/// Cyclic download interval.
		/// </summary>
		public int EmailsCyclicallyAddingInterval {
			get {
				return GetTypedColumnValue<int>("EmailsCyclicallyAddingInterval");
			}
			set {
				SetColumnValue("EmailsCyclicallyAddingInterval", value);
			}
		}

		/// <summary>
		/// IsCustomFlagsNotSuported.
		/// </summary>
		public bool IsCustomFlagsNotSuported {
			get {
				return GetTypedColumnValue<bool>("IsCustomFlagsNotSuported");
			}
			set {
				SetColumnValue("IsCustomFlagsNotSuported", value);
			}
		}

		/// <summary>
		/// LastSyncDate.
		/// </summary>
		public DateTime LastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("LastSyncDate");
			}
			set {
				SetColumnValue("LastSyncDate", value);
			}
		}

		/// <summary>
		/// Allow shared access.
		/// </summary>
		public bool IsShared {
			get {
				return GetTypedColumnValue<bool>("IsShared");
			}
			set {
				SetColumnValue("IsShared", value);
			}
		}

		/// <summary>
		/// Send emails from BPMStudio.
		/// </summary>
		public bool SendEmailsViaThisAccount {
			get {
				return GetTypedColumnValue<bool>("SendEmailsViaThisAccount");
			}
			set {
				SetColumnValue("SendEmailsViaThisAccount", value);
			}
		}

		/// <summary>
		/// Use by default.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		/// <summary>
		/// Download all emails from mailbox.
		/// </summary>
		public bool LoadAllEmailsFromMailBox {
			get {
				return GetTypedColumnValue<bool>("LoadAllEmailsFromMailBox");
			}
			set {
				SetColumnValue("LoadAllEmailsFromMailBox", value);
			}
		}

		/// <summary>
		/// Download emails starting from.
		/// </summary>
		public DateTime LoadEmailsFromDate {
			get {
				return GetTypedColumnValue<DateTime>("LoadEmailsFromDate");
			}
			set {
				SetColumnValue("LoadEmailsFromDate", value);
			}
		}

		/// <summary>
		/// Mailbox name.
		/// </summary>
		public string MailboxName {
			get {
				return GetTypedColumnValue<string>("MailboxName");
			}
			set {
				SetColumnValue("MailboxName", value);
			}
		}

		/// <summary>
		/// Sender's email.
		/// </summary>
		public string SenderEmailAddress {
			get {
				return GetTypedColumnValue<string>("SenderEmailAddress");
			}
			set {
				SetColumnValue("SenderEmailAddress", value);
			}
		}

		/// <summary>
		/// Anonymous authentication.
		/// </summary>
		public bool IsAnonymousAuthentication {
			get {
				return GetTypedColumnValue<bool>("IsAnonymousAuthentication");
			}
			set {
				SetColumnValue("IsAnonymousAuthentication", value);
			}
		}

		/// <summary>
		/// Set custom display name.
		/// </summary>
		public string SenderDisplayValue {
			get {
				return GetTypedColumnValue<string>("SenderDisplayValue");
			}
			set {
				SetColumnValue("SenderDisplayValue", value);
			}
		}

		/// <summary>
		/// Signature.
		/// </summary>
		public string Signature {
			get {
				return GetTypedColumnValue<string>("Signature");
			}
			set {
				SetColumnValue("Signature", value);
			}
		}

		/// <summary>
		/// Add signatures to outbound emails.
		/// </summary>
		public bool UseSignature {
			get {
				return GetTypedColumnValue<bool>("UseSignature");
			}
			set {
				SetColumnValue("UseSignature", value);
			}
		}

		/// <summary>
		/// ActualizeMessageRelations.
		/// </summary>
		public bool ActualizeMessageRelations {
			get {
				return GetTypedColumnValue<bool>("ActualizeMessageRelations");
			}
			set {
				SetColumnValue("ActualizeMessageRelations", value);
			}
		}

		/// <exclude/>
		public Guid ErrorCodeId {
			get {
				return GetTypedColumnValue<Guid>("ErrorCodeId");
			}
			set {
				SetColumnValue("ErrorCodeId", value);
				_errorCode = null;
			}
		}

		/// <exclude/>
		public string ErrorCodeName {
			get {
				return GetTypedColumnValue<string>("ErrorCodeName");
			}
			set {
				SetColumnValue("ErrorCodeName", value);
				if (_errorCode != null) {
					_errorCode.Name = value;
				}
			}
		}

		private SyncErrorMessage _errorCode;
		/// <summary>
		/// Error code identifier.
		/// </summary>
		public SyncErrorMessage ErrorCode {
			get {
				return _errorCode ??
					(_errorCode = LookupColumnEntities.GetEntity("ErrorCode") as SyncErrorMessage);
			}
		}

		/// <summary>
		/// Last synchronization error text.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <summary>
		/// Number of retry attempts.
		/// </summary>
		public int RetryCounter {
			get {
				return GetTypedColumnValue<int>("RetryCounter");
			}
			set {
				SetColumnValue("RetryCounter", value);
			}
		}

		/// <exclude/>
		public Guid OAuthTokenStorageId {
			get {
				return GetTypedColumnValue<Guid>("OAuthTokenStorageId");
			}
			set {
				SetColumnValue("OAuthTokenStorageId", value);
				_oAuthTokenStorage = null;
			}
		}

		/// <exclude/>
		public string OAuthTokenStorageUserAppLogin {
			get {
				return GetTypedColumnValue<string>("OAuthTokenStorageUserAppLogin");
			}
			set {
				SetColumnValue("OAuthTokenStorageUserAppLogin", value);
				if (_oAuthTokenStorage != null) {
					_oAuthTokenStorage.UserAppLogin = value;
				}
			}
		}

		private OAuthTokenStorage _oAuthTokenStorage;
		/// <summary>
		/// OAuth token storage identifier.
		/// </summary>
		public OAuthTokenStorage OAuthTokenStorage {
			get {
				return _oAuthTokenStorage ??
					(_oAuthTokenStorage = LookupColumnEntities.GetEntity("OAuthTokenStorage") as OAuthTokenStorage);
			}
		}

		/// <summary>
		/// Send new emails notifications by web socket.
		/// </summary>
		public bool SendWebsocketNotifications {
			get {
				return GetTypedColumnValue<bool>("SendWebsocketNotifications");
			}
			set {
				SetColumnValue("SendWebsocketNotifications", value);
			}
		}

		/// <summary>
		/// Synchronization stopped.
		/// </summary>
		public bool SynchronizationStopped {
			get {
				return GetTypedColumnValue<bool>("SynchronizationStopped");
			}
			set {
				SetColumnValue("SynchronizationStopped", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxSyncSettings_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftInserting", e);
			Loaded += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftLoaded", e);
			Saved += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("MailboxSyncSettings_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxSyncSettings_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_BaseEventsProcess

	/// <exclude/>
	public partial class MailboxSyncSettings_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MailboxSyncSettings_Base_BPMSoft
	{

		public MailboxSyncSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxSyncSettings_BaseEventsProcess";
			SchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5e487721-02e2-48ee-b755-dfa5160f5315");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsSharedDef {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("f05546ac-fcc7-4711-8849-cb96618fa7de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailboxSyncSettingsSaved;
		public ProcessFlowElement MailboxSyncSettingsSaved {
			get {
				return _mailboxSyncSettingsSaved ?? (_mailboxSyncSettingsSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailboxSyncSettingsSaved",
					SchemaElementUId = new Guid("932ab824-8e8b-49f1-a156-5db83030dd13"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mailboxSyncSettingsSavedScriptTask;
		public ProcessScriptTask MailboxSyncSettingsSavedScriptTask {
			get {
				return _mailboxSyncSettingsSavedScriptTask ?? (_mailboxSyncSettingsSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailboxSyncSettingsSavedScriptTask",
					SchemaElementUId = new Guid("ef4f7464-130e-48ef-b835-ac60389c9b97"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailboxSyncSettingsSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("404d60dd-ba85-419c-8bab-5c75a5d06070"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailboxSyncSettingsInserted;
		public ProcessFlowElement MailboxSyncSettingsInserted {
			get {
				return _mailboxSyncSettingsInserted ?? (_mailboxSyncSettingsInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailboxSyncSettingsInserted",
					SchemaElementUId = new Guid("5de1e911-2a94-4b30-9517-d770f7f0eeb7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mailboxSyncSettingsInsertedScriptTask;
		public ProcessScriptTask MailboxSyncSettingsInsertedScriptTask {
			get {
				return _mailboxSyncSettingsInsertedScriptTask ?? (_mailboxSyncSettingsInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailboxSyncSettingsInsertedScriptTask",
					SchemaElementUId = new Guid("118f9ee5-9549-4986-9545-7493769e4cc4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailboxSyncSettingsInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4;
		public ProcessFlowElement EventSubProcess4 {
			get {
				return _eventSubProcess4 ?? (_eventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4",
					SchemaElementUId = new Guid("4a2df159-f182-465e-bad1-4db4e7275fac"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailboxSyncSettingsSaving;
		public ProcessFlowElement MailboxSyncSettingsSaving {
			get {
				return _mailboxSyncSettingsSaving ?? (_mailboxSyncSettingsSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailboxSyncSettingsSaving",
					SchemaElementUId = new Guid("deec75e4-b0e6-4702-b03a-7ccd779c0358"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mailboxSyncSettingsSavingScriptTask;
		public ProcessScriptTask MailboxSyncSettingsSavingScriptTask {
			get {
				return _mailboxSyncSettingsSavingScriptTask ?? (_mailboxSyncSettingsSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailboxSyncSettingsSavingScriptTask",
					SchemaElementUId = new Guid("52d5eb7f-7e4d-47e1-98d7-97797a897ed4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailboxSyncSettingsSavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("97f942d4-6d57-47aa-b066-8c61a65f9413"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailboxSyncSettingsDeleting;
		public ProcessFlowElement MailboxSyncSettingsDeleting {
			get {
				return _mailboxSyncSettingsDeleting ?? (_mailboxSyncSettingsDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailboxSyncSettingsDeleting",
					SchemaElementUId = new Guid("52c6eb3b-0cbb-479b-8e64-1da87e475068"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mailboxSyncSettingsDeletingScriptTask;
		public ProcessScriptTask MailboxSyncSettingsDeletingScriptTask {
			get {
				return _mailboxSyncSettingsDeletingScriptTask ?? (_mailboxSyncSettingsDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailboxSyncSettingsDeletingScriptTask",
					SchemaElementUId = new Guid("c5e440a2-089b-4410-a9e7-1713f6467682"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailboxSyncSettingsDeletingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess5;
		public ProcessFlowElement EventSubProcess5 {
			get {
				return _eventSubProcess5 ?? (_eventSubProcess5 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess5",
					SchemaElementUId = new Guid("f02a626a-3bfe-41e4-9743-d9279f6d7e8f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessageMailboxSyncSettingsUpdated;
		public ProcessFlowElement StartMessageMailboxSyncSettingsUpdated {
			get {
				return _startMessageMailboxSyncSettingsUpdated ?? (_startMessageMailboxSyncSettingsUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessageMailboxSyncSettingsUpdated",
					SchemaElementUId = new Guid("5143a02b-b6cf-46a2-be05-2c5435bcf38c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskMailboxSyncSettingsUpdated;
		public ProcessScriptTask ScriptTaskMailboxSyncSettingsUpdated {
			get {
				return _scriptTaskMailboxSyncSettingsUpdated ?? (_scriptTaskMailboxSyncSettingsUpdated = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskMailboxSyncSettingsUpdated",
					SchemaElementUId = new Guid("907cdc92-62d3-46b7-8114-aa716742b41a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskMailboxSyncSettingsUpdatedExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[MailboxSyncSettingsSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsSaved };
			FlowElements[MailboxSyncSettingsSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsSavedScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[MailboxSyncSettingsInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsInserted };
			FlowElements[MailboxSyncSettingsInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsInsertedScriptTask };
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[MailboxSyncSettingsSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsSaving };
			FlowElements[MailboxSyncSettingsSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsSavingScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[MailboxSyncSettingsDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsDeleting };
			FlowElements[MailboxSyncSettingsDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MailboxSyncSettingsDeletingScriptTask };
			FlowElements[EventSubProcess5.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess5 };
			FlowElements[StartMessageMailboxSyncSettingsUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessageMailboxSyncSettingsUpdated };
			FlowElements[ScriptTaskMailboxSyncSettingsUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskMailboxSyncSettingsUpdated };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "MailboxSyncSettingsSaved":
						e.Context.QueueTasks.Enqueue("MailboxSyncSettingsSavedScriptTask");
						break;
					case "MailboxSyncSettingsSavedScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "MailboxSyncSettingsInserted":
						e.Context.QueueTasks.Enqueue("MailboxSyncSettingsInsertedScriptTask");
						break;
					case "MailboxSyncSettingsInsertedScriptTask":
						break;
					case "EventSubProcess4":
						break;
					case "MailboxSyncSettingsSaving":
						e.Context.QueueTasks.Enqueue("MailboxSyncSettingsSavingScriptTask");
						break;
					case "MailboxSyncSettingsSavingScriptTask":
						break;
					case "EventSubProcess3":
						break;
					case "MailboxSyncSettingsDeleting":
						e.Context.QueueTasks.Enqueue("MailboxSyncSettingsDeletingScriptTask");
						break;
					case "MailboxSyncSettingsDeletingScriptTask":
						break;
					case "EventSubProcess5":
						break;
					case "StartMessageMailboxSyncSettingsUpdated":
						e.Context.QueueTasks.Enqueue("ScriptTaskMailboxSyncSettingsUpdated");
						break;
					case "ScriptTaskMailboxSyncSettingsUpdated":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("MailboxSyncSettingsSaved");
			ActivatedEventElements.Add("MailboxSyncSettingsInserted");
			ActivatedEventElements.Add("MailboxSyncSettingsSaving");
			ActivatedEventElements.Add("MailboxSyncSettingsDeleting");
			ActivatedEventElements.Add("StartMessageMailboxSyncSettingsUpdated");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "MailboxSyncSettingsSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsSaved";
					result = MailboxSyncSettingsSaved.Execute(context);
					break;
				case "MailboxSyncSettingsSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsSavedScriptTask";
					result = MailboxSyncSettingsSavedScriptTask.Execute(context, MailboxSyncSettingsSavedScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "MailboxSyncSettingsInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsInserted";
					result = MailboxSyncSettingsInserted.Execute(context);
					break;
				case "MailboxSyncSettingsInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsInsertedScriptTask";
					result = MailboxSyncSettingsInsertedScriptTask.Execute(context, MailboxSyncSettingsInsertedScriptTaskExecute);
					break;
				case "EventSubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "MailboxSyncSettingsSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsSaving";
					result = MailboxSyncSettingsSaving.Execute(context);
					break;
				case "MailboxSyncSettingsSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsSavingScriptTask";
					result = MailboxSyncSettingsSavingScriptTask.Execute(context, MailboxSyncSettingsSavingScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "MailboxSyncSettingsDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsDeleting";
					result = MailboxSyncSettingsDeleting.Execute(context);
					break;
				case "MailboxSyncSettingsDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailboxSyncSettingsDeletingScriptTask";
					result = MailboxSyncSettingsDeletingScriptTask.Execute(context, MailboxSyncSettingsDeletingScriptTaskExecute);
					break;
				case "EventSubProcess5":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessageMailboxSyncSettingsUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessageMailboxSyncSettingsUpdated";
					result = StartMessageMailboxSyncSettingsUpdated.Execute(context);
					break;
				case "ScriptTaskMailboxSyncSettingsUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskMailboxSyncSettingsUpdated";
					result = ScriptTaskMailboxSyncSettingsUpdated.Execute(context, ScriptTaskMailboxSyncSettingsUpdatedExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool MailboxSyncSettingsSavedScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.IsDefault) {
				var upd = new Update(UserConnection, "MailboxSyncSettings")
					.Set("IsDefault", Column.Parameter(false))
					.Where("Id").IsNotEqual(Column.Parameter(Entity.Id))
					.And("IsDefault").IsEqual(Column.Parameter(true))
					.And("SysAdminUnitId").IsEqual(Column.Parameter(Entity.SysAdminUnitId)) as Update;
				upd.Execute();
			}
			if (IsSharedDef && !Entity.IsShared) {
				DeleteSharedRights();
			}
			return true;
		}

		public virtual bool MailboxSyncSettingsInsertedScriptTaskExecute(ProcessExecutingContext context) {
			var rootEmailFolderId = new Guid("181F9D34-5DEE-E011-A86B-00155D04C01D");
			var mailboxFolderTypeId = FolderConsts.MailboxFolderTypeId;
			var activityFolder = new BPMSoft.Configuration.ActivityFolder(UserConnection);
			activityFolder.Id = Guid.NewGuid();
			activityFolder.Name = Entity.MailboxName;
			activityFolder.ParentId = rootEmailFolderId;
			activityFolder.FolderTypeId = mailboxFolderTypeId;
			activityFolder.Save();
			return true;
		}

		public virtual bool MailboxSyncSettingsSavingScriptTaskExecute(ProcessExecutingContext context) {
			IsSharedDef = (bool)(Entity.GetColumnOldValue("IsShared") ?? false);
			return true;
		}

		public virtual bool MailboxSyncSettingsDeletingScriptTaskExecute(ProcessExecutingContext context) {
			var activityFolderSchema = UserConnection.EntitySchemaManager.FindInstanceByName("ActivityFolder");
			var activityFolder = activityFolderSchema.CreateEntity(UserConnection);
			var condition = new Dictionary<string, object>();
			condition.Add("Name", Entity.MailboxName);
			if(activityFolder.FetchFromDB(condition)) {
				activityFolder.Delete();
			}
			return true;
		}

		public virtual bool ScriptTaskMailboxSyncSettingsUpdatedExecute(ProcessExecutingContext context) {
			var newValue = Entity.GetTypedColumnValue<string>("MailboxName");
			var oldValue = Entity.GetTypedOldColumnValue<string>("MailboxName");
			if (newValue != oldValue) {
				var update = new Update(UserConnection, "ActivityFolder")
					.Set("Name", Column.Parameter(newValue))
					.Where("Name").IsLike(Column.Parameter(oldValue))
					.And("FolderTypeId").IsEqual(Column.Parameter(FolderConsts.MailboxFolderTypeId));
				update.Execute();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MailboxSyncSettings_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("MailboxSyncSettingsSaved")) {
							context.QueueTasks.Enqueue("MailboxSyncSettingsSaved");
						}
						break;
					case "MailboxSyncSettings_Base_BPMSoftInserted":
							if (ActivatedEventElements.Contains("MailboxSyncSettingsInserted")) {
							context.QueueTasks.Enqueue("MailboxSyncSettingsInserted");
						}
						break;
					case "MailboxSyncSettings_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("MailboxSyncSettingsSaving")) {
							context.QueueTasks.Enqueue("MailboxSyncSettingsSaving");
						}
						break;
					case "MailboxSyncSettings_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("MailboxSyncSettingsDeleting")) {
							context.QueueTasks.Enqueue("MailboxSyncSettingsDeleting");
						}
						break;
					case "MailboxSyncSettings_Base_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("StartMessageMailboxSyncSettingsUpdated")) {
							context.QueueTasks.Enqueue("StartMessageMailboxSyncSettingsUpdated");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_BaseEventsProcess

	/// <exclude/>
	public class MailboxSyncSettings_BaseEventsProcess : MailboxSyncSettings_BaseEventsProcess<MailboxSyncSettings_Base_BPMSoft>
	{

		public MailboxSyncSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxSyncSettings_BaseEventsProcess

	public partial class MailboxSyncSettings_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void DeleteSharedRights() {
			var currentUserId = UserConnection.CurrentUser.Id;
			var manualSourceId = new Guid("8A248A03-E9A5-DF11-9989-485B39C18470");
			var del = new Delete(UserConnection)
				.From("SysMailboxSyncSettingsRight")
				.Where("RecordId").IsEqual(Column.Parameter(Entity.Id))
				.And("SysAdminUnitId").IsNotEqual(Column.Parameter(currentUserId)) as Delete;
			del.Execute();
			var sel = new Select(UserConnection)
				.Column("Id")
				.From("SysMailboxSyncSettingsRight")
				.Where("RecordId").IsEqual(Column.Parameter(Entity.Id))
				.And("SysAdminUnitId").IsEqual(Column.Parameter(currentUserId)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = sel.ExecuteReader(dbExecutor)) {
					if(!dr.Read()) {
						Insert ins =
							new Insert(UserConnection)
								.Into("SysMailboxSyncSettingsRight")
								.Set("RecordId", Column.Parameter(Entity.Id))
								.Set("SysAdminUnitId", Column.Parameter(currentUserId))
								.Set("Operation", Column.Parameter(EntitySchemaRecordRightOperation.Read))
								.Set("RightLevel", Column.Parameter(2))
								.Set("Position", Column.Parameter(0))
								.Set("SourceId", Column.Parameter("8A248A03-E9A5-DF11-9989-485B39C18470"))
								 as Insert;
						ins.Execute();
						ins =
							new Insert(UserConnection)
								.Into("SysMailboxSyncSettingsRight")
								.Set("RecordId", Column.Parameter(Entity.Id))
								.Set("SysAdminUnitId", Column.Parameter(currentUserId))
								.Set("Operation", Column.Parameter(EntitySchemaRecordRightOperation.Edit))
								.Set("RightLevel", Column.Parameter(2))
								.Set("Position", Column.Parameter(0))
								.Set("SourceId", Column.Parameter("8A248A03-E9A5-DF11-9989-485B39C18470"))
								 as Insert;
						ins.Execute();
						ins =
							new Insert(UserConnection)
								.Into("SysMailboxSyncSettingsRight")
								.Set("RecordId", Column.Parameter(Entity.Id))
								.Set("SysAdminUnitId", Column.Parameter(currentUserId))
								.Set("Operation", Column.Parameter(EntitySchemaRecordRightOperation.Delete))
								.Set("RightLevel", Column.Parameter(2))
								.Set("Position", Column.Parameter(0))
								.Set("SourceId", Column.Parameter("8A248A03-E9A5-DF11-9989-485B39C18470"))
								 as Insert;
						ins.Execute();
					}
				}
			}
		}

		#endregion

	}

	#endregion

}

