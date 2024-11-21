namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using System;

	#region Class: DaysOfWeekSchema

	/// <exclude/>
	public class DaysOfWeekSchema : BPMSoft.Core.ValueListSchema
	{

		#region Constructors: Public

		public DaysOfWeekSchema(ValueListSchemaManager valueListSchemaManager)
			: base(valueListSchemaManager) {
		}

		public DaysOfWeekSchema(DaysOfWeekSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaysOfWeekSchema(DaysOfWeekSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fc08d254-e59a-432b-ad3d-d47f86a63d45");
			RealUId = new Guid("fc08d254-e59a-432b-ad3d-d47f86a63d45");
			Name = "DaysOfWeek";
			ParentSchemaUId = new Guid("ffd66d1f-f7a2-4812-88bf-7df6ddb90753");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			Flags = false;
			AutoValues = true;
		}

		protected override void InitializeItems() {
			base.InitializeItems();
			Items.Add(new ValueListSchemaItem() { Name = "Sunday", Value = 0, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Monday", Value = 1, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Tuesday", Value = 2, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Wednesday", Value = 3, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Thursday", Value = 4, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Friday", Value = 5, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Saturday", Value = 6, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
		}

		#endregion

	}

	#endregion

	#region Enum: DaysOfWeek

	public enum DaysOfWeek
	{
		Sunday,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday

	}

	#endregion

}

