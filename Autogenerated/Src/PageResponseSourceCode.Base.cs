using System;
using System.Text;
using System.Collections.Generic;
using System.Web;

namespace BPMSoft.Configuration
{
	public static class ContentType 
	{
		public static string StreamType = "APPLICATION/OCTET-STREAM";
		public static string XmlType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml";
	}
	public static class PageResponse 
	{
		public static void Write(HttpResponse response, byte[] data, string fileName, string contentType){
			response.AddHeader("Content-Disposition", "attachment; filename*=UTF-8''" + System.Web.HttpUtility.UrlPathEncode(fileName) + "");
			response.ContentType = contentType;
			response.AddHeader("Content-Length", data.Length.ToString());
			response.BinaryWrite(data);
			response.End();
		}
	}
}


