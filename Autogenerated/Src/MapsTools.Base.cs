using System;
using System.Text;
using BPMSoft.UI.WebControls.Controls;
using BPMSoft.Core.Process.Configuration;
using BPMSoft.Core;
using System.IO;
using System.Collections.Generic;
using System.Net;
using BPMSoft.Common;
using System.Globalization;
using Newtonsoft.Json;

[Serializable]
public class MapPoint {	
	public MapPointLocations Locations  { get; set; }
	public string Address { get; set; }
	public string Color { get; set; }
	public string InfoWindowHtml { get; set; }
	public string ObjectName { get; set; }
	
	// TODO: ######## ########### ############ ## ######### ### ###############, ### #### ###### ### ######## ########## ### ######### #####, 
	// ######### # ####### ###### ########## Json - 4.0.4.0 - ############ ### ############ ######## ########## # ########### ###########
	// ### #############. ######## ########## # ###### 4.0.8.0 
	// (http://james.newtonking.com/archive/2012/02/11/json-net-4-0-release-8-bug-fixes.aspx). 
	// ##### ########## ########## ##### ####### ####### ###### ####### ## ######### ##### 
	// # ######## ######### [JsonConstructor] ########### ########### ###########.	
	[JsonConstructor]
	public MapPoint () {}
	
	public MapPoint (string latitudeValue, string longitudeValue, string address = null, string infoWindowHtml = null, string color = null) {
		bool hasLocations = false;
		bool hasAddress = false;
		if (MapPointLocations.TryCheckParameters(latitudeValue, longitudeValue)) {
			Locations = new MapPointLocations(latitudeValue, longitudeValue);
			hasLocations = true;
		}
		if (!string.IsNullOrEmpty(address)) {
			Address = address;
			hasAddress = true;
		}		
		if (!hasLocations && !hasAddress) {
			throw new ArgumentException("Location parameters of the point of map is not correct");
		}
		if (!string.IsNullOrEmpty(infoWindowHtml)) {
			InfoWindowHtml = infoWindowHtml;
		}
		if (!string.IsNullOrEmpty(infoWindowHtml)) {
			Color = color;
		}		
	}	
}

[Serializable]
public class ObjectAddressInfo : MapPoint {
	public Guid UId { get; set; }	
	public string AddressType { get; set; }	
	public bool IsPrimary { get; set; } // TODO (#.########): #### ########, ### # #############, ##### ######## ##############, ######## #### #########
	
	// TODO: ######## ########### ############ ## ######### ### ###############, ### #### ###### ### ######## ########## ### ######### #####, 
	// ######### # ####### ###### ########## Json - 4.0.4.0 - ############ ### ############ ######## ########## # ########### ###########
	// ### #############. ######## ########## # ###### 4.0.8.0 
	// (http://james.newtonking.com/archive/2012/02/11/json-net-4-0-release-8-bug-fixes.aspx). 
	// ##### ########## ########## ##### ####### ####### ###### ####### ## ######### ##### 
	// # ######## ######### [JsonConstructor] ########### ########### ###########.
	[JsonConstructor]	
	public ObjectAddressInfo() {}
	
	public ObjectAddressInfo(Guid recordUId, string address, bool isPrimary = false, string addressType = null, string objectName = null, 
		string latitudeValue = null, string longitudeValue = null, string infoWindowHtml = null, string color = null) 
		: base (latitudeValue, longitudeValue, address, infoWindowHtml, color) 
	{
		UId = recordUId;
		IsPrimary = isPrimary; 
		AddressType = addressType;
		ObjectName = objectName;		
	}
	public ObjectAddressInfo(string address, bool isPrimary = false, string addressType = null, string objectName = null)
		: this(Guid.NewGuid(), address, isPrimary, addressType, objectName){}
	
