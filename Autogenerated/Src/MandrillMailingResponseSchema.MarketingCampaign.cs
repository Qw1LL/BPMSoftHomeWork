namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MandrillMailingResponseSchema

	/// <exclude/>
	public class MandrillMailingResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MandrillMailingResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MandrillMailingResponseSchema(MandrillMailingResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("300c4950-cc6e-4d74-b555-e972ea0b4444");
			Name = "MandrillMailingResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("aa578739-72a4-4d6e-8c15-4350e99d075d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,77,75,196,64,12,134,207,21,252,15,129,189,183,119,93,60,184,130,236,161,80,182,71,241,48,157,102,107,96,62,202,76,70,92,197,255,110,250,233,42,168,120,155,100,222,55,121,242,58,101,49,246,74,35,220,86,101,237,143,156,239,188,59,82,151,130,98,242,46,47,149,107,3,25,83,99,120,38,81,189,93,94,100,41,146,235,160,62,69,70,123,253,173,206,15,201,49,89,204,197,64,202,208,235,56,70,84,162,219,4,236,164,128,157,81,49,94,193,50,186,84,100,100,192,65,56,188,139,56,74,139,162,128,109,76,214,170,112,186,145,159,100,24,252,17,248,9,87,27,196,25,201,78,254,124,91,44,6,25,240,112,167,88,201,41,28,148,230,71,105,244,169,49,164,65,15,187,127,90,61,92,39,210,21,180,10,190,199,192,132,66,91,141,254,233,255,11,221,210,248,164,156,129,0,95,80,167,49,197,213,116,142,56,49,150,104,27,12,3,225,130,216,120,111,160,78,90,163,144,14,121,103,89,135,60,4,157,101,113,126,188,255,2,50,31,5,145,21,167,248,191,221,247,137,90,168,71,227,190,253,99,249,6,37,196,49,40,169,166,222,121,75,58,31,182,214,199,178,93,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("300c4950-cc6e-4d74-b555-e972ea0b4444"));
		}

		#endregion

	}

	#endregion

}

