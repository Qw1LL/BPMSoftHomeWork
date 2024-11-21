namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MultiDeleteWorkerSchema

	/// <exclude/>
	public class MultiDeleteWorkerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MultiDeleteWorkerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MultiDeleteWorkerSchema(MultiDeleteWorkerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fec963bc-4f40-4b98-bb72-921691cdead0");
			Name = "MultiDeleteWorker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,209,78,219,64,16,124,54,18,255,176,162,18,114,36,148,15,72,9,15,4,132,80,21,53,106,132,120,64,60,92,206,147,112,173,185,179,246,206,64,84,245,223,217,59,219,36,198,109,5,47,103,223,238,120,102,118,214,86,61,194,87,74,131,206,23,243,165,91,135,241,204,217,181,217,212,172,130,113,150,126,31,30,100,181,55,118,67,203,173,15,120,252,250,238,46,240,178,132,142,88,63,190,130,5,27,189,195,236,56,25,127,175,142,47,109,48,193,192,75,91,0,95,24,155,40,59,43,149,247,19,154,215,101,48,23,40,17,112,235,248,23,56,129,170,122,85,26,77,58,98,134,16,154,208,185,242,248,1,237,184,240,223,43,52,147,180,205,56,79,150,197,227,77,74,156,7,174,117,112,44,138,139,196,157,100,58,157,129,66,126,227,193,242,153,109,230,166,186,119,61,161,235,11,147,222,20,111,79,133,90,70,62,33,183,250,41,237,51,170,20,75,226,1,236,71,201,73,54,161,149,184,205,223,115,236,225,90,207,102,77,249,174,26,215,20,148,177,254,27,182,249,209,181,159,41,175,85,129,163,17,29,31,83,190,114,174,28,237,192,119,123,128,123,154,78,73,230,69,199,155,189,69,116,249,2,93,75,12,52,37,139,103,106,18,108,6,231,91,19,30,150,193,85,11,118,26,222,255,207,111,92,116,150,253,33,148,30,159,210,248,0,105,60,229,72,251,131,45,154,21,198,219,254,70,231,8,15,174,136,203,100,23,132,11,69,135,168,186,2,185,39,48,155,2,148,254,191,45,93,33,44,24,34,136,162,169,228,109,3,233,209,133,197,8,53,219,182,152,60,37,75,255,226,126,209,168,210,47,34,244,123,17,180,213,188,99,237,165,64,220,187,77,41,239,181,71,131,40,155,104,90,103,189,143,199,67,205,190,231,65,134,77,182,189,242,225,129,20,95,1,21,255,28,154,39,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fec963bc-4f40-4b98-bb72-921691cdead0"));
		}

		#endregion

	}

	#endregion

}

