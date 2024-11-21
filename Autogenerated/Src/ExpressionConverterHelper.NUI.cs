namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Core;

	#region Interface: IExpressionConverter

	public interface IExpressionConverter {

		#region Methods: Public

		string Evaluate(object value, string arguments = "");

		#endregion

	}

	#endregion

	#region Class: ExpressionConverterAttribute

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Method)]
	public class ExpressionConverterAttribute : System.Attribute {
	
		#region Constructors: Public
	
		public ExpressionConverterAttribute(string expressionName) {
			this.expressionName = expressionName;
		}
	
		#endregion
	
		#region Properties: Public
	
		private string expressionName;
		public string ExpressionName
		{
			get {return expressionName;}
		}
	
		#endregion
	
	}

	#endregion

	#region Class: ExpressionConverterValue

	public class ExpressionConverterValue {

		#region Constructors: Public

		public ExpressionConverterValue() {
			var dataValueTypeManager = new DataValueTypeManager();
			ValueType = dataValueTypeManager.GetInstanceByName("LongText");
			Data = string.Empty;
		}

		#endregion

		#region Properties: Public

		public DataValueType ValueType {get; set; }

		public object Data { get; set; }

		#endregion

	}

	#endregion

	#region Class: ExpressionConverterElement

	public class ExpressionConverterElement {

		#region Properties: Public

		public string Name {get; set;}
		public string Argument {get; set;}

		#endregion

	}

	#endregion

	#region Class: ExpressionConverterHelper

	/// <summary>
	/// Expression converter helper class.
	/// </summary>
	public class ExpressionConverterHelper {

				#region Fields: Public

		public static Dictionary<string, string> ExpressionConverterCollection;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Converts string value with specified macros.
		/// </summary>
		/// <param name="macrosElement">Macros element.</param>
		/// <param name="value">Converting value.</param>
		/// <param name="macrosValue">Macros value.</param>
		/// <returns>Converted string value.</returns>
		public ExpressionConverterValue GetValue(ExpressionConverterElement macrosElement, object value, ExpressionConverterValue macrosValue = null) {
			if (macrosValue == null) {
				macrosValue = new ExpressionConverterValue();
			} else {
				value = macrosValue.Data;
			}
			if (ExpressionConverterCollection == null) {
				ExpressionConverterCollection = new Dictionary<string, string>();
				var assembly = Type.GetType("BPMSoft.Configuration.ExpressionConverterElement").Assembly;
				var types =
					from type in assembly.GetTypes()
					let attributes = type.GetCustomAttributes(typeof(ExpressionConverterAttribute), true)
					where attributes != null && attributes.Length > 0
					select type;
				foreach (var type in types) {
					var attributes = type.GetCustomAttributes(typeof(ExpressionConverterAttribute), true);
					if (attributes.Count() > 0) {
						if (!ExpressionConverterCollection.ContainsKey(
								((ExpressionConverterAttribute)attributes[0]).ExpressionName)) {
							ExpressionConverterCollection.Add(((ExpressionConverterAttribute)attributes[0]).ExpressionName,
								string.Format("BPMSoft.Configuration.{0}", type.Name));
						}
					}
				}
			}
			if (ExpressionConverterCollection.ContainsKey(macrosElement.Name)) {
				Type expressionConverterClass = Type.GetType(ExpressionConverterCollection[macrosElement.Name]);
				var expressionConverter = (IExpressionConverter)Activator.CreateInstance(expressionConverterClass);
				if (expressionConverter != null) {
					macrosValue.Data = expressionConverter.Evaluate(value, macrosElement.Argument);
				}
			}
			return macrosValue;
		}

		public ExpressionConverterValue GetValue(string macrosName, object value) {
			var macrosElement = new ExpressionConverterElement() {
				Name = macrosName,
				Argument = string.Empty
			};
			return GetValue(macrosElement, value);
		}

		public ExpressionConverterValue GetValue(List<ExpressionConverterElement> macrosList, object value) {
			ExpressionConverterValue macrosValue = null;
			foreach (var macrosElement in macrosList) {
				macrosValue = GetValue(macrosElement, value, macrosValue);
			}
			return macrosValue;
		}

		public List<ExpressionConverterElement> MacrosList(string source) {
			var response = new List<ExpressionConverterElement>();
			var macrosList = Match(source);
			string[] argumentSeparator = new string[] {"|"};
			foreach (string macros in macrosList) {
				var item = new ExpressionConverterElement();
				string[] macrosSplit = macros.Split(argumentSeparator, StringSplitOptions.RemoveEmptyEntries);
				item.Name = macrosSplit[0];
				if (macrosSplit.Length > 1) {
					item.Argument = macrosSplit[1];
				}
				response.Add(item);
			}
			return response;
		}

		public string GetColumnName(string columnName) {
			string[] stringSeparatorsFrom = new string[] {"[#"};
			string[] macrosSplit = columnName.Split(stringSeparatorsFrom, StringSplitOptions.RemoveEmptyEntries);
			return macrosSplit.Length > 0 ?macrosSplit[0] : string.Empty;
		}

		public static List<string> Match(string source) {
			var response = new List<string>();
			string pattern = @"(?<=\[#)(?<macros>[^(#\])]*)(?=#\])";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
			try
			{
				MatchCollection matchcollection = regex.Matches(source);
				foreach(Match match in matchcollection) {
					string matchResult = match.Result("${macros}");
					response.Add(matchResult);
				}
			} catch (Exception)
			{
			}
			return response;
		}
		
		#endregion

	}

	#endregion

}

