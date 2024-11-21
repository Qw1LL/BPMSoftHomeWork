namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CurrencyRateHelperSchema

	/// <exclude/>
	public class CurrencyRateHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CurrencyRateHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CurrencyRateHelperSchema(CurrencyRateHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("10302f70-95a4-407b-9a13-247da73bf707");
			Name = "CurrencyRateHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,82,77,111,219,48,12,61,39,64,254,3,161,147,140,121,114,119,110,146,195,82,180,27,208,12,65,28,236,174,120,116,98,64,31,134,62,86,164,67,255,251,36,57,114,221,97,221,105,64,140,64,228,227,123,36,31,189,237,212,9,234,139,117,40,111,23,115,63,121,178,7,161,143,92,116,207,220,117,90,133,228,98,174,184,68,219,243,6,225,243,110,91,235,214,177,141,86,109,119,242,38,97,22,243,95,139,249,172,247,71,209,53,208,8,110,45,108,188,49,168,154,203,158,59,252,130,162,71,19,16,17,53,171,170,10,150,214,75,201,205,101,157,3,15,232,44,184,51,66,227,29,72,174,92,103,45,7,221,134,247,192,3,65,9,217,88,95,253,73,176,236,185,225,18,98,163,43,18,177,100,29,165,217,178,74,137,87,156,65,231,141,178,235,205,68,104,89,229,104,132,93,231,176,46,204,22,255,76,92,77,104,48,242,109,175,21,244,7,54,157,228,34,181,85,64,26,108,150,99,173,225,77,92,11,172,82,26,62,2,245,66,171,83,17,95,183,9,250,147,27,8,11,12,8,133,79,240,205,203,35,154,123,109,36,119,95,85,171,175,124,179,33,126,55,208,214,24,39,113,218,132,34,82,146,132,120,25,216,134,238,71,93,118,208,117,234,154,6,137,130,237,177,23,193,58,74,110,74,82,2,33,69,42,122,137,190,190,227,70,29,221,24,93,112,250,191,45,127,138,203,252,100,157,151,250,190,89,251,127,57,148,215,30,186,206,76,7,29,245,233,212,164,50,59,153,117,179,107,93,11,52,186,195,14,230,178,227,198,34,205,136,18,116,56,146,152,27,139,190,115,225,177,200,165,127,115,252,13,18,42,200,77,20,91,238,206,108,167,159,232,167,155,114,68,177,71,84,39,119,30,44,9,70,198,115,89,65,130,222,11,173,13,77,247,53,201,126,88,141,98,67,52,248,248,122,1,227,129,197,104,248,194,239,55,226,12,200,90,233,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10302f70-95a4-407b-9a13-247da73bf707"));
		}

		#endregion

	}

	#endregion

}

