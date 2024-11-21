namespace BPMSoft.Configuration.Formula
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.Formula;
	using BPMSoft.Core.Formula.DataProviders.DataProviderConfigs;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Formula.Exceptions;
	using BPMSoft.Web.Common.ServiceRouting;
	using Newtonsoft.Json;

	#region Class: FormulaCalculationServiceResponse

	[DataContract]
	public class FormulaCalculationServiceResponse : ConfigurationServiceResponse
	{

		#region Fields: Private

		private object _result;

		#endregion

		#region Constructor: Public

		public FormulaCalculationServiceResponse() { }

		public FormulaCalculationServiceResponse(Exception exception)
			: base(exception) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "result")]
		public object Result {
			get { return _result; }
			set {
				if (value is DateTime) {
					_result = JsonConvert.SerializeObject(value, new JsonSerializerSettings {
						DateFormatHandling = DateFormatHandling.IsoDateFormat
					}).Replace("\"", string.Empty);
				} else {
					_result = value;
				}
			}
		}

		#endregion

	}

	#endregion

	#region Class: FormulaCalculationService

	[DefaultServiceRoute]
	[SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FormulaCalculationService : BaseService
	{

		#region Methods: Private

		private string GetConfigurationErrorMessage(string key) {
			return UserConnection.GetLocalizableString("FormulaCalculationService", key);
		}

		private FormulaCalculationServiceResponse GetExceptionResponse(FormulaOperandConversionException exception) {
			return new FormulaCalculationServiceResponse(exception) {
				ErrorInfo = {
					Message = exception.ShortMessage
				}
			};
		}

		private FormulaCalculationServiceResponse GetExceptionResponse(Exception exception, string localizationKey) {
			var exceptionResponse = new FormulaCalculationServiceResponse(exception) {
				ErrorInfo = {
					Message = GetConfigurationErrorMessage(localizationKey)
				}
			};
			return exceptionResponse;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped)]
		public FormulaCalculationServiceResponse Calculate(string formula, string entitySchemaName, Guid recordId,
			Dictionary<string, object> changedColumns) {
			try {
				var result = ClassFactory.Get<IFormulaCalculator>()
					.Configure(new ColumnDataProviderConfig(UserConnection, entitySchemaName, recordId, changedColumns))
					.Calculate(formula);
				return new FormulaCalculationServiceResponse {
					Result = result
				};
			} catch (FormulaCalculationException exception) when (exception.InnerException is DivideByZeroException) {
				var exceptionResponse = GetExceptionResponse(exception, "FormulaErrorDivisionByZero");
				throw new WebFaultException<FormulaCalculationServiceResponse>(exceptionResponse,
					HttpStatusCode.InternalServerError);
			} catch (FormulaCalculationException exception) when (exception.InnerException is OverflowException || exception.InnerException is ArgumentOutOfRangeException) {
				var exceptionResponse = GetExceptionResponse(exception, "FormulaErrorSizeExceeded");
				throw new WebFaultException<FormulaCalculationServiceResponse>(exceptionResponse,
					HttpStatusCode.InternalServerError);
			} catch (FormulaOperandConversionException exception) {
				throw new WebFaultException<FormulaCalculationServiceResponse>(GetExceptionResponse(exception),
					HttpStatusCode.BadRequest);
			} catch (Exception exception) {
				var exceptionResponse = GetExceptionResponse(exception, "FormulaErrorInvalidExpression");
				throw new WebFaultException<FormulaCalculationServiceResponse>(exceptionResponse,
					HttpStatusCode.BadRequest);
			}
		}

		#endregion

	}

	#endregion

}

