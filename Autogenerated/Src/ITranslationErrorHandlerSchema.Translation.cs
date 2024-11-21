namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITranslationErrorHandlerSchema

	/// <exclude/>
	public class ITranslationErrorHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationErrorHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationErrorHandlerSchema(ITranslationErrorHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("89e47229-db11-45c3-8172-96402d1727d6");
			Name = "ITranslationErrorHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,203,110,194,48,16,60,131,196,63,172,224,210,74,85,114,167,41,135,62,212,114,64,66,208,31,48,246,38,88,117,236,104,215,65,138,42,254,189,182,211,0,69,162,39,175,215,227,153,241,172,91,214,182,130,109,199,30,235,236,197,25,131,210,107,103,57,123,71,139,164,229,227,100,60,25,91,81,35,55,66,34,60,175,87,91,87,250,128,180,165,174,90,18,17,156,125,146,176,108,82,61,25,127,199,27,163,25,97,21,182,176,180,30,169,12,87,231,176,188,128,189,17,57,250,16,86,25,164,132,111,218,157,209,18,244,0,255,7,61,234,21,78,18,43,244,123,167,120,14,235,196,209,31,230,121,14,5,183,117,45,168,91,12,141,53,18,107,246,12,24,9,25,156,148,45,161,2,213,82,76,65,52,141,233,98,225,207,210,156,157,216,242,107,186,162,17,36,106,136,233,60,77,35,165,117,45,111,80,58,82,60,93,36,211,16,130,99,81,33,131,236,179,13,106,101,104,7,12,133,72,157,85,87,122,240,133,29,103,69,158,168,147,210,193,105,5,91,113,192,68,200,119,175,58,77,40,24,41,216,71,223,15,208,175,139,244,172,11,15,247,105,120,55,178,216,96,237,14,193,151,48,166,143,227,108,181,36,87,131,223,35,92,140,0,188,216,25,188,17,70,178,184,65,70,255,235,113,80,158,161,85,253,148,210,254,216,127,141,63,205,35,252,0,16,117,121,215,131,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("89e47229-db11-45c3-8172-96402d1727d6"));
		}

		#endregion

	}

	#endregion

}

