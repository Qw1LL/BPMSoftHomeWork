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

	#region Class: BaseCaseSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseCaseSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseCaseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseCaseSchema(BaseCaseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseCaseSchema(BaseCaseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_SolutionOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9ad0ba05-3b32-4561-8bfc-870aee9c951c");
			index.Name = "IX_SolutionOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn solutionProvidedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("4f3631c8-b14e-4591-a25a-b9207401cfa2"),
				ColumnUId = new Guid("81552f0a-fd92-4865-9533-f4c3ab2861a7"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionProvidedOnIndexColumn);
			EntitySchemaIndexColumn solutionDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5de35510-255d-4f3f-8119-9a3f9b8082f5"),
				ColumnUId = new Guid("624839d1-3bd0-45e0-95d1-28326703f19c"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionDateIndexColumn);
			EntitySchemaIndexColumn solutionOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8dab4368-f988-43de-a48e-bbf238fc3237"),
				ColumnUId = new Guid("0fa66efc-d2d0-47b9-abab-9e3ad2ea82d3"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(solutionOverdueIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_ResponseOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8d002ad1-0715-4bdc-aa5e-8be1a5e39381");
			index.Name = "IX_ResponseOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn respondedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("14abc9af-1b98-4ee2-b236-3a9576b1770f"),
				ColumnUId = new Guid("02612dc8-7243-4acb-b0bd-abbd19e24136"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(respondedOnIndexColumn);
			EntitySchemaIndexColumn responseDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c3226bd5-beb9-48ea-9383-30fb120d4f4d"),
				ColumnUId = new Guid("25280121-c075-441f-b4f8-feeb6cc7ca38"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(responseDateIndexColumn);
			EntitySchemaIndexColumn responseOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a4aaaa1e-d84e-48a2-84ac-04c35a6fad1e"),
				ColumnUId = new Guid("1ed4e080-0bf8-4f4f-97e8-b3e22f3240a0"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(responseOverdueIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			RealUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			Name = "BaseCase";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c91a9a6f-008d-4b2e-83d5-03868ad68c99")) == null) {
				Columns.Add(CreateRegisteredOnColumn());
			}
			if (Columns.FindByUId(new Guid("ffe8526d-044f-4222-a1ef-fca83a0772d8")) == null) {
				Columns.Add(CreateSubjectColumn());
			}
			if (Columns.FindByUId(new Guid("6f9b3e63-5998-4c16-b1b0-cd712516ad18")) == null) {
				Columns.Add(CreateSymptomsColumn());
			}
			if (Columns.FindByUId(new Guid("70620d00-e4ea-48d1-9fdc-4572fcd8d41b")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("25280121-c075-441f-b4f8-feeb6cc7ca38")) == null) {
				Columns.Add(CreateResponseDateColumn());
			}
			if (Columns.FindByUId(new Guid("624839d1-3bd0-45e0-95d1-28326703f19c")) == null) {
				Columns.Add(CreateSolutionDateColumn());
			}
			if (Columns.FindByUId(new Guid("a71adaea-3464-4dee-bb4f-c7a535450ad7")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("4bc0db67-0abe-4fbd-a70a-54d0bee0c42d")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("6a2e8ee8-f1cb-45ad-a731-6b082109d507")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("a93cb111-ce30-4da4-89ec-d2a2f3dd71c4")) == null) {
				Columns.Add(CreateOriginColumn());
			}
			if (Columns.FindByUId(new Guid("b15302c9-b5c4-4d94-afd5-3d409f9adfe1")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("6396f46e-c49f-4fb1-850d-824869ff04b3")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("9147230c-ab53-4eb4-b0b4-ac78be6f8326")) == null) {
				Columns.Add(CreateGroupColumn());
			}
			if (Columns.FindByUId(new Guid("02612dc8-7243-4acb-b0bd-abbd19e24136")) == null) {
				Columns.Add(CreateRespondedOnColumn());
			}
			if (Columns.FindByUId(new Guid("c0b67cd6-c592-4f3e-9efe-12e783c4d396")) == null) {
				Columns.Add(CreateFirstSolutionProvidedOnColumn());
			}
			if (Columns.FindByUId(new Guid("81552f0a-fd92-4865-9533-f4c3ab2861a7")) == null) {
				Columns.Add(CreateSolutionProvidedOnColumn());
			}
			if (Columns.FindByUId(new Guid("e12191ff-2811-430d-aeca-7a4435e4b1b9")) == null) {
				Columns.Add(CreateClosureDateColumn());
			}
			if (Columns.FindByUId(new Guid("d2fb7a30-8a2e-462b-963a-b88ff1f52f0e")) == null) {
				Columns.Add(CreateClosureCodeColumn());
			}
			if (Columns.FindByUId(new Guid("aafda194-dbd6-4337-923a-b19a456eeea9")) == null) {
				Columns.Add(CreateSolutionColumn());
			}
			if (Columns.FindByUId(new Guid("ccfc5fbf-4dc9-47e4-91f3-54ea9251ab18")) == null) {
				Columns.Add(CreateSatisfactionLevelColumn());
			}
			if (Columns.FindByUId(new Guid("af280321-e749-41dd-98e5-383906747e29")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("1ed4e080-0bf8-4f4f-97e8-b3e22f3240a0")) == null) {
				Columns.Add(CreateResponseOverdueColumn());
			}
			if (Columns.FindByUId(new Guid("0fa66efc-d2d0-47b9-abab-9e3ad2ea82d3")) == null) {
				Columns.Add(CreateSolutionOverdueColumn());
			}
			if (Columns.FindByUId(new Guid("e66437f6-089c-4f5c-b4ba-d1f8c71506d0")) == null) {
				Columns.Add(CreateSatisfactionLevelCommentColumn());
			}
			if (Columns.FindByUId(new Guid("fce13454-f217-4c5e-af89-35e4d8ebdda3")) == null) {
				Columns.Add(CreateSolutionRemainsColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7b8ce6b4-29ca-40c7-bea1-b5bf7b7c404a"),
				Name = @"Number",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateRegisteredOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c91a9a6f-008d-4b2e-83d5-03868ad68c99"),
				Name = @"RegisteredOn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ffe8526d-044f-4222-a1ef-fca83a0772d8"),
				Name = @"Subject",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateSymptomsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6f9b3e63-5998-4c16-b1b0-cd712516ad18"),
				Name = @"Symptoms",
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("70620d00-e4ea-48d1-9fdc-4572fcd8d41b"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateResponseDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("25280121-c075-441f-b4f8-feeb6cc7ca38"),
				Name = @"ResponseDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("624839d1-3bd0-45e0-95d1-28326703f19c"),
				Name = @"SolutionDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a71adaea-3464-4dee-bb4f-c7a535450ad7"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"CaseStatusDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4bc0db67-0abe-4fbd-a70a-54d0bee0c42d"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6a2e8ee8-f1cb-45ad-a731-6b082109d507"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("e662865c-728f-40db-b3dd-15dcf46d47df"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"CasePriorityDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOriginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a93cb111-ce30-4da4-89ec-d2a2f3dd71c4"),
				Name = @"Origin",
				ReferenceSchemaUId = new Guid("b17869fe-43f9-487a-af82-b7626f1fc810"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"CaseOriginDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b15302c9-b5c4-4d94-afd5-3d409f9adfe1"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6396f46e-c49f-4fb1-850d-824869ff04b3"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9147230c-ab53-4eb4-b0b4-ac78be6f8326"),
				Name = @"Group",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateRespondedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("02612dc8-7243-4acb-b0bd-abbd19e24136"),
				Name = @"RespondedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateFirstSolutionProvidedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c0b67cd6-c592-4f3e-9efe-12e783c4d396"),
				Name = @"FirstSolutionProvidedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("30de0e3b-0a22-4b21-aec2-eb5dee3a342f")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionProvidedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("81552f0a-fd92-4865-9533-f4c3ab2861a7"),
				Name = @"SolutionProvidedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateClosureDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("e12191ff-2811-430d-aeca-7a4435e4b1b9"),
				Name = @"ClosureDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateClosureCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d2fb7a30-8a2e-462b-963a-b88ff1f52f0e"),
				Name = @"ClosureCode",
				ReferenceSchemaUId = new Guid("66827e0a-27d4-4616-b69a-ac6321b7be52"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("aafda194-dbd6-4337-923a-b19a456eeea9"),
				Name = @"Solution",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateSatisfactionLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ccfc5fbf-4dc9-47e4-91f3-54ea9251ab18"),
				Name = @"SatisfactionLevel",
				ReferenceSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("af280321-e749-41dd-98e5-383906747e29"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("63fec14d-0309-43b0-99c5-b085abf0c314"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateResponseOverdueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1ed4e080-0bf8-4f4f-97e8-b3e22f3240a0"),
				Name = @"ResponseOverdue",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("a2fc2e06-4c85-4afa-ac7e-48c4edb4a538")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionOverdueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0fa66efc-d2d0-47b9-abab-9e3ad2ea82d3"),
				Name = @"SolutionOverdue",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("a2fc2e06-4c85-4afa-ac7e-48c4edb4a538")
			};
		}

		protected virtual EntitySchemaColumn CreateSatisfactionLevelCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e66437f6-089c-4f5c-b4ba-d1f8c71506d0"),
				Name = @"SatisfactionLevelComment",
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("f8c6eb84-3d71-4afb-ace7-681ff694a7b0"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionRemainsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("fce13454-f217-4c5e-af89-35e4d8ebdda3"),
				Name = @"SolutionRemains",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("d7034329-b0c9-4f8a-ab80-129b052eadf0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_SolutionOverdue_AttributesIndex());
			Indexes.Add(CreateIX_ResponseOverdue_AttributesIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseCase(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseCase_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseCaseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseCaseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseCase

	/// <summary>
	/// Базовое обращение.
	/// </summary>
	public class BaseCase : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseCase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseCase";
		}

		public BaseCase(BaseCase source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Дата регистрации.
		/// </summary>
		public DateTime RegisteredOn {
			get {
				return GetTypedColumnValue<DateTime>("RegisteredOn");
			}
			set {
				SetColumnValue("RegisteredOn", value);
			}
		}

		/// <summary>
		/// Тема.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Symptoms {
			get {
				return GetTypedColumnValue<string>("Symptoms");
			}
			set {
				SetColumnValue("Symptoms", value);
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
		/// Время реакции.
		/// </summary>
		public DateTime ResponseDate {
			get {
				return GetTypedColumnValue<DateTime>("ResponseDate");
			}
			set {
				SetColumnValue("ResponseDate", value);
			}
		}

		/// <summary>
		/// Время разрешения.
		/// </summary>
		public DateTime SolutionDate {
			get {
				return GetTypedColumnValue<DateTime>("SolutionDate");
			}
			set {
				SetColumnValue("SolutionDate", value);
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

		private CaseStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CaseStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as CaseStatus);
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

		private CasePriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public CasePriority Priority {
			get {
				return _priority ??
					(_priority = LookupColumnEntities.GetEntity("Priority") as CasePriority);
			}
		}

		/// <exclude/>
		public Guid OriginId {
			get {
				return GetTypedColumnValue<Guid>("OriginId");
			}
			set {
				SetColumnValue("OriginId", value);
				_origin = null;
			}
		}

		/// <exclude/>
		public string OriginName {
			get {
				return GetTypedColumnValue<string>("OriginName");
			}
			set {
				SetColumnValue("OriginName", value);
				if (_origin != null) {
					_origin.Name = value;
				}
			}
		}

		private CaseOrigin _origin;
		/// <summary>
		/// Происхождение.
		/// </summary>
		public CaseOrigin Origin {
			get {
				return _origin ??
					(_origin = LookupColumnEntities.GetEntity("Origin") as CaseOrigin);
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
		public Guid GroupId {
			get {
				return GetTypedColumnValue<Guid>("GroupId");
			}
			set {
				SetColumnValue("GroupId", value);
				_group = null;
			}
		}

		/// <exclude/>
		public string GroupName {
			get {
				return GetTypedColumnValue<string>("GroupName");
			}
			set {
				SetColumnValue("GroupName", value);
				if (_group != null) {
					_group.Name = value;
				}
			}
		}

		private SysAdminUnit _group;
		/// <summary>
		/// Группа ответственных.
		/// </summary>
		public SysAdminUnit Group {
			get {
				return _group ??
					(_group = LookupColumnEntities.GetEntity("Group") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Фактическая реакция.
		/// </summary>
		public DateTime RespondedOn {
			get {
				return GetTypedColumnValue<DateTime>("RespondedOn");
			}
			set {
				SetColumnValue("RespondedOn", value);
			}
		}

		/// <summary>
		/// Первое решение.
		/// </summary>
		public DateTime FirstSolutionProvidedOn {
			get {
				return GetTypedColumnValue<DateTime>("FirstSolutionProvidedOn");
			}
			set {
				SetColumnValue("FirstSolutionProvidedOn", value);
			}
		}

		/// <summary>
		/// Фактическое разрешение.
		/// </summary>
		public DateTime SolutionProvidedOn {
			get {
				return GetTypedColumnValue<DateTime>("SolutionProvidedOn");
			}
			set {
				SetColumnValue("SolutionProvidedOn", value);
			}
		}

		/// <summary>
		/// Дата закрытия.
		/// </summary>
		public DateTime ClosureDate {
			get {
				return GetTypedColumnValue<DateTime>("ClosureDate");
			}
			set {
				SetColumnValue("ClosureDate", value);
			}
		}

		/// <exclude/>
		public Guid ClosureCodeId {
			get {
				return GetTypedColumnValue<Guid>("ClosureCodeId");
			}
			set {
				SetColumnValue("ClosureCodeId", value);
				_closureCode = null;
			}
		}

		/// <exclude/>
		public string ClosureCodeName {
			get {
				return GetTypedColumnValue<string>("ClosureCodeName");
			}
			set {
				SetColumnValue("ClosureCodeName", value);
				if (_closureCode != null) {
					_closureCode.Name = value;
				}
			}
		}

		private ClosureCode _closureCode;
		/// <summary>
		/// Причина закрытия.
		/// </summary>
		public ClosureCode ClosureCode {
			get {
				return _closureCode ??
					(_closureCode = LookupColumnEntities.GetEntity("ClosureCode") as ClosureCode);
			}
		}

		/// <summary>
		/// Решение.
		/// </summary>
		public string Solution {
			get {
				return GetTypedColumnValue<string>("Solution");
			}
			set {
				SetColumnValue("Solution", value);
			}
		}

		/// <exclude/>
		public Guid SatisfactionLevelId {
			get {
				return GetTypedColumnValue<Guid>("SatisfactionLevelId");
			}
			set {
				SetColumnValue("SatisfactionLevelId", value);
				_satisfactionLevel = null;
			}
		}

		/// <exclude/>
		public string SatisfactionLevelName {
			get {
				return GetTypedColumnValue<string>("SatisfactionLevelName");
			}
			set {
				SetColumnValue("SatisfactionLevelName", value);
				if (_satisfactionLevel != null) {
					_satisfactionLevel.Name = value;
				}
			}
		}

		private SatisfactionLevel _satisfactionLevel;
		/// <summary>
		/// Уровень удовлетворенности.
		/// </summary>
		public SatisfactionLevel SatisfactionLevel {
			get {
				return _satisfactionLevel ??
					(_satisfactionLevel = LookupColumnEntities.GetEntity("SatisfactionLevel") as SatisfactionLevel);
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

		private CaseCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public CaseCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as CaseCategory);
			}
		}

		/// <summary>
		/// Просрочен по реакции.
		/// </summary>
		public bool ResponseOverdue {
			get {
				return GetTypedColumnValue<bool>("ResponseOverdue");
			}
			set {
				SetColumnValue("ResponseOverdue", value);
			}
		}

		/// <summary>
		/// Просрочен по разрешению.
		/// </summary>
		public bool SolutionOverdue {
			get {
				return GetTypedColumnValue<bool>("SolutionOverdue");
			}
			set {
				SetColumnValue("SolutionOverdue", value);
			}
		}

		/// <summary>
		/// Комментарий к оценке.
		/// </summary>
		public string SatisfactionLevelComment {
			get {
				return GetTypedColumnValue<string>("SatisfactionLevelComment");
			}
			set {
				SetColumnValue("SatisfactionLevelComment", value);
			}
		}

		/// <summary>
		/// Осталось по разрешению.
		/// </summary>
		public Decimal SolutionRemains {
			get {
				return GetTypedColumnValue<Decimal>("SolutionRemains");
			}
			set {
				SetColumnValue("SolutionRemains", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseCase_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseCaseDeleted", e);
			Inserting += (s, e) => ThrowEvent("BaseCaseInserting", e);
			Validating += (s, e) => ThrowEvent("BaseCaseValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseCase(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseCase_CaseEventsProcess

	/// <exclude/>
	public partial class BaseCase_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseCase
	{

		public BaseCase_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseCase_CaseEventsProcess";
			SchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
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

	#region Class: BaseCase_CaseEventsProcess

	/// <exclude/>
	public class BaseCase_CaseEventsProcess : BaseCase_CaseEventsProcess<BaseCase>
	{

		public BaseCase_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseCase_CaseEventsProcess

	public partial class BaseCase_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseCaseEventsProcess

	/// <exclude/>
	public class BaseCaseEventsProcess : BaseCase_CaseEventsProcess
	{

		public BaseCaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

