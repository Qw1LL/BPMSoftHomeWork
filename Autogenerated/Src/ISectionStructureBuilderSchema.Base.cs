namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISectionStructureBuilderSchema

	/// <exclude/>
	public class ISectionStructureBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISectionStructureBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISectionStructureBuilderSchema(ISectionStructureBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f3b188d-ae35-4cb4-bff8-fb00b0b7fadd");
			Name = "ISectionStructureBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,77,10,194,48,16,133,215,41,244,14,1,55,10,210,3,232,202,234,166,11,69,200,9,98,50,173,3,249,35,63,66,145,222,221,164,69,221,136,171,225,205,188,153,247,141,225,26,130,227,2,104,123,61,51,219,199,230,104,77,143,67,242,60,162,53,117,245,172,171,186,34,41,160,25,40,27,67,4,189,255,232,239,138,135,223,221,230,212,230,65,30,173,60,12,249,30,237,76,4,223,231,188,29,237,24,136,146,193,162,79,34,38,15,109,66,37,193,207,126,151,110,10,5,197,183,253,143,155,100,68,66,30,22,37,61,56,167,198,99,10,209,234,252,134,196,178,16,214,33,250,194,21,196,29,52,191,228,135,183,148,129,202,231,104,152,203,166,176,79,11,38,24,185,144,22,57,189,0,222,149,166,84,30,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f3b188d-ae35-4cb4-bff8-fb00b0b7fadd"));
		}

		#endregion

	}

	#endregion

}

