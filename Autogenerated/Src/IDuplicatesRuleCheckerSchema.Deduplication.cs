namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDuplicatesRuleCheckerSchema

	/// <exclude/>
	public class IDuplicatesRuleCheckerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicatesRuleCheckerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicatesRuleCheckerSchema(IDuplicatesRuleCheckerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("53ff3e32-a9b5-4c01-b749-bb3b0594295a");
			Name = "IDuplicatesRuleChecker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,83,205,106,194,64,16,62,43,248,14,131,94,90,40,201,93,173,208,154,34,57,88,164,250,2,155,100,98,134,38,217,176,179,171,13,165,239,222,221,196,168,84,11,165,224,37,100,102,103,190,191,100,75,81,32,87,34,70,120,94,45,215,50,213,222,92,150,41,109,141,18,154,100,233,5,152,152,42,167,184,169,6,253,207,65,191,103,152,202,45,172,107,214,88,76,6,125,219,25,41,220,218,99,8,75,141,42,181,96,99,8,131,195,26,242,155,201,113,158,97,252,142,170,153,246,125,31,166,108,138,66,168,122,118,168,87,74,238,40,65,6,1,140,26,100,10,5,234,76,38,12,90,66,236,150,65,103,8,98,39,40,23,17,229,164,107,55,148,156,171,3,101,137,216,235,24,252,51,138,202,68,118,10,168,211,247,171,188,158,53,104,159,71,71,203,86,197,24,86,13,66,123,248,211,64,211,104,32,248,170,74,113,69,39,68,181,243,90,97,76,41,97,2,148,56,225,151,202,219,78,37,148,40,160,180,223,234,113,72,201,112,182,177,44,97,112,204,198,155,250,205,196,105,65,161,54,170,228,217,70,25,4,250,69,194,158,116,118,192,86,152,158,224,253,25,224,7,177,230,7,144,214,143,218,19,35,164,34,103,180,68,29,178,163,138,164,204,97,129,58,228,224,132,237,242,124,113,235,119,11,67,206,216,253,228,118,177,49,10,21,103,192,54,134,66,52,14,254,26,99,187,242,106,223,219,56,47,145,110,18,239,25,237,63,98,126,138,53,237,240,106,216,172,149,187,150,39,252,46,246,17,150,73,251,55,55,245,87,123,99,207,154,182,243,13,100,165,32,154,6,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53ff3e32-a9b5-4c01-b749-bb3b0594295a"));
		}

		#endregion

	}

	#endregion

}

