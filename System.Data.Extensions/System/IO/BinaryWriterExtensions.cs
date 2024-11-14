namespace System.IO
{
	using Data;

	/// <summary>
	/// BinaryWriter에 IRow, IColumn 을 기록하는 확장기능
	/// </summary>
	public static class BinaryWriterExtensions
	{
		/// <summary>
		/// BinaryWriter 에 IRow 데이터를 기록합니다.
		/// </summary>
		public static void Write(this BinaryWriter writer, DefaultRow row)
		{
			writer.Write(row.ColumnCount);
			foreach (string columnName in row.ColumnNames)
			{
				IColumn column = row.GetColumn(columnName);
				writer.WriteUTF8(columnName);
				writer.Write(column);
			}
		}

		/// <summary>
		/// BinaryWriter 에 IColumn 데이터를 기록합니다.
		/// </summary>
		public static void Write(this BinaryWriter writer, IColumn column)
		{
			writer.Write((int)column.Type);
			switch (column)
			{
				case SByteColumn col:
					writer.Write(col.Value);
					break;
				case ByteColumn col:
					writer.Write(col.Value);
					break;
				case Int16Column col:
					writer.Write(col.Value);
					break;
				case UInt16Column col:
					writer.Write(col.Value);
					break;
				case Int32Column col:
					writer.Write(col.Value);
					break;
				case UInt32Column col:
					writer.Write(col.Value);
					break;
				case Int64Column col:
					writer.Write(col.Value);
					break;
				case UInt64Column col:
					writer.Write(col.Value);
					break;
				case HalfColumn col:
					writer.Write(col.Value);
					break;
				case SingleColumn col:
					writer.Write(col.Value);
					break;
				case DoubleColumn col:
					writer.Write(col.Value);
					break;
				case DecimalColumn col:
					writer.Write(col.Value);
					break;
				case StringColumn col:
					writer.WriteUTF8(col.Value);
					break;
				case IPAddressColumn col:
					writer.Write(col.Value);
					break;
				case NullColumn:
					writer.Write('\0');
					break;
			}
		}
	}
}
