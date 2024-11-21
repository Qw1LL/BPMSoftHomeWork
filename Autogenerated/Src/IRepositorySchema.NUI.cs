namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IRepositorySchema

	/// <exclude/>
	public class IRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRepositorySchema(IRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fb47eba1-93f4-4a26-a75c-b68259fb6949");
			Name = "IRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,77,75,196,48,16,61,175,224,127,24,234,101,5,105,239,90,11,42,186,236,65,144,109,193,115,218,206,174,129,52,41,249,80,138,248,223,157,36,219,186,236,250,9,30,51,125,243,230,189,151,73,37,235,208,244,172,65,184,126,184,47,213,218,166,55,74,174,249,198,105,102,185,146,199,71,175,199,71,51,103,184,220,64,57,24,139,221,197,222,153,240,66,96,227,193,38,93,160,68,205,27,194,16,234,68,227,134,170,176,148,22,245,154,70,156,195,114,133,189,50,220,42,61,4,72,150,101,144,27,215,117,76,15,197,246,92,97,215,11,102,177,5,61,129,193,42,96,181,177,154,53,22,12,85,216,6,211,177,63,219,35,200,237,208,99,207,52,235,64,146,187,203,164,74,138,146,122,136,17,165,229,150,216,8,144,230,217,132,243,157,189,171,5,111,128,143,98,119,181,230,85,1,47,79,168,17,42,56,135,107,102,208,243,177,90,224,109,32,164,118,31,211,129,157,80,88,161,117,90,154,113,118,61,0,111,189,246,67,241,177,178,171,156,183,73,17,71,248,166,60,155,212,70,168,142,212,91,8,125,31,11,30,81,193,29,151,237,124,225,120,75,205,167,241,78,62,151,120,163,145,2,159,36,114,57,102,12,76,250,107,136,6,184,53,127,144,30,185,146,34,112,251,117,137,133,159,76,68,159,187,62,130,129,168,112,94,109,89,190,117,179,194,78,61,227,127,7,254,172,72,70,164,254,77,166,179,18,153,110,158,72,6,167,71,98,188,138,158,54,144,55,100,35,133,95,170,25,59,66,87,82,60,76,4,95,134,88,134,169,116,101,198,9,187,23,228,242,86,186,14,195,218,250,133,126,244,11,61,191,115,178,201,171,51,168,149,18,197,36,49,76,249,33,228,143,173,166,119,177,243,38,191,50,54,73,220,174,86,200,229,123,137,11,180,87,66,204,189,144,217,91,252,167,160,108,227,111,197,31,223,222,1,156,68,47,21,190,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb47eba1-93f4-4a26-a75c-b68259fb6949"));
		}

		#endregion

	}

	#endregion

}

