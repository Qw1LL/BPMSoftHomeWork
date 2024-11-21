namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AuthenticationResultSchema

	/// <exclude/>
	public class AuthenticationResultSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AuthenticationResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AuthenticationResultSchema(AuthenticationResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16a1ffba-730d-4792-8d1d-f8f8fb57e8df");
			Name = "AuthenticationResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("48c79191-1a42-4c6e-9843-1938fdf8bec4");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,205,138,194,48,16,199,207,45,244,29,6,188,219,187,138,224,186,87,161,232,19,196,56,205,6,218,36,204,36,7,17,223,221,52,81,177,82,221,75,96,38,255,143,95,98,68,143,236,132,68,248,105,118,7,219,250,249,214,154,86,171,64,194,107,107,170,242,82,149,85,89,204,8,85,28,97,219,9,230,5,108,130,255,67,227,181,76,162,61,114,232,124,210,213,117,13,43,14,125,47,232,188,190,207,123,116,132,28,229,12,114,176,131,109,33,218,65,140,66,128,82,202,252,17,82,191,164,184,112,236,180,188,187,167,187,139,204,249,4,109,200,58,36,175,49,210,54,201,158,239,223,1,139,76,56,132,76,115,13,64,73,52,34,122,32,29,173,237,224,16,164,196,72,118,1,133,126,9,60,28,215,47,117,191,200,146,180,75,175,254,239,47,62,87,179,39,109,20,236,98,179,80,56,85,62,67,115,202,223,145,230,188,29,47,227,238,6,126,165,48,230,2,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16a1ffba-730d-4792-8d1d-f8f8fb57e8df"));
		}

		#endregion

	}

	#endregion

}

