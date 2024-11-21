namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using Polly;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: BulkEmailMacroComposer

	/// <summary>
	/// Provides methods to build macros and its values for mailing recipients.
	/// </summary>
	public class BulkEmailMacroComposer : BaseBulkEmailMacroComposer
	{

		#region Constants: Private

		private const string BulkEmailIdPropertyName = "bulkEmailId";
		private const string ReplicaIdPropertyName = "replicaId";

		#endregion

		#region Fields: Private
		
		private static readonly int _retryCount = 3;
		private static readonly int _initialParallelExecutionThreadCount = Math.Min(Environment.ProcessorCount, 4);
		private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(_initialParallelExecutionThreadCount);
		private readonly BulkEmail _bulkEmail;
		private readonly string _linkedEntitySchemaName;
		private readonly Context _macroRetryContext;
		private readonly Policy _macroRetryPolicy;
		private readonly string _mandrillIdColumnName;
		private AudienceMacroDataSource _audienceDataSource;
		private MacroValuesDataSource _macroValuesDataSource;
		private readonly ISendingEmailProgressRepository _progressRepository;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of BaseBulkEmailMacroComposer class, to prepare global and personal macros.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="contactId">Unique identifier of the contact that will be used for 
		/// initializing collection of global macros.</param>
		/// <param name="bulkEmailId">Unique identifier of the bulk email that will be used for 
		/// initializing collection of global macros.</param>
		public BulkEmailMacroComposer(UserConnection userConnection, Guid contactId, Guid bulkEmailId)
			: base(userConnection, contactId, bulkEmailId) {
			_macroRetryPolicy = Policy.Handle<Exception>().Retry(_retryCount,
				(exception, retryIteration, context) => OnRetry(context, retryIteration, exception));
			_macroRetryContext = new Context("macroRetryPolicy");
			_mandrillIdColumnName = "MandrillId";
			_progressRepository = ClassFactory.Get<SendingEmailProgressRepository>(
				new ConstructorArgument("userConnection", UserConnection));
		}

		/// <summary>
		/// Creates instance of BulkEmailMacroComposer class, to prepare global and personal macroses.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="bulkEmail">Bulk email that will be used for initializing collection of global macros.</param>
		/// <param name="linkedEntitySchemaName">Name of the recipient linked entity.</param>
		public BulkEmailMacroComposer(UserConnection userConnection, BulkEmail bulkEmail, string linkedEntitySchemaName)
			: this(userConnection, bulkEmail.OwnerId, bulkEmail.Id) {
			_bulkEmail = bulkEmail;
			_linkedEntitySchemaName = linkedEntitySchemaName;
		}

		#endregion

		#region Properties: Public

		public MacroValuesDataSource MacroValuesDataSource {
			get => _macroValuesDataSource ?? (_macroValuesDataSource = InitMacroValuesDataSource());
			set => _macroValuesDataSource = value;
		}

		public AudienceMacroDataSource AudienceMacroDataSource {
			get =>
				_audienceDataSource ?? (_audienceDataSource =
					ClassFactory.Get<AudienceMacroDataSource>(new ConstructorArgument("userConnection", UserConnection))
				);
			set => _audienceDataSource = value;
		}

		#endregion

		#region Methods: Private

		private static void OnRetry(Context context, int retryIteration, Exception exception) {
			MailingUtilities.Log.WarnFormat(
				"[BulkEmailMacroComposer.PrepareMacros]: " +
				$"Error while PrepareMacros for replica {context[ReplicaIdPropertyName]} in bulkEmail {context[BulkEmailIdPropertyName]} " +
				$"on iteration {retryIteration - 1}. ", exception);
		}

		private Dictionary<Guid, IEnumerable<BulkEmailMacroInfo>> GetMacrosForRecipients(
			Dictionary<string, string> commonMacros, IEnumerable<MacrosInfo> macrosCollection,
			IEnumerable<RecipientMacroContract> recipients) {
			try {
				_semaphore.Wait();
				return MacroValuesDataSource.GetMacroValues(recipients, commonMacros, macrosCollection);
			} finally {
				_semaphore.Release();
			}
		}

		private IEnumerable<RecipientMacroContract> GetRecipients(Guid replicaId) {
			var audienceEntityCollection = AudienceMacroDataSource.GetAudience(_bulkEmail.Id, replicaId);
			return audienceEntityCollection.Select(x => new RecipientMacroContract {
				ContactId = x.GetTypedColumnValue<Guid>("ContactId"),
				LinkedEntityId = x.GetTypedColumnValue<Guid>("LinkedEntityId"),
				RecipientUId = x.GetTypedColumnValue<Guid>(_mandrillIdColumnName),
			});
		}

		private MacroValuesDataSource InitMacroValuesDataSource() {
			var macroValuesDataSource = ClassFactory.Get<MacroValuesDataSource>(
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("linkedEntitySchemaName", _linkedEntitySchemaName));
			macroValuesDataSource.MacrosHelper = MacrosHelper;
			macroValuesDataSource.TrackedAliases = TrackedAliases;
			return macroValuesDataSource;
		}

		private void InternalPrepareMacros(Guid replicaId, IEnumerable<MacrosInfo> macrosCollection, Func<bool> canHandleBatch) {
			if (_bulkEmail == null || !CanPrepareMacros(macrosCollection)) {
				return;
			}
			var commonMacros =
				MacroValuesDataSource.GetGlobalMacrosValues(BulkEmailId, GlobalMacrosContactId, macrosCollection);
			while (canHandleBatch() && GetRecipients(replicaId) is var recipients &&
				recipients.Any()) {
				var recipientMacrosValues = GetMacrosForRecipients(commonMacros, macrosCollection, recipients);
				RecipientMacroRepository.Save(BulkEmailId, recipientMacrosValues);
				_progressRepository.IncrementPreparedRecipients(BulkEmailId, 0);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns personal macros of the contact.
		/// </summary>
		/// <param name="contactId"></param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>The recipient macros collection.</returns>
		public override Dictionary<string, string> GetContactMacrosValues(Guid contactId,
			IEnumerable<MacrosInfo> macrosCollection) {
			if (_bulkEmail == null) {
				return base.GetContactMacrosValues(contactId, macrosCollection);
			}
			var contactMacros = macrosCollection.Where(m =>
				!m.IsGlobal && m.ParentId == MailingConsts.EmailTemplateMacrosParentContactId);
			var arguments = new Dictionary<Guid, object>();
			arguments.Add(Guid.Empty, new KeyValuePair<string, Guid>(_personalMacrosSchema, contactId));
			arguments.Add(MailingConsts.EmailTemplateMacrosParentContactId, contactId);
			return MacrosHelper.GetMacrosValues(contactMacros, arguments);
		}

		/// <summary>
		/// Returns personal macros of the linked entity.
		/// </summary>
		/// <param name="linkedEntityId"></param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <returns>The recipient macros collection.</returns>
		public virtual Dictionary<string, string> GetLinkedEntityMacrosValues(Guid linkedEntityId,
			IEnumerable<MacrosInfo> macrosCollection) {
			if (string.IsNullOrEmpty(_linkedEntitySchemaName)) {
				return new Dictionary<string, string>();
			}
			var linkedEntityMacros = macrosCollection.Where(m =>
				!m.IsGlobal && m.ParentId == MailingConsts.EmailTemplateMacrosParentEntityId);
			var arguments = new Dictionary<Guid, object>();
			arguments.Add(Guid.Empty, new KeyValuePair<string, Guid>(_linkedEntitySchemaName, linkedEntityId));
			arguments.Add(MailingConsts.EmailTemplateMacrosParentEntityId, linkedEntityId);
			return MacrosHelper.GetMacrosValues(linkedEntityMacros, arguments);
		}

		/// <summary>
		/// Prepares personal macros of the contacts.
		/// </summary>
		/// <param name="replicaId">Identifier of the template replica.</param>
		/// <param name="macrosCollection">Collection of macros.</param>
		/// <param name="canHandleBatch">Function that indicates if batch can be processed.</param>
		public virtual void PrepareMacros(Guid replicaId, IEnumerable<MacrosInfo> macrosCollection, Func<bool> canHandleBatch) {
			MailingUtilities.Log.InfoFormat("[BulkEmailMacroComposer.PrepareMacros]: " +
				$"PrepareMacros started. replicaId {replicaId} in bulkEmail {_bulkEmail?.Id}.");
			_macroRetryContext[ReplicaIdPropertyName] = replicaId;
			_macroRetryContext[BulkEmailIdPropertyName] = _bulkEmail?.Id;
			_macroRetryPolicy.Execute(() => InternalPrepareMacros(replicaId, macrosCollection, canHandleBatch), _macroRetryContext);
			MailingUtilities.Log.InfoFormat("[BulkEmailMacroComposer.PrepareMacros]: " +
				$"PrepareMacros Finished.  replicaId {replicaId} in bulkEmail {_bulkEmail?.Id}.");
		}

		public virtual void PrepareMacros(Guid replicaId, IEnumerable<MacrosInfo> macrosCollection) {
			PrepareMacros(replicaId, macrosCollection, () => true);
		}

		#endregion

	}

	#endregion

}

