namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.DynamicContent;
	using BPMSoft.Configuration.DynamicContent.Models;
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

	#region Class: BulkEmailSchema

	/// <exclude/>
	public class BulkEmailSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailSchema(BulkEmailSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailSchema(BulkEmailSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8");
			RealUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8");
			Name = "BulkEmail";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
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
			if (Columns.FindByUId(new Guid("179852a9-99a4-40d7-9a0d-1b1354528eab")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("ba9154c4-cbaf-44bc-a613-fc75abe5d0e4")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("61488596-901e-457a-b02d-c2fea49f75c3")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("eedcc192-9bd0-4870-b471-e2935e03e269")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("bb7976b3-0b0a-4623-bf51-f7d5d7127b24")) == null) {
				Columns.Add(CreateSenderNameColumn());
			}
			if (Columns.FindByUId(new Guid("a7b7ea13-8870-409d-8dec-d91dcef2770f")) == null) {
				Columns.Add(CreateSenderEmailColumn());
			}
			if (Columns.FindByUId(new Guid("ea0bf113-a0a3-4b5c-b3b7-c82f8f10c610")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("93fd7ba3-6f59-4bb6-b242-54fbb8c960a8")) == null) {
				Columns.Add(CreateSendStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("4098b376-f4a4-43b9-9c2a-83a0ed5bb111")) == null) {
				Columns.Add(CreateSendDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("ea77b054-19e8-4f5a-acad-426389d56b27")) == null) {
				Columns.Add(CreateClicksColumn());
			}
			if (Columns.FindByUId(new Guid("2b38e45b-4d3e-4f8b-94e6-e2f6a2286c9b")) == null) {
				Columns.Add(CreateOpensColumn());
			}
			if (Columns.FindByUId(new Guid("f220825a-b9e8-439b-9379-a9abc4784ecb")) == null) {
				Columns.Add(CreateSoftBounceColumn());
			}
			if (Columns.FindByUId(new Guid("08ad2aad-2a2f-485c-a056-3575826d5856")) == null) {
				Columns.Add(CreateHardBounceColumn());
			}
			if (Columns.FindByUId(new Guid("538a2dca-73f7-4535-bc5c-80d2a1dac4d7")) == null) {
				Columns.Add(CreateUnsubscribeColumn());
			}
			if (Columns.FindByUId(new Guid("60c0d829-5d8b-4b3c-9941-5ea47ba88aa5")) == null) {
				Columns.Add(CreateSpamColumn());
			}
			if (Columns.FindByUId(new Guid("69026123-bf84-463f-b512-d0e138aaa535")) == null) {
				Columns.Add(CreateClicksCountColumn());
			}
			if (Columns.FindByUId(new Guid("0b997f26-118b-422c-85c8-665334844ad5")) == null) {
				Columns.Add(CreateOpensCountColumn());
			}
			if (Columns.FindByUId(new Guid("7340a01b-ae07-471d-96f0-c3e59cb5a506")) == null) {
				Columns.Add(CreateSoftBounceCountColumn());
			}
			if (Columns.FindByUId(new Guid("93d105bd-60a0-44bd-9d51-82e5b55c0b28")) == null) {
				Columns.Add(CreateHardBounceCountColumn());
			}
			if (Columns.FindByUId(new Guid("c19c69e9-a4f5-4967-82fc-c4ae2169e56f")) == null) {
				Columns.Add(CreateUnsubscribeCountColumn());
			}
			if (Columns.FindByUId(new Guid("3ad234c8-e65c-4261-bd4f-dd5153614592")) == null) {
				Columns.Add(CreateSpamCountColumn());
			}
			if (Columns.FindByUId(new Guid("31c0c36e-2d17-41fb-b60a-9ced9d6114da")) == null) {
				Columns.Add(CreateSegmentsStatusColumn());
			}
			if (Columns.FindByUId(new Guid("2c873902-d974-4c19-8ff7-b33beebe0337")) == null) {
				Columns.Add(CreateRecipientCountColumn());
			}
			if (Columns.FindByUId(new Guid("da45936d-12c4-44f5-9dbf-93dccfcb27bc")) == null) {
				Columns.Add(CreateLastActualizeDateColumn());
			}
			if (Columns.FindByUId(new Guid("3e65fbaf-d5dd-431d-a2b9-2badabbaacf5")) == null) {
				Columns.Add(CreateTemplateSubjectColumn());
			}
			if (Columns.FindByUId(new Guid("9ec4de0a-6c4f-4634-b5af-df256380edb7")) == null) {
				Columns.Add(CreateTemplateBodyColumn());
			}
			if (Columns.FindByUId(new Guid("b5ee5edb-5d5b-4438-be3c-ba043ef3f561")) == null) {
				Columns.Add(CreateDeliveredCountColumn());
			}
			if (Columns.FindByUId(new Guid("46e0c161-0fd6-4300-9bdd-eb4f68dcbe34")) == null) {
				Columns.Add(CreateNotDeliveredCountColumn());
			}
			if (Columns.FindByUId(new Guid("d224320e-5b42-4e13-afe3-27eb41d49285")) == null) {
				Columns.Add(CreateInQueueCountColumn());
			}
			if (Columns.FindByUId(new Guid("4084cb33-7820-4578-b8b9-87ced0ca3b9d")) == null) {
				Columns.Add(CreateCanceledCountColumn());
			}
			if (Columns.FindByUId(new Guid("b1896082-56f9-4cf8-aedb-25ff3dfc2727")) == null) {
				Columns.Add(CreateBlankEmailCountColumn());
			}
			if (Columns.FindByUId(new Guid("9d65ede6-b98b-455a-821b-90cf0e7cd064")) == null) {
				Columns.Add(CreateIncorrectEmailCountColumn());
			}
			if (Columns.FindByUId(new Guid("ca45c924-d210-40ce-9b87-b720a73a3040")) == null) {
				Columns.Add(CreateUnreachableEmailCountColumn());
			}
			if (Columns.FindByUId(new Guid("e2a193cf-9dd4-4246-9d53-49daeadf5892")) == null) {
				Columns.Add(CreateDoNotUseEmailCountColumn());
			}
			if (Columns.FindByUId(new Guid("ad9e52d0-1f2b-442c-b960-ce42914243ca")) == null) {
				Columns.Add(CreateUnsubscribedByTypeCountColumn());
			}
			if (Columns.FindByUId(new Guid("efa2e7d3-8633-4a52-a400-30924f08f0f4")) == null) {
				Columns.Add(CreateDuplicateEmailCountColumn());
			}
			if (Columns.FindByUId(new Guid("89232498-d4f6-4b83-b20d-2572c1571f85")) == null) {
				Columns.Add(CreateRejectedCountColumn());
			}
			if (Columns.FindByUId(new Guid("2a285982-5a92-48f1-b639-8479545c4721")) == null) {
				Columns.Add(CreateCommonErrorCountColumn());
			}
			if (Columns.FindByUId(new Guid("2c1e0609-ac0a-4c38-b860-8f5388f297d7")) == null) {
				Columns.Add(CreateInvalidAddresseeCountColumn());
			}
			if (Columns.FindByUId(new Guid("eae57226-68ed-4856-8246-c5ec4606529b")) == null) {
				Columns.Add(CreatePercentWeightColumn());
			}
			if (Columns.FindByUId(new Guid("c2a9de1b-9bd4-44bb-b3ac-7d4448d346d0")) == null) {
				Columns.Add(CreatePercentActiveWeightColumn());
			}
			if (Columns.FindByUId(new Guid("d785e098-20e4-438e-9a96-ac93fb86a156")) == null) {
				Columns.Add(CreatePercentInactiveWeightColumn());
			}
			if (Columns.FindByUId(new Guid("2a905616-fe78-440c-b1fb-d046b98410ee")) == null) {
				Columns.Add(CreateSendCountColumn());
			}
			if (Columns.FindByUId(new Guid("0006f192-a00c-4372-82d8-24df40e8782e")) == null) {
				Columns.Add(CreateCommunicationLimitCountColumn());
			}
			if (Columns.FindByUId(new Guid("b2d54128-352b-409c-8d9f-864222172044")) == null) {
				Columns.Add(CreateUtmSourceColumn());
			}
			if (Columns.FindByUId(new Guid("545c4f53-5c13-4c18-99b3-12713feafb07")) == null) {
				Columns.Add(CreateUtmMediumColumn());
			}
			if (Columns.FindByUId(new Guid("6a54fc79-6db3-495e-8752-c15f3de1371f")) == null) {
				Columns.Add(CreateUtmCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("d145dfd4-03eb-4bd1-ae1a-ec1046c2290c")) == null) {
				Columns.Add(CreateUtmTermColumn());
			}
			if (Columns.FindByUId(new Guid("c0ecb652-be4e-4e14-91a1-dc17c4eabe25")) == null) {
				Columns.Add(CreateUtmContentColumn());
			}
			if (Columns.FindByUId(new Guid("c38d1340-1f04-4106-893b-c123256082ed")) == null) {
				Columns.Add(CreateDomainsColumn());
			}
			if (Columns.FindByUId(new Guid("71c597c9-94dd-4efe-b2d9-d6989621653a")) == null) {
				Columns.Add(CreateUseUtmColumn());
			}
			if (Columns.FindByUId(new Guid("6f3b2c62-03a2-4a6a-802b-5c3445e6b534")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("271d3ef0-6520-479c-8067-5b212d91e534")) == null) {
				Columns.Add(CreateStatisticDateColumn());
			}
			if (Columns.FindByUId(new Guid("5d100c2f-01b7-4216-9bf7-6bf20af49d30")) == null) {
				Columns.Add(CreateResponseProcessingCompletedColumn());
			}
			if (Columns.FindByUId(new Guid("70e14aa1-d9f5-4b73-b59e-22d5513d3dd8")) == null) {
				Columns.Add(CreateSplitTestColumn());
			}
			if (Columns.FindByUId(new Guid("e38eb3e2-20d5-4b11-aa34-c2fe23348070")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("c5bf86d5-4624-4470-b6b1-0d3d8755dba1")) == null) {
				Columns.Add(CreateLaunchOptionColumn());
			}
			if (Columns.FindByUId(new Guid("167e049c-00ae-41c5-bfc2-856eae2880c9")) == null) {
				Columns.Add(CreateTemplateConfigColumn());
			}
			if (Columns.FindByUId(new Guid("7030ab07-36cf-4227-8bce-55f97a1e5120")) == null) {
				Columns.Add(CreateDeliveryErrorColumn());
			}
			if (Columns.FindByUId(new Guid("467b5d60-a7b3-4cf2-b607-0b77bc504ff9")) == null) {
				Columns.Add(CreateIsSystemEmailColumn());
			}
			if (Columns.FindByUId(new Guid("f986de1b-eccd-4409-a145-a7ef9d4116c3")) == null) {
				Columns.Add(CreateTemplateNotFoundCountColumn());
			}
			if (Columns.FindByUId(new Guid("1f2d242f-785a-4c0f-9942-6caac23d668a")) == null) {
				Columns.Add(CreateSendersDomainNotVerifiedCountColumn());
			}
			if (Columns.FindByUId(new Guid("2d960dec-c57c-4412-8667-022cbacf5373")) == null) {
				Columns.Add(CreateSendersNameNotValidCountColumn());
			}
			if (Columns.FindByUId(new Guid("2f9ae67f-dd2a-457c-80e5-5fe0882a88e8")) == null) {
				Columns.Add(CreateAudienceSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("9734ab99-efb5-46bc-b625-a52b9951bfd9")) == null) {
				Columns.Add(CreateIsAudienceInitedColumn());
			}
			if (Columns.FindByUId(new Guid("e19995c0-0799-7e7b-ba0a-1befde6c131d")) == null) {
				Columns.Add(CreateThrottlingModeColumn());
			}
			if (Columns.FindByUId(new Guid("9a8c9082-ccfd-394e-df50-de23c790054a")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("0a35dfc6-dcb9-1fd0-44c9-f90622cf4b40")) == null) {
				Columns.Add(CreateExpirationDateColumn());
			}
			if (Columns.FindByUId(new Guid("b8421a17-59a8-5353-5ec0-e8c67221a5f2")) == null) {
				Columns.Add(CreateBusinessTimeEndColumn());
			}
			if (Columns.FindByUId(new Guid("92815ba2-919c-b6e1-b095-408aab9fb28e")) == null) {
				Columns.Add(CreateBusinessTimeStartColumn());
			}
			if (Columns.FindByUId(new Guid("91e53dbc-866a-7934-ff55-9e5558359b90")) == null) {
				Columns.Add(CreateDeliveryScheduleDaysColumn());
			}
			if (Columns.FindByUId(new Guid("54749ce9-d65e-229d-8739-65f7ea97fdf1")) == null) {
				Columns.Add(CreateDeliveryScheduleColumn());
			}
			if (Columns.FindByUId(new Guid("253496e7-cad2-1027-1cb0-fa4dd7181bcc")) == null) {
				Columns.Add(CreateThrottlingQueueColumn());
			}
			if (Columns.FindByUId(new Guid("416be0a3-2703-e665-d832-7170d3e909b1")) == null) {
				Columns.Add(CreateExpiredCountColumn());
			}
			if (Columns.FindByUId(new Guid("c84180d9-e4a3-ce6d-8920-093e20f33445")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
			if (Columns.FindByUId(new Guid("6fb691c3-9a6c-3859-b9c1-18a9dca54e82")) == null) {
				Columns.Add(CreateStoppedSummaryCountColumn());
			}
			if (Columns.FindByUId(new Guid("3dfd79d6-54ec-3be5-a6c8-aaea068daca2")) == null) {
				Columns.Add(CreateStoppedManuallyCountColumn());
			}
			if (Columns.FindByUId(new Guid("6b07e6b6-00d4-726e-9f72-870285fe5597")) == null) {
				Columns.Add(CreateStoppedInProviderCountColumn());
			}
			if (Columns.FindByUId(new Guid("d9d80b39-8f01-0cd9-cd13-5e1397a56765")) == null) {
				Columns.Add(CreateExpiredSummaryCountColumn());
			}
			if (Columns.FindByUId(new Guid("5177a1fb-d654-4a2b-8b2c-75d5f1010b6b")) == null) {
				Columns.Add(CreateExpiredInProviderCountColumn());
			}
			if (Columns.FindByUId(new Guid("443ae6ca-2069-ac9e-9a32-1c44118a64f5")) == null) {
				Columns.Add(CreateDelayBetweenEmailColumn());
			}
			if (Columns.FindByUId(new Guid("8019ee41-ff67-82fa-a872-e704b374d38d")) == null) {
				Columns.Add(CreateDailyLimitColumn());
			}
			if (Columns.FindByUId(new Guid("2e0f5a7b-6245-49eb-8cfc-a8c27a93ece6")) == null) {
				Columns.Add(CreateProviderNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("975137ab-181c-4e96-b4d9-66e55474b28d"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("179852a9-99a4-40d7-9a0d-1b1354528eab"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ba9154c4-cbaf-44bc-a613-fc75abe5d0e4"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2909d41f-2797-4c45-9f3f-9835eb88e515"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("61488596-901e-457a-b02d-c2fea49f75c3"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"32848d61-3792-4b06-a183-eaf1d1769897"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("eedcc192-9bd0-4870-b471-e2935e03e269"),
				Name = @"StartDate",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bb7976b3-0b0a-4623-bf51-f7d5d7127b24"),
				Name = @"SenderName",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a7b7ea13-8870-409d-8dec-d91dcef2770f"),
				Name = @"SenderEmail",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ea0bf113-a0a3-4b5c-b3b7-c82f8f10c610"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateSendStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("93fd7ba3-6f59-4bb6-b242-54fbb8c960a8"),
				Name = @"SendStartDate",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected virtual EntitySchemaColumn CreateSendDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("4098b376-f4a4-43b9-9c2a-83a0ed5bb111"),
				Name = @"SendDueDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected virtual EntitySchemaColumn CreateClicksColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("ea77b054-19e8-4f5a-acad-426389d56b27"),
				Name = @"Clicks",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateOpensColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("2b38e45b-4d3e-4f8b-94e6-e2f6a2286c9b"),
				Name = @"Opens",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateSoftBounceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("f220825a-b9e8-439b-9379-a9abc4784ecb"),
				Name = @"SoftBounce",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateHardBounceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("08ad2aad-2a2f-485c-a056-3575826d5856"),
				Name = @"HardBounce",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateUnsubscribeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("538a2dca-73f7-4535-bc5c-80d2a1dac4d7"),
				Name = @"Unsubscribe",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateSpamColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("60c0d829-5d8b-4b3c-9941-5ea47ba88aa5"),
				Name = @"Spam",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateClicksCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("69026123-bf84-463f-b512-d0e138aaa535"),
				Name = @"ClicksCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateOpensCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0b997f26-118b-422c-85c8-665334844ad5"),
				Name = @"OpensCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateSoftBounceCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7340a01b-ae07-471d-96f0-c3e59cb5a506"),
				Name = @"SoftBounceCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateHardBounceCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("93d105bd-60a0-44bd-9d51-82e5b55c0b28"),
				Name = @"HardBounceCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateUnsubscribeCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c19c69e9-a4f5-4967-82fc-c4ae2169e56f"),
				Name = @"UnsubscribeCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateSpamCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3ad234c8-e65c-4261-bd4f-dd5153614592"),
				Name = @"SpamCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateSegmentsStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("31c0c36e-2d17-41fb-b60a-9ced9d6114da"),
				Name = @"SegmentsStatus",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"fa360d2c-1658-49ad-9152-22479fdc0c12"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2c873902-d974-4c19-8ff7-b33beebe0337"),
				Name = @"RecipientCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLastActualizeDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("da45936d-12c4-44f5-9dbf-93dccfcb27bc"),
				Name = @"LastActualizeDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("8ff9fe4f-03be-4db5-b64a-71abfee30f54")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateSubjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3e65fbaf-d5dd-431d-a2b9-2badabbaacf5"),
				Name = @"TemplateSubject",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("23e6b872-7cf2-4336-8046-3b06c9b28cbc")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9ec4de0a-6c4f-4634-b5af-df256380edb7"),
				Name = @"TemplateBody",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("f00632d3-aaec-4e50-866a-0cdd26a022a6"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateDeliveredCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b5ee5edb-5d5b-4438-be3c-ba043ef3f561"),
				Name = @"DeliveredCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("2c3183e7-3de0-4a25-b7f0-d9d1c3360565")
			};
		}

		protected virtual EntitySchemaColumn CreateNotDeliveredCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("46e0c161-0fd6-4300-9bdd-eb4f68dcbe34"),
				Name = @"NotDeliveredCount",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("2c3183e7-3de0-4a25-b7f0-d9d1c3360565")
			};
		}

		protected virtual EntitySchemaColumn CreateInQueueCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d224320e-5b42-4e13-afe3-27eb41d49285"),
				Name = @"InQueueCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("2c3183e7-3de0-4a25-b7f0-d9d1c3360565")
			};
		}

		protected virtual EntitySchemaColumn CreateCanceledCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("4084cb33-7820-4578-b8b9-87ced0ca3b9d"),
				Name = @"CanceledCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreateBlankEmailCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b1896082-56f9-4cf8-aedb-25ff3dfc2727"),
				Name = @"BlankEmailCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateIncorrectEmailCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9d65ede6-b98b-455a-821b-90cf0e7cd064"),
				Name = @"IncorrectEmailCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateUnreachableEmailCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ca45c924-d210-40ce-9b87-b720a73a3040"),
				Name = @"UnreachableEmailCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateDoNotUseEmailCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e2a193cf-9dd4-4246-9d53-49daeadf5892"),
				Name = @"DoNotUseEmailCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateUnsubscribedByTypeCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ad9e52d0-1f2b-442c-b960-ce42914243ca"),
				Name = @"UnsubscribedByTypeCount",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateDuplicateEmailCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("efa2e7d3-8633-4a52-a400-30924f08f0f4"),
				Name = @"DuplicateEmailCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateRejectedCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("89232498-d4f6-4b83-b20d-2572c1571f85"),
				Name = @"RejectedCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreateCommonErrorCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2a285982-5a92-48f1-b639-8479545c4721"),
				Name = @"CommonErrorCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreateInvalidAddresseeCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2c1e0609-ac0a-4c38-b860-8f5388f297d7"),
				Name = @"InvalidAddresseeCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreatePercentWeightColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("eae57226-68ed-4856-8246-c5ec4606529b"),
				Name = @"PercentWeight",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreatePercentActiveWeightColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c2a9de1b-9bd4-44bb-b3ac-7d4448d346d0"),
				Name = @"PercentActiveWeight",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreatePercentInactiveWeightColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("d785e098-20e4-438e-9a96-ac93fb86a156"),
				Name = @"PercentInactiveWeight",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreateSendCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2a905616-fe78-440c-b1fb-d046b98410ee"),
				Name = @"SendCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a2630389-bac5-4784-8917-9f3e3f8725d4")
			};
		}

		protected virtual EntitySchemaColumn CreateCommunicationLimitCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0006f192-a00c-4372-82d8-24df40e8782e"),
				Name = @"CommunicationLimitCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("b2d54128-352b-409c-8d9f-864222172044"),
				Name = @"UtmSource",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("adf55717-cd89-44d1-9a17-d38a4b5e7c12")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmMediumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("545c4f53-5c13-4c18-99b3-12713feafb07"),
				Name = @"UtmMedium",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("adf55717-cd89-44d1-9a17-d38a4b5e7c12")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("6a54fc79-6db3-495e-8752-c15f3de1371f"),
				Name = @"UtmCampaign",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("adf55717-cd89-44d1-9a17-d38a4b5e7c12")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmTermColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d145dfd4-03eb-4bd1-ae1a-ec1046c2290c"),
				Name = @"UtmTerm",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("adf55717-cd89-44d1-9a17-d38a4b5e7c12")
			};
		}

		protected virtual EntitySchemaColumn CreateUtmContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c0ecb652-be4e-4e14-91a1-dc17c4eabe25"),
				Name = @"UtmContent",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("adf55717-cd89-44d1-9a17-d38a4b5e7c12")
			};
		}

		protected virtual EntitySchemaColumn CreateDomainsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c38d1340-1f04-4106-893b-c123256082ed"),
				Name = @"Domains",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("adf55717-cd89-44d1-9a17-d38a4b5e7c12")
			};
		}

		protected virtual EntitySchemaColumn CreateUseUtmColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("71c597c9-94dd-4efe-b2d9-d6989621653a"),
				Name = @"UseUtm",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("adf55717-cd89-44d1-9a17-d38a4b5e7c12")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f3b2c62-03a2-4a6a-802b-5c3445e6b534"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("33ac637b-a93c-4dbe-96cf-f1afd79bdc1c")
			};
		}

		protected virtual EntitySchemaColumn CreateStatisticDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("271d3ef0-6520-479c-8067-5b212d91e534"),
				Name = @"StatisticDate",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected virtual EntitySchemaColumn CreateResponseProcessingCompletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5d100c2f-01b7-4216-9bf7-6bf20af49d30"),
				Name = @"ResponseProcessingCompleted",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			};
		}

		protected virtual EntitySchemaColumn CreateSplitTestColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("70e14aa1-d9f5-4b73-b59e-22d5513d3dd8"),
				Name = @"SplitTest",
				ReferenceSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e38eb3e2-20d5-4b11-aa34-c2fe23348070"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("13cffa88-d296-4202-8bee-d023d51a8454"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("d6fec08a-2746-46b6-a96c-0a31e271957f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"8cec06ed-2643-46f7-ab00-352acbc3bd8a"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLaunchOptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c5bf86d5-4624-4470-b6b1-0d3d8755dba1"),
				Name = @"LaunchOption",
				ReferenceSchemaUId = new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("167e049c-00ae-41c5-bfc2-856eae2880c9"),
				Name = @"TemplateConfig",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855")
			};
		}

		protected virtual EntitySchemaColumn CreateDeliveryErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7030ab07-36cf-4227-8bce-55f97a1e5120"),
				Name = @"DeliveryError",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("fa13654a-18fd-4552-95cb-2194666647a5"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsSystemEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("467b5d60-a7b3-4cf2-b607-0b77bc504ff9"),
				Name = @"IsSystemEmail",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("fa13654a-18fd-4552-95cb-2194666647a5")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateNotFoundCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f986de1b-eccd-4409-a145-a7ef9d4116c3"),
				Name = @"TemplateNotFoundCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateSendersDomainNotVerifiedCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1f2d242f-785a-4c0f-9942-6caac23d668a"),
				Name = @"SendersDomainNotVerifiedCount",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateSendersNameNotValidCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2d960dec-c57c-4412-8667-022cbacf5373"),
				Name = @"SendersNameNotValidCount",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateAudienceSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2f9ae67f-dd2a-457c-80e5-5fe0882a88e8"),
				Name = @"AudienceSchema",
				ReferenceSchemaUId = new Guid("ee825389-76df-4c88-b91c-f43d7fc15a32"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2db96695-3d62-40e4-9f31-2f1fff23eefb"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsAudienceInitedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9734ab99-efb5-46bc-b625-a52b9951bfd9"),
				Name = @"IsAudienceInited",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateThrottlingModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e19995c0-0799-7e7b-ba0a-1befde6c131d"),
				Name = @"ThrottlingMode",
				ReferenceSchemaUId = new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"8bfdb047-5833-4498-8365-5b83f3f1fd63"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9a8c9082-ccfd-394e-df50-de23c790054a"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("5c382e01-49bd-8855-4a42-dc1d5b4d4569"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"7f472a85-9865-4a56-96d2-f6decb26e0ca"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateExpirationDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("0a35dfc6-dcb9-1fd0-44c9-f90622cf4b40"),
				Name = @"ExpirationDate",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateBusinessTimeEndColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("b8421a17-59a8-5353-5ec0-e8c67221a5f2"),
				Name = @"BusinessTimeEnd",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2021-01-29T23:59:00"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateBusinessTimeStartColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("92815ba2-919c-b6e1-b095-408aab9fb28e"),
				Name = @"BusinessTimeStart",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2021-01-29T00:00:00"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDeliveryScheduleDaysColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("91e53dbc-866a-7934-ff55-9e5558359b90"),
				Name = @"DeliveryScheduleDays",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateDeliveryScheduleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("54749ce9-d65e-229d-8739-65f7ea97fdf1"),
				Name = @"DeliverySchedule",
				ReferenceSchemaUId = new Guid("2c09efb4-f805-4eb0-172a-2df5f83c68e2"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"71b47d54-7ef9-4443-b9e6-faae213eea33"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateThrottlingQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("253496e7-cad2-1027-1cb0-fa4dd7181bcc"),
				Name = @"ThrottlingQueue",
				ReferenceSchemaUId = new Guid("eb720e69-12b8-8fe3-e018-7cb960d35698"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"44239c7e-f1c4-41df-a6ee-7e7205449c8b"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateExpiredCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("416be0a3-2703-e665-d832-7170d3e909b1"),
				Name = @"ExpiredCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c84180d9-e4a3-ce6d-8920-093e20f33445"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateStoppedSummaryCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6fb691c3-9a6c-3859-b9c1-18a9dca54e82"),
				Name = @"StoppedSummaryCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateStoppedManuallyCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3dfd79d6-54ec-3be5-a6c8-aaea068daca2"),
				Name = @"StoppedManuallyCount",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateStoppedInProviderCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6b07e6b6-00d4-726e-9f72-870285fe5597"),
				Name = @"StoppedInProviderCount",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateExpiredSummaryCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d9d80b39-8f01-0cd9-cd13-5e1397a56765"),
				Name = @"ExpiredSummaryCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateExpiredInProviderCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5177a1fb-d654-4a2b-8b2c-75d5f1010b6b"),
				Name = @"ExpiredInProviderCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateDelayBetweenEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("443ae6ca-2069-ac9e-9a32-1c44118a64f5"),
				Name = @"DelayBetweenEmail",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateDailyLimitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8019ee41-ff67-82fa-a872-e704b374d38d"),
				Name = @"DailyLimit",
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateProviderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("2e0f5a7b-6245-49eb-8cfc-a8c27a93ece6"),
				Name = @"ProviderName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				ModifiedInSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmail(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmail_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmail

	/// <summary>
	/// Email.
	/// </summary>
	public class BulkEmail : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmail";
		}

		public BulkEmail(BulkEmail source)
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

		private BulkEmailType _type;
		/// <summary>
		/// Тип рассылки.
		/// </summary>
		public BulkEmailType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as BulkEmailType);
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

		private BulkEmailStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public BulkEmailStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as BulkEmailStatus);
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
		/// Имя отправителя.
		/// </summary>
		public string SenderName {
			get {
				return GetTypedColumnValue<string>("SenderName");
			}
			set {
				SetColumnValue("SenderName", value);
			}
		}

		/// <summary>
		/// Email отправителя.
		/// </summary>
		public string SenderEmail {
			get {
				return GetTypedColumnValue<string>("SenderEmail");
			}
			set {
				SetColumnValue("SenderEmail", value);
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
		/// Отправка начата.
		/// </summary>
		public DateTime SendStartDate {
			get {
				return GetTypedColumnValue<DateTime>("SendStartDate");
			}
			set {
				SetColumnValue("SendStartDate", value);
			}
		}

		/// <summary>
		/// Отправка завершена.
		/// </summary>
		public DateTime SendDueDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDueDate");
			}
			set {
				SetColumnValue("SendDueDate", value);
			}
		}

		/// <summary>
		/// Переходы, %.
		/// </summary>
		public Decimal Clicks {
			get {
				return GetTypedColumnValue<Decimal>("Clicks");
			}
			set {
				SetColumnValue("Clicks", value);
			}
		}

		/// <summary>
		/// Открытия, %.
		/// </summary>
		public Decimal Opens {
			get {
				return GetTypedColumnValue<Decimal>("Opens");
			}
			set {
				SetColumnValue("Opens", value);
			}
		}

		/// <summary>
		/// Soft Bounce, %.
		/// </summary>
		public Decimal SoftBounce {
			get {
				return GetTypedColumnValue<Decimal>("SoftBounce");
			}
			set {
				SetColumnValue("SoftBounce", value);
			}
		}

		/// <summary>
		/// Hard Bounce, %.
		/// </summary>
		public Decimal HardBounce {
			get {
				return GetTypedColumnValue<Decimal>("HardBounce");
			}
			set {
				SetColumnValue("HardBounce", value);
			}
		}

		/// <summary>
		/// Отписки, %.
		/// </summary>
		public Decimal Unsubscribe {
			get {
				return GetTypedColumnValue<Decimal>("Unsubscribe");
			}
			set {
				SetColumnValue("Unsubscribe", value);
			}
		}

		/// <summary>
		/// Спам, %.
		/// </summary>
		public Decimal Spam {
			get {
				return GetTypedColumnValue<Decimal>("Spam");
			}
			set {
				SetColumnValue("Spam", value);
			}
		}

		/// <summary>
		/// Переходы, кол-во.
		/// </summary>
		public int ClicksCount {
			get {
				return GetTypedColumnValue<int>("ClicksCount");
			}
			set {
				SetColumnValue("ClicksCount", value);
			}
		}

		/// <summary>
		/// Открытия, кол-во.
		/// </summary>
		public int OpensCount {
			get {
				return GetTypedColumnValue<int>("OpensCount");
			}
			set {
				SetColumnValue("OpensCount", value);
			}
		}

		/// <summary>
		/// Soft Bounce, кол-во.
		/// </summary>
		public int SoftBounceCount {
			get {
				return GetTypedColumnValue<int>("SoftBounceCount");
			}
			set {
				SetColumnValue("SoftBounceCount", value);
			}
		}

		/// <summary>
		/// Hard Bounce, кол-во.
		/// </summary>
		public int HardBounceCount {
			get {
				return GetTypedColumnValue<int>("HardBounceCount");
			}
			set {
				SetColumnValue("HardBounceCount", value);
			}
		}

		/// <summary>
		/// Отписки, кол-во.
		/// </summary>
		public int UnsubscribeCount {
			get {
				return GetTypedColumnValue<int>("UnsubscribeCount");
			}
			set {
				SetColumnValue("UnsubscribeCount", value);
			}
		}

		/// <summary>
		/// Спам, кол-во.
		/// </summary>
		public int SpamCount {
			get {
				return GetTypedColumnValue<int>("SpamCount");
			}
			set {
				SetColumnValue("SpamCount", value);
			}
		}

		/// <exclude/>
		public Guid SegmentsStatusId {
			get {
				return GetTypedColumnValue<Guid>("SegmentsStatusId");
			}
			set {
				SetColumnValue("SegmentsStatusId", value);
				_segmentsStatus = null;
			}
		}

		/// <exclude/>
		public string SegmentsStatusName {
			get {
				return GetTypedColumnValue<string>("SegmentsStatusName");
			}
			set {
				SetColumnValue("SegmentsStatusName", value);
				if (_segmentsStatus != null) {
					_segmentsStatus.Name = value;
				}
			}
		}

		private SegmentStatus _segmentsStatus;
		/// <summary>
		/// Список контактов.
		/// </summary>
		public SegmentStatus SegmentsStatus {
			get {
				return _segmentsStatus ??
					(_segmentsStatus = LookupColumnEntities.GetEntity("SegmentsStatus") as SegmentStatus);
			}
		}

		/// <summary>
		/// Получатели.
		/// </summary>
		public int RecipientCount {
			get {
				return GetTypedColumnValue<int>("RecipientCount");
			}
			set {
				SetColumnValue("RecipientCount", value);
			}
		}

		/// <summary>
		/// Время последнего обновления.
		/// </summary>
		public DateTime LastActualizeDate {
			get {
				return GetTypedColumnValue<DateTime>("LastActualizeDate");
			}
			set {
				SetColumnValue("LastActualizeDate", value);
			}
		}

		/// <summary>
		/// Тема.
		/// </summary>
		public string TemplateSubject {
			get {
				return GetTypedColumnValue<string>("TemplateSubject");
			}
			set {
				SetColumnValue("TemplateSubject", value);
			}
		}

		/// <summary>
		/// Текст шаблона.
		/// </summary>
		public string TemplateBody {
			get {
				return GetTypedColumnValue<string>("TemplateBody");
			}
			set {
				SetColumnValue("TemplateBody", value);
			}
		}

		/// <summary>
		/// Доставлено.
		/// </summary>
		public int DeliveredCount {
			get {
				return GetTypedColumnValue<int>("DeliveredCount");
			}
			set {
				SetColumnValue("DeliveredCount", value);
			}
		}

		/// <summary>
		/// Не доставлено.
		/// </summary>
		public int NotDeliveredCount {
			get {
				return GetTypedColumnValue<int>("NotDeliveredCount");
			}
			set {
				SetColumnValue("NotDeliveredCount", value);
			}
		}

		/// <summary>
		/// В очереди.
		/// </summary>
		public int InQueueCount {
			get {
				return GetTypedColumnValue<int>("InQueueCount");
			}
			set {
				SetColumnValue("InQueueCount", value);
			}
		}

		/// <summary>
		/// Отменено, кол-во.
		/// </summary>
		public int CanceledCount {
			get {
				return GetTypedColumnValue<int>("CanceledCount");
			}
			set {
				SetColumnValue("CanceledCount", value);
			}
		}

		/// <summary>
		/// Email не заполнен .
		/// </summary>
		public int BlankEmailCount {
			get {
				return GetTypedColumnValue<int>("BlankEmailCount");
			}
			set {
				SetColumnValue("BlankEmailCount", value);
			}
		}

		/// <summary>
		/// Incorrect email.
		/// </summary>
		public int IncorrectEmailCount {
			get {
				return GetTypedColumnValue<int>("IncorrectEmailCount");
			}
			set {
				SetColumnValue("IncorrectEmailCount", value);
			}
		}

		/// <summary>
		/// Недоступный email.
		/// </summary>
		public int UnreachableEmailCount {
			get {
				return GetTypedColumnValue<int>("UnreachableEmailCount");
			}
			set {
				SetColumnValue("UnreachableEmailCount", value);
			}
		}

		/// <summary>
		/// Не использовать email.
		/// </summary>
		public int DoNotUseEmailCount {
			get {
				return GetTypedColumnValue<int>("DoNotUseEmailCount");
			}
			set {
				SetColumnValue("DoNotUseEmailCount", value);
			}
		}

		/// <summary>
		/// Отписан по типу рассылки.
		/// </summary>
		public int UnsubscribedByTypeCount {
			get {
				return GetTypedColumnValue<int>("UnsubscribedByTypeCount");
			}
			set {
				SetColumnValue("UnsubscribedByTypeCount", value);
			}
		}

		/// <summary>
		/// Дубль emailа.
		/// </summary>
		public int DuplicateEmailCount {
			get {
				return GetTypedColumnValue<int>("DuplicateEmailCount");
			}
			set {
				SetColumnValue("DuplicateEmailCount", value);
			}
		}

		/// <summary>
		/// Отклонено, кол-во.
		/// </summary>
		public int RejectedCount {
			get {
				return GetTypedColumnValue<int>("RejectedCount");
			}
			set {
				SetColumnValue("RejectedCount", value);
			}
		}

		/// <summary>
		/// Общая ошибка запроса, кол-во.
		/// </summary>
		public int CommonErrorCount {
			get {
				return GetTypedColumnValue<int>("CommonErrorCount");
			}
			set {
				SetColumnValue("CommonErrorCount", value);
			}
		}

		/// <summary>
		/// Некорректный адресат, кол-во.
		/// </summary>
		public int InvalidAddresseeCount {
			get {
				return GetTypedColumnValue<int>("InvalidAddresseeCount");
			}
			set {
				SetColumnValue("InvalidAddresseeCount", value);
			}
		}

		/// <summary>
		/// PercentWeight.
		/// </summary>
		public Decimal PercentWeight {
			get {
				return GetTypedColumnValue<Decimal>("PercentWeight");
			}
			set {
				SetColumnValue("PercentWeight", value);
			}
		}

		/// <summary>
		/// PercentActiveWeight.
		/// </summary>
		public Decimal PercentActiveWeight {
			get {
				return GetTypedColumnValue<Decimal>("PercentActiveWeight");
			}
			set {
				SetColumnValue("PercentActiveWeight", value);
			}
		}

		/// <summary>
		/// PercentInactiveWeight.
		/// </summary>
		public Decimal PercentInactiveWeight {
			get {
				return GetTypedColumnValue<Decimal>("PercentInactiveWeight");
			}
			set {
				SetColumnValue("PercentInactiveWeight", value);
			}
		}

		/// <summary>
		/// Отправлено.
		/// </summary>
		public int SendCount {
			get {
				return GetTypedColumnValue<int>("SendCount");
			}
			set {
				SetColumnValue("SendCount", value);
			}
		}

		/// <summary>
		/// Cancelled (communication limit).
		/// </summary>
		public int CommunicationLimitCount {
			get {
				return GetTypedColumnValue<int>("CommunicationLimitCount");
			}
			set {
				SetColumnValue("CommunicationLimitCount", value);
			}
		}

		/// <summary>
		/// utm_source.
		/// </summary>
		public string UtmSource {
			get {
				return GetTypedColumnValue<string>("UtmSource");
			}
			set {
				SetColumnValue("UtmSource", value);
			}
		}

		/// <summary>
		/// utm_medium.
		/// </summary>
		public string UtmMedium {
			get {
				return GetTypedColumnValue<string>("UtmMedium");
			}
			set {
				SetColumnValue("UtmMedium", value);
			}
		}

		/// <summary>
		/// utm_campaign.
		/// </summary>
		public string UtmCampaign {
			get {
				return GetTypedColumnValue<string>("UtmCampaign");
			}
			set {
				SetColumnValue("UtmCampaign", value);
			}
		}

		/// <summary>
		/// utm_term.
		/// </summary>
		public string UtmTerm {
			get {
				return GetTypedColumnValue<string>("UtmTerm");
			}
			set {
				SetColumnValue("UtmTerm", value);
			}
		}

		/// <summary>
		/// utm_content.
		/// </summary>
		public string UtmContent {
			get {
				return GetTypedColumnValue<string>("UtmContent");
			}
			set {
				SetColumnValue("UtmContent", value);
			}
		}

		/// <summary>
		/// Список доменов.
		/// </summary>
		public string Domains {
			get {
				return GetTypedColumnValue<string>("Domains");
			}
			set {
				SetColumnValue("Domains", value);
			}
		}

		/// <summary>
		/// Использовать UTM-метки.
		/// </summary>
		public bool UseUtm {
			get {
				return GetTypedColumnValue<bool>("UseUtm");
			}
			set {
				SetColumnValue("UseUtm", value);
			}
		}

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
			}
		}

		/// <summary>
		/// StatisticDate.
		/// </summary>
		public DateTime StatisticDate {
			get {
				return GetTypedColumnValue<DateTime>("StatisticDate");
			}
			set {
				SetColumnValue("StatisticDate", value);
			}
		}

		/// <summary>
		/// Обработка откликов завершена.
		/// </summary>
		public bool ResponseProcessingCompleted {
			get {
				return GetTypedColumnValue<bool>("ResponseProcessingCompleted");
			}
			set {
				SetColumnValue("ResponseProcessingCompleted", value);
			}
		}

		/// <exclude/>
		public Guid SplitTestId {
			get {
				return GetTypedColumnValue<Guid>("SplitTestId");
			}
			set {
				SetColumnValue("SplitTestId", value);
				_splitTest = null;
			}
		}

		/// <exclude/>
		public string SplitTestName {
			get {
				return GetTypedColumnValue<string>("SplitTestName");
			}
			set {
				SetColumnValue("SplitTestName", value);
				if (_splitTest != null) {
					_splitTest.Name = value;
				}
			}
		}

		private BulkEmailSplit _splitTest;
		/// <summary>
		/// Сплит-тест.
		/// </summary>
		public BulkEmailSplit SplitTest {
			get {
				return _splitTest ??
					(_splitTest = LookupColumnEntities.GetEntity("SplitTest") as BulkEmailSplit);
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private BulkEmailCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public BulkEmailCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as BulkEmailCategory);
			}
		}

		/// <exclude/>
		public Guid LaunchOptionId {
			get {
				return GetTypedColumnValue<Guid>("LaunchOptionId");
			}
			set {
				SetColumnValue("LaunchOptionId", value);
				_launchOption = null;
			}
		}

		/// <exclude/>
		public string LaunchOptionName {
			get {
				return GetTypedColumnValue<string>("LaunchOptionName");
			}
			set {
				SetColumnValue("LaunchOptionName", value);
				if (_launchOption != null) {
					_launchOption.Name = value;
				}
			}
		}

		private BulkEmailLaunchOption _launchOption;
		/// <summary>
		/// Вариант запуска.
		/// </summary>
		public BulkEmailLaunchOption LaunchOption {
			get {
				return _launchOption ??
					(_launchOption = LookupColumnEntities.GetEntity("LaunchOption") as BulkEmailLaunchOption);
			}
		}

		/// <summary>
		/// Конфиг шаблона.
		/// </summary>
		public string TemplateConfig {
			get {
				return GetTypedColumnValue<string>("TemplateConfig");
			}
			set {
				SetColumnValue("TemplateConfig", value);
			}
		}

		/// <summary>
		/// Количество ошибок доставки.
		/// </summary>
		public int DeliveryError {
			get {
				return GetTypedColumnValue<int>("DeliveryError");
			}
			set {
				SetColumnValue("DeliveryError", value);
			}
		}

		/// <summary>
		/// Системная рассылка.
		/// </summary>
		public bool IsSystemEmail {
			get {
				return GetTypedColumnValue<bool>("IsSystemEmail");
			}
			set {
				SetColumnValue("IsSystemEmail", value);
			}
		}

		/// <summary>
		/// Шаблон отсутствует.
		/// </summary>
		public int TemplateNotFoundCount {
			get {
				return GetTypedColumnValue<int>("TemplateNotFoundCount");
			}
			set {
				SetColumnValue("TemplateNotFoundCount", value);
			}
		}

		/// <summary>
		/// Домен отправителя не подтвержден.
		/// </summary>
		public int SendersDomainNotVerifiedCount {
			get {
				return GetTypedColumnValue<int>("SendersDomainNotVerifiedCount");
			}
			set {
				SetColumnValue("SendersDomainNotVerifiedCount", value);
			}
		}

		/// <summary>
		/// Невалидное имя отправителя.
		/// </summary>
		public int SendersNameNotValidCount {
			get {
				return GetTypedColumnValue<int>("SendersNameNotValidCount");
			}
			set {
				SetColumnValue("SendersNameNotValidCount", value);
			}
		}

		/// <exclude/>
		public Guid AudienceSchemaId {
			get {
				return GetTypedColumnValue<Guid>("AudienceSchemaId");
			}
			set {
				SetColumnValue("AudienceSchemaId", value);
				_audienceSchema = null;
			}
		}

		/// <exclude/>
		public string AudienceSchemaDisplayName {
			get {
				return GetTypedColumnValue<string>("AudienceSchemaDisplayName");
			}
			set {
				SetColumnValue("AudienceSchemaDisplayName", value);
				if (_audienceSchema != null) {
					_audienceSchema.DisplayName = value;
				}
			}
		}

		private BulkEmailAudienceSchema _audienceSchema;
		/// <summary>
		/// Схема аудитории рассылки.
		/// </summary>
		public BulkEmailAudienceSchema AudienceSchema {
			get {
				return _audienceSchema ??
					(_audienceSchema = LookupColumnEntities.GetEntity("AudienceSchema") as BulkEmailAudienceSchema);
			}
		}

		/// <summary>
		/// Аудитория инициализирована.
		/// </summary>
		public bool IsAudienceInited {
			get {
				return GetTypedColumnValue<bool>("IsAudienceInited");
			}
			set {
				SetColumnValue("IsAudienceInited", value);
			}
		}

		/// <exclude/>
		public Guid ThrottlingModeId {
			get {
				return GetTypedColumnValue<Guid>("ThrottlingModeId");
			}
			set {
				SetColumnValue("ThrottlingModeId", value);
				_throttlingMode = null;
			}
		}

		/// <exclude/>
		public string ThrottlingModeName {
			get {
				return GetTypedColumnValue<string>("ThrottlingModeName");
			}
			set {
				SetColumnValue("ThrottlingModeName", value);
				if (_throttlingMode != null) {
					_throttlingMode.Name = value;
				}
			}
		}

		private BulkEmailThrottlingMode _throttlingMode;
		/// <summary>
		/// Режим распределения.
		/// </summary>
		public BulkEmailThrottlingMode ThrottlingMode {
			get {
				return _throttlingMode ??
					(_throttlingMode = LookupColumnEntities.GetEntity("ThrottlingMode") as BulkEmailThrottlingMode);
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

		private BulkEmailPriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public BulkEmailPriority Priority {
			get {
				return _priority ??
					(_priority = LookupColumnEntities.GetEntity("Priority") as BulkEmailPriority);
			}
		}

		/// <summary>
		/// Срок действия рассылки.
		/// </summary>
		public DateTime ExpirationDate {
			get {
				return GetTypedColumnValue<DateTime>("ExpirationDate");
			}
			set {
				SetColumnValue("ExpirationDate", value);
			}
		}

		/// <summary>
		/// По.
		/// </summary>
		public DateTime BusinessTimeEnd {
			get {
				return GetTypedColumnValue<DateTime>("BusinessTimeEnd");
			}
			set {
				SetColumnValue("BusinessTimeEnd", value);
			}
		}

		/// <summary>
		/// С.
		/// </summary>
		public DateTime BusinessTimeStart {
			get {
				return GetTypedColumnValue<DateTime>("BusinessTimeStart");
			}
			set {
				SetColumnValue("BusinessTimeStart", value);
			}
		}

		/// <summary>
		/// Дни запланированной отправки.
		/// </summary>
		public string DeliveryScheduleDays {
			get {
				return GetTypedColumnValue<string>("DeliveryScheduleDays");
			}
			set {
				SetColumnValue("DeliveryScheduleDays", value);
			}
		}

		/// <exclude/>
		public Guid DeliveryScheduleId {
			get {
				return GetTypedColumnValue<Guid>("DeliveryScheduleId");
			}
			set {
				SetColumnValue("DeliveryScheduleId", value);
				_deliverySchedule = null;
			}
		}

		/// <exclude/>
		public string DeliveryScheduleName {
			get {
				return GetTypedColumnValue<string>("DeliveryScheduleName");
			}
			set {
				SetColumnValue("DeliveryScheduleName", value);
				if (_deliverySchedule != null) {
					_deliverySchedule.Name = value;
				}
			}
		}

		private EmailDeliverySchedule _deliverySchedule;
		/// <summary>
		/// Расписание отправки.
		/// </summary>
		public EmailDeliverySchedule DeliverySchedule {
			get {
				return _deliverySchedule ??
					(_deliverySchedule = LookupColumnEntities.GetEntity("DeliverySchedule") as EmailDeliverySchedule);
			}
		}

		/// <exclude/>
		public Guid ThrottlingQueueId {
			get {
				return GetTypedColumnValue<Guid>("ThrottlingQueueId");
			}
			set {
				SetColumnValue("ThrottlingQueueId", value);
				_throttlingQueue = null;
			}
		}

		/// <exclude/>
		public string ThrottlingQueueName {
			get {
				return GetTypedColumnValue<string>("ThrottlingQueueName");
			}
			set {
				SetColumnValue("ThrottlingQueueName", value);
				if (_throttlingQueue != null) {
					_throttlingQueue.Name = value;
				}
			}
		}

		private EmailThrottlingQueue _throttlingQueue;
		/// <summary>
		/// Очередь распределения.
		/// </summary>
		public EmailThrottlingQueue ThrottlingQueue {
			get {
				return _throttlingQueue ??
					(_throttlingQueue = LookupColumnEntities.GetEntity("ThrottlingQueue") as EmailThrottlingQueue);
			}
		}

		/// <summary>
		/// Остановлен (истек срок отправки), кол-во.
		/// </summary>
		public int ExpiredCount {
			get {
				return GetTypedColumnValue<int>("ExpiredCount");
			}
			set {
				SetColumnValue("ExpiredCount", value);
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

		/// <summary>
		/// Остановлено вручную, кол-во.
		/// </summary>
		public int StoppedSummaryCount {
			get {
				return GetTypedColumnValue<int>("StoppedSummaryCount");
			}
			set {
				SetColumnValue("StoppedSummaryCount", value);
			}
		}

		/// <summary>
		/// Остановлено вручную, кол-во.
		/// </summary>
		public int StoppedManuallyCount {
			get {
				return GetTypedColumnValue<int>("StoppedManuallyCount");
			}
			set {
				SetColumnValue("StoppedManuallyCount", value);
			}
		}

		/// <summary>
		/// Остановлено вручную (provider), кол-во.
		/// </summary>
		public int StoppedInProviderCount {
			get {
				return GetTypedColumnValue<int>("StoppedInProviderCount");
			}
			set {
				SetColumnValue("StoppedInProviderCount", value);
			}
		}

		/// <summary>
		/// Остановлен (истек срок отправки), кол-во.
		/// </summary>
		public int ExpiredSummaryCount {
			get {
				return GetTypedColumnValue<int>("ExpiredSummaryCount");
			}
			set {
				SetColumnValue("ExpiredSummaryCount", value);
			}
		}

		/// <summary>
		/// Остановлен (истек срок отправки), кол-во (от провайдера).
		/// </summary>
		public int ExpiredInProviderCount {
			get {
				return GetTypedColumnValue<int>("ExpiredInProviderCount");
			}
			set {
				SetColumnValue("ExpiredInProviderCount", value);
			}
		}

		/// <summary>
		/// Задержка между письмами.
		/// </summary>
		public int DelayBetweenEmail {
			get {
				return GetTypedColumnValue<int>("DelayBetweenEmail");
			}
			set {
				SetColumnValue("DelayBetweenEmail", value);
			}
		}

		/// <summary>
		/// Лимит писем в день.
		/// </summary>
		public int DailyLimit {
			get {
				return GetTypedColumnValue<int>("DailyLimit");
			}
			set {
				SetColumnValue("DailyLimit", value);
			}
		}

		/// <summary>
		/// Провайдер рассылок.
		/// </summary>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmail_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailDeleted", e);
			Deleting += (s, e) => ThrowEvent("BulkEmailDeleting", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailInserting", e);
			Saved += (s, e) => ThrowEvent("BulkEmailSaved", e);
			Saving += (s, e) => ThrowEvent("BulkEmailSaving", e);
			Validating += (s, e) => ThrowEvent("BulkEmailValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmail(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmail_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmail_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmail
	{

		public BulkEmail_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmail_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsTemplateBodyChanged {
			get;
			set;
		}

		public virtual int EntityRId {
			get;
			set;
		}

		public virtual bool IsCopy {
			get;
			set;
		}

		public virtual Guid SourceBulkEmailId {
			get;
			set;
		}

		private ProcessFlowElement _bulkEmailInsertingStartMessageEventSubProcess;
		public ProcessFlowElement BulkEmailInsertingStartMessageEventSubProcess {
			get {
				return _bulkEmailInsertingStartMessageEventSubProcess ?? (_bulkEmailInsertingStartMessageEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BulkEmailInsertingStartMessageEventSubProcess",
					SchemaElementUId = new Guid("bfa3f852-95e0-43b6-a88e-0d4e0a14cce7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _bulkEmailInsertingStartMessageScriptTask;
		public ProcessScriptTask BulkEmailInsertingStartMessageScriptTask {
			get {
				return _bulkEmailInsertingStartMessageScriptTask ?? (_bulkEmailInsertingStartMessageScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BulkEmailInsertingStartMessageScriptTask",
					SchemaElementUId = new Guid("909f355c-72fa-4512-9198-1dd649b4be2f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BulkEmailInsertingStartMessageScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _bulkEmailInsertingStartMessage;
		public ProcessFlowElement BulkEmailInsertingStartMessage {
			get {
				return _bulkEmailInsertingStartMessage ?? (_bulkEmailInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BulkEmailInsertingStartMessage",
					SchemaElementUId = new Guid("77eef246-adde-4746-baa0-8c43f45c9e91"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("1c17b7d0-53cd-4e1e-80a0-d273013bcf78"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _bulkEmailSavedStartMessage;
		public ProcessFlowElement BulkEmailSavedStartMessage {
			get {
				return _bulkEmailSavedStartMessage ?? (_bulkEmailSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BulkEmailSavedStartMessage",
					SchemaElementUId = new Guid("3efa3683-63a7-433a-a91a-f91b30902d67"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _bulkEmailSavedScriptTask;
		public ProcessScriptTask BulkEmailSavedScriptTask {
			get {
				return _bulkEmailSavedScriptTask ?? (_bulkEmailSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BulkEmailSavedScriptTask",
					SchemaElementUId = new Guid("ac808fe5-89f8-4089-b4c0-a1fa19a956b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BulkEmailSavedScriptTaskExecute,
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
					SchemaElementUId = new Guid("5384c573-e924-43fc-8f5b-a2f33ed87318"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _bulkEmailSavingStartMessage;
		public ProcessFlowElement BulkEmailSavingStartMessage {
			get {
				return _bulkEmailSavingStartMessage ?? (_bulkEmailSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BulkEmailSavingStartMessage",
					SchemaElementUId = new Guid("aa6911e5-eb04-4e0c-bb09-6a49b788d31d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _bulkEmailSavingScriptTask;
		public ProcessScriptTask BulkEmailSavingScriptTask {
			get {
				return _bulkEmailSavingScriptTask ?? (_bulkEmailSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BulkEmailSavingScriptTask",
					SchemaElementUId = new Guid("1435242c-1d2d-493f-be0c-09a3f08257a3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BulkEmailSavingScriptTaskExecute,
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
					SchemaElementUId = new Guid("ceff2bdf-c695-472c-a1b4-626707842379"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _bulkEmailDeletedStartMessage;
		public ProcessFlowElement BulkEmailDeletedStartMessage {
			get {
				return _bulkEmailDeletedStartMessage ?? (_bulkEmailDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BulkEmailDeletedStartMessage",
					SchemaElementUId = new Guid("683c8b5a-dc29-4f59-b24f-bd9ee357c840"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _bulkEmailDeletedScriptTask;
		public ProcessScriptTask BulkEmailDeletedScriptTask {
			get {
				return _bulkEmailDeletedScriptTask ?? (_bulkEmailDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BulkEmailDeletedScriptTask",
					SchemaElementUId = new Guid("597a6100-6597-4b98-b5d0-e8976a8a06d2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BulkEmailDeletedScriptTaskExecute,
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
					SchemaElementUId = new Guid("eda2b2b0-bed7-44bc-aff7-22561620ddc9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _bulkEmailDeletingStartMessage;
		public ProcessFlowElement BulkEmailDeletingStartMessage {
			get {
				return _bulkEmailDeletingStartMessage ?? (_bulkEmailDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BulkEmailDeletingStartMessage",
					SchemaElementUId = new Guid("d3103f32-ca32-4bb5-92b0-44317f62b35e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _bulkEmailDeletingStartMessageScriptTask;
		public ProcessScriptTask BulkEmailDeletingStartMessageScriptTask {
			get {
				return _bulkEmailDeletingStartMessageScriptTask ?? (_bulkEmailDeletingStartMessageScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BulkEmailDeletingStartMessageScriptTask",
					SchemaElementUId = new Guid("0ff3235e-52ab-45fd-a817-ad2bfb182c07"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BulkEmailDeletingStartMessageScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BulkEmailInsertingStartMessageEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailInsertingStartMessageEventSubProcess };
			FlowElements[BulkEmailInsertingStartMessageScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailInsertingStartMessageScriptTask };
			FlowElements[BulkEmailInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailInsertingStartMessage };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[BulkEmailSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailSavedStartMessage };
			FlowElements[BulkEmailSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailSavedScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[BulkEmailSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailSavingStartMessage };
			FlowElements[BulkEmailSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailSavingScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[BulkEmailDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailDeletedStartMessage };
			FlowElements[BulkEmailDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailDeletedScriptTask };
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[BulkEmailDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailDeletingStartMessage };
			FlowElements[BulkEmailDeletingStartMessageScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BulkEmailDeletingStartMessageScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BulkEmailInsertingStartMessageEventSubProcess":
						break;
					case "BulkEmailInsertingStartMessageScriptTask":
						break;
					case "BulkEmailInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("BulkEmailInsertingStartMessageScriptTask");
						break;
					case "EventSubProcess1":
						break;
					case "BulkEmailSavedStartMessage":
						e.Context.QueueTasks.Enqueue("BulkEmailSavedScriptTask");
						break;
					case "BulkEmailSavedScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "BulkEmailSavingStartMessage":
						e.Context.QueueTasks.Enqueue("BulkEmailSavingScriptTask");
						break;
					case "BulkEmailSavingScriptTask":
						break;
					case "EventSubProcess3":
						break;
					case "BulkEmailDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("BulkEmailDeletedScriptTask");
						break;
					case "BulkEmailDeletedScriptTask":
						break;
					case "EventSubProcess4":
						break;
					case "BulkEmailDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("BulkEmailDeletingStartMessageScriptTask");
						break;
					case "BulkEmailDeletingStartMessageScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BulkEmailInsertingStartMessage");
			ActivatedEventElements.Add("BulkEmailSavedStartMessage");
			ActivatedEventElements.Add("BulkEmailSavingStartMessage");
			ActivatedEventElements.Add("BulkEmailDeletedStartMessage");
			ActivatedEventElements.Add("BulkEmailDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BulkEmailInsertingStartMessageEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BulkEmailInsertingStartMessageScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailInsertingStartMessageScriptTask";
					result = BulkEmailInsertingStartMessageScriptTask.Execute(context, BulkEmailInsertingStartMessageScriptTaskExecute);
					break;
				case "BulkEmailInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailInsertingStartMessage";
					result = BulkEmailInsertingStartMessage.Execute(context);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "BulkEmailSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailSavedStartMessage";
					result = BulkEmailSavedStartMessage.Execute(context);
					break;
				case "BulkEmailSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailSavedScriptTask";
					result = BulkEmailSavedScriptTask.Execute(context, BulkEmailSavedScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "BulkEmailSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailSavingStartMessage";
					result = BulkEmailSavingStartMessage.Execute(context);
					break;
				case "BulkEmailSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailSavingScriptTask";
					result = BulkEmailSavingScriptTask.Execute(context, BulkEmailSavingScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "BulkEmailDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailDeletedStartMessage";
					result = BulkEmailDeletedStartMessage.Execute(context);
					break;
				case "BulkEmailDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailDeletedScriptTask";
					result = BulkEmailDeletedScriptTask.Execute(context, BulkEmailDeletedScriptTaskExecute);
					break;
				case "EventSubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "BulkEmailDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailDeletingStartMessage";
					result = BulkEmailDeletingStartMessage.Execute(context);
					break;
				case "BulkEmailDeletingStartMessageScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BulkEmailDeletingStartMessageScriptTask";
					result = BulkEmailDeletingStartMessageScriptTask.Execute(context, BulkEmailDeletingStartMessageScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool BulkEmailInsertingStartMessageScriptTaskExecute(ProcessExecutingContext context) {
			BulkEmailInserting();
			return true;
		}

		public virtual bool BulkEmailSavedScriptTaskExecute(ProcessExecutingContext context) {
			BulkEmailSaved();
			return true;
		}

		public virtual bool BulkEmailSavingScriptTaskExecute(ProcessExecutingContext context) {
			var bulkEmailId = Entity.GetTypedColumnValue<Guid>("Id");
			var oldBulkEmailId = Entity.GetTypedOldColumnValue<Guid>("Id");
			IsCopy = bulkEmailId != oldBulkEmailId;
			SourceBulkEmailId = IsCopy ? oldBulkEmailId : default(Guid);
			var templateBody = Entity.GetTypedColumnValue<string>("TemplateBody");
			var oldTemplateBody = Entity.GetTypedOldColumnValue<string>("TemplateBody");
			IsTemplateBodyChanged = !templateBody.Equals(oldTemplateBody, StringComparison.OrdinalIgnoreCase);
			if (IsCopy) {
				SetBulkEmailStatus();
			}
			var oldAudienceSchemaId = Entity.GetTypedOldColumnValue<Guid>("AudienceSchemaId");
			var isAudienceInited = Entity.GetTypedColumnValue<bool>("IsAudienceInited");
			if (!isAudienceInited) {
				CheckAudienceSchemaState(bulkEmailId);
			} else {
				Entity.SetColumnValue("AudienceSchemaId", oldAudienceSchemaId);
			}
			return true;
		}

		public virtual bool BulkEmailDeletedScriptTaskExecute(ProcessExecutingContext context) {
			BulkEmailDeleted();
			return true;
		}

		public virtual bool BulkEmailDeletingStartMessageScriptTaskExecute(ProcessExecutingContext context) {
			BulkEmailDeleting();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BulkEmailInserting":
							if (ActivatedEventElements.Contains("BulkEmailInsertingStartMessage")) {
							context.QueueTasks.Enqueue("BulkEmailInsertingStartMessage");
						}
						break;
					case "BulkEmailSaved":
							if (ActivatedEventElements.Contains("BulkEmailSavedStartMessage")) {
							context.QueueTasks.Enqueue("BulkEmailSavedStartMessage");
						}
						break;
					case "BulkEmailSaving":
							if (ActivatedEventElements.Contains("BulkEmailSavingStartMessage")) {
							context.QueueTasks.Enqueue("BulkEmailSavingStartMessage");
						}
						break;
					case "BulkEmailDeleted":
							if (ActivatedEventElements.Contains("BulkEmailDeletedStartMessage")) {
							context.QueueTasks.Enqueue("BulkEmailDeletedStartMessage");
						}
						break;
					case "BulkEmailDeleting":
							if (ActivatedEventElements.Contains("BulkEmailDeletingStartMessage")) {
							context.QueueTasks.Enqueue("BulkEmailDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmail_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmail_MarketingCampaignEventsProcess : BulkEmail_MarketingCampaignEventsProcess<BulkEmail>
	{

		public BulkEmail_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: BulkEmailEventsProcess

	/// <exclude/>
	public class BulkEmailEventsProcess : BulkEmail_MarketingCampaignEventsProcess
	{

		public BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

