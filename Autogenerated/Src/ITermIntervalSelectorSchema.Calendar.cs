namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITermIntervalSelectorSchema

	/// <exclude/>
	public class ITermIntervalSelectorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITermIntervalSelectorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITermIntervalSelectorSchema(ITermIntervalSelectorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ad912a0-8f79-46f0-9654-054938f2e9ef");
			Name = "ITermIntervalSelector";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f69a32ba-7e77-47bd-be6b-d095bbdc629a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,81,203,106,195,48,16,60,199,224,127,88,114,106,161,216,31,80,215,208,7,4,31,2,5,251,7,20,117,237,168,232,97,164,85,33,148,254,123,87,138,221,36,20,116,88,205,206,140,102,87,86,24,12,179,144,8,47,239,251,222,141,84,189,58,59,170,41,122,65,202,217,178,248,46,139,77,12,202,78,208,159,2,161,225,190,214,40,83,51,84,59,180,232,149,124,100,78,93,215,208,132,104,140,240,167,118,185,119,150,208,143,201,220,141,192,165,1,149,144,47,161,33,96,50,113,190,90,165,245,149,118,142,7,173,228,153,156,229,221,192,226,110,209,246,139,180,25,18,55,229,251,247,248,38,1,123,164,163,251,0,58,10,2,143,20,189,13,64,202,224,37,196,232,60,72,161,101,212,121,216,148,37,43,111,194,156,145,89,120,97,192,242,182,158,182,194,79,209,160,165,176,109,159,215,50,123,5,226,173,225,164,48,84,77,157,21,23,131,37,65,59,92,39,96,218,138,39,226,205,152,60,30,236,144,238,222,84,94,54,167,105,216,159,63,226,1,220,225,147,55,208,194,95,144,251,244,3,63,101,193,231,23,74,203,208,245,209,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ad912a0-8f79-46f0-9654-054938f2e9ef"));
		}

		#endregion

	}

	#endregion

}

