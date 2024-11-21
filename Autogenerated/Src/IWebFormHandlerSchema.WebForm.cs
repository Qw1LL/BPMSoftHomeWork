namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IWebFormHandlerSchema

	/// <exclude/>
	public class IWebFormHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebFormHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebFormHandlerSchema(IWebFormHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("85b340bd-4e82-4d09-9c7d-737d1496c5d3");
			Name = "IWebFormHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,63,107,195,48,16,197,231,24,252,29,142,100,105,23,107,119,211,12,109,73,234,33,96,154,66,103,197,58,57,2,75,50,146,108,40,165,223,189,250,227,24,167,237,34,238,30,191,119,247,116,138,74,180,61,109,16,158,234,227,73,115,87,60,107,197,69,59,24,234,132,86,121,246,149,103,171,193,10,213,254,15,20,7,84,232,75,100,31,120,222,107,35,79,104,70,209,224,67,158,121,227,198,96,235,33,168,148,67,195,253,150,18,170,137,123,165,138,117,104,34,70,8,129,173,29,164,164,230,115,55,245,181,209,163,96,104,65,92,189,112,37,201,2,237,135,115,39,154,5,244,107,126,57,11,111,104,135,206,85,138,107,111,11,191,154,211,29,209,93,52,179,37,212,113,88,140,244,39,83,20,210,80,11,238,130,192,253,76,96,212,209,98,198,151,193,146,210,83,67,37,40,127,228,199,117,48,188,120,126,189,123,191,177,111,73,164,162,105,212,130,77,91,66,230,187,240,4,79,196,67,113,159,14,187,218,160,98,41,126,236,191,211,185,111,68,175,253,0,42,3,207,145,222,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("85b340bd-4e82-4d09-9c7d-737d1496c5d3"));
		}

		#endregion

	}

	#endregion

}

