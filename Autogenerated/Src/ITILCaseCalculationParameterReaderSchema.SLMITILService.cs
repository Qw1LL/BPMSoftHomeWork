namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITILCaseCalculationParameterReaderSchema

	/// <exclude/>
	public class ITILCaseCalculationParameterReaderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITILCaseCalculationParameterReaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITILCaseCalculationParameterReaderSchema(ITILCaseCalculationParameterReaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b6eb7ae2-e22e-4845-925b-505d5771ca69");
			Name = "ITILCaseCalculationParameterReader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5be0374d-f3b5-4c63-b887-7fd46e962c93");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,193,106,219,64,16,61,43,144,127,24,148,139,3,65,186,187,182,160,117,154,96,112,168,168,211,83,233,97,179,26,57,11,210,174,152,93,185,184,37,255,222,217,149,100,43,173,81,232,45,232,32,246,205,190,183,243,158,70,171,69,141,182,17,18,225,83,254,176,53,165,75,86,70,151,106,215,146,112,202,232,203,139,223,151,23,81,107,149,222,193,246,96,29,214,92,175,42,148,190,104,147,123,212,72,74,126,56,238,57,137,16,158,71,147,59,33,157,33,133,150,235,254,137,210,52,133,133,109,235,90,208,33,235,215,119,134,106,11,141,32,110,207,33,89,40,13,193,74,88,252,172,29,29,114,163,180,27,152,233,136,250,253,203,30,137,84,129,63,120,209,180,79,149,146,32,43,97,45,172,31,215,27,207,95,137,74,182,85,240,150,15,234,95,81,20,72,115,152,174,179,162,207,34,186,34,220,113,21,56,39,235,168,245,102,236,28,242,112,88,240,243,143,161,0,172,181,114,74,84,234,23,90,16,160,241,39,40,230,11,205,201,155,18,220,51,50,5,17,36,97,185,140,223,238,54,78,179,206,89,114,60,113,28,196,96,254,109,161,217,53,4,91,47,239,167,247,128,132,111,15,154,121,203,184,181,72,28,183,238,198,46,206,30,249,68,143,129,60,130,201,34,13,140,255,52,255,237,149,114,16,61,45,175,189,86,52,135,39,214,152,253,85,122,21,218,21,234,162,155,138,126,221,143,200,3,186,103,83,248,233,32,227,152,136,197,68,200,247,232,160,82,214,249,72,131,149,110,232,229,169,249,169,184,8,93,75,218,102,155,105,133,69,58,108,12,57,13,109,129,233,255,27,184,85,193,31,107,47,120,186,249,231,189,129,238,157,249,6,67,124,246,180,103,24,158,104,130,70,104,219,202,193,50,196,200,55,198,25,17,127,83,68,81,183,49,249,88,20,179,120,139,180,87,18,115,190,43,146,117,17,223,192,24,97,224,28,165,109,26,67,110,131,123,172,6,206,8,26,147,124,2,125,95,1,58,243,25,61,246,242,7,234,194,237,18,29,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b6eb7ae2-e22e-4845-925b-505d5771ca69"));
		}

		#endregion

	}

	#endregion

}

