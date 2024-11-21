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

	#region Class: EventSchema

	/// <exclude/>
	public class EventSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventSchema(EventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventSchema(EventSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			RealUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			Name = "Event";
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
			if (Columns.FindByUId(new Guid("681ae3d8-644e-4c88-9f55-752ee45dd4a4")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("611dd225-b1b2-4fe9-a9ae-8e17947b30ce")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("3284033b-d83d-4f37-b7a9-b89bef88a8af")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("74338ff9-e309-436d-a2a0-25d19313523e")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("6abd0ec9-8a6d-4060-b6b8-948d16a547f4")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("11aaba7b-60c1-4ff7-b612-8fa0fb3323be")) == null) {
				Columns.Add(CreateGoalColumn());
			}
			if (Columns.FindByUId(new Guid("82c6a0b8-0cc6-483b-8177-2d6d3eab0d73")) == null) {
				Columns.Add(CreateTerritoryColumn());
			}
			if (Columns.FindByUId(new Guid("f209390f-73a2-47ae-97b9-fcd541bfd5dc")) == null) {
				Columns.Add(CreateIndustryColumn());
			}
			if (Columns.FindByUId(new Guid("998e902d-a9d5-49e5-bd1f-30981c8da5f3")) == null) {
				Columns.Add(CreateActualResponseColumn());
			}
			if (Columns.FindByUId(new Guid("caab7f9b-9c25-462d-802b-9a6d2c5d4fc1")) == null) {
				Columns.Add(CreatePrimaryBudgetedCostColumn());
			}
			if (Columns.FindByUId(new Guid("4b1d344a-e187-4afb-8908-a7afcbbd175f")) == null) {
				Columns.Add(CreatePrimaryExpectedRevenueColumn());
			}
			if (Columns.FindByUId(new Guid("e6a3cb4a-643f-4d3e-a220-d41b28eb8505")) == null) {
				Columns.Add(CreatePrimaryActualCostColumn());
			}
			if (Columns.FindByUId(new Guid("c14a5743-28b5-4fdf-93af-d34708923ef5")) == null) {
				Columns.Add(CreatePrimaryActualRevenueColumn());
			}
			if (Columns.FindByUId(new Guid("645eabb6-dace-4ed4-b41f-01ef4469a857")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("72cf8359-d4a2-4f5a-b969-4f465d737aa3")) == null) {
				Columns.Add(CreateActualizeStatusColumn());
			}
			if (Columns.FindByUId(new Guid("2110bf6a-b8ef-4d49-899a-512a263da248")) == null) {
				Columns.Add(CreateLastActualizeDateColumn());
			}
			if (Columns.FindByUId(new Guid("64dc54f1-ff40-49fe-9a43-6d5f7baa2bda")) == null) {
				Columns.Add(CreateRecipientCountColumn());
			}
			if (Columns.FindByUId(new Guid("00650465-f72d-4313-a6d4-535bdcb0d4ce")) == null) {
				Columns.Add(CreateSegmentsStatusColumn());
			}
			if (Columns.FindByUId(new Guid("6a45e8e7-bc96-493b-9876-226000f5ef6e")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a29c8526-f618-4151-9ee7-ba8c7135ae5a"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("681ae3d8-644e-4c88-9f55-752ee45dd4a4"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("43bd22d7-5b84-454f-825d-e32f880c2504"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"c5822cf8-1e61-45bf-bb76-3b90e68d75f5"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("611dd225-b1b2-4fe9-a9ae-8e17947b30ce"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3284033b-d83d-4f37-b7a9-b89bef88a8af"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("b52918af-f05e-4251-985a-7877360e1e02"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"02d383fb-ce9b-4c5a-8c5a-c3e0f2989251"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("74338ff9-e309-436d-a2a0-25d19313523e"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("6abd0ec9-8a6d-4060-b6b8-948d16a547f4"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateGoalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("11aaba7b-60c1-4ff7-b612-8fa0fb3323be"),
				Name = @"Goal",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateTerritoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("82c6a0b8-0cc6-483b-8177-2d6d3eab0d73"),
				Name = @"Territory",
				ReferenceSchemaUId = new Guid("a0d1e591-78ee-44cb-9a58-39d6b59346f8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateIndustryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f209390f-73a2-47ae-97b9-fcd541bfd5dc"),
				Name = @"Industry",
				ReferenceSchemaUId = new Guid("95de3d3b-b909-40d9-a3fa-e80d38ec208e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateActualResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("998e902d-a9d5-49e5-bd1f-30981c8da5f3"),
				Name = @"ActualResponse",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryBudgetedCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("caab7f9b-9c25-462d-802b-9a6d2c5d4fc1"),
				Name = @"PrimaryBudgetedCost",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryExpectedRevenueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("4b1d344a-e187-4afb-8908-a7afcbbd175f"),
				Name = @"PrimaryExpectedRevenue",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryActualCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("e6a3cb4a-643f-4d3e-a220-d41b28eb8505"),
				Name = @"PrimaryActualCost",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryActualRevenueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c14a5743-28b5-4fdf-93af-d34708923ef5"),
				Name = @"PrimaryActualRevenue",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("645eabb6-dace-4ed4-b41f-01ef4469a857"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateActualizeStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("72cf8359-d4a2-4f5a-b969-4f465d737aa3"),
				Name = @"ActualizeStatus",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b")
			};
		}

		protected virtual EntitySchemaColumn CreateLastActualizeDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("2110bf6a-b8ef-4d49-899a-512a263da248"),
				Name = @"LastActualizeDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b")
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("64dc54f1-ff40-49fe-9a43-6d5f7baa2bda"),
				Name = @"RecipientCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("06c5e2cb-107e-4211-a5bd-01241dc3944b"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSegmentsStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("00650465-f72d-4313-a6d4-535bdcb0d4ce"),
				Name = @"SegmentsStatus",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"fa360d2c-1658-49ad-9152-22479fdc0c12"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6a45e8e7-bc96-493b-9876-226000f5ef6e"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				ModifiedInSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				CreatedInPackageId = new Guid("33ac637b-a93c-4dbe-96cf-f1afd79bdc1c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Event(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Event_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"));
		}

		#endregion

	}

	#endregion

	#region Class: Event

	/// <summary>
	/// Мероприятие.
	/// </summary>
	public class Event : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Event(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Event";
		}

		public Event(Event source)
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

		private EventType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public EventType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as EventType);
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

		private EventStatus _status;
		/// <summary>
		/// Состояние мероприятия.
		/// </summary>
		public EventStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as EventStatus);
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
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Цель.
		/// </summary>
		public string Goal {
			get {
				return GetTypedColumnValue<string>("Goal");
			}
			set {
				SetColumnValue("Goal", value);
			}
		}

		/// <exclude/>
		public Guid TerritoryId {
			get {
				return GetTypedColumnValue<Guid>("TerritoryId");
			}
			set {
				SetColumnValue("TerritoryId", value);
				_territory = null;
			}
		}

		/// <exclude/>
		public string TerritoryName {
			get {
				return GetTypedColumnValue<string>("TerritoryName");
			}
			set {
				SetColumnValue("TerritoryName", value);
				if (_territory != null) {
					_territory.Name = value;
				}
			}
		}

		private Territory _territory;
		/// <summary>
		/// Территория.
		/// </summary>
		public Territory Territory {
			get {
				return _territory ??
					(_territory = LookupColumnEntities.GetEntity("Territory") as Territory);
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
		/// Фактический отклик.
		/// </summary>
		public string ActualResponse {
			get {
				return GetTypedColumnValue<string>("ActualResponse");
			}
			set {
				SetColumnValue("ActualResponse", value);
			}
		}

		/// <summary>
		/// Плановый бюджет, б.в.
		/// </summary>
		public Decimal PrimaryBudgetedCost {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryBudgetedCost");
			}
			set {
				SetColumnValue("PrimaryBudgetedCost", value);
			}
		}

		/// <summary>
		/// План продаж, б.в.
		/// </summary>
		public Decimal PrimaryExpectedRevenue {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryExpectedRevenue");
			}
			set {
				SetColumnValue("PrimaryExpectedRevenue", value);
			}
		}

		/// <summary>
		/// Фактические затраты, б.в.
		/// </summary>
		public Decimal PrimaryActualCost {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryActualCost");
			}
			set {
				SetColumnValue("PrimaryActualCost", value);
			}
		}

		/// <summary>
		/// Факт продаж, б.в.
		/// </summary>
		public Decimal PrimaryActualRevenue {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryActualRevenue");
			}
			set {
				SetColumnValue("PrimaryActualRevenue", value);
			}
		}

		/// <summary>
		/// Примечания.
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
		public Guid ActualizeStatusId {
			get {
				return GetTypedColumnValue<Guid>("ActualizeStatusId");
			}
			set {
				SetColumnValue("ActualizeStatusId", value);
				_actualizeStatus = null;
			}
		}

		/// <exclude/>
		public string ActualizeStatusName {
			get {
				return GetTypedColumnValue<string>("ActualizeStatusName");
			}
			set {
				SetColumnValue("ActualizeStatusName", value);
				if (_actualizeStatus != null) {
					_actualizeStatus.Name = value;
				}
			}
		}

		private SegmentStatus _actualizeStatus;
		/// <summary>
		/// Состояние актуализации сегмента.
		/// </summary>
		public SegmentStatus ActualizeStatus {
			get {
				return _actualizeStatus ??
					(_actualizeStatus = LookupColumnEntities.GetEntity("ActualizeStatus") as SegmentStatus);
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
		/// Количество участников.
		/// </summary>
		public int RecipientCount {
			get {
				return GetTypedColumnValue<int>("RecipientCount");
			}
			set {
				SetColumnValue("RecipientCount", value);
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
		/// Список лидов.
		/// </summary>
		public SegmentStatus SegmentsStatus {
			get {
				return _segmentsStatus ??
					(_segmentsStatus = LookupColumnEntities.GetEntity("SegmentsStatus") as SegmentStatus);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Event_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventDeleted", e);
			Inserting += (s, e) => ThrowEvent("EventInserting", e);
			Validating += (s, e) => ThrowEvent("EventValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Event(this);
		}

		#endregion

	}

	#endregion

	#region Class: Event_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class Event_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Event
	{

		public Event_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Event_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f");
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

	#region Class: Event_MarketingCampaignEventsProcess

	/// <exclude/>
	public class Event_MarketingCampaignEventsProcess : Event_MarketingCampaignEventsProcess<Event>
	{

		public Event_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Event_MarketingCampaignEventsProcess

	public partial class Event_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EventEventsProcess

	/// <exclude/>
	public class EventEventsProcess : Event_MarketingCampaignEventsProcess
	{

		public EventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

