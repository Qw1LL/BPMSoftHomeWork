namespace BPMSoft.Configuration
{
	using System;

	#region  Class: CalculateAgeHelper

	/// <summary>
	/// Class for calculate contact age.  
	/// </summary>
	public class CalculateAgeHelper
	{
		#region Methods: Private

		/// <summary>
		/// Check date not greater current date.
		/// </summary>
		/// <param name="inputDate">.</param>
		/// <returns>true - if date valid</returns>
		private bool IsNotGreaterCurrentDate(DateTime inputDate) {
			return inputDate.Date <= DateTime.UtcNow.Date;
		}

		/// <summary>
		/// Check date not equal "MinValue". 
		/// </summary>
		/// <param name="inputDate">.</param>
		/// <returns>true - if date valid</returns>
		private bool IsNotEqualMinValue(DateTime inputDate) {
			return !inputDate.Equals(DateTime.MinValue);
		}

		#endregion

		#region Constructors: Public

		public CalculateAgeHelper() {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get full years from current date.
		/// </summary>
		/// <param name="inputDate">.</param>
		/// <returns>Age</returns>
		public virtual int GetFullAgeYears(DateTime inputDate) {
			if (IsNotGreaterCurrentDate(inputDate) && IsNotEqualMinValue(inputDate)) {
				DateTime currentDate = DateTime.Now.Date;
				int age = currentDate.Year - inputDate.Year;
				return currentDate.AddYears(-age).Date < inputDate.Date ? (age - 1) : age;
			}
			return 0;
		}

		#endregion
	}
	#endregion
}
