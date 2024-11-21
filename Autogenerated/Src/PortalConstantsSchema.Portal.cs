namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PortalConstantsSchema

	/// <exclude/>
	public class PortalConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalConstantsSchema(PortalConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0d4ff333-6c25-49dc-97f3-5f38c4c7f52d");
			Name = "PortalConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b54a206c-0c3a-4346-bc7a-d3b009155be5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,65,107,27,49,16,133,207,49,248,63,44,57,181,135,105,36,173,100,73,132,30,36,173,84,122,48,49,113,115,42,61,168,107,217,94,88,107,205,174,150,96,74,255,123,229,56,33,117,2,109,32,160,147,120,51,239,155,55,51,14,77,220,20,203,195,144,194,238,122,58,153,78,162,223,133,97,239,235,80,232,197,124,217,173,211,39,211,197,117,179,25,123,159,154,46,78,39,191,166,147,139,253,248,179,109,234,98,72,249,175,46,234,214,15,67,177,232,250,228,219,44,206,191,49,13,89,117,84,94,92,93,125,207,221,109,76,77,58,44,235,109,216,249,219,80,223,54,155,109,90,118,99,95,135,31,71,209,121,191,62,248,85,23,219,67,241,101,108,86,197,63,171,111,238,99,232,139,207,69,12,247,15,234,15,151,179,153,85,152,59,14,149,195,21,80,196,4,72,108,20,32,169,8,98,188,178,202,138,203,143,215,239,114,85,99,218,118,231,182,148,16,100,156,206,62,12,83,160,212,88,80,85,133,0,35,169,25,213,140,32,65,223,107,59,247,113,244,109,150,254,109,44,20,161,66,161,18,172,84,236,56,52,6,41,133,4,42,152,46,165,193,130,114,244,94,227,42,172,253,216,166,51,95,71,177,69,100,38,192,150,36,15,76,72,206,217,74,11,204,104,110,140,68,179,82,62,229,252,124,6,243,110,53,182,111,90,249,73,121,186,169,185,111,226,194,111,194,215,213,25,1,150,210,112,73,13,96,234,44,80,77,8,40,140,21,16,100,101,134,43,41,19,213,43,2,181,218,53,241,46,54,233,45,16,234,73,172,218,246,132,114,55,132,126,120,193,193,9,210,156,99,3,150,43,14,212,149,121,3,249,20,128,17,83,17,108,74,94,74,247,192,241,72,241,56,84,24,134,60,211,183,195,254,255,121,188,170,48,221,110,223,230,84,210,11,20,198,74,35,181,114,160,73,206,133,26,196,65,151,130,129,162,142,42,49,115,198,81,242,28,201,239,233,36,191,63,175,243,46,105,2,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0d4ff333-6c25-49dc-97f3-5f38c4c7f52d"));
		}

		#endregion

	}

	#endregion

}

