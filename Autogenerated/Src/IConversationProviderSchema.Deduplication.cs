namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IConversationProviderSchema

	/// <exclude/>
	public class IConversationProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IConversationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IConversationProviderSchema(IConversationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae9b308e-924f-4ea5-bac1-90760e48d38f");
			Name = "IConversationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b5c46c08-cc76-4157-b24b-44267444e258");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,193,106,2,49,16,134,207,10,190,195,96,47,45,136,123,175,214,131,34,101,161,22,193,67,207,113,51,187,6,54,201,50,73,164,82,250,238,77,178,174,174,104,177,218,227,36,255,204,124,255,36,227,140,80,5,172,118,198,162,28,245,186,189,174,98,18,77,197,50,132,233,114,177,210,185,29,206,180,202,69,225,136,89,161,21,124,5,81,231,129,176,8,81,170,44,82,238,213,207,144,122,221,22,201,68,217,146,244,86,112,164,40,78,146,4,198,198,73,201,104,55,217,199,169,172,74,148,168,172,129,82,23,69,128,208,57,224,39,102,46,182,241,65,69,58,67,238,8,135,77,141,164,85,164,114,235,82,100,32,26,128,203,253,247,184,103,8,241,224,205,55,70,238,75,228,154,100,237,142,173,181,179,176,246,230,148,10,76,191,3,157,19,213,39,21,35,38,33,76,241,165,127,72,120,247,97,127,178,108,194,120,61,28,39,81,123,76,37,180,142,148,153,180,141,128,224,94,216,220,4,233,171,19,28,166,129,176,173,123,52,150,2,240,73,203,167,209,61,238,51,29,222,166,49,109,55,120,187,241,172,69,150,242,254,5,71,71,235,91,237,253,204,21,63,113,19,77,158,86,185,207,12,18,105,2,207,254,255,215,188,197,212,89,114,228,152,105,238,191,193,60,34,253,41,97,129,198,176,226,144,227,55,51,132,87,199,247,33,236,166,206,184,52,200,65,88,154,122,48,1,104,0,251,175,211,238,24,134,221,249,174,87,29,21,175,183,189,215,245,39,63,2,21,207,108,49,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae9b308e-924f-4ea5-bac1-90760e48d38f"));
		}

		#endregion

	}

	#endregion

}

