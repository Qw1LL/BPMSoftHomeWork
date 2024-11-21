namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImporterFactorySchema

	/// <exclude/>
	public class IFileImporterFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImporterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImporterFactorySchema(IFileImporterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("03765a8d-a731-806b-9649-74b2d943ce1c");
			Name = "IFileImporterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,80,203,106,195,48,16,60,199,224,127,88,124,106,47,209,7,212,241,33,129,4,31,10,165,165,31,160,170,163,84,16,61,88,73,135,80,242,239,149,220,134,56,184,199,157,157,157,153,29,39,45,98,144,10,180,125,121,126,243,58,173,119,222,105,115,204,44,147,241,110,189,55,39,140,54,120,78,109,243,221,54,171,28,141,59,206,184,140,167,182,41,184,16,130,250,152,173,149,124,30,254,230,87,4,70,132,75,145,44,210,151,255,36,237,153,20,67,38,144,46,194,100,38,101,240,85,64,204,20,66,254,56,25,69,198,149,189,174,1,199,91,22,240,94,170,228,249,92,120,53,213,194,126,2,118,255,59,45,173,126,145,32,89,90,114,165,144,77,151,35,184,20,225,160,106,11,221,208,139,105,123,35,51,82,102,23,135,62,2,245,37,189,233,198,173,140,152,103,236,68,185,187,18,235,229,130,65,7,164,249,252,240,126,231,75,247,49,30,75,213,171,75,219,92,126,0,10,63,245,187,181,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("03765a8d-a731-806b-9649-74b2d943ce1c"));
		}

		#endregion

	}

	#endregion

}

