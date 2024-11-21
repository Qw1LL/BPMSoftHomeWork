namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: WebHookTypesSchema

	/// <exclude/>
	public class WebHookTypesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebHookTypesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebHookTypesSchema(WebHookTypesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3d2ed00b-c1c2-42d1-a51d-b896bc7b6d83");
			Name = "WebHookTypes";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,83,203,106,221,48,16,93,59,144,127,16,201,198,129,224,15,104,232,230,62,146,64,122,225,82,59,116,81,74,144,229,185,142,136,44,185,163,177,137,41,249,247,74,182,108,95,167,166,27,161,121,29,157,57,51,210,188,2,91,115,1,108,115,60,164,230,68,201,214,232,147,44,27,228,36,141,190,188,248,115,121,17,53,86,234,146,165,157,37,168,238,38,123,107,16,102,107,46,71,72,118,27,23,112,161,107,132,210,161,176,173,226,214,126,97,27,110,225,7,228,143,198,188,245,225,186,201,149,20,140,231,150,144,11,98,194,167,45,179,34,247,190,59,39,164,35,154,26,144,36,56,184,99,95,62,196,3,84,74,142,182,37,41,246,45,104,202,186,26,88,127,248,46,162,168,4,242,132,163,200,134,203,71,40,70,217,114,2,182,115,71,38,43,96,47,224,203,189,121,119,6,62,133,123,112,111,205,184,225,22,33,80,131,154,5,254,207,36,149,244,100,147,7,160,148,159,32,253,173,124,93,60,63,112,51,48,250,24,121,141,64,115,6,251,202,90,174,26,56,75,12,188,175,65,23,131,46,75,145,14,64,175,166,88,87,104,18,187,53,178,96,143,92,23,106,84,59,126,182,128,110,252,26,132,159,61,107,22,166,39,122,134,147,27,163,88,134,221,18,97,183,217,191,131,104,200,32,43,242,241,122,203,254,15,60,116,76,216,141,189,207,165,137,27,40,82,134,92,91,222,39,199,65,175,104,249,238,191,84,63,225,108,77,85,201,85,160,48,49,194,73,97,38,56,137,87,22,239,223,5,212,61,97,184,89,161,246,221,40,149,115,241,182,6,122,224,110,240,186,156,231,31,136,126,51,101,178,71,52,120,111,176,226,20,95,253,12,129,161,29,76,220,126,11,176,54,120,109,242,89,225,95,87,183,142,205,249,206,4,254,39,174,236,208,192,184,212,195,156,90,137,212,112,197,220,212,253,55,117,123,248,128,166,169,159,160,139,199,166,2,130,255,40,73,102,210,62,49,116,178,190,104,131,119,233,236,125,127,1,124,106,125,68,78,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3d2ed00b-c1c2-42d1-a51d-b896bc7b6d83"));
		}

		#endregion

	}

	#endregion

}

