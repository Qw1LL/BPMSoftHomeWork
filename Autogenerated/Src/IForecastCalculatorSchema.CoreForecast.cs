namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IForecastCalculatorSchema

	/// <exclude/>
	public class IForecastCalculatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IForecastCalculatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IForecastCalculatorSchema(IForecastCalculatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ec2b165-5e49-4298-bc0b-1de925207e9f");
			Name = "IForecastCalculator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,75,107,2,49,16,62,43,248,31,6,189,180,151,13,120,108,237,30,42,20,60,8,130,224,125,154,157,72,32,143,101,146,20,74,241,191,27,163,219,108,171,144,195,76,190,215,36,227,208,82,232,81,18,188,239,182,123,175,98,179,246,78,233,99,98,140,218,187,230,195,51,73,12,241,176,132,159,217,116,146,207,130,233,152,17,216,184,72,172,178,242,5,54,3,107,141,70,38,131,209,243,108,154,169,66,8,88,133,100,45,242,119,123,235,43,5,244,224,0,42,119,234,230,1,210,155,100,93,104,6,3,49,114,232,211,167,209,114,164,124,24,61,185,140,122,151,254,39,158,194,255,64,248,66,147,168,196,222,231,94,111,122,100,180,224,242,151,189,205,75,77,121,140,48,111,119,191,117,179,18,5,168,26,166,152,216,133,118,235,59,173,52,117,80,133,153,60,160,23,250,248,37,197,49,212,105,159,30,128,213,232,249,53,235,79,229,203,23,228,186,235,130,202,182,78,103,193,109,128,2,224,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ec2b165-5e49-4298-bc0b-1de925207e9f"));
		}

		#endregion

	}

	#endregion

}

