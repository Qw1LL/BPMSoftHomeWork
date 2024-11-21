namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GetAvailableProvidersResponseSchema

	/// <exclude/>
	public class GetAvailableProvidersResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetAvailableProvidersResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetAvailableProvidersResponseSchema(GetAvailableProvidersResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a32e2754-ebd1-43a6-8c8d-70af49bb850d");
			Name = "GetAvailableProvidersResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,84,77,111,219,48,12,61,59,64,254,3,209,93,54,160,176,239,75,22,96,77,139,34,135,12,65,114,28,118,80,100,58,17,32,75,134,40,167,232,138,254,247,81,178,149,207,22,195,138,0,187,216,38,69,62,190,71,82,54,162,70,106,132,68,184,91,204,87,182,242,249,212,154,74,109,90,39,188,178,38,159,62,172,230,182,68,77,195,193,203,112,144,181,164,204,6,86,207,228,177,230,72,173,81,134,48,202,31,209,160,83,114,116,30,179,108,141,87,53,230,43,62,21,90,253,142,168,28,197,113,159,28,110,216,128,169,22,68,95,225,17,253,247,157,80,90,172,53,46,156,221,169,18,29,45,153,28,195,99,76,40,138,2,198,212,214,181,112,207,147,222,94,98,227,144,208,120,2,191,69,224,239,86,123,176,85,180,252,214,89,239,117,160,67,114,139,101,171,49,79,56,197,17,208,207,123,225,5,235,246,78,72,255,139,29,77,187,214,74,130,12,204,254,70,44,227,190,240,115,47,135,67,26,116,94,33,107,90,68,156,238,252,156,125,116,48,54,129,117,64,225,29,40,203,125,79,131,8,145,234,66,205,31,65,71,147,8,4,33,151,74,58,41,115,172,215,232,62,255,224,217,194,55,184,17,23,236,111,190,4,149,73,230,236,193,180,53,186,16,49,78,33,51,83,217,9,92,234,134,23,216,160,31,5,194,35,120,237,149,163,41,59,241,209,238,188,199,206,236,114,218,199,117,254,231,112,79,121,92,111,150,2,118,66,183,8,202,148,74,242,210,51,203,167,45,50,111,23,201,167,49,130,34,30,185,49,60,114,44,223,25,105,244,68,180,131,41,39,222,181,56,46,228,4,84,245,62,226,8,108,40,249,164,8,111,67,82,37,52,197,172,163,82,7,228,183,118,71,209,52,129,157,46,205,218,90,13,179,195,233,249,98,100,217,213,27,85,98,37,194,2,84,156,187,151,8,66,74,203,63,153,171,53,175,175,114,141,214,221,119,80,111,54,174,63,251,104,219,2,107,19,10,245,183,33,41,248,135,223,66,74,9,246,41,69,242,46,204,33,221,141,152,240,145,123,63,28,188,254,1,112,211,30,123,96,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a32e2754-ebd1-43a6-8c8d-70af49bb850d"));
		}

		#endregion

	}

	#endregion

}

