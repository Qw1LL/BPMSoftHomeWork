namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMailingAudienceDataSourceFactorySchema

	/// <exclude/>
	public class IMailingAudienceDataSourceFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMailingAudienceDataSourceFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMailingAudienceDataSourceFactorySchema(IMailingAudienceDataSourceFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b546faf9-3ac8-4a7c-a169-bbd0f8b47719");
			Name = "IMailingAudienceDataSourceFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("137c1838-0170-451f-b0dc-9c1d36ce6de8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,75,111,211,64,16,62,183,82,255,195,200,61,208,74,149,45,196,161,82,73,45,149,180,32,31,2,145,76,197,1,113,216,120,199,206,74,246,174,217,157,109,9,168,255,157,241,35,38,105,8,164,8,218,11,23,203,179,51,243,205,204,55,15,45,42,116,181,200,16,94,77,39,169,201,41,28,27,157,171,194,91,65,202,232,131,253,111,7,251,123,222,41,93,64,186,112,132,213,203,65,30,27,139,44,177,124,104,177,96,99,72,52,161,205,25,236,12,146,137,80,37,91,93,120,169,80,103,120,41,72,164,198,219,12,95,139,140,140,93,180,142,81,20,193,200,249,170,18,118,17,247,242,212,154,27,37,209,65,133,52,55,18,200,64,102,81,16,130,210,142,4,99,57,48,57,187,33,54,138,252,60,216,30,43,136,226,112,25,38,90,137,243,241,221,204,153,18,9,143,130,15,170,44,97,134,96,177,50,55,40,65,228,92,3,156,134,207,79,195,23,193,241,39,54,174,253,172,84,25,71,239,139,251,125,109,192,94,204,27,127,7,106,38,109,49,238,12,166,45,90,167,188,95,254,122,253,63,2,110,48,161,241,118,96,227,161,100,108,178,209,189,212,194,138,10,52,207,195,121,224,29,90,158,3,141,89,51,4,65,124,205,242,51,7,217,240,20,142,162,214,254,231,238,60,82,78,20,152,200,32,126,63,71,240,90,125,246,220,62,137,154,84,174,152,94,78,153,88,81,117,169,254,26,108,38,40,155,167,234,43,118,96,142,255,26,255,154,3,52,140,48,33,114,19,192,34,121,171,93,252,246,79,137,26,69,75,136,6,115,187,45,140,219,142,36,125,140,163,235,53,230,96,157,200,19,120,227,149,132,129,158,147,166,199,48,20,120,220,109,211,222,33,106,217,141,77,43,223,117,59,182,254,184,195,202,165,28,134,77,80,62,221,238,65,143,123,245,133,56,125,215,54,125,39,231,62,81,198,128,91,69,243,214,209,117,245,36,18,156,175,107,99,233,17,86,123,59,135,176,211,141,251,127,6,118,56,3,100,85,81,176,216,159,131,101,163,255,193,89,88,5,24,198,169,3,184,23,124,37,205,167,191,46,233,114,10,255,202,153,233,213,67,253,15,56,59,119,223,1,39,113,218,249,47,8,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b546faf9-3ac8-4a7c-a169-bbd0f8b47719"));
		}

		#endregion

	}

	#endregion

}

