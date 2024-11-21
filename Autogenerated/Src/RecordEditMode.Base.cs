namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using System;

	#region Class: RecordEditModeSchema

	/// <exclude/>
	public class RecordEditModeSchema : BPMSoft.Core.ValueListSchema
	{

		#region Constructors: Public

		public RecordEditModeSchema(ValueListSchemaManager valueListSchemaManager)
			: base(valueListSchemaManager) {
		}

		public RecordEditModeSchema(RecordEditModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RecordEditModeSchema(RecordEditModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ccc6f34c-94ec-4d7d-85ef-4b79a2086707");
			RealUId = new Guid("ccc6f34c-94ec-4d7d-85ef-4b79a2086707");
			Name = "RecordEditMode";
			ParentSchemaUId = new Guid("ffd66d1f-f7a2-4812-88bf-7df6ddb90753");
			CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			Flags = false;
			AutoValues = true;
		}

		protected override void InitializeItems() {
			base.InitializeItems();
			Items.Add(new ValueListSchemaItem() { Name = "New", Value = 0, CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c") });
			Items.Add(new ValueListSchemaItem() { Name = "Existing", Value = 1, CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c") });
		}

		#endregion

	}

	#endregion

	#region Enum: RecordEditMode

	public enum RecordEditMode
	{
		New,
		Existing

	}

	#endregion

}

