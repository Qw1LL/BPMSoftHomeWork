namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SessionTokenResponseSchema

	/// <exclude/>
	public class SessionTokenResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SessionTokenResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SessionTokenResponseSchema(SessionTokenResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f87b198-4253-acd7-9bd9-07d8390cb4bc");
			Name = "SessionTokenResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,221,106,194,64,16,133,175,13,228,29,6,188,79,238,171,20,90,47,122,99,33,152,250,0,227,102,18,23,147,153,176,63,22,145,190,123,55,27,83,172,109,165,55,203,206,153,159,243,29,198,142,108,143,138,224,185,120,45,165,118,217,74,184,214,141,55,232,180,112,86,138,210,216,174,9,171,23,226,52,57,167,73,154,204,230,134,154,208,132,85,139,214,62,64,73,214,134,242,77,14,196,155,112,77,216,82,156,203,243,28,150,214,119,29,154,211,227,165,158,6,224,93,187,61,104,174,197,116,209,10,112,39,222,1,42,37,158,29,88,50,71,29,176,144,171,240,143,6,217,116,50,191,186,217,251,93,171,21,168,1,229,15,146,217,72,253,133,93,24,233,201,56,77,129,189,136,235,105,236,223,226,70,225,233,134,103,187,89,15,28,63,65,38,18,235,140,230,102,218,43,199,181,173,105,225,12,13,185,69,56,20,158,143,59,142,151,16,224,134,20,255,242,186,142,253,155,205,156,184,26,179,199,122,84,191,139,65,251,4,61,73,134,78,11,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f87b198-4253-acd7-9bd9-07d8390cb4bc"));
		}

		#endregion

	}

	#endregion

}

