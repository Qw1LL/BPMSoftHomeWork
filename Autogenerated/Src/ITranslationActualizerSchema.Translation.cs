namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITranslationActualizerSchema

	/// <exclude/>
	public class ITranslationActualizerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationActualizerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationActualizerSchema(ITranslationActualizerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e2bd260d-8139-4e57-b269-fae5dc20c315");
			Name = "ITranslationActualizer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6d72ca66-8680-4c3f-b4a0-15ba7a19db7c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,107,194,64,16,61,43,248,31,6,189,216,75,114,215,84,176,214,82,161,130,160,180,231,213,76,226,66,178,43,179,147,128,45,253,239,221,108,200,103,107,241,18,146,153,55,239,189,121,25,37,82,52,23,113,66,120,218,109,247,58,98,111,165,85,36,227,140,4,75,173,188,3,9,101,18,247,62,26,126,141,134,131,204,72,21,195,254,106,24,211,121,253,221,12,19,122,107,197,146,37,26,219,182,128,9,97,108,167,97,163,24,41,178,74,51,216,180,88,151,39,206,68,34,63,145,28,250,146,29,19,121,2,89,129,111,98,7,214,140,125,214,244,235,28,21,155,25,236,28,65,217,195,162,86,118,94,133,10,19,164,224,131,36,227,155,62,21,52,226,152,224,187,72,50,116,136,37,197,102,1,127,247,137,52,149,219,12,38,168,194,82,178,171,191,69,62,235,176,103,192,247,125,8,76,150,166,130,174,139,170,80,111,97,128,155,221,188,26,239,247,7,130,139,32,145,130,178,191,234,113,44,170,233,23,210,233,120,113,56,35,132,130,17,88,131,97,65,12,21,192,177,66,100,81,94,224,59,6,71,152,107,25,54,22,90,225,78,159,45,205,65,166,8,29,137,135,249,125,171,36,77,102,144,23,161,153,27,27,229,29,3,253,168,205,244,95,193,61,114,39,181,98,103,198,123,179,107,13,218,228,90,217,255,10,200,234,108,76,11,177,58,11,21,99,56,117,167,125,109,59,168,236,246,238,226,187,188,253,78,209,214,126,0,6,241,104,131,111,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e2bd260d-8139-4e57-b269-fae5dc20c315"));
		}

		#endregion

	}

	#endregion

}

