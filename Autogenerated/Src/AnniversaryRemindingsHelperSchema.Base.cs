namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AnniversaryRemindingsHelperSchema

	/// <exclude/>
	public class AnniversaryRemindingsHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AnniversaryRemindingsHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AnniversaryRemindingsHelperSchema(AnniversaryRemindingsHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f3683174-bd15-44f4-9f35-a742936c5d37");
			Name = "AnniversaryRemindingsHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7094e60e-83c9-4747-8d9c-40b7b1b1c58b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,219,74,195,64,16,125,78,160,255,48,228,41,197,176,249,0,107,192,86,193,8,94,104,252,129,109,58,109,87,146,73,220,139,82,196,127,119,178,169,109,10,177,176,55,206,156,115,152,179,187,36,107,52,173,44,17,230,175,79,69,179,177,98,209,208,70,109,157,150,86,53,52,9,191,39,97,224,140,162,237,128,160,81,220,205,175,39,33,151,90,183,170,84,9,198,50,189,132,178,146,198,192,45,145,250,68,109,164,222,47,177,86,180,102,181,121,192,170,69,205,138,206,48,232,102,154,166,48,51,174,174,153,151,253,1,75,180,78,147,1,131,21,150,22,190,148,221,193,123,163,8,90,169,185,85,203,182,226,40,246,24,16,227,55,81,47,136,178,194,239,98,150,250,98,54,206,45,119,88,203,103,62,71,217,194,105,141,100,161,199,60,225,178,88,158,210,21,3,159,65,232,203,94,233,48,242,249,245,21,125,232,71,206,251,38,87,21,198,7,160,207,150,48,77,119,15,113,106,255,8,141,54,53,5,127,215,65,47,23,157,109,236,189,247,45,138,156,8,117,242,143,208,203,2,241,66,241,104,61,129,40,95,71,83,145,155,251,15,39,171,120,216,208,168,0,174,122,5,255,25,246,213,254,141,15,169,60,244,195,11,79,30,191,61,98,158,10,144,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3683174-bd15-44f4-9f35-a742936c5d37"));
		}

		#endregion

	}

	#endregion

}

