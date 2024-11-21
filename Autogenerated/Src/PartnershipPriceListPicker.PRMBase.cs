namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: PartnershipPriceListPicker

	/// <summary>
	/// Class for selection PriceList from Partnership.
	/// </summary>
	public class PartnershipPriceListPicker : AccountPriceListPicker
	{

		#region Constants: Private

		private readonly Guid _parameterTypeBenefit = Guid.Parse("1C4E69DD-3C34-4008-A564-BF9232A34D27");
		private readonly Guid _parameterCategory = Guid.Parse("bddfbe22-29d4-4fee-8ed7-e5b2496768e3");

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="PartnershipPriceListPicker"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public PartnershipPriceListPicker(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Private

		private Select GetPartnershipPriceListSelect(Guid accountId) {
			return new Select(UserConnection)
					.Column("GuidValue")
					.From("PartnershipParameter").As("PP")
					.InnerJoin("Partnership").As("P")
					.On("P", "Id").IsEqual("PP", "PartnershipId")
					.And("P", "PartnerLevelId").IsEqual("PP", "PartnerLevelId")
					.Where("P", "AccountId").IsEqual(Column.Parameter(accountId))
					.And("P", "IsActive").IsEqual(Column.Const(true))
					.And("PP", "ParameterTypeId").IsEqual(Column.Const(_parameterTypeBenefit))
					.And("PP", "PartnerParamCategoryId").IsEqual(Column.Const(_parameterCategory))
				as Select;
		}

		#endregion

		#region Methods: Protected

		protected Guid GetPriceListByPartnershipBenefit(Guid accountId) {
			var partnershipSelect = GetPartnershipPriceListSelect(accountId);
			partnershipSelect.ExecuteSingleRecord<Guid>(reader =>
				reader.GetColumnValue<Guid>("GuidValue"), out Guid result);
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get Price List using account. Took from account, if there is no Price List,
		/// then took it from partnership
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>PriceList identifier</returns>
		public override Guid GetPriceList(Guid accountId) {
			var priceList = base.GetPriceListByAccount(accountId);
			return priceList != default(Guid) ? priceList : GetPriceListByPartnershipBenefit(accountId);
		}

		#endregion
	}

	#endregion

}
