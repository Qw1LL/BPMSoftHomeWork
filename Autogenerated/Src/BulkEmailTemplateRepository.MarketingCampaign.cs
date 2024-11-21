namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.DynamicContent;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using Newtonsoft.Json.Linq;

	#region Class: BulkEmailTemplateRepository

	public class BulkEmailTemplateRepository
	{

		#region Fields: Private

		private DCTemplateRepository<DCTemplateModel> _templateRepository;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of the class.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		public BulkEmailTemplateRepository(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// User connection instance.
		/// </summary>
		private UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		public virtual DCTemplateRepository<DCTemplateModel> DCTemplateRepository {
			get =>
				_templateRepository ?? (_templateRepository =
					new DCTemplateRepository<DCTemplateModel>(UserConnection));
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns template model by email identifier.
		/// </summary>
		/// <param name="bulkEmailId">Email identifier.</param>
		/// <returns>Replica model.</returns>
		private DCTemplateModel GetDcTemplateModel(Guid bulkEmailId) {
			var repositoryOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.ExcludeReplicaHtmlContent
			};
			return DCTemplateRepository.ReadByRecordId(bulkEmailId, repositoryOptions);
		}

		/// <summary>
		/// Returns replica recipient count select.
		/// </summary>
		/// <param name="replicaIds">Replicas ids array.</param>
		/// <returns>Returns <see cref="Select"/> Select.</returns>
		private Select GetBulkEmailRecipientReplicaCountSelect(Guid[] replicaIds) {
			var select = new Select(UserConnection)
				.Column("DCReplicaId")
				.Column(Func.Count("Id")).As("RecipientCount")
				.From("BulkEmailRecipientReplica")
				.Where("DCReplicaId").In(Column.Parameters(replicaIds))
				.GroupBy("DCReplicaId") as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		private void DeleteBulkEmailReplicaHeaders(Guid bulkEmailId) {
			var delete = new Delete(UserConnection)
				.From(nameof(BulkEmailReplicaHeaders))
				.Where(nameof(BulkEmailReplicaHeaders.BulkEmailId)).IsEqual(Column.Parameter(bulkEmailId));
			delete.Execute();
		}

		private void InsertHeaders(Guid bulkEmailId, ReplicaHeaderModel headers) {
			var replicaMask = headers.ReplicaMask;
			var replicaIdsubSelect = CreateReplicaIdSelect(bulkEmailId, replicaMask);
			new Insert(UserConnection).Into(nameof(BulkEmailReplicaHeaders))
				.Set(nameof(BulkEmailReplicaHeaders.BulkEmailId), Column.Parameter(bulkEmailId))
				.Set(nameof(BulkEmailReplicaHeaders.DCReplicaId), replicaIdsubSelect)
				.Set(nameof(BulkEmailReplicaHeaders.SenderEmail), Column.Parameter(headers.SenderEmail))
				.Set(nameof(BulkEmailReplicaHeaders.SenderName), Column.Parameter(headers.SenderName))
				.Set(nameof(BulkEmailReplicaHeaders.Subject), Column.Parameter(headers.Subject))
				.Set(nameof(BulkEmailReplicaHeaders.Preheader), Column.Parameter(headers.Preheader ?? string.Empty))
				.Execute();
		}

		private Select CreateReplicaIdSelect(Guid bulkEmailId, int replicaMask) {
			var replicaIdsubSelect = new Select(UserConnection)
				.Column(nameof(DCReplica), nameof(DCReplica.Id))
				.From(nameof(DCReplica))
				.InnerJoin(nameof(DCTemplate))
					.On(nameof(DCReplica.DCTemplateId))
					.IsEqual(nameof(DCTemplate), nameof(DCTemplate.Id))
				.Where(nameof(DCTemplate.RecordId)).IsEqual(Column.Parameter(bulkEmailId))
				.And(nameof(DCReplica.Mask)).IsEqual(Column.Parameter(replicaMask)) as Select;
			return replicaIdsubSelect;
		}

		/// <summary>
		/// Returns preheader from bulk email template config.
		/// </summary>
		/// <param name="templateConfig">Email template config.</param>
		/// <returns>Replica model.</returns>
		private string GetTemplatePreHeader(string templateConfig) {
			if (string.IsNullOrEmpty(templateConfig)) {
				return null;
			}
			var templateJson = JObject.Parse(templateConfig);
			return templateJson["PreHeaderText"]?.Value<string>();
		}

		private Select GetBulkEmailReplicaHeadersSelect(Guid sourceBulkEmailId, Guid targetBulkEmailId) {
			var select = new Select(UserConnection)
				.Column("trgTemplate", "RecordId")
				.Column("trgReplica", "Id")
				.Column("headers", "Subject")
				.Column("headers", "Preheader")
				.Column("headers", "SenderName")
				.Column("headers", "SenderEmail")
				.From("DCTemplate").As("srcTemplate")
				.InnerJoin("DCTemplate").As("trgTemplate").On("trgTemplate", "RecordId")
					.IsEqual(Column.Parameter(targetBulkEmailId))
				.InnerJoin("DCReplica").As("srcReplica").On("srcTemplate", "Id").IsEqual("srcReplica", "DCTemplateId")
				.InnerJoin("DCReplica").As("trgReplica").On("trgTemplate", "Id").IsEqual("trgReplica", "DCTemplateId")
					.And("trgReplica", "Mask").IsEqual("srcReplica", "Mask")
				.InnerJoin("BulkEmailReplicaHeaders").As("headers").On("headers", "DCReplicaId").IsEqual("srcReplica", "Id")
				.Where("srcTemplate", "RecordId").IsEqual(Column.Parameter(sourceBulkEmailId))
				as Select;
			select.SpecifyNoLockHints(true);
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns identifiers of sent replicas of email.
		/// </summary>
		/// <param name="bulkEmailId">Email identifier.</param>
		/// <returns>Replica identifiers array.</returns>
		public Guid[] GetSentDcReplicaIds(Guid bulkEmailId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				"BulkEmailRecipientReplica");
			esq.IsDistinct = true;
			var replicaColumn = esq.AddColumn("DCReplica.Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"DCReplica.DCTemplate.RecordId", bulkEmailId));
			var sentDCReplicaCollection = esq.GetEntityCollection(UserConnection);
			return sentDCReplicaCollection.Select(s => s.GetTypedColumnValue<Guid>(replicaColumn.Name)).ToArray();
		}

		/// <summary>
		/// Receives all replicas of email template.
		/// </summary>
		/// <param name="bulkEmailId">Email identifier.</param>
		/// <returns>Array of replica models.</returns>
		public virtual DCReplicaModel[] GetDcReplicas(Guid bulkEmailId) {
			var model = GetDcTemplateModel(bulkEmailId);
			if (model?.Replicas == null) {
				return new DCReplicaModel[0];
			}
			return model.Replicas.ToArray();
		}

		/// <summary>
		/// Counts the number of recipients for each template replica.
		/// </summary>
		/// <param name="replicaIds">Array of replica identifiers.</param>
		/// <returns>Dictionary with numbers of recipients for each replica.</returns>
		public Dictionary<Guid, int> GetBulkEmailRecipientReplicaCount(Guid[] replicaIds) {
			var replicaCountSelect = GetBulkEmailRecipientReplicaCountSelect(replicaIds);
			var countDictionary = new Dictionary<Guid, int>();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				replicaCountSelect.ExecuteReader(reader => {
					countDictionary.Add(reader.GetColumnValue<Guid>("DCReplicaId"),
						reader.GetColumnValue<int>("RecipientCount"));
				});
			}
			return countDictionary;
		}

		/// <summary>
		/// Saves the replica headers.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="replicaHeaders">The replica headers.</param>
		public void SaveHeaders(Guid bulkEmailId, IEnumerable<ReplicaHeaderModel> replicaHeaders) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					DeleteBulkEmailReplicaHeaders(bulkEmailId);
					foreach (var headers in replicaHeaders) {
						InsertHeaders(bulkEmailId, headers);
					}
					dbExecutor.CommitTransaction();
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		/// <summary>
		/// Gets the replica headers.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <returns></returns>
		public IEnumerable<ReplicaHeaderModel> GetHeaders(Guid bulkEmailId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, nameof(BulkEmailReplicaHeaders));
			esq.UseAdminRights = false;
			esq.IgnoreDisplayValues = true;
			var maskColumn = esq.AddColumn("DCReplica.Mask");
			var subjectColumn = esq.AddColumn("Subject");
			var preheaderColumn = esq.AddColumn("Preheader");
			var senderEmailColumn = esq.AddColumn("SenderEmail");
			var senderNameColumn = esq.AddColumn("SenderName");
			var replicaIdColumn = esq.AddColumn("DCReplica.Id");
			var entitySchemaQueryFilterItem =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "BulkEmail", bulkEmailId);
			esq.Filters.Add(entitySchemaQueryFilterItem);
			var entityCollection = esq.GetEntityCollection(UserConnection);
			return entityCollection.Select(x => new ReplicaHeaderModel {
				Subject = x.GetTypedColumnValue<string>(subjectColumn.Name),
				Preheader = x.GetTypedColumnValue<string>(preheaderColumn.Name),
				SenderEmail = x.GetTypedColumnValue<string>(senderEmailColumn.Name),
				ReplicaMask = x.GetTypedColumnValue<int>(maskColumn.Name),
				SenderName = x.GetTypedColumnValue<string>(senderNameColumn.Name),
				ReplicaId = x.GetTypedColumnValue<Guid>(replicaIdColumn.Name)
			});
		}

		/// <summary>
		/// Gets the default headers from BulkEmail.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <returns></returns>
		public EmailHeaderModel GetDefaultHeaders(Guid bulkEmailId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, nameof(BulkEmail)) {
				UseAdminRights = false,
				IgnoreDisplayValues = true
			};
			var subjectColumn = esq.AddColumn("TemplateSubject");
			var templateConfig = esq.AddColumn("TemplateConfig");
			var senderEmailColumn = esq.AddColumn("SenderEmail");
			var senderNameColumn = esq.AddColumn("SenderName");
			var entityItem = esq.GetEntity(UserConnection, bulkEmailId);
			return new EmailHeaderModel {
				Subject = entityItem?.GetTypedColumnValue<string>(subjectColumn.Name),
				Preheader = GetTemplatePreHeader(entityItem?.GetTypedColumnValue<string>(templateConfig.Name)),
				SenderEmail = entityItem?.GetTypedColumnValue<string>(senderEmailColumn.Name),
				SenderName = entityItem?.GetTypedColumnValue<string>(senderNameColumn.Name)
			};
		}

		public void CopyBulkEmailReplicaHeaders(Guid sourceBulkEmailId, Guid targetBulkEmailId) {
			Select select = GetBulkEmailReplicaHeadersSelect(sourceBulkEmailId, targetBulkEmailId);
			var insert = new InsertSelect(UserConnection).Into("BulkEmailReplicaHeaders")
				.Set("BulkEmailId", "DCReplicaId", "Subject", "Preheader", "SenderName", "SenderEmail")
				.FromSelect(select);
			insert.Execute();
		}

		#endregion

	}

	#endregion

	#region Class: ReplicaHeaderModel

	/// <summary>
	/// Represents DTO of headers for the bulk email template replica.
	/// </summary>
	public class ReplicaHeaderModel : EmailHeaderModel
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the replica mask.
		/// </summary>
		public int ReplicaMask { get; set; }

		/// <summary>
		/// Gets or sets the replica identifier.
		/// </summary>
		public Guid ReplicaId { get; set; }

		#endregion

	}

	#endregion

	#region Class: ReplicaHeaderModel

	/// <summary>
	/// Represents DTO of headers for the bulk email template.
	/// </summary>
	public class EmailHeaderModel
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets sender name.
		/// </summary>
		public string SenderName { get; set; }

		/// <summary>
		/// Gets or sets sender email.
		/// </summary>
		public string SenderEmail { get; set; }

		/// <summary>
		/// Gets or sets the email subject.
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// Gets or sets the email preheader.
		/// </summary>
		public string Preheader { get; set; }

		#endregion

	}

	#endregion

}

