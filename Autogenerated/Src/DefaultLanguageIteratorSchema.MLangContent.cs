namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DefaultLanguageIteratorSchema

	/// <exclude/>
	public class DefaultLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DefaultLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DefaultLanguageIteratorSchema(DefaultLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aeeb29af-e2e5-4dd2-b9f3-3255567cf2c9");
			Name = "DefaultLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2659875a-4670-491c-9c1f-f4641a7bae64");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,147,77,111,194,48,12,134,207,69,226,63,88,229,2,82,69,239,12,122,128,93,144,182,9,13,113,154,118,200,130,91,34,181,73,149,143,77,219,196,127,159,147,6,65,199,216,165,74,156,215,246,227,55,169,100,13,154,150,113,132,229,230,113,171,74,59,93,41,89,138,202,105,102,133,146,195,193,247,112,144,56,35,100,117,33,208,120,55,28,80,124,164,177,34,17,172,106,102,204,12,238,177,100,174,182,15,76,86,142,85,184,182,72,69,148,14,210,60,207,97,110,92,211,48,253,89,196,125,212,67,29,19,64,196,140,12,236,129,89,104,181,122,23,123,60,159,151,90,53,192,149,180,140,219,78,98,208,130,144,96,248,1,27,54,61,245,201,47,26,181,238,173,22,28,184,71,188,69,8,51,88,50,131,215,224,137,159,254,60,166,146,198,106,199,233,136,166,221,132,194,97,184,171,233,66,96,45,133,21,172,22,95,104,64,226,7,113,26,203,36,57,173,74,18,35,2,215,88,46,210,27,76,105,94,248,121,174,7,234,34,45,211,172,1,73,183,183,72,157,65,77,108,18,185,191,178,180,216,209,222,219,20,3,211,121,30,212,127,39,119,214,61,209,58,45,182,97,157,117,22,19,174,159,216,123,221,171,16,13,189,129,61,222,245,96,160,207,150,1,25,232,223,210,185,235,196,215,76,102,240,70,23,48,238,171,39,16,236,79,78,61,158,93,77,86,46,130,153,235,203,224,203,107,84,38,254,40,146,69,246,75,221,47,56,162,57,99,100,87,5,254,201,236,160,143,244,23,208,183,123,2,35,148,251,238,157,132,125,23,237,7,143,63,32,86,180,179,109,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aeeb29af-e2e5-4dd2-b9f3-3255567cf2c9"));
		}

		#endregion

	}

	#endregion

}

