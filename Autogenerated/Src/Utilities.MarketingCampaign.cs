namespace BPMSoft.Configuration.Marketing.Utilities
{
	using System;
	using System.Text;
	using System.Threading;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: InsertBuilder

	/// <summary>
	/// Represents multiple row insert query builder class.
	/// </summary>
	public class InsertBuilder
	{
		#region Constants: Private

		const int MultiplyInsertRowsLimit = 1000;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly StringBuilder _queryBuilder = new StringBuilder();

		private readonly string _initializationString = string.Empty;

		private readonly string _valuesFormatString = string.Empty;

		private int _counter;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Inits new instance of the class.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="initValue">Initial string of query.</param>
		/// <param name="valuesFormatString">Template for input parameters.</param>
		[Obsolete("This method is obsolete. Use InsertSelect instead.")]
		public InsertBuilder(UserConnection userConnection, string initValue, string valuesFormatString) {
			_userConnection = userConnection;
			_initializationString = initValue;
			_valuesFormatString = valuesFormatString;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes insert of rows to put.
		/// </summary>
		public void ExecuteInsert() {
			if (_counter > 0) {
				CustomQuery query = new CustomQuery(_userConnection, _queryBuilder.ToString());
				query.Execute();
				_counter = 0;
				_queryBuilder.Clear();
			}
		}

		/// <summary>
		/// Adds row with current parameters.
		/// </summary>
		/// <param name="parameters">Parameters of the row.</param>
		public void InsertRow(params object[] parameters) {
			if (_counter == 0) {
				_queryBuilder.Append(_initializationString);
			} else {
				_queryBuilder.Append(" UNION ALL ");
			}
			_counter++;
			_queryBuilder.AppendFormat(_valuesFormatString, parameters);
			if (_counter == MultiplyInsertRowsLimit) {
				ExecuteInsert();
			}
		}

		/// <summary>
		/// Returns SQL query.
		/// </summary>
		/// <returns>SQL query row.</returns>
		public string GetQueryString() {
			string query = _queryBuilder.ToString();
			return String.IsNullOrEmpty(query) ? string.Empty : query + ";";
		}
		#endregion
	}

	#endregion

	#region Class: Utilities

	/// <summary>
	/// Contains utility methods of package MarketingCampaign.
	/// </summary>
	public static class Utilities
	{

		#region Methods: Public

		/// <summary>
		/// Makes call of input function while correct execution of function will be happend
		/// or number of exceptions will be over head.
		/// </summary>
		/// <param name="function">Function to execute.</param>
		/// <param name="attemptsCount">Number of attemption to execute function.</param>
		/// <param name="timeout">Time out when try to execute function.</param>
		/// <param name="result">Input function execution result.</param>
		/// <returns>Function execution result.</returns>
		public static bool TryExecute<T>(Func<T> function, int attemptsCount, int timeout, out object result) {
			for (int i = 1; i <= attemptsCount; i++) {
				try {
					result = function();
					return true;
				} catch {
					if (i < attemptsCount) {
						Thread.Sleep(timeout);
					}
				}
			}
			result = null;
			return false;
		}

		// <summary>
		/// Makes call of input function while correct execution of function will be happened
		/// or wait 120 seconds will be exceeded.
		/// </summary>
		/// <param name="func">Function to execute.</param>
		public static T RetryOnFailure<T>(Func<T> func) {
			return RetryOnFailure(func, 120, 10);
		}

		// <summary>
		/// Makes call of input function while correct execution of function will be happened
		/// or time to wait will be exceeded.
		/// </summary>
		/// <param name="func">Function to execute.</param>
		/// <param name="waitTimeSeconds">Number of Seconds for trying.</param>
		/// <param name="sleepSeconds">Time in seconds for delay between iteration.</param>
		public static T RetryOnFailure<T>(Func<T> func, int waitTimeSeconds, int sleepSeconds) {
			var stopwatch = new Stopwatch();
			TimeSpan waitTimeSpan = TimeSpan.FromSeconds(waitTimeSeconds);
			stopwatch.Start();
			while (true) {
				try {
					return func();
				} catch {
					Thread.Sleep(TimeSpan.FromSeconds(sleepSeconds));
					if (stopwatch.Elapsed > waitTimeSpan) {
						throw;
					}
				}
			}
		}

		/// <summary>
		/// Returns SUMM of counter values.
		/// </summary>
		/// <param name="counters">Counter collection <see cref="Marketing.Utilities.TypedCounter"/>.</param>
		/// <param name="counterName">Name of the counter.</param>
		/// <returns>Counter values SUMM.</returns>
		public static int Sum<T>(this IEnumerable<TypedCounter<T>> counters, string counterName) {
			int sum = 0;
			foreach (TypedCounter<T> counter in counters) {
				sum += counter.Get(counterName);
			}
			return sum;
		}

		/// <summary>
		/// Removes table from DB or makes it empty if is needed.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="truncateData">Truncate table if this is needed.</param>
		public static void DropTable(string tableName, UserConnection userConnection, bool truncateData) {
			var sp = new StoredProcedure(userConnection, "tsp_DropOrTruncateTable");
			sp.WithParameter("tableName", tableName);
			sp.WithParameter("isTruncate", truncateData ? 1 : 0);
			sp.Execute();
		}

		/// <summary>
		/// Removes table from DB.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="userConnection">User connection instance.</param>
		public static void DropTable(string tableName, UserConnection userConnection) {
			DropTable(tableName, userConnection, false);
		}

		/// <summary>
		/// Converts DateTime to unix timestamp.
		/// </summary>
		/// <param name="dateTime">Time to convert</param>
		/// <returns>Time at unix timestamp format.</returns>
		public static int ConvertDateTimeToTimestamp(DateTime dateTime) {
			return (int)(dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}

		/// <summary>
		/// Converts unix timestamp to DateTime.
		/// </summary>
		/// <param name="timestamp">Time at unix timestamp format.</param>
		/// <returns>Date time.</returns>
		public static DateTime ConvertTimestampToDateTime(int timestamp) {
			return new DateTime(1970, 1, 1).AddSeconds(timestamp);
		}

		#endregion

	}

	#endregion

	#region Class: TypedCounter

	/// <summary>
	/// Represents typed counter class.
	/// </summary>
	public class TypedCounter<T>
	{

		#region Class: Internal

		internal class InnerCounter
		{

			public InnerCounter(params T[] args) {
				_assignedTypes = args;
			}

			private readonly IEnumerable<T> _assignedTypes;

			private int _value;

			public int Value {
				get {
					return _value;
				}
			}

			public void Count(T arg) {
				if (_assignedTypes.Contains(arg)) {
					_value++;
				}
			}
		}

		#endregion

		#region Fields: Private

		private readonly Dictionary<string, InnerCounter> _counters;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new class instance.
		/// </summary>
		public TypedCounter() {
			_counters = new Dictionary<string, InnerCounter>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Registeres new Counter.
		/// If counter with the same has been already existed
		/// it would be replaced with the new one.
		/// </summary>
		/// <param name="name">Counter name.</param>
		/// <param name="args">Accotiative counter values.</param>
		public void Register(string name, params T[] args) {
			_counters[name] = new InnerCounter(args);
		}

		/// <summary>
		/// Makes increment for counters which accotiative values are connected with the input value.
		/// </summary>
		/// <param name="arg">Value.</param>
		public void Count(T arg) {
			foreach (InnerCounter counter in _counters.Values) {
				counter.Count(arg);
			}
		}

		/// <summary>
		/// Returns counter's value.
		/// </summary>
		/// <param name="name">Counter name.</param>
		/// <returns>Counter value.</returns>
		public int Get(string name) {
			return _counters[name].Value;
		}

		/// <summary>
		/// Crears inner counters of class instance.
		/// </summary>
		public void Clear() {
			_counters.Clear();
		}

		#endregion

	}

	#endregion

}
