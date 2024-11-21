namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using System;

	#region Class: HoursOrMinutesSchema

	/// <exclude/>
	public class HoursOrMinutesSchema : BPMSoft.Core.ValueListSchema
	{

		#region Constructors: Public

		public HoursOrMinutesSchema(ValueListSchemaManager valueListSchemaManager)
			: base(valueListSchemaManager) {
		}

		public HoursOrMinutesSchema(HoursOrMinutesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public HoursOrMinutesSchema(HoursOrMinutesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9994c85c-ff5c-4aad-895d-7908fc082aec");
			RealUId = new Guid("9994c85c-ff5c-4aad-895d-7908fc082aec");
			Name = "HoursOrMinutes";
			ParentSchemaUId = new Guid("ffd66d1f-f7a2-4812-88bf-7df6ddb90753");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			Flags = false;
			AutoValues = true;
		}

		protected override void InitializeItems() {
			base.InitializeItems();
			Items.Add(new ValueListSchemaItem() { Name = "Hours", Value = 0, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
			Items.Add(new ValueListSchemaItem() { Name = "Minutes", Value = 1, CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6") });
		}

		#endregion

	}

	#endregion

	#region Enum: HoursOrMinutes

	public enum HoursOrMinutes
	{
		Hours,
		Minutes

	}

	#endregion

}

