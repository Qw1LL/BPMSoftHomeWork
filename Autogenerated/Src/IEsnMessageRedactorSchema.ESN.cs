namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEsnMessageRedactorSchema

	/// <exclude/>
	public class IEsnMessageRedactorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEsnMessageRedactorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEsnMessageRedactorSchema(IEsnMessageRedactorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95f9fa02-7c86-4d9f-a8c2-7614daa3758a");
			Name = "IEsnMessageRedactor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,85,203,110,194,48,16,60,131,196,63,172,232,161,32,85,201,189,15,14,5,84,113,232,67,165,82,207,38,222,16,171,177,141,108,167,8,85,252,123,29,219,9,80,232,131,71,143,107,239,206,206,140,39,138,32,28,245,140,36,8,183,79,247,99,153,154,168,47,69,202,166,133,34,134,73,17,13,199,15,173,230,71,171,217,40,52,19,83,24,47,180,65,126,85,215,125,169,48,26,10,195,12,67,109,143,237,197,153,194,169,157,4,24,9,131,42,181,208,151,48,26,106,113,143,90,147,41,62,35,37,137,145,202,245,198,113,12,215,186,224,156,168,69,47,212,79,74,190,51,138,26,56,154,76,82,13,169,84,160,101,194,72,14,2,205,92,170,55,80,14,164,36,192,61,170,142,42,180,120,13,110,86,76,114,150,0,171,136,236,230,209,40,229,109,81,241,92,164,54,128,165,188,197,121,73,200,77,150,171,182,119,249,147,25,81,132,131,176,166,222,180,67,251,128,24,210,238,133,173,64,109,21,93,199,174,175,30,155,51,147,129,201,16,50,204,103,32,83,75,4,17,18,133,233,77,219,50,126,85,204,96,0,24,188,60,182,227,158,163,112,87,48,234,24,134,171,206,118,43,172,113,232,250,231,249,65,104,104,182,74,19,201,185,149,189,167,210,17,93,233,28,209,45,149,27,35,97,131,55,167,239,139,127,49,39,96,119,220,65,77,244,2,118,152,181,198,233,71,179,134,148,29,157,138,149,83,243,76,106,152,32,160,69,197,95,92,219,136,212,216,168,181,47,96,63,223,28,249,202,171,137,148,185,19,85,7,201,93,87,200,23,160,55,54,253,205,159,131,195,20,218,87,169,216,199,160,141,88,5,131,170,253,95,7,15,113,168,74,83,112,40,64,215,14,253,53,65,3,204,209,224,233,51,68,29,46,61,90,170,231,183,59,14,221,127,20,246,237,219,159,86,216,238,87,44,133,53,150,254,31,134,130,250,223,88,171,185,252,4,183,62,197,118,35,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95f9fa02-7c86-4d9f-a8c2-7614daa3758a"));
		}

		#endregion

	}

	#endregion

}

