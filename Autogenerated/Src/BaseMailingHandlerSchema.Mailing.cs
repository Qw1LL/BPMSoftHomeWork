namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseMailingHandlerSchema

	/// <exclude/>
	public class BaseMailingHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseMailingHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseMailingHandlerSchema(BaseMailingHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c034f568-64d4-4b23-8e61-b1ebaf6fc883");
			Name = "BaseMailingHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0a66fb70-43c4-43cd-a81c-f036ca2264c0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,93,75,235,64,16,125,142,224,127,24,234,139,23,36,121,183,181,160,21,123,123,161,151,98,241,7,108,146,105,187,178,217,13,251,81,40,226,127,191,147,221,77,154,212,170,215,151,194,206,156,153,57,103,230,164,146,85,104,106,86,32,60,172,150,107,181,177,233,76,201,13,223,58,205,44,87,242,242,226,237,242,34,113,134,203,45,172,15,198,98,69,121,33,176,104,146,38,157,163,68,205,139,113,135,57,54,209,120,62,154,174,139,29,150,78,160,166,60,33,174,52,110,169,23,204,4,51,230,22,30,152,193,37,227,130,202,126,51,89,18,204,163,178,44,131,137,113,85,197,244,97,26,223,13,20,170,128,133,93,0,167,45,54,235,129,107,151,11,94,0,203,141,213,172,176,80,52,163,206,76,130,91,88,156,206,78,72,63,253,118,52,159,56,138,146,120,174,52,223,51,139,33,89,135,7,104,100,165,146,226,0,52,168,33,245,170,242,185,86,174,254,75,75,134,59,24,197,230,163,160,60,185,66,89,134,182,195,25,43,173,106,212,150,163,159,163,44,109,27,203,118,82,124,30,213,196,89,4,44,208,24,63,170,185,89,146,108,209,54,39,72,222,191,43,253,163,242,255,41,219,115,109,29,19,189,170,163,184,174,20,222,104,11,214,105,57,16,63,134,247,94,203,207,116,47,209,238,84,249,149,232,150,194,35,247,6,164,251,78,2,155,27,80,249,43,97,166,48,71,187,98,154,102,90,212,230,250,197,160,38,67,203,96,88,112,131,231,175,72,59,18,150,78,136,241,143,104,122,95,133,228,169,65,125,96,70,134,176,104,128,75,99,153,164,111,76,109,192,238,176,111,214,143,110,13,145,186,209,0,146,116,220,141,134,172,71,211,69,175,93,147,131,162,75,166,147,204,87,250,70,167,190,223,43,94,70,78,139,216,226,155,5,69,163,158,21,247,140,149,218,255,88,92,228,212,30,210,83,10,157,58,74,237,89,238,235,186,251,175,72,3,134,60,119,29,221,122,51,48,96,195,244,179,195,133,232,48,72,177,127,23,65,139,2,250,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c034f568-64d4-4b23-8e61-b1ebaf6fc883"));
		}

		#endregion

	}

	#endregion

}

