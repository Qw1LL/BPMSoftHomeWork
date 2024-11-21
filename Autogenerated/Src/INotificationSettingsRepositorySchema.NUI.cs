namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationSettingsRepositorySchema

	/// <exclude/>
	public class INotificationSettingsRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationSettingsRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationSettingsRepositorySchema(INotificationSettingsRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dc33ae41-bf6c-4f6c-b52a-7eaf39e99da6");
			Name = "INotificationSettingsRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,146,203,78,195,48,16,69,215,141,148,127,24,149,13,72,40,217,67,41,18,44,170,44,120,136,192,7,184,206,56,12,194,15,217,147,69,132,250,239,216,73,137,210,135,132,228,205,92,251,30,223,177,199,8,141,193,9,137,240,240,250,84,91,197,197,163,53,138,218,206,11,38,107,32,207,126,242,108,209,5,50,45,212,125,96,212,183,121,22,149,11,143,109,218,175,12,163,87,209,127,3,213,179,101,82,36,7,99,141,204,209,19,222,208,217,64,108,125,31,77,113,149,101,9,171,208,105,45,124,191,222,215,19,3,172,2,51,131,4,8,123,12,248,137,83,252,81,202,25,198,117,219,111,146,64,19,233,255,48,169,175,147,56,131,176,65,62,136,1,164,69,139,64,13,154,36,162,7,101,61,4,135,50,85,13,4,249,137,90,164,92,167,193,70,197,9,47,52,152,248,214,119,203,4,225,190,30,60,31,85,179,92,191,108,191,80,242,158,2,81,42,86,229,96,56,239,159,39,123,239,29,38,196,188,89,224,40,194,17,101,211,81,147,250,154,31,172,82,87,151,195,206,81,166,107,72,234,253,193,35,140,87,93,197,223,95,236,198,9,64,211,140,67,144,103,187,95,171,57,153,59,71,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dc33ae41-bf6c-4f6c-b52a-7eaf39e99da6"));
		}

		#endregion

	}

	#endregion

}

