namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using System;

	#region Class: SysLicTypeSchema

	/// <exclude/>
	public class SysLicTypeSchema : BPMSoft.Core.ValueListSchema
	{

		#region Constructors: Public

		public SysLicTypeSchema(ValueListSchemaManager valueListSchemaManager)
			: base(valueListSchemaManager) {
		}

		public SysLicTypeSchema(SysLicTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLicTypeSchema(SysLicTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fbf0632a-b7f3-43e7-b27d-682bbe8b93d7");
			RealUId = new Guid("fbf0632a-b7f3-43e7-b27d-682bbe8b93d7");
			Name = "SysLicType";
			ParentSchemaUId = new Guid("ffd66d1f-f7a2-4812-88bf-7df6ddb90753");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			Flags = false;
			AutoValues = false;
		}

		protected override void InitializeItems() {
			base.InitializeItems();
			Items.Add(new ValueListSchemaItem() { Name = "Personal", Value = 0, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Competitive", Value = 1, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
		}

		#endregion

	}

	#endregion

	#region Enum: SysLicType

	public enum SysLicType
	{
		Personal = 0,
		Competitive = 1

	}

	#endregion

}

