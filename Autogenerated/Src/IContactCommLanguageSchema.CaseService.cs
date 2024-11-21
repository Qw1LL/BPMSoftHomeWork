namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IContactCommLanguageSchema

	/// <exclude/>
	public class IContactCommLanguageSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IContactCommLanguageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IContactCommLanguageSchema(IContactCommLanguageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb716256-d7b9-4bb9-a683-e956c5354404");
			Name = "IContactCommLanguage";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77fa8847-960e-4748-ad77-e37bb90e03a0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,77,106,195,48,16,133,215,54,248,14,67,86,233,198,58,64,93,47,154,66,8,180,80,200,9,166,214,200,21,88,146,145,70,148,80,114,247,74,142,157,63,104,187,19,163,247,222,124,111,44,26,10,35,118,4,207,239,111,123,167,184,222,56,171,116,31,61,178,118,182,42,191,171,178,136,65,219,30,246,135,192,100,30,171,50,77,198,248,49,232,14,180,101,242,42,187,119,201,198,216,241,198,25,243,138,182,143,216,83,210,101,119,33,132,128,38,68,99,208,31,218,101,176,37,134,97,22,130,150,100,89,43,77,30,60,13,200,36,225,75,243,39,116,167,208,250,156,34,238,99,154,17,61,26,176,169,198,211,106,150,239,228,170,157,113,174,146,235,70,76,218,139,213,19,71,111,67,187,240,222,138,151,223,44,223,70,45,51,241,122,122,156,215,60,156,142,241,107,193,0,146,20,198,225,170,169,242,206,64,152,46,9,129,152,211,97,255,106,183,64,188,220,231,252,139,58,59,214,153,177,56,86,229,241,7,86,109,222,160,234,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb716256-d7b9-4bb9-a683-e956c5354404"));
		}

		#endregion

	}

	#endregion

}

