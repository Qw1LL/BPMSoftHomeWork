namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IntegrationUtilsSchema

	/// <exclude/>
	public class IntegrationUtilsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntegrationUtilsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntegrationUtilsSchema(IntegrationUtilsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d4eda3c2-a9cc-455c-a6b6-3d2187c88a64");
			Name = "IntegrationUtils";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,223,110,130,48,20,198,175,37,225,29,26,175,48,49,125,1,179,27,197,45,38,211,45,50,183,235,174,28,89,19,104,73,123,234,66,22,223,125,165,69,7,139,38,220,0,231,207,239,156,175,253,176,70,200,130,100,141,65,168,22,113,100,125,184,124,221,102,234,136,116,165,52,220,76,210,116,121,205,7,150,166,12,153,203,197,145,100,21,152,154,113,232,17,242,40,10,171,25,10,37,227,232,39,142,38,181,253,44,5,39,188,100,198,144,141,68,40,66,245,128,162,52,174,222,246,92,154,12,186,18,39,39,37,114,242,161,5,66,214,72,190,7,99,75,76,14,6,180,27,47,129,183,52,177,131,112,78,158,172,99,140,23,216,5,185,208,131,162,246,115,186,64,213,16,100,204,221,82,221,30,46,7,195,181,168,219,220,172,149,228,117,77,78,76,247,69,63,171,34,227,95,80,49,242,240,79,1,93,75,20,216,132,234,150,73,86,128,166,143,66,230,27,233,78,37,57,44,155,157,187,174,100,58,156,54,157,45,238,236,113,27,110,45,166,43,13,12,33,108,75,134,26,186,89,67,140,102,128,41,28,87,170,180,149,124,103,165,5,147,220,109,236,117,13,148,6,231,55,249,212,93,151,255,28,55,33,189,88,224,201,171,33,227,224,189,247,203,147,193,186,113,216,203,197,89,79,94,125,30,7,175,181,86,58,253,251,19,90,213,189,255,98,220,161,157,61,142,107,95,111,162,2,122,64,190,83,223,119,88,118,130,206,141,179,123,156,39,113,116,254,5,83,235,201,58,168,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d4eda3c2-a9cc-455c-a6b6-3d2187c88a64"));
		}

		#endregion

	}

	#endregion

}

