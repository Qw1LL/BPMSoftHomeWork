namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseCloudResponseSchema

	/// <exclude/>
	public class BaseCloudResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseCloudResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseCloudResponseSchema(BaseCloudResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4d2a5529-1027-4e39-b5d9-500029d6ce6b");
			Name = "BaseCloudResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,77,111,194,48,12,134,207,69,226,63,88,112,157,232,157,175,3,213,52,237,128,132,198,254,64,72,221,54,90,155,176,56,1,77,136,255,62,55,45,31,27,176,177,157,218,56,175,95,63,118,18,45,42,164,181,144,8,179,197,124,105,50,55,72,140,206,84,238,173,112,202,232,65,242,184,156,155,20,75,234,118,118,221,78,183,19,245,45,230,188,1,73,41,136,134,48,19,132,73,105,124,250,194,54,70,19,6,81,28,199,48,38,95,85,194,126,76,219,117,72,128,204,88,88,113,14,216,86,15,153,53,21,112,25,216,42,87,128,52,85,197,238,107,107,214,104,157,66,26,28,236,226,51,191,181,95,149,74,130,12,150,87,16,162,134,245,8,187,56,218,13,97,17,114,155,253,239,156,33,240,132,142,64,192,70,148,30,65,233,84,73,30,133,206,97,91,160,43,208,130,43,20,157,240,249,159,188,148,72,129,244,18,181,137,4,179,227,18,96,44,167,206,122,28,199,114,10,42,131,165,19,206,19,224,187,23,37,65,207,188,245,70,96,234,98,91,69,248,80,171,51,222,8,242,179,42,39,211,118,30,43,99,74,120,166,101,195,3,60,132,40,138,114,116,176,99,94,231,173,62,20,154,76,218,34,251,90,178,255,109,24,124,102,84,127,153,8,40,56,220,223,107,93,167,110,209,114,115,72,174,25,22,166,103,253,65,15,173,53,182,247,67,99,228,108,125,2,45,253,14,184,167,81,141,20,26,184,159,157,175,58,137,28,239,135,127,189,154,180,185,129,55,111,148,255,231,59,94,42,201,79,238,111,148,183,82,47,88,149,118,144,176,230,26,101,31,117,218,188,152,176,110,162,95,131,28,251,4,251,174,177,108,51,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4d2a5529-1027-4e39-b5d9-500029d6ce6b"));
		}

		#endregion

	}

	#endregion

}