	public override string ToString() {
		var sb = new StringBuilder();
		bool hasAddress = !string.IsNullOrEmpty(Address);
		bool hasObjectName = !string.IsNullOrEmpty(ObjectName);
		bool hasAddressType = !string.IsNullOrEmpty(AddressType);			
		if (hasObjectName) {
			sb.Append(ObjectName);			
		}		
		if (hasObjectName && hasAddressType) {
			sb.Append(", ");
		}		
		if (hasAddressType) {			
			sb.Append(AddressType);			
		}
		if (hasAddress && (hasObjectName || hasAddressType)) {			
			sb.Append(": ");
		}
		if (hasAddress) {
			sb.Append(Address);
		}
		return sb.ToString();
	}
}


[Serializable]
public class MapPointLocations { // TODO (#.########): ##### ## ####### ##### ######### # #########
	public string Latitude { get; protected set; }
	public string Longitude { get; protected set; }
	
	public MapPointLocations(string latitudeValue, string longitudeValue) {
		CheckParameters(latitudeValue, longitudeValue);		
		Latitude = latitudeValue;
		Longitude = longitudeValue;
	}
	
	private static void CheckParameters(string latitudeValue, string longitudeValue) { // TODO (#.########): ###### ########, # ## ########### ##########
		string exceptionText = "At least one of arguments is invalid";
		
		if (string.IsNullOrEmpty(latitudeValue)) {
			throw new ArgumentException(exceptionText, "latitudeValue");
		}		
		if (string.IsNullOrEmpty(longitudeValue)) {
			throw new ArgumentException(exceptionText, "longitudeValue");
		}
		
		var convertProvider = new NumberFormatInfo();
		convertProvider.NumberDecimalSeparator = ".";
		//convertProvider.NumberGroupSeparator = ".";
		//convertProvider.NumberGroupSizes = new int[ ] { 3 };
		
		try {
			Convert.ToDouble(latitudeValue.Replace(",", ".").Replace(" ", string.Empty), convertProvider);
		} catch (Exception) {
			throw new ArgumentException(exceptionText, "latitudeValue");
		}
		try {			
			Convert.ToDouble(longitudeValue.Replace(",", ".").Replace(" ", string.Empty), convertProvider);
		} catch (Exception) {
			throw new ArgumentException(exceptionText, "longitudeValue");
		}		
	}
	
	public static bool TryCheckParameters(string latitudeValue, string longitudeValue) {
		try {
			CheckParameters(latitudeValue, longitudeValue);
		} catch (Exception) {
			return false;
		}
		return true;		
	}
	
}

public class YandexMapsTools {

	public UserConnection UserConnection { get; }

	public YandexMapsTools(UserConnection userConnection) {
		UserConnection = userConnection;
		//_configurationTools = new ConfigurationTools(_userConnection);
		//_integrationTools = new IntegrationTools(_userConnection);
	}
	
