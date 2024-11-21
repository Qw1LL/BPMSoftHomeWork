namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using BPMSoft.Configuration.DynamicContent;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core.DB;
	using Polly;
	using BPMSoft.Core.Factories;

	#region Class: AudienceSegmentationMailingState

	/// <summary>
	/// Mailing state that implements email audience segmentation by template replicas.
	/// </summary>
	public class AudienceSegmentationMailingState : MailingState
	{

		#region Constants: Private

		private const string BatchSizePropertyName = "batchSize";
		private const string BulkEmailIdPropertyName = "bulkEmailId";

		#endregion

		#region Fields: Private

		private readonly Policy _segmentationPolicy;
		private readonly Context _segmentationRetryContext;
		private static readonly int _iterationBatchSize = 5000;
		private static readonly int _retryCount = 3;
		private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(InitialParallelExecutionThreadCount);

		#endregion

		#region Constructors: Public

		public AudienceSegmentationMailingState() {
			_segmentationPolicy = Policy.Handle<Exception>().Retry(_retryCount,
				(exception, retryIteration, context) => OnRetry(context, retryIteration, exception));
			_segmentationRetryContext = new Context("segmentationPolicy", new Dictionary<string, object> {
				{ BatchSizePropertyName, _iterationBatchSize }
			});
		}

		#endregion

		#region Properties: Private

		private static int InitialParallelExecutionThreadCount =>
			Math.Min(Math.Max(Environment.ProcessorCount / 2, 1), 4);

		#endregion

		#region Properties: Protected

		protected override string ErrorMessageStringCode => "AudienceSegmentationError";

		protected override string EventLczStringCode => "AudienceSegmentationEventName";

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the audience data source factory.
		/// </summary>
		[Obsolete]
		public IMailingAudienceSessionedDataSourceFactory AudienceDataSourceFactory { get; set; }

		/// <summary>
		/// Gets or sets dynamic content strategy resolver.
		/// </summary>
		public DCStrategyResolver DCStrategyResolver { get; set; }

		/// <summary>
		/// Gets or sets the dynamic template repository.
		/// </summary>
		public DCTemplateRepository<DCTemplateModel> DCTemplateRepository { get; set; }

		public override Guid[] AvailableForExecutionStatuses => new[] { MailingConsts.BulkEmailStatusStartsId };

		#endregion

		#region Methods: Private

		private static void OnRetry(Context context, int retryIteration, Exception exception) {
			MailingUtilities.Log.WarnFormat(
				"[AudienceSegmentationMailingState.Segmentation]: " +
				$"Error while audience segmentation email {context[BulkEmailIdPropertyName]} " +
				$"with batch size {context[BatchSizePropertyName]} and iteration {retryIteration - 1}. ", exception);
		}

		private DCSegmentationContext CreateSegmentationContext(DCTemplateModel template, Select audienceSelect) {
			return new DCSegmentationContext(Context.UserConnection) {
				Template = template,
				SourceAudience = audienceSelect,
				SourceAlias = "MandrillDeliveryPackage",
				EntityIdSourceColumn = "RecipientUId",
				SourceColumnForFilter = "ContactId",
				TargetTable = "BulkEmailRecipientReplica",
				EntityIdTargetColumn = "RecipientId",
				ReplicaIdTargetColumn = "DCReplicaId",
				RecordIdTargetColumn = "BulkEmailId"
			};
		}

		private Select GetAudienceSelect(Guid bulkEmailId) {
			var querySource = ClassFactory.Get<AudienceSegmentationQuerySource>(
				new ConstructorArgument("userConnection", Context.UserConnection));
			return querySource.GetAudienceSelect(bulkEmailId);
		}

		private DCTemplateModel GetDcTemplateModel(Guid bulkEmailId) {
			var repositoryOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.None
			};
			DCTemplateModel template = DCTemplateRepository.ReadByRecordId(bulkEmailId, repositoryOptions);
			if (template == null) {
				throw new ArgumentException($"Template for BulkEmail with id {bulkEmailId} not found");
			}
			return template;
		}

		private void ResolveRecipientsReplica(Guid bulkEmailId, int batchSize) {
			DCTemplateModel template = GetDcTemplateModel(bulkEmailId);
			Select audienceSelect = GetAudienceSelect(bulkEmailId);
			var processedRecordsCount = 1;
			while (CanHandle() && processedRecordsCount > 0) {
				DCSegmentationContext segmentationContext = CreateSegmentationContext(template, audienceSelect);
				segmentationContext.BatchSize = batchSize;
				try {
					_semaphore.Wait();
					processedRecordsCount = DCStrategyResolver.SegmentAudience(segmentationContext);
				} finally {
					_semaphore.Release();
				}
				SendingEmailProgressRepository.IncrementPreparedRecipients(bulkEmailId, processedRecordsCount);
			};
		}

		#endregion

		#region Methods: Protected

		protected override MailingStateExecutionResult HandleStepInternal() {
			var bulkEmail = (BulkEmail)Context.BulkEmailEntity;
			var bulkEmailId = bulkEmail.PrimaryColumnValue;
			MailingUtilities.Log.InfoFormat(
				"[AudienceSegmentationMailingState.Segmentation]: " +
				"Audience segmentation started. BulkEmailId {0}.", bulkEmailId);
			_segmentationRetryContext[BulkEmailIdPropertyName] = bulkEmailId;
			_segmentationPolicy.Execute(
				() => ResolveRecipientsReplica(bulkEmailId, (int)_segmentationRetryContext[BatchSizePropertyName]),
				_segmentationRetryContext);
			MailingUtilities.Log.InfoFormat(
				"[AudienceSegmentationMailingState.Segmentation]: " +
				"Audience segmentation Finished. BulkEmailId {0}.", bulkEmailId);
			return new MailingStateExecutionResult(this.GetType()) {
				Success = true,
				Status = MailingStateExecutionStatus.Done
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes the instance.
		/// </summary>
		public override void Initialize() {
			base.Initialize();
			DCStrategyResolver = new DCStrategyResolver(Context.UserConnection);
			DCTemplateRepository = new DCTemplateRepository<DCTemplateModel>(Context.UserConnection);
		}

		#endregion

	}

	#endregion

}

