namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CalendarCountTermFactorySchema

	/// <exclude/>
	public class CalendarCountTermFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CalendarCountTermFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CalendarCountTermFactorySchema(CalendarCountTermFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0a4f01d7-03db-4c5d-934f-5339cf3d53d8");
			Name = "CalendarCountTermFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,77,111,219,48,12,61,187,64,255,3,145,93,210,139,125,111,211,0,173,215,110,151,0,5,154,162,103,69,166,29,97,182,100,80,82,50,99,232,127,31,229,175,164,77,183,184,23,25,162,222,123,124,162,69,106,81,161,173,133,68,184,127,90,61,155,220,197,169,209,185,42,60,9,167,140,142,83,81,162,206,4,217,203,139,63,151,23,145,183,74,23,240,220,88,135,213,205,184,63,80,9,227,71,33,157,33,133,246,112,62,138,172,85,133,47,90,57,184,61,151,46,30,160,172,194,58,223,8,11,62,135,180,20,214,194,245,168,152,26,175,221,26,169,234,178,54,45,56,73,18,88,88,95,85,130,154,101,191,31,8,32,3,3,28,83,32,239,56,241,64,73,142,56,181,223,148,74,130,108,243,253,59,91,196,69,225,117,244,183,66,183,53,89,112,248,212,10,116,167,31,13,181,129,31,232,64,138,82,250,178,189,58,84,40,183,66,43,91,193,166,129,66,237,80,131,227,26,128,231,34,4,139,167,30,187,72,45,72,84,160,249,63,222,206,92,95,180,217,114,61,82,23,73,139,56,16,8,157,39,109,151,233,103,201,25,62,156,7,66,95,134,157,34,231,69,9,247,194,226,88,132,112,131,113,51,63,253,199,131,153,43,8,47,39,138,236,94,57,185,133,249,199,120,36,89,245,244,141,196,43,165,189,195,235,14,19,117,174,186,7,208,151,63,102,3,139,14,53,250,88,206,175,110,254,171,250,106,232,23,191,201,105,226,239,192,211,115,252,52,158,206,73,7,204,151,93,79,17,62,130,78,215,255,46,154,115,186,12,249,178,223,9,178,175,35,242,19,245,12,115,225,75,55,104,236,184,127,145,200,208,10,173,21,5,242,24,153,189,104,177,41,17,156,1,73,40,28,130,224,22,39,226,161,102,116,22,134,207,161,225,99,24,187,2,148,229,175,173,81,170,92,97,22,207,250,132,145,219,146,217,131,198,61,220,81,225,43,212,238,225,183,196,58,52,201,252,56,117,239,240,45,172,188,180,51,128,107,208,141,129,118,223,69,223,7,223,254,2,144,27,10,252,111,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0a4f01d7-03db-4c5d-934f-5339cf3d53d8"));
		}

		#endregion

	}

	#endregion

}

