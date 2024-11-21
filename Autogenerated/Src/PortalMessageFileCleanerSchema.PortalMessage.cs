namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PortalMessageFileCleanerSchema

	/// <exclude/>
	public class PortalMessageFileCleanerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalMessageFileCleanerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalMessageFileCleanerSchema(PortalMessageFileCleanerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("58b34129-eda1-43f6-b441-329cc91b3415");
			Name = "PortalMessageFileCleaner";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c85d2d65-6230-4aeb-9934-bfac9785d42f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,84,77,111,219,48,12,61,187,64,255,3,225,94,28,160,179,119,238,18,23,141,219,12,57,4,8,208,13,59,14,138,77,187,2,100,201,211,71,179,108,232,127,31,101,37,105,227,166,89,46,6,68,62,61,62,62,82,150,172,69,211,177,18,97,186,92,60,170,218,166,133,146,53,111,156,102,150,43,121,121,241,247,242,34,114,134,203,6,30,55,198,98,251,101,127,126,189,160,241,120,52,189,159,82,130,82,87,26,27,98,131,66,48,99,110,96,169,180,101,98,129,198,176,6,103,92,96,33,144,73,212,61,182,115,43,193,75,40,61,244,4,50,34,97,244,221,83,207,56,138,202,115,107,254,204,44,134,100,23,14,160,145,85,74,138,13,124,55,168,169,65,137,165,239,14,126,186,131,115,16,27,93,161,172,2,235,97,9,2,26,171,93,105,149,246,133,122,157,1,145,101,25,140,141,107,91,166,55,249,46,48,151,220,114,38,248,31,52,32,113,13,156,110,51,73,78,171,154,192,136,80,106,172,39,241,71,45,198,89,158,238,185,179,33,249,184,99,154,181,32,105,124,147,248,176,139,56,247,93,66,185,15,164,227,172,71,247,151,183,246,126,84,53,25,56,116,72,61,2,191,14,81,52,240,13,38,3,156,95,135,232,229,180,155,11,180,79,170,58,199,200,123,20,104,201,196,174,215,12,109,16,13,53,169,134,213,6,26,254,140,18,120,133,210,242,154,83,231,228,239,17,232,185,102,118,67,103,230,85,156,207,255,203,254,214,227,158,83,163,117,90,154,252,155,118,120,13,188,14,122,215,204,64,213,247,83,93,131,178,79,168,215,220,32,124,130,154,9,227,89,118,215,222,204,106,165,148,216,154,240,110,108,201,87,199,43,56,162,121,55,170,192,215,47,96,160,72,6,195,27,245,176,40,157,105,213,38,239,183,49,222,230,163,244,7,137,197,36,38,59,118,161,40,157,155,135,95,142,137,164,80,194,181,50,93,122,11,168,134,78,142,41,218,51,221,201,42,137,11,122,148,228,194,116,115,30,225,64,117,90,56,173,105,38,126,93,253,47,203,178,210,190,150,72,31,126,99,233,168,215,17,228,240,25,110,129,158,45,194,77,48,249,196,114,134,232,97,240,229,31,81,19,80,96,35,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("58b34129-eda1-43f6-b441-329cc91b3415"));
		}

		#endregion

	}

	#endregion

}

