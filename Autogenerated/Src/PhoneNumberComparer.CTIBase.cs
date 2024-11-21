namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region class: PhoneNumberComparer

	/// <summary>
	/// Interface for comparing or filtering by phone numbers.
	/// </summary>
	public interface IPhoneNumberComparer
	{

		/// <summary>
		/// Matches the first phone number with the reversed digits (search number) of the second phone number.
		/// </summary>
		/// <param name="phoneNumber1">The first phone number.</param>
		/// <param name="searchNumber2">The reversed digits (search number) of the second phone number.</param>
		/// <returns><c>true</c> if phone numbers are equal, otherwise - <c>false</c>.</returns>
		bool Match(string phoneNumber1, string searchNumber2);

		/// <summary>
		/// Matches the phone number with at least one search number from the given set.
		/// </summary>
		/// <param name="phoneNumber">The phone number to match.</param>
		/// <param name="searchNumbers">The search number set to compare with.</param>
		/// <returns>If the number matches at least one search number returns <c>true</c>, otherwise - <c>false</c>.
		/// </returns>
		bool MatchAny(string phoneNumber, IEnumerable<string> searchNumbers);

		/// <summary>
		/// Gets the filters to search contacts by phone numbers.
		/// </summary>
		/// <param name="esq">The entity schema query that searches for contact communication.</param>
		/// <param name="phones">The phone numbers.</param>
		/// <returns>The group of filters, that filters contact communications by the given phone numbers.</returns>
		EntitySchemaQueryFilterCollection GetSearchContactFilters(EntitySchemaQuery esq, List<string> phones);
	}

	/// <summary>
	/// The class for comparing or filtering by phone numbers.
	/// </summary>
	public class PhoneNumberComparer : IPhoneNumberComparer
	{

		#region Constants: Private

		private const int DefaultSearchNumberLength = 7;
		private const int DefaultInternalNumberLength = 3; 

		#endregion

		#region Fields: Private

		private readonly int _searchNumberLength;
		private readonly int _internalNumberLength;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="PhoneNumberComparer"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public PhoneNumberComparer(UserConnection userConnection) {
			_searchNumberLength = Core.Configuration.SysSettings.GetValue(userConnection, "SearchNumberLength",
				DefaultSearchNumberLength);
			_internalNumberLength = Core.Configuration.SysSettings.GetValue(userConnection, "InternalNumberLength",
				DefaultInternalNumberLength);
		}

		#endregion

		#region Methods: Private

		private string PreprocessPhone(string phone) {
			string str = Regex.Replace(phone ?? "", @"[^\d]", "");
			char[] charArray = str.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray).Substring(0, Math.Min(charArray.Length, _searchNumberLength));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Matches the first phone number with the reversed digits (search number) of the second phone number.
		/// </summary>
		/// <param name="phoneNumber1">The first phone number.</param>
		/// <param name="searchNumber2">The reversed digits (search number) of the second phone number.</param>
		/// <returns><c>true</c> if phone numbers are equal, otherwise - <c>false</c>.</returns>
		public bool Match(string phoneNumber1, string searchNumber2) {
			if (phoneNumber1.IsNullOrEmpty() || searchNumber2.IsNullOrEmpty()) {
				return false;
			}
			string preprocessedPhone = PreprocessPhone(phoneNumber1);
			bool isInternal = preprocessedPhone.Length <= _internalNumberLength;
			if (isInternal) {
				return searchNumber2.Equals(preprocessedPhone);
			}
			return searchNumber2.StartsWith(preprocessedPhone);
		}

		/// <summary>
		/// Matches the phone number with at least one search number from the given set.
		/// </summary>
		/// <param name="phoneNumber">The phone number to match.</param>
		/// <param name="searchNumbers">The search number set to compare with.</param>
		/// <returns>If the number matches at least one search number returns <c>true</c>, otherwise - <c>false</c>.
		/// </returns>
		public bool MatchAny(string phoneNumber, IEnumerable<string> searchNumbers) {
			if (searchNumbers == null) {
				return false;
			}
			return searchNumbers.Any(searchNumber => Match(phoneNumber, searchNumber));
		}

		/// <summary>
		/// Gets the filters to search contacts by phone numbers.
		/// </summary>
		/// <param name="esq">The entity schema query that searches for contact communication.</param>
		/// <param name="phones">The phone numbers.</param>
		/// <returns>The group of filters, that filters contact communications by the given phone numbers.</returns>
		public EntitySchemaQueryFilterCollection GetSearchContactFilters(EntitySchemaQuery esq, List<string> phones) {
			if (phones == null || !phones.Any()) {
				return null;
			}
			IEnumerable<string> validPhones = phones
				.Select(PreprocessPhone)
				.Where(StringUtilities.IsNotNullOrWhiteSpace)
				.ToList();
			if (!validPhones.Any()) {
				return null;
			}
			var filterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			foreach (string number in validPhones) {
				FilterComparisonType comparisonType = number.Length <= _internalNumberLength
					? FilterComparisonType.Equal
					: FilterComparisonType.StartWith;
				filterGroup.Add(esq.CreateFilterWithParameters(comparisonType,
					"[ContactCommunication:Contact:Id].SearchNumber", number));
			}
			return filterGroup;
		}

		#endregion

	} 

	#endregion

}

