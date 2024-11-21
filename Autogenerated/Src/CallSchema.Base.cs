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

	#region Class: Call_Base_BPMSoftSchema

	/// <exclude/>
	public class Call_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Call_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Call_Base_BPMSoftSchema(Call_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Call_Base_BPMSoftSchema(Call_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateICallCreatedOnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8f49136d-4605-4a5e-94bf-dec8cd6b8c60");
			index.Name = "ICallCreatedOn";
			index.CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fbd9727b-1533-41f4-b11a-e3e7a77a63e9"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			RealUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			Name = "Call_Base_BPMSoft";
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("08714579-5b41-4466-935d-7291ec9fee39")) == null) {
				Columns.Add(CreateIntegrationIdColumn());
			}
			if (Columns.FindByUId(new Guid("8691e153-4a7d-4ff8-9ef0-eae19ae4d6c0")) == null) {
				Columns.Add(CreateParentCallIdColumn());
			}
			if (Columns.FindByUId(new Guid("db19ab54-786c-489d-a81b-e31fcfea6fcc")) == null) {
				Columns.Add(CreateCallerIdColumn());
			}
			if (Columns.FindByUId(new Guid("c3265f75-0500-4b23-928c-6bc533a24877")) == null) {
				Columns.Add(CreateCalledIdColumn());
			}
			if (Columns.FindByUId(new Guid("e88b47ae-910f-4581-aac2-982f66b692f3")) == null) {
				Columns.Add(CreateRedirectingIdColumn());
			}
			if (Columns.FindByUId(new Guid("85645933-6fcf-4894-8258-bee0a3c55316")) == null) {
				Columns.Add(CreateRedirectionIdColumn());
			}
			if (Columns.FindByUId(new Guid("95704ae2-3e7a-464f-aefb-0edd8db5b507")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("148873dc-7962-43df-9baf-6cfb771b10f2")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("605170f5-cf92-4729-8f36-94fda24ecc6f")) == null) {
				Columns.Add(CreateDurationColumn());
			}
			if (Columns.FindByUId(new Guid("924973de-6177-440b-ad38-b1abc98aeb3c")) == null) {
				Columns.Add(CreateBeforeConnectionTimeColumn());
			}
			if (Columns.FindByUId(new Guid("0a7cdc13-0f0f-401b-9f8d-c480524900bb")) == null) {
				Columns.Add(CreateTalkTimeColumn());
			}
			if (Columns.FindByUId(new Guid("b697512e-550b-4aca-8bb8-58d9e14c9429")) == null) {
				Columns.Add(CreateHoldTimeColumn());
			}
			if (Columns.FindByUId(new Guid("c71efb6e-ad12-4e53-9b3f-a988ac3db07d")) == null) {
				Columns.Add(CreateDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("204847ca-4d30-4977-8472-28be138e4e1c")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("40abd693-f493-4880-b6bf-2f52380601a7")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("d7d5d5c0-c14f-4183-b490-b911b0b1489d")) == null) {
				Columns.Add(CreateResultColumn());
			}
			if (Columns.FindByUId(new Guid("f96643ed-b6b1-4128-b2c4-5ef193641a35")) == null) {
				Columns.Add(CreateCommentColumn());
			}
			if (Columns.FindByUId(new Guid("d9bc2a14-6304-4e40-8d56-26ab7734507a")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("e8c42eb9-570c-4b13-83c1-70cbacf5e5d4")) == null) {
				Columns.Add(CreateActivityColumn());
			}
			if (Columns.FindByUId(new Guid("cc850a9e-807c-4b98-8eed-e126d8d18ae2")) == null) {
				Columns.Add(CreateGloballyUniqueCallLinkageIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsIndexed = false;
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIntegrationIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("08714579-5b41-4466-935d-7291ec9fee39"),
				Name = @"IntegrationId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentCallIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8691e153-4a7d-4ff8-9ef0-eae19ae4d6c0"),
				Name = @"ParentCallId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCallerIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("db19ab54-786c-489d-a81b-e31fcfea6fcc"),
				Name = @"CallerId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCalledIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c3265f75-0500-4b23-928c-6bc533a24877"),
				Name = @"CalledId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRedirectingIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e88b47ae-910f-4581-aac2-982f66b692f3"),
				Name = @"RedirectingId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRedirectionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("85645933-6fcf-4894-8258-bee0a3c55316"),
				Name = @"RedirectionId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("95704ae2-3e7a-464f-aefb-0edd8db5b507"),
				Name = @"StartDate",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("148873dc-7962-43df-9baf-6cfb771b10f2"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("605170f5-cf92-4729-8f36-94fda24ecc6f"),
				Name = @"Duration",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBeforeConnectionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("924973de-6177-440b-ad38-b1abc98aeb3c"),
				Name = @"BeforeConnectionTime",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTalkTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0a7cdc13-0f0f-401b-9f8d-c480524900bb"),
				Name = @"TalkTime",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHoldTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b697512e-550b-4aca-8bb8-58d9e14c9429"),
				Name = @"HoldTime",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c71efb6e-ad12-4e53-9b3f-a988ac3db07d"),
				Name = @"Direction",
				ReferenceSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"c072be2c-3d82-4468-9d4a-6db47d1f4cca"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("08ff9e4a-715b-4bde-867d-06ec64002a81"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("204847ca-4d30-4977-8472-28be138e4e1c"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("40abd693-f493-4880-b6bf-2f52380601a7"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d7d5d5c0-c14f-4183-b490-b911b0b1489d"),
				Name = @"Result",
				ReferenceSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f96643ed-b6b1-4128-b2c4-5ef193641a35"),
				Name = @"Comment",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d9bc2a14-6304-4e40-8d56-26ab7734507a"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e8c42eb9-570c-4b13-83c1-70cbacf5e5d4"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02")
			};
		}

		protected virtual EntitySchemaColumn CreateGloballyUniqueCallLinkageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cc850a9e-807c-4b98-8eed-e126d8d18ae2"),
				Name = @"GloballyUniqueCallLinkageId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateICallCreatedOnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Call_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Call_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Call_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Call_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"));
		}

		#endregion

	}

	#endregion

	#region Class: Call_Base_BPMSoft

	/// <summary>
	/// Call.
	/// </summary>
	public class Call_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Call_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call_Base_BPMSoft";
		}

		public Call_Base_BPMSoft(Call_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Call Id.
		/// </summary>
		public string IntegrationId {
			get {
				return GetTypedColumnValue<string>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <summary>
		/// Source call Id.
		/// </summary>
		public string ParentCallId {
			get {
				return GetTypedColumnValue<string>("ParentCallId");
			}
			set {
				SetColumnValue("ParentCallId", value);
			}
		}

		/// <summary>
		/// From.
		/// </summary>
		public string CallerId {
			get {
				return GetTypedColumnValue<string>("CallerId");
			}
			set {
				SetColumnValue("CallerId", value);
			}
		}

		/// <summary>
		/// To.
		/// </summary>
		public string CalledId {
			get {
				return GetTypedColumnValue<string>("CalledId");
			}
			set {
				SetColumnValue("CalledId", value);
			}
		}

		/// <summary>
		/// Redirecting extension.
		/// </summary>
		/// <remarks>
		/// The subscriber extension, which transferred the call.
		/// </remarks>
		public string RedirectingId {
			get {
				return GetTypedColumnValue<string>("RedirectingId");
			}
			set {
				SetColumnValue("RedirectingId", value);
			}
		}

		/// <summary>
		/// Redirecting to extension.
		/// </summary>
		/// <remarks>
		/// The subscriber extension at which the call was transferred.
		/// </remarks>
		public string RedirectionId {
			get {
				return GetTypedColumnValue<string>("RedirectionId");
			}
			set {
				SetColumnValue("RedirectionId", value);
			}
		}

		/// <summary>
		/// Start date.
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
		/// End date.
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
		/// Duration.
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
		/// Time to connect.
		/// </summary>
		public int BeforeConnectionTime {
			get {
				return GetTypedColumnValue<int>("BeforeConnectionTime");
			}
			set {
				SetColumnValue("BeforeConnectionTime", value);
			}
		}

		/// <summary>
		/// Conversation time.
		/// </summary>
		public int TalkTime {
			get {
				return GetTypedColumnValue<int>("TalkTime");
			}
			set {
				SetColumnValue("TalkTime", value);
			}
		}

		/// <summary>
		/// On hold time.
		/// </summary>
		public int HoldTime {
			get {
				return GetTypedColumnValue<int>("HoldTime");
			}
			set {
				SetColumnValue("HoldTime", value);
			}
		}

		/// <exclude/>
		public Guid DirectionId {
			get {
				return GetTypedColumnValue<Guid>("DirectionId");
			}
			set {
				SetColumnValue("DirectionId", value);
				_direction = null;
			}
		}

		/// <exclude/>
		public string DirectionName {
			get {
				return GetTypedColumnValue<string>("DirectionName");
			}
			set {
				SetColumnValue("DirectionName", value);
				if (_direction != null) {
					_direction.Name = value;
				}
			}
		}

		private CallDirection _direction;
		/// <summary>
		/// Call direction.
		/// </summary>
		public CallDirection Direction {
			get {
				return _direction ??
					(_direction = LookupColumnEntities.GetEntity("Direction") as CallDirection);
			}
		}

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

		/// <exclude/>
		public Guid ResultId {
			get {
				return GetTypedColumnValue<Guid>("ResultId");
			}
			set {
				SetColumnValue("ResultId", value);
				_result = null;
			}
		}

		/// <exclude/>
		public string ResultName {
			get {
				return GetTypedColumnValue<string>("ResultName");
			}
			set {
				SetColumnValue("ResultName", value);
				if (_result != null) {
					_result.Name = value;
				}
			}
		}

		private ActivityResult _result;
		/// <summary>
		/// Result.
		/// </summary>
		public ActivityResult Result {
			get {
				return _result ??
					(_result = LookupColumnEntities.GetEntity("Result") as ActivityResult);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
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

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		/// <summary>
		/// Globally unique call linkage Id.
		/// </summary>
		public string GloballyUniqueCallLinkageId {
			get {
				return GetTypedColumnValue<string>("GloballyUniqueCallLinkageId");
			}
			set {
				SetColumnValue("GloballyUniqueCallLinkageId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Call_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Call_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Call_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Call_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Call_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Call_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Call_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Call_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Call_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Call_BaseEventsProcess

	/// <exclude/>
	public partial class Call_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Call_Base_BPMSoft
	{

		public Call_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Call_BaseEventsProcess";
			SchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
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

	#region Class: Call_BaseEventsProcess

	/// <exclude/>
	public class Call_BaseEventsProcess : Call_BaseEventsProcess<Call_Base_BPMSoft>
	{

		public Call_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Call_BaseEventsProcess

	public partial class Call_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

