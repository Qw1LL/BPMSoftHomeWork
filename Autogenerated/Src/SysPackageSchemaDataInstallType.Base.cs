namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using System;

	#region Class: SysPackageSchemaDataInstallTypeSchema

	/// <exclude/>
	public class SysPackageSchemaDataInstallTypeSchema : BPMSoft.Core.ValueListSchema
	{

		#region Constructors: Public

		public SysPackageSchemaDataInstallTypeSchema(ValueListSchemaManager valueListSchemaManager)
			: base(valueListSchemaManager) {
		}

		public SysPackageSchemaDataInstallTypeSchema(SysPackageSchemaDataInstallTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageSchemaDataInstallTypeSchema(SysPackageSchemaDataInstallTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8598c861-bf61-4e11-a7d8-4f8b030ea0f6");
			RealUId = new Guid("8598c861-bf61-4e11-a7d8-4f8b030ea0f6");
			Name = "SysPackageSchemaDataInstallType";
			ParentSchemaUId = new Guid("ffd66d1f-f7a2-4812-88bf-7df6ddb90753");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			Flags = false;
			AutoValues = true;
		}

		protected override void InitializeItems() {
			base.InitializeItems();
			Items.Add(new ValueListSchemaItem() { Name = "Install", Value = 0, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "FirstInstall", Value = 1, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Update", Value = 2, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
		}

		#endregion

	}

	#endregion

	#region Enum: SysPackageSchemaDataInstallType

	public enum SysPackageSchemaDataInstallType
	{
		Install,
		FirstInstall,
		Update

	}

	#endregion

}

