namespace BPMSoft.Configuration
{
	using System;

	/// <summary>
	/// Interface for PriceList selection.
	/// </summary>
	public interface IPriceListPicker
	{
		/// <summary>
		/// Get pricelist using account.
		/// </summary>
		/// /// <param name="accountId">Account identifier.</param>
		/// <returns>PriceList</returns>
		Guid GetPriceList(Guid accountId);
	}
}
