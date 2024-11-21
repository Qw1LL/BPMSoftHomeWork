namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.DB;

	#region Class: WebFormObjectCampaignFilter

	public class WebFormObjectCampaignFilter
	{

		#region Constants: Private

		private const string LeadTableName = "Lead";

		private static string EventTargetTableName = "EventTarget";

		#endregion

		#region Methods: Private

		private static Select GetNotSubmitedLandingFilterQuery(UserConnection userConnection, Guid landingId,
			string filterTablename) {
			if (filterTablename == EventTargetTableName) {
				return new Select(userConnection)
					.Column(Column.Parameter(1)).As("counter")
					.From("LandingObjectDefaults")
					.InnerJoin(EventTargetTableName)
						.On(EventTargetTableName, "EventId").IsEqual("LandingObjectDefaults", "GuidValue")
					.Where("LandingId").IsEqual(Column.Parameter(landingId))
					.And("CampaignTarget", "ContactId").IsEqual(EventTargetTableName, "ContactId") as Select;
			}
			if (filterTablename == LeadTableName) {
				return new Select(userConnection)
					.Column(Column.Parameter(1)).As("counter")
					.From(LeadTableName)
					.Where(LeadTableName, "WebFormId").IsEqual(Column.Parameter(landingId))
					.And("CampaignTarget", "ContactId").IsEqual(LeadTableName, "QualifiedContactId") as Select;
			}
			return null;
		}

		private static Select GetSubmitedLandingFilterQuery(UserConnection userConnection, Guid landingId,
			string filterTablename) {
			if (filterTablename == EventTargetTableName) {
				return new Select(userConnection)
					.Column("LandingObjectDefaults", "LandingId").As("RecordId")
					.Column(EventTargetTableName, "ContactId").As("ContactId")
					.From("LandingObjectDefaults")
					.InnerJoin(EventTargetTableName)
						.On(EventTargetTableName, "EventId").IsEqual("LandingObjectDefaults", "GuidValue")
					.Where("LandingObjectDefaults", "LandingId").IsEqual(Column.Parameter(landingId))
					.And(EventTargetTableName, "GeneratedWebFormId").IsEqual(Column.Parameter(landingId)) as Select;
			}
			if (filterTablename == LeadTableName) {
				return new Select(userConnection)
					.Column(LeadTableName, "QualifiedContactId").As("ContactId")
					.From(LeadTableName)
					.Where(LeadTableName, "WebFormId").IsEqual(Column.Parameter(landingId))
					.And("QualifiedContactId").Not().IsNull() as Select;
			}
			return null;
		}

		private static string GetFilterTableName(UserConnection userConnection, Guid landingId) {
			var landingTypeId = (new Select(userConnection)
				.Column("TypeId")
				.From("GeneratedWebForm")
				.Where("Id").IsEqual(Column.Parameter(landingId)) as Select)
				.ExecuteScalar<Guid>();
			if (landingTypeId == CampaignConsts.LeadLandingTypeId) {
				return LeadTableName;
			}
			if (landingTypeId == CampaignConsts.EventTargetLandingTypeId) {
				return EventTargetTableName;
			}
			return String.Empty;
		}

		#endregion

		#region Methods: Public

		public static Select GetFilterQuery(UserConnection userConnection, Guid filterId, Guid landingId, 
				out bool notExistsFilter) {
			notExistsFilter = false;
			string filterTablename = GetFilterTableName(userConnection, landingId);
			Select landingFilterQuery = null;
			if (filterId == CampaignConsts.LandingFormSubmitedCampaignFilterId) {
				landingFilterQuery = GetSubmitedLandingFilterQuery(userConnection, landingId, filterTablename);
			} else if (filterId == CampaignConsts.LandingFormNotSubmitedCampaignFilterId) {
				notExistsFilter = true;
				landingFilterQuery = GetNotSubmitedLandingFilterQuery(userConnection, landingId, filterTablename);
			}
			landingFilterQuery.SpecifyNoLockHints();
			return landingFilterQuery;
		}

		#endregion

	}

	#endregion

}

