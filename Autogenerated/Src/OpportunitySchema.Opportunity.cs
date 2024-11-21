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

	#region Class: Opportunity_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class Opportunity_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Opportunity_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Opportunity_Opportunity_BPMSoftSchema(Opportunity_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Opportunity_Opportunity_BPMSoftSchema(Opportunity_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_OpportunityTitleIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("538d5288-c406-4b69-8f00-7b42c02cbdf3");
			index.Name = "IDX_OpportunityTitle";
			index.CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			index.ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			index.CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13");
			EntitySchemaIndexColumn titleIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7a45b5d6-7ce5-4417-8995-a0f6d21a272b"),
				ColumnUId = new Guid("790563cf-fd14-4d5d-a5fd-b6eddb10d6d3"),
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(titleIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			RealUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			Name = "Opportunity_Opportunity_BPMSoft";
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

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2b2e93bb-c5ac-4478-9e31-306c5bd5ceeb")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("797ac352-4979-4d28-906f-82feb6dbc9dc")) == null) {
				Columns.Add(CreateStageColumn());
			}
			if (Columns.FindByUId(new Guid("c8f5d6d7-aa99-4295-ade0-4ff6e840655f")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("d979bca9-13c3-463b-b279-641c0c51f9df")) == null) {
				Columns.Add(CreateCloseReasonColumn());
			}
			if (Columns.FindByUId(new Guid("975de813-489f-495b-98ab-e56a8a527e77")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("4b95e3ff-fd52-4ae1-b0a5-2c5103ff15a7")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("fae41c1b-a153-43df-852a-17ab3e608c18")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("c4eab4ef-2c91-43b5-b2a1-df5e60f6c3cd")) == null) {
				Columns.Add(CreateMoodColumn());
			}
			if (Columns.FindByUId(new Guid("3aab3a22-ded6-41a6-98bb-4bc7ca20bb06")) == null) {
				Columns.Add(CreateIsPrimaryColumn());
			}
			if (Columns.FindByUId(new Guid("75ad358c-8d9c-4bbb-83d5-2d9f60d3b7c3")) == null) {
				Columns.Add(CreatePartnerColumn());
			}
			if (Columns.FindByUId(new Guid("4348809e-6f05-426c-8802-958ffe90b176")) == null) {
				Columns.Add(CreateBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("bc62f730-7e4a-4578-953c-1cd9ac58a2b2")) == null) {
				Columns.Add(CreateProbabilityColumn());
			}
			if (Columns.FindByUId(new Guid("63c0fc1f-ac41-4497-96be-c27201994072")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("6c76d697-8138-47fc-897c-1f3820c45893")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("15f0f091-e66f-42db-807b-f4c2ad6337b6")) == null) {
				Columns.Add(CreateResponsibleDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("19429c25-e5dc-4a77-ab74-69bbec821ce4")) == null) {
				Columns.Add(CreateWeaknessesColumn());
			}
			if (Columns.FindByUId(new Guid("9295050c-1727-416a-949d-4684e2b61e3b")) == null) {
				Columns.Add(CreateStrengthColumn());
			}
			if (Columns.FindByUId(new Guid("d1cf610a-dc34-447b-b637-9970dc4f1b7e")) == null) {
				Columns.Add(CreateTacticColumn());
			}
			if (Columns.FindByUId(new Guid("7d2e418f-2cac-4b0c-823c-9f431027ce56")) == null) {
				Columns.Add(CreateCheckDateColumn());
			}
			if (Columns.FindByUId(new Guid("65715559-fa3f-4781-be93-5f3920b3e8f4")) == null) {
				Columns.Add(CreateProcessIdColumn());
			}
			if (Columns.FindByUId(new Guid("f460aa34-e072-4804-aa46-f886e60a3852")) == null) {
				Columns.Add(CreateWinnerColumn());
			}
			if (Columns.FindByUId(new Guid("64a05bfa-350d-4dbf-bfd8-fb579a74f39e")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("cf5dc330-48e7-48ac-8b86-06ffb1ae0391")) == null) {
				Columns.Add(CreateCompletenessColumn());
			}
			if (Columns.FindByUId(new Guid("f22a9cf5-213a-427f-aed7-ef864ffff2dd")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("790563cf-fd14-4d5d-a5fd-b6eddb10d6d3"),
				Name = @"Title",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2b2e93bb-c5ac-4478-9e31-306c5bd5ceeb"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("85fe0df7-a970-4717-8f7b-8caba783906b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("797ac352-4979-4d28-906f-82feb6dbc9dc"),
				Name = @"Stage",
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"c2067b11-0ee0-df11-971b-001d60e938c6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c8f5d6d7-aa99-4295-ade0-4ff6e840655f"),
				Name = @"DueDate",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCloseReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d979bca9-13c3-463b-b279-641c0c51f9df"),
				Name = @"CloseReason",
				ReferenceSchemaUId = new Guid("27ba43e5-6280-4458-855d-3c7118f678d7"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("684553a7-a59d-46fa-af4b-fc76e9fe3694"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("975de813-489f-495b-98ab-e56a8a527e77"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4b95e3ff-fd52-4ae1-b0a5-2c5103ff15a7"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fae41c1b-a153-43df-852a-17ab3e608c18"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("98f95046-8a53-4d6d-be56-91d68e624e6a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateMoodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c4eab4ef-2c91-43b5-b2a1-df5e60f6c3cd"),
				Name = @"Mood",
				ReferenceSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateIsPrimaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3aab3a22-ded6-41a6-98bb-4bc7ca20bb06"),
				Name = @"IsPrimary",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("75ad358c-8d9c-4bbb-83d5-2d9f60d3b7c3"),
				Name = @"Partner",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("4348809e-6f05-426c-8802-958ffe90b176"),
				Name = @"Budget",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateProbabilityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bc62f730-7e4a-4578-953c-1cd9ac58a2b2"),
				Name = @"Probability",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("63c0fc1f-ac41-4497-96be-c27201994072"),
				Name = @"Amount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6c76d697-8138-47fc-897c-1f3820c45893"),
				Name = @"Source",
				ReferenceSchemaUId = new Guid("6f66df29-03a2-41b3-9cde-021eeeedfcb0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateResponsibleDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("15f0f091-e66f-42db-807b-f4c2ad6337b6"),
				Name = @"ResponsibleDepartment",
				ReferenceSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateWeaknessesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("19429c25-e5dc-4a77-ab74-69bbec821ce4"),
				Name = @"Weaknesses",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateStrengthColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("9295050c-1727-416a-949d-4684e2b61e3b"),
				Name = @"Strength",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateTacticColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d1cf610a-dc34-447b-b637-9970dc4f1b7e"),
				Name = @"Tactic",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateCheckDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("7d2e418f-2cac-4b0c-823c-9f431027ce56"),
				Name = @"CheckDate",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("65715559-fa3f-4781-be93-5f3920b3e8f4"),
				Name = @"ProcessId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("8faebbb4-6032-45a8-ace5-f8b3ded3b01d")
			};
		}

		protected virtual EntitySchemaColumn CreateWinnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f460aa34-e072-4804-aa46-f886e60a3852"),
				Name = @"Winner",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("64a05bfa-350d-4dbf-bfd8-fb579a74f39e"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("847c168f-46d2-4935-ba54-2d351061d222")
			};
		}

		protected virtual EntitySchemaColumn CreateCompletenessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("cf5dc330-48e7-48ac-8b86-06ffb1ae0391"),
				Name = @"Completeness",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("2e81487b-ecb4-48b5-b3e6-cfc1669b881f")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f22a9cf5-213a-427f-aed7-ef864ffff2dd"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("331ebe45-2152-452a-9e4b-d72e7bcbf340"),
				IsMultiLineText = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_OpportunityTitleIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Opportunity_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Opportunity_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Opportunity_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Opportunity_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"));
		}

		#endregion

	}

	#endregion

	#region Class: Opportunity_Opportunity_BPMSoft

	/// <summary>
	/// Продажа.
	/// </summary>
	public class Opportunity_Opportunity_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Opportunity_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Opportunity_Opportunity_BPMSoft";
		}

		public Opportunity_Opportunity_BPMSoft(Opportunity_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
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

		private OpportunityType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public OpportunityType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as OpportunityType);
			}
		}

		/// <exclude/>
		public Guid StageId {
			get {
				return GetTypedColumnValue<Guid>("StageId");
			}
			set {
				SetColumnValue("StageId", value);
				_stage = null;
			}
		}

		/// <exclude/>
		public string StageName {
			get {
				return GetTypedColumnValue<string>("StageName");
			}
			set {
				SetColumnValue("StageName", value);
				if (_stage != null) {
					_stage.Name = value;
				}
			}
		}

		private OpportunityStage _stage;
		/// <summary>
		/// Стадия.
		/// </summary>
		public OpportunityStage Stage {
			get {
				return _stage ??
					(_stage = LookupColumnEntities.GetEntity("Stage") as OpportunityStage);
			}
		}

		/// <summary>
		/// Дата закрытия.
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
		public Guid CloseReasonId {
			get {
				return GetTypedColumnValue<Guid>("CloseReasonId");
			}
			set {
				SetColumnValue("CloseReasonId", value);
				_closeReason = null;
			}
		}

		/// <exclude/>
		public string CloseReasonName {
			get {
				return GetTypedColumnValue<string>("CloseReasonName");
			}
			set {
				SetColumnValue("CloseReasonName", value);
				if (_closeReason != null) {
					_closeReason.Name = value;
				}
			}
		}

		private OpportunityCloseReason _closeReason;
		/// <summary>
		/// Причина закрытия.
		/// </summary>
		public OpportunityCloseReason CloseReason {
			get {
				return _closeReason ??
					(_closeReason = LookupColumnEntities.GetEntity("CloseReason") as OpportunityCloseReason);
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

		private OpportunityCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public OpportunityCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as OpportunityCategory);
			}
		}

		/// <exclude/>
		public Guid MoodId {
			get {
				return GetTypedColumnValue<Guid>("MoodId");
			}
			set {
				SetColumnValue("MoodId", value);
				_mood = null;
			}
		}

		/// <exclude/>
		public string MoodName {
			get {
				return GetTypedColumnValue<string>("MoodName");
			}
			set {
				SetColumnValue("MoodName", value);
				if (_mood != null) {
					_mood.Name = value;
				}
			}
		}

		private OpportunityMood _mood;
		/// <summary>
		/// Настроение.
		/// </summary>
		public OpportunityMood Mood {
			get {
				return _mood ??
					(_mood = LookupColumnEntities.GetEntity("Mood") as OpportunityMood);
			}
		}

		/// <summary>
		/// Первая продажа данному клиенту.
		/// </summary>
		public bool IsPrimary {
			get {
				return GetTypedColumnValue<bool>("IsPrimary");
			}
			set {
				SetColumnValue("IsPrimary", value);
			}
		}

		/// <exclude/>
		public Guid PartnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerId");
			}
			set {
				SetColumnValue("PartnerId", value);
				_partner = null;
			}
		}

		/// <exclude/>
		public string PartnerName {
			get {
				return GetTypedColumnValue<string>("PartnerName");
			}
			set {
				SetColumnValue("PartnerName", value);
				if (_partner != null) {
					_partner.Name = value;
				}
			}
		}

		private Account _partner;
		/// <summary>
		/// Партнер.
		/// </summary>
		public Account Partner {
			get {
				return _partner ??
					(_partner = LookupColumnEntities.GetEntity("Partner") as Account);
			}
		}

		/// <summary>
		/// Бюджет клиента.
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
		/// Вероятность, %.
		/// </summary>
		public int Probability {
			get {
				return GetTypedColumnValue<int>("Probability");
			}
			set {
				SetColumnValue("Probability", value);
			}
		}

		/// <summary>
		/// Сумма продажи.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
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

		private OpportunitySource _source;
		/// <summary>
		/// Источник.
		/// </summary>
		public OpportunitySource Source {
			get {
				return _source ??
					(_source = LookupColumnEntities.GetEntity("Source") as OpportunitySource);
			}
		}

		/// <exclude/>
		public Guid ResponsibleDepartmentId {
			get {
				return GetTypedColumnValue<Guid>("ResponsibleDepartmentId");
			}
			set {
				SetColumnValue("ResponsibleDepartmentId", value);
				_responsibleDepartment = null;
			}
		}

		/// <exclude/>
		public string ResponsibleDepartmentName {
			get {
				return GetTypedColumnValue<string>("ResponsibleDepartmentName");
			}
			set {
				SetColumnValue("ResponsibleDepartmentName", value);
				if (_responsibleDepartment != null) {
					_responsibleDepartment.Name = value;
				}
			}
		}

		private OpportunityDepartment _responsibleDepartment;
		/// <summary>
		/// Направление.
		/// </summary>
		public OpportunityDepartment ResponsibleDepartment {
			get {
				return _responsibleDepartment ??
					(_responsibleDepartment = LookupColumnEntities.GetEntity("ResponsibleDepartment") as OpportunityDepartment);
			}
		}

		/// <summary>
		/// Наши слабые стороны.
		/// </summary>
		public string Weaknesses {
			get {
				return GetTypedColumnValue<string>("Weaknesses");
			}
			set {
				SetColumnValue("Weaknesses", value);
			}
		}

		/// <summary>
		/// Наши сильные стороны.
		/// </summary>
		public string Strength {
			get {
				return GetTypedColumnValue<string>("Strength");
			}
			set {
				SetColumnValue("Strength", value);
			}
		}

		/// <summary>
		/// Тактика продажи.
		/// </summary>
		public string Tactic {
			get {
				return GetTypedColumnValue<string>("Tactic");
			}
			set {
				SetColumnValue("Tactic", value);
			}
		}

		/// <summary>
		/// Дата проверки руководителем.
		/// </summary>
		public DateTime CheckDate {
			get {
				return GetTypedColumnValue<DateTime>("CheckDate");
			}
			set {
				SetColumnValue("CheckDate", value);
			}
		}

		/// <summary>
		/// Идентификатор процесса.
		/// </summary>
		public Guid ProcessId {
			get {
				return GetTypedColumnValue<Guid>("ProcessId");
			}
			set {
				SetColumnValue("ProcessId", value);
			}
		}

		/// <exclude/>
		public Guid WinnerId {
			get {
				return GetTypedColumnValue<Guid>("WinnerId");
			}
			set {
				SetColumnValue("WinnerId", value);
				_winner = null;
			}
		}

		/// <exclude/>
		public string WinnerName {
			get {
				return GetTypedColumnValue<string>("WinnerName");
			}
			set {
				SetColumnValue("WinnerName", value);
				if (_winner != null) {
					_winner.Name = value;
				}
			}
		}

		private Account _winner;
		/// <summary>
		/// Победитель.
		/// </summary>
		public Account Winner {
			get {
				return _winner ??
					(_winner = LookupColumnEntities.GetEntity("Winner") as Account);
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
		/// Полнота наполнения.
		/// </summary>
		public int Completeness {
			get {
				return GetTypedColumnValue<int>("Completeness");
			}
			set {
				SetColumnValue("Completeness", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Opportunity_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Opportunity_Opportunity_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Opportunity_Opportunity_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Opportunity_Opportunity_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Opportunity_Opportunity_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Opportunity_Opportunity_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Opportunity_Opportunity_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Opportunity_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Opportunity_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Opportunity_OpportunityEventsProcess

	/// <exclude/>
	public partial class Opportunity_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Opportunity_Opportunity_BPMSoft
	{

		#region Class: PrimaryActualRevenueCalcSumUserTaskFlowElement

		/// <exclude/>
		public class PrimaryActualRevenueCalcSumUserTaskFlowElement : CalcSumUserTask
		{

			public PrimaryActualRevenueCalcSumUserTaskFlowElement(UserConnection userConnection, Opportunity_OpportunityEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "PrimaryActualRevenueCalcSumUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("047e7598-b79a-46b1-8e57-8a057cfe8e5e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		#region Class: SynchronizeStageFlowElement

		/// <exclude/>
		public class SynchronizeStageFlowElement : SynchronizeChildEntityData
		{

			public SynchronizeStageFlowElement(UserConnection userConnection, Opportunity_OpportunityEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SynchronizeStage";
				IsLogging = false;
				SchemaElementUId = new Guid("5363dbee-cfca-42db-a161-776e61c80ee8");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		#region Class: PrimaryActualRevenueCalcSumOnDeleteUserTaskFlowElement

		/// <exclude/>
		public class PrimaryActualRevenueCalcSumOnDeleteUserTaskFlowElement : CalcSumUserTask
		{

			public PrimaryActualRevenueCalcSumOnDeleteUserTaskFlowElement(UserConnection userConnection, Opportunity_OpportunityEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "PrimaryActualRevenueCalcSumOnDeleteUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("5dfe5189-466f-49c2-b05b-c2a6f82981f2");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Opportunity_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Opportunity_OpportunityEventsProcess";
			SchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid StageOldValue {
			get;
			set;
		}

		public virtual bool IsStageChanged {
			get;
			set;
		}

		public virtual bool NeedSynchronizeCompetitor {
			get;
			set;
		}

		public virtual bool IsOwnerChanged {
			get;
			set;
		}

		public virtual Guid CampaignId {
			get;
			set;
		}

		public virtual Guid CampaignOldValue {
			get;
			set;
		}

		public virtual bool IsNewStageEnd {
			get;
			set;
		}

		public virtual Guid OldOwnerId {
			get;
			set;
		}

		public virtual bool IsTacticChanged {
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

		private ProcessFlowElement _subProcess1;
		public ProcessFlowElement SubProcess1 {
			get {
				return _subProcess1 ?? (_subProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess1",
					SchemaElementUId = new Guid("67267353-ee30-460a-a08f-7f503cdef2ca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _opportunitySaved;
		public ProcessFlowElement OpportunitySaved {
			get {
				return _opportunitySaved ?? (_opportunitySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunitySaved",
					SchemaElementUId = new Guid("8af1be52-c288-43d8-afc4-a09b32ab1996"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _synchronizeStageScript;
		public ProcessScriptTask SynchronizeStageScript {
			get {
				return _synchronizeStageScript ?? (_synchronizeStageScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeStageScript",
					SchemaElementUId = new Guid("8020eaaf-f57a-4bf3-9c97-2cb7d483e5aa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeStageScriptExecute,
				});
			}
		}

		private ProcessScriptTask _resetCompetitorsIsWinnerFalgScriptTask;
		public ProcessScriptTask ResetCompetitorsIsWinnerFalgScriptTask {
			get {
				return _resetCompetitorsIsWinnerFalgScriptTask ?? (_resetCompetitorsIsWinnerFalgScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ResetCompetitorsIsWinnerFalgScriptTask",
					SchemaElementUId = new Guid("8d0ca9d5-2876-404e-bddd-57cfcf8f47ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ResetCompetitorsIsWinnerFalgScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _scriptPrimaryActualRevenueCalcSum;
		public ProcessScriptTask ScriptPrimaryActualRevenueCalcSum {
			get {
				return _scriptPrimaryActualRevenueCalcSum ?? (_scriptPrimaryActualRevenueCalcSum = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptPrimaryActualRevenueCalcSum",
					SchemaElementUId = new Guid("8075f06c-e302-49cd-b9c2-3548a040da09"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptPrimaryActualRevenueCalcSumExecute,
				});
			}
		}

		private PrimaryActualRevenueCalcSumUserTaskFlowElement _primaryActualRevenueCalcSumUserTask;
		public PrimaryActualRevenueCalcSumUserTaskFlowElement PrimaryActualRevenueCalcSumUserTask {
			get {
				return _primaryActualRevenueCalcSumUserTask ?? (_primaryActualRevenueCalcSumUserTask = new PrimaryActualRevenueCalcSumUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _scriptDoNothing;
		public ProcessScriptTask ScriptDoNothing {
			get {
				return _scriptDoNothing ?? (_scriptDoNothing = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptDoNothing",
					SchemaElementUId = new Guid("d4e66c47-cd0c-4e92-9a59-1b705d7e3334"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptDoNothingExecute,
				});
			}
		}

		private SynchronizeStageFlowElement _synchronizeStage;
		public SynchronizeStageFlowElement SynchronizeStage {
			get {
				return _synchronizeStage ?? (_synchronizeStage = new SynchronizeStageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("56796de1-8d42-460e-b1cc-30f198063445"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateRemindingsExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess2;
		public ProcessFlowElement SubProcess2 {
			get {
				return _subProcess2 ?? (_subProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess2",
					SchemaElementUId = new Guid("2b072ee0-6c70-4a3b-b0b0-1752cbe3259a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _opportunitySaving;
		public ProcessFlowElement OpportunitySaving {
			get {
				return _opportunitySaving ?? (_opportunitySaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunitySaving",
					SchemaElementUId = new Guid("6be2a148-5ab8-4792-947c-5594134ff4b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptOpportunitySaving;
		public ProcessScriptTask ScriptOpportunitySaving {
			get {
				return _scriptOpportunitySaving ?? (_scriptOpportunitySaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptOpportunitySaving",
					SchemaElementUId = new Guid("a0e6fad5-70a6-47b0-9328-11505b526d6b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptOpportunitySavingExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess3;
		public ProcessFlowElement SubProcess3 {
			get {
				return _subProcess3 ?? (_subProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess3",
					SchemaElementUId = new Guid("42fb7d8c-e942-4855-9233-9dd870db06cb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _opportunityDeleting;
		public ProcessFlowElement OpportunityDeleting {
			get {
				return _opportunityDeleting ?? (_opportunityDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpportunityDeleting",
					SchemaElementUId = new Guid("3a094e2c-1580-4f53-a8e8-155cac0202f5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptOpportunityDeleting;
		public ProcessScriptTask ScriptOpportunityDeleting {
			get {
				return _scriptOpportunityDeleting ?? (_scriptOpportunityDeleting = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptOpportunityDeleting",
					SchemaElementUId = new Guid("27e3276c-fd8a-4ec2-858d-68c734734a22"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptOpportunityDeletingExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess4;
		public ProcessFlowElement SubProcess4 {
			get {
				return _subProcess4 ?? (_subProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess4",
					SchemaElementUId = new Guid("049ceae7-6039-4901-80af-77656912f566"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("48265622-0d8c-4a5f-9246-eb16a24a6a7d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		private PrimaryActualRevenueCalcSumOnDeleteUserTaskFlowElement _primaryActualRevenueCalcSumOnDeleteUserTask;
		public PrimaryActualRevenueCalcSumOnDeleteUserTaskFlowElement PrimaryActualRevenueCalcSumOnDeleteUserTask {
			get {
				return _primaryActualRevenueCalcSumOnDeleteUserTask ?? (_primaryActualRevenueCalcSumOnDeleteUserTask = new PrimaryActualRevenueCalcSumOnDeleteUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _scriptDeleteDoNothing;
		public ProcessScriptTask ScriptDeleteDoNothing {
			get {
				return _scriptDeleteDoNothing ?? (_scriptDeleteDoNothing = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptDeleteDoNothing",
					SchemaElementUId = new Guid("d314254b-f9a9-42a9-9d05-c0de08ed91e5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptDeleteDoNothingExecute,
				});
			}
		}

		private ProcessConditionalFlow _sequenceFlow6790;
		public ProcessConditionalFlow SequenceFlow6790 {
			get {
				return _sequenceFlow6790 ?? (_sequenceFlow6790 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "SequenceFlow6790",
					SchemaElementUId = new Guid("171018ec-9329-4062-bdad-99f499b5bcb7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _sequenceFlow6793;
		public ProcessConditionalFlow SequenceFlow6793 {
			get {
				return _sequenceFlow6793 ?? (_sequenceFlow6793 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "SequenceFlow6793",
					SchemaElementUId = new Guid("efb73336-27e0-48e3-bf29-9fb9843aab75"),
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
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[OpportunitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunitySaved };
			FlowElements[SynchronizeStageScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeStageScript };
			FlowElements[ResetCompetitorsIsWinnerFalgScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ResetCompetitorsIsWinnerFalgScriptTask };
			FlowElements[ScriptPrimaryActualRevenueCalcSum.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptPrimaryActualRevenueCalcSum };
			FlowElements[PrimaryActualRevenueCalcSumUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrimaryActualRevenueCalcSumUserTask };
			FlowElements[ScriptDoNothing.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptDoNothing };
			FlowElements[SynchronizeStage.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeStage };
			FlowElements[UpdateRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateRemindings };
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[OpportunitySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunitySaving };
			FlowElements[ScriptOpportunitySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptOpportunitySaving };
			FlowElements[SubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess3 };
			FlowElements[OpportunityDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityDeleting };
			FlowElements[ScriptOpportunityDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptOpportunityDeleting };
			FlowElements[SubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess4 };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[PrimaryActualRevenueCalcSumOnDeleteUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrimaryActualRevenueCalcSumOnDeleteUserTask };
			FlowElements[ScriptDeleteDoNothing.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptDeleteDoNothing };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SubProcess1":
						break;
					case "OpportunitySaved":
						e.Context.QueueTasks.Enqueue("SynchronizeStageScript");
						e.Context.QueueTasks.Enqueue("UpdateRemindings");
						break;
					case "SynchronizeStageScript":
						e.Context.QueueTasks.Enqueue("ResetCompetitorsIsWinnerFalgScriptTask");
						break;
					case "ResetCompetitorsIsWinnerFalgScriptTask":
						break;
					case "ScriptPrimaryActualRevenueCalcSum":
						if (SequenceFlow6790ExpressionExecute()) {
						e.Context.QueueTasks.Enqueue("PrimaryActualRevenueCalcSumUserTask");
							break;
						}
						e.Context.QueueTasks.Enqueue("ScriptDoNothing");
						break;
					case "PrimaryActualRevenueCalcSumUserTask":
						break;
					case "ScriptDoNothing":
						break;
					case "SynchronizeStage":
						break;
					case "UpdateRemindings":
						break;
					case "SubProcess2":
						break;
					case "OpportunitySaving":
						e.Context.QueueTasks.Enqueue("ScriptOpportunitySaving");
						break;
					case "ScriptOpportunitySaving":
						break;
					case "SubProcess3":
						break;
					case "OpportunityDeleting":
						e.Context.QueueTasks.Enqueue("ScriptOpportunityDeleting");
						break;
					case "ScriptOpportunityDeleting":
						break;
					case "SubProcess4":
						break;
					case "ScriptTask2":
						if (SequenceFlow6793ExpressionExecute()) {
						e.Context.QueueTasks.Enqueue("PrimaryActualRevenueCalcSumOnDeleteUserTask");
							break;
						}
						e.Context.QueueTasks.Enqueue("ScriptDeleteDoNothing");
						break;
					case "PrimaryActualRevenueCalcSumOnDeleteUserTask":
						break;
					case "ScriptDeleteDoNothing":
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool SequenceFlow6790ExpressionExecute() {
			return Convert.ToBoolean((CampaignId != null) || (CampaignOldValue != null));
		}

		private bool SequenceFlow6793ExpressionExecute() {
			return Convert.ToBoolean((CampaignOldValue != null));
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("OpportunitySaved");
			ActivatedEventElements.Add("OpportunitySaving");
			ActivatedEventElements.Add("OpportunityDeleting");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "OpportunitySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunitySaved";
					result = OpportunitySaved.Execute(context);
					break;
				case "SynchronizeStageScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeStageScript";
					result = SynchronizeStageScript.Execute(context, SynchronizeStageScriptExecute);
					break;
				case "ResetCompetitorsIsWinnerFalgScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ResetCompetitorsIsWinnerFalgScriptTask";
					result = ResetCompetitorsIsWinnerFalgScriptTask.Execute(context, ResetCompetitorsIsWinnerFalgScriptTaskExecute);
					break;
				case "ScriptPrimaryActualRevenueCalcSum":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptPrimaryActualRevenueCalcSum";
					result = ScriptPrimaryActualRevenueCalcSum.Execute(context, ScriptPrimaryActualRevenueCalcSumExecute);
					break;
				case "PrimaryActualRevenueCalcSumUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PrimaryActualRevenueCalcSumUserTask";
					result = PrimaryActualRevenueCalcSumUserTask.Execute(context);
					break;
				case "ScriptDoNothing":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptDoNothing";
					result = ScriptDoNothing.Execute(context, ScriptDoNothingExecute);
					break;
				case "SynchronizeStage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeStage";
					result = SynchronizeStage.Execute(context);
					break;
				case "UpdateRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateRemindings";
					result = UpdateRemindings.Execute(context, UpdateRemindingsExecute);
					break;
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "OpportunitySaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunitySaving";
					result = OpportunitySaving.Execute(context);
					break;
				case "ScriptOpportunitySaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptOpportunitySaving";
					result = ScriptOpportunitySaving.Execute(context, ScriptOpportunitySavingExecute);
					break;
				case "SubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "OpportunityDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "OpportunityDeleting";
					result = OpportunityDeleting.Execute(context);
					break;
				case "ScriptOpportunityDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptOpportunityDeleting";
					result = ScriptOpportunityDeleting.Execute(context, ScriptOpportunityDeletingExecute);
					break;
				case "SubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
					break;
				case "PrimaryActualRevenueCalcSumOnDeleteUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PrimaryActualRevenueCalcSumOnDeleteUserTask";
					result = PrimaryActualRevenueCalcSumOnDeleteUserTask.Execute(context);
					break;
				case "ScriptDeleteDoNothing":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptDeleteDoNothing";
					result = ScriptDeleteDoNothing.Execute(context, ScriptDeleteDoNothingExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SynchronizeStageScriptExecute(ProcessExecutingContext context) {
			if (CampaignOldValue.Equals(Guid.Empty) && IsTacticChanged) {
				var tacticHelper = BPMSoft.Core.Factories.ClassFactory.Get<BPMSoft.Configuration.OpportunityTacticsHelper>(
					new BPMSoft.Core.Factories.ConstructorArgument("userConnection", UserConnection));
				tacticHelper.UpdateOpportunityTacticHistory(Entity);
			}
			SynchronizeOpportunityStage();
			return true;
		}

		public virtual bool ResetCompetitorsIsWinnerFalgScriptTaskExecute(ProcessExecutingContext context) {
			if(IsStageChanged && Entity.GetTypedColumnValue<Guid>("StageId") == new Guid("60D5310C-5BE6-DF11-971B-001D60E938C6")) {
				var update = new Update(UserConnection, "OpportunityCompetitor")
					.Set("IsWinner", Column.Parameter(false))
					.Where("OpportunityId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue))
					.And("IsWinner").IsEqual(Column.Parameter(true));
				update.Execute();
			}
			return true;
		}

		public virtual bool ScriptPrimaryActualRevenueCalcSumExecute(ProcessExecutingContext context) {
			Guid CampaignId = Guid.Empty;
			//CampaignId = Entity.GetTypedColumnValue<Guid>("CampaignId");
			if ((CampaignId != null) || (CampaignOldValue != null)) {
				CampaignId = (CampaignId != null) ? CampaignId : CampaignOldValue;
				PrimaryActualRevenueCalcSumUserTask.ParentSchemaUId = new Guid("a7dc714c-45a7-4971-9e1e-cfe64d5cd410");
				PrimaryActualRevenueCalcSumUserTask.ChildSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
				PrimaryActualRevenueCalcSumUserTask.ParentColumnResultUId = new Guid("eb2b9611-afa5-41f2-b8c8-88e09a258f30");
				PrimaryActualRevenueCalcSumUserTask.ParentColumnRelationUId = new Guid("c6d27fd7-1dd3-40f0-aba0-f32018ce59a7");
				PrimaryActualRevenueCalcSumUserTask.ChildColumnUId = new Guid("68fae92e-bdb4-4473-bf47-8edff49010ea");
				PrimaryActualRevenueCalcSumUserTask.ParentColumnRelationValue = new Guid(CampaignId.ToString());
			}
			return true;
		}

		public virtual bool ScriptDoNothingExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool UpdateRemindingsExecute(ProcessExecutingContext context) {
			ExecuteUpdateRemindings();
			return true;
		}

		public virtual bool ScriptOpportunitySavingExecute(ProcessExecutingContext context) {
			/*CampaignOldValue = Entity.GetTypedOldColumnValue<Guid>(Entity.Schema.Columns.GetByName("Campaign").ColumnValueName);
			if (CampaignOldValue.Equals(Guid.Empty)) {
				return true;
			}*/
			var columns = Entity.GetChangedColumnValues();
			InitCanGenerateAnniversaryReminding();
			string ownerColumnName = Entity.Schema.Columns.GetByName("Owner").ColumnValueName;
			IsOwnerChanged = columns.Any(c => c.Name == ownerColumnName);
			string stageColumnName = Entity.Schema.Columns.GetByName("Stage").ColumnValueName;
			bool isTacticChanged = columns.Any(c => c.Name == "Tactic");
			bool isCheckDateChanged = columns.Any(c => c.Name == "CheckDate");
			bool isStageColumnLoaded = Entity.IsColumnValueLoaded(stageColumnName);
			string dueDateColumnName = "DueDate";
			IsTacticChanged = isTacticChanged || isCheckDateChanged;
			OldOwnerId = Entity.GetTypedOldColumnValue<Guid>(ownerColumnName);
			StageOldValue = isStageColumnLoaded ? Entity.GetTypedOldColumnValue<Guid>(stageColumnName) : Guid.Empty;
			var stageId = isStageColumnLoaded ? Entity.GetTypedColumnValue<Guid>(stageColumnName) : Guid.Empty;
			var dueDate = Entity.IsColumnValueLoaded(dueDateColumnName) ?
				Entity.GetTypedColumnValue<DateTime>(dueDateColumnName) :
				new DateTime();
			IsStageChanged = StageOldValue != stageId;
			
			if (IsStageChanged) {
				IsNewStageEnd = false;
				var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
				var stageSchemaQuery = new EntitySchemaQuery(entitySchemaManager, "OpportunityStage");
				stageSchemaQuery.AddColumn("End");				
				var stageIdFilter = stageSchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", stageId);
				stageSchemaQuery.Filters.Add(stageIdFilter);	
				var stages = stageSchemaQuery.GetEntityCollection(UserConnection);
				if (stages.Count > 0) {
					IsNewStageEnd = stages[0].GetTypedColumnValue<bool>("End");
				}
				if(IsNewStageEnd) {
					Entity.SetColumnValue("DueDate", UserConnection.CurrentUser.GetCurrentDateTime());
				}
			}
			return true;
		}

		public virtual bool ScriptOpportunityDeletingExecute(ProcessExecutingContext context) {
			//CampaignOldValue = Entity.GetTypedOldColumnValue<Guid>(Entity.Schema.Columns.GetByName("Campaign").ColumnValueName);
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			if (CampaignOldValue != null) {
				PrimaryActualRevenueCalcSumOnDeleteUserTask.ParentSchemaUId = new Guid("a7dc714c-45a7-4971-9e1e-cfe64d5cd410");
				PrimaryActualRevenueCalcSumOnDeleteUserTask.ChildSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
				PrimaryActualRevenueCalcSumOnDeleteUserTask.ParentColumnResultUId = new Guid("eb2b9611-afa5-41f2-b8c8-88e09a258f30");
				PrimaryActualRevenueCalcSumOnDeleteUserTask.ParentColumnRelationUId = new Guid("c6d27fd7-1dd3-40f0-aba0-f32018ce59a7");
				PrimaryActualRevenueCalcSumOnDeleteUserTask.ChildColumnUId = new Guid("68fae92e-bdb4-4473-bf47-8edff49010ea");
				PrimaryActualRevenueCalcSumOnDeleteUserTask.ParentColumnRelationValue = new Guid(CampaignOldValue.ToString());
			}
			return true;
		}

		public virtual bool ScriptDeleteDoNothingExecute(ProcessExecutingContext context) {
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Opportunity_Opportunity_BPMSoftSaved":
							if (ActivatedEventElements.Contains("OpportunitySaved")) {
							context.QueueTasks.Enqueue("OpportunitySaved");
						}
						break;
					case "Opportunity_Opportunity_BPMSoftSaving":
							if (ActivatedEventElements.Contains("OpportunitySaving")) {
							context.QueueTasks.Enqueue("OpportunitySaving");
						}
						break;
					case "Opportunity_Opportunity_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("OpportunityDeleting")) {
							context.QueueTasks.Enqueue("OpportunityDeleting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Opportunity_OpportunityEventsProcess

	/// <exclude/>
	public class Opportunity_OpportunityEventsProcess : Opportunity_OpportunityEventsProcess<Opportunity_Opportunity_BPMSoft>
	{

		public Opportunity_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

