namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ColumnValuesIteratorSchema

	/// <exclude/>
	public class ColumnValuesIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ColumnValuesIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ColumnValuesIteratorSchema(ColumnValuesIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f924bc20-2aaa-439a-84e8-9d39b2eb7fb7");
			Name = "ColumnValuesIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,75,111,163,48,16,62,19,41,255,97,148,94,232,5,238,219,36,210,110,90,173,34,109,164,106,43,237,221,53,3,177,100,108,100,155,116,179,85,254,251,142,13,166,180,77,104,123,65,48,158,199,247,24,163,88,141,182,97,28,225,199,253,238,65,151,46,219,104,85,138,170,53,204,9,173,178,13,171,27,38,42,101,231,179,231,249,44,105,173,80,21,60,28,173,195,154,50,165,68,238,211,108,246,19,21,26,193,111,230,51,202,186,50,88,81,20,54,146,89,251,13,40,175,173,213,31,38,91,180,91,135,212,89,155,144,151,231,57,44,109,91,215,204,28,215,253,119,151,128,22,30,143,116,134,8,220,96,185,90,156,235,113,39,177,70,229,22,249,58,139,205,242,81,183,166,125,148,130,3,247,32,46,96,72,136,19,61,7,192,247,70,55,104,156,64,66,77,239,142,216,97,209,165,188,197,26,2,61,2,11,124,144,2,74,109,64,116,36,60,172,247,184,146,38,118,134,95,194,186,229,4,181,245,203,132,103,168,208,221,128,245,143,19,172,64,225,211,199,229,233,117,103,72,114,133,170,232,56,190,38,76,102,91,103,90,78,53,158,114,80,108,130,239,45,150,172,149,142,232,14,101,240,180,23,124,15,66,9,39,152,20,255,176,39,79,39,47,162,92,18,162,115,232,28,131,244,26,252,190,37,201,150,26,7,26,73,114,154,230,178,67,183,215,197,39,157,219,14,120,139,177,121,186,4,140,138,143,182,47,186,208,175,218,164,167,7,97,92,203,36,28,180,40,194,152,129,74,236,146,125,47,138,212,251,55,38,126,139,150,46,80,64,68,228,59,194,239,43,118,140,27,29,10,126,99,35,233,218,78,229,146,83,34,20,216,179,21,159,150,243,163,173,32,189,57,210,29,67,70,139,208,203,7,165,209,245,215,36,204,125,164,97,134,213,160,232,175,180,90,208,150,57,252,235,22,107,218,82,255,18,174,22,9,237,135,249,223,80,116,42,91,230,161,108,188,83,65,253,30,88,122,110,193,98,207,126,72,244,136,70,4,26,233,129,153,129,139,80,195,61,140,121,73,127,150,197,25,177,79,103,6,105,123,73,224,46,250,58,120,250,15,148,183,74,119,135,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f924bc20-2aaa-439a-84e8-9d39b2eb7fb7"));
		}

		#endregion

	}

	#endregion

}

