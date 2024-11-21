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

	#region Class: BufferedImportEntitySchema

	/// <exclude/>
	public class BufferedImportEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BufferedImportEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BufferedImportEntitySchema(BufferedImportEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BufferedImportEntitySchema(BufferedImportEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
			RealUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
			Name = "BufferedImportEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6149dc4a-0845-4f34-953b-8d2d6cd2b2bf")) == null) {
				Columns.Add(CreateColumn1Column());
			}
			if (Columns.FindByUId(new Guid("c1caf677-8c20-4d9b-ae1b-d530d80d9dda")) == null) {
				Columns.Add(CreateColumn2Column());
			}
			if (Columns.FindByUId(new Guid("9b306515-52a1-4326-ac81-3e1fcd1259ef")) == null) {
				Columns.Add(CreateColumn3Column());
			}
			if (Columns.FindByUId(new Guid("9c1aeb37-b5e1-4d88-b81e-8a73c987401a")) == null) {
				Columns.Add(CreateColumn4Column());
			}
			if (Columns.FindByUId(new Guid("341a68ab-0028-47a2-b875-d5bd6f1f8e17")) == null) {
				Columns.Add(CreateColumn5Column());
			}
			if (Columns.FindByUId(new Guid("945a5535-76fc-4361-b88f-20fb03a3d076")) == null) {
				Columns.Add(CreateColumn6Column());
			}
			if (Columns.FindByUId(new Guid("97f7ae9f-4612-4b96-a281-d3810e63b017")) == null) {
				Columns.Add(CreateColumn7Column());
			}
			if (Columns.FindByUId(new Guid("81dda907-db24-4528-96b8-50aa77718b4b")) == null) {
				Columns.Add(CreateColumn8Column());
			}
			if (Columns.FindByUId(new Guid("27a24011-3332-4f58-b15d-0c4c66d0e94f")) == null) {
				Columns.Add(CreateColumn9Column());
			}
			if (Columns.FindByUId(new Guid("afeb8b8b-a9ef-43df-8bde-769736564275")) == null) {
				Columns.Add(CreateColumn10Column());
			}
			if (Columns.FindByUId(new Guid("29144d77-05b4-44f1-a831-58fa92c40e96")) == null) {
				Columns.Add(CreateColumn11Column());
			}
			if (Columns.FindByUId(new Guid("f7eb5b8b-fa3a-47d4-a892-48e2833d5f56")) == null) {
				Columns.Add(CreateColumn12Column());
			}
			if (Columns.FindByUId(new Guid("7480ccaa-a86e-431a-872c-04e5783a73ff")) == null) {
				Columns.Add(CreateColumn13Column());
			}
			if (Columns.FindByUId(new Guid("404debdd-63e9-443e-ba68-79f1f9a6f618")) == null) {
				Columns.Add(CreateColumn14Column());
			}
			if (Columns.FindByUId(new Guid("3e840f4e-d535-4de1-aefd-fb27de340351")) == null) {
				Columns.Add(CreateColumn15Column());
			}
			if (Columns.FindByUId(new Guid("ca14eb42-8293-4cd8-bc1f-cca215d4e714")) == null) {
				Columns.Add(CreateColumn16Column());
			}
			if (Columns.FindByUId(new Guid("1109c8f6-71eb-4ba2-9a55-44cd3b771362")) == null) {
				Columns.Add(CreateColumn17Column());
			}
			if (Columns.FindByUId(new Guid("0fe0e83c-065b-4cae-8ab2-84b6ceaad46c")) == null) {
				Columns.Add(CreateColumn18Column());
			}
			if (Columns.FindByUId(new Guid("4677c6f5-e7aa-49e0-8deb-45632210accf")) == null) {
				Columns.Add(CreateColumn19Column());
			}
			if (Columns.FindByUId(new Guid("d736a88e-2dbf-49aa-8396-d294d4fd26f3")) == null) {
				Columns.Add(CreateColumn20Column());
			}
			if (Columns.FindByUId(new Guid("6a9dee03-a868-4587-8354-adbf17016479")) == null) {
				Columns.Add(CreateColumn21Column());
			}
			if (Columns.FindByUId(new Guid("d070955a-9438-437e-94f1-a78a6e0200d7")) == null) {
				Columns.Add(CreateColumn22Column());
			}
			if (Columns.FindByUId(new Guid("6232e346-617d-4789-897b-25855150f4dd")) == null) {
				Columns.Add(CreateColumn23Column());
			}
			if (Columns.FindByUId(new Guid("aa99a304-2fab-46e4-8814-4cb9921a2966")) == null) {
				Columns.Add(CreateColumn24Column());
			}
			if (Columns.FindByUId(new Guid("0af5415a-2122-480d-b539-1f64c63f041d")) == null) {
				Columns.Add(CreateColumn25Column());
			}
			if (Columns.FindByUId(new Guid("61fc2063-f068-49f3-ae52-f4bd3e3eb50d")) == null) {
				Columns.Add(CreateColumn26Column());
			}
			if (Columns.FindByUId(new Guid("2e303ce3-5a20-490c-af5c-14859a174bd0")) == null) {
				Columns.Add(CreateColumn27Column());
			}
			if (Columns.FindByUId(new Guid("88b73402-bb44-4139-ac1e-caa674458c6a")) == null) {
				Columns.Add(CreateColumn28Column());
			}
			if (Columns.FindByUId(new Guid("345f4800-2617-4f3e-b89d-3df86fc8ba7e")) == null) {
				Columns.Add(CreateColumn29Column());
			}
			if (Columns.FindByUId(new Guid("20750bc4-6d0c-4e08-8c63-d5aa7b2d7f60")) == null) {
				Columns.Add(CreateColumn30Column());
			}
			if (Columns.FindByUId(new Guid("3e3d4919-7fb7-46fb-b3cd-d8da39f241ee")) == null) {
				Columns.Add(CreateImportSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("e9305713-9ddc-41f8-a8c7-c8f46de4dcee")) == null) {
				Columns.Add(CreateColumn31Column());
			}
			if (Columns.FindByUId(new Guid("a3fe5bee-395d-4269-9203-558334d3e3bd")) == null) {
				Columns.Add(CreateColumn32Column());
			}
			if (Columns.FindByUId(new Guid("187e2f98-fb20-4ee2-8f84-449c4552c714")) == null) {
				Columns.Add(CreateColumn33Column());
			}
			if (Columns.FindByUId(new Guid("ebb6fb5c-12bb-4831-8bf9-b8de6798692a")) == null) {
				Columns.Add(CreateColumn34Column());
			}
			if (Columns.FindByUId(new Guid("a224199e-5bd1-4e6d-9527-3650d3e7575a")) == null) {
				Columns.Add(CreateColumn35Column());
			}
			if (Columns.FindByUId(new Guid("eebec8ab-58f1-4ee8-b52f-315712a389f9")) == null) {
				Columns.Add(CreateColumn36Column());
			}
			if (Columns.FindByUId(new Guid("c3b22dea-773f-4422-9282-9588b19146ea")) == null) {
				Columns.Add(CreateColumn37Column());
			}
			if (Columns.FindByUId(new Guid("23041f9c-3792-44a4-9e03-52767c40e9c5")) == null) {
				Columns.Add(CreateColumn38Column());
			}
			if (Columns.FindByUId(new Guid("a2f8630f-cfe6-4c3f-bb26-e1b4ac4d31b2")) == null) {
				Columns.Add(CreateColumn39Column());
			}
			if (Columns.FindByUId(new Guid("26ec786c-bee1-4684-8d85-8c646b81b8b2")) == null) {
				Columns.Add(CreateColumn40Column());
			}
			if (Columns.FindByUId(new Guid("7f22b64b-4a32-4941-9fab-549e7f25135e")) == null) {
				Columns.Add(CreateColumn41Column());
			}
			if (Columns.FindByUId(new Guid("a92961e1-2df9-437f-be2b-da3afacbaa5d")) == null) {
				Columns.Add(CreateColumn42Column());
			}
			if (Columns.FindByUId(new Guid("688d76b7-ffad-4ec1-9f06-e9379fe6969f")) == null) {
				Columns.Add(CreateColumn43Column());
			}
			if (Columns.FindByUId(new Guid("5b41ae17-1aae-4984-9c03-df6ae655268e")) == null) {
				Columns.Add(CreateColumn44Column());
			}
			if (Columns.FindByUId(new Guid("e40130a6-74c8-4a39-89d8-b4bb8e0ca78f")) == null) {
				Columns.Add(CreateColumn45Column());
			}
			if (Columns.FindByUId(new Guid("c4bebcc1-df91-4906-9ab7-a496021e530f")) == null) {
				Columns.Add(CreateColumn46Column());
			}
			if (Columns.FindByUId(new Guid("9b88e1ac-6e0e-472d-82d0-91e56c5cb460")) == null) {
				Columns.Add(CreateColumn47Column());
			}
			if (Columns.FindByUId(new Guid("0573c7d3-277f-4886-9b68-e9ada0662661")) == null) {
				Columns.Add(CreateColumn48Column());
			}
			if (Columns.FindByUId(new Guid("176ce0d6-266c-44c6-8e63-3d8dc199dc4c")) == null) {
				Columns.Add(CreateColumn49Column());
			}
			if (Columns.FindByUId(new Guid("d57e2c55-0e2a-4e1a-9a8a-2e007e4d50fb")) == null) {
				Columns.Add(CreateColumn50Column());
			}
			if (Columns.FindByUId(new Guid("e44c9c6b-43d2-401c-9e41-b6dc1ad3d6f9")) == null) {
				Columns.Add(CreateImportExcelRowIndexColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateColumn1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6149dc4a-0845-4f34-953b-8d2d6cd2b2bf"),
				Name = @"Column1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c1caf677-8c20-4d9b-ae1b-d530d80d9dda"),
				Name = @"Column2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9b306515-52a1-4326-ac81-3e1fcd1259ef"),
				Name = @"Column3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9c1aeb37-b5e1-4d88-b81e-8a73c987401a"),
				Name = @"Column4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("341a68ab-0028-47a2-b875-d5bd6f1f8e17"),
				Name = @"Column5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("945a5535-76fc-4361-b88f-20fb03a3d076"),
				Name = @"Column6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("97f7ae9f-4612-4b96-a281-d3810e63b017"),
				Name = @"Column7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("81dda907-db24-4528-96b8-50aa77718b4b"),
				Name = @"Column8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("27a24011-3332-4f58-b15d-0c4c66d0e94f"),
				Name = @"Column9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("afeb8b8b-a9ef-43df-8bde-769736564275"),
				Name = @"Column10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn11Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("29144d77-05b4-44f1-a831-58fa92c40e96"),
				Name = @"Column11",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn12Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f7eb5b8b-fa3a-47d4-a892-48e2833d5f56"),
				Name = @"Column12",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn13Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7480ccaa-a86e-431a-872c-04e5783a73ff"),
				Name = @"Column13",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn14Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("404debdd-63e9-443e-ba68-79f1f9a6f618"),
				Name = @"Column14",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn15Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3e840f4e-d535-4de1-aefd-fb27de340351"),
				Name = @"Column15",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn16Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ca14eb42-8293-4cd8-bc1f-cca215d4e714"),
				Name = @"Column16",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn17Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("1109c8f6-71eb-4ba2-9a55-44cd3b771362"),
				Name = @"Column17",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn18Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0fe0e83c-065b-4cae-8ab2-84b6ceaad46c"),
				Name = @"Column18",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn19Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4677c6f5-e7aa-49e0-8deb-45632210accf"),
				Name = @"Column19",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn20Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d736a88e-2dbf-49aa-8396-d294d4fd26f3"),
				Name = @"Column20",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn21Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6a9dee03-a868-4587-8354-adbf17016479"),
				Name = @"Column21",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn22Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d070955a-9438-437e-94f1-a78a6e0200d7"),
				Name = @"Column22",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn23Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6232e346-617d-4789-897b-25855150f4dd"),
				Name = @"Column23",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn24Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("aa99a304-2fab-46e4-8814-4cb9921a2966"),
				Name = @"Column24",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn25Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0af5415a-2122-480d-b539-1f64c63f041d"),
				Name = @"Column25",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn26Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("61fc2063-f068-49f3-ae52-f4bd3e3eb50d"),
				Name = @"Column26",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn27Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2e303ce3-5a20-490c-af5c-14859a174bd0"),
				Name = @"Column27",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn28Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("88b73402-bb44-4139-ac1e-caa674458c6a"),
				Name = @"Column28",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn29Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("345f4800-2617-4f3e-b89d-3df86fc8ba7e"),
				Name = @"Column29",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn30Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("20750bc4-6d0c-4e08-8c63-d5aa7b2d7f60"),
				Name = @"Column30",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateImportSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3e3d4919-7fb7-46fb-b3cd-d8da39f241ee"),
				Name = @"ImportSessionId",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn31Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e9305713-9ddc-41f8-a8c7-c8f46de4dcee"),
				Name = @"Column31",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn32Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a3fe5bee-395d-4269-9203-558334d3e3bd"),
				Name = @"Column32",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn33Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("187e2f98-fb20-4ee2-8f84-449c4552c714"),
				Name = @"Column33",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn34Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ebb6fb5c-12bb-4831-8bf9-b8de6798692a"),
				Name = @"Column34",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn35Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a224199e-5bd1-4e6d-9527-3650d3e7575a"),
				Name = @"Column35",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn36Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("eebec8ab-58f1-4ee8-b52f-315712a389f9"),
				Name = @"Column36",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn37Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c3b22dea-773f-4422-9282-9588b19146ea"),
				Name = @"Column37",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn38Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("23041f9c-3792-44a4-9e03-52767c40e9c5"),
				Name = @"Column38",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn39Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a2f8630f-cfe6-4c3f-bb26-e1b4ac4d31b2"),
				Name = @"Column39",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn40Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("26ec786c-bee1-4684-8d85-8c646b81b8b2"),
				Name = @"Column40",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn41Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7f22b64b-4a32-4941-9fab-549e7f25135e"),
				Name = @"Column41",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn42Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a92961e1-2df9-437f-be2b-da3afacbaa5d"),
				Name = @"Column42",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn43Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("688d76b7-ffad-4ec1-9f06-e9379fe6969f"),
				Name = @"Column43",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn44Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("5b41ae17-1aae-4984-9c03-df6ae655268e"),
				Name = @"Column44",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn45Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e40130a6-74c8-4a39-89d8-b4bb8e0ca78f"),
				Name = @"Column45",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn46Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c4bebcc1-df91-4906-9ab7-a496021e530f"),
				Name = @"Column46",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn47Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9b88e1ac-6e0e-472d-82d0-91e56c5cb460"),
				Name = @"Column47",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn48Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0573c7d3-277f-4886-9b68-e9ada0662661"),
				Name = @"Column48",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn49Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("176ce0d6-266c-44c6-8e63-3d8dc199dc4c"),
				Name = @"Column49",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn50Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d57e2c55-0e2a-4e1a-9a8a-2e007e4d50fb"),
				Name = @"Column50",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateImportExcelRowIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e44c9c6b-43d2-401c-9e41-b6dc1ad3d6f9"),
				Name = @"ImportExcelRowIndex",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BufferedImportEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BufferedImportEntity_FileImportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BufferedImportEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BufferedImportEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"));
		}

		#endregion

	}

	#endregion

	#region Class: BufferedImportEntity

	/// <summary>
	/// Buffer data store for file import.
	/// </summary>
	public class BufferedImportEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BufferedImportEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BufferedImportEntity";
		}

		public BufferedImportEntity(BufferedImportEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Column1.
		/// </summary>
		public string Column1 {
			get {
				return GetTypedColumnValue<string>("Column1");
			}
			set {
				SetColumnValue("Column1", value);
			}
		}

		/// <summary>
		/// Column2.
		/// </summary>
		public string Column2 {
			get {
				return GetTypedColumnValue<string>("Column2");
			}
			set {
				SetColumnValue("Column2", value);
			}
		}

		/// <summary>
		/// Column3.
		/// </summary>
		public string Column3 {
			get {
				return GetTypedColumnValue<string>("Column3");
			}
			set {
				SetColumnValue("Column3", value);
			}
		}

		/// <summary>
		/// Column4.
		/// </summary>
		public string Column4 {
			get {
				return GetTypedColumnValue<string>("Column4");
			}
			set {
				SetColumnValue("Column4", value);
			}
		}

		/// <summary>
		/// Column5.
		/// </summary>
		public string Column5 {
			get {
				return GetTypedColumnValue<string>("Column5");
			}
			set {
				SetColumnValue("Column5", value);
			}
		}

		/// <summary>
		/// Column6.
		/// </summary>
		public string Column6 {
			get {
				return GetTypedColumnValue<string>("Column6");
			}
			set {
				SetColumnValue("Column6", value);
			}
		}

		/// <summary>
		/// Column7.
		/// </summary>
		public string Column7 {
			get {
				return GetTypedColumnValue<string>("Column7");
			}
			set {
				SetColumnValue("Column7", value);
			}
		}

		/// <summary>
		/// Column8.
		/// </summary>
		public string Column8 {
			get {
				return GetTypedColumnValue<string>("Column8");
			}
			set {
				SetColumnValue("Column8", value);
			}
		}

		/// <summary>
		/// Column9.
		/// </summary>
		public string Column9 {
			get {
				return GetTypedColumnValue<string>("Column9");
			}
			set {
				SetColumnValue("Column9", value);
			}
		}

		/// <summary>
		/// Column10.
		/// </summary>
		public string Column10 {
			get {
				return GetTypedColumnValue<string>("Column10");
			}
			set {
				SetColumnValue("Column10", value);
			}
		}

		/// <summary>
		/// Column11.
		/// </summary>
		public string Column11 {
			get {
				return GetTypedColumnValue<string>("Column11");
			}
			set {
				SetColumnValue("Column11", value);
			}
		}

		/// <summary>
		/// Column12.
		/// </summary>
		public string Column12 {
			get {
				return GetTypedColumnValue<string>("Column12");
			}
			set {
				SetColumnValue("Column12", value);
			}
		}

		/// <summary>
		/// Column13.
		/// </summary>
		public string Column13 {
			get {
				return GetTypedColumnValue<string>("Column13");
			}
			set {
				SetColumnValue("Column13", value);
			}
		}

		/// <summary>
		/// Column14.
		/// </summary>
		public string Column14 {
			get {
				return GetTypedColumnValue<string>("Column14");
			}
			set {
				SetColumnValue("Column14", value);
			}
		}

		/// <summary>
		/// Column15.
		/// </summary>
		public string Column15 {
			get {
				return GetTypedColumnValue<string>("Column15");
			}
			set {
				SetColumnValue("Column15", value);
			}
		}

		/// <summary>
		/// Column16.
		/// </summary>
		public string Column16 {
			get {
				return GetTypedColumnValue<string>("Column16");
			}
			set {
				SetColumnValue("Column16", value);
			}
		}

		/// <summary>
		/// Column17.
		/// </summary>
		public string Column17 {
			get {
				return GetTypedColumnValue<string>("Column17");
			}
			set {
				SetColumnValue("Column17", value);
			}
		}

		/// <summary>
		/// Column18.
		/// </summary>
		public string Column18 {
			get {
				return GetTypedColumnValue<string>("Column18");
			}
			set {
				SetColumnValue("Column18", value);
			}
		}

		/// <summary>
		/// Column19.
		/// </summary>
		public string Column19 {
			get {
				return GetTypedColumnValue<string>("Column19");
			}
			set {
				SetColumnValue("Column19", value);
			}
		}

		/// <summary>
		/// Column20.
		/// </summary>
		public string Column20 {
			get {
				return GetTypedColumnValue<string>("Column20");
			}
			set {
				SetColumnValue("Column20", value);
			}
		}

		/// <summary>
		/// Column21.
		/// </summary>
		public string Column21 {
			get {
				return GetTypedColumnValue<string>("Column21");
			}
			set {
				SetColumnValue("Column21", value);
			}
		}

		/// <summary>
		/// Column22.
		/// </summary>
		public string Column22 {
			get {
				return GetTypedColumnValue<string>("Column22");
			}
			set {
				SetColumnValue("Column22", value);
			}
		}

		/// <summary>
		/// Column23.
		/// </summary>
		public string Column23 {
			get {
				return GetTypedColumnValue<string>("Column23");
			}
			set {
				SetColumnValue("Column23", value);
			}
		}

		/// <summary>
		/// Column24.
		/// </summary>
		public string Column24 {
			get {
				return GetTypedColumnValue<string>("Column24");
			}
			set {
				SetColumnValue("Column24", value);
			}
		}

		/// <summary>
		/// Column25.
		/// </summary>
		public string Column25 {
			get {
				return GetTypedColumnValue<string>("Column25");
			}
			set {
				SetColumnValue("Column25", value);
			}
		}

		/// <summary>
		/// Column26.
		/// </summary>
		public string Column26 {
			get {
				return GetTypedColumnValue<string>("Column26");
			}
			set {
				SetColumnValue("Column26", value);
			}
		}

		/// <summary>
		/// Column27.
		/// </summary>
		public string Column27 {
			get {
				return GetTypedColumnValue<string>("Column27");
			}
			set {
				SetColumnValue("Column27", value);
			}
		}

		/// <summary>
		/// Column28.
		/// </summary>
		public string Column28 {
			get {
				return GetTypedColumnValue<string>("Column28");
			}
			set {
				SetColumnValue("Column28", value);
			}
		}

		/// <summary>
		/// Column29.
		/// </summary>
		public string Column29 {
			get {
				return GetTypedColumnValue<string>("Column29");
			}
			set {
				SetColumnValue("Column29", value);
			}
		}

		/// <summary>
		/// Column30.
		/// </summary>
		public string Column30 {
			get {
				return GetTypedColumnValue<string>("Column30");
			}
			set {
				SetColumnValue("Column30", value);
			}
		}

		/// <summary>
		/// ImportSessionId.
		/// </summary>
		public Guid ImportSessionId {
			get {
				return GetTypedColumnValue<Guid>("ImportSessionId");
			}
			set {
				SetColumnValue("ImportSessionId", value);
			}
		}

		/// <summary>
		/// Column31.
		/// </summary>
		public string Column31 {
			get {
				return GetTypedColumnValue<string>("Column31");
			}
			set {
				SetColumnValue("Column31", value);
			}
		}

		/// <summary>
		/// Column32.
		/// </summary>
		public string Column32 {
			get {
				return GetTypedColumnValue<string>("Column32");
			}
			set {
				SetColumnValue("Column32", value);
			}
		}

		/// <summary>
		/// Column33.
		/// </summary>
		public string Column33 {
			get {
				return GetTypedColumnValue<string>("Column33");
			}
			set {
				SetColumnValue("Column33", value);
			}
		}

		/// <summary>
		/// Column34.
		/// </summary>
		public string Column34 {
			get {
				return GetTypedColumnValue<string>("Column34");
			}
			set {
				SetColumnValue("Column34", value);
			}
		}

		/// <summary>
		/// Column35.
		/// </summary>
		public string Column35 {
			get {
				return GetTypedColumnValue<string>("Column35");
			}
			set {
				SetColumnValue("Column35", value);
			}
		}

		/// <summary>
		/// Column36.
		/// </summary>
		public string Column36 {
			get {
				return GetTypedColumnValue<string>("Column36");
			}
			set {
				SetColumnValue("Column36", value);
			}
		}

		/// <summary>
		/// Column37.
		/// </summary>
		public string Column37 {
			get {
				return GetTypedColumnValue<string>("Column37");
			}
			set {
				SetColumnValue("Column37", value);
			}
		}

		/// <summary>
		/// Column38.
		/// </summary>
		public string Column38 {
			get {
				return GetTypedColumnValue<string>("Column38");
			}
			set {
				SetColumnValue("Column38", value);
			}
		}

		/// <summary>
		/// Column39.
		/// </summary>
		public string Column39 {
			get {
				return GetTypedColumnValue<string>("Column39");
			}
			set {
				SetColumnValue("Column39", value);
			}
		}

		/// <summary>
		/// Column40.
		/// </summary>
		public string Column40 {
			get {
				return GetTypedColumnValue<string>("Column40");
			}
			set {
				SetColumnValue("Column40", value);
			}
		}

		/// <summary>
		/// Column41.
		/// </summary>
		public string Column41 {
			get {
				return GetTypedColumnValue<string>("Column41");
			}
			set {
				SetColumnValue("Column41", value);
			}
		}

		/// <summary>
		/// Column42.
		/// </summary>
		public string Column42 {
			get {
				return GetTypedColumnValue<string>("Column42");
			}
			set {
				SetColumnValue("Column42", value);
			}
		}

		/// <summary>
		/// Column43.
		/// </summary>
		public string Column43 {
			get {
				return GetTypedColumnValue<string>("Column43");
			}
			set {
				SetColumnValue("Column43", value);
			}
		}

		/// <summary>
		/// Column44.
		/// </summary>
		public string Column44 {
			get {
				return GetTypedColumnValue<string>("Column44");
			}
			set {
				SetColumnValue("Column44", value);
			}
		}

		/// <summary>
		/// Column45.
		/// </summary>
		public string Column45 {
			get {
				return GetTypedColumnValue<string>("Column45");
			}
			set {
				SetColumnValue("Column45", value);
			}
		}

		/// <summary>
		/// Column46.
		/// </summary>
		public string Column46 {
			get {
				return GetTypedColumnValue<string>("Column46");
			}
			set {
				SetColumnValue("Column46", value);
			}
		}

		/// <summary>
		/// Column47.
		/// </summary>
		public string Column47 {
			get {
				return GetTypedColumnValue<string>("Column47");
			}
			set {
				SetColumnValue("Column47", value);
			}
		}

		/// <summary>
		/// Column48.
		/// </summary>
		public string Column48 {
			get {
				return GetTypedColumnValue<string>("Column48");
			}
			set {
				SetColumnValue("Column48", value);
			}
		}

		/// <summary>
		/// Column49.
		/// </summary>
		public string Column49 {
			get {
				return GetTypedColumnValue<string>("Column49");
			}
			set {
				SetColumnValue("Column49", value);
			}
		}

		/// <summary>
		/// Column50.
		/// </summary>
		public string Column50 {
			get {
				return GetTypedColumnValue<string>("Column50");
			}
			set {
				SetColumnValue("Column50", value);
			}
		}

		/// <summary>
		/// ImportExcelRowIndex.
		/// </summary>
		public int ImportExcelRowIndex {
			get {
				return GetTypedColumnValue<int>("ImportExcelRowIndex");
			}
			set {
				SetColumnValue("ImportExcelRowIndex", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BufferedImportEntity_FileImportEventsProcess(UserConnection);
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
			return new BufferedImportEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: BufferedImportEntity_FileImportEventsProcess

	/// <exclude/>
	public partial class BufferedImportEntity_FileImportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BufferedImportEntity
	{

		public BufferedImportEntity_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BufferedImportEntity_FileImportEventsProcess";
			SchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
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

	#region Class: BufferedImportEntity_FileImportEventsProcess

	/// <exclude/>
	public class BufferedImportEntity_FileImportEventsProcess : BufferedImportEntity_FileImportEventsProcess<BufferedImportEntity>
	{

		public BufferedImportEntity_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BufferedImportEntity_FileImportEventsProcess

	public partial class BufferedImportEntity_FileImportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BufferedImportEntityEventsProcess

	/// <exclude/>
	public class BufferedImportEntityEventsProcess : BufferedImportEntity_FileImportEventsProcess
	{

		public BufferedImportEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

