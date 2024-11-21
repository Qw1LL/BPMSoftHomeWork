namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OperatorLogoutEventHandlerSchema

	/// <exclude/>
	public class OperatorLogoutEventHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OperatorLogoutEventHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OperatorLogoutEventHandlerSchema(OperatorLogoutEventHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c46064d2-8bfb-8ae3-a732-e51330addf7c");
			Name = "OperatorLogoutEventHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,77,79,195,48,12,61,111,18,255,193,42,151,78,66,233,29,54,14,12,16,149,24,76,154,56,33,14,33,113,187,72,109,82,229,99,80,33,254,59,78,215,109,108,108,92,210,216,121,207,174,159,159,230,53,186,134,11,132,155,249,108,97,10,207,166,70,23,170,12,150,123,101,52,123,174,181,18,75,174,53,86,108,134,206,241,82,233,242,108,248,117,54,28,4,71,87,88,180,206,99,125,181,141,119,101,44,30,207,178,123,46,188,177,10,29,189,19,226,220,98,73,173,96,90,113,231,46,225,185,65,234,109,236,163,41,77,240,119,43,212,254,129,107,89,161,237,208,89,150,193,216,133,186,230,182,189,238,227,5,122,48,61,13,156,231,30,129,234,5,135,22,170,174,10,219,16,179,3,230,216,33,242,202,25,16,22,139,73,146,255,109,154,100,215,145,253,122,139,5,15,149,191,81,90,210,64,169,111,27,52,69,122,132,48,186,128,39,18,21,38,144,156,30,37,25,189,81,209,38,188,87,74,128,136,131,255,51,55,92,194,145,62,196,167,45,208,185,21,112,134,126,105,36,73,56,239,234,174,31,187,41,149,94,162,85,94,26,113,122,80,182,254,118,169,244,133,180,35,35,104,20,209,5,35,18,33,214,234,255,119,101,148,132,211,104,8,98,4,209,32,131,129,183,109,127,27,172,184,5,17,172,37,124,132,231,146,4,10,130,77,119,41,150,203,104,152,30,187,217,231,140,107,94,146,6,19,208,248,177,21,169,207,166,212,170,231,28,224,217,148,76,91,226,6,191,136,166,72,247,250,95,192,47,111,111,173,77,99,56,239,216,30,143,229,154,28,171,86,72,246,149,216,55,252,6,193,189,88,66,122,247,41,176,233,84,130,47,248,142,111,116,116,107,65,45,215,155,233,226,117,118,63,73,185,31,98,13,250,143,129,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c46064d2-8bfb-8ae3-a732-e51330addf7c"));
		}

		#endregion

	}

	#endregion

}

