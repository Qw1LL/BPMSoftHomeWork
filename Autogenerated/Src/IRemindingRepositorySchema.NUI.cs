namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IRemindingRepositorySchema

	/// <exclude/>
	public class IRemindingRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRemindingRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRemindingRepositorySchema(IRemindingRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4233de2b-b2d2-4f8a-93e4-3ee4626b552e");
			Name = "IRemindingRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,205,106,2,49,16,62,43,248,14,131,94,218,139,123,111,237,30,90,138,228,208,34,238,19,196,205,68,7,54,201,50,73,4,41,125,247,38,241,111,81,44,228,146,225,251,157,196,74,131,190,151,45,194,251,234,171,113,58,204,63,156,213,180,141,44,3,57,59,25,255,76,198,163,232,201,110,161,57,248,128,230,245,230,158,240,93,135,109,6,251,249,18,45,50,181,25,147,206,140,113,155,198,32,108,64,214,201,227,5,196,26,13,89,149,232,107,236,157,167,224,248,48,25,39,108,85,85,176,240,209,24,201,135,250,116,95,177,219,147,66,15,18,12,134,157,83,160,29,3,99,139,180,207,1,184,104,33,251,249,89,160,26,40,244,113,211,81,11,116,54,127,224,61,202,5,239,236,203,96,141,33,178,245,39,159,196,43,70,247,78,199,9,31,209,245,117,31,64,26,194,14,135,252,69,117,134,101,158,248,180,209,32,203,77,135,11,241,237,2,105,106,203,218,133,213,174,134,37,134,75,100,255,244,156,182,250,48,106,131,97,152,19,200,131,71,27,254,203,219,75,150,6,108,122,255,183,233,133,41,212,116,88,192,221,20,128,244,28,54,199,68,78,85,138,66,17,220,59,82,57,195,53,174,240,77,66,62,13,27,46,35,169,250,170,37,84,110,52,250,45,173,102,104,213,241,183,148,175,147,134,127,72,32,227,227,153,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4233de2b-b2d2-4f8a-93e4-3ee4626b552e"));
		}

		#endregion

	}

	#endregion

}

