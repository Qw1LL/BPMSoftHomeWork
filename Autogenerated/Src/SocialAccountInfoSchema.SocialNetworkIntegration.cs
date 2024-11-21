namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SocialAccountInfoSchema

	/// <exclude/>
	public class SocialAccountInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SocialAccountInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SocialAccountInfoSchema(SocialAccountInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f043ea0-5608-4609-9088-37f2047f71ad");
			Name = "SocialAccountInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,207,106,131,64,16,198,207,6,242,14,75,122,73,46,62,64,75,15,109,10,37,208,20,169,233,169,228,176,174,163,44,232,174,236,159,67,90,124,247,142,59,182,141,198,18,188,136,251,237,55,223,140,191,81,241,26,108,195,5,176,199,100,159,234,194,197,91,173,10,89,122,195,157,212,42,78,181,144,188,90,46,190,150,139,200,91,169,74,150,158,172,131,250,110,116,142,223,188,114,178,134,56,5,131,5,242,51,148,163,11,125,55,6,74,60,176,109,197,173,189,101,20,249,32,132,198,146,157,42,116,48,125,60,113,199,177,183,51,92,184,35,10,141,207,42,41,152,232,138,166,106,34,28,9,159,127,233,90,89,103,188,112,218,96,147,36,84,147,163,79,186,200,88,15,20,102,207,79,27,214,125,113,20,189,232,82,42,118,63,188,140,131,218,33,136,34,106,116,225,32,153,44,212,102,151,95,152,126,46,200,118,56,53,48,97,34,153,44,239,22,204,132,133,228,96,105,123,40,160,114,226,50,132,148,24,221,128,113,18,70,136,2,253,61,212,25,152,245,43,254,18,216,98,229,67,234,106,115,60,99,248,236,101,206,250,41,8,80,9,142,102,179,253,75,251,127,98,213,97,27,6,226,202,186,159,136,48,207,79,116,1,206,196,140,7,130,57,63,145,200,142,51,251,49,127,55,57,63,87,90,226,61,204,205,180,174,250,69,92,201,28,109,148,212,161,216,126,3,38,74,227,57,205,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f043ea0-5608-4609-9088-37f2047f71ad"));
		}

		#endregion

	}

	#endregion

}

