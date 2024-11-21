namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;

	#region Class: ContactTimezone

	public class ContactTimezone : IContactTimezone
	{

		#region Class: Private

		private class LocationTimezoneColumnsName
		{
			public string Code { get; set; }

			public string LocationId { get; set; }

			public string Location { get; set; }
		}

		#endregion

		#region Fields: Private

		private bool _isSysAdminUnitContact = false;
		private readonly IEnumerable<LocationTimezoneColumnsName> _profileTimezoneColumnsName =
				new List<LocationTimezoneColumnsName>() {
			new LocationTimezoneColumnsName() { Code = "Code" }
		};
		private readonly IEnumerable<LocationTimezoneColumnsName> _addressTimezoneColumnsName =
				new List<LocationTimezoneColumnsName>() {
			new LocationTimezoneColumnsName() { Code = "CityTimeZoneCode", LocationId = "TimezoneCityId", Location = "City"},
			new LocationTimezoneColumnsName() { Code = "RegionTimeZoneCode", LocationId = "TimezoneRegionId", Location = "Region"},
			new LocationTimezoneColumnsName() { Code = "CountryTimeZoneCode", LocationId = "TimezoneCountryId", Location = "Country"}
		};

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize new instance of the class.
		/// </summary>
		/// <param name="userConnection">User connection instance</param>
		public ContactTimezone(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		private UserConnection _userConnection;
		protected UserConnection UserConnection {
			set {
				if (value == null) {
					throw new ArgumentNullException("userConnection");
				}
				_userConnection = value;
			}
			get {
				return _userConnection;
			}
		}

		private Guid _contactId;
		protected Guid ContactId {
			set {
				if (value.Equals(Guid.Empty)) {
					throw new ArgumentEmptyException("contactId");
				}
				_contactId = value;
			}
			get {
				return _contactId;
			}
		}

		#endregion

		#region Methods: Private

		private ContactTimezoneInfo GetContactAccountAddressTimezone() {
			Select select = GetContactAccountAddressTimezoneSelect();
			return ReadTimezoneFromSelectResult(select, _addressTimezoneColumnsName);
		}

		private Select GetContactAccountAddressTimezoneSelect() {
			Select select = GetGeneralAddressSelect("AccountAddress", AddressTypeConsts.LegalId);
			select.Join(JoinType.LeftOuter, "Contact")
				.On("Contact", "AccountId").IsEqual("AccountAddress", "AccountId")
			.Where("Contact", "Id").IsEqual(Column.Parameter(ContactId));
			return select;
		}

		private ContactTimezoneInfo GetContactAddressTimezone() {
			Select select = GetContactAddressTimezoneSelect();
			return ReadTimezoneFromSelectResult(select, _addressTimezoneColumnsName);
		}

		private Select GetContactAddressTimezoneSelect() {
			Select select = GetGeneralAddressSelect("ContactAddress", AddressTypeConsts.HomeId);
			select.Where("ContactAddress", "ContactId").IsEqual(Column.Parameter(ContactId));
			return select;
		}

		private Select GetGeneralAddressSelect(string contactAddressType, Guid mainAddressTypeId) {
			Select subselectForCase = GetSubselectForCase(mainAddressTypeId);
			Select subselectForCityCount = GetSubselectForCityCount();
			return new Select(UserConnection).Top(1)
				.Column(contactAddressType, "AddressTypeId")
				.Column(contactAddressType, "CityId")
				.Column("City", "Id").As("TimezoneCityId")
				.Column("Region", "Id").As("TimezoneRegionId")
				.Column("Country", "Id").As("TimezoneCountryId")
				.Column("tzCity", "Code").As("CityTimeZoneCode")
				.Column("tzRegion", "Code").As("RegionTimeZoneCode")
				.Column("tzCountry", "Code").As("CountryTimeZoneCode")
				.Column(Column.SubSelect(subselectForCase)).As("MainAddressTypeId")
				.Column(Column.SubSelect(subselectForCityCount)).As("IsSetCity")
			.From(contactAddressType)
			.Join(JoinType.LeftOuter, "City")
				.On("City", "Id").IsEqual(contactAddressType, "CityId")
			.Join(JoinType.LeftOuter, "Region")
				.On("Region", "Id").IsEqual(contactAddressType, "RegionId")
			.Join(JoinType.LeftOuter, "Country")
				.On("Country", "Id").IsEqual(contactAddressType, "CountryId")
			.Join(JoinType.LeftOuter, "TimeZone").As("tzCity")
				.On("City", "TimeZoneId").IsEqual("tzCity", "Id")
			.Join(JoinType.LeftOuter, "TimeZone").As("tzRegion")
				.On("Region", "TimeZoneId").IsEqual("tzRegion", "Id")
			.Join(JoinType.LeftOuter, "TimeZone").As("tzCountry")
				.On("Country", "TimeZoneId").IsEqual("tzCountry", "Id")
			.Join(JoinType.LeftOuter, "AddressType")
				.On("AddressType", "Id").IsEqual(contactAddressType, "AddressTypeId")
			.OrderByDesc("MainAddressTypeId")
			.OrderByDesc("IsSetCity")
			.OrderByDesc(contactAddressType, "CreatedOn") as Select;
		}

		private Select GetSubselectForCityCount() {
			return new Select(UserConnection)
				.Column(Func.Count("Id"))
				.From("City").As("cityCount")
				.Where("cityCount", "Name").IsEqual("City", "Name") as Select;
		}


		private Select GetSubselectForCase(Guid mainAddressTypeId) {
			return new Select(UserConnection)
				.Column("subAddressType", "Id")
			.From("AddressType").As("subAddressType")
			.Where("subAddressType", "Id").IsEqual(Column.Parameter(mainAddressTypeId))
				.And("AddressType", "Id").IsEqual("subAddressType", "Id") as Select;
		}

		private ContactTimezoneInfo GetProfileTimezone() {
			Select select = GetProfileTimezoneSelect();
			ContactTimezoneInfo info = ReadTimezoneFromSelectResult(select, _profileTimezoneColumnsName);
			string timezone = info.TimezoneCode;
			_isSysAdminUnitContact = !string.IsNullOrEmpty(timezone);
			return info;
		}

		private ContactTimezoneInfo GetSysSettingTimezone() {
			Guid timezoneId = Core.Configuration.SysSettings.GetValue<Guid>(UserConnection, "DefaultTimeZone", Guid.Empty);
			if (!timezoneId.IsEmpty()) {
				Select select = GetTimezoneSelect(timezoneId);
				return ReadTimezoneFromSelectResult(select, _profileTimezoneColumnsName);
			}
			return new ContactTimezoneInfo();
		}

		private Select GetTimezoneSelect(Guid timezoneId) {
			var select =
					new Select(UserConnection)
							.Column("Code")
					.From("TimeZone")
					.Where("TimeZone", "Id").IsEqual(Column.Parameter(timezoneId)) as Select;
			return select;
		}

		private Select GetProfileTimezoneSelect() {
			var select =
				new Select(UserConnection)
					.Column("SysAdminUnit", "TimeZoneId")
					.Column("TimeZone", "Code")
				.From("SysAdminUnit")
				.Join(JoinType.LeftOuter, "TimeZone")
					.On("SysAdminUnit", "TimeZoneId").IsEqual("TimeZone", "Code")
				.Where("SysAdminUnit", "ContactId").IsEqual(Column.Parameter(ContactId)) as Select;
			return select;
		}

		private ContactTimezoneInfo ReadTimezoneFromSelectResult(Select select,
				IEnumerable<LocationTimezoneColumnsName> timezoneCodeColumnsName) {
			var timezone = string.Empty;
			var location = string.Empty;
			var locationId = Guid.Empty;
			var locationType = string.Empty;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						foreach (LocationTimezoneColumnsName column in timezoneCodeColumnsName) {
							timezone = reader.GetColumnValue<string>(column.Code);
							if (!string.IsNullOrEmpty(timezone) && !string.IsNullOrEmpty(column.Location) &&
									!string.IsNullOrEmpty(column.LocationId)) {
								locationId = reader.GetColumnValue<Guid>(column.LocationId);
								locationType = column.Location;
								break;
							}
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(locationType) && !locationId.Equals(default(Guid))) {
				location = GetLocationName(locationId, locationType);
			}
			return new ContactTimezoneInfo() {
				TimezoneCode = timezone,
				Location = location
			};
		}

		private string GetLocationName(Guid locationId, string locationType) {
			var result = string.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, locationType);
			string columnName = esq.AddColumn("Name").Name;
			IEntitySchemaQueryFilterItem filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				esq.RootSchema.GetPrimaryColumnName(), locationId);
			esq.Filters.Add(filter);
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				result = entities[0].GetTypedColumnValue<string>(columnName);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns contact GMT timezone.
		/// </summary>
		/// <param name="contactId">Contact id.</param>
		/// <returns>Contact GMT timezone.</returns>
		public ContactTimezoneInfo GetTimezone(Guid contactId) {
			ContactId = contactId;
			ContactTimezoneInfo info = GetProfileTimezone();
			if (string.IsNullOrEmpty(info.TimezoneCode) && _isSysAdminUnitContact) {
				info = GetSysSettingTimezone();
			}
			if (string.IsNullOrEmpty(info.TimezoneCode)) {
				info = GetContactAddressTimezone();
			}
			if (string.IsNullOrEmpty(info.TimezoneCode)) {
				info = GetContactAccountAddressTimezone();
			}
			return info;
		}

		#endregion

	}

	#endregion

}

