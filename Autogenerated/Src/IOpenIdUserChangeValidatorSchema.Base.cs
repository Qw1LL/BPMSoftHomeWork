namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IOpenIdUserChangeValidatorSchema

	/// <exclude/>
	public class IOpenIdUserChangeValidatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOpenIdUserChangeValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOpenIdUserChangeValidatorSchema(IOpenIdUserChangeValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb3ab0c1-6714-4491-9345-efbe56bcf524");
			Name = "IOpenIdUserChangeValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,77,79,131,64,16,61,183,73,255,195,164,94,52,105,202,93,43,73,37,30,122,104,52,154,122,31,96,128,137,48,75,246,67,37,166,255,221,93,16,235,7,241,64,152,93,230,189,121,239,49,130,13,153,22,51,130,155,251,253,163,42,236,58,81,82,112,233,52,90,86,178,190,107,73,118,249,214,217,106,49,127,95,204,103,206,176,148,223,122,53,93,77,222,174,111,197,178,101,50,254,179,111,56,211,84,122,58,216,137,37,93,248,113,151,176,27,168,15,134,116,82,161,148,244,132,53,231,104,149,238,17,173,75,107,206,128,71,192,191,253,179,32,109,22,69,17,108,140,107,26,212,93,60,94,36,21,101,207,6,184,0,122,99,99,131,78,231,41,32,67,129,148,160,81,57,23,76,249,23,62,250,77,176,105,81,99,3,226,131,186,94,6,168,15,72,40,11,233,44,227,83,13,86,129,87,131,41,26,218,68,61,102,154,194,116,102,155,55,44,7,97,187,255,156,190,140,199,10,40,228,214,129,42,32,56,253,195,164,201,58,45,38,126,24,222,96,181,163,96,110,202,19,160,228,96,240,197,87,223,196,173,64,217,138,244,43,27,130,129,13,10,172,131,232,145,59,12,75,149,170,33,65,25,162,14,82,206,251,228,79,126,127,70,177,130,254,135,119,48,101,239,34,236,200,209,63,97,19,72,242,97,25,250,243,241,3,38,98,193,20,129,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb3ab0c1-6714-4491-9345-efbe56bcf524"));
		}

		#endregion

	}

	#endregion

}

