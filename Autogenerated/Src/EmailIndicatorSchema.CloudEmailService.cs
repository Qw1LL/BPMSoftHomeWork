namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailIndicatorSchema

	/// <exclude/>
	public class EmailIndicatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailIndicatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailIndicatorSchema(EmailIndicatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8e8d82a0-a320-4f28-97ed-a3ba83092051");
			Name = "EmailIndicator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,77,79,227,48,16,134,207,169,196,127,24,133,11,92,218,251,242,33,45,1,85,149,150,85,69,37,46,136,195,212,153,182,86,29,59,178,39,43,193,106,255,59,99,39,13,180,69,218,66,47,73,230,251,121,51,182,197,138,66,141,138,224,102,122,63,115,11,30,22,206,46,244,178,241,200,218,217,147,193,223,147,65,214,4,109,151,48,123,9,76,213,197,142,45,249,198,144,138,201,97,56,38,75,94,171,189,156,135,198,178,174,104,56,147,40,26,253,154,122,75,150,228,157,122,90,138,1,133,193,16,126,192,93,133,218,76,108,169,21,178,243,41,99,52,26,193,101,104,170,10,253,203,117,103,63,80,237,41,144,229,0,20,43,128,189,107,230,134,64,111,74,135,155,202,209,135,210,167,91,100,20,129,236,81,241,179,56,106,41,210,10,84,28,190,55,59,19,237,242,236,17,167,222,213,228,89,147,112,78,83,97,27,223,5,76,142,49,9,155,243,16,226,187,167,2,133,117,212,30,233,246,241,90,190,123,170,230,228,207,126,203,102,224,10,242,174,34,63,143,188,27,224,192,62,254,222,162,141,65,92,82,150,45,137,227,159,207,178,208,125,252,59,148,111,78,86,173,36,188,134,63,104,26,250,2,93,95,185,205,167,45,195,77,223,244,88,60,89,86,131,166,101,3,183,0,94,237,44,250,64,216,182,79,225,228,52,238,227,254,76,193,199,52,227,88,224,192,200,7,147,38,79,210,214,155,5,90,80,114,76,81,219,208,201,206,221,58,143,253,115,242,222,249,252,67,175,247,210,207,52,39,148,79,15,207,44,65,30,43,213,232,192,81,233,228,86,124,173,224,116,35,3,64,169,75,176,142,161,66,86,171,111,45,44,117,154,148,191,100,198,182,132,232,185,28,55,186,188,238,110,109,202,249,143,152,83,178,101,123,149,147,221,122,183,157,226,123,3,73,26,3,79,18,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8e8d82a0-a320-4f28-97ed-a3ba83092051"));
		}

		#endregion

	}

	#endregion

}

