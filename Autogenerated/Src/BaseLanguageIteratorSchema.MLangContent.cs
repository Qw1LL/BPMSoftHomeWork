namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseLanguageIteratorSchema

	/// <exclude/>
	public class BaseLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseLanguageIteratorSchema(BaseLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("88e0be6b-543f-42a7-9c74-8a6542583cb1");
			Name = "BaseLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2659875a-4670-491c-9c1f-f4641a7bae64");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,84,193,138,219,48,16,61,103,97,255,97,240,94,210,75,124,223,38,129,110,40,193,208,133,208,165,167,210,131,34,143,189,2,89,54,35,169,197,45,251,239,29,41,182,215,118,178,33,55,107,120,122,243,230,205,147,141,168,208,54,66,34,60,29,158,95,234,194,173,118,181,41,84,233,73,56,85,155,251,187,127,247,119,11,111,149,41,225,165,181,14,171,207,179,51,227,181,70,25,192,118,181,71,131,164,228,59,230,157,148,144,171,92,127,32,44,25,11,59,45,172,125,132,39,97,241,155,48,165,23,37,102,14,185,107,77,17,151,166,41,172,173,175,42,65,237,182,59,7,48,23,17,65,18,22,155,36,155,223,76,210,45,168,170,209,88,161,113,113,128,85,79,149,142,184,26,127,212,74,130,56,90,71,66,58,144,65,203,69,41,240,8,103,77,152,32,152,50,76,114,160,186,65,114,10,121,156,67,100,142,3,156,77,16,11,63,44,18,200,218,152,147,101,65,222,185,190,94,96,0,239,6,236,252,24,69,44,74,116,193,238,197,219,149,166,95,136,68,11,117,1,186,27,5,200,107,180,215,155,15,115,127,103,236,207,95,48,62,218,81,115,176,83,5,15,104,242,147,51,221,185,95,56,7,196,145,151,236,96,48,138,106,199,115,96,126,69,118,102,148,83,66,171,191,220,207,224,31,80,76,32,12,71,149,39,25,165,224,210,222,56,8,31,76,23,43,141,32,81,129,225,236,111,18,63,113,53,217,206,55,180,78,35,250,100,77,175,250,98,88,150,179,5,77,153,63,117,158,205,64,155,25,236,22,43,159,209,189,214,249,45,113,219,163,179,195,214,45,28,91,224,135,161,92,11,42,15,31,133,66,186,213,39,66,89,83,158,229,201,246,235,25,197,122,228,81,188,72,232,60,25,203,80,95,117,47,105,20,63,203,23,122,196,56,113,29,250,168,113,189,247,42,223,6,249,189,201,118,25,74,208,171,232,221,44,248,199,34,228,43,44,127,11,138,169,230,148,76,163,218,35,23,173,66,29,8,66,223,8,229,223,213,64,159,229,203,129,58,174,32,236,224,163,69,156,170,211,226,219,127,154,29,129,228,74,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("88e0be6b-543f-42a7-9c74-8a6542583cb1"));
		}

		#endregion

	}

	#endregion

}

