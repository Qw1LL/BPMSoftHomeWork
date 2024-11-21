namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OmniAfterDeduplicationActionSchema

	/// <exclude/>
	public class OmniAfterDeduplicationActionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmniAfterDeduplicationActionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmniAfterDeduplicationActionSchema(OmniAfterDeduplicationActionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a70187d1-6bbf-4710-ba7a-8c8f800e7324");
			Name = "OmniAfterDeduplicationAction";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,203,110,131,48,16,60,19,169,255,176,165,151,228,2,247,188,164,52,77,165,28,104,35,69,253,0,215,44,96,9,12,90,219,81,163,170,255,94,219,16,21,80,18,245,130,180,227,217,153,241,96,163,132,204,225,249,144,28,235,76,71,219,90,102,34,55,196,180,168,101,244,130,169,105,74,193,253,180,120,152,152,59,220,247,74,10,94,48,41,177,140,18,84,138,229,150,123,101,135,240,42,24,237,164,22,90,160,178,167,15,147,39,194,220,138,194,182,100,74,205,193,105,111,50,141,52,8,180,225,238,235,232,141,249,180,32,112,199,190,75,134,57,236,111,11,125,59,173,224,226,125,160,186,65,114,145,230,112,240,6,254,184,243,250,80,72,182,0,137,173,238,104,180,74,65,144,163,94,64,67,226,196,52,130,178,131,5,127,90,11,148,105,235,226,198,158,167,149,80,154,12,215,53,93,117,189,119,183,233,40,131,25,140,179,54,211,136,179,26,177,254,17,49,65,93,212,233,48,93,28,199,176,84,166,170,24,157,215,221,60,72,8,188,174,154,18,109,15,246,133,164,37,82,116,217,138,71,107,203,134,17,171,64,178,10,87,97,133,148,99,234,95,198,57,92,39,126,2,66,101,74,13,232,209,104,25,251,5,183,222,117,116,170,69,10,187,47,228,70,227,180,221,133,190,80,215,132,200,96,218,135,163,35,47,176,98,111,214,24,30,87,16,218,82,52,227,58,236,232,1,161,54,228,11,114,13,5,65,239,189,119,212,125,234,50,101,194,222,238,181,52,170,232,96,181,101,86,121,244,119,102,183,154,246,216,31,244,11,183,179,32,25,158,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a70187d1-6bbf-4710-ba7a-8c8f800e7324"));
		}

		#endregion

	}

	#endregion

}

