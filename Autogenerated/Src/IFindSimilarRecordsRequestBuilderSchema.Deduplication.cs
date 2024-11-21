namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFindSimilarRecordsRequestBuilderSchema

	/// <exclude/>
	public class IFindSimilarRecordsRequestBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFindSimilarRecordsRequestBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFindSimilarRecordsRequestBuilderSchema(IFindSimilarRecordsRequestBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f0cc1cb-f956-4f6e-ba88-abeb40ffc587");
			Name = "IFindSimilarRecordsRequestBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,65,75,236,48,16,62,43,248,31,134,122,113,225,209,242,68,16,116,221,131,138,224,65,20,171,39,241,144,109,166,187,129,109,82,39,9,15,81,255,187,147,182,217,238,174,62,236,62,222,165,48,51,153,111,230,251,190,164,90,84,104,107,81,32,156,223,221,228,166,116,233,133,209,165,154,121,18,78,25,157,94,162,244,245,66,21,77,180,183,251,182,183,187,227,173,210,51,200,95,173,195,234,116,25,247,237,132,156,229,252,62,225,140,155,224,90,59,164,146,71,156,192,245,149,210,50,87,149,90,8,186,199,194,144,180,247,248,226,209,186,115,175,22,18,169,105,204,178,12,198,214,87,149,160,215,73,23,119,117,48,37,184,57,114,25,17,10,194,242,44,9,144,151,221,142,24,225,146,108,2,165,33,176,40,168,152,135,253,184,209,182,131,59,68,212,78,57,133,54,141,19,179,149,145,181,159,50,32,168,184,250,144,205,119,88,28,254,46,121,223,160,155,27,105,79,224,174,1,107,139,155,220,122,114,118,56,49,50,21,8,176,53,22,170,84,40,55,155,214,215,188,226,211,185,99,87,228,10,132,51,157,52,16,237,109,133,248,170,68,155,169,5,137,10,52,95,150,179,164,28,48,98,242,192,92,168,13,194,176,105,96,216,16,212,248,39,142,238,234,233,56,107,224,251,105,132,206,147,182,13,136,210,214,9,205,14,108,225,252,183,236,198,89,132,13,115,190,237,109,141,232,130,131,1,82,194,0,45,70,167,63,59,31,149,234,175,236,63,248,226,45,18,63,94,141,69,120,171,201,228,145,99,40,150,137,175,50,111,109,106,100,45,133,19,127,119,45,223,36,16,207,175,234,255,116,59,181,102,129,14,15,146,227,244,247,97,122,4,239,221,131,1,197,13,88,19,134,94,153,2,211,248,249,245,165,219,58,55,74,70,207,3,239,65,208,177,215,21,214,101,254,5,1,165,129,249,143,119,101,31,181,108,255,34,77,252,209,254,79,215,146,31,159,189,177,93,104,186,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f0cc1cb-f956-4f6e-ba88-abeb40ffc587"));
		}

		#endregion

	}

	#endregion

}

