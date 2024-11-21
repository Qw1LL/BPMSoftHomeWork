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
	using BPMSoft.Core.Store;
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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;

	#region Class: Activity_Base_BPMSoftSchema

	/// <exclude/>
	public class Activity_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Activity_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_Base_BPMSoftSchema(Activity_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_Base_BPMSoftSchema(Activity_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			RealUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			Name = "Activity_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateStartDateColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeOwnerAdminUnitColumn() {
			base.InitializeOwnerAdminUnitColumn();
			OwnerAdminUnitColumn = CreateOwnerRoleColumn();
			if (Columns.FindByUId(OwnerAdminUnitColumn.UId) == null) {
				Columns.Add(OwnerAdminUnitColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4038ce1f-15b2-4630-abb6-0c7377ab4c9b")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("4248a634-bad1-4a20-a6af-4cd85fd24630")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("60c813ae-ce04-4c50-9049-affa1ce6e7b8")) == null) {
				Columns.Add(CreateAuthorColumn());
			}
			if (Columns.FindByUId(new Guid("0d677c6b-95fd-47e2-a8b1-eadea6767eff")) == null) {
				Columns.Add(CreateRemindToAuthorColumn());
			}
			if (Columns.FindByUId(new Guid("69e70c11-5851-467a-b74b-15d3505e4f57")) == null) {
				Columns.Add(CreateRemindToAuthorDateColumn());
			}
			if (Columns.FindByUId(new Guid("de2d9c7f-a8b4-4f28-85d3-ee2593ac0f00")) == null) {
				Columns.Add(CreateRemindToOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("9917a146-aa6a-46d0-bd35-a9356c4d4992")) == null) {
				Columns.Add(CreateRemindToOwnerDateColumn());
			}
			if (Columns.FindByUId(new Guid("5491c33f-e927-4ca8-a579-d4810ea54c56")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("c814fa71-e01b-4325-ac8d-8d4a293ed138")) == null) {
				Columns.Add(CreateActivityCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("ff2dec51-885c-428a-8e6a-80c0c14b1434")) == null) {
				Columns.Add(CreateShowInSchedulerColumn());
			}
			if (Columns.FindByUId(new Guid("c8d84f9c-b48b-479b-9ac6-4412f3436ca2")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("ae372cfa-a21f-47f0-8a64-17d137ebe966")) == null) {
				Columns.Add(CreateResultColumn());
			}
			if (Columns.FindByUId(new Guid("070b689f-c9d8-46e3-bb52-bcb1f430f5cf")) == null) {
				Columns.Add(CreateDetailedResultColumn());
			}
			if (Columns.FindByUId(new Guid("06ff3e76-36f0-44d2-8f07-ffb752ffde09")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
			if (Columns.FindByUId(new Guid("fb0d6fd1-17a1-4a04-a155-a4b643c6d048")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("bfaa9c7f-c368-4402-8310-a17660faf148")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("52b16ed8-6a96-4c0d-9887-4ba8cbb953e9")) == null) {
				Columns.Add(CreateSenderColumn());
			}
			if (Columns.FindByUId(new Guid("0cb5732f-80c0-41ab-a51a-8a509143a98b")) == null) {
				Columns.Add(CreateRecepientColumn());
			}
			if (Columns.FindByUId(new Guid("b2e5a95e-72e6-4985-b9b2-af1c335ed333")) == null) {
				Columns.Add(CreateCopyRecepientColumn());
			}
			if (Columns.FindByUId(new Guid("a1502eb1-c06a-4e2e-8010-f51eed7315d4")) == null) {
				Columns.Add(CreateBlindCopyRecepientColumn());
			}
			if (Columns.FindByUId(new Guid("618e7503-83b1-452d-aa33-8f76792853b5")) == null) {
				Columns.Add(CreateBodyColumn());
			}
			if (Columns.FindByUId(new Guid("961b5183-9eff-4424-b7f8-ee5267b489b6")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("b5b47ef8-e084-4cb0-bf59-19b3199014c7")) == null) {
				Columns.Add(CreateColorColumn());
			}
			if (Columns.FindByUId(new Guid("6689a019-c904-4b25-a89d-d17f3f3767cc")) == null) {
				Columns.Add(CreateSendDateColumn());
			}
			if (Columns.FindByUId(new Guid("4935a122-b7bc-443c-a282-72bd82f76ec4")) == null) {
				Columns.Add(CreateEmailSendStatusColumn());
			}
			if (Columns.FindByUId(new Guid("dd115e6f-5443-4238-97d5-3f9c36d8a9db")) == null) {
				Columns.Add(CreateDurationInMinutesColumn());
			}
			if (Columns.FindByUId(new Guid("5ff0586c-bedc-4c23-84f3-086402411dbb")) == null) {
				Columns.Add(CreateErrorOnSendColumn());
			}
			if (Columns.FindByUId(new Guid("487c8731-254d-4f2d-b152-9d823db2fc51")) == null) {
				Columns.Add(CreateDurationInMnutesAndHoursColumn());
			}
			if (Columns.FindByUId(new Guid("7bb00970-c11a-4a5a-82e5-d0a613afde06")) == null) {
				Columns.Add(CreateAllowedResultColumn());
			}
			if (Columns.FindByUId(new Guid("c7636768-5007-4cb9-800f-0d729fcadf4f")) == null) {
				Columns.Add(CreateCreatedByInvCRMColumn());
			}
			if (Columns.FindByUId(new Guid("af5a73d3-20ec-4419-819b-1575ce196bd2")) == null) {
				Columns.Add(CreateMessageTypeColumn());
			}
			if (Columns.FindByUId(new Guid("80fd1395-7e28-485e-a566-82fa964ba80b")) == null) {
				Columns.Add(CreateIsHtmlBodyColumn());
			}
			if (Columns.FindByUId(new Guid("1c19adcd-d3b5-4403-b515-b5c2cc9e481c")) == null) {
				Columns.Add(CreateMailHashColumn());
			}
			if (Columns.FindByUId(new Guid("ee2173fc-0840-4735-8c14-b58b6e3d9b99")) == null) {
				Columns.Add(CreateProcessElementIdColumn());
			}
			if (Columns.FindByUId(new Guid("d480d73a-f329-47f2-a0a2-cac4e82a2a40")) == null) {
				Columns.Add(CreateGlobalActivityIDColumn());
			}
			if (Columns.FindByUId(new Guid("004b1104-cc46-4865-b079-f23d2665c922")) == null) {
				Columns.Add(CreateIsNeedProcessColumn());
			}
			if (Columns.FindByUId(new Guid("2bbd4d7c-2727-47d6-bde1-311fdbbbb97e")) == null) {
				Columns.Add(CreateActivityConnectionColumn());
			}
			if (Columns.FindByUId(new Guid("734dfca1-2478-4719-8f3c-bfe3c6d1813d")) == null) {
				Columns.Add(CreateOrganizerColumn());
			}
			if (Columns.FindByUId(new Guid("a3d9fc18-5ad2-486f-9efd-be29f0d4429a")) == null) {
				Columns.Add(CreateCallDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("3f1f6edd-5b9c-45d5-9575-edcf22c54893")) == null) {
				Columns.Add(CreateHeaderPropertiesColumn());
			}
			if (Columns.FindByUId(new Guid("7737db5f-7bab-4188-9d8e-a89636a84370")) == null) {
				Columns.Add(CreateIsAutoSubmittedColumn());
			}
			if (Columns.FindByUId(new Guid("67551707-45c4-4d2b-a77b-683eb8aa5fe1")) == null) {
				Columns.Add(CreateSenderContactColumn());
			}
			if (Columns.FindByUId(new Guid("6bb4799d-c450-4d98-ae51-a92e9689c358")) == null) {
				Columns.Add(CreatePreviewColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("4dcf0a31-7fd7-4dba-a004-e413b1753431"),
				Name = @"Title",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("a12ca538-61b1-4907-9fdf-01969163d4dd"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("4038ce1f-15b2-4630-abb6-0c7377ab4c9b"),
				Name = @"DueDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4248a634-bad1-4a20-a6af-4cd85fd24630"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"ab96fa02-7fe6-df11-971b-001d60e938c6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAuthorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("60c813ae-ce04-4c50-9049-affa1ce6e7b8"),
				Name = @"Author",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRemindToAuthorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0d677c6b-95fd-47e2-a8b1-eadea6767eff"),
				Name = @"RemindToAuthor",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindToAuthorDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("69e70c11-5851-467a-b74b-15d3505e4f57"),
				Name = @"RemindToAuthorDate",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f0736fa3-79d1-4760-ae69-96ec56993491"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRemindToOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("de2d9c7f-a8b4-4f28-85d3-ee2593ac0f00"),
				Name = @"RemindToOwner",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindToOwnerDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("9917a146-aa6a-46d0-bd35-a9356c4d4992"),
				Name = @"RemindToOwnerDate",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5491c33f-e927-4ca8-a579-d4810ea54c56"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"fbe0acdc-cfc0-df11-b00f-001d60e938c6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateActivityCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c814fa71-e01b-4325-ac8d-8d4a293ed138"),
				Name = @"ActivityCategory",
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"f51c4643-58e6-df11-971b-001d60e938c6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateShowInSchedulerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ff2dec51-885c-428a-8e6a-80c0c14b1434"),
				Name = @"ShowInScheduler",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c8d84f9c-b48b-479b-9ac6-4412f3436ca2"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("805aace4-8604-40e7-a9eb-0f54174593c0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"384d4b84-58e6-df11-971b-001d60e938c6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ae372cfa-a21f-47f0-8a64-17d137ebe966"),
				Name = @"Result",
				ReferenceSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateDetailedResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("070b689f-c9d8-46e3-bb52-bcb1f430f5cf"),
				Name = @"DetailedResult",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("06ff3e76-36f0-44d2-8f07-ffb752ffde09"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb0d6fd1-17a1-4a04-a155-a4b643c6d048"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bfaa9c7f-c368-4402-8310-a17660faf148"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateSenderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("52b16ed8-6a96-4c0d-9887-4ba8cbb953e9"),
				Name = @"Sender",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateRecepientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0cb5732f-80c0-41ab-a51a-8a509143a98b"),
				Name = @"Recepient",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCopyRecepientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b2e5a95e-72e6-4985-b9b2-af1c335ed333"),
				Name = @"CopyRecepient",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateBlindCopyRecepientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1502eb1-c06a-4e2e-8010-f51eed7315d4"),
				Name = @"BlindCopyRecepient",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("618e7503-83b1-452d-aa33-8f76792853b5"),
				Name = @"Body",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("961b5183-9eff-4424-b7f8-ee5267b489b6"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("b5b47ef8-e084-4cb0-bf59-19b3199014c7"),
				Name = @"Color",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"#405f97"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSendDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("6689a019-c904-4b25-a89d-d17f3f3767cc"),
				Name = @"SendDate",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailSendStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4935a122-b7bc-443c-a282-72bd82f76ec4"),
				Name = @"EmailSendStatus",
				ReferenceSchemaUId = new Guid("f3f1789f-fb2d-436f-a590-93667c0e8644"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInMinutesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("dd115e6f-5443-4238-97d5-3f9c36d8a9db"),
				Name = @"DurationInMinutes",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorOnSendColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5ff0586c-bedc-4c23-84f3-086402411dbb"),
				Name = @"ErrorOnSend",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInMnutesAndHoursColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("487c8731-254d-4f2d-b152-9d823db2fc51"),
				Name = @"DurationInMnutesAndHours",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAllowedResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7bb00970-c11a-4a5a-82e5-d0a613afde06"),
				Name = @"AllowedResult",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedByInvCRMColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c7636768-5007-4cb9-800f-0d729fcadf4f"),
				Name = @"CreatedByInvCRM",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("af5a73d3-20ec-4419-819b-1575ce196bd2"),
				Name = @"MessageType",
				ReferenceSchemaUId = new Guid("4b276ad6-71c1-4b9a-be9d-379edc60012f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsHtmlBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("80fd1395-7e28-485e-a566-82fa964ba80b"),
				Name = @"IsHtmlBody",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMailHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("1c19adcd-d3b5-4403-b515-b5c2cc9e481c"),
				Name = @"MailHash",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("22efb752-2950-4da1-988b-653cc43dc44c")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ee2173fc-0840-4735-8c14-b58b6e3d9b99"),
				Name = @"ProcessElementId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("5ca48210-97af-47ed-9943-795346aceaf8")
			};
		}

		protected virtual EntitySchemaColumn CreateGlobalActivityIDColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d480d73a-f329-47f2-a0a2-cac4e82a2a40"),
				Name = @"GlobalActivityID",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("02c41552-6138-41c7-b1d8-208f324fe99a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsNeedProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("004b1104-cc46-4865-b079-f23d2665c922"),
				Name = @"IsNeedProcess",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("e2abafdc-6941-48ad-bc50-34f0bc9897c4")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityConnectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2bbd4d7c-2727-47d6-bde1-311fdbbbb97e"),
				Name = @"ActivityConnection",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("61ccc0bd-2b82-4636-a566-7b489433a0ee")
			};
		}

		protected virtual EntitySchemaColumn CreateOrganizerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("734dfca1-2478-4719-8f3c-bfe3c6d1813d"),
				Name = @"Organizer",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("9dae2167-8d3b-4948-9812-c7a970f9490e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCallDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3d9fc18-5ad2-486f-9efd-be29f0d4429a"),
				Name = @"CallDirection",
				ReferenceSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("53c6a55b-73f6-4900-9445-a818892f6106"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1d96a65f-2131-4916-8825-2d142b1000b2"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateHeaderPropertiesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3f1f6edd-5b9c-45d5-9575-edcf22c54893"),
				Name = @"HeaderProperties",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsAutoSubmittedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7737db5f-7bab-4188-9d8e-a89636a84370"),
				Name = @"IsAutoSubmitted",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("67551707-45c4-4d2b-a77b-683eb8aa5fe1"),
				Name = @"SenderContact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreatePreviewColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6bb4799d-c450-4d98-ae51-a92e9689c358"),
				Name = @"Preview",
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("44967d0f-c9bf-4baa-2759-11e670e86cc3"),
				Name = @"OwnerRole",
				ReferenceSchemaUId = new Guid("1f424900-3d1a-4ffe-badd-a76e62ed952b"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("07376563-30e5-48fd-8d5f-c37f73bbc55d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_Base_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Activity_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_Base_BPMSoft";
		}

		public Activity_Base_BPMSoft(Activity_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Начало.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Завершение.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private ActivityPriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public ActivityPriority Priority {
			get {
				return _priority ??
					(_priority = LookupColumnEntities.GetEntity("Priority") as ActivityPriority);
			}
		}

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private Contact _author;
		/// <summary>
		/// Автор.
		/// </summary>
		public Contact Author {
			get {
				return _author ??
					(_author = LookupColumnEntities.GetEntity("Author") as Contact);
			}
		}

		/// <summary>
		/// Напоминать автору.
		/// </summary>
		public bool RemindToAuthor {
			get {
				return GetTypedColumnValue<bool>("RemindToAuthor");
			}
			set {
				SetColumnValue("RemindToAuthor", value);
			}
		}

		/// <summary>
		/// Дата напоминания автору.
		/// </summary>
		public DateTime RemindToAuthorDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToAuthorDate");
			}
			set {
				SetColumnValue("RemindToAuthorDate", value);
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
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Напоминать ответственному.
		/// </summary>
		public bool RemindToOwner {
			get {
				return GetTypedColumnValue<bool>("RemindToOwner");
			}
			set {
				SetColumnValue("RemindToOwner", value);
			}
		}

		/// <summary>
		/// Дата напоминания ответственному.
		/// </summary>
		public DateTime RemindToOwnerDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToOwnerDate");
			}
			set {
				SetColumnValue("RemindToOwnerDate", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ActivityType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ActivityType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ActivityType);
			}
		}

		/// <exclude/>
		public Guid ActivityCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ActivityCategoryId");
			}
			set {
				SetColumnValue("ActivityCategoryId", value);
				_activityCategory = null;
			}
		}

		/// <exclude/>
		public string ActivityCategoryName {
			get {
				return GetTypedColumnValue<string>("ActivityCategoryName");
			}
			set {
				SetColumnValue("ActivityCategoryName", value);
				if (_activityCategory != null) {
					_activityCategory.Name = value;
				}
			}
		}

		private ActivityCategory _activityCategory;
		/// <summary>
		/// Категория.
		/// </summary>
		public ActivityCategory ActivityCategory {
			get {
				return _activityCategory ??
					(_activityCategory = LookupColumnEntities.GetEntity("ActivityCategory") as ActivityCategory);
			}
		}

		/// <summary>
		/// Отображать в расписании.
		/// </summary>
		public bool ShowInScheduler {
			get {
				return GetTypedColumnValue<bool>("ShowInScheduler");
			}
			set {
				SetColumnValue("ShowInScheduler", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private ActivityStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ActivityStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ActivityStatus);
			}
		}

		/// <exclude/>
		public Guid ResultId {
			get {
				return GetTypedColumnValue<Guid>("ResultId");
			}
			set {
				SetColumnValue("ResultId", value);
				_result = null;
			}
		}

		/// <exclude/>
		public string ResultName {
			get {
				return GetTypedColumnValue<string>("ResultName");
			}
			set {
				SetColumnValue("ResultName", value);
				if (_result != null) {
					_result.Name = value;
				}
			}
		}

		private ActivityResult _result;
		/// <summary>
		/// Результат.
		/// </summary>
		public ActivityResult Result {
			get {
				return _result ??
					(_result = LookupColumnEntities.GetEntity("Result") as ActivityResult);
			}
		}

		/// <summary>
		/// Результат подробно.
		/// </summary>
		public string DetailedResult {
			get {
				return GetTypedColumnValue<string>("DetailedResult");
			}
			set {
				SetColumnValue("DetailedResult", value);
			}
		}

		/// <exclude/>
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Часовой пояс.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = LookupColumnEntities.GetEntity("TimeZone") as TimeZone);
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
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

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
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// От кого.
		/// </summary>
		public string Sender {
			get {
				return GetTypedColumnValue<string>("Sender");
			}
			set {
				SetColumnValue("Sender", value);
			}
		}

		/// <summary>
		/// Кому.
		/// </summary>
		public string Recepient {
			get {
				return GetTypedColumnValue<string>("Recepient");
			}
			set {
				SetColumnValue("Recepient", value);
			}
		}

		/// <summary>
		/// Копия.
		/// </summary>
		public string CopyRecepient {
			get {
				return GetTypedColumnValue<string>("CopyRecepient");
			}
			set {
				SetColumnValue("CopyRecepient", value);
			}
		}

		/// <summary>
		/// Скрытая копия.
		/// </summary>
		public string BlindCopyRecepient {
			get {
				return GetTypedColumnValue<string>("BlindCopyRecepient");
			}
			set {
				SetColumnValue("BlindCopyRecepient", value);
			}
		}

		/// <summary>
		/// Тело.
		/// </summary>
		public string Body {
			get {
				return GetTypedColumnValue<string>("Body");
			}
			set {
				SetColumnValue("Body", value);
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Цвет.
		/// </summary>
		/// <remarks>
		/// Цвет задачи.
		/// </remarks>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Отправлено.
		/// </summary>
		public DateTime SendDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDate");
			}
			set {
				SetColumnValue("SendDate", value);
			}
		}

		/// <exclude/>
		public Guid EmailSendStatusId {
			get {
				return GetTypedColumnValue<Guid>("EmailSendStatusId");
			}
			set {
				SetColumnValue("EmailSendStatusId", value);
				_emailSendStatus = null;
			}
		}

		/// <exclude/>
		public string EmailSendStatusName {
			get {
				return GetTypedColumnValue<string>("EmailSendStatusName");
			}
			set {
				SetColumnValue("EmailSendStatusName", value);
				if (_emailSendStatus != null) {
					_emailSendStatus.Name = value;
				}
			}
		}

		private EmailSendStatus _emailSendStatus;
		/// <summary>
		/// Состояние отправки сообщения.
		/// </summary>
		public EmailSendStatus EmailSendStatus {
			get {
				return _emailSendStatus ??
					(_emailSendStatus = LookupColumnEntities.GetEntity("EmailSendStatus") as EmailSendStatus);
			}
		}

		/// <summary>
		/// Продолжительность (минут).
		/// </summary>
		public int DurationInMinutes {
			get {
				return GetTypedColumnValue<int>("DurationInMinutes");
			}
			set {
				SetColumnValue("DurationInMinutes", value);
			}
		}

		/// <summary>
		/// Ошибка при отправке.
		/// </summary>
		public string ErrorOnSend {
			get {
				return GetTypedColumnValue<string>("ErrorOnSend");
			}
			set {
				SetColumnValue("ErrorOnSend", value);
			}
		}

		/// <summary>
		/// Продолжительность (часов, минут).
		/// </summary>
		public string DurationInMnutesAndHours {
			get {
				return GetTypedColumnValue<string>("DurationInMnutesAndHours");
			}
			set {
				SetColumnValue("DurationInMnutesAndHours", value);
			}
		}

		/// <summary>
		/// Возможные результаты.
		/// </summary>
		public string AllowedResult {
			get {
				return GetTypedColumnValue<string>("AllowedResult");
			}
			set {
				SetColumnValue("AllowedResult", value);
			}
		}

		/// <summary>
		/// Создано в InvisibleCRM.
		/// </summary>
		public bool CreatedByInvCRM {
			get {
				return GetTypedColumnValue<bool>("CreatedByInvCRM");
			}
			set {
				SetColumnValue("CreatedByInvCRM", value);
			}
		}

		/// <exclude/>
		public Guid MessageTypeId {
			get {
				return GetTypedColumnValue<Guid>("MessageTypeId");
			}
			set {
				SetColumnValue("MessageTypeId", value);
				_messageType = null;
			}
		}

		/// <exclude/>
		public string MessageTypeName {
			get {
				return GetTypedColumnValue<string>("MessageTypeName");
			}
			set {
				SetColumnValue("MessageTypeName", value);
				if (_messageType != null) {
					_messageType.Name = value;
				}
			}
		}

		private EmailType _messageType;
		/// <summary>
		/// Тип сообщения.
		/// </summary>
		public EmailType MessageType {
			get {
				return _messageType ??
					(_messageType = LookupColumnEntities.GetEntity("MessageType") as EmailType);
			}
		}

		/// <summary>
		/// Тело письма в формате HTML.
		/// </summary>
		public bool IsHtmlBody {
			get {
				return GetTypedColumnValue<bool>("IsHtmlBody");
			}
			set {
				SetColumnValue("IsHtmlBody", value);
			}
		}

		/// <summary>
		/// Хеш код.
		/// </summary>
		public string MailHash {
			get {
				return GetTypedColumnValue<string>("MailHash");
			}
			set {
				SetColumnValue("MailHash", value);
			}
		}

		/// <summary>
		/// Элемент процесса.
		/// </summary>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
			}
		}

		/// <summary>
		/// Глобальный идентификатор активности Outlook.
		/// </summary>
		public string GlobalActivityID {
			get {
				return GetTypedColumnValue<string>("GlobalActivityID");
			}
			set {
				SetColumnValue("GlobalActivityID", value);
			}
		}

		/// <summary>
		/// Нуждается в обработке.
		/// </summary>
		public bool IsNeedProcess {
			get {
				return GetTypedColumnValue<bool>("IsNeedProcess");
			}
			set {
				SetColumnValue("IsNeedProcess", value);
			}
		}

		/// <exclude/>
		public Guid ActivityConnectionId {
			get {
				return GetTypedColumnValue<Guid>("ActivityConnectionId");
			}
			set {
				SetColumnValue("ActivityConnectionId", value);
				_activityConnection = null;
			}
		}

		/// <exclude/>
		public string ActivityConnectionTitle {
			get {
				return GetTypedColumnValue<string>("ActivityConnectionTitle");
			}
			set {
				SetColumnValue("ActivityConnectionTitle", value);
				if (_activityConnection != null) {
					_activityConnection.Title = value;
				}
			}
		}

		private Activity _activityConnection;
		/// <summary>
		/// Активность.
		/// </summary>
		public Activity ActivityConnection {
			get {
				return _activityConnection ??
					(_activityConnection = LookupColumnEntities.GetEntity("ActivityConnection") as Activity);
			}
		}

		/// <exclude/>
		public Guid OrganizerId {
			get {
				return GetTypedColumnValue<Guid>("OrganizerId");
			}
			set {
				SetColumnValue("OrganizerId", value);
				_organizer = null;
			}
		}

		/// <exclude/>
		public string OrganizerName {
			get {
				return GetTypedColumnValue<string>("OrganizerName");
			}
			set {
				SetColumnValue("OrganizerName", value);
				if (_organizer != null) {
					_organizer.Name = value;
				}
			}
		}

		private Contact _organizer;
		/// <summary>
		/// Организатор.
		/// </summary>
		public Contact Organizer {
			get {
				return _organizer ??
					(_organizer = LookupColumnEntities.GetEntity("Organizer") as Contact);
			}
		}

		/// <exclude/>
		public Guid CallDirectionId {
			get {
				return GetTypedColumnValue<Guid>("CallDirectionId");
			}
			set {
				SetColumnValue("CallDirectionId", value);
				_callDirection = null;
			}
		}

		/// <exclude/>
		public string CallDirectionName {
			get {
				return GetTypedColumnValue<string>("CallDirectionName");
			}
			set {
				SetColumnValue("CallDirectionName", value);
				if (_callDirection != null) {
					_callDirection.Name = value;
				}
			}
		}

		private CallDirection _callDirection;
		/// <summary>
		/// Направление звонка.
		/// </summary>
		public CallDirection CallDirection {
			get {
				return _callDirection ??
					(_callDirection = LookupColumnEntities.GetEntity("CallDirection") as CallDirection);
			}
		}

		/// <summary>
		/// Свойства заголовка.
		/// </summary>
		public string HeaderProperties {
			get {
				return GetTypedColumnValue<string>("HeaderProperties");
			}
			set {
				SetColumnValue("HeaderProperties", value);
			}
		}

		/// <summary>
		/// Автоматическое уведомление.
		/// </summary>
		public bool IsAutoSubmitted {
			get {
				return GetTypedColumnValue<bool>("IsAutoSubmitted");
			}
			set {
				SetColumnValue("IsAutoSubmitted", value);
			}
		}

		/// <exclude/>
		public Guid SenderContactId {
			get {
				return GetTypedColumnValue<Guid>("SenderContactId");
			}
			set {
				SetColumnValue("SenderContactId", value);
				_senderContact = null;
			}
		}

		/// <exclude/>
		public string SenderContactName {
			get {
				return GetTypedColumnValue<string>("SenderContactName");
			}
			set {
				SetColumnValue("SenderContactName", value);
				if (_senderContact != null) {
					_senderContact.Name = value;
				}
			}
		}

		private Contact _senderContact;
		/// <summary>
		/// Контакт отправителя.
		/// </summary>
		public Contact SenderContact {
			get {
				return _senderContact ??
					(_senderContact = LookupColumnEntities.GetEntity("SenderContact") as Contact);
			}
		}

		/// <summary>
		/// Предпросмотр.
		/// </summary>
		public string Preview {
			get {
				return GetTypedColumnValue<string>("Preview");
			}
			set {
				SetColumnValue("Preview", value);
			}
		}

		/// <exclude/>
		public Guid OwnerRoleId {
			get {
				return GetTypedColumnValue<Guid>("OwnerRoleId");
			}
			set {
				SetColumnValue("OwnerRoleId", value);
				_ownerRole = null;
			}
		}

		/// <exclude/>
		public string OwnerRoleName {
			get {
				return GetTypedColumnValue<string>("OwnerRoleName");
			}
			set {
				SetColumnValue("OwnerRoleName", value);
				if (_ownerRole != null) {
					_ownerRole.Name = value;
				}
			}
		}

		private VwSysRole _ownerRole;
		/// <summary>
		/// Роль.
		/// </summary>
		public VwSysRole OwnerRole {
			get {
				return _ownerRole ??
					(_ownerRole = LookupColumnEntities.GetEntity("OwnerRole") as VwSysRole);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Activity_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Activity_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Activity_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Activity_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Activity_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Activity_Base_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("Activity_Base_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("Activity_Base_BPMSoftValidating", e);
			DefColumnValuesSet += (s, e) => ThrowEvent("Activity_Base_BPMSoftDefColumnValuesSet", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_BaseEventsProcess

	/// <exclude/>
	public partial class Activity_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Activity_Base_BPMSoft
	{

		#region Class: SynchronizeSubjectRemindingOwnerFlowElement

		/// <exclude/>
		public class SynchronizeSubjectRemindingOwnerFlowElement : SynchronizeSubjectRemindingUserTask
		{

			public SynchronizeSubjectRemindingOwnerFlowElement(UserConnection userConnection, Activity_BaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SynchronizeSubjectRemindingOwner";
				IsLogging = false;
				SchemaElementUId = new Guid("4ebed4c4-db85-492e-ae3e-30ea37ce7801");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		#region Class: SynchronizeSubjectRemindingAuthorFlowElement

		/// <exclude/>
		public class SynchronizeSubjectRemindingAuthorFlowElement : SynchronizeSubjectRemindingUserTask
		{

			public SynchronizeSubjectRemindingAuthorFlowElement(UserConnection userConnection, Activity_BaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SynchronizeSubjectRemindingAuthor";
				IsLogging = false;
				SchemaElementUId = new Guid("4567ea18-f5a1-4ba9-aa5f-b7c4b7a1e09e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Activity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_BaseEventsProcess";
			SchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Object InsertedValues {
			get;
			set;
		}

		public virtual Object DeletedValues {
			get;
			set;
		}

		public virtual bool IsDifferentContacts {
			get;
			set;
		}

		public virtual Object RecepientsEmails {
			get;
			set;
		}

		public virtual Object CopyRecepientsEmails {
			get;
			set;
		}

		public virtual Object BlindCopyRecepientsEmails {
			get;
			set;
		}

		public virtual Object RecepientsEmailsForDelete {
			get;
			set;
		}

		public virtual Guid oldOwnerId {
			get;
			set;
		}

		public virtual Guid newOwnerId {
			get;
			set;
		}

		public virtual Guid oldContactId {
			get;
			set;
		}

		public virtual Guid newContactId {
			get;
			set;
		}

		public virtual string SenderEmail {
			get;
			set;
		}

		public virtual Guid SenderId {
			get;
			set;
		}

		public virtual bool IsNew {
			get;
			set;
		}

		public virtual bool IsNeedAutoEmailRelation {
			get;
			set;
		}

		public virtual Object EmailParticipantHelper {
			get;
			set;
		}

		public virtual bool CanGenerateAnniversaryReminding {
			get;
			set;
		}

		public virtual Object EntityChangedColumns {
			get;
			set;
		}

		private ProcessFlowElement _activitySavedSubProcess;
		public ProcessFlowElement ActivitySavedSubProcess {
			get {
				return _activitySavedSubProcess ?? (_activitySavedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivitySavedSubProcess",
					SchemaElementUId = new Guid("cec59e3a-99bd-4af7-bcab-ed936238fc72"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessageActivitySaved;
		public ProcessFlowElement StartMessageActivitySaved {
			get {
				return _startMessageActivitySaved ?? (_startMessageActivitySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessageActivitySaved",
					SchemaElementUId = new Guid("60828812-b879-4291-a03e-325b2cc89fa5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _synchronizeRemindingsIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SynchronizeRemindingsIntermediateThrowMessageEvent {
			get {
				return _synchronizeRemindingsIntermediateThrowMessageEvent ?? (_synchronizeRemindingsIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SynchronizeRemindingsIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("4e7601f9-de28-48b6-bd1f-e9c20fe849ef"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SynchronizeRemindings",
				});
			}
		}

		private ProcessScriptTask _activitySavedScriptTask;
		public ProcessScriptTask ActivitySavedScriptTask {
			get {
				return _activitySavedScriptTask ?? (_activitySavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivitySavedScriptTask",
					SchemaElementUId = new Guid("242e3956-ea08-4383-b3e4-0c5226d72265"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivitySavedScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _updateRemindings;
		public ProcessScriptTask UpdateRemindings {
			get {
				return _updateRemindings ?? (_updateRemindings = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateRemindings",
					SchemaElementUId = new Guid("7c214338-8ceb-405d-998b-154439a24622"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateRemindingsExecute,
				});
			}
		}

		private ProcessFlowElement _activitySavingSubProcess;
		public ProcessFlowElement ActivitySavingSubProcess {
			get {
				return _activitySavingSubProcess ?? (_activitySavingSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivitySavingSubProcess",
					SchemaElementUId = new Guid("3fbd2388-ab69-48d4-b802-8fe8efad9978"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activitySavingStartMessage;
		public ProcessFlowElement ActivitySavingStartMessage {
			get {
				return _activitySavingStartMessage ?? (_activitySavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivitySavingStartMessage",
					SchemaElementUId = new Guid("5444156a-a20a-4e76-a7ef-c321a7553570"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activitySavingScriptTask;
		public ProcessScriptTask ActivitySavingScriptTask {
			get {
				return _activitySavingScriptTask ?? (_activitySavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivitySavingScriptTask",
					SchemaElementUId = new Guid("7ff002e9-e185-412b-a40f-a18c71dd8be2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivitySavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _activityInsertingEventSubProcess;
		public ProcessFlowElement ActivityInsertingEventSubProcess {
			get {
				return _activityInsertingEventSubProcess ?? (_activityInsertingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivityInsertingEventSubProcess",
					SchemaElementUId = new Guid("fdc25270-216b-4cf9-bcc8-c94d500860f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityInserting;
		public ProcessFlowElement ActivityInserting {
			get {
				return _activityInserting ?? (_activityInserting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityInserting",
					SchemaElementUId = new Guid("0c5dc6d7-e051-4e24-b8f2-d0cd1dadb4fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptActivityInserting;
		public ProcessScriptTask ScriptActivityInserting {
			get {
				return _scriptActivityInserting ?? (_scriptActivityInserting = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptActivityInserting",
					SchemaElementUId = new Guid("a1ca2b05-103a-4752-a317-e8e0577c9a7e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptActivityInsertingExecute,
				});
			}
		}

		private ProcessFlowElement _activityDefColumnValuesSetEventSubProcess;
		public ProcessFlowElement ActivityDefColumnValuesSetEventSubProcess {
			get {
				return _activityDefColumnValuesSetEventSubProcess ?? (_activityDefColumnValuesSetEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivityDefColumnValuesSetEventSubProcess",
					SchemaElementUId = new Guid("635fa9cb-7360-4e6c-9ab7-d95b48a6c9ad"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityDefColumnValuesSet;
		public ProcessFlowElement ActivityDefColumnValuesSet {
			get {
				return _activityDefColumnValuesSet ?? (_activityDefColumnValuesSet = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityDefColumnValuesSet",
					SchemaElementUId = new Guid("5ef784c0-f459-416d-8a35-da718a515473"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activityDefColumnValuesSetScriptTask;
		public ProcessScriptTask ActivityDefColumnValuesSetScriptTask {
			get {
				return _activityDefColumnValuesSetScriptTask ?? (_activityDefColumnValuesSetScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityDefColumnValuesSetScriptTask",
					SchemaElementUId = new Guid("0644828a-9ba4-4328-bbbc-120722acce56"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityDefColumnValuesSetScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _activityDeletingEventSubProcess;
		public ProcessFlowElement ActivityDeletingEventSubProcess {
			get {
				return _activityDeletingEventSubProcess ?? (_activityDeletingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivityDeletingEventSubProcess",
					SchemaElementUId = new Guid("0d943db0-ee11-46b4-90c5-46a02cc28819"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityDeletingStartMessage;
		public ProcessFlowElement ActivityDeletingStartMessage {
			get {
				return _activityDeletingStartMessage ?? (_activityDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityDeletingStartMessage",
					SchemaElementUId = new Guid("cede14f1-3821-47d0-8677-059509518170"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activityDeletingScriptTask;
		public ProcessScriptTask ActivityDeletingScriptTask {
			get {
				return _activityDeletingScriptTask ?? (_activityDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityDeletingScriptTask",
					SchemaElementUId = new Guid("f9ac769f-4ad2-4537-8e36-5a552312a4f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityDeletingScriptTaskExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _synchronizeRemindingsOnDeleteIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent {
			get {
				return _synchronizeRemindingsOnDeleteIntermediateThrowMessageEvent ?? (_synchronizeRemindingsOnDeleteIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("8b15e558-03f8-4435-bdc6-57a990231738"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SynchronizeRemindings",
				});
			}
		}

		private ProcessFlowElement _remindingsSynchronizeEventSubProcess;
		public ProcessFlowElement RemindingsSynchronizeEventSubProcess {
			get {
				return _remindingsSynchronizeEventSubProcess ?? (_remindingsSynchronizeEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "RemindingsSynchronizeEventSubProcess",
					SchemaElementUId = new Guid("a0ff1647-9846-4530-9692-fda7f87ec9ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _synchronizeRemindingsStartMessage;
		public ProcessFlowElement SynchronizeRemindingsStartMessage {
			get {
				return _synchronizeRemindingsStartMessage ?? (_synchronizeRemindingsStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SynchronizeRemindingsStartMessage",
					SchemaElementUId = new Guid("6870ffad-93d9-4841-a511-07de9af2d792"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _synchronizeSubjectRemindingOwnerScript;
		public ProcessScriptTask SynchronizeSubjectRemindingOwnerScript {
			get {
				return _synchronizeSubjectRemindingOwnerScript ?? (_synchronizeSubjectRemindingOwnerScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeSubjectRemindingOwnerScript",
					SchemaElementUId = new Guid("75c05abb-9798-41e2-b0bb-09150b07ab1e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeSubjectRemindingOwnerScriptExecute,
				});
			}
		}

		private SynchronizeSubjectRemindingOwnerFlowElement _synchronizeSubjectRemindingOwner;
		public SynchronizeSubjectRemindingOwnerFlowElement SynchronizeSubjectRemindingOwner {
			get {
				return _synchronizeSubjectRemindingOwner ?? (_synchronizeSubjectRemindingOwner = new SynchronizeSubjectRemindingOwnerFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _synchronizeSubjectRemindingAuthorScript;
		public ProcessScriptTask SynchronizeSubjectRemindingAuthorScript {
			get {
				return _synchronizeSubjectRemindingAuthorScript ?? (_synchronizeSubjectRemindingAuthorScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeSubjectRemindingAuthorScript",
					SchemaElementUId = new Guid("005cc890-8c70-4098-88ec-80950340fe5a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeSubjectRemindingAuthorScriptExecute,
				});
			}
		}

		private SynchronizeSubjectRemindingAuthorFlowElement _synchronizeSubjectRemindingAuthor;
		public SynchronizeSubjectRemindingAuthorFlowElement SynchronizeSubjectRemindingAuthor {
			get {
				return _synchronizeSubjectRemindingAuthor ?? (_synchronizeSubjectRemindingAuthor = new SynchronizeSubjectRemindingAuthorFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _activityInsertedEventSubProcess;
		public ProcessFlowElement ActivityInsertedEventSubProcess {
			get {
				return _activityInsertedEventSubProcess ?? (_activityInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivityInsertedEventSubProcess",
					SchemaElementUId = new Guid("90556cbb-797c-4592-baba-c65e4c525176"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityInserted;
		public ProcessFlowElement ActivityInserted {
			get {
				return _activityInserted ?? (_activityInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityInserted",
					SchemaElementUId = new Guid("201f36e9-3509-40c4-9630-c4a30c1cff66"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptActivityInserted;
		public ProcessScriptTask ScriptActivityInserted {
			get {
				return _scriptActivityInserted ?? (_scriptActivityInserted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptActivityInserted",
					SchemaElementUId = new Guid("ba458700-4412-44e1-ae92-b324e4da2990"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptActivityInsertedExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_194a2b9eda6c440ba0883a59c753280a;
		public ProcessFlowElement EventSubProcess3_194a2b9eda6c440ba0883a59c753280a {
			get {
				return _eventSubProcess3_194a2b9eda6c440ba0883a59c753280a ?? (_eventSubProcess3_194a2b9eda6c440ba0883a59c753280a = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_194a2b9eda6c440ba0883a59c753280a",
					SchemaElementUId = new Guid("194a2b9e-da6c-440b-a088-3a59c753280a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_9d37e41aabe548ae868128ec71992033;
		public ProcessFlowElement StartMessage3_9d37e41aabe548ae868128ec71992033 {
			get {
				return _startMessage3_9d37e41aabe548ae868128ec71992033 ?? (_startMessage3_9d37e41aabe548ae868128ec71992033 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_9d37e41aabe548ae868128ec71992033",
					SchemaElementUId = new Guid("9d37e41a-abe5-48ae-8681-28ec71992033"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d;
		public ProcessScriptTask ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d {
			get {
				return _activityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d ?? (_activityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d",
					SchemaElementUId = new Guid("42f1f750-f7be-4667-b75e-eb7454a4a25d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25dExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12;
		public ProcessFlowElement EventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12 {
			get {
				return _eventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12 ?? (_eventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12",
					SchemaElementUId = new Guid("38129d2d-0520-4c70-a5d0-e36e2ead4a12"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15;
		public ProcessFlowElement StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15 {
			get {
				return _startMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15 ?? (_startMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15",
					SchemaElementUId = new Guid("fd2b53ad-8ebd-437d-bbd1-59c8f69b7f15"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_5a9e7100c80e443d9faafa3afd1b2c56;
		public ProcessScriptTask ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56 {
			get {
				return _scriptTask3_5a9e7100c80e443d9faafa3afd1b2c56 ?? (_scriptTask3_5a9e7100c80e443d9faafa3afd1b2c56 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56",
					SchemaElementUId = new Guid("5a9e7100-c80e-443d-9faa-fa3afd1b2c56"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56Execute,
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow1_91b0fd7fdfd7441c9a9c9652b3e2f653;
		public ProcessConditionalFlow ConditionalSequenceFlow1_91b0fd7fdfd7441c9a9c9652b3e2f653 {
			get {
				return _conditionalSequenceFlow1_91b0fd7fdfd7441c9a9c9652b3e2f653 ?? (_conditionalSequenceFlow1_91b0fd7fdfd7441c9a9c9652b3e2f653 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow1_91b0fd7fdfd7441c9a9c9652b3e2f653",
					SchemaElementUId = new Guid("91b0fd7f-dfd7-441c-9a9c-9652b3e2f653"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow2_a34effe2af294a52a41439c626702dc4;
		public ProcessConditionalFlow ConditionalSequenceFlow2_a34effe2af294a52a41439c626702dc4 {
			get {
				return _conditionalSequenceFlow2_a34effe2af294a52a41439c626702dc4 ?? (_conditionalSequenceFlow2_a34effe2af294a52a41439c626702dc4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow2_a34effe2af294a52a41439c626702dc4",
					SchemaElementUId = new Guid("a34effe2-af29-4a52-a414-39c626702dc4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private LocalizableString _hour;
		public LocalizableString Hour {
			get {
				return _hour ?? (_hour = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.Hour.Value"));
			}
		}

		private LocalizableString _minute;
		public LocalizableString Minute {
			get {
				return _minute ?? (_minute = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.Minute.Value"));
			}
		}

		private LocalizableString _senderEmailMoreThenOne;
		public LocalizableString SenderEmailMoreThenOne {
			get {
				return _senderEmailMoreThenOne ?? (_senderEmailMoreThenOne = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.SenderEmailMoreThenOne.Value"));
			}
		}

		private LocalizableString _ownerAndOwnerRoleAreEmptyErrorMessage;
		public LocalizableString OwnerAndOwnerRoleAreEmptyErrorMessage {
			get {
				return _ownerAndOwnerRoleAreEmptyErrorMessage ?? (_ownerAndOwnerRoleAreEmptyErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.OwnerAndOwnerRoleAreEmptyErrorMessage.Value"));
			}
		}

		private LocalizableString _ownerIsEmptyErrorMessage;
		public LocalizableString OwnerIsEmptyErrorMessage {
			get {
				return _ownerIsEmptyErrorMessage ?? (_ownerIsEmptyErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.OwnerIsEmptyErrorMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ActivitySavedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivitySavedSubProcess };
			FlowElements[StartMessageActivitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessageActivitySaved };
			FlowElements[SynchronizeRemindingsIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeRemindingsIntermediateThrowMessageEvent };
			FlowElements[ActivitySavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivitySavedScriptTask };
			FlowElements[UpdateRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateRemindings };
			FlowElements[ActivitySavingSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivitySavingSubProcess };
			FlowElements[ActivitySavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivitySavingStartMessage };
			FlowElements[ActivitySavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivitySavingScriptTask };
			FlowElements[ActivityInsertingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityInsertingEventSubProcess };
			FlowElements[ActivityInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityInserting };
			FlowElements[ScriptActivityInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptActivityInserting };
			FlowElements[ActivityDefColumnValuesSetEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityDefColumnValuesSetEventSubProcess };
			FlowElements[ActivityDefColumnValuesSet.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityDefColumnValuesSet };
			FlowElements[ActivityDefColumnValuesSetScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityDefColumnValuesSetScriptTask };
			FlowElements[ActivityDeletingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityDeletingEventSubProcess };
			FlowElements[ActivityDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityDeletingStartMessage };
			FlowElements[ActivityDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityDeletingScriptTask };
			FlowElements[SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent };
			FlowElements[RemindingsSynchronizeEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { RemindingsSynchronizeEventSubProcess };
			FlowElements[SynchronizeRemindingsStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeRemindingsStartMessage };
			FlowElements[SynchronizeSubjectRemindingOwnerScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeSubjectRemindingOwnerScript };
			FlowElements[SynchronizeSubjectRemindingOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeSubjectRemindingOwner };
			FlowElements[SynchronizeSubjectRemindingAuthorScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeSubjectRemindingAuthorScript };
			FlowElements[SynchronizeSubjectRemindingAuthor.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeSubjectRemindingAuthor };
			FlowElements[ActivityInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityInsertedEventSubProcess };
			FlowElements[ActivityInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityInserted };
			FlowElements[ScriptActivityInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptActivityInserted };
			FlowElements[EventSubProcess3_194a2b9eda6c440ba0883a59c753280a.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_194a2b9eda6c440ba0883a59c753280a };
			FlowElements[StartMessage3_9d37e41aabe548ae868128ec71992033.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_9d37e41aabe548ae868128ec71992033 };
			FlowElements[ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d };
			FlowElements[EventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12 };
			FlowElements[StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15 };
			FlowElements[ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ActivitySavedSubProcess":
						break;
					case "StartMessageActivitySaved":
						e.Context.QueueTasks.Enqueue("SynchronizeRemindingsIntermediateThrowMessageEvent");
						e.Context.QueueTasks.Enqueue("ActivitySavedScriptTask");
						e.Context.QueueTasks.Enqueue("UpdateRemindings");
						break;
					case "SynchronizeRemindingsIntermediateThrowMessageEvent":
						break;
					case "ActivitySavedScriptTask":
						break;
					case "UpdateRemindings":
						break;
					case "ActivitySavingSubProcess":
						break;
					case "ActivitySavingStartMessage":
						e.Context.QueueTasks.Enqueue("ActivitySavingScriptTask");
						break;
					case "ActivitySavingScriptTask":
						break;
					case "ActivityInsertingEventSubProcess":
						break;
					case "ActivityInserting":
						e.Context.QueueTasks.Enqueue("ScriptActivityInserting");
						break;
					case "ScriptActivityInserting":
						break;
					case "ActivityDefColumnValuesSetEventSubProcess":
						break;
					case "ActivityDefColumnValuesSet":
						e.Context.QueueTasks.Enqueue("ActivityDefColumnValuesSetScriptTask");
						break;
					case "ActivityDefColumnValuesSetScriptTask":
						break;
					case "ActivityDeletingEventSubProcess":
						break;
					case "ActivityDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("ActivityDeletingScriptTask");
						break;
					case "ActivityDeletingScriptTask":
						e.Context.QueueTasks.Enqueue("SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent");
						break;
					case "SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent":
						break;
					case "RemindingsSynchronizeEventSubProcess":
						break;
					case "SynchronizeRemindingsStartMessage":
						e.Context.QueueTasks.Enqueue("SynchronizeSubjectRemindingAuthorScript");
						e.Context.QueueTasks.Enqueue("SynchronizeSubjectRemindingOwnerScript");
						break;
					case "SynchronizeSubjectRemindingOwnerScript":
						if (ConditionalSequenceFlow1_91b0fd7fdfd7441c9a9c9652b3e2f653ExpressionExecute()) {
						e.Context.QueueTasks.Enqueue("SynchronizeSubjectRemindingOwner");
							break;
						}
						break;
					case "SynchronizeSubjectRemindingOwner":
						break;
					case "SynchronizeSubjectRemindingAuthorScript":
						if (ConditionalSequenceFlow2_a34effe2af294a52a41439c626702dc4ExpressionExecute()) {
						e.Context.QueueTasks.Enqueue("SynchronizeSubjectRemindingAuthor");
							break;
						}
						break;
					case "SynchronizeSubjectRemindingAuthor":
						break;
					case "ActivityInsertedEventSubProcess":
						break;
					case "ActivityInserted":
						e.Context.QueueTasks.Enqueue("ScriptActivityInserted");
						break;
					case "ScriptActivityInserted":
						break;
					case "EventSubProcess3_194a2b9eda6c440ba0883a59c753280a":
						break;
					case "StartMessage3_9d37e41aabe548ae868128ec71992033":
						e.Context.QueueTasks.Enqueue("ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d");
						break;
					case "ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d":
						break;
					case "EventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12":
						break;
					case "StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15":
						e.Context.QueueTasks.Enqueue("ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56");
						break;
					case "ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56":
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalSequenceFlow1_91b0fd7fdfd7441c9a9c9652b3e2f653ExpressionExecute() {
			return Convert.ToBoolean(Entity.GetTypedColumnValue<Guid>("TypeId") != ActivityConsts.EmailTypeUId);
		}

		private bool ConditionalSequenceFlow2_a34effe2af294a52a41439c626702dc4ExpressionExecute() {
			return Convert.ToBoolean(Entity.GetTypedColumnValue<Guid>("TypeId") != ActivityConsts.EmailTypeUId);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessageActivitySaved");
			ActivatedEventElements.Add("ActivitySavingStartMessage");
			ActivatedEventElements.Add("ActivityInserting");
			ActivatedEventElements.Add("ActivityDefColumnValuesSet");
			ActivatedEventElements.Add("ActivityDeletingStartMessage");
			ActivatedEventElements.Add("SynchronizeRemindingsStartMessage");
			ActivatedEventElements.Add("ActivityInserted");
			ActivatedEventElements.Add("StartMessage3_9d37e41aabe548ae868128ec71992033");
			ActivatedEventElements.Add("StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "ActivitySavedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessageActivitySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessageActivitySaved";
					result = StartMessageActivitySaved.Execute(context);
					break;
				case "SynchronizeRemindingsIntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					result = SynchronizeRemindingsIntermediateThrowMessageEvent.Execute(context);
					break;
				case "ActivitySavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivitySavedScriptTask";
					result = ActivitySavedScriptTask.Execute(context, ActivitySavedScriptTaskExecute);
					break;
				case "UpdateRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateRemindings";
					result = UpdateRemindings.Execute(context, UpdateRemindingsExecute);
					break;
				case "ActivitySavingSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivitySavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivitySavingStartMessage";
					result = ActivitySavingStartMessage.Execute(context);
					break;
				case "ActivitySavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivitySavingScriptTask";
					result = ActivitySavingScriptTask.Execute(context, ActivitySavingScriptTaskExecute);
					break;
				case "ActivityInsertingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityInserting";
					result = ActivityInserting.Execute(context);
					break;
				case "ScriptActivityInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptActivityInserting";
					result = ScriptActivityInserting.Execute(context, ScriptActivityInsertingExecute);
					break;
				case "ActivityDefColumnValuesSetEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityDefColumnValuesSet":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityDefColumnValuesSet";
					result = ActivityDefColumnValuesSet.Execute(context);
					break;
				case "ActivityDefColumnValuesSetScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityDefColumnValuesSetScriptTask";
					result = ActivityDefColumnValuesSetScriptTask.Execute(context, ActivityDefColumnValuesSetScriptTaskExecute);
					break;
				case "ActivityDeletingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityDeletingStartMessage";
					result = ActivityDeletingStartMessage.Execute(context);
					break;
				case "ActivityDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityDeletingScriptTask";
					result = ActivityDeletingScriptTask.Execute(context, ActivityDeletingScriptTaskExecute);
					break;
				case "SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					result = SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent.Execute(context);
					break;
				case "RemindingsSynchronizeEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SynchronizeRemindingsStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeRemindingsStartMessage";
					result = SynchronizeRemindingsStartMessage.Execute(context);
					break;
				case "SynchronizeSubjectRemindingOwnerScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeSubjectRemindingOwnerScript";
					result = SynchronizeSubjectRemindingOwnerScript.Execute(context, SynchronizeSubjectRemindingOwnerScriptExecute);
					break;
				case "SynchronizeSubjectRemindingOwner":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeSubjectRemindingOwner";
					result = SynchronizeSubjectRemindingOwner.Execute(context);
					break;
				case "SynchronizeSubjectRemindingAuthorScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeSubjectRemindingAuthorScript";
					result = SynchronizeSubjectRemindingAuthorScript.Execute(context, SynchronizeSubjectRemindingAuthorScriptExecute);
					break;
				case "SynchronizeSubjectRemindingAuthor":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeSubjectRemindingAuthor";
					result = SynchronizeSubjectRemindingAuthor.Execute(context);
					break;
				case "ActivityInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityInserted";
					result = ActivityInserted.Execute(context);
					break;
				case "ScriptActivityInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptActivityInserted";
					result = ScriptActivityInserted.Execute(context, ScriptActivityInsertedExecute);
					break;
				case "EventSubProcess3_194a2b9eda6c440ba0883a59c753280a":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_9d37e41aabe548ae868128ec71992033":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_9d37e41aabe548ae868128ec71992033";
					result = StartMessage3_9d37e41aabe548ae868128ec71992033.Execute(context);
					break;
				case "ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d";
					result = ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25d.Execute(context, ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25dExecute);
					break;
				case "EventSubProcess4_38129d2d05204c70a5d0e36e2ead4a12":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15";
					result = StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15.Execute(context);
					break;
				case "ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56";
					result = ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56.Execute(context, ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActivitySavedScriptTaskExecute(ProcessExecutingContext context) {
			return OnActivitySaved(context);
		}

		public virtual bool UpdateRemindingsExecute(ProcessExecutingContext context) {
			GenerateRemindings();
			return true;
		}

		public virtual bool ActivitySavingScriptTaskExecute(ProcessExecutingContext context) {
			return OnActivitySaving(context);
		}

		public virtual bool ScriptActivityInsertingExecute(ProcessExecutingContext context) {
			return OnActivityInserting(context);
		}

		public virtual bool ActivityDefColumnValuesSetScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.Schema.FindSchemaColumnByPath("StartDate") != null && 
				Entity.Schema.FindSchemaColumnByPath("DueDate") != null) {
				var startDate = Entity.GetTypedColumnValue<DateTime>("StartDate");
				if (startDate == DateTime.MinValue) {
					startDate = UserConnection.CurrentUser.GetCurrentDateTime();
					int startMinute = startDate.Minute;
					startMinute = (((startMinute / 5) + 2 * (startMinute % 5) / 5) * 5) % 60;
					var val = startDate.AddMinutes(-startDate.Minute);
					startDate = val.AddMinutes(startMinute);
					startDate = startDate.AddSeconds(-startDate.Second);
					Entity.SetColumnValue("StartDate", startDate);
					Entity.SetColumnValue("DueDate", startDate.AddMinutes(30));
				}
				var dueDate = Entity.GetTypedColumnValue<DateTime>("DueDate");
				if (dueDate == DateTime.MinValue) {
					Entity.SetColumnValue("DueDate", startDate.AddMinutes(30));
				}
			}
			return true;
		}

		public virtual bool ActivityDeletingScriptTaskExecute(ProcessExecutingContext context) {
			return ActivityDeleting(context);
		}

		public virtual bool SynchronizeSubjectRemindingOwnerScriptExecute(ProcessExecutingContext context) {
			var remindToOwner = Entity.GetTypedColumnValue<bool>("RemindToOwner");
			var owner = Entity.GetTypedColumnValue<Guid>("OwnerId");
			if (remindToOwner && (newOwnerId.IsNotEmpty() && !newOwnerId.Equals(oldOwnerId))) {
				SynchronizeSubjectRemindingOwner.IsSingleReminder = true;
			}
			var remindToOwnerDate = Entity.GetTypedColumnValue<DateTime>("RemindToOwnerDate");
			if (remindToOwnerDate == null || remindToOwnerDate.Equals(DateTime.MinValue)) {
				remindToOwnerDate = Entity.GetTypedColumnValue<DateTime>("StartDate");
			}
			PrepereSynchronizeSubjectRemindingUserTask(
				SynchronizeSubjectRemindingOwner, 
				owner, 
				remindToOwnerDate, 
				(bool)remindToOwner,
				RemindingConsts.RemindingSourceOwnerId
			);
			return true;
		}

		public virtual bool SynchronizeSubjectRemindingAuthorScriptExecute(ProcessExecutingContext context) {
			var remindToAuthor = Entity.GetTypedColumnValue<bool>("RemindToAuthor");
			var author = Entity.GetTypedColumnValue<Guid>("AuthorId");
			var remindToAuthorDate = Entity.GetTypedColumnValue<DateTime>("RemindToAuthorDate");
			if (remindToAuthorDate == null || remindToAuthorDate.Equals(DateTime.MinValue)) {
				remindToAuthorDate = Entity.GetTypedColumnValue<DateTime>("DueDate");
			}
			PrepereSynchronizeSubjectRemindingUserTask(
				SynchronizeSubjectRemindingAuthor, 
				author, 
				remindToAuthorDate, 
				(bool)remindToAuthor,
				RemindingConsts.RemindingSourceAuthorId
			);
			return true;
		}

		public virtual bool ScriptActivityInsertedExecute(ProcessExecutingContext context) {
			return OnActivityInserted(context);
		}

		public virtual bool ActivityUpdatedScriptTask_42f1f750f7be4667b75eeb7454a4a25dExecute(ProcessExecutingContext context) {
			OnActivityUpdated_aa5f074ac858455d865435cc7584e9ca(context);
			return true;
		}

		public virtual bool ScriptTask3_5a9e7100c80e443d9faafa3afd1b2c56Execute(ProcessExecutingContext context) {
			OnActivityValidating(context);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Activity_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("StartMessageActivitySaved")) {
							context.QueueTasks.Enqueue("StartMessageActivitySaved");
						}
						break;
					case "Activity_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("ActivitySavingStartMessage")) {
							context.QueueTasks.Enqueue("ActivitySavingStartMessage");
						}
						break;
					case "Activity_Base_BPMSoftInserting":
							if (ActivatedEventElements.Contains("ActivityInserting")) {
							context.QueueTasks.Enqueue("ActivityInserting");
						}
						break;
					case "Activity_Base_BPMSoftDefColumnValuesSet":
							if (ActivatedEventElements.Contains("ActivityDefColumnValuesSet")) {
							context.QueueTasks.Enqueue("ActivityDefColumnValuesSet");
						}
						break;
					case "Activity_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("ActivityDeletingStartMessage")) {
							context.QueueTasks.Enqueue("ActivityDeletingStartMessage");
						}
						break;
					case "SynchronizeRemindings":
							if (ActivatedEventElements.Contains("SynchronizeRemindingsStartMessage")) {
							context.QueueTasks.Enqueue("SynchronizeRemindingsStartMessage");
						}
						break;
					case "Activity_Base_BPMSoftInserted":
							if (ActivatedEventElements.Contains("ActivityInserted")) {
							context.QueueTasks.Enqueue("ActivityInserted");
						}
						break;
					case "Activity_Base_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("StartMessage3_9d37e41aabe548ae868128ec71992033")) {
							context.QueueTasks.Enqueue("StartMessage3_9d37e41aabe548ae868128ec71992033");
						}
						break;
					case "Activity_Base_BPMSoftValidating":
							if (ActivatedEventElements.Contains("StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15")) {
							context.QueueTasks.Enqueue("StartMessage4_fd2b53ad8ebd437dbbd159c8f69b7f15");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_BaseEventsProcess

	/// <exclude/>
	public class Activity_BaseEventsProcess : Activity_BaseEventsProcess<Activity_Base_BPMSoft>
	{

		public Activity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

