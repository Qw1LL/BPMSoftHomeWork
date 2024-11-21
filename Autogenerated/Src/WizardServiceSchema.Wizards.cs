namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: WizardServiceSchema

	/// <exclude/>
	public class WizardServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WizardServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WizardServiceSchema(WizardServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("467d8f7f-4fb4-4876-adaa-b5904a205d6f");
			Name = "WizardService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("35c77563-f7ec-4c0b-91e3-f2665bae1236");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,193,106,27,49,16,61,175,193,255,48,36,23,27,204,250,158,182,129,216,16,146,128,27,147,109,240,193,228,32,107,199,182,200,74,218,106,180,14,219,210,127,239,72,90,59,107,66,211,163,158,222,188,153,247,102,140,208,72,181,144,8,179,229,162,176,91,159,207,173,217,170,93,227,132,87,214,12,7,191,135,131,172,33,101,118,80,180,228,81,231,5,186,131,146,184,176,37,86,95,62,251,204,111,164,87,135,40,243,57,111,133,155,119,194,113,12,6,121,20,173,99,49,255,94,58,220,177,18,204,43,65,116,5,43,245,75,184,178,147,137,132,233,116,10,95,169,209,90,184,246,186,123,63,123,85,41,223,2,37,30,200,80,12,91,235,224,205,186,215,208,238,77,249,125,39,150,31,69,166,61,149,117,215,130,83,241,78,72,255,18,176,27,170,191,163,231,233,106,118,183,137,45,158,240,103,163,28,106,52,158,70,253,71,176,8,223,224,63,37,129,149,119,64,57,14,77,234,102,83,41,217,77,124,230,22,174,96,38,8,79,222,179,176,162,83,62,11,244,123,91,114,66,203,40,16,163,249,144,77,4,230,21,10,7,178,191,110,32,233,84,237,97,235,172,6,41,104,31,50,249,24,74,182,126,172,49,85,244,115,201,214,188,180,123,115,176,175,56,74,99,176,241,139,229,99,241,227,98,2,51,91,182,133,111,171,16,6,211,22,72,36,118,120,66,243,149,19,117,141,229,36,232,100,33,9,36,127,107,157,22,254,172,32,65,249,3,89,51,129,39,62,93,107,168,3,255,197,139,113,30,243,60,88,85,38,231,103,119,94,68,223,163,49,196,44,179,243,63,228,59,182,230,14,43,54,157,167,90,33,247,56,122,230,179,98,166,73,255,227,112,195,217,159,20,248,37,154,50,45,132,95,9,235,67,195,1,99,127,1,167,217,86,248,123,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("467d8f7f-4fb4-4876-adaa-b5904a205d6f"));
		}

		#endregion

	}

	#endregion

}

