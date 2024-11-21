namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ValidateSenderDomainRequestSchema

	/// <exclude/>
	public class ValidateSenderDomainRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ValidateSenderDomainRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ValidateSenderDomainRequestSchema(ValidateSenderDomainRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f9ce81e-a5d7-4bb1-aa16-62e6c9485129");
			Name = "ValidateSenderDomainRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,193,110,194,48,12,134,207,32,241,14,22,92,182,75,123,31,219,14,3,132,118,96,66,84,218,5,113,8,173,219,69,106,147,46,118,145,24,218,187,207,73,1,1,67,147,216,165,169,29,251,207,231,63,49,170,66,170,85,138,240,50,159,37,54,231,104,100,77,174,139,198,41,214,214,68,163,73,50,179,25,150,212,235,238,122,221,78,67,218,20,144,108,137,177,26,94,196,209,162,49,172,43,140,18,116,90,149,250,43,40,72,149,212,13,28,22,18,192,168,84,68,15,240,46,219,153,98,76,208,100,232,198,182,82,218,44,240,179,65,226,80,30,199,49,60,82,83,85,202,109,159,247,113,104,133,220,58,112,109,37,176,133,205,94,8,40,40,65,22,164,162,131,68,124,162,177,28,43,86,50,28,59,149,242,74,18,117,179,46,117,10,105,208,253,147,168,35,163,203,247,56,197,220,217,26,29,107,148,81,230,65,165,221,191,196,14,137,41,50,129,80,147,95,249,3,1,69,187,4,157,161,184,149,107,116,158,246,55,110,203,59,195,106,141,238,238,77,110,9,158,160,31,90,95,179,254,189,231,63,12,48,109,116,6,147,118,7,118,80,32,15,253,97,67,248,190,133,234,204,64,186,129,137,78,28,163,115,50,98,39,207,99,185,130,83,87,233,255,140,198,31,105,243,240,95,59,187,17,15,111,113,239,208,226,227,107,160,254,94,143,5,215,40,7,50,70,251,4,66,220,102,207,147,146,251,1,13,154,174,169,83,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f9ce81e-a5d7-4bb1-aa16-62e6c9485129"));
		}

		#endregion

	}

	#endregion

}

