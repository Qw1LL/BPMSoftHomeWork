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

	#region Class: Lead_Lead_BPMSoftSchema

	/// <exclude/>
	public class Lead_Lead_BPMSoftSchema : BPMSoft.Configuration.BaseEntityNotesSchema
	{

		#region Constructors: Public

		public Lead_Lead_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Lead_Lead_BPMSoftSchema(Lead_Lead_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Lead_Lead_BPMSoftSchema(Lead_Lead_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_LeadNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("bf3f62f3-5d38-4031-a648-58b036f8f19d");
			index.Name = "IDX_LeadName";
			index.CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06");
			EntitySchemaIndexColumn leadNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2c3ed9bd-ff44-447d-b4af-c6a4e4090a5a"),
				ColumnUId = new Guid("d06ba9af-faf5-4741-a672-e154ae561a94"),
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(leadNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			RealUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			Name = "Lead_Lead_BPMSoft";
			ParentSchemaUId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateLeadNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("85e56029-bf1f-46b8-9293-a6395e7f00f9")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("865eb25f-3941-423f-a4c0-c7834368a7af")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("afdaca14-10c0-4767-b1f4-ed06946d37eb")) == null) {
				Columns.Add(CreateTitleColumn());
			}
			if (Columns.FindByUId(new Guid("4d0cc359-3e5f-481c-b8aa-117ca6b24c06")) == null) {
				Columns.Add(CreateFullJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("9ad7b70c-f7cb-4877-8186-16c8dea584fa")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("243f2974-3fa5-4b78-93e9-7fc8c1bc2749")) == null) {
				Columns.Add(CreateInformationSourceColumn());
			}
			if (Columns.FindByUId(new Guid("2edaf1d4-f64e-4351-aa6b-c81a7ebfc108")) == null) {
				Columns.Add(CreateIndustryColumn());
			}
			if (Columns.FindByUId(new Guid("718683e1-7d00-48d6-ad3f-c882ee2ce79f")) == null) {
				Columns.Add(CreateAnnualRevenueColumn());
			}
			if (Columns.FindByUId(new Guid("49508aa7-fa69-4ce3-aa4d-1eeb2c9d73a5")) == null) {
				Columns.Add(CreateEmployeesNumberColumn());
			}
			if (Columns.FindByUId(new Guid("94a3a853-08cb-485f-89f4-182878a5aaeb")) == null) {
				Columns.Add(CreateBusinesPhoneColumn());
			}
			if (Columns.FindByUId(new Guid("40fef1d9-f9d9-4246-a90f-389e256aacd4")) == null) {
				Columns.Add(CreateMobilePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("fee32d81-7e24-4a34-91c7-3083e4d4938f")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("75485248-dedd-4fa5-ace4-787e2d097627")) == null) {
				Columns.Add(CreateFaxColumn());
			}
			if (Columns.FindByUId(new Guid("e753916c-14d1-4213-bb77-9334d5e6bf7f")) == null) {
				Columns.Add(CreateWebsiteColumn());
			}
			if (Columns.FindByUId(new Guid("66852a75-b22e-4390-a8df-49814cdb0131")) == null) {
				Columns.Add(CreateAddressTypeColumn());
			}
			if (Columns.FindByUId(new Guid("d79b4d09-4791-4993-952b-e097088b55c6")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("dce30e38-3b37-40b3-b9f5-08b790d93420")) == null) {
				Columns.Add(CreateRegionColumn());
			}
			if (Columns.FindByUId(new Guid("4258b690-fe71-4b7a-8278-f0a7b9dd4780")) == null) {
				Columns.Add(CreateCityColumn());
			}
			if (Columns.FindByUId(new Guid("e1f35c38-67f2-4da3-a3f6-d4294aada246")) == null) {
				Columns.Add(CreateZipColumn());
			}
			if (Columns.FindByUId(new Guid("76b846c6-6af5-40c2-9576-5c5dbc0d6200")) == null) {
				Columns.Add(CreateAddressColumn());
			}
			if (Columns.FindByUId(new Guid("89a00df1-3d34-4a63-b34c-2978dcf7e0ae")) == null) {
				Columns.Add(CreateDoNotUseEmailColumn());
			}
			if (Columns.FindByUId(new Guid("7c2e8e89-aba1-46b1-b386-83480927dd78")) == null) {
				Columns.Add(CreateDoNotUsePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("1e8e0db1-0507-47eb-97c7-ceb789403aad")) == null) {
				Columns.Add(CreateDoNotUseFaxColumn());
			}
			if (Columns.FindByUId(new Guid("48a0c461-b224-4faf-8ede-ce36d53af43e")) == null) {
				Columns.Add(CreateDoNotUseSMSColumn());
			}
			if (Columns.FindByUId(new Guid("54067cf3-13f5-42d1-8af9-90c6bddc7773")) == null) {
				Columns.Add(CreateDoNotUseMailColumn());
			}
			if (Columns.FindByUId(new Guid("3875ae0d-ca52-4134-81df-2f67a88a3e78")) == null) {
				Columns.Add(CreateCommentaryColumn());
			}
			if (Columns.FindByUId(new Guid("ad490d58-054a-4d85-9246-dd8466eb3983")) == null) {
				Columns.Add(CreateQualifiedContactColumn());
			}
			if (Columns.FindByUId(new Guid("32949ae4-ff13-48f5-9f5d-45a74558ea55")) == null) {
				Columns.Add(CreateQualifiedAccountColumn());
			}
			if (Columns.FindByUId(new Guid("5c696704-62e8-4503-86bf-ed66c3dd63d5")) == null) {
				Columns.Add(CreateLeadTypeColumn());
			}
			if (Columns.FindByUId(new Guid("9b279c76-0213-4f51-acd6-3936e1069bd4")) == null) {
				Columns.Add(CreateLeadTypeStatusColumn());
			}
			if (Columns.FindByUId(new Guid("1970ed4a-c0ea-4d9d-97ab-68bc7ccc324a")) == null) {
				Columns.Add(CreateLeadDisqualifyReasonColumn());
			}
			if (Columns.FindByUId(new Guid("a3200694-9a9a-42a6-824f-870d5b03e255")) == null) {
				Columns.Add(CreateAccountCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("6a7045c5-ab82-4bf9-a929-9ac065c69343")) == null) {
				Columns.Add(CreateAccountOwnershipColumn());
			}
			if (Columns.FindByUId(new Guid("c7fb190e-51d8-4c65-a5db-c3714d3b0af7")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("257a1321-f45d-4868-bf44-e9f2297661d3")) == null) {
				Columns.Add(CreateGenderColumn());
			}
			if (Columns.FindByUId(new Guid("aa8c19b4-a8fb-4284-b969-8f15630a25ec")) == null) {
				Columns.Add(CreateJobColumn());
			}
			if (Columns.FindByUId(new Guid("4a577f44-6cf7-40d0-b1f8-81c2cf6539d1")) == null) {
				Columns.Add(CreateDecisionRoleColumn());
			}
			if (Columns.FindByUId(new Guid("bc0c2d60-5a3d-4840-aa4e-c60ea776e206")) == null) {
				Columns.Add(CreateQualifyStatusColumn());
			}
			if (Columns.FindByUId(new Guid("ee7282d6-232b-449f-bf7b-1bd2e1f36a58")) == null) {
				Columns.Add(CreateDearColumn());
			}
			if (Columns.FindByUId(new Guid("9fb3dc53-b29b-46e2-ba98-ae587bf61fb2")) == null) {
				Columns.Add(CreateQualificationProcessIdColumn());
			}
			if (Columns.FindByUId(new Guid("279fe3e0-79c0-4f80-ba0f-f56df245f49c")) == null) {
				Columns.Add(CreateRemindToOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("5c0fa796-b083-4126-ace9-cfddc25539a0")) == null) {
				Columns.Add(CreateSalesOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("882bf1d7-3d1f-4208-80ca-bf913c8d4f2f")) == null) {
				Columns.Add(CreateBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("efc32501-4c3a-4500-8fa4-1d70c6bf26f9")) == null) {
				Columns.Add(CreateMeetingDateColumn());
			}
			if (Columns.FindByUId(new Guid("4c3a6f1b-99d3-4baf-8954-076274d0675c")) == null) {
				Columns.Add(CreateDecisionDateColumn());
			}
			if (Columns.FindByUId(new Guid("11b61c8f-5920-4f71-8df0-d68b54efc8db")) == null) {
				Columns.Add(CreateShowDistributionPageColumn());
			}
			if (Columns.FindByUId(new Guid("087fc72c-7115-4275-965c-c100b7eabba1")) == null) {
				Columns.Add(CreateRegisterMethodColumn());
			}
			if (Columns.FindByUId(new Guid("52e9a4db-31fd-4cec-8ad5-4f07143c900c")) == null) {
				Columns.Add(CreateLeadSourceColumn());
			}
			if (Columns.FindByUId(new Guid("6af59dc9-8eda-4550-b30a-00db9126349c")) == null) {
				Columns.Add(CreateLeadMediumColumn());
			}
			if (Columns.FindByUId(new Guid("016f2995-d657-4704-a9a0-cd4deeca83b9")) == null) {
				Columns.Add(CreateNextActualizationDateColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLeadNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d06ba9af-faf5-4741-a672-e154ae561a94"),
				Name = @"LeadName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("85e56029-bf1f-46b8-9293-a6395e7f00f9"),
				Name = @"Account",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("865eb25f-3941-423f-a4c0-c7834368a7af"),
				Name = @"Contact",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("afdaca14-10c0-4767-b1f4-ed06946d37eb"),
				Name = @"Title",
				ReferenceSchemaUId = new Guid("e3c92284-1491-4438-986f-4bf5dbe4b847"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFullJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4d0cc359-3e5f-481c-b8aa-117ca6b24c06"),
				Name = @"FullJobTitle",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9ad7b70c-f7cb-4877-8186-16c8dea584fa"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateInformationSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("243f2974-3fa5-4b78-93e9-7fc8c1bc2749"),
				Name = @"InformationSource",
				ReferenceSchemaUId = new Guid("d3e76dcb-eb9f-494b-b5d9-0643e5418beb"),
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIndustryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2edaf1d4-f64e-4351-aa6b-c81a7ebfc108"),
				Name = @"Industry",
				ReferenceSchemaUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAnnualRevenueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("718683e1-7d00-48d6-ad3f-c882ee2ce79f"),
				Name = @"AnnualRevenue",
				ReferenceSchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEmployeesNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("49508aa7-fa69-4ce3-aa4d-1eeb2c9d73a5"),
				Name = @"EmployeesNumber",
				ReferenceSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBusinesPhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("94a3a853-08cb-485f-89f4-182878a5aaeb"),
				Name = @"BusinesPhone",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMobilePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("40fef1d9-f9d9-4246-a90f-389e256aacd4"),
				Name = @"MobilePhone",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fee32d81-7e24-4a34-91c7-3083e4d4938f"),
				Name = @"Email",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("75485248-dedd-4fa5-ace4-787e2d097627"),
				Name = @"Fax",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateWebsiteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e753916c-14d1-4213-bb77-9334d5e6bf7f"),
				Name = @"Website",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("66852a75-b22e-4390-a8df-49814cdb0131"),
				Name = @"AddressType",
				ReferenceSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d79b4d09-4791-4993-952b-e097088b55c6"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dce30e38-3b37-40b3-b9f5-08b790d93420"),
				Name = @"Region",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4258b690-fe71-4b7a-8278-f0a7b9dd4780"),
				Name = @"City",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateZipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("e1f35c38-67f2-4da3-a3f6-d4294aada246"),
				Name = @"Zip",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("76b846c6-6af5-40c2-9576-5c5dbc0d6200"),
				Name = @"Address",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("89a00df1-3d34-4a63-b34c-2978dcf7e0ae"),
				Name = @"DoNotUseEmail",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUsePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7c2e8e89-aba1-46b1-b386-83480927dd78"),
				Name = @"DoNotUsePhone",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseFaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1e8e0db1-0507-47eb-97c7-ceb789403aad"),
				Name = @"DoNotUseFax",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseSMSColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("48a0c461-b224-4faf-8ede-ce36d53af43e"),
				Name = @"DoNotUseSMS",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseMailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("54067cf3-13f5-42d1-8af9-90c6bddc7773"),
				Name = @"DoNotUseMail",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCommentaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3875ae0d-ca52-4134-81df-2f67a88a3e78"),
				Name = @"Commentary",
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateQualifiedContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ad490d58-054a-4d85-9246-dd8466eb3983"),
				Name = @"QualifiedContact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateQualifiedAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("32949ae4-ff13-48f5-9f5d-45a74558ea55"),
				Name = @"QualifiedAccount",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c696704-62e8-4503-86bf-ed66c3dd63d5"),
				Name = @"LeadType",
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadTypeStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9b279c76-0213-4f51-acd6-3936e1069bd4"),
				Name = @"LeadTypeStatus",
				ReferenceSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"5b3d1046-fc16-45c8-a5a1-298dfc857546"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLeadDisqualifyReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1970ed4a-c0ea-4d9d-97ab-68bc7ccc324a"),
				Name = @"LeadDisqualifyReason",
				ReferenceSchemaUId = new Guid("086904b2-10a7-4156-bb21-c23a98228ace"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3200694-9a9a-42a6-824f-870d5b03e255"),
				Name = @"AccountCategory",
				ReferenceSchemaUId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountOwnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6a7045c5-ab82-4bf9-a929-9ac065c69343"),
				Name = @"AccountOwnership",
				ReferenceSchemaUId = new Guid("ce243c2c-b7d3-4dc4-b474-ab24c677801b"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7fb190e-51d8-4c65-a5db-c3714d3b0af7"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateGenderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("257a1321-f45d-4868-bf44-e9f2297661d3"),
				Name = @"Gender",
				ReferenceSchemaUId = new Guid("0bc5d826-8e8f-48cd-b087-30b33d133120"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateJobColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("aa8c19b4-a8fb-4284-b969-8f15630a25ec"),
				Name = @"Job",
				ReferenceSchemaUId = new Guid("c82ab6f0-0e36-4376-9ab3-c583d714b7b6"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateDecisionRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4a577f44-6cf7-40d0-b1f8-81c2cf6539d1"),
				Name = @"DecisionRole",
				ReferenceSchemaUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateQualifyStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bc0c2d60-5a3d-4840-aa4e-c60ea776e206"),
				Name = @"QualifyStatus",
				ReferenceSchemaUId = new Guid("22341cd1-5b33-4c40-9011-6f7693ef6e44"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"d790a45d-03ff-4ddb-9dea-8087722c582c"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDearColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ee7282d6-232b-449f-bf7b-1bd2e1f36a58"),
				Name = @"Dear",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateQualificationProcessIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9fb3dc53-b29b-46e2-ba98-ae587bf61fb2"),
				Name = @"QualificationProcessId",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4876aa01-1104-4377-95ef-62d9f2868871")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("52817348-4c01-4015-a766-cb10c7b554c8"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindToOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("279fe3e0-79c0-4f80-ba0f-f56df245f49c"),
				Name = @"RemindToOwner",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateSalesOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c0fa796-b083-4126-ace9-cfddc25539a0"),
				Name = @"SalesOwner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("882bf1d7-3d1f-4208-80ca-bf913c8d4f2f"),
				Name = @"Budget",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateMeetingDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("efc32501-4c3a-4500-8fa4-1d70c6bf26f9"),
				Name = @"MeetingDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected virtual EntitySchemaColumn CreateDecisionDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("4c3a6f1b-99d3-4baf-8954-076274d0675c"),
				Name = @"DecisionDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("ed05a91d-cec9-4c5e-a904-603ee0a7a7cf")
			};
		}

		protected virtual EntitySchemaColumn CreateShowDistributionPageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("11b61c8f-5920-4f71-8df0-d68b54efc8db"),
				Name = @"ShowDistributionPage",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("ed05a91d-cec9-4c5e-a904-603ee0a7a7cf"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRegisterMethodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("087fc72c-7115-4275-965c-c100b7eabba1"),
				Name = @"RegisterMethod",
				ReferenceSchemaUId = new Guid("5e1ccd88-7f69-456e-af1a-915ffacb033d"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("f66d94dc-fe0c-4783-80ca-eecdef787525"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"240ab9c6-4d7c-4688-b380-af44dd147d7a"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLeadSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("52e9a4db-31fd-4cec-8ad5-4f07143c900c"),
				Name = @"LeadSource",
				ReferenceSchemaUId = new Guid("533025a5-cb29-46d5-935a-7e12616d69b6"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("f66d94dc-fe0c-4783-80ca-eecdef787525")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadMediumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6af59dc9-8eda-4550-b30a-00db9126349c"),
				Name = @"LeadMedium",
				ReferenceSchemaUId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("f66d94dc-fe0c-4783-80ca-eecdef787525")
			};
		}

		protected virtual EntitySchemaColumn CreateNextActualizationDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("016f2995-d657-4704-a9a0-cd4deeca83b9"),
				Name = @"NextActualizationDate",
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("5f03a468-0c0a-48e5-bc42-ece8f3c6faf0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_LeadNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Lead_Lead_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lead_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Lead_Lead_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Lead_Lead_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"));
		}

		#endregion

	}

	#endregion

	#region Class: Lead_Lead_BPMSoft

	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead_Lead_BPMSoft : BPMSoft.Configuration.BaseEntityNotes
	{

		#region Constructors: Public

		public Lead_Lead_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead_Lead_BPMSoft";
		}

		public Lead_Lead_BPMSoft(Lead_Lead_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Лид.
		/// </summary>
		public string LeadName {
			get {
				return GetTypedColumnValue<string>("LeadName");
			}
			set {
				SetColumnValue("LeadName", value);
			}
		}

		/// <summary>
		/// Название контрагента.
		/// </summary>
		public string Account {
			get {
				return GetTypedColumnValue<string>("Account");
			}
			set {
				SetColumnValue("Account", value);
			}
		}

		/// <summary>
		/// ФИО контакта.
		/// </summary>
		public string Contact {
			get {
				return GetTypedColumnValue<string>("Contact");
			}
			set {
				SetColumnValue("Contact", value);
			}
		}

		/// <exclude/>
		public Guid TitleId {
			get {
				return GetTypedColumnValue<Guid>("TitleId");
			}
			set {
				SetColumnValue("TitleId", value);
				_title = null;
			}
		}

		/// <exclude/>
		public string TitleName {
			get {
				return GetTypedColumnValue<string>("TitleName");
			}
			set {
				SetColumnValue("TitleName", value);
				if (_title != null) {
					_title.Name = value;
				}
			}
		}

		private ContactSalutationType _title;
		/// <summary>
		/// Обращение.
		/// </summary>
		public ContactSalutationType Title {
			get {
				return _title ??
					(_title = LookupColumnEntities.GetEntity("Title") as ContactSalutationType);
			}
		}

		/// <summary>
		/// Полное название должности.
		/// </summary>
		public string FullJobTitle {
			get {
				return GetTypedColumnValue<string>("FullJobTitle");
			}
			set {
				SetColumnValue("FullJobTitle", value);
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

		private LeadStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public LeadStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as LeadStatus);
			}
		}

		/// <exclude/>
		public Guid InformationSourceId {
			get {
				return GetTypedColumnValue<Guid>("InformationSourceId");
			}
			set {
				SetColumnValue("InformationSourceId", value);
				_informationSource = null;
			}
		}

		/// <exclude/>
		public string InformationSourceName {
			get {
				return GetTypedColumnValue<string>("InformationSourceName");
			}
			set {
				SetColumnValue("InformationSourceName", value);
				if (_informationSource != null) {
					_informationSource.Name = value;
				}
			}
		}

		private InformationSource _informationSource;
		/// <summary>
		/// Источник информации.
		/// </summary>
		public InformationSource InformationSource {
			get {
				return _informationSource ??
					(_informationSource = LookupColumnEntities.GetEntity("InformationSource") as InformationSource);
			}
		}

		/// <exclude/>
		public Guid IndustryId {
			get {
				return GetTypedColumnValue<Guid>("IndustryId");
			}
			set {
				SetColumnValue("IndustryId", value);
				_industry = null;
			}
		}

		/// <exclude/>
		public string IndustryName {
			get {
				return GetTypedColumnValue<string>("IndustryName");
			}
			set {
				SetColumnValue("IndustryName", value);
				if (_industry != null) {
					_industry.Name = value;
				}
			}
		}

		private AccountIndustry _industry;
		/// <summary>
		/// Отрасль.
		/// </summary>
		public AccountIndustry Industry {
			get {
				return _industry ??
					(_industry = LookupColumnEntities.GetEntity("Industry") as AccountIndustry);
			}
		}

		/// <exclude/>
		public Guid AnnualRevenueId {
			get {
				return GetTypedColumnValue<Guid>("AnnualRevenueId");
			}
			set {
				SetColumnValue("AnnualRevenueId", value);
				_annualRevenue = null;
			}
		}

		/// <exclude/>
		public string AnnualRevenueName {
			get {
				return GetTypedColumnValue<string>("AnnualRevenueName");
			}
			set {
				SetColumnValue("AnnualRevenueName", value);
				if (_annualRevenue != null) {
					_annualRevenue.Name = value;
				}
			}
		}

		private AccountAnnualRevenue _annualRevenue;
		/// <summary>
		/// Годовой оборот.
		/// </summary>
		public AccountAnnualRevenue AnnualRevenue {
			get {
				return _annualRevenue ??
					(_annualRevenue = LookupColumnEntities.GetEntity("AnnualRevenue") as AccountAnnualRevenue);
			}
		}

		/// <exclude/>
		public Guid EmployeesNumberId {
			get {
				return GetTypedColumnValue<Guid>("EmployeesNumberId");
			}
			set {
				SetColumnValue("EmployeesNumberId", value);
				_employeesNumber = null;
			}
		}

		/// <exclude/>
		public string EmployeesNumberName {
			get {
				return GetTypedColumnValue<string>("EmployeesNumberName");
			}
			set {
				SetColumnValue("EmployeesNumberName", value);
				if (_employeesNumber != null) {
					_employeesNumber.Name = value;
				}
			}
		}

		private AccountEmployeesNumber _employeesNumber;
		/// <summary>
		/// Количество сотрудников.
		/// </summary>
		public AccountEmployeesNumber EmployeesNumber {
			get {
				return _employeesNumber ??
					(_employeesNumber = LookupColumnEntities.GetEntity("EmployeesNumber") as AccountEmployeesNumber);
			}
		}

		/// <summary>
		/// Рабочий телефон.
		/// </summary>
		public string BusinesPhone {
			get {
				return GetTypedColumnValue<string>("BusinesPhone");
			}
			set {
				SetColumnValue("BusinesPhone", value);
			}
		}

		/// <summary>
		/// Мобильный телефон.
		/// </summary>
		public string MobilePhone {
			get {
				return GetTypedColumnValue<string>("MobilePhone");
			}
			set {
				SetColumnValue("MobilePhone", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// Факс.
		/// </summary>
		public string Fax {
			get {
				return GetTypedColumnValue<string>("Fax");
			}
			set {
				SetColumnValue("Fax", value);
			}
		}

		/// <summary>
		/// Web.
		/// </summary>
		public string Website {
			get {
				return GetTypedColumnValue<string>("Website");
			}
			set {
				SetColumnValue("Website", value);
			}
		}

		/// <exclude/>
		public Guid AddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("AddressTypeId");
			}
			set {
				SetColumnValue("AddressTypeId", value);
				_addressType = null;
			}
		}

		/// <exclude/>
		public string AddressTypeName {
			get {
				return GetTypedColumnValue<string>("AddressTypeName");
			}
			set {
				SetColumnValue("AddressTypeName", value);
				if (_addressType != null) {
					_addressType.Name = value;
				}
			}
		}

		private AddressType _addressType;
		/// <summary>
		/// Тип адреса.
		/// </summary>
		public AddressType AddressType {
			get {
				return _addressType ??
					(_addressType = LookupColumnEntities.GetEntity("AddressType") as AddressType);
			}
		}

		/// <exclude/>
		public Guid CountryId {
			get {
				return GetTypedColumnValue<Guid>("CountryId");
			}
			set {
				SetColumnValue("CountryId", value);
				_country = null;
			}
		}

		/// <exclude/>
		public string CountryName {
			get {
				return GetTypedColumnValue<string>("CountryName");
			}
			set {
				SetColumnValue("CountryName", value);
				if (_country != null) {
					_country.Name = value;
				}
			}
		}

		private Country _country;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country Country {
			get {
				return _country ??
					(_country = LookupColumnEntities.GetEntity("Country") as Country);
			}
		}

		/// <exclude/>
		public Guid RegionId {
			get {
				return GetTypedColumnValue<Guid>("RegionId");
			}
			set {
				SetColumnValue("RegionId", value);
				_region = null;
			}
		}

		/// <exclude/>
		public string RegionName {
			get {
				return GetTypedColumnValue<string>("RegionName");
			}
			set {
				SetColumnValue("RegionName", value);
				if (_region != null) {
					_region.Name = value;
				}
			}
		}

		private Region _region;
		/// <summary>
		/// Область/штат.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = LookupColumnEntities.GetEntity("Region") as Region);
			}
		}

		/// <exclude/>
		public Guid CityId {
			get {
				return GetTypedColumnValue<Guid>("CityId");
			}
			set {
				SetColumnValue("CityId", value);
				_city = null;
			}
		}

		/// <exclude/>
		public string CityName {
			get {
				return GetTypedColumnValue<string>("CityName");
			}
			set {
				SetColumnValue("CityName", value);
				if (_city != null) {
					_city.Name = value;
				}
			}
		}

		private City _city;
		/// <summary>
		/// Город.
		/// </summary>
		public City City {
			get {
				return _city ??
					(_city = LookupColumnEntities.GetEntity("City") as City);
			}
		}

		/// <summary>
		/// Индекс.
		/// </summary>
		public string Zip {
			get {
				return GetTypedColumnValue<string>("Zip");
			}
			set {
				SetColumnValue("Zip", value);
			}
		}

		/// <summary>
		/// Адрес.
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
		/// Не использовать email.
		/// </summary>
		public bool DoNotUseEmail {
			get {
				return GetTypedColumnValue<bool>("DoNotUseEmail");
			}
			set {
				SetColumnValue("DoNotUseEmail", value);
			}
		}

		/// <summary>
		/// Не использовать телефон.
		/// </summary>
		public bool DoNotUsePhone {
			get {
				return GetTypedColumnValue<bool>("DoNotUsePhone");
			}
			set {
				SetColumnValue("DoNotUsePhone", value);
			}
		}

		/// <summary>
		/// Не использовать факс.
		/// </summary>
		public bool DoNotUseFax {
			get {
				return GetTypedColumnValue<bool>("DoNotUseFax");
			}
			set {
				SetColumnValue("DoNotUseFax", value);
			}
		}

		/// <summary>
		/// Не использовать SMS.
		/// </summary>
		public bool DoNotUseSMS {
			get {
				return GetTypedColumnValue<bool>("DoNotUseSMS");
			}
			set {
				SetColumnValue("DoNotUseSMS", value);
			}
		}

		/// <summary>
		/// Не использовать почту.
		/// </summary>
		public bool DoNotUseMail {
			get {
				return GetTypedColumnValue<bool>("DoNotUseMail");
			}
			set {
				SetColumnValue("DoNotUseMail", value);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Commentary {
			get {
				return GetTypedColumnValue<string>("Commentary");
			}
			set {
				SetColumnValue("Commentary", value);
			}
		}

		/// <exclude/>
		public Guid QualifiedContactId {
			get {
				return GetTypedColumnValue<Guid>("QualifiedContactId");
			}
			set {
				SetColumnValue("QualifiedContactId", value);
				_qualifiedContact = null;
			}
		}

		/// <exclude/>
		public string QualifiedContactName {
			get {
				return GetTypedColumnValue<string>("QualifiedContactName");
			}
			set {
				SetColumnValue("QualifiedContactName", value);
				if (_qualifiedContact != null) {
					_qualifiedContact.Name = value;
				}
			}
		}

		private Contact _qualifiedContact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact QualifiedContact {
			get {
				return _qualifiedContact ??
					(_qualifiedContact = LookupColumnEntities.GetEntity("QualifiedContact") as Contact);
			}
		}

		/// <exclude/>
		public Guid QualifiedAccountId {
			get {
				return GetTypedColumnValue<Guid>("QualifiedAccountId");
			}
			set {
				SetColumnValue("QualifiedAccountId", value);
				_qualifiedAccount = null;
			}
		}

		/// <exclude/>
		public string QualifiedAccountName {
			get {
				return GetTypedColumnValue<string>("QualifiedAccountName");
			}
			set {
				SetColumnValue("QualifiedAccountName", value);
				if (_qualifiedAccount != null) {
					_qualifiedAccount.Name = value;
				}
			}
		}

		private Account _qualifiedAccount;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account QualifiedAccount {
			get {
				return _qualifiedAccount ??
					(_qualifiedAccount = LookupColumnEntities.GetEntity("QualifiedAccount") as Account);
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = LookupColumnEntities.GetEntity("LeadType") as LeadType);
			}
		}

		/// <exclude/>
		public Guid LeadTypeStatusId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeStatusId");
			}
			set {
				SetColumnValue("LeadTypeStatusId", value);
				_leadTypeStatus = null;
			}
		}

		/// <exclude/>
		public string LeadTypeStatusName {
			get {
				return GetTypedColumnValue<string>("LeadTypeStatusName");
			}
			set {
				SetColumnValue("LeadTypeStatusName", value);
				if (_leadTypeStatus != null) {
					_leadTypeStatus.Name = value;
				}
			}
		}

		private LeadTypeStatus _leadTypeStatus;
		/// <summary>
		/// Зрелость потребности.
		/// </summary>
		public LeadTypeStatus LeadTypeStatus {
			get {
				return _leadTypeStatus ??
					(_leadTypeStatus = LookupColumnEntities.GetEntity("LeadTypeStatus") as LeadTypeStatus);
			}
		}

		/// <exclude/>
		public Guid LeadDisqualifyReasonId {
			get {
				return GetTypedColumnValue<Guid>("LeadDisqualifyReasonId");
			}
			set {
				SetColumnValue("LeadDisqualifyReasonId", value);
				_leadDisqualifyReason = null;
			}
		}

		/// <exclude/>
		public string LeadDisqualifyReasonName {
			get {
				return GetTypedColumnValue<string>("LeadDisqualifyReasonName");
			}
			set {
				SetColumnValue("LeadDisqualifyReasonName", value);
				if (_leadDisqualifyReason != null) {
					_leadDisqualifyReason.Name = value;
				}
			}
		}

		private LeadDisqualifyReason _leadDisqualifyReason;
		/// <summary>
		/// Причина дисквалификации.
		/// </summary>
		public LeadDisqualifyReason LeadDisqualifyReason {
			get {
				return _leadDisqualifyReason ??
					(_leadDisqualifyReason = LookupColumnEntities.GetEntity("LeadDisqualifyReason") as LeadDisqualifyReason);
			}
		}

		/// <exclude/>
		public Guid AccountCategoryId {
			get {
				return GetTypedColumnValue<Guid>("AccountCategoryId");
			}
			set {
				SetColumnValue("AccountCategoryId", value);
				_accountCategory = null;
			}
		}

		/// <exclude/>
		public string AccountCategoryName {
			get {
				return GetTypedColumnValue<string>("AccountCategoryName");
			}
			set {
				SetColumnValue("AccountCategoryName", value);
				if (_accountCategory != null) {
					_accountCategory.Name = value;
				}
			}
		}

		private AccountCategory _accountCategory;
		/// <summary>
		/// Категория.
		/// </summary>
		public AccountCategory AccountCategory {
			get {
				return _accountCategory ??
					(_accountCategory = LookupColumnEntities.GetEntity("AccountCategory") as AccountCategory);
			}
		}

		/// <exclude/>
		public Guid AccountOwnershipId {
			get {
				return GetTypedColumnValue<Guid>("AccountOwnershipId");
			}
			set {
				SetColumnValue("AccountOwnershipId", value);
				_accountOwnership = null;
			}
		}

		/// <exclude/>
		public string AccountOwnershipName {
			get {
				return GetTypedColumnValue<string>("AccountOwnershipName");
			}
			set {
				SetColumnValue("AccountOwnershipName", value);
				if (_accountOwnership != null) {
					_accountOwnership.Name = value;
				}
			}
		}

		private AccountOwnership _accountOwnership;
		/// <summary>
		/// Форма собственности.
		/// </summary>
		public AccountOwnership AccountOwnership {
			get {
				return _accountOwnership ??
					(_accountOwnership = LookupColumnEntities.GetEntity("AccountOwnership") as AccountOwnership);
			}
		}

		/// <exclude/>
		public Guid DepartmentId {
			get {
				return GetTypedColumnValue<Guid>("DepartmentId");
			}
			set {
				SetColumnValue("DepartmentId", value);
				_department = null;
			}
		}

		/// <exclude/>
		public string DepartmentName {
			get {
				return GetTypedColumnValue<string>("DepartmentName");
			}
			set {
				SetColumnValue("DepartmentName", value);
				if (_department != null) {
					_department.Name = value;
				}
			}
		}

		private Department _department;
		/// <summary>
		/// Департамент.
		/// </summary>
		public Department Department {
			get {
				return _department ??
					(_department = LookupColumnEntities.GetEntity("Department") as Department);
			}
		}

		/// <exclude/>
		public Guid GenderId {
			get {
				return GetTypedColumnValue<Guid>("GenderId");
			}
			set {
				SetColumnValue("GenderId", value);
				_gender = null;
			}
		}

		/// <exclude/>
		public string GenderName {
			get {
				return GetTypedColumnValue<string>("GenderName");
			}
			set {
				SetColumnValue("GenderName", value);
				if (_gender != null) {
					_gender.Name = value;
				}
			}
		}

		private Gender _gender;
		/// <summary>
		/// Пол.
		/// </summary>
		public Gender Gender {
			get {
				return _gender ??
					(_gender = LookupColumnEntities.GetEntity("Gender") as Gender);
			}
		}

		/// <exclude/>
		public Guid JobId {
			get {
				return GetTypedColumnValue<Guid>("JobId");
			}
			set {
				SetColumnValue("JobId", value);
				_job = null;
			}
		}

		/// <exclude/>
		public string JobName {
			get {
				return GetTypedColumnValue<string>("JobName");
			}
			set {
				SetColumnValue("JobName", value);
				if (_job != null) {
					_job.Name = value;
				}
			}
		}

		private Job _job;
		/// <summary>
		/// Должность.
		/// </summary>
		public Job Job {
			get {
				return _job ??
					(_job = LookupColumnEntities.GetEntity("Job") as Job);
			}
		}

		/// <exclude/>
		public Guid DecisionRoleId {
			get {
				return GetTypedColumnValue<Guid>("DecisionRoleId");
			}
			set {
				SetColumnValue("DecisionRoleId", value);
				_decisionRole = null;
			}
		}

		/// <exclude/>
		public string DecisionRoleName {
			get {
				return GetTypedColumnValue<string>("DecisionRoleName");
			}
			set {
				SetColumnValue("DecisionRoleName", value);
				if (_decisionRole != null) {
					_decisionRole.Name = value;
				}
			}
		}

		private ContactDecisionRole _decisionRole;
		/// <summary>
		/// Роль.
		/// </summary>
		public ContactDecisionRole DecisionRole {
			get {
				return _decisionRole ??
					(_decisionRole = LookupColumnEntities.GetEntity("DecisionRole") as ContactDecisionRole);
			}
		}

		/// <exclude/>
		public Guid QualifyStatusId {
			get {
				return GetTypedColumnValue<Guid>("QualifyStatusId");
			}
			set {
				SetColumnValue("QualifyStatusId", value);
				_qualifyStatus = null;
			}
		}

		/// <exclude/>
		public string QualifyStatusName {
			get {
				return GetTypedColumnValue<string>("QualifyStatusName");
			}
			set {
				SetColumnValue("QualifyStatusName", value);
				if (_qualifyStatus != null) {
					_qualifyStatus.Name = value;
				}
			}
		}

		private QualifyStatus _qualifyStatus;
		/// <summary>
		/// Стадия лида.
		/// </summary>
		public QualifyStatus QualifyStatus {
			get {
				return _qualifyStatus ??
					(_qualifyStatus = LookupColumnEntities.GetEntity("QualifyStatus") as QualifyStatus);
			}
		}

		/// <summary>
		/// Приветствие.
		/// </summary>
		public string Dear {
			get {
				return GetTypedColumnValue<string>("Dear");
			}
			set {
				SetColumnValue("Dear", value);
			}
		}

		/// <summary>
		/// QualificationProcessId.
		/// </summary>
		/// <remarks>
		/// Идентификатор в таблице SysProcessData.
		/// </remarks>
		public Guid QualificationProcessId {
			get {
				return GetTypedColumnValue<Guid>("QualificationProcessId");
			}
			set {
				SetColumnValue("QualificationProcessId", value);
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
		/// Напоминание ответственному.
		/// </summary>
		public bool RemindToOwner {
			get {
				return GetTypedColumnValue<bool>("RemindToOwner");
			}
			set {
				SetColumnValue("RemindToOwner", value);
			}
		}

		/// <exclude/>
		public Guid SalesOwnerId {
			get {
				return GetTypedColumnValue<Guid>("SalesOwnerId");
			}
			set {
				SetColumnValue("SalesOwnerId", value);
				_salesOwner = null;
			}
		}

		/// <exclude/>
		public string SalesOwnerName {
			get {
				return GetTypedColumnValue<string>("SalesOwnerName");
			}
			set {
				SetColumnValue("SalesOwnerName", value);
				if (_salesOwner != null) {
					_salesOwner.Name = value;
				}
			}
		}

		private Contact _salesOwner;
		/// <summary>
		/// Ответственный за продажу.
		/// </summary>
		public Contact SalesOwner {
			get {
				return _salesOwner ??
					(_salesOwner = LookupColumnEntities.GetEntity("SalesOwner") as Contact);
			}
		}

		/// <summary>
		/// Бюджет.
		/// </summary>
		public Decimal Budget {
			get {
				return GetTypedColumnValue<Decimal>("Budget");
			}
			set {
				SetColumnValue("Budget", value);
			}
		}

		/// <summary>
		/// Дата и время встречи.
		/// </summary>
		public DateTime MeetingDate {
			get {
				return GetTypedColumnValue<DateTime>("MeetingDate");
			}
			set {
				SetColumnValue("MeetingDate", value);
			}
		}

		/// <summary>
		/// Дата принятия решения.
		/// </summary>
		public DateTime DecisionDate {
			get {
				return GetTypedColumnValue<DateTime>("DecisionDate");
			}
			set {
				SetColumnValue("DecisionDate", value);
			}
		}

		/// <summary>
		/// Отображать страницу распределения.
		/// </summary>
		public bool ShowDistributionPage {
			get {
				return GetTypedColumnValue<bool>("ShowDistributionPage");
			}
			set {
				SetColumnValue("ShowDistributionPage", value);
			}
		}

		/// <exclude/>
		public Guid RegisterMethodId {
			get {
				return GetTypedColumnValue<Guid>("RegisterMethodId");
			}
			set {
				SetColumnValue("RegisterMethodId", value);
				_registerMethod = null;
			}
		}

		/// <exclude/>
		public string RegisterMethodName {
			get {
				return GetTypedColumnValue<string>("RegisterMethodName");
			}
			set {
				SetColumnValue("RegisterMethodName", value);
				if (_registerMethod != null) {
					_registerMethod.Name = value;
				}
			}
		}

		private LeadRegisterMethod _registerMethod;
		/// <summary>
		/// Как зарегистрирован.
		/// </summary>
		public LeadRegisterMethod RegisterMethod {
			get {
				return _registerMethod ??
					(_registerMethod = LookupColumnEntities.GetEntity("RegisterMethod") as LeadRegisterMethod);
			}
		}

		/// <exclude/>
		public Guid LeadSourceId {
			get {
				return GetTypedColumnValue<Guid>("LeadSourceId");
			}
			set {
				SetColumnValue("LeadSourceId", value);
				_leadSource = null;
			}
		}

		/// <exclude/>
		public string LeadSourceName {
			get {
				return GetTypedColumnValue<string>("LeadSourceName");
			}
			set {
				SetColumnValue("LeadSourceName", value);
				if (_leadSource != null) {
					_leadSource.Name = value;
				}
			}
		}

		private LeadSource _leadSource;
		/// <summary>
		/// Источник.
		/// </summary>
		public LeadSource LeadSource {
			get {
				return _leadSource ??
					(_leadSource = LookupColumnEntities.GetEntity("LeadSource") as LeadSource);
			}
		}

		/// <exclude/>
		public Guid LeadMediumId {
			get {
				return GetTypedColumnValue<Guid>("LeadMediumId");
			}
			set {
				SetColumnValue("LeadMediumId", value);
				_leadMedium = null;
			}
		}

		/// <exclude/>
		public string LeadMediumName {
			get {
				return GetTypedColumnValue<string>("LeadMediumName");
			}
			set {
				SetColumnValue("LeadMediumName", value);
				if (_leadMedium != null) {
					_leadMedium.Name = value;
				}
			}
		}

		private LeadMedium _leadMedium;
		/// <summary>
		/// Канал.
		/// </summary>
		public LeadMedium LeadMedium {
			get {
				return _leadMedium ??
					(_leadMedium = LookupColumnEntities.GetEntity("LeadMedium") as LeadMedium);
			}
		}

		/// <summary>
		/// Дата следующей актуализации.
		/// </summary>
		public DateTime NextActualizationDate {
			get {
				return GetTypedColumnValue<DateTime>("NextActualizationDate");
			}
			set {
				SetColumnValue("NextActualizationDate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Lead_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Lead_Lead_BPMSoftDeleted", e);
			Inserted += (s, e) => ThrowEvent("Lead_Lead_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Lead_Lead_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Lead_Lead_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Lead_Lead_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Lead_Lead_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Lead_Lead_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_LeadEventsProcess

	/// <exclude/>
	public partial class Lead_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityNotes_BaseEventsProcess<TEntity> where TEntity : Lead_Lead_BPMSoft
	{

		public Lead_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lead_LeadEventsProcess";
			SchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcessEntitySaved;
		public ProcessFlowElement EventSubProcessEntitySaved {
			get {
				return _eventSubProcessEntitySaved ?? (_eventSubProcessEntitySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcessEntitySaved",
					SchemaElementUId = new Guid("3b7aac10-edc6-4ef5-814b-f6205547608c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskEntitySaved;
		public ProcessScriptTask ScriptTaskEntitySaved {
			get {
				return _scriptTaskEntitySaved ?? (_scriptTaskEntitySaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskEntitySaved",
					SchemaElementUId = new Guid("468a31ce-cf2f-46d1-b7f4-67f6e0e305bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskEntitySavedExecute,
				});
			}
		}

		private ProcessFlowElement _leadSavedStartMessage143234;
		public ProcessFlowElement LeadSavedStartMessage143234 {
			get {
				return _leadSavedStartMessage143234 ?? (_leadSavedStartMessage143234 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "LeadSavedStartMessage143234",
					SchemaElementUId = new Guid("acd9b402-0c00-4029-95db-78b38fadeab2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _eventSubProcessEntitySaving;
		public ProcessFlowElement EventSubProcessEntitySaving {
			get {
				return _eventSubProcessEntitySaving ?? (_eventSubProcessEntitySaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcessEntitySaving",
					SchemaElementUId = new Guid("696e5b6c-925d-4079-9e97-3d9a9c2c4893"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _leadSaving;
		public ProcessFlowElement LeadSaving {
			get {
				return _leadSaving ?? (_leadSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "LeadSaving",
					SchemaElementUId = new Guid("a5be23f0-4ce9-4a02-be35-d3c4705181e6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskLeadSaving;
		public ProcessScriptTask ScriptTaskLeadSaving {
			get {
				return _scriptTaskLeadSaving ?? (_scriptTaskLeadSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskLeadSaving",
					SchemaElementUId = new Guid("eea25304-53e9-46c1-af58-db71a9f72427"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskLeadSavingExecute,
				});
			}
		}

		private ProcessFlowElement _afterInsertEventSubProcess;
		public ProcessFlowElement AfterInsertEventSubProcess {
			get {
				return _afterInsertEventSubProcess ?? (_afterInsertEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "AfterInsertEventSubProcess",
					SchemaElementUId = new Guid("40ffaf7b-cec3-4fc9-a544-655ba4ce3a1b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _leadInsertedStartMessage;
		public ProcessFlowElement LeadInsertedStartMessage {
			get {
				return _leadInsertedStartMessage ?? (_leadInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "LeadInsertedStartMessage",
					SchemaElementUId = new Guid("8965ab88-ffc4-48e2-afdb-ae1ab27d912c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _leadInsertedScriptTask;
		public ProcessScriptTask LeadInsertedScriptTask {
			get {
				return _leadInsertedScriptTask ?? (_leadInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LeadInsertedScriptTask",
					SchemaElementUId = new Guid("1621a8eb-06b7-4f72-90f1-85067347437f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LeadInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _leadInsertingEventSubProcess;
		public ProcessFlowElement LeadInsertingEventSubProcess {
			get {
				return _leadInsertingEventSubProcess ?? (_leadInsertingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "LeadInsertingEventSubProcess",
					SchemaElementUId = new Guid("7c990a6c-def3-4036-abeb-f6cc737d00b9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _leadInsertingStartMessage;
		public ProcessFlowElement LeadInsertingStartMessage {
			get {
				return _leadInsertingStartMessage ?? (_leadInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "LeadInsertingStartMessage",
					SchemaElementUId = new Guid("be085075-e867-48a5-9bc0-2449f344db96"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _leadInsertingScriptTask;
		public ProcessScriptTask LeadInsertingScriptTask {
			get {
				return _leadInsertingScriptTask ?? (_leadInsertingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LeadInsertingScriptTask",
					SchemaElementUId = new Guid("8a93c014-a0f6-4cfe-9bd1-e09888ed7ead"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LeadInsertingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcessEntitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcessEntitySaved };
			FlowElements[ScriptTaskEntitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskEntitySaved };
			FlowElements[LeadSavedStartMessage143234.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadSavedStartMessage143234 };
			FlowElements[EventSubProcessEntitySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcessEntitySaving };
			FlowElements[LeadSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadSaving };
			FlowElements[ScriptTaskLeadSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskLeadSaving };
			FlowElements[AfterInsertEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { AfterInsertEventSubProcess };
			FlowElements[LeadInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadInsertedStartMessage };
			FlowElements[LeadInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadInsertedScriptTask };
			FlowElements[LeadInsertingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadInsertingEventSubProcess };
			FlowElements[LeadInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadInsertingStartMessage };
			FlowElements[LeadInsertingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LeadInsertingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcessEntitySaved":
						break;
					case "ScriptTaskEntitySaved":
						break;
					case "LeadSavedStartMessage143234":
						e.Context.QueueTasks.Enqueue("ScriptTaskEntitySaved");
						break;
					case "EventSubProcessEntitySaving":
						break;
					case "LeadSaving":
						e.Context.QueueTasks.Enqueue("ScriptTaskLeadSaving");
						break;
					case "ScriptTaskLeadSaving":
						break;
					case "AfterInsertEventSubProcess":
						break;
					case "LeadInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("LeadInsertedScriptTask");
						break;
					case "LeadInsertedScriptTask":
						break;
					case "LeadInsertingEventSubProcess":
						break;
					case "LeadInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("LeadInsertingScriptTask");
						break;
					case "LeadInsertingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("LeadSavedStartMessage143234");
			ActivatedEventElements.Add("LeadSaving");
			ActivatedEventElements.Add("LeadInsertedStartMessage");
			ActivatedEventElements.Add("LeadInsertingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcessEntitySaved":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptTaskEntitySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskEntitySaved";
					result = ScriptTaskEntitySaved.Execute(context, ScriptTaskEntitySavedExecute);
					break;
				case "LeadSavedStartMessage143234":
					context.QueueTasks.Dequeue();
					context.SenderName = "LeadSavedStartMessage143234";
					result = LeadSavedStartMessage143234.Execute(context);
					break;
				case "EventSubProcessEntitySaving":
					context.QueueTasks.Dequeue();
					break;
				case "LeadSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "LeadSaving";
					result = LeadSaving.Execute(context);
					break;
				case "ScriptTaskLeadSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskLeadSaving";
					result = ScriptTaskLeadSaving.Execute(context, ScriptTaskLeadSavingExecute);
					break;
				case "AfterInsertEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "LeadInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "LeadInsertedStartMessage";
					result = LeadInsertedStartMessage.Execute(context);
					break;
				case "LeadInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LeadInsertedScriptTask";
					result = LeadInsertedScriptTask.Execute(context, LeadInsertedScriptTaskExecute);
					break;
				case "LeadInsertingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "LeadInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "LeadInsertingStartMessage";
					result = LeadInsertingStartMessage.Execute(context);
					break;
				case "LeadInsertingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LeadInsertingScriptTask";
					result = LeadInsertingScriptTask.Execute(context, LeadInsertingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTaskEntitySavedExecute(ProcessExecutingContext context) {
			LeadSaved();
			return true;
		}

		public virtual bool ScriptTaskLeadSavingExecute(ProcessExecutingContext context) {
			LeadSavingMethod();
			return true;
		}

		public virtual bool LeadInsertedScriptTaskExecute(ProcessExecutingContext context) {
			LeadInserted();
			return true;
		}

		public virtual bool LeadInsertingScriptTaskExecute(ProcessExecutingContext context) {
			LeadInserting();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Lead_Lead_BPMSoftSaved":
							if (ActivatedEventElements.Contains("LeadSavedStartMessage143234")) {
							context.QueueTasks.Enqueue("LeadSavedStartMessage143234");
						}
						break;
					case "Lead_Lead_BPMSoftSaving":
							if (ActivatedEventElements.Contains("LeadSaving")) {
							context.QueueTasks.Enqueue("LeadSaving");
						}
						break;
					case "Lead_Lead_BPMSoftInserted":
							if (ActivatedEventElements.Contains("LeadInsertedStartMessage")) {
							context.QueueTasks.Enqueue("LeadInsertedStartMessage");
						}
						break;
					case "Lead_Lead_BPMSoftInserting":
							if (ActivatedEventElements.Contains("LeadInsertingStartMessage")) {
							context.QueueTasks.Enqueue("LeadInsertingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_LeadEventsProcess

	/// <exclude/>
	public class Lead_LeadEventsProcess : Lead_LeadEventsProcess<Lead_Lead_BPMSoft>
	{

		public Lead_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

