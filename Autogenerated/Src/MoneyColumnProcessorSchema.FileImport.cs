namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MoneyColumnProcessorSchema

	/// <exclude/>
	public class MoneyColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MoneyColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MoneyColumnProcessorSchema(MoneyColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1ada78ef-dac1-4b3e-9c3b-95c44f2ee05b");
			Name = "MoneyColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1a247561-b87d-48fb-9e13-b6a8baa960d3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,78,227,64,12,134,207,32,241,14,86,185,180,18,74,238,44,173,68,139,138,122,0,85,98,187,151,21,135,233,196,41,35,37,227,224,153,65,170,86,188,59,206,76,187,144,16,144,184,36,25,231,247,111,251,139,99,85,141,174,81,26,97,190,190,123,160,210,103,11,178,165,217,5,86,222,144,205,150,166,194,85,221,16,251,179,211,127,103,167,39,193,25,187,131,135,189,243,88,255,250,127,126,207,101,28,142,102,75,165,61,177,65,39,239,69,113,206,184,19,127,88,84,202,185,75,184,35,139,251,5,85,161,182,107,38,141,206,17,71,93,158,231,112,101,236,19,178,241,5,105,208,140,229,116,180,172,72,249,158,124,148,207,142,122,23,234,90,241,254,120,190,182,96,172,243,202,202,148,84,130,127,50,14,116,91,23,228,129,101,124,178,206,108,43,132,146,24,154,228,215,246,31,155,2,29,203,192,139,170,2,186,236,88,34,255,80,227,239,13,150,42,84,126,110,108,33,121,99,191,111,144,202,241,170,215,224,228,2,238,133,54,76,193,202,77,4,67,67,79,38,143,226,216,132,109,101,244,161,201,33,25,92,194,16,3,73,149,143,36,215,119,190,50,155,231,208,178,23,204,235,232,155,20,63,37,251,9,109,12,44,24,149,71,215,5,44,243,139,18,241,224,57,52,128,120,182,44,63,195,76,145,70,177,170,35,167,233,40,56,100,25,195,162,110,55,114,52,219,200,89,190,202,49,144,93,229,81,29,147,15,224,134,42,142,55,29,31,232,218,78,132,232,86,57,28,247,195,237,210,159,188,30,160,162,45,18,215,46,100,169,209,32,123,89,110,65,204,228,37,23,139,239,40,207,165,210,15,32,223,40,175,210,2,38,182,193,154,103,121,54,5,90,111,74,131,252,5,74,217,229,212,11,208,11,50,139,30,110,131,41,162,223,159,214,238,183,184,109,86,5,76,103,221,88,22,1,246,101,233,207,237,83,72,108,186,193,215,55,74,66,118,42,87,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1ada78ef-dac1-4b3e-9c3b-95c44f2ee05b"));
		}

		#endregion

	}

	#endregion

}

