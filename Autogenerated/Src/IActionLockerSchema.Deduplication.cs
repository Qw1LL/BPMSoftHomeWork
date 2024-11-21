namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IActionLockerSchema

	/// <exclude/>
	public class IActionLockerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IActionLockerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IActionLockerSchema(IActionLockerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb40de33-e3f6-43df-ac5e-ea49b9ed783e");
			Name = "IActionLocker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b5c46c08-cc76-4157-b24b-44267444e258");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,219,106,195,48,12,125,94,161,255,32,178,151,13,74,253,190,118,129,46,27,163,176,141,65,190,192,117,148,214,52,177,131,47,101,101,236,223,231,75,186,38,180,164,133,189,36,150,116,164,35,29,217,86,115,177,134,124,175,13,214,179,241,104,60,18,180,70,221,80,134,240,244,249,158,203,210,76,51,41,74,190,182,138,26,46,5,124,123,208,205,173,194,181,183,150,194,160,42,29,250,1,150,11,230,1,111,146,109,81,5,16,33,4,230,218,214,53,85,251,180,181,93,49,163,100,165,129,50,134,90,131,145,128,95,200,108,168,45,75,144,13,70,34,61,61,84,32,157,18,141,93,85,156,1,63,208,246,89,219,230,78,136,131,195,67,136,21,149,251,13,81,158,114,70,79,67,21,173,193,171,243,152,48,41,118,168,116,72,90,22,73,154,117,108,224,197,116,78,2,250,124,178,102,27,172,233,135,59,39,105,30,206,33,48,156,244,215,163,167,123,198,194,54,78,6,106,142,189,95,164,229,218,11,144,164,254,11,218,80,211,103,220,73,94,64,142,198,135,115,31,189,123,181,206,211,159,116,226,18,149,191,47,199,25,38,16,112,157,254,38,176,146,178,130,200,119,63,27,216,72,182,65,182,117,55,97,197,43,110,246,237,82,176,183,146,107,55,34,255,173,207,213,107,81,104,172,18,58,93,92,188,192,115,114,192,250,228,160,74,70,197,75,28,51,234,219,233,251,140,184,173,122,63,241,201,161,40,226,171,243,166,243,253,2,116,101,250,79,187,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb40de33-e3f6-43df-ac5e-ea49b9ed783e"));
		}

		#endregion

	}

	#endregion

}

