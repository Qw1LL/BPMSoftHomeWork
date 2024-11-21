namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ServiceInfoSchema

	/// <exclude/>
	public class ServiceInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceInfoSchema(ServiceInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8e8ff62d-d15e-4cbb-bf69-9d73591e0c11");
			Name = "ServiceInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,193,110,194,48,12,134,207,32,241,14,86,185,108,151,246,62,6,7,202,52,237,208,9,173,199,105,135,208,58,93,164,54,65,137,51,137,161,189,251,220,52,48,58,113,225,210,216,127,252,219,159,83,45,58,116,123,81,33,172,183,69,105,36,165,185,209,82,53,222,10,82,70,167,249,83,89,152,26,91,55,155,30,103,211,137,119,74,55,80,30,28,97,151,190,121,77,170,195,180,68,171,68,171,190,131,99,49,155,114,221,220,98,195,9,228,173,112,238,1,184,226,75,85,248,162,165,9,215,89,150,193,163,243,93,39,236,97,21,243,13,74,165,85,223,2,164,177,80,181,198,215,224,6,227,201,146,93,120,222,55,130,4,195,146,21,21,125,176,176,247,187,86,85,108,228,145,227,137,19,70,231,239,153,106,107,205,30,45,41,100,180,109,112,13,247,255,177,130,240,140,228,128,129,92,127,210,39,130,230,39,3,35,67,28,249,210,179,251,146,112,64,44,176,219,161,189,123,237,93,75,72,162,163,79,147,251,30,251,196,237,200,134,183,253,187,135,35,52,72,139,126,242,2,126,110,65,228,128,184,25,139,99,76,182,34,66,101,81,46,147,66,168,150,107,226,188,50,58,146,108,117,211,50,209,53,218,228,122,103,222,44,6,87,214,154,163,174,135,159,19,242,65,29,139,172,253,2,19,1,249,23,173,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8e8ff62d-d15e-4cbb-bf69-9d73591e0c11"));
		}

		#endregion

	}

	#endregion

}

