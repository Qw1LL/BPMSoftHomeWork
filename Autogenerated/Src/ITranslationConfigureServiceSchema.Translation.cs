namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITranslationConfigureServiceSchema

	/// <exclude/>
	public class ITranslationConfigureServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationConfigureServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationConfigureServiceSchema(ITranslationConfigureServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2811bd82-3edc-4fba-a9ab-749eda63fb70");
			Name = "ITranslationConfigureService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,75,107,131,64,16,62,27,200,127,88,236,37,129,176,222,219,36,135,20,90,82,176,9,49,144,67,232,97,163,163,149,234,174,221,89,3,82,250,223,59,235,106,30,20,210,94,212,253,156,239,177,51,35,69,9,88,137,24,216,98,29,70,42,53,252,81,201,52,207,106,45,76,174,36,223,106,33,177,104,191,135,131,175,225,192,171,49,151,25,139,26,52,80,242,8,244,49,143,33,84,9,20,15,183,126,242,29,28,168,128,74,238,52,100,36,198,150,210,128,78,201,248,158,45,47,76,122,119,232,216,45,39,8,2,54,197,186,44,133,110,230,221,153,76,46,104,44,86,142,198,208,241,120,79,11,46,120,251,78,148,76,140,22,177,25,189,210,237,217,140,249,55,2,248,227,55,98,86,245,161,200,99,150,247,161,255,200,236,81,167,232,249,43,120,11,60,131,193,62,254,41,125,81,151,18,233,221,41,217,248,191,243,59,68,131,169,181,196,249,20,1,88,172,33,157,93,231,111,165,78,153,146,13,205,87,73,4,63,152,79,131,158,107,197,246,171,10,220,148,251,126,216,155,122,123,26,213,82,30,213,7,140,66,48,239,42,177,13,90,175,162,173,63,97,27,248,172,1,205,147,210,165,48,132,83,105,8,136,34,3,7,241,23,84,114,194,22,42,105,34,211,20,182,183,231,146,19,202,119,90,84,21,36,19,107,231,245,249,110,139,182,83,240,254,115,79,219,223,51,122,189,38,29,105,52,118,187,248,237,54,18,100,226,150,210,30,9,251,1,128,166,144,225,20,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2811bd82-3edc-4fba-a9ab-749eda63fb70"));
		}

		#endregion

	}

	#endregion

}

