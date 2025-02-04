namespace BPMSoft.Configuration
{
    using System;
    using BPMSoft.Common;
    using BPMSoft.Core;
    using BPMSoft.Core.DB;
    using BPMSoft.Core.Entities;
    using Telegram.Bot.Types;

    public class UsrTransortRequestsHelper
    {
        public UserConnection UserConnection;
        
        public UsrTransortRequestsHelper(UserConnection userConnection) {
            this.UserConnection = userConnection;
        }

        public int getActivityCount(Guid driverId) {
            var esq = getActivityEsq();
            var esqIdFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", driverId);
            var esqStatusFilter = esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", "201cfba8-58e6-df11-971b-001d60e938c6");
            var esqStatusFilter1 = esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", "4bdbb88f-58e6-df11-971b-001d60e938c6");
            esq.Filters.Add(esqIdFilter);
            esq.Filters.Add(esqStatusFilter);
            esq.Filters.Add(esqStatusFilter1);
            var activities = esq.GetEntityCollection(this.UserConnection);

            if (activities == null) return 0;
            
            return activities.Count;
        }
        
        public int deleteActivities(Guid usrReqId) {
            if (usrReqId.IsEmpty()) return 0;
            
            var delete = new Delete(this.UserConnection)
                .From("Activity")
                .Where("UsrTransportRequestId").IsEqual(Column.Parameter(usrReqId));
            return delete.Execute();
        }

        private EntitySchemaQuery getActivityEsq() {
            var entitySchema = this.UserConnection.EntitySchemaManager.GetInstanceByName("Activity");
            var esq = new EntitySchemaQuery(entitySchema) { };
            esq.PrimaryQueryColumn.IsAlwaysSelect = true;
           
            return esq;
        }
    }

}