	public string GetDirectionsPanelHtmlFunctionScript() {
		var sb = new StringBuilder();
		sb.AppendLine(
			@"function getDirectionsPanelHtml(route) {
				var way = route.getPaths().get(0),
					segments = way.getSegments(),
					moveList = '<table cellspacing = 10><tr><td></td><td align = center bgcolor = #EEE9E9><b>Трогаемся<b></td><td></td></tr>';
				for (var i = 0; i < segments.length; i++) {
					var street = segments[i].getStreet();
					moveList += '<tr>';
					moveList += '<td align=right>';
					moveList += (i + 1) + '.';
					moveList += '</td>';

					moveList += '<td>';
					moveList += ('Едем <b>' + segments[i].getHumanAction() + (street ? '</b> на <b>' + street : '') + '</b>');
					moveList += '</td>';

					moveList += '<td width=50>';
					var segLength = segments[i].getLength();
					if (segLength > 100) {
						moveList += (segments[i].getLength() / 1000).toFixed(1) + ' км';
					} else {
						moveList += (segments[i].getLength()).toFixed(0) + ' м';
					}
					moveList += '</td>';

					moveList += '</tr>';
				}
				moveList += '<tr><td></td><td align = center bgcolor = #EEE9E9><b>Останавливаемся.</b></td><td></td></tr>';
				moveList += '</table>';
				return moveList;
			}"		
		);		
		return sb.ToString();	
	}
	
	public string GetGetGeoObjectCollectionBoundsScript() {			
		return (
			@"function GetGeoObjectCollectionBounds(gObjects) {
				var iterator = gObjects.getIterator();
				var currPoint = iterator.getNext();
				var minXY;
				var maxXY;
				var isFirst;
				isFirst = true;
				do {
					var currPointXY = currPoint.geometry.getBounds()[0];
					var x = currPointXY[0];
					var y = currPointXY[1];
					if (isFirst) {
						isFirst = false;
						minXY = [x, y];
						maxXY = [x, y];
						if (gObjects.getLength() == 1) {
							break;
						}						
					} else {
						if (x < minXY[0]) {
							minXY[0] = x;
						} 
						if (x > maxXY[0]) {
							maxXY[0] = x;
						} 
						if (y < minXY[1]) {
							minXY[1] = y;
						} 
						if (y > maxXY[1]) {
							maxXY[1] = y;
						}
					}
					currPoint = iterator.getNext();
				} while (currPoint)
				return [minXY, maxXY];
			}");
	}
}

public class GoogleMapsTools {
	private readonly UserConnection _userConnection;
	private readonly ConfigurationTools _configurationTools;
	private readonly IntegrationTools _integrationTools;
	
	public UserConnection UserConnection {
		get {
			return _userConnection;
		}
	}
	
	public GoogleMapsTools(UserConnection userConnection) {
		_userConnection = userConnection;
		_configurationTools = new ConfigurationTools(_userConnection);
		_integrationTools = new IntegrationTools(_userConnection);
	}
	
	public string GetLocalizableStringValue(string localizableStringName) {
		var result = string.Empty;
		if (!string.IsNullOrEmpty(localizableStringName)) {
			string lsv = "LocalizableStrings." + localizableStringName + ".Value";		
			//###, ####### ############# ###### # Workspace CR173646
			var ls = new LocalizableString(UserConnection.Workspace.ResourceStorage, "MapsTools", lsv);
			result = ls.ToString();
		}
		return result;
	}
	
