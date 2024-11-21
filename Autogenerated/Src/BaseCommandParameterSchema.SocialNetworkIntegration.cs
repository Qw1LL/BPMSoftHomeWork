namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseCommandParameterSchema

	/// <exclude/>
	public class BaseCommandParameterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseCommandParameterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseCommandParameterSchema(BaseCommandParameterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a330adc7-9feb-43e7-b328-86d676594b41");
			Name = "BaseCommandParameter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,79,77,75,195,64,16,61,111,33,255,97,73,47,13,148,160,87,165,151,70,60,89,9,70,188,136,135,105,50,141,11,217,221,56,59,41,104,201,127,119,179,73,133,22,171,167,157,125,51,239,203,128,70,215,66,137,114,157,111,10,187,227,52,179,102,167,234,142,128,149,53,105,97,75,5,77,52,59,68,179,104,38,58,167,76,45,139,79,199,168,211,7,101,62,110,207,193,167,206,176,210,152,22,72,158,167,190,130,138,191,242,119,115,194,218,127,100,214,128,115,55,114,13,14,51,171,53,152,42,7,242,49,24,41,220,189,222,1,131,79,193,4,37,191,121,160,237,182,141,42,101,57,240,46,208,196,152,239,199,35,39,219,34,177,66,111,148,7,250,184,15,218,27,212,91,164,197,163,39,203,149,140,141,127,227,100,48,58,58,57,166,161,82,56,240,194,66,136,26,121,168,42,132,155,134,254,178,222,30,154,238,119,193,151,97,243,143,226,28,77,53,150,56,109,180,65,126,183,213,89,157,73,222,238,145,72,85,120,244,121,182,69,24,22,201,100,70,200,29,153,105,157,222,91,210,192,139,248,112,213,175,14,215,125,188,12,77,151,99,188,228,143,48,35,122,10,246,223,120,249,197,133,66,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a330adc7-9feb-43e7-b328-86d676594b41"));
		}

		#endregion

	}

	#endregion

}

