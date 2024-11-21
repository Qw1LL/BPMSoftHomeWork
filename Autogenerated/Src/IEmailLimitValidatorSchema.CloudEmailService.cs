namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEmailLimitValidatorSchema

	/// <exclude/>
	public class IEmailLimitValidatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEmailLimitValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEmailLimitValidatorSchema(IEmailLimitValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("45824530-29b2-4569-b8ff-91a6519d7e62");
			Name = "IEmailLimitValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,95,75,195,64,12,127,222,96,223,33,116,47,10,210,190,235,236,131,67,164,224,96,108,232,251,217,166,93,160,119,87,115,119,147,33,251,238,230,214,110,56,167,66,41,52,77,126,255,18,163,52,186,78,149,8,15,203,197,218,214,62,157,91,83,83,19,88,121,178,102,50,254,156,140,71,193,145,105,96,189,115,30,245,221,100,44,149,41,99,35,191,161,48,30,185,150,241,91,40,30,181,162,246,153,52,249,87,213,82,165,188,101,233,148,39,203,50,152,185,160,181,226,93,62,124,47,217,110,169,66,7,26,253,198,86,14,188,133,109,63,134,128,17,9,62,200,111,192,161,169,34,121,27,113,93,122,68,203,190,193,117,225,173,165,18,232,40,229,47,37,226,68,222,23,106,14,133,161,79,244,68,171,237,32,33,210,93,242,245,149,78,177,210,96,36,190,251,68,34,116,170,193,162,74,242,23,67,239,1,65,172,25,79,53,33,131,173,193,111,16,134,158,116,150,29,38,127,7,98,44,169,35,25,117,115,27,140,79,242,213,169,0,101,172,156,197,84,91,254,153,207,5,58,163,15,108,92,62,24,140,59,99,116,161,245,169,236,206,121,101,36,47,81,56,115,136,80,50,214,247,201,217,254,215,200,91,42,113,37,55,98,141,195,36,203,133,226,136,25,73,254,235,62,165,186,232,189,95,61,5,170,142,65,20,213,77,92,153,168,57,179,124,45,247,53,218,247,119,51,21,111,253,157,197,205,237,191,0,147,16,65,206,171,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("45824530-29b2-4569-b8ff-91a6519d7e62"));
		}

		#endregion

	}

	#endregion

}

