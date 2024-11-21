namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CaseServiceConstsSchema

	/// <exclude/>
	public class CaseServiceConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CaseServiceConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CaseServiceConstsSchema(CaseServiceConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c96d0a7-eeac-44d3-afd1-3e92a22d0b77");
			Name = "CaseServiceConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,205,106,2,49,20,70,215,10,190,67,176,155,118,17,153,95,199,169,116,49,137,90,186,104,17,245,5,210,204,85,2,51,201,116,110,70,144,226,187,55,19,233,166,180,84,220,37,57,31,223,185,132,171,69,13,216,8,9,132,173,95,183,102,111,39,220,232,189,58,116,173,176,202,104,242,57,26,142,134,131,14,149,62,144,237,9,45,212,115,255,114,215,194,161,231,188,18,136,143,100,221,189,87,74,122,210,248,35,65,235,10,36,145,61,39,92,32,108,161,61,42,9,174,30,45,246,189,131,31,209,22,68,105,116,117,34,207,157,42,201,6,208,84,93,63,195,155,177,106,175,164,159,103,215,84,47,37,121,242,145,201,90,180,8,247,227,40,78,179,156,231,140,22,139,56,162,73,26,5,116,22,167,49,205,88,17,23,5,103,105,92,228,227,135,249,127,194,37,90,85,123,201,6,62,58,64,251,155,139,207,86,44,12,86,33,101,78,73,19,54,77,104,190,8,83,154,69,171,36,88,46,179,112,154,177,43,92,133,180,234,168,236,201,181,58,168,26,161,237,198,84,176,51,78,247,205,184,255,168,201,159,209,91,37,92,94,45,225,242,86,9,147,215,91,92,182,215,156,47,123,5,186,188,172,86,127,61,127,1,16,108,176,42,159,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c96d0a7-eeac-44d3-afd1-3e92a22d0b77"));
		}

		#endregion

	}

	#endregion

}

