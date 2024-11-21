namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SubjectEmailHashComposerSchema

	/// <exclude/>
	public class SubjectEmailHashComposerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SubjectEmailHashComposerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SubjectEmailHashComposerSchema(SubjectEmailHashComposerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ab466a0-81cf-410f-864e-38ae3b3a01c4");
			Name = "SubjectEmailHashComposer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,97,107,219,48,16,253,236,66,255,195,209,125,177,33,56,223,187,182,208,36,109,23,88,183,178,180,12,54,246,65,177,47,206,13,89,10,58,41,155,25,253,239,61,217,138,219,174,27,24,195,189,119,122,247,244,78,70,181,200,59,85,33,204,238,110,87,118,227,203,185,53,27,106,130,83,158,172,57,62,250,115,124,148,5,38,211,192,170,99,143,173,240,90,99,21,73,46,111,208,160,163,234,253,216,243,44,226,240,223,104,121,173,42,111,29,33,11,47,29,211,233,20,206,56,180,173,114,221,69,170,231,90,49,67,229,80,121,100,192,86,145,134,173,226,173,20,100,42,29,234,40,186,179,204,180,214,8,149,53,123,116,62,98,162,219,144,81,26,56,172,127,138,201,242,48,96,250,98,194,247,5,110,84,208,126,70,38,10,229,190,219,161,221,228,203,171,56,231,131,140,153,219,86,196,209,21,19,248,36,241,192,57,156,172,6,189,55,45,39,197,15,81,220,133,181,166,10,170,222,246,255,90,225,20,102,138,241,13,46,231,37,99,249,103,239,28,54,18,43,220,162,223,218,154,79,225,174,215,29,200,52,195,202,85,29,213,8,203,43,19,90,116,74,18,56,99,239,228,34,23,112,131,62,42,35,231,15,34,44,139,52,195,162,32,188,42,39,48,154,88,220,127,30,242,45,32,46,58,203,62,18,251,81,47,101,126,14,6,127,193,75,38,47,226,114,179,108,175,220,33,106,233,186,20,245,61,249,238,193,147,230,242,154,126,127,221,146,31,94,23,231,253,148,50,133,147,142,15,250,229,101,93,127,81,166,193,124,244,191,52,30,157,236,49,255,219,120,52,242,202,252,224,58,75,186,98,34,217,153,36,28,77,189,144,87,36,68,50,144,128,196,207,108,221,141,92,44,18,126,79,45,126,179,230,249,220,1,232,233,199,34,93,192,161,15,206,164,156,122,232,49,173,82,198,12,219,236,107,65,229,123,2,53,50,51,31,108,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ab466a0-81cf-410f-864e-38ae3b3a01c4"));
		}

		#endregion

	}

	#endregion

}

