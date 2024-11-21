namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.IO;
	using System.Net;
	using System.Text;
	using System.Web;
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using ServiceStack.Text;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Configuration.PRM;
	using ErrorInfo = BPMSoft.Core.ServiceModelContract.ErrorInfo;

	#region Class: LeadRightsService

	/// <summary>
	/// Service for granting and cleaning lead`s rigths for partners.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class LeadRightsService
	{
		#region Fields: Private

		private readonly Guid _defaultRightSource;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LeadRightsService() {
			_defaultRightSource = PRMBaseConstants.SysEntitySchemaRecRightSourceLeadPartnerOwner;
		}

		/// <summary>
		/// Constructor with user connection.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance</param>
		public LeadRightsService(UserConnection userConnection) : this() {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection _userConnection;
		private UserConnection UserConnection {
			get {
				return _userConnection ?? (_userConnection = HttpContext.Current.Session["UserConnection"] as UserConnection);
			}
		}

		/// <summary>
		/// <see cref="RightsManagerHelper"/> instance.
		/// </summary>
		private RightsManagerHelper _helper;
		private RightsManagerHelper Helper {
			get {
				return _helper ?? (_helper = ClassFactory.Get<RightsManagerHelper>(
					new ConstructorArgument("userConnection", UserConnection), new ConstructorArgument("schemaName", "Lead")));
			}
		}

		#endregion

		#region Methods: Private

		private RightsParams GetLeadRightsParamsForGrantToPartner(Guid leadId, Guid partnerId) {
			var rightsParams = new RightsParams(leadId, _defaultRightSource);
			PRMUtility utility = new PRMUtility(UserConnection);
			rightsParams.SysAdminUnitId = utility.GetPartnershipRoleByAccount(partnerId);
			rightsParams.OperationsRights = new Dictionary<EntitySchemaRecordRightLevel, List<EntitySchemaRecordRightOperation>> { {
					EntitySchemaRecordRightLevel.Allow,
						new List<EntitySchemaRecordRightOperation> {
							EntitySchemaRecordRightOperation.Read, EntitySchemaRecordRightOperation.Edit
						}
					}
				};
			return rightsParams;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Service method that provides granting lead read/edit rights for partners.
		/// </summary>
		/// <param name="leadId">The id of lead</param>
		/// <param name="partnerId">The id of partner</param>
		/// <returns>Exception message if it occurs</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse GrantLeadReadEditRightsForPartner(Guid leadId, Guid partnerId) {
			try {
				var rightsParams = GetLeadRightsParamsForGrantToPartner(leadId, partnerId);
				if (rightsParams.SysAdminUnitId == Guid.Empty) {
					return new BaseResponse { Success = false };
				}
				Helper.GrantRightsForRecord(rightsParams);
			} catch (Exception e) {
				return new BaseResponse {
					Success = false, 
					ErrorInfo = new ErrorInfo {
						Message = e.Message
					}
				};
			}
			return new BaseResponse {
				Success = true
			};
		}

		/// <summary>
		/// Service method that provides removing lead rights for partners.
		/// </summary>
		/// <param name="leadId">The id of lead</param>
		/// <returns>Exception message if it occurs</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse RemovePartnersLeadRights(Guid leadId) {
			try {
				Helper.RemoveRecordRightsBySource(leadId, PRMBaseConstants.SysEntitySchemaRecRightSourceLeadPartnerOwner);
			} catch (Exception e) {
				return new BaseResponse {
					Success = false, 
					ErrorInfo = new ErrorInfo {
						Message = e.Message
					}
				};
			}
			return new BaseResponse {
				Success = true
			};
		}

		/// <summary>
		/// Service method that replacing lead rights from old partner to new partner.
		/// </summary>
		/// <param name="leadId">The id of lead</param>
		/// <param name="newPartnerId">The id of new partner</param>
		/// <returns>Exception message if it occurs</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse ReplacePartnersLeadRights(Guid leadId, Guid newPartnerId) {
			try {
				Helper.RemoveRecordRightsBySource(leadId, _defaultRightSource);
				var rightsParams = GetLeadRightsParamsForGrantToPartner(leadId, newPartnerId);
				if (rightsParams.SysAdminUnitId == Guid.Empty) {
					return new BaseResponse {
						Success = false
					};
				}
				Helper.GrantRightsForRecord(rightsParams);
			} catch (Exception e) {
				return new BaseResponse {
					Success = false, 
					ErrorInfo = new ErrorInfo {
						Message = e.Message
					}
				};
			}			
			return new BaseResponse {
				Success = true
			};
		}

		#endregion
	}

	#endregion
}

