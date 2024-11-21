namespace BPMSoft.Configuration.Passport
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: ProductInfo

	[DataContract]
	public partial class ProductInfo
	{
		[DataMember(Name = "productInOrderId")]
		public Guid ProductInOrderId { get; set; }

		[DataMember(Name = "quantity")]
		public decimal Quantity { get; set; }
	}

	#endregion

	#region Class: SupplyPaymentProductInfoRequest

	[DataContract]
	public partial class SupplyPaymentProductInfoRequest
	{

		[DataMember(Name = "supplyPaymentElementId")]
		public Guid SupplyPaymentElementId { get; set; }

		[DataMember(Name = "productsInfo")]
		public ProductInfo[] ProductsInfo { get; set; }

	}

	#endregion

	#region Class: OrderPassportService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class OrderPassportService : BaseService
	{
		#region Class: UpdateSupplyPaymentProductsRequest

		[DataContract]
		public class UpdateSupplyPaymentProductsRequest
		{
			/// <summary>
			/// Id #### ####### ######## # #####.
			/// </summary>
			[DataMember(Name = "supplyPaymentElementId")]
			public Guid SupplyPaymentElementId { get; set; }

			/// <summary>
			/// ########## # ########## #########. ###### ######### #### ####-########, ### #### - Id ######## # ######, 
			/// ######## - ##### ########## ### ######## # #### ####### ######## # #####.
			/// </summary>
			public Dictionary<Guid, decimal> ProductsInfo {
				get {
					return Common.Json.Json.Deserialize<Dictionary<Guid, decimal>>(ProductsData);
				}
			}

			[DataMember(Name = "productsData")]
			public string ProductsData { get; set; }
		}

		#endregion

		#region Properties: Private

		private OrderPassportHelper PassportHelper {
			get {
				return ClassFactory.Get<OrderPassportHelper>(new ConstructorArgument("userConnection", UserConnection));
			}
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ChangeTemplate(Guid orderId, Guid templateId) {
			var response = new ConfigurationServiceResponse();
			try {
				PassportHelper.ChangeTemplate(orderId, templateId);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse TurnDefPassportTemplateOff(Guid orderId) {
			var response = new ConfigurationServiceResponse();
			try {
				PassportHelper.TurnDefPassportTemplateOff(orderId);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateSupplyPaymentProducts(UpdateSupplyPaymentProductsRequest updateRequest) {
			var response = new ConfigurationServiceResponse();
			try {
				PassportHelper.UpdateSupplyPaymentProducts(updateRequest.SupplyPaymentElementId, updateRequest.ProductsInfo);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ClearSupplyPaymentProducts(Guid supplyPaymentElementId) {
			var response = new ConfigurationServiceResponse();
			try {
				PassportHelper.ClearSupplyPaymentProducts(supplyPaymentElementId);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ValidateSupplyPaymentPercentage(Guid orderId,
				Guid currentElementId, decimal newPercentageValue) {
			var response = new ConfigurationServiceResponse();
			try {
				PassportHelper.ValidateSupplyPaymentPercentage(orderId, currentElementId, newPercentageValue);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ValidateSupplyPaymentAmountPlan(Guid orderId, Guid currentElementId, decimal newAmountPlanValue) {
			var response = new ConfigurationServiceResponse();
			try {
				PassportHelper.ValidateSupplyPaymentAmountPlan(orderId, currentElementId, newAmountPlanValue);
			}
			catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ValidateOrderProductQuantity(Guid orderProductId, decimal newQuantity) {
			var response = new ConfigurationServiceResponse();
			try {
				PassportHelper.ValidateOrderProductQuantity(orderProductId, newQuantity);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		#endregion
	}

	#endregion

}

