namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DefaultLanguageRuleSchema

	/// <exclude/>
	public class DefaultLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DefaultLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DefaultLanguageRuleSchema(DefaultLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("32971764-08e0-45a0-b450-0b4e7438a79c");
			Name = "DefaultLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5c69ef14-1695-42a6-839b-8d7e06516faf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,148,193,106,227,64,12,134,207,46,244,29,68,122,73,32,216,247,180,201,161,89,40,129,13,91,26,186,247,137,71,118,6,236,25,163,209,132,13,165,239,190,26,219,105,226,52,45,187,71,105,52,250,127,125,35,219,170,26,125,163,114,132,199,231,245,198,21,156,46,157,45,76,25,72,177,113,246,246,230,237,246,38,9,222,216,18,54,7,207,88,223,127,196,167,11,132,247,23,85,27,100,150,200,195,124,80,54,108,158,74,237,177,80,26,72,139,44,203,224,193,135,186,86,116,88,244,241,178,82,222,79,129,119,138,161,33,183,55,26,61,84,202,150,65,149,8,62,52,141,35,134,90,153,106,235,254,244,117,30,25,140,5,223,122,137,81,212,72,143,2,217,153,66,19,182,149,201,33,143,34,240,3,11,21,42,254,217,55,127,9,21,194,12,30,149,199,243,148,220,138,80,146,59,194,82,166,0,153,201,179,178,236,103,240,76,102,175,88,42,226,121,211,5,144,199,115,240,76,17,79,47,177,70,239,165,221,177,237,210,105,20,84,163,235,167,163,14,78,114,135,86,119,154,49,254,100,129,66,206,142,162,139,118,166,174,226,146,104,135,148,80,140,121,65,20,141,203,219,187,66,138,80,172,18,22,243,163,139,243,153,71,217,34,226,251,204,175,203,52,138,84,13,86,118,105,62,10,30,73,252,88,204,227,27,143,22,175,18,71,6,125,34,125,200,218,234,246,114,79,255,138,224,248,117,208,6,134,93,39,241,114,50,219,202,203,140,47,78,224,237,253,26,173,19,171,53,242,206,233,127,193,244,107,203,74,16,157,150,77,86,207,178,41,140,12,84,144,171,255,119,249,190,162,103,236,14,201,176,118,57,100,231,88,220,30,137,68,19,158,130,209,240,132,31,128,86,122,220,166,162,27,62,188,96,238,72,175,180,140,222,98,105,143,244,16,105,191,81,43,45,91,54,252,66,83,233,251,91,85,225,146,248,244,155,85,157,182,58,73,175,209,122,153,76,226,47,32,73,8,57,144,253,82,190,45,186,254,64,146,125,255,11,125,35,125,195,142,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("32971764-08e0-45a0-b450-0b4e7438a79c"));
		}

		#endregion

	}

	#endregion

}

