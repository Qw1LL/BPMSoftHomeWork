namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using System;

	#region Class: SysPackageInstallTypeSchema

	/// <exclude/>
	public class SysPackageInstallTypeSchema : BPMSoft.Core.ValueListSchema
	{

		#region Constructors: Public

		public SysPackageInstallTypeSchema(ValueListSchemaManager valueListSchemaManager)
			: base(valueListSchemaManager) {
		}

		public SysPackageInstallTypeSchema(SysPackageInstallTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageInstallTypeSchema(SysPackageInstallTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("999bec5a-7aa1-4347-9040-d3421732352f");
			RealUId = new Guid("999bec5a-7aa1-4347-9040-d3421732352f");
			Name = "SysPackageInstallType";
			ParentSchemaUId = new Guid("ffd66d1f-f7a2-4812-88bf-7df6ddb90753");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			Flags = false;
			AutoValues = true;
		}

		protected override void InitializeItems() {
			base.InitializeItems();
			Items.Add(new ValueListSchemaItem() { Name = "SourceCode", Value = 0, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Repository", Value = 1, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
		}

		#endregion

	}

	#endregion

	#region Enum: SysPackageInstallType

	public enum SysPackageInstallType
	{
		SourceCode,
		Repository

	}

	#endregion

}

