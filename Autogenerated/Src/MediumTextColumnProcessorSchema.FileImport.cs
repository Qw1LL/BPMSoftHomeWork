namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MediumTextColumnProcessorSchema

	/// <exclude/>
	public class MediumTextColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MediumTextColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MediumTextColumnProcessorSchema(MediumTextColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("849d8e1e-95a1-4326-a3ca-a768f4bf5d14");
			Name = "MediumTextColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("560ff4eb-7ab5-4d8f-8733-4031e1e3144b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,110,219,48,12,134,207,41,208,119,32,178,75,2,12,246,189,107,2,44,41,58,228,208,33,64,155,93,134,29,20,153,78,9,216,146,71,81,197,130,161,239,62,218,74,150,57,141,7,244,98,91,244,207,159,228,39,201,153,26,67,99,44,194,98,253,240,232,75,201,150,222,149,180,139,108,132,188,203,238,169,194,85,221,120,150,235,171,223,215,87,163,24,200,237,224,113,31,4,235,79,127,215,167,92,198,203,209,236,222,88,241,76,24,244,191,42,62,48,238,212,31,150,149,9,225,6,30,176,160,88,63,225,47,89,250,42,214,110,205,222,98,8,158,59,113,158,231,112,75,238,25,153,164,240,22,44,99,57,27,95,80,143,243,249,81,30,98,93,27,222,31,215,159,29,144,11,98,156,78,234,75,144,103,10,96,219,218,160,31,172,8,188,11,180,173,16,74,207,208,36,191,118,134,83,99,96,187,90,240,98,170,136,33,59,214,201,255,41,244,253,14,75,19,43,89,144,43,52,121,34,251,6,125,57,89,157,117,57,253,8,95,21,59,204,192,233,75,5,131,211,79,167,63,212,182,137,219,138,236,161,221,65,45,220,192,69,126,35,221,54,125,158,136,235,164,194,177,221,13,5,191,238,188,147,226,157,152,223,112,238,2,75,70,35,24,250,180,149,131,42,17,15,150,131,51,168,113,11,246,45,217,20,105,12,155,186,131,54,27,199,128,172,163,56,180,237,57,29,207,55,186,214,45,58,6,178,219,188,83,119,201,7,128,131,101,39,155,158,25,244,189,167,74,118,107,2,78,206,195,237,125,24,189,30,232,162,43,18,224,62,109,173,209,32,139,158,123,101,205,94,52,23,139,255,225,94,104,165,119,224,190,51,98,210,145,76,148,163,163,159,250,77,5,58,161,146,144,7,120,234,17,79,189,128,127,65,102,213,195,151,72,69,231,247,173,181,123,82,183,205,170,128,217,188,31,203,78,20,207,181,233,102,159,163,72,128,250,193,215,63,200,223,46,217,119,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("849d8e1e-95a1-4326-a3ca-a768f4bf5d14"));
		}

		#endregion

	}

	#endregion

}

