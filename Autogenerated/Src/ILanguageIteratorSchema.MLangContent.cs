namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ILanguageIteratorSchema

	/// <exclude/>
	public class ILanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ILanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ILanguageIteratorSchema(ILanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f45065ed-3795-44ee-a8b8-acb977312744");
			Name = "ILanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("16e592d3-2033-426b-b620-6aa2b1f8eec0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,65,106,195,48,16,60,59,144,63,44,201,165,189,216,247,212,245,161,165,24,67,3,161,121,129,108,173,93,129,189,50,43,233,96,74,254,94,201,178,211,36,244,32,193,142,102,118,102,87,36,6,52,163,104,16,222,78,199,179,110,109,250,174,169,85,157,99,97,149,166,237,230,103,187,73,156,81,212,193,121,50,22,135,151,135,218,243,251,30,155,64,54,105,137,132,172,26,207,241,172,61,99,231,81,168,200,34,183,222,226,0,213,167,160,206,137,14,43,15,9,171,121,38,102,89,6,185,113,195,32,120,42,150,250,11,71,70,131,100,13,8,2,181,208,161,245,167,87,198,6,255,122,130,126,105,103,210,181,77,118,211,103,116,117,175,26,80,171,255,127,246,137,159,207,223,215,176,71,180,223,90,154,3,156,102,113,124,124,12,152,4,160,68,159,237,26,0,144,220,16,155,134,44,51,227,46,76,68,70,193,98,0,242,75,127,221,49,54,154,101,37,119,197,7,89,101,39,136,0,40,233,199,86,173,66,78,243,108,22,252,233,25,173,99,50,94,177,186,129,110,111,214,144,103,43,35,72,170,133,86,247,152,151,78,201,34,132,94,119,96,158,2,180,152,86,242,57,126,90,178,71,146,113,23,115,125,137,95,121,7,94,126,1,5,88,3,150,53,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f45065ed-3795-44ee-a8b8-acb977312744"));
		}

		#endregion

	}

	#endregion

}

