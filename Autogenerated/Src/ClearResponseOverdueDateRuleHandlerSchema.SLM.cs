namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ClearResponseOverdueDateRuleHandlerSchema

	/// <exclude/>
	public class ClearResponseOverdueDateRuleHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ClearResponseOverdueDateRuleHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ClearResponseOverdueDateRuleHandlerSchema(ClearResponseOverdueDateRuleHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d4ab598-48ce-4320-8df6-59d7c39071fd");
			Name = "ClearResponseOverdueDateRuleHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,111,194,48,12,61,23,137,255,224,193,165,72,83,181,51,27,59,80,246,117,64,67,176,237,158,181,166,139,148,38,85,62,144,208,196,127,159,211,20,1,165,76,156,34,63,251,249,249,57,150,172,68,83,177,12,97,186,152,175,212,218,38,169,146,107,94,56,205,44,87,178,223,251,237,247,34,103,184,44,96,181,53,22,203,251,86,156,204,152,101,103,96,170,132,192,204,119,48,201,11,74,212,60,59,212,28,148,202,82,201,46,92,99,55,154,204,166,23,18,79,210,114,203,209,92,72,63,179,204,42,125,33,127,228,55,73,153,64,153,51,237,11,169,116,168,177,32,24,82,193,140,25,211,131,76,47,105,97,228,11,223,55,168,115,135,228,31,151,78,224,43,147,185,64,93,211,42,247,45,120,6,153,103,93,67,130,49,188,165,204,156,246,137,252,234,15,19,16,219,106,231,109,208,32,139,90,160,214,218,139,93,33,19,127,26,212,212,72,134,175,1,119,18,142,160,22,140,90,69,147,86,153,223,96,180,11,210,67,218,85,152,175,137,155,97,23,90,85,168,253,127,116,142,218,82,104,133,97,138,2,109,173,20,85,154,111,200,6,152,6,216,253,47,61,71,251,163,242,110,221,141,226,57,132,93,196,245,193,108,1,235,103,111,157,175,33,14,8,93,173,253,216,86,152,211,37,187,82,126,49,225,240,129,75,251,24,15,90,59,30,140,224,102,2,119,251,22,81,195,95,161,61,162,158,179,110,137,18,12,146,161,78,87,13,118,106,148,176,63,241,197,144,34,179,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d4ab598-48ce-4320-8df6-59d7c39071fd"));
		}

		#endregion

	}

	#endregion

}

