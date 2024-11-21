namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBaseColumnProcessorSchema

	/// <exclude/>
	public class IBaseColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBaseColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBaseColumnProcessorSchema(IBaseColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("24ec1cf7-a414-4353-993f-36cb36a92b2f");
			Name = "IBaseColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,142,77,171,194,48,16,69,215,22,250,31,102,231,70,236,254,33,46,44,10,93,8,242,30,184,31,227,68,2,73,38,204,36,130,200,251,239,182,210,226,7,204,230,206,229,28,110,196,64,154,208,16,108,14,251,63,182,121,217,114,180,238,82,4,179,227,184,220,57,79,93,72,44,185,174,238,117,53,107,154,6,86,90,66,64,185,173,199,252,75,73,72,41,102,133,19,42,129,45,209,12,48,122,151,111,96,89,192,176,47,33,206,21,146,176,33,85,150,73,213,188,185,82,57,121,103,192,197,76,98,135,73,221,166,215,181,79,246,48,129,240,3,221,107,84,139,83,179,248,120,11,97,30,201,175,230,221,182,21,97,233,235,49,210,249,136,190,144,246,241,234,206,52,108,188,195,127,93,245,247,0,131,210,211,206,39,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("24ec1cf7-a414-4353-993f-36cb36a92b2f"));
		}

		#endregion

	}

	#endregion

}

