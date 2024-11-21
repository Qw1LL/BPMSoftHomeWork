namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TimeColumnProcessorSchema

	/// <exclude/>
	public class TimeColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TimeColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TimeColumnProcessorSchema(TimeColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("761b0013-5b74-46b7-87d9-cd9671c4ab75");
			Name = "TimeColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1a247561-b87d-48fb-9e13-b6a8baa960d3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,193,110,219,48,12,134,207,41,208,119,32,178,75,2,12,246,189,107,2,44,41,58,228,208,33,64,155,93,134,30,20,153,78,9,216,146,75,73,5,130,161,239,62,74,74,214,58,117,7,180,23,91,162,127,254,20,63,209,70,181,232,58,165,17,22,235,155,91,91,251,98,105,77,77,187,192,202,147,53,197,53,53,184,106,59,203,254,252,236,207,249,217,40,56,50,59,184,221,59,143,237,183,127,251,151,92,198,225,104,113,173,180,183,76,232,228,187,40,190,48,238,196,31,150,141,114,238,2,238,168,197,165,109,66,107,214,108,53,58,103,57,201,202,178,132,75,50,15,200,228,43,171,65,51,214,179,241,149,242,56,144,49,46,231,199,20,23,218,86,241,254,184,255,110,128,140,243,202,72,159,182,6,255,64,14,116,172,12,178,96,1,96,141,163,109,131,80,91,134,46,251,197,14,98,33,208,169,10,60,169,38,160,43,142,21,202,87,37,126,95,97,173,66,227,23,100,42,73,155,248,125,135,182,158,172,78,206,55,253,10,63,5,55,204,192,200,75,4,3,61,76,167,247,98,216,133,109,67,250,112,196,1,21,92,164,163,13,82,27,201,53,201,243,133,176,244,230,57,68,250,2,122,157,156,179,226,19,112,223,208,77,129,37,163,36,185,62,99,97,32,74,196,131,237,176,101,196,249,150,103,142,116,138,85,155,80,205,198,193,33,75,35,6,117,156,202,241,124,35,123,185,152,99,160,184,44,147,58,37,31,224,13,20,156,108,122,54,208,119,157,10,213,173,114,56,57,13,199,185,31,61,31,168,162,169,50,216,62,101,169,209,33,123,153,111,97,204,214,75,46,86,255,195,188,144,74,31,64,44,183,162,242,8,102,178,193,208,163,172,169,66,227,169,38,228,119,72,202,48,231,179,128,125,66,102,209,195,143,64,85,242,251,21,237,238,196,109,179,170,96,54,239,199,138,200,239,84,149,255,221,83,8,25,77,63,248,252,23,202,60,143,19,89,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("761b0013-5b74-46b7-87d9-cd9671c4ab75"));
		}

		#endregion

	}

	#endregion

}

