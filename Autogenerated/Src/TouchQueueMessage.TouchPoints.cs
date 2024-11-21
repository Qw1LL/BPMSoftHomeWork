namespace BPMSoft.Configuration
{
	using System;
	using System.Security.Cryptography;
	using System.Text;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;

	#region Enum: TouchQueueMessageType

	/// <summary>
	/// Defines what action exactly contains touch queue message.
	/// </summary>
	public enum TouchQueueMessageType
	{
		Default = 0,
		Import = 1,
		Sync = 2,
		Clear = 3
	}

	#endregion

	#region Class: TouchQueueMessage

	/// <summary>
	/// Base DTO for message of <see cref="TouchQueue"/>.
	/// </summary>
	public class TouchQueueMessage : BaseTaskQueueMessage
	{

		#region Properties: Public

		/// <summary>
		/// Message type defines what exactly contains queue message.
		/// </summary>
		public TouchQueueMessageType Type { get; set; } = TouchQueueMessageType.Default;

		/// <summary>
		/// Flag to indicate queue deduplication necessity.
		/// </summary>
		public bool RequiresDeduplication { get; set; } = false;

		#endregion

		#region Methods: Private

		private string GetStringFromHash(byte[] hash) {
			var builder = new StringBuilder();
			for (int i = 0; i < hash.Length; i++) {
				builder.Append(hash[i].ToString("X2"));
			}
			return builder.ToString();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates message instance from JSON with specified retries count.
		/// </summary>
		///<param name="messageId">Message identifier.</param>
		/// <param name="json">String representation of message.</param>
		/// <param name="retriesCount">Number of retries to process message in case of crash or error.</param>
		/// <returns>Instance of <see cref="TouchQueueMessage"/> class.</returns>
		/// <exception cref="ArgumentNullOrEmptyException">In case of empty JSON.</exception>
		public static TouchQueueMessage Create(Guid messageId, string json, int retriesCount) {
			json.CheckArgumentNullOrEmpty(nameof(json));
			var result = Json.Deserialize<TouchQueueMessage>(json, new JsonSerializerSettings {
				TypeNameHandling = TypeNameHandling.All
			});
			result.Id = messageId;
			result.MaxRetryCount = retriesCount;
			return result;
		}

		/// <summary>
		/// Creates message instance from JSON.
		/// </summary>
		///<param name="messageId">Message identifier.</param>
		/// <param name="json">String representation of message.</param>
		/// <returns>Instance of <see cref="TouchQueueMessage"/> class.</returns>
		/// <exception cref="ArgumentNullOrEmptyException">In case of empty JSON.</exception>
		public static TouchQueueMessage Create(Guid messageId, string json) => Create(messageId, json, 1);

		/// <inheritdoc />
		public override int GetMessageType() => (int)Type;

		/// <summary>
		/// Returns identifier of tracking system <see cref="TouchEventTracking"/>.
		/// </summary>
		/// <returns>Identifier of Tracking system. <see cref="Guid.Empty"/> by default.</returns>
		public virtual Guid GetTracking() => Guid.Empty;

		/// <summary>
		/// Returns message type name.
		/// </summary>
		/// <returns>Type name.</returns>
		public virtual string GetTypeName() => GetType().FullName;

		/// <summary>
		/// Returns extended info about message parameters.
		/// </summary>
		/// <returns>Message description.</returns>
		public virtual string GetDescription() {
			return $"Type: {GetTypeName()}, Priority: {GetPriority()}, "
				+ $"RetryCount: {GetMaxRetryCount()}, Tracking: {GetTracking()}";
		}

		/// <summary>
		/// Returns hash of serialized message.
		/// </summary>
		/// <returns>Hash of the message.</returns>
		public string GetHash() {
			var json = ToString();
			byte[] hash;
			using (SHA512 shaManaged = new SHA512Managed()) {
				hash = shaManaged.ComputeHash(Encoding.Unicode.GetBytes(json));
			}
			return GetStringFromHash(hash);
		}

		#endregion

	}

	#endregion

}

