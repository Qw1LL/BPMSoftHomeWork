namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PdfAsyncReportGenerationControllerSchema

	/// <exclude/>
	public class PdfAsyncReportGenerationControllerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PdfAsyncReportGenerationControllerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PdfAsyncReportGenerationControllerSchema(PdfAsyncReportGenerationControllerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("71fc74a3-8eb1-455a-8bf5-06643861c00c");
			Name = "PdfAsyncReportGenerationController";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,82,193,78,227,64,12,61,23,137,127,176,194,5,14,36,215,21,208,74,165,171,162,61,176,170,40,156,16,135,97,226,180,35,37,227,89,143,83,41,90,241,239,120,146,82,90,237,34,144,184,68,242,228,249,249,249,249,121,211,96,12,198,34,92,47,110,151,84,73,62,35,95,185,85,203,70,28,249,227,163,191,199,71,163,54,58,191,130,101,23,5,155,124,137,188,113,22,111,169,196,58,159,90,113,155,30,121,185,195,189,19,49,230,115,99,133,216,97,212,255,138,56,97,92,41,24,102,181,137,241,2,22,101,53,141,157,183,119,24,136,229,6,61,14,99,85,131,48,213,53,114,234,210,190,199,105,12,191,81,102,212,4,5,60,187,218,73,119,135,127,90,199,216,160,151,120,186,95,36,105,48,134,79,90,18,42,223,62,148,103,79,58,164,40,10,184,138,109,211,24,238,38,219,90,149,49,198,132,7,3,118,39,11,168,2,147,148,175,153,60,181,17,22,63,231,231,220,111,1,171,221,26,16,7,175,242,55,242,98,143,61,180,207,181,179,96,147,19,95,48,2,46,224,218,68,252,212,174,145,30,76,191,59,167,23,76,1,89,244,2,106,55,147,160,21,44,7,72,47,201,249,53,178,147,146,84,10,99,53,206,62,156,178,61,124,10,136,168,33,247,93,192,172,72,155,140,194,27,47,208,6,153,157,218,31,133,83,22,246,176,48,158,64,102,66,208,165,77,162,43,66,89,93,130,93,27,142,40,227,135,251,249,249,143,172,15,201,55,164,29,188,19,127,44,239,215,191,52,196,233,216,7,181,42,238,131,58,132,184,203,111,80,174,254,219,57,57,205,52,0,217,217,16,242,209,9,250,114,176,191,175,95,134,232,31,60,190,188,2,56,215,212,158,121,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("71fc74a3-8eb1-455a-8bf5-06643861c00c"));
		}

		#endregion

	}

	#endregion

}

