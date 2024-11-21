namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationRepositorySchema

	/// <exclude/>
	public class INotificationRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationRepositorySchema(INotificationRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c3d2ee1-fb37-4416-8019-d5f16be32ce0");
			Name = "INotificationRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,146,221,74,196,48,16,133,175,183,208,119,24,122,181,222,180,15,96,45,184,34,165,23,46,178,251,4,105,156,212,64,126,74,126,46,138,248,238,38,89,187,110,93,81,20,100,33,4,154,204,153,243,205,73,21,145,104,71,66,17,54,143,15,123,205,92,121,167,21,227,131,55,196,113,173,242,236,37,207,86,222,114,53,192,126,178,14,101,184,23,2,105,188,180,101,139,10,13,167,215,161,38,172,170,170,160,182,94,74,98,166,230,253,187,83,14,13,139,253,153,54,240,68,28,1,66,41,90,11,74,59,206,56,77,54,229,172,174,78,228,163,239,5,167,192,143,29,186,237,137,100,135,163,182,220,105,51,133,210,8,121,102,159,14,118,232,188,81,22,136,16,11,71,27,45,207,61,15,39,230,32,106,62,70,5,205,192,61,227,167,22,117,53,87,70,105,119,175,188,68,67,122,129,245,2,181,83,76,55,208,162,187,21,98,125,21,195,90,253,200,187,48,130,126,2,21,30,234,59,230,145,24,34,83,213,77,17,247,162,217,134,253,43,238,128,157,138,255,127,222,205,20,25,214,214,153,248,255,68,170,191,78,63,24,237,199,95,101,144,20,69,211,30,133,151,142,34,145,204,89,36,186,20,198,107,158,133,245,6,81,177,244,189,135,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c3d2ee1-fb37-4416-8019-d5f16be32ce0"));
		}

		#endregion

	}

	#endregion

}

