namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TermCalculationServiceUtilitiesSchema

	/// <exclude/>
	public class TermCalculationServiceUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TermCalculationServiceUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TermCalculationServiceUtilitiesSchema(TermCalculationServiceUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("609e8015-fad5-45e5-8005-deb9093949ca");
			Name = "TermCalculationServiceUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d862795b-510a-489d-988e-e22493fe3a79");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,148,77,79,195,48,12,134,207,157,180,255,96,105,103,202,29,16,8,134,132,118,64,154,214,221,16,135,44,243,166,136,54,41,249,64,26,19,255,29,39,93,215,82,198,186,22,232,161,77,220,196,126,98,191,177,100,25,154,156,113,132,187,233,99,162,86,54,30,43,185,18,107,167,153,21,74,198,115,212,217,152,165,220,165,97,158,160,126,19,28,135,131,237,112,48,28,68,206,8,185,134,100,99,44,102,151,141,121,60,115,210,138,12,99,218,35,88,42,222,131,3,90,69,235,70,26,215,52,129,113,202,140,185,128,157,87,31,107,134,175,14,141,13,171,206,233,129,43,227,178,140,233,205,117,97,128,145,127,138,119,245,13,131,120,183,226,234,188,182,229,233,158,89,70,71,178,154,113,251,76,134,220,45,82,193,33,103,218,18,21,112,79,112,16,32,42,142,184,103,157,106,149,35,109,66,2,158,6,39,197,255,38,100,69,25,136,190,35,21,76,143,152,45,80,123,162,18,233,193,137,101,73,50,161,4,78,150,176,5,255,63,90,163,245,217,141,34,179,27,124,248,87,75,240,126,241,167,90,40,45,236,230,120,240,163,161,171,248,93,9,140,213,94,63,51,74,56,13,131,94,230,164,160,54,146,17,202,101,81,164,48,47,172,117,99,212,148,28,52,52,103,114,37,13,169,186,84,80,67,115,183,133,76,206,56,233,136,9,137,26,86,74,131,70,146,148,119,233,85,14,76,46,193,168,212,237,45,157,228,120,64,134,37,211,207,58,132,19,132,56,171,67,118,171,6,89,209,167,255,102,239,164,173,24,71,52,153,52,83,211,135,163,116,242,63,162,184,160,115,102,84,94,51,23,252,197,84,125,224,244,54,84,251,126,233,76,163,30,90,56,204,178,109,235,72,45,45,1,122,95,202,68,57,205,177,172,69,239,230,80,203,82,55,140,84,133,206,80,37,229,47,16,58,83,44,148,74,97,66,5,217,95,245,95,80,244,106,208,99,102,176,189,57,127,17,250,65,237,147,241,19,182,227,69,23,252,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("609e8015-fad5-45e5-8005-deb9093949ca"));
		}

		#endregion

	}

	#endregion

}

