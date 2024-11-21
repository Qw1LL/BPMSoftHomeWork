namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PrimeContactInAccountLanguageRuleSchema

	/// <exclude/>
	public class PrimeContactInAccountLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PrimeContactInAccountLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PrimeContactInAccountLanguageRuleSchema(PrimeContactInAccountLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41844107-7e4d-4d9f-9450-654c0ae6bb86");
			Name = "PrimeContactInAccountLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,193,106,219,64,16,61,59,144,127,24,212,139,13,70,186,59,182,32,49,37,24,234,226,214,77,239,155,213,200,94,144,118,221,217,93,23,17,242,239,29,105,87,142,172,4,154,139,96,70,243,222,188,247,102,181,168,209,158,132,68,120,216,109,247,166,116,233,218,232,82,29,60,9,167,140,190,189,121,185,189,153,120,171,244,1,246,141,117,88,223,93,234,55,0,225,199,221,244,171,118,202,41,180,252,155,7,178,44,131,165,245,117,45,168,201,99,189,174,132,181,115,56,145,57,171,2,45,84,66,31,188,56,224,28,74,50,53,8,41,141,215,46,237,209,217,0,126,242,207,149,146,32,91,6,216,145,170,145,165,59,33,221,70,223,7,216,183,72,246,211,87,8,11,120,16,22,135,45,230,96,119,252,157,124,33,60,176,91,96,2,235,200,75,103,200,46,96,215,45,8,19,99,237,65,60,161,112,44,90,49,74,104,206,208,148,60,132,8,146,176,92,37,253,174,141,142,194,134,203,147,44,111,93,189,183,21,58,39,65,162,6,205,215,89,37,222,34,49,131,70,217,158,36,201,159,184,6,121,105,164,203,172,155,238,192,49,148,255,198,49,125,186,34,133,235,29,179,150,106,178,128,103,78,108,58,250,5,47,240,26,83,67,93,132,224,174,83,220,162,59,154,226,51,1,238,198,103,7,174,248,205,148,138,29,142,31,192,103,162,138,227,155,34,201,163,105,104,249,92,51,32,190,202,171,99,80,250,136,164,92,97,36,100,195,20,205,25,137,24,8,143,94,21,240,136,151,4,55,197,180,107,93,214,113,42,93,100,103,65,128,246,15,172,64,227,95,232,158,127,179,151,71,172,197,15,143,212,140,82,79,135,3,91,161,153,153,230,144,68,229,201,236,238,194,217,231,179,54,149,175,245,119,246,202,43,120,81,122,95,20,161,55,77,218,155,115,48,241,234,105,175,53,229,48,102,105,11,9,116,97,103,47,221,197,50,176,177,197,80,143,132,206,7,78,3,75,103,191,87,181,41,24,127,77,216,82,253,106,78,24,213,253,22,149,199,101,11,202,167,239,189,68,78,66,231,73,15,88,187,246,199,143,141,187,175,255,0,69,119,239,153,188,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41844107-7e4d-4d9f-9450-654c0ae6bb86"));
		}

		#endregion

	}

	#endregion

}

