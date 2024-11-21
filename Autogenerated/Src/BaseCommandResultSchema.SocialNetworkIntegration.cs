namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseCommandResultSchema

	/// <exclude/>
	public class BaseCommandResultSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseCommandResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseCommandResultSchema(BaseCommandResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d2b8d1ca-42bf-4559-aeb0-b421b90c0d74");
			Name = "BaseCommandResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,80,189,110,131,48,16,158,65,202,59,88,201,146,44,60,64,170,44,161,107,34,4,217,170,170,186,152,11,178,132,109,100,159,73,211,42,239,222,195,64,211,168,11,58,223,247,123,24,208,232,59,144,40,246,197,161,178,23,202,114,107,46,170,9,14,72,89,147,85,86,42,104,23,233,247,34,77,130,87,166,17,213,205,19,234,172,12,134,148,198,172,66,199,4,245,21,233,47,139,148,121,43,135,13,63,68,222,130,247,91,177,7,143,185,213,26,76,93,162,15,45,69,210,219,43,16,112,22,57,144,244,206,139,46,156,91,37,133,28,68,255,53,98,43,158,138,113,108,175,36,50,216,89,227,145,245,220,144,191,191,225,133,179,29,58,82,200,13,138,104,61,226,49,247,128,250,140,110,125,228,227,197,78,44,9,63,105,185,25,74,204,45,60,185,225,214,19,3,98,56,61,73,26,36,190,142,7,63,13,247,209,175,115,170,7,66,81,223,12,104,86,126,56,184,70,124,114,154,247,37,92,31,78,211,148,56,164,224,204,67,51,152,142,17,51,99,128,184,98,15,109,192,145,146,196,82,187,40,202,78,182,138,77,215,155,63,250,169,217,10,77,61,254,140,248,30,183,207,203,251,15,150,52,186,156,255,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d2b8d1ca-42bf-4559-aeb0-b421b90c0d74"));
		}

		#endregion

	}

	#endregion

}

