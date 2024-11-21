namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SessionTokenRestResponseSchema

	/// <exclude/>
	public class SessionTokenRestResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SessionTokenRestResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SessionTokenRestResponseSchema(SessionTokenRestResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6e3a15ec-b9d8-c38d-ff2f-9dd9e4d205ff");
			Name = "SessionTokenRestResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,143,65,79,195,48,12,133,207,171,212,255,96,137,123,123,7,196,129,34,113,1,81,209,253,129,172,117,75,180,54,174,98,7,132,38,254,59,110,210,177,13,196,33,145,252,108,189,247,61,103,38,228,217,180,8,247,245,115,67,189,20,21,185,222,14,193,27,177,228,138,134,90,107,198,39,52,221,35,186,60,59,228,89,158,109,174,60,14,186,132,106,52,204,215,208,32,179,142,91,218,163,123,69,22,125,51,57,198,120,91,150,37,220,114,152,38,227,63,239,214,185,26,41,116,224,215,51,120,216,190,192,135,149,55,176,174,39,63,197,96,48,59,10,2,156,172,65,22,239,226,104,87,158,249,205,97,55,218,22,218,5,229,95,18,80,200,243,34,203,174,246,244,110,59,244,39,218,77,106,247,83,79,47,102,244,98,81,59,214,49,38,237,127,87,138,194,26,125,34,253,139,122,100,101,241,214,13,23,176,112,128,1,229,70,251,234,247,181,98,160,235,18,73,156,147,122,41,170,246,13,97,105,97,208,193,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6e3a15ec-b9d8-c38d-ff2f-9dd9e4d205ff"));
		}

		#endregion

	}

	#endregion

}

