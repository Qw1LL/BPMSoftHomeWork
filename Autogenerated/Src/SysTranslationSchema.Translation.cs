namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Translation;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Translation;
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

	#region Class: SysTranslationSchema

	/// <exclude/>
	public class SysTranslationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysTranslationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTranslationSchema(SysTranslationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTranslationSchema(SysTranslationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateSysTranslationKeyIndexIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("0a3e49f7-91d5-4b49-b92a-3357cdbbddb4");
			index.Name = "SysTranslationKeyIndex";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			EntitySchemaIndexColumn keyIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c8bc4d42-2e51-487f-8804-2525880becba"),
				ColumnUId = new Guid("4e54682a-31c5-4ec3-b1e9-d291901bfc9e"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(keyIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951");
			RealUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951");
			Name = "SysTranslation";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateKeyColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2ec7a8e1-bda1-45f1-8038-8c9d6ee310ed")) == null) {
				Columns.Add(CreateLanguage0Column());
			}
			if (Columns.FindByUId(new Guid("d6083d73-a1ce-4f49-8cb8-01de8db77af6")) == null) {
				Columns.Add(CreateLanguage1Column());
			}
			if (Columns.FindByUId(new Guid("113fb377-47d2-444b-b8d4-0847dbb63ca3")) == null) {
				Columns.Add(CreateLanguage2Column());
			}
			if (Columns.FindByUId(new Guid("7a63c135-6350-4e15-af20-ae7553afd1e9")) == null) {
				Columns.Add(CreateLanguage3Column());
			}
			if (Columns.FindByUId(new Guid("db708816-23d4-43bd-8eb7-5f46a021f2c3")) == null) {
				Columns.Add(CreateLanguage4Column());
			}
			if (Columns.FindByUId(new Guid("a1deada4-b1d5-4d72-b92b-5ee7a9dcf808")) == null) {
				Columns.Add(CreateLanguage5Column());
			}
			if (Columns.FindByUId(new Guid("e02df9b3-41a3-48f2-ada7-f646b4e6cf46")) == null) {
				Columns.Add(CreateLanguage6Column());
			}
			if (Columns.FindByUId(new Guid("7a28646b-7a1d-46fd-a095-638905442eaf")) == null) {
				Columns.Add(CreateLanguage7Column());
			}
			if (Columns.FindByUId(new Guid("312972d9-b3a7-4647-9e3f-ef1dd53867bf")) == null) {
				Columns.Add(CreateLanguage8Column());
			}
			if (Columns.FindByUId(new Guid("a159185b-84dd-4fe8-a21b-e27b7f1ae509")) == null) {
				Columns.Add(CreateLanguage9Column());
			}
			if (Columns.FindByUId(new Guid("5551a508-bb63-4e92-abcc-459226c10967")) == null) {
				Columns.Add(CreateIsVerified0Column());
			}
			if (Columns.FindByUId(new Guid("f9fd8b05-9437-499a-bd61-4fb757c5e93a")) == null) {
				Columns.Add(CreateIsVerified1Column());
			}
			if (Columns.FindByUId(new Guid("70ebca63-31fd-4660-aca0-f121d8364f8d")) == null) {
				Columns.Add(CreateIsVerified2Column());
			}
			if (Columns.FindByUId(new Guid("8ba15eda-adf6-40cd-a328-5486b63e7e83")) == null) {
				Columns.Add(CreateIsVerified3Column());
			}
			if (Columns.FindByUId(new Guid("67ad9d20-ff6c-4be5-bdcd-c88425f2b88c")) == null) {
				Columns.Add(CreateIsVerified4Column());
			}
			if (Columns.FindByUId(new Guid("127a8bf4-4468-4cab-b3ff-7c2337e9c0ec")) == null) {
				Columns.Add(CreateIsVerified5Column());
			}
			if (Columns.FindByUId(new Guid("4bf92d3a-9799-4ae3-9540-13a4ae135ce2")) == null) {
				Columns.Add(CreateIsVerified6Column());
			}
			if (Columns.FindByUId(new Guid("5052c476-9f8e-4220-95fa-c75d1042b7d0")) == null) {
				Columns.Add(CreateIsVerified7Column());
			}
			if (Columns.FindByUId(new Guid("c0297e29-a2e8-43a8-8537-d8a92a358fb9")) == null) {
				Columns.Add(CreateIsVerified8Column());
			}
			if (Columns.FindByUId(new Guid("cf773afc-033f-48db-99de-d52c78c848cf")) == null) {
				Columns.Add(CreateIsVerified9Column());
			}
			if (Columns.FindByUId(new Guid("8cb78c5b-b362-4c6d-ae55-665a29ebbec0")) == null) {
				Columns.Add(CreateIsChanged0Column());
			}
			if (Columns.FindByUId(new Guid("db362f56-b1ec-4efc-b1a6-f25ac4e66c9c")) == null) {
				Columns.Add(CreateIsChanged1Column());
			}
			if (Columns.FindByUId(new Guid("249f0a0e-5b79-445d-ae09-62c431e62802")) == null) {
				Columns.Add(CreateIsChanged2Column());
			}
			if (Columns.FindByUId(new Guid("1f10ced2-9735-498e-a313-5c798e0c48e2")) == null) {
				Columns.Add(CreateIsChanged3Column());
			}
			if (Columns.FindByUId(new Guid("f3a685ec-f704-4e02-bff9-5d7b62a99548")) == null) {
				Columns.Add(CreateIsChanged4Column());
			}
			if (Columns.FindByUId(new Guid("90f169b1-6f0a-498f-8f6e-a8c1d429e39c")) == null) {
				Columns.Add(CreateIsChanged5Column());
			}
			if (Columns.FindByUId(new Guid("472f1dc3-eac2-4f2c-8831-366cc3eaf84c")) == null) {
				Columns.Add(CreateIsChanged6Column());
			}
			if (Columns.FindByUId(new Guid("2cb95690-896f-486c-8be4-5dff742fffec")) == null) {
				Columns.Add(CreateIsChanged7Column());
			}
			if (Columns.FindByUId(new Guid("88a18436-7505-4c77-9bef-a44e2dbea4b6")) == null) {
				Columns.Add(CreateIsChanged8Column());
			}
			if (Columns.FindByUId(new Guid("584d8f47-54e4-44dd-882b-01c6ed74c2ef")) == null) {
				Columns.Add(CreateIsChanged9Column());
			}
			if (Columns.FindByUId(new Guid("b660805a-93ce-4205-8c07-5ea919badfb0")) == null) {
				Columns.Add(CreateLanguage10Column());
			}
			if (Columns.FindByUId(new Guid("2895cab7-493e-4fa0-b4c8-feccfeab8d16")) == null) {
				Columns.Add(CreateLanguage11Column());
			}
			if (Columns.FindByUId(new Guid("25f36736-1938-4fa4-996d-bb17f6933fc3")) == null) {
				Columns.Add(CreateLanguage12Column());
			}
			if (Columns.FindByUId(new Guid("60838d5f-7537-44fd-ad1f-4bdb50a54541")) == null) {
				Columns.Add(CreateLanguage13Column());
			}
			if (Columns.FindByUId(new Guid("b3ee34f3-ce8d-436f-b675-cd8c9c224df8")) == null) {
				Columns.Add(CreateLanguage14Column());
			}
			if (Columns.FindByUId(new Guid("7a937094-5dc2-4a32-95da-06e00f1139e0")) == null) {
				Columns.Add(CreateLanguage15Column());
			}
			if (Columns.FindByUId(new Guid("35d10ee8-41dc-48bf-8659-568cdef39c0a")) == null) {
				Columns.Add(CreateLanguage16Column());
			}
			if (Columns.FindByUId(new Guid("8c82395d-354d-451d-aad9-ec3ebf5de014")) == null) {
				Columns.Add(CreateLanguage17Column());
			}
			if (Columns.FindByUId(new Guid("e9ed5185-278f-4a43-a061-29e948852e32")) == null) {
				Columns.Add(CreateLanguage18Column());
			}
			if (Columns.FindByUId(new Guid("31388a0e-8db5-4496-aa7a-04303f7fe5fd")) == null) {
				Columns.Add(CreateLanguage19Column());
			}
			if (Columns.FindByUId(new Guid("d416a27a-0a72-4638-813e-9feff82b71cc")) == null) {
				Columns.Add(CreateLanguage20Column());
			}
			if (Columns.FindByUId(new Guid("bf358b7e-6e84-43d1-9150-d65f579aea87")) == null) {
				Columns.Add(CreateLanguage21Column());
			}
			if (Columns.FindByUId(new Guid("ff995c89-7283-44bd-b06e-a5c402b02988")) == null) {
				Columns.Add(CreateLanguage22Column());
			}
			if (Columns.FindByUId(new Guid("e0eef4f9-5d80-42c3-a213-d9b2316819a7")) == null) {
				Columns.Add(CreateLanguage23Column());
			}
			if (Columns.FindByUId(new Guid("c97d0e51-e6e4-459f-ab83-de017c36ab2f")) == null) {
				Columns.Add(CreateLanguage24Column());
			}
			if (Columns.FindByUId(new Guid("99ff77a8-b873-4ce0-bb20-64696be2c627")) == null) {
				Columns.Add(CreateLanguage25Column());
			}
			if (Columns.FindByUId(new Guid("3b872cdb-cd76-4891-992d-da4b5337ded6")) == null) {
				Columns.Add(CreateLanguage26Column());
			}
			if (Columns.FindByUId(new Guid("bfdd9315-a491-4272-b9c2-e1dc49b85ba5")) == null) {
				Columns.Add(CreateLanguage27Column());
			}
			if (Columns.FindByUId(new Guid("d7f3dd56-94fe-4922-9974-37db8bdf932b")) == null) {
				Columns.Add(CreateLanguage28Column());
			}
			if (Columns.FindByUId(new Guid("7fba7ad8-cb09-46b7-aa22-4fced486e021")) == null) {
				Columns.Add(CreateLanguage29Column());
			}
			if (Columns.FindByUId(new Guid("e14a9e9b-cc27-42f5-bbda-5bba8348a5ca")) == null) {
				Columns.Add(CreateLanguage30Column());
			}
			if (Columns.FindByUId(new Guid("363ce737-e745-4c50-ab60-75214785f4d8")) == null) {
				Columns.Add(CreateIsVerified10Column());
			}
			if (Columns.FindByUId(new Guid("a9555a78-3734-4fb7-b5b9-ea000313d4a1")) == null) {
				Columns.Add(CreateIsVerified11Column());
			}
			if (Columns.FindByUId(new Guid("72f0c330-fd85-4c81-bf09-e846eaf0e01c")) == null) {
				Columns.Add(CreateIsVerified12Column());
			}
			if (Columns.FindByUId(new Guid("1a8e092e-4f69-4adb-8318-e06815073178")) == null) {
				Columns.Add(CreateIsVerified13Column());
			}
			if (Columns.FindByUId(new Guid("c8601f44-b46c-4080-8ed9-d388be1e9a43")) == null) {
				Columns.Add(CreateIsVerified14Column());
			}
			if (Columns.FindByUId(new Guid("5f701f56-4cae-460d-a8f0-08f3e4255e77")) == null) {
				Columns.Add(CreateIsVerified15Column());
			}
			if (Columns.FindByUId(new Guid("5ee1b637-4766-40da-98a0-a3a8dd6a3df3")) == null) {
				Columns.Add(CreateIsVerified16Column());
			}
			if (Columns.FindByUId(new Guid("8c14177f-643c-4f56-ac50-edfdc50b74ff")) == null) {
				Columns.Add(CreateIsVerified17Column());
			}
			if (Columns.FindByUId(new Guid("6f35fc91-a078-461f-b7a2-65d79fad86e3")) == null) {
				Columns.Add(CreateIsVerified18Column());
			}
			if (Columns.FindByUId(new Guid("84f672ab-d268-4084-a96d-721b7cbacd2a")) == null) {
				Columns.Add(CreateIsVerified19Column());
			}
			if (Columns.FindByUId(new Guid("dd2f9d93-1cef-4e0f-ac70-c0f0bf2f8d42")) == null) {
				Columns.Add(CreateIsVerified20Column());
			}
			if (Columns.FindByUId(new Guid("6ff14239-5454-4450-a00f-86eabb7ec06a")) == null) {
				Columns.Add(CreateIsVerified21Column());
			}
			if (Columns.FindByUId(new Guid("6a9c8d59-6e76-4b5f-8bfc-a4a659827f86")) == null) {
				Columns.Add(CreateIsVerified22Column());
			}
			if (Columns.FindByUId(new Guid("eddc2538-c371-499d-99fb-134827bba9b7")) == null) {
				Columns.Add(CreateIsVerified23Column());
			}
			if (Columns.FindByUId(new Guid("0b79d6b3-6d1a-429e-a12a-179ce5828a2a")) == null) {
				Columns.Add(CreateIsVerified24Column());
			}
			if (Columns.FindByUId(new Guid("6772bde1-06b6-49a9-a306-94b3daf6bbc7")) == null) {
				Columns.Add(CreateIsVerified25Column());
			}
			if (Columns.FindByUId(new Guid("c3ca9919-eed4-4bcd-86a7-defc66b0e397")) == null) {
				Columns.Add(CreateIsVerified26Column());
			}
			if (Columns.FindByUId(new Guid("7fe2dae2-708d-4b86-914c-4fad61c5da5d")) == null) {
				Columns.Add(CreateIsVerified27Column());
			}
			if (Columns.FindByUId(new Guid("e5716d37-153d-4385-bcaa-8c0da867bee9")) == null) {
				Columns.Add(CreateIsVerified28Column());
			}
			if (Columns.FindByUId(new Guid("23d06938-2239-4c15-b8a1-b39ee6b05eb0")) == null) {
				Columns.Add(CreateIsVerified29Column());
			}
			if (Columns.FindByUId(new Guid("8892f5ee-d627-41cc-afec-de4355272014")) == null) {
				Columns.Add(CreateIsVerified30Column());
			}
			if (Columns.FindByUId(new Guid("98449d55-0dce-4e49-ba6f-373c599f4e57")) == null) {
				Columns.Add(CreateIsChanged10Column());
			}
			if (Columns.FindByUId(new Guid("241dd570-e9cf-4b72-8c30-5f76e58c8c2b")) == null) {
				Columns.Add(CreateIsChanged11Column());
			}
			if (Columns.FindByUId(new Guid("3e757d67-38d3-4842-a9f7-3312efb6b411")) == null) {
				Columns.Add(CreateIsChanged12Column());
			}
			if (Columns.FindByUId(new Guid("163c3906-00dd-4c20-8c82-785ad579ede7")) == null) {
				Columns.Add(CreateIsChanged13Column());
			}
			if (Columns.FindByUId(new Guid("d7eb9557-486f-405d-ac92-4294c352628e")) == null) {
				Columns.Add(CreateIsChanged14Column());
			}
			if (Columns.FindByUId(new Guid("f0841c66-af84-49c4-ab03-e9f7a349facf")) == null) {
				Columns.Add(CreateIsChanged15Column());
			}
			if (Columns.FindByUId(new Guid("722faacd-d97d-4b64-8661-c07472086a25")) == null) {
				Columns.Add(CreateIsChanged16Column());
			}
			if (Columns.FindByUId(new Guid("af96d99c-ec23-4043-bde8-f97e7db3ed8e")) == null) {
				Columns.Add(CreateIsChanged17Column());
			}
			if (Columns.FindByUId(new Guid("5c0e60f4-b9ba-496f-b56a-50dbdebb898c")) == null) {
				Columns.Add(CreateIsChanged18Column());
			}
			if (Columns.FindByUId(new Guid("96d13aa6-c170-4694-ae0d-d0463651e41d")) == null) {
				Columns.Add(CreateIsChanged19Column());
			}
			if (Columns.FindByUId(new Guid("49d434fa-e9e7-4cba-9fd9-5a0306d3d2b7")) == null) {
				Columns.Add(CreateIsChanged20Column());
			}
			if (Columns.FindByUId(new Guid("0df6886f-97eb-4752-82a8-0da5dee6249c")) == null) {
				Columns.Add(CreateIsChanged21Column());
			}
			if (Columns.FindByUId(new Guid("39ef4e05-1810-4cb6-a977-23f681dd659d")) == null) {
				Columns.Add(CreateIsChanged22Column());
			}
			if (Columns.FindByUId(new Guid("26a7838b-a83d-43c6-a396-a17936c07a17")) == null) {
				Columns.Add(CreateIsChanged23Column());
			}
			if (Columns.FindByUId(new Guid("0cdd4104-cdc1-4b57-8483-01a43244859e")) == null) {
				Columns.Add(CreateIsChanged24Column());
			}
			if (Columns.FindByUId(new Guid("9f1041fe-571e-4a58-b68e-9f728f488f9c")) == null) {
				Columns.Add(CreateIsChanged25Column());
			}
			if (Columns.FindByUId(new Guid("d4fe99db-e84c-49c2-a768-f6652ee1acfe")) == null) {
				Columns.Add(CreateIsChanged26Column());
			}
			if (Columns.FindByUId(new Guid("419266c3-e19b-4b2c-83ef-9d2a9b936187")) == null) {
				Columns.Add(CreateIsChanged27Column());
			}
			if (Columns.FindByUId(new Guid("02036514-fbb6-463d-9e07-cd89369e00f8")) == null) {
				Columns.Add(CreateIsChanged28Column());
			}
			if (Columns.FindByUId(new Guid("aa124d6e-753c-45eb-939c-d61fc83d0fce")) == null) {
				Columns.Add(CreateIsChanged29Column());
			}
			if (Columns.FindByUId(new Guid("addfc1e0-c1e6-4561-b00b-74f7c123da75")) == null) {
				Columns.Add(CreateIsChanged30Column());
			}
			if (Columns.FindByUId(new Guid("ead9f0f9-8b1b-4b01-9909-c0c388bc3d87")) == null) {
				Columns.Add(CreateLanguage0ShortColumn());
			}
			if (Columns.FindByUId(new Guid("ce3656a3-ad7d-4a5d-bb9e-3ee49ff631de")) == null) {
				Columns.Add(CreateLanguage1ShortColumn());
			}
			if (Columns.FindByUId(new Guid("cc6140b8-79de-44ea-8c87-bbdb8b119be3")) == null) {
				Columns.Add(CreateLanguage2ShortColumn());
			}
			if (Columns.FindByUId(new Guid("aad4b88c-e4b5-441b-abbd-1178462e7eb2")) == null) {
				Columns.Add(CreateLanguage3ShortColumn());
			}
			if (Columns.FindByUId(new Guid("42a45adf-2690-4271-9578-c786a4695796")) == null) {
				Columns.Add(CreateLanguage4ShortColumn());
			}
			if (Columns.FindByUId(new Guid("993dc791-47a4-4b76-a58e-df13a575d462")) == null) {
				Columns.Add(CreateLanguage5ShortColumn());
			}
			if (Columns.FindByUId(new Guid("44ea85a1-46a7-40df-a981-9bd9898f80b9")) == null) {
				Columns.Add(CreateLanguage6ShortColumn());
			}
			if (Columns.FindByUId(new Guid("f587e1f0-cd1a-497e-9817-09bc3a381b48")) == null) {
				Columns.Add(CreateLanguage7ShortColumn());
			}
			if (Columns.FindByUId(new Guid("0f3b754a-2b40-4a80-934b-97c8e9a09772")) == null) {
				Columns.Add(CreateLanguage8ShortColumn());
			}
			if (Columns.FindByUId(new Guid("5056540b-d232-4b74-a299-4225acdb1847")) == null) {
				Columns.Add(CreateLanguage9ShortColumn());
			}
			if (Columns.FindByUId(new Guid("0cf89ab4-26e0-4f23-a0d7-f721d39eaaa0")) == null) {
				Columns.Add(CreateLanguage10ShortColumn());
			}
			if (Columns.FindByUId(new Guid("40a049ca-a293-43c5-9304-661202c1d86a")) == null) {
				Columns.Add(CreateLanguage11ShortColumn());
			}
			if (Columns.FindByUId(new Guid("4ddf08b2-2767-4afd-8bc3-4229e0ccd8d3")) == null) {
				Columns.Add(CreateLanguage12ShortColumn());
			}
			if (Columns.FindByUId(new Guid("41e6bdee-287e-4caa-82e2-4ddc5092ca49")) == null) {
				Columns.Add(CreateLanguage13ShortColumn());
			}
			if (Columns.FindByUId(new Guid("fddf606f-3c8f-433f-b9a4-bffbad5cec20")) == null) {
				Columns.Add(CreateLanguage14ShortColumn());
			}
			if (Columns.FindByUId(new Guid("4b682718-9aa5-4834-af36-f2af4a5e68ad")) == null) {
				Columns.Add(CreateLanguage15ShortColumn());
			}
			if (Columns.FindByUId(new Guid("ec08203f-22a8-472b-b6f7-2ac332fc5f85")) == null) {
				Columns.Add(CreateLanguage16ShortColumn());
			}
			if (Columns.FindByUId(new Guid("78788498-e85a-4f3b-8f48-7ed04f1de4b9")) == null) {
				Columns.Add(CreateLanguage17ShortColumn());
			}
			if (Columns.FindByUId(new Guid("a14c9923-c42f-412c-a77a-8db648f1a96f")) == null) {
				Columns.Add(CreateLanguage18ShortColumn());
			}
			if (Columns.FindByUId(new Guid("7180df09-88b4-4a6c-9377-d5ca0c5033f3")) == null) {
				Columns.Add(CreateLanguage19ShortColumn());
			}
			if (Columns.FindByUId(new Guid("d9456e2d-9f91-4e35-8119-76a2f5fcd12e")) == null) {
				Columns.Add(CreateLanguage20ShortColumn());
			}
			if (Columns.FindByUId(new Guid("c8d1375f-4386-49e4-a525-bffee6457acd")) == null) {
				Columns.Add(CreateLanguage21ShortColumn());
			}
			if (Columns.FindByUId(new Guid("a778af48-7eb9-40f0-844d-26a4789dc26e")) == null) {
				Columns.Add(CreateLanguage22ShortColumn());
			}
			if (Columns.FindByUId(new Guid("449f9fee-6e85-4338-9f6c-b5920fa3cf9f")) == null) {
				Columns.Add(CreateLanguage23ShortColumn());
			}
			if (Columns.FindByUId(new Guid("d39f10b9-8ccd-49f6-8515-75d4209d0064")) == null) {
				Columns.Add(CreateLanguage24ShortColumn());
			}
			if (Columns.FindByUId(new Guid("b94e98db-e7bc-4030-8acc-1b422110676b")) == null) {
				Columns.Add(CreateLanguage25ShortColumn());
			}
			if (Columns.FindByUId(new Guid("17f99c85-5618-4649-9189-609b170b9b88")) == null) {
				Columns.Add(CreateLanguage26ShortColumn());
			}
			if (Columns.FindByUId(new Guid("53d7cb24-7e6b-4331-aa8a-146c0600e750")) == null) {
				Columns.Add(CreateLanguage27ShortColumn());
			}
			if (Columns.FindByUId(new Guid("f75e0b47-7c3a-4059-8c94-26609978b6f7")) == null) {
				Columns.Add(CreateLanguage28ShortColumn());
			}
			if (Columns.FindByUId(new Guid("bfc8fa4c-293e-4f23-8366-a262a3c0b1ad")) == null) {
				Columns.Add(CreateLanguage29ShortColumn());
			}
			if (Columns.FindByUId(new Guid("cd1f2eb5-91f5-4588-851b-1b39ff76782e")) == null) {
				Columns.Add(CreateLanguage30ShortColumn());
			}
			if (Columns.FindByUId(new Guid("57b0e5bd-8222-4e20-8e5c-85b88c2f21b8")) == null) {
				Columns.Add(CreateErrorMessageColumn());
			}
			if (Columns.FindByUId(new Guid("ef07d070-6d91-e242-d162-9d2fd0d1ff3e")) == null) {
				Columns.Add(CreateIsVerified35Column());
			}
			if (Columns.FindByUId(new Guid("5316a436-94f8-efca-9fd7-db94895c2956")) == null) {
				Columns.Add(CreateIsVerified34Column());
			}
			if (Columns.FindByUId(new Guid("e52bd629-6c8e-144b-f73c-08006c24a9de")) == null) {
				Columns.Add(CreateIsVerified33Column());
			}
			if (Columns.FindByUId(new Guid("120d00e8-9993-fa99-a2f4-fb273baff63c")) == null) {
				Columns.Add(CreateIsVerified32Column());
			}
			if (Columns.FindByUId(new Guid("e0a0a035-ebac-6bf7-0f22-91783d10de34")) == null) {
				Columns.Add(CreateIsVerified31Column());
			}
			if (Columns.FindByUId(new Guid("27ca62c6-ef1e-7bc7-f1d9-b715d2613b3b")) == null) {
				Columns.Add(CreateIsChanged35Column());
			}
			if (Columns.FindByUId(new Guid("5039736e-d364-d5bc-8dd9-c88f6cbbeea0")) == null) {
				Columns.Add(CreateIsChanged34Column());
			}
			if (Columns.FindByUId(new Guid("c010b004-6b92-5825-c464-f48a9cfdd077")) == null) {
				Columns.Add(CreateIsChanged33Column());
			}
			if (Columns.FindByUId(new Guid("8b43b173-5d37-38da-c240-f72db0502435")) == null) {
				Columns.Add(CreateIsChanged32Column());
			}
			if (Columns.FindByUId(new Guid("0225ae48-3ae0-3be1-b618-a792623031bd")) == null) {
				Columns.Add(CreateIsChanged31Column());
			}
			if (Columns.FindByUId(new Guid("9a1072e0-bf3d-40cd-aee8-d9418b8f9423")) == null) {
				Columns.Add(CreateLanguage35Column());
			}
			if (Columns.FindByUId(new Guid("a2ca2365-c683-6cda-0489-61db4f659517")) == null) {
				Columns.Add(CreateLanguage34Column());
			}
			if (Columns.FindByUId(new Guid("9034dc03-1877-ec1b-c14d-30f8c3c0d47f")) == null) {
				Columns.Add(CreateLanguage33Column());
			}
			if (Columns.FindByUId(new Guid("d3b9b9d0-c529-24a9-6b95-c3eeac8adc12")) == null) {
				Columns.Add(CreateLanguage32Column());
			}
			if (Columns.FindByUId(new Guid("ebf54aea-6be2-65c0-f0d0-fd0056a3228c")) == null) {
				Columns.Add(CreateLanguage31Column());
			}
			if (Columns.FindByUId(new Guid("4c796d05-9046-385c-eed6-952c4fdf5df4")) == null) {
				Columns.Add(CreateLanguage35ShortColumn());
			}
			if (Columns.FindByUId(new Guid("c72968a5-7e5d-db40-5b64-3d12af98decd")) == null) {
				Columns.Add(CreateLanguage34ShortColumn());
			}
			if (Columns.FindByUId(new Guid("b1579c2d-0549-fdef-0682-755281e9c113")) == null) {
				Columns.Add(CreateLanguage33ShortColumn());
			}
			if (Columns.FindByUId(new Guid("5c025ba8-44ad-2663-f87d-e776a4268b6e")) == null) {
				Columns.Add(CreateLanguage32ShortColumn());
			}
			if (Columns.FindByUId(new Guid("9b44f8ac-5e91-f945-26a3-4541fd4a0131")) == null) {
				Columns.Add(CreateLanguage31ShortColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4e54682a-31c5-4ec3-b1e9-d291901bfc9e"),
				Name = @"Key",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage0Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2ec7a8e1-bda1-45f1-8038-8c9d6ee310ed"),
				Name = @"Language0",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d6083d73-a1ce-4f49-8cb8-01de8db77af6"),
				Name = @"Language1",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("113fb377-47d2-444b-b8d4-0847dbb63ca3"),
				Name = @"Language2",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7a63c135-6350-4e15-af20-ae7553afd1e9"),
				Name = @"Language3",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("db708816-23d4-43bd-8eb7-5f46a021f2c3"),
				Name = @"Language4",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1deada4-b1d5-4d72-b92b-5ee7a9dcf808"),
				Name = @"Language5",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e02df9b3-41a3-48f2-ada7-f646b4e6cf46"),
				Name = @"Language6",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7a28646b-7a1d-46fd-a095-638905442eaf"),
				Name = @"Language7",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("312972d9-b3a7-4647-9e3f-ef1dd53867bf"),
				Name = @"Language8",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a159185b-84dd-4fe8-a21b-e27b7f1ae509"),
				Name = @"Language9",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified0Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5551a508-bb63-4e92-abcc-459226c10967"),
				Name = @"IsVerified0",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f9fd8b05-9437-499a-bd61-4fb757c5e93a"),
				Name = @"IsVerified1",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("70ebca63-31fd-4660-aca0-f121d8364f8d"),
				Name = @"IsVerified2",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8ba15eda-adf6-40cd-a328-5486b63e7e83"),
				Name = @"IsVerified3",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("67ad9d20-ff6c-4be5-bdcd-c88425f2b88c"),
				Name = @"IsVerified4",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("127a8bf4-4468-4cab-b3ff-7c2337e9c0ec"),
				Name = @"IsVerified5",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4bf92d3a-9799-4ae3-9540-13a4ae135ce2"),
				Name = @"IsVerified6",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5052c476-9f8e-4220-95fa-c75d1042b7d0"),
				Name = @"IsVerified7",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c0297e29-a2e8-43a8-8537-d8a92a358fb9"),
				Name = @"IsVerified8",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cf773afc-033f-48db-99de-d52c78c848cf"),
				Name = @"IsVerified9",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("bfca9347-f1f5-488e-aaab-4b6bdd3d61fe")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged0Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8cb78c5b-b362-4c6d-ae55-665a29ebbec0"),
				Name = @"IsChanged0",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("db362f56-b1ec-4efc-b1a6-f25ac4e66c9c"),
				Name = @"IsChanged1",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("249f0a0e-5b79-445d-ae09-62c431e62802"),
				Name = @"IsChanged2",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1f10ced2-9735-498e-a313-5c798e0c48e2"),
				Name = @"IsChanged3",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f3a685ec-f704-4e02-bff9-5d7b62a99548"),
				Name = @"IsChanged4",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("90f169b1-6f0a-498f-8f6e-a8c1d429e39c"),
				Name = @"IsChanged5",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("472f1dc3-eac2-4f2c-8831-366cc3eaf84c"),
				Name = @"IsChanged6",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2cb95690-896f-486c-8be4-5dff742fffec"),
				Name = @"IsChanged7",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("88a18436-7505-4c77-9bef-a44e2dbea4b6"),
				Name = @"IsChanged8",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("584d8f47-54e4-44dd-882b-01c6ed74c2ef"),
				Name = @"IsChanged9",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b660805a-93ce-4205-8c07-5ea919badfb0"),
				Name = @"Language10",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage11Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2895cab7-493e-4fa0-b4c8-feccfeab8d16"),
				Name = @"Language11",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage12Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("25f36736-1938-4fa4-996d-bb17f6933fc3"),
				Name = @"Language12",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage13Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("60838d5f-7537-44fd-ad1f-4bdb50a54541"),
				Name = @"Language13",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage14Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b3ee34f3-ce8d-436f-b675-cd8c9c224df8"),
				Name = @"Language14",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage15Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7a937094-5dc2-4a32-95da-06e00f1139e0"),
				Name = @"Language15",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage16Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("35d10ee8-41dc-48bf-8659-568cdef39c0a"),
				Name = @"Language16",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage17Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8c82395d-354d-451d-aad9-ec3ebf5de014"),
				Name = @"Language17",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage18Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e9ed5185-278f-4a43-a061-29e948852e32"),
				Name = @"Language18",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage19Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("31388a0e-8db5-4496-aa7a-04303f7fe5fd"),
				Name = @"Language19",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage20Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d416a27a-0a72-4638-813e-9feff82b71cc"),
				Name = @"Language20",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage21Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("bf358b7e-6e84-43d1-9150-d65f579aea87"),
				Name = @"Language21",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage22Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ff995c89-7283-44bd-b06e-a5c402b02988"),
				Name = @"Language22",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage23Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e0eef4f9-5d80-42c3-a213-d9b2316819a7"),
				Name = @"Language23",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage24Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c97d0e51-e6e4-459f-ab83-de017c36ab2f"),
				Name = @"Language24",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage25Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("99ff77a8-b873-4ce0-bb20-64696be2c627"),
				Name = @"Language25",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage26Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3b872cdb-cd76-4891-992d-da4b5337ded6"),
				Name = @"Language26",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage27Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("bfdd9315-a491-4272-b9c2-e1dc49b85ba5"),
				Name = @"Language27",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage28Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d7f3dd56-94fe-4922-9974-37db8bdf932b"),
				Name = @"Language28",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage29Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7fba7ad8-cb09-46b7-aa22-4fced486e021"),
				Name = @"Language29",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage30Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e14a9e9b-cc27-42f5-bbda-5bba8348a5ca"),
				Name = @"Language30",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("363ce737-e745-4c50-ab60-75214785f4d8"),
				Name = @"IsVerified10",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified11Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a9555a78-3734-4fb7-b5b9-ea000313d4a1"),
				Name = @"IsVerified11",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified12Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("72f0c330-fd85-4c81-bf09-e846eaf0e01c"),
				Name = @"IsVerified12",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified13Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1a8e092e-4f69-4adb-8318-e06815073178"),
				Name = @"IsVerified13",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified14Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c8601f44-b46c-4080-8ed9-d388be1e9a43"),
				Name = @"IsVerified14",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified15Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5f701f56-4cae-460d-a8f0-08f3e4255e77"),
				Name = @"IsVerified15",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified16Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5ee1b637-4766-40da-98a0-a3a8dd6a3df3"),
				Name = @"IsVerified16",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified17Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8c14177f-643c-4f56-ac50-edfdc50b74ff"),
				Name = @"IsVerified17",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified18Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6f35fc91-a078-461f-b7a2-65d79fad86e3"),
				Name = @"IsVerified18",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified19Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("84f672ab-d268-4084-a96d-721b7cbacd2a"),
				Name = @"IsVerified19",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified20Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("dd2f9d93-1cef-4e0f-ac70-c0f0bf2f8d42"),
				Name = @"IsVerified20",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified21Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6ff14239-5454-4450-a00f-86eabb7ec06a"),
				Name = @"IsVerified21",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified22Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6a9c8d59-6e76-4b5f-8bfc-a4a659827f86"),
				Name = @"IsVerified22",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified23Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("eddc2538-c371-499d-99fb-134827bba9b7"),
				Name = @"IsVerified23",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified24Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0b79d6b3-6d1a-429e-a12a-179ce5828a2a"),
				Name = @"IsVerified24",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified25Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6772bde1-06b6-49a9-a306-94b3daf6bbc7"),
				Name = @"IsVerified25",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified26Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c3ca9919-eed4-4bcd-86a7-defc66b0e397"),
				Name = @"IsVerified26",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified27Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7fe2dae2-708d-4b86-914c-4fad61c5da5d"),
				Name = @"IsVerified27",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified28Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e5716d37-153d-4385-bcaa-8c0da867bee9"),
				Name = @"IsVerified28",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified29Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("23d06938-2239-4c15-b8a1-b39ee6b05eb0"),
				Name = @"IsVerified29",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified30Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8892f5ee-d627-41cc-afec-de4355272014"),
				Name = @"IsVerified30",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("98449d55-0dce-4e49-ba6f-373c599f4e57"),
				Name = @"IsChanged10",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged11Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("241dd570-e9cf-4b72-8c30-5f76e58c8c2b"),
				Name = @"IsChanged11",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged12Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3e757d67-38d3-4842-a9f7-3312efb6b411"),
				Name = @"IsChanged12",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged13Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("163c3906-00dd-4c20-8c82-785ad579ede7"),
				Name = @"IsChanged13",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged14Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d7eb9557-486f-405d-ac92-4294c352628e"),
				Name = @"IsChanged14",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged15Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f0841c66-af84-49c4-ab03-e9f7a349facf"),
				Name = @"IsChanged15",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged16Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("722faacd-d97d-4b64-8661-c07472086a25"),
				Name = @"IsChanged16",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged17Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("af96d99c-ec23-4043-bde8-f97e7db3ed8e"),
				Name = @"IsChanged17",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged18Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5c0e60f4-b9ba-496f-b56a-50dbdebb898c"),
				Name = @"IsChanged18",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged19Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("96d13aa6-c170-4694-ae0d-d0463651e41d"),
				Name = @"IsChanged19",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged20Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("49d434fa-e9e7-4cba-9fd9-5a0306d3d2b7"),
				Name = @"IsChanged20",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged21Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0df6886f-97eb-4752-82a8-0da5dee6249c"),
				Name = @"IsChanged21",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged22Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("39ef4e05-1810-4cb6-a977-23f681dd659d"),
				Name = @"IsChanged22",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged23Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("26a7838b-a83d-43c6-a396-a17936c07a17"),
				Name = @"IsChanged23",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged24Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0cdd4104-cdc1-4b57-8483-01a43244859e"),
				Name = @"IsChanged24",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged25Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9f1041fe-571e-4a58-b68e-9f728f488f9c"),
				Name = @"IsChanged25",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged26Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d4fe99db-e84c-49c2-a768-f6652ee1acfe"),
				Name = @"IsChanged26",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged27Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("419266c3-e19b-4b2c-83ef-9d2a9b936187"),
				Name = @"IsChanged27",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged28Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("02036514-fbb6-463d-9e07-cd89369e00f8"),
				Name = @"IsChanged28",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged29Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("aa124d6e-753c-45eb-939c-d61fc83d0fce"),
				Name = @"IsChanged29",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged30Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("addfc1e0-c1e6-4561-b00b-74f7c123da75"),
				Name = @"IsChanged30",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage0ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ead9f0f9-8b1b-4b01-9909-c0c388bc3d87"),
				Name = @"Language0Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage1ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ce3656a3-ad7d-4a5d-bb9e-3ee49ff631de"),
				Name = @"Language1Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage2ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cc6140b8-79de-44ea-8c87-bbdb8b119be3"),
				Name = @"Language2Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage3ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("aad4b88c-e4b5-441b-abbd-1178462e7eb2"),
				Name = @"Language3Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage4ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("42a45adf-2690-4271-9578-c786a4695796"),
				Name = @"Language4Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage5ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("993dc791-47a4-4b76-a58e-df13a575d462"),
				Name = @"Language5Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage6ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("44ea85a1-46a7-40df-a981-9bd9898f80b9"),
				Name = @"Language6Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage7ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f587e1f0-cd1a-497e-9817-09bc3a381b48"),
				Name = @"Language7Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage8ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0f3b754a-2b40-4a80-934b-97c8e9a09772"),
				Name = @"Language8Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage9ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5056540b-d232-4b74-a299-4225acdb1847"),
				Name = @"Language9Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage10ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0cf89ab4-26e0-4f23-a0d7-f721d39eaaa0"),
				Name = @"Language10Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage11ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("40a049ca-a293-43c5-9304-661202c1d86a"),
				Name = @"Language11Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage12ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4ddf08b2-2767-4afd-8bc3-4229e0ccd8d3"),
				Name = @"Language12Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage13ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("41e6bdee-287e-4caa-82e2-4ddc5092ca49"),
				Name = @"Language13Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage14ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fddf606f-3c8f-433f-b9a4-bffbad5cec20"),
				Name = @"Language14Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage15ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4b682718-9aa5-4834-af36-f2af4a5e68ad"),
				Name = @"Language15Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage16ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ec08203f-22a8-472b-b6f7-2ac332fc5f85"),
				Name = @"Language16Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage17ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("78788498-e85a-4f3b-8f48-7ed04f1de4b9"),
				Name = @"Language17Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage18ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a14c9923-c42f-412c-a77a-8db648f1a96f"),
				Name = @"Language18Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage19ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7180df09-88b4-4a6c-9377-d5ca0c5033f3"),
				Name = @"Language19Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage20ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d9456e2d-9f91-4e35-8119-76a2f5fcd12e"),
				Name = @"Language20Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage21ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c8d1375f-4386-49e4-a525-bffee6457acd"),
				Name = @"Language21Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage22ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a778af48-7eb9-40f0-844d-26a4789dc26e"),
				Name = @"Language22Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage23ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("449f9fee-6e85-4338-9f6c-b5920fa3cf9f"),
				Name = @"Language23Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage24ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d39f10b9-8ccd-49f6-8515-75d4209d0064"),
				Name = @"Language24Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage25ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b94e98db-e7bc-4030-8acc-1b422110676b"),
				Name = @"Language25Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage26ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("17f99c85-5618-4649-9189-609b170b9b88"),
				Name = @"Language26Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage27ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("53d7cb24-7e6b-4331-aa8a-146c0600e750"),
				Name = @"Language27Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage28ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f75e0b47-7c3a-4059-8c94-26609978b6f7"),
				Name = @"Language28Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage29ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bfc8fa4c-293e-4f23-8366-a262a3c0b1ad"),
				Name = @"Language29Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage30ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cd1f2eb5-91f5-4588-851b-1b39ff76782e"),
				Name = @"Language30Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("4f20c153-048f-4a5e-b76c-c7a7749e359a")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("57b0e5bd-8222-4e20-8e5c-85b88c2f21b8"),
				Name = @"ErrorMessage",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified35Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ef07d070-6d91-e242-d162-9d2fd0d1ff3e"),
				Name = @"IsVerified35",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified34Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5316a436-94f8-efca-9fd7-db94895c2956"),
				Name = @"IsVerified34",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified33Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e52bd629-6c8e-144b-f73c-08006c24a9de"),
				Name = @"IsVerified33",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified32Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("120d00e8-9993-fa99-a2f4-fb273baff63c"),
				Name = @"IsVerified32",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsVerified31Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e0a0a035-ebac-6bf7-0f22-91783d10de34"),
				Name = @"IsVerified31",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged35Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("27ca62c6-ef1e-7bc7-f1d9-b715d2613b3b"),
				Name = @"IsChanged35",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged34Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5039736e-d364-d5bc-8dd9-c88f6cbbeea0"),
				Name = @"IsChanged34",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged33Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c010b004-6b92-5825-c464-f48a9cfdd077"),
				Name = @"IsChanged33",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged32Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8b43b173-5d37-38da-c240-f72db0502435"),
				Name = @"IsChanged32",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChanged31Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0225ae48-3ae0-3be1-b618-a792623031bd"),
				Name = @"IsChanged31",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage35Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9a1072e0-bf3d-40cd-aee8-d9418b8f9423"),
				Name = @"Language35",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage34Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a2ca2365-c683-6cda-0489-61db4f659517"),
				Name = @"Language34",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage33Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9034dc03-1877-ec1b-c14d-30f8c3c0d47f"),
				Name = @"Language33",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage32Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d3b9b9d0-c529-24a9-6b95-c3eeac8adc12"),
				Name = @"Language32",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage31Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ebf54aea-6be2-65c0-f0d0-fd0056a3228c"),
				Name = @"Language31",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage35ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4c796d05-9046-385c-eed6-952c4fdf5df4"),
				Name = @"Language35Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage34ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c72968a5-7e5d-db40-5b64-3d12af98decd"),
				Name = @"Language34Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage33ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b1579c2d-0549-fdef-0682-755281e9c113"),
				Name = @"Language33Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage32ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5c025ba8-44ad-2663-f87d-e776a4268b6e"),
				Name = @"Language32Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguage31ShortColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9b44f8ac-5e91-f945-26a3-4541fd4a0131"),
				Name = @"Language31Short",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				ModifiedInSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"),
				CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateSysTranslationKeyIndexIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTranslation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTranslation_TranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTranslationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTranslationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslation

	/// <summary>
	/// Translation.
	/// </summary>
	public class SysTranslation : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysTranslation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTranslation";
		}

		public SysTranslation(SysTranslation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Language0.
		/// </summary>
		public string Language0 {
			get {
				return GetTypedColumnValue<string>("Language0");
			}
			set {
				SetColumnValue("Language0", value);
			}
		}

		/// <summary>
		/// Language1.
		/// </summary>
		public string Language1 {
			get {
				return GetTypedColumnValue<string>("Language1");
			}
			set {
				SetColumnValue("Language1", value);
			}
		}

		/// <summary>
		/// Language2.
		/// </summary>
		public string Language2 {
			get {
				return GetTypedColumnValue<string>("Language2");
			}
			set {
				SetColumnValue("Language2", value);
			}
		}

		/// <summary>
		/// Language3.
		/// </summary>
		public string Language3 {
			get {
				return GetTypedColumnValue<string>("Language3");
			}
			set {
				SetColumnValue("Language3", value);
			}
		}

		/// <summary>
		/// Language4.
		/// </summary>
		public string Language4 {
			get {
				return GetTypedColumnValue<string>("Language4");
			}
			set {
				SetColumnValue("Language4", value);
			}
		}

		/// <summary>
		/// Language5.
		/// </summary>
		public string Language5 {
			get {
				return GetTypedColumnValue<string>("Language5");
			}
			set {
				SetColumnValue("Language5", value);
			}
		}

		/// <summary>
		/// Language6.
		/// </summary>
		public string Language6 {
			get {
				return GetTypedColumnValue<string>("Language6");
			}
			set {
				SetColumnValue("Language6", value);
			}
		}

		/// <summary>
		/// Language7.
		/// </summary>
		public string Language7 {
			get {
				return GetTypedColumnValue<string>("Language7");
			}
			set {
				SetColumnValue("Language7", value);
			}
		}

		/// <summary>
		/// Language8.
		/// </summary>
		public string Language8 {
			get {
				return GetTypedColumnValue<string>("Language8");
			}
			set {
				SetColumnValue("Language8", value);
			}
		}

		/// <summary>
		/// Language9.
		/// </summary>
		public string Language9 {
			get {
				return GetTypedColumnValue<string>("Language9");
			}
			set {
				SetColumnValue("Language9", value);
			}
		}

		/// <summary>
		/// IsVerified0.
		/// </summary>
		public bool IsVerified0 {
			get {
				return GetTypedColumnValue<bool>("IsVerified0");
			}
			set {
				SetColumnValue("IsVerified0", value);
			}
		}

		/// <summary>
		/// IsVerified1.
		/// </summary>
		public bool IsVerified1 {
			get {
				return GetTypedColumnValue<bool>("IsVerified1");
			}
			set {
				SetColumnValue("IsVerified1", value);
			}
		}

		/// <summary>
		/// IsVerified0.
		/// </summary>
		public bool IsVerified2 {
			get {
				return GetTypedColumnValue<bool>("IsVerified2");
			}
			set {
				SetColumnValue("IsVerified2", value);
			}
		}

		/// <summary>
		/// IsVerified3.
		/// </summary>
		public bool IsVerified3 {
			get {
				return GetTypedColumnValue<bool>("IsVerified3");
			}
			set {
				SetColumnValue("IsVerified3", value);
			}
		}

		/// <summary>
		/// IsVerified4.
		/// </summary>
		public bool IsVerified4 {
			get {
				return GetTypedColumnValue<bool>("IsVerified4");
			}
			set {
				SetColumnValue("IsVerified4", value);
			}
		}

		/// <summary>
		/// IsVerified5.
		/// </summary>
		public bool IsVerified5 {
			get {
				return GetTypedColumnValue<bool>("IsVerified5");
			}
			set {
				SetColumnValue("IsVerified5", value);
			}
		}

		/// <summary>
		/// IsVerified6.
		/// </summary>
		public bool IsVerified6 {
			get {
				return GetTypedColumnValue<bool>("IsVerified6");
			}
			set {
				SetColumnValue("IsVerified6", value);
			}
		}

		/// <summary>
		/// IsVerified7.
		/// </summary>
		public bool IsVerified7 {
			get {
				return GetTypedColumnValue<bool>("IsVerified7");
			}
			set {
				SetColumnValue("IsVerified7", value);
			}
		}

		/// <summary>
		/// IsVerified8.
		/// </summary>
		public bool IsVerified8 {
			get {
				return GetTypedColumnValue<bool>("IsVerified8");
			}
			set {
				SetColumnValue("IsVerified8", value);
			}
		}

		/// <summary>
		/// IsVerified9.
		/// </summary>
		public bool IsVerified9 {
			get {
				return GetTypedColumnValue<bool>("IsVerified9");
			}
			set {
				SetColumnValue("IsVerified9", value);
			}
		}

		/// <summary>
		/// IsChanged0.
		/// </summary>
		public bool IsChanged0 {
			get {
				return GetTypedColumnValue<bool>("IsChanged0");
			}
			set {
				SetColumnValue("IsChanged0", value);
			}
		}

		/// <summary>
		/// IsChanged1.
		/// </summary>
		public bool IsChanged1 {
			get {
				return GetTypedColumnValue<bool>("IsChanged1");
			}
			set {
				SetColumnValue("IsChanged1", value);
			}
		}

		/// <summary>
		/// IsChanged2.
		/// </summary>
		public bool IsChanged2 {
			get {
				return GetTypedColumnValue<bool>("IsChanged2");
			}
			set {
				SetColumnValue("IsChanged2", value);
			}
		}

		/// <summary>
		/// IsChanged3.
		/// </summary>
		public bool IsChanged3 {
			get {
				return GetTypedColumnValue<bool>("IsChanged3");
			}
			set {
				SetColumnValue("IsChanged3", value);
			}
		}

		/// <summary>
		/// IsChanged4.
		/// </summary>
		public bool IsChanged4 {
			get {
				return GetTypedColumnValue<bool>("IsChanged4");
			}
			set {
				SetColumnValue("IsChanged4", value);
			}
		}

		/// <summary>
		/// IsChanged5.
		/// </summary>
		public bool IsChanged5 {
			get {
				return GetTypedColumnValue<bool>("IsChanged5");
			}
			set {
				SetColumnValue("IsChanged5", value);
			}
		}

		/// <summary>
		/// IsChanged6.
		/// </summary>
		public bool IsChanged6 {
			get {
				return GetTypedColumnValue<bool>("IsChanged6");
			}
			set {
				SetColumnValue("IsChanged6", value);
			}
		}

		/// <summary>
		/// IsChanged7.
		/// </summary>
		public bool IsChanged7 {
			get {
				return GetTypedColumnValue<bool>("IsChanged7");
			}
			set {
				SetColumnValue("IsChanged7", value);
			}
		}

		/// <summary>
		/// IsChanged8.
		/// </summary>
		public bool IsChanged8 {
			get {
				return GetTypedColumnValue<bool>("IsChanged8");
			}
			set {
				SetColumnValue("IsChanged8", value);
			}
		}

		/// <summary>
		/// IsChanged9.
		/// </summary>
		public bool IsChanged9 {
			get {
				return GetTypedColumnValue<bool>("IsChanged9");
			}
			set {
				SetColumnValue("IsChanged9", value);
			}
		}

		/// <summary>
		/// Language10.
		/// </summary>
		public string Language10 {
			get {
				return GetTypedColumnValue<string>("Language10");
			}
			set {
				SetColumnValue("Language10", value);
			}
		}

		/// <summary>
		/// Language11.
		/// </summary>
		public string Language11 {
			get {
				return GetTypedColumnValue<string>("Language11");
			}
			set {
				SetColumnValue("Language11", value);
			}
		}

		/// <summary>
		/// Language12.
		/// </summary>
		public string Language12 {
			get {
				return GetTypedColumnValue<string>("Language12");
			}
			set {
				SetColumnValue("Language12", value);
			}
		}

		/// <summary>
		/// Language13.
		/// </summary>
		public string Language13 {
			get {
				return GetTypedColumnValue<string>("Language13");
			}
			set {
				SetColumnValue("Language13", value);
			}
		}

		/// <summary>
		/// Language14.
		/// </summary>
		public string Language14 {
			get {
				return GetTypedColumnValue<string>("Language14");
			}
			set {
				SetColumnValue("Language14", value);
			}
		}

		/// <summary>
		/// Language15.
		/// </summary>
		public string Language15 {
			get {
				return GetTypedColumnValue<string>("Language15");
			}
			set {
				SetColumnValue("Language15", value);
			}
		}

		/// <summary>
		/// Language16.
		/// </summary>
		public string Language16 {
			get {
				return GetTypedColumnValue<string>("Language16");
			}
			set {
				SetColumnValue("Language16", value);
			}
		}

		/// <summary>
		/// Language17.
		/// </summary>
		public string Language17 {
			get {
				return GetTypedColumnValue<string>("Language17");
			}
			set {
				SetColumnValue("Language17", value);
			}
		}

		/// <summary>
		/// Language18.
		/// </summary>
		public string Language18 {
			get {
				return GetTypedColumnValue<string>("Language18");
			}
			set {
				SetColumnValue("Language18", value);
			}
		}

		/// <summary>
		/// Language19.
		/// </summary>
		public string Language19 {
			get {
				return GetTypedColumnValue<string>("Language19");
			}
			set {
				SetColumnValue("Language19", value);
			}
		}

		/// <summary>
		/// Language20.
		/// </summary>
		public string Language20 {
			get {
				return GetTypedColumnValue<string>("Language20");
			}
			set {
				SetColumnValue("Language20", value);
			}
		}

		/// <summary>
		/// Language21.
		/// </summary>
		public string Language21 {
			get {
				return GetTypedColumnValue<string>("Language21");
			}
			set {
				SetColumnValue("Language21", value);
			}
		}

		/// <summary>
		/// Language22.
		/// </summary>
		public string Language22 {
			get {
				return GetTypedColumnValue<string>("Language22");
			}
			set {
				SetColumnValue("Language22", value);
			}
		}

		/// <summary>
		/// Language23.
		/// </summary>
		public string Language23 {
			get {
				return GetTypedColumnValue<string>("Language23");
			}
			set {
				SetColumnValue("Language23", value);
			}
		}

		/// <summary>
		/// Language24.
		/// </summary>
		public string Language24 {
			get {
				return GetTypedColumnValue<string>("Language24");
			}
			set {
				SetColumnValue("Language24", value);
			}
		}

		/// <summary>
		/// Language25.
		/// </summary>
		public string Language25 {
			get {
				return GetTypedColumnValue<string>("Language25");
			}
			set {
				SetColumnValue("Language25", value);
			}
		}

		/// <summary>
		/// Language26.
		/// </summary>
		public string Language26 {
			get {
				return GetTypedColumnValue<string>("Language26");
			}
			set {
				SetColumnValue("Language26", value);
			}
		}

		/// <summary>
		/// Language27.
		/// </summary>
		public string Language27 {
			get {
				return GetTypedColumnValue<string>("Language27");
			}
			set {
				SetColumnValue("Language27", value);
			}
		}

		/// <summary>
		/// Language28.
		/// </summary>
		public string Language28 {
			get {
				return GetTypedColumnValue<string>("Language28");
			}
			set {
				SetColumnValue("Language28", value);
			}
		}

		/// <summary>
		/// Language29.
		/// </summary>
		public string Language29 {
			get {
				return GetTypedColumnValue<string>("Language29");
			}
			set {
				SetColumnValue("Language29", value);
			}
		}

		/// <summary>
		/// Language30.
		/// </summary>
		public string Language30 {
			get {
				return GetTypedColumnValue<string>("Language30");
			}
			set {
				SetColumnValue("Language30", value);
			}
		}

		/// <summary>
		/// IsVerified10.
		/// </summary>
		public bool IsVerified10 {
			get {
				return GetTypedColumnValue<bool>("IsVerified10");
			}
			set {
				SetColumnValue("IsVerified10", value);
			}
		}

		/// <summary>
		/// IsVerified11.
		/// </summary>
		public bool IsVerified11 {
			get {
				return GetTypedColumnValue<bool>("IsVerified11");
			}
			set {
				SetColumnValue("IsVerified11", value);
			}
		}

		/// <summary>
		/// IsVerified12.
		/// </summary>
		public bool IsVerified12 {
			get {
				return GetTypedColumnValue<bool>("IsVerified12");
			}
			set {
				SetColumnValue("IsVerified12", value);
			}
		}

		/// <summary>
		/// IsVerified13.
		/// </summary>
		public bool IsVerified13 {
			get {
				return GetTypedColumnValue<bool>("IsVerified13");
			}
			set {
				SetColumnValue("IsVerified13", value);
			}
		}

		/// <summary>
		/// IsVerified14.
		/// </summary>
		public bool IsVerified14 {
			get {
				return GetTypedColumnValue<bool>("IsVerified14");
			}
			set {
				SetColumnValue("IsVerified14", value);
			}
		}

		/// <summary>
		/// IsVerified15.
		/// </summary>
		public bool IsVerified15 {
			get {
				return GetTypedColumnValue<bool>("IsVerified15");
			}
			set {
				SetColumnValue("IsVerified15", value);
			}
		}

		/// <summary>
		/// IsVerified16.
		/// </summary>
		public bool IsVerified16 {
			get {
				return GetTypedColumnValue<bool>("IsVerified16");
			}
			set {
				SetColumnValue("IsVerified16", value);
			}
		}

		/// <summary>
		/// IsVerified17.
		/// </summary>
		public bool IsVerified17 {
			get {
				return GetTypedColumnValue<bool>("IsVerified17");
			}
			set {
				SetColumnValue("IsVerified17", value);
			}
		}

		/// <summary>
		/// IsVerified18.
		/// </summary>
		public bool IsVerified18 {
			get {
				return GetTypedColumnValue<bool>("IsVerified18");
			}
			set {
				SetColumnValue("IsVerified18", value);
			}
		}

		/// <summary>
		/// IsVerified19.
		/// </summary>
		public bool IsVerified19 {
			get {
				return GetTypedColumnValue<bool>("IsVerified19");
			}
			set {
				SetColumnValue("IsVerified19", value);
			}
		}

		/// <summary>
		/// IsVerified20.
		/// </summary>
		public bool IsVerified20 {
			get {
				return GetTypedColumnValue<bool>("IsVerified20");
			}
			set {
				SetColumnValue("IsVerified20", value);
			}
		}

		/// <summary>
		/// IsVerified21.
		/// </summary>
		public bool IsVerified21 {
			get {
				return GetTypedColumnValue<bool>("IsVerified21");
			}
			set {
				SetColumnValue("IsVerified21", value);
			}
		}

		/// <summary>
		/// IsVerified22.
		/// </summary>
		public bool IsVerified22 {
			get {
				return GetTypedColumnValue<bool>("IsVerified22");
			}
			set {
				SetColumnValue("IsVerified22", value);
			}
		}

		/// <summary>
		/// IsVerified23.
		/// </summary>
		public bool IsVerified23 {
			get {
				return GetTypedColumnValue<bool>("IsVerified23");
			}
			set {
				SetColumnValue("IsVerified23", value);
			}
		}

		/// <summary>
		/// IsVerified24.
		/// </summary>
		public bool IsVerified24 {
			get {
				return GetTypedColumnValue<bool>("IsVerified24");
			}
			set {
				SetColumnValue("IsVerified24", value);
			}
		}

		/// <summary>
		/// IsVerified25.
		/// </summary>
		public bool IsVerified25 {
			get {
				return GetTypedColumnValue<bool>("IsVerified25");
			}
			set {
				SetColumnValue("IsVerified25", value);
			}
		}

		/// <summary>
		/// IsVerified26.
		/// </summary>
		public bool IsVerified26 {
			get {
				return GetTypedColumnValue<bool>("IsVerified26");
			}
			set {
				SetColumnValue("IsVerified26", value);
			}
		}

		/// <summary>
		/// IsVerified27.
		/// </summary>
		public bool IsVerified27 {
			get {
				return GetTypedColumnValue<bool>("IsVerified27");
			}
			set {
				SetColumnValue("IsVerified27", value);
			}
		}

		/// <summary>
		/// IsVerified28.
		/// </summary>
		public bool IsVerified28 {
			get {
				return GetTypedColumnValue<bool>("IsVerified28");
			}
			set {
				SetColumnValue("IsVerified28", value);
			}
		}

		/// <summary>
		/// IsVerified29.
		/// </summary>
		public bool IsVerified29 {
			get {
				return GetTypedColumnValue<bool>("IsVerified29");
			}
			set {
				SetColumnValue("IsVerified29", value);
			}
		}

		/// <summary>
		/// IsVerified30.
		/// </summary>
		public bool IsVerified30 {
			get {
				return GetTypedColumnValue<bool>("IsVerified30");
			}
			set {
				SetColumnValue("IsVerified30", value);
			}
		}

		/// <summary>
		/// IsChanged10.
		/// </summary>
		public bool IsChanged10 {
			get {
				return GetTypedColumnValue<bool>("IsChanged10");
			}
			set {
				SetColumnValue("IsChanged10", value);
			}
		}

		/// <summary>
		/// IsChanged11.
		/// </summary>
		public bool IsChanged11 {
			get {
				return GetTypedColumnValue<bool>("IsChanged11");
			}
			set {
				SetColumnValue("IsChanged11", value);
			}
		}

		/// <summary>
		/// IsChanged12.
		/// </summary>
		public bool IsChanged12 {
			get {
				return GetTypedColumnValue<bool>("IsChanged12");
			}
			set {
				SetColumnValue("IsChanged12", value);
			}
		}

		/// <summary>
		/// IsChanged13.
		/// </summary>
		public bool IsChanged13 {
			get {
				return GetTypedColumnValue<bool>("IsChanged13");
			}
			set {
				SetColumnValue("IsChanged13", value);
			}
		}

		/// <summary>
		/// IsChanged14.
		/// </summary>
		public bool IsChanged14 {
			get {
				return GetTypedColumnValue<bool>("IsChanged14");
			}
			set {
				SetColumnValue("IsChanged14", value);
			}
		}

		/// <summary>
		/// IsChanged15.
		/// </summary>
		public bool IsChanged15 {
			get {
				return GetTypedColumnValue<bool>("IsChanged15");
			}
			set {
				SetColumnValue("IsChanged15", value);
			}
		}

		/// <summary>
		/// IsChanged16.
		/// </summary>
		public bool IsChanged16 {
			get {
				return GetTypedColumnValue<bool>("IsChanged16");
			}
			set {
				SetColumnValue("IsChanged16", value);
			}
		}

		/// <summary>
		/// IsChanged17.
		/// </summary>
		public bool IsChanged17 {
			get {
				return GetTypedColumnValue<bool>("IsChanged17");
			}
			set {
				SetColumnValue("IsChanged17", value);
			}
		}

		/// <summary>
		/// IsChanged18.
		/// </summary>
		public bool IsChanged18 {
			get {
				return GetTypedColumnValue<bool>("IsChanged18");
			}
			set {
				SetColumnValue("IsChanged18", value);
			}
		}

		/// <summary>
		/// IsChanged19.
		/// </summary>
		public bool IsChanged19 {
			get {
				return GetTypedColumnValue<bool>("IsChanged19");
			}
			set {
				SetColumnValue("IsChanged19", value);
			}
		}

		/// <summary>
		/// IsChanged20.
		/// </summary>
		public bool IsChanged20 {
			get {
				return GetTypedColumnValue<bool>("IsChanged20");
			}
			set {
				SetColumnValue("IsChanged20", value);
			}
		}

		/// <summary>
		/// IsChanged21.
		/// </summary>
		public bool IsChanged21 {
			get {
				return GetTypedColumnValue<bool>("IsChanged21");
			}
			set {
				SetColumnValue("IsChanged21", value);
			}
		}

		/// <summary>
		/// IsChanged22.
		/// </summary>
		public bool IsChanged22 {
			get {
				return GetTypedColumnValue<bool>("IsChanged22");
			}
			set {
				SetColumnValue("IsChanged22", value);
			}
		}

		/// <summary>
		/// IsChanged23.
		/// </summary>
		public bool IsChanged23 {
			get {
				return GetTypedColumnValue<bool>("IsChanged23");
			}
			set {
				SetColumnValue("IsChanged23", value);
			}
		}

		/// <summary>
		/// IsChanged24.
		/// </summary>
		public bool IsChanged24 {
			get {
				return GetTypedColumnValue<bool>("IsChanged24");
			}
			set {
				SetColumnValue("IsChanged24", value);
			}
		}

		/// <summary>
		/// IsChanged25.
		/// </summary>
		public bool IsChanged25 {
			get {
				return GetTypedColumnValue<bool>("IsChanged25");
			}
			set {
				SetColumnValue("IsChanged25", value);
			}
		}

		/// <summary>
		/// IsChanged26.
		/// </summary>
		public bool IsChanged26 {
			get {
				return GetTypedColumnValue<bool>("IsChanged26");
			}
			set {
				SetColumnValue("IsChanged26", value);
			}
		}

		/// <summary>
		/// IsChanged27.
		/// </summary>
		public bool IsChanged27 {
			get {
				return GetTypedColumnValue<bool>("IsChanged27");
			}
			set {
				SetColumnValue("IsChanged27", value);
			}
		}

		/// <summary>
		/// IsChanged28.
		/// </summary>
		public bool IsChanged28 {
			get {
				return GetTypedColumnValue<bool>("IsChanged28");
			}
			set {
				SetColumnValue("IsChanged28", value);
			}
		}

		/// <summary>
		/// IsChanged29.
		/// </summary>
		public bool IsChanged29 {
			get {
				return GetTypedColumnValue<bool>("IsChanged29");
			}
			set {
				SetColumnValue("IsChanged29", value);
			}
		}

		/// <summary>
		/// IsChanged30.
		/// </summary>
		public bool IsChanged30 {
			get {
				return GetTypedColumnValue<bool>("IsChanged30");
			}
			set {
				SetColumnValue("IsChanged30", value);
			}
		}

		/// <summary>
		/// Language0Short.
		/// </summary>
		public string Language0Short {
			get {
				return GetTypedColumnValue<string>("Language0Short");
			}
			set {
				SetColumnValue("Language0Short", value);
			}
		}

		/// <summary>
		/// Language1Short.
		/// </summary>
		public string Language1Short {
			get {
				return GetTypedColumnValue<string>("Language1Short");
			}
			set {
				SetColumnValue("Language1Short", value);
			}
		}

		/// <summary>
		/// Language2Short.
		/// </summary>
		public string Language2Short {
			get {
				return GetTypedColumnValue<string>("Language2Short");
			}
			set {
				SetColumnValue("Language2Short", value);
			}
		}

		/// <summary>
		/// Language3Short.
		/// </summary>
		public string Language3Short {
			get {
				return GetTypedColumnValue<string>("Language3Short");
			}
			set {
				SetColumnValue("Language3Short", value);
			}
		}

		/// <summary>
		/// Language4Short.
		/// </summary>
		public string Language4Short {
			get {
				return GetTypedColumnValue<string>("Language4Short");
			}
			set {
				SetColumnValue("Language4Short", value);
			}
		}

		/// <summary>
		/// Language5Short.
		/// </summary>
		public string Language5Short {
			get {
				return GetTypedColumnValue<string>("Language5Short");
			}
			set {
				SetColumnValue("Language5Short", value);
			}
		}

		/// <summary>
		/// Language6Short.
		/// </summary>
		public string Language6Short {
			get {
				return GetTypedColumnValue<string>("Language6Short");
			}
			set {
				SetColumnValue("Language6Short", value);
			}
		}

		/// <summary>
		/// Language7Short.
		/// </summary>
		public string Language7Short {
			get {
				return GetTypedColumnValue<string>("Language7Short");
			}
			set {
				SetColumnValue("Language7Short", value);
			}
		}

		/// <summary>
		/// Language8Short.
		/// </summary>
		public string Language8Short {
			get {
				return GetTypedColumnValue<string>("Language8Short");
			}
			set {
				SetColumnValue("Language8Short", value);
			}
		}

		/// <summary>
		/// Language9Short.
		/// </summary>
		public string Language9Short {
			get {
				return GetTypedColumnValue<string>("Language9Short");
			}
			set {
				SetColumnValue("Language9Short", value);
			}
		}

		/// <summary>
		/// Language10Short.
		/// </summary>
		public string Language10Short {
			get {
				return GetTypedColumnValue<string>("Language10Short");
			}
			set {
				SetColumnValue("Language10Short", value);
			}
		}

		/// <summary>
		/// Language11Short.
		/// </summary>
		public string Language11Short {
			get {
				return GetTypedColumnValue<string>("Language11Short");
			}
			set {
				SetColumnValue("Language11Short", value);
			}
		}

		/// <summary>
		/// Language12Short.
		/// </summary>
		public string Language12Short {
			get {
				return GetTypedColumnValue<string>("Language12Short");
			}
			set {
				SetColumnValue("Language12Short", value);
			}
		}

		/// <summary>
		/// Language13Short.
		/// </summary>
		public string Language13Short {
			get {
				return GetTypedColumnValue<string>("Language13Short");
			}
			set {
				SetColumnValue("Language13Short", value);
			}
		}

		/// <summary>
		/// Language14Short.
		/// </summary>
		public string Language14Short {
			get {
				return GetTypedColumnValue<string>("Language14Short");
			}
			set {
				SetColumnValue("Language14Short", value);
			}
		}

		/// <summary>
		/// Language15Short.
		/// </summary>
		public string Language15Short {
			get {
				return GetTypedColumnValue<string>("Language15Short");
			}
			set {
				SetColumnValue("Language15Short", value);
			}
		}

		/// <summary>
		/// Language16Short.
		/// </summary>
		public string Language16Short {
			get {
				return GetTypedColumnValue<string>("Language16Short");
			}
			set {
				SetColumnValue("Language16Short", value);
			}
		}

		/// <summary>
		/// Language17Short.
		/// </summary>
		public string Language17Short {
			get {
				return GetTypedColumnValue<string>("Language17Short");
			}
			set {
				SetColumnValue("Language17Short", value);
			}
		}

		/// <summary>
		/// Language18Short.
		/// </summary>
		public string Language18Short {
			get {
				return GetTypedColumnValue<string>("Language18Short");
			}
			set {
				SetColumnValue("Language18Short", value);
			}
		}

		/// <summary>
		/// Language19Short.
		/// </summary>
		public string Language19Short {
			get {
				return GetTypedColumnValue<string>("Language19Short");
			}
			set {
				SetColumnValue("Language19Short", value);
			}
		}

		/// <summary>
		/// Language20Short.
		/// </summary>
		public string Language20Short {
			get {
				return GetTypedColumnValue<string>("Language20Short");
			}
			set {
				SetColumnValue("Language20Short", value);
			}
		}

		/// <summary>
		/// Language21Short.
		/// </summary>
		public string Language21Short {
			get {
				return GetTypedColumnValue<string>("Language21Short");
			}
			set {
				SetColumnValue("Language21Short", value);
			}
		}

		/// <summary>
		/// Language22Short.
		/// </summary>
		public string Language22Short {
			get {
				return GetTypedColumnValue<string>("Language22Short");
			}
			set {
				SetColumnValue("Language22Short", value);
			}
		}

		/// <summary>
		/// Language23Short.
		/// </summary>
		public string Language23Short {
			get {
				return GetTypedColumnValue<string>("Language23Short");
			}
			set {
				SetColumnValue("Language23Short", value);
			}
		}

		/// <summary>
		/// Language24Short.
		/// </summary>
		public string Language24Short {
			get {
				return GetTypedColumnValue<string>("Language24Short");
			}
			set {
				SetColumnValue("Language24Short", value);
			}
		}

		/// <summary>
		/// Language25Short.
		/// </summary>
		public string Language25Short {
			get {
				return GetTypedColumnValue<string>("Language25Short");
			}
			set {
				SetColumnValue("Language25Short", value);
			}
		}

		/// <summary>
		/// Language26Short.
		/// </summary>
		public string Language26Short {
			get {
				return GetTypedColumnValue<string>("Language26Short");
			}
			set {
				SetColumnValue("Language26Short", value);
			}
		}

		/// <summary>
		/// Language27Short.
		/// </summary>
		public string Language27Short {
			get {
				return GetTypedColumnValue<string>("Language27Short");
			}
			set {
				SetColumnValue("Language27Short", value);
			}
		}

		/// <summary>
		/// Language28Short.
		/// </summary>
		public string Language28Short {
			get {
				return GetTypedColumnValue<string>("Language28Short");
			}
			set {
				SetColumnValue("Language28Short", value);
			}
		}

		/// <summary>
		/// Language29Short.
		/// </summary>
		public string Language29Short {
			get {
				return GetTypedColumnValue<string>("Language29Short");
			}
			set {
				SetColumnValue("Language29Short", value);
			}
		}

		/// <summary>
		/// Language30Short.
		/// </summary>
		public string Language30Short {
			get {
				return GetTypedColumnValue<string>("Language30Short");
			}
			set {
				SetColumnValue("Language30Short", value);
			}
		}

		/// <summary>
		/// Error message.
		/// </summary>
		public string ErrorMessage {
			get {
				return GetTypedColumnValue<string>("ErrorMessage");
			}
			set {
				SetColumnValue("ErrorMessage", value);
			}
		}

		/// <summary>
		/// IsVerified35.
		/// </summary>
		public bool IsVerified35 {
			get {
				return GetTypedColumnValue<bool>("IsVerified35");
			}
			set {
				SetColumnValue("IsVerified35", value);
			}
		}

		/// <summary>
		/// IsVerified34.
		/// </summary>
		public bool IsVerified34 {
			get {
				return GetTypedColumnValue<bool>("IsVerified34");
			}
			set {
				SetColumnValue("IsVerified34", value);
			}
		}

		/// <summary>
		/// IsVerified33.
		/// </summary>
		public bool IsVerified33 {
			get {
				return GetTypedColumnValue<bool>("IsVerified33");
			}
			set {
				SetColumnValue("IsVerified33", value);
			}
		}

		/// <summary>
		/// IsVerified32.
		/// </summary>
		public bool IsVerified32 {
			get {
				return GetTypedColumnValue<bool>("IsVerified32");
			}
			set {
				SetColumnValue("IsVerified32", value);
			}
		}

		/// <summary>
		/// IsVerified31.
		/// </summary>
		public bool IsVerified31 {
			get {
				return GetTypedColumnValue<bool>("IsVerified31");
			}
			set {
				SetColumnValue("IsVerified31", value);
			}
		}

		/// <summary>
		/// IsChanged35.
		/// </summary>
		public bool IsChanged35 {
			get {
				return GetTypedColumnValue<bool>("IsChanged35");
			}
			set {
				SetColumnValue("IsChanged35", value);
			}
		}

		/// <summary>
		/// IsChanged34.
		/// </summary>
		public bool IsChanged34 {
			get {
				return GetTypedColumnValue<bool>("IsChanged34");
			}
			set {
				SetColumnValue("IsChanged34", value);
			}
		}

		/// <summary>
		/// IsChanged33.
		/// </summary>
		public bool IsChanged33 {
			get {
				return GetTypedColumnValue<bool>("IsChanged33");
			}
			set {
				SetColumnValue("IsChanged33", value);
			}
		}

		/// <summary>
		/// IsChanged32.
		/// </summary>
		public bool IsChanged32 {
			get {
				return GetTypedColumnValue<bool>("IsChanged32");
			}
			set {
				SetColumnValue("IsChanged32", value);
			}
		}

		/// <summary>
		/// IsChanged31.
		/// </summary>
		public bool IsChanged31 {
			get {
				return GetTypedColumnValue<bool>("IsChanged31");
			}
			set {
				SetColumnValue("IsChanged31", value);
			}
		}

		/// <summary>
		/// Language35.
		/// </summary>
		public string Language35 {
			get {
				return GetTypedColumnValue<string>("Language35");
			}
			set {
				SetColumnValue("Language35", value);
			}
		}

		/// <summary>
		/// Language34.
		/// </summary>
		public string Language34 {
			get {
				return GetTypedColumnValue<string>("Language34");
			}
			set {
				SetColumnValue("Language34", value);
			}
		}

		/// <summary>
		/// Language33.
		/// </summary>
		public string Language33 {
			get {
				return GetTypedColumnValue<string>("Language33");
			}
			set {
				SetColumnValue("Language33", value);
			}
		}

		/// <summary>
		/// Language32.
		/// </summary>
		public string Language32 {
			get {
				return GetTypedColumnValue<string>("Language32");
			}
			set {
				SetColumnValue("Language32", value);
			}
		}

		/// <summary>
		/// Language31.
		/// </summary>
		public string Language31 {
			get {
				return GetTypedColumnValue<string>("Language31");
			}
			set {
				SetColumnValue("Language31", value);
			}
		}

		/// <summary>
		/// Language35Short.
		/// </summary>
		public string Language35Short {
			get {
				return GetTypedColumnValue<string>("Language35Short");
			}
			set {
				SetColumnValue("Language35Short", value);
			}
		}

		/// <summary>
		/// Language34Short.
		/// </summary>
		public string Language34Short {
			get {
				return GetTypedColumnValue<string>("Language34Short");
			}
			set {
				SetColumnValue("Language34Short", value);
			}
		}

		/// <summary>
		/// Language33Short.
		/// </summary>
		public string Language33Short {
			get {
				return GetTypedColumnValue<string>("Language33Short");
			}
			set {
				SetColumnValue("Language33Short", value);
			}
		}

		/// <summary>
		/// Language32Short.
		/// </summary>
		public string Language32Short {
			get {
				return GetTypedColumnValue<string>("Language32Short");
			}
			set {
				SetColumnValue("Language32Short", value);
			}
		}

		/// <summary>
		/// Language31Short.
		/// </summary>
		public string Language31Short {
			get {
				return GetTypedColumnValue<string>("Language31Short");
			}
			set {
				SetColumnValue("Language31Short", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTranslation_TranslationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysTranslationDeleted", e);
			Saved += (s, e) => ThrowEvent("SysTranslationSaved", e);
			Saving += (s, e) => ThrowEvent("SysTranslationSaving", e);
			Updated += (s, e) => ThrowEvent("SysTranslationUpdated", e);
			Validating += (s, e) => ThrowEvent("SysTranslationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysTranslation(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslation_TranslationEventsProcess

	/// <exclude/>
	public partial class SysTranslation_TranslationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysTranslation
	{

		public SysTranslation_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTranslation_TranslationEventsProcess";
			SchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsInActualizing {
			get;
			set;
		}

		private ProcessFlowElement _sysTranslationSavedEventSubProcess;
		public ProcessFlowElement SysTranslationSavedEventSubProcess {
			get {
				return _sysTranslationSavedEventSubProcess ?? (_sysTranslationSavedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysTranslationSavedEventSubProcess",
					SchemaElementUId = new Guid("7f01fa69-82cf-47b3-b3ac-8cf67553e339"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysTranslationSavedStartMessage;
		public ProcessFlowElement SysTranslationSavedStartMessage {
			get {
				return _sysTranslationSavedStartMessage ?? (_sysTranslationSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysTranslationSavedStartMessage",
					SchemaElementUId = new Guid("95a1d21e-9487-4d18-ae66-3ed288c4993f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysTranslationSavedScriptTask;
		public ProcessScriptTask SysTranslationSavedScriptTask {
			get {
				return _sysTranslationSavedScriptTask ?? (_sysTranslationSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysTranslationSavedScriptTask",
					SchemaElementUId = new Guid("3154f277-1160-49a5-b3fd-4c7dbf93514c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysTranslationSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysTranslationUpdatedEventSubProcess;
		public ProcessFlowElement SysTranslationUpdatedEventSubProcess {
			get {
				return _sysTranslationUpdatedEventSubProcess ?? (_sysTranslationUpdatedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysTranslationUpdatedEventSubProcess",
					SchemaElementUId = new Guid("23caadfd-86de-4fb9-a774-e8f107bb7080"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysTranslationUpdatedStartMessage;
		public ProcessFlowElement SysTranslationUpdatedStartMessage {
			get {
				return _sysTranslationUpdatedStartMessage ?? (_sysTranslationUpdatedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysTranslationUpdatedStartMessage",
					SchemaElementUId = new Guid("07371b4a-fa36-4b95-8dbe-1f3ff54303bd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysTranslationUpdatedScriptTask;
		public ProcessScriptTask SysTranslationUpdatedScriptTask {
			get {
				return _sysTranslationUpdatedScriptTask ?? (_sysTranslationUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysTranslationUpdatedScriptTask",
					SchemaElementUId = new Guid("c8ab652e-78ef-4475-9e80-4f852c3441cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysTranslationUpdatedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sysTranslationSavingEventSubProcess;
		public ProcessFlowElement SysTranslationSavingEventSubProcess {
			get {
				return _sysTranslationSavingEventSubProcess ?? (_sysTranslationSavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysTranslationSavingEventSubProcess",
					SchemaElementUId = new Guid("92d9c732-7a4c-4679-af97-7adafc0f0b97"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysTranslationSavingStartMessage;
		public ProcessFlowElement SysTranslationSavingStartMessage {
			get {
				return _sysTranslationSavingStartMessage ?? (_sysTranslationSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysTranslationSavingStartMessage",
					SchemaElementUId = new Guid("0054fef8-3a89-4e23-89a8-93ea36d1aeb0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysTranslationSavingScriptTask;
		public ProcessScriptTask SysTranslationSavingScriptTask {
			get {
				return _sysTranslationSavingScriptTask ?? (_sysTranslationSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysTranslationSavingScriptTask",
					SchemaElementUId = new Guid("608e4db7-d3cb-44a8-85bf-4f29bccd28a0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysTranslationSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SysTranslationSavedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationSavedEventSubProcess };
			FlowElements[SysTranslationSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationSavedStartMessage };
			FlowElements[SysTranslationSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationSavedScriptTask };
			FlowElements[SysTranslationUpdatedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationUpdatedEventSubProcess };
			FlowElements[SysTranslationUpdatedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationUpdatedStartMessage };
			FlowElements[SysTranslationUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationUpdatedScriptTask };
			FlowElements[SysTranslationSavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationSavingEventSubProcess };
			FlowElements[SysTranslationSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationSavingStartMessage };
			FlowElements[SysTranslationSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysTranslationSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SysTranslationSavedEventSubProcess":
						break;
					case "SysTranslationSavedStartMessage":
						e.Context.QueueTasks.Enqueue("SysTranslationSavedScriptTask");
						break;
					case "SysTranslationSavedScriptTask":
						break;
					case "SysTranslationUpdatedEventSubProcess":
						break;
					case "SysTranslationUpdatedStartMessage":
						e.Context.QueueTasks.Enqueue("SysTranslationUpdatedScriptTask");
						break;
					case "SysTranslationUpdatedScriptTask":
						break;
					case "SysTranslationSavingEventSubProcess":
						break;
					case "SysTranslationSavingStartMessage":
						e.Context.QueueTasks.Enqueue("SysTranslationSavingScriptTask");
						break;
					case "SysTranslationSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysTranslationSavedStartMessage");
			ActivatedEventElements.Add("SysTranslationUpdatedStartMessage");
			ActivatedEventElements.Add("SysTranslationSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SysTranslationSavedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysTranslationSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysTranslationSavedStartMessage";
					result = SysTranslationSavedStartMessage.Execute(context);
					break;
				case "SysTranslationSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysTranslationSavedScriptTask";
					result = SysTranslationSavedScriptTask.Execute(context, SysTranslationSavedScriptTaskExecute);
					break;
				case "SysTranslationUpdatedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysTranslationUpdatedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysTranslationUpdatedStartMessage";
					result = SysTranslationUpdatedStartMessage.Execute(context);
					break;
				case "SysTranslationUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysTranslationUpdatedScriptTask";
					result = SysTranslationUpdatedScriptTask.Execute(context, SysTranslationUpdatedScriptTaskExecute);
					break;
				case "SysTranslationSavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysTranslationSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysTranslationSavingStartMessage";
					result = SysTranslationSavingStartMessage.Execute(context);
					break;
				case "SysTranslationSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysTranslationSavingScriptTask";
					result = SysTranslationSavingScriptTask.Execute(context, SysTranslationSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SysTranslationSavedScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysTranslationSaved(context);
		}

		public virtual bool SysTranslationUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysTranslationUpdated(context);
		}

		public virtual bool SysTranslationSavingScriptTaskExecute(ProcessExecutingContext context) {
			return OnSysTranslationSaving(context);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysTranslationSaved":
							if (ActivatedEventElements.Contains("SysTranslationSavedStartMessage")) {
							context.QueueTasks.Enqueue("SysTranslationSavedStartMessage");
						}
						break;
					case "SysTranslationUpdated":
							if (ActivatedEventElements.Contains("SysTranslationUpdatedStartMessage")) {
							context.QueueTasks.Enqueue("SysTranslationUpdatedStartMessage");
						}
						break;
					case "SysTranslationSaving":
							if (ActivatedEventElements.Contains("SysTranslationSavingStartMessage")) {
							context.QueueTasks.Enqueue("SysTranslationSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslation_TranslationEventsProcess

	/// <exclude/>
	public class SysTranslation_TranslationEventsProcess : SysTranslation_TranslationEventsProcess<SysTranslation>
	{

		public SysTranslation_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTranslation_TranslationEventsProcess

	public partial class SysTranslation_TranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool OnSysTranslationSaved(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool OnSysTranslationUpdated(ProcessExecutingContext context) {
			return true;
		}

		public virtual void SetIsChanged() {
			if (IsInActualizing) {
				return;
			}
			ITranslationActualizersFactory translationActualizersFactory = ClassFactory.Get<TranslationActualizersFactory>(
				new ConstructorArgument("userConnection", UserConnection));
			ITranslationActualizer translationActualizer = translationActualizersFactory.GetTranslationActualizer();
			translationActualizer.SetIsTranslationChanged(Entity);
		}

		public virtual bool OnSysTranslationSaving(ProcessExecutingContext context) {
			SetIsChanged();
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: SysTranslationEventsProcess

	/// <exclude/>
	public class SysTranslationEventsProcess : SysTranslation_TranslationEventsProcess
	{

		public SysTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

