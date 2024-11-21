namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ValidateSenderDomainResponseSchema

	/// <exclude/>
	public class ValidateSenderDomainResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ValidateSenderDomainResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ValidateSenderDomainResponseSchema(ValidateSenderDomainResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("871f1b8a-e82c-41c2-a927-53b14043304e");
			Name = "ValidateSenderDomainResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,146,65,75,195,64,16,133,207,45,244,63,12,245,162,151,228,110,107,15,182,82,10,86,74,2,94,196,195,54,153,196,133,205,110,216,217,20,106,241,191,59,187,73,165,164,69,193,131,120,73,216,55,47,51,223,219,137,22,21,82,45,50,132,251,205,58,53,133,139,230,70,23,178,108,172,112,210,232,104,254,144,174,77,142,138,70,195,195,104,56,104,72,234,18,210,61,57,172,216,169,20,102,222,70,209,18,53,90,153,77,250,158,164,209,78,86,24,165,92,21,74,190,135,174,236,98,223,149,197,146,15,48,87,130,232,22,158,185,156,11,135,41,234,28,237,194,84,66,234,132,217,184,59,6,127,28,199,48,165,166,170,132,221,207,186,115,130,181,69,66,237,8,108,231,5,83,128,123,67,32,180,59,201,185,10,99,185,230,172,196,157,231,202,67,99,10,50,127,152,123,13,89,82,209,113,68,124,50,163,110,182,74,102,144,121,196,31,8,7,124,63,252,252,138,181,177,166,70,235,36,114,182,77,104,211,214,251,49,130,176,68,78,16,136,248,237,233,91,76,207,116,14,53,120,89,8,39,214,88,109,209,94,63,241,2,225,14,198,116,2,181,210,133,161,241,205,171,247,118,9,30,37,185,105,218,243,204,160,175,16,28,160,68,55,241,32,19,248,232,18,177,169,13,21,206,173,218,19,123,203,236,247,253,31,11,60,167,250,195,165,213,45,9,113,16,38,110,33,46,221,246,197,81,9,186,198,114,104,103,27,4,121,188,31,159,166,27,10,146,96,231,255,207,239,167,111,141,81,176,162,240,39,255,114,213,140,249,9,192,140,109,124,53,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("871f1b8a-e82c-41c2-a927-53b14043304e"));
		}

		#endregion

	}

	#endregion

}

