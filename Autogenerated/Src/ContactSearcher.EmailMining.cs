namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;

	#region Interface: IContactSearcher

	/// <summary>
	/// Provides utility methods for searching contacts.
	/// </summary>
	public interface IContactSearcher
	{

		#region Methods: Public

		/// <summary>
		/// Searches for contacts in database by given email adresses.
		/// </summary>
		/// <param name="emails">List of emails to search by.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		IEnumerable<Guid> SearchByEmails(List<string> emails);

		/// <summary>
		/// Searches for contacts in database by name.
		/// </summary>
		/// <param name="name">Contact name to search.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		IEnumerable<Guid> SearchByName(string name);

		/// <summary>
		/// Searches for contacts in database by first and last name.
		/// </summary>
		/// <param name="firstName">Given / first name.</param>
		/// <param name="lastName">Surname / last name.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		IEnumerable<Guid> SearchByFirstAndLastName(string firstName, string lastName);

		/// <summary>
		/// Searches for contacts in database by given phone numbers.
		/// </summary>
		/// <param name="phones">List of phone numbers to search by.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		IEnumerable<Guid> SearchByPhones(List<string> phones);

		#endregion

	}

	#endregion

	#region Class: ContactSearcher

	/// <summary>
	/// Implementation of <see cref="IContactSearcher"/>.
	/// </summary>
	[DefaultBinding(typeof(IContactSearcher))]
	public class ContactSearcher : IContactSearcher
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of <see cref="ContactSearcher"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public ContactSearcher(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		/// <summary>
		/// Initializes a new instance of <see cref="ContactSearcher"/> class with custom
		/// <see cref="IPhoneNumberComparer"/>.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="phoneNumberComparer">Phone number comparer.</param>
		public ContactSearcher(UserConnection userConnection, IPhoneNumberComparer phoneNumberComparer) 
				: this(userConnection) {
			_phoneNumberComparer = phoneNumberComparer;
		}

		#endregion

		#region Properties: Private

		private IPhoneNumberComparer _phoneNumberComparer;
		private IPhoneNumberComparer PhoneNumberComparer {
			get {
				return _phoneNumberComparer ?? (_phoneNumberComparer = new PhoneNumberComparer(_userConnection));
			}
		}

		#endregion

		#region Methods: Private

		private EntitySchemaQuery GetEsqForContactSearch() {
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var esq = new EntitySchemaQuery(schema);
			esq.PrimaryQueryColumn.IsVisible = true;
			return esq;
		}

		private List<Guid> FindContacts(EntitySchemaQuery esq) {
			return esq.GetEntityCollection(_userConnection)
				.Select(entity => entity.PrimaryColumnValue).ToList();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Searches for contacts in database by given email adresses.
		/// </summary>
		/// <param name="emails">List of emails to search by.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		public IEnumerable<Guid> SearchByEmails(List<string> emails) {
			if (emails == null) {
				return new List<Guid>();
			}
			IEnumerable<string> validEmails = emails.Where(StringUtilities.IsNotNullOrWhiteSpace);
			if (!validEmails.Any()) {
				return new List<Guid>();
			}
			EntitySchemaQuery esq = GetEsqForContactSearch();
			esq.Filters.LogicalOperation = LogicalOperationStrict.Or;
			foreach (string email in validEmails) {
				var filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"[ContactCommunication:Contact:Id].Number", email);
				esq.Filters.Add(filter);
			}
			return FindContacts(esq);
		}

		/// <summary>
		/// Searches for contacts in database by name.
		/// </summary>
		/// <param name="name">Contact name to search.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		public IEnumerable<Guid> SearchByName(string name) {
			if (string.IsNullOrWhiteSpace(name)) {
				return new List<Guid>();
			}
			EntitySchemaQuery esq = GetEsqForContactSearch();
			var nameFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Name", name);
			esq.Filters.Add(nameFilter);
			return FindContacts(esq);
		}

		/// <summary>
		/// Searches for contacts in database by first and last name.
		/// </summary>
		/// <param name="firstName">Given / first name.</param>
		/// <param name="lastName">Surname / last name.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		public IEnumerable<Guid> SearchByFirstAndLastName(string firstName, string lastName) {
			if (firstName.IsNullOrWhiteSpace() || lastName.IsNullOrWhiteSpace()) {
				return new List<Guid>();
			}
			EntitySchemaQuery esq = GetEsqForContactSearch();
			var firstNameFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "GivenName", firstName);
			var lastNameFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Surname", lastName);
			esq.Filters.Add(firstNameFilter);
			esq.Filters.Add(lastNameFilter);
			return FindContacts(esq);
		}

		/// <summary>
		/// Searches for contacts in database by given phone numbers.
		/// </summary>
		/// <param name="phones">List of phone numbers to search by.</param>
		/// <returns>Collection of ids of found contacts.</returns>
		public IEnumerable<Guid> SearchByPhones(List<string> phones) {
			EntitySchemaQuery esq = GetEsqForContactSearch();
			EntitySchemaQueryFilterCollection filters = PhoneNumberComparer.GetSearchContactFilters(esq, phones);
			if (filters.IsNullOrEmpty()) {
				return new List<Guid>();
			}
			esq.Filters.Add(filters);
			return FindContacts(esq);
		}

		#endregion

	}

	#endregion

}

