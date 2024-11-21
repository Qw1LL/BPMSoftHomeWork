namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	
	#region Class: MailingHandlersUtilities

	/// <summary>
	/// Utilities for interaction with mailing handlers.
	/// </summary>
	public static class MailingHandlersUtilities
	{

		#region Constants: Private

		private const string LogPattern = "MailingHandlersUtilities.{0}";

		#endregion

		#region Methods: Private

		private static string GetFormattedMessage(string message, IMailingHandler handler) {
			string typeName = handler.GetType().Name;
			return GetFormattedMessage(message, typeName);
		}

		private static string GetFormattedMessage(string message, string typeName) {
			message = string.Format(message, typeName);
			return string.Format(LogPattern, message);
		}

		private static void LogError(string message, IMailingHandler handler, Exception exception = null) {
			message = GetFormattedMessage(message, handler);
			LogError(message, exception);
		}

		private static void LogError(string message, string typeName, Exception exception = null) {
			message = GetFormattedMessage(message, typeName);
			LogError(message, exception);
		}

		private static void LogError(string message, Exception exception = null) {
			if (exception == null) {
				MailingUtilities.Log.Error(message);
			} else {
				MailingUtilities.Log.Error(message, exception);
			}
		}

		private static void LogInfo(string message, IMailingHandler handler) {
			message = GetFormattedMessage(message, handler);
			MailingUtilities.Log.Info(message);
		}

		private static EntityCollection GetMailingHandlers(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysMailingHandler");
			esq.AddColumn("Name");
			esq.AddColumn("ClassName");
			esq.AddColumn("Provider");
			var collection = esq.GetEntityCollection(userConnection);
			return collection;
		}

		private static IEnumerable<string> GetProviderHandlers(Guid providerId, EntityCollection handlers) {
			return handlers.Where(_ => _.GetTypedColumnValue<Guid>("ProviderId") == providerId)
				.Select(_ => _.GetTypedColumnValue<string>("ClassName")).Distinct();
		}

		private static IEnumerable<string> GetDisabledHandlers(EntityCollection allHandlers,
				IEnumerable<string> activeHandlers) {
			return allHandlers.Where(_ => !activeHandlers.Contains(_.GetTypedColumnValue<string>("ClassName")))
				.Select(_ => _.GetTypedColumnValue<string>("ClassName")).Distinct();
		}

		private static void ActivateHandlers(IEnumerable<IMailingHandler> handlers, UserConnection userConnection) {
			foreach(var handler in handlers) {
				try {
					handler.CreateInstance(userConnection);
					LogInfo("Instance of {0} created.", handler);
				} catch (Exception e) {
					LogError("ActivateHandlers. Creating instance of {0} fails.", handler, e);
				}
			}
		}

		private static void DeactivateHandlers(IEnumerable<IMailingHandler> handlers) {
			foreach(var handler in handlers) {
				try {
					handler.RemoveInstance();
					LogInfo("Instance of {0} removed.", handler);
				} catch (Exception e) {
					LogError("DeactivateHandlers. Removing instance of {0} fails.", handler, e);
				}
			}
		}

		private static IEnumerable<IMailingHandler> InstantiateHandlers(IEnumerable<string> handlersClassNames) {
			List<IMailingHandler> handlers = new List<IMailingHandler>();
			foreach(string className in handlersClassNames) {
				Type classType = Type.GetType(className);
				if (classType != null) {
					try {
						var mailingHandler = Activator.CreateInstance(classType) as IMailingHandler;
						handlers.Add(mailingHandler);
					} catch (Exception e) {
						LogError("InstantiateHandlers. Failed to create instance of {0}.", className, e);
					}
				}
			}
			return handlers;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Enables handlers of the active mailing provider.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public static void EnableActiveProviderHandlers(UserConnection userConnection) {
			Guid providerId = MailingUtilities.GetActiveProviderId(userConnection);
			EntityCollection mailingHandlers = GetMailingHandlers(userConnection);
			IEnumerable<string> activeHandlersNames = GetProviderHandlers(providerId, mailingHandlers);
			IEnumerable<string> inactiveHandlersNames = GetDisabledHandlers(mailingHandlers, activeHandlersNames);
			IEnumerable<IMailingHandler> activeHandlers = InstantiateHandlers(activeHandlersNames);
			IEnumerable<IMailingHandler> inactiveHandlers = InstantiateHandlers(inactiveHandlersNames);
			DeactivateHandlers(inactiveHandlers);
			ActivateHandlers(activeHandlers, userConnection);
		}



		#endregion

	}

	#endregion

}

