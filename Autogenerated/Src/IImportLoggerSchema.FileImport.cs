namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportLoggerSchema

	/// <exclude/>
	public class IImportLoggerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportLoggerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportLoggerSchema(IImportLoggerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b874d1d-c36b-481a-b709-ada9ef850f84");
			Name = "IImportLogger";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,82,97,75,195,48,16,253,188,66,255,67,216,190,76,144,246,187,206,129,142,138,5,11,133,253,130,172,189,198,72,147,43,151,180,56,100,255,221,36,181,19,167,130,34,236,99,238,222,189,119,239,242,52,87,96,58,94,1,187,43,139,45,54,54,217,160,110,164,232,137,91,137,58,185,151,45,228,170,67,178,113,244,26,71,179,174,223,181,178,98,82,91,160,198,143,229,99,247,17,133,0,114,0,15,154,45,8,132,155,102,5,216,39,172,205,21,43,195,88,28,249,102,154,166,108,101,122,165,56,237,215,83,225,129,235,186,5,195,128,8,41,57,194,210,83,220,170,227,196,21,211,110,237,155,185,1,93,3,205,215,171,52,84,191,7,193,0,218,222,146,48,159,113,3,202,250,93,53,243,154,75,220,61,67,101,217,200,121,201,54,216,246,74,151,132,21,24,19,16,217,68,196,142,148,23,215,191,177,244,82,65,23,142,121,102,91,147,238,169,181,241,199,50,109,165,221,111,249,0,255,114,39,117,131,164,66,88,152,139,146,225,2,206,236,51,119,27,20,163,242,23,167,31,173,191,250,243,135,49,172,69,241,131,155,176,128,7,185,228,47,39,166,133,211,29,163,31,222,135,56,58,188,1,172,69,22,59,97,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b874d1d-c36b-481a-b709-ada9ef850f84"));
		}

		#endregion

	}

	#endregion

}

