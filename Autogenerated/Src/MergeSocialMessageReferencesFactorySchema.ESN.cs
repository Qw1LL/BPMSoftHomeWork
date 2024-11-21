namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MergeSocialMessageReferencesFactorySchema

	/// <exclude/>
	public class MergeSocialMessageReferencesFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MergeSocialMessageReferencesFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MergeSocialMessageReferencesFactorySchema(MergeSocialMessageReferencesFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e48291b4-a733-42d9-a644-93ba7e513590");
			Name = "MergeSocialMessageReferencesFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,75,3,49,16,61,87,240,63,12,219,131,45,148,221,187,182,61,104,91,17,172,136,61,138,72,204,206,110,3,187,201,146,201,86,22,233,127,119,54,177,31,139,45,244,50,33,201,203,203,123,111,70,139,18,169,18,18,225,254,117,185,50,153,139,31,140,206,84,94,91,225,148,209,241,124,245,114,125,245,115,125,213,171,73,233,28,86,13,57,44,25,83,20,40,91,0,197,143,168,209,42,121,183,199,156,38,154,97,90,87,133,146,126,119,10,108,49,94,8,233,140,85,72,124,207,136,190,197,156,193,176,68,155,227,202,72,37,138,37,18,137,28,223,48,67,139,90,34,133,39,141,199,39,73,2,99,170,203,82,216,102,250,183,127,181,102,163,82,36,32,255,30,202,64,112,67,32,242,156,249,133,67,176,123,182,24,118,52,201,17,207,251,12,51,81,23,238,94,233,148,53,15,92,83,161,201,6,79,94,215,63,41,195,17,188,112,168,48,129,232,2,225,209,240,131,127,168,234,47,142,6,100,33,136,46,177,11,183,112,230,119,38,227,110,113,221,167,183,80,88,164,116,203,73,168,13,187,13,151,85,216,0,57,238,135,228,4,68,106,116,209,64,151,244,208,102,248,60,132,196,206,52,126,159,135,182,211,210,107,85,112,237,69,29,35,209,200,63,125,86,228,198,228,44,135,57,253,131,51,114,174,157,114,205,83,26,133,131,173,95,124,221,134,121,232,245,81,167,193,85,215,226,18,221,218,120,143,62,199,112,233,219,168,244,154,135,211,165,70,38,109,39,119,65,159,213,254,136,238,16,233,32,72,4,146,107,44,69,219,212,33,76,166,199,81,156,214,197,154,219,233,237,28,110,127,1,107,149,118,124,105,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e48291b4-a733-42d9-a644-93ba7e513590"));
		}

		#endregion

	}

	#endregion

}

