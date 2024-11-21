namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Common;
	using global::Common.Logging;

	#region Class: MultiDeleteExecutor

	public class MultiDeleteExecutor : IJobExecutor
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("MultiDelete");

		#endregion

		#region Fields: Protected

		protected UserConnection UserConnection;
		protected IDictionary<string, object> Parameters;
		protected IRecordResultHandler ResultHandler;
		protected IDictionary<string, IOperationAgent> OperationAgents;
		protected IDictionary<string, IRecordsOperationWorker> OperationWorkers;
		protected ICollection<DependentInfo> DependentInfos = new List<DependentInfo>();

		#endregion

		#region Properties: Private

		private bool? _isCascade;
		private bool IsCascade {
			get {
				if (_isCascade == null) {
					if (Parameters.ContainsKey("IsCascade")) {
						_isCascade = Convert.ToBoolean(Parameters["IsCascade"]);
					}
				}
				return _isCascade != null && (bool)_isCascade;
			}
		}

		private IEnumerable<Guid> _recordIds;
		private IEnumerable<Guid> RecordIds {
			get {
				if (_recordIds == null) {
					if (Parameters.ContainsKey("RecordIds")) {
						_recordIds = (IEnumerable<Guid>)Parameters["RecordIds"];
					}
				}
				return _recordIds;
			}
		}

		private string _schemaName;
		public string SchemaName {
			get {
				if (_schemaName == null) {
					if (Parameters.ContainsKey("SchemaName")) {
						_schemaName = (string)Parameters["SchemaName"];
					}
				}
				return _schemaName;
			}
		}

		#endregion

		#region Methods: Private

		private void PreparedParameters(IDictionary<string, object> parameters) {
			var recordIds = (string[])parameters["RecordIds"];
			IEnumerable<Guid> parameterRecordIds = recordIds.Select(id => new Guid(id));
			IDictionary<string, object> preparedParameters =
				GetReplaceParameter("RecordIds", parameterRecordIds, parameters);
			Parameters = preparedParameters;
		}

		private T GetInstance<T>(ConstructorArgument[] arguments = null)
				where T : class {
			if (arguments == null) {
				arguments = new ConstructorArgument[0];
			}
			return ClassFactory.Get<T>(arguments);
		}

		private ConstructorArgument[] GetConstrustorArguments(IDictionary<string, object> parameters = null) {
			var result = new List<ConstructorArgument>() {
				new ConstructorArgument("userConnection", UserConnection)
			};
			if (parameters != null) {
				result.Add(new ConstructorArgument("parameters", parameters));
			}
			return result.ToArray();
		}

		private IDictionary<string, object> GetReplaceParameter(string name, object value, IDictionary<string, object> parameters = null) {
			var result = parameters == null
				? new Dictionary<string, object>(Parameters)
				: new Dictionary<string, object>(parameters);
			if (result.ContainsKey(name)) {
				result[name] = value;
			} else {
				result.Add(name, value);
			}
			return result;
		}

		private bool IsUnlink(IDictionary<string, object> parameters) {
			bool result = false;
			if (parameters != null && parameters.ContainsKey("IsUnlink")) {
				result = Convert.ToBoolean(parameters["IsUnlink"]);
			}
			return result;
		}

		private IDictionary<string, T> GetInstanceFactory<T>(Func<IDictionary<string, object>, T> predicate) {
			var result = new Dictionary<string, T>();
			if (DependentInfos.Any()) {
				var preparedParameters = new Dictionary<string, object>();
				foreach (DependentInfo dependentInfo in DependentInfos) {
					IDictionary<string, object> parameters = GetReplaceParameter("SchemaName", dependentInfo.EntitySchemaName);
					parameters = GetReplaceParameter("RecordReferenceIds", RecordIds, parameters);
					parameters = GetReplaceParameter("RecordIds", dependentInfo.RecordIds, parameters);
					parameters = GetReplaceParameter("Columns", dependentInfo.ColumnsName, parameters);
					preparedParameters.Add(dependentInfo.EntitySchemaName, parameters);
				}
				foreach (KeyValuePair<string, object> preparedParameter in preparedParameters) {
					T instance = predicate((IDictionary<string, object>)preparedParameters[preparedParameter.Key]);
					result.Add(preparedParameter.Key, instance);
				}
			}
			IDictionary<string, object> parametersDelete = GetReplaceParameter("IsUnlink", false);
			parametersDelete = GetReplaceParameter("IsRoot", true, parametersDelete);
			T baseInstance = predicate(parametersDelete);
			result.Add(SchemaName + "_root", baseInstance);
			return result;
		}

		private void PreparedRecordIds() {
			var items = new List<Guid>();
			var recordIds = new List<Guid>();
			if (Parameters.ContainsKey("IsDeleteAll")) {
				IDictionary<string, object> parametersDelete = GetReplaceParameter("IsRoot", true, Parameters);
				IOperationAgent agent = GetOperationAgentInstance(parametersDelete);
				do {
					recordIds.AddRange(items);
					items = (List<Guid>)agent.GetNextItems();
				} while (items != null);
				Parameters["RecordIds"] = recordIds;
				Parameters.Remove("PreviousOperationKey");
			}
		}

		private void ForceFinalMessage() {
			IRecordProcessedHandler handler = ResultHandler as IRecordProcessedHandler;
			if (handler != null) {
				handler.HandleRecordProcessed(null, new RecordProcessedEventArgs());
			}
		}

		private void MergeDependentInfoCollection(IEnumerable<DependentInfo> collection) {
			foreach (DependentInfo dependentInfo in collection) {
				var curruntDependentInfo =
						DependentInfos.FirstOrDefault(info => info.EntitySchemaName == dependentInfo.EntitySchemaName);
				if (curruntDependentInfo != null) {
					curruntDependentInfo.RecordIds = curruntDependentInfo.RecordIds.Concat(dependentInfo.RecordIds).ToList();
					curruntDependentInfo.RecordsCount = curruntDependentInfo.RecordIds.Count();
				} else {
					DependentInfos.Add(dependentInfo);
				}
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual IRecordResultHandler GetRecordResultHandlerInstance() {
			var arguments = GetConstrustorArguments(Parameters);
			return GetInstance<RecordResultHandler>(arguments);
		}

		protected virtual IDictionary<string, IOperationAgent> GetOperationAgentInstances() {
			return GetInstanceFactory(GetOperationAgentInstance);
		}

		protected virtual IOperationAgent GetOperationAgentInstance(IDictionary<string, object> parameters) {
			var arguments = GetConstrustorArguments(parameters);
			return GetInstance<MultiDeleteOperationAgent>(arguments);
		}


		protected virtual IDictionary<string, IRecordsOperationWorker> GetRecordsOperationWorkerInstances() {
			return GetInstanceFactory(GetRecordsOperationWorkerInstance);
		}

		protected virtual IRecordsOperationWorker GetRecordsOperationWorkerInstance(IDictionary<string, object> parameters) {
			var arguments = GetConstrustorArguments(parameters);
			bool isUnlink = IsUnlink(parameters);
			return (isUnlink)
				? GetInstance<MultiUnlinkWorker>(arguments)
				: GetInstance<MultiDeleteWorker>(arguments) as IRecordsOperationWorker;
		}

		protected virtual EntityDependenciesHelper GetEntityDependenciesHelperInstance() {
			var arguments = new[] {
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("useAdminRights", false)
			};
			return GetInstance<EntityDependenciesHelper>(arguments);
		}

		protected virtual void LoadDependentRecordsInfo() {
			EntityDependenciesHelper helper = GetEntityDependenciesHelperInstance();
			foreach (Guid recordId in RecordIds) {
				IEnumerable<DependentInfo> collection = helper.GetDependentEntitiesContainRecords(SchemaName,
						recordId, true);
				MergeDependentInfoCollection(collection);
			}
			int dependentRecordsCount = DependentInfos.Sum(info => info.RecordsCount);
			if (Parameters.ContainsKey("DependentRecordsCount")) {
				Parameters["DependentRecordsCount"] = dependentRecordsCount;
			} else {
				Parameters.Add("DependentRecordsCount", dependentRecordsCount);
			}
		}

		protected virtual void CreateInstances() {
			ResultHandler = GetRecordResultHandlerInstance();
			OperationAgents = GetOperationAgentInstances();
			OperationWorkers = GetRecordsOperationWorkerInstances();
		}

		protected virtual void SubscribeEvent() {
			var handler = ResultHandler as IRecordProcessedHandler;
			foreach (KeyValuePair<string, IRecordsOperationWorker> recordsOperationWorker in OperationWorkers) {
				var worker = recordsOperationWorker.Value;
				var agent = OperationAgents[recordsOperationWorker.Key] as IRecordProcessedHandler;
				if (agent != null) {
					worker.RecordProcessed += agent.HandleRecordProcessed;
				}
				if (handler != null) {
					worker.RecordProcessed += handler.HandleRecordProcessed;
				}
			}
		}

		protected virtual void Enqueue() {
			IOperationAgent instance;
			if (DependentInfos.Any()) {
				foreach (DependentInfo dependentInfo in DependentInfos) {
					instance = OperationAgents[dependentInfo.EntitySchemaName];
					instance.Enqueue(dependentInfo.RecordIds);
				}
			}
			instance = OperationAgents[SchemaName + "_root"];
			instance.Enqueue(RecordIds);
		}

		protected virtual void MultiDelete() {
			foreach (KeyValuePair<string, IOperationAgent> operationAgent in OperationAgents) {
				IOperationAgent agent = operationAgent.Value;
				while (agent.MoreAvaliable) {
					IRecordsOperationWorker worker = OperationWorkers[operationAgent.Key];
					IEnumerable<Guid> items = agent.GetNextItems();
					if (items != null) {
						worker.ApplyOperations(items);
					}
				}
			}
		}

		#endregion

		#region Methods: Public

		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			UserConnection = userConnection;
			PreparedParameters(parameters);
			try {
				_log.Info("Start.");
				PreparedRecordIds();
				if (IsCascade) {
					LoadDependentRecordsInfo();
				}
				CreateInstances();
				SubscribeEvent();
				Enqueue();
				MultiDelete();
				ForceFinalMessage();
				_log.Info("End.\n");
			} catch (Exception ex) {
				_log.Error(ex.Message, ex);
				throw;
			}
		}

		#endregion

	}

	#endregion

}


