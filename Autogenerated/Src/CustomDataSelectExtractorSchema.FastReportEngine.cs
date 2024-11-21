namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CustomDataSelectExtractorSchema

	/// <exclude/>
	public class CustomDataSelectExtractorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CustomDataSelectExtractorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CustomDataSelectExtractorSchema(CustomDataSelectExtractorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d22a5d4a-7982-4321-bd97-6c4681d2eb43");
			Name = "CustomDataSelectExtractor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b2e55c4-93df-4e50-a678-d373851bda85");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,82,219,74,3,49,16,125,222,130,255,16,241,101,11,37,31,80,75,65,107,5,145,202,226,126,65,154,78,183,129,221,100,153,204,90,139,248,239,78,18,109,187,182,138,15,190,132,157,179,231,204,156,185,88,213,128,111,149,6,113,91,44,74,183,38,57,115,118,109,170,14,21,25,103,229,51,180,14,201,216,74,222,43,79,41,154,219,202,88,144,179,206,147,107,46,6,111,23,131,172,243,76,17,229,206,19,52,215,251,248,239,41,79,53,7,214,157,34,85,186,14,53,200,155,165,39,84,58,164,241,44,97,209,21,66,197,145,152,213,202,251,177,72,158,162,2,106,208,52,127,141,124,135,145,108,44,1,90,85,11,29,216,63,147,197,88,60,156,129,39,201,211,193,79,175,175,73,74,247,43,39,192,211,209,73,225,41,123,227,41,242,187,239,103,1,180,113,43,238,168,232,150,181,209,233,103,27,191,79,228,226,211,97,254,63,254,132,62,134,70,130,71,30,22,227,245,6,26,245,196,247,50,20,97,229,89,102,214,34,191,236,145,227,174,100,25,153,62,172,157,148,177,254,17,118,249,145,250,75,158,209,6,221,86,88,216,114,3,26,218,144,32,31,134,75,200,178,247,248,34,80,135,54,50,190,247,156,159,169,91,160,123,49,43,192,80,133,109,239,43,142,250,29,201,66,33,163,124,10,62,85,227,98,113,244,96,87,105,250,49,78,104,31,100,236,3,134,54,206,62,49,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d22a5d4a-7982-4321-bd97-6c4681d2eb43"));
		}

		#endregion

	}

	#endregion

}

