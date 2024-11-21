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

	#region Class: SysModuleSchema

	/// <exclude/>
	public class SysModuleSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleSchema(SysModuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleSchema(SysModuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5");
			RealUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5");
			Name = "SysModule";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImage32Column();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3f098e0d-6cbd-4e8f-bc3e-00709f2d8d82")) == null) {
				Columns.Add(CreateSysModuleEntityColumn());
			}
			if (Columns.FindByUId(new Guid("6d827ba7-a622-47cc-8f11-b40b91c7441a")) == null) {
				Columns.Add(CreateImage16Column());
			}
			if (Columns.FindByUId(new Guid("ed272316-b65f-41db-a9b4-e53ab939e4d6")) == null) {
				Columns.Add(CreateImage20Column());
			}
			if (Columns.FindByUId(new Guid("d3afc924-2d21-4c0e-b2f3-9f8c180221f9")) == null) {
				Columns.Add(CreateFolderModeColumn());
			}
			if (Columns.FindByUId(new Guid("eea74681-e019-4885-9a1e-e8261f2665ea")) == null) {
				Columns.Add(CreateGlobalSearchAvailableColumn());
			}
			if (Columns.FindByUId(new Guid("34dfc288-1b25-4d53-bdf3-16b58a84e276")) == null) {
				Columns.Add(CreateHasAnalyticsColumn());
			}
			if (Columns.FindByUId(new Guid("a0fd39b2-b680-4515-ac3c-72322db4f1b8")) == null) {
				Columns.Add(CreateHasActionsColumn());
			}
			if (Columns.FindByUId(new Guid("80769c54-f4f4-43cb-93f8-0824715969a6")) == null) {
				Columns.Add(CreateHasRecentColumn());
			}
			if (Columns.FindByUId(new Guid("e0c474a3-e4bc-457e-bb67-c1ec1b399f60")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("9a366fd1-19c8-4ba7-9bdd-039f164c08ec")) == null) {
				Columns.Add(CreateHelpContextIdColumn());
			}
			if (Columns.FindByUId(new Guid("7b904e78-84bf-408c-a7a1-1287e66837d3")) == null) {
				Columns.Add(CreateModuleHeaderColumn());
			}
			if (Columns.FindByUId(new Guid("bd3cf32d-f9b5-471b-a0ca-f541296b979d")) == null) {
				Columns.Add(CreateAttributeColumn());
			}
			if (Columns.FindByUId(new Guid("b3fefb7f-2aab-4b16-97aa-6ca3f3bd7ac2")) == null) {
				Columns.Add(CreateSysPageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("327a0dc4-df63-4f6e-9d33-bc403d284cb6")) == null) {
				Columns.Add(CreateCardSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("d57c3c34-e293-4aed-bff6-91dc90408958")) == null) {
				Columns.Add(CreateSectionModuleSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("af5bbb5e-9c78-44b7-8fdd-2bfc4353b4a8")) == null) {
				Columns.Add(CreateSectionSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("cb4bb1d2-d369-406e-8150-502dd7af2199")) == null) {
				Columns.Add(CreateCardModuleUIdColumn());
			}
			if (Columns.FindByUId(new Guid("f3a29fb6-f13d-443e-8360-d4f51e8bcec8")) == null) {
				Columns.Add(CreateTypeColumnValueColumn());
			}
			if (Columns.FindByUId(new Guid("380d55b9-487c-429b-9aff-e04101ffc307")) == null) {
				Columns.Add(CreateLogoColumn());
			}
			if (Columns.FindByUId(new Guid("e6243d2b-cc8f-4b2d-8646-36bac9fb48e9")) == null) {
				Columns.Add(CreateSysModuleVisaColumn());
			}
			if (Columns.FindByUId(new Guid("dedaabd6-732d-47ac-b229-50a8ee02292c")) == null) {
				Columns.Add(CreateIsSystemColumn());
			}
			if (Columns.FindByUId(new Guid("1e4741cc-9a6e-446f-9865-5f5910fadd67")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3da3c3b2-02fb-4cca-80c3-7946d4e8f565"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3f098e0d-6cbd-4e8f-bc3e-00709f2d8d82"),
				Name = @"SysModuleEntity",
				ReferenceSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateImage16Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("6d827ba7-a622-47cc-8f11-b40b91c7441a"),
				Name = @"Image16",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateImage20Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("ed272316-b65f-41db-a9b4-e53ab939e4d6"),
				Name = @"Image20",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFolderModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d3afc924-2d21-4c0e-b2f3-9f8c180221f9"),
				Name = @"FolderMode",
				ReferenceSchemaUId = new Guid("02a6ed88-f913-47b6-bf0a-80646634f47b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateGlobalSearchAvailableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("eea74681-e019-4885-9a1e-e8261f2665ea"),
				Name = @"GlobalSearchAvailable",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHasAnalyticsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("34dfc288-1b25-4d53-bdf3-16b58a84e276"),
				Name = @"HasAnalytics",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHasActionsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a0fd39b2-b680-4515-ac3c-72322db4f1b8"),
				Name = @"HasActions",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHasRecentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("80769c54-f4f4-43cb-93f8-0824715969a6"),
				Name = @"HasRecent",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e0c474a3-e4bc-457e-bb67-c1ec1b399f60"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpContextIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9a366fd1-19c8-4ba7-9bdd-039f164c08ec"),
				Name = @"HelpContextId",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateModuleHeaderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7b904e78-84bf-408c-a7a1-1287e66837d3"),
				Name = @"ModuleHeader",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateAttributeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("bd3cf32d-f9b5-471b-a0ca-f541296b979d"),
				Name = @"Attribute",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b3fefb7f-2aab-4b16-97aa-6ca3f3bd7ac2"),
				Name = @"SysPageSchemaUId",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCardSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("327a0dc4-df63-4f6e-9d33-bc403d284cb6"),
				Name = @"CardSchemaUId",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateSectionModuleSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d57c3c34-e293-4aed-bff6-91dc90408958"),
				Name = @"SectionModuleSchemaUId",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateSectionSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("af5bbb5e-9c78-44b7-8fdd-2bfc4353b4a8"),
				Name = @"SectionSchemaUId",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768")
			};
		}

		protected virtual EntitySchemaColumn CreateCardModuleUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cb4bb1d2-d369-406e-8150-502dd7af2199"),
				Name = @"CardModuleUId",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("53c384bc-84c9-40fb-bbfe-0f8b5f1bc768"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"4E1670DC-10DB-4217-929A-669F906E5D75"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f3a29fb6-f13d-443e-8360-d4f51e8bcec8"),
				Name = @"TypeColumnValue",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("02c41552-6138-41c7-b1d8-208f324fe99a")
			};
		}

		protected virtual EntitySchemaColumn CreateImage32Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("63f1eb37-455a-4a53-ace2-fa5ef4c3d10f"),
				Name = @"Image32",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("9a95a9a3-7baf-4869-baaa-b8cd58de998d")
			};
		}

		protected virtual EntitySchemaColumn CreateLogoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("380d55b9-487c-429b-9aff-e04101ffc307"),
				Name = @"Logo",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("52a014a4-b7b7-428e-a58c-f451a377ae35")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleVisaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e6243d2b-cc8f-4b2d-8646-36bac9fb48e9"),
				Name = @"SysModuleVisa",
				ReferenceSchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsSystemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("dedaabd6-732d-47ac-b229-50a8ee02292c"),
				Name = @"IsSystem",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("ba31bbcd-215e-4a69-ac9a-e1a800c4560f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1e4741cc-9a6e-446f-9865-5f5910fadd67"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				ModifiedInSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				CreatedInPackageId = new Guid("22b2bd9d-6266-4a41-abb5-5814c95ed04d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModule_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModule

	/// <summary>
	/// Section.
	/// </summary>
	public class SysModule : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModule";
		}

		public SysModule(SysModule source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
				_sysModuleEntity = null;
			}
		}

		private SysModuleEntity _sysModuleEntity;
		/// <summary>
		/// Section object.
		/// </summary>
		public SysModuleEntity SysModuleEntity {
			get {
				return _sysModuleEntity ??
					(_sysModuleEntity = LookupColumnEntities.GetEntity("SysModuleEntity") as SysModuleEntity);
			}
		}

		/// <exclude/>
		public Guid FolderModeId {
			get {
				return GetTypedColumnValue<Guid>("FolderModeId");
			}
			set {
				SetColumnValue("FolderModeId", value);
				_folderMode = null;
			}
		}

		/// <exclude/>
		public string FolderModeName {
			get {
				return GetTypedColumnValue<string>("FolderModeName");
			}
			set {
				SetColumnValue("FolderModeName", value);
				if (_folderMode != null) {
					_folderMode.Name = value;
				}
			}
		}

		private SysModuleFolderMode _folderMode;
		/// <summary>
		/// Section folders mode.
		/// </summary>
		public SysModuleFolderMode FolderMode {
			get {
				return _folderMode ??
					(_folderMode = LookupColumnEntities.GetEntity("FolderMode") as SysModuleFolderMode);
			}
		}

		/// <summary>
		/// Include in search.
		/// </summary>
		public bool GlobalSearchAvailable {
			get {
				return GetTypedColumnValue<bool>("GlobalSearchAvailable");
			}
			set {
				SetColumnValue("GlobalSearchAvailable", value);
			}
		}

		/// <summary>
		/// Includes reports and charts.
		/// </summary>
		public bool HasAnalytics {
			get {
				return GetTypedColumnValue<bool>("HasAnalytics");
			}
			set {
				SetColumnValue("HasAnalytics", value);
			}
		}

		/// <summary>
		/// Contains processes.
		/// </summary>
		public bool HasActions {
			get {
				return GetTypedColumnValue<bool>("HasActions");
			}
			set {
				SetColumnValue("HasActions", value);
			}
		}

		/// <summary>
		/// Contains &quot;Recent&quot; folder.
		/// </summary>
		public bool HasRecent {
			get {
				return GetTypedColumnValue<bool>("HasRecent");
			}
			set {
				SetColumnValue("HasRecent", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Contextual help Id.
		/// </summary>
		public string HelpContextId {
			get {
				return GetTypedColumnValue<string>("HelpContextId");
			}
			set {
				SetColumnValue("HelpContextId", value);
			}
		}

		/// <summary>
		/// Module caption.
		/// </summary>
		public string ModuleHeader {
			get {
				return GetTypedColumnValue<string>("ModuleHeader");
			}
			set {
				SetColumnValue("ModuleHeader", value);
			}
		}

		/// <summary>
		/// Attribute.
		/// </summary>
		public string Attribute {
			get {
				return GetTypedColumnValue<string>("Attribute");
			}
			set {
				SetColumnValue("Attribute", value);
			}
		}

		/// <summary>
		/// Unique identifier of section page.
		/// </summary>
		public Guid SysPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysPageSchemaUId");
			}
			set {
				SetColumnValue("SysPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of section edit page schema.
		/// </summary>
		public Guid CardSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("CardSchemaUId");
			}
			set {
				SetColumnValue("CardSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of section module schema.
		/// </summary>
		public Guid SectionModuleSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SectionModuleSchemaUId");
			}
			set {
				SetColumnValue("SectionModuleSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of section schema.
		/// </summary>
		public Guid SectionSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SectionSchemaUId");
			}
			set {
				SetColumnValue("SectionSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of edit page module schema.
		/// </summary>
		public Guid CardModuleUId {
			get {
				return GetTypedColumnValue<Guid>("CardModuleUId");
			}
			set {
				SetColumnValue("CardModuleUId", value);
			}
		}

		/// <summary>
		/// Type column value.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <exclude/>
		public Guid Image32Id {
			get {
				return GetTypedColumnValue<Guid>("Image32Id");
			}
			set {
				SetColumnValue("Image32Id", value);
				_image32 = null;
			}
		}

		/// <exclude/>
		public string Image32Name {
			get {
				return GetTypedColumnValue<string>("Image32Name");
			}
			set {
				SetColumnValue("Image32Name", value);
				if (_image32 != null) {
					_image32.Name = value;
				}
			}
		}

		private SysImage _image32;
		/// <summary>
		/// Image (32x32).
		/// </summary>
		public SysImage Image32 {
			get {
				return _image32 ??
					(_image32 = LookupColumnEntities.GetEntity("Image32") as SysImage);
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Logo.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = LookupColumnEntities.GetEntity("Logo") as SysImage);
			}
		}

		/// <exclude/>
		public Guid SysModuleVisaId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleVisaId");
			}
			set {
				SetColumnValue("SysModuleVisaId", value);
				_sysModuleVisa = null;
			}
		}

		private SysModuleVisa _sysModuleVisa;
		/// <summary>
		/// Approval settings.
		/// </summary>
		public SysModuleVisa SysModuleVisa {
			get {
				return _sysModuleVisa ??
					(_sysModuleVisa = LookupColumnEntities.GetEntity("SysModuleVisa") as SysModuleVisa);
			}
		}

		/// <summary>
		/// System section.
		/// </summary>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
			}
		}

		/// <summary>
		/// Section types.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModule_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModule(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModule_BaseEventsProcess

	/// <exclude/>
	public partial class SysModule_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModule
	{

		public SysModule_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModule_BaseEventsProcess";
			SchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5");
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

	#region Class: SysModule_BaseEventsProcess

	/// <exclude/>
	public class SysModule_BaseEventsProcess : SysModule_BaseEventsProcess<SysModule>
	{

		public SysModule_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModule_BaseEventsProcess

	public partial class SysModule_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleEventsProcess

	/// <exclude/>
	public class SysModuleEventsProcess : SysModule_BaseEventsProcess
	{

		public SysModuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

