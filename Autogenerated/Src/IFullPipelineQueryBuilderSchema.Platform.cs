namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFullPipelineQueryBuilderSchema

	/// <exclude/>
	public class IFullPipelineQueryBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFullPipelineQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFullPipelineQueryBuilderSchema(IFullPipelineQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("72be6cd2-93c1-4725-9a00-7c556867169a");
			Name = "IFullPipelineQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eccc4091-3404-497f-94e5-8c10d0f3a0d7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,77,79,195,48,12,61,111,210,254,131,213,93,64,66,237,125,116,61,116,12,180,195,80,209,248,3,89,235,110,145,242,81,156,4,169,66,252,119,210,100,29,131,33,14,141,234,103,191,231,23,199,138,73,52,29,171,17,202,106,187,211,173,77,87,90,181,252,224,136,89,174,213,108,250,49,155,78,156,225,234,0,187,222,88,148,62,47,4,214,67,210,164,79,168,144,120,125,127,174,89,105,194,244,161,244,128,135,230,132,7,95,6,27,101,145,90,223,99,1,155,71,39,68,197,59,20,92,225,139,67,234,75,199,69,131,20,8,89,150,65,110,156,148,140,250,226,20,87,164,223,121,131,6,36,218,163,110,192,106,120,27,120,176,143,68,104,181,255,188,42,116,39,217,116,84,202,46,164,58,183,23,188,6,62,90,249,207,201,196,223,217,159,103,255,219,208,217,44,160,10,34,49,249,219,107,0,130,132,1,123,196,104,114,176,114,237,37,34,29,35,38,65,249,249,47,147,58,204,220,36,197,171,103,158,130,52,207,66,201,223,12,83,31,81,178,103,255,159,20,195,9,186,13,109,35,126,205,37,180,142,148,41,114,131,190,3,97,187,76,118,56,188,99,146,21,121,54,102,135,242,8,199,171,132,185,220,108,214,202,73,36,182,23,152,95,78,109,173,44,183,125,220,151,98,180,125,7,198,210,176,10,223,14,111,227,58,76,230,168,154,56,210,16,127,198,37,249,1,122,236,11,190,147,40,245,146,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("72be6cd2-93c1-4725-9a00-7c556867169a"));
		}

		#endregion

	}

	#endregion

}

