namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GetXmlSchemaFilesContentResponseSchema

	/// <exclude/>
	public class GetXmlSchemaFilesContentResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetXmlSchemaFilesContentResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetXmlSchemaFilesContentResponseSchema(GetXmlSchemaFilesContentResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("90c4c327-4a7f-a0dd-f8fb-e87a2ae11e91");
			Name = "GetXmlSchemaFilesContentResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0cd720a-279e-436c-a704-8c755267ad15");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,205,106,195,48,16,132,207,14,228,29,68,122,105,160,248,1,210,159,67,98,154,147,139,137,47,133,144,131,162,140,221,5,73,54,146,92,72,75,223,189,43,57,110,104,47,189,136,213,106,52,251,237,88,105,224,123,169,32,214,85,89,119,77,200,55,157,109,168,29,156,12,212,217,188,134,123,39,133,2,158,90,11,55,159,125,206,103,217,224,201,182,162,62,251,0,195,122,173,161,162,216,231,91,176,134,212,253,95,205,110,176,129,12,162,27,73,77,31,201,251,170,186,142,118,152,38,150,221,9,154,89,130,147,42,176,148,197,55,14,45,255,19,27,45,189,95,137,45,194,171,209,181,122,131,145,207,164,225,163,26,54,236,120,33,134,65,250,179,47,100,144,147,205,129,27,253,112,212,164,132,138,30,255,90,136,149,88,75,143,171,99,198,235,243,249,131,82,185,174,135,11,4,230,169,146,243,248,158,198,150,48,71,184,219,23,142,88,60,138,69,19,7,44,150,17,98,162,40,40,5,39,221,249,193,7,199,81,220,9,178,97,127,120,18,137,70,196,176,179,172,69,12,128,11,127,41,190,46,16,176,167,145,35,221,199,238,239,38,247,190,1,166,53,28,221,226,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("90c4c327-4a7f-a0dd-f8fb-e87a2ae11e91"));
		}

		#endregion

	}

	#endregion

}

