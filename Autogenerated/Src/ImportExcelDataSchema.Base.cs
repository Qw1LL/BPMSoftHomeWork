namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportExcelDataSchema

	/// <exclude/>
	public class ImportExcelDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportExcelDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportExcelDataSchema(ImportExcelDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f0c56b32-3373-4f0c-9885-a983759de99d");
			Name = "ImportExcelData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("380e5823-e58a-46ec-aacb-19be835fa110");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,203,106,195,48,16,69,215,14,244,31,134,100,211,110,236,189,211,118,81,55,20,67,18,2,105,215,69,177,39,66,84,150,140,52,46,49,33,255,94,73,126,144,166,180,169,193,178,30,119,174,102,142,71,177,10,109,205,10,132,167,205,106,171,247,20,103,90,237,5,111,12,35,161,85,156,87,181,54,180,56,20,40,159,25,177,155,201,241,102,18,53,86,40,14,219,214,18,86,243,113,205,165,222,49,153,166,153,174,42,23,185,212,156,187,109,119,238,20,51,131,220,217,65,38,153,181,41,116,174,153,150,77,165,182,72,78,22,84,73,146,192,189,109,170,138,153,246,177,95,207,250,103,156,156,47,250,47,156,237,132,84,227,193,44,57,115,171,155,157,20,5,20,62,133,78,214,37,208,21,236,4,190,180,65,37,20,65,174,74,60,192,17,56,210,28,172,31,78,103,10,75,198,87,157,177,218,131,186,38,91,40,18,212,118,23,174,29,243,95,245,59,173,37,228,118,169,245,71,83,191,182,245,21,229,26,177,236,104,254,208,157,58,242,168,202,127,193,191,248,69,1,208,27,9,41,72,160,13,138,177,34,70,223,57,142,50,24,40,14,102,27,163,107,52,254,40,133,77,8,15,78,81,109,196,39,35,28,188,12,178,82,43,217,66,238,186,6,222,165,27,30,192,77,87,76,49,142,38,126,65,242,237,132,230,118,26,46,156,222,117,109,117,145,82,136,246,111,200,33,114,56,250,89,100,144,26,163,130,179,111,216,200,195,9,67,72,118,68,244,7,181,75,30,167,47,254,139,178,227,58,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f0c56b32-3373-4f0c-9885-a983759de99d"));
		}

		#endregion

	}

	#endregion

}

