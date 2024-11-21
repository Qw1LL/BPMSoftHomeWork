namespace BPMSoft.Configuration
{
	using System;

	#region Class: ProductPriceData

	/// <summary>
	/// Class container for ProductPrice.
	/// </summary>
	public class ProductPriceData
	{

		#region Properties: Public

		/// <summary>
		/// Tax identifier.
		/// </summary>
		public Guid TaxId;
		/// <summary>
		/// Currency identifier.
		/// </summary>
		public Guid CurrencyId;
		/// <summary>
		/// Price List identifier.
		/// </summary>
		public Guid PriceListId;
		/// <summary>
		/// Percent of tax.
		/// </summary>
		public decimal TaxPercent;
		/// <summary>
		/// Price of product.
		/// </summary>
		public decimal Price;

		#endregion

	}

	#endregion

}
