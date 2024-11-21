namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ValidateSenderRequestSchema

	/// <exclude/>
	public class ValidateSenderRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ValidateSenderRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ValidateSenderRequestSchema(ValidateSenderRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("efc01930-33c9-4ec2-8ddf-662cdd8b0a08");
			Name = "ValidateSenderRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,77,79,2,49,16,61,75,194,127,152,224,65,189,236,222,249,58,128,132,152,136,217,176,198,139,241,80,150,1,155,116,91,236,180,36,72,252,239,78,187,128,97,193,175,203,110,102,250,222,235,188,55,213,162,68,90,137,2,97,144,77,114,179,112,201,208,232,133,92,122,43,156,52,58,25,142,242,137,153,163,162,102,99,219,108,92,120,146,122,9,249,134,28,150,140,84,10,139,0,163,100,140,26,173,44,58,117,204,212,107,39,75,76,114,62,21,74,190,71,85,70,49,238,210,226,146,11,24,42,65,212,134,39,62,158,11,135,57,234,57,218,41,190,121,36,23,129,105,154,66,151,124,89,10,187,233,239,234,72,130,133,177,96,43,36,56,3,235,157,4,80,212,184,34,192,82,72,69,201,94,36,173,169,116,9,81,40,50,80,88,92,244,90,191,68,144,12,4,241,120,118,45,11,220,205,215,130,52,104,61,223,10,39,152,229,172,40,220,11,55,86,126,166,100,1,69,156,242,172,51,104,195,169,28,51,57,101,254,30,194,201,172,89,161,117,18,57,161,44,138,86,231,245,76,98,99,140,142,128,35,161,240,119,175,88,217,7,37,201,133,8,78,51,168,58,28,155,199,67,249,248,29,239,11,22,237,78,176,156,161,189,126,224,7,4,61,104,69,202,61,51,90,55,33,128,125,2,119,35,237,75,180,98,166,176,75,206,242,203,232,195,104,15,133,45,44,209,117,194,188,29,248,8,172,191,91,27,229,25,104,190,251,127,198,206,176,126,182,181,178,102,45,121,107,161,62,118,86,185,9,11,58,0,234,126,226,34,121,233,213,46,99,93,117,143,155,220,251,4,189,232,198,152,135,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("efc01930-33c9-4ec2-8ddf-662cdd8b0a08"));
		}

		#endregion

	}

	#endregion

}

