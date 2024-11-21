namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITranslationServiceSchema

	/// <exclude/>
	public class ITranslationServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationServiceSchema(ITranslationServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8368303c-f5ee-4bf3-920a-9f76b46f2286");
			Name = "ITranslationService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6d72ca66-8680-4c3f-b4a0-15ba7a19db7c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,83,77,139,194,48,20,60,87,240,63,132,122,169,80,250,3,148,61,168,176,208,133,174,197,10,30,202,30,98,250,90,131,109,146,77,210,66,119,217,255,190,175,173,138,162,120,223,189,132,100,50,243,230,77,62,4,173,192,40,202,128,44,227,40,145,185,13,86,82,228,188,168,53,181,92,138,96,171,169,48,101,63,31,143,190,199,35,167,54,92,20,36,105,141,133,42,72,64,55,156,65,36,51,40,231,207,54,131,29,236,145,128,148,137,134,2,139,145,80,88,208,57,26,207,72,120,101,114,18,245,212,244,180,192,142,172,166,204,122,239,216,44,121,33,238,61,223,157,126,160,64,213,251,146,51,194,207,165,31,87,118,48,6,142,151,78,34,176,7,153,153,25,137,123,249,176,153,174,21,12,71,112,118,239,12,156,20,115,132,162,145,71,240,6,89,215,78,188,78,182,174,79,54,240,89,131,177,175,82,87,212,34,142,212,8,140,161,5,12,80,240,102,164,240,201,82,102,109,98,219,18,110,40,23,52,216,105,170,20,100,126,103,231,108,240,114,164,48,240,188,104,31,222,105,36,207,200,130,217,154,150,252,11,174,146,123,211,249,159,13,117,127,129,103,53,89,40,85,182,255,63,230,234,0,236,248,40,230,4,68,54,60,225,126,253,51,124,175,27,16,177,95,126,252,89,67,225,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8368303c-f5ee-4bf3-920a-9f76b46f2286"));
		}

		#endregion

	}

	#endregion

}

