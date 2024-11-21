namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: MailingContext

	/// <summary>
	/// Class of sending context for bulk email.
	/// </summary>
	public class MailingContext
	{

		#region Fields: Private

		private MailingState _state;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MailingContext"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="bulkEmailEntity">The bulk email entity.</param>
		public MailingContext(UserConnection userConnection, Entity bulkEmailEntity) {
			UserConnection = userConnection;
			BulkEmailEntity = bulkEmailEntity;
		}

		#endregion

		#region Properties: Public
		
		public DateTime StartedOn { get; set; }

		/// <summary>
		/// Gets the bulk email entity being launched. 
		/// </summary>
		public Entity BulkEmailEntity { get; }

		/// <summary>
		/// Gets or sets the session identifier.
		/// </summary>
		public Guid SessionId { get; set; }

		/// <summary>
		/// Gets the user connection.
		/// </summary>
		public UserConnection UserConnection { get; }

		public IEnumerable<IMailingTemplate> MailingTemplates { get; set; }

		/// <summary>
		/// Gets or sets the CES service API.
		/// </summary>
		public ICESApi ServiceApi { get; set; }

		/// <summary>
		/// Gets or sets schema name of linked entoty for extended macros.
		/// </summary>
		public string LinkedEntitySchemaName { get; set; }

		/// <summary>
		/// Gets or sets number of the iteration for sending recipients.
		/// </summary>
		public int BatchNumber { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Changes the state of context.
		/// </summary>
		/// <param name="state">The state.</param>
		public void ChangeState(MailingState state) {
			_state = state;
			_state.Context = this;
			_state.Initialize();
		}

		/// <summary>
		/// Executes current state of context.
		/// </summary>
		/// <returns></returns>
		public MailingStateExecutionResult Execute() {
			try {
				return _state.Handle();
			} catch (Exception e) {
				return new MailingStateExecutionResult(_state.GetType()) {
					Success = false,
					Status = MailingStateExecutionStatus.Failed,
					Exception = e
				};
			}
		}

		#endregion

	}

	#endregion

}

