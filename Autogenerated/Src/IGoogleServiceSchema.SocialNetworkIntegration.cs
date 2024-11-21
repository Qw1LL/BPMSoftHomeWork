namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IGoogleServiceSchema

	/// <exclude/>
	public class IGoogleServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGoogleServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGoogleServiceSchema(IGoogleServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("956a9445-e36a-4d6f-9741-e5836ee6b58c");
			Name = "IGoogleService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,77,107,194,64,16,61,71,232,127,24,244,162,32,201,221,90,161,10,149,20,82,165,41,120,144,30,214,100,18,151,38,187,233,238,70,8,197,255,222,201,174,17,237,135,151,133,121,243,230,205,188,153,21,172,68,93,177,4,97,190,142,98,153,25,127,33,69,198,243,90,49,195,165,240,99,153,112,86,220,245,190,238,122,94,173,185,200,33,110,180,193,210,143,81,29,120,130,145,76,177,184,191,149,244,31,19,195,15,86,237,54,111,131,59,34,16,101,160,48,39,54,132,194,160,202,104,182,9,132,75,41,243,2,79,124,203,218,158,2,154,215,40,150,152,225,11,89,129,7,232,95,81,251,163,119,226,86,245,174,224,9,240,78,240,151,158,71,254,232,61,183,142,208,236,101,170,39,176,182,149,46,25,4,1,76,117,93,150,76,53,179,14,120,69,83,43,161,33,145,130,82,168,168,73,38,85,105,253,2,219,201,218,64,110,123,129,222,51,133,41,176,170,34,69,183,221,179,106,240,83,118,170,156,238,108,241,135,174,63,13,186,116,203,223,174,42,116,231,234,118,209,122,246,182,180,208,80,28,228,7,14,157,157,118,57,235,85,252,214,31,211,212,159,53,106,243,100,21,9,39,106,132,90,179,28,29,228,63,107,41,198,48,151,105,19,155,134,134,191,164,156,81,127,163,200,13,166,173,158,174,104,208,83,245,127,130,246,22,158,91,125,231,43,36,91,93,53,44,209,92,226,195,145,251,16,222,0,69,234,46,99,227,163,251,38,87,224,241,27,153,60,116,115,202,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("956a9445-e36a-4d6f-9741-e5836ee6b58c"));
		}

		#endregion

	}

	#endregion

}

