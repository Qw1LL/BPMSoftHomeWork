namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Process;
	using BPMSoft.Web.Common;

	/// <summary>
	/// ###### ######## ######-#########.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ProcessValidationService : BaseService {

		/// <summary>
		/// ########## ########### ########## ######-########.
		/// </summary>
		internal class ProcessCheckParameterComparer: IEqualityComparer<ProcessCheckParameter> {

			/// <summary>
			/// ######### ############ ##########.
			/// </summary>
			/// <param name="x">########### ######## ######-########.</param>
			/// <param name="y">########### ######## ######-########.</param>
			/// <returns>####### ############.</returns>
			public bool Equals(ProcessCheckParameter x, ProcessCheckParameter y) {
				if (ReferenceEquals(x, y)) {
					return true;
				}
				if (ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) {
					return false;
				}
				return ((x.Name == y.Name) && (!x.DataValueTypes.Except(y.DataValueTypes).Any() ||
					!y.DataValueTypes.Except(x.DataValueTypes).Any()));
			}
			
			/// <summary>
			/// ########## HashCode ####### ############ ######### ######-########.
			/// </summary>
			/// <param name="processCheckParameter">########### ######## ######-########.</param>
			/// <returns>HashCode.</returns>
			public int GetHashCode(ProcessCheckParameter processCheckParameter) {
				if (ReferenceEquals(processCheckParameter, null)) {
					return 0;
				}
				int hashName = (processCheckParameter.Name == null) ? 0 : processCheckParameter.Name.GetHashCode();
				int hashDataValueTypes = (processCheckParameter.DataValueTypes == null)
					? 0 
					: processCheckParameter.DataValueTypes.GetHashCode();
				return hashName ^ hashDataValueTypes;
			}
		}

		/// <summary>
		/// ######### ############ ########## ######-########.
		/// </summary>
		/// <param name="processUId">############# ######-########.</param>
		/// <param name="checkParameters">###### ########### ##########.</param>
		/// <returns>######### ########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ProcessCheckResult CheckParameters(Guid processUId, List<ProcessCheckParameter> checkParameters) {
			if ((checkParameters == null) || (checkParameters.Count == 0)) {
				return new ProcessCheckResult {
					IsValid = true
				};
			}
			ISchemaManagerItem<ProcessSchema> processManagerItem =
				UserConnection.ProcessSchemaManager.FindItemByUId(processUId);
			if (processManagerItem == null) {
				string errorText = new LocalizableString(UserConnection.ResourceStorage, "ProcessValidationService",
					"LocalizableStrings.ProcessNotFoundErrorText.Value").ToString();
				return new ProcessCheckResult {
					IsValid = false,
					ErrorText = errorText
				};
			}
			ProcessSchema processSchema = UserConnection.ProcessSchemaManager.GetInstanceByUId(processUId);
			var parameters = processSchema.Parameters;
			ProcessCheckParameterComparer comparer = new ProcessCheckParameterComparer();
			List<ProcessCheckParameter> invalidParameters = checkParameters
				.Where(checkParameter => !(parameters
					.Select(parameter => new ProcessCheckParameter() {
						Name = parameter.Name,
						DataValueTypes = new List<string>(1) {
							parameter.DataValueType.Name
						}
					})
					.Where(parameter => checkParameters.Contains(parameter, comparer))
					.ToList<ProcessCheckParameter>()).Contains(checkParameter, comparer)
				)
				.ToList();
			return new ProcessCheckResult {
				IsValid = (invalidParameters.Count == 0),
				InvalidParameters = invalidParameters
			};
		}

		/// <summary>
		/// ##### ############ ######### ######-########.
		/// </summary>
		[DataContract]
		public class ProcessCheckParameter {

			/// <summary>
			/// ### #########.
			/// </summary>
			[DataMember(Name = "name")]
			public string Name;

			/// <summary>
			/// ###### ##### #########.
			/// </summary>
			[DataMember(Name = "dataValueTypes")]
			public List<string> DataValueTypes;
		}

		/// <summary>
		/// ##### ########## ########.
		/// </summary>
		[DataContract]
		public class ProcessCheckResult {

			/// <summary>
			/// ####### ############.
			/// </summary>
			[DataMember(Name = "isValid")]
			public bool IsValid;

			/// <summary>
			/// ###### ############ ##########.
			/// </summary>
			[DataMember(Name = "invalidParameters")]
			public List<ProcessCheckParameter> InvalidParameters;

			/// <summary>
			/// ##### ######.
			/// </summary>
			[DataMember(Name = "errorText")]
			public string ErrorText;
		}
	}
}

