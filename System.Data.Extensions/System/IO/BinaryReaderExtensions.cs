namespace System.IO
{
	using Data;

	/// <summary>
	/// BinaryReader 로 부터 IRow, IColumn 을 읽어오는 확장기능
	/// </summary>
	public static class BinaryReaderExtensions
	{
		/// <summary>
		/// BinaryReader 로 부터 IRow 를 읽어옵니다.
		/// </summary>
		public static T ReadRow<T>(this BinaryReader reader) where T : IRow, new()
		{
			T row = new();
			int columnCount = reader.ReadInt32();
			for (int index = 0; index <columnCount; index++)
			{
				string columnName = reader.ReadUTF8();
				IColumn column = reader.ReadColumn();
				row.SetColumn(columnName, column);
			}
			return row;
		}

		/// <summary>
		/// BinaryReader 로 부터 IColumn 을 읽어옵니다.
		/// </summary>
		public static IColumn ReadColumn(this BinaryReader reader)
		{
			ColumnType type = (ColumnType)reader.ReadInt32();
			switch (type)
			{
				case ColumnType.SByte:
					return new SByteColumn(reader.ReadSByte());
				case ColumnType.Byte:
					return new ByteColumn(reader.ReadByte());
				case ColumnType.Int16:
					return new Int16Column(reader.ReadInt16());
				case ColumnType.UInt16:
					return new UInt16Column(reader.ReadUInt16());
				case ColumnType.Int32:
					return new Int32Column(reader.ReadInt32());
				case ColumnType.UInt32:
					return new UInt32Column(reader.ReadUInt32());
				case ColumnType.Int64:
					return new Int64Column(reader.ReadInt64());
				case ColumnType.UInt64:
					return new UInt64Column(reader.ReadUInt64());
				case ColumnType.Half:
					return new HalfColumn(reader.ReadHalf());
				case ColumnType.Single:
					return new SingleColumn(reader.ReadSingle());
				case ColumnType.Double:
					return new DoubleColumn(reader.ReadDouble());
				case ColumnType.Decimal:
					return new DecimalColumn(reader.ReadDecimal());
				case ColumnType.String:
					return new StringColumn(reader.ReadUTF8());
				case ColumnType.IPAddress:
					return new IPAddressColumn(reader.ReadIPAddress());
				default:
					return new NullColumn();
			}
		}
	}
}
