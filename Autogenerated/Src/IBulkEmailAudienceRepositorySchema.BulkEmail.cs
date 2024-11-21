namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBulkEmailAudienceRepositorySchema

	/// <exclude/>
	public class IBulkEmailAudienceRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkEmailAudienceRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkEmailAudienceRepositorySchema(IBulkEmailAudienceRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a06eeb92-03f3-e55d-a005-1861571a3c8a");
			Name = "IBulkEmailAudienceRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8ded9bc0-26e3-4d8b-ab12-46857e761bcf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,147,219,78,195,48,12,134,175,55,105,239,96,109,55,32,77,237,61,135,74,108,32,180,11,196,96,240,0,89,235,174,22,109,82,114,16,170,16,239,142,155,174,107,89,167,209,139,74,113,226,47,191,127,59,82,20,104,74,17,35,44,214,79,27,149,218,96,169,100,74,59,167,133,37,37,39,227,239,201,120,228,12,201,29,108,42,99,177,184,62,172,187,4,141,193,131,180,100,9,77,183,237,35,213,82,229,57,198,53,10,110,225,207,201,224,248,0,167,114,242,76,227,174,62,189,146,22,117,202,194,174,96,181,112,249,199,67,33,40,191,115,9,161,140,241,21,75,101,200,42,93,249,156,48,12,225,198,184,162,16,186,138,246,235,123,52,177,166,45,26,72,157,244,124,145,243,117,144,42,13,98,143,1,149,130,205,16,182,204,7,172,47,8,90,90,216,195,149,110,155,83,12,212,42,250,71,208,136,45,227,255,161,146,39,180,153,74,204,21,172,61,167,217,60,150,236,3,143,104,205,25,113,240,69,54,131,196,149,76,17,22,33,86,50,97,43,149,52,181,236,161,238,38,82,10,45,10,144,220,231,219,233,182,213,189,74,166,209,187,164,79,135,64,9,114,35,82,66,125,194,142,155,208,167,159,166,161,249,156,70,27,172,219,7,76,210,213,9,201,109,53,231,73,135,154,222,170,18,167,81,235,106,175,86,203,27,231,25,170,244,86,28,43,106,162,195,84,141,214,105,105,162,222,128,178,122,141,49,149,124,55,247,97,104,182,21,140,237,236,98,102,11,169,169,131,121,111,116,180,181,92,60,58,74,188,51,251,6,204,247,47,100,19,103,108,213,139,87,203,142,206,107,214,104,48,96,247,125,135,58,89,245,234,4,232,185,169,186,173,254,178,121,90,163,25,202,164,25,74,191,254,105,30,92,47,8,252,77,198,28,255,5,3,144,133,242,23,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a06eeb92-03f3-e55d-a005-1861571a3c8a"));
		}

		#endregion

	}

	#endregion

}