	public Dictionary<string, string> GetLocationsUsingGeocodingApi(string address, string googleMapsAPIKey, bool showWarnings) {
		// Use Geocoding API if you wish to geocode , known addresses. 
		// It requires Google Maps API Key.
		// If you don't want to use the key you can use Google Maps API. 
		// It provides a geocoder class for geocoding addresses dynamically from user input. 
		// But these requests are rate-limited to discourage abuse of the service.
		var result = new Dictionary<string, string>();
		var latitudeValue = "0";
		var longitudeValue = "0";
		var precision = 1;
		var zoom = 0;
		var httpCode = 0;
		if (!string.IsNullOrEmpty(address)) {
			var formattedAddress = GetFormattedAddress(address);
			bool useSensor = false;
			var googleMapsRequestParameters = new Dictionary<string, string> {
				{"q", formattedAddress},
				{"key", googleMapsAPIKey},
				{"sensor", useSensor.ToString()},
				{"output", "csv"},
				{"oe", "utf8"}
				//{"gl"} for using country code		
			};
			var googleMapsUri = "https://maps.google.com/maps/geo?"; // TODO (А.Шевченко): получать текущий протокол
			var googleMapsRequestParametersString = _integrationTools.GetHttpRequestParametersString(googleMapsRequestParameters);
			var requestUri = googleMapsUri + googleMapsRequestParametersString;
			var request = WebRequest.Create(requestUri) as HttpWebRequest;
			request.Method = "GET";
			request.Credentials = CredentialCache.DefaultCredentials;
			var asciiEncoding = new ASCIIEncoding();
			request.CookieContainer = new CookieContainer();
			string responseFromServer = null;
			using (var response = request.GetResponse() as HttpWebResponse) {
				using (Stream responseStream = response.GetResponseStream()) {
					Encoding encode = Encoding.GetEncoding("utf-8");
					using (var responseReader = new StreamReader(responseStream, encode)) {
						responseFromServer = responseReader.ReadToEnd();
					}
				}
			}
			if (!string.IsNullOrEmpty(responseFromServer)) {
				var httpCodePrecisionLatitudeLongitude = responseFromServer.Split(',');
				httpCode = int.Parse(httpCodePrecisionLatitudeLongitude[0]);
				if (httpCode == 200) {
					precision = int.Parse(httpCodePrecisionLatitudeLongitude[1]);
					latitudeValue = httpCodePrecisionLatitudeLongitude[2];
					longitudeValue = httpCodePrecisionLatitudeLongitude[3];
				}
			}
		}
		var precisionZoomDictionary = new Dictionary<int, int>() {
			{0, 1},	{1, 2},	{2, 5},	{3, 8},	{4, 11}, 
			{5, 12}, {6, 13}, {7, 14},	{8, 16}, {9, 18}
		};
		if (precision < 0) {
			zoom = 0;
		}
		if (precision > 9) {
			zoom = 18;
		}
		zoom = precisionZoomDictionary[precision];

		bool isResultCorrect = (httpCode == 200);
		if (!isResultCorrect && showWarnings) {
			ShowGeocodingApiHttpCodeMessage(GetLocalizableStringValue("PointIsNotLocatedError"), httpCode);
		}
		result.Add("Latitude", latitudeValue);
		result.Add("Longitude", longitudeValue);
		result.Add("Zoom", zoom.ToString());
		result.Add("Precision", precision.ToString());
		result.Add("ResultHttpCode", httpCode.ToString());
		return result;
	}
	
	public string GetShowGoogleMapsApiGeocodingResultCodeMessageScript() {
		var sb = new StringBuilder();
		var questionTask = new QuestionUserTask(UserConnection);
		var caption = questionTask.WarningCaption;
		sb.AppendLine("function ShowGoogleMapsApiGeocodingResultCodeMessage(mainMessageText, status) {");
			sb.AppendLine("var message = '';");
			sb.AppendLine("if (status == google.maps.GeocoderStatus.OK) { return; }");
			sb.AppendLine("else if (status == google.maps.GeocoderStatus.ZERO_RESULTS) { message = '" + GetLocalizableStringValue("UnknownAddressErrorCause") + "' ;} ");
			sb.AppendLine("else if (status == google.maps.GeocoderStatus.OVER_QUERY_LIMIT) { message = '" + GetLocalizableStringValue("TooManyQueriesErrorCause") + "' ;} ");
			sb.AppendLine("else if (status == google.maps.GeocoderStatus.REQUEST_DENIED) { message = '" + GetLocalizableStringValue("ServerErrorErrorCause") + "' ;} ");
			sb.AppendLine("else if (status == google.maps.GeocoderStatus.INVALID_REQUEST) { message = '" + GetLocalizableStringValue("MissingQueryErrorCause") + "' ;} ");
			sb.AppendLine("var warningMessageText = mainMessageText;");
			sb.AppendLine("if (message != '') { warningMessageText += ' (' + message + ')'; }");
			sb.AppendLine("Ext.MessageBox.message(");
			sb.AppendLine("'" + caption + "',");
			sb.AppendLine("warningMessageText,");
			sb.AppendLine("Ext.MessageBox.OK,");
			sb.AppendLine("Ext.MessageBox.WARNING,");
			sb.AppendLine("function(btn) {;}" + ",");
			sb.AppendLine("this");
			sb.AppendLine(");");
		sb.AppendLine("}");
		return sb.ToString();
	}
	
