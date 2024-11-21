namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportParametersRepositorySchema

	/// <exclude/>
	public class IImportParametersRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportParametersRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportParametersRepositorySchema(IImportParametersRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0944487b-5887-4694-84cc-de8e541b2ac6");
			Name = "IImportParametersRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a83ae89b-1206-453d-b626-f37ab41fffbf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,84,77,111,219,48,12,61,39,64,254,3,209,83,7,4,246,189,243,114,88,219,5,58,12,13,26,116,59,43,22,157,9,179,37,65,146,91,24,67,255,123,37,203,78,252,181,46,201,134,157,12,81,228,123,143,207,20,5,45,208,40,154,34,124,222,124,221,202,204,70,183,82,100,124,95,106,106,185,20,209,23,158,35,41,148,212,118,49,255,181,152,207,74,195,197,30,182,149,177,88,124,28,156,93,105,158,99,234,235,76,180,70,129,154,167,163,28,242,224,66,46,168,202,93,206,83,224,194,162,206,60,63,9,52,27,170,157,36,23,52,143,168,164,225,86,234,10,110,128,220,11,203,109,117,140,37,195,244,149,3,245,10,103,113,28,67,98,202,162,160,186,90,181,129,39,197,168,69,48,150,238,17,100,6,188,174,6,131,198,56,185,135,178,120,88,151,40,79,0,194,145,124,186,226,236,106,149,196,117,100,58,65,224,75,144,181,245,60,253,228,103,201,89,35,163,147,115,189,46,93,152,179,37,28,157,174,47,204,189,40,29,108,15,240,67,176,110,186,195,59,204,157,15,160,14,134,64,38,245,133,125,6,202,80,67,216,68,31,129,172,17,223,207,126,87,228,26,173,105,53,165,84,164,152,67,150,211,125,244,47,132,213,217,26,109,169,133,89,145,49,71,18,183,151,62,123,39,101,238,229,16,67,186,160,183,117,1,178,243,91,107,38,204,83,53,180,200,46,159,180,97,163,164,135,2,132,69,103,13,226,55,154,151,56,101,252,232,207,6,3,122,158,92,236,133,210,50,117,249,78,237,216,136,232,63,57,209,104,232,84,182,170,184,112,219,192,53,59,132,24,61,212,77,11,49,105,196,18,234,232,129,231,228,249,239,188,212,23,110,127,116,116,165,178,80,254,125,189,231,81,59,203,119,188,94,184,238,46,160,252,196,10,184,153,106,18,168,96,240,28,6,97,66,196,224,125,28,113,19,223,223,18,70,251,214,55,243,221,81,182,246,28,100,95,255,201,2,200,220,174,131,76,203,2,216,238,148,38,31,235,111,40,51,86,35,45,6,106,183,117,208,99,251,53,26,78,231,143,109,179,66,79,85,247,23,99,218,89,162,94,240,111,165,206,94,23,243,215,55,147,124,39,155,164,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0944487b-5887-4694-84cc-de8e541b2ac6"));
		}

		#endregion

	}

	#endregion

}

