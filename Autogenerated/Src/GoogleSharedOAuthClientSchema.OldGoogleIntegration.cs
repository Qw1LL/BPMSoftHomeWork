namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GoogleSharedOAuthClientSchema

	/// <exclude/>
	public class GoogleSharedOAuthClientSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleSharedOAuthClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleSharedOAuthClientSchema(GoogleSharedOAuthClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b6e2a4fc-fe7f-4b18-9691-d148df804de7");
			Name = "GoogleSharedOAuthClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,75,75,195,64,16,62,71,240,63,12,241,146,66,73,238,218,22,108,69,17,124,97,241,36,30,214,100,146,46,164,187,97,118,87,17,241,191,59,187,105,53,105,27,15,30,242,216,121,124,51,223,55,179,74,172,209,52,34,71,152,63,220,46,117,105,211,133,86,165,172,28,9,43,181,58,62,250,60,62,138,156,145,170,234,4,16,158,29,180,166,151,34,183,154,36,154,125,255,82,231,82,212,233,253,185,179,43,246,178,255,132,176,226,18,176,168,133,49,167,112,165,117,85,227,114,37,8,139,16,181,168,37,42,27,66,179,44,131,137,113,235,181,160,143,217,230,252,136,13,161,225,8,3,66,109,178,33,36,66,30,50,161,212,4,38,224,65,213,186,69,211,212,50,15,204,210,45,108,214,193,125,190,192,82,184,218,206,165,42,184,249,196,126,52,168,203,164,211,206,104,12,119,44,25,76,33,30,104,56,30,189,48,82,227,94,185,18,119,194,220,134,168,193,150,116,143,110,196,138,243,251,87,30,173,140,37,231,133,101,149,30,2,110,27,177,171,74,48,116,194,61,197,125,142,173,165,17,36,214,160,152,202,52,118,6,233,70,87,82,197,179,73,22,28,33,110,67,97,160,249,132,171,248,249,254,36,143,225,137,127,185,188,194,220,11,28,60,191,199,145,135,140,78,225,85,24,76,58,73,59,81,224,247,45,250,218,72,128,170,104,85,232,75,114,139,118,165,11,175,6,105,203,137,88,252,33,200,35,90,71,138,151,132,91,231,190,253,248,121,47,252,110,240,249,127,123,51,36,42,181,165,102,19,131,8,57,97,57,141,15,173,127,122,29,62,254,249,105,40,206,102,32,121,114,66,229,152,78,178,45,82,152,195,150,36,232,55,36,146,5,194,1,0,184,66,219,51,36,127,143,163,21,58,106,11,129,194,247,253,65,247,225,118,242,253,13,31,152,83,107,237,27,217,246,13,19,93,243,127,107,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b6e2a4fc-fe7f-4b18-9691-d148df804de7"));
		}

		#endregion

	}

	#endregion

}

