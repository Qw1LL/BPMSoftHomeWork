namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FromNameNotNullValidationRuleSchema

	/// <exclude/>
	public class FromNameNotNullValidationRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FromNameNotNullValidationRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FromNameNotNullValidationRuleSchema(FromNameNotNullValidationRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6d5308f5-73b6-4136-a80d-c0e6af1a6d50");
			Name = "FromNameNotNullValidationRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,83,75,107,227,48,16,62,187,208,255,48,219,66,73,97,145,239,109,221,67,67,91,194,214,161,36,144,187,98,143,19,177,178,228,213,200,41,102,233,127,223,145,252,104,146,194,94,132,245,73,243,61,70,99,35,107,164,70,22,8,79,239,249,218,86,94,204,173,169,212,174,117,210,43,107,224,242,226,239,229,69,210,146,50,59,88,119,228,177,230,11,90,99,17,78,73,188,162,65,167,138,251,243,59,111,202,252,97,144,225,107,135,187,64,52,215,146,232,14,224,197,217,122,201,162,75,235,151,173,214,27,169,85,25,165,86,173,198,88,145,166,41,60,80,91,215,210,117,143,195,126,133,141,67,66,227,9,252,30,161,8,100,240,161,252,30,28,151,17,216,10,14,19,19,84,214,129,97,13,168,88,12,106,89,56,75,176,237,0,235,198,119,98,148,72,143,52,154,118,171,85,49,240,254,215,34,220,193,147,36,60,3,153,130,251,196,235,148,55,71,191,183,37,39,126,119,214,115,187,176,236,207,207,211,69,96,96,195,62,29,231,44,241,56,65,0,71,83,121,72,19,50,124,15,209,35,141,116,178,142,197,217,149,195,66,53,138,219,118,245,184,26,63,67,175,182,173,254,205,221,144,74,139,135,52,22,196,250,102,180,10,246,128,206,169,18,225,96,85,9,11,227,209,25,57,118,2,103,139,28,137,228,14,39,210,133,169,44,76,106,183,16,134,38,73,14,210,133,103,105,113,52,15,25,188,162,143,17,54,35,62,113,204,166,250,159,144,179,53,30,39,158,69,242,36,78,178,255,194,238,54,204,91,146,168,10,102,167,244,63,50,48,252,98,112,115,115,170,43,162,154,248,18,134,44,3,242,142,37,196,115,24,138,209,113,50,121,16,11,163,188,146,122,197,191,7,187,192,185,229,110,100,48,83,28,111,112,119,124,36,230,210,20,168,177,92,199,199,163,97,126,98,199,122,183,159,97,229,37,14,9,95,234,231,36,238,123,244,20,252,252,7,129,237,76,214,154,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6d5308f5-73b6-4136-a80d-c0e6af1a6d50"));
		}

		#endregion

	}

	#endregion

}

