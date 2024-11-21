namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: UpperExpressionConverterSchema

	/// <exclude/>
	public class UpperExpressionConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpperExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpperExpressionConverterSchema(UpperExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("610a8b86-38e8-423a-9fde-cc03471e6042");
			Name = "UpperExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("75f7d434-56de-4d62-8a8c-9fe090e3ebb1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,77,111,219,48,12,61,59,64,254,3,161,93,108,180,176,151,107,218,186,232,130,20,8,208,110,5,210,158,138,29,20,155,113,52,216,178,161,143,108,193,208,255,62,74,178,141,164,201,46,18,244,200,247,200,39,82,242,6,117,199,11,132,111,47,207,235,118,107,210,69,43,183,162,178,138,27,209,202,233,228,239,116,18,89,45,100,5,235,131,54,216,220,76,39,132,124,81,88,81,24,22,53,215,122,14,111,93,135,106,249,167,83,168,53,193,36,177,71,101,80,249,220,44,203,224,86,219,166,225,234,144,247,111,79,128,130,107,4,109,148,83,199,145,13,197,64,135,194,201,167,131,70,118,36,242,126,161,218,131,33,169,141,53,24,51,175,207,146,159,148,217,217,77,45,138,32,245,223,70,97,14,171,75,48,241,233,3,232,28,29,63,163,217,181,37,121,126,241,186,33,248,217,162,7,122,21,61,56,220,243,218,162,51,115,238,38,32,29,87,188,1,73,19,185,99,62,153,229,235,99,234,109,230,51,46,19,184,170,108,131,210,104,150,195,67,89,10,55,61,94,195,8,159,179,21,26,171,164,206,7,183,229,73,163,96,90,176,227,148,136,61,164,59,126,255,167,125,254,210,17,56,125,123,187,249,133,133,9,252,235,33,58,118,0,119,192,88,2,110,161,162,168,15,210,69,112,28,94,137,39,222,248,184,216,14,104,186,210,223,109,93,255,80,203,166,51,7,7,38,131,72,20,122,2,194,2,235,35,104,255,22,166,216,65,60,86,30,243,253,194,177,71,161,180,89,236,184,98,115,55,224,83,161,116,109,55,161,112,252,245,26,102,73,250,218,250,165,89,201,61,87,130,75,19,39,112,229,123,75,159,80,86,102,7,57,204,224,254,19,117,150,208,70,145,219,208,86,84,226,150,219,218,92,42,119,46,127,100,133,14,191,123,40,203,176,126,254,29,208,83,240,227,31,8,191,210,5,201,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("610a8b86-38e8-423a-9fde-cc03471e6042"));
		}

		#endregion

	}

	#endregion

}

