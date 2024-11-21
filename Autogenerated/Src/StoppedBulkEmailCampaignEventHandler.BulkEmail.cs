namespace BPMSoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BPMSoft.Common;
    using BPMSoft.Core.Campaign;
    using BPMSoft.Core.Campaign.EventHandler;
    using BPMSoft.Core.DB;
    using CoreCampaignSchema = Core.Campaign.CampaignSchema;

    #region Class: StoppedBulkEmailCampaignEventHandler

    public sealed class StoppedBulkEmailCampaignEventHandler : CampaignEventHandlerBase, IOnCampaignValidate,
        IOnCampaignBeforeSave
    {

        #region Methods: Private

        private bool GetHasEmailWithStatus(Guid[] bulkEmailStatusId, IEnumerable<Guid> emailIds) {
            if (!UserConnection.GetIsFeatureEnabled("BulkEmailStop") || emailIds.IsEmpty()) {
                return false;
            }
            var select = new Select(UserConnection).Count(nameof(BulkEmail.Id)).From(nameof(BulkEmail))
                .Where(nameof(BulkEmail.Id)).In(Column.Parameters(emailIds))
                .And(nameof(BulkEmail.StatusId)).In(Column.Parameters(bulkEmailStatusId)) as Select;
            var emailsCount = select.ExecuteScalar<int>();
            return emailsCount > 0;
        }
        
        private IEnumerable<Guid> GetBulkEmailIds(CoreCampaignSchema schema) {
            return schema.FlowElements.OfType<MarketingEmailElement>().Select(x => x.MarketingEmailId);
        }

        private void ValidateStoppedEmail() {
            var emailIds = GetBulkEmailIds(CampaignSchema);
            var hasEmailWithStatus = GetHasEmailWithStatus(new[] {
                MailingConsts.BulkEmailStatusHardStoppedId, MailingConsts.BulkEmailStatusBreakingId
            }, emailIds);
            if (!hasEmailWithStatus) {
                return;
            }
            var message = GetLczStringValue(nameof(StoppedBulkEmailCampaignEventHandler),
                "StoppedEmailOnStartingCampaign");
            CampaignSchema.AddValidationInfo(message, CampaignValidationInfoLevel.Warning);
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// Handles an event that is raised before campaign schema saved.
        /// </summary>
        public void OnBeforeSave() {
            ValidateStoppedEmail();
        }

        /// <summary>Handles an event that is raised on campaign validation before start.</summary>
        public void OnValidate() {
            ValidateStoppedEmail();
        }

        #endregion

    }

    #endregion

}

