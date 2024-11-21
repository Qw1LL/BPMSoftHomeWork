namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMLEntityPredictorSchema

	/// <exclude/>
	public class IMLEntityPredictorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMLEntityPredictorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMLEntityPredictorSchema(IMLEntityPredictorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f591c48-2aae-4f89-af89-1090bb3a3146");
			Name = "IMLEntityPredictor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,203,106,195,48,16,60,55,144,127,88,114,106,33,216,31,208,196,208,23,197,16,67,32,233,7,40,214,58,81,107,75,102,87,106,27,74,255,189,146,29,37,14,233,33,224,131,102,53,51,154,29,172,69,131,220,138,18,225,113,89,172,76,101,147,39,163,43,181,117,36,172,50,58,41,22,227,209,207,120,116,227,88,233,45,172,246,108,177,185,63,226,147,134,48,89,146,41,145,249,220,192,115,61,59,77,83,152,177,107,26,65,251,236,128,115,109,145,170,240,114,101,8,90,66,169,202,160,0,161,37,176,248,12,254,118,135,195,27,66,118,181,5,165,1,181,85,118,159,68,235,116,224,221,186,77,173,74,79,138,246,121,177,120,233,232,203,222,201,144,103,133,157,46,98,117,131,3,139,99,14,228,107,98,92,230,232,39,173,32,209,128,246,45,207,39,141,145,88,231,114,146,173,189,95,7,64,201,96,81,41,164,100,150,118,220,255,165,253,67,81,219,163,171,197,237,49,250,27,35,173,5,127,76,178,112,2,235,143,240,165,236,110,184,29,126,91,18,208,233,249,210,151,208,58,210,156,29,90,58,213,225,169,241,46,144,205,230,29,75,27,203,124,208,114,229,155,188,125,117,74,246,155,231,114,10,29,138,155,77,161,88,60,11,43,78,198,49,236,32,220,113,52,7,237,234,250,46,252,137,191,227,145,255,254,0,177,228,9,152,200,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f591c48-2aae-4f89-af89-1090bb3a3146"));
		}

		#endregion

	}

	#endregion

}

