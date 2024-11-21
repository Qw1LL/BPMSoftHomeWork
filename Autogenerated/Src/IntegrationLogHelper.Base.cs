using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BPMSoft.Core;
using BPMSoft.Common;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{
	public class IntegrationLogHelper {
		public static readonly Guid MailChimpSystemId = new Guid("8CFE7519-6E7A-453D-9278-046BDE8CC833");
		public static readonly Guid MailServerSystemId = new Guid("A83DA2EF-8739-48D8-B14A-6FC39B555FB8");
		public static readonly Guid UpdateSendingStatusOperationId = new Guid("CAEC936A-8E87-4A91-8BEA-0655966457BC");
		public static readonly Guid SendCampaignOperationId = new Guid("FDA4CB23-C2F5-42BC-85E4-0ABD0A03B0CA");
		public static readonly Guid SendBMPonlineMassMailingOperationId = new Guid("BF536637-25FC-40DF-A541-8070DFC9EE6E");
		public static readonly Guid ImportDirectionId = new Guid("A3F528A7-8A23-4435-8E3F-B2B84DF4EA3E");
		public static readonly Guid ExportDirectionId = new Guid("0D8E082B-8A96-4C3F-A1B1-2B96D922ADEC");
		public static readonly Guid SuccessResultId = new Guid("00FC0D2C-6325-4ABC-AB97-90CABFB064E6");
		public static readonly Guid ErrorResultId = new Guid("D62F29E2-A456-48D1-9E36-B01DA3C2ACDD");
		
		private readonly UserConnection _userConnection;
		public IntegrationLogHelper(UserConnection userConnection) {
			if (userConnection == null) {
				throw new ArgumentNullException("userConnection");
			}			
			_userConnection = userConnection;			
		}
		
		public void Log(Guid systemId, Guid operationId, Guid directionId, Guid resultId, string description, string errorDescription = null) {
			if (!string.IsNullOrEmpty(description) && description.Length > 500) {
				description = description.Substring(0, 500);
			}
			if (!string.IsNullOrEmpty(errorDescription) && errorDescription.Length > 500) {
				errorDescription = errorDescription.Substring(0, 500);
			}
			var schema = _userConnection.EntitySchemaManager.FindInstanceByName("IntegrationLog");
			var entity = schema.CreateEntity(_userConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue("IntegrationSystemId", systemId); //MailChimp system
			entity.SetColumnValue("OperationId", operationId);
			entity.SetColumnValue("DirectionId", directionId);
			entity.SetColumnValue("ResultId", resultId);			
			entity.SetColumnValue("Description", description);
			entity.SetColumnValue("ErrorDescription", errorDescription);
			entity.Save();
		}
	}
}
