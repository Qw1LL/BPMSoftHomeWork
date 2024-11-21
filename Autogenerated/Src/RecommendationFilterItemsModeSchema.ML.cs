namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RecommendationFilterItemsModeSchema

	/// <exclude/>
	public class RecommendationFilterItemsModeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecommendationFilterItemsModeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecommendationFilterItemsModeSchema(RecommendationFilterItemsModeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab1853cd-ba91-4c11-942e-58eb26dfa9d8");
			Name = "RecommendationFilterItemsMode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("55b53857-a033-4921-8f47-13b5471dd33e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,144,187,10,2,49,16,69,235,93,216,127,24,176,149,77,47,98,161,40,88,8,162,136,117,204,78,214,96,30,107,30,160,136,255,110,18,21,20,5,193,46,55,115,231,206,153,209,84,161,235,40,67,24,47,23,107,195,125,61,49,154,139,54,88,234,133,209,80,149,151,170,172,202,162,103,177,77,122,170,131,26,192,10,153,81,10,117,147,77,51,33,61,218,185,71,229,22,166,193,236,39,132,192,208,5,165,168,61,143,30,58,21,193,112,224,217,15,66,131,125,203,137,242,24,208,249,250,217,79,94,2,186,176,147,130,1,198,249,191,198,23,17,185,248,32,200,31,27,23,9,180,60,131,72,118,224,214,168,23,156,206,98,35,88,202,76,8,159,12,197,118,31,251,250,121,193,239,249,211,19,147,33,110,249,95,252,88,82,118,136,143,235,253,228,113,193,251,213,147,188,222,0,209,170,118,131,170,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab1853cd-ba91-4c11-942e-58eb26dfa9d8"));
		}

		#endregion

	}

	#endregion

}

