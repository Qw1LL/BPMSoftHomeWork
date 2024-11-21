namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TypedValueModelSchema

	/// <exclude/>
	public class TypedValueModelSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TypedValueModelSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TypedValueModelSchema(TypedValueModelSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e563da35-a0e4-4fae-aeed-9e1cbe43a1ed");
			Name = "TypedValueModel";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,65,107,132,48,16,133,207,43,248,31,6,246,174,247,110,233,161,238,85,16,90,246,62,198,209,166,152,68,50,73,65,150,253,239,77,162,150,109,183,120,9,204,203,203,123,95,70,163,34,158,80,16,188,54,245,155,233,93,81,25,221,203,193,91,116,210,232,162,66,53,161,28,52,231,217,53,207,14,158,165,30,238,172,150,78,121,22,244,163,165,33,216,161,26,145,249,9,222,231,137,186,11,142,158,106,211,209,152,44,101,89,194,51,123,165,208,206,47,235,124,38,22,86,182,196,160,162,15,122,99,65,172,141,64,218,73,55,3,139,15,82,8,10,133,53,240,21,51,139,45,173,188,139,155,124,59,74,1,34,2,60,246,31,2,124,56,127,56,27,107,38,178,78,82,128,109,210,203,229,254,47,100,18,82,16,152,126,23,45,66,61,82,109,88,166,253,36,225,214,164,43,12,228,78,192,241,184,237,244,214,49,151,183,50,97,70,175,52,116,232,112,89,3,184,240,203,253,218,115,48,167,206,184,144,180,149,255,202,143,164,187,101,47,105,94,212,223,98,208,190,1,68,0,73,62,42,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e563da35-a0e4-4fae-aeed-9e1cbe43a1ed"));
		}

		#endregion

	}

	#endregion

}

