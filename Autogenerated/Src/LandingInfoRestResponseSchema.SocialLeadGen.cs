namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LandingInfoRestResponseSchema

	/// <exclude/>
	public class LandingInfoRestResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LandingInfoRestResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LandingInfoRestResponseSchema(LandingInfoRestResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ff0d71e4-de6c-c97e-7e4b-bdc6aecbd4a2");
			Name = "LandingInfoRestResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,205,106,195,48,16,132,207,49,248,29,22,114,143,239,73,233,161,46,13,129,180,53,117,95,64,182,214,206,130,45,25,253,180,132,208,119,239,202,118,210,166,63,196,57,72,160,209,48,250,134,149,18,45,218,78,148,8,119,217,99,174,43,183,72,181,170,168,246,70,56,210,106,145,235,146,68,179,69,33,215,168,226,232,16,71,51,111,73,213,144,239,173,195,118,21,71,172,204,13,214,108,134,180,17,214,46,97,43,148,100,203,70,85,250,5,173,227,213,105,101,177,183,38,73,2,55,214,183,173,48,251,219,241,156,54,218,75,48,163,13,238,95,159,225,157,220,14,136,3,76,219,115,128,40,180,119,208,12,201,96,125,97,75,67,69,143,120,76,77,190,197,118,190,104,168,132,50,0,253,199,3,75,56,107,23,238,50,163,223,72,162,249,98,158,113,101,222,79,29,217,209,161,113,132,92,52,235,95,25,238,127,22,235,133,7,230,7,146,1,241,55,227,17,210,58,19,58,5,239,70,194,1,106,116,43,176,97,251,184,20,173,120,122,147,195,159,216,60,57,62,19,53,78,37,207,216,123,5,121,176,79,39,15,238,171,200,199,105,95,132,95,123,146,167,175,241,39,253,28,149,28,166,222,159,7,245,92,100,237,19,115,207,145,22,66,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff0d71e4-de6c-c97e-7e4b-bdc6aecbd4a2"));
		}

		#endregion

	}

	#endregion

}

