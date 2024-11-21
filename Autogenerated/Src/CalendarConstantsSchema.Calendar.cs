namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CalendarConstantsSchema

	/// <exclude/>
	public class CalendarConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CalendarConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CalendarConstantsSchema(CalendarConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("be7f28d4-9023-4e82-8abd-f8718e729d3d");
			Name = "CalendarConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,93,107,219,48,20,125,110,32,255,65,100,47,219,131,18,89,146,109,169,221,6,250,176,182,61,20,10,237,24,236,77,75,148,96,150,200,197,146,25,97,236,191,79,78,98,218,166,161,205,24,216,24,93,221,123,142,116,207,185,246,118,227,194,189,157,59,32,111,174,111,155,101,156,170,198,47,235,85,215,218,88,55,126,170,236,218,249,133,109,195,120,244,123,60,186,232,66,237,87,224,118,27,162,219,92,141,71,41,242,166,117,171,148,8,212,218,134,112,9,238,234,141,251,234,235,152,80,66,180,62,166,186,139,244,220,119,63,214,245,28,164,80,76,159,121,159,123,50,181,231,120,128,28,54,46,193,205,174,190,223,236,223,167,104,173,179,139,198,175,183,224,83,87,47,192,112,96,109,183,225,203,2,124,0,222,253,218,237,188,157,144,66,27,130,112,5,115,33,11,72,137,64,80,84,170,132,52,87,184,228,185,102,132,235,201,187,171,115,25,174,107,223,69,119,76,66,153,164,198,112,6,43,34,13,164,38,231,80,20,202,64,204,104,69,17,163,70,98,243,15,36,159,155,174,61,166,144,37,75,36,186,191,71,197,33,197,21,134,194,16,10,149,38,66,243,170,80,188,56,135,226,91,211,254,76,106,158,104,148,212,74,74,150,113,200,37,78,141,42,112,9,57,45,12,212,8,21,52,23,88,83,148,157,79,112,186,79,68,72,74,176,40,160,18,140,38,49,178,28,74,65,8,76,23,33,170,204,153,96,6,157,207,113,170,77,9,28,177,74,151,80,103,25,131,20,97,1,57,87,8,98,147,51,130,121,86,105,92,29,24,118,174,75,253,222,27,47,173,254,236,109,251,36,246,220,236,131,72,59,163,30,156,62,155,205,192,251,208,109,54,182,221,126,60,172,135,60,48,31,28,61,29,50,103,143,82,79,13,201,51,138,255,154,144,16,219,126,126,181,91,218,110,29,251,1,252,222,120,167,154,133,75,157,155,28,133,39,47,53,255,128,36,109,112,15,71,220,195,60,142,189,136,81,251,8,6,115,248,94,193,84,93,160,215,42,246,82,251,100,219,148,142,233,254,47,116,142,122,73,211,191,221,50,112,46,238,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be7f28d4-9023-4e82-8abd-f8718e729d3d"));
		}

		#endregion

	}

	#endregion

}

