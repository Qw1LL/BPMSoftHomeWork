namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MLModelListenerSchema

	/// <exclude/>
	public class MLModelListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MLModelListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MLModelListenerSchema(MLModelListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c04a9621-1ecc-4eff-a2d5-eca6fc6ea020");
			Name = "MLModelListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,84,81,107,219,48,16,126,118,161,255,225,112,31,106,195,144,223,179,36,144,166,133,65,227,46,44,221,211,232,131,34,159,19,13,91,50,146,28,8,99,255,125,103,201,46,115,150,118,163,111,101,47,134,59,221,119,119,223,167,79,86,188,70,219,112,129,112,179,206,55,186,116,108,169,85,41,119,173,225,78,106,197,242,213,229,197,143,203,139,168,181,82,237,126,171,49,248,241,108,150,221,41,39,157,68,251,151,99,118,119,64,229,186,42,170,187,50,184,163,97,176,172,184,181,19,200,87,185,46,176,90,73,235,80,161,241,37,89,150,193,212,182,117,205,205,113,222,199,67,1,148,218,192,117,143,186,6,234,43,221,17,208,15,96,3,54,59,1,79,45,34,175,172,6,97,176,156,197,175,45,201,110,184,69,159,59,250,196,48,55,134,172,235,246,237,204,81,178,17,123,172,249,3,169,11,51,136,251,221,226,244,137,234,155,118,91,73,1,162,35,123,202,21,38,240,194,48,2,210,61,208,247,89,173,28,221,94,23,164,215,218,55,12,135,167,58,249,196,39,174,138,10,237,160,204,134,31,176,8,250,116,242,252,169,79,200,52,220,240,26,20,81,152,197,22,85,65,132,231,126,37,8,17,155,102,190,228,60,2,227,249,227,30,189,204,189,196,143,147,23,68,246,91,45,74,135,198,183,95,152,157,237,164,5,169,172,227,138,172,41,180,114,92,170,206,76,110,143,195,56,79,0,10,238,248,104,147,94,94,125,64,99,100,129,112,208,178,128,207,202,147,78,244,246,59,138,129,192,7,56,55,26,48,133,206,241,81,180,165,155,96,3,114,128,96,218,57,59,138,190,90,52,244,84,20,181,235,46,163,29,135,51,72,146,208,60,13,192,148,141,1,161,201,24,197,22,77,67,171,251,135,183,228,100,32,246,5,107,226,145,228,43,42,178,100,196,181,193,66,10,199,183,21,14,242,109,132,145,141,187,199,99,216,235,231,191,219,224,22,43,116,255,159,17,122,218,111,178,194,109,143,125,95,102,184,162,161,225,159,225,227,144,29,39,41,247,11,146,47,100,28,10,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c04a9621-1ecc-4eff-a2d5-eca6fc6ea020"));
		}

		#endregion

	}

	#endregion

}

