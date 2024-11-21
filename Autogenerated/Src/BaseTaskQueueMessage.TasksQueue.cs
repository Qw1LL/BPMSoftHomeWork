namespace BPMSoft.Configuration
{
	using Newtonsoft.Json;
	using System;
	using BPMSoft.Common.Json;

	#region Class: BaseTaskQueueMessage

	/// <summary>
	/// Base message for queue.
	/// </summary>
	public abstract class BaseTaskQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BaseTaskQueueMessage"/>.
		/// </summary>
		public BaseTaskQueueMessage() {
			Id = Guid.NewGuid();
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id message.
		/// </summary>
		[JsonIgnore]
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Number of retries to process message in case of crash or error.
		/// </summary>
		private int _maxRetryCount = int.MinValue;
		[JsonIgnore]
		public int MaxRetryCount {
			get => _maxRetryCount == int.MinValue
					? (_maxRetryCount = GetMaxRetryCount())
					: _maxRetryCount;
			set {
				_maxRetryCount = value;
			}
		}

		/// <summary>
		/// Id of current user.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Guid UserId { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Stringifies <see cref="EventQueueMessage"/> DTO.
		/// </summary>
		/// <returns>String in JSON format.</returns>
		public override string ToString() => Json.Serialize(this, true, TypeNameHandling.All);

		/// <summary>
		/// Defines number of retries in case of crash or error.
		/// </summary>
		/// <returns>Number of retries.</returns>
		public virtual int GetMaxRetryCount() => 1;

		/// <summary>
		/// Defines priority of current message. Messages with highest priority will be processed first.
		/// </summary>
		public virtual int GetPriority() => 0;

		/// <summary>
		/// Returns int representation of message type.
		/// </summary>
		/// <returns>Message type</returns>
		public abstract int GetMessageType();

		#endregion

	}

	#endregion

}

