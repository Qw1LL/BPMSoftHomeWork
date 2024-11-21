namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PageResponseSourceCodeSchema

	/// <exclude/>
	public class PageResponseSourceCodeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PageResponseSourceCodeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PageResponseSourceCodeSchema(PageResponseSourceCodeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7282cd51-6666-41a7-9651-efa983edf92b");
			Name = "PageResponseSourceCode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,219,106,227,48,16,125,174,193,255,32,252,82,103,155,168,175,11,33,15,105,54,189,64,47,166,113,104,97,217,7,69,26,39,2,93,140,52,46,53,203,254,251,142,157,166,13,166,1,27,91,51,231,204,156,57,163,38,106,183,101,171,54,34,216,105,154,52,71,71,94,194,59,14,99,11,111,12,72,212,222,69,126,3,14,130,150,67,200,11,108,40,148,38,78,88,136,181,144,192,174,138,135,149,175,144,200,174,210,219,38,136,142,159,38,127,211,228,172,110,54,70,75,22,145,98,146,73,35,98,100,4,67,112,88,182,53,48,130,116,176,1,46,98,232,27,98,0,97,123,220,140,101,243,162,184,191,91,204,203,187,167,199,203,167,69,185,44,39,171,242,121,57,127,200,166,39,11,188,90,115,96,139,186,166,124,175,236,242,205,41,238,107,112,239,214,84,62,88,129,113,226,171,74,75,80,94,54,150,164,241,88,83,103,21,119,0,104,13,239,191,220,10,237,46,136,210,247,251,119,98,182,66,108,225,153,108,33,255,78,13,247,230,181,98,47,65,35,228,183,136,245,39,58,124,252,140,217,166,69,248,253,135,41,129,98,124,24,165,210,6,30,201,241,207,128,252,114,113,212,119,57,59,20,224,115,165,110,73,62,132,60,251,240,122,242,75,83,46,234,110,252,108,76,110,32,10,185,235,70,157,246,149,187,93,254,152,173,203,235,201,207,243,243,140,93,28,237,154,119,34,215,168,141,198,150,175,131,41,4,238,150,78,122,5,249,65,211,136,8,89,54,234,247,240,165,226,120,205,179,99,185,3,220,55,106,239,193,109,113,71,66,59,11,248,254,196,75,79,247,129,38,207,71,195,78,87,218,137,208,238,45,237,24,195,252,210,169,124,31,235,214,70,47,61,105,242,31,79,110,34,53,27,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7282cd51-6666-41a7-9651-efa983edf92b"));
		}

		#endregion

	}

	#endregion

}

