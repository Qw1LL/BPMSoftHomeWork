namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SynchronizationColumnComparatorSchema

	/// <exclude/>
	public class SynchronizationColumnComparatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SynchronizationColumnComparatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SynchronizationColumnComparatorSchema(SynchronizationColumnComparatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e35d3e1f-66cd-49ce-837d-7492da9c21e7");
			Name = "SynchronizationColumnComparator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,146,77,75,196,64,12,134,207,22,250,31,194,122,81,88,58,119,173,61,184,245,224,65,16,10,222,167,109,90,71,102,146,238,124,8,85,252,239,246,107,81,186,43,94,246,50,240,134,247,205,147,33,33,105,208,117,178,66,184,127,126,42,184,241,201,142,169,81,109,176,210,43,166,228,129,188,242,125,209,83,245,106,153,212,199,84,141,163,207,56,138,163,139,75,139,237,32,33,71,141,173,244,120,3,43,227,142,117,48,195,107,58,57,244,99,59,165,132,16,144,186,96,140,180,125,182,232,28,61,90,163,8,29,168,6,210,209,110,44,54,64,195,120,119,27,199,193,86,248,34,117,192,141,200,64,57,192,125,144,26,60,31,89,107,116,94,209,4,159,253,89,114,64,138,21,115,142,158,64,100,197,36,224,125,84,73,42,38,223,201,212,49,45,255,169,252,145,183,232,131,37,151,61,158,251,159,169,56,180,30,80,93,40,181,170,160,94,54,3,37,179,254,111,59,87,92,190,97,229,225,215,24,91,88,106,107,222,245,237,124,1,72,245,124,4,163,252,138,163,111,91,185,232,149,80,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e35d3e1f-66cd-49ce-837d-7492da9c21e7"));
		}

		#endregion

	}

	#endregion

}

