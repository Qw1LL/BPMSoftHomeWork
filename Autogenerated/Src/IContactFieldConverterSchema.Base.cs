namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IContactFieldConverterSchema

	/// <exclude/>
	public class IContactFieldConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IContactFieldConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IContactFieldConverterSchema(IContactFieldConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e41c16cf-8b54-48e0-a08f-2fb93df528b9");
			Name = "IContactFieldConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,77,107,194,64,16,61,71,240,63,12,233,165,189,184,119,63,114,104,193,226,193,34,120,44,61,108,215,73,92,72,54,97,118,83,144,226,127,239,108,220,24,83,13,10,33,204,100,223,155,247,230,177,49,178,64,91,73,133,240,186,89,111,203,212,77,222,74,147,234,172,38,233,116,105,224,119,60,138,248,121,34,204,124,187,50,14,41,101,248,20,86,12,116,82,185,165,198,124,199,245,15,18,159,141,71,140,22,66,192,220,214,69,33,233,144,132,62,160,33,94,214,121,14,134,101,99,72,61,21,84,203,157,180,84,113,193,173,234,239,92,43,208,173,240,160,110,196,86,249,125,182,186,161,178,226,35,141,118,10,155,102,200,233,252,191,185,65,119,22,43,201,41,148,4,106,207,133,98,21,11,146,72,30,188,209,107,167,145,135,125,126,193,246,204,243,225,69,81,134,110,214,20,54,20,199,96,20,205,238,228,181,111,124,141,110,95,238,30,113,189,100,141,158,99,71,218,100,64,232,106,50,150,241,136,160,8,211,69,28,246,219,102,69,44,18,14,211,58,105,20,14,236,209,124,241,59,20,205,220,69,220,76,79,174,149,38,115,209,192,58,86,144,78,238,75,207,69,139,245,228,14,4,239,232,186,238,57,172,228,85,95,102,119,162,184,43,10,109,50,55,86,121,48,10,203,19,31,218,110,32,152,155,33,94,38,17,22,238,82,248,96,236,243,69,62,236,192,39,17,249,223,178,119,135,194,189,234,95,171,227,31,205,150,19,143,225,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e41c16cf-8b54-48e0-a08f-2fb93df528b9"));
		}

		#endregion

	}

	#endregion

}

