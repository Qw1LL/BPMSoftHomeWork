namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.IO;
	using System.Net;
	using System.Xml;

	#region Class: WebServiceUserTask

	[DesignModeProperty(Name = "Service", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.Service.Caption", DescriptionResourceItem = "Parameters.Service.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ServiceMethod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.ServiceMethod.Caption", DescriptionResourceItem = "Parameters.ServiceMethod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ServiceUrl", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.ServiceUrl.Caption", DescriptionResourceItem = "Parameters.ServiceUrl.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ServiceMethodParameters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.ServiceMethodParameters.Caption", DescriptionResourceItem = "Parameters.ServiceMethodParameters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RequestStatus", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.RequestStatus.Caption", DescriptionResourceItem = "Parameters.RequestStatus.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Result", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.Result.Caption", DescriptionResourceItem = "Parameters.Result.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsLoggingRequestAndResponce", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.IsLoggingRequestAndResponce.Caption", DescriptionResourceItem = "Parameters.IsLoggingRequestAndResponce.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Request", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.Request.Caption", DescriptionResourceItem = "Parameters.Request.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Responce", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.Responce.Caption", DescriptionResourceItem = "Parameters.Responce.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RequestBodyInternal", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.RequestBodyInternal.Caption", DescriptionResourceItem = "Parameters.RequestBodyInternal.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RequestParameters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "e7acb2e5efc641d38c02589ae6b943f1", CaptionResourceItem = "Parameters.RequestParameters.Caption", DescriptionResourceItem = "Parameters.RequestParameters.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class WebServiceUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public WebServiceUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("e7acb2e5-efc6-41d3-8c02-589ae6b943f1");
		}

		#endregion

		#region Properties: Public

		public virtual Guid Service {
			get;
			set;
		}

		public virtual string ServiceMethod {
			get;
			set;
		}

		public virtual Guid ServiceUrl {
			get;
			set;
		}

		public virtual string ServiceMethodParameters {
			get;
			set;
		}

		public virtual int RequestStatus {
			get;
			set;
		}

		private Entity _result;
		public virtual Entity Result {
			get {
				return _result ?? (_result = new Entity(UserConnection));
			}
			set {
				_result = value;
			}
		}

		public virtual bool IsLoggingRequestAndResponce {
			get;
			set;
		}

		public virtual string Request {
			get;
			set;
		}

		public virtual string Responce {
			get;
			set;
		}

		public virtual string RequestBodyInternal {
			get;
			set;
		}

		public virtual string RequestParameters {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (ServiceUrl == Guid.Empty || string.IsNullOrEmpty(ServiceMethod)) {
				return true;
			}
			string serviceUrl = (new Select(UserConnection)
				.Column("URL")
				.From("WebServiceURL")
				.Where("Id").IsEqual(new QueryParameter("Id", ServiceUrl)) as Select)
				.ExecuteScalar<string>();
			HttpWebRequest webRequest = CreateWebRequest(serviceUrl, ServiceMethod);
			string Request = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:web=""http://www.webserviceX.NET/"">
			<soap:Header/>
				<soap:Body>";
			Request += RequestBodyInternal;
			Request += @"
				</soap:Body>
			</soap:Envelope>";
			webRequest.ContentLength = Request.Length;
			using (Stream stream = webRequest.GetRequestStream()) {
				using (StreamWriter streamWriter = new StreamWriter(stream)) {
					streamWriter.Write(Request);
					streamWriter.Close();
				}
			}
			using (WebResponse response = webRequest.GetResponse()) {
				using (StreamReader rd = new StreamReader(response.GetResponseStream())) { 
					Responce = rd.ReadToEnd();
				}
			}
			PrepareResponceResult();
			if (!IsLoggingRequestAndResponce) {
				Request = string.Empty;
				Responce = string.Empty;
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public virtual HttpWebRequest CreateWebRequest(string url, string soapAction) {
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.ContentType = "application/soap+xml;charset=UTF-8;action=\"http://www.webserviceX.NET/" + soapAction + "\"";
			webRequest.Method = "POST";
			webRequest.KeepAlive = true;
			return webRequest;
		}

		public virtual string PrepareRequestParameters() {
			return @"
			<web:ConversionRate>
						<web:FromCurrency>USD</web:FromCurrency>
						<web:ToCurrency>UAH</web:ToCurrency>
					</web:ConversionRate>";
		}

		public virtual void PrepareResponceResult() {
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("Service")) {
				writer.WriteValue("Service", Service, Guid.Empty);
			}
			if (!HasMapping("ServiceMethod")) {
				writer.WriteValue("ServiceMethod", ServiceMethod, null);
			}
			if (!HasMapping("ServiceUrl")) {
				writer.WriteValue("ServiceUrl", ServiceUrl, Guid.Empty);
			}
			if (!HasMapping("ServiceMethodParameters")) {
				writer.WriteValue("ServiceMethodParameters", ServiceMethodParameters, null);
			}
			if (!HasMapping("RequestStatus")) {
				writer.WriteValue("RequestStatus", RequestStatus, 0);
			}
			if (Result != null && Result.Schema != null) {
				if (UseFlowEngineMode) {
					Result.Write(writer, "Result");
				} else {
					string serializedEntity = Entity.SerializeToJson(Result);
					writer.WriteValue("Result", serializedEntity, null);
				}
			}
			if (!HasMapping("IsLoggingRequestAndResponce")) {
				writer.WriteValue("IsLoggingRequestAndResponce", IsLoggingRequestAndResponce, false);
			}
			if (!HasMapping("Request")) {
				writer.WriteValue("Request", Request, null);
			}
			if (!HasMapping("Responce")) {
				writer.WriteValue("Responce", Responce, null);
			}
			if (!HasMapping("RequestBodyInternal")) {
				writer.WriteValue("RequestBodyInternal", RequestBodyInternal, null);
			}
			if (!HasMapping("RequestParameters")) {
				writer.WriteValue("RequestParameters", RequestParameters, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Service":
					Service = reader.GetGuidValue();
				break;
				case "ServiceMethod":
					ServiceMethod = reader.GetStringValue();
				break;
				case "ServiceUrl":
					ServiceUrl = reader.GetGuidValue();
				break;
				case "ServiceMethodParameters":
					ServiceMethodParameters = reader.GetStringValue();
				break;
				case "RequestStatus":
					RequestStatus = reader.GetIntValue();
				break;
				case "Result":
					if (UseFlowEngineMode) {
						Result = reader.GetValue<Entity>();
					} else {
						Result = Entity.DeserializeFromJson(UserConnection, reader.GetValue<System.String>());
					}
				break;
				case "IsLoggingRequestAndResponce":
					IsLoggingRequestAndResponce = reader.GetBoolValue();
				break;
				case "Request":
					Request = reader.GetStringValue();
				break;
				case "Responce":
					Responce = reader.GetStringValue();
				break;
				case "RequestBodyInternal":
					RequestBodyInternal = reader.GetStringValue();
				break;
				case "RequestParameters":
					RequestParameters = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

