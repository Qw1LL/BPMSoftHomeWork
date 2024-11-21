namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: RegistrationFromEmail

	/// <summary>
	/// A class that provides base functionality of junk emails filtering.
	/// </summary>
	public class RegistrationFromEmail
	{
		#region Properties: Public

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get;
			private set;
		}

		#endregion

		#region Constructors: Public

		public RegistrationFromEmail() {
		}

		public RegistrationFromEmail(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Extracts the property value of given header properties.
		/// </summary>
		/// <param name="headerProperties">Header properties.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns>Property value.</returns>
		public virtual object ExtractPropertyValue(string headerProperties, string propertyName,
			string pattern = JunkFilterConsts.HeaderPropertyValuesPattern) {
			pattern = string.Format(pattern, propertyName);
			var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			Match match = regex.Match(headerProperties);
			return match.Success ? match.Groups[2].Value.Trim() : null;
		}

		/// <summary>
		/// Extracts all of property values of given header properties.
		/// </summary>
		/// <param name="headerProperties">Header properties.</param>
		/// <returns>Dictionary of properties and their values.</returns>
		public virtual Dictionary<string, object> ExtractPropertyValues(string headerProperties,
			string pattern = JunkFilterConsts.HeaderPropertyValuesPattern) {
			pattern = string.Format(pattern, @".+");
			var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			var result = new Dictionary<string, object>();
			foreach (Match match in regex.Matches(headerProperties)) {
				if (match.Success) {
					string propertyName = match.Groups[1].Value;
					object propertyValue = match.Groups[2].Value.Trim();
					if (!result.ContainsKey(propertyName.ToLower())) {
						result.Add(propertyName.ToLower(), propertyValue);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Instantiates handlers for all active header properties and runs Check-methods.
		/// </summary>
		/// <param name="headerProperties">Header properties.</param>
		/// <returns>True if all of Check-methods returns true.
		/// False if at least one of Check-methods returns false.</returns>
		public virtual bool CheckAllHeaderProperties(string headerProperties) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "HeaderProperty");
			string flagName = esq.AddColumn("Name").Name;
			string handlerTypeName = esq.AddColumn("Handler").Name;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsActive", true));
			EntityCollection headerPropertiesToCheck = esq.GetEntityCollection(UserConnection);
			Dictionary<string, object> propertyValues = ExtractPropertyValues(headerProperties);
			foreach (var headerProperty in headerPropertiesToCheck) {
				var propertyName = headerProperty.GetTypedColumnValue<string>(flagName);
				var typeName = headerProperty.GetTypedColumnValue<string>(handlerTypeName);
				object propertyValue;
				if (propertyValues.TryGetValue(propertyName.ToLower(), out propertyValue)) {
					Type classType = Type.GetType(typeName);
					if (classType != null) {
						string assemblyQualifiedName = classType.AssemblyQualifiedName;
						var handler = ClassFactory.ForceGet<IHeaderPropertyHandler>(assemblyQualifiedName);
						if (!handler.Check(propertyValue)) {
							return false;
						}
					}
				}
			}
			return true;
		}

		/// <summary>
		/// For each entry of Blacklist (Domain, Email adress, etc.) checks Sender property of given emailEntity activity
		/// to match.
		/// </summary>
		/// <param name="emailEntity">Email activity.</param>
		/// <returns>True if Sender property matches to any of blacklist entries and False otherwise.</returns>
		public virtual bool CheckIsBlacklisted(Entity email) {
			var comparison = StringComparison.OrdinalIgnoreCase;
			var sender = email.GetTypedColumnValue<string>(JunkFilterConsts.SenderColumnName);
			sender = ActivityUtils.ExtractEmailAddress(sender);
			string domain = Regex.Match(sender, JunkFilterConsts.DomainPattern).Value.TrimStart('@');
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Blacklist");
			string typeCodeColumnName = esq.AddColumn("TypeOfField.Code").Name;
			string name = esq.AddColumn("Name").Name;
			EntityCollection filters = esq.GetEntityCollection(UserConnection);
			foreach (var filter in filters) {
				var typeCode = filter.GetTypedColumnValue<string>(typeCodeColumnName);
				var filteringValue = filter.GetTypedColumnValue<string>(name);
				switch (typeCode) {
					case JunkFilterConsts.EmailTypeCode:
						if (string.Equals(sender, filteringValue, comparison)) {
							return true;
						}
						break;
					case JunkFilterConsts.DomainTypeCode:
						if (string.Equals(domain, filteringValue, comparison)) {
							return true;
						}
						break;
					case JunkFilterConsts.EntryTypeCode:
						if (sender.IndexOf(filteringValue, comparison) >= 0) {
							return true;
						}
						break;
					default:
						throw new Exception(new LocalizableString(UserConnection.ResourceStorage,
							"RegistrationFromEmail", "UnsupportedTypeOfFieldErrorMsg"));
				}
			}
			return false;
		}

		#endregion

	}

	#endregion

}
