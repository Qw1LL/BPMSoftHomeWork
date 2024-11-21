namespace BPMSoft.Configuration.Mailing
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.DynamicContent;

	#region Class: CESMailingTemplateFactory

	/// <summary>
	/// Provides methods for creating instancies of the <see cref="IMailingTemplate"/>.
	/// </summary>
	public class CESMailingTemplateFactory
	{

		#region Methods: Public

		/// <summary>
		/// Creates instance of <see cref="DCTemplateRepository&lt;DCTemplateModel&gt;"/>.
		/// </summary>
		/// <param name="userConnection"></param>
		/// <returns></returns>
		public virtual DCTemplateRepository<DCTemplateModel> CreateDcTemplateRepository(UserConnection userConnection) {
			var templateRepository = new DCTemplateRepository<DCTemplateModel>(userConnection);
			return templateRepository;
		}

		/// <summary>
		/// Creates instance of the <see cref="IMailingTemplate"/> for every replica of dynamic content.
		/// </summary>
		/// <param name="userConnection">Instance of the user connection.</param>
		/// <param name="bulkEmail">Instance of the bulk email.</param>
		/// <param name="macroParser">Instance of the <see cref="BulkEmailMacroParser"/>.</param>
		/// <returns>Returns instance of the <see cref="IMailingTemplate"/>.</returns>
		public IEnumerable<IMailingTemplate> CreateDCTemplates(UserConnection userConnection, BulkEmail bulkEmail,
			BulkEmailMacroParser macroParser) {
			var templateRepository = CreateDcTemplateRepository(userConnection);
			var templateReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.None
			};
			var template = templateRepository.ReadByRecordId(bulkEmail.Id, templateReadOptions);
			if (template == null) {
				return null;
			}
			return CreateInstances(userConnection, bulkEmail, template.Replicas, macroParser);
		}

		/// <summary>
		/// Creates instance of the <see cref="IMailingTemplate"/>.
		/// </summary>
		/// <param name="userConnection">Instance of the user connection.</param>
		/// <param name="bulkEmail">Instance of the bulk email.</param>
		/// <param name="macroParser">Instance of the macros parser.</param>
		/// <returns>Returns instance of the <see cref="IMailingTemplate"/>.</returns>
		public virtual IMailingTemplate CreateInstance(UserConnection userConnection, BulkEmail bulkEmail,
			BulkEmailMacroParser macroParser) {
			return new CESMailingTemplate(userConnection, bulkEmail, macroParser);
		}

		/// <summary>
		/// Creates instance of the <see cref="IMailingTemplate"/> for given replicas of dynamic content.
		/// </summary>
		/// <param name="userConnection">Instance of the user connection.</param>
		/// <param name="bulkEmail">Instance of the bulk email.</param>
		/// <param name="replicas">Replicas collection.</param>
		/// <param name="macroParser">Instance of the <see cref="BulkEmailMacroParser"/>.</param>
		/// <returns>Returns instance of the <see cref="IMailingTemplate"/>.</returns>
		public virtual IEnumerable<IMailingTemplate> CreateInstances(UserConnection userConnection, BulkEmail bulkEmail,
			IEnumerable<DCReplicaModel> replicas, BulkEmailMacroParser macroParser = null) {
			var templateReplicas = new List<IMailingTemplate>();
			foreach (var replica in replicas) {
				var templateFromReplica = new CESMailingTemplate(userConnection, bulkEmail, macroParser);
				templateFromReplica.Content = replica.Content;
				templateFromReplica.ReplicaId = replica.Id;
				templateFromReplica.Init();
				templateReplicas.Add(templateFromReplica);
			}
			return templateReplicas;
		}

		#endregion

	}

	#endregion

}

