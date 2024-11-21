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

	#region Class: Project_Project_BPMSoftSchema

	/// <exclude/>
	public class Project_Project_BPMSoftSchema : BPMSoft.Configuration.BaseEntityNotesSchema
	{

		#region Constructors: Public

		public Project_Project_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Project_Project_BPMSoftSchema(Project_Project_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Project_Project_BPMSoftSchema(Project_Project_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			RealUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			Name = "Project_Project_BPMSoft";
			ParentSchemaUId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
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

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentProjectColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("62a1bf12-279e-48d8-8a28-041be01c5003")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("1b4c54b0-33fc-4aeb-9f48-acddb453fe5b")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("41e82ce8-a31c-48a0-b6a5-b90660c83759")) == null) {
				Columns.Add(CreateProjectEntryTypeColumn());
			}
			if (Columns.FindByUId(new Guid("e0d39946-16ca-4649-b6fb-1be29312f709")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("532d4f22-8b39-4860-8e62-60b678c9193a")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("e1829b39-9b37-4a34-9e33-18fc056fdcbd")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("8f11337c-f8fe-4e3c-9576-b26554359fd7")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("470aee83-6564-4676-b0c7-44e8374664d5")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("e8cb5416-f527-45fa-ab0d-625b915c088c")) == null) {
				Columns.Add(CreateDurationColumn());
			}
			if (Columns.FindByUId(new Guid("f78cd4b2-fd18-4053-894d-b255fd197b62")) == null) {
				Columns.Add(CreateDeadlineColumn());
			}
			if (Columns.FindByUId(new Guid("88bc4b97-11f8-448f-9d43-3c801f60790e")) == null) {
				Columns.Add(CreateSupplierColumn());
			}
			if (Columns.FindByUId(new Guid("32044112-504d-4450-9d02-bd669f4c4f01")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
			if (Columns.FindByUId(new Guid("66e7067f-6bcd-431f-bc33-93a89d748ad6")) == null) {
				Columns.Add(CreateActualCompletionColumn());
			}
			if (Columns.FindByUId(new Guid("99967435-03c4-41e2-ac57-e1313ee1aac1")) == null) {
				Columns.Add(CreateIsAutoCalcCompletionColumn());
			}
			if (Columns.FindByUId(new Guid("d3a36229-802e-4ca7-8136-991aedd18274")) == null) {
				Columns.Add(CreatePlanIncomeColumn());
			}
			if (Columns.FindByUId(new Guid("486f48f4-375e-4a21-aa9f-b0cf7dfef749")) == null) {
				Columns.Add(CreateFactIncomeColumn());
			}
			if (Columns.FindByUId(new Guid("ae3fe8ec-0c11-4db9-891b-0a3a97f7e4be")) == null) {
				Columns.Add(CreateIncomeDevColumn());
			}
			if (Columns.FindByUId(new Guid("1e0cfd57-b456-4e2c-af46-e9161c3f7aff")) == null) {
				Columns.Add(CreateIncomeDevPercColumn());
			}
			if (Columns.FindByUId(new Guid("19c7568e-fa60-4afe-a1b4-5b63f75bffb4")) == null) {
				Columns.Add(CreatePlanExternalCostColumn());
			}
			if (Columns.FindByUId(new Guid("48f4cd4f-df8a-4894-a574-f04c5c7760f2")) == null) {
				Columns.Add(CreateFactExternalCostColumn());
			}
			if (Columns.FindByUId(new Guid("a3ee342c-2693-4946-8923-dfae5a31758a")) == null) {
				Columns.Add(CreateExternalCostDevColumn());
			}
			if (Columns.FindByUId(new Guid("a1d3575a-66fd-41f9-ba98-5f6db0a378e0")) == null) {
				Columns.Add(CreatePlanExternalDevPercColumn());
			}
			if (Columns.FindByUId(new Guid("4d54a487-00a3-4365-89b2-1c1db30cd74b")) == null) {
				Columns.Add(CreatePlanExpenseColumn());
			}
			if (Columns.FindByUId(new Guid("5409edce-b74d-43d1-b2bc-809d3e704441")) == null) {
				Columns.Add(CreateFactExpenseColumn());
			}
			if (Columns.FindByUId(new Guid("61c108ff-dde2-481a-862c-aefbf5c427a8")) == null) {
				Columns.Add(CreateExpenseDevColumn());
			}
			if (Columns.FindByUId(new Guid("b81af69b-d44c-413a-ab0f-e92d747f98b0")) == null) {
				Columns.Add(CreateExpenseDevPercColumn());
			}
			if (Columns.FindByUId(new Guid("9da8c8a1-94c2-43bd-b3d3-110811d7cebf")) == null) {
				Columns.Add(CreatePlanInternalCostColumn());
			}
			if (Columns.FindByUId(new Guid("76578c06-52ea-4daf-9fc7-cb311960a9d4")) == null) {
				Columns.Add(CreateFactInternalCostColumn());
			}
			if (Columns.FindByUId(new Guid("d0c0c991-79b5-4c4d-a023-c21247ac055f")) == null) {
				Columns.Add(CreateInternalCostDevColumn());
			}
			if (Columns.FindByUId(new Guid("5ca01a2f-a281-4f2c-9683-bed1debf6499")) == null) {
				Columns.Add(CreatePlanInternalDevPercColumn());
			}
			if (Columns.FindByUId(new Guid("49fdaaf1-5d6d-4733-9db3-d91072236648")) == null) {
				Columns.Add(CreatePlanMarginColumn());
			}
			if (Columns.FindByUId(new Guid("caca0f15-0494-47c7-a6e9-d6e2ff54fa5a")) == null) {
				Columns.Add(CreatePlanMarginPercColumn());
			}
			if (Columns.FindByUId(new Guid("e4e98bdc-f728-41a4-89b9-7c70ff75def5")) == null) {
				Columns.Add(CreateFactMarginColumn());
			}
			if (Columns.FindByUId(new Guid("2a15bb6d-441c-4b2a-b8fd-a4d0d1bfe4ff")) == null) {
				Columns.Add(CreateFactMarginPercColumn());
			}
			if (Columns.FindByUId(new Guid("3c28c5e9-a73f-4a49-bf98-59634c5310c9")) == null) {
				Columns.Add(CreateMarginDevColumn());
			}
			if (Columns.FindByUId(new Guid("a95be56a-d10a-4921-bfe4-faea45cf0db2")) == null) {
				Columns.Add(CreateMarginDevPercColumn());
			}
			if (Columns.FindByUId(new Guid("07b548e1-64fe-41bd-ae88-0f4927be9c65")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			column.CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("aaec4bf5-a07d-4f79-b45d-8c7eeead3fad"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("62a1bf12-279e-48d8-8a28-041be01c5003"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1b4c54b0-33fc-4aeb-9f48-acddb453fe5b"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateProjectEntryTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("41e82ce8-a31c-48a0-b6a5-b90660c83759"),
				Name = @"ProjectEntryType",
				ReferenceSchemaUId = new Guid("282a4e1e-5384-406c-8b67-a66fe9b9c0d9"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e0d39946-16ca-4649-b6fb-1be29312f709"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("ebcd53e5-4d8a-4109-b995-951d35677bc5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("532d4f22-8b39-4860-8e62-60b678c9193a"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e1829b39-9b37-4a34-9e33-18fc056fdcbd"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("8bafd341-8ae7-4703-bca6-8de07c992d37"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ProjectStateDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("8f11337c-f8fe-4e3c-9576-b26554359fd7"),
				Name = @"StartDate",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("470aee83-6564-4676-b0c7-44e8374664d5"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e8cb5416-f527-45fa-ab0d-625b915c088c"),
				Name = @"Duration",
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateDeadlineColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("f78cd4b2-fd18-4053-894d-b255fd197b62"),
				Name = @"Deadline",
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateSupplierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("88bc4b97-11f8-448f-9d43-3c801f60790e"),
				Name = @"Supplier",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserAccount")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("32044112-504d-4450-9d02-bd669f4c4f01"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateParentProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1e08e1e5-e00b-4abb-8022-43a6b913d48f"),
				Name = @"ParentProject",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateActualCompletionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("66e7067f-6bcd-431f-bc33-93a89d748ad6"),
				Name = @"ActualCompletion",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateIsAutoCalcCompletionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("99967435-03c4-41e2-ac57-e1313ee1aac1"),
				Name = @"IsAutoCalcCompletion",
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("ee500218-76c6-4043-a948-469ada4fc1d4")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanIncomeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("d3a36229-802e-4ca7-8136-991aedd18274"),
				Name = @"PlanIncome",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateFactIncomeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("486f48f4-375e-4a21-aa9f-b0cf7dfef749"),
				Name = @"FactIncome",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateIncomeDevColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("ae3fe8ec-0c11-4db9-891b-0a3a97f7e4be"),
				Name = @"IncomeDev",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateIncomeDevPercColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("1e0cfd57-b456-4e2c-af46-e9161c3f7aff"),
				Name = @"IncomeDevPerc",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanExternalCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("19c7568e-fa60-4afe-a1b4-5b63f75bffb4"),
				Name = @"PlanExternalCost",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateFactExternalCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("48f4cd4f-df8a-4894-a574-f04c5c7760f2"),
				Name = @"FactExternalCost",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalCostDevColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("a3ee342c-2693-4946-8923-dfae5a31758a"),
				Name = @"ExternalCostDev",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanExternalDevPercColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("a1d3575a-66fd-41f9-ba98-5f6db0a378e0"),
				Name = @"PlanExternalDevPerc",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanExpenseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("4d54a487-00a3-4365-89b2-1c1db30cd74b"),
				Name = @"PlanExpense",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateFactExpenseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("5409edce-b74d-43d1-b2bc-809d3e704441"),
				Name = @"FactExpense",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateExpenseDevColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("61c108ff-dde2-481a-862c-aefbf5c427a8"),
				Name = @"ExpenseDev",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateExpenseDevPercColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("b81af69b-d44c-413a-ab0f-e92d747f98b0"),
				Name = @"ExpenseDevPerc",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanInternalCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("9da8c8a1-94c2-43bd-b3d3-110811d7cebf"),
				Name = @"PlanInternalCost",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateFactInternalCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("76578c06-52ea-4daf-9fc7-cb311960a9d4"),
				Name = @"FactInternalCost",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateInternalCostDevColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("d0c0c991-79b5-4c4d-a023-c21247ac055f"),
				Name = @"InternalCostDev",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanInternalDevPercColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("5ca01a2f-a281-4f2c-9683-bed1debf6499"),
				Name = @"PlanInternalDevPerc",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanMarginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("49fdaaf1-5d6d-4733-9db3-d91072236648"),
				Name = @"PlanMargin",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePlanMarginPercColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("caca0f15-0494-47c7-a6e9-d6e2ff54fa5a"),
				Name = @"PlanMarginPerc",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateFactMarginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("e4e98bdc-f728-41a4-89b9-7c70ff75def5"),
				Name = @"FactMargin",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateFactMarginPercColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("2a15bb6d-441c-4b2a-b8fd-a4d0d1bfe4ff"),
				Name = @"FactMarginPerc",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateMarginDevColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("3c28c5e9-a73f-4a49-bf98-59634c5310c9"),
				Name = @"MarginDev",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreateMarginDevPercColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("a95be56a-d10a-4921-bfe4-faea45cf0db2"),
				Name = @"MarginDevPerc",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("07b548e1-64fe-41bd-ae88-0f4927be9c65"),
				Name = @"Position",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				ModifiedInSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Project_Project_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Project_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Project_Project_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Project_Project_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"));
		}

		#endregion

	}

	#endregion

	#region Class: Project_Project_BPMSoft

	/// <summary>
	/// Проект.
	/// </summary>
	public class Project_Project_BPMSoft : BPMSoft.Configuration.BaseEntityNotes
	{

		#region Constructors: Public

		public Project_Project_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Project_Project_BPMSoft";
		}

		public Project_Project_BPMSoft(Project_Project_BPMSoft source)
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
		public Guid ProjectEntryTypeId {
			get {
				return GetTypedColumnValue<Guid>("ProjectEntryTypeId");
			}
			set {
				SetColumnValue("ProjectEntryTypeId", value);
				_projectEntryType = null;
			}
		}

		/// <exclude/>
		public string ProjectEntryTypeName {
			get {
				return GetTypedColumnValue<string>("ProjectEntryTypeName");
			}
			set {
				SetColumnValue("ProjectEntryTypeName", value);
				if (_projectEntryType != null) {
					_projectEntryType.Name = value;
				}
			}
		}

		private ProjectEntryType _projectEntryType;
		/// <summary>
		/// Тип записи проекта.
		/// </summary>
		public ProjectEntryType ProjectEntryType {
			get {
				return _projectEntryType ??
					(_projectEntryType = LookupColumnEntities.GetEntity("ProjectEntryType") as ProjectEntryType);
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

		private ProjectType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ProjectType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ProjectType);
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

		private ProjectStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ProjectStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ProjectStatus);
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
		/// Длительность.
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
		/// Крайний срок.
		/// </summary>
		public DateTime Deadline {
			get {
				return GetTypedColumnValue<DateTime>("Deadline");
			}
			set {
				SetColumnValue("Deadline", value);
			}
		}

		/// <exclude/>
		public Guid SupplierId {
			get {
				return GetTypedColumnValue<Guid>("SupplierId");
			}
			set {
				SetColumnValue("SupplierId", value);
				_supplier = null;
			}
		}

		/// <exclude/>
		public string SupplierName {
			get {
				return GetTypedColumnValue<string>("SupplierName");
			}
			set {
				SetColumnValue("SupplierName", value);
				if (_supplier != null) {
					_supplier.Name = value;
				}
			}
		}

		private Account _supplier;
		/// <summary>
		/// Поставщик.
		/// </summary>
		public Account Supplier {
			get {
				return _supplier ??
					(_supplier = LookupColumnEntities.GetEntity("Supplier") as Account);
			}
		}

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		/// <exclude/>
		public Guid ParentProjectId {
			get {
				return GetTypedColumnValue<Guid>("ParentProjectId");
			}
			set {
				SetColumnValue("ParentProjectId", value);
				_parentProject = null;
			}
		}

		/// <exclude/>
		public string ParentProjectName {
			get {
				return GetTypedColumnValue<string>("ParentProjectName");
			}
			set {
				SetColumnValue("ParentProjectName", value);
				if (_parentProject != null) {
					_parentProject.Name = value;
				}
			}
		}

		private Project _parentProject;
		/// <summary>
		/// Родительский элемент.
		/// </summary>
		public Project ParentProject {
			get {
				return _parentProject ??
					(_parentProject = LookupColumnEntities.GetEntity("ParentProject") as Project);
			}
		}

		/// <summary>
		/// % выполнения.
		/// </summary>
		public Decimal ActualCompletion {
			get {
				return GetTypedColumnValue<Decimal>("ActualCompletion");
			}
			set {
				SetColumnValue("ActualCompletion", value);
			}
		}

		/// <summary>
		/// Рассчитывать автоматически.
		/// </summary>
		public bool IsAutoCalcCompletion {
			get {
				return GetTypedColumnValue<bool>("IsAutoCalcCompletion");
			}
			set {
				SetColumnValue("IsAutoCalcCompletion", value);
			}
		}

		/// <summary>
		/// План. доход.
		/// </summary>
		public Decimal PlanIncome {
			get {
				return GetTypedColumnValue<Decimal>("PlanIncome");
			}
			set {
				SetColumnValue("PlanIncome", value);
			}
		}

		/// <summary>
		/// Факт. доход.
		/// </summary>
		public Decimal FactIncome {
			get {
				return GetTypedColumnValue<Decimal>("FactIncome");
			}
			set {
				SetColumnValue("FactIncome", value);
			}
		}

		/// <summary>
		/// Отклонение дохода.
		/// </summary>
		public Decimal IncomeDev {
			get {
				return GetTypedColumnValue<Decimal>("IncomeDev");
			}
			set {
				SetColumnValue("IncomeDev", value);
			}
		}

		/// <summary>
		/// Отклонение дохода, %.
		/// </summary>
		public Decimal IncomeDevPerc {
			get {
				return GetTypedColumnValue<Decimal>("IncomeDevPerc");
			}
			set {
				SetColumnValue("IncomeDevPerc", value);
			}
		}

		/// <summary>
		/// План. сметн. стоимость.
		/// </summary>
		public Decimal PlanExternalCost {
			get {
				return GetTypedColumnValue<Decimal>("PlanExternalCost");
			}
			set {
				SetColumnValue("PlanExternalCost", value);
			}
		}

		/// <summary>
		/// Факт. сметн. стоимость.
		/// </summary>
		public Decimal FactExternalCost {
			get {
				return GetTypedColumnValue<Decimal>("FactExternalCost");
			}
			set {
				SetColumnValue("FactExternalCost", value);
			}
		}

		/// <summary>
		/// Отклонение сметн. стоимости.
		/// </summary>
		public Decimal ExternalCostDev {
			get {
				return GetTypedColumnValue<Decimal>("ExternalCostDev");
			}
			set {
				SetColumnValue("ExternalCostDev", value);
			}
		}

		/// <summary>
		/// Отклонение сметн. стоимости, %.
		/// </summary>
		public Decimal PlanExternalDevPerc {
			get {
				return GetTypedColumnValue<Decimal>("PlanExternalDevPerc");
			}
			set {
				SetColumnValue("PlanExternalDevPerc", value);
			}
		}

		/// <summary>
		/// План. прямой расход.
		/// </summary>
		public Decimal PlanExpense {
			get {
				return GetTypedColumnValue<Decimal>("PlanExpense");
			}
			set {
				SetColumnValue("PlanExpense", value);
			}
		}

		/// <summary>
		/// Факт. прямой расход.
		/// </summary>
		public Decimal FactExpense {
			get {
				return GetTypedColumnValue<Decimal>("FactExpense");
			}
			set {
				SetColumnValue("FactExpense", value);
			}
		}

		/// <summary>
		/// Отклонение прямых расходов.
		/// </summary>
		public Decimal ExpenseDev {
			get {
				return GetTypedColumnValue<Decimal>("ExpenseDev");
			}
			set {
				SetColumnValue("ExpenseDev", value);
			}
		}

		/// <summary>
		/// Отклонение прямых расходов, %.
		/// </summary>
		public Decimal ExpenseDevPerc {
			get {
				return GetTypedColumnValue<Decimal>("ExpenseDevPerc");
			}
			set {
				SetColumnValue("ExpenseDevPerc", value);
			}
		}

		/// <summary>
		/// План. себестоимость.
		/// </summary>
		public Decimal PlanInternalCost {
			get {
				return GetTypedColumnValue<Decimal>("PlanInternalCost");
			}
			set {
				SetColumnValue("PlanInternalCost", value);
			}
		}

		/// <summary>
		/// Факт. себестоимость.
		/// </summary>
		public Decimal FactInternalCost {
			get {
				return GetTypedColumnValue<Decimal>("FactInternalCost");
			}
			set {
				SetColumnValue("FactInternalCost", value);
			}
		}

		/// <summary>
		/// Отклонение себестоимости.
		/// </summary>
		public Decimal InternalCostDev {
			get {
				return GetTypedColumnValue<Decimal>("InternalCostDev");
			}
			set {
				SetColumnValue("InternalCostDev", value);
			}
		}

		/// <summary>
		/// Отклонение себестоимости, %.
		/// </summary>
		public Decimal PlanInternalDevPerc {
			get {
				return GetTypedColumnValue<Decimal>("PlanInternalDevPerc");
			}
			set {
				SetColumnValue("PlanInternalDevPerc", value);
			}
		}

		/// <summary>
		/// План. маржа.
		/// </summary>
		public Decimal PlanMargin {
			get {
				return GetTypedColumnValue<Decimal>("PlanMargin");
			}
			set {
				SetColumnValue("PlanMargin", value);
			}
		}

		/// <summary>
		/// План. маржа, %.
		/// </summary>
		public Decimal PlanMarginPerc {
			get {
				return GetTypedColumnValue<Decimal>("PlanMarginPerc");
			}
			set {
				SetColumnValue("PlanMarginPerc", value);
			}
		}

		/// <summary>
		/// Факт. маржа.
		/// </summary>
		public Decimal FactMargin {
			get {
				return GetTypedColumnValue<Decimal>("FactMargin");
			}
			set {
				SetColumnValue("FactMargin", value);
			}
		}

		/// <summary>
		/// Факт маржа, %.
		/// </summary>
		public Decimal FactMarginPerc {
			get {
				return GetTypedColumnValue<Decimal>("FactMarginPerc");
			}
			set {
				SetColumnValue("FactMarginPerc", value);
			}
		}

		/// <summary>
		/// Отклонение маржи.
		/// </summary>
		public Decimal MarginDev {
			get {
				return GetTypedColumnValue<Decimal>("MarginDev");
			}
			set {
				SetColumnValue("MarginDev", value);
			}
		}

		/// <summary>
		/// Отклонение маржи, %.
		/// </summary>
		public Decimal MarginDevPerc {
			get {
				return GetTypedColumnValue<Decimal>("MarginDevPerc");
			}
			set {
				SetColumnValue("MarginDevPerc", value);
			}
		}

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Project_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Project_Project_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Project_Project_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Project_Project_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Project_Project_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Project_Project_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Project_Project_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Project_ProjectEventsProcess

	/// <exclude/>
	public partial class Project_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityNotes_BaseEventsProcess<TEntity> where TEntity : Project_Project_BPMSoft
	{

		public Project_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Project_ProjectEventsProcess";
			SchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a11d7fa4-9946-494c-ae41-2169844d29be");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private bool _isNeedLog = false;
		public bool IsNeedLog {
			get {
				return _isNeedLog;
			}
			set {
				_isNeedLog = value;
			}
		}

		private bool _needUpdatePosition = true;
		public bool NeedUpdatePosition {
			get {
				return _needUpdatePosition;
			}
			set {
				_needUpdatePosition = value;
			}
		}

		public virtual bool ContactChanged {
			get;
			set;
		}

		public virtual bool AccountChanged {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("cb8cef88-5377-4da2-be1d-161d09fc70d2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _projectSaved;
		public ProcessFlowElement ProjectSaved {
			get {
				return _projectSaved ?? (_projectSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProjectSaved",
					SchemaElementUId = new Guid("797b2a67-63b9-49db-bae0-b31132b13252"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _projectSavedScriptTask;
		public ProcessScriptTask ProjectSavedScriptTask {
			get {
				return _projectSavedScriptTask ?? (_projectSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ProjectSavedScriptTask",
					SchemaElementUId = new Guid("b4a11403-587f-4b26-ac2f-09d15c19975e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ProjectSavedScriptTaskExecute,
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
					SchemaElementUId = new Guid("5fac7060-a713-4b35-bc4f-aeb64f926aef"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _projectSaving;
		public ProcessFlowElement ProjectSaving {
			get {
				return _projectSaving ?? (_projectSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ProjectSaving",
					SchemaElementUId = new Guid("44b055ea-2c68-4566-b722-cc86020d40d8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _projectSavingScriptTask;
		public ProcessScriptTask ProjectSavingScriptTask {
			get {
				return _projectSavingScriptTask ?? (_projectSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ProjectSavingScriptTask",
					SchemaElementUId = new Guid("3c3e0d00-9ceb-4027-88f1-e509b2cce5a9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ProjectSavingScriptTaskExecute,
				});
			}
		}

		private LocalizableString _parentArgumentException;
		public LocalizableString ParentArgumentException {
			get {
				return _parentArgumentException ?? (_parentArgumentException = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.ParentArgumentException.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[ProjectSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectSaved };
			FlowElements[ProjectSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectSavedScriptTask };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ProjectSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectSaving };
			FlowElements[ProjectSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ProjectSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess2":
						break;
					case "ProjectSaved":
						e.Context.QueueTasks.Enqueue("ProjectSavedScriptTask");
						break;
					case "ProjectSavedScriptTask":
						break;
					case "EventSubProcess1":
						break;
					case "ProjectSaving":
						e.Context.QueueTasks.Enqueue("ProjectSavingScriptTask");
						break;
					case "ProjectSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ProjectSaved");
			ActivatedEventElements.Add("ProjectSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ProjectSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectSaved";
					result = ProjectSaved.Execute(context);
					break;
				case "ProjectSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectSavedScriptTask";
					result = ProjectSavedScriptTask.Execute(context, ProjectSavedScriptTaskExecute);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ProjectSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectSaving";
					result = ProjectSaving.Execute(context);
					break;
				case "ProjectSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ProjectSavingScriptTask";
					result = ProjectSavingScriptTask.Execute(context, ProjectSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ProjectSavedScriptTaskExecute(ProcessExecutingContext context) {
			if (ContactChanged || AccountChanged) {
				UpdateChildren(Entity.GetTypedColumnValue<Guid>("Id"), Entity.GetColumnValue("ContactId"), Entity.GetColumnValue("AccountId"));
			}
			return true;
		}

		public virtual bool ProjectSavingScriptTaskExecute(ProcessExecutingContext context) {
			ContactChanged = false;
			AccountChanged = false;
			if (!CheckParent()) {
				throw new ArgumentException(ParentArgumentException);
			}
			if (NeedUpdatePosition) {
				UpdatePosition();
			}
			ContactChanged = GetChanged("Guid","ContactId");
			AccountChanged = GetChanged("Guid","AccountId");
			if (Entity.SupplierId == Guid.Empty) {
				EntitySchemaColumn supplier = Entity.Schema.Columns.FindByName("Supplier");
				supplier.DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.None,
					ValueSource = @""
				};
				Entity.SetColumnValue("SupplierId", null);
			}
			return true; 
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Project_Project_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ProjectSaved")) {
							context.QueueTasks.Enqueue("ProjectSaved");
						}
						break;
					case "Project_Project_BPMSoftSaving":
							if (ActivatedEventElements.Contains("ProjectSaving")) {
							context.QueueTasks.Enqueue("ProjectSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Project_ProjectEventsProcess

	/// <exclude/>
	public class Project_ProjectEventsProcess : Project_ProjectEventsProcess<Project_Project_BPMSoft>
	{

		public Project_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Project_ProjectEventsProcess

	public partial class Project_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool GetChanged(string typeName, string columnName) {
			var value = Entity.GetColumnValue(columnName);
			var oldValue = Entity.GetColumnOldValue(columnName);
			if (value == null && oldValue == null) {
				return false;
			}
			if (value == null || oldValue == null) {
				return true;
			} 
			if ((typeName == "decimal" && (decimal)value != (decimal)oldValue) ||
				(typeName == "DateTime" && (DateTime)value != (DateTime)oldValue) ||
				(typeName == "Guid" && (Guid)value != (Guid)oldValue)) {
				return true;
			}
			return false;
		}

		public virtual void UpdatePosition() {
			var OldParentProjectId = Entity.GetTypedOldColumnValue<Guid>("ParentProjectId");
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentProjectId");
			if (Entity.StoringState != StoringObjectState.New && parentId == Guid.Empty) {
				return;
			}
			int currentPosition = Entity.GetTypedColumnValue<int>("Position");
			if ((Entity.StoringState != StoringObjectState.New) || 
				(Entity.StoringState == StoringObjectState.New && currentPosition != default(int))) {
				return;
			}
			Select selectCount = new Select(UserConnection).
				Column(Func.Count("Id")).
				From("Project").
				Where("ParentProjectId").IsEqual(Column.Parameter(parentId)) as Select;
			int position = 0;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = selectCount.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						position = UserConnection.DBTypeConverter.DBValueToInt(reader[0]);
					}
				}
			}
			Entity.SetColumnValue("Position",position);
		}

		public virtual bool CheckParent() {
			var projectId = Entity.GetTypedColumnValue<Guid>(Entity.Schema.GetPrimaryColumnName());
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentProjectId");
			if (projectId != parentId) {
				List<Guid> childProjectsIds = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId,UserConnection);
				if (!childProjectsIds.Contains(parentId)) {
					return true;
				}
			}
			return false;
		}

		public virtual void UpdateChildren(Guid projectId, object newContactId, object newAccountId) {
			if (projectId != Guid.Empty) {
				var childProjectsIds = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId,UserConnection).Select(x => new QueryParameter(x));
				(new Update(UserConnection, "Project")
								.Set("ContactId", Column.Parameter(newContactId, "Guid"))
								.Set("AccountId", Column.Parameter(newAccountId, "Guid"))
								.Where("Id")
									.In(childProjectsIds) as Update).Execute();
			}
		}

		#endregion

	}

	#endregion

}

