namespace BPMSoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BPMSoft.Common;
    using BPMSoft.Configuration.Reporting.FastReport;
    using BPMSoft.Core;
    using BPMSoft.Core.Entities;
    using BPMSoft.Core.Factories;

    #region Class: ContactAnniversariesReportDataProvider

    [DefaultBinding(typeof(IFastReportDataSourceDataProvider), Name = "ContactAnniversariesReportDataProvider")]
    public class ContactAnniversariesReportDataProvider : IFastReportDataSourceDataProvider
    {

        #region Fields: Private

        private readonly Guid _contactEntitySchemaUId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");
        private readonly Guid _contactAnniversaryEntitySchemaUId = new Guid("FA36E9A5-C2FC-47B2-B5CB-2B58EF61D4E6");
        private readonly string _resourceManagerName = "ContactAnniversariesReportDataProvider";

        private readonly string[] _localizableStringNames = new[] {
            "ContactTitle",
            "ContactNameLabel",
            "ContactOwnerLabel",
            "NoteworthyEventsTitle",
            "ContactHomePhoneLabel",
            "ContactMobilePhoneLabel",
            "NoteworthyEventsDateLabel",
            "ContactBusinessPhoneLabel",
            "NoteworthyEventsTypeLabel"
        };

        #endregion

        #region Methods: Private

        private IEnumerable<IReadOnlyDictionary<string, object>> GetContactData(UserConnection userConnection,
            Guid entitySchemaUId, IEntitySchemaQueryFilterItem filter) {
            var entitySchema = userConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
            EntitySchemaQuery query = new EntitySchemaQuery(entitySchema);
            var idColumn = query.AddColumn("Id");
            query.AddColumn("Name");
            query.AddColumn("Phone");
            query.AddColumn("HomePhone");
            query.AddColumn("MobilePhone");
            var ownerColumn = query.AddColumn("Owner");
            query.Filters.Add(filter);
            EntityCollection collection = query.GetEntityCollection(userConnection);
            var result = new List<IReadOnlyDictionary<string, object>>();
            foreach (var entity in collection) {
                var lookupColumn = entity.Schema.Columns.GetByName(ownerColumn.Name);
                result.Add(new Dictionary<string, object> {
                    ["Name"] = entity.GetColumnValue("Name").ToString(),
                    ["Phone"] = entity.GetColumnValue("Phone").ToString(),
                    ["HomePhone"] = entity.GetColumnValue("HomePhone").ToString(),
                    ["MobilePhone"] = entity.GetColumnValue("MobilePhone").ToString(),
                    ["Id"] = entity.GetTypedColumnValue<Guid>(idColumn.Name),
                    ["OwnerName"] = entity.GetTypedColumnValue<string>(lookupColumn.DisplayColumnValueName)
                });
            }
            return result;
        }

        private IEnumerable<IReadOnlyDictionary<string, object>> GetContactAnniversaryData(
            UserConnection userConnection, Guid entitySchemaUId, IEntitySchemaQueryFilterItem filter) {
            var entitySchema = userConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
            EntitySchemaQuery query = new EntitySchemaQuery(entitySchema);
            var dateColumn = query.AddColumn("Date");
            var contactColumn = query.AddColumn("Contact");
            var typeColumn = query.AddColumn("AnniversaryType");
            var subQueryExpression = query.CreateSubEntitySchemaExpression("Contact.Id");
            subQueryExpression.SubQuery.Filters.Add(filter);
            var subFilter = new EntitySchemaQueryFilter(FilterComparisonType.Exists);
            subFilter.RightExpressions.Add(subQueryExpression);
            query.Filters.Add(subFilter);
            EntityCollection collection = query.GetEntityCollection(userConnection);
            var result = new List<IReadOnlyDictionary<string, object>>();
            foreach (var entity in collection) {
                var lookupContactColumn = entity.Schema.Columns.GetByName(contactColumn.Name);
                var lookupTypeColumn = entity.Schema.Columns.GetByName(typeColumn.Name);
                result.Add(new Dictionary<string, object> {
                    ["Date"] = entity.GetTypedColumnValue<DateTime>(dateColumn.Name),
                    ["ContactId"] = entity.GetColumnValue(lookupContactColumn.ColumnValueName),
                    ["TypeName"] = entity.GetTypedColumnValue<string>(lookupTypeColumn.DisplayColumnValueName)
                });
            }
            return result;
        }

        private IEntitySchemaQueryFilterItem ExtractFilterFromParameters(UserConnection userConnection,
            Guid entitySchemaUId, IReadOnlyDictionary<string, object> parameters) {
            var managerItem = userConnection.EntitySchemaManager.GetItemByUId(entitySchemaUId);
            return parameters.ExtractEsqFilterFromReportParameters(userConnection, managerItem.Name) ??
                throw new Exception();
            ;
        }

        private IEnumerable<IReadOnlyDictionary<string, object>> GetLocalizableStrings(UserConnection userConnection) {
            var localizableStrings = _localizableStringNames.ToDictionary(x => x,
                x => (object)(new LocalizableString(userConnection.ResourceStorage, _resourceManagerName,
                    $"LocalizableStrings.{x}.Value")).Value);
            return new[] { localizableStrings };
        }

        #endregion

        #region Methods: Public

        public Task<ReportDataDictionary> GetData(UserConnection userConnection,
            IReadOnlyDictionary<string, object> parameters) {
            var contactFilter = ExtractFilterFromParameters(userConnection, _contactEntitySchemaUId, parameters);
            var result = new ReportDataDictionary {
                ["Contact"] = GetContactData(userConnection, _contactEntitySchemaUId, contactFilter),
                ["ContactAnniversary"] = GetContactAnniversaryData(userConnection, _contactAnniversaryEntitySchemaUId,
                    contactFilter),
                ["LocalizableStrings"] = GetLocalizableStrings(userConnection)
            };
            return Task.FromResult(result);
        }

        #endregion

    }

    #endregion

}

