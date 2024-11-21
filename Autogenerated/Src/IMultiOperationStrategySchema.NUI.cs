namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMultiOperationStrategySchema

	/// <exclude/>
	public class IMultiOperationStrategySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMultiOperationStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMultiOperationStrategySchema(IMultiOperationStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("adc64851-8f11-475d-84ca-1c46bf4d2941");
			Name = "IMultiOperationStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,81,75,195,48,16,199,159,59,216,119,56,230,139,130,52,239,90,251,48,133,81,112,42,20,63,64,108,46,229,160,77,234,37,17,138,236,187,155,172,180,195,77,33,36,185,203,239,127,255,36,103,100,143,110,144,13,194,246,109,95,91,237,243,71,107,52,181,129,165,39,107,214,171,239,245,42,11,142,76,11,245,232,60,246,247,103,113,228,187,14,155,4,187,124,135,6,153,154,200,68,234,138,177,141,89,168,140,71,214,209,226,14,170,125,232,60,189,14,56,85,175,125,92,177,29,143,248,16,62,58,106,128,102,250,127,56,75,119,202,132,16,80,184,208,247,146,199,114,78,60,89,176,179,0,226,40,6,201,178,103,212,96,226,67,31,54,104,60,249,241,37,238,55,162,188,56,101,108,44,43,87,169,120,152,47,30,226,220,100,146,93,86,44,211,12,86,195,148,203,11,113,4,255,214,157,188,202,119,67,159,1,129,84,210,105,66,118,191,164,95,150,84,124,216,242,17,215,206,115,250,255,147,243,45,60,147,243,197,46,144,42,97,41,124,147,90,117,152,90,129,70,77,221,72,225,225,7,187,134,59,42,245,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("adc64851-8f11-475d-84ca-1c46bf4d2941"));
		}

		#endregion

	}

	#endregion

}

