namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: UpperExpressionConveterSchema

	/// <exclude/>
	public class UpperExpressionConveterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpperExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpperExpressionConveterSchema(UpperExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27fcf242-4fd9-4cab-8a03-9f96704724a7");
			Name = "UpperExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,143,63,11,194,64,12,197,103,11,253,14,161,147,130,28,56,137,186,249,103,20,133,226,36,14,215,154,182,7,237,221,113,201,137,162,253,238,166,186,22,178,188,188,151,223,35,86,119,72,94,151,8,219,243,49,119,21,171,157,179,149,169,99,208,108,156,77,147,119,154,76,34,25,91,67,254,34,198,110,35,90,230,122,42,200,181,200,56,205,150,106,165,22,240,129,189,3,235,24,34,33,112,99,8,202,86,19,205,193,88,57,211,247,223,126,180,67,93,188,199,112,120,250,128,68,162,197,124,96,96,12,217,236,38,77,62,22,173,41,255,52,24,139,74,18,214,163,206,0,1,65,12,63,244,105,210,127,1,230,112,134,152,237,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27fcf242-4fd9-4cab-8a03-9f96704724a7"));
		}

		#endregion

	}

	#endregion

}

