namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDuplicatesScheduledSearchParameterRepositorySchema

	/// <exclude/>
	public class IDuplicatesScheduledSearchParameterRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicatesScheduledSearchParameterRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicatesScheduledSearchParameterRepositorySchema(IDuplicatesScheduledSearchParameterRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99c0874b-e6e1-4d26-9563-bae0f7a8c6d5");
			Name = "IDuplicatesScheduledSearchParameterRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,83,205,78,194,64,16,62,67,194,59,76,240,162,137,161,119,69,14,138,49,28,48,68,120,129,237,118,74,55,46,187,205,206,22,109,140,239,238,236,182,5,148,68,131,7,189,237,76,103,190,191,73,141,216,32,149,66,34,220,46,230,75,155,251,209,157,53,185,90,87,78,120,101,205,104,138,89,85,106,37,99,53,232,191,13,250,189,51,135,107,46,96,102,60,186,156,87,175,96,54,109,135,144,150,178,224,21,141,217,18,133,147,197,66,56,102,224,193,39,44,45,41,111,93,61,232,51,72,146,36,48,166,106,179,17,174,158,180,53,143,56,36,52,158,64,128,219,205,131,183,32,164,68,162,240,42,59,64,2,155,131,47,16,168,101,132,78,41,18,80,36,31,117,68,201,1,83,89,165,60,5,170,83,127,170,248,94,200,96,23,194,28,125,97,51,186,130,69,132,141,222,142,204,197,198,93,129,242,153,162,98,177,21,74,139,84,105,229,235,224,66,236,93,253,108,10,210,154,23,168,68,169,114,133,89,215,13,11,27,1,134,97,130,237,99,223,77,39,18,197,169,155,97,179,242,200,239,225,100,21,56,143,144,66,224,92,201,231,209,56,137,155,123,32,135,190,114,134,38,43,87,33,168,83,61,188,40,95,180,98,28,230,199,122,146,9,224,171,34,79,151,96,25,202,189,40,66,200,133,38,100,37,29,117,208,146,90,171,225,1,253,140,190,156,140,238,195,254,57,121,167,204,26,246,208,23,215,223,221,200,97,84,249,11,51,25,230,162,210,30,182,66,87,252,233,15,143,244,233,54,91,171,178,214,198,180,81,244,37,151,219,122,185,67,60,49,157,41,106,60,61,157,244,63,147,104,36,255,42,130,51,52,89,243,147,115,245,30,123,135,45,238,124,0,84,109,99,135,60,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99c0874b-e6e1-4d26-9563-bae0f7a8c6d5"));
		}

		#endregion

	}

	#endregion

}

