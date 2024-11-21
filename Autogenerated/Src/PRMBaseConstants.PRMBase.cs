namespace BPMSoft.Configuration
{
	using System;

	#region Class: PRMBaseConstants

	public static class PRMBaseConstants
	{

		#region Constants: Public

		/// <summary>
		// Credit TransactionType identifier.
		/// </summary>
		public static Guid CreditTransactionType = new Guid("BC975A02-CFFE-4DC6-A136-DDD0219C711A");

		/// <summary>
		// Debit TransactionType identifier.
		/// </summary>
		public static Guid DebitTransactionType = new Guid("74DF3568-6092-426E-9279-C36D197B643C");

		/// <summary>
		/// Obligation parameter type identifier.
		/// </summary>
		public static readonly Guid ObligationParameterTypeId = new Guid("40BC2EC9-E399-40E3-B8FA-E0B13BC61BFD");

		/// <summary>
		/// Current partnership parameter type identifier.
		/// </summary>
		public static readonly Guid CurrentPartnershipParamTypeId = new Guid("A2B453DD-F6E6-4677-A79F-74AADED40ED6");

		/// <summary>
		/// Target partnership parameter type identifier.
		/// </summary>
		public static readonly Guid TargetPartnershipParamTypeId = new Guid("4A517C28-EB6D-48D7-9C76-457D60FA600E");

		/// <summary>
		/// Benefit parameter type identifier.
		/// </summary>
		public static readonly Guid BenefitParameterTypeId = new Guid("1C4E69DD-3C34-4008-A564-BF9232A34D27");

		/// <summary>
		/// Free certification partnership parameter category identifier.
		/// </summary>
		public static readonly Guid FreeCertificationCategory = new Guid("924EA7FA-C4C6-4A28-BC67-3D4DAA216CAE");

		/// <summary>
		/// Certified experts partnership parameter category identifier.
		/// </summary>
		public static readonly Guid NumberOfCertifiedExpertsCategory = new Guid("EEBB4F0F-90EF-4114-AB3D-5FB1E351B0D8");

		/// <summary>
		/// Not paid payment method identifier.
		/// </summary>
		public static readonly Guid NotPaidPaymentMethod = new Guid("5B2E90B1-A70C-4742-A26B-40D9073D76B8");

		/// <summary>
		/// Certification fund type identifier.
		/// </summary>
		public static readonly Guid CertificationFundType = new Guid("B2F336D4-79DC-429D-8400-EBD4A24DF3DA");

		/// <summary>
		/// Education activity schema unique identifier.
		/// </summary>
		public static readonly Guid EducationActivitySchemaUId = new Guid("48A0DDFD-A99E-4BF5-8B5A-E56DFEC31E0C");

		/// <summary>
		/// Education activity schema unique identifier.
		/// </summary>
		public static readonly Guid IntergratorPartnerTypeId = new Guid("326e998f-6442-49fa-8bed-9eb466e96fcc");

		/// <summary>
		/// Education activity schema unique identifier.
		/// </summary>
		public static readonly Guid ConsultantPartnerTypeId = new Guid("6ba367fb-ecf7-436e-8b8a-784106495a31");

		/// <summary>
		/// Marketing activity partnership parameter category unique identifier.
		/// </summary>
		public static readonly Guid MktgActivityPartnerParamCategoryId = Guid.Parse("CF158EA3-5B2E-4A58-BBCA-AC87AEB7166D");

		/// <summary>
		/// Marketing activity approved status unique identifier.
		/// </summary>
		public static readonly Guid ApprovedStatusId = Guid.Parse("C4D9DC54-82C2-43CD-886F-D33F392FB36D");

		/// <summary>
		/// Current partnership parameter type unique identifier.
		/// </summary>
		public static readonly Guid CurrentPartnershipParameterTypeId = Guid.Parse("A2B453DD-F6E6-4677-A79F-74AADED40ED6");

		/// <summary>
		/// Unique identifier of list value type of partnership parameter.
		/// </summary>
		public static readonly Guid SpecificationTypeListId = Guid.Parse("ECF578A0-4B4D-40E6-909C-39AF2A798D32");

		/// <summary>
		/// Unique identifier of demical value type of partnership parameter.
		/// </summary>
		public static readonly Guid SpecificationTypeDemicalId = Guid.Parse("BEB46531-4F29-452C-BE18-1ED5F1AA8B80");

		/// <summary>
		/// Unique identifier of boolean value type of partnership parameter.
		/// </summary>
		public static readonly Guid SpecificationTypeBooleanId = Guid.Parse("359E0E35-BB39-4F07-9B9F-AEC6AD076828");

		/// <summary>
		/// Unique identifier of string value type of partnership parameter.
		/// </summary>
		public static readonly Guid SpecificationTypeStringId = Guid.Parse("7AAD419A-9E7A-4785-8D13-C7FF1402E13D");

		/// <summary>
		/// Unique identifier of integer value type of partnership parameter.
		/// </summary>
		public static readonly Guid SpecificationTypeIntegerId = Guid.Parse("2212241A-71EB-468B-A3D5-C0F39DFE51C9");

		/// <summary>
		/// Unique identifier of PRM portal user role in SysAdminUnit table.
		/// </summary>
		public static readonly Guid PRMPortalUserRoleId = new Guid("9827231b-d14a-4a41-b6bd-876ae68b7381");
		
		/// <summary>
		/// Unique identifier of Partners CIS user role in SysAdminUnit table.
		/// </summary>
		public static readonly Guid PartnersCISUserRoleId = new Guid("5370c193-76a0-4ebb-959c-87416cec3886");
		
		/// <summary>
		/// Unique identifier of Partners Global user role in SysAdminUnit table.
		/// </summary>
		public static readonly Guid PartnersGlobalUserRoleId = new Guid("500eaff7-6757-4fc0-8803-f65abb3ba78c");

		/// <summary>
		/// Unique identifier of lead partner owner in SysEntitySchemaRecRightSource table.
		/// </summary>
		public static readonly Guid SysEntitySchemaRecRightSourceLeadPartnerOwner = new Guid("AC6DD777-2740-4F10-9C03-62F969ABC1DE");
		
		/// <summary>
		/// Unique identifier of Default in SysEntitySchemaRecRightSource table.
		/// </summary>
		public static readonly Guid SysEntitySchemaRecRightSourceDefault = new Guid("F41E0268-E324-4228-9E9E-5CB7CC906398");

		#endregion

	}

	#endregion

}
