namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMLProblemTypeFeaturesSchema

	/// <exclude/>
	public class IMLProblemTypeFeaturesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMLProblemTypeFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMLProblemTypeFeaturesSchema(IMLProblemTypeFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af781143-48a0-4837-b191-06bc575a6ccb");
			Name = "IMLProblemTypeFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b54cb82a-9c72-40e4-855f-14a0ef44684e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,193,106,2,49,16,134,207,10,190,195,28,235,101,247,1,42,61,84,144,10,46,21,236,11,204,166,147,109,32,201,132,217,201,65,196,119,119,118,181,165,32,100,2,9,255,255,205,151,49,209,88,208,17,188,31,187,19,123,109,182,156,125,24,170,160,6,206,77,119,88,45,47,171,229,162,109,91,216,140,53,37,148,243,219,227,189,207,74,226,167,174,103,129,130,162,193,213,136,2,158,80,171,208,8,236,65,127,8,198,66,46,248,224,160,8,247,145,18,232,185,80,243,75,109,255,97,75,237,163,229,194,31,121,223,29,142,247,210,151,117,118,15,176,37,77,202,238,39,175,249,227,3,109,117,213,82,21,94,20,101,32,93,131,227,88,83,158,77,19,127,83,4,21,12,57,228,97,242,120,22,89,244,204,113,2,125,206,156,237,189,125,1,99,189,194,213,2,54,118,110,220,55,152,164,63,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af781143-48a0-4837-b191-06bc575a6ccb"));
		}

		#endregion

	}

	#endregion

}

