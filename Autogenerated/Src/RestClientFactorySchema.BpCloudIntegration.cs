namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RestClientFactorySchema

	/// <exclude/>
	public class RestClientFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RestClientFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RestClientFactorySchema(RestClientFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d31eb8c4-6fa9-4307-aac7-0b01e4d010f5");
			Name = "RestClientFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,146,219,78,195,48,12,134,175,59,105,239,96,141,155,33,161,246,30,216,144,24,32,144,56,105,131,7,8,157,183,70,74,147,224,56,154,6,226,221,241,210,140,141,211,77,149,252,254,237,126,182,99,85,139,193,171,26,225,252,241,110,230,22,92,78,156,93,232,101,36,197,218,217,126,239,189,223,43,98,208,118,9,83,12,60,107,20,249,147,126,79,196,3,194,165,56,96,98,84,8,199,41,58,49,26,45,95,169,154,29,173,147,169,170,42,56,13,177,109,21,173,199,249,158,227,71,176,106,116,221,64,77,168,24,3,76,47,103,79,80,167,10,176,210,44,1,71,132,53,195,28,23,42,26,134,128,204,194,17,202,109,221,106,175,176,143,47,70,215,16,88,176,107,41,35,76,127,33,21,210,142,124,191,224,239,144,27,55,23,252,199,148,223,5,127,66,39,97,242,31,166,242,158,156,39,45,81,104,148,157,27,164,132,248,155,177,83,188,34,213,130,149,185,143,6,47,42,224,51,153,193,248,92,14,240,60,189,5,118,16,229,184,112,4,202,24,32,124,141,210,69,40,79,171,148,183,43,67,200,145,108,24,39,158,108,19,215,86,222,248,190,207,228,102,55,14,232,154,217,9,195,192,180,89,113,230,129,17,12,6,135,176,89,125,81,236,165,229,182,71,82,114,99,47,111,194,125,52,230,129,46,91,207,235,97,78,62,76,89,197,25,88,92,237,173,96,152,245,227,159,250,54,77,94,149,132,187,95,148,51,105,195,95,96,64,153,171,209,111,233,45,94,231,225,14,179,181,107,53,67,37,233,35,47,23,237,188,219,111,186,119,234,119,241,227,19,73,113,141,218,248,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d31eb8c4-6fa9-4307-aac7-0b01e4d010f5"));
		}

		#endregion

	}

	#endregion

}

