namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CaseLanguageIteratorSchema

	/// <exclude/>
	public class CaseLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CaseLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CaseLanguageIteratorSchema(CaseLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2765b5d5-b370-4bb8-88bf-c51f5ee29ecf");
			Name = "CaseLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,77,107,194,64,16,61,71,240,63,12,233,69,65,146,187,85,15,218,139,80,65,20,79,165,135,117,59,9,11,155,221,176,31,180,182,248,223,59,187,70,77,109,232,199,33,11,59,243,222,155,55,179,19,197,42,180,53,227,8,243,245,106,171,11,151,45,180,42,68,233,13,115,66,171,126,239,163,223,75,188,21,170,108,1,12,222,247,123,20,191,51,88,18,8,22,146,89,59,134,5,179,248,200,84,233,89,137,75,135,164,160,77,196,229,121,14,19,235,171,138,153,195,172,185,159,1,80,208,39,133,117,161,196,254,0,156,68,64,54,42,54,59,179,243,22,189,246,123,41,56,240,80,181,179,40,140,97,222,233,37,9,221,92,109,107,101,157,241,156,82,228,126,29,85,163,223,111,134,79,142,149,112,130,73,241,142,22,20,190,130,32,54,83,52,57,93,16,24,17,184,193,98,154,118,25,74,243,89,6,23,225,118,47,167,72,205,12,171,64,209,91,76,83,111,209,144,51,133,60,60,64,58,219,209,29,248,37,144,77,242,136,142,228,102,18,93,37,7,187,47,58,240,85,118,24,216,201,24,246,196,28,220,164,32,14,41,57,11,110,188,164,134,167,177,229,101,59,248,244,220,32,147,144,90,49,33,231,250,45,88,217,208,120,105,176,113,129,218,132,27,75,195,209,149,253,128,5,243,210,81,210,49,238,126,32,141,32,14,56,109,147,155,210,127,47,181,245,117,173,141,251,23,39,216,251,29,125,164,31,131,206,176,69,113,211,80,189,156,150,45,222,99,252,38,120,252,4,29,173,165,180,130,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2765b5d5-b370-4bb8-88bf-c51f5ee29ecf"));
		}

		#endregion

	}

	#endregion

}

