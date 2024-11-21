namespace BPMSoft.Configuration.CurrencyException
{
	using System;
	using Common;

	#region Class: CurrencyErrorMessageHelper

	/// <summary>
	/// Provides utility methods for working with error message of the currency.
	/// </summary>
	internal static class CurrencyErrorMessageHelper
	{
		#region Methods: Private

		/// <summary>
		/// Returns localizable string to error message.
		/// </summary>
		/// <param name="storage">Resource storage.</param>
		/// <param name="localizableStringName">Localizable string name.</param>
		/// <returns></returns>
		public static string GetErrorMessageTemplate(IResourceStorage storage, string localizableStringName) {
			var errorMessageTemplate = new LocalizableString(storage, "CurrencyException",
				$"LocalizableStrings.{localizableStringName}.Value");
			return errorMessageTemplate.ToString();
		}

		#endregion
		
	}

	#endregion

	#region Class: CurrencyNotFoundException

	/// <summary>
	/// The exception that is thrown when currency identifier does not found or the exchange rate does not set.
	/// </summary>
	public class CurrencyNotFoundException : NullOrEmptyException
	{

		#region Constructors: Public
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CurrencyNotFoundException"/> class.
		/// </summary>
		/// <param name="storage">Resource storage.</param>
		/// <param name="currencyId">Currency identifier.</param>
		public CurrencyNotFoundException(IResourceStorage storage, Guid currencyId)
			: base(GetErrorMessage(storage, currencyId)) {
		}
		
		#endregion

		#region Methods: Private

		private static LocalizableString GetErrorMessage(IResourceStorage storage, Guid currencyId) {
			var errorMessageTemplate = CurrencyErrorMessageHelper
				.GetErrorMessageTemplate(storage, "CurrencyNotFoundExceptionMessage");
			return string.Format(errorMessageTemplate, currencyId);
		}

		#endregion

	}

	#endregion

	#region Class: CurrencyParameterLessOrEqualsZeroExteption

	/// <summary>
	/// The exception that is thrown when currency parameter less or equals zero.
	/// </summary>
	public class CurrencyParameterLessOrEqualsZeroException : Exception
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrencyParameterLessOrEqualsZeroException"/> class.
		/// </summary>
		/// <param name="storage">Resource storage.</param>
		/// <param name="currencyId">Currency identifier.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value"></param>
		public CurrencyParameterLessOrEqualsZeroException(IResourceStorage storage, Guid currencyId,
				string parameterName, object value) 
			: base(GetErrorMessage(storage, currencyId, parameterName, value)) {
		}

		#endregion

		#region Methods: Private

		private static string GetErrorMessage(IResourceStorage storage, Guid currencyId,
				string parameterName, object value) {
			string errorMessageTemplate = CurrencyErrorMessageHelper
				.GetErrorMessageTemplate(storage, "CurrencyParameterLessOrEqualsZeroExceptionMessage");
			return string.Format(errorMessageTemplate, value, parameterName, currencyId);
		}

		#endregion
		
	}

	#endregion
}

