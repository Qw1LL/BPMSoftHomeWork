namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISyncStrategySchema

	/// <exclude/>
	public class ISyncStrategySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISyncStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISyncStrategySchema(ISyncStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b771ff15-a14f-4f39-be65-1b31aa728594");
			Name = "ISyncStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,146,207,78,195,48,12,198,207,171,212,119,176,182,11,92,214,11,167,49,38,241,71,160,29,42,21,21,30,32,180,110,22,169,77,138,157,76,84,104,239,78,210,110,83,213,193,145,67,165,196,181,63,255,62,199,90,52,200,173,40,16,30,178,52,55,149,93,166,66,213,113,244,29,71,51,199,74,75,200,59,182,216,220,198,145,143,44,8,165,50,26,182,218,34,85,190,106,5,219,188,211,69,110,73,88,148,93,159,148,36,9,172,217,53,141,160,110,115,188,103,100,246,170,68,134,6,237,206,148,12,149,33,144,104,225,211,33,117,96,13,48,10,42,118,161,161,54,22,216,139,98,233,179,153,133,68,94,158,100,147,145,110,235,62,106,85,64,43,200,42,81,131,58,49,77,145,102,193,203,25,61,29,0,86,144,245,229,225,87,248,166,208,125,224,145,208,107,240,145,13,240,171,37,15,20,84,148,159,65,122,159,221,64,45,180,116,30,49,16,94,34,14,17,66,235,72,243,57,144,79,229,70,197,227,92,182,20,230,241,130,246,93,135,129,164,44,135,210,215,48,180,171,235,225,77,254,21,189,21,36,26,208,126,73,238,230,126,27,10,124,242,170,243,77,30,142,80,250,51,236,69,237,112,185,78,250,204,75,207,191,152,253,203,228,179,95,60,179,71,154,216,12,29,223,84,131,112,238,127,50,190,64,93,14,175,234,111,135,97,65,71,161,56,58,252,0,151,53,205,226,222,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b771ff15-a14f-4f39-be65-1b31aa728594"));
		}

		#endregion

	}

	#endregion

}