	public string GetShowGoogleMapsApiDirectionsResultCodeMessageScript() {
		var sb = new StringBuilder();
		var questionTask = new QuestionUserTask(UserConnection);
		var caption = questionTask.WarningCaption;
		sb.AppendLine("function ShowGoogleMapsApiDirectionsResultCodeMessage(mainMessageText, status) {");
			sb.AppendLine("var message = '';");
			sb.AppendLine("if (status == google.maps.DirectionsStatus.OK) { return; }");
			sb.AppendLine("else if (status == google.maps.DirectionsStatus.ZERO_RESULTS) { message = '" + GetLocalizableStringValue("DirectionsErrorZeroResultsCause") + "' ;} ");
			sb.AppendLine("else if (status == google.maps.DirectionsStatus.OVER_QUERY_LIMIT) { message = '" + GetLocalizableStringValue("TooManyQueriesErrorCause") + "' ;} ");
			sb.AppendLine("else if (status == google.maps.DirectionsStatus.REQUEST_DENIED) { message = '" + GetLocalizableStringValue("DirectionsErrorRequestDeniedCause") + "' ;} ");	
			sb.AppendLine("else if (status == google.maps.DirectionsStatus.MAX_WAYPOINTS_EXCEEDED) { message = '" + GetLocalizableStringValue("DirectionsErrorMaxWaypointsExceededCause") + "' ;} ");
			sb.AppendLine("else if (status == google.maps.DirectionsStatus.NOT_FOUND) { message = '" + GetLocalizableStringValue("DirectionsErrorNotFoundCause") + "' ;} ");
			sb.AppendLine("else if (status == google.maps.DirectionsStatus.UNKNOWN_ERROR) { message = '" + GetLocalizableStringValue("ServerErrorErrorCause") + "' ;} ");	
			sb.AppendLine("else if (status == google.maps.DirectionsStatus.INVALID_REQUEST) { message = '" + GetLocalizableStringValue("ServerErrorErrorCause") + "' ;} ");
			sb.AppendLine("var warningMessageText = mainMessageText;");
			sb.AppendLine("if (message != '') { warningMessageText += ' (' + message + ')'; }");
			sb.AppendLine("Ext.MessageBox.message(");
			sb.AppendLine("'" + caption + "',");
			sb.AppendLine("warningMessageText,");
			sb.AppendLine("Ext.MessageBox.OK,");
			sb.AppendLine("Ext.MessageBox.WARNING,");
			sb.AppendLine("function(btn) {;}" + ",");
			sb.AppendLine("this");
			sb.AppendLine(");");
		sb.AppendLine("}");
		return sb.ToString();
	}
	
	private void ShowGeocodingApiHttpCodeMessage(string mainMessageText, int resultHttpCode) {
		var resultHttpCodeErrorCauses = new Dictionary <int,string> {
			{0, GetLocalizableStringValue("NoServerResponseErrorCause")},
			{500, GetLocalizableStringValue("ServerErrorErrorCause")},
			{601, GetLocalizableStringValue("MissingQueryErrorCause")},
			{602, GetLocalizableStringValue("UnknownAddressErrorCause")},
			{603, GetLocalizableStringValue("UnavailableAddressErrorCause")},
			{610, GetLocalizableStringValue("BadKeyErrorCause")},
			{620, GetLocalizableStringValue("TooManyQueriesErrorCause")},
		};
		var warningMessage = mainMessageText;
		if (resultHttpCodeErrorCauses.ContainsKey(resultHttpCode)) {	
			warningMessage += " (" + resultHttpCodeErrorCauses[resultHttpCode] + ")";
		}
		var showMessageScript = _configurationTools.GetShowWarningMessageScript(warningMessage);
		var scriptManager = ((BPMSoft.UI.WebControls.Page)System.Web.HttpContext.Current.CurrentHandler).FindControl("ScriptManager") as ScriptManager;
		scriptManager.AddScript(showMessageScript);
	}
	
	private string GetFormattedAddress(string address) {
		var result = address;
		result = result.Replace(" ", "+");
		result = result.Replace(" ,", " ");
		return result;
	}
}
