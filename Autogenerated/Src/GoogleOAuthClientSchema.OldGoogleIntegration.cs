namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GoogleOAuthClientSchema

	/// <exclude/>
	public class GoogleOAuthClientSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleOAuthClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleOAuthClientSchema(GoogleOAuthClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d3c16520-2979-4ffd-92ac-fac71311fb0b");
			Name = "GoogleOAuthClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("50cc600a-f6aa-433b-8a0a-6a453519907c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,201,106,195,48,16,61,39,144,127,24,124,114,32,216,247,212,49,52,41,13,133,110,36,244,84,122,80,148,177,43,176,37,163,165,37,148,254,123,71,202,82,55,118,232,65,200,179,188,55,51,111,44,201,106,52,13,227,8,243,231,135,181,42,108,178,80,178,16,165,211,204,10,37,71,195,175,209,112,224,140,144,101,43,65,227,85,175,55,185,101,220,42,45,208,116,227,107,197,5,171,146,167,107,103,223,41,74,241,52,77,33,51,174,174,153,222,229,7,123,133,141,70,131,210,26,96,18,150,74,149,21,66,192,0,175,4,249,147,35,48,109,33,95,111,176,96,174,178,115,33,183,84,51,182,187,6,85,17,7,220,34,192,198,19,120,164,73,97,6,209,158,180,21,139,198,111,196,209,184,77,37,56,85,97,198,64,39,7,166,208,178,40,221,203,210,153,32,56,72,63,99,181,243,66,248,102,187,221,238,61,13,211,172,6,73,77,205,34,103,80,223,171,82,200,40,207,210,16,8,121,135,150,58,205,196,196,239,165,61,193,38,240,66,159,84,88,34,247,91,11,145,95,115,12,158,109,48,133,13,51,24,183,80,231,105,97,168,239,176,156,254,217,86,104,157,150,180,27,234,133,26,17,156,209,148,80,208,33,251,210,186,46,41,160,247,100,121,102,16,129,107,44,102,81,223,207,146,220,133,203,159,83,201,40,205,65,144,204,76,114,76,178,244,200,20,68,211,202,210,60,184,5,245,129,90,139,45,66,15,1,44,209,254,113,196,255,40,24,164,25,236,11,129,196,207,246,86,254,18,157,33,253,75,240,154,250,67,215,15,52,85,198,25,112,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d3c16520-2979-4ffd-92ac-fac71311fb0b"));
		}

		#endregion

	}

	#endregion

}

