namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.EntitySynchronization;
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

	#region Class: Contact_Base_BPMSoftSchema

	/// <exclude/>
	public class Contact_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Contact_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_Base_BPMSoftSchema(Contact_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_Base_BPMSoftSchema(Contact_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			RealUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			Name = "Contact_Base_BPMSoft";
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

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreatePhotoColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
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
			if (Columns.FindByUId(new Guid("c5d7c4d3-f308-40d3-8469-6ab6882bd70a")) == null) {
				Columns.Add(CreateDearColumn());
			}
			if (Columns.FindByUId(new Guid("f16cbd03-a8a8-4bdd-9970-a0c7985a1996")) == null) {
				Columns.Add(CreateSalutationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("3a3317c0-09f6-4a26-998b-018d1caa2c36")) == null) {
				Columns.Add(CreateGenderColumn());
			}
			if (Columns.FindByUId(new Guid("5c6ca10e-1180-4c1e-8a50-55a72ff9bdd4")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("f70c762a-1038-49a7-a3e8-f24fb8cfdeef")) == null) {
				Columns.Add(CreateDecisionRoleColumn());
			}
			if (Columns.FindByUId(new Guid("a49571cc-a9a9-4c3e-a346-46c466e9a0d3")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("344436e4-9d6b-4a30-936f-f8ea45f2adb4")) == null) {
				Columns.Add(CreateJobColumn());
			}
			if (Columns.FindByUId(new Guid("8b680ac7-e46c-466c-b630-e5cb4da13a55")) == null) {
				Columns.Add(CreateJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("94cb8750-ad6f-4e80-b553-7d9e194a856e")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("3f08db69-6d2f-4b1c-87a4-acddc6c3b9d6")) == null) {
				Columns.Add(CreateBirthDateColumn());
			}
			if (Columns.FindByUId(new Guid("84c5808a-7859-4198-ba6a-243c95a3300b")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("98e085c7-ad4d-4ac6-8c1c-09be09876d44")) == null) {
				Columns.Add(CreateMobilePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("0a455b85-133c-4944-aff1-2ce7f7e50fee")) == null) {
				Columns.Add(CreateHomePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("5ff9516e-251c-41de-a085-67fa199cdfe7")) == null) {
				Columns.Add(CreateSkypeColumn());
			}
			if (Columns.FindByUId(new Guid("dbf202ec-c444-479b-bcf4-d8e5b1863201")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("5ad029c6-0fa7-4db6-8fef-c72a0f535682")) == null) {
				Columns.Add(CreateAddressTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0fb61bc8-a195-4d90-aecc-18b411b51814")) == null) {
				Columns.Add(CreateAddressColumn());
			}
			if (Columns.FindByUId(new Guid("cf58ca72-531b-4dd2-b4d5-f0d5b7c556f6")) == null) {
				Columns.Add(CreateCityColumn());
			}
			if (Columns.FindByUId(new Guid("0e50f221-470e-482b-8580-f61c74b8b1c1")) == null) {
				Columns.Add(CreateRegionColumn());
			}
			if (Columns.FindByUId(new Guid("0737d99d-eebc-4b8e-9859-634414f7cc04")) == null) {
				Columns.Add(CreateZipColumn());
			}
			if (Columns.FindByUId(new Guid("9463dea9-2576-4d37-812f-342ee57ddf32")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("1b1d8f33-4d26-4353-a1ed-07e11fc82112")) == null) {
				Columns.Add(CreateDoNotUseEmailColumn());
			}
			if (Columns.FindByUId(new Guid("a6bcf6fe-a06d-42ed-a263-f829ece05fd9")) == null) {
				Columns.Add(CreateDoNotUseCallColumn());
			}
			if (Columns.FindByUId(new Guid("d9deaed5-8e42-40c0-9bb1-a6bfe6716ca4")) == null) {
				Columns.Add(CreateDoNotUseFaxColumn());
			}
			if (Columns.FindByUId(new Guid("7e295464-4dee-4448-832c-97434b1f2943")) == null) {
				Columns.Add(CreateDoNotUseSmsColumn());
			}
			if (Columns.FindByUId(new Guid("238d9e74-ff12-4e40-8467-350bd9d4b58d")) == null) {
				Columns.Add(CreateDoNotUseMailColumn());
			}
			if (Columns.FindByUId(new Guid("fd73da4b-2b3d-483e-89d2-383a6db099ac")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("327e44bd-0b97-48c0-b11a-4686d6605b4f")) == null) {
				Columns.Add(CreateContactPhotoColumn());
			}
			if (Columns.FindByUId(new Guid("b903e71d-74cd-4b79-9dd9-d0c84ef6ad44")) == null) {
				Columns.Add(CreateGPSNColumn());
			}
			if (Columns.FindByUId(new Guid("b9021fa0-6606-4027-8335-bf0624b58218")) == null) {
				Columns.Add(CreateGPSEColumn());
			}
			if (Columns.FindByUId(new Guid("771a60e2-020c-4dd2-8512-b428b8a47dba")) == null) {
				Columns.Add(CreateSurnameColumn());
			}
			if (Columns.FindByUId(new Guid("cc26b1c5-4254-4287-9c15-0b5acd319811")) == null) {
				Columns.Add(CreateGivenNameColumn());
			}
			if (Columns.FindByUId(new Guid("33a879a3-d466-4b3f-b529-377a69ff0819")) == null) {
				Columns.Add(CreateMiddleNameColumn());
			}
			if (Columns.FindByUId(new Guid("ced280cc-7423-4175-9896-ea592a9e81a6")) == null) {
				Columns.Add(CreateConfirmedColumn());
			}
			if (Columns.FindByUId(new Guid("a855b7ae-45be-4d73-9074-9d84e4ae66c4")) == null) {
				Columns.Add(CreateLanguageColumn());
			}
			if (Columns.FindByUId(new Guid("bcdc7a32-4332-4caf-858d-0078b56856fe")) == null) {
				Columns.Add(CreateAgeColumn());
			}
			if (Columns.FindByUId(new Guid("f963730e-7256-f35d-03ff-ba60a1d641d7")) == null) {
				Columns.Add(CreateIsEmailConfirmedColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a5cca792-47dd-428a-83fb-5c92bdd97ff8"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("64fa90dd-0cf5-45d7-88e4-6fa691d3c425"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDearColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c5d7c4d3-f308-40d3-8469-6ab6882bd70a"),
				Name = @"Dear",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSalutationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f16cbd03-a8a8-4bdd-9970-a0c7985a1996"),
				Name = @"SalutationType",
				ReferenceSchemaUId = new Guid("e3c92284-1491-4438-986f-4bf5dbe4b847"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateGenderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3a3317c0-09f6-4a26-998b-018d1caa2c36"),
				Name = @"Gender",
				ReferenceSchemaUId = new Guid("0bc5d826-8e8f-48cd-b087-30b33d133120"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c6ca10e-1180-4c1e-8a50-55a72ff9bdd4"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDecisionRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f70c762a-1038-49a7-a3e8-f24fb8cfdeef"),
				Name = @"DecisionRole",
				ReferenceSchemaUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a49571cc-a9a9-4c3e-a346-46c466e9a0d3"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateJobColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("344436e4-9d6b-4a30-936f-f8ea45f2adb4"),
				Name = @"Job",
				ReferenceSchemaUId = new Guid("c82ab6f0-0e36-4376-9ab3-c583d714b7b6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8b680ac7-e46c-466c-b630-e5cb4da13a55"),
				Name = @"JobTitle",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("94cb8750-ad6f-4e80-b553-7d9e194a856e"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBirthDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("3f08db69-6d2f-4b1c-87a4-acddc6c3b9d6"),
				Name = @"BirthDate",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("84c5808a-7859-4198-ba6a-243c95a3300b"),
				Name = @"Phone",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMobilePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("98e085c7-ad4d-4ac6-8c1c-09be09876d44"),
				Name = @"MobilePhone",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHomePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0a455b85-133c-4944-aff1-2ce7f7e50fee"),
				Name = @"HomePhone",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSkypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5ff9516e-251c-41de-a085-67fa199cdfe7"),
				Name = @"Skype",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("dbf202ec-c444-479b-bcf4-d8e5b1863201"),
				Name = @"Email",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5ad029c6-0fa7-4db6-8fef-c72a0f535682"),
				Name = @"AddressType",
				ReferenceSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0fb61bc8-a195-4d90-aecc-18b411b51814"),
				Name = @"Address",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf58ca72-531b-4dd2-b4d5-f0d5b7c556f6"),
				Name = @"City",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0e50f221-470e-482b-8580-f61c74b8b1c1"),
				Name = @"Region",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateZipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0737d99d-eebc-4b8e-9859-634414f7cc04"),
				Name = @"Zip",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9463dea9-2576-4d37-812f-342ee57ddf32"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1b1d8f33-4d26-4353-a1ed-07e11fc82112"),
				Name = @"DoNotUseEmail",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseCallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a6bcf6fe-a06d-42ed-a263-f829ece05fd9"),
				Name = @"DoNotUseCall",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseFaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d9deaed5-8e42-40c0-9bb1-a6bfe6716ca4"),
				Name = @"DoNotUseFax",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseSmsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7e295464-4dee-4448-832c-97434b1f2943"),
				Name = @"DoNotUseSms",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseMailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("238d9e74-ff12-4e40-8467-350bd9d4b58d"),
				Name = @"DoNotUseMail",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fd73da4b-2b3d-483e-89d2-383a6db099ac"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactPhotoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("327e44bd-0b97-48c0-b11a-4686d6605b4f"),
				Name = @"ContactPhoto",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePhotoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("0495373c-5053-4ae3-b553-dc92779c4702"),
				Name = @"Photo",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("abc2d3f4-826b-4178-b0c1-b277e94aed5f")
			};
		}

		protected virtual EntitySchemaColumn CreateGPSNColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("b903e71d-74cd-4b79-9dd9-d0c84ef6ad44"),
				Name = @"GPSN",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("88ca8859-5a70-4347-94ce-f17e86447db4")
			};
		}

		protected virtual EntitySchemaColumn CreateGPSEColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("b9021fa0-6606-4027-8335-bf0624b58218"),
				Name = @"GPSE",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("88ca8859-5a70-4347-94ce-f17e86447db4")
			};
		}

		protected virtual EntitySchemaColumn CreateSurnameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("771a60e2-020c-4dd2-8512-b428b8a47dba"),
				Name = @"Surname",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847")
			};
		}

		protected virtual EntitySchemaColumn CreateGivenNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cc26b1c5-4254-4287-9c15-0b5acd319811"),
				Name = @"GivenName",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847")
			};
		}

		protected virtual EntitySchemaColumn CreateMiddleNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("33a879a3-d466-4b3f-b529-377a69ff0819"),
				Name = @"MiddleName",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847")
			};
		}

		protected virtual EntitySchemaColumn CreateConfirmedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ced280cc-7423-4175-9896-ea592a9e81a6"),
				Name = @"Confirmed",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("4fc0058c-8585-4c70-9e25-887f84d29fa9"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a855b7ae-45be-4d73-9074-9d84e4ae66c4"),
				Name = @"Language",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateAgeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bcdc7a32-4332-4caf-858d-0078b56856fe"),
				Name = @"Age",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			};
		}

		protected virtual EntitySchemaColumn CreateIsEmailConfirmedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f963730e-7256-f35d-03ff-ba60a1d641d7"),
				Name = @"IsEmailConfirmed",
				CreatedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				ModifiedInSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contact_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_Base_BPMSoft

	/// <summary>
	/// Контакт.
	/// </summary>
	public class Contact_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Contact_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_Base_BPMSoft";
		}

		public Contact_Base_BPMSoft(Contact_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ФИО.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
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
		public Guid SalutationTypeId {
			get {
				return GetTypedColumnValue<Guid>("SalutationTypeId");
			}
			set {
				SetColumnValue("SalutationTypeId", value);
				_salutationType = null;
			}
		}

		/// <exclude/>
		public string SalutationTypeName {
			get {
				return GetTypedColumnValue<string>("SalutationTypeName");
			}
			set {
				SetColumnValue("SalutationTypeName", value);
				if (_salutationType != null) {
					_salutationType.Name = value;
				}
			}
		}

		private ContactSalutationType _salutationType;
		/// <summary>
		/// Обращение.
		/// </summary>
		public ContactSalutationType SalutationType {
			get {
				return _salutationType ??
					(_salutationType = LookupColumnEntities.GetEntity("SalutationType") as ContactSalutationType);
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

		private ContactType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ContactType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ContactType);
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

		/// <summary>
		/// Полное название должности.
		/// </summary>
		public string JobTitle {
			get {
				return GetTypedColumnValue<string>("JobTitle");
			}
			set {
				SetColumnValue("JobTitle", value);
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

		/// <summary>
		/// Дата рождения.
		/// </summary>
		public DateTime BirthDate {
			get {
				return GetTypedColumnValue<DateTime>("BirthDate");
			}
			set {
				SetColumnValue("BirthDate", value);
			}
		}

		/// <summary>
		/// Рабочий телефон.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
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
		/// Домашний телефон.
		/// </summary>
		public string HomePhone {
			get {
				return GetTypedColumnValue<string>("HomePhone");
			}
			set {
				SetColumnValue("HomePhone", value);
			}
		}

		/// <summary>
		/// Skype.
		/// </summary>
		public string Skype {
			get {
				return GetTypedColumnValue<string>("Skype");
			}
			set {
				SetColumnValue("Skype", value);
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
		/// Область.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = LookupColumnEntities.GetEntity("Region") as Region);
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

		/// <summary>
		/// Не использовать Email.
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
		public bool DoNotUseCall {
			get {
				return GetTypedColumnValue<bool>("DoNotUseCall");
			}
			set {
				SetColumnValue("DoNotUseCall", value);
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
		public bool DoNotUseSms {
			get {
				return GetTypedColumnValue<bool>("DoNotUseSms");
			}
			set {
				SetColumnValue("DoNotUseSms", value);
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

		/// <exclude/>
		public Guid PhotoId {
			get {
				return GetTypedColumnValue<Guid>("PhotoId");
			}
			set {
				SetColumnValue("PhotoId", value);
				_photo = null;
			}
		}

		/// <exclude/>
		public string PhotoName {
			get {
				return GetTypedColumnValue<string>("PhotoName");
			}
			set {
				SetColumnValue("PhotoName", value);
				if (_photo != null) {
					_photo.Name = value;
				}
			}
		}

		private SysImage _photo;
		/// <summary>
		/// Фото.
		/// </summary>
		public SysImage Photo {
			get {
				return _photo ??
					(_photo = LookupColumnEntities.GetEntity("Photo") as SysImage);
			}
		}

		/// <summary>
		/// GPS N.
		/// </summary>
		public string GPSN {
			get {
				return GetTypedColumnValue<string>("GPSN");
			}
			set {
				SetColumnValue("GPSN", value);
			}
		}

		/// <summary>
		/// GPS E.
		/// </summary>
		public string GPSE {
			get {
				return GetTypedColumnValue<string>("GPSE");
			}
			set {
				SetColumnValue("GPSE", value);
			}
		}

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string Surname {
			get {
				return GetTypedColumnValue<string>("Surname");
			}
			set {
				SetColumnValue("Surname", value);
			}
		}

		/// <summary>
		/// Имя.
		/// </summary>
		public string GivenName {
			get {
				return GetTypedColumnValue<string>("GivenName");
			}
			set {
				SetColumnValue("GivenName", value);
			}
		}

		/// <summary>
		/// Отчество.
		/// </summary>
		public string MiddleName {
			get {
				return GetTypedColumnValue<string>("MiddleName");
			}
			set {
				SetColumnValue("MiddleName", value);
			}
		}

		/// <summary>
		/// Подтвержден.
		/// </summary>
		public bool Confirmed {
			get {
				return GetTypedColumnValue<bool>("Confirmed");
			}
			set {
				SetColumnValue("Confirmed", value);
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Язык общения.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = LookupColumnEntities.GetEntity("Language") as SysLanguage);
			}
		}

		/// <summary>
		/// Возраст.
		/// </summary>
		public int Age {
			get {
				return GetTypedColumnValue<int>("Age");
			}
			set {
				SetColumnValue("Age", value);
			}
		}

		/// <summary>
		/// IsEmailConfirmed.
		/// </summary>
		/// <remarks>
		/// Email подтверждён.
		/// </remarks>
		public bool IsEmailConfirmed {
			get {
				return GetTypedColumnValue<bool>("IsEmailConfirmed");
			}
			set {
				SetColumnValue("IsEmailConfirmed", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contact_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Contact_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Contact_Base_BPMSoftDeleting", e);
			Inserting += (s, e) => ThrowEvent("Contact_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Contact_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Contact_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Contact_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contact_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_BaseEventsProcess

	/// <exclude/>
	public partial class Contact_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Contact_Base_BPMSoft
	{

		#region Class: SynchronizeAnniversaryFlowElement

		/// <exclude/>
		public class SynchronizeAnniversaryFlowElement : SynchronizeChildEntityData
		{

			public SynchronizeAnniversaryFlowElement(UserConnection userConnection, Contact_BaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SynchronizeAnniversary";
				IsLogging = false;
				SchemaElementUId = new Guid("3a05881c-2d6c-4b29-aced-b2e655151398");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Contact_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_BaseEventsProcess";
			SchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private bool _isCareerChanged = true;
		public bool IsCareerChanged {
			get {
				return _isCareerChanged;
			}
			set {
				_isCareerChanged = value;
			}
		}

		public virtual bool Current {
			get;
			set;
		}

		private bool _needUpdate = true;
		public bool NeedUpdate {
			get {
				return _needUpdate;
			}
			set {
				_needUpdate = value;
			}
		}

		public virtual Object ProcessSchemaParameter1 {
			get;
			set;
		}

		public virtual bool IsCurrentUserPhoroChanged {
			get;
			set;
		}

		public virtual bool NeedUpdateCareer {
			get;
			set;
		}

		public virtual bool NeedInsertCareer {
			get;
			set;
		}

		public virtual Object CommunicationSynchronizer {
			get;
			set;
		}

		public virtual bool NeedDeleteCareer {
			get;
			set;
		}

		public virtual Guid PreviousAccountValue {
			get;
			set;
		}

		public virtual bool CanGenerateAnniversaryReminding {
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
					SchemaElementUId = new Guid("ac1862f6-5081-47bb-9e5a-1d801f37648e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactSaved;
		public ProcessFlowElement ContactSaved {
			get {
				return _contactSaved ?? (_contactSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactSaved",
					SchemaElementUId = new Guid("767e7517-bb79-4680-b6e3-4fe8162501e6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _synchronizeContactAddressScriptTask;
		public ProcessScriptTask SynchronizeContactAddressScriptTask {
			get {
				return _synchronizeContactAddressScriptTask ?? (_synchronizeContactAddressScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeContactAddressScriptTask",
					SchemaElementUId = new Guid("193c9932-6748-4236-bea9-d5cc48807672"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeContactAddressScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _synchronizeContactCommunication;
		public ProcessScriptTask SynchronizeContactCommunication {
			get {
				return _synchronizeContactCommunication ?? (_synchronizeContactCommunication = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeContactCommunication",
					SchemaElementUId = new Guid("baff5e90-c8e3-4458-927d-dbeb1b295e9f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeContactCommunicationExecute,
				});
			}
		}

		private ProcessScriptTask _scriptSynchronizeAnniversary;
		public ProcessScriptTask ScriptSynchronizeAnniversary {
			get {
				return _scriptSynchronizeAnniversary ?? (_scriptSynchronizeAnniversary = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptSynchronizeAnniversary",
					SchemaElementUId = new Guid("4a1a63ac-66ea-4123-981f-52c401d078ba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptSynchronizeAnniversaryExecute,
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
					SchemaElementUId = new Guid("2e282bfa-9287-4113-a46a-da1bbec3b4de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateRemindingsExecute,
				});
			}
		}

		private SynchronizeAnniversaryFlowElement _synchronizeAnniversary;
		public SynchronizeAnniversaryFlowElement SynchronizeAnniversary {
			get {
				return _synchronizeAnniversary ?? (_synchronizeAnniversary = new SynchronizeAnniversaryFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _updateCareerScriptTask;
		public ProcessScriptTask UpdateCareerScriptTask {
			get {
				return _updateCareerScriptTask ?? (_updateCareerScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateCareerScriptTask",
					SchemaElementUId = new Guid("5d623849-3c39-4bb3-b94c-9678cb0a2ae8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateCareerScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _synchronizeNameScriptTast;
		public ProcessScriptTask SynchronizeNameScriptTast {
			get {
				return _synchronizeNameScriptTast ?? (_synchronizeNameScriptTast = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeNameScriptTast",
					SchemaElementUId = new Guid("1d75978c-1eba-428d-98de-6319ff5257b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeNameScriptTastExecute,
				});
			}
		}

		private ProcessFlowElement _contactSavingEventSubProcess;
		public ProcessFlowElement ContactSavingEventSubProcess {
			get {
				return _contactSavingEventSubProcess ?? (_contactSavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ContactSavingEventSubProcess",
					SchemaElementUId = new Guid("a8975df4-ae3d-4cfa-ad27-0666ece40f37"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactSaving;
		public ProcessFlowElement ContactSaving {
			get {
				return _contactSaving ?? (_contactSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactSaving",
					SchemaElementUId = new Guid("5e79f0ee-c33c-44ea-88e2-6375b47106ca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _contactSavingScriptTask;
		public ProcessScriptTask ContactSavingScriptTask {
			get {
				return _contactSavingScriptTask ?? (_contactSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ContactSavingScriptTask",
					SchemaElementUId = new Guid("a858ee01-adbc-4740-b449-e5868ac1cbf2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ContactSavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2s;
		public ProcessFlowElement EventSubProcess2s {
			get {
				return _eventSubProcess2s ?? (_eventSubProcess2s = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2s",
					SchemaElementUId = new Guid("bd823e8f-6967-4022-a2b8-1e23cd411050"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactDeleting;
		public ProcessFlowElement ContactDeleting {
			get {
				return _contactDeleting ?? (_contactDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactDeleting",
					SchemaElementUId = new Guid("d4f5150a-1aab-4bf4-98ca-e891eb03ff43"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _synchronizeContactCorrespondenceScriptTask;
		public ProcessScriptTask SynchronizeContactCorrespondenceScriptTask {
			get {
				return _synchronizeContactCorrespondenceScriptTask ?? (_synchronizeContactCorrespondenceScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeContactCorrespondenceScriptTask",
					SchemaElementUId = new Guid("d1983277-3250-4b98-bef8-5f3dc94fccaf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeContactCorrespondenceScriptTaskExecute,
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
					SchemaElementUId = new Guid("12d88f28-b68f-4628-98fa-d1d76ebb3050"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactDeleted;
		public ProcessFlowElement ContactDeleted {
			get {
				return _contactDeleted ?? (_contactDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactDeleted",
					SchemaElementUId = new Guid("b610ca25-5e69-4cfe-b077-c0ba24de5e5f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _deleteRemindings;
		public ProcessScriptTask DeleteRemindings {
			get {
				return _deleteRemindings ?? (_deleteRemindings = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DeleteRemindings",
					SchemaElementUId = new Guid("52789257-7720-4840-982e-f8dcd9e06a89"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DeleteRemindingsExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ContactSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactSaved };
			FlowElements[SynchronizeContactAddressScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeContactAddressScriptTask };
			FlowElements[SynchronizeContactCommunication.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeContactCommunication };
			FlowElements[ScriptSynchronizeAnniversary.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptSynchronizeAnniversary };
			FlowElements[UpdateRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateRemindings };
			FlowElements[SynchronizeAnniversary.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeAnniversary };
			FlowElements[UpdateCareerScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateCareerScriptTask };
			FlowElements[SynchronizeNameScriptTast.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeNameScriptTast };
			FlowElements[ContactSavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactSavingEventSubProcess };
			FlowElements[ContactSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactSaving };
			FlowElements[ContactSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactSavingScriptTask };
			FlowElements[EventSubProcess2s.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2s };
			FlowElements[ContactDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactDeleting };
			FlowElements[SynchronizeContactCorrespondenceScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeContactCorrespondenceScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[ContactDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactDeleted };
			FlowElements[DeleteRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { DeleteRemindings };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ContactSaved":
						e.Context.QueueTasks.Enqueue("SynchronizeContactAddressScriptTask");
						e.Context.QueueTasks.Enqueue("SynchronizeContactCommunication");
						e.Context.QueueTasks.Enqueue("ScriptSynchronizeAnniversary");
						e.Context.QueueTasks.Enqueue("UpdateRemindings");
						e.Context.QueueTasks.Enqueue("UpdateCareerScriptTask");
						e.Context.QueueTasks.Enqueue("SynchronizeNameScriptTast");
						break;
					case "SynchronizeContactAddressScriptTask":
						break;
					case "SynchronizeContactCommunication":
						break;
					case "ScriptSynchronizeAnniversary":
						e.Context.QueueTasks.Enqueue("SynchronizeAnniversary");
						break;
					case "UpdateRemindings":
						break;
					case "SynchronizeAnniversary":
						break;
					case "UpdateCareerScriptTask":
						break;
					case "SynchronizeNameScriptTast":
						break;
					case "ContactSavingEventSubProcess":
						break;
					case "ContactSaving":
						e.Context.QueueTasks.Enqueue("ContactSavingScriptTask");
						break;
					case "ContactSavingScriptTask":
						break;
					case "EventSubProcess2s":
						break;
					case "ContactDeleting":
						e.Context.QueueTasks.Enqueue("SynchronizeContactCorrespondenceScriptTask");
						break;
					case "SynchronizeContactCorrespondenceScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "ContactDeleted":
						e.Context.QueueTasks.Enqueue("DeleteRemindings");
						break;
					case "DeleteRemindings":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ContactSaved");
			ActivatedEventElements.Add("ContactSaving");
			ActivatedEventElements.Add("ContactDeleting");
			ActivatedEventElements.Add("ContactDeleted");
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
				case "ContactSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactSaved";
					result = ContactSaved.Execute(context);
					break;
				case "SynchronizeContactAddressScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeContactAddressScriptTask";
					result = SynchronizeContactAddressScriptTask.Execute(context, SynchronizeContactAddressScriptTaskExecute);
					break;
				case "SynchronizeContactCommunication":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeContactCommunication";
					result = SynchronizeContactCommunication.Execute(context, SynchronizeContactCommunicationExecute);
					break;
				case "ScriptSynchronizeAnniversary":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptSynchronizeAnniversary";
					result = ScriptSynchronizeAnniversary.Execute(context, ScriptSynchronizeAnniversaryExecute);
					break;
				case "UpdateRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateRemindings";
					result = UpdateRemindings.Execute(context, UpdateRemindingsExecute);
					break;
				case "SynchronizeAnniversary":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeAnniversary";
					result = SynchronizeAnniversary.Execute(context);
					break;
				case "UpdateCareerScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateCareerScriptTask";
					result = UpdateCareerScriptTask.Execute(context, UpdateCareerScriptTaskExecute);
					break;
				case "SynchronizeNameScriptTast":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeNameScriptTast";
					result = SynchronizeNameScriptTast.Execute(context, SynchronizeNameScriptTastExecute);
					break;
				case "ContactSavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ContactSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactSaving";
					result = ContactSaving.Execute(context);
					break;
				case "ContactSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactSavingScriptTask";
					result = ContactSavingScriptTask.Execute(context, ContactSavingScriptTaskExecute);
					break;
				case "EventSubProcess2s":
					context.QueueTasks.Dequeue();
					break;
				case "ContactDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactDeleting";
					result = ContactDeleting.Execute(context);
					break;
				case "SynchronizeContactCorrespondenceScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeContactCorrespondenceScriptTask";
					result = SynchronizeContactCorrespondenceScriptTask.Execute(context, SynchronizeContactCorrespondenceScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ContactDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactDeleted";
					result = ContactDeleted.Execute(context);
					break;
				case "DeleteRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "DeleteRemindings";
					result = DeleteRemindings.Execute(context, DeleteRemindingsExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SynchronizeContactAddressScriptTaskExecute(ProcessExecutingContext context) {
			return SynchronizeContactAddress();
		}

		public virtual bool SynchronizeContactCommunicationExecute(ProcessExecutingContext context) {
			return SynchronizeCommunication();
		}

		public virtual bool ScriptSynchronizeAnniversaryExecute(ProcessExecutingContext context) {
			var ContactAnniversarySchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactAnniversary");
			Guid columnUId;
			Guid childObjectColumnUId;
			
			var mappingCoulmns = new System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>>();
			var searchFilters = new System.Collections.Generic.Dictionary<
			Guid, object>();
			
			//--------------- Filters ----------------
			childObjectColumnUId = ContactAnniversarySchema.Columns.GetByName("Contact").UId;
			searchFilters.Add(childObjectColumnUId, Entity.GetColumnValue(Entity.Schema.GetPrimaryColumnName()));
			
			childObjectColumnUId = ContactAnniversarySchema.Columns.GetByName("AnniversaryType").UId;
			searchFilters.Add(childObjectColumnUId, new Guid("173D56D2-FDCA-DF11-9B2A-001D60E938C6"));
			
			
			//--------------- Map Params ----------------
			columnUId = Entity.Schema.Columns.GetByName("BirthDate").UId;
			childObjectColumnUId = ContactAnniversarySchema.Columns.GetByName("Date").UId;
			var column = new System.Collections.Generic.Dictionary<
			Guid, object>();
			column.Add(childObjectColumnUId, columnUId);
			mappingCoulmns.Add(columnUId, column);
			
			columnUId = Entity.Schema.Columns.GetByName("Id").UId;
			childObjectColumnUId = ContactAnniversarySchema.Columns.GetByName("Contact").UId;
			column = new System.Collections.Generic.Dictionary<
			Guid, object>();
			column.Add(childObjectColumnUId, columnUId);
			mappingCoulmns.Add(columnUId, column);
			
			//--------------- Def Values ----------------
			var defaultValues = new System.Collections.Generic.Dictionary<
			Guid, object>();
			childObjectColumnUId = ContactAnniversarySchema.Columns.GetByName("AnniversaryType").UId;
			defaultValues.Add(childObjectColumnUId, new Guid("173D56D2-FDCA-DF11-9B2A-001D60E938C6"));
			
			SynchronizeAnniversary.ChildEntitySchemaUId = new Guid("FA36E9A5-C2FC-47B2-B5CB-2B58EF61D4E6");
			SynchronizeAnniversary.SingleRowSearchFilters = searchFilters;
			SynchronizeAnniversary.MappingColumns = mappingCoulmns;
			SynchronizeAnniversary.DefaultValues = defaultValues;
			SynchronizeAnniversary.RequiredFields = new string[]{"Date"};
			SynchronizeAnniversary.RequiredAllFields = true;
			
			
			return true;
		}

		public virtual bool UpdateRemindingsExecute(ProcessExecutingContext context) {
			ExecuteUpdateRemindings();
			return true;
		}

		public virtual bool UpdateCareerScriptTaskExecute(ProcessExecutingContext context) {
			ChangeCareer();
			return true;
		}

		public virtual bool SynchronizeNameScriptTastExecute(ProcessExecutingContext context) {
			SynchronizeContactName();
			return true;
		}

		public virtual bool ContactSavingScriptTaskExecute(ProcessExecutingContext context) {
			IsCurrentUserPhoroChanged = (Entity.GetTypedColumnValue<Guid>("PhotoId") !=
				Entity.GetTypedOldColumnValue<Guid>("PhotoId") && Entity.GetTypedColumnValue<Guid>("Id") ==
			UserConnection.CurrentUser.ContactId);
			PreviousAccountValue = Entity.GetTypedOldColumnValue<Guid>("AccountId");
			FillSgmOrNameField();
			CheckIsCareerChanged();
			InitializeCommunicationSynchronizer();
			InitCanGenerateAnniversaryReminding();
			UpdateContactAge();
			return true;
		}

		public virtual bool SynchronizeContactCorrespondenceScriptTaskExecute(ProcessExecutingContext context) {
			new Update(UserConnection, "ContactCorrespondence")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("ContactId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue)).Execute();
			return true;
		}

		public virtual bool DeleteRemindingsExecute(ProcessExecutingContext context) {
			ExecuteDeleteRemindings();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Contact_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ContactSaved")) {
							context.QueueTasks.Enqueue("ContactSaved");
						}
						break;
					case "Contact_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("ContactSaving")) {
							context.QueueTasks.Enqueue("ContactSaving");
						}
						break;
					case "Contact_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("ContactDeleting")) {
							context.QueueTasks.Enqueue("ContactDeleting");
						}
						break;
					case "Contact_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("ContactDeleted")) {
							context.QueueTasks.Enqueue("ContactDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_BaseEventsProcess

	/// <exclude/>
	public class Contact_BaseEventsProcess : Contact_BaseEventsProcess<Contact_Base_BPMSoft>
	{

		public Contact_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

