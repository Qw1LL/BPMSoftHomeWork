namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Text.RegularExpressions;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Core.Entities;

	#region Class: DiagramElementMap

	public class DiagramElementMap
	{

		#region Constructors: Public

		public DiagramElementMap(string schemaName, IEnumerable<DiagramElementMapPointer> pointers, 
			string referenceColumnValueName = "") {
			Pointers = pointers;
			SchemaName = schemaName;
			ReferenceColumnValueName = referenceColumnValueName;
		}

		#endregion

		#region Properties: Public

		public IEnumerable<DiagramElementMapPointer> Pointers { get; private set; }

		public string SchemaName { get; private set; }

		public string ReferenceColumnValueName { get; private set; }

		#endregion

		#region Methods: Private

		private static JToken GetToken(string[] paths) {
			if (paths.Length > 1 && string.IsNullOrEmpty(paths[1])) {
				return new JArray();
			}
			return new JObject();;
		}

		#endregion

		#region Methods: Public

		public string GetJTokenValueByPath(JToken jToken, string valuePath) {
			string[] paths = valuePath.Split('.');
			JToken node = jToken.DeepClone();
			foreach (string path in paths) {
				if (string.IsNullOrEmpty(path)) {
					if (node.Type == JTokenType.Array && node.HasValues) {
						node = node[0];
						continue;
					}
					node = null;
				}
				if (node == null) {
					return string.Empty;
				}
				if (node.Type == JTokenType.Object) {
					node = node[path];
				} else {
					return string.Empty;
				}
				if (node == null) {
					return string.Empty;
				}
			}
			return node.ToString();
		}

		public void SetJObjectValueByPath(JToken jToken, string valuePath, object value, string prevPath = "") {
			if (string.IsNullOrEmpty(valuePath)) {
				return;
			}
			string[] paths = valuePath.Split('.');
			string currentPath = paths[0];
			var regex = new Regex("^" + currentPath + "(\\.+)?");
			string remainingPath = regex.Replace(valuePath, string.Empty);
			if (string.IsNullOrEmpty(remainingPath)) {
				if (jToken.Type == JTokenType.Array) {
					var jArray = (JArray)jToken;
					jArray.Add(new JObject());
					jToken = jArray[0];
				}
				jToken[currentPath] = new JValue(value);
				return;
			}
			JToken newToken = GetToken(paths);
			JToken nextToken;
			if (jToken.Type == JTokenType.Array) {
				if (!jToken.HasValues) {
					var jArray = (JArray)jToken;
					jArray.Add(newToken);
				}
				nextToken = jToken[0];
			} else {
				nextToken = jToken[currentPath];
			}
			if (nextToken == null) {
				jToken[currentPath] = newToken;
				nextToken = jToken[currentPath];
			}
			SetJObjectValueByPath(nextToken, remainingPath, value, currentPath);
		}

		public void Apply(Entity target, JToken source) {
			foreach (DiagramElementMapPointer pointer in Pointers) {
				string value = GetJTokenValueByPath(source, pointer.EntityColumnValueName);
				if (pointer.ValueType == typeof(string)) {
					target.SetColumnValue(pointer.ObjectPropertyPath, value);
					continue;
				}
				if (string.IsNullOrEmpty(value)) {
					target.SetColumnValue(pointer.ObjectPropertyPath, null);
					continue;
				}
				object parsedValue = null;
				object[] parameters = new object[] { value, parsedValue };
				bool parseResult = (bool)pointer.TryParseMethod.Invoke(null, parameters);
				if (parseResult) {
					parsedValue = parameters[1];
					target.SetColumnValue(pointer.ObjectPropertyPath, parsedValue);
				}
			}
		}

		public void Apply(JObject target, Entity source) {
			foreach (DiagramElementMapPointer pointer in Pointers) {
				object sourceValue = source.GetColumnValue(pointer.ObjectPropertyPath);
				if (sourceValue == null) {
					sourceValue = string.Empty;
				}
				SetJObjectValueByPath(target, pointer.EntityColumnValueName, sourceValue);
			}
			object id = source.GetColumnValue("Id");
			SetJObjectValueByPath(target, "name", id);
		}
		
		#endregion

	}

	#endregion

	#region Class: DiagramElementMapPointer

	public class DiagramElementMapPointer
	{

		#region Constructors: Public

		public DiagramElementMapPointer(string entityColumnValueName, string objectPropertyPath, Type valueType) {
			EntityColumnValueName = entityColumnValueName;
			ObjectPropertyPath = objectPropertyPath;
			ValueType = valueType;
			_tryParseMethod = ValueType.GetMethod("TryParse");
		}

		#endregion

		#region Properties: Public

		public string EntityColumnValueName { get; private set; }

		public string ObjectPropertyPath { get; private set; }

		public Type ValueType { get; private set; }

		private MethodInfo _tryParseMethod;
		public MethodInfo TryParseMethod => _tryParseMethod;

		#endregion

	}

	#endregion

}

