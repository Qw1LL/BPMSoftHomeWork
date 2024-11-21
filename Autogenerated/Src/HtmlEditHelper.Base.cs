namespace BPMSoft.Configuration
{
	using System;
	using System.IO;
	using System.Text;
	using System.Web;
	using System.Drawing;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;	
	using BPMSoft.UI.WebControls;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.Configuration.FileUpload;
	using BPMSoft.Core.Factories;

	public static class HtmlEditHelper
	{
		#region Properties: Private

		private static Page Page {
			get {
				return HttpContext.Current.CurrentHandler as Page;
			}
		}

		private static ScriptManager ScriptManager {
			get {
				var scriptManager = Page.FindControl("ScriptManager") as ScriptManager;
				return scriptManager;
			}
		}

		#endregion

		#region Methods: Private

		private static string GetLocalizableStringValue(UserConnection userConnection, string localizableStringName) {
			var result = string.Empty;
			if (!string.IsNullOrEmpty(localizableStringName)) {
				string lsv = "LocalizableStrings." + localizableStringName + ".Value";
				var ls = new LocalizableString(
					//###, ####### ############# ###### # Workspace CR172513
					userConnection.Workspace.ResourceStorage, 
					"HtmlEditHelper", lsv);
				result = ls.ToString();
			}
			return result;
		}

		#endregion
		
		#region Methods: Public

		/// <summary>
		/// ######### ########### ## ###### "##### # ######" # ############ ###### ####### ###### ## ###########
		/// # ######## HtmlEdit ## #######
		/// </summary>
		/// <param name="userConnection">UserConnection ######## ############</param>
		/// <param name="htmlEdit">######## HtmlEdit</param>
		/// <param name="entitySchema">##### #######, # ####### ######### ###########</param>
		/// <param name="entityId">UId #######, # ####### ######### ###########</param>
		public static void SaveAndInsertImage(UserConnection userConnection, HtmlEdit htmlEdit, EntitySchema entitySchema, Guid entityId) {
			// ######### ####### #####
			if (Page.Request.Files.Count == 0) {
				return;
			}

			// ######## ##### ###### "##### # ######", #### ##### ##### ### - ###### ## ######
			EntitySchemaManager esm = userConnection.EntitySchemaManager;
			string fileSchemaName = entitySchema.Name + "File";
			EntitySchema fileEntitySchema = esm.FindInstanceByName(fileSchemaName);
			if (fileEntitySchema == null) {
				return;
			}

			string fileFieldName = htmlEdit.ClientID + "_loadedImage-file";
			HttpPostedFile file = Page.Request.Files[fileFieldName];
			string fileName = file.FileName;
			if (string.IsNullOrEmpty(fileName)) {
				return;
			}
			// ######## ###### #### ### ###### #####
			Stream fileStream = file.InputStream;
			fileStream.Position = 0;
			long fileSize = fileStream.Length;
			var fileData = new byte[fileStream.Length];
			fileStream.Read(fileData, 0, fileData.Length);
			
			var img = Image.FromStream(fileStream);
			
			if(GraphicUtilities.GetImageFormat(img.RawFormat) == null){
				var warning = GetLocalizableStringValue(userConnection, "Warning");
				var fileTypeError = GetLocalizableStringValue(userConnection, "FileTypeError");
				
				const string messageCallback = @" function() {{}} ";
				
				string showMessageScript = ClientScriptUtilities.GetMessageScript(warning, fileTypeError,
				MessageBoxButtons.Ok, MessageBoxIcon.Information, messageCallback);				
				ScriptManager.AddScript(showMessageScript);				
				return;
			}

			// crea Entity ### ###### ##### # ######### ##
			var fileUId = Guid.NewGuid(); 			 
			var fileRepository = ClassFactory.Get<FileRepository>(
						new ConstructorArgument("userConnection", userConnection));
			var fileEntityInfo = new FileEntityUploadInfo(fileSchemaName, fileUId, fileName);
			fileEntityInfo.ParentColumnName = entitySchema.Name;
			fileEntityInfo.ParentColumnValue = entityId;
			fileEntityInfo.TotalFileLength = fileData.Length;
			fileEntityInfo.Content = new MemoryStream(fileData);			
			fileRepository.UploadFile(fileEntityInfo);			  

			// ####### ###### ControlImage # ############## ###
			var controlImage = new ControlImage {
				// ###### ##### ###########. # ###### ###### ## Entity
				Source = ControlImageSource.EntityColumn,
				// ## ##### EntitySchema-# ##### ######## Entity
				SchemaUId = fileEntitySchema.UId,
				// ######### ####### (ID ######)
				EntityPrimaryColumnValue = fileUId,
				// ####### ## ####### ##### ######## ######. #### ###### #### UsePrimaryImageColumn, ######### ## ###########
				EntitySchemaColumnUId = fileEntitySchema.Columns.GetByName("Data").UId,
				UsePrimaryImageColumn = false
			};

			// ### ##### ######## ########## ###### ControlImage ###### ######## ##########.
			// ######### ###### ### ##### ##### ########### # ######### #######.
			// ## ###### ###### ## ###### ############## ############# ###### # ######## ### ## ######
			string controlImageValue = Json.Serialize(controlImage, new ControlImageJsonConverter());
			ScriptManager.AddScript(string.Format("{0}.insertImage({1})", htmlEdit.ClientID, controlImageValue));
			
			
		}


		/// <summary>
		/// ############ ########## ######, ###########, ##### ## ######### ######## ##### ########### ###########,
		/// # ######### ## ### #############
		/// </summary>
		/// <param name="userConnection">UserConnection ######## ############</param>
		/// <param name="htmlEdit">######## HtmlEdit</param>
		public static void RegisterDetailAddImageScript(UserConnection userConnection, HtmlEdit htmlEdit) {
			var script = "{0}.on('beforeimageadd', function(htmlEdit) {{ {1} }});";
			var sb = new StringBuilder();
			sb.Append(@"
				var needAddDetailRequest = Ext.decode(Ext.get('customDataField').dom.value)['needAddDetailRequest'];
				if (!needAddDetailRequest) {
					htmlEdit.showCreateImageWindow();
				} else {");
			const string messageCallback = @"
				function(btn) {{
					if (btn == 'yes') {{
						if (!Ext.FormValidator.validate()) {{
							return;
						}}
						var activeDataSource = window[Ext.decode(Ext.get('customDataField').dom.value)['SysModule_activeDataSource']];
						var onDatasourceSaved = function() {{
							htmlEdit.showCreateImageWindow();
							activeDataSource.un('saved', onDatasourceSaved, this);
						}};
						activeDataSource.on('saved', onDatasourceSaved, this);
						activeDataSource.save();
					}}
				}}";
			var warning = GetLocalizableStringValue(userConnection, "Warning");
			var newRecordNotSavedMessage = GetLocalizableStringValue(userConnection, "NewRecordNotSavedMessage");
			string showMessageScript = ClientScriptUtilities.GetMessageScript(warning, newRecordNotSavedMessage,
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, messageCallback);
			sb.Append(showMessageScript);
			sb.Append("}\n");
			script = string.Format(script, htmlEdit.ClientID, sb);
			ScriptManager.AddScript(script);
		}

		#endregion

		//GetImageFormat
		//GraphicUtilities
	}
}
