namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SspOperationExtensionsSchema

	/// <exclude/>
	public class SspOperationExtensionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SspOperationExtensionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SspOperationExtensionsSchema(SspOperationExtensionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("63085386-1dd0-42f1-b47d-9c7bcf45cfbd");
			Name = "SspOperationExtensions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,205,110,219,48,12,199,207,46,208,119,224,188,139,3,20,246,125,109,2,44,105,182,203,138,5,48,246,0,138,66,219,66,45,201,16,233,38,217,218,119,159,36,39,94,62,186,97,7,11,22,73,253,249,35,69,25,161,145,58,33,17,230,171,167,210,86,156,47,172,169,84,221,59,193,202,154,188,44,87,183,55,191,110,111,146,158,148,169,161,220,19,163,206,75,148,189,83,188,191,31,29,127,78,107,109,205,123,118,135,239,91,243,199,185,119,120,215,71,135,181,79,9,139,86,16,125,130,146,186,239,29,14,24,203,29,163,33,255,67,49,178,40,10,120,160,94,107,225,246,179,195,62,158,130,202,58,216,90,247,28,146,108,21,55,32,94,132,106,197,186,69,176,71,49,2,159,132,168,203,143,74,197,137,84,215,175,91,37,129,216,135,74,144,81,244,111,36,137,239,139,95,175,112,6,158,6,229,51,129,170,128,27,132,158,208,65,35,8,156,170,27,38,96,11,90,24,81,99,0,137,94,10,56,215,60,131,165,19,78,104,48,254,174,166,41,29,122,191,52,181,50,152,206,142,119,1,24,13,158,4,17,164,195,106,154,62,206,203,243,224,98,246,80,68,173,40,125,94,235,139,85,155,129,122,33,204,83,132,243,133,255,8,104,25,55,138,224,82,13,206,73,38,16,198,36,73,214,214,182,32,133,249,188,209,202,40,98,223,55,132,233,69,112,254,21,217,167,89,238,188,149,113,236,110,150,142,185,99,226,116,2,175,175,81,53,249,255,243,167,137,87,214,177,104,15,90,247,81,201,223,72,246,225,130,239,200,158,112,227,236,22,12,110,97,172,117,39,177,139,218,62,212,143,85,254,197,58,45,56,11,49,223,172,20,173,250,25,198,171,140,206,44,61,157,236,244,110,16,77,174,46,34,31,85,243,69,239,28,26,14,136,158,221,88,62,212,20,241,198,194,210,201,29,252,179,182,67,113,111,97,13,139,255,194,147,66,179,25,94,85,216,190,253,6,142,170,164,70,237,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63085386-1dd0-42f1-b47d-9c7bcf45cfbd"));
		}

		#endregion

	}

	#endregion

}

