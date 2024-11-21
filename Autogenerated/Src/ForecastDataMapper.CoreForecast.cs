namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;

	/// <summary>
	/// Provides methods to map forecast data.
	/// </summary>
	public class ForecastDataMapper
	{
		#region Constants: Private

		private const string TreeNodesSeparator = "__EDGE__";

		#endregion

		#region Methods: Private

		private void FillColumnValues(ICollection<TableColumn> columns, Row row, TreeTableDataItem item) {
			foreach (TableColumn column in columns) {
				foreach (TableColumn child in column.Children) {
					var tableCell = new TableCell {
						ColumnCode = child.Code + "_" + column.Code,
						ColumnId = child.Id,
						GroupCode = column.Code,
						GroupId = column.Id,
						Id = child.Id,
						RecordId = row.Id
					};
					Cell cell = row.Cells?
						.FirstOrDefault(rowCell => rowCell.PeriodId.Equals(column.Id)
							&& rowCell.ColumnId.Equals(child.Id));
					if (cell != null) {
						tableCell.Value = (double)cell.Value;
						if (child.TypeId == ForecastConsts.ObjectValueColumnTypeId) {
							tableCell.HasRecords = true;
						}
					}
					item.ColumnValues.Add(tableCell);
				}
			}
		}

		private TreeTableDataItem GetTreeTableDataItem(Row row) {
			return new TreeTableDataItem {
				Id = row.Id.ToString(),
				RecordId = row.Id,
				Caption = row.Value,
				IsGroup = row.IsGroup,
				ColumnValues = new List<TableCell>()
			};
		}

		private string FormTableItemId(Guid[] parentsIds, Guid recordId) {
			if (parentsIds == null) {
				return recordId.ToString();
			}
			var idParts = parentsIds.Concat(new [] {recordId});
			return string.Join(TreeNodesSeparator, idParts);
		}

		#endregion

		#region Methods: Public

		/// <summary>Gets the map table columns.</summary>
		/// <param name="data">The forecast data.</param>
		/// <returns>Collection of <see cref="TableColumn"/></returns>
		public ICollection<TableColumn> GetMapTableColumns(ForecastData data) {
			var mapColumns = new List<TableColumn>();
			foreach (ColumnInfo column in data.Columns) {
				var periodCode = column.Period.Name.Replace(" ", "_");
				var item = mapColumns.FirstOrDefault(a => a.Code.Equals(periodCode));
				if (item == null) {
					item = new TableColumn {
						Id = column.Period.Id,
						Code = periodCode,
						Caption = column.Period.Name,
						Children = new List<TableColumn>(),
						IsFractionalPartHidden = column.IsFractionalPartHidden
					};
					mapColumns.Add(item);
				}
				item.Children.Add(new TableColumn {
					Id = column.Id,
					Code = column.Id.ToString(),
					Caption = column.Title,
					IsHide = column.IsHide,
					IsEditable = column.TypeId == ForecastConsts.EditableColumnTypeId,
					EditMode = column.EditMode,
					IsFractionalPartHidden = column.IsFractionalPartHidden,
					TypeId = column.TypeId
				});
			}
			return mapColumns;
		}

		/// <summary>Gets the map tree table data items.</summary>
		/// <param name="data">The forecast data.</param>
		/// <param name="columns">The forecast columns.</param>
		/// <returns>Collection of <see cref="TreeTableDataItem"/></returns>
		public ICollection<TreeTableDataItem> GetMapTreeTableDataItems(ForecastData data,
			   ICollection<TableColumn> columns) {
			var mapSourceData = new List<TreeTableDataItem>();
			foreach (Row row in data.Rows) {
				var item = GetTreeTableDataItem(row);
				FillColumnValues(columns, row, item);
				mapSourceData.Add(item);
			}
			return mapSourceData;
		}

		/// <summary>
		/// Forms TreeTableDataItem collection from table cells.
		/// </summary>
		/// <param name="cells">Table cells.</param>
		/// <param name="parentsIds">Table record's parents.</param>
		/// <returns></returns>
		public ICollection<TreeTableDataItem> GetMapTreeTableDataItems(IEnumerable<TableCell> cells,
				Guid[] parentsIds = null) {
			var rows = cells.GroupBy(cell => cell.RecordId).Select(grpCells => new TreeTableDataItem {
				Id = FormTableItemId(parentsIds, grpCells.Key),
				RecordId = grpCells.Key,
				ColumnValues = grpCells.ToList()
			}).ToList();
			return rows;
		}

		#endregion
	}

}

