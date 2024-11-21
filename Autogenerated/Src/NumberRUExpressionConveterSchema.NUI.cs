namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: NumberRUExpressionConveterSchema

	/// <exclude/>
	public class NumberRUExpressionConveterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NumberRUExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NumberRUExpressionConveterSchema(NumberRUExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d1467aa9-7149-4dab-9d97-0660599142d3");
			Name = "NumberRUExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,143,59,11,194,64,16,132,107,3,249,15,75,42,5,57,176,18,181,243,81,250,192,96,37,22,151,184,137,7,201,93,184,221,19,69,243,223,221,104,107,96,155,157,153,253,134,181,186,70,106,116,142,176,60,108,83,87,176,90,57,91,152,50,120,205,198,217,56,122,197,209,32,144,177,37,164,79,98,172,23,178,203,156,247,25,185,10,25,135,201,84,205,212,4,222,176,118,96,29,67,32,4,190,25,130,188,210,68,99,48,86,206,244,245,171,255,237,80,187,80,103,232,143,167,205,163,241,72,36,146,248,119,244,140,62,25,93,164,172,9,89,101,242,31,16,122,210,18,134,121,159,217,161,64,64,221,51,109,28,181,31,129,147,165,205,246,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d1467aa9-7149-4dab-9d97-0660599142d3"));
		}

		#endregion

	}

	#endregion

}

