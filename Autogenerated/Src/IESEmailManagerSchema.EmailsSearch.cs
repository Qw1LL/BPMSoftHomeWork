namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IESEmailManagerSchema

	/// <exclude/>
	public class IESEmailManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IESEmailManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IESEmailManagerSchema(IESEmailManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f0a3bfc-dd1a-49ca-91a0-daff393823fe");
			Name = "IESEmailManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92df5372-6a61-42f2-95f4-67c9e246a93f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,193,106,195,48,12,134,207,14,228,29,4,189,108,48,242,0,93,201,97,91,40,129,5,10,121,2,197,85,82,131,35,119,178,125,40,163,239,62,215,94,7,99,59,24,97,251,243,175,207,98,92,201,159,81,19,188,28,134,209,205,161,121,117,60,155,37,10,6,227,184,233,86,52,214,143,132,162,79,117,245,89,87,117,165,162,55,188,192,120,241,129,214,132,91,75,250,198,250,102,79,76,98,244,243,15,243,127,230,222,186,9,109,201,76,108,162,55,66,75,186,129,158,3,201,156,108,182,208,119,99,238,61,32,227,66,146,177,115,156,172,209,96,238,212,95,72,37,67,165,110,235,30,57,80,56,185,163,223,194,33,63,206,57,170,239,56,174,36,56,89,218,189,153,108,143,114,217,249,32,201,250,9,74,109,91,40,142,101,6,15,239,198,135,111,164,5,161,143,72,62,60,22,127,181,33,62,150,134,121,127,45,191,250,117,120,253,2,222,230,34,54,107,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f0a3bfc-dd1a-49ca-91a0-daff393823fe"));
		}

		#endregion

	}

	#endregion

}

