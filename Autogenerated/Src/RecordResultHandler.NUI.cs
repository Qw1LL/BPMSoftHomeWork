namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Messaging.Common;
	using Newtonsoft.Json;

	#region Class: RecordResultHandler

	public class RecordResultHandler : IRecordResultHandler, IRecordProcessedHandler {

		#region Class: Message

		[Serializable]
		[JsonObject(MemberSerialization.OptIn)]
		protected class Message {

			#region Fields: Private

			private int _total;
			private int _processed;
			private int _skipped;
			private Guid _operationKey;

			#endregion

			#region Constructors: Public

			public Message() {
			}

			public Message(int total, int processed, int skipped, Guid operationKey) {
				_total = total;
				_processed = processed;
				_skipped = skipped;
				_operationKey = operationKey;
			}

			#endregion

			#region Properties: Public

			[JsonProperty(PropertyName = "total")]
			public int Total {
				get { return _total; }
				set { _total = value; }
			}

			[JsonProperty(PropertyName = "processed")]
			public int Processed {
				get { return _processed; }
				set { _processed = value; }
			}

			[JsonProperty(PropertyName = "skipped")]
			public int Skipped {
				get { return _skipped; }
				set { _skipped = value; }
			}

			[JsonProperty(PropertyName = "operationKey")]
			public Guid OperationKey {
				get { return _operationKey; }
				set { _operationKey = value; }
			}

			public override string ToString() {
				return JsonConvert.SerializeObject(this);
			}

			#endregion

		}

		#endregion

		#region Constants: Private

		private const string SENDER = "MultiDelete";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IDictionary<string, object> _parameters;
		private readonly Guid _operationKey;
		private readonly object _locker = new object();

		#endregion

		#region Constructors: Public

		public RecordResultHandler(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			_parameters = parameters;
			_operationKey = (Guid)_parameters["OperationKey"];
		}

		#endregion

		#region Properties: Protected

		private int _total;
		protected int Total {
			get {
				if (_total.Equals(default(int))) {
					_total = GetRecordIdsCount();
				}
				return _total;
			}
		}

		protected int Processed { get; private set; }

		protected int Skipped { get; private set; }

		#endregion

		#region Methods: Private

		private int GetRecordIdsCount() {
			var dependentRecordsCount = 0;
			var recordIds = (IEnumerable<Guid>)_parameters["RecordIds"];
			if (_parameters.ContainsKey("DependentRecordsCount")) {
				dependentRecordsCount = (int)_parameters["DependentRecordsCount"];
			}
			return recordIds.Count() + dependentRecordsCount;
		}

		#endregion

		#region Methods: Prodected

		protected virtual string GetBodyMessage() {
			var message = new Message(Total, Processed, Skipped, _operationKey);
			return message.ToString();
		}

		protected virtual void PostMessage(string sender, string body) {
			Guid sysAdminUnit = _userConnection.CurrentUser.Id;
			IMsgChannel channel = MsgChannelManager.Instance.FindItemByUId(sysAdminUnit);
			if (channel == null) {
				return;
			}
			var simpleMessage = new SimpleMessage() {
				Id = sysAdminUnit,
				Body = body,
			};
			simpleMessage.Header.Sender = sender;
			channel.PostMessage(simpleMessage);
		}

		#endregion

		#region Methods: Public

		public virtual void RecordProcessed() {
			var body = GetBodyMessage();
			PostMessage(SENDER, body);
		}

		public virtual void HandleRecordProcessed(object sender, RecordProcessedEventArgs args) {
			lock (_locker) {
				Processed++;
				if (args.Exception != null) {
					Skipped++;
				}
				if (args.RecordId.Equals(default(Guid))) {
					Processed = Total;
				}
				RecordProcessed();
			}
		}

		#endregion

	}

	#endregion

}


