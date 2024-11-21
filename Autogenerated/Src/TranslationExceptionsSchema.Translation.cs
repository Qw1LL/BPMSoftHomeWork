namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TranslationExceptionsSchema

	/// <exclude/>
	public class TranslationExceptionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationExceptionsSchema(TranslationExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd34e1f4-8c12-45a5-b98a-235cdfe34c22");
			Name = "TranslationExceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,80,77,79,195,48,12,61,183,82,255,131,37,46,227,210,222,7,226,192,180,27,72,147,54,193,217,13,110,27,41,117,170,56,97,12,196,127,199,253,24,140,11,92,226,248,217,126,239,217,140,61,201,128,134,224,126,247,184,247,77,44,55,158,27,219,166,128,209,122,46,15,1,89,220,244,47,242,143,34,207,146,88,110,97,127,146,72,253,77,145,43,114,21,168,213,50,108,28,138,172,225,57,216,72,15,222,160,179,239,88,59,122,66,151,104,251,102,104,152,73,116,162,170,42,184,149,212,247,24,78,119,75,126,232,8,232,220,5,177,195,8,86,52,6,127,100,56,118,196,32,248,74,224,7,154,157,129,86,217,71,144,100,12,137,52,201,149,103,230,234,130,122,72,181,179,6,204,232,237,31,107,176,134,11,155,153,46,171,239,207,118,158,37,134,100,162,15,186,228,110,162,157,59,22,137,191,201,87,58,60,30,78,175,45,216,210,181,138,213,40,180,250,206,199,219,102,159,139,38,241,203,44,59,229,51,250,27,84,236,11,253,132,181,112,187,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd34e1f4-8c12-45a5-b98a-235cdfe34c22"));
		}

		#endregion

	}

	#endregion

}

