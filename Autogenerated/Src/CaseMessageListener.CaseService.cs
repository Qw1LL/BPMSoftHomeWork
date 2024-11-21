using global::Common.Logging;
using System;
using System.Collections.Generic;
using BPMSoft.Core;
using BPMSoft.Core.Factories;
using BPMSoft.Core.Scheduler;
using SystemSettings = BPMSoft.Core.Configuration.SysSettings;


namespace BPMSoft.Configuration
{

    #region Class: CaseMessageListener

    public class CaseMessageListener : BaseMessageListener
    {

        #region Constants: Private

        private const string jobName = "CasePortalMessageMultiLanguageProcessJob";
        private const string jobGroupName = "CasePortalMessageMultiLanguageProcessJobGroup";
        private static readonly ILog _log = LogManager.GetLogger("CaseMessageListener");

        #endregion

        #region Fields: Private

        private readonly UserConnection _userConnection;
        private readonly Guid _portalNotifierId = new Guid("0C61DA8A-7A29-42C0-9877-08D5FEF15F28");
        private readonly Guid _casePortalNotificationProcessId;

        #endregion

        #region Constructor: Public

        public CaseMessageListener(UserConnection userConnection) : base(userConnection) {
            HistorySchemaName = "CaseMessageHistory";
            HistorySchemaReferenceColumnName = "CaseId";
            ListenerSchemaUId = CaseConsts.CaseSchemaUId;
            NeedCheckExistenceOfRecord = true;
            _userConnection = userConnection;
            _casePortalNotificationProcessId = SystemSettings.GetValue<Guid>(userConnection,
                "CasePortalMessageMultiLanguageProcess", Guid.Empty);
        }

        #endregion

        #region Methods: Protected

        protected ICasePushNotifier GetPushNotifier() {
            return ClassFactory.Get<ICasePushNotifier>(new ConstructorArgument("userConnection", _userConnection));
        }

        protected void RunProcess(Guid recordId) {
            UserConnection userConnection = _userConnection;
            bool isSystemUser = false;
            if (_userConnection.CurrentUser.ConnectionType == UserType.SSP) {
                userConnection = _userConnection.AppConnection.SystemUserConnection;
                isSystemUser = true;
                _log.InfoFormat("Current user type is SSP. UserName: {0}, recordId: {1}", _userConnection.CurrentUser.Name, recordId);
            } else {
                _log.InfoFormat("Current user type is NOT SSP. UserName: {0}, recordId: {1}", userConnection.CurrentUser.Name, recordId);
            }
            if (_casePortalNotificationProcessId != default(Guid)) {
                var manager = userConnection.ProcessSchemaManager;
                var processSchema = manager.FindItemByUId(_casePortalNotificationProcessId);
                if (processSchema != null) {
                    Dictionary<string, object> parameters = new Dictionary<string, object> {
                        {"RecordId", recordId}
                    };
                    _log.InfoFormat("Process starting with recordId: {0}", recordId);
                    AppScheduler.TriggerJob(string.Concat(jobName, "_", recordId), jobGroupName, processSchema.Name,
                        userConnection.Workspace.Name, userConnection.CurrentUser.Name, parameters, isSystemUser);
                    _log.InfoFormat("Process started with recordId: {0}", recordId);
                } else {
                    _log.InfoFormat("ProcessSchemaManager is null for recordId: {0}, userName: {1}, userConnectionType: {2}. Process was't started", recordId, userConnection.CurrentUser.Name, userConnection.CurrentUser.ConnectionType);
                }
            } else {
                _log.InfoFormat("CasePortalMessageMultiLanguageProcess system settings is empty for recordId: {0}, userName: {1}, userConnectionType: {2}. Process was't started", recordId, userConnection.CurrentUser.Name, userConnection.CurrentUser.ConnectionType);
            }
        }

        protected override bool InsertMessage() {
            var messageInfo = base.NotifierMessageInfo;
            bool insertResult = base.InsertMessage();
            Guid caseId = messageInfo.ListenersData[ListenerSchemaUId];
            if (insertResult && base.MessageNotifierId == _portalNotifierId) {
                try {
                    var recordId = messageInfo.NotifierRecordId;
                    _log.InfoFormat("[CaseId: {2}] CasePortalMessageMultiLanguageProcess should be started for Message: {0}, RecordId: {1}", messageInfo.Message, recordId, caseId);
                    RunProcess(recordId);
                } catch (Exception ex) {
                    _log.ErrorFormat("[CaseId: {3}] An error occured while starting process Message: {0}, CallStack: {1}, InnerException: {2}", ex.Message, ex.StackTrace, ex.InnerException, caseId);
                }
                GetPushNotifier().NotifyNewMessage(caseId);
            }
            return insertResult;
        }

        #endregion
    }

    #endregion

}
