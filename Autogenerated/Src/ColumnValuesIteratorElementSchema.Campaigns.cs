namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ColumnValuesIteratorElementSchema

	/// <exclude/>
	public class ColumnValuesIteratorElementSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ColumnValuesIteratorElementSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ColumnValuesIteratorElementSchema(ColumnValuesIteratorElementSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("940b6f42-9d5c-4d59-8253-b8b8e250727e");
			Name = "ColumnValuesIteratorElement";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,81,75,75,196,48,16,62,183,208,255,48,212,139,94,218,187,238,46,104,241,224,161,80,16,188,207,166,211,110,176,73,74,38,93,21,217,255,110,154,180,226,46,139,183,204,227,123,204,23,141,138,120,68,65,240,212,212,175,166,115,69,101,116,39,251,201,162,147,70,23,21,170,17,101,175,57,75,191,179,52,75,147,27,75,189,31,64,53,32,243,61,84,102,152,148,126,195,97,34,126,113,228,81,198,62,15,164,72,187,176,94,150,37,108,120,82,10,237,215,110,169,31,247,236,44,10,7,20,23,161,51,214,47,17,129,176,212,109,243,107,156,121,185,43,86,186,242,15,223,56,237,7,41,0,87,74,49,219,250,223,85,18,15,249,189,164,38,119,48,173,191,165,9,92,113,120,233,59,153,27,53,190,19,131,151,153,97,31,210,29,64,161,176,134,225,24,148,0,117,11,34,72,47,157,217,114,64,158,121,142,157,17,45,42,208,62,255,109,46,140,118,244,233,242,157,15,127,126,132,68,70,107,4,49,75,221,175,65,113,177,41,3,44,176,92,158,126,52,178,133,38,130,110,175,37,176,146,47,106,119,15,75,14,164,219,24,69,168,79,241,155,207,154,167,31,117,91,187,59,39,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("940b6f42-9d5c-4d59-8253-b8b8e250727e"));
		}

		#endregion

	}

	#endregion

}

