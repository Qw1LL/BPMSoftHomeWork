namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CaseTimeZoneMacrosConverterSchema

	/// <exclude/>
	public class CaseTimeZoneMacrosConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CaseTimeZoneMacrosConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CaseTimeZoneMacrosConverterSchema(CaseTimeZoneMacrosConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("def50b48-4f91-4a9d-ab1b-2977e4e375ae");
			Name = "CaseTimeZoneMacrosConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,193,110,219,48,12,61,187,64,255,129,240,46,14,16,216,247,44,49,176,102,109,225,67,134,162,93,47,187,169,50,157,10,136,37,131,146,59,100,67,255,125,148,100,39,117,26,100,23,195,164,30,31,31,31,37,45,90,180,157,144,8,55,15,155,39,211,184,124,109,116,163,182,61,9,167,140,190,190,250,123,125,149,244,86,233,45,60,237,173,195,246,235,33,62,22,16,158,207,230,119,66,58,67,10,45,159,51,226,11,225,150,73,97,189,19,214,46,96,45,44,254,84,45,254,50,26,55,66,146,177,220,251,13,201,33,5,120,81,20,176,180,125,219,10,218,151,67,252,136,29,161,69,237,44,200,17,12,141,33,248,46,92,32,131,214,51,73,180,160,116,232,0,12,86,110,159,143,132,197,7,198,174,127,217,41,9,210,235,185,36,103,1,55,151,180,38,108,18,127,143,243,25,109,29,245,126,118,30,243,33,52,137,136,211,145,66,162,210,202,41,177,83,127,88,180,198,223,44,220,58,161,121,37,166,97,48,34,72,194,102,149,94,208,151,22,101,28,194,79,249,121,204,152,233,4,137,22,52,47,124,149,246,22,137,171,53,74,191,229,180,124,230,216,27,58,36,242,101,17,208,231,139,173,124,197,86,252,224,255,180,188,13,230,66,76,133,243,73,237,96,240,5,233,217,243,68,10,76,149,205,129,141,244,215,234,216,115,230,121,147,5,188,48,103,246,9,125,132,129,191,185,201,251,176,25,212,117,92,206,116,83,27,116,175,166,246,75,34,227,152,4,235,120,222,141,33,24,150,73,170,70,24,245,87,186,49,112,143,110,140,179,251,94,213,195,37,123,68,105,168,174,234,161,121,82,141,32,166,127,99,18,90,122,39,74,96,250,16,194,42,190,133,248,78,246,57,211,6,196,105,89,153,5,186,196,223,142,15,151,235,27,109,251,150,59,103,167,251,156,195,212,213,217,252,63,245,146,155,86,53,215,157,204,17,202,102,254,117,39,9,161,235,73,31,180,123,177,7,15,34,228,188,217,49,59,77,190,255,3,100,35,63,176,120,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("def50b48-4f91-4a9d-ab1b-2977e4e375ae"));
		}

		#endregion

	}

	#endregion

}

