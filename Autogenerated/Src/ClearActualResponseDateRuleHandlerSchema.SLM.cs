namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ClearActualResponseDateRuleHandlerSchema

	/// <exclude/>
	public class ClearActualResponseDateRuleHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ClearActualResponseDateRuleHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ClearActualResponseDateRuleHandlerSchema(ClearActualResponseDateRuleHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("49896338-f1b3-42b4-a897-a58e4a82829a");
			Name = "ClearActualResponseDateRuleHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,203,110,194,48,16,60,7,137,127,112,225,18,164,42,31,64,75,165,18,250,58,160,34,160,189,187,206,146,90,114,236,200,15,36,84,241,239,93,199,65,144,52,105,123,178,118,188,179,179,51,182,164,5,152,146,50,32,243,213,114,163,118,54,73,149,220,241,220,105,106,185,146,195,193,215,112,16,57,195,101,78,54,7,99,161,184,105,213,201,130,90,250,3,76,149,16,192,252,4,147,60,129,4,205,217,185,231,172,84,20,74,118,225,26,186,209,100,49,239,185,120,144,150,91,14,166,231,250,145,50,171,116,207,253,133,223,36,165,2,100,70,181,111,196,214,177,134,28,97,146,10,106,204,20,15,160,250,158,89,71,197,26,99,67,119,128,246,97,237,4,60,83,153,9,208,21,171,116,31,130,51,194,60,233,31,28,50,37,47,41,53,205,49,145,15,254,172,143,52,171,157,55,129,107,172,170,249,149,212,73,235,111,149,248,205,128,198,57,50,188,11,113,141,114,66,42,189,168,213,52,107,181,249,248,162,99,80,30,99,80,97,189,186,174,119,93,105,85,130,246,143,209,185,105,75,161,85,134,45,114,176,149,82,84,106,190,71,27,196,212,192,241,119,233,37,216,79,149,117,235,238,21,207,72,200,34,174,126,203,129,64,117,156,172,243,29,137,3,130,95,214,110,15,37,100,248,141,93,33,223,169,112,112,235,227,220,242,2,238,226,81,72,56,131,236,85,142,38,228,106,70,164,19,226,52,38,170,103,108,192,94,208,155,164,235,192,8,30,209,83,167,177,26,107,122,69,236,27,33,104,243,12,179,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("49896338-f1b3-42b4-a897-a58e4a82829a"));
		}

		#endregion

	}

	#endregion

}

