namespace System.Data
{
	using Net;

	/// <summary>
	/// Row 구현을 위한 인터페이스
	/// </summary>
	public interface IRow : IComparable<IRow>
	{
		/// <summary>
		/// Column 개수를 가져옵니다.
		/// </summary>
		int ColumnCount { get; }
		/// <summary>
		/// Column 명 목록을 가져옵니다.
		/// </summary>
		IEnumerable<string> ColumnNames { get; }
		/// <summary>
		/// 대상 Column의 형식을 가져옵니다.
		/// </summary>
		ColumnType GetColumnType(string columnName);
		/// <summary>
		/// 대상 Column을 가져옵니다. (없으면 null)
		/// </summary>
		IColumn GetColumn(string name);
		/// <summary>
		/// 대상 Column을 추가합니다.
		/// </summary>
		void SetColumn(string name, IColumn column);
		/// <summary>
		/// <see cref="System.SByte"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetSByte(string name, sbyte value);
		/// <summary>
		/// <see cref="System.Byte"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetByte(string name, byte value);
		/// <summary>
		/// <see cref="System.Int16"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetInt16(string name, short value);
		/// <summary>
		/// <see cref="System.UInt16"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetUInt16(string name, ushort value);
		/// <summary>
		/// <see cref="System.Int32"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetInt32(string name, int value);
		/// <summary>
		/// <see cref="System.UInt32"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetUInt32(string name, uint value);
		/// <summary>
		/// <see cref="System.Int64"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetInt64(string name, long value);
		/// <summary>
		/// <see cref="System.UInt64"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetUInt64(string name, ulong value);
		/// <summary>
		/// <see cref="System.Half"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetHalf(string name, Half value);
		/// <summary>
		/// <see cref="System.Single"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetSingle(string name, float value);
		/// <summary>
		/// <see cref="System.Double"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetDouble(string name, double value);
		/// <summary>
		/// <see cref="System.Decimal"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetDecimal(string name, decimal value);
		/// <summary>
		/// <see cref="System.String"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetString(string name, string value);
		/// <summary>
		/// <see cref="System.Net.IPAddress"/> 형식의 Column을 추가합니다.
		/// </summary>
		void SetIPAddress(string name, IPAddress value);
	}

	/// <summary>
	/// 기본 Row 구현체
	/// </summary>
	public sealed class DefaultRow : IRow
	{
		private readonly Dictionary<string, IColumn> columns = new Dictionary<string, IColumn>();

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int ColumnCount => columns.Count;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public IEnumerable<string> ColumnNames => columns.Keys;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IRow? other)
		{
			if (other is null)
				return 1;
			int compare = 0;
			foreach (string columnName in columns.Keys)
			{
				IColumn column = GetColumn(columnName);
				IColumn otherColumn = other.GetColumn(columnName);
				compare = column.CompareTo(otherColumn);
				if (compare != 0)
					return compare;
			}
			return compare;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public IColumn GetColumn(string name)
		{
			if (!columns.TryGetValue(name, out IColumn? column))
				return new NullColumn();
			return column;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType GetColumnType(string columnName)
		{
			IColumn? column = GetColumn(columnName);
			if (column is null)
				return ColumnType.NULL;
			return column.Type;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetColumn(string name, IColumn column)
		{
			if (!columns.TryAdd(name, column))
				columns[name] = column;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetSByte(string name, sbyte value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetByte(string name, byte value)
		{
			SetColumn(name, new ByteColumn(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetInt16(string name, short value)
		{
			SetColumn(name, new  Int16Column(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetUInt16(string name, ushort value)
		{
			SetColumn(name, new UInt16Column(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetInt32(string name, int value)
		{
			SetColumn(name, new Int32Column(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetUInt32(string name, uint value)
		{
			SetColumn(name, new UInt32Column(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetInt64(string name, long value)
		{
			SetColumn(name, new Int64Column(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetUInt64(string name, ulong value)
		{
			SetColumn(name, new UInt64Column(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetHalf(string name, Half value)
		{
			SetColumn(name, new HalfColumn(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetSingle(string name, float value)
		{
			SetColumn(name, new SingleColumn(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetDouble(string name, double value)
		{
			SetColumn(name, new DoubleColumn(value));
		}	

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetDecimal(string name, decimal value)
		{
			SetColumn(name, new DecimalColumn(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetString(string name, string value)
		{
			SetColumn(name, new StringColumn(value));
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void SetIPAddress(string name, IPAddress value)
		{
			SetColumn(name, new IPAddressColumn(value));
		}
	}
}
