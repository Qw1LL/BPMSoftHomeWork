namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MLDefaultProblemTypeFeaturesSchema

	/// <exclude/>
	public class MLDefaultProblemTypeFeaturesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MLDefaultProblemTypeFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MLDefaultProblemTypeFeaturesSchema(MLDefaultProblemTypeFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d30cac6-8bd4-4ed6-a823-a8838e7983e0");
			Name = "MLDefaultProblemTypeFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b54cb82a-9c72-40e4-855f-14a0ef44684e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,203,106,195,48,16,69,215,49,248,31,102,105,111,236,125,211,118,145,132,208,130,77,3,237,174,116,49,118,70,70,32,75,70,154,9,132,144,127,175,252,8,4,18,16,2,13,119,14,247,200,98,79,97,192,150,96,115,168,191,157,226,98,235,172,210,157,120,100,237,108,81,87,105,114,73,147,149,4,109,187,187,140,167,98,143,45,59,175,41,172,211,36,38,202,178,132,215,32,125,143,254,252,190,188,119,164,80,12,131,34,100,241,4,39,52,66,1,148,243,128,198,192,224,93,99,168,7,62,15,20,138,27,163,188,131,252,46,132,141,182,199,88,32,27,147,78,101,159,117,117,152,119,127,226,96,63,211,67,158,255,197,149,65,26,163,91,104,13,134,0,117,181,0,158,196,225,5,158,115,34,36,42,199,251,193,105,26,124,96,0,39,60,8,67,198,232,59,226,28,90,103,164,183,147,88,239,142,100,128,61,106,27,27,143,86,143,90,183,146,39,237,89,208,64,227,156,25,185,95,19,118,59,195,46,16,209,107,184,194,91,164,9,197,95,94,93,211,36,158,127,176,121,173,69,180,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d30cac6-8bd4-4ed6-a823-a8838e7983e0"));
		}

		#endregion

	}

	#endregion

}

