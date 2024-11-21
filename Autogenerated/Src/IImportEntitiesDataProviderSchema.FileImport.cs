namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportEntitiesDataProviderSchema

	/// <exclude/>
	public class IImportEntitiesDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportEntitiesDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportEntitiesDataProviderSchema(IImportEntitiesDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("18959618-7987-4279-b581-a64c3683bed3");
			Name = "IImportEntitiesDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,84,75,111,226,48,16,62,23,137,255,48,162,23,86,90,145,123,155,141,180,60,218,162,21,90,84,170,189,155,100,146,90,56,118,52,182,179,66,171,254,247,29,39,64,105,120,136,75,32,158,239,49,223,216,142,22,37,218,74,164,8,227,229,98,101,114,55,154,24,157,203,194,147,112,210,232,209,147,84,56,47,43,67,174,223,251,215,239,221,121,43,117,1,171,173,117,88,62,118,222,153,170,20,166,129,103,71,207,168,145,100,202,24,70,85,126,173,100,10,82,59,164,60,152,205,91,205,153,118,210,73,180,83,225,196,146,76,45,51,36,134,179,17,63,239,238,9,11,214,130,5,186,119,147,217,7,88,54,50,109,49,138,34,136,173,47,75,65,219,100,191,48,81,40,200,66,198,114,144,147,41,97,236,243,28,9,179,35,187,45,56,177,86,8,235,45,84,173,101,6,113,37,72,148,132,57,104,158,199,143,129,108,224,43,180,150,253,231,217,0,162,131,69,28,117,77,91,242,5,102,18,71,77,185,65,215,70,102,77,143,250,76,95,60,134,225,179,103,64,71,226,219,227,149,192,83,84,232,16,140,218,211,0,119,90,163,27,27,206,165,222,117,177,12,171,172,70,246,201,235,244,82,231,191,85,167,233,87,241,55,108,223,48,144,226,16,224,59,116,245,18,184,228,114,53,220,92,91,228,68,157,96,224,12,100,235,91,227,85,7,187,175,129,78,128,27,220,242,241,245,165,62,7,36,116,158,180,229,194,254,95,40,173,141,81,176,18,53,126,29,200,155,153,142,135,221,176,240,217,8,207,103,166,125,137,20,142,97,220,2,91,235,4,62,187,184,58,153,201,59,166,27,16,181,144,170,57,203,76,131,180,229,241,175,215,238,214,241,108,14,126,147,64,27,36,191,78,148,46,14,227,21,173,87,14,106,161,36,95,56,100,224,201,112,254,236,106,172,122,108,51,228,15,193,81,212,102,109,159,247,30,117,214,222,251,246,29,107,222,120,152,133,231,139,208,153,66,138,103,68,134,22,124,63,68,129,77,225,39,21,124,198,206,221,245,176,59,211,113,67,8,95,171,143,126,239,227,63,115,228,174,235,242,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("18959618-7987-4279-b581-a64c3683bed3"));
		}

		#endregion

	}

	#endregion

}

