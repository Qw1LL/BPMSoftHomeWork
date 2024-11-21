using System;

namespace BPMSoft.Configuration
{
	public static class ContactConsts
	{
		/// <summary>
		/// Type - Employee
		/// </summary>
		public static Guid EmployeeTypeId
		{
			get {
				return Guid.Parse("60733EFC-F36B-1410-A883-16D83CAB0980");
			}
		}

		/// <summary>
		/// Gender - Male.
		/// </summary>
		public const string MaleId = "EEAC42EE-65B6-DF11-831A-001D60E938C6";
		
		/// <summary>
		/// Gender - Female.
		/// </summary>
		public const string FemaleId = "FC2483F8-65B6-DF11-831A-001D60E938C6";
	}
}
