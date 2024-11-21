namespace BPMSoft.Configuration.ServiceSchema
{

	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core.Factories;

	#region Interface: IServiceSchemaParameterBuilder

	public interface IServiceSchemaParameterBuilder
	{
		Dictionary<string, object> Build(IEnumerable<ServiceSchemaParameter> parameters);
	}

	#endregion
	
	#region Class: ServiceSchemaParameterBuilder

	[DefaultBinding(typeof(IServiceSchemaParameterBuilder))]
	public class ServiceSchemaParameterBuilder : IServiceSchemaParameterBuilder
	{

		private static Dictionary<string, object> Build(IEnumerable<ServiceSchemaParameter> parameters,
				Dictionary<string, object> serviceParameters) {
			foreach (var parameter in parameters) {
				object value = parameter.NestedParameters?.Select(nestedParameter =>
					Build(nestedParameter, new Dictionary<string, object>())).ToList() ?? parameter.Value;
				serviceParameters.Add(parameter.Code, value);
			} 
			return serviceParameters;
		}

		public Dictionary<string, object> Build(IEnumerable<ServiceSchemaParameter> parameters) {
			return Build(parameters, new Dictionary<string, object>());
		}
	}

	#endregion

}
