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

    #region Class: ExpiredBulkEmailCampaignEventHandler

    public sealed class ExpiredBulkEmailCampaignEventHandler : CampaignEventHandlerBase, IOnCampaignValidate,
        IOnCampaignBeforeSave
    {

        #region Methods: Private

        private bool GetHasExpiredEmails(IEnumerable<Guid> emailIds) {
            if (!UserConnection.GetIsFeatureEnabled("TriggerEmailThrottlingQueue") || emailIds.IsEmpty()) {
                return false;
            }
            var select = new Select(UserConnection).Count(nameof(BulkEmail.Id)).From(nameof(BulkEmail))
                .Where(nameof(BulkEmail.Id)).In(Column.Parameters(emailIds))
                .And(nameof(BulkEmail.ExpirationDate)).IsLessOrEqual(Column.Parameter(DateTime.UtcNow)) as Select;
            var emailsCount = select.ExecuteScalar<int>();
            return emailsCount > 0;
        }

        private IEnumerable<Guid> GetBulkEmailIds(CoreCampaignSchema schema) {
            return schema.FlowElements.OfType<MarketingEmailElement>().Select(x => x.MarketingEmailId);
        }

        private void ValidateExpiredEmail() {
            var emailIds = GetBulkEmailIds(CampaignSchema);
            var hasExpiredEmails = GetHasExpiredEmails(emailIds);
            if (!hasExpiredEmails) {
                return;
            }
            var message = GetLczStringValue(nameof(ExpiredBulkEmailCampaignEventHandler),
                "ExpiredEmailOnSavingCampaign");
            CampaignSchema.AddValidationInfo(message, CampaignValidationInfoLevel.Warning);
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// Handles an event that is raised before campaign schema saved.
        /// </summary>
        public void OnBeforeSave() {
            ValidateExpiredEmail();
        }

        /// <summary>Handles an event that is raised on campaign validation before start.</summary>
        public void OnValidate() {
            ValidateExpiredEmail();
        }

        #endregion

    }

    #endregion

}

