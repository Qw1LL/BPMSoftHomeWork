namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: Account_Base_BPMSoftSchema

	/// <exclude/>
	public class Account_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Account_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Account_Base_BPMSoftSchema(Account_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Account_Base_BPMSoftSchema(Account_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			RealUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			Name = "Account_Base_BPMSoft";
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
			PrimaryImageColumn = CreateAccountLogoColumn();
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
			if (Columns.FindByUId(new Guid("dedb8f3b-4cb0-46ec-99e8-483ab92e10bb")) == null) {
				Columns.Add(CreateOwnershipColumn());
			}
			if (Columns.FindByUId(new Guid("165072a8-b718-4490-ab89-223f30390d81")) == null) {
				Columns.Add(CreatePrimaryContactColumn());
			}
			if (Columns.FindByUId(new Guid("f25a5087-fab6-4c7a-9cd0-177325f6e715")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("d7da954f-d0d8-4eca-a2b4-7d4f7121f6b4")) == null) {
				Columns.Add(CreateIndustryColumn());
			}
			if (Columns.FindByUId(new Guid("60cc5643-4ee2-4adf-b76b-06000ad0b067")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("d60a9c06-1170-4cd6-9dc1-c972bc451533")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("9dbe8164-58b4-42c9-a75e-7c568d430d50")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("9411651f-b785-4920-a542-e8ac11d2cf8d")) == null) {
				Columns.Add(CreateAdditionalPhoneColumn());
			}
			if (Columns.FindByUId(new Guid("40bf89ca-5927-47a6-b3fe-8955deb5f3ce")) == null) {
				Columns.Add(CreateFaxColumn());
			}
			if (Columns.FindByUId(new Guid("a1d2ad98-d068-4fc2-8454-8a7c944cd0a1")) == null) {
				Columns.Add(CreateWebColumn());
			}
			if (Columns.FindByUId(new Guid("9f5af167-9ab8-4c83-99db-7503df0eb650")) == null) {
				Columns.Add(CreateAddressTypeColumn());
			}
			if (Columns.FindByUId(new Guid("8cfabb54-64ca-413d-a4e0-81ce9d2f0c8f")) == null) {
				Columns.Add(CreateAddressColumn());
			}
			if (Columns.FindByUId(new Guid("13bbd624-a13b-4bc2-b05c-fff21e9f7b92")) == null) {
				Columns.Add(CreateCityColumn());
			}
			if (Columns.FindByUId(new Guid("8f532bba-53fb-4f56-babd-38402cb57b2a")) == null) {
				Columns.Add(CreateRegionColumn());
			}
			if (Columns.FindByUId(new Guid("3fe38c61-ff55-4012-b28d-67e59d5b1986")) == null) {
				Columns.Add(CreateZipColumn());
			}
			if (Columns.FindByUId(new Guid("2a7c00bd-0519-4742-b905-d8ce5f1b70ca")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("0039b8f7-f5cf-44c9-8828-4b9cb2fd6634")) == null) {
				Columns.Add(CreateAccountCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("8696b76a-1f0b-42a4-8279-934399c0207f")) == null) {
				Columns.Add(CreateEmployeesNumberColumn());
			}
			if (Columns.FindByUId(new Guid("a006d013-4ef6-47a1-a000-d25346fcb392")) == null) {
				Columns.Add(CreateAnnualRevenueColumn());
			}
			if (Columns.FindByUId(new Guid("0136fb47-c018-4b7f-8ed3-0eb6bd686b20")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("c8abae85-5c2e-45bc-826b-fd53a88660c8")) == null) {
				Columns.Add(CreateLogoColumn());
			}
			if (Columns.FindByUId(new Guid("e36ae687-347d-4bf7-b260-90129862e357")) == null) {
				Columns.Add(CreateAlternativeNameColumn());
			}
			if (Columns.FindByUId(new Guid("f1f01f71-ddef-48bb-bc88-0fd2f3526ad9")) == null) {
				Columns.Add(CreateGPSNColumn());
			}
			if (Columns.FindByUId(new Guid("2ce4d59d-2ae4-4840-b4a7-33eee33fdb60")) == null) {
				Columns.Add(CreateGPSEColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7c81a01e-f59b-47df-830c-8e830f1bf889"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7c85a229-8cfa-4c29-8ab9-9463560a92ec"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dedb8f3b-4cb0-46ec-99e8-483ab92e10bb"),
				Name = @"Ownership",
				ReferenceSchemaUId = new Guid("ce243c2c-b7d3-4dc4-b474-ab24c677801b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("165072a8-b718-4490-ab89-223f30390d81"),
				Name = @"PrimaryContact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f25a5087-fab6-4c7a-9cd0-177325f6e715"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIndustryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d7da954f-d0d8-4eca-a2b4-7d4f7121f6b4"),
				Name = @"Industry",
				ReferenceSchemaUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("60cc5643-4ee2-4adf-b76b-06000ad0b067"),
				Name = @"Code",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d60a9c06-1170-4cd6-9dc1-c972bc451533"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("3ae4a2bb-d3dc-48bf-8271-9ca91dcdeba1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9dbe8164-58b4-42c9-a75e-7c568d430d50"),
				Name = @"Phone",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAdditionalPhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9411651f-b785-4920-a542-e8ac11d2cf8d"),
				Name = @"AdditionalPhone",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("40bf89ca-5927-47a6-b3fe-8955deb5f3ce"),
				Name = @"Fax",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateWebColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a1d2ad98-d068-4fc2-8454-8a7c944cd0a1"),
				Name = @"Web",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9f5af167-9ab8-4c83-99db-7503df0eb650"),
				Name = @"AddressType",
				ReferenceSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8cfabb54-64ca-413d-a4e0-81ce9d2f0c8f"),
				Name = @"Address",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("13bbd624-a13b-4bc2-b05c-fff21e9f7b92"),
				Name = @"City",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8f532bba-53fb-4f56-babd-38402cb57b2a"),
				Name = @"Region",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateZipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3fe38c61-ff55-4012-b28d-67e59d5b1986"),
				Name = @"Zip",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2a7c00bd-0519-4742-b905-d8ce5f1b70ca"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0039b8f7-f5cf-44c9-8828-4b9cb2fd6634"),
				Name = @"AccountCategory",
				ReferenceSchemaUId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEmployeesNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8696b76a-1f0b-42a4-8279-934399c0207f"),
				Name = @"EmployeesNumber",
				ReferenceSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAnnualRevenueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a006d013-4ef6-47a1-a000-d25346fcb392"),
				Name = @"AnnualRevenue",
				ReferenceSchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0136fb47-c018-4b7f-8ed3-0eb6bd686b20"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLogoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("c8abae85-5c2e-45bc-826b-fd53a88660c8"),
				Name = @"Logo",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAlternativeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e36ae687-347d-4bf7-b260-90129862e357"),
				Name = @"AlternativeName",
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateGPSNColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f1f01f71-ddef-48bb-bc88-0fd2f3526ad9"),
				Name = @"GPSN",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("88ca8859-5a70-4347-94ce-f17e86447db4")
			};
		}

		protected virtual EntitySchemaColumn CreateGPSEColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("2ce4d59d-2ae4-4840-b4a7-33eee33fdb60"),
				Name = @"GPSE",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("88ca8859-5a70-4347-94ce-f17e86447db4")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountLogoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("27a77271-50e0-436f-a559-38ce3f8f7f37"),
				Name = @"AccountLogo",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				ModifiedInSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Account_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Account_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Account_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Account_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"));
		}

		#endregion

	}

	#endregion

	#region Class: Account_Base_BPMSoft

	/// <summary>
	/// Контрагент.
	/// </summary>
	public class Account_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Account_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account_Base_BPMSoft";
		}

		public Account_Base_BPMSoft(Account_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
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

		/// <exclude/>
		public Guid PrimaryContactId {
			get {
				return GetTypedColumnValue<Guid>("PrimaryContactId");
			}
			set {
				SetColumnValue("PrimaryContactId", value);
				_primaryContact = null;
			}
		}

		/// <exclude/>
		public string PrimaryContactName {
			get {
				return GetTypedColumnValue<string>("PrimaryContactName");
			}
			set {
				SetColumnValue("PrimaryContactName", value);
				if (_primaryContact != null) {
					_primaryContact.Name = value;
				}
			}
		}

		private Contact _primaryContact;
		/// <summary>
		/// Основной контакт.
		/// </summary>
		public Contact PrimaryContact {
			get {
				return _primaryContact ??
					(_primaryContact = LookupColumnEntities.GetEntity("PrimaryContact") as Contact);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private Account _parent;
		/// <summary>
		/// Родительский контрагент.
		/// </summary>
		public Account Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as Account);
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

		/// <summary>
		/// Код.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
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

		private AccountType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public AccountType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as AccountType);
			}
		}

		/// <summary>
		/// Основной телефон.
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
		/// Дополнительный телефон.
		/// </summary>
		public string AdditionalPhone {
			get {
				return GetTypedColumnValue<string>("AdditionalPhone");
			}
			set {
				SetColumnValue("AdditionalPhone", value);
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
		public string Web {
			get {
				return GetTypedColumnValue<string>("Web");
			}
			set {
				SetColumnValue("Web", value);
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
		/// Альтернативные названия.
		/// </summary>
		public string AlternativeName {
			get {
				return GetTypedColumnValue<string>("AlternativeName");
			}
			set {
				SetColumnValue("AlternativeName", value);
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

		/// <exclude/>
		public Guid AccountLogoId {
			get {
				return GetTypedColumnValue<Guid>("AccountLogoId");
			}
			set {
				SetColumnValue("AccountLogoId", value);
				_accountLogo = null;
			}
		}

		/// <exclude/>
		public string AccountLogoName {
			get {
				return GetTypedColumnValue<string>("AccountLogoName");
			}
			set {
				SetColumnValue("AccountLogoName", value);
				if (_accountLogo != null) {
					_accountLogo.Name = value;
				}
			}
		}

		private SysImage _accountLogo;
		/// <summary>
		/// Логотип контрагента.
		/// </summary>
		public SysImage AccountLogo {
			get {
				return _accountLogo ??
					(_accountLogo = LookupColumnEntities.GetEntity("AccountLogo") as SysImage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Account_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Account_Base_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Account_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Account_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Account_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Account_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Account_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Account_BaseEventsProcess

	/// <exclude/>
	public partial class Account_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Account_Base_BPMSoft
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Account_BaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("23f80421-a6e3-43ce-935b-490631fc9c22");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Account_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Account_BaseEventsProcess";
			SchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid OldParentId {
			get;
			set;
		}

		public virtual bool ParentIdIsNotNull {
			get;
			set;
		}

		public virtual Object CommunicationSynchronizer {
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

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("a3c39c58-36fa-41f9-978a-41f4ec5defe7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountSaved;
		public ProcessFlowElement AccountSaved {
			get {
				return _accountSaved ?? (_accountSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountSaved",
					SchemaElementUId = new Guid("e63b0109-ceea-4da8-b0d4-b0cfda08fe27"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _synchronizeAccountAddressScriptTask;
		public ProcessScriptTask SynchronizeAccountAddressScriptTask {
			get {
				return _synchronizeAccountAddressScriptTask ?? (_synchronizeAccountAddressScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeAccountAddressScriptTask",
					SchemaElementUId = new Guid("f30faa55-8788-4cd8-8f5f-358532e6f92b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeAccountAddressScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _synchronizeAccountCommunication;
		public ProcessScriptTask SynchronizeAccountCommunication {
			get {
				return _synchronizeAccountCommunication ?? (_synchronizeAccountCommunication = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeAccountCommunication",
					SchemaElementUId = new Guid("8daa7139-ad38-4748-9d7b-b3f957254876"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeAccountCommunicationExecute,
				});
			}
		}

		private ProcessScriptTask _scriptAccountParentSaved;
		public ProcessScriptTask ScriptAccountParentSaved {
			get {
				return _scriptAccountParentSaved ?? (_scriptAccountParentSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptAccountParentSaved",
					SchemaElementUId = new Guid("356c651f-eb15-4ba0-b31c-dc367acecdd6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptAccountParentSavedExecute,
				});
			}
		}

		private ProcessScriptTask _needGenerateScript;
		public ProcessScriptTask NeedGenerateScript {
			get {
				return _needGenerateScript ?? (_needGenerateScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "NeedGenerateScript",
					SchemaElementUId = new Guid("2d13f163-9406-40fd-a471-238f99046454"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = NeedGenerateScriptExecute,
				});
			}
		}

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _needGeenerateNumberExclusiveGateway;
		public ProcessExclusiveGateway NeedGeenerateNumberExclusiveGateway {
			get {
				return _needGeenerateNumberExclusiveGateway ?? (_needGeenerateNumberExclusiveGateway = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "NeedGeenerateNumberExclusiveGateway",
					SchemaElementUId = new Guid("f9d48047-c089-464f-9c0e-eabd04f0f45f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.NeedGeenerateNumberExclusiveGateway.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessEndEvent _end1;
		public ProcessEndEvent End1 {
			get {
				return _end1 ?? (_end1 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End1",
					SchemaElementUId = new Guid("8b8b9071-51d8-416c-ac2f-913cdc0bc7e2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _setGeneratedNumberScript;
		public ProcessScriptTask SetGeneratedNumberScript {
			get {
				return _setGeneratedNumberScript ?? (_setGeneratedNumberScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetGeneratedNumberScript",
					SchemaElementUId = new Guid("cb92e71d-1b18-439a-9821-f2f1b6e17740"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGeneratedNumberScriptExecute,
				});
			}
		}

		private ProcessScriptTask _scriptUpdateCampaignTargetCustomer;
		public ProcessScriptTask ScriptUpdateCampaignTargetCustomer {
			get {
				return _scriptUpdateCampaignTargetCustomer ?? (_scriptUpdateCampaignTargetCustomer = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptUpdateCampaignTargetCustomer",
					SchemaElementUId = new Guid("7a8a7f26-df98-41f9-b7d6-216928ec2507"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptUpdateCampaignTargetCustomerExecute,
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
					SchemaElementUId = new Guid("12429ad4-daac-4657-b543-6809b5928197"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateRemindingsExecute,
				});
			}
		}

		private ProcessScriptTask _initPrimaryContactAccountScriptTask;
		public ProcessScriptTask InitPrimaryContactAccountScriptTask {
			get {
				return _initPrimaryContactAccountScriptTask ?? (_initPrimaryContactAccountScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InitPrimaryContactAccountScriptTask",
					SchemaElementUId = new Guid("157a7f7c-9e1c-468b-87dd-f0e34c919c91"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = InitPrimaryContactAccountScriptTaskExecute,
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
					SchemaElementUId = new Guid("13734a1f-49cc-4fa2-9bab-dbe73a4dc714"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountSavingStartMessage;
		public ProcessFlowElement AccountSavingStartMessage {
			get {
				return _accountSavingStartMessage ?? (_accountSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountSavingStartMessage",
					SchemaElementUId = new Guid("1e590ddb-3f7a-41be-a10a-4f737b059754"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _accountSavingScriptTask;
		public ProcessScriptTask AccountSavingScriptTask {
			get {
				return _accountSavingScriptTask ?? (_accountSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "AccountSavingScriptTask",
					SchemaElementUId = new Guid("03fc7fc9-e572-406a-9d56-895f390391d5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = AccountSavingScriptTaskExecute,
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
					SchemaElementUId = new Guid("015c6ee2-b03d-4d96-b1a0-655d13a07b97"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountDeleted;
		public ProcessFlowElement AccountDeleted {
			get {
				return _accountDeleted ?? (_accountDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountDeleted",
					SchemaElementUId = new Guid("e6aefae8-1e05-4df5-b99e-a1f285635209"),
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
					SchemaElementUId = new Guid("7f528bdc-4a27-43f0-99eb-6c41c212dfc3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DeleteRemindingsExecute,
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow1324;
		public ProcessConditionalFlow ConditionalFlow1324 {
			get {
				return _conditionalFlow1324 ?? (_conditionalFlow1324 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1324",
					SchemaElementUId = new Guid("2b2e6f45-8346-46d4-8c0c-de9addade517"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[AccountSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountSaved };
			FlowElements[SynchronizeAccountAddressScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeAccountAddressScriptTask };
			FlowElements[SynchronizeAccountCommunication.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeAccountCommunication };
			FlowElements[ScriptAccountParentSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAccountParentSaved };
			FlowElements[NeedGenerateScript.SchemaElementUId] = new Collection<ProcessFlowElement> { NeedGenerateScript };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
			FlowElements[NeedGeenerateNumberExclusiveGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { NeedGeenerateNumberExclusiveGateway };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[SetGeneratedNumberScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGeneratedNumberScript };
			FlowElements[ScriptUpdateCampaignTargetCustomer.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptUpdateCampaignTargetCustomer };
			FlowElements[UpdateRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateRemindings };
			FlowElements[InitPrimaryContactAccountScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { InitPrimaryContactAccountScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[AccountSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountSavingStartMessage };
			FlowElements[AccountSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountSavingScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[AccountDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountDeleted };
			FlowElements[DeleteRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { DeleteRemindings };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "AccountSaved":
						e.Context.QueueTasks.Enqueue("SynchronizeAccountAddressScriptTask");
						e.Context.QueueTasks.Enqueue("SynchronizeAccountCommunication");
						e.Context.QueueTasks.Enqueue("ScriptAccountParentSaved");
						e.Context.QueueTasks.Enqueue("NeedGenerateScript");
						e.Context.QueueTasks.Enqueue("ScriptUpdateCampaignTargetCustomer");
						e.Context.QueueTasks.Enqueue("UpdateRemindings");
						e.Context.QueueTasks.Enqueue("InitPrimaryContactAccountScriptTask");
						break;
					case "SynchronizeAccountAddressScriptTask":
						break;
					case "SynchronizeAccountCommunication":
						break;
					case "ScriptAccountParentSaved":
						break;
					case "NeedGenerateScript":
						e.Context.QueueTasks.Enqueue("NeedGeenerateNumberExclusiveGateway");
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("SetGeneratedNumberScript");
						break;
					case "NeedGeenerateNumberExclusiveGateway":
						if (ConditionalFlow1324ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
							break;
						}
						e.Context.QueueTasks.Enqueue("End1");
						break;
					case "End1":
						break;
					case "SetGeneratedNumberScript":
						break;
					case "ScriptUpdateCampaignTargetCustomer":
						break;
					case "UpdateRemindings":
						break;
					case "InitPrimaryContactAccountScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "AccountSavingStartMessage":
						e.Context.QueueTasks.Enqueue("AccountSavingScriptTask");
						break;
					case "AccountSavingScriptTask":
						break;
					case "EventSubProcess3":
						break;
					case "AccountDeleted":
						e.Context.QueueTasks.Enqueue("DeleteRemindings");
						break;
					case "DeleteRemindings":
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1324ExpressionExecute() {
			return Convert.ToBoolean(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Code")));
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("AccountSaved");
			ActivatedEventElements.Add("AccountSavingStartMessage");
			ActivatedEventElements.Add("AccountDeleted");
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
				case "AccountSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountSaved";
					result = AccountSaved.Execute(context);
					break;
				case "SynchronizeAccountAddressScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeAccountAddressScriptTask";
					result = SynchronizeAccountAddressScriptTask.Execute(context, SynchronizeAccountAddressScriptTaskExecute);
					break;
				case "SynchronizeAccountCommunication":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeAccountCommunication";
					result = SynchronizeAccountCommunication.Execute(context, SynchronizeAccountCommunicationExecute);
					break;
				case "ScriptAccountParentSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptAccountParentSaved";
					result = ScriptAccountParentSaved.Execute(context, ScriptAccountParentSavedExecute);
					break;
				case "NeedGenerateScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "NeedGenerateScript";
					result = NeedGenerateScript.Execute(context, NeedGenerateScriptExecute);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
				case "NeedGeenerateNumberExclusiveGateway":
					context.QueueTasks.Dequeue();
					context.SenderName = "NeedGeenerateNumberExclusiveGateway";
					result = NeedGeenerateNumberExclusiveGateway.Execute(context);
					break;
				case "End1":
					context.QueueTasks.Dequeue();
					break;
				case "SetGeneratedNumberScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGeneratedNumberScript";
					result = SetGeneratedNumberScript.Execute(context, SetGeneratedNumberScriptExecute);
					break;
				case "ScriptUpdateCampaignTargetCustomer":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptUpdateCampaignTargetCustomer";
					result = ScriptUpdateCampaignTargetCustomer.Execute(context, ScriptUpdateCampaignTargetCustomerExecute);
					break;
				case "UpdateRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateRemindings";
					result = UpdateRemindings.Execute(context, UpdateRemindingsExecute);
					break;
				case "InitPrimaryContactAccountScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "InitPrimaryContactAccountScriptTask";
					result = InitPrimaryContactAccountScriptTask.Execute(context, InitPrimaryContactAccountScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "AccountSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountSavingStartMessage";
					result = AccountSavingStartMessage.Execute(context);
					break;
				case "AccountSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountSavingScriptTask";
					result = AccountSavingScriptTask.Execute(context, AccountSavingScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "AccountDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountDeleted";
					result = AccountDeleted.Execute(context);
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

		public virtual bool SynchronizeAccountAddressScriptTaskExecute(ProcessExecutingContext context) {
			// TODO: Актуализировать после возможности добавлять пользовательские атрибуты
			return SyncronizeAccountAddress();
		}

		public virtual bool SynchronizeAccountCommunicationExecute(ProcessExecutingContext context) {
			return SynchronizeCommunication();
		}

		public virtual bool ScriptAccountParentSavedExecute(ProcessExecutingContext context) {
			return SynchronizeRelationship();
		}

		public virtual bool NeedGenerateScriptExecute(ProcessExecutingContext context) {
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool SetGeneratedNumberScriptExecute(ProcessExecutingContext context) {
			string code = GenerateNumberUserTask.ResultCode;
			var update = new Update(UserConnection, Entity.Schema.Name)
				.Set("Code", Column.Parameter(code))
				.Where("Id").IsEqual(Column.Parameter(Entity.PrimaryColumnValue));
			update.Execute();
			return true;
		}

		public virtual bool ScriptUpdateCampaignTargetCustomerExecute(ProcessExecutingContext context) {
			var accountName = Entity.GetTypedColumnValue<string>(Entity.Schema.FindPrimaryDisplayColumnName());
			var accountId   = Entity.GetTypedColumnValue<string>("Id"); 
			/*new Update(UserConnection, "CampaignTarget")
				.Set("Customer", Column.Parameter(accountName))
				.Where("AccountId").IsEqual(Column.Parameter(accountId))
				.Execute();*/
			return true;
		}

		public virtual bool UpdateRemindingsExecute(ProcessExecutingContext context) {
			GenerateRemindings();
			return true;
		}

		public virtual bool InitPrimaryContactAccountScriptTaskExecute(ProcessExecutingContext context) {
			InitPrimaryContactAccount();
			return true;
		}

		public virtual bool AccountSavingScriptTaskExecute(ProcessExecutingContext context) {
			OldParentId = Entity.GetTypedOldColumnValue<Guid>("ParentId");
			InitializeCommunicationSynchronizer();
			InitCanGenerateAnniversaryReminding();
			return true;
		}

		public virtual bool DeleteRemindingsExecute(ProcessExecutingContext context) {
			Guid id = Entity.GetTypedColumnValue<Guid>("Id");
			Guid schemaUid = Entity.Schema.UId;
			AccountAnniversaryReminding remindingsGenerator = new AccountAnniversaryReminding(UserConnection, id);
			remindingsGenerator.DeleteRecordRemindings(schemaUid);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Account_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("AccountSaved")) {
							context.QueueTasks.Enqueue("AccountSaved");
						}
						break;
					case "Account_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("AccountSavingStartMessage")) {
							context.QueueTasks.Enqueue("AccountSavingStartMessage");
						}
						break;
					case "Account_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("AccountDeleted")) {
							context.QueueTasks.Enqueue("AccountDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Account_BaseEventsProcess

	/// <exclude/>
	public class Account_BaseEventsProcess : Account_BaseEventsProcess<Account_Base_BPMSoft>
	{

		public Account_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

