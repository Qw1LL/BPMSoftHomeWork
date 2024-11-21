namespace BPMSoft.Configuration
{
	using System;
	//using System.Numerics;
	//using System.DateTime;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	
	public enum ChartPointType {
		None,
		//DateTime_Double, // In place of DateTime only string is in use
		Double_DateTime,
		String_Double,
		Double_Double
	}
	
	public class ChartHelper {
		private static ChartHelper _instance = null;	
		public static ChartHelper Instance(UserConnection userConnection) {
			return _instance ?? (_instance = new ChartHelper(userConnection));		
		}
		
		private UserConnection _userConnection;
		private ChartHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}		
		
		public static ChartPointType GetChartPointType(EntitySchemaQuery esq, string aggregationColumnName, string groupByColumnName, DataValueTypeManager dataValueTypeManager) {

			var result = ChartPointType.None;
			
			var type1 = GetType(esq, groupByColumnName, dataValueTypeManager);
			var type2 = GetType(esq, aggregationColumnName, dataValueTypeManager);
			
			if (type1 == null || type2 == null) {
				return result;
			}
			
			if (IsValueTypeNumeric(type1) && IsValueTypeNumeric(type2)) {
				result = ChartPointType.Double_Double;				
			}
			else {
				if (IsValueTypeNumeric(type1) && IsValueTypeDateTime(type2)) {
					result = ChartPointType.Double_DateTime;
				}
				else {
					result = ChartPointType.String_Double;
				}
			}	

			
			/*
			if (esq == null 
					|| string.IsNullOrEmpty(aggregationColumnName)
					|| string.IsNullOrEmpty(groupByColumnName)) {
				return ChartPointType.None;
			}
			
			var firstColumn = esq.AddColumn(groupByColumnName);
			var type1 = firstColumn.GetResultDataValueType(dataValueTypeManager);
			var secondColumn = esq.AddColumn(aggregationColumnName);			
			var type2 = secondColumn.GetResultDataValueType(dataValueTypeManager);
			
			var result = ChartPointType.None;
			if (IsValueTypeNumeric(type1.ValueType.Name) && IsValueTypeNumeric(type2.ValueType.Name)) {
				result = ChartPointType.Double_Double;				
			}
			else {
				if (IsValueTypeNumeric(type1.ValueType.Name) && IsValueTypeDateTime(type2.ValueType.Name)) {
					result = ChartPointType.Double_DateTime;
				}
				else {
					result = ChartPointType.String_Double;
				}
			}	
			*/
			return result;
		}
		
		public static Type GetType(EntitySchemaQuery esq, string columnName, DataValueTypeManager dataValueTypeManager) {
			if (esq == null || string.IsNullOrEmpty(columnName)) {
				return null;
			}
			var column = esq.AddColumn(columnName);
			var type = column.GetResultDataValueType(dataValueTypeManager);
			return type.ValueType;//.Name;
		}
		
		private static bool IsValueTypeNumeric(Type valueType) {
			var value = valueType.Name;
			return value.Equals("Decimal") || value.Equals("Double")
				|| value.Equals("Byte") || value.Equals("Int16") || value.Equals("Int32") || value.Equals("Int64") 
				|| value.Equals("SByte") || value.Equals("UInt16") || value.Equals("UInt32") || value.Equals("UInt64")
				|| value.Equals("Single"); //|| value is BigInteger 
		}
		
		public static bool IsValueTypeDateTime(Type valueType) {
			if (valueType == null) {
				return false;
			}
			var value = valueType.Name;
			return value.Equals("DateTime");
		}
	}
}
