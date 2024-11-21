namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ChatLanguageIteratorSchema

	/// <exclude/>
	public class ChatLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChatLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChatLanguageIteratorSchema(ChatLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bfb32ab4-18f2-0b7b-7c32-952642edc498");
			Name = "ChatLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,61,111,194,64,12,157,131,196,127,176,194,2,82,149,236,20,24,160,11,82,171,162,86,76,85,7,115,117,194,73,151,11,186,15,85,180,226,191,215,119,33,52,124,12,237,144,147,252,252,252,252,108,71,99,69,118,135,130,96,190,122,122,173,11,151,45,106,93,200,210,27,116,178,214,253,222,119,191,151,120,43,117,217,33,24,186,239,247,24,31,24,42,153,4,11,133,214,142,97,177,69,247,136,186,244,88,210,210,17,43,212,38,242,242,60,135,137,245,85,133,102,63,59,198,45,1,10,254,148,180,46,180,216,236,225,185,210,50,8,129,58,42,217,172,85,200,59,18,59,191,81,82,128,8,157,111,54,134,49,204,209,210,181,159,36,76,244,107,189,214,214,25,47,56,197,19,172,162,106,244,124,101,186,113,173,165,147,168,228,23,89,208,244,9,146,171,81,243,246,234,130,201,68,32,12,21,211,244,150,161,52,159,101,112,18,238,206,210,32,59,52,88,129,230,123,76,83,111,201,176,51,77,34,28,33,157,173,57,6,113,2,178,73,30,217,177,248,184,137,91,45,135,235,51,29,56,151,29,133,234,100,12,27,94,211,240,34,149,52,91,74,90,197,23,175,120,226,105,156,121,217,5,223,222,161,97,38,33,197,10,14,133,91,234,246,138,93,234,133,155,209,93,167,110,139,12,171,127,215,61,80,129,94,253,129,125,224,31,150,223,230,178,3,210,31,205,249,99,220,160,231,224,225,7,207,58,206,27,24,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bfb32ab4-18f2-0b7b-7c32-952642edc498"));
		}

		#endregion

	}

	#endregion

}

