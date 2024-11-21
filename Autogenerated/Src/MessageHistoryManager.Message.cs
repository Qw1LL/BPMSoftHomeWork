using System;
using System.Collections.Generic;
using System.Data;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.DB;

namespace BPMSoft.Configuration
{

	#region Class: MessageHistoryManager

	public class MessageHistoryManager
	{
		
		#region Fields: Private

		private readonly IMessageNotifier _notifier;
		private readonly List<string> _listeners;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructor: Public

		public MessageHistoryManager(UserConnection userConnection, IMessageNotifier notifier) {
			_userConnection = userConnection;
			_notifier = notifier;
			_listeners = GetListeners();
		}

		#endregion

		#region Methods: Private

		private object GetInstance(string listener) {
			Type type = Type.GetType(listener);
			return type != null ? Activator.CreateInstance(type, _userConnection) : null;
		}

		private IEnumerable<IMessageListener> InstantiateListeners() {
			var list = new List<IMessageListener>();
			foreach (var listener in _listeners) {
				var instance = (IMessageListener)GetInstance(listener);
				if (instance != null) {
					list.Add(instance);
				}
			}
			return list;
		}

		private List<string> GetListeners() {
			var result = new List<string>();
			var select = new Select(_userConnection)
				.Column("ML", "ClassName")
				.From("ListenerByNotifier").As("LN")
				.LeftOuterJoin("MessageListener").As("ML").On("ML", "Id").IsEqual("LN", "MessageListenerId")
				.LeftOuterJoin("MessageNotifier").As("MN").On("MN", "Id").IsEqual("LN", "MessageNotifierId")
				.Where("MN", "SchemaUId").IsEqual(new QueryParameter(_notifier.MessageInfo.SchemaUId))
				.And()
					.OpenBlock("ML", "ClassName").IsNotEqual(Column.Parameter(string.Empty))
						.Or("ML", "ClassName").Not().IsNull()
					.CloseBlock() as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						result.Add(dataReader.GetColumnValue<string>("ClassName"));
					}
				}
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public void Notify() {
			foreach (var listener in InstantiateListeners()) {
				_notifier.Subscribe(listener);
			}
			_notifier.Notify();
		}

		#endregion

	}

	#endregion

}
