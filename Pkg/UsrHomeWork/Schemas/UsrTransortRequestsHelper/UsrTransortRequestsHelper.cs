namespace BPMSoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using BPMSoft.Common;
    using BPMSoft.Core;
    using BPMSoft.Core.DB;
    using BPMSoft.Core.Entities;
    using Telegram.Bot.Types;
    using Update = BPMSoft.Core.DB.Update;

    public class UsrTransortRequestsHelper
    {
        public UserConnection UserConnection;
        
        public UsrTransortRequestsHelper(UserConnection userConnection) {
            this.UserConnection = userConnection;
        }

        public int getActivityCount(Guid driverId) {
            if (driverId.IsEmpty()) return 0;
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
        
        public IEnumerable<Guid> GetAllUsrTransportRequests() {
            var esq = getUsrTransportRequestsEsq();
            var records = esq.GetEntityCollection(this.UserConnection);
            return records.Select(record => record.GetTypedColumnValue<Guid>("Id"));
        }
        
        public Guid GetUsrTransportRequestsById(string recordId) {
            if (recordId.IsNullOrEmpty()) return Guid.Empty;
            var esq = getUsrTransportRequestsEsq();
            var records = esq.GetEntityCollection(this.UserConnection);
            Guid.TryParse(recordId, out Guid id);
            try {
                var findedRecord = records.First(record => record.GetTypedColumnValue<Guid>("Id") == id); // тут через LinQ
                return findedRecord.GetTypedColumnValue<Guid>("Id");
            } catch (Exception e) {
                return Guid.Empty;
            }
        }
        
        public int UpdateUsrTransportRequestsByIdCore(string recordId, string name) {
            if (recordId.IsNullOrEmpty() || name.IsEmpty()) return 0;
            var usrTransportRequest = new UsrTransportRequests(this.UserConnection);
            if (usrTransportRequest.FetchFromDB(recordId, false)) { 
                var update = new Update(this.UserConnection, "UsrTransportRequests") // тут через Update CoreDB
                    .Set("UsrName", Column.Parameter(name))
                    .Where("Id").IsEqual(Column.Parameter(usrTransportRequest.GetTypedColumnValue<Guid>("Id")));
                return update.Execute(); // тут через Delete Entity
            }
            return 0;
        }
        
        public Guid UpdateUsrTransportRequestsByIdEntity(string recordId, string name) {
            if (recordId.IsNullOrEmpty() || name.IsEmpty()) return Guid.Empty;
            var usrTransportRequest = new UsrTransportRequests(this.UserConnection);
            if (usrTransportRequest.FetchFromDB(recordId, false)) { 
                usrTransportRequest.UsrName = name;
                usrTransportRequest.Save();
                return usrTransportRequest.PrimaryColumnValue;// тут через Delete Entity
            }
            return Guid.Empty;
        }
        
        public void DeleteUsrTransportRequestsById(string recordId) {
            if (recordId.IsNullOrEmpty()) return;
            var usrTransportRequest = new UsrTransportRequests(this.UserConnection);
            if (usrTransportRequest.FetchFromDB(recordId, false)) { // тут через FetchFromDB
                usrTransportRequest.Delete(); // тут через Delete Entity
            }
        }
        
        public Guid CreateUsrTransportRequests(UsrTransportRequestData data) {
            if (data == null) return Guid.Empty;

            var usrTransportRequest = new UsrTransportRequests(this.UserConnection);
            usrTransportRequest.SetDefColumnValues();
            usrTransportRequest.UsrName = data.UsrName;
            usrTransportRequest.UsrRequestNumber = data.UsrRequestNumber;
            usrTransportRequest.UsrDeliveryAddress = data.UsrDeliveryAddress;
            usrTransportRequest.UsrDescription = data.UsrDescription;

            usrTransportRequest.Save();
            return usrTransportRequest.PrimaryColumnValue;
        }
        
        private EntitySchemaQuery getUsrTransportRequestsEsq() {
            var entitySchema = this.UserConnection.EntitySchemaManager.GetInstanceByName("UsrTransportRequests");
            var esq = new EntitySchemaQuery(entitySchema) { };
            esq.PrimaryQueryColumn.IsAlwaysSelect = true;
           
            return esq;
        }
    }
    
    [DataContract]
    public class UsrTransportRequestData
    {
        [DataMember(Name = "name", IsRequired = true)]
        public string UsrName;

        [DataMember(Name = "requestNumber", IsRequired = true)]
        public string UsrRequestNumber;

        [DataMember(Name = "deliveryAddress", IsRequired = true)]
        public string UsrDeliveryAddress;
        
        [DataMember(Name = "description")]
        public string UsrDescription;
    }

}
