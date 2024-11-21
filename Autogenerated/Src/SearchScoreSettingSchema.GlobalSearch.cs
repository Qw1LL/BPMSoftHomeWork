namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SearchScoreSettingSchema

	/// <exclude/>
	public class SearchScoreSettingSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SearchScoreSettingSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SearchScoreSettingSchema(SearchScoreSettingSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f808b42-28b6-4954-82ef-e995b5076254");
			Name = "SearchScoreSetting";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6f142301-7a5f-41f6-815b-40f61aa5d442");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,81,189,106,195,48,16,158,109,240,59,28,153,90,40,246,3,52,205,208,95,40,52,132,106,232,80,58,168,234,217,17,200,146,209,157,9,166,228,221,123,178,157,210,16,58,100,16,210,221,119,223,143,36,175,91,164,78,27,132,219,205,139,10,53,151,119,193,215,182,233,163,102,27,60,124,23,121,145,103,61,89,223,128,26,136,177,149,1,231,208,36,148,202,39,244,24,173,185,254,157,89,227,142,5,72,66,207,20,188,0,2,85,85,5,75,234,219,86,199,97,53,215,175,216,69,36,244,76,128,78,19,91,3,132,58,154,45,144,9,17,165,96,22,65,42,15,252,234,143,64,215,127,58,33,24,33,18,168,145,166,18,75,77,36,153,144,220,217,137,239,216,120,240,108,121,128,29,218,102,203,73,253,84,62,123,79,217,55,49,116,24,121,184,56,28,214,242,86,112,3,139,137,186,184,252,72,163,115,20,235,25,222,198,126,122,139,236,95,247,71,139,238,139,142,110,119,182,127,61,106,28,251,223,219,241,71,68,96,73,28,69,250,10,166,125,53,91,166,88,123,89,69,190,255,1,80,90,226,38,244,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f808b42-28b6-4954-82ef-e995b5076254"));
		}

		#endregion

	}

	#endregion

}

