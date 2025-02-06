namespace BPMSoft.Configuration.CDTeams
{
    using System;
    using System.Linq;
    using BPMSoft.Core;
    using BPMSoft.Core.Entities;
    using BPMSoft.Core.Entities.Events;
    using BPMSoft.Core.Factories;

    [EntityEventListener(SchemaName = "UsrTransportRequests")]
    public class UsrTransportRequestsEventListener : BaseEntityEventListener
    {
        public override void OnSaved(object sender, EntityAfterEventArgs e) {
            base.OnSaved(sender, e);
            var entity = (UsrTransportRequests)sender;
            var logger = new UsrLogger(entity.UserConnection);
            logger.SetDefColumnValues();
            logger.UsrName = "Saved " + entity.Id;
            logger.UsrResult = "Saved";
            logger.Save();
        }

        public override void OnDeleted(object sender, EntityAfterEventArgs e) {
            base.OnDeleted(sender, e);
            var entity = (UsrTransportRequests)sender;
            var logger = new UsrLogger(entity.UserConnection);
            logger.SetDefColumnValues();
            logger.UsrName = "Deleted";
            logger.UsrResult = "Deleted";
            logger.Save();
        }

        public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
            base.OnUpdating(sender, e);
            var entity = (UsrTransportRequests)sender;
            var logger = new UsrLogger(entity.UserConnection);
            var changedValues = entity.GetChangedColumnValues().Select(x => $"{x.Name}: {x.OldValue} - {x.Value}").ToList();
            logger.SetDefColumnValues();
            logger.UsrName = "Updating " + entity.Id;
            logger.UsrResult = $"Updated  + {String.Join(Environment.NewLine, changedValues)}";
            logger.Save();
        }

        public override void OnInserted(object sender, EntityAfterEventArgs e) {
            base.OnInserted(sender, e);
            var entity = (UsrTransportRequests)sender;
            var logger = new UsrLogger(entity.UserConnection);
            logger.SetDefColumnValues();
            logger.UsrName = "Inserted " + entity.Id;
            logger.UsrResult = "Inserted";
            logger.Save();
        }
    }
}
