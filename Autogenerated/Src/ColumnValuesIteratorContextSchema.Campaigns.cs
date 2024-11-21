namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ColumnValuesIteratorContextSchema

	/// <exclude/>
	public class ColumnValuesIteratorContextSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ColumnValuesIteratorContextSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ColumnValuesIteratorContextSchema(ColumnValuesIteratorContextSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c11e73b-d8b2-4159-8639-b9b25cb1fe29");
			Name = "ColumnValuesIteratorContext";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,77,79,227,48,16,134,207,32,241,31,70,112,97,37,148,220,105,201,97,187,18,66,162,218,106,249,56,112,51,206,36,88,242,71,228,177,183,116,81,255,59,19,187,13,45,148,170,123,73,50,246,204,219,231,157,153,90,97,144,58,33,17,126,206,166,119,174,9,197,196,217,70,181,209,139,160,156,45,38,194,116,66,181,150,78,142,223,78,142,143,34,41,219,194,221,130,2,154,209,167,152,43,181,70,217,151,81,113,141,22,189,146,31,57,31,242,30,7,85,190,230,132,51,143,45,23,193,68,11,162,75,96,153,104,236,163,208,17,233,38,32,131,56,207,80,1,95,67,74,47,203,18,198,20,141,17,126,81,173,226,213,61,204,95,148,124,1,201,145,80,150,64,217,46,6,232,132,103,151,172,68,208,56,207,181,136,32,61,54,87,167,187,126,234,180,172,64,216,26,60,82,212,129,75,188,51,128,130,101,81,163,65,27,138,53,67,185,1,209,197,103,173,36,200,222,194,126,7,71,220,71,126,14,174,103,222,117,232,131,66,182,62,75,42,249,254,179,205,236,115,213,56,8,202,32,252,115,22,123,154,175,56,107,158,123,78,123,226,172,27,219,184,33,248,221,52,132,1,222,160,197,48,2,254,28,193,18,174,182,114,139,135,208,207,238,123,142,97,212,224,26,48,66,122,71,96,92,141,154,246,3,221,42,10,227,105,159,159,218,51,237,75,42,72,7,148,27,182,230,234,145,44,206,119,87,156,255,56,156,78,166,105,192,223,172,158,55,100,174,180,134,103,228,5,33,238,61,214,252,1,60,90,21,22,7,224,111,140,183,218,154,245,78,244,201,70,246,255,96,15,251,199,43,155,215,47,241,173,236,236,199,252,165,146,12,159,142,175,163,170,47,54,41,255,36,221,10,242,251,11,243,1,165,131,139,51,180,117,222,226,20,47,243,191,121,235,112,249,14,180,99,64,75,97,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c11e73b-d8b2-4159-8639-b9b25cb1fe29"));
		}

		#endregion

	}

	#endregion

}

