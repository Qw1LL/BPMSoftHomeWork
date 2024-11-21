namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignConfigurationServiceResponseSchema

	/// <exclude/>
	public class CampaignConfigurationServiceResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignConfigurationServiceResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignConfigurationServiceResponseSchema(CampaignConfigurationServiceResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fd1fe187-de0b-4898-b834-f29572b7524b");
			Name = "CampaignConfigurationServiceResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,83,61,79,195,48,16,157,83,137,255,112,106,151,100,73,118,10,12,164,12,12,173,170,118,96,64,12,142,123,9,70,137,29,217,14,165,32,254,59,231,124,208,180,64,21,85,44,150,253,116,239,238,189,187,179,100,5,154,146,113,132,219,229,124,173,82,27,198,74,166,34,171,52,179,66,201,139,209,199,197,200,171,140,144,25,172,119,198,98,49,253,126,119,132,69,37,194,53,234,87,193,113,174,54,152,135,51,102,25,101,177,154,113,59,61,162,135,171,74,90,81,160,99,8,150,139,247,186,12,69,81,220,68,99,70,15,136,115,102,204,37,196,172,40,153,200,228,129,160,182,208,138,68,43,105,176,230,69,81,4,87,166,42,10,166,119,55,237,187,171,15,169,210,192,219,76,96,26,54,232,150,30,118,236,168,71,127,236,235,127,34,160,172,146,92,112,224,78,214,32,85,64,226,79,138,246,168,171,116,238,29,19,108,117,197,173,210,100,124,89,215,107,34,142,189,213,192,12,83,86,229,22,248,158,6,86,1,215,200,44,130,32,144,73,114,169,210,65,106,93,19,126,118,161,115,61,36,131,31,128,91,19,207,123,96,90,210,172,239,101,170,224,26,36,110,161,135,248,129,91,6,239,243,132,177,248,60,7,176,21,246,25,80,107,234,131,112,181,19,102,112,3,212,88,124,227,88,58,198,63,152,188,235,114,1,6,52,97,87,195,199,51,156,79,80,110,154,185,31,46,193,82,171,18,181,21,56,100,5,218,236,160,146,23,228,246,15,119,245,38,207,177,72,80,251,11,250,232,164,108,188,221,203,26,7,110,187,187,30,244,29,244,239,141,191,12,235,175,236,121,166,189,252,110,166,65,15,65,194,190,0,47,167,166,143,102,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fd1fe187-de0b-4898-b834-f29572b7524b"));
		}

		#endregion

	}

	#endregion

}

