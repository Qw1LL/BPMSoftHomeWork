namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITemplateLoaderSchema

	/// <exclude/>
	public class ITemplateLoaderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITemplateLoaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITemplateLoaderSchema(ITemplateLoaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0678da09-bb18-43d7-b171-709841aeb44c");
			Name = "ITemplateLoader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9fb8de7b-ba51-4bde-a802-902958879110");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,83,205,106,194,64,16,62,71,240,29,6,79,22,74,242,0,218,28,42,34,130,133,130,237,3,140,201,36,44,100,39,97,119,246,16,138,239,222,221,109,163,209,214,30,237,45,51,251,253,205,12,97,212,100,59,44,8,158,95,95,246,109,37,233,170,229,74,213,206,160,168,150,167,147,143,233,36,113,86,113,13,251,222,10,233,197,169,94,181,134,46,171,116,205,162,68,145,245,109,255,208,185,67,163,10,80,44,100,170,96,177,125,35,221,53,40,180,107,177,36,227,33,65,61,201,178,12,150,214,105,141,166,207,135,198,187,37,3,69,203,76,69,8,146,158,128,217,24,25,80,171,19,40,146,70,101,84,79,106,146,16,51,57,198,80,191,187,109,72,44,32,3,105,84,13,200,119,76,16,131,108,253,87,16,59,244,160,60,72,149,228,135,172,148,79,55,95,118,104,80,27,170,128,253,26,159,102,145,61,204,184,45,103,89,254,48,24,32,151,80,82,133,174,17,104,144,107,135,53,221,152,41,118,162,242,13,217,124,125,153,242,28,41,93,102,145,120,214,49,36,206,176,189,166,140,7,11,100,233,61,117,192,6,114,188,100,31,246,50,24,207,55,78,149,112,149,229,97,241,223,75,29,150,249,167,198,0,250,162,223,99,239,221,72,103,228,158,239,126,198,189,251,209,30,33,118,207,177,194,21,195,239,113,252,4,211,212,245,63,14,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0678da09-bb18-43d7-b171-709841aeb44c"));
		}

		#endregion

	}

	#endregion

}

