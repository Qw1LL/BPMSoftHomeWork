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

	#region Class: LeadQualificationSchema

	/// <exclude/>
	public class LeadQualificationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LeadQualificationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadQualificationSchema(LeadQualificationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadQualificationSchema(LeadQualificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			RealUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			Name = "LeadQualification";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
			IsDBView = true;
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
			if (Columns.FindByUId(new Guid("7ea2f741-2f64-42e4-9e09-66b94809b40b")) == null) {
				Columns.Add(CreateContactBusinessPhoneColumn());
			}
			if (Columns.FindByUId(new Guid("86f76e93-e58f-403d-aa6f-1ad66f2cea64")) == null) {
				Columns.Add(CreateContactMobilePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("93536b50-8c19-4a3d-8dd8-cf4cb990b197")) == null) {
				Columns.Add(CreateContactEmailColumn());
			}
			if (Columns.FindByUId(new Guid("0bac8f96-dfc6-423c-b3ad-2b332ca627c8")) == null) {
				Columns.Add(CreateAccountBusinessPhoneColumn());
			}
			if (Columns.FindByUId(new Guid("3747c438-3102-496c-afb9-bdd5d8e1897e")) == null) {
				Columns.Add(CreateAccountFaxColumn());
			}
			if (Columns.FindByUId(new Guid("7219d5a6-f4ba-4f70-96bc-3349f411f997")) == null) {
				Columns.Add(CreateAccountWebsiteColumn());
			}
			if (Columns.FindByUId(new Guid("3c501455-ac07-4ad6-9c61-3f6373adebb8")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("ee1b6f6b-db50-43b2-9812-6f6d6ef1b970")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("6af811c6-321b-48f9-93cb-b4d02fc33ee9")) == null) {
				Columns.Add(CreateGenderColumn());
			}
			if (Columns.FindByUId(new Guid("539a63aa-f994-4d59-bf52-bf329e334b98")) == null) {
				Columns.Add(CreateFullJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("c160addc-25c9-4a45-bf97-b192a65e1f9e")) == null) {
				Columns.Add(CreateLeadContactNameColumn());
			}
			if (Columns.FindByUId(new Guid("ad5e1fc8-64cf-4a3f-93b9-2c16c52dccff")) == null) {
				Columns.Add(CreateJobColumn());
			}
			if (Columns.FindByUId(new Guid("15f03c1f-ab9b-4390-94b0-4b0449eed22e")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("1690674c-06b5-4f4e-b45e-fc8c048f824f")) == null) {
				Columns.Add(CreateSalutationColumn());
			}
			if (Columns.FindByUId(new Guid("228c174e-2e73-4f0c-8722-fd6093935c3e")) == null) {
				Columns.Add(CreateDearColumn());
			}
			if (Columns.FindByUId(new Guid("e66dba0d-528d-46ab-a608-76f5dec76e94")) == null) {
				Columns.Add(CreateAnnualRevenueColumn());
			}
			if (Columns.FindByUId(new Guid("525f41ee-8445-49a5-9d80-b354df7e807f")) == null) {
				Columns.Add(CreateEmployeesNumberColumn());
			}
			if (Columns.FindByUId(new Guid("35fa4229-dfe1-45cb-be20-11cc92dbd524")) == null) {
				Columns.Add(CreateAccountCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("e5b930e6-183c-438f-be32-3e479ca92ace")) == null) {
				Columns.Add(CreateIndustryColumn());
			}
			if (Columns.FindByUId(new Guid("f40c7e1f-cce7-49c6-8f74-bc3790aa33a9")) == null) {
				Columns.Add(CreateOwnershipColumn());
			}
			if (Columns.FindByUId(new Guid("156ecd82-0ac8-423e-97bc-b904c77c70db")) == null) {
				Columns.Add(CreateLeadAccountNameColumn());
			}
			if (Columns.FindByUId(new Guid("536d3ec5-2518-4e62-a288-653f794ce873")) == null) {
				Columns.Add(CreateDecisionRoleColumn());
			}
			if (Columns.FindByUId(new Guid("4cd7638f-0a98-40d8-a352-dbb0e02e24ba")) == null) {
				Columns.Add(CreateLeadTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0049eef6-ce0b-4f05-b0c0-a907ef9e2331")) == null) {
				Columns.Add(CreateLeadTypeRipenessColumn());
			}
			if (Columns.FindByUId(new Guid("fa13e4d5-1a96-492b-9d62-82adf61d4407")) == null) {
				Columns.Add(CreateLeadContactAddressTypeColumn());
			}
			if (Columns.FindByUId(new Guid("f0824a2f-2203-4c7b-84b8-59c6c99cdeb5")) == null) {
				Columns.Add(CreateLeadContactCountryColumn());
			}
			if (Columns.FindByUId(new Guid("fb588b33-2d32-4ad7-9368-3113a406689f")) == null) {
				Columns.Add(CreateLeadContactRegionColumn());
			}
			if (Columns.FindByUId(new Guid("203f6403-8d26-43a2-8712-e6f219853a8a")) == null) {
				Columns.Add(CreateLeadContactCityColumn());
			}
			if (Columns.FindByUId(new Guid("14bde4bb-07be-4c9a-9067-ea355c7d28f9")) == null) {
				Columns.Add(CreateLeadContactZipColumn());
			}
			if (Columns.FindByUId(new Guid("39b8a183-6b9c-4d52-b8bf-9449f8c06d06")) == null) {
				Columns.Add(CreateLeadContactAddressColumn());
			}
			if (Columns.FindByUId(new Guid("e1c5c9a6-d29a-4677-9e4a-303a72e7ffc8")) == null) {
				Columns.Add(CreateLeadSourceColumn());
			}
			if (Columns.FindByUId(new Guid("92a0fed9-0be8-4b28-a4df-b233d739f938")) == null) {
				Columns.Add(CreateLeadAccountAddressTypeColumn());
			}
			if (Columns.FindByUId(new Guid("1dd3d632-e3a3-4d94-b31e-3f9b2e3db2ae")) == null) {
				Columns.Add(CreateLeadAccountCountryColumn());
			}
			if (Columns.FindByUId(new Guid("2ff370de-eceb-4221-b205-8b0cf496bed3")) == null) {
				Columns.Add(CreateLeadAccountRegionColumn());
			}
			if (Columns.FindByUId(new Guid("cf2a49d4-f276-4385-b78c-8c4ab585a223")) == null) {
				Columns.Add(CreateLeadAccountCityColumn());
			}
			if (Columns.FindByUId(new Guid("d807a758-752f-4fcc-af92-6c1b11462238")) == null) {
				Columns.Add(CreateLeadAccountZipColumn());
			}
			if (Columns.FindByUId(new Guid("fb788b38-65fb-4525-b9bc-2d8390375e8a")) == null) {
				Columns.Add(CreateLeadAccountAddressColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			column.CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			column.CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			column.CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			column.CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			column.CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			column.CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("adec4cff-676d-480a-84ae-de304b48e31e"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateContactBusinessPhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7ea2f741-2f64-42e4-9e09-66b94809b40b"),
				Name = @"ContactBusinessPhone",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateContactMobilePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("86f76e93-e58f-403d-aa6f-1ad66f2cea64"),
				Name = @"ContactMobilePhone",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateContactEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("93536b50-8c19-4a3d-8dd8-cf4cb990b197"),
				Name = @"ContactEmail",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountBusinessPhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0bac8f96-dfc6-423c-b3ad-2b332ca627c8"),
				Name = @"AccountBusinessPhone",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountFaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3747c438-3102-496c-afb9-bdd5d8e1897e"),
				Name = @"AccountFax",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountWebsiteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7219d5a6-f4ba-4f70-96bc-3349f411f997"),
				Name = @"AccountWebsite",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3c501455-ac07-4ad6-9c61-3f6373adebb8"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ee1b6f6b-db50-43b2-9812-6f6d6ef1b970"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateGenderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6af811c6-321b-48f9-93cb-b4d02fc33ee9"),
				Name = @"Gender",
				ReferenceSchemaUId = new Guid("0bc5d826-8e8f-48cd-b087-30b33d133120"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateFullJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("539a63aa-f994-4d59-bf52-bf329e334b98"),
				Name = @"FullJobTitle",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadContactNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c160addc-25c9-4a45-bf97-b192a65e1f9e"),
				Name = @"LeadContactName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateJobColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ad5e1fc8-64cf-4a3f-93b9-2c16c52dccff"),
				Name = @"Job",
				ReferenceSchemaUId = new Guid("c82ab6f0-0e36-4376-9ab3-c583d714b7b6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("15f03c1f-ab9b-4390-94b0-4b0449eed22e"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateSalutationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1690674c-06b5-4f4e-b45e-fc8c048f824f"),
				Name = @"Salutation",
				ReferenceSchemaUId = new Guid("e3c92284-1491-4438-986f-4bf5dbe4b847"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateDearColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("228c174e-2e73-4f0c-8722-fd6093935c3e"),
				Name = @"Dear",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateAnnualRevenueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e66dba0d-528d-46ab-a608-76f5dec76e94"),
				Name = @"AnnualRevenue",
				ReferenceSchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateEmployeesNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("525f41ee-8445-49a5-9d80-b354df7e807f"),
				Name = @"EmployeesNumber",
				ReferenceSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("35fa4229-dfe1-45cb-be20-11cc92dbd524"),
				Name = @"AccountCategory",
				ReferenceSchemaUId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateIndustryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e5b930e6-183c-438f-be32-3e479ca92ace"),
				Name = @"Industry",
				ReferenceSchemaUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f40c7e1f-cce7-49c6-8f74-bc3790aa33a9"),
				Name = @"Ownership",
				ReferenceSchemaUId = new Guid("ce243c2c-b7d3-4dc4-b474-ab24c677801b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadAccountNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("156ecd82-0ac8-423e-97bc-b904c77c70db"),
				Name = @"LeadAccountName",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateDecisionRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("536d3ec5-2518-4e62-a288-653f794ce873"),
				Name = @"DecisionRole",
				ReferenceSchemaUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4cd7638f-0a98-40d8-a352-dbb0e02e24ba"),
				Name = @"LeadType",
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadTypeRipenessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0049eef6-ce0b-4f05-b0c0-a907ef9e2331"),
				Name = @"LeadTypeRipeness",
				ReferenceSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadContactAddressTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fa13e4d5-1a96-492b-9d62-82adf61d4407"),
				Name = @"LeadContactAddressType",
				ReferenceSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadContactCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f0824a2f-2203-4c7b-84b8-59c6c99cdeb5"),
				Name = @"LeadContactCountry",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadContactRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb588b33-2d32-4ad7-9368-3113a406689f"),
				Name = @"LeadContactRegion",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadContactCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("203f6403-8d26-43a2-8712-e6f219853a8a"),
				Name = @"LeadContactCity",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadContactZipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("14bde4bb-07be-4c9a-9067-ea355c7d28f9"),
				Name = @"LeadContactZip",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadContactAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("39b8a183-6b9c-4d52-b8bf-9449f8c06d06"),
				Name = @"LeadContactAddress",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e1c5c9a6-d29a-4677-9e4a-303a72e7ffc8"),
				Name = @"LeadSource",
				ReferenceSchemaUId = new Guid("d3e76dcb-eb9f-494b-b5d9-0643e5418beb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadAccountAddressTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("92a0fed9-0be8-4b28-a4df-b233d739f938"),
				Name = @"LeadAccountAddressType",
				ReferenceSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadAccountCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1dd3d632-e3a3-4d94-b31e-3f9b2e3db2ae"),
				Name = @"LeadAccountCountry",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadAccountRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2ff370de-eceb-4221-b205-8b0cf496bed3"),
				Name = @"LeadAccountRegion",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadAccountCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf2a49d4-f276-4385-b78c-8c4ab585a223"),
				Name = @"LeadAccountCity",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadAccountZipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d807a758-752f-4fcc-af92-6c1b11462238"),
				Name = @"LeadAccountZip",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadAccountAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fb788b38-65fb-4525-b9bc-2d8390375e8a"),
				Name = @"LeadAccountAddress",
				CreatedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				ModifiedInSchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadQualification(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadQualification_CoreLeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadQualificationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadQualificationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3e76137e-09bc-41af-9df2-38f840e14732"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadQualification

	/// <summary>
	/// Квалифицируемый лид.
	/// </summary>
	public class LeadQualification : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LeadQualification(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadQualification";
		}

		public LeadQualification(LeadQualification source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Лид.
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
		/// Рабочий телефон.
		/// </summary>
		public string ContactBusinessPhone {
			get {
				return GetTypedColumnValue<string>("ContactBusinessPhone");
			}
			set {
				SetColumnValue("ContactBusinessPhone", value);
			}
		}

		/// <summary>
		/// Мобильный телефон.
		/// </summary>
		public string ContactMobilePhone {
			get {
				return GetTypedColumnValue<string>("ContactMobilePhone");
			}
			set {
				SetColumnValue("ContactMobilePhone", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string ContactEmail {
			get {
				return GetTypedColumnValue<string>("ContactEmail");
			}
			set {
				SetColumnValue("ContactEmail", value);
			}
		}

		/// <summary>
		/// Основной телефон.
		/// </summary>
		public string AccountBusinessPhone {
			get {
				return GetTypedColumnValue<string>("AccountBusinessPhone");
			}
			set {
				SetColumnValue("AccountBusinessPhone", value);
			}
		}

		/// <summary>
		/// Факс.
		/// </summary>
		public string AccountFax {
			get {
				return GetTypedColumnValue<string>("AccountFax");
			}
			set {
				SetColumnValue("AccountFax", value);
			}
		}

		/// <summary>
		/// Интернет.
		/// </summary>
		public string AccountWebsite {
			get {
				return GetTypedColumnValue<string>("AccountWebsite");
			}
			set {
				SetColumnValue("AccountWebsite", value);
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

		/// <summary>
		/// ФИО.
		/// </summary>
		public string LeadContactName {
			get {
				return GetTypedColumnValue<string>("LeadContactName");
			}
			set {
				SetColumnValue("LeadContactName", value);
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
		public Guid SalutationId {
			get {
				return GetTypedColumnValue<Guid>("SalutationId");
			}
			set {
				SetColumnValue("SalutationId", value);
				_salutation = null;
			}
		}

		/// <exclude/>
		public string SalutationName {
			get {
				return GetTypedColumnValue<string>("SalutationName");
			}
			set {
				SetColumnValue("SalutationName", value);
				if (_salutation != null) {
					_salutation.Name = value;
				}
			}
		}

		private ContactSalutationType _salutation;
		/// <summary>
		/// Обращение.
		/// </summary>
		public ContactSalutationType Salutation {
			get {
				return _salutation ??
					(_salutation = LookupColumnEntities.GetEntity("Salutation") as ContactSalutationType);
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
		public Guid OwnershipId {
			get {
				return GetTypedColumnValue<Guid>("OwnershipId");
			}
			set {
				SetColumnValue("OwnershipId", value);
				_ownership = null;
			}
		}

		/// <exclude/>
		public string OwnershipName {
			get {
				return GetTypedColumnValue<string>("OwnershipName");
			}
			set {
				SetColumnValue("OwnershipName", value);
				if (_ownership != null) {
					_ownership.Name = value;
				}
			}
		}

		private AccountOwnership _ownership;
		/// <summary>
		/// Форма собственности.
		/// </summary>
		public AccountOwnership Ownership {
			get {
				return _ownership ??
					(_ownership = LookupColumnEntities.GetEntity("Ownership") as AccountOwnership);
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string LeadAccountName {
			get {
				return GetTypedColumnValue<string>("LeadAccountName");
			}
			set {
				SetColumnValue("LeadAccountName", value);
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
		public Guid LeadTypeRipenessId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeRipenessId");
			}
			set {
				SetColumnValue("LeadTypeRipenessId", value);
				_leadTypeRipeness = null;
			}
		}

		/// <exclude/>
		public string LeadTypeRipenessName {
			get {
				return GetTypedColumnValue<string>("LeadTypeRipenessName");
			}
			set {
				SetColumnValue("LeadTypeRipenessName", value);
				if (_leadTypeRipeness != null) {
					_leadTypeRipeness.Name = value;
				}
			}
		}

		private LeadTypeStatus _leadTypeRipeness;
		/// <summary>
		/// Зрелость потребности.
		/// </summary>
		public LeadTypeStatus LeadTypeRipeness {
			get {
				return _leadTypeRipeness ??
					(_leadTypeRipeness = LookupColumnEntities.GetEntity("LeadTypeRipeness") as LeadTypeStatus);
			}
		}

		/// <exclude/>
		public Guid LeadContactAddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactAddressTypeId");
			}
			set {
				SetColumnValue("LeadContactAddressTypeId", value);
				_leadContactAddressType = null;
			}
		}

		/// <exclude/>
		public string LeadContactAddressTypeName {
			get {
				return GetTypedColumnValue<string>("LeadContactAddressTypeName");
			}
			set {
				SetColumnValue("LeadContactAddressTypeName", value);
				if (_leadContactAddressType != null) {
					_leadContactAddressType.Name = value;
				}
			}
		}

		private AddressType _leadContactAddressType;
		/// <summary>
		/// Тип адреса.
		/// </summary>
		public AddressType LeadContactAddressType {
			get {
				return _leadContactAddressType ??
					(_leadContactAddressType = LookupColumnEntities.GetEntity("LeadContactAddressType") as AddressType);
			}
		}

		/// <exclude/>
		public Guid LeadContactCountryId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactCountryId");
			}
			set {
				SetColumnValue("LeadContactCountryId", value);
				_leadContactCountry = null;
			}
		}

		/// <exclude/>
		public string LeadContactCountryName {
			get {
				return GetTypedColumnValue<string>("LeadContactCountryName");
			}
			set {
				SetColumnValue("LeadContactCountryName", value);
				if (_leadContactCountry != null) {
					_leadContactCountry.Name = value;
				}
			}
		}

		private Country _leadContactCountry;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country LeadContactCountry {
			get {
				return _leadContactCountry ??
					(_leadContactCountry = LookupColumnEntities.GetEntity("LeadContactCountry") as Country);
			}
		}

		/// <exclude/>
		public Guid LeadContactRegionId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactRegionId");
			}
			set {
				SetColumnValue("LeadContactRegionId", value);
				_leadContactRegion = null;
			}
		}

		/// <exclude/>
		public string LeadContactRegionName {
			get {
				return GetTypedColumnValue<string>("LeadContactRegionName");
			}
			set {
				SetColumnValue("LeadContactRegionName", value);
				if (_leadContactRegion != null) {
					_leadContactRegion.Name = value;
				}
			}
		}

		private Region _leadContactRegion;
		/// <summary>
		/// Область/штат.
		/// </summary>
		public Region LeadContactRegion {
			get {
				return _leadContactRegion ??
					(_leadContactRegion = LookupColumnEntities.GetEntity("LeadContactRegion") as Region);
			}
		}

		/// <exclude/>
		public Guid LeadContactCityId {
			get {
				return GetTypedColumnValue<Guid>("LeadContactCityId");
			}
			set {
				SetColumnValue("LeadContactCityId", value);
				_leadContactCity = null;
			}
		}

		/// <exclude/>
		public string LeadContactCityName {
			get {
				return GetTypedColumnValue<string>("LeadContactCityName");
			}
			set {
				SetColumnValue("LeadContactCityName", value);
				if (_leadContactCity != null) {
					_leadContactCity.Name = value;
				}
			}
		}

		private City _leadContactCity;
		/// <summary>
		/// Город.
		/// </summary>
		public City LeadContactCity {
			get {
				return _leadContactCity ??
					(_leadContactCity = LookupColumnEntities.GetEntity("LeadContactCity") as City);
			}
		}

		/// <summary>
		/// Индекс.
		/// </summary>
		public string LeadContactZip {
			get {
				return GetTypedColumnValue<string>("LeadContactZip");
			}
			set {
				SetColumnValue("LeadContactZip", value);
			}
		}

		/// <summary>
		/// Адрес.
		/// </summary>
		public string LeadContactAddress {
			get {
				return GetTypedColumnValue<string>("LeadContactAddress");
			}
			set {
				SetColumnValue("LeadContactAddress", value);
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

		private InformationSource _leadSource;
		/// <summary>
		/// Источник.
		/// </summary>
		public InformationSource LeadSource {
			get {
				return _leadSource ??
					(_leadSource = LookupColumnEntities.GetEntity("LeadSource") as InformationSource);
			}
		}

		/// <exclude/>
		public Guid LeadAccountAddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountAddressTypeId");
			}
			set {
				SetColumnValue("LeadAccountAddressTypeId", value);
				_leadAccountAddressType = null;
			}
		}

		/// <exclude/>
		public string LeadAccountAddressTypeName {
			get {
				return GetTypedColumnValue<string>("LeadAccountAddressTypeName");
			}
			set {
				SetColumnValue("LeadAccountAddressTypeName", value);
				if (_leadAccountAddressType != null) {
					_leadAccountAddressType.Name = value;
				}
			}
		}

		private AddressType _leadAccountAddressType;
		/// <summary>
		/// Тип адреса.
		/// </summary>
		public AddressType LeadAccountAddressType {
			get {
				return _leadAccountAddressType ??
					(_leadAccountAddressType = LookupColumnEntities.GetEntity("LeadAccountAddressType") as AddressType);
			}
		}

		/// <exclude/>
		public Guid LeadAccountCountryId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountCountryId");
			}
			set {
				SetColumnValue("LeadAccountCountryId", value);
				_leadAccountCountry = null;
			}
		}

		/// <exclude/>
		public string LeadAccountCountryName {
			get {
				return GetTypedColumnValue<string>("LeadAccountCountryName");
			}
			set {
				SetColumnValue("LeadAccountCountryName", value);
				if (_leadAccountCountry != null) {
					_leadAccountCountry.Name = value;
				}
			}
		}

		private Country _leadAccountCountry;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country LeadAccountCountry {
			get {
				return _leadAccountCountry ??
					(_leadAccountCountry = LookupColumnEntities.GetEntity("LeadAccountCountry") as Country);
			}
		}

		/// <exclude/>
		public Guid LeadAccountRegionId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountRegionId");
			}
			set {
				SetColumnValue("LeadAccountRegionId", value);
				_leadAccountRegion = null;
			}
		}

		/// <exclude/>
		public string LeadAccountRegionName {
			get {
				return GetTypedColumnValue<string>("LeadAccountRegionName");
			}
			set {
				SetColumnValue("LeadAccountRegionName", value);
				if (_leadAccountRegion != null) {
					_leadAccountRegion.Name = value;
				}
			}
		}

		private Region _leadAccountRegion;
		/// <summary>
		/// Область/штат.
		/// </summary>
		public Region LeadAccountRegion {
			get {
				return _leadAccountRegion ??
					(_leadAccountRegion = LookupColumnEntities.GetEntity("LeadAccountRegion") as Region);
			}
		}

		/// <exclude/>
		public Guid LeadAccountCityId {
			get {
				return GetTypedColumnValue<Guid>("LeadAccountCityId");
			}
			set {
				SetColumnValue("LeadAccountCityId", value);
				_leadAccountCity = null;
			}
		}

		/// <exclude/>
		public string LeadAccountCityName {
			get {
				return GetTypedColumnValue<string>("LeadAccountCityName");
			}
			set {
				SetColumnValue("LeadAccountCityName", value);
				if (_leadAccountCity != null) {
					_leadAccountCity.Name = value;
				}
			}
		}

		private City _leadAccountCity;
		/// <summary>
		/// Город.
		/// </summary>
		public City LeadAccountCity {
			get {
				return _leadAccountCity ??
					(_leadAccountCity = LookupColumnEntities.GetEntity("LeadAccountCity") as City);
			}
		}

		/// <summary>
		/// Индекс.
		/// </summary>
		public string LeadAccountZip {
			get {
				return GetTypedColumnValue<string>("LeadAccountZip");
			}
			set {
				SetColumnValue("LeadAccountZip", value);
			}
		}

		/// <summary>
		/// Адрес.
		/// </summary>
		public string LeadAccountAddress {
			get {
				return GetTypedColumnValue<string>("LeadAccountAddress");
			}
			set {
				SetColumnValue("LeadAccountAddress", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadQualification_CoreLeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadQualificationDeleted", e);
			Inserting += (s, e) => ThrowEvent("LeadQualificationInserting", e);
			Validating += (s, e) => ThrowEvent("LeadQualificationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadQualification(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadQualification_CoreLeadEventsProcess

	/// <exclude/>
	public partial class LeadQualification_CoreLeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LeadQualification
	{

		public LeadQualification_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadQualification_CoreLeadEventsProcess";
			SchemaUId = new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3e76137e-09bc-41af-9df2-38f840e14732");
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

	#region Class: LeadQualification_CoreLeadEventsProcess

	/// <exclude/>
	public class LeadQualification_CoreLeadEventsProcess : LeadQualification_CoreLeadEventsProcess<LeadQualification>
	{

		public LeadQualification_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadQualification_CoreLeadEventsProcess

	public partial class LeadQualification_CoreLeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadQualificationEventsProcess

	/// <exclude/>
	public class LeadQualificationEventsProcess : LeadQualification_CoreLeadEventsProcess
	{

		public LeadQualificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

