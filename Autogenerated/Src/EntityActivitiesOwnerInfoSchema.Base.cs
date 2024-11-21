namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EntityActivitiesOwnerInfoSchema

	/// <exclude/>
	public class EntityActivitiesOwnerInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityActivitiesOwnerInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityActivitiesOwnerInfoSchema(EntityActivitiesOwnerInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f495a412-7027-454b-a334-1948a1100b0a");
			Name = "EntityActivitiesOwnerInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,207,106,195,48,12,198,207,13,228,29,4,189,55,247,118,12,182,50,74,14,107,3,121,2,207,145,83,67,108,7,203,89,8,165,239,62,255,105,187,178,141,110,221,197,216,146,252,125,63,201,214,76,33,245,140,35,60,87,175,181,17,110,177,54,90,200,118,176,204,73,163,243,236,144,103,179,129,164,110,161,158,200,161,90,229,153,143,204,45,182,62,13,235,142,17,45,225,69,59,233,166,39,238,228,187,116,18,105,55,106,180,165,22,38,22,23,69,1,15,52,40,197,236,244,120,58,215,206,88,36,144,190,198,170,104,5,26,57,18,249,26,112,6,248,158,233,22,193,4,33,48,2,88,210,158,22,103,189,226,74,176,31,222,58,201,129,7,152,91,44,51,223,140,95,47,244,149,53,61,218,80,180,132,42,106,164,252,87,224,24,40,27,244,202,66,38,158,176,79,52,223,113,206,60,155,65,54,39,156,178,129,3,180,232,86,64,97,57,254,226,35,2,121,244,49,93,115,233,61,77,227,15,158,187,174,73,93,255,215,85,227,120,191,235,22,199,123,93,183,254,247,125,78,19,136,239,81,177,219,86,228,108,248,140,105,172,117,188,16,85,126,176,156,163,110,210,75,199,115,138,94,7,103,121,118,252,0,234,81,70,24,1,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f495a412-7027-454b-a334-1948a1100b0a"));
		}

		#endregion

	}

	#endregion

}

