namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBaseFileImportStageSchema

	/// <exclude/>
	public class IBaseFileImportStageSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBaseFileImportStageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBaseFileImportStageSchema(IBaseFileImportStageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2e54df01-9a20-4cc1-b98f-462bb7d75af3");
			Name = "IBaseFileImportStage";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a83ae89b-1206-453d-b626-f37ab41fffbf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,77,106,195,48,16,133,215,54,248,14,131,179,105,55,209,62,105,186,72,73,193,139,128,33,39,80,165,177,43,176,126,208,200,37,33,244,238,85,164,36,110,211,20,186,211,140,190,121,243,244,100,184,70,114,92,32,172,219,237,206,118,97,254,98,77,167,250,209,243,160,172,153,191,170,1,27,237,172,15,85,121,172,202,170,44,102,30,251,120,3,208,152,128,190,139,163,11,104,214,156,112,66,119,129,247,152,96,55,190,13,74,128,186,160,127,144,69,148,46,174,202,173,183,14,125,80,72,11,104,147,64,210,42,24,99,240,68,163,214,220,31,158,47,141,164,0,74,94,1,246,157,184,217,68,27,51,234,60,210,72,56,66,143,97,9,159,89,125,134,70,102,3,231,250,236,102,139,225,221,202,255,88,217,236,81,140,1,193,121,43,144,8,40,91,51,32,209,171,15,148,32,6,78,132,116,223,106,234,56,238,185,6,19,63,101,85,167,51,198,224,168,158,0,66,4,225,177,91,213,249,89,237,4,177,137,98,105,54,213,247,2,63,37,124,114,152,138,135,91,33,152,22,63,46,127,103,83,228,188,126,198,21,123,95,46,166,251,158,74,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2e54df01-9a20-4cc1-b98f-462bb7d75af3"));
		}

		#endregion

	}

	#endregion

}

