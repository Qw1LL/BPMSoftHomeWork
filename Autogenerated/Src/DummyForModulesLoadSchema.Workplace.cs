namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DummyForModulesLoadSchema

	/// <exclude/>
	public class DummyForModulesLoadSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DummyForModulesLoadSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DummyForModulesLoadSchema(DummyForModulesLoadSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("be6b597e-2758-49e0-b6d7-c2a371cdad22");
			Name = "DummyForModulesLoad";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bb927652-946c-46e9-92ec-d4e247692a1b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be6b597e-2758-49e0-b6d7-c2a371cdad22"));
		}

		#endregion

	}

	#endregion

}

