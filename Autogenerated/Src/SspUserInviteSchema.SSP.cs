namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SspUserInviteSchema

	/// <exclude/>
	public class SspUserInviteSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SspUserInviteSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SspUserInviteSchema(SspUserInviteSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0da7f03-8582-4036-b93e-8094a1fe6e41");
			Name = "SspUserInvite";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,193,74,195,64,16,61,91,232,63,12,244,222,220,173,10,85,164,20,84,66,131,39,241,176,110,39,113,33,217,13,51,187,149,82,252,119,119,55,214,54,86,234,90,47,33,25,230,205,123,111,38,51,90,52,200,173,144,8,215,249,125,97,74,59,190,49,186,84,149,35,97,149,209,227,162,200,135,131,205,112,112,230,88,233,10,138,53,91,108,38,195,129,143,140,8,43,159,2,55,181,96,62,135,130,219,71,70,154,235,149,178,24,19,178,44,131,11,118,77,35,104,125,245,249,237,171,91,161,52,18,148,134,160,53,100,69,13,42,98,198,91,72,182,135,105,221,75,173,36,200,192,209,167,128,115,152,239,7,162,94,143,8,98,191,180,229,100,90,36,171,208,11,204,99,169,168,236,64,90,12,220,54,66,213,96,202,173,44,231,75,7,81,135,170,182,178,216,82,232,74,7,220,64,133,118,2,28,30,239,71,104,242,93,245,174,29,210,206,151,199,121,102,78,45,119,185,255,97,2,237,7,158,100,234,193,39,158,196,228,255,145,233,178,81,250,81,171,52,99,125,64,50,103,152,60,144,169,145,127,231,120,122,142,233,139,144,125,146,169,238,125,42,165,113,58,205,213,55,196,223,108,249,42,168,25,211,167,117,215,1,78,30,218,167,206,25,25,215,38,217,235,3,78,226,124,72,53,23,90,242,39,103,11,100,87,219,176,202,97,253,187,75,118,148,232,197,152,26,10,39,37,250,51,211,99,129,75,176,228,112,114,236,110,16,249,91,246,246,170,106,236,78,153,215,156,118,55,34,48,213,84,225,79,156,227,96,138,215,44,194,194,56,191,48,64,40,13,253,50,177,104,111,206,161,143,83,105,213,234,199,78,142,80,47,187,179,25,191,187,104,63,248,254,1,70,5,102,77,47,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0da7f03-8582-4036-b93e-8094a1fe6e41"));
		}

		#endregion

	}

	#endregion

}

