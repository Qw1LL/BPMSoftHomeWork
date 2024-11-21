namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using System;

	#region Class: UserTaskExecutedModeSchema

	/// <exclude/>
	public class UserTaskExecutedModeSchema : BPMSoft.Core.ValueListSchema
	{

		#region Constructors: Public

		public UserTaskExecutedModeSchema(ValueListSchemaManager valueListSchemaManager)
			: base(valueListSchemaManager) {
		}

		public UserTaskExecutedModeSchema(UserTaskExecutedModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UserTaskExecutedModeSchema(UserTaskExecutedModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41615aa0-05ef-41f2-800b-128f55378cef");
			RealUId = new Guid("41615aa0-05ef-41f2-800b-128f55378cef");
			Name = "UserTaskExecutedMode";
			ParentSchemaUId = new Guid("ffd66d1f-f7a2-4812-88bf-7df6ddb90753");
			CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			Flags = false;
			AutoValues = true;
		}

		protected override void InitializeItems() {
			base.InitializeItems();
			Items.Add(new ValueListSchemaItem() { Name = "EditPageDisplayed", Value = 0, CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c") });
			Items.Add(new ValueListSchemaItem() { Name = "OKButtonClicked", Value = 1, CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c") });
		}

		#endregion

	}

	#endregion

	#region Enum: UserTaskExecutedMode

	public enum UserTaskExecutedMode
	{
		EditPageDisplayed,
		OKButtonClicked

	}

	#endregion

}

