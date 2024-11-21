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

	#region Class: TouchSchema

	/// <exclude/>
	public class TouchSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TouchSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TouchSchema(TouchSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TouchSchema(TouchSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda");
			RealUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda");
			Name = "Touch";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateSessionIdColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("dcce3f70-704b-9d25-1c34-7164eaf914bb")) == null) {
				Columns.Add(CreateCityColumn());
			}
			if (Columns.FindByUId(new Guid("27c20e65-ae81-62fe-7cd1-dff5aec1e544")) == null) {
				Columns.Add(CreatePageReferrerColumn());
			}
			if (Columns.FindByUId(new Guid("a3000eb8-3285-8c3a-f3f5-be907b064bd0")) == null) {
				Columns.Add(CreateDurationColumn());
			}
			if (Columns.FindByUId(new Guid("587d6cf8-bc68-2cc8-9556-87f53ca11dc1")) == null) {
				Columns.Add(CreateDomainColumn());
			}
			if (Columns.FindByUId(new Guid("cac4c7a1-0abd-456b-7f83-c78e8e9b3045")) == null) {
				Columns.Add(CreateLanguageColumn());
			}
			if (Columns.FindByUId(new Guid("aaad9878-8fd2-a514-e9a9-cdddf2bc44e8")) == null) {
				Columns.Add(CreateIPColumn());
			}
			if (Columns.FindByUId(new Guid("97c2062a-41f4-b9f7-ed78-cb8e7fc02b89")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("7639c621-2038-8611-fc5a-990848141abc")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("3ee8b199-35ed-75fb-eeaf-07f49dc906a4")) == null) {
				Columns.Add(CreateUtmTermStrColumn());
			}
			if (Columns.FindByUId(new Guid("ddc7e6ca-715a-5cfa-0b0a-4fdeb1337065")) == null) {
				Columns.Add(CreateUtmSourceStrColumn());
			}
			if (Columns.FindByUId(new Guid("c23f78ef-783c-26ac-38b7-18cf4260d711")) == null) {
				Columns.Add(CreateUtmMediumStrColumn());
			}
			if (Columns.FindByUId(new Guid("df37a85c-6872-5ec5-d581-947559c9c3d8")) == null) {
				Columns.Add(CreateUtmContentStrColumn());
			}
			if (Columns.FindByUId(new Guid("755a521e-d7ea-1ef9-7fa5-7458708dbc3c")) == null) {
				Columns.Add(CreateUtmCampaignStrColumn());
			}
			if (Columns.FindByUId(new Guid("699ca8a2-46d7-111d-c16f-b8b7a6b57a86")) == null) {
				Columns.Add(CreatePlatformColumn());
			}
			if (Columns.FindByUId(new Guid("76303777-4460-dd41-c50c-9000807ab0dd")) == null) {
				Columns.Add(CreateDeviceColumn());
			}
			if (Columns.FindByUId(new Guid("b042d89a-3c47-1e79-1afb-e84ea64e2212")) == null) {
				Columns.Add(CreatePlatformStrColumn());
			}
			if (Columns.FindByUId(new Guid("9725ab52-5efa-d733-e12e-eac103a3e611")) == null) {
				Columns.Add(CreateLanguageStrColumn());
			}
			if (Columns.FindByUId(new Guid("7dfa06b7-7c73-ed1b-c4f4-04e303ded95b")) == null) {
				Columns.Add(CreateDeviceStrColumn());
			}
			if (Columns.FindByUId(new Guid("7c43539c-4ea0-eb2c-fc90-b16cf0c0b94b")) == null) {
				Columns.Add(CreateCountryStrColumn());
			}
			if (Columns.FindByUId(new Guid("5c562cd8-3aad-fed0-269d-0b6868d8d5d4")) == null) {
				Columns.Add(CreateCityStrColumn());
			}
			if (Columns.FindByUId(new Guid("eaa8ecb4-7e57-7bfd-18b7-dd2bcf306bc1")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("d022128f-a95c-d5a4-930d-4fb9c579e1aa")) == null) {
				Columns.Add(CreateCountryCodeColumn());
			}
			if (Columns.FindByUId(new Guid("bb62078b-d456-fea5-3488-c4ed7f53cf87")) == null) {
				Columns.Add(CreateRegionCodeColumn());
			}
			if (Columns.FindByUId(new Guid("d55823be-fe25-bf26-c015-d18e22b0a5c8")) == null) {
				Columns.Add(CreateRegionStrColumn());
			}
			if (Columns.FindByUId(new Guid("1a21cac6-a3d3-b24d-2836-ab4ba6f19932")) == null) {
				Columns.Add(CreateRegionColumn());
			}
			if (Columns.FindByUId(new Guid("7e9dd414-409e-4a22-378c-b3ac6468a929")) == null) {
				Columns.Add(CreateLocationColumn());
			}
			if (Columns.FindByUId(new Guid("a803809d-bc45-d357-1a52-50a5b7a1a529")) == null) {
				Columns.Add(CreateReferrerTypeStrColumn());
			}
			if (Columns.FindByUId(new Guid("5721e532-8d27-9015-48de-2a1eb4e0926d")) == null) {
				Columns.Add(CreateReferrerNameStrColumn());
			}
			if (Columns.FindByUId(new Guid("710bdb10-1216-de71-ee15-d90efe737862")) == null) {
				Columns.Add(CreateReferrerKeywordColumn());
			}
			if (Columns.FindByUId(new Guid("1d1ec990-91a2-7b0f-0ef1-a736c55b49e9")) == null) {
				Columns.Add(CreateReferrerUrlColumn());
			}
			if (Columns.FindByUId(new Guid("ed063589-f5dd-1569-922d-0680a60ea906")) == null) {
				Columns.Add(CreateReferrerTypeColumn());
			}
			if (Columns.FindByUId(new Guid("c60baccd-8d38-ccf6-7be7-d82f96068492")) == null) {
				Columns.Add(CreateReferrerNameColumn());
			}
			if (Columns.FindByUId(new Guid("e248b20f-3ed6-89e3-9612-81f30c235bff")) == null) {
				Columns.Add(CreateUtmIdStrColumn());
			}
			if (Columns.FindByUId(new Guid("ff946a34-1b1a-8f4a-a833-28bc82846b5e")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("3e7fef33-647b-0409-0648-2a60ad0d397e")) == null) {
				Columns.Add(CreateChannelColumn());
			}
			if (Columns.FindByUId(new Guid("70f795da-44a6-3038-fecc-558ce6932cc8")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("270d3f72-138e-dc36-5e7b-7025301fca30")) == null) {
				Columns.Add(CreateAccountEmployeesNumberColumn());
			}
			if (Columns.FindByUId(new Guid("7d0af04a-eca4-4140-4aa7-7e610cfdfce9")) == null) {
				Columns.Add(CreateAccountExactNoOfEmployeesColumn());
			}
			if (Columns.FindByUId(new Guid("2420e91a-594e-0978-4d7e-926df1bb8b19")) == null) {
				Columns.Add(CreateFacebookProfileUrlColumn());
			}
			if (Columns.FindByUId(new Guid("cd608d85-420f-31b1-866a-9fe9e067a075")) == null) {
				Columns.Add(CreateWebsiteColumn());
			}
			if (Columns.FindByUId(new Guid("e298f8ea-c262-9b75-85ec-6e95892f94d3")) == null) {
				Columns.Add(CreateLinkedInProfileUrlColumn());
			}
			if (Columns.FindByUId(new Guid("8d6eb347-c2fc-241c-30fb-3eeffd29bfdc")) == null) {
				Columns.Add(CreateSubIndustryColumn());
			}
			if (Columns.FindByUId(new Guid("c4f819ac-38af-ad49-71a4-d0015b553689")) == null) {
				Columns.Add(CreateIndustryColumn());
			}
			if (Columns.FindByUId(new Guid("ff2ec5d1-9c18-ae54-c9cc-6cf9231f6ac3")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("ed68034e-5aa2-55d6-e277-003d9e4247d2")) == null) {
				Columns.Add(CreateAccountNameTextColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dcce3f70-704b-9d25-1c34-7164eaf914bb"),
				Name = @"City",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreatePageReferrerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("27c20e65-ae81-62fe-7cd1-dff5aec1e544"),
				Name = @"PageReferrer",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a3000eb8-3285-8c3a-f3f5-be907b064bd0"),
				Name = @"Duration",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateDomainColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("587d6cf8-bc68-2cc8-9556-87f53ca11dc1"),
				Name = @"Domain",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cac4c7a1-0abd-456b-7f83-c78e8e9b3045"),
				Name = @"Language",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateIPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("aaad9878-8fd2-a514-e9a9-cdddf2bc44e8"),
				Name = @"IP",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("97c2062a-41f4-b9f7-ed78-cb8e7fc02b89"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7639c621-2038-8611-fc5a-990848141abc"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmTermStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3ee8b199-35ed-75fb-eeaf-07f49dc906a4"),
				Name = @"UtmTermStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmSourceStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ddc7e6ca-715a-5cfa-0b0a-4fdeb1337065"),
				Name = @"UtmSourceStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmMediumStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c23f78ef-783c-26ac-38b7-18cf4260d711"),
				Name = @"UtmMediumStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmContentStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("df37a85c-6872-5ec5-d581-947559c9c3d8"),
				Name = @"UtmContentStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmCampaignStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("755a521e-d7ea-1ef9-7fa5-7458708dbc3c"),
				Name = @"UtmCampaignStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreatePlatformColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("699ca8a2-46d7-111d-c16f-b8b7a6b57a86"),
				Name = @"Platform",
				ReferenceSchemaUId = new Guid("076b2d45-7daa-4e3a-a63a-7b95ab668afe"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateDeviceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("76303777-4460-dd41-c50c-9000807ab0dd"),
				Name = @"Device",
				ReferenceSchemaUId = new Guid("3c07afc6-fb87-493c-9303-7d3dbab690ad"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("29b8d471-9a85-14d5-a26e-6cda4d071c45"),
				Name = @"SessionId",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreatePlatformStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b042d89a-3c47-1e79-1afb-e84ea64e2212"),
				Name = @"PlatformStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguageStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9725ab52-5efa-d733-e12e-eac103a3e611"),
				Name = @"LanguageStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateDeviceStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7dfa06b7-7c73-ed1b-c4f4-04e303ded95b"),
				Name = @"DeviceStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateCountryStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7c43539c-4ea0-eb2c-fc90-b16cf0c0b94b"),
				Name = @"CountryStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateCityStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5c562cd8-3aad-fed0-269d-0b6868d8d5d4"),
				Name = @"CityStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("eaa8ecb4-7e57-7bfd-18b7-dd2bcf306bc1"),
				Name = @"StartDate",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateCountryCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d022128f-a95c-d5a4-930d-4fb9c579e1aa"),
				Name = @"CountryCode",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("bb62078b-d456-fea5-3488-c4ed7f53cf87"),
				Name = @"RegionCode",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d55823be-fe25-bf26-c015-d18e22b0a5c8"),
				Name = @"RegionStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a21cac6-a3d3-b24d-2836-ab4ba6f19932"),
				Name = @"Region",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateLocationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7e9dd414-409e-4a22-378c-b3ac6468a929"),
				Name = @"Location",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateReferrerTypeStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a803809d-bc45-d357-1a52-50a5b7a1a529"),
				Name = @"ReferrerTypeStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateReferrerNameStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5721e532-8d27-9015-48de-2a1eb4e0926d"),
				Name = @"ReferrerNameStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateReferrerKeywordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("710bdb10-1216-de71-ee15-d90efe737862"),
				Name = @"ReferrerKeyword",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateReferrerUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1d1ec990-91a2-7b0f-0ef1-a736c55b49e9"),
				Name = @"ReferrerUrl",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateReferrerTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ed063589-f5dd-1569-922d-0680a60ea906"),
				Name = @"ReferrerType",
				ReferenceSchemaUId = new Guid("0aa9fb42-d3d0-4981-841f-eed551db7db5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateReferrerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c60baccd-8d38-ccf6-7be7-d82f96068492"),
				Name = @"ReferrerName",
				ReferenceSchemaUId = new Guid("8dabc088-2beb-4667-9d8e-cd4651bcdb5b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmIdStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("e248b20f-3ed6-89e3-9612-81f30c235bff"),
				Name = @"UtmIdStr",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ff946a34-1b1a-8f4a-a833-28bc82846b5e"),
				Name = @"Source",
				ReferenceSchemaUId = new Guid("533025a5-cb29-46d5-935a-7e12616d69b6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("adeef8c7-14f0-4c40-90a0-5eb424823b07")
			};
		}

		protected virtual EntitySchemaColumn CreateChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3e7fef33-647b-0409-0648-2a60ad0d397e"),
				Name = @"Channel",
				ReferenceSchemaUId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("adeef8c7-14f0-4c40-90a0-5eb424823b07")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("70f795da-44a6-3038-fecc-558ce6932cc8"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateAccountEmployeesNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("270d3f72-138e-dc36-5e7b-7025301fca30"),
				Name = @"AccountEmployeesNumber",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountExactNoOfEmployeesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7d0af04a-eca4-4140-4aa7-7e610cfdfce9"),
				Name = @"AccountExactNoOfEmployees",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateFacebookProfileUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2420e91a-594e-0978-4d7e-926df1bb8b19"),
				Name = @"FacebookProfileUrl",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateWebsiteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cd608d85-420f-31b1-866a-9fe9e067a075"),
				Name = @"Website",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkedInProfileUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e298f8ea-c262-9b75-85ec-6e95892f94d3"),
				Name = @"LinkedInProfileUrl",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateSubIndustryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("8d6eb347-c2fc-241c-30fb-3eeffd29bfdc"),
				Name = @"SubIndustry",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateIndustryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c4f819ac-38af-ad49-71a4-d0015b553689"),
				Name = @"Industry",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ff2ec5d1-9c18-ae54-c9cc-6cf9231f6ac3"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountNameTextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ed68034e-5aa2-55d6-e277-003d9e4247d2"),
				Name = @"AccountNameText",
				CreatedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				ModifiedInSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				CreatedInPackageId = new Guid("8fa2fedf-477a-49c5-b16a-2ddd6c5f7040")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Touch(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Touch_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TouchSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TouchSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"));
		}

		#endregion

	}

	#endregion

	#region Class: Touch

	/// <summary>
	/// Web sessions.
	/// </summary>
	public class Touch : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Touch(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Touch";
		}

		public Touch(Touch source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// City.
		/// </summary>
		public City City {
			get {
				return _city ??
					(_city = LookupColumnEntities.GetEntity("City") as City);
			}
		}

		/// <summary>
		/// Page referrer URL.
		/// </summary>
		/// <remarks>
		/// URL of the previous webpage from which a link was followed.
		/// </remarks>
		public string PageReferrer {
			get {
				return GetTypedColumnValue<string>("PageReferrer");
			}
			set {
				SetColumnValue("PageReferrer", value);
			}
		}

		/// <summary>
		/// Web session duration, seconds.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Domain.
		/// </summary>
		public string Domain {
			get {
				return GetTypedColumnValue<string>("Domain");
			}
			set {
				SetColumnValue("Domain", value);
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
		/// Language.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = LookupColumnEntities.GetEntity("Language") as SysLanguage);
			}
		}

		/// <summary>
		/// IP address.
		/// </summary>
		public string IP {
			get {
				return GetTypedColumnValue<string>("IP");
			}
			set {
				SetColumnValue("IP", value);
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
		/// Country.
		/// </summary>
		public Country Country {
			get {
				return _country ??
					(_country = LookupColumnEntities.GetEntity("Country") as Country);
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
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// utm_term.
		/// </summary>
		/// <remarks>
		/// Identifies search terms.
		/// </remarks>
		public string UtmTermStr {
			get {
				return GetTypedColumnValue<string>("UtmTermStr");
			}
			set {
				SetColumnValue("UtmTermStr", value);
			}
		}

		/// <summary>
		/// utm_source.
		/// </summary>
		/// <remarks>
		/// Identifies which site sent the traffic, and is a required parameter.
		/// </remarks>
		public string UtmSourceStr {
			get {
				return GetTypedColumnValue<string>("UtmSourceStr");
			}
			set {
				SetColumnValue("UtmSourceStr", value);
			}
		}

		/// <summary>
		/// utm_medium.
		/// </summary>
		/// <remarks>
		/// Identifies what type of link was used, such as cost per click or email.
		/// </remarks>
		public string UtmMediumStr {
			get {
				return GetTypedColumnValue<string>("UtmMediumStr");
			}
			set {
				SetColumnValue("UtmMediumStr", value);
			}
		}

		/// <summary>
		/// utm_content.
		/// </summary>
		/// <remarks>
		/// Identifies what specifically was clicked to bring the user to the site, such as a banner ad or a text link. It is often used for A/B testing and content-targeted ads.
		/// </remarks>
		public string UtmContentStr {
			get {
				return GetTypedColumnValue<string>("UtmContentStr");
			}
			set {
				SetColumnValue("UtmContentStr", value);
			}
		}

		/// <summary>
		/// utm_campaign.
		/// </summary>
		/// <remarks>
		/// Identifies a specific product promotion or strategic campaign.
		/// </remarks>
		public string UtmCampaignStr {
			get {
				return GetTypedColumnValue<string>("UtmCampaignStr");
			}
			set {
				SetColumnValue("UtmCampaignStr", value);
			}
		}

		/// <exclude/>
		public Guid PlatformId {
			get {
				return GetTypedColumnValue<Guid>("PlatformId");
			}
			set {
				SetColumnValue("PlatformId", value);
				_platform = null;
			}
		}

		/// <exclude/>
		public string PlatformName {
			get {
				return GetTypedColumnValue<string>("PlatformName");
			}
			set {
				SetColumnValue("PlatformName", value);
				if (_platform != null) {
					_platform.Name = value;
				}
			}
		}

		private TouchPlatform _platform;
		/// <summary>
		/// Platform.
		/// </summary>
		public TouchPlatform Platform {
			get {
				return _platform ??
					(_platform = LookupColumnEntities.GetEntity("Platform") as TouchPlatform);
			}
		}

		/// <exclude/>
		public Guid DeviceId {
			get {
				return GetTypedColumnValue<Guid>("DeviceId");
			}
			set {
				SetColumnValue("DeviceId", value);
				_device = null;
			}
		}

		/// <exclude/>
		public string DeviceName {
			get {
				return GetTypedColumnValue<string>("DeviceName");
			}
			set {
				SetColumnValue("DeviceName", value);
				if (_device != null) {
					_device.Name = value;
				}
			}
		}

		private TouchDevice _device;
		/// <summary>
		/// Device.
		/// </summary>
		public TouchDevice Device {
			get {
				return _device ??
					(_device = LookupColumnEntities.GetEntity("Device") as TouchDevice);
			}
		}

		/// <summary>
		/// Session.
		/// </summary>
		public string SessionId {
			get {
				return GetTypedColumnValue<string>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Platform (string).
		/// </summary>
		public string PlatformStr {
			get {
				return GetTypedColumnValue<string>("PlatformStr");
			}
			set {
				SetColumnValue("PlatformStr", value);
			}
		}

		/// <summary>
		/// Language (string).
		/// </summary>
		public string LanguageStr {
			get {
				return GetTypedColumnValue<string>("LanguageStr");
			}
			set {
				SetColumnValue("LanguageStr", value);
			}
		}

		/// <summary>
		/// Device (string).
		/// </summary>
		public string DeviceStr {
			get {
				return GetTypedColumnValue<string>("DeviceStr");
			}
			set {
				SetColumnValue("DeviceStr", value);
			}
		}

		/// <summary>
		/// Country (string).
		/// </summary>
		public string CountryStr {
			get {
				return GetTypedColumnValue<string>("CountryStr");
			}
			set {
				SetColumnValue("CountryStr", value);
			}
		}

		/// <summary>
		/// City (string).
		/// </summary>
		public string CityStr {
			get {
				return GetTypedColumnValue<string>("CityStr");
			}
			set {
				SetColumnValue("CityStr", value);
			}
		}

		/// <summary>
		/// Session start date.
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
		/// Country code.
		/// </summary>
		public string CountryCode {
			get {
				return GetTypedColumnValue<string>("CountryCode");
			}
			set {
				SetColumnValue("CountryCode", value);
			}
		}

		/// <summary>
		/// Region code.
		/// </summary>
		public string RegionCode {
			get {
				return GetTypedColumnValue<string>("RegionCode");
			}
			set {
				SetColumnValue("RegionCode", value);
			}
		}

		/// <summary>
		/// Region (string).
		/// </summary>
		public string RegionStr {
			get {
				return GetTypedColumnValue<string>("RegionStr");
			}
			set {
				SetColumnValue("RegionStr", value);
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
		/// Region.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = LookupColumnEntities.GetEntity("Region") as Region);
			}
		}

		/// <summary>
		/// Location.
		/// </summary>
		public string Location {
			get {
				return GetTypedColumnValue<string>("Location");
			}
			set {
				SetColumnValue("Location", value);
			}
		}

		/// <summary>
		/// Referrer type (string).
		/// </summary>
		public string ReferrerTypeStr {
			get {
				return GetTypedColumnValue<string>("ReferrerTypeStr");
			}
			set {
				SetColumnValue("ReferrerTypeStr", value);
			}
		}

		/// <summary>
		/// Referrer name (string).
		/// </summary>
		public string ReferrerNameStr {
			get {
				return GetTypedColumnValue<string>("ReferrerNameStr");
			}
			set {
				SetColumnValue("ReferrerNameStr", value);
			}
		}

		/// <summary>
		/// Referrer keyword.
		/// </summary>
		public string ReferrerKeyword {
			get {
				return GetTypedColumnValue<string>("ReferrerKeyword");
			}
			set {
				SetColumnValue("ReferrerKeyword", value);
			}
		}

		/// <summary>
		/// Referrer URL.
		/// </summary>
		public string ReferrerUrl {
			get {
				return GetTypedColumnValue<string>("ReferrerUrl");
			}
			set {
				SetColumnValue("ReferrerUrl", value);
			}
		}

		/// <exclude/>
		public Guid ReferrerTypeId {
			get {
				return GetTypedColumnValue<Guid>("ReferrerTypeId");
			}
			set {
				SetColumnValue("ReferrerTypeId", value);
				_referrerType = null;
			}
		}

		/// <exclude/>
		public string ReferrerTypeName {
			get {
				return GetTypedColumnValue<string>("ReferrerTypeName");
			}
			set {
				SetColumnValue("ReferrerTypeName", value);
				if (_referrerType != null) {
					_referrerType.Name = value;
				}
			}
		}

		private ReferrerType _referrerType;
		/// <summary>
		/// Referrer type.
		/// </summary>
		public ReferrerType ReferrerType {
			get {
				return _referrerType ??
					(_referrerType = LookupColumnEntities.GetEntity("ReferrerType") as ReferrerType);
			}
		}

		/// <exclude/>
		public Guid ReferrerNameId {
			get {
				return GetTypedColumnValue<Guid>("ReferrerNameId");
			}
			set {
				SetColumnValue("ReferrerNameId", value);
				_referrerName = null;
			}
		}

		/// <exclude/>
		public string ReferrerNameName {
			get {
				return GetTypedColumnValue<string>("ReferrerNameName");
			}
			set {
				SetColumnValue("ReferrerNameName", value);
				if (_referrerName != null) {
					_referrerName.Name = value;
				}
			}
		}

		private ReferrerName _referrerName;
		/// <summary>
		/// Referrer name.
		/// </summary>
		public ReferrerName ReferrerName {
			get {
				return _referrerName ??
					(_referrerName = LookupColumnEntities.GetEntity("ReferrerName") as ReferrerName);
			}
		}

		/// <summary>
		/// utm_id.
		/// </summary>
		public string UtmIdStr {
			get {
				return GetTypedColumnValue<string>("UtmIdStr");
			}
			set {
				SetColumnValue("UtmIdStr", value);
			}
		}

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private LeadSource _source;
		/// <summary>
		/// Source.
		/// </summary>
		public LeadSource Source {
			get {
				return _source ??
					(_source = LookupColumnEntities.GetEntity("Source") as LeadSource);
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

		private LeadMedium _channel;
		/// <summary>
		/// Channel.
		/// </summary>
		public LeadMedium Channel {
			get {
				return _channel ??
					(_channel = LookupColumnEntities.GetEntity("Channel") as LeadMedium);
			}
		}

		/// <summary>
		/// Notes.
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
		/// No. of employees (range).
		/// </summary>
		public string AccountEmployeesNumber {
			get {
				return GetTypedColumnValue<string>("AccountEmployeesNumber");
			}
			set {
				SetColumnValue("AccountEmployeesNumber", value);
			}
		}

		/// <summary>
		/// Exact number of employees.
		/// </summary>
		public string AccountExactNoOfEmployees {
			get {
				return GetTypedColumnValue<string>("AccountExactNoOfEmployees");
			}
			set {
				SetColumnValue("AccountExactNoOfEmployees", value);
			}
		}

		/// <summary>
		/// Facebook profile.
		/// </summary>
		public string FacebookProfileUrl {
			get {
				return GetTypedColumnValue<string>("FacebookProfileUrl");
			}
			set {
				SetColumnValue("FacebookProfileUrl", value);
			}
		}

		/// <summary>
		/// Website.
		/// </summary>
		public string Website {
			get {
				return GetTypedColumnValue<string>("Website");
			}
			set {
				SetColumnValue("Website", value);
			}
		}

		/// <summary>
		/// LinkedIn profile.
		/// </summary>
		public string LinkedInProfileUrl {
			get {
				return GetTypedColumnValue<string>("LinkedInProfileUrl");
			}
			set {
				SetColumnValue("LinkedInProfileUrl", value);
			}
		}

		/// <summary>
		/// SubIndustry.
		/// </summary>
		public string SubIndustry {
			get {
				return GetTypedColumnValue<string>("SubIndustry");
			}
			set {
				SetColumnValue("SubIndustry", value);
			}
		}

		/// <summary>
		/// Industry.
		/// </summary>
		public string Industry {
			get {
				return GetTypedColumnValue<string>("Industry");
			}
			set {
				SetColumnValue("Industry", value);
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
		/// Account name.
		/// </summary>
		public string AccountNameText {
			get {
				return GetTypedColumnValue<string>("AccountNameText");
			}
			set {
				SetColumnValue("AccountNameText", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Touch_TouchPointsEventsProcess(UserConnection);
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
			return new Touch(this);
		}

		#endregion

	}

	#endregion

	#region Class: Touch_TouchPointsEventsProcess

	/// <exclude/>
	public partial class Touch_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Touch
	{

		public Touch_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Touch_TouchPointsEventsProcess";
			SchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda");
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

	#region Class: Touch_TouchPointsEventsProcess

	/// <exclude/>
	public class Touch_TouchPointsEventsProcess : Touch_TouchPointsEventsProcess<Touch>
	{

		public Touch_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Touch_TouchPointsEventsProcess

	public partial class Touch_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TouchEventsProcess

	/// <exclude/>
	public class TouchEventsProcess : Touch_TouchPointsEventsProcess
	{

		public TouchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

