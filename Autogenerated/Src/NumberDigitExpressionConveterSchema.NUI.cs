namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: NumberDigitExpressionConveterSchema

	/// <exclude/>
	public class NumberDigitExpressionConveterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NumberDigitExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NumberDigitExpressionConveterSchema(NumberDigitExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f5ab4edf-58fd-4173-bee4-f6489fa39530");
			Name = "NumberDigitExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,187,10,194,64,16,69,107,23,242,15,67,42,5,89,176,18,181,211,88,250,128,148,98,177,137,99,28,72,118,195,206,172,40,154,127,119,163,173,218,158,185,247,92,198,154,6,185,53,37,194,114,191,201,221,89,244,202,217,51,85,193,27,33,103,19,245,72,212,32,48,217,10,242,59,11,54,139,68,69,114,216,21,236,106,20,28,166,83,61,211,19,120,66,230,192,58,129,192,8,114,33,134,178,54,204,99,32,27,91,230,244,230,95,39,244,54,52,5,250,140,42,146,245,173,245,200,28,105,140,92,209,11,250,116,116,140,123,109,40,106,42,63,78,248,93,136,121,152,255,185,247,66,136,186,254,169,46,81,221,11,202,234,185,142,254,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f5ab4edf-58fd-4173-bee4-f6489fa39530"));
		}

		#endregion

	}

	#endregion

}

