namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.DynamicContent;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: BulkEmail_MarketingCampaignEventsProcess

	public partial class BulkEmail_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void BulkEmailInserting() {
			if (!Entity.GetIsColumnValueLoaded("CategoryId")) {
				return;
			}
			if (Entity.CategoryId == MarketingConsts.TriggeredEmailBulkEmailCategoryId) {
				Entity.SetColumnValue("StartDate", DateTime.UtcNow.AddMinutes(15));
			}
			if (!Entity.GetIsColumnValueLoaded("LaunchOptionId") || !Entity.LaunchOptionId.IsEmpty()) {
				return;
			}
			if (Entity.CategoryId == MarketingConsts.MassmailingBulkEmailCategoryId) {
				Entity.SetColumnValue("LaunchOptionId", MarketingConsts.BulkEmailManaulLaunchOptionId);
			}
			if (Entity.CategoryId == MarketingConsts.TriggeredEmailBulkEmailCategoryId) {
				Entity.SetColumnValue("LaunchOptionId", MarketingConsts.TriggerEmailScheduledLaunchOptionId);
			}
		}

		public virtual void BulkEmailSaved() {
			var isDCFeatureEnabled = UserConnection.GetIsFeatureEnabled("BulkEmailDynamicContentBuilder");
			if (isDCFeatureEnabled && IsCopy && SourceBulkEmailId.IsNotEmpty()) {
				var hasTemplateSource = HasTemplate(SourceBulkEmailId);
				if (hasTemplateSource) {
					CopyBulkEmailTemplate();
				} else {
					CopyBulkEmailWithoutTemplate();
				}
			}
			if (!isDCFeatureEnabled && (IsCopy || IsTemplateBodyChanged)) {
				CopyBulkEmailWithoutTemplate();
			}
		}

		public virtual void BulkEmailDeleted() {
			var isDCFeatureEnabled = UserConnection.GetIsFeatureEnabled("BulkEmailDynamicContentBuilder");
			if (Entity.GetIsColumnValueLoaded("StatusId") && EntityRId > 0) {
				Guid statusColumnValue = Entity.GetTypedColumnValue<Guid>("StatusId");
				if(statusColumnValue == MarketingConsts.BulkEmailStatusPlannedId) {
					var delete = new Delete(UserConnection)
							.From("BulkEmailTarget")
							.Where("BulkEmailId").IsEqual(Column.Parameter(Entity.Id));
					delete.Execute();
				}
			}
			if (isDCFeatureEnabled) {
				DeleteBulkEmailTemplate();
			}
		}

		public virtual int GetBulkEmailRId(Guid bulkEmailId) {
			var select = new Select(UserConnection)
				.Column("RId")
				.From("BulkEmail")
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			return select.ExecuteScalar<int>();
		}

		public virtual void BulkEmailDeleting() {
			EntityRId = GetBulkEmailRId(Entity.Id);
		}

		public virtual void CopyBulkEmailTemplate() {
			var templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection);
			var repositoryReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.ExcludeAttributes
					| DCTemplateReadOption.ExcludeReplicaHtmlContent
			};
			var existingTemplate = templateRepository.ReadByRecordId(SourceBulkEmailId, repositoryReadOptions);
			if (existingTemplate != null && existingTemplate.Id.IsNotEmpty()) {
				var templateCopyId = templateRepository.Copy(existingTemplate.Id);
				LinkTemplateWithBulkEmail(templateCopyId);
				CopyHyperlinks();
				CopyHeaders();
			}
		}

		public virtual void LinkTemplateWithBulkEmail(Guid templateCopyId) {
			if (templateCopyId.IsNotEmpty()) {
				var bulkEmailId = Entity.GetTypedColumnValue<Guid>("Id");
				var templateEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(nameof(DCTemplate));
				var templateEntity = templateEntitySchema.CreateEntity(UserConnection);
				if (templateEntity.FetchFromDB(templateCopyId)) {
					templateEntity.SetColumnValue("RecordId", bulkEmailId);
					templateEntity.Save();
				}
			}
		}

		public virtual void DeleteBulkEmailTemplate() {
			var bulkEmailId = Entity.GetTypedColumnValue<Guid>("Id");
			var templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection);
			var repositoryReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.ExcludeAttributes
					| DCTemplateReadOption.ExcludeReplicaHtmlContent
			};
			var existingTemplate = templateRepository.ReadByRecordId(bulkEmailId, repositoryReadOptions);
			if (existingTemplate != null && existingTemplate.Id.IsNotEmpty()) {
				templateRepository.Delete(existingTemplate.Id);
			}
		}

		public virtual void CopyHyperlinks() {
			var bulkEmailId = Entity.GetTypedColumnValue<Guid>("Id");
			var hyperlinksRepository = new BulkEmailHyperlinkRepository(UserConnection);
			hyperlinksRepository.CopyBulkEmailHyperlinks(SourceBulkEmailId, bulkEmailId);
		}

		public virtual void CopyBulkEmailWithoutTemplate() {
			var bulkEmailId = Entity.GetTypedColumnValue<Guid>("Id");
			var templateBody = Entity.GetTypedColumnValue<string>("TemplateBody");
			var statusId = Entity.GetTypedColumnValue<Guid>("StatusId");
			bool replaseHyperlinks = (statusId == MarketingConsts.BulkEmailStatusPlannedId);
			BulkEmailHyperlinkHelper.SaveBulkEmailHyperlinks(bulkEmailId, templateBody, replaseHyperlinks, UserConnection);
		}

		public virtual bool HasTemplate(Guid bulkEmailId) {
			var templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection);
			var repositoryReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.ExcludeAttributes
					| DCTemplateReadOption.ExcludeReplicaHtmlContent
			};
			var existingTemplate = templateRepository.ReadByRecordId(bulkEmailId, repositoryReadOptions);
			return existingTemplate != null && existingTemplate.Id.IsNotEmpty();
		}

		public virtual void CopyHeaders() {
			var bulkEmailId = Entity.GetTypedColumnValue<Guid>("Id");
			var templateRepository = new BulkEmailTemplateRepository(UserConnection);
			templateRepository.CopyBulkEmailReplicaHeaders(SourceBulkEmailId, bulkEmailId);
		}

		public virtual void SetBulkEmailStatus() {
			var isWizardFeatureEnabled = UserConnection.GetIsFeatureEnabled("MarketingContentBuilderWizard");
			var isCurrentStatusDraft = Entity.GetTypedColumnValue<Guid>("StatusId") == MailingConsts.BulkEmailStatusDraftId;
			var defaultStatus = isWizardFeatureEnabled && isCurrentStatusDraft 
				? MailingConsts.BulkEmailStatusDraftId 
				: MailingConsts.BulkEmailStatusPlannedId;
			Entity.SetColumnValue("StatusId", defaultStatus);
		}

		public virtual void CheckAudienceSchemaState(Guid bulkEmailId) {
			var select = new Select(UserConnection)
				.Column("AudienceSchemaId")
				.Column("IsAudienceInited")
				.From(nameof(BulkEmail))
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			select.SpecifyNoLockHints();
			select.ExecuteReader(dr => {
				var audienceSchemaId = dr.GetColumnValue<Guid>("AudienceSchemaId");
				var isAudienceInited = dr.GetColumnValue<bool>("IsAudienceInited");
				if (isAudienceInited) {
					Entity.SetColumnValue("AudienceSchemaId", audienceSchemaId);
				}
			});
		}

		#endregion

	}

	#endregion

}

