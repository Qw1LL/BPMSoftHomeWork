namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwSectionDesignerModuleInfoSchema

	/// <exclude/>
	public class VwSectionDesignerModuleInfoSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwSectionDesignerModuleInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSectionDesignerModuleInfoSchema(VwSectionDesignerModuleInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSectionDesignerModuleInfoSchema(VwSectionDesignerModuleInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c");
			RealUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c");
			Name = "VwSectionDesignerModuleInfo";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCodeColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b70760e9-4339-4a29-8575-eaa72442771b")) == null) {
				Columns.Add(CreateWorkspaceIdColumn());
			}
			if (Columns.FindByUId(new Guid("0c5c6c49-8b76-4aea-8c6a-f66358d47e18")) == null) {
				Columns.Add(CreateWorkspaceNameColumn());
			}
			if (Columns.FindByUId(new Guid("4a51ac48-8b52-4b1c-ae0c-1a5e97bf7cab")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("a0cc89ae-1f50-4f95-b69e-1f09f9d23278")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("a52b1710-b24c-41f6-b994-29c48c13e6a3")) == null) {
				Columns.Add(CreateSectionSchemaIdColumn());
			}
			if (Columns.FindByUId(new Guid("cd1d1076-fb22-453f-91f7-556030c96db3")) == null) {
				Columns.Add(CreateSectionSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("3a969e87-3824-47b8-a8aa-3341191d632c")) == null) {
				Columns.Add(CreateEntityFolderIdColumn());
			}
			if (Columns.FindByUId(new Guid("a7622b91-eef7-40fe-b27e-c58f5d0564fa")) == null) {
				Columns.Add(CreateEntityFolderNameColumn());
			}
			if (Columns.FindByUId(new Guid("93ee0bee-7aa2-41e1-93b8-4dc55f16fe77")) == null) {
				Columns.Add(CreateEntityInFolderIdColumn());
			}
			if (Columns.FindByUId(new Guid("67834ea3-10ac-4e30-99cf-ced63d45b61d")) == null) {
				Columns.Add(CreateEntityInFolderNameColumn());
			}
			if (Columns.FindByUId(new Guid("5e4685c9-ec9d-496e-b305-e69be6f64e73")) == null) {
				Columns.Add(CreateTypeColumnIdColumn());
			}
			if (Columns.FindByUId(new Guid("af7d2a74-11bf-43bc-8bef-db1dac483353")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("f2fb0d55-f54f-4bca-a1c7-815d8ecce6bf")) == null) {
				Columns.Add(CreateHeaderColumn());
			}
			if (Columns.FindByUId(new Guid("14368a2e-840b-4adb-acde-8793a61ce775")) == null) {
				Columns.Add(CreateSysModuleEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("52f056e8-3d49-4ade-82e9-fd5e323bd0e4")) == null) {
				Columns.Add(CreateSysModuleCaptionLczIdColumn());
			}
			if (Columns.FindByUId(new Guid("66973885-d226-4d6b-989b-4e8258ef9962")) == null) {
				Columns.Add(CreateSysModuleHeaderLczIdColumn());
			}
			if (Columns.FindByUId(new Guid("aef65b46-2cb4-4c29-bb31-8d4ae62b2976")) == null) {
				Columns.Add(CreateCultureIdColumn());
			}
			if (Columns.FindByUId(new Guid("da14f2df-00dd-43d3-89d8-b246f4d13044")) == null) {
				Columns.Add(CreateImage32IdColumn());
			}
			if (Columns.FindByUId(new Guid("4d53f4ba-835f-4217-a09b-064b91fb4fb1")) == null) {
				Columns.Add(CreateSectionDetailIdColumn());
			}
			if (Columns.FindByUId(new Guid("fa66f065-207f-4ed7-9582-867fdd234e69")) == null) {
				Columns.Add(CreateSectionDetailNameColumn());
			}
			if (Columns.FindByUId(new Guid("bb55fbab-73aa-4276-8277-7a5a76e0e0ce")) == null) {
				Columns.Add(CreateLogoIdColumn());
			}
			if (Columns.FindByUId(new Guid("00ffcb6a-e106-4a4b-b13c-8ab24192b94b")) == null) {
				Columns.Add(CreateEntityTagIdColumn());
			}
			if (Columns.FindByUId(new Guid("6420a3c6-ecd5-4ec8-86af-581ebcdc9070")) == null) {
				Columns.Add(CreateEntityTagNameColumn());
			}
			if (Columns.FindByUId(new Guid("6a7c43be-5d00-4cb9-9132-69c24c20d13f")) == null) {
				Columns.Add(CreateEntityInTagIdColumn());
			}
			if (Columns.FindByUId(new Guid("f7fbdf0d-f39e-4616-b661-f3a98e238b9f")) == null) {
				Columns.Add(CreateEntityInTagNameColumn());
			}
			if (Columns.FindByUId(new Guid("fd344ebc-1612-4a21-ab54-40fb85942852")) == null) {
				Columns.Add(CreateCaptionOldColumn());
			}
			if (Columns.FindByUId(new Guid("2d41491a-38c7-4b40-b894-0ba0e88df1e7")) == null) {
				Columns.Add(CreateHeaderOldColumn());
			}
			if (Columns.FindByUId(new Guid("e4432b07-7efa-4ac4-ba14-c6cd040bc29a")) == null) {
				Columns.Add(CreateDefaultCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("8923828d-59c9-4961-b0b2-59dff2ac93fb")) == null) {
				Columns.Add(CreateDefaultHeaderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("59a1c101-5401-46bd-9e13-4d1e88dd48e5"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a545fe2f-27b0-4265-8d2d-476106d1c23d"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkspaceIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b70760e9-4339-4a29-8575-eaa72442771b"),
				Name = @"WorkspaceId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkspaceNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0c5c6c49-8b76-4aea-8c6a-f66358d47e18"),
				Name = @"WorkspaceName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4a51ac48-8b52-4b1c-ae0c-1a5e97bf7cab"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a0cc89ae-1f50-4f95-b69e-1f09f9d23278"),
				Name = @"EntityName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateSectionSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a52b1710-b24c-41f6-b994-29c48c13e6a3"),
				Name = @"SectionSchemaId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateSectionSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cd1d1076-fb22-453f-91f7-556030c96db3"),
				Name = @"SectionSchemaName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityFolderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3a969e87-3824-47b8-a8aa-3341191d632c"),
				Name = @"EntityFolderId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityFolderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a7622b91-eef7-40fe-b27e-c58f5d0564fa"),
				Name = @"EntityFolderName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityInFolderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("93ee0bee-7aa2-41e1-93b8-4dc55f16fe77"),
				Name = @"EntityInFolderId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityInFolderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("67834ea3-10ac-4e30-99cf-ced63d45b61d"),
				Name = @"EntityInFolderName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5e4685c9-ec9d-496e-b305-e69be6f64e73"),
				Name = @"TypeColumnId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("af7d2a74-11bf-43bc-8bef-db1dac483353"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateHeaderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f2fb0d55-f54f-4bca-a1c7-815d8ecce6bf"),
				Name = @"Header",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("14368a2e-840b-4adb-acde-8793a61ce775"),
				Name = @"SysModuleEntityId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f49bb6bd-841c-4c63-ad99-02e5e16b44e0")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleCaptionLczIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("52f056e8-3d49-4ade-82e9-fd5e323bd0e4"),
				Name = @"SysModuleCaptionLczId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f49bb6bd-841c-4c63-ad99-02e5e16b44e0")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleHeaderLczIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("66973885-d226-4d6b-989b-4e8258ef9962"),
				Name = @"SysModuleHeaderLczId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f49bb6bd-841c-4c63-ad99-02e5e16b44e0")
			};
		}

		protected virtual EntitySchemaColumn CreateCultureIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("aef65b46-2cb4-4c29-bb31-8d4ae62b2976"),
				Name = @"CultureId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f49bb6bd-841c-4c63-ad99-02e5e16b44e0")
			};
		}

		protected virtual EntitySchemaColumn CreateImage32IdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("da14f2df-00dd-43d3-89d8-b246f4d13044"),
				Name = @"Image32Id",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("1963b82f-827a-45d5-9d45-b9c69a3e7506")
			};
		}

		protected virtual EntitySchemaColumn CreateSectionDetailIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4d53f4ba-835f-4217-a09b-064b91fb4fb1"),
				Name = @"SectionDetailId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("c53101b8-fc97-4884-80b5-073b8b9d9629")
			};
		}

		protected virtual EntitySchemaColumn CreateSectionDetailNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("fa66f065-207f-4ed7-9582-867fdd234e69"),
				Name = @"SectionDetailName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("c53101b8-fc97-4884-80b5-073b8b9d9629")
			};
		}

		protected virtual EntitySchemaColumn CreateLogoIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("bb55fbab-73aa-4276-8277-7a5a76e0e0ce"),
				Name = @"LogoId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("c53101b8-fc97-4884-80b5-073b8b9d9629")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityTagIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("00ffcb6a-e106-4a4b-b13c-8ab24192b94b"),
				Name = @"EntityTagId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f859a419-7cd0-4279-8be1-be8c6fc7e2cb")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityTagNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6420a3c6-ecd5-4ec8-86af-581ebcdc9070"),
				Name = @"EntityTagName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f859a419-7cd0-4279-8be1-be8c6fc7e2cb")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityInTagIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6a7c43be-5d00-4cb9-9132-69c24c20d13f"),
				Name = @"EntityInTagId",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f859a419-7cd0-4279-8be1-be8c6fc7e2cb")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityInTagNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f7fbdf0d-f39e-4616-b661-f3a98e238b9f"),
				Name = @"EntityInTagName",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("f859a419-7cd0-4279-8be1-be8c6fc7e2cb")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionOldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fd344ebc-1612-4a21-ab54-40fb85942852"),
				Name = @"CaptionOld",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("e1c0b1c2-9464-4e77-9858-9f20ed2250ae")
			};
		}

		protected virtual EntitySchemaColumn CreateHeaderOldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2d41491a-38c7-4b40-b894-0ba0e88df1e7"),
				Name = @"HeaderOld",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("e1c0b1c2-9464-4e77-9858-9f20ed2250ae")
			};
		}

		protected virtual EntitySchemaColumn CreateDefaultCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e4432b07-7efa-4ac4-ba14-c6cd040bc29a"),
				Name = @"DefaultCaption",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("e1c0b1c2-9464-4e77-9858-9f20ed2250ae")
			};
		}

		protected virtual EntitySchemaColumn CreateDefaultHeaderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8923828d-59c9-4961-b0b2-59dff2ac93fb"),
				Name = @"DefaultHeader",
				CreatedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				ModifiedInSchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"),
				CreatedInPackageId = new Guid("e1c0b1c2-9464-4e77-9858-9f20ed2250ae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSectionDesignerModuleInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSectionDesignerModuleInfo_PlatformEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSectionDesignerModuleInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSectionDesignerModuleInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSectionDesignerModuleInfo

	/// <summary>
	/// Section information in designer (view).
	/// </summary>
	public class VwSectionDesignerModuleInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSectionDesignerModuleInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSectionDesignerModuleInfo";
		}

		public VwSectionDesignerModuleInfo(VwSectionDesignerModuleInfo source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
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
		/// WorkspaceId.
		/// </summary>
		public Guid WorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("WorkspaceId");
			}
			set {
				SetColumnValue("WorkspaceId", value);
			}
		}

		/// <summary>
		/// WorkspaceName.
		/// </summary>
		public string WorkspaceName {
			get {
				return GetTypedColumnValue<string>("WorkspaceName");
			}
			set {
				SetColumnValue("WorkspaceName", value);
			}
		}

		/// <summary>
		/// EntityId.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// EntityName.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// SectionSchemaId.
		/// </summary>
		public Guid SectionSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SectionSchemaId");
			}
			set {
				SetColumnValue("SectionSchemaId", value);
			}
		}

		/// <summary>
		/// SectionSchemaName.
		/// </summary>
		public string SectionSchemaName {
			get {
				return GetTypedColumnValue<string>("SectionSchemaName");
			}
			set {
				SetColumnValue("SectionSchemaName", value);
			}
		}

		/// <summary>
		/// EntityFolderId.
		/// </summary>
		public Guid EntityFolderId {
			get {
				return GetTypedColumnValue<Guid>("EntityFolderId");
			}
			set {
				SetColumnValue("EntityFolderId", value);
			}
		}

		/// <summary>
		/// EntityFolderName.
		/// </summary>
		public string EntityFolderName {
			get {
				return GetTypedColumnValue<string>("EntityFolderName");
			}
			set {
				SetColumnValue("EntityFolderName", value);
			}
		}

		/// <summary>
		/// EntityInFolderId.
		/// </summary>
		public Guid EntityInFolderId {
			get {
				return GetTypedColumnValue<Guid>("EntityInFolderId");
			}
			set {
				SetColumnValue("EntityInFolderId", value);
			}
		}

		/// <summary>
		/// EntityInFolderName.
		/// </summary>
		public string EntityInFolderName {
			get {
				return GetTypedColumnValue<string>("EntityInFolderName");
			}
			set {
				SetColumnValue("EntityInFolderName", value);
			}
		}

		/// <summary>
		/// TypeColumnId.
		/// </summary>
		public Guid TypeColumnId {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnId");
			}
			set {
				SetColumnValue("TypeColumnId", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Header.
		/// </summary>
		public string Header {
			get {
				return GetTypedColumnValue<string>("Header");
			}
			set {
				SetColumnValue("Header", value);
			}
		}

		/// <summary>
		/// SysModuleEntityId.
		/// </summary>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
			}
		}

		/// <summary>
		/// SysModuleCaptionLczId.
		/// </summary>
		public Guid SysModuleCaptionLczId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleCaptionLczId");
			}
			set {
				SetColumnValue("SysModuleCaptionLczId", value);
			}
		}

		/// <summary>
		/// SysModuleHeaderLczId.
		/// </summary>
		public Guid SysModuleHeaderLczId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleHeaderLczId");
			}
			set {
				SetColumnValue("SysModuleHeaderLczId", value);
			}
		}

		/// <summary>
		/// CultureId.
		/// </summary>
		public Guid CultureId {
			get {
				return GetTypedColumnValue<Guid>("CultureId");
			}
			set {
				SetColumnValue("CultureId", value);
			}
		}

		/// <summary>
		/// Image32Id.
		/// </summary>
		public Guid Image32Id {
			get {
				return GetTypedColumnValue<Guid>("Image32Id");
			}
			set {
				SetColumnValue("Image32Id", value);
			}
		}

		/// <summary>
		/// SectionDetailId.
		/// </summary>
		public Guid SectionDetailId {
			get {
				return GetTypedColumnValue<Guid>("SectionDetailId");
			}
			set {
				SetColumnValue("SectionDetailId", value);
			}
		}

		/// <summary>
		/// SectionDetailName.
		/// </summary>
		public string SectionDetailName {
			get {
				return GetTypedColumnValue<string>("SectionDetailName");
			}
			set {
				SetColumnValue("SectionDetailName", value);
			}
		}

		/// <summary>
		/// LogoId.
		/// </summary>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
			}
		}

		/// <summary>
		/// EntityTagId.
		/// </summary>
		public Guid EntityTagId {
			get {
				return GetTypedColumnValue<Guid>("EntityTagId");
			}
			set {
				SetColumnValue("EntityTagId", value);
			}
		}

		/// <summary>
		/// EntityTagName.
		/// </summary>
		public string EntityTagName {
			get {
				return GetTypedColumnValue<string>("EntityTagName");
			}
			set {
				SetColumnValue("EntityTagName", value);
			}
		}

		/// <summary>
		/// EntityInTagId.
		/// </summary>
		public Guid EntityInTagId {
			get {
				return GetTypedColumnValue<Guid>("EntityInTagId");
			}
			set {
				SetColumnValue("EntityInTagId", value);
			}
		}

		/// <summary>
		/// EntityInTagName.
		/// </summary>
		public string EntityInTagName {
			get {
				return GetTypedColumnValue<string>("EntityInTagName");
			}
			set {
				SetColumnValue("EntityInTagName", value);
			}
		}

		/// <summary>
		/// CaptionOld.
		/// </summary>
		public string CaptionOld {
			get {
				return GetTypedColumnValue<string>("CaptionOld");
			}
			set {
				SetColumnValue("CaptionOld", value);
			}
		}

		/// <summary>
		/// HeaderOld.
		/// </summary>
		public string HeaderOld {
			get {
				return GetTypedColumnValue<string>("HeaderOld");
			}
			set {
				SetColumnValue("HeaderOld", value);
			}
		}

		/// <summary>
		/// Default caption.
		/// </summary>
		public string DefaultCaption {
			get {
				return GetTypedColumnValue<string>("DefaultCaption");
			}
			set {
				SetColumnValue("DefaultCaption", value);
			}
		}

		/// <summary>
		/// Default header.
		/// </summary>
		public string DefaultHeader {
			get {
				return GetTypedColumnValue<string>("DefaultHeader");
			}
			set {
				SetColumnValue("DefaultHeader", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSectionDesignerModuleInfo_PlatformEventsProcess(UserConnection);
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
			return new VwSectionDesignerModuleInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSectionDesignerModuleInfo_PlatformEventsProcess

	/// <exclude/>
	public partial class VwSectionDesignerModuleInfo_PlatformEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwSectionDesignerModuleInfo
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwSectionDesignerModuleInfo_PlatformEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSectionDesignerModuleInfo_PlatformEventsProcess";
			SchemaUId = new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ad7b6c75-aaf9-4ff6-8ca8-03237a2a159c");
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

	#region Class: VwSectionDesignerModuleInfo_PlatformEventsProcess

	/// <exclude/>
	public class VwSectionDesignerModuleInfo_PlatformEventsProcess : VwSectionDesignerModuleInfo_PlatformEventsProcess<VwSectionDesignerModuleInfo>
	{

		public VwSectionDesignerModuleInfo_PlatformEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSectionDesignerModuleInfo_PlatformEventsProcess

	public partial class VwSectionDesignerModuleInfo_PlatformEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSectionDesignerModuleInfoEventsProcess

	/// <exclude/>
	public class VwSectionDesignerModuleInfoEventsProcess : VwSectionDesignerModuleInfo_PlatformEventsProcess
	{

		public VwSectionDesignerModuleInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

