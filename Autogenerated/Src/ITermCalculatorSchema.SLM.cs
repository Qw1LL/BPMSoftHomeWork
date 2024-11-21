namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITermCalculatorSchema

	/// <exclude/>
	public class ITermCalculatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITermCalculatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITermCalculatorSchema(ITermCalculatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bf14023c-5dd2-42fc-a1c9-2ee0dcd85fa4");
			Name = "ITermCalculator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,145,77,106,195,48,16,133,215,21,232,14,67,86,237,198,58,64,93,47,154,110,186,40,20,43,23,80,213,113,16,88,63,104,164,64,8,185,123,165,56,118,26,2,205,170,59,205,204,123,250,230,73,153,140,219,130,220,83,66,251,204,25,103,78,89,164,160,52,194,235,231,135,244,67,106,214,222,13,102,155,163,74,198,187,70,98,220,25,141,27,140,150,179,3,103,15,66,8,104,41,91,171,226,190,59,215,61,134,136,132,46,17,208,164,135,84,12,160,213,168,243,168,146,143,205,236,20,191,172,33,127,141,70,131,113,69,60,212,21,222,43,102,189,152,138,164,18,111,144,167,198,44,67,40,232,224,29,33,124,151,170,130,110,73,83,39,168,168,44,212,196,47,43,74,42,166,183,98,88,117,178,30,39,115,43,78,154,139,37,98,202,209,81,215,95,49,90,49,247,171,176,222,178,49,22,47,43,245,103,117,157,60,46,227,5,249,84,94,254,110,42,242,99,174,63,240,159,169,228,21,227,94,170,89,253,87,170,35,103,199,31,219,184,79,36,100,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bf14023c-5dd2-42fc-a1c9-2ee0dcd85fa4"));
		}

		#endregion

	}

	#endregion

}

