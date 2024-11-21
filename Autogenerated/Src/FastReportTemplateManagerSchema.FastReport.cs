namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FastReportTemplateManagerSchema

	/// <exclude/>
	public class FastReportTemplateManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FastReportTemplateManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FastReportTemplateManagerSchema(FastReportTemplateManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7f4089a7-7a40-49e7-97e4-e0cfff18a6ec");
			Name = "FastReportTemplateManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a4b49bea-882f-4e7d-ae8d-44e3ec2194f3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,75,110,219,48,16,93,43,64,238,192,58,27,25,8,120,128,166,237,194,142,21,120,97,55,136,221,108,11,150,26,219,4,40,82,32,135,73,132,32,119,239,208,148,20,75,117,189,17,48,31,190,223,200,136,10,124,45,36,176,217,227,106,99,119,200,231,214,236,212,62,56,129,202,26,254,4,181,117,168,204,158,23,194,99,170,174,175,222,175,175,178,224,169,203,54,141,71,168,238,250,250,44,202,185,177,3,234,82,255,198,193,158,86,216,92,11,239,191,178,79,150,45,84,181,22,8,43,97,196,30,220,113,185,14,127,180,146,76,198,221,75,171,25,9,164,111,15,94,40,208,37,161,63,58,245,66,123,105,88,167,130,57,16,165,53,186,97,191,60,56,210,109,64,70,209,236,119,24,212,73,110,118,3,166,76,168,67,10,90,244,232,130,68,235,34,209,81,104,203,147,68,255,87,110,62,226,29,210,78,89,12,59,203,70,106,216,247,209,94,204,56,251,184,172,113,5,120,176,229,121,121,36,62,30,232,1,122,121,249,67,80,37,195,182,90,150,157,146,23,225,24,24,84,216,108,228,1,42,65,82,70,226,248,226,100,220,186,228,132,188,164,136,132,145,48,107,214,244,219,229,147,127,35,153,76,239,70,28,132,126,74,198,231,116,46,132,68,144,143,120,219,199,106,199,242,47,233,17,47,0,229,161,112,182,186,159,229,39,86,58,47,25,30,156,125,101,6,94,217,146,198,107,139,133,13,166,92,188,73,168,35,226,152,225,246,36,15,190,181,155,99,104,249,244,150,93,240,66,71,105,29,117,111,123,79,49,148,109,83,67,57,183,58,84,230,89,232,0,223,210,37,126,228,147,123,129,162,3,137,158,210,128,47,253,58,104,253,211,45,170,154,34,232,48,207,89,250,180,49,144,226,0,131,51,189,154,11,127,78,234,14,155,212,251,11,247,213,197,78,53,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f4089a7-7a40-49e7-97e4-e0cfff18a6ec"));
		}

		#endregion

	}

	#endregion

}

